Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services

Imports Longkong.Pojjaman.Gui
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Drawing.Printing
Imports Longkong.Pojjaman.Gui.Components
Imports System.Globalization
Imports System.Reflection
Imports Longkong.Pojjaman.TextHelper
Imports Longkong.Pojjaman.Gui.ReportsAndDocs
Imports System.Collections.Generic

Namespace Longkong.Pojjaman.Gui.Panels
  Public Class ProjectReceivePaymentMasterItemView
    'Inherits UserControl
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
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
    Friend WithEvents tgItem As Longkong.Pojjaman.Gui.Components.TreeGrid
    <System.Diagnostics.DebuggerStepThrough()> Protected Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Me.lblItem = New System.Windows.Forms.Label()
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
      Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
      Me.tgItem = New Longkong.Pojjaman.Gui.Components.TreeGrid()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.tgItem, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'lblItem
      '
      Me.lblItem.BackColor = System.Drawing.Color.Transparent
      Me.lblItem.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblItem.Location = New System.Drawing.Point(8, 12)
      Me.lblItem.Name = "lblItem"
      Me.lblItem.Size = New System.Drawing.Size(451, 18)
      Me.lblItem.TabIndex = 15
      Me.lblItem.Text = "รายการกำหนดผังบัญชี แบบแสดงบัญชีรายรับรายจ่ายโครงการ (บช. ๑)"
      Me.lblItem.TextAlign = System.Drawing.ContentAlignment.BottomLeft
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
      Me.tgItem.ColorList.AddRange(New System.Drawing.Color() {System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))})
      Me.tgItem.DataMember = ""
      Me.tgItem.HeaderForeColor = System.Drawing.SystemColors.ControlText
      Me.tgItem.Location = New System.Drawing.Point(8, 33)
      Me.tgItem.Name = "tgItem"
      Me.tgItem.PreferredRowHeight = 21
      Me.tgItem.Size = New System.Drawing.Size(902, 521)
      Me.tgItem.SortingArrowColor = System.Drawing.Color.Red
      Me.tgItem.TabIndex = 10
      Me.tgItem.TreeManager = Nothing
      '
      'ProjectReceivePaymentMasterItemView
      '
      Me.Controls.Add(Me.tgItem)
      Me.Controls.Add(Me.lblItem)
      Me.Name = "ProjectReceivePaymentMasterItemView"
      Me.Size = New System.Drawing.Size(916, 562)
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.tgItem, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Members"
    Private m_entity As ProjectReceivePaymentMaster
    Private m_isInitialized As Boolean = False
    Private m_treeManager As TreeManager

    Private m_tableStyleEnable As Hashtable

    Private m_enableState As Hashtable
#End Region

#Region "Constructors"
    Public Sub New(ByVal entity As ISimpleEntity, ByVal handler As Object, ByVal basket As BasketDialog, ByVal filters As Filter(), ByVal entities As ArrayList)
      MyBase.New()
      Me.InitializeComponent()

      m_entity = New ProjectReceivePaymentMaster

      SaveEnableState()
      Dim dt As TreeTable = ProjectReceivePaymentMaster.GetColumnSchemaTable()
      Dim dst As DataGridTableStyle = Me.CreateTableStyle()
      m_treeManager = New TreeManager(dt, tgItem)
      m_treeManager.SetTableStyle(dst)
      m_treeManager.AllowSorting = False
      m_treeManager.AllowDelete = False
      tgItem.AllowNew = False

      AddHandler dt.ColumnChanging, AddressOf Treetable_ColumnChanging
      AddHandler dt.ColumnChanged, AddressOf Treetable_ColumnChanged
      'AddHandler dt.RowDeleted, AddressOf ItemDelete

      UpdateEntityProperties()
    End Sub
    Private Sub SaveEnableState()
      m_enableState = New Hashtable
      For Each ctrl As Control In Me.Controls
        m_enableState.Add(ctrl, ctrl.Enabled)
      Next
    End Sub
#End Region

#Region "Style"
    Public Function CreateTableStyle() As DataGridTableStyle
      Dim dst As New DataGridTableStyle
      dst.MappingName = "ProjectReceivePaymentMaster"
      Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)

      Dim csLineNumber As New TreeTextColumn
      csLineNumber.MappingName = "LineNumber"
      csLineNumber.HeaderText = "Row" 'myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ProjectReceivePaymentMasterItemView.LineNumberHeaderText}")
      csLineNumber.NullText = ""
      csLineNumber.Width = 45
      csLineNumber.DataAlignment = HorizontalAlignment.Center
      csLineNumber.ReadOnly = True
      csLineNumber.TextBox.Name = "LineNumber"

      Dim csThaiNumber As New TreeTextColumn
      csThaiNumber.MappingName = "ThaiNumber"
      csThaiNumber.HeaderText = "" 'myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ProjectReceivePaymentMasterItemView.ThaiNumberHeaderText}")
      csThaiNumber.NullText = ""
      csThaiNumber.Width = 45
      csThaiNumber.DataAlignment = HorizontalAlignment.Center
      csThaiNumber.ReadOnly = True
      csThaiNumber.TextBox.Name = "ThaiNumber"

      Dim csDescription As New TreeTextColumn
      csDescription.MappingName = "Description"
      csDescription.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ProjectReceivePaymentDetailView.DescriptionText}")
      csDescription.NullText = ""
      csDescription.Width = 300
      csDescription.ReadOnly = True
      csDescription.TextBox.Name = "Description"

      Dim csSeparator1 As New DataGridBarrierColumn
      csSeparator1.MappingName = "Separator1"
      csSeparator1.HeaderText = "" 'myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ProjectReceivePaymentDetailView.DescriptionText}")
      csSeparator1.NullText = ""

      Dim csGLAccount As New TreeTextColumn
      csGLAccount.MappingName = "GLAccount"
      csGLAccount.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ProjectReceivePaymentDetailView.GLAccountText}")
      csGLAccount.NullText = ""
      csGLAccount.Width = 500
      'csGLAccount.ReadOnly = True
      csGLAccount.TextBox.Name = "GLAccount"

      Dim csGLButton As New DataGridButtonColumn
      csGLButton.MappingName = "GLButton"
      csGLButton.HeaderText = ""
      csGLButton.NullText = ""
      AddHandler csGLButton.Click, AddressOf GLAccountClicked

      dst.GridColumnStyles.Add(csLineNumber)
      dst.GridColumnStyles.Add(csThaiNumber)
      dst.GridColumnStyles.Add(csDescription)
      dst.GridColumnStyles.Add(csSeparator1)
      dst.GridColumnStyles.Add(csGLAccount)
      dst.GridColumnStyles.Add(csGLButton)

      m_tableStyleEnable = New Hashtable
      For Each colStyle As DataGridColumnStyle In dst.GridColumnStyles
        m_tableStyleEnable.Add(colStyle, colStyle.ReadOnly)
      Next

      Return dst
    End Function
    Public Sub GLClicked(ByVal e As ButtonColumnEventArgs)
      If e.Column = 7 Then
        GLAccountClicked(e)
      End If
    End Sub
    Public Sub GLAccountClicked(ByVal e As ButtonColumnEventArgs)

      Dim theRow As TreeRow = m_treeManager.SelectedRow
      If theRow Is Nothing OrElse theRow.Tag Is Nothing Then
        Return
      End If
      Dim itm As ProjectReceivePaymentMasterItem = Nothing
      If TypeOf theRow.Tag Is ProjectReceivePaymentMasterItem Then
        itm = CType(theRow.Tag, ProjectReceivePaymentMasterItem)
      End If
      Dim filters(1) As Filter
      filters(0) = New Filter("CheckedIdList", itm.GLIdSeparate)
      filters(1) = New Filter("acct_typeGroup", "4,5")

      Dim Entities As New ArrayList
      Dim _entity As New Account
      _entity.Type = New AccountType(-1)
      Entities.Add(_entity)

      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenTreeDialog(New Account, AddressOf SetGLAccount, filters, Entities)
      'Me.IsDirty = True
    End Sub
    Private Sub SetGLAccount(ByVal items As BasketItemCollection)
      'Me.m_treeManager.SelectedRow("CCCode") = cc.Code
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      Dim theRow As TreeRow = m_treeManager.SelectedRow
      Dim itm As ProjectReceivePaymentMasterItem = Nothing
      If TypeOf theRow.Tag Is ProjectReceivePaymentMasterItem Then
        itm = CType(theRow.Tag, ProjectReceivePaymentMasterItem)
        itm.GLAccountList = New List(Of Account)
        itm.IsFormula = False
      End If
      Dim dupItemList As New ArrayList
      For i As Integer = 0 To items.Count - 1
        Dim item As BasketItem = CType(items(i), BasketItem)
        Dim myItem As New Account(item.Id)
        Dim dupItem As Account = Me.m_entity.ValidateGL(myItem)
        If myItem.IsControlGroup OrElse dupItem.Originated OrElse dupItem.Code.Trim.Length > 0 Then
          dupItemList.Add(dupItem.Code)
        Else
          itm.GLAccountList.Add(myItem)
        End If
      Next

      If dupItemList.Count > 0 Then
        msgServ.ShowWarningFormatted("${res:Longkong.Pojjaman.Gui.Panels.ProjectReceivePaymentDetailView.DuplicateGLCode}", vbCrLf & String.Join(vbCrLf, dupItemList.ToArray))
      End If

      theRow("GLAccount") = itm.GLCodeSeparate
      Me.m_treeManager.Treetable.AcceptChanges()
    End Sub
