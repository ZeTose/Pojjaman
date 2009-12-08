Namespace Longkong.Core.Services
    Public Interface IService
        Event Initialize As EventHandler
        Event Unload As EventHandler

        Sub InitializeService()
        Sub UnloadService()
    End Interface
End Namespace

