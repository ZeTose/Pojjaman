Imports Longkong.Core.AddIns.Codons
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Imports Longkong.Core.Properties
Imports Longkong.Pojjaman.Gui
Imports Longkong.Pojjaman.Gui.Dialogs
Namespace Longkong.Pojjaman.Commands
    Public Class ReloadFile
        Inherits AbstractMenuCommand

#Region "Constructors"
        Public Sub New()
        End Sub
#End Region

#Region "Methods"
        Public Overrides Sub Run()
            Dim window1 As IWorkbenchWindow = WorkbenchSingleton.Workbench.ActiveWorkbenchWindow
            If (((Not window1 Is Nothing) AndAlso (Not window1.ViewContent.FileName Is Nothing)) AndAlso Not window1.ViewContent.IsViewOnly) Then
                Dim service1 As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
                If service1.AskQuestion("${res:Longkong.Pojjaman.Commands.ReloadFile.ReloadFileQuestion}") Then
                    Dim convertable1 As IXmlConvertable = Nothing
                    If TypeOf window1.ViewContent Is IMementoCapable Then
                        convertable1 = CType(window1.ViewContent, IMementoCapable).CreateMemento
                    End If
                    window1.ViewContent.Load(window1.ViewContent.FileName)
                    If (Not convertable1 Is Nothing) Then
                        CType(window1.ViewContent, IMementoCapable).SetMemento(convertable1)
                    End If
                End If
            End If
        End Sub
#End Region


    End Class
End Namespace
