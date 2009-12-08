Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms

Namespace Longkong.CustomControl
    Public Class DefaultSideTabFactory
        Implements ISideTabFactory

#Region "Constructors"
        Public Sub New()
        End Sub
#End Region

#Region "Methods"
        Public Function CreateSideTab(ByVal sideBar As OutlookBar, ByVal name As String) As OutlookBarTab Implements ISideTabFactory.CreateSideTab
            Return New OutlookBarTab(sideBar, name)
        End Function
#End Region
 
    End Class
End Namespace