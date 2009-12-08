Imports Longkong.Pojjaman.Gui
Namespace Longkong.Pojjaman.Gui
    Public MustInherit Class AbstractBaseViewContent
        Implements IBaseViewContent

#Region "Members"
        Private m_workbenchWindow As IWorkbenchWindow
#End Region

#Region "Events"
        Public Event WorkbenchWindowChanged As EventHandler
#End Region

#Region "Constructors"
        Protected Sub New()
            Me.m_workbenchWindow = Nothing
        End Sub
#End Region

#Region "Methods"
        Protected Overridable Sub OnWorkbenchWindowChanged(ByVal e As EventArgs)
            RaiseEvent WorkbenchWindowChanged(Me, e)
        End Sub
#End Region

#Region "IBaseViewContent"
        Public MustOverride ReadOnly Property Control() As System.Windows.Forms.Control Implements Longkong.Pojjaman.Gui.IBaseViewContent.Control
        Public Overridable Sub Deselected() Implements Longkong.Pojjaman.Gui.IBaseViewContent.Deselected
        End Sub
        Public Overridable Sub RedrawContent() Implements Longkong.Pojjaman.Gui.IBaseViewContent.RedrawContent

        End Sub
        Public Overridable Sub Selected() Implements Longkong.Pojjaman.Gui.IBaseViewContent.Selected

        End Sub
        Public Overridable Sub SwitchedTo() Implements Longkong.Pojjaman.Gui.IBaseViewContent.SwitchedTo

        End Sub
        Public Overridable ReadOnly Property TabPageText() As String Implements Longkong.Pojjaman.Gui.IBaseViewContent.TabPageText
            Get
                Return "Abstract Content"
            End Get
        End Property
        Public Overridable ReadOnly Property TabPageIcon() As String Implements Longkong.Pojjaman.Gui.IBaseViewContent.TabPageIcon
            Get
                Return "Abstract Content"
            End Get
        End Property
        Public Overridable Property WorkbenchWindow() As Longkong.Pojjaman.Gui.IWorkbenchWindow Implements Longkong.Pojjaman.Gui.IBaseViewContent.WorkbenchWindow
            Get
                Return Me.m_workbenchWindow
            End Get
            Set(ByVal value As IWorkbenchWindow)
                Me.m_workbenchWindow = value
                Me.OnWorkbenchWindowChanged(EventArgs.Empty)
            End Set
        End Property
        Public Overridable Sub Dispose() Implements System.IDisposable.Dispose
        End Sub
#End Region

    End Class
End Namespace