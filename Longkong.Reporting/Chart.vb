Imports System
Imports System.Drawing
Imports System.Collections

Namespace Longkong.Reporting

    '*********************************************************************
    '
    ' Chart Class
    '
    ' Base class implementation for BarChart and PieChart
    '
    '*********************************************************************

    Public MustInherit Class Chart
        Private m_colorLimit As Integer = 12

        Private m_color As Color() = {Color.Chocolate, Color.YellowGreen, Color.Olive, Color.DarkKhaki, Color.Sienna, Color.PaleGoldenrod, Color.Peru, Color.Tan, Color.Khaki, Color.DarkGoldenrod, Color.Maroon, Color.OliveDrab}

        ' Represent collection of all data points for the chart
        Private m_dataPoints As New ChartItemsCollection

        ' The implementation of this method is provided by derived classes
        Public MustOverride Function Draw() As Bitmap

        Public Property DataPoints() As ChartItemsCollection
            Get
                Return m_dataPoints
            End Get
            Set(ByVal Value As ChartItemsCollection)
                m_dataPoints = Value
            End Set
        End Property

        Public Sub SetColor(ByVal index As Integer, ByVal NewColor As Color)
            If index < m_colorLimit Then
                m_color(index) = NewColor
            Else
                Throw New Exception("Color Limit is " & m_colorLimit)
            End If
        End Sub

        Public Function GetColor(ByVal index As Integer) As Color
            If index < m_colorLimit Then
                Return m_color(index)
            Else
                Throw New Exception("Color Limit is " & m_colorLimit)
            End If
        End Function
    End Class
End Namespace