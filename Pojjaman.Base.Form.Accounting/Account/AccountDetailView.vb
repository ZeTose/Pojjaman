Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.TextHelper
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Imports System.Reflection
Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.Gui.Panels
Imports Longkong.Pojjaman.Gui
Namespace Longkong.Pojjaman.Gui.Panels
  Public Class AccountDetailView
    Inherits AbstractEntityDetailPanelView
    Implements IValidatable

#Region "Members"
    Private m_entity As Account
    Private m_isInitialized As Boolean = False
    Private m_treeManager As TreeManager
#End Region

#Region "Properties"
    Public ReadOnly Property ACCBColl() As ACCBudgetCollection
      Get
        For Each ext As IExtender In m_entity.Extenders
          If TypeOf ext Is ACCBudgetCollection Then
            Return CType(ext, ACCBudgetCollection)
          End If
        Next
        Return New ACCBudgetCollection(Me.m_entity)
      End Get
    End Property
#End Region

#Region "Constructor"
    Public Sub New()
      MyBase.New()
      Me.InitializeComponent()
      Me.SetLabelText()
      Initialize()

      Dim dt As TreeTable = Me.GetSchemaTable
      Dim dst As DataGridTableStyle = Me.CreateTableStyle2
      m_treeManager = New TreeManager(dt, tgBudget)
      m_treeManager.SetTableStyle(dst)
      m_treeManager.AllowSorting = False
      m_treeManager.AllowDelete = False

      AddHandler dt.ColumnChanging, AddressOf Treetable_ColumnChanging
      AddHandler dt.ColumnChanged, AddressOf Treetable_ColumnChanged

      UpdateEntityProperties()
      EventWiring()
      LoopControl(Me)
    End Sub
#End Region

#Region "Style"
    Public Shared Function GetSchemaTable() As TreeTable
      Dim myDatatable As New TreeTable("ACCBudget")
      'myDatatable.Columns.Add(New DataColumn("selected", GetType(Boolean)))
      myDatatable.Columns.Add(New DataColumn("linenumber", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("Name", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("StartDate", GetType(Date)))
      myDatatable.Columns.Add(New DataColumn("EndDate", GetType(Date)))
      myDatatable.Columns.Add(New DataColumn("Budget", GetType(Decimal)))
      Return myDatatable
    End Function

    Public Function CreateTableStyle2() As DataGridTableStyle
      Dim dst As New DataGridTableStyle
      dst.MappingName = "ACCBudget"
      Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)

      Dim csLineNumber As New TreeTextColumn
      csLineNumber.MappingName = "linenumber"
      csLineNumber.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AccBudget.LineNumberHeaderText}")
      csLineNumber.NullText = ""
      csLineNumber.Width = 30
      csLineNumber.DataAlignment = HorizontalAlignment.Center
      csLineNumber.ReadOnly = True
      csLineNumber.TextBox.Name = "linenumber"

      Dim csName As New TreeTextColumn
      csName.MappingName = "Name"
      csName.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AccBudget.NameHeaderText}")
      csName.NullText = ""
      csName.ReadOnly = False
      csName.TextBox.Name = "Name"

      Dim csStart As New DataGridTimePickerColumn
      csStart.MappingName = "StartDate"
      csStart.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AccBudget.StartHeaderText}")
      csStart.NullText = ""
      csStart.Width = 75
      csStart.ReadOnly = False

      Dim csEnd As New DataGridTimePickerColumn
      csEnd.MappingName = "EndDate"
      csEnd.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AccBudget.EndHeaderText}")
      csEnd.NullText = ""
      csEnd.Width = 75
      csEnd.ReadOnly = False

      Dim csBudget As New TreeTextColumn
      csBudget.MappingName = "Budget"
      csBudget.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AccBudget.BudgetHeaderText}")
      csBudget.NullText = ""
      csBudget.Width = 75
      csBudget.DataAlignment = HorizontalAlignment.Right
      csBudget.Alignment = HorizontalAlignment.Right
      csBudget.TextBox.Name = "Budget"
      csBudget.ReadOnly = False

      dst.GridColumnStyles.Add(csLineNumber)
      dst.GridColumnStyles.Add(csName)
      dst.GridColumnStyles.Add(csStart)
      dst.GridColumnStyles.Add(csEnd)
      dst.GridColumnStyles.Add(csBudget)
      Return dst
    End Function
    Private Sub RefreshACCBudget()

      Dim dt As TreeTable = Me.m_treeManager.Treetable
      dt.Clear()

      m_isInitialized = False
      Me.ACCBColl.Populate(dt)
      m_isInitialized = True
    End Sub
