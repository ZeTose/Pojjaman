Imports System
Imports System.Collections
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Drawing.Drawing2D

Namespace Longkong.Reporting

    '*********************************************************************
    '
    ' PieChart Class
    '
    ' This class uses GDI+ to render Pie Chart.
    '
    '*********************************************************************

    Public Class PieChart
        Inherits Chart
        Private m_bufferSpace As Integer = 125
        Private m_chartItems As ArrayList
        Private m_perimeter As Integer
        Private m_backgroundColor As Color
        Private m_borderColor As Color
        Private m_total As Single
        Private m_legendWidth As Integer
        Private m_legendHeight As Integer
        Private m_legendFontHeight As Integer
        Private m_legendFontStyle As String
        Private m_legendFontSize As Single

        Public Sub New()
            m_chartItems = New ArrayList
            m_perimeter = 250
            m_backgroundColor = Color.White
            m_borderColor = Color.FromArgb(63, 63, 63)
            m_legendFontSize = 8
            m_legendFontStyle = "Verdana"
        End Sub

        Public Sub New(ByVal bgColor As Color)
            m_chartItems = New ArrayList
            m_perimeter = 250
            m_backgroundColor = bgColor
            m_borderColor = Color.FromArgb(63, 63, 63)
            m_legendFontSize = 8
            m_legendFontStyle = "Verdana"
        End Sub

        '*********************************************************************
        '
        ' This method collects all data points and calculate all the necessary dimensions 
        ' to draw the chart.  It is the first method called before invoking the Draw() method.
        '
        '*********************************************************************

        Public Sub CollectDataPoints(ByVal xValues() As String, ByVal yValues() As String)
            m_total = 0.0F

            Dim i As Integer
            For i = 0 To xValues.Length - 1
                Dim ftemp As Single = Convert.ToSingle(yValues(i))
                m_chartItems.Add(New ChartItem(xValues(i), xValues.ToString(), ftemp, 0, 0, Color.AliceBlue))
                m_total += ftemp
            Next i

            Dim nextStartPos As Single = 0.0F
            Dim counter As Integer = 0
            Dim item As ChartItem
            For Each item In m_chartItems
                item.StartPos = nextStartPos
                item.SweepSize = item.Value / m_total * 360
                nextStartPos = item.StartPos + item.SweepSize
                counter = counter + 1
                item.ItemColor = GetColor(counter)
            Next
            CalculateLegendWidthHeight()
        End Sub

        '*********************************************************************
        '
        ' This method returns a bitmap to the calling function.  This is the method
        ' that actually draws the pie chart and the legend with it.
        '
        '*********************************************************************

        Public Overrides Function Draw() As Bitmap
            Dim perimeter As Integer = m_perimeter
            Dim pieRect As New Rectangle(0, 0, perimeter, perimeter - 1)
            Dim bmp As New Bitmap(perimeter + m_legendWidth, perimeter)
            Dim grp As Graphics = Nothing
            Dim sf As StringFormat = Nothing

            Try
                grp = Graphics.FromImage(bmp)
                sf = New StringFormat

                'Paint Back ground
                grp.FillRectangle(New SolidBrush(m_backgroundColor), 0, 0, perimeter + m_legendWidth, perimeter)

                'Align text to the right
                sf.Alignment = StringAlignment.Far

                'Draw all wedges and legends
                Dim i As Integer
                For i = 0 To m_chartItems.Count - 1
                    Dim item As ChartItem = CType(m_chartItems(i), ChartItem)
                    Dim brs As SolidBrush = Nothing
                    Try
                        brs = New SolidBrush(item.ItemColor)
                        grp.FillPie(brs, pieRect, item.StartPos, item.SweepSize)
                        grp.FillRectangle(brs, perimeter + m_bufferSpace, i * m_legendFontHeight + 15, 10, 10)

                        grp.DrawString(item.Label, New Font(m_legendFontStyle, m_legendFontSize), New SolidBrush(Color.Black), perimeter + m_bufferSpace + 20, i * m_legendFontHeight + 13)

                        grp.DrawString(item.Value.ToString("C"), New Font(m_legendFontStyle, m_legendFontSize), New SolidBrush(Color.Black), perimeter + m_bufferSpace + 200, i * m_legendFontHeight + 13, sf)
                    Finally
                        If Not (brs Is Nothing) Then
                            brs.Dispose()
                        End If
                    End Try
                Next i
                'draws the border around Pie
                grp.DrawEllipse(New Pen(m_borderColor, 2), pieRect)

                'draw border around legend
                grp.DrawRectangle(New Pen(m_borderColor, 1), perimeter + m_bufferSpace - 10, 10, 220, m_chartItems.Count * m_legendFontHeight + 25)

                'Draw Total under legend
                grp.DrawString("Total", New Font(m_legendFontStyle, m_legendFontSize, FontStyle.Bold), New SolidBrush(Color.Black), perimeter + m_bufferSpace + 30, (m_chartItems.Count + 1) * m_legendFontHeight, sf)
                grp.DrawString(m_total.ToString("C"), New Font(m_legendFontStyle, m_legendFontSize, FontStyle.Bold), New SolidBrush(Color.Black), perimeter + m_bufferSpace + 200, (m_chartItems.Count + 1) * m_legendFontHeight, sf)

                grp.SmoothingMode = SmoothingMode.AntiAlias
            Finally
                If Not (sf Is Nothing) Then
                    sf.Dispose()
                End If
                If Not (grp Is Nothing) Then
                    grp.Dispose()
                End If
            End Try
            Return bmp
        End Function

        '*********************************************************************
        '
        '	This method calculates the space required to draw the chart legend.
        '
        '*********************************************************************

        Private Sub CalculateLegendWidthHeight()
            Dim fontLegend As New Font(m_legendFontStyle, m_legendFontSize)
            m_legendFontHeight = fontLegend.Height + 5
            m_legendHeight = fontLegend.Height * (m_chartItems.Count + 1)
            If m_legendHeight > m_perimeter Then
                m_perimeter = m_legendHeight
            End If
            m_legendWidth = m_perimeter + m_bufferSpace
        End Sub
    End Class
End Namespace