Imports System.Windows.Forms
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports Longkong.Core.Services
Imports Longkong.Core.Properties
Imports System.Drawing
Imports Longkong.Pojjaman.Services
Imports System.IO
Imports System.Reflection
Imports System.Xml
Imports Microsoft.Win32
Imports System.Text
Imports System.Threading
Imports Longkong.Pojjaman.FormDisplayBinding
Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.Gui.ReportsAndDocs
Imports Longkong.Pojjaman.Commands
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.AdobeForm
Imports System.Collections.Generic
Imports DevExpress.LookAndFeel
Imports DevExpress.XtraReports.UserDesigner
Imports DevExpress.XtraReports.UI

Namespace Longkong.Pojjaman.Gui.Panels
  'มีไว้เพื่อเป็นแม่ของหน้า Detail ต่างๆ มี methods และ properties ที่จำเป็น
  Public Class AbstractEntityDetailPanelView
    Inherits UserControl
    Implements ISecondaryViewContent, ISimpleEntityPanel _
    , IEditable, IClipboardHandler, IPrintable, IKeyReceiver, ISecurityValidatable, INewPrintable

#Region "Members"
    Private m_view As PanelDisplayBinding.PanelView
    Private m_owner As IListPanel
    Private m_workbenchWindow As IWorkbenchWindow
    Private m_securityService As SecurityService
    Private m_StringParserService As StringParserService
    Private m_statusbarService As IStatusBarService
    Private m_dateTimeService As DateTimeService
    Private m_accessTale As DataTable
#End Region

#Region "Constructors"
    Public Sub New()
      MyBase.New()
      Me.AutoScroll = True
    End Sub

    Private Sub AbstractEntityDetailPanelView_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
      Dim fullName As String = Me.GetType.FullName
      'm_accessTale = Access.GetFormAccessTable(fullName)
      'If Not FormSecurityValidator Is Nothing AndAlso Not m_accessTale Is Nothing Then
      '    LoopSecurity(Me)
      'End If
      LoopControl(Me)
    End Sub
#End Region

#Region "Properties"
    Public Overridable Property StatusDescription As String
    Public Overridable Property StatusMessage As String
    Public Property StatusColor As Color
    <Browsable(False)> _
    Public ReadOnly Property StatusBarService() As IStatusBarService
      Get
        If m_statusbarService Is Nothing Then
          m_statusbarService = CType(ServiceManager.Services.GetService(GetType(IStatusBarService)), IStatusBarService)
        End If
        Return m_statusbarService
      End Get
    End Property
    <Browsable(False)> _
    Public ReadOnly Property StringParserService() As StringParserService
      Get
        If m_StringParserService Is Nothing Then
          m_StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
        End If
        Return m_StringParserService
      End Get
    End Property
    <Browsable(False)> _
    Public ReadOnly Property SecurityService() As SecurityService
      Get
        If m_securityService Is Nothing Then
          m_securityService = CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService)
        End If
        Return m_securityService
      End Get
    End Property
    <Browsable(False)> _
    Public ReadOnly Property DateTimeService() As DateTimeService
      Get
        If m_dateTimeService Is Nothing Then
          m_dateTimeService = CType(ServiceManager.Services.GetService(GetType(DateTimeService)), DateTimeService)
        End If
        Return DateTimeService
      End Get
    End Property
#End Region

