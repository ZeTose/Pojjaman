Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms

Namespace Longkong.Pojjaman.Gui.Components
    Public Interface ISideTabFactory
        ' Methods
        Function CreateSideTab(ByVal sideBar As VSSideBar, ByVal name As String) As VSSideTab
    End Interface
End Namespace