#End Region

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
    Friend WithEvents lblAltName As System.Windows.Forms.Label
    Friend WithEvents lblCode As System.Windows.Forms.Label
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents txtAltName As System.Windows.Forms.TextBox
    Friend WithEvents txtCode As System.Windows.Forms.TextBox
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents lblParent As System.Windows.Forms.Label
    Friend WithEvents txtParent As System.Windows.Forms.TextBox
    Friend WithEvents chkControl As System.Windows.Forms.CheckBox
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
    Friend WithEvents cmbType As System.Windows.Forms.ComboBox
    Friend WithEvents lblType As System.Windows.Forms.Label
    Friend WithEvents tgBudget As Longkong.Pojjaman.Gui.Components.TreeGrid
    Friend WithEvents lblBudgetList As System.Windows.Forms.Label
    Friend WithEvents ibtnBlankBudget As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents ibtnDelBudget As Longkong.Pojjaman.Gui.Components.ImageButton
    <System.Diagnostics.DebuggerStepThrough()> Protected Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container
      Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(AccountDetailView))
      Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
      Me.cmbType = New System.Windows.Forms.ComboBox
      Me.chkControl = New System.Windows.Forms.CheckBox
      Me.lblParent = New System.Windows.Forms.Label
      Me.txtParent = New System.Windows.Forms.TextBox
      Me.lblAltName = New System.Windows.Forms.Label
      Me.txtAltName = New System.Windows.Forms.TextBox
      Me.txtCode = New System.Windows.Forms.TextBox
      Me.lblCode = New System.Windows.Forms.Label
      Me.lblName = New System.Windows.Forms.Label
      Me.txtName = New System.Windows.Forms.TextBox
      Me.lblType = New System.Windows.Forms.Label
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider
      Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
      Me.tgBudget = New Longkong.Pojjaman.Gui.Components.TreeGrid
      Me.lblBudgetList = New System.Windows.Forms.Label
      Me.ibtnBlankBudget = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.ibtnDelBudget = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.grbDetail.SuspendLayout()
      CType(Me.tgBudget, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'grbDetail
      '
      Me.grbDetail.Controls.Add(Me.cmbType)
      Me.grbDetail.Controls.Add(Me.chkControl)
      Me.grbDetail.Controls.Add(Me.lblParent)
      Me.grbDetail.Controls.Add(Me.txtParent)
      Me.grbDetail.Controls.Add(Me.lblAltName)
      Me.grbDetail.Controls.Add(Me.txtAltName)
      Me.grbDetail.Controls.Add(Me.txtCode)
      Me.grbDetail.Controls.Add(Me.lblCode)
      Me.grbDetail.Controls.Add(Me.lblName)
      Me.grbDetail.Controls.Add(Me.txtName)
      Me.grbDetail.Controls.Add(Me.lblType)
      Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbDetail.Location = New System.Drawing.Point(16, 16)
      Me.grbDetail.Name = "grbDetail"
      Me.grbDetail.Size = New System.Drawing.Size(448, 160)
      Me.grbDetail.TabIndex = 0
      Me.grbDetail.TabStop = False
      Me.grbDetail.Text = "รายละเอียด"
      '
      'cmbType
      '
      Me.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbType.Location = New System.Drawing.Point(112, 120)
      Me.cmbType.Name = "cmbType"
      Me.cmbType.Size = New System.Drawing.Size(248, 24)
      Me.cmbType.TabIndex = 128
      '
      'chkControl
      '
      Me.chkControl.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.chkControl.Location = New System.Drawing.Point(224, 25)
      Me.chkControl.Name = "chkControl"
      Me.chkControl.Size = New System.Drawing.Size(136, 20)
      Me.chkControl.TabIndex = 2
      Me.chkControl.Text = "เป็นบัญชีคุม"
      '
      'lblParent
      '
      Me.lblParent.Location = New System.Drawing.Point(8, 96)
      Me.lblParent.Name = "lblParent"
      Me.lblParent.Size = New System.Drawing.Size(104, 20)
      Me.lblParent.TabIndex = 127
      Me.lblParent.Text = "อยู่ภายใต้ผังบัญชี:"
      Me.lblParent.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtParent
      '
      Me.txtParent.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtParent, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtParent, "")
      Me.Validator.SetGotFocusBackColor(Me.txtParent, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtParent, System.Drawing.Color.Empty)
      Me.txtParent.Location = New System.Drawing.Point(112, 96)
      Me.Validator.SetMaxValue(Me.txtParent, "")
      Me.Validator.SetMinValue(Me.txtParent, "")
      Me.txtParent.Name = "txtParent"
      Me.txtParent.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtParent, "")
      Me.Validator.SetRequired(Me.txtParent, False)
      Me.txtParent.Size = New System.Drawing.Size(248, 22)
      Me.txtParent.TabIndex = 5
      Me.txtParent.Text = ""
      '
      'lblAltName
      '
      Me.lblAltName.Location = New System.Drawing.Point(24, 72)
      Me.lblAltName.Name = "lblAltName"
      Me.lblAltName.Size = New System.Drawing.Size(88, 20)
      Me.lblAltName.TabIndex = 124
      Me.lblAltName.Text = "ชื่ออื่น:"
      Me.lblAltName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtAltName
      '
      Me.txtAltName.BackColor = System.Drawing.SystemColors.Window
      Me.Validator.SetDataType(Me.txtAltName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtAltName, "")
      Me.Validator.SetGotFocusBackColor(Me.txtAltName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtAltName, System.Drawing.Color.Empty)
      Me.txtAltName.Location = New System.Drawing.Point(112, 72)
      Me.Validator.SetMaxValue(Me.txtAltName, "")
      Me.Validator.SetMinValue(Me.txtAltName, "")
      Me.txtAltName.Name = "txtAltName"
      Me.Validator.SetRegularExpression(Me.txtAltName, "")
      Me.Validator.SetRequired(Me.txtAltName, False)
      Me.txtAltName.Size = New System.Drawing.Size(248, 22)
      Me.txtAltName.TabIndex = 4
      Me.txtAltName.Text = ""
      '
      'txtCode
      '
      Me.txtCode.BackColor = System.Drawing.SystemColors.Window
      Me.Validator.SetDataType(Me.txtCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtCode, "")
      Me.Validator.SetGotFocusBackColor(Me.txtCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtCode, System.Drawing.Color.Empty)
      Me.txtCode.Location = New System.Drawing.Point(112, 24)
      Me.Validator.SetMaxValue(Me.txtCode, "")
      Me.Validator.SetMinValue(Me.txtCode, "")
      Me.txtCode.Name = "txtCode"
      Me.Validator.SetRegularExpression(Me.txtCode, "")
      Me.Validator.SetRequired(Me.txtCode, True)
      Me.txtCode.Size = New System.Drawing.Size(84, 22)
      Me.txtCode.TabIndex = 0
      Me.txtCode.Text = ""
      '
      'lblCode
      '
      Me.lblCode.Location = New System.Drawing.Point(24, 24)
      Me.lblCode.Name = "lblCode"
      Me.lblCode.Size = New System.Drawing.Size(88, 20)
      Me.lblCode.TabIndex = 123
      Me.lblCode.Text = "รหัส:"
      Me.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblName
      '
      Me.lblName.Location = New System.Drawing.Point(24, 48)
      Me.lblName.Name = "lblName"
      Me.lblName.Size = New System.Drawing.Size(88, 20)
      Me.lblName.TabIndex = 122
      Me.lblName.Text = "ชื่อ:"
      Me.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtName
      '
      Me.txtName.BackColor = System.Drawing.SystemColors.Window
      Me.Validator.SetDataType(Me.txtName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtName, "")
      Me.Validator.SetGotFocusBackColor(Me.txtName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtName, System.Drawing.Color.Empty)
      Me.txtName.Location = New System.Drawing.Point(112, 48)
      Me.Validator.SetMaxValue(Me.txtName, "")
      Me.Validator.SetMinValue(Me.txtName, "")
      Me.txtName.Name = "txtName"
      Me.Validator.SetRegularExpression(Me.txtName, "")
      Me.Validator.SetRequired(Me.txtName, True)
      Me.txtName.Size = New System.Drawing.Size(248, 22)
      Me.txtName.TabIndex = 3
      Me.txtName.Text = ""
      '
      'lblType
      '
      Me.lblType.Location = New System.Drawing.Point(8, 120)
      Me.lblType.Name = "lblType"
      Me.lblType.Size = New System.Drawing.Size(104, 20)
      Me.lblType.TabIndex = 127
      Me.lblType.Text = "หมวด:"
      Me.lblType.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
      'tgBudget
      '
      Me.tgBudget.AllowNew = False
      Me.tgBudget.AllowSorting = False
      Me.tgBudget.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.tgBudget.AutoColumnResize = True
      Me.tgBudget.CaptionVisible = False
      Me.tgBudget.Cellchanged = False
      Me.tgBudget.DataMember = ""
      Me.tgBudget.HeaderForeColor = System.Drawing.SystemColors.ControlText
      Me.tgBudget.Location = New System.Drawing.Point(16, 208)
      Me.tgBudget.Name = "tgBudget"
      Me.tgBudget.Size = New System.Drawing.Size(448, 96)
      Me.tgBudget.SortingArrowColor = System.Drawing.Color.Red
      Me.tgBudget.TabIndex = 215
      Me.tgBudget.TreeManager = Nothing
      '
      'lblBudgetList
      '
      Me.lblBudgetList.BackColor = System.Drawing.Color.Transparent
      Me.lblBudgetList.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblBudgetList.ForeColor = System.Drawing.SystemColors.ControlText
      Me.lblBudgetList.Location = New System.Drawing.Point(16, 184)
      Me.lblBudgetList.Name = "lblBudgetList"
      Me.lblBudgetList.Size = New System.Drawing.Size(168, 18)
      Me.lblBudgetList.TabIndex = 216
      Me.lblBudgetList.Text = "งบแผนก:"
      Me.lblBudgetList.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'ibtnBlankBudget
      '
      Me.ibtnBlankBudget.Image = CType(resources.GetObject("ibtnBlankBudget.Image"), System.Drawing.Image)
      Me.ibtnBlankBudget.Location = New System.Drawing.Point(464, 208)
      Me.ibtnBlankBudget.Name = "ibtnBlankBudget"
      Me.ibtnBlankBudget.Size = New System.Drawing.Size(24, 24)
      Me.ibtnBlankBudget.TabIndex = 218
      Me.ibtnBlankBudget.TabStop = False
      Me.ibtnBlankBudget.ThemedImage = CType(resources.GetObject("ibtnBlankBudget.ThemedImage"), System.Drawing.Bitmap)
      '
      'ibtnDelBudget
      '
      Me.ibtnDelBudget.Image = CType(resources.GetObject("ibtnDelBudget.Image"), System.Drawing.Image)
      Me.ibtnDelBudget.Location = New System.Drawing.Point(464, 232)
      Me.ibtnDelBudget.Name = "ibtnDelBudget"
      Me.ibtnDelBudget.Size = New System.Drawing.Size(24, 24)
      Me.ibtnDelBudget.TabIndex = 217
      Me.ibtnDelBudget.TabStop = False
      Me.ibtnDelBudget.ThemedImage = CType(resources.GetObject("ibtnDelBudget.ThemedImage"), System.Drawing.Bitmap)
      '
      'AccountDetailView
      '
      Me.Controls.Add(Me.ibtnBlankBudget)
      Me.Controls.Add(Me.ibtnDelBudget)
      Me.Controls.Add(Me.tgBudget)
      Me.Controls.Add(Me.lblBudgetList)
      Me.Controls.Add(Me.grbDetail)
      Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Name = "AccountDetailView"
      Me.Size = New System.Drawing.Size(520, 328)
      Me.grbDetail.ResumeLayout(False)
      CType(Me.tgBudget, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Methods"

#End Region

#Region "IListDetail"
    Public Overrides Sub CheckFormEnable()
      cmbType.Enabled = False
      If Not Me.m_entity.Originated Then
        If Me.m_entity.Parent Is Nothing OrElse Not Me.m_entity.Parent.Originated Then
          cmbType.Enabled = True
        End If
      End If
    End Sub
    Public Overrides Property Entity() As ISimpleEntity
      Get
        Return Me.m_entity
      End Get
      Set(ByVal Value As ISimpleEntity)
        Me.m_entity = Nothing
        Me.m_entity = CType(Value, Account)
        Dim parentAcct As Account = CType(Me.m_entity.Parent, Account)
        'Hack:
        Me.m_entity.OnTabPageTextChanged(m_entity, EventArgs.Empty)
        UpdateEntityProperties()
      End Set
    End Property

    Public Overrides Sub ClearDetail()
      txtCode.Text = ""
      txtName.Text = ""
      txtAltName.Text = ""
      chkControl.Checked = False
      cmbType.SelectedIndex = -1
      m_treeManager.Treetable.Clear()
    End Sub
    Public Overrides Sub Initialize()
      AccountType.ListCodeDescriptionInComboBox(Me.cmbType, "acct_type")
    End Sub

    Public Overrides Sub SetLabelText()
      If Not Me.m_entity Is Nothing Then
        Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
      End If
      Me.lblCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AccountDetailView.lblCode}")
      Me.Validator.SetDisplayName(Me.txtCode, Me.lblCode.Text.TrimEnd(":".ToCharArray))
      Me.lblName.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AccountDetailView.lblName}")
      Me.Validator.SetDisplayName(Me.txtName, Me.lblName.Text.TrimEnd(":".ToCharArray))
      Me.lblAltName.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AccountDetailView.lblAltName}")
      Me.Validator.SetDisplayName(Me.txtAltName, Me.lblAltName.Text.TrimEnd(":".ToCharArray))
      Me.lblParent.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AccountDetailView.lblParent}")
      Me.Validator.SetDisplayName(Me.txtParent, Me.lblParent.Text.TrimEnd(":".ToCharArray))
      Me.chkControl.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AccountDetailView.chkControl}")
      Me.lblType.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AccountDetailView.lblType}")
      Me.grbDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AccountDetailView.grbDetail}")
      Me.lblBudgetList.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AccountDetailView.lblBudgetList}")
    End Sub

    Protected Overrides Sub EventWiring()
      AddHandler txtCode.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtName.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtAltName.TextChanged, AddressOf Me.ChangeProperty
      AddHandler chkControl.CheckedChanged, AddressOf Me.ChangeProperty
      AddHandler cmbType.SelectedIndexChanged, AddressOf Me.ChangeProperty
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
        Me.txtParent.Text = Me.StringParserService.Parse("${res:Global.TreeRoot}")
      End If
      If Me.m_entity.IsControlGroup Then
        chkControl.Checked = True
      Else
        chkControl.Checked = False
      End If

      For Each item As IdValuePair In Me.cmbType.Items
        If Not Me.m_entity.Type Is Nothing AndAlso Me.m_entity.Type.Value = item.Id Then
          Me.cmbType.SelectedItem = item
        End If
      Next

      RefreshACCBudget()

      SetLabelText()
      CheckFormEnable()
      m_isInitialized = True
    End Sub
    Public Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)
      If Me.m_entity Is Nothing Or Not m_isInitialized Then
        Return
      End If
      Select Case CType(sender, Control).Name.ToLower
        Case "txtcode"
          Me.m_entity.Code = txtCode.Text
        Case "txtname"
          Me.m_entity.Name = txtName.Text
        Case "txtaltname"
          Me.m_entity.AlternateName = txtAltName.Text
        Case "chkcontrol"
          Me.m_entity.IsControlGroup = chkControl.Checked
        Case "cmbtype"
          Dim item As IdValuePair = CType(Me.cmbType.SelectedItem, IdValuePair)
          Me.m_entity.Type = New AccountType(item.Id)
      End Select
      Me.WorkbenchWindow.ViewContent.IsDirty = True
      CheckFormEnable()
    End Sub
