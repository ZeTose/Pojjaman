Imports Longkong.Pojjaman.Gui
Namespace Longkong.Pojjaman.Gui
    Public MustInherit Class AbstractSecondaryViewContent
        Inherits AbstractBaseViewContent
        Implements ISecondaryViewContent

#Region "Constructors"
        Protected Sub New()
        End Sub
#End Region

#Region "Properties"
        Public Overrides ReadOnly Property Control() As System.Windows.Forms.Control
            Get

            End Get
        End Property
#End Region

#Region "ISecondaryViewContent"
        Public Overridable Sub NotifyAfterSave(ByVal successful As Boolean) Implements ISecondaryViewContent.NotifyAfterSave
        End Sub
        Public Overridable Sub NotifyBeforeSave() Implements ISecondaryViewContent.NotifyBeforeSave
        End Sub
#End Region

    End Class
End Namespace