#Region "Methods"
    Public Sub LoopSecurity(ByVal thisCtrl As Control)
      For Each ctrl As Control In thisCtrl.Controls
        Dim rows As DataRow() = m_accessTale.Select("form_controlname='" & ctrl.Name & "'")
        If rows.Length = 1 Then
          Dim row As DataRow = rows(0)
          Dim accessId As Integer = CInt(row("form_accessID"))
          Dim requiredLevel As Integer = CInt(row("form_requiredlevel"))
          Dim action As FailAction = CType([Enum].Parse(GetType(FailAction), row("form_failaction").ToString), FailAction)
          Me.FormSecurityValidator.SetAccessId(ctrl, accessId)
          Me.FormSecurityValidator.SetFailAction(ctrl, action)
          Me.FormSecurityValidator.SetRequiredLevel(ctrl, requiredLevel)
        End If
        LoopSecurity(ctrl)
      Next
    End Sub
    Public Sub LoopControl(ByVal thisCtr As Control)
      Dim ctr As Control
      For Each ctr In thisCtr.Controls
        If TypeOf ctr Is TextBox Then
          RemoveHandler ctr.GotFocus, AddressOf ControlFocus
          AddHandler ctr.GotFocus, AddressOf ControlFocus
        End If
        If Not TypeOf ctr Is DataGrid Then
          LoopControl(ctr)
        End If
      Next
    End Sub
    Private Sub ControlFocus(ByVal sender As Object, ByVal e As EventArgs)
      'WorkbenchSingleton.Workbench.RedrawEditComponents()
    End Sub
    Public Function MinDateToNull(ByVal dt As Date, ByVal nullString As String) As String
      If dt.Equals(Date.MinValue) Then
        Return nullString
      End If
      Return dt.ToShortDateString 'พี่ดำมาแก้คืนว่ะ
      'Return dt.ToString("dd/MM/yyyy")  ' เหน่งมาแก้นะครับ
    End Function
    Public Function MinDateToNow(ByVal dt As Date) As Date
      If dt.Equals(Date.MinValue) Then
        dt = Now
      End If
      Return dt
    End Function
    Public Function MaxDtpDate(ByVal dt As Date) As Date
      If dt.CompareTo(DateTimePicker.MaxDateTime) >= 0 Then
        Return DateTimePicker.MaxDateTime
      End If
      Return MinDateToNow(dt)
    End Function
    Protected Sub ControlValidated(ByVal sender As Object, ByVal e As System.EventArgs)
      Try
        RefreshBindings(Me.Entity)
      Catch ex As Exception
        Debug.WriteLine(ex.Message)
      End Try
    End Sub
    Protected Overridable Sub EventWiring()
      Debug.WriteLine("Implement Me! (AbstractEntityDetailPanelView.EventWiring)")
    End Sub

    Public Sub RefreshBindings(ByVal dataSource As Object)
      Me.BindingContext(dataSource).SuspendBinding()
      Me.BindingContext(dataSource).ResumeBinding()
    End Sub
    Protected Overridable Sub FormatHandler(ByVal sender As Object, ByVal e As ConvertEventArgs)
      If e.Value Is Nothing And e.DesiredType Is GetType(String) Then
        e.Value = ""
      End If
      If e.DesiredType Is GetType(DateTime) Then
        If CType(e.Value, Date) = DateTime.MinValue Then
          e.Value = DateTime.Now
        End If
      End If
    End Sub
    Protected Overridable Sub ParseHandler(ByVal sender As Object, ByVal cevent As ConvertEventArgs)

    End Sub
    Protected Sub DecimalToCurrencyString(ByVal sender As Object, ByVal cevent As ConvertEventArgs)
      ' This method is the Format event handler. Whenever the 
      ' control displays a new value, the value is converted from 
      ' its native Decimal type to a string. The ToString method 
      ' then formats the value as a Currency, by using the 
      ' formatting character "c".

      ' The application can only convert to string type. 

      If Not cevent.DesiredType Is GetType(String) Then
        Exit Sub
      End If
      If Not IsNumeric(cevent.Value) Then
        Exit Sub
      End If
      cevent.Value = CType(cevent.Value, Decimal).ToString("c")
    End Sub
    Protected Sub CurrencyStringToDecimal(ByVal sender As Object, ByVal cevent As ConvertEventArgs)
      ' This method is the Parse event handler. The Parse event 
      ' occurs whenever the displayed value changes. The static 
      ' ToDecimal method of the Convert class converts the 
      ' value back to its native Decimal type.

      ' Can only convert to decimal type.
      If Not cevent.DesiredType Is GetType(Decimal) Then
        Exit Sub
      End If

      cevent.Value = Decimal.Parse(cevent.Value.ToString, Globalization.NumberStyles.Currency, Nothing)

    End Sub
    Public Overridable Sub SetStatusBarMessage()
      Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)

      Dim currentUserId As Integer = Me.SecurityService.CurrentUser.Id

      Dim cancelPersonName As String = ""
      Dim lastEditorPersonName As String = ""
      Dim originatorPersonName As String = ""

      Dim cancelDate As String = ""
      Dim lastEditDate As String = ""
      Dim originDate As String = ""

      Dim approvePersonName As String = ""
      Dim approveDate As String = ""

      Me.StatusDescription = ""
      Me.StatusMessage = ""

      Dim alpha As Byte = CByte(ConfigurationUser.GetConfig(currentUserId, "alpha.statusbar"))

      If Me.Entity Is Nothing Then
        Return
      End If

      If Not Me.Entity.Originated Then
        Me.StatusDescription = myStringParserService.Parse("${res:Global.Already}")
        Me.StatusColor = Color.FromArgb(alpha, ConfigurationUser.GetColorConfiguration(currentUserId, "color.normal"))
      Else
        Me.StatusColor = Color.FromArgb(alpha, ConfigurationUser.GetColorConfiguration(currentUserId, "color.normal"))

        If Not Me.Entity.CancelPerson Is Nothing Then
          cancelPersonName = Me.Entity.CancelPerson.Name
        End If
        If Not Me.Entity.LastEditor Is Nothing Then
          lastEditorPersonName = Me.Entity.LastEditor.Name
        End If
        If Not Me.Entity.Originator Is Nothing Then
          originatorPersonName = Me.Entity.Originator.Name
        End If

        If IsDate(Me.Entity.CancelDate) AndAlso Not Me.Entity.CancelDate.Equals(Date.MinValue) Then
          cancelDate = Me.Entity.CancelDate.ToShortDateString & " " & Me.Entity.CancelDate.ToShortTimeString
        End If
        If IsDate(Me.Entity.LastEditDate) AndAlso Not Me.Entity.LastEditDate.Equals(Date.MinValue) Then
          lastEditDate = Me.Entity.LastEditDate.ToShortDateString & " " & Me.Entity.LastEditDate.ToShortTimeString
        End If
        If IsDate(Me.Entity.OriginDate) AndAlso Not Me.Entity.OriginDate.Equals(Date.MinValue) Then
          originDate = Me.Entity.OriginDate.ToShortDateString & " " & Me.Entity.OriginDate.ToShortTimeString
        End If

        If Me.Entity.Canceled Then
          Me.StatusDescription = myStringParserService.Parse("${res:Global.Cancel}") & ": " & cancelDate & " " & myStringParserService.Parse("${res:Global.By}") & ": " & cancelPersonName
          Me.StatusMessage = myStringParserService.Parse("${res:Global.Cancel}")
          Me.StatusColor = Color.FromArgb(alpha, ConfigurationUser.GetColorConfiguration(currentUserId, "color.cancel"))
        End If
        If Me.Entity.Status.Value = 0 Then
          Me.StatusDescription = myStringParserService.Parse("${res:Global.Cancel}") & ": " & lastEditDate & " " & myStringParserService.Parse("${res:Global.By}") & ": " & lastEditorPersonName
          Me.StatusMessage = myStringParserService.Parse("${res:Global.Cancel}")
          Me.StatusColor = Color.FromArgb(alpha, ConfigurationUser.GetColorConfiguration(currentUserId, "color.cancel"))
        ElseIf Me.Entity.Status.Value = 4 Then
          If Me.Entity.Edited Then
            Me.StatusDescription = myStringParserService.Parse("${res:Global.Added}") & ": " & originDate & " " & myStringParserService.Parse("${res:Global.By}") & ": " & originatorPersonName & ", " & myStringParserService.Parse("${res:Global.Edited}") & ": " & lastEditDate & " " & myStringParserService.Parse("${res:Global.By}") & ": " & lastEditorPersonName
          Else
            Me.StatusDescription = myStringParserService.Parse("${res:Global.Added}") & ": " & originDate & " " & myStringParserService.Parse("${res:Global.By}") & ": " & originatorPersonName
          End If
          Me.StatusMessage = myStringParserService.Parse("${res:Global.GLPasseded}")
          Me.StatusColor = Color.FromArgb(alpha, ConfigurationUser.GetColorConfiguration(currentUserId, "color.glpass"))
        Else

          If Me.Entity.Edited Then
            Me.StatusDescription = myStringParserService.Parse("${res:Global.Added}") & ": " & originDate & " " & myStringParserService.Parse("${res:Global.By}") & ": " & originatorPersonName & ", " & myStringParserService.Parse("${res:Global.Edited}") & ": " & lastEditDate & " " & myStringParserService.Parse("${res:Global.By}") & ": " & lastEditorPersonName
          Else
            Me.StatusDescription = myStringParserService.Parse("${res:Global.Added}") & ": " & originDate & " " & myStringParserService.Parse("${res:Global.By}") & ": " & originatorPersonName
          End If
          If TypeOf Me.Entity Is IDocStatusAble Then
            Dim doc As IDocStatusAble = CType(Me.Entity, IDocStatusAble)
            If doc.IsReferenced Then
              If Me.StatusMessage.Length > 0 Then
                Me.StatusMessage &= ", " & myStringParserService.Parse("${res:Global.Referenced}")
              Else
                Me.StatusMessage = myStringParserService.Parse("${res:Global.Referenced}")
              End If
              Me.StatusColor = Color.FromArgb(alpha, ConfigurationUser.GetColorConfiguration(currentUserId, "color.reference"))
            End If
          End If
          If TypeOf Me.Entity Is ICloseStatusAble Then
            Dim doc As ICloseStatusAble = CType(Me.Entity, ICloseStatusAble)
            If doc.Closed Then
              If Me.StatusMessage.Length > 0 Then
                Me.StatusMessage &= ", " & myStringParserService.Parse("${res:Global.Closed}")
              Else
                Me.StatusMessage = myStringParserService.Parse("${res:Global.Closed}")
              End If
              Me.StatusColor = Color.FromArgb(alpha, ConfigurationUser.GetColorConfiguration(currentUserId, "color.close"))
            End If
          End If
          If TypeOf Me.Entity Is IApproveStatusAble Then
            Dim aprov As IApproveStatusAble = CType(Me.Entity, IApproveStatusAble)
            If aprov.IsAuthorized Then
              If Me.StatusMessage.Length > 0 Then
                Me.StatusMessage &= ", " & myStringParserService.Parse("${res:Global.Authorized}")
              Else
                Me.StatusMessage = myStringParserService.Parse("${res:Global.Authorized}")
              End If
              Me.StatusColor = Color.FromArgb(alpha, ConfigurationUser.GetColorConfiguration(currentUserId, "color.authorize"))
            ElseIf aprov.IsLevelApproved Then
              If Me.StatusMessage.Length > 0 Then
                Me.StatusMessage &= ", " & myStringParserService.Parse("${res:Global.Approved}")
              Else
                Me.StatusMessage = myStringParserService.Parse("${res:Global.Approved}")
              End If
              Me.StatusColor = Color.FromArgb(alpha, ConfigurationUser.GetColorConfiguration(currentUserId, "color.approve"))
            ElseIf aprov.IsReject Then
              If Me.StatusMessage.Length > 0 Then
                Me.StatusMessage &= ", " & myStringParserService.Parse("${res:Global.Reject}")
              Else
                Me.StatusMessage = myStringParserService.Parse("${res:Global.Reject}")
              End If
              Me.StatusColor = Color.FromArgb(alpha, ConfigurationUser.GetColorConfiguration(currentUserId, "color.reject"))
            End If
          End If

          'ElseIf Me.Entity.Edited Then
          '  Me.StatusDescription = myStringParserService.Parse("${res:Global.Added}") & ": " & originDate & " " & myStringParserService.Parse("${res:Global.By}") & ": " & originatorPersonName & ", " & myStringParserService.Parse("${res:Global.Edited}") & ": " & lastEditDate & " " & myStringParserService.Parse("${res:Global.By}") & ": " & lastEditorPersonName

          '  If TypeOf Me.Entity Is IApprovAble Then
          '    Dim aprov As IApprovAble = CType(Me.Entity, IApprovAble)
          '    If aprov.IsApproved Then
          '      Me.StatusMessage = myStringParserService.Parse("${res:Global.Approved}")
          '      If Not Me.StatusColor.Equals(Color.FromArgb(95, Color.Red)) Then
          '        'Me.StatusColor = Color.FromArgb(95, Color.Green)
          '      Else
          '        'Me.StatusColor = Color.FromArgb(95, Color.Blue)
          '      End If
          '    End If
          '  End If

          '  If TypeOf Me.Entity Is IDocStatusAble Then
          '    Dim doc As IDocStatusAble = CType(Me.Entity, IDocStatusAble)
          '    If doc.IsReferenced Then
          '      If Me.StatusMessage.Length > 0 Then
          '        Me.StatusMessage &= ", " & myStringParserService.Parse("${res:Global.Referenced}")
          '      Else
          '        Me.StatusMessage = myStringParserService.Parse("${res:Global.Referenced}")
          '        'Me.StatusColor = Color.FromArgb(95, Color.Pink)
          '      End If
          '    End If
          '  End If

          'Else
          '  Me.StatusDescription = myStringParserService.Parse("${res:Global.Added}") & ": " & originDate & " " & myStringParserService.Parse("${res:Global.By}") & ": " & originatorPersonName
          '  Me.StatusMessage = ""
          '  'Me.StatusColor = Color.FromArgb(0, Color.White)

          '  If TypeOf Me.Entity Is IApprovAble Then
          '    Dim aprov As IApprovAble = CType(Me.Entity, IApprovAble)
          '    If aprov.IsApproved Then
          '      Me.StatusMessage = myStringParserService.Parse("${res:Global.Approved}")
          '      If Not Me.StatusColor.Equals(Color.FromArgb(95, Color.Red)) Then
          '        'Me.StatusColor = Color.FromArgb(95, Color.Green)
          '      Else
          '        'Me.StatusColor = Color.FromArgb(95, Color.Blue)
          '      End If
          '    End If
          '  End If

          '  If TypeOf Me.Entity Is IDocStatusAble Then
          '    Dim doc As IDocStatusAble = CType(Me.Entity, IDocStatusAble)
          '    If doc.IsReferenced Then
          '      If Me.StatusMessage.Length > 0 Then
          '        Me.StatusMessage &= ", " & myStringParserService.Parse("${res:Global.Referenced}")
          '      Else
          '        Me.StatusMessage = myStringParserService.Parse("${res:Global.Referenced}")
          '        'Me.StatusColor = Color.FromArgb(95, Color.Pink)
          '      End If
          '    End If
          '  End If

        End If
      End If
    End Sub

