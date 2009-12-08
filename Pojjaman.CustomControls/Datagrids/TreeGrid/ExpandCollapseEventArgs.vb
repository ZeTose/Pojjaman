Imports System
Imports System.Windows.Forms
Namespace Longkong.Pojjaman.Gui.Components
    Public Class ExpandCollapseEventArgs
        Inherits EventArgs

        Private m_row As ExpandableDataRow

        Public ReadOnly Property Row() As ExpandableDataRow
            Get
                Return m_row
            End Get
        End Property

        Public Sub New(ByVal myRow As ExpandableDataRow)
            m_row = myRow
        End Sub
    End Class
End Namespace
