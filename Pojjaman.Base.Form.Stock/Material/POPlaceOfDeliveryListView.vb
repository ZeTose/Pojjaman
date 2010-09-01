Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.TextHelper
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Imports System.Reflection
Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.Services
Imports System.Drawing.Printing
Imports Longkong.Pojjaman.Gui.ReportsAndDocs
Imports System.Drawing
Imports System.Drawing.Drawing2D
Namespace Longkong.Pojjaman.Gui.Panels
  Public Class POPlaceOfDeliveryListView
    Inherits AbstractEntityPanelViewContent
    Implements IValidatable, ISimpleListPanel

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
    Friend WithEvents lblItem As System.Windows.Forms.Label
    Friend WithEvents tgItem As Longkong.Pojjaman.Gui.Components.TreeGrid
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
    Friend WithEvents ibtnBlank As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents ibtnDelRow As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtCode As System.Windows.Forms.TextBox
    Friend WithEvents lblCode As System.Windows.Forms.Label
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Protected Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(POPlaceOfDeliveryListView))
      Me.tgItem = New Longkong.Pojjaman.Gui.Components.TreeGrid()
      Me.lblItem = New System.Windows.Forms.Label()
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
      Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
      Me.txtCode = New System.Windows.Forms.TextBox()
      Me.ibtnBlank = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.ibtnDelRow = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.lblCode = New System.Windows.Forms.Label()
      Me.btnSearch = New System.Windows.Forms.Button()
      CType(Me.tgItem, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'tgItem
      '
      Me.tgItem.AllowNew = False
      Me.tgItem.AllowSorting = False
      Me.tgItem.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.tgItem.AutoColumnResize = False
      Me.tgItem.CaptionVisible = False
      Me.tgItem.Cellchanged = False
      Me.tgItem.DataMember = ""
      Me.tgItem.HeaderForeColor = System.Drawing.SystemColors.ControlText
      Me.tgItem.Location = New System.Drawing.Point(8, 65)
      Me.tgItem.Name = "tgItem"
      Me.tgItem.Size = New System.Drawing.Size(656, 311)
      Me.tgItem.SortingArrowColor = System.Drawing.Color.Red
      Me.tgItem.TabIndex = 3
      Me.tgItem.TreeManager = Nothing
      '
      'lblItem
      '
      Me.lblItem.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblItem.ForeColor = System.Drawing.Color.Black
      Me.lblItem.Location = New System.Drawing.Point(8, 43)
      Me.lblItem.Name = "lblItem"
      Me.lblItem.Size = New System.Drawing.Size(112, 18)
      Me.lblItem.TabIndex = 6
      Me.lblItem.Text = "สถานที่ส่งของ:"
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
      Me.Validator.ErrorProvider = Nothing
      Me.Validator.GotFocusBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
      Me.Validator.HasNewRow = False
      Me.Validator.InvalidBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
      '
      'txtCode
      '
      Me.Validator.SetDataType(Me.txtCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtCode, "")
      Me.txtCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtCode, System.Drawing.Color.Empty)
      Me.txtCode.Location = New System.Drawing.Point(120, 8)
      Me.Validator.SetMinValue(Me.txtCode, "")
      Me.txtCode.Name = "txtCode"
      Me.Validator.SetRegularExpression(Me.txtCode, "")
      Me.Validator.SetRequired(Me.txtCode, False)
      Me.txtCode.Size = New System.Drawing.Size(202, 21)
      Me.txtCode.TabIndex = 0
      '
      'ibtnBlank
      '
      Me.ibtnBlank.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnBlank.Location = New System.Drawing.Point(120, 35)
      Me.ibtnBlank.Name = "ibtnBlank"
      Me.ibtnBlank.Size = New System.Drawing.Size(24, 24)
      Me.ibtnBlank.TabIndex = 7
      Me.ibtnBlank.TabStop = False
      Me.ibtnBlank.ThemedImage = CType(resources.GetObject("ibtnBlank.ThemedImage"), System.Drawing.Bitmap)
      '
      'ibtnDelRow
      '
      Me.ibtnDelRow.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnDelRow.Location = New System.Drawing.Point(144, 35)
      Me.ibtnDelRow.Name = "ibtnDelRow"
      Me.ibtnDelRow.Size = New System.Drawing.Size(24, 24)
      Me.ibtnDelRow.TabIndex = 8
      Me.ibtnDelRow.TabStop = False
      Me.ibtnDelRow.ThemedImage = CType(resources.GetObject("ibtnDelRow.ThemedImage"), System.Drawing.Bitmap)
      '
      'lblCode
      '
      Me.lblCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCode.ForeColor = System.Drawing.Color.Black
      Me.lblCode.Location = New System.Drawing.Point(16, 8)
      Me.lblCode.Name = "lblCode"
      Me.lblCode.Size = New System.Drawing.Size(104, 18)
      Me.lblCode.TabIndex = 4
      Me.lblCode.Text = "รหัส:"
      Me.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'btnSearch
      '
      Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnSearch.Location = New System.Drawing.Point(328, 8)
      Me.btnSearch.Name = "btnSearch"
      Me.btnSearch.Size = New System.Drawing.Size(72, 24)
      Me.btnSearch.TabIndex = 2
      Me.btnSearch.TabStop = False
      Me.btnSearch.Text = "Search"
      '
      'POPlaceOfDeliveryListView
      '
      Me.Controls.Add(Me.txtCode)
      Me.Controls.Add(Me.lblCode)
      Me.Controls.Add(Me.btnSearch)
      Me.Controls.Add(Me.ibtnBlank)
      Me.Controls.Add(Me.ibtnDelRow)
      Me.Controls.Add(Me.tgItem)
      Me.Controls.Add(Me.lblItem)
      Me.Name = "POPlaceOfDeliveryListView"
      Me.Size = New System.Drawing.Size(672, 392)
      CType(Me.tgItem, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

    End Sub

#End Region

#Region "Members"
    Private m_entity As POPlaceOfDelivery
    Private m_treeManager As TreeManager

    Private m_isInitialized As Boolean

    Private m_tableInitialized As Boolean

    Private m_DeliAdd As POPlaceOfDelivery
    Private m_oldRow As TreeRow = Nothing

    Private m_otherFilters As Filter()
    Private m_poplaceofDeliCollection As POPlaceOfDeliveryCollection

#End Region

#Region "Constructors"
    Public Sub New(ByVal entity As ISimpleEntity, ByVal handler As Object, ByVal basket As BasketDialog, ByVal filters As Filter(), ByVal entities As ArrayList)
      MyBase.New()
      InitializeComponent()
      Me.SetLabelText()
      Initialize()

      m_entity = New POPlaceOfDelivery

      m_otherFilters = filters

      Dim dt As TreeTable = Me.GetSchemaTable()
      Dim dst As DataGridTableStyle = Me.CreateTableStyle()
      m_treeManager = New TreeManager(dt, tgItem)
      m_treeManager.SetTableStyle(dst)
      m_treeManager.AllowSorting = False
      m_treeManager.AllowDelete = False
      tgItem.AllowNew = False

      'WrapperArrayList.AddItemAddedHandler(dt, AddressOf ItemAdded)
      AddHandler dt.ColumnChanging, AddressOf Treetable_ColumnChanging
      AddHandler dt.ColumnChanged, AddressOf Treetable_ColumnChanged
      AddHandler dt.RowDeleted, AddressOf ItemDelete

      EventWiring()

      'initial entity
      Me.UpdateEntityProperties()
      Me.TitleName = m_entity.TabPageText

      btnSearch_Click(Nothing, Nothing)
      LoopControl(Me)
    End Sub
#End Region

#Region "Properties"
    Public Property PoplaceofDeliCollection() As POPlaceOfDeliveryCollection      Get        Return m_poplaceofDeliCollection      End Get      Set(ByVal Value As POPlaceOfDeliveryCollection)        m_poplaceofDeliCollection = Value      End Set    End Property
#End Region

#Region "ISimpleListPanel"
    Public Sub ChangeTitle(ByVal sender As Object, ByVal e As System.EventArgs) Implements ISimpleListPanel.ChangeTitle

    End Sub
    Public Sub CheckFormEnable() Implements ISimplePanel.CheckFormEnable

    End Sub
    Public Sub ClearDetail() Implements ISimplePanel.ClearDetail
    End Sub
    Public Sub SetLabelText() Implements ISimplePanel.SetLabelText
      If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
      Me.lblItem.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.POPlaceOfDeliveryListView.lblItem}")
      Me.lblCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.UnitFilterSubPanel.lblCode}")
      Me.btnSearch.Text = Me.StringParserService.Parse("${res:Global.SearchButtonText}")
      'Me.lblPODeliType.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.UnitFilterSubPanel.lblUnitType}")
    End Sub
    Protected Sub EventWiring()

    End Sub
    Public Sub UpdateEntityProperties() Implements ISimplePanel.UpdateEntityProperties
      m_isInitialized = False
      ClearDetail()
      If m_entity Is Nothing Then
        Return
      End If

      'Hack
      Me.IsDirty = False

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

      End Select
      Me.WorkbenchWindow.ViewContent.IsDirty = Me.WorkbenchWindow.ViewContent.IsDirty Or dirtyFlag
      CheckFormEnable()
    End Sub
    Private Sub PropChanged(ByVal sender As Object, ByVal e As PropertyChangedEventArgs)
      If e.Name = "ItemChanged" Then
        Me.WorkbenchWindow.ViewContent.IsDirty = True
      End If
    End Sub
    Public Sub SetStatus()

    End Sub
    Public Sub ShowInPad() Implements ISimplePanel.ShowInPad

    End Sub

    Public ReadOnly Property Title() As String Implements ISimplePanel.Title
      Get
        If Not m_entity Is Nothing Then
          Return Me.m_entity.ListPanelTitle
        End If
      End Get
    End Property
    Public Property Entity() As BusinessLogic.ISimpleEntity Implements ISimpleEntityPanel.Entity
      Get
        Return m_entity
      End Get
      Set(ByVal Value As BusinessLogic.ISimpleEntity)

      End Set
    End Property

    Public Event EntityPropertyChanged(ByVal sender As Object, ByVal e As System.EventArgs) Implements ISimpleEntityPanel.EntityPropertyChanged

    Public Sub AddNew() Implements ISimpleListPanel.AddNew

    End Sub

    Private Sub OnEntitySelected(ByVal entity As ISimpleEntity)
      RaiseEvent EntitySelected(entity)
    End Sub
    Public Event EntitySelected(ByVal entity As BusinessLogic.ISimpleEntity) Implements ISimpleListPanel.EntitySelected

    Public Sub RefreshData(ByVal id As String) Implements ISimpleListPanel.RefreshData

    End Sub

    Public Property SelectedEntity() As BusinessLogic.ISimpleEntity Implements ISimpleListPanel.SelectedEntity
      Get
      End Get
      Set(ByVal Value As BusinessLogic.ISimpleEntity)
      End Set
    End Property
    Public ReadOnly Property Icon() As String Implements ISimplePanel.Icon
      Get

      End Get
    End Property

    Public Sub Initialize() Implements ISimplePanel.Initialize
      'PopulateType()
    End Sub