#End Region

#Region "Event Handler"
    Private Sub PanelView_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
      If Not Me.DesignMode Then
        Try
          'Me.SetStatus()
          Me.StatusBarService.SetMessage(Me.StatusDescription)
          Me.StatusBarService.SetStatusMessage(Me.StatusMessage, Me.StatusColor)
        Catch ex As Exception

        End Try
      End If
    End Sub
    Private Sub AbstractEntityDetailPanelView_ParentChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ParentChanged
      If Not Me.DesignMode Then
        Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
        Dim currentUserId As Integer = Me.SecurityService.CurrentUser.Id
        Dim alpha As Byte = CByte(ConfigurationUser.GetConfig(currentUserId, "alpha.statusbar"))
        Me.StatusColor = Color.FromArgb(alpha, ConfigurationUser.GetColorConfiguration(currentUserId, "color.normal"))
        Me.StatusDescription = myStringParserService.Parse("${res:Global.Already}")
        Me.StatusBarService.SetMessage(Me.StatusDescription)
        Me.StatusBarService.SetStatusMessage(Me.StatusMessage, Me.StatusColor)
      End If
    End Sub

    Private Sub AbstractEntityDetailPanelView_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
      If Not Me.DesignMode Then
        Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
        Dim currentUserId As Integer = Me.SecurityService.CurrentUser.Id
        Dim alpha As Byte = CByte(ConfigurationUser.GetConfig(currentUserId, "alpha.statusbar"))
        Me.StatusColor = Color.FromArgb(alpha, ConfigurationUser.GetColorConfiguration(currentUserId, "color.normal"))
        Me.StatusDescription = myStringParserService.Parse("${res:Global.Already}")
        Me.StatusBarService.SetMessage(Me.StatusDescription)
        Me.StatusBarService.SetStatusMessage(Me.StatusMessage, Me.StatusColor)
      End If
    End Sub
#End Region

#Region "ISimpleEntityPanel"
    Public Event EntityPropertyChanged(ByVal sender As Object, ByVal e As System.EventArgs) Implements ISimpleEntityPanel.EntityPropertyChanged

    Public Overridable Sub CheckFormEnable() Implements ISimpleEntityPanel.CheckFormEnable
      Debug.WriteLine("Implement Me! (AbstractEntityDetailPanelView.CheckFormEnable)")
    End Sub

    Public Overridable Sub ClearDetail() Implements ISimpleEntityPanel.ClearDetail
      Debug.WriteLine("Implement Me! (AbstractEntityDetailPanelView.ClearDetail)")
    End Sub

    Public Overridable Property Entity() As BusinessLogic.ISimpleEntity Implements ISimpleEntityPanel.Entity
      Get

      End Get
      Set(ByVal Value As BusinessLogic.ISimpleEntity)

      End Set
    End Property
    Public Overridable Sub SetLabelText() Implements ISimpleEntityPanel.SetLabelText
      Debug.WriteLine("Implement Me! (AbstractEntityDetailPanelView.SetLabelText)")
    End Sub

    Public Overridable Sub UpdateEntityProperties() Implements ISimpleEntityPanel.UpdateEntityProperties
      Debug.WriteLine("Implement Me! (AbstractEntityDetailPanelView.UpdateEntityProperties)")
    End Sub

    Public Overridable Sub Initialize() Implements ISimpleEntityPanel.Initialize
      Debug.WriteLine("Implement Me! (AbstractEntityDetailPanelView.Initialize)")
    End Sub

    Public Overridable ReadOnly Property Icon() As String Implements ISimpleEntityPanel.Icon
      Get
        'If Me.Entity Is Nothing Then
        '    Return Me.Owner.Entity.DetailPanelIcon
        'End If
        'Return Me.Entity.DetailPanelIcon
      End Get
    End Property
    Public Overridable Sub ShowInPad() Implements ISimpleEntityPanel.ShowInPad

    End Sub
    Public Overridable ReadOnly Property Title() As String Implements ISimpleEntityPanel.Title
      Get
        'If Me.Entity Is Nothing Then
        '    Return Me.Owner.Entity.DetailPanelTitle
        'End If
        'Return Me.Entity.DetailPanelTitle
      End Get
    End Property
