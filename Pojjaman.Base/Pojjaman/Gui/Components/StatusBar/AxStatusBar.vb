Imports System.Drawing
Namespace Longkong.Pojjaman.Gui.Components
    Public Class AxStatusBar
        Inherits StatusBar

#Region "Methods"
        Protected Overrides Sub OnDrawItem(ByVal sbdievent As StatusBarDrawItemEventArgs)
            If TypeOf sbdievent.Panel Is AxStatusBarPanel Then
                CType(sbdievent.Panel, AxStatusBarPanel).DrawPanel(sbdievent)
            Else
                MyBase.OnDrawItem(sbdievent)
            End If
        End Sub
#End Region

    End Class
End Namespace
