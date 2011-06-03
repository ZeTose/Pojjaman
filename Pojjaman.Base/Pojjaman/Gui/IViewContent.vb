Namespace Longkong.Pojjaman.Gui

    Public Delegate Sub SaveEventHandler(ByVal sender As Object, ByVal e As SaveEventArgs)
    Public Class SaveEventArgs
        Inherits EventArgs

#Region "Members"
        Private m_successful As Boolean
#End Region

#Region "Constructos"
        Public Sub New(ByVal successful As Boolean)
            Me.m_successful = successful
        End Sub
#End Region

#Region "Properties"
        Public ReadOnly Property Successful() As Boolean
            Get
                Return Me.m_successful
            End Get
        End Property
#End Region
    End Class
  Public Interface ISaveContent

  End Interface
    Public Interface IViewContent
        Inherits IBaseViewContent, IDisposable

        ' Events
        Event DirtyChanged As EventHandler
        Event Saved As SaveEventHandler
        Event Saving As EventHandler
        Event TitleNameChanged As EventHandler

        ' Methods
        Sub Load(ByVal fileName As String)
        Sub Save()
        Sub Save(ByVal fileName As String)

        ' Properties
        ReadOnly Property CreateAsSubViewContent() As Boolean
        Property FileName() As String
        Property PanelName() As String
        Property IsDirty() As Boolean
        ReadOnly Property IsReadOnly() As Boolean
        ReadOnly Property IsUntitled() As Boolean
        ReadOnly Property IsViewOnly() As Boolean
        Property TitleName() As String
    Property UntitledName() As String
    Property ForceLabel As String
    End Interface
End Namespace



