Imports Longkong.Core.AddIns.Codons
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Gui
Namespace Longkong.Pojjaman.Commands
    Public Class Redo
        Inherits AbstractMenuCommand

#Region "Constructors"
        Public Sub New()
        End Sub
#End Region

#Region "Properties"
        Public Overrides Property IsEnabled() As Boolean
            Get
                Dim activeWindow As IWorkbenchWindow = WorkbenchSingleton.Workbench.ActiveWorkbenchWindow
                Dim editableWindow As IEditable
                If (Not activeWindow Is Nothing) Then
                    If TypeOf activeWindow.ActiveViewContent Is IEditable Then
                        editableWindow = CType(activeWindow.ActiveViewContent, IEditable)
                    End If
                Else
                    editableWindow = Nothing
                End If
                If (Not editableWindow Is Nothing) Then
                    Return editableWindow.EnableRedo
                End If
                Return False
            End Get
            Set(ByVal Value As Boolean)
            End Set
        End Property
#End Region

#Region "Methods"
        Public Overrides Sub Run()
            If Me.IsEnabled Then
                Dim activeWindow As IWorkbenchWindow = WorkbenchSingleton.Workbench.ActiveWorkbenchWindow
                Dim editableWindow As IEditable
                If (Not activeWindow Is Nothing) Then
                    If TypeOf activeWindow.ActiveViewContent Is IEditable Then
                        editableWindow = CType(activeWindow.ActiveViewContent, IEditable)
                    End If
                Else
                    editableWindow = Nothing
                End If
                If (Not editableWindow Is Nothing) Then
                    editableWindow.Redo()
                End If
            End If
        End Sub
#End Region

    End Class
End Namespace
