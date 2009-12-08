Imports Longkong.Core.AddIns.Codons
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Gui
Imports Longkong.Pojjaman.Gui.Dialogs
Namespace Longkong.Pojjaman.Commands.TabStrip
    Public Class CopyPathName
        Inherits AbstractMenuCommand

#Region "Constructors"
        Public Sub New()
        End Sub
#End Region

#Region "Methods"
        Public Overrides Sub Run()
            Dim window As IWorkbenchWindow = CType(Me.Owner, IWorkbenchWindow)
            If ((Not window Is Nothing) AndAlso (Not window.ViewContent.FileName Is Nothing)) Then
                Clipboard.SetDataObject(New DataObject(DataFormats.Text, window.ViewContent.FileName))
            End If
        End Sub
#End Region

    End Class
End Namespace
