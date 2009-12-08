Imports System.Windows.Forms
Imports System.ComponentModel.Design
Imports Longkong.Core.Services
Imports Longkong.Core.Properties
Imports System.Drawing
Imports System.ComponentModel
Imports Longkong.Pojjaman.Services
Imports Longkong.Pojjaman.BrowserDisplayBinding
Namespace Longkong.Pojjaman.Gui.Pads
    Friend Class HelpLinkInformation

#Region "Members"
        Private m_isMSDN As Boolean
        Private m_link As String
#End Region

#Region "Constructors"
        Public Sub New(ByVal link As String, ByVal isMSDN As Boolean)
            Me.m_isMSDN = False
            Me.m_link = link
            Me.m_isMSDN = isMSDN
        End Sub
#End Region

#Region "Properties"
        Public Property IsMSDN() As Boolean
            Get
                Return Me.m_isMSDN
            End Get
            Set(ByVal value As Boolean)
                Me.m_isMSDN = value
            End Set
        End Property
        Public Property Link() As String
            Get
                Return Me.m_link
            End Get
            Set(ByVal value As String)
                Me.m_link = value
            End Set
        End Property
#End Region

#Region "Methods"

#End Region

    End Class
End Namespace