#End Region

#Region "ISecondaryViewContent"

    Public Event WorkbenchWindowChanged As EventHandler
    Protected Overridable Sub OnWorkbenchWindowChanged(ByVal e As EventArgs)
      RaiseEvent WorkbenchWindowChanged(Me, e)
    End Sub

    Public ReadOnly Property Control() As System.Windows.Forms.Control Implements IBaseViewContent.Control
      Get
        Return Me
      End Get
    End Property
    Public Overridable Sub Deselected() Implements IBaseViewContent.Deselected
      If Not Me.WorkbenchWindow.SubViewContents Is Nothing Then
        'CType(Me.WorkbenchWindow.SubViewContents(0), IListPanel).SelectedEntity = Me.Entity
      End If
    End Sub
    Public Overridable Sub RedrawContent() Implements IBaseViewContent.RedrawContent
    End Sub
    Public Overridable Sub InitProgress()
      Dim totalWork As Integer = 10 * Me.WorkbenchWindow.SubViewContents.Count - 1
      Dim myStatusBarService As IStatusBarService = CType(ServiceManager.Services.GetService(GetType(IStatusBarService)), IStatusBarService)
      myStatusBarService.ProgressMonitor.BeginTask("${res:MainWindow.StatusBar.LoadingEntity}", totalWork)
    End Sub
    Public Overridable Sub EndProgress()
      Dim myStatusBarService As IStatusBarService = CType(ServiceManager.Services.GetService(GetType(IStatusBarService)), IStatusBarService)
      myStatusBarService.ProgressMonitor.Done()
    End Sub
    Public Overridable Sub Selected() Implements IBaseViewContent.Selected
      If Not Me.WorkbenchWindow Is Nothing Then
        If Not Me.WorkbenchWindow.SubViewContents Is Nothing AndAlso Me.WorkbenchWindow.SubViewContents.Count > 0 Then
          If TypeOf Me.WorkbenchWindow.SubViewContents(0) Is ISimpleListPanel Then
            Dim selectedEntity As ISimpleEntity = CType(Me.WorkbenchWindow.SubViewContents(0), ISimpleListPanel).SelectedEntity
            If selectedEntity Is Nothing Then
              CType(Me.WorkbenchWindow.SubViewContents(0), ISimpleListPanel).AddNew()
              Return
            End If
            For i As Integer = 1 To Me.WorkbenchWindow.SubViewContents.Count - 1
              If TypeOf Me.WorkbenchWindow.SubViewContents(i) Is AbstractEntityDetailPanelView Then
                Dim myView As AbstractEntityDetailPanelView = CType(Me.WorkbenchWindow.SubViewContents(i), AbstractEntityDetailPanelView)
                myView.InitProgress()
                myView.Entity = selectedEntity
                EndProgress()
              End If
            Next
          End If
          'If Not Me.WorkbenchWindow.SubViewContents(0) Is Nothing Then
          '    If TypeOf Me.WorkbenchWindow.SubViewContents(0) Is ISimpleListPanel Then
          '        Dim selectedEntity As ISimpleEntity = CType(Me.WorkbenchWindow.SubViewContents(0), ISimpleListPanel).SelectedEntity
          '        If selectedEntity Is Nothing Then
          '            CType(Me.WorkbenchWindow.SubViewContents(0), ISimpleListPanel).AddNew()
          '            Return
          '        End If
          '        Me.Entity = CType(Me.WorkbenchWindow.SubViewContents(0), ISimpleListPanel).SelectedEntity
          '    End If
          'End If
        End If
      End If
    End Sub
    Public Overridable Sub SwitchedTo() Implements IBaseViewContent.SwitchedTo
    End Sub
    Public ReadOnly Property TabPageText() As String Implements IBaseViewContent.TabPageText
      Get
        Return "${res:" & Me.GetType.FullName & ".TabPageText}"
      End Get
    End Property
    Public Overridable ReadOnly Property TabPageIcon() As String Implements Longkong.Pojjaman.Gui.IBaseViewContent.TabPageIcon
      Get
        Return "${res:" & Me.GetType.FullName & ".TabPageIcon}"
      End Get
    End Property
    Public Overridable Property WorkbenchWindow() As IWorkbenchWindow Implements IBaseViewContent.WorkbenchWindow
      Get
        Return Me.m_workbenchWindow
      End Get
      Set(ByVal Value As IWorkbenchWindow)
        Me.m_workbenchWindow = Value
        Me.OnWorkbenchWindowChanged(EventArgs.Empty)
      End Set
    End Property
    Public Overridable Sub NotifyAfterSave(ByVal successful As Boolean) Implements ISecondaryViewContent.NotifyAfterSave
      If Not successful Then
        Return
      End If
      Dim myEntity As SimpleBusinessEntityBase = SimpleBusinessEntityBase.GetEntity(Me.Entity.FullClassName, Entity.Id)
      'Me.Entity = Nothing
      Me.Entity = myEntity
      Dim listPanel As ISimpleListPanel = CType(Me.WorkbenchWindow.ViewContent, ISimpleListPanel)
      If Not listPanel.SelectedEntity Is Nothing Then
        RemoveHandler listPanel.SelectedEntity.TabPageTextChanged, AddressOf listPanel.ChangeTitle
      End If
      'Performance!!!
      listPanel.SelectedEntity = Nothing
      GC.Collect()
      'END Performance!!!

      listPanel.SelectedEntity = Me.Entity
      AddHandler listPanel.SelectedEntity.TabPageTextChanged, AddressOf listPanel.ChangeTitle

    End Sub
    Public Overridable Sub NotifyBeforeSave() Implements ISecondaryViewContent.NotifyBeforeSave

    End Sub
#End Region

#Region "InewPrintable"
    Public Overridable Sub ShowSelectSchemaDataDialog() Implements INewPrintable.ShowSelectSchemaDataDialog
      If Not Me.Entity Is Nothing Then
        If TypeOf Me.Entity Is ISimpleEntity Then
          'Dim exdata As EntitySimpleSchema = CType(Me.Entity, INewPrintable).SimpleSchema
          'If Not exdata Is Nothing AndAlso Not exdata.DataSet Is Nothing Then
          If TypeOf Me.Entity Is SimpleBusinessEntityBase Then
            'CType(Me.Entity, SimpleBusinessEntityBase).NewPrintableEntities = New SuperPrintableEntity
            If TypeOf Me.Entity Is INewPrintableEntity Then
              CType(Me.Entity, SimpleBusinessEntityBase).NewPrintableEntities = CType(Me.Entity, INewPrintableEntity)
              Dim dialog As New SchemaDataExportDialog(CType(Me.Entity, INewPrintableEntity), Me.Entity) ', New SuperPrintableEntity)
              'Dim filePath As String = ""
              dialog.StartPosition = FormStartPosition.CenterParent
              dialog.ShowDialog()
              If dialog.IsOpenFormDesigner Then
                Dim newReport As New XtraReport
                newReport = XtraReport.FromFile(dialog.FilePath, True)
                Dim userLookAndFeel_ As New UserLookAndFeel(newReport)
                userLookAndFeel_.UseDefaultLookAndFeel = False
                userLookAndFeel_.UseWindowsXPTheme = False
                userLookAndFeel_.Style = LookAndFeelStyle.Skin
                userLookAndFeel_.SkinName = "Metropolis"
                'newReport.ShowRibbonDesigner(userLookAndFeel_)
                newReport.ShowRibbonDesigner(userLookAndFeel_)
              End If

              'dialog.Show()
            End If
          End If
          'End If
        End If
      End If
    End Sub
    Public Overridable ReadOnly Property CanExportSchema As Boolean Implements INewPrintable.CanExportSchema
      Get
        Return True
      End Get
    End Property
