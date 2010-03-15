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
Imports System.Globalization
Namespace Longkong.Pojjaman.Gui.Panels
  Public Class AccountPeriodView
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
    Friend WithEvents lblYear As System.Windows.Forms.Label
    Friend WithEvents btnAutorun As System.Windows.Forms.Button
    Friend WithEvents cmbYear As System.Windows.Forms.ComboBox
    Friend WithEvents tgItem As Longkong.Pojjaman.Gui.Components.TreeGrid
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
    Friend WithEvents ibtnBlank As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents ibtnDelRow As Longkong.Pojjaman.Gui.Components.ImageButton
    <System.Diagnostics.DebuggerStepThrough()> Protected Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container
      Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(AccountPeriodView))
      Me.tgItem = New Longkong.Pojjaman.Gui.Components.TreeGrid
      Me.lblYear = New System.Windows.Forms.Label
      Me.lblItem = New System.Windows.Forms.Label
      Me.btnAutorun = New System.Windows.Forms.Button
      Me.cmbYear = New System.Windows.Forms.ComboBox
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider
      Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
      Me.ibtnBlank = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.ibtnDelRow = New Longkong.Pojjaman.Gui.Components.ImageButton
      CType(Me.tgItem, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'tgItem
      '
      Me.tgItem.AllowNew = False
      Me.tgItem.AllowSorting = False
      Me.tgItem.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.tgItem.AutoColumnResize = True
      Me.tgItem.CaptionVisible = False
      Me.tgItem.Cellchanged = False
      Me.tgItem.DataMember = ""
      Me.tgItem.HeaderForeColor = System.Drawing.SystemColors.ControlText
      Me.tgItem.Location = New System.Drawing.Point(8, 72)
      Me.tgItem.Name = "tgItem"
      Me.tgItem.Size = New System.Drawing.Size(656, 288)
      Me.tgItem.SortingArrowColor = System.Drawing.Color.Red
      Me.tgItem.TabIndex = 199
      Me.tgItem.TreeManager = Nothing
      '
      'lblYear
      '
      Me.lblYear.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblYear.ForeColor = System.Drawing.Color.Black
      Me.lblYear.Location = New System.Drawing.Point(8, 16)
      Me.lblYear.Name = "lblYear"
      Me.lblYear.Size = New System.Drawing.Size(56, 18)
      Me.lblYear.TabIndex = 197
      Me.lblYear.Text = "ปีภาษี:"
      Me.lblYear.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblItem
      '
      Me.lblItem.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblItem.ForeColor = System.Drawing.Color.Black
      Me.lblItem.Location = New System.Drawing.Point(8, 56)
      Me.lblItem.Name = "lblItem"
      Me.lblItem.Size = New System.Drawing.Size(112, 18)
      Me.lblItem.TabIndex = 198
      Me.lblItem.Text = "กำหนดงวดบัญชี:"
      Me.lblItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'btnAutorun
      '
      Me.btnAutorun.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnAutorun.Location = New System.Drawing.Point(168, 13)
      Me.btnAutorun.Name = "btnAutorun"
      Me.btnAutorun.Size = New System.Drawing.Size(64, 24)
      Me.btnAutorun.TabIndex = 201
      Me.btnAutorun.Text = "Autorun"
      '
      'cmbYear
      '
      Me.cmbYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbYear.Location = New System.Drawing.Point(64, 15)
      Me.cmbYear.Name = "cmbYear"
      Me.cmbYear.Size = New System.Drawing.Size(104, 21)
      Me.cmbYear.TabIndex = 202
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
      Me.Validator.GotFocusBackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
      Me.Validator.HasNewRow = False
      Me.Validator.InvalidBackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(128, Byte), CType(0, Byte))
      '
      'ibtnBlank
      '
      Me.ibtnBlank.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.ibtnBlank.Image = CType(resources.GetObject("ibtnBlank.Image"), System.Drawing.Image)
      Me.ibtnBlank.Location = New System.Drawing.Point(8, 360)
      Me.ibtnBlank.Name = "ibtnBlank"
      Me.ibtnBlank.Size = New System.Drawing.Size(24, 24)
      Me.ibtnBlank.TabIndex = 203
      Me.ibtnBlank.TabStop = False
      Me.ibtnBlank.ThemedImage = CType(resources.GetObject("ibtnBlank.ThemedImage"), System.Drawing.Bitmap)
      '
      'ibtnDelRow
      '
      Me.ibtnDelRow.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.ibtnDelRow.Image = CType(resources.GetObject("ibtnDelRow.Image"), System.Drawing.Image)
      Me.ibtnDelRow.Location = New System.Drawing.Point(32, 360)
      Me.ibtnDelRow.Name = "ibtnDelRow"
      Me.ibtnDelRow.Size = New System.Drawing.Size(24, 24)
      Me.ibtnDelRow.TabIndex = 204
      Me.ibtnDelRow.TabStop = False
      Me.ibtnDelRow.ThemedImage = CType(resources.GetObject("ibtnDelRow.ThemedImage"), System.Drawing.Bitmap)
      '
      'AccountPeriodView
      '
      Me.Controls.Add(Me.ibtnBlank)
      Me.Controls.Add(Me.ibtnDelRow)
      Me.Controls.Add(Me.cmbYear)
      Me.Controls.Add(Me.btnAutorun)
      Me.Controls.Add(Me.tgItem)
      Me.Controls.Add(Me.lblYear)
      Me.Controls.Add(Me.lblItem)
      Me.Name = "AccountPeriodView"
      Me.Size = New System.Drawing.Size(672, 392)
      CType(Me.tgItem, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Members"
    Private m_entity As AccountPeriod
    Private m_treeManager As TreeManager

    Private m_isInitialized As Boolean

    Private m_tableInitialized As Boolean

    Private m_period As AccountPeriod
    Private m_oldRow As TreeRow = Nothing

    Private m_otherFilters As Filter()
    Private m_periodCollection As AccountPeriodCollection

    Private m_year As Date
#End Region

#Region "Constructors"
    Public Sub New(ByVal entity As ISimpleEntity, ByVal handler As Object, ByVal basket As BasketDialog, ByVal filters As Filter(), ByVal entities As ArrayList)
      MyBase.New()
      InitializeComponent()
      Me.SetLabelText()
      Initialize()

      m_entity = New AccountPeriod

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

			cmbYear_SelectedIndexChanged(Nothing, Nothing)

      LoopControl(Me)
    End Sub
#End Region

#Region "Properties"
    Public Property PeriodCollection() As AccountPeriodCollection      Get        Return m_periodCollection      End Get      Set(ByVal Value As AccountPeriodCollection)        m_periodCollection = Value      End Set    End Property
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
      Me.lblItem.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AccountPeriodView.lblItem}")
      Me.lblYear.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AccountPeriodView.lblYear}")
      Me.btnAutorun.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AccountPeriodView.btnAutorun}")
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
      PopulateCombo()
    End Sub
