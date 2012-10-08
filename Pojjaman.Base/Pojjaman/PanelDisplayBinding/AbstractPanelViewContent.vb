Imports System.IO
Imports Longkong.Pojjaman.Gui.Panels
Imports Longkong.Pojjaman.Gui
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Namespace Longkong.Pojjaman.Gui
    Public Class AbstractPanelViewContent
        Inherits AbstractBasePanelViewContent
        Implements IViewContent

#Region "Members"
        Private m_panelName As String
        Private m_fileName As String
        Private m_isDirty As Boolean
        Private m_titleName As String
        Private m_untitledName As String
        Private m_entity As BusinessLogic.BusinessEntity
        Private m_securityService As SecurityService
        Private m_StringParserService As StringParserService
        Private m_statusbarService As IStatusBarService
#End Region

#Region "Events"
        Public Event FileNameChanged As EventHandler
#End Region

#Region "Constructrs"
        Public Sub New()
            Me.m_untitledName = String.Empty
            Me.m_titleName = Nothing
            Me.m_fileName = Nothing
            Me.m_isDirty = False
            If TypeOf Me Is IEntityPanel Then
                AddHandler CType(Me, IEntityPanel).EntityPropertyChanged, AddressOf Me.PropertyChanged
            End If
        End Sub
#End Region

#Region "Methods"
        Private Sub PropertyChanged(ByVal sender As Object, ByVal e As EventArgs)
            Me.IsDirty = True
        End Sub
        Protected Overridable Sub OnDirtyChanged(ByVal e As EventArgs)
            RaiseEvent DirtyChanged(Me, e)
        End Sub
        Protected Overridable Sub OnFileNameChanged(ByVal e As EventArgs)
            RaiseEvent FileNameChanged(Me, e)
        End Sub
        Protected Overridable Sub OnSaved(ByVal e As SaveEventArgs)
            RaiseEvent Saved(Me, e)
        End Sub
        Protected Overridable Sub OnSaving(ByVal e As EventArgs)
            RaiseEvent Saving(Me, e)
        End Sub
        Protected Overridable Sub OnTitleNameChanged(ByVal e As EventArgs)
            RaiseEvent TitleNameChanged(Me, e)
        End Sub
        Protected Overridable Sub SetTitleAndFileName(ByVal fileName As String)
            Me.TitleName = Path.GetFileName(fileName)
            Me.FileName = fileName
            Me.IsDirty = False
        End Sub
#End Region

#Region "IViewContent"
        Public Event DirtyChanged(ByVal sender As Object, ByVal e As System.EventArgs) Implements IViewContent.DirtyChanged
        Public Event TitleNameChanged(ByVal sender As Object, ByVal e As System.EventArgs) Implements IViewContent.TitleNameChanged
        Public Event Saved(ByVal sender As Object, ByVal e As SaveEventArgs) Implements IViewContent.Saved
        Public Event Saving(ByVal sender As Object, ByVal e As System.EventArgs) Implements IViewContent.Saving

        Public Overridable ReadOnly Property CreateAsSubViewContent() As Boolean Implements IViewContent.CreateAsSubViewContent
            Get
                Return False
            End Get
        End Property
        Public Overridable Property FileName() As String Implements IViewContent.FileName
            Get
                Return Me.m_fileName
            End Get
            Set(ByVal value As String)
                Me.m_fileName = value
                Me.OnFileNameChanged(EventArgs.Empty)
            End Set
        End Property
        Public Overridable Property IsDirty() As Boolean Implements IViewContent.IsDirty
            Get
                Return Me.m_isDirty
            End Get
            Set(ByVal value As Boolean)
                Me.m_isDirty = value
                Me.OnDirtyChanged(EventArgs.Empty)
            End Set
        End Property
        Public Overridable ReadOnly Property IsReadOnly() As Boolean Implements IViewContent.IsReadOnly
            Get
                Return False
            End Get
        End Property
        Public Overridable ReadOnly Property IsUntitled() As Boolean Implements IViewContent.IsUntitled
            Get
                Return (Me.m_titleName Is Nothing)
            End Get
        End Property
        Public Overridable ReadOnly Property IsViewOnly() As Boolean Implements IViewContent.IsViewOnly
            Get
                Return False
            End Get
        End Property
        Public Sub LoadFile(ByVal fileName As String) Implements IViewContent.Load
            Return
        End Sub
        Public Overridable Overloads Sub Save() Implements IViewContent.Save
            If TypeOf Me Is IValidatable Then
                Dim validator As Gui.Components.PJMTextboxValidator = CType(Me, IValidatable).FormValidator
                If Not validator Is Nothing Then
                    If Not validator.ValidationSummary Is Nothing AndAlso validator.ValidationSummary.Length > 0 Then
                        MessageBox.Show(validator.ValidationSummary)
                        Return
                    End If
                End If
            End If
            If TypeOf Me Is IListPanel Then
                Dim eventID As String = CType(Me, IListPanel).SelectedEntity.Save(SecurityService.CurrentUser.Id)
                If Not IsNumeric(eventID) Then 'Todo
                    MessageBox.Show(eventID)
                ElseIf CInt(eventId) = -1 Then
                    'code ซ้ำ
                    'Todo
                    'MessageBox.Show(StringParserService.Parse("รหัส") & " " & CType(Me, IListPanel).SelectedEntity.Code & " " & StringParserService.Parse("มีอยู่แล้ว"))
                    MessageBox.Show(StringParserService.Parse("${res:ShowMessage.AbstractPanelViewContent.Code}") & " " & CType(Me, IListPanel).SelectedEntity.Code & " " & StringParserService.Parse("${res:ShowMessage.AbstractPanelViewContent.Already}"))
                Else
                    'MessageBox.Show(CType(Me, IListPanel).SelectedEntity.TabPageText & " ข้อมูลถูกเก็บเรียบร้อย")
                    MessageBox.Show(CType(Me, IListPanel).SelectedEntity.TabPageText & " " & StringParserService.Parse("${res:ShowMessage.AbstractPanelViewContent.SaveCompleted}"))
                    Me.IsDirty = False
                    Me.OnSaved(New SaveEventArgs(True))
                End If
            ElseIf TypeOf Me Is IEntityPanel Then
                Dim eventID As String = CType(Me, IEntityPanel).Entity.Save(SecurityService.CurrentUser.Id)
                If Not IsNumeric(eventID) Then 'Todo
                    MessageBox.Show(eventID)
                Else
                    'MessageBox.Show("ข้อมูลถูกเก็บเรียบร้อย")
                    MessageBox.Show(StringParserService.Parse("${res:ShowMessage.AbstractPanelViewContent.SaveCompleted}"))
                    Me.IsDirty = False
                    Me.OnSaved(New SaveEventArgs(True))
                End If
            End If
        End Sub
        Public Overridable Overloads Sub Save(ByVal fileName As String) Implements IViewContent.Save
            Throw New NotImplementedException
        End Sub
        Public Overridable Property TitleName() As String Implements IViewContent.TitleName
            Get
                If Not Me.IsUntitled Then
                    Return Me.m_titleName
                End If
                Return Me.m_untitledName
            End Get
            Set(ByVal value As String)
                Me.m_titleName = value
                Me.OnTitleNameChanged(EventArgs.Empty)
            End Set
        End Property
        Public Overridable Property UntitledName() As String Implements IViewContent.UntitledName
            Get
                Return Me.m_untitledName
            End Get
            Set(ByVal value As String)
                Me.m_untitledName = value
            End Set
        End Property
        Public Overridable Property PanelName() As String Implements IViewContent.PanelName
            Get
                Return m_panelName
            End Get
            Set(ByVal Value As String)
                m_panelName = Value
            End Set
        End Property
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
#End Region

    Public Property ForceLabel As String Implements IViewContent.ForceLabel

    End Class
End Namespace

