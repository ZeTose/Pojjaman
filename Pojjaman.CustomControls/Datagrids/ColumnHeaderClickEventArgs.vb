Imports System
Imports System.Windows.Forms
Namespace Longkong.Pojjaman.Gui.Components
    Public Class ColumnHeaderClickEventArgs
        Inherits EventArgs

        Private m_col As Integer

        Public ReadOnly Property Column() As Integer
            Get
                Return m_col
            End Get
        End Property

        Public Sub New(ByVal myCol As Integer)
            m_col = myCol
        End Sub
    End Class
End Namespace