#End Region

#Region "Methods"
    Private Sub PopulateCombo()
			Dim years(9) As Date
			Dim basedate As Date

			Dim MyCulture As CultureInfo
			MyCulture = New CultureInfo("th-TH")		 'Application.CurrentCulture
			basedate = Date.Parse(Configuration.GetConfig("BaseDate"), MyCulture)
			'basedate = CDate(Configuration.GetConfig("BaseDate"))
      For i As Integer = 0 To 9
				years(i) = basedate.AddYears(i)
      Next
      Dim myDateTimeService As DateTimeService = CType(ServiceManager.Services.GetService(GetType(DateTimeService)), DateTimeService)
      myDateTimeService.ListYearsInComboBox(Me.cmbYear, years)
    End Sub
#End Region

#Region "Style"
    Private Function GetLockingComboTable() As DataTable
      Dim dt As New DataTable
      dt.Columns.Add(New DataColumn("Value"))
      dt.Columns.Add(New DataColumn("Description"))

      Dim row As DataRow = dt.NewRow
      row("Value") = 0
      row("Description") = "No Lock"
      dt.Rows.Add(row)

      row = dt.NewRow
      row("Value") = 1
      row("Description") = "GL Lock"
      dt.Rows.Add(row)

      row = dt.NewRow
      row("Value") = 2
      row("Description") = "All Lock"
      dt.Rows.Add(row)

      Return dt
    End Function
    Public Function CreateTableStyle() As DataGridTableStyle
      Dim dst As New DataGridTableStyle
      dst.MappingName = "AccountPeriod"

      Dim csLineNumber As New TreeTextColumn
      csLineNumber.MappingName = "LineNumber"
      csLineNumber.HeaderText = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AccountPeriodView.LineNumberHeaderText}")
      csLineNumber.NullText = ""
      csLineNumber.Width = 30
      csLineNumber.DataAlignment = HorizontalAlignment.Center
      csLineNumber.ReadOnly = True

      Dim csCode As New TreeTextColumn
      csCode.MappingName = "code"
      csCode.HeaderText = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AccountPeriodView.CodeHeaderText}")
      csCode.NullText = ""
      csCode.Width = 60
      csCode.TextBox.Name = "code"
      csCode.ReadOnly = readonlyFlag

      Dim csStartDate As New DataGridTimePickerColumn
      csStartDate.MappingName = "StartDate"
      csStartDate.HeaderText = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AccountPeriodView.StartDateHeaderText}")
      csStartDate.NullText = ""
      csStartDate.Width = 100

      Dim csEndDate As New DataGridTimePickerColumn
      csEndDate.MappingName = "EndDate"
      csEndDate.HeaderText = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AccountPeriodView.EndDateHeaderText}")
      csEndDate.NullText = ""
      csEndDate.Width = 100

      Dim csStatus As New TreeTextColumn
      csStatus.MappingName = "Status"
      csStatus.HeaderText = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AccountPeriodView.StatusHeaderText}")
      csStatus.NullText = ""
      csStatus.DataAlignment = HorizontalAlignment.Right
      csStatus.Format = "#,###.##"
      csStatus.ReadOnly = True
      csStatus.Width = 60

      Dim csProfit As New TreeTextColumn
      csProfit.MappingName = "Profit"
      csProfit.HeaderText = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AccountPeriodView.ProfitHeaderText}")
      csProfit.NullText = ""
      csProfit.DataAlignment = HorizontalAlignment.Right
      csProfit.Format = "#,###.##"
      csProfit.ReadOnly = True
      csProfit.Width = 60

      Dim csAccProfit As New TreeTextColumn
      csAccProfit.MappingName = "AccProfit"
      csAccProfit.HeaderText = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AccountPeriodView.AccProfitHeaderText}")
      csAccProfit.NullText = ""
      csAccProfit.DataAlignment = HorizontalAlignment.Right
      csAccProfit.Format = "#,###.##"
      csAccProfit.ReadOnly = True
      csAccProfit.Width = 60

      Dim csLocking As DataGridComboColumn
      csLocking = New DataGridComboColumn("Locking", GetLockingComboTable, "Description", "Value")
      csLocking.HeaderText = "Locking"
      csLocking.Width = 70
      csLocking.NullText = String.Empty

      dst.GridColumnStyles.Add(csLineNumber)
      dst.GridColumnStyles.Add(csCode)
      dst.GridColumnStyles.Add(csStartDate)
      dst.GridColumnStyles.Add(csEndDate)
      dst.GridColumnStyles.Add(csStatus)
      dst.GridColumnStyles.Add(csProfit)
      dst.GridColumnStyles.Add(csAccProfit)
      dst.GridColumnStyles.Add(csLocking)
      Return dst
    End Function
    Public Function GetSchemaTable() As TreeTable
      Dim myDatatable As New TreeTable("AccountPeriod")

      myDatatable.Columns.Add(New DataColumn("Linenumber", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("Code", GetType(String)))
      Dim dateCol As New DataColumn("StartDate", GetType(Date))
      dateCol.DefaultValue = Date.MinValue
      myDatatable.Columns.Add(dateCol)
      dateCol = New DataColumn("EndDate", GetType(Date))
      dateCol.DefaultValue = Date.MinValue
      myDatatable.Columns.Add(dateCol)
      myDatatable.Columns.Add(New DataColumn("Status", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Profit", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("AccProfit", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Locking", GetType(Integer)))

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
        UpdateAmount(e)
      End If
      Me.m_treeManager.Treetable.AcceptChanges()
      Me.IsDirty = True
    End Sub
    Private Sub UpdateAmount(ByVal e As DataColumnChangeEventArgs)
      If m_period Is Nothing Then
        Return
      End If
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
          Case "startdate"
            SetStartDate(e)
          Case "enddate"
            SetEndDate(e)
          Case "locking"
            SetLock(e)
        End Select
        ValidateRow(e)
      Catch ex As Exception
        MessageBox.Show(ex.ToString)
      End Try
    End Sub
    Public Sub ValidateRow(ByVal e As DataColumnChangeEventArgs)
      Dim code As Object = e.Row("code")
      Dim startdate As Object = e.Row("startdate")
      Dim enddate As Object = e.Row("enddate")

      Select Case e.Column.ColumnName.ToLower
        Case "code"
          code = e.ProposedValue
        Case "startdate"
          startdate = e.ProposedValue
        Case "enddate"
          enddate = e.ProposedValue
      End Select

      Dim isBlankRow As Boolean = False
      If (IsDBNull(code) OrElse code.ToString.Length = 0) _
          And (IsDBNull(startdate) OrElse CDate(startdate).Equals(Date.MinValue)) _
          And (IsDBNull(enddate) OrElse CDate(enddate).Equals(Date.MinValue)) _
          Then
        isBlankRow = True
      End If

      If Not isBlankRow Then
        If IsDBNull(code) OrElse CStr(code).Length = 0 Then
          e.Row.SetColumnError("code", Me.StringParserService.Parse("${res:Global.Error.NoPeriodCode}"))
        Else
          e.Row.SetColumnError("code", "")
        End If
        If IsDBNull(startdate) OrElse CStr(startdate).Length = 0 Then
          e.Row.SetColumnError("startdate", Me.StringParserService.Parse("${res:Global.Error.NoPeriodStartDate}"))
        Else
          e.Row.SetColumnError("startdate", "")
        End If
        If IsDBNull(enddate) OrElse CStr(enddate).Length = 0 Then
          e.Row.SetColumnError("enddate", Me.StringParserService.Parse("${res:Global.Error.NoPeriodEndDate}"))
        Else
          e.Row.SetColumnError("enddate", "")
        End If
      End If
    End Sub
    Public Function ValidateRow(ByVal row As TreeRow) As Boolean
      Dim code As Object = row("code")
      Dim startdate As Object = row("startdate")
      Dim enddate As Object = row("enddate")

      Dim flag As Boolean = True
      If (IsDBNull(code) OrElse code.ToString.Length = 0) _
          And (IsDBNull(startdate) OrElse CDate(startdate).Equals(Date.MinValue)) _
          And (IsDBNull(enddate) OrElse CDate(enddate).Equals(Date.MinValue)) _
          Then
        flag = False
      End If

      Return flag
    End Function
    Private m_updating As Boolean = False
    Private Function DupCode(ByVal e As DataColumnChangeEventArgs) As Boolean
      If IsDBNull(e.ProposedValue) Then
        Return False
      End If
      For Each row As TreeRow In Me.m_treeManager.Treetable.Rows
        If Not row Is e.Row Then
          If Not row.IsNull("code") Then
            If e.ProposedValue.ToString.ToLower = row("code").ToString.ToLower Then
              Return True
            End If
          End If
        End If
      Next
      Return False
    End Function
    Public Sub SetLock(ByVal e As System.Data.DataColumnChangeEventArgs)
      If m_updating Then
        Return
      End If
      m_updating = True
      If readonlyFlag() Then
        e.ProposedValue = e.Row(e.Column)
        m_updating = False
        Return
      End If
      If m_period Is Nothing Then
        e.ProposedValue = e.Row(e.Column)
        m_updating = False
        Return
      End If
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      If m_period.IsLocked Then
        Me.MessageService.ShowMessageFormatted("${res:Global.Error.PeriodIsLockedCannotBeModified}", New String() {m_period.Code})
        e.ProposedValue = e.Row(e.Column)
        m_updating = False
        Return
      End If
      m_period.Locking = [Enum].Parse(GetType(AccountPeriodLock), e.ProposedValue)
      m_updating = False
    End Sub
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
      If m_period Is Nothing Then
        e.ProposedValue = e.Row(e.Column)
        m_updating = False
        Return
      End If
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      If m_period.IsLocked Then
        Me.MessageService.ShowMessageFormatted("${res:Global.Error.PeriodIsLockedCannotBeModified}", New String() {m_period.Code})
        e.ProposedValue = e.Row(e.Column)
        m_updating = False
        Return
      End If
      If DupCode(e) Then
        msgServ.ShowMessageFormatted("${res:Global.Error.AlreadyHasCode}", New String() {m_period.DetailPanelTitle, e.ProposedValue.ToString})
        e.ProposedValue = e.Row(e.Column)
        m_updating = False
        Return
      End If
      m_period.Code = e.ProposedValue.ToString
      m_updating = False
    End Sub
    Public Sub SetStartDate(ByVal e As System.Data.DataColumnChangeEventArgs)
      If m_updating Then
        Return
      End If
      m_updating = True
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      If readonlyFlag() Then
        e.ProposedValue = e.Row(e.Column)
        m_updating = False
        Return
      End If
      If m_period.IsLocked Then
        Me.MessageService.ShowMessageFormatted("${res:Global.Error.PeriodIsLockedCannotBeModified}", New String() {m_period.Code})
        e.ProposedValue = e.Row(e.Column)
        m_updating = False
        Return
      End If
      If Me.m_periodCollection.IndexOf(m_period) > 0 Then
        Me.MessageService.ShowMessage("${res:Global.Error.ModifiedStartDateOnlyFirstPeriod}")
        e.ProposedValue = e.Row(e.Column)
        m_updating = False
        Return
      End If
      Dim lastYearEndDate As Date = m_period.GetLastYearEndDate
      If Not lastYearEndDate.Equals(Date.MinValue) AndAlso CDate(e.ProposedValue) <= lastYearEndDate Then
        Me.MessageService.ShowMessageFormatted("${res:Global.Error.DateBelowLastYearPeriod}", New String() {CDate(e.ProposedValue).ToShortDateString, lastYearEndDate.ToShortDateString})
        e.ProposedValue = e.Row(e.Column)
        m_updating = False
        Return
      End If
      m_period.StartDate = CDate(e.ProposedValue)
      m_updating = False
    End Sub
    Public Sub SetEndDate(ByVal e As System.Data.DataColumnChangeEventArgs)
      If m_updating Then
        Return
      End If
      m_updating = True
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      If readonlyFlag() Then
        e.ProposedValue = e.Row(e.Column)
        m_updating = False
        Return
      End If
      If m_period.IsLocked Then
        Me.MessageService.ShowMessageFormatted("${res:Global.Error.PeriodIsLockedCannotBeModified}", New String() {m_period.Code})
        e.ProposedValue = e.Row(e.Column)
        m_updating = False
        Return
      End If
      m_period.EndDate = CDate(e.ProposedValue)
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
      Dim lastPeriodStart As Date
      Dim lastPeriodEnd As Date
      If Me.m_periodCollection.Count > 0 Then
        lastPeriodStart = Me.m_periodCollection(Me.m_periodCollection.Count - 1).StartDate
        lastPeriodEnd = Me.m_periodCollection(Me.m_periodCollection.Count - 1).EndDate
      End If
      If Me.m_periodCollection.Count = 0 Then
        'ไม่มี period ในปี
        lastPeriodEnd = AccountPeriod.GetYearEndDate(m_year.AddYears(-1))
      End If

      If lastPeriodEnd.Equals(Date.MinValue) Then
        'ท้ายที่สุดก็ยังไม่มี ให้เป็นวันสุดท้ายของปี
        lastPeriodEnd = New Date(m_year.Year, 1, 1).AddDays(-1)
      End If

      If lastPeriodStart.Equals(Date.MinValue) Then
        Dim days As Integer = Date.DaysInMonth(lastPeriodEnd.Year, lastPeriodEnd.Month)
        lastPeriodStart = lastPeriodEnd.AddDays(-days)
      End If

      Dim nextYearStartDate As Date = AccountPeriod.GetYearStartDate(m_year.AddYears(1))

      If Not nextYearStartDate.Equals(Date.MinValue) AndAlso lastPeriodEnd.AddDays(1) >= nextYearStartDate Then
        Me.MessageService.ShowMessageFormatted("${res:Global.Error.DateExceedNextYearPeriod}", New String() {nextYearStartDate.ToShortDateString})
        Return
      End If
      Dim diff1 As Long = DateDiff(DateInterval.Day, lastPeriodStart, lastPeriodEnd)
      Dim diff2 As Long = DateDiff(DateInterval.Day, lastPeriodEnd, nextYearStartDate)
      If Not nextYearStartDate.Equals(Date.MinValue) Then
        diff1 = Math.Min(diff1, diff2)
      End If
      Dim newItem As New AccountPeriod
      newItem.StartDate = lastPeriodEnd.AddDays(1)
      newItem.EndDate = newItem.StartDate.AddDays(diff1)
      Me.m_periodCollection.Add(newItem)
      Dim newRow As TreeRow = Me.m_treeManager.Treetable.Childs.Add
      newRow.Tag = newItem
      Me.m_period = newItem
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
      If Me.m_period Is Nothing Then
        Return
      End If
      Me.m_tableInitialized = False
      itr("Linenumber") = Me.m_treeManager.Treetable.Childs.Count
      itr("code") = m_period.Code
      itr("StartDate") = m_period.StartDate
      itr("EndDate") = m_period.EndDate
      Dim profit As Decimal = m_period.GetNetProfit
      Dim accProfit As Decimal = m_period.GetAccProfit
      If profit = 0 Then
        itr("Profit") = ""
      Else
        itr("Profit") = profit
      End If
      If accProfit = 0 Then
        itr("AccProfit") = ""
      Else
        itr("AccProfit") = accProfit
      End If
      If m_period.IsLocked Then
        itr("Status") = m_period.StringParserService.Parse("${res:Global.PeriodClose}")
      Else
        itr("status") = m_period.StringParserService.Parse("${res:Global.PeriodOpen}")
      End If
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
      If Not TypeOf theRow.Tag Is AccountPeriod Then
        Return
      End If
      If Me.m_period Is Nothing Then
        Return
      End If
      If m_period.IsLocked Then
        Me.MessageService.ShowMessageFormatted("${res:Global.Error.PeriodIsLockedCannotBeDeleted}", New String() {m_period.Code})
        Return
      End If
      If Me.m_periodCollection.IndexOf(m_period) < Me.m_periodCollection.Count - 1 Then
        Me.MessageService.ShowMessage("${res:Global.Error.DeleteOnlyLastPeriod}")
        Return
      End If
      Me.m_periodCollection.Remove(m_period)
      m_period = Nothing
      theRow.Parent.Childs.Remove(theRow)
      Me.IsDirty = True
    End Sub
    Private Sub tgItem_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tgItem.CurrentCellChanged
      Dim theRow As TreeRow = m_treeManager.SelectedRow
      If m_oldRow Is theRow Then
        Return
      End If
      If TypeOf theRow.Tag Is AccountPeriod Then
        m_period = CType(theRow.Tag, AccountPeriod)
      Else
        m_period = Nothing
      End If
      m_oldRow = m_treeManager.SelectedRow
    End Sub
    Private Sub cmbYear_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbYear.SelectedIndexChanged
			m_year = Date.MinValue
      If cmbYear.Items.Count = 0 Then
        Return
      End If
      If Not TypeOf cmbYear.SelectedValue Is Date Then
        Return
			End If
			m_year = CDate(Me.cmbYear.SelectedValue)
			Dim filters(0) As Filter
			filters(0) = New Filter("year", IIf(CDate(cmbYear.SelectedValue).Equals(Date.MinValue), DBNull.Value, CDate(Me.cmbYear.SelectedValue)))
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
			Me.m_periodCollection = New AccountPeriodCollection(newfilters)
			Me.m_tableInitialized = False
			Me.m_periodCollection.PopulateTable(Me.m_treeManager.Treetable)
			Me.m_tableInitialized = True
    End Sub
    Private Sub btnAutorun_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAutorun.Click
      If cmbYear.Items.Count = 0 Then
        Return
      End If
      If Not TypeOf cmbYear.SelectedValue Is Date Then
        Return
      End If
      If Me.m_periodCollection Is Nothing Then
        Return
      End If
      If Me.m_periodCollection.AutoRun(CDate(cmbYear.SelectedValue)) Then
        Me.m_tableInitialized = False
        Me.m_periodCollection.PopulateTable(Me.m_treeManager.Treetable)
        Me.m_tableInitialized = True
        Me.IsDirty = True
      End If
    End Sub
#End Region

#Region "Overrides"
    Public Overrides ReadOnly Property TabPageText() As String
      Get
        Return Me.m_entity.ListPanelTitle
      End Get
    End Property
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

      If Not Me.PeriodCollection Is Nothing Then
        Dim errorMessage As String = Me.PeriodCollection.Save(currentUserId).Message
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
#End Region

#Region "IValidatable"
    Public ReadOnly Property FormValidator() As components.PJMTextboxValidator Implements IValidatable.FormValidator
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

  End Class
End Namespace