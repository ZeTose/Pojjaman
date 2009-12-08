Imports System
Imports System.Drawing
Imports System.Collections
Imports System.Drawing.Imaging
Imports System.Drawing.Drawing2D
Imports Microsoft.VisualBasic

Namespace Longkong.Reporting

    Public Class BarGraph
        Inherits Chart

#Region "Members"
        Private m_graphLegendSpacer As Single = 15.0F
        Private m_labelFontSize As Integer = 7
        Private m_legendFontSize As Integer = 9
        Private m_legendRectangleSize As Single = 10.0F
        Private m_spacer As Single = 5.0F

        ' Overall related members
        Private m_backColor As Color
        Private m_fontFamily As String
        Private m_longestTickValue As String = String.Empty ' Used to calculate max value width
        Private m_maxTickValueWidth As Single ' Used to calculate left offset of bar graph
        Private m_totalHeight As Single
        Private m_totalWidth As Single

        ' Graph related members
        Private m_barWidth As Single
        Private m_bottomBuffer As Single ' Space from bottom to x axis
        Private m_displayBarData As Boolean
        Private m_fontColor As Color
        Private m_graphHeight As Single
        Private m_graphWidth As Single
        Private m_maxValue As Single = 0.0F ' = final tick value * tick count
        Private m_scaleFactor As Single ' = m_maxValue / m_graphHeight
        Private m_spaceBtwBars As Single ' For now same as m_barWidth
        Private m_topBuffer As Single ' Space from top to the top of y axis
        Private m_xOrigin As Single ' x position where graph starts drawing
        Private m_yOrigin As Single ' y position where graph starts drawing
        Private m_yLabel As String
        Private m_yTickCount As Integer
        Private m_yTickValue As Single ' Value for each tick = m_maxValue/m_yTickCount
        ' Legend related members
        Private m_displayLegend As Boolean
        Private m_legendWidth As Single
        Private m_longestLabel As String = String.Empty ' Used to calculate legend width
        Private m_maxLabelWidth As Single = 0.0F
#End Region

#Region "Constructors"
        Public Sub New()
            AssignDefaultSettings()
        End Sub

        Public Sub New(ByVal bgColor As Color)
            AssignDefaultSettings()
            BackgroundColor = bgColor
        End Sub
#End Region

#Region "Properties"
        Public Property FontFamily() As String
            Get
                Return m_fontFamily
            End Get
            Set(ByVal Value As String)
                m_fontFamily = Value
            End Set
        End Property

        Public WriteOnly Property BackgroundColor() As Color
            Set(ByVal Value As Color)
                m_backColor = Value
            End Set
        End Property

        Public WriteOnly Property BottomBuffer() As Integer
            Set(ByVal Value As Integer)
                m_bottomBuffer = Convert.ToSingle(Value)
            End Set
        End Property

        Public WriteOnly Property FontColor() As Color
            Set(ByVal Value As Color)
                m_fontColor = Value
            End Set
        End Property

        Public Property Height() As Integer
            Get
                Return Convert.ToInt32(m_totalHeight)
            End Get
            Set(ByVal Value As Integer)
                m_totalHeight = Convert.ToSingle(Value)
            End Set
        End Property

        Public Property Width() As Integer
            Get
                Return Convert.ToInt32(m_totalWidth)
            End Get
            Set(ByVal Value As Integer)
                m_totalWidth = Convert.ToSingle(Value)
            End Set
        End Property

        Public Property ShowLegend() As Boolean
            Get
                Return m_displayLegend
            End Get
            Set(ByVal Value As Boolean)
                m_displayLegend = Value
            End Set
        End Property

        Public Property ShowData() As Boolean
            Get
                Return m_displayBarData
            End Get
            Set(ByVal Value As Boolean)
                m_displayBarData = Value
            End Set
        End Property

        Public WriteOnly Property TopBuffer() As Integer
            Set(ByVal Value As Integer)
                m_topBuffer = Convert.ToSingle(Value)
            End Set
        End Property

        Public Property VerticalLabel() As String
            Get
                Return m_yLabel
            End Get
            Set(ByVal Value As String)
                m_yLabel = Value
            End Set
        End Property

        Public Property VerticalTickCount() As Integer
            Get
                Return m_yTickCount
            End Get
            Set(ByVal Value As Integer)
                m_yTickCount = Value
            End Set
        End Property
#End Region