#End Region

#Region "Datetime"
    Public Overloads Function DateToString(ByVal dtp As DateTimePicker, ByVal txtdate As TextBox) As String
      txtdate.Text = String.Format("{0:dd\/MM\/yyyy}", dtp.Value)
      Return String.Format("{0:dd\/MM\/yyyy}", dtp.Value)
    End Function
    Public Overloads Function DateToString(ByVal dt As DateTime, ByVal txtdate As TextBox) As String
      Dim dateStr As String
      If dt.Equals(Date.MinValue) Then
        dateStr = Nothing
      Else
        dateStr = String.Format("{0:dd\/MM\/yyyy}", dt)
      End If
      txtdate.Text = dateStr
      Return dateStr
    End Function

    Public Function StringToDate(ByVal txtdate As TextBox, ByVal dtp As DateTimePicker) As DateTime
      If txtdate.Text Is Nothing OrElse txtdate.TextLength = 0 Then
        dtp.Value = Date.Now
        txtdate.Text = Nothing
        Return Date.MinValue
      Else
        If IsDate(txtdate.Text) Then
          dtp.Value = Convert.ToDateTime(txtdate.Text)
          Return dtp.Value
        Else
          dtp.Value = Date.Now
          txtdate.Text = Nothing
          Return Date.MinValue
        End If

      End If
    End Function
#End Region

#Region "IEditable"
    Public Overridable ReadOnly Property ClipboardHandler() As IClipboardHandler Implements IEditable.ClipboardHandler
      Get
        Return Me
      End Get
    End Property
    Public Overridable ReadOnly Property EnableRedo() As Boolean Implements IEditable.EnableRedo
      Get
        Return False
      End Get
    End Property
    Public Overridable ReadOnly Property EnableUndo() As Boolean Implements IEditable.EnableUndo
      Get
        Return False
      End Get
    End Property
    Public Overridable Sub Redo() Implements IEditable.Redo

    End Sub
    Public Overridable Property Text1() As String Implements IEditable.Text
      Get

      End Get
      Set(ByVal Value As String)

      End Set
    End Property
    Public Overridable Sub Undo() Implements IEditable.Undo

    End Sub
#End Region

#Region "IClipboardHandler"
    Public Overridable Sub Copy(ByVal sender As Object, ByVal e As System.EventArgs) Implements IClipboardHandler.Copy

    End Sub
    Public Overridable Sub Cut(ByVal sender As Object, ByVal e As System.EventArgs) Implements IClipboardHandler.Cut

    End Sub
    Public Overridable Sub Delete(ByVal sender As Object, ByVal e As System.EventArgs) Implements IClipboardHandler.Delete

    End Sub
    Public Overridable ReadOnly Property EnableCopy() As Boolean Implements IClipboardHandler.EnableCopy
      Get
        Return False
      End Get
    End Property
    Public Overridable ReadOnly Property EnableCut() As Boolean Implements IClipboardHandler.EnableCut
      Get
        Return False
      End Get
    End Property
    Public Overridable ReadOnly Property EnableDelete() As Boolean Implements IClipboardHandler.EnableDelete
      Get
        Return False
      End Get
    End Property
    Public Overridable ReadOnly Property EnablePaste() As Boolean Implements IClipboardHandler.EnablePaste
      Get
        Return False
      End Get
    End Property
    Public Overridable ReadOnly Property EnableSelectAll() As Boolean Implements IClipboardHandler.EnableSelectAll
      Get
        Return False
      End Get
    End Property
    Public Overridable Sub Paste(ByVal sender As Object, ByVal e As System.EventArgs) Implements IClipboardHandler.Paste

    End Sub
    Public Overridable Sub SelectAll(ByVal sender As Object, ByVal e As System.EventArgs) Implements IClipboardHandler.SelectAll

    End Sub
#End Region

#Region "IPrintable"
    Private thePath As String = ""
    Public Overridable ReadOnly Property PrintDocument() As System.Drawing.Printing.PrintDocument Implements IPrintable.PrintDocument
      Get
        Dim myPropertyService As PropertyService = CType(ServiceManager.Services.GetService(GetType(PropertyService)), PropertyService)
        Dim FormPath As String = (myPropertyService.DataDirectory & Path.DirectorySeparatorChar & "forms" & Path.DirectorySeparatorChar & "Adobe" & Path.DirectorySeparatorChar & "documents")
        Dim ReportPath As String = (myPropertyService.DataDirectory & Path.DirectorySeparatorChar & "forms" & Path.DirectorySeparatorChar & "Adobe" & Path.DirectorySeparatorChar & "reports")

        Dim PrintingReportType As ReportExtentionType = ReportExtentionType.XMLReport

        If Not Me.Entity Is Nothing Then
          If TypeOf Me.Entity Is IPrintableEntity Then
            Dim fileName As String = CType(Me.Entity, IPrintableEntity).GetDefaultForm
            If fileName Is Nothing OrElse fileName.Length = 0 Then
              fileName = Entity.ClassName
            End If
            If TypeOf Entity Is Report Or TypeOf Entity Is FFormat Then
              thePath = ReportPath & Path.DirectorySeparatorChar & fileName & ".xml"
            ElseIf TypeOf Entity Is ISimpleEntity Then
              thePath = FormPath & Path.DirectorySeparatorChar & fileName & ".xml"
            End If

            Dim paths As FormPaths
            Dim nameForPath As String
            If TypeOf Entity Is Report Then
              nameForPath = Entity.FullClassName & ".Reports"
            ElseIf TypeOf Entity Is ISimpleEntity Then
              nameForPath = Entity.FullClassName & ".Documents"
            End If
            Dim myProperties As PropertyService = CType(ServiceManager.Services.GetService(GetType(PropertyService)), PropertyService)
            paths = CType(myProperties.GetProperty(nameForPath, New FormPaths(nameForPath, Entity.ClassName, thePath)), FormPaths)
            Dim dlg As New Longkong.Pojjaman.Gui.Dialogs.SelectFormsDialog(paths)
            If dlg.ShowDialog() = DialogResult.OK Then
              thePath = dlg.KeyValuePair.Value
            Else
              Return Nothing
            End If
            If thePath.EndsWith(".rpt") Then
              PrintingReportType = ReportExtentionType.CrystalReport
            ElseIf thePath.EndsWith(".repx") Then
              PrintingReportType = ReportExtentionType.XtraReport
            End If
            If File.Exists(thePath) Then
              '--Report form แบบใหม่--
              If PrintingReportType = ReportExtentionType.CrystalReport Then
                Dim crform As New CrystalForm(Me.Entity, thePath)
                crform.ShowDialog()
                Return Nothing
              ElseIf PrintingReportType = ReportExtentionType.XtraReport Then
                If TypeOf Me.Entity Is SimpleBusinessEntityBase Then
                  '--เฉพาะรายงานเท่านั้นที่จะเข้าส่วนนี้--
                  '--เพราะว่า Entity เป็นรายงานจริง แต่ว่า Schema และ Data อยากได้ข้อมูลที่มาจาก Grid ที่ Preview อยู่--
                  '--ยัดค่ามาจาก GridReportPanelView เรียบร้อยแล้ว--
                  If Not CType(Me.Entity, SimpleBusinessEntityBase).NewPrintableEntities Is Nothing AndAlso
                    TypeOf CType(Me.Entity, SimpleBusinessEntityBase).NewPrintableEntities Is GridReportPanelView Then
                    Dim xtform As New XtraForm(CType(Me.Entity, SimpleBusinessEntityBase).NewPrintableEntities, thePath, Me.Entity)
                    xtform.ShowDialog()
                    Return Nothing
                  End If
                End If

                If TypeOf Me.Entity Is INewPrintableEntity Then
                  Dim xtform As New XtraForm(CType(Me.Entity, INewPrintableEntity), thePath, Me.Entity)
                  xtform.ShowDialog()
                End If

                'Dim xtform As New XtraForm(Me.Entity, thePath, New SuperPrintableEntity)

                Return Nothing
              End If
              '--ส่วนด้านล่างเป็น form แบบเดิม--
              If TypeOf Me.Entity Is RptFinancialStatement Then
                Dim fform As New FFormatForm(thePath, CType(Me.Entity, IPrintableEntity))
                Return fform.PrintDocument
              ElseIf TypeOf Me.Entity Is FFormat Then
                Dim fform As New FFormatForm(thePath, CType(Me.Entity, IPrintableEntity))
                Return fform.PrintDocument
              ElseIf Me.Entity.ClassName.ToLower = "complexreport" Then
                Dim fform As New ComplexReportForm(thePath, CType(Me.Entity, IPrintableEntity))
                Return fform.PrintDocument
              Else
                'Dim df As New DesignerForm(thePath, CType(Me.Entity, IPrintableEntity))
                Dim df As New DesignerForm(thePath, New SuperPrintableEntity)
                Return df.PrintDocument
              End If
            End If
          End If
        End If
      End Get
    End Property
    Public Overridable ReadOnly Property CanPrint() As Boolean Implements IPrintable.CanPrint
      Get
        Return True
      End Get
    End Property
    Public Overridable ReadOnly Property PrintDocuments() As System.Collections.ArrayList Implements IPrintable.PrintDocuments
      Get

      End Get
    End Property
