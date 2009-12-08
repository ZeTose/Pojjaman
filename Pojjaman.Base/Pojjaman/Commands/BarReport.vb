Imports Longkong.Core.AddIns.Codons
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Gui
Imports Longkong.Pojjaman.Gui.Dialogs
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Pojjaman.Gui.Panels
Imports Longkong.Pojjaman.PanelDisplayBinding
Namespace Longkong.Pojjaman.Commands
    Public Class BarReport
        Inherits AbstractMenuCommand

#Region "Constructors"
        Public Sub New()
        End Sub
#End Region

#Region "Methods"
        Public Overrides Sub Run()
            'Dim myControl As New ReportPanel
            Dim myControl As New ReportPrintingPanel
            Dim myView As New PanelView(myControl)
            WorkbenchSingleton.Workbench.ShowView(myView)
        End Sub
#End Region

    End Class
End Namespace