#Region "Methods"
        '*********************************************************************
        '
        ' This method collects all data points and calculate all the necessary dimensions 
        ' to draw the bar graph.  It is the method called before invoking the Draw() method.
        ' labels is the x values.
        ' values is the y values.
        '
        '*********************************************************************

        Public Overloads Sub CollectDataPoints(ByVal labels() As String, ByVal values() As String)
            If labels.Length = values.Length Then
                Dim i As Integer
                For i = 0 To labels.Length - 1
                    Dim temp As Single = Convert.ToSingle(values(i))
                    Dim shortLbl As String = MakeShortLabel(labels(i))

                    ' For now put 0.0 for start position and sweep size
                    DataPoints.Add(New ChartItem(shortLbl, labels(i), temp, 0.0F, 0.0F, GetColor(i)))

                    ' Find max value from data; this is only temporary m_maxValue
                    If m_maxValue < temp Then
                        m_maxValue = temp
                    End If
                    ' Find the longest description
                    If m_displayLegend Then
                        Dim currentLbl As String = labels(i) + " (" + shortLbl + ")"
                        Dim currentWidth As Single = CalculateImgFontWidth(currentLbl, m_legendFontSize, FontFamily)
                        If m_maxLabelWidth < currentWidth Then
                            m_longestLabel = currentLbl
                            m_maxLabelWidth = currentWidth
                        End If
                    End If
                Next i

                CalculateTickAndMax()
                CalculateGraphDimension()
                CalculateBarWidth(DataPoints.Count, m_graphWidth)
                CalculateSweepValues()
            Else
                Throw New Exception("X data count is different from Y data count")
            End If
        End Sub

        '*********************************************************************
        '
        ' Same as above; called when user doesn't care about the x values
        '
        '*********************************************************************

        Public Overloads Sub CollectDataPoints(ByVal values() As String)
            Dim labels As String() = values
            CollectDataPoints(labels, values)
        End Sub

        '*********************************************************************
        '
        ' This method returns a bar graph bitmap to the calling function.  It is called after 
        ' all dimensions and data points are calculated.
        '
        '*********************************************************************

        Public Overrides Function Draw() As Bitmap
            Dim height As Integer = Convert.ToInt32(m_totalHeight)
            Dim width As Integer = Convert.ToInt32(m_totalWidth)

            Dim bmp As New Bitmap(width, height)
            Dim graph As Graphics = Nothing

            Try
                graph = Graphics.FromImage(bmp)
                graph.CompositingQuality = CompositingQuality.HighQuality
                graph.SmoothingMode = SmoothingMode.AntiAlias

                ' Set the background: need to draw one pixel larger than the bitmap to cover all area
                graph.FillRectangle(New SolidBrush(m_backColor), -1, -1, bmp.Width + 1, bmp.Height + 1)

                DrawVerticalLabelArea(graph)
                DrawBars(graph)
                DrawXLabelArea(graph)
                If m_displayLegend Then
                    DrawLegend(graph)
                End If

            Finally
                If Not (graph Is Nothing) Then
                    graph.Dispose()
                End If
            End Try

            Return bmp
        End Function

        '*********************************************************************
        '
        ' This method draws all the bars for the graph.
        '
        '*********************************************************************

        Private Sub DrawBars(ByVal graph As Graphics)
            Dim brsFont As SolidBrush = Nothing
            Dim valFont As Font = Nothing
            Dim sfFormat As StringFormat = Nothing

            Try
                brsFont = New SolidBrush(m_fontColor)
                valFont = New Font(m_fontFamily, m_labelFontSize)
                sfFormat = New StringFormat
                sfFormat.Alignment = StringAlignment.Center
                Dim i As Integer = 0

                ' Draw bars and the value above each bar
                Dim item As ChartItem
                For Each item In DataPoints
                    Dim barBrush As SolidBrush = Nothing
                    Try
                        barBrush = New SolidBrush(item.ItemColor)
                        Dim itemY As Single = m_yOrigin + m_graphHeight - item.SweepSize

                        ' When drawing, all position is relative to (m_xOrigin, m_yOrigin)
                        graph.FillRectangle(barBrush, m_xOrigin + item.StartPos, itemY, m_barWidth, item.SweepSize)

                        ' Draw data value
                        If m_displayBarData Then
                            Dim startX As Single = m_xOrigin + i * (m_barWidth + m_spaceBtwBars) ' This draws the value on center of the bar
                            Dim startY As Single = itemY - 2.0F - valFont.Height ' Positioned on top of each bar by 2 pixels
                            Dim recVal As New RectangleF(startX, startY, m_barWidth + m_spaceBtwBars, valFont.Height)
                            graph.DrawString(item.Value.ToString("#,###.##"), valFont, brsFont, recVal, sfFormat)
                        End If
                        i += 1
                    Finally
                        If Not (barBrush Is Nothing) Then
                            barBrush.Dispose()
                        End If
                    End Try
                Next item
            Finally
                If Not (brsFont Is Nothing) Then
                    brsFont.Dispose()
                End If
                If Not (valFont Is Nothing) Then
                    valFont.Dispose()
                End If
                If Not (sfFormat Is Nothing) Then
                    sfFormat.Dispose()
                End If
            End Try
        End Sub

        '*********************************************************************
        '
        ' This method draws the y label, tick marks, tick values, and the y axis.
        '
        '*********************************************************************

        Private Sub DrawVerticalLabelArea(ByVal graph As Graphics)
            Dim lblFont As Font = Nothing
            Dim brs As SolidBrush = Nothing
            Dim lblFormat As StringFormat = Nothing
            Dim pen As pen = Nothing
            Dim sfVLabel As StringFormat = Nothing

            Try
                lblFont = New Font(m_fontFamily, m_labelFontSize)
                brs = New SolidBrush(m_fontColor)
                lblFormat = New StringFormat
                pen = New pen(m_fontColor)
                sfVLabel = New StringFormat

                lblFormat.Alignment = StringAlignment.Near

                ' Draw vertical label at the top of y-axis and place it in the middle top of y-axis
                Dim recVLabel As New RectangleF(0.0F, m_yOrigin - 2 * m_spacer - lblFont.Height, m_xOrigin * 2, lblFont.Height)
                sfVLabel.Alignment = StringAlignment.Center
                graph.DrawString(m_yLabel, lblFont, brs, recVLabel, sfVLabel)

                ' Draw all tick values and tick marks
                Dim i As Integer
                For i = 0 To m_yTickCount - 1
                    Dim currentY As Single = m_topBuffer + i * m_yTickValue / m_scaleFactor ' Position for tick mark
                    Dim labelY As Single = CSng(currentY - lblFont.Height / 2) ' Place label in the middle of tick
                    Dim lblRec As New RectangleF(m_spacer, labelY, m_maxTickValueWidth, lblFont.Height)
                    Dim currentTick As Single = m_maxValue - i * m_yTickValue ' Calculate tick value from top to bottom
                    graph.DrawString(currentTick.ToString("#,###.##"), lblFont, brs, lblRec, lblFormat) ' Draw tick value  
                    graph.DrawLine(pen, m_xOrigin, currentY, m_xOrigin - 4.0F, currentY) ' Draw tick mark
                Next i

                ' Draw y axis
                graph.DrawLine(pen, m_xOrigin, m_yOrigin, m_xOrigin, m_yOrigin + m_graphHeight)
            Finally
                If Not (lblFont Is Nothing) Then
                    lblFont.Dispose()
                End If
                If Not (brs Is Nothing) Then
                    brs.Dispose()
                End If
                If Not (lblFormat Is Nothing) Then
                    lblFormat.Dispose()
                End If
                If Not (pen Is Nothing) Then
                    pen.Dispose()
                End If
                If Not (sfVLabel Is Nothing) Then
                    sfVLabel.Dispose()
                End If
            End Try
        End Sub

        '*********************************************************************
        '
        ' This method draws x axis and all x labels
        '
        '*********************************************************************

        Private Sub DrawXLabelArea(ByVal graph As Graphics)
            Dim lblFont As Font = Nothing
            Dim brs As SolidBrush = Nothing
            Dim lblFormat As StringFormat = Nothing
            Dim pen As pen = Nothing

            Try
                lblFont = New Font(m_fontFamily, m_labelFontSize)
                brs = New SolidBrush(m_fontColor)
                lblFormat = New StringFormat
                pen = New pen(m_fontColor)

                lblFormat.Alignment = StringAlignment.Center

                ' Draw x axis
                graph.DrawLine(pen, m_xOrigin, m_yOrigin + m_graphHeight, m_xOrigin + m_graphWidth, m_yOrigin + m_graphHeight)

                Dim currentX As Single
                Dim currentY As Single = m_yOrigin + m_graphHeight + 2.0F ' All x labels are drawn 2 pixels below x-axis
                Dim labelWidth As Single = m_barWidth + m_spaceBtwBars ' Fits exactly below the bar
                Dim i As Integer = 0

                ' Draw x labels
                Dim item As ChartItem
                For Each item In DataPoints
                    currentX = m_xOrigin + i * labelWidth
                    Dim recLbl As New RectangleF(currentX, currentY, labelWidth, lblFont.Height)
                    Dim lblString As String = CStr(IIf(m_displayLegend, item.Label, item.Description))
                    graph.DrawString(lblString, lblFont, brs, recLbl, lblFormat)
                    i += 1
                Next item
            Finally
                If Not (lblFont Is Nothing) Then
                    lblFont.Dispose()
                End If
                If Not (brs Is Nothing) Then
                    brs.Dispose()
                End If
                If Not (lblFormat Is Nothing) Then
                    lblFormat.Dispose()
                End If
                If Not (pen Is Nothing) Then
                    pen.Dispose()
                End If
            End Try
        End Sub

        '*********************************************************************
        '
        ' This method determines where to place the legend box.
        ' It draws the legend border, legend description, and legend color code.
        '
        '*********************************************************************

        Private Sub DrawLegend(ByVal graph As Graphics)
            Dim lblFont As Font = Nothing
            Dim brs As SolidBrush = Nothing
            Dim lblFormat As StringFormat = Nothing
            Dim pen As pen = Nothing

            Try
                lblFont = New Font(m_fontFamily, m_legendFontSize)
                brs = New SolidBrush(m_fontColor)
                lblFormat = New StringFormat
                pen = New pen(m_fontColor)
                lblFormat.Alignment = StringAlignment.Near

                ' Calculate Legend drawing start point
                Dim startX As Single = m_xOrigin + m_graphWidth + m_graphLegendSpacer
                Dim startY As Single = m_yOrigin

                Dim xColorCode As Single = startX + m_spacer
                Dim xLegendText As Single = xColorCode + m_legendRectangleSize + m_spacer
                Dim legendHeight As Single = 0.0F
                Dim i As Integer
                For i = 0 To DataPoints.Count - 1
                    Dim point As ChartItem = DataPoints(i)
                    Dim [text] As String = point.Description + " (" + point.Label + ")"
                    Dim currentY As Single = startY + m_spacer + i * (lblFont.Height + m_spacer)
                    legendHeight += lblFont.Height + m_spacer

                    ' Draw legend description
                    graph.DrawString([text], lblFont, brs, xLegendText, currentY, lblFormat)

                    ' Draw color code
                    graph.FillRectangle(New SolidBrush(DataPoints(i).ItemColor), xColorCode, currentY + 3.0F, m_legendRectangleSize, m_legendRectangleSize)
                Next i

                ' Draw legend border
                graph.DrawRectangle(pen, startX, startY, m_legendWidth, legendHeight + m_spacer)
            Finally
                If Not (lblFont Is Nothing) Then
                    lblFont.Dispose()
                End If
                If Not (brs Is Nothing) Then
                    brs.Dispose()
                End If
                If Not (lblFormat Is Nothing) Then
                    lblFormat.Dispose()
                End If
                If Not (pen Is Nothing) Then
                    pen.Dispose()
                End If
            End Try
        End Sub

        '*********************************************************************
        '
        ' This method calculates all measurement aspects of the bar graph from the given data points
        '
        '*********************************************************************

        Private Sub CalculateGraphDimension()
            FindLongestTickValue()

            ' Need to add another character for spacing; this is not used for drawing, just for calculation
            m_longestTickValue += "0"
            m_maxTickValueWidth = CalculateImgFontWidth(m_longestTickValue, m_labelFontSize, FontFamily)
            Dim leftOffset As Single = m_spacer + m_maxTickValueWidth
            Dim rtOffset As Single = 0.0F

            If m_displayLegend Then
                m_legendWidth = m_spacer + m_legendRectangleSize + m_spacer + m_maxLabelWidth + m_spacer
                rtOffset = m_graphLegendSpacer + m_legendWidth + m_spacer
            Else
                rtOffset = m_spacer ' Make graph in the middle
            End If
            m_graphHeight = m_totalHeight - m_topBuffer - m_bottomBuffer ' Buffer spaces are used to print labels
            m_graphWidth = m_totalWidth - leftOffset - rtOffset
            m_xOrigin = leftOffset
            m_yOrigin = m_topBuffer

            ' Once the correct m_maxValue is determined, then calculate m_scaleFactor
            m_scaleFactor = m_maxValue / m_graphHeight
        End Sub

        '*********************************************************************
        '
        ' This method determines the longest tick value from the given data points.
        ' The result is needed to calculate the correct graph dimension.
        '
        '*********************************************************************

        Private Sub FindLongestTickValue()
            Dim currentTick As Single
            Dim tickString As String
            Dim i As Integer
            For i = 0 To m_yTickCount - 1
                currentTick = m_maxValue - i * m_yTickValue
                tickString = currentTick.ToString("#,###.##")
                If m_longestTickValue.Length < tickString.Length Then
                    m_longestTickValue = tickString
                End If
            Next i
        End Sub

        '*********************************************************************
        '
        ' This method calculates the image width in pixel for a given text
        '
        '*********************************************************************

        Private Function CalculateImgFontWidth(ByVal [text] As String, ByVal size As Integer, ByVal family As String) As Single
            Dim bmp As Bitmap = Nothing
            Dim graph As Graphics = Nothing
            Dim font As font = Nothing

            Try
                font = New font(family, size)

                ' Calculate the size of the string.
                bmp = New Bitmap(1, 1, PixelFormat.Format32bppArgb)
                graph = Graphics.FromImage(bmp)
                Dim oSize As SizeF = graph.MeasureString([text], font)

                Return oSize.Width
            Finally
                If Not (graph Is Nothing) Then
                    graph.Dispose()
                End If
                If Not (bmp Is Nothing) Then
                    bmp.Dispose()
                End If
                If Not (font Is Nothing) Then
                    font.Dispose()
                End If
            End Try
        End Function

        '*********************************************************************
        '
        ' This method creates abbreviation from long description; used for making legend
        '
        '*********************************************************************

        Private Function MakeShortLabel(ByVal [text] As String) As String
            Dim label As String = [text]
            If [text].Length > 2 Then
                Dim midPostition As Integer = Convert.ToInt32(Math.Floor(([text].Length / 2)))
                label = [text].Substring(0, 1) + [text].Substring(midPostition, 1) + [text].Substring([text].Length - 1, 1)
            End If
            Return label
        End Function

        '*********************************************************************
        '
        ' This method calculates the max value and each tick mark value for the bar graph.
        '
        '*********************************************************************

        Private Sub CalculateTickAndMax()
            Dim tempMax As Single = 0.0F

            ' Give graph some head room first about 10% of current max
            m_maxValue *= 1.1F

            If m_maxValue <> 0.0F Then
                ' Find a rounded value nearest to the current max value
                ' Calculate this max first to give enough space to draw value on each bar
                Dim exp As Double = Convert.ToDouble(Math.Floor(Math.Log10(m_maxValue)))
                tempMax = Convert.ToSingle((Math.Ceiling((m_maxValue / Math.Pow(10, exp))) * Math.Pow(10, exp)))
            Else
                tempMax = 1.0F
            End If
            ' Once max value is calculated, tick value can be determined; tick value should be a whole number
            m_yTickValue = tempMax / m_yTickCount
            Dim expTick As Double = Convert.ToDouble(Math.Floor(Math.Log10(m_yTickValue)))
            m_yTickValue = Convert.ToSingle((Math.Ceiling((m_yTickValue / Math.Pow(10, expTick))) * Math.Pow(10, expTick)))

            ' Re-calculate the max value with the new tick value
            m_maxValue = m_yTickValue * m_yTickCount
        End Sub

        '*********************************************************************
        '
        ' This method calculates the height for each bar in the graph
        '
        '*********************************************************************

        Private Sub CalculateSweepValues()
            ' Called when all values and scale factor are known
            ' All values calculated here are relative from (m_xOrigin, m_yOrigin)
            Dim i As Integer = 0
            Dim item As ChartItem
            For Each item In DataPoints
                ' This implementation does not support negative value
                If item.Value >= 0 Then
                    item.SweepSize = item.Value / m_scaleFactor
                End If
                ' (m_spaceBtwBars/2) makes half white space for the first bar
                item.StartPos = m_spaceBtwBars / 2 + i * (m_barWidth + m_spaceBtwBars)
                i += 1
            Next item
        End Sub

        '*********************************************************************
        '
        ' This method calculates the width for each bar in the graph
        '
        '*********************************************************************

        Private Sub CalculateBarWidth(ByVal dataCount As Integer, ByVal barGraphWidth As Single)
            ' White space between each bar is the same as bar width itself
            m_barWidth = barGraphWidth / (dataCount * 2) ' Each bar has 1 white space 
            m_spaceBtwBars = m_barWidth
        End Sub

        '*********************************************************************
        '
        ' This method assigns default value to the bar graph properties and is only 
        ' called from BarGraph constructors
        '
        '*********************************************************************

        Private Sub AssignDefaultSettings()
            ' default values
            m_totalWidth = 700.0F
            m_totalHeight = 450.0F
            m_fontFamily = "Verdana"
            m_backColor = Color.White
            m_fontColor = Color.Black
            m_topBuffer = 30.0F
            m_bottomBuffer = 30.0F
            m_yTickCount = 2
            m_displayLegend = False
            m_displayBarData = False
        End Sub
#End Region

    End Class
End Namespace