#End Region

#Region "Methods"
    'Private Sub PopulateType()
    '  'Me.cmbunitType.Items.AddRange(New Object() _
    '  '{ _
    '  'Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.UnitFilterSubPanel.cmbUnitType.All}") _
    '  ', Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.UnitFilterSubPanel.cmbUnitType.Default}") _
    '  ', Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.UnitFilterSubPanel.cmbUnitType.UserDefined}") _
    '  '})
    '  'cmbunitType.SelectedIndex = 0
    'End Sub
#End Region

#Region "Style"
    Public Function CreateTableStyle() As DataGridTableStyle
      Dim dst As New DataGridTableStyle
      dst.MappingName = "POPlaceOfDelivery"

      Dim csLineNumber As New TreeTextColumn
      csLineNumber.MappingName = "LineNumber"
      csLineNumber.HeaderText = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.POPlaceOfDeliveryListView.LineNumberHeaderText}")
      csLineNumber.NullText = ""
      csLineNumber.Width = 30
      csLineNumber.DataAlignment = HorizontalAlignment.Center
      csLineNumber.ReadOnly = True

      Dim csCode As New TreeTextColumn
      csCode.MappingName = "code"
      csCode.HeaderText = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.POPlaceOfDeliveryListView.CodeHeaderText}")
      csCode.NullText = ""
      csCode.Width = 100
      csCode.TextBox.Name = "code"
      csCode.ReadOnly = readonlyFlag()

      Dim csName As New TreeTextColumn
      csName.MappingName = "name"
      csName.HeaderText = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.POPlaceOfDeliveryListView.NameHeaderText}")
      csName.NullText = ""
      csName.Width = 100
      csName.TextBox.Name = "name"
      csName.ReadOnly = readonlyFlag()

      'Dim csDefault As New TreeTextColumn
      'csDefault.MappingName = "Default"
      'csDefault.HeaderText = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.UnitListView.DefaultHeaderText}")
      'csDefault.NullText = ""
      'csDefault.Width = 100
      'csDefault.TextBox.Name = "Default"
      'csDefault.ReadOnly = True

      dst.GridColumnStyles.Add(csLineNumber)
      dst.GridColumnStyles.Add(csCode)
      dst.GridColumnStyles.Add(csName)
      'dst.GridColumnStyles.Add(csDefault)
      Return dst
    End Function
    Public Function GetSchemaTable() As TreeTable
      Dim myDatatable As New TreeTable("POPlaceOfDelivery")
      myDatatable.Columns.Add(New DataColumn("Linenumber", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("Code", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Name", GetType(String)))
      'myDatatable.Columns.Add(New DataColumn("Default", GetType(String)))
      Return myDatatable
    End Function
#End Region

#Region "TreeTable Handlers"
    Private Sub Treetable_ColumnChanged(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs)
      Me.m_treeManager.Treetable.AcceptChanges()
      If Not Me.m_tableInitialized Then
        Return
      End If
      If CType(e.Row, TreeRow).Tag Is Nothing Then
        Return
      End If
      Dim index As Integer = Me.m_treeManager.Treetable.Childs.IndexOf(CType(e.Row, TreeRow))
      If ValidateRow(CType(e.Row, TreeRow)) Then
        Dim pe As New PropertyChangedEventArgs
      End If
      Me.m_treeManager.Treetable.AcceptChanges()
      Me.IsDirty = True
    End Sub
    Private Sub Treetable_ColumnChanging(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs)
      If Not Me.m_tableInitialized Then
        Return
      End If
      If CType(e.Row, TreeRow).Tag Is Nothing Then
        Return
      End If
      Try
        Select Case e.Column.ColumnName.ToLower
          Case "code"
            SetCode(e)
          Case "name"
            SetName(e)
        End Select
        ValidateRow(e)
      Catch ex As Exception
        MessageBox.Show(ex.ToString)
      End Try
    End Sub
    Public Sub ValidateRow(ByVal e As DataColumnChangeEventArgs)
      Dim code As Object = e.Row("code")
      Dim name As Object = e.Row("name")

      Select Case e.Column.ColumnName.ToLower
        Case "code"
          code = e.ProposedValue
        Case "name"
          name = e.ProposedValue
      End Select

      Dim isBlankRow As Boolean = False
      If (IsDBNull(code) OrElse code.ToString.Length = 0) _
          And (IsDBNull(name) OrElse name.ToString.Length = 0) _
          Then
        isBlankRow = True
      End If

      If Not isBlankRow Then
        If IsDBNull(code) OrElse CStr(code).Length = 0 Then
          e.Row.SetColumnError("code", Me.StringParserService.Parse("${res:Global.Error.NoPOPlaceOfDeliveryCode}"))
        Else
          e.Row.SetColumnError("code", "")
        End If
        If IsDBNull(name) OrElse CStr(name).Length = 0 Then
          e.Row.SetColumnError("name", Me.StringParserService.Parse("${res:Global.Error.NoPOPlaceOfDeliveryName}"))
        Else
          e.Row.SetColumnError("name", "")
        End If
      End If
    End Sub
    Public Function ValidateRow(ByVal row As TreeRow) As Boolean
      Dim code As Object = row("code")
      Dim name As Object = row("name")

      Dim flag As Boolean = True
      If (IsDBNull(code) OrElse code.ToString.Length = 0) _
          And (IsDBNull(name) OrElse name.ToString.Length = 0) _
          Then
        flag = False
      End If

      Return flag
    End Function
    Private m_updating As Boolean = False
    Private Function DupCodeOrName(ByVal e As DataColumnChangeEventArgs) As Boolean
      If IsDBNull(e.ProposedValue) Then
        Return False
      End If
      For Each row As TreeRow In Me.m_treeManager.Treetable.Rows
        If Not row Is e.Row Then
          If Not row.IsNull("name") Then
            If e.ProposedValue.ToString.ToLower = row("name").ToString.ToLower Then
              Return True
            End If
            If e.ProposedValue.ToString.ToLower = row("code").ToString.ToLower Then
              Return True
            End If
          End If
        End If
      Next
      Dim testDeliAdd As New POPlaceOfDelivery(e.ProposedValue.ToString)
      If m_DeliAdd Is Nothing OrElse m_DeliAdd.Originated Then
        If testDeliAdd.Originated Then
          Return True
        End If
      End If
      If Not m_DeliAdd Is Nothing AndAlso m_DeliAdd.Originated Then
        If testDeliAdd.Originated And testDeliAdd.Id <> m_DeliAdd.Id Then
          Return True
        End If
      End If
      Return False
    End Function
    Private Function readonlyFlag() As Boolean
      Return m_otherFilters IsNot Nothing AndAlso m_otherFilters.Length > 0
    End Function
    Public Sub SetCode(ByVal e As System.Data.DataColumnChangeEventArgs)
      If m_updating Then
        Return
      End If
      m_updating = True
      If readonlyFlag() Then
        e.ProposedValue = e.Row(e.Column)
        m_updating = False
        Return
      End If
      If m_DeliAdd Is Nothing Then
        e.ProposedValue = e.Row(e.Column)
        m_updating = False
        Return
      End If
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      If m_DeliAdd.IsDefault Then
        Me.MessageService.ShowMessageFormatted("${res:Global.Error.DefaultPOPlaceOfDeliveryCannotBeModified}", New String() {m_DeliAdd.Code})
        e.ProposedValue = e.Row(e.Column)
        m_updating = False
        Return
      End If
      If DupCodeOrName(e) Then
        msgServ.ShowMessageFormatted("${res:Global.Error.AlreadyHasCodeOrName}", New String() {m_DeliAdd.DetailPanelTitle, e.ProposedValue.ToString})
        e.ProposedValue = e.Row(e.Column)
        m_updating = False
        Return
      End If
      m_DeliAdd.Code = e.ProposedValue.ToString
      m_updating = False
    End Sub
    Public Sub SetName(ByVal e As System.Data.DataColumnChangeEventArgs)
      If m_updating Then
        Return
      End If
      m_updating = True
      If readonlyFlag() Then
        e.ProposedValue = e.Row(e.Column)
        m_updating = False
        Return
      End If
      If m_DeliAdd Is Nothing Then
        e.ProposedValue = e.Row(e.Column)
        m_updating = False
        Return
      End If
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      If m_DeliAdd.IsDefault Then
        Me.MessageService.ShowMessageFormatted("${res:Global.Error.DefaultPOPlaceOfDeliveryCannotBeModified}", New String() {m_DeliAdd.Code})
        e.ProposedValue = e.Row(e.Column)
        m_updating = False
        Return
      End If
      If DupCodeOrName(e) Then
        msgServ.ShowMessageFormatted("${res:Global.Error.AlreadyHasCodeOrName}", New String() {m_DeliAdd.DetailPanelTitle, e.ProposedValue.ToString})
        e.ProposedValue = e.Row(e.Column)
        m_updating = False
        Return
      End If
      m_DeliAdd.Name = e.ProposedValue.ToString
      m_updating = False
    End Sub
    Private Sub ItemDelete(ByVal sender As Object, ByVal e As System.Data.DataRowChangeEventArgs)
      'Dim row As DataRow = e.Row
      'Me.m_treeManager.Treetable.Childs.Remove(CType(row, TreeRow))
      'Try
      '    If Not Me.m_isInitialized Then
      '        Return
      '    End If

      '    Dim index As TreeRow = CType(e.Row, TreeRow)
      '    Me.m_treeManager.Treetable.Childs.Remove(index)
      'Catch ex As Exception
      '    MessageBox.Show(ex.ToString)
      'End Try
    End Sub
#End Region

#Region "Event Handlers"
    Private Sub ibtnBlank_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ibtnBlank.Click
      Dim newItem As New POPlaceOfDelivery
      If newItem Is Nothing OrElse Me.m_poplaceofDeliCollection Is Nothing Then
        Return
      End If
      Me.m_poplaceofDeliCollection.Add(newItem)
      Dim newRow As TreeRow = Me.m_treeManager.Treetable.Childs.Add
      newRow.Tag = newItem
      Me.m_DeliAdd = newItem
      Me.m_treeManager.Treetable.AcceptChanges()
      Me.m_treeManager.SelectedRow = newRow
      UpdateItemRow()
      Me.IsDirty = True
    End Sub
    Public Sub UpdateItemRow()
      Dim itr As TreeRow = Me.m_treeManager.SelectedRow
      If itr Is Nothing Then
        Return
      End If
      If Me.m_DeliAdd Is Nothing Then
        Return
      End If
      Me.m_tableInitialized = False
      itr("Linenumber") = Me.m_treeManager.Treetable.Childs.Count
      itr("code") = m_DeliAdd.Code
      itr("Name") = m_DeliAdd.Name
      'If m_DeliAdd.IsDefault Then
      '  itr("Default") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.UnitFilterSubPanel.cmbUnitType.Default}")
      'Else
      '  itr("Default") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.UnitFilterSubPanel.cmbUnitType.UserDefined}")
      'End If
      Me.m_tableInitialized = True
    End Sub
    Private Sub ibtnDelRow_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ibtnDelRow.Click
      If Me.m_entity Is Nothing Then
        Return
      End If
      Dim theRow As TreeRow = Me.m_treeManager.SelectedRow
      If theRow Is Nothing Then
        Return
      End If
      If Not TypeOf theRow.Tag Is POPlaceOfDelivery Then
        Return
      End If
      If Me.m_DeliAdd Is Nothing Then
        Return
      End If
      If m_DeliAdd.IsDefault Then
        Me.MessageService.ShowMessageFormatted("${res:Global.Error.DefaultPOPlaceOfDeliveryCannotBeDeleted}", New String() {m_DeliAdd.Name})
        Return
      End If
      Me.m_poplaceofDeliCollection.Remove(m_DeliAdd)
      m_DeliAdd = Nothing
      theRow.Parent.Childs.Remove(theRow)
      ReInDex()
      Me.IsDirty = True
    End Sub
    Private Sub ReInDex()
      Dim dt As TreeTable = Me.m_treeManager.Treetable
      For i As Integer = 1 To dt.Childs.Count
        dt.Childs(i - 1)("Linenumber") = i
      Next
    End Sub
    Private Sub tgItem_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tgItem.CurrentCellChanged
      Dim theRow As TreeRow = m_treeManager.SelectedRow
      If m_oldRow Is theRow Then
        Return
      End If
      If TypeOf theRow.Tag Is POPlaceOfDelivery Then
        m_DeliAdd = CType(theRow.Tag, POPlaceOfDelivery)
      Else
        m_DeliAdd = Nothing
      End If
      m_oldRow = m_treeManager.SelectedRow
    End Sub
    Private Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
      Dim filters() As Filter = GetFilterArray()
      Dim otherLength As Integer = 0
      If Not m_otherFilters Is Nothing AndAlso m_otherFilters.Length > 0 Then
        otherLength = m_otherFilters.Length
      End If
      Dim newfilters(filters.Length + otherLength - 1) As Filter
      For i As Integer = 0 To filters.Length - 1
        newfilters(i) = filters(i)
      Next
      If otherLength > 0 Then
        For i As Integer = 0 To otherLength - 1
          newfilters(i + filters.Length) = m_otherFilters(i)
        Next
      End If
      Me.m_poplaceofDeliCollection = New POPlaceOfDeliveryCollection(newfilters)

      Me.m_tableInitialized = False
      Me.m_poplaceofDeliCollection.PopulateTable(Me.m_treeManager.Treetable)
      Me.m_tableInitialized = True
    End Sub
    Private Function GetFilterArray() As Filter()
      Dim arr(3) As Filter
      arr(0) = New Filter("code", IIf(Me.txtCode.Text.Length = 0, DBNull.Value, Me.txtCode.Text))
      arr(1) = New Filter("IDList", IIf(Me.txtCode.Text.Length = 0, DBNull.Value, Me.txtCode.Text))
      arr(2) = New Filter("CodeListed", IIf(Me.txtCode.Text.Length = 0, DBNull.Value, Me.txtCode.Text))
      arr(3) = New Filter("IncludeIdList", IIf(Me.txtCode.Text.Length = 0, DBNull.Value, Me.txtCode.Text))

      'Dim PoPlaceDeliIsDefault As Object
      'Select Case Me.cmbUnitType.SelectedIndex
      '  Case -1, 0
      '    PoPlaceDeliIsDefault = DBNull.Value
      '  Case 1
      '    PoPlaceDeliIsDefault = True
      '  Case 2
      '    PoPlaceDeliIsDefault = False
      'End Select
      Return arr
    End Function
#End Region

#Region "Overrides"
    Public Overrides ReadOnly Property TabPageText() As String
      Get
        Return Me.m_entity.ListPanelTitle
      End Get
    End Property
#End Region

#Region "IValidatable"
    Public ReadOnly Property FormValidator() As Components.PJMTextboxValidator Implements IValidatable.FormValidator
      Get
        Return Me.Validator
      End Get
    End Property
#End Region

#Region "IClipboardHandler Overrides"
#End Region

#Region "IKeyReceiver"
    Public Overrides Function ProcessKey(ByVal keyPressed As System.Windows.Forms.Keys) As Boolean
      Try
        Select Case keyPressed
          Case Keys.Insert
            ibtnBlank_Click(Nothing, Nothing)
            Return True
          Case Keys.Delete
            If Me.tgItem.Focused Then
              ibtnDelRow_Click(Nothing, Nothing)
              Return True
            Else
              Return False
            End If
          Case Else
            Return False
        End Select
      Catch ex As Exception
        Throw ex
      End Try
    End Function
#End Region

    Public Overloads Overrides Sub Save()
      OnSaving(New EventArgs)
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      Dim currentUserId As Integer = currentUserId
      If SecurityService.CurrentUser Is Nothing Then
        msgServ.ShowMessage("${res:Global.Error.NoUser}")
        Me.OnSaved(New SaveEventArgs(False))
        SecurityService.UpdateAccessTable()
        WorkbenchSingleton.Workbench.RedrawEditComponents()
        Return
      End If
      currentUserId = SecurityService.CurrentUser.Id
      If Not Me.WorkbenchWindow.SubViewContents Is Nothing AndAlso Me.WorkbenchWindow.SubViewContents.Count > 0 Then
        For Each content As IBaseViewContent In Me.WorkbenchWindow.SubViewContents
          If TypeOf content Is IValidatable Then
            Dim validator As Gui.Components.PJMTextboxValidator = CType(content, IValidatable).FormValidator
            If Not validator Is Nothing Then
              If Not validator.ValidationSummary Is Nothing AndAlso validator.ValidationSummary.Length > 0 Then
                msgServ.ShowMessage(validator.ValidationSummary)
                Me.OnSaved(New SaveEventArgs(False))
                SecurityService.UpdateAccessTable()
                WorkbenchSingleton.Workbench.RedrawEditComponents()
                Return
              End If
            End If
          End If
        Next
      End If

      If Not Me.PoplaceofDeliCollection Is Nothing Then
        Dim errorMessage As String = Me.PoplaceofDeliCollection.Save(currentUserId).Message
        If Not IsNumeric(errorMessage) Then 'Todo
          msgServ.ShowMessage(errorMessage)
          Me.OnSaved(New SaveEventArgs(False))
        Else
          msgServ.ShowMessage("${res:Global.Info.DataSaved}")
          CType(Me, ISimpleListPanel).RefreshData("")
          Me.IsDirty = False
          Me.OnSaved(New SaveEventArgs(True))
        End If
      End If

      SecurityService.UpdateAccessTable()
      WorkbenchSingleton.Workbench.RedrawEditComponents()
      GC.Collect()
    End Sub
  End Class
End Namespace