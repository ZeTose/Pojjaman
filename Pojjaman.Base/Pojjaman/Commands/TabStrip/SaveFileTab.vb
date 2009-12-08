Imports Longkong.Core.AddIns.Codons
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Gui
Imports Longkong.Pojjaman.Gui.Dialogs
Namespace Longkong.Pojjaman.Commands.TabStrip
    Public Class SaveFileTab
        Inherits AbstractMenuCommand

#Region "Constructors"
        Public Sub New()
        End Sub
#End Region

#Region "Methods"
        Public Overrides Sub Run()
            Dim window As IWorkbenchWindow = CType(Me.Owner, IWorkbenchWindow)
            If ((Not window Is Nothing) AndAlso Not window.ViewContent.IsViewOnly) Then
                If window.ViewContent.IsUntitled Then
                    SaveFileAsTab.SaveFileAs(window)
                Else
                    'Dim service1 As IProjectService = CType(ServiceManager.Services.GetService(GetType(IProjectService)), IProjectService)
                    'service1.MarkFileDirty(window.ViewContent.FileName)
                    Dim myFileUtilityService As FileUtilityService = CType(ServiceManager.Services.GetService(GetType(FileUtilityService)), FileUtilityService)
                    Dim content As IViewContent = window.ViewContent
                    myFileUtilityService.ObservedSave(New FileOperationDelegate(AddressOf content.Save), window.ViewContent.FileName)
                End If
            End If
        End Sub
#End Region

    End Class
End Namespace