#End Region

#Region "Properties"
    Private ReadOnly Property CurrentItem() As ProjectReceivePaymentMasterItem
      Get
        Dim row As TreeRow = Me.m_treeManager.SelectedRow
        If row Is Nothing Then
          Return Nothing
        End If
        If Not TypeOf row.Tag Is ProjectReceivePaymentMasterItem Then
          Return Nothing
        End If
        Return CType(row.Tag, ProjectReceivePaymentMasterItem)
      End Get
    End Property
#End Region

#Region "TreeTable Handlers"
    Private Sub Treetable_ColumnChanged(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs)
      If Not m_isInitialized Then
        Return
      End If
      '  Dim index As Integer = Me.m_treeManager.Treetable.Childs.IndexOf(CType(e.Row, TreeRow))
      If ValidateRow(CType(e.Row, TreeRow)) Then
        Me.m_treeManager.Treetable.AcceptChanges()
      End If
      Me.IsDirty = True
    End Sub
    Private Sub Treetable_ColumnChanging(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs)
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
     
      Select Case e.Column.ColumnName.ToLower
        Case "glaccount"
          SetGLCodeList(e)
      End Select
    End Sub
    Public Sub ValidateRow(ByVal e As DataColumnChangeEventArgs)
      'Dim ffc_name As Object = e.Row("ffc_name")
      'Dim ffc_alignment As Object = e.Row("ffc_alignment")
      'Dim ffc_widthpercent As Object = e.Row("ffc_widthpercent")
      'Dim ffc_startdate As Object = e.Row("ffc_startdate")
      'Dim ffc_enddate As Object = e.Row("ffc_enddate")

      'Select Case e.Column.ColumnName.ToLower
      '  Case "ffc_name"
      '    ffc_name = e.ProposedValue
      '  Case "ffc_alignment"
      '    ffc_alignment = e.ProposedValue
      '  Case "ffc_widthpercent"
      '    ffc_widthpercent = e.ProposedValue
      '  Case "ffc_startdate"
      '    ffc_startdate = e.ProposedValue
      '  Case "ffc_enddate"
      '    ffc_enddate = e.ProposedValue
      '  Case Else
      '    Return
      'End Select

      'Dim isBlankRow As Boolean = False
      'If IsDBNull(ffc_alignment) _
      'AndAlso IsDBNull(ffc_name) _
      'AndAlso IsDBNull(ffc_widthpercent) _
      'AndAlso IsDBNull(ffc_startdate) _
      'AndAlso IsDBNull(ffc_enddate) Then
      '  isBlankRow = True
      'End If
      'If Not isBlankRow Then
      '  If Not IsNumeric(ffc_widthpercent) OrElse CDec(ffc_widthpercent) < 0 Then
      '    e.Row.SetColumnError("ffc_widthpercent", Me.StringParserService.Parse("${res:Global.Error.FFCWidthMissing}"))
      '  Else
      '    e.Row.SetColumnError("ffc_widthpercent", "")
      '  End If
      '  If Not IsNumeric(ffc_alignment) Then
      '    e.Row.SetColumnError("ffc_alignment", Me.StringParserService.Parse("${res:Global.Error.FFCAlignmentMissing}"))
      '  Else
      '    e.Row.SetColumnError("ffc_alignment", "")
      '  End If
      '  If Not IsDate(ffc_enddate) OrElse CDate(ffc_enddate).Equals(Date.MinValue) Then
      '    e.Row.SetColumnError("ffc_enddate", Me.StringParserService.Parse("${res:Global.Error.FFCEndDateMissing}"))
      '  Else
      '    e.Row.SetColumnError("ffc_enddate", "")
      '  End If
      'End If
    End Sub
    Public Function ValidateRow(ByVal row As TreeRow) As Boolean
      'If row.Tag Is Nothing Then
      '  Return False
      'End If
      'Return True
    End Function
    Private m_updating As Boolean = False
    Public Sub SetGLCodeList(ByVal e As DataColumnChangeEventArgs)
      Dim doc As ProjectReceivePaymentMasterItem = Me.CurrentItem
      If Not e.ProposedValue Is Nothing AndAlso e.ProposedValue.ToString.Length > 0 Then
        If e.ProposedValue.ToString.StartsWith("=") Then
          doc.IsFormula = True
          doc.GLAccountList = New List(Of Account)
          doc.Formula = e.ProposedValue.ToString
        End If
      Else
        doc.IsFormula = False
        doc.Formula = ""
        doc.GLAccountList = New List(Of Account)
      End If

      Dim row As TreeRow = Me.m_treeManager.SelectedRow

      If doc.IsFormula Then
        e.ProposedValue = doc.Formula

        If Not row Is Nothing Then
          row("GLButton") = "invisible"
        End If
      Else
        e.ProposedValue = doc.GLCodeSeparate

        If Not row Is Nothing Then
          row("GLButton") = ""
        End If
      End If
    End Sub
