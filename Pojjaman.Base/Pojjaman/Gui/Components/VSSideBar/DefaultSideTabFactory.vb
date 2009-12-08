Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms

Namespace Longkong.Pojjaman.Gui.Components
    Public Class DefaultSideTabFactory
        Implements ISideTabFactory

#Region "Constructors"
        Public Sub New()
        End Sub
#End Region

#Region "Methods"
        Public Function CreateSideTab(ByVal sideBar As VSSideBar, ByVal name As String) As VSSideTab Implements ISideTabFactory.CreateSideTab
            Return New VSSideTab(sideBar, name)
        End Function
#End Region

    End Class
End Namespace