#End Region

#Region "IKeyReceiver"
    Public Overridable Function ProcessKey(ByVal keyPressed As System.Windows.Forms.Keys) As Boolean Implements Commands.IKeyReceiver.ProcessKey
      Select Case keyPressed
        Case Keys.Enter
          If TypeOf Me.ActiveControl Is TextBox Then
            If Me.ActiveControl.Name.ToLower.StartsWith("txt") Then
              If CType(Me.ActiveControl, TextBox).Multiline Then
                Dim tmpIndx As Integer = CType(Me.ActiveControl, TextBox).SelectionStart
                CType(Me.ActiveControl, TextBox).Text = CType(Me.ActiveControl, TextBox).Text.Insert(CType(Me.ActiveControl, TextBox).SelectionStart, vbCrLf)
                CType(Me.ActiveControl, TextBox).SelectionStart = tmpIndx + 2
                Return True
              End If
            End If
          End If
          SendKeys.Send("{tab}")
          Return True
      End Select
      Dim receiver As IKeyReceiver
      For Each ctrl As Control In Me.Controls
        If TypeOf ctrl Is IKeyReceiver Then
          receiver = CType(ctrl, IKeyReceiver)
        End If
      Next
      If Not (receiver Is Nothing) Then
        Return receiver.ProcessKey(keyPressed)
      End If
      Return False
    End Function
#End Region

#Region "ISecurityValidatable"
    Public Overridable ReadOnly Property FormSecurityValidator() As Components.SecurityValidator Implements ISecurityValidatable.FormSecurityValidator
      Get

      End Get
    End Property
