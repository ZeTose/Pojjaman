Imports System.Windows.Forms
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
Namespace Longkong.Pojjaman.Gui.Panels
    Public Class AbstractDetailPanelView
        Inherits UserControl
        Implements IListDetail, ISecondaryViewContent

#Region "Members"
        Private m_view As PanelDisplayBinding.PanelView
        Private m_owner As IListPanel
        Private m_workbenchWindow As IWorkbenchWindow
        Private m_securityService As SecurityService
        Private m_StringParserService As StringParserService
        Private m_statusbarService As IStatusBarService
        Private m_dateTimeService As DateTimeService
#End Region

#Region "Constructors"
        Public Sub New()
            MyBase.New()
            InitializeComponent()
            SetLabelText()
            Initialize()
        End Sub
        Public Sub New(ByVal entity As BusinessLogic.BusinessEntity)
            Me.New()
            Me.Entity = entity
        End Sub
#End Region

#Region "Inititialize"
        Protected Overridable Sub InitializeComponent()
            Debug.WriteLine("Implement Me! (AbstractDetailPanelView.InitializeComponent)")
        End Sub
#End Region

#Region "Properties"
        Public ReadOnly Property StatusBarService() As IStatusBarService
            Get
                If m_statusbarService Is Nothing Then
                    m_statusbarService = CType(ServiceManager.Services.GetService(GetType(IStatusBarService)), IStatusBarService)
                End If
                Return m_statusbarService
            End Get
        End Property
        Public ReadOnly Property StringParserService() As StringParserService
            Get
                If m_StringParserService Is Nothing Then
                    m_StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
                End If
                Return m_StringParserService
            End Get
        End Property
        Public ReadOnly Property SecurityService() As SecurityService
            Get
                If m_securityService Is Nothing Then
                    m_securityService = CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService)
                End If
                Return m_securityService
            End Get
        End Property
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
        Public Function MinDateToNow(ByVal dt As Date) As Date
            If dt.Equals(Date.MinValue) Then
                dt = Now
            End If
            Return dt
        End Function
        Protected Sub ControlValidated(ByVal sender As Object, ByVal e As System.EventArgs)
            Try
                RefreshBindings(Me.Entity)
            Catch ex As Exception
                Debug.WriteLine(ex.Message)
            End Try
        End Sub
        Protected Overridable Sub EventWiring()
            Debug.WriteLine("Implement Me! (AbstractDetailPanelView.EventWiring)")
        End Sub
        Protected Overridable Sub AddBinding(ByVal ctrl As System.Windows.Forms.Control, ByVal ds As Object, ByVal prop As String, ByVal name As String)
            Dim t As Date = Now
            Try
                If Not IsNothing(ctrl.DataBindings(prop)) Then
                    ctrl.DataBindings.Remove(ctrl.DataBindings(prop))
                End If
                Dim b As Binding = ctrl.DataBindings.Add(prop, ds, name)
                AddHandler b.Format, AddressOf FormatHandler
                AddHandler b.Parse, AddressOf ParseHandler
            Catch ex As Exception
                Debug.WriteLine(ctrl.Name & ":" & name & ":" & ex.Message)
            End Try
            Debug.WriteLine(ctrl.Name & ":" & name & ":" & Now.Subtract(t).ToString)
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
#End Region

#Region "IListDetail"
        Public Event EntityPropertyChanged(ByVal sender As Object, ByVal e As System.EventArgs) Implements IEntityPanel.EntityPropertyChanged

        Public Overridable Sub CheckFormEnable() Implements IEntityPanel.CheckFormEnable
            Debug.WriteLine("Implement Me! (AbstractDetailPanelView.CheckFormEnable)")
        End Sub

        Public Overridable Sub ClearDetail() Implements IEntityPanel.ClearDetail
            Debug.WriteLine("Implement Me! (AbstractDetailPanelView.ClearDetail)")
        End Sub

        Public Overridable Property Entity() As BusinessLogic.BusinessEntity Implements IEntityPanel.Entity
            Get

            End Get
            Set(ByVal Value As BusinessLogic.BusinessEntity)

            End Set
        End Property
        Public Overridable Sub SetLabelText() Implements IEntityPanel.SetLabelText
            Debug.WriteLine("Implement Me! (AbstractDetailPanelView.SetLabelText)")
        End Sub

        Public Overridable Sub UpdateEntityProperties() Implements IEntityPanel.UpdateEntityProperties
            Debug.WriteLine("Implement Me! (AbstractDetailPanelView.UpdateEntityProperties)")
        End Sub

        Public Overridable Sub Initialize() Implements IListDetail.Initialize
            Debug.WriteLine("Implement Me! (AbstractDetailPanelView.Initialize)")
        End Sub

        Public Overridable Property Owner() As IListPanel Implements IListDetail.Owner
            Get
                Return Me.m_owner
            End Get
            Set(ByVal Value As IListPanel)
                Me.m_owner = Value
            End Set
        End Property
        Public Overridable ReadOnly Property Icon() As String Implements IPanel.Icon
            Get
                If Me.Entity Is Nothing Then
                    Return Me.Owner.Entity.DetailPanelIcon
                End If
                Return Me.Entity.DetailPanelIcon
            End Get
        End Property
        Public Overridable Sub ShowInPad() Implements IPanel.ShowInPad

        End Sub
        Public Overridable ReadOnly Property Title() As String Implements IPanel.Title
            Get
                If Me.Entity Is Nothing Then
                    Return Me.Owner.Entity.DetailPanelTitle
                End If
                Return Me.Entity.DetailPanelTitle
            End Get
        End Property
        Public Overridable Property View() As PanelDisplayBinding.PanelView Implements IPanel.View
            Get
                Return Me.m_view
            End Get
            Set(ByVal Value As PanelDisplayBinding.PanelView)
                Me.m_view = Value
            End Set
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
                CType(Me.WorkbenchWindow.SubViewContents(0), IListPanel).SelectedEntity = Me.Entity
            End If
        End Sub
        Public Overridable Sub RedrawContent() Implements IBaseViewContent.RedrawContent
        End Sub
        Public Overridable Sub Selected() Implements IBaseViewContent.Selected
        End Sub
        Public Overridable Sub SwitchedTo() Implements IBaseViewContent.SwitchedTo
        End Sub
        Public Overridable ReadOnly Property TabPageText() As String Implements IBaseViewContent.TabPageText
            Get

            End Get
        End Property
        Public Overridable ReadOnly Property TabPageIcon() As String Implements Longkong.Pojjaman.Gui.IBaseViewContent.TabPageIcon
            Get
                Return "Abstract Content"
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

        End Sub
        Public Overridable Sub NotifyBeforeSave() Implements ISecondaryViewContent.NotifyBeforeSave

        End Sub
#End Region


    End Class
End Namespace

