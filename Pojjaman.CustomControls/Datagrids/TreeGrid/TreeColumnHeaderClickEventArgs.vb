Imports System
Imports System.Windows.Forms
Namespace Longkong.Pojjaman.Gui.Components
    Public Class TreeColumnHeaderClickEventArgs
        Inherits EventArgs

#Region "Members"
        Private m_col As Integer
        Private m_button As MouseButtons
#End Region

#Region "Constructors"
        Public Sub New(ByVal myCol As Integer, ByVal b As MouseButtons)
            m_col = myCol
        End Sub
#End Region

#Region "Properties"
        Public ReadOnly Property Column() As Integer
            Get
                Return m_col
            End Get
        End Property
        Public Property Button() As MouseButtons            Get                Return m_button            End Get            Set(ByVal Value As MouseButtons)                m_button = Value            End Set        End Property
#End Region

    End Class
End Namespace