#End Region

#Region "Event"

#End Region

#Region "IValidatable"
    Public ReadOnly Property FormValidator() As components.PJMTextboxValidator Implements IValidatable.FormValidator
      Get
        Return Me.Validator
      End Get
    End Property
#End Region

#Region "Overides"
    Public Overrides ReadOnly Property TabPageIcon() As String
      Get
        Return (New Account).DetailPanelIcon
      End Get
    End Property
#End Region

#Region "TreeTable Handlers"
    Private Sub Treetable_ColumnChanged(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs)
      If Not m_isInitialized Then
        Return
      End If

      Dim index As Integer = Me.m_treeManager.Treetable.Childs.IndexOf(CType(e.Row, TreeRow))
      If ValidateRow(CType(e.Row, TreeRow)) Then
        Me.m_treeManager.Treetable.AcceptChanges()
      End If
      Dim currIndex As Integer = Me.tgBudget.CurrentRowIndex
      RefreshACCBudget()
      tgBudget.CurrentRowIndex = currIndex
      Me.WorkbenchWindow.ViewContent.IsDirty = True
    End Sub
    Private Sub Treetable_ColumnChanging(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs)
      If Not m_isInitialized Then
        Return
      End If
      Try
        Select Case e.Column.ColumnName.ToLower
          Case "name"
            SetName(e)
          Case "startdate"
            If Not IsDBNull(e.ProposedValue) Then
              SetStartDate(e)
            End If
          Case "enddate"
            If Not IsDBNull(e.ProposedValue) Then
              SetEndDate(e)
            End If
          Case "budget"
            SetBudget(e)
        End Select
        ValidateRow(e)
      Catch ex As Exception
        MessageBox.Show(ex.ToString)
      End Try
    End Sub
    Public Sub ValidateRow(ByVal e As DataColumnChangeEventArgs)

      Dim name As Object = e.Row("Name")
      Dim stdate As Object = e.Row("StartDate")
      Dim eddate As Object = e.Row("EndDate")
      Dim budget As Object = e.Row("Budget")

      Select Case e.Column.ColumnName.ToLower
        Case "name"
          name = e.ProposedValue
        Case "startdate"
          stdate = e.ProposedValue
        Case "enddate"
          eddate = e.ProposedValue
        Case "budget"
          budget = e.ProposedValue
        Case Else
          Return
      End Select

      'Dim isBlankRow As Boolean = False
      'If IsDBNull(name) Then
      '    isBlankRow = True
      'End If

      'If Not isBlankRow Then
      If IsDBNull(name) Then
        e.Row.SetColumnError("Name", "")
      End If
      If IsDBNull(stdate) Then
        e.Row.SetColumnError("StartDate", "")
      End If
      If IsDBNull(eddate) Then
        e.Row.SetColumnError("Enddate", "")
      End If
      'If IsDBNull(budget) OrElse CDec(budget) <= 0 Then
      '    e.Row.SetColumnError("percent", Me.StringParserService.Parse("${res:Global.Error.PercentMissing}"))
      'Else
      e.Row.SetColumnError("Budget", "")
      'End If

      'End If

    End Sub
    Public Function ValidateRow(ByVal row As TreeRow) As Boolean
      If row.IsNull("Budget") Then
        Return False
      End If
      Return True
    End Function
    Private m_updating As Boolean = False
    Public Sub SetName(ByVal e As System.Data.DataColumnChangeEventArgs)
      If m_updating Then
        Return
      End If
      Dim item As Longkong.Pojjaman.BusinessLogic.ACCBudget = Me.CurrentCCBudget
      If item Is Nothing Then
        Return
      End If
      m_updating = True
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      item.Name = e.ProposedValue.ToString
      m_updating = False
    End Sub
    Public Sub SetStartDate(ByVal e As System.Data.DataColumnChangeEventArgs)
      If m_updating Then
        Return
      End If
      Dim item As Longkong.Pojjaman.BusinessLogic.ACCBudget = Me.CurrentCCBudget
      If item Is Nothing Then
        Return
      End If
      m_updating = True
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      item.StartDate = CDate(e.ProposedValue).ToShortDateString
      m_updating = False
    End Sub
    Public Sub SetEndDate(ByVal e As System.Data.DataColumnChangeEventArgs)
      If m_updating Then
        Return
      End If
      Dim item As Longkong.Pojjaman.BusinessLogic.ACCBudget = Me.CurrentCCBudget
      If item Is Nothing Then
        Return
      End If
      m_updating = True
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      item.EndDate = CDate(e.ProposedValue).ToShortDateString
      m_updating = False
    End Sub
    Public Sub SetBudget(ByVal e As System.Data.DataColumnChangeEventArgs)
      If m_updating Then
        Return
      End If
      Dim item As Longkong.Pojjaman.BusinessLogic.ACCBudget = Me.CurrentCCBudget
      If item Is Nothing Then
        Return
      End If
      m_updating = True
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      item.Budget = Configuration.FormatToString(e.ProposedValue, DigitConfig.Price)
      m_updating = False
    End Sub
    Private ReadOnly Property CurrentCCBudget() As Longkong.Pojjaman.BusinessLogic.ACCBudget
      Get
        Dim row As TreeRow = Me.m_treeManager.SelectedRow
        If row Is Nothing Then
          Return Nothing
        End If
        Return CType(row.Tag, Longkong.Pojjaman.BusinessLogic.ACCBudget)
      End Get
    End Property
#End Region

    Private Sub ibtnBlankBudget_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnBlankBudget.Click
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      If Me.m_entity Is Nothing Then
        Return
      End If
      Dim dpm As New Pojjaman.BusinessLogic.ACCBudget
      dpm.StartDate = Now
      dpm.EndDate = Now
      Me.ACCBColl.Add(dpm)
      RefreshACCBudget()
      tgBudget.CurrentRowIndex = Me.ACCBColl.Count - 1
      Me.WorkbenchWindow.ViewContent.IsDirty = True
    End Sub
    Private Sub ibtnDelBudget_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnDelBudget.Click
      Dim item As Pojjaman.BusinessLogic.ACCBudget = Me.CurrentCCBudget
      If item Is Nothing Then
        Return
      End If
      Me.ACCBColl.Remove(item)
      RefreshACCBudget()
      Me.WorkbenchWindow.ViewContent.IsDirty = True
    End Sub
  End Class
End Namespace
