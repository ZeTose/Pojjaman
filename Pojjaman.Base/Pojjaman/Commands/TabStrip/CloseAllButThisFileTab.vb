Imports Longkong.Core.AddIns.Codons
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Gui
Imports Longkong.Pojjaman.Gui.Dialogs
Namespace Longkong.Pojjaman.Commands.TabStrip
    Public Class CloseAllButThisFileTab
        Inherits AbstractMenuCommand

#Region "Constructors"
        Public Sub New()
        End Sub
#End Region

#Region "Methods"
        Public Overrides Sub Run()
            Dim window As IWorkbenchWindow = CType(Me.Owner, IWorkbenchWindow)
            Dim contentsToClose As New ArrayList
            For i As Integer = 0 To WorkbenchSingleton.Workbench.ViewContentCollection.Count - 1
                Dim content As IViewContent = WorkbenchSingleton.Workbench.ViewContentCollection(i)
                If (Not content.WorkbenchWindow Is window) Then
                    contentsToClose.Add(content)
                End If
            Next
            For Each content As IViewContent In contentsToClose
                content.WorkbenchWindow.CloseWindow(False)
            Next
        End Sub
#End Region

    End Class
End Namespace
