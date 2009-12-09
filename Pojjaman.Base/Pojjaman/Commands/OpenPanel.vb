Imports Longkong.Core.AddIns.Codons
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Gui
Imports Longkong.Pojjaman.Gui.Panels
Imports Longkong.Pojjaman.Gui.Dialogs
Imports Longkong.Core.Properties
Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.PanelDisplayBinding
Imports Longkong.Core.AddIns
Namespace Longkong.Pojjaman.Commands
    Public Class OpenPanel
        Inherits AbstractEntityMenuCommand

#Region "Properties"
        Public Property Panel As String
        Public Property AddIn As AddIn
#End Region

#Region "Constructors"
        Public Sub New()
        End Sub
#End Region

#Region "Methods"
        Public Overrides Sub Run()
            Dim panelToOpen As Object
            If (Not Me.Panel Is Nothing) AndAlso Not Me.AddIn Is Nothing Then
                panelToOpen = Me.AddIn.CreateObject(Me.Panel)
                If TypeOf panelToOpen Is IViewContent Then
                    WorkbenchSingleton.Workbench.ShowView(CType(panelToOpen, IViewContent))
                End If
            End If
        End Sub
#End Region
    End Class
End Namespace