#End Region

  End Class

  Public Class SuperPrintableEntity
    Implements IPrintableEntity, IHasStatusString, IHasEntityList ', INewPrintableEntity

    Private m_entities As List(Of IPrintableEntity)
    Private m_entityNames As Dictionary(Of IPrintableEntity, String)

    'Private m_newentities As List(Of INewPrintableEntity)
    'Private m_newentityNames As Dictionary(Of INewPrintableEntity, String)

    Public Sub New()
      m_entities = New List(Of IPrintableEntity)
      'm_newentities = New List(Of INewPrintableEntity)
      m_entityNames = New Dictionary(Of IPrintableEntity, String)
      'm_newentityNames = New Dictionary(Of INewPrintableEntity, String)

      Dim window As IWorkbenchWindow = WorkbenchSingleton.Workbench.ActiveWorkbenchWindow
      For Each myview As Object In window.SubViewContents
        If TypeOf myview Is IAuxTab Then
          Dim aux As Object = CType(myview, IAuxTab).AuxEntity
          If aux Is Nothing Then
            aux = CType(myview, IAuxTabItem).AuxEntityItem
          End If

          If TypeOf aux Is IPrintableEntity Then
            Dim auxPrintable As IPrintableEntity = CType(aux, IPrintableEntity)
            If Not m_entityNames.ContainsKey(CType(auxPrintable, IPrintableEntity)) Then
              m_entityNames(CType(auxPrintable, IPrintableEntity)) = myview.GetType.Name
            End If
            m_entities.Add(CType(auxPrintable, IPrintableEntity))
            If String.IsNullOrEmpty(m_StatusString) Then
              If TypeOf aux Is IHasStatusString Then
                If Not String.IsNullOrEmpty(CType(aux, IHasStatusString).StatusString) Then
                  m_StatusString = CType(aux, IHasStatusString).StatusString
                End If
              End If
            End If
          End If
          'If TypeOf aux Is INewPrintableEntity Then
          '  Dim auxPrintable As INewPrintableEntity = CType(aux, INewPrintableEntity)
          '  If Not m_newentityNames.ContainsKey(CType(auxPrintable, INewPrintableEntity)) Then
          '    m_newentityNames(CType(auxPrintable, INewPrintableEntity)) = myview.GetType.Name
          '  End If
          '  m_newentities.Add(CType(auxPrintable, INewPrintableEntity))
          '  'If String.IsNullOrEmpty(m_StatusString) Then
          '  '  If TypeOf aux Is IHasStatusString Then
          '  '    If Not String.IsNullOrEmpty(CType(aux, IHasStatusString).StatusString) Then
          '  '      m_StatusString = CType(aux, IHasStatusString).StatusString
          '  '    End If
          '  '  End If
          '  'End If
          'End If

        ElseIf Not TypeOf myview Is AbstractEntityPanelViewContent AndAlso TypeOf myview Is ISimpleEntityPanel Then

          Dim myentity As Object = CType(window.ActiveViewContent, ISimpleEntityPanel).Entity
          If TypeOf myentity Is IPrintableEntity Then
            Dim iprintable As IPrintableEntity = CType(myentity, IPrintableEntity)
            If Not m_entityNames.ContainsKey(CType(iprintable, IPrintableEntity)) Then
              m_entityNames(CType(iprintable, IPrintableEntity)) = myview.GetType.Name
            End If
            m_entities.Add(CType(iprintable, IPrintableEntity))
            If String.IsNullOrEmpty(m_StatusString) Then
              If TypeOf myentity Is IHasStatusString Then
                If Not String.IsNullOrEmpty(CType(myentity, IHasStatusString).StatusString) Then
                  m_StatusString = CType(myentity, IHasStatusString).StatusString
                End If
              End If
            End If
          End If

          'If TypeOf myentity Is INewPrintableEntity Then
          '  Dim iprintable As INewPrintableEntity = CType(myentity, INewPrintableEntity)
          '  If Not m_newentityNames.ContainsKey(CType(iprintable, INewPrintableEntity)) Then
          '    m_newentityNames(CType(iprintable, INewPrintableEntity)) = myview.GetType.Name
          '  End If
          '  m_newentities.Add(CType(iprintable, INewPrintableEntity))
          '  'If String.IsNullOrEmpty(m_StatusString) Then
          '  '  If TypeOf myentity Is IHasStatusString Then
          '  '    If Not String.IsNullOrEmpty(CType(myentity, IHasStatusString).StatusString) Then
          '  '      m_StatusString = CType(myentity, IHasStatusString).StatusString
          '  '    End If
          '  '  End If
          '  'End If
          'End If

        End If
      Next
      For Each e As IPrintableEntity In m_entities
        If TypeOf e Is ISimpleEntity Then
          EntityList.Add(CType(e, ISimpleEntity))
        End If
      Next
    End Sub

    Public Property Code As String Implements BusinessLogic.IIdentifiable.Code
      Get

      End Get
      Set(ByVal value As String)

      End Set
    End Property

    Public Property Id As Integer Implements BusinessLogic.IIdentifiable.Id
      Get

      End Get
      Set(ByVal value As Integer)

      End Set
    End Property

    Public Function GetDefaultForm() As String Implements BusinessLogic.IPrintableEntity.GetDefaultForm

    End Function

    Public Function GetDefaultFormPath() As String Implements BusinessLogic.IPrintableEntity.GetDefaultFormPath

    End Function

    Public Function GetDocPrintingEntries() As BusinessLogic.DocPrintingItemCollection Implements BusinessLogic.IPrintableEntity.GetDocPrintingEntries
      Dim ret As New DocPrintingItemCollection
      Dim tmpRet As New DocPrintingItemCollection
      Dim window As IWorkbenchWindow = WorkbenchSingleton.Workbench.ActiveWorkbenchWindow
      Dim activeContent As Object = window.ActiveViewContent
      For Each entity As IPrintableEntity In m_entities
        Dim dpiColl As DocPrintingItemCollection = entity.GetDocPrintingEntries
        For Each dpi As DocPrintingItem In dpiColl 'entity.GetDocPrintingEntries
          Dim tmpDPI As DocPrintingItem = dpi.Clone
          If Not tmpDPI.Mapping Is Nothing Then
            If m_entityNames.ContainsKey(entity) Then
              tmpDPI.Mapping = m_entityNames(entity) & "." & tmpDPI.Mapping
              If Not String.IsNullOrEmpty(tmpDPI.Table) Then
                tmpDPI.Table = m_entityNames(entity) & "." & tmpDPI.Table
              End If
              If activeContent.GetType.Name = m_entityNames(entity) Then
                ret.Add(dpi)
              End If
            End If
          End If
          tmpRet.Add(tmpDPI)
        Next

        If Not dpiColl.RelationList Is Nothing AndAlso dpiColl.RelationList.Count > 0 Then
          tmpRet.RelationList.AddRange(dpiColl.RelationList)
        End If

        '==============================CUSTOM NOTES=============================================
        If m_entityNames.ContainsKey(entity) AndAlso activeContent.GetType.Name = m_entityNames(entity) Then
          If TypeOf entity Is IHasCustomNote Then
            Dim coll As CustomNoteCollection        ' = CType(m_entity, IHasCustomNote).GetCustomNoteCollection
            If TypeOf entity Is IHasMainDoc Then
              If Not (TypeOf (entity) Is JournalEntry) Then
                coll = CType(CType(entity, IHasMainDoc).MainDoc, IHasCustomNote).GetCustomNoteCollection
              Else
                coll = CType(entity, IHasCustomNote).GetCustomNoteCollection
              End If
            Else
              coll = CType(entity, IHasCustomNote).GetCustomNoteCollection
            End If
            For Each note As CustomNote In coll
              Dim dpi As New DocPrintingItem
              dpi.Mapping = "Note." & note.NoteName
              If note.IsDropDown Then
                dpi.Value = Boolean.Parse(CStr(note.Note))
                dpi.DataType = "System.Boolean"
              Else
                dpi.Value = CStr(note.Note)
                dpi.DataType = "System.String"
              End If
              ret.Add(dpi)
            Next
          End If
        End If
        '==============================END CUSTOM NOTES=============================================

      Next

      Dim myDpiColl As New DocPrintingItemCollection
      Dim myDpi As DocPrintingItem
      For Each entity As IPrintableEntity In m_entities
        If TypeOf entity Is ISimpleEntity Then
          Dim myEntity As ISimpleEntity = CType(entity, ISimpleEntity)

          'ชื่อผู้สร้างเอกสาร
          If myEntity.Originator IsNot Nothing Then
            myDpi = New DocPrintingItem
            myDpi.Mapping = "CreatorId"
            myDpi.Value = myEntity.Originator.Id
            myDpi.DataType = "System.String"
            myDpi.SignatureType = SignatureType.User
            myDpiColl.Add(myDpi)

            myDpi = New DocPrintingItem
            myDpi.Mapping = "CreatorName"
            myDpi.Value = myEntity.Originator.Name
            myDpi.DataType = "System.String"
            myDpiColl.Add(myDpi)

            myDpi = New DocPrintingItem
            myDpi.Mapping = "CreatorCode"
            myDpi.Value = myEntity.Originator.Code
            myDpi.DataType = "System.String"
            myDpiColl.Add(myDpi)

            myDpi = New DocPrintingItem
            myDpi.Mapping = "CreatorInfo"
            myDpi.Value = myEntity.Originator.Code & ":" & myEntity.Originator.Name
            myDpi.DataType = "System.String"
            myDpiColl.Add(myDpi)
          End If

          'วันที่สร้างเอกสาร
          If myEntity.OriginDate <> Date.MinValue Then
            myDpi = New DocPrintingItem
            myDpi.Mapping = "CreateDate"
            myDpi.Value = myEntity.OriginDate.ToShortDateString
            myDpi.DataType = "System.DateTime"
            myDpiColl.Add(myDpi)
          End If

          'ผู้แก้ไขล่าสุด
          If myEntity.LastEditor IsNot Nothing Then
            myDpi = New DocPrintingItem
            myDpi.Mapping = "LastEditorId"
            myDpi.Value = myEntity.LastEditor.Id
            myDpi.DataType = "System.String"
            myDpi.SignatureType = SignatureType.User
            myDpiColl.Add(myDpi)

            myDpi = New DocPrintingItem
            myDpi.Mapping = "LastEditorName"
            myDpi.Value = myEntity.LastEditor.Name
            myDpi.DataType = "System.String"
            myDpiColl.Add(myDpi)

            myDpi = New DocPrintingItem
            myDpi.Mapping = "LastEditorCode"
            myDpi.Value = myEntity.LastEditor.Code
            myDpi.DataType = "System.String"
            myDpiColl.Add(myDpi)

            myDpi = New DocPrintingItem
            myDpi.Mapping = "LastEditorInfo"
            myDpi.Value = myEntity.LastEditor.Code & ":" & myEntity.LastEditor.Name
            myDpi.DataType = "System.String"
            myDpiColl.Add(myDpi)
          End If

          'วันที่แก้ไขล่าสุด
          If myEntity.LastEditDate <> Date.MinValue Then
            myDpi = New DocPrintingItem
            myDpi.Mapping = "LastEditDate"
            myDpi.Value = myEntity.LastEditDate.ToShortDateString
            myDpi.DataType = "System.DateTime"
            myDpiColl.Add(myDpi)
          End If

          'ผู้ที่ทำเอกสาร
          Dim mySecurity As SecurityService = CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService)
          myDpi = New DocPrintingItem
          myDpi.Mapping = "UserId"
          myDpi.Value = mySecurity.CurrentUser.Id
          myDpi.DataType = "System.String"
          myDpi.SignatureType = SignatureType.User
          myDpiColl.Add(myDpi)

          'ผู้ที่ Print
          'Dim mySecurity As SecurityService = CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService)
          myDpi = New DocPrintingItem
          myDpi.Mapping = "PrintBy"
          myDpi.Value = mySecurity.CurrentUser.Name
          myDpi.DataType = "System.String"
          myDpiColl.Add(myDpi)

          'วันที่ Print
          myDpi = New DocPrintingItem
          myDpi.Mapping = "PrintDate"
          myDpi.Value = Date.Now.ToString("dd/MM/yyyy hh:mm:ss")
          myDpi.DataType = "System.Datetime"
          myDpiColl.Add(myDpi)

          'จำนวนครั้งที่ Print
          myDpi = New DocPrintingItem
          myDpi.Mapping = m_entityNames(entity) & "." & "PrintNumber"
          myDpi.Value = myEntity.GetNumberOfPrinting + 1
          myDpi.DataType = "System.Integer"
          myDpiColl.Add(myDpi)

        End If
      Next

      If Not tmpRet.RelationList Is Nothing AndAlso tmpRet.RelationList.Count > 0 Then
        ret.RelationList.AddRange(tmpRet.RelationList)
      End If
      If Not myDpiColl.RelationList Is Nothing AndAlso myDpiColl.RelationList.Count > 0 Then
        ret.RelationList.AddRange(myDpiColl.RelationList)
      End If

      ret.AddRange(tmpRet)
      ret.AddRange(myDpiColl)
      Return ret
    End Function

