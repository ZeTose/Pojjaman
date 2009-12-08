Namespace Longkong.Core.Services
    Public Class AbstractService
        Implements IService

#Region "IService"
        Public Event Unload(ByVal sender As Object, ByVal e As System.EventArgs) Implements IService.Unload
        Public Event Initialize(ByVal sender As Object, ByVal e As System.EventArgs) Implements IService.Initialize

        Protected Overridable Sub OnInitialize(ByVal e As EventArgs)
            RaiseEvent Initialize(Me, e)
        End Sub
        Protected Overridable Sub OnUnload(ByVal e As EventArgs)
            RaiseEvent Unload(Me, e)
        End Sub

        Public Overridable Sub InitializeService() Implements IService.InitializeService
            Me.OnInitialize(EventArgs.Empty)
        End Sub

        Public Overridable Sub UnloadService() Implements IService.UnloadService
            Me.OnUnload(EventArgs.Empty)
        End Sub
#End Region


    End Class
End Namespace

