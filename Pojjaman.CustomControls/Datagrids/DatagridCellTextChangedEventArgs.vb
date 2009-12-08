Namespace Longkong.Pojjaman.Gui.Components
    Public Class DatagridCellTextChangedEventArgs
        Inherits EventArgs

#Region "Members"
        Private m_rowNum As Integer
        Private m_columnNum As Integer
        Private m_value As Object
#End Region

#Region "Constructors"
        Public Sub New(ByVal row As Integer, ByVal col As Integer, ByVal theValue As Object)
            m_rowNum = row
            m_columnNum = col
            m_value = theValue
        End Sub
#End Region

#Region "Properties"
        Public ReadOnly Property RowNum() As Integer            Get                Return m_rowNum            End Get        End Property        Public ReadOnly Property ColumnNum() As Integer            Get                Return m_columnNum            End Get        End Property        Public ReadOnly Property Value() As Object            Get                Return m_value            End Get        End Property
#End Region

    End Class
End Namespace

