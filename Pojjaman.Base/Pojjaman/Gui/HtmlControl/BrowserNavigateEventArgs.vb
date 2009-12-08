Imports Longkong.Pojjaman.Gui
Imports System.Windows.Forms
Imports System.ComponentModel
Namespace Longkong.Pojjaman.Gui.HtmlControl
    Public Class BrowserNavigateEventArgs
        Inherits CancelEventArgs

#Region "Members"
        Private m_url As String
#End Region

#Region "Constructors"
        Public Sub New(ByVal url As String, ByVal cancel As Boolean)
            MyBase.New(cancel)
            Me.m_url = url
        End Sub
#End Region

#Region "Properties"
        Public ReadOnly Property Url() As String
            Get
                Return Me.m_url
            End Get
        End Property
#End Region

    End Class
End Namespace