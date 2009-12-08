Imports System
Imports System.Windows.Forms


Namespace Longkong.Pojjaman.Gui.Components

    Public Class ButtonColumnEventArgs
        Inherits EventArgs

        Private m_rowNum As Integer
        Private m_columnNum As Integer
        Private m_buttonValue As Object


        Public ReadOnly Property Column() As Integer
            Get
                Return m_columnNum
            End Get
        End Property

        Public ReadOnly Property Row() As Integer
            Get
                Return m_rowNum
            End Get
        End Property

        Public ReadOnly Property ButtonValue() As Object
            Get
                Return m_buttonValue
            End Get
        End Property

        Public Sub New(ByVal rowNum As Integer, ByVal columnNum As Integer, ByVal buttonValue As Object)
            m_rowNum = rowNum
            m_columnNum = columnNum
            m_buttonValue = buttonValue
        End Sub
    End Class
End Namespace