#End Region

#Region "IListDetail"
    ' แสดงค่าข้อมูลของลูกค้าลงใน control ที่อยู่บนฟอร์ม
    Public Sub UpdateEntityProperties() Implements ISimplePanel.UpdateEntityProperties
      m_isInitialized = False
      'ClearDetail()
      If m_entity Is Nothing Then
        Return
      End If

      RefreshDocs()

      m_isInitialized = True
    End Sub
    Private Sub RefreshDocs()
      Me.m_isInitialized = False
      Me.m_entity.Populate(m_treeManager.Treetable)
      RefreshBlankGrid()
      'ReIndex()
      Me.m_isInitialized = True
    End Sub
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

      If Not Me.m_entity Is Nothing Then
        Dim errorMessage As String = Me.m_entity.Save(currentUserId).Message
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
    Public Property Entity() As BusinessLogic.ISimpleEntity Implements ISimpleEntityPanel.Entity
      Get
        Return m_entity
      End Get
      Set(ByVal Value As BusinessLogic.ISimpleEntity)

      End Set
    End Property
#End Region

#Region "Event Handlers"
#End Region

#Region "IValidatable"
    Public ReadOnly Property FormValidator() As Components.PJMTextboxValidator Implements IValidatable.FormValidator
      Get
        Return Me.Validator
      End Get
    End Property
