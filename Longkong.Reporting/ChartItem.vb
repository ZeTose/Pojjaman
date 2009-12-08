Imports System
Imports System.Collections
Imports System.Diagnostics
Imports System.Drawing

Namespace Longkong.Reporting

    '*********************************************************************
    '
    ' ChartItem Class
    '
    ' This class represents a data point in a chart
    '
    '*********************************************************************

    Public Class ChartItem
        Private m_label As String
        Private m_description As String
        Private m_value As Single
        Private m_color As Color
        Private m_startPos As Single
        Private m_sweepSize As Single

        Private Sub New()
        End Sub

        Public Sub New(ByVal label As String, ByVal desc As String, ByVal data As Single, ByVal start As Single, ByVal sweep As Single, ByVal clr As Color)
            m_label = label
            m_description = desc
            m_value = data
            m_startPos = start
            m_sweepSize = sweep
            m_color = clr
        End Sub
        Public Property Label() As String
            Get
                Return m_label
            End Get
            Set(ByVal Value As String)
                m_label = Value
            End Set
        End Property

        Public Property Description() As String
            Get
                Return m_description
            End Get
            Set(ByVal Value As String)
                m_description = Value
            End Set
        End Property

        Public Property Value() As Single
            Get
                Return m_value
            End Get
            Set(ByVal Value As Single)
                m_value = Value
            End Set
        End Property

        Public Property ItemColor() As Color
            Get
                Return m_color
            End Get
            Set(ByVal Value As Color)
                m_color = Value
            End Set
        End Property

        Public Property StartPos() As Single
            Get
                Return m_startPos
            End Get
            Set(ByVal Value As Single)
                m_startPos = Value
            End Set
        End Property

        Public Property SweepSize() As Single
            Get
                Return m_sweepSize
            End Get
            Set(ByVal Value As Single)
                m_sweepSize = Value
            End Set
        End Property
    End Class

    '*********************************************************************
    '
    ' Custom Collection for ChartItems
    '
    '*********************************************************************

    Public Class ChartItemsCollection
        Inherits CollectionBase

        Default Public Property Item(ByVal index As Integer) As ChartItem
            Get
                Return CType(List(index), ChartItem)
            End Get
            Set(ByVal Value As ChartItem)
                List(index) = Value
            End Set
        End Property

        Public Function Add(ByVal value As ChartItem) As Integer
            Return List.Add(value)
        End Function

        Public Function IndexOf(ByVal value As ChartItem) As Integer
            Return List.IndexOf(value)
        End Function

        Public Function Contains(ByVal value As ChartItem) As Boolean
            Return List.Contains(value)
        End Function

        Public Sub Remove(ByVal value As ChartItem)
            List.Remove(value)
        End Sub
    End Class
End Namespace