#Region "INewPrintableEntity"
    'Public Function GetDocPrintingCollumnsEntries() As DocPrintingItemCollection Implements INewPrintableEntity.GetDocPrintingColumnsEntries
    '  Dim ret As New DocPrintingItemCollection
    '  Dim tmpRet As New DocPrintingItemCollection
    '  Dim window As IWorkbenchWindow = WorkbenchSingleton.Workbench.ActiveWorkbenchWindow
    '  Dim activeContent As Object = window.ActiveViewContent
    '  For Each entity As INewPrintableEntity In m_entities
    '    For Each dpi As DocPrintingItem In entity.GetDocPrintingColumnsEntries
    '      Dim tmpDPI As DocPrintingItem = dpi.Clone
    '      If Not tmpDPI.Mapping Is Nothing Then
    '        If m_newentityNames.ContainsKey(entity) Then
    '          tmpDPI.Mapping = m_newentityNames(entity) & "." & tmpDPI.Mapping
    '          If Not String.IsNullOrEmpty(tmpDPI.Table) Then
    '            tmpDPI.Table = m_newentityNames(entity) & "." & tmpDPI.Table
    '          End If
    '          If activeContent.GetType.Name = m_newentityNames(entity) Then
    '            ret.Add(dpi)
    '          End If
    '        End If
    '      End If
    '      tmpRet.Add(tmpDPI)
    '    Next

    '    If Not entity.GetDocPrintingColumnsEntries.RelationList Is Nothing AndAlso entity.GetDocPrintingColumnsEntries.RelationList.Count > 0 Then
    '      tmpRet.RelationList.AddRange(entity.GetDocPrintingColumnsEntries.RelationList)
    '    End If

    '    '==============================CUSTOM NOTES=============================================
    '    If m_newentityNames.ContainsKey(entity) AndAlso activeContent.GetType.Name = m_newentityNames(entity) Then
    '      If TypeOf entity Is IHasCustomNote Then
    '        Dim coll As CustomNoteCollection
    '        If TypeOf entity Is IHasMainDoc Then
    '          If Not (TypeOf (entity) Is JournalEntry) Then
    '            coll = CType(CType(entity, IHasMainDoc).MainDoc, IHasCustomNote).GetCustomNoteCollection
    '          Else
    '            coll = CType(entity, IHasCustomNote).GetCustomNoteCollection
    '          End If
    '        Else
    '          coll = CType(entity, IHasCustomNote).GetCustomNoteCollection
    '        End If
    '        For Each note As CustomNote In coll
    '          Dim dpi As New DocPrintingItem
    '          dpi.Mapping = "Note." & note.NoteName
    '          If note.IsDropDown Then
    '            dpi.Value = Boolean.Parse(CStr(note.Note))
    '            dpi.DataType = "System.Boolean"
    '          Else
    '            dpi.Value = CStr(note.Note)
    '            dpi.DataType = "System.String"
    '          End If
    '          ret.Add(dpi)
    '        Next
    '      End If
    '    End If
    '    '==============================END CUSTOM NOTES=============================================

    '  Next

    '  Dim myDpiColl As New DocPrintingItemCollection
    '  Dim myDpi As DocPrintingItem
    '  For Each entity As INewPrintableEntity In m_entities
    '    If TypeOf entity Is ISimpleEntity Then
    '      Dim myEntity As ISimpleEntity = CType(entity, ISimpleEntity)

    '      myDpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("CreatorId", "System.String"))
    '      myDpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("CreatorName", "System.String"))
    '      myDpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("CreatorCode", "System.String"))
    '      myDpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("CreatorInfo", "System.String"))
    '      myDpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("CreateDate", "System.DateTime"))
    '      myDpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("LastEditorId", "System.String"))
    '      myDpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("LastEditorCode", "System.String"))
    '      myDpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("LastEditorName", "System.String"))
    '      myDpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("LastEditorInfo", "System.String"))
    '      myDpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("LastEditDate", "System.DateTime"))
    '      myDpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("UserId", "System.String"))
    '      myDpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("PrintBy", "System.String"))
    '      myDpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("PrintDate", "System.Datetime"))

    '    End If
    '  Next

    '  If Not tmpRet.RelationList Is Nothing AndAlso tmpRet.RelationList.Count > 0 Then
    '    ret.RelationList.AddRange(tmpRet.RelationList)
    '  End If
    '  If Not myDpiColl.RelationList Is Nothing AndAlso myDpiColl.RelationList.Count > 0 Then
    '    ret.RelationList.AddRange(myDpiColl.RelationList)
    '  End If

    '  ret.AddRange(tmpRet)
    '  ret.AddRange(myDpiColl)
    '  Return ret
    'End Function
    'Public Function GetDocPrintingDataEntries() As DocPrintingItemCollection Implements INewPrintableEntity.GetDocPrintingDataEntries
    '  Return Me.GetDocPrintingEntries
    'End Function
#End Region

    Private m_StatusString As String
    Public ReadOnly Property StatusString As String Implements BusinessLogic.IHasStatusString.StatusString
      Get
        Return m_StatusString
      End Get
    End Property
    Private m_EntityList As List(Of ISimpleEntity)
    Public ReadOnly Property EntityList As System.Collections.Generic.List(Of BusinessLogic.ISimpleEntity) Implements BusinessLogic.IHasEntityList.EntityList
      Get
        If m_EntityList Is Nothing Then
          m_EntityList = New List(Of ISimpleEntity)
        End If
        Return m_EntityList
      End Get
    End Property

    Public ReadOnly Property CurrentUserId As Integer Implements BusinessLogic.IHasEntityList.CurrentUserId
      Get
        Dim secServ As SecurityService = CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService)
        If secServ.CurrentUser Is Nothing Then
          Return 0
        End If
        Return secServ.CurrentUser.Id
      End Get
    End Property
  End Class


End Namespace