#End Region

#Region "Overrides"
    Public Overrides ReadOnly Property TabPageIcon() As String
      Get
        Return (New FFormat).DetailPanelIcon
      End Get
    End Property
#End Region

#Region "After the main entity has been saved"
    'Public Overrides Sub NotifyAfterSave(ByVal successful As Boolean)
    '  If Not successful Then
    '    Return
    '  End If
    '  Me.Entity = CType(Me.WorkbenchWindow.SubViewContents(1), ISimpleEntityPanel).Entity
    'End Sub
#End Region

#Region "Event of Button controls"

#End Region

#Region "Grid Resizing"
    Private Sub tgItem_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs)
      'If Me.m_entity Is Nothing Then
      '  Return
      'End If
      'RefreshBlankGrid()
    End Sub
    Private Sub RefreshBlankGrid()
      If Me.tgItem.Height = 0 Then
        Return
      End If
      Dim dirtyFlag As Boolean = Me.IsDirty
      Dim index As Integer = tgItem.CurrentRowIndex

      Do Until Me.m_treeManager.Treetable.Rows.Count > tgItem.VisibleRowCount
        'เพิ่มแถวจนเต็ม
        Dim row As TreeRow = Me.m_treeManager.Treetable.Childs.Add()
        row("GLButton") = "invisible"
      Loop

      If Me.m_entity.ProjectReceivePaymentMasterItemList.Count = Me.m_treeManager.Treetable.Childs.Count Then
        'เพิ่มอีก 1 แถว ถ้ามีข้อมูลจนถึงแถวสุดท้าย
        Dim row As TreeRow = Me.m_treeManager.Treetable.Childs.Add()
        row("GLButton") = "invisible"
      End If
      Me.m_treeManager.Treetable.AcceptChanges()
      tgItem.CurrentRowIndex = Math.Max(0, index)
      Me.IsDirty = dirtyFlag
    End Sub
#End Region

    Public Event EntityPropertyChanged(sender As Object, e As System.EventArgs) Implements ISimpleEntityPanel.EntityPropertyChanged

    Public Sub AddNew() Implements ISimpleListPanel.AddNew

    End Sub

    Public Sub ChangeTitle(sender As Object, e As System.EventArgs) Implements ISimpleListPanel.ChangeTitle

    End Sub

    Public Event EntitySelected(entity As BusinessLogic.ISimpleEntity) Implements ISimpleListPanel.EntitySelected

    Public Sub RefreshData(id As String) Implements ISimpleListPanel.RefreshData

    End Sub

    Public Property SelectedEntity As BusinessLogic.ISimpleEntity Implements ISimpleListPanel.SelectedEntity
      Get

      End Get
      Set(value As BusinessLogic.ISimpleEntity)

      End Set
    End Property

    Public Sub CheckFormEnable1() Implements ISimplePanel.CheckFormEnable

    End Sub

    Public Sub ClearDetail1() Implements ISimplePanel.ClearDetail

    End Sub

    Public ReadOnly Property Icon As String Implements ISimplePanel.Icon
      Get

      End Get
    End Property

    Public Sub Initialize1() Implements ISimplePanel.Initialize

    End Sub

    Public Sub SetLabelText1() Implements ISimplePanel.SetLabelText

    End Sub

    Public Sub ShowInPad() Implements ISimplePanel.ShowInPad

    End Sub

    Public ReadOnly Property Title As String Implements ISimplePanel.Title
      Get

      End Get
    End Property

  End Class
End Namespace