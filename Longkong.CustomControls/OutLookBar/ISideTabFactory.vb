Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms

Namespace Longkong.CustomControl
    Public Interface ISideTabFactory
        ' Methods
        Function CreateSideTab(ByVal sideBar As OutlookBar, ByVal name As String) As OutlookBarTab
    End Interface
End Namespace