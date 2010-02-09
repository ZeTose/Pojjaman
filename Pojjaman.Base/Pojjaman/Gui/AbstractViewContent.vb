Imports System.IO
Namespace Longkong.Pojjaman.Gui
    Public MustInherit Class AbstractViewContent
        Inherits AbstractBaseViewContent
    Implements IViewContent

#Region "Members"
    Private m_panelName As String
    Private m_fileName As String
    Private m_isDirty As Boolean
    Private m_isViewOnly As Boolean
    Private m_titleName As String
    Private m_untitledName As String
    Private m_entity As BusinessLogic.BusinessEntity
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
      Me.m_isViewOnly = False
    End Sub
    Public Sub New(ByVal titleName As String)
      Me.m_untitledName = String.Empty
      Me.m_fileName = Nothing
      Me.m_isDirty = False
      Me.m_isViewOnly = False
      Me.m_titleName = titleName
    End Sub
    Public Sub New(ByVal titleName As String, ByVal fileName As String)
      Me.m_untitledName = String.Empty
      Me.TitleName = Nothing
      Me.m_isDirty = False
      Me.m_isViewOnly = False
      Me.m_titleName = titleName
      Me.m_fileName = fileName
    End Sub
#End Region

#Region "Properties"
    Public Overrides ReadOnly Property Control() As System.Windows.Forms.Control
      Get

      End Get
    End Property
#End Region

#Region "Methods"

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
    Protected Sub SetTitleAndFileName(ByVal fileName As String)
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
        Return Me.m_isViewOnly
      End Get
    End Property
    Public MustOverride Sub Load(ByVal fileName As String) Implements IViewContent.Load
    Public Overridable Overloads Sub Save() Implements IViewContent.Save
      If Me.IsDirty Then
        Me.Save(Me.FileName)
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
    Public Property PanelName() As String Implements IViewContent.PanelName
      Get
        Return m_panelName
      End Get
      Set(ByVal Value As String)
        m_panelName = Value
      End Set
    End Property
#End Region

    Public Property ForceLabel As String Implements IViewContent.ForceLabel
  End Class
End Namespace

