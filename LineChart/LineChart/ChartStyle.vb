Public Class ChartStyle
  Public Property ChartCanvas As Canvas
  Public Property Xmin As Double
  Public Property Xmax As Double
  Public Property Ymin As Double
  Public Property Ymax As Double

  Public Function NormalizePoint(ByVal pt As Point) As Point
    If (ChartCanvas.Width.ToString = "NaN") Then
      ChartCanvas.Width = 270
    End If
    If (ChartCanvas.Height.ToString = "NaN") Then
      ChartCanvas.Height = 250
    End If
    Dim ret As New Point
    ret.X = (pt.X - Xmin) * ChartCanvas.Width / (Xmax - Xmin)
    ret.Y = ChartCanvas.Height - (pt.Y - Ymin) * ChartCanvas.Height / (Ymax - Ymin)
    Return ret
  End Function
  Public Function OptimalSpacing(ByVal original As Double) As Double
    Dim da As Double() = {1.0, 2.0, 5.0}
    Dim multiplier As Double = Math.Pow(10, Math.Floor(Math.Log(original) / Math.Log(10)))
    Dim dmin As Double = 100 * multiplier
    Dim spacing As Double = 0.0
    Dim mn As Double = 100

    For Each d As Double In da
      Dim delta As Double = Math.Abs(original - d * multiplier)
      If delta < dmin Then
        dmin = delta
        spacing = d * multiplier
      End If
      If d < mn Then
        mn = d
      End If
    Next
    If (Math.Abs(original - 10 * mn * multiplier) < Math.Abs(original - spacing)) Then
      spacing = 10 * mn * multiplier
    End If
    Return spacing
  End Function
  'Public Function TimeSpanToDouble(ByVal ts As TimeSpan) As Double
  '  Dim dt As Date = Date.Parse("1 Jan")
  '  Dim d1 As Double = BitConverter.ToDouble(BitConverter.GetBytes(dt.Ticks), 0)
  '  dt += ts
  '  Dim d2 As Double = BitConverter.ToDouble(BitConverter.GetBytes(dt.Ticks), 0)
  '  Return d2 - d1
  'End Function
  Public Function DateToDouble(ByVal dt As Date) As Double
    Return BitConverter.ToDouble(BitConverter.GetBytes(dt.Ticks), 0)
  End Function
  Public Function DoubleToDate(ByVal d As Double) As Date
    Return New DateTime(BitConverter.ToInt64(BitConverter.GetBytes(d), 0))
  End Function
End Class
Public Class ChartStyleGridLines
  Inherits ChartStyle
  Private rightOffset As Double = 10
  Private leftOffset As Double = 20
  Private bottomOffset As Double = 15
  Private gridline As New Line
  Public Property XLabel As String
  Public Property YLabel As String
  Public Property Title As String
  Public Property GridlinePattern As GridlinePatternEnum
  Public Property XTick As Double = 1
  Public Property YTick As Double = 0.5
  Public Property GridlineColor As Brush = Brushes.LightGray
  Public Property TextCanvas As Canvas
  Public Property IsXGrid As Boolean = True
  Public Property IsYGrid As Boolean = True
  Public Property DataString As List(Of String)

  Public Sub New()
    Title = "Title"
    XLabel = "X Axis"
    YLabel = "Y Axis"
  End Sub

  Property VerticalLines As List(Of Double)

  Public Sub AddChartStyle(ByVal tbTitle As TextBlock, ByVal tbXLabel As TextBlock, ByVal tbYLabel As TextBlock)
    Dim pt As New Point
    Dim tick As New Line
    Dim offset As Double = 0
    Dim dx, dy As Double
    Dim tb As New TextBlock
    Dim optimalXSpacing As Double = 100
    Dim optimalYSpacing As Double = 80

    '==Determine right offset
    tb.Text = Math.Round(Xmax, 0).ToString()
    tb.Measure(New Size(Double.PositiveInfinity, Double.PositiveInfinity))
    Dim size As Size = tb.DesiredSize
    rightOffset = size.Width / 2 + 2

    '==Determine left offset
    Dim xScale As Double = 0.0
    Dim yScale As Double = 0.0
    Dim xSpacing As Double = 0.0
    Dim ySpacing As Double = 0.0
    Dim xTick As Double = 0.0
    Dim yTick As Double = 0.0
    Dim xStart As Integer = 0
    Dim xEnd As Integer = 1
    Dim yStart As Integer = 0
    Dim yEnd As Integer = 1
    Dim offset0 As Double = 30
    While Math.Abs(offset - offset0) > 1
      If Xmin <> Xmax Then
        xScale = (TextCanvas.ActualWidth - offset0 - rightOffset - 5) / (Xmax - Xmin)
      End If
      If Ymin <> Ymax Then
        yScale = TextCanvas.ActualHeight / (Ymax - Ymin)
      End If
      xSpacing = optimalXSpacing / xScale
      xTick = OptimalSpacing(xSpacing)
      ySpacing = optimalYSpacing / yScale
      yTick = OptimalSpacing(ySpacing)
      xStart = CInt(Math.Ceiling(Xmin / xTick))
      xEnd = CInt(Math.Floor(Xmax / xTick))
      yStart = CInt(Math.Ceiling(Ymin / yTick))
      yEnd = CInt(Math.Floor(Ymax / yTick))

      For i As Integer = yStart To yEnd
        dy = i * yTick
        pt = NormalizePoint(New Point(Xmin, dy))
        tb = New TextBlock()
        tb.Text = dy.ToString("#,###.##")
        tb.TextAlignment = TextAlignment.Right
        tb.Measure(New Size(Double.PositiveInfinity, Double.PositiveInfinity))
        size = tb.DesiredSize
        If (offset < size.Width) Then
          offset = size.Width
        End If
      Next
      
      If (offset0 > offset) Then
        offset0 -= 0.5
      ElseIf (offset0 < offset) Then
        offset0 += 0.5
      End If
    End While

    leftOffset = offset + 5

    Canvas.SetLeft(ChartCanvas, leftOffset)
    Canvas.SetBottom(ChartCanvas, bottomOffset)
    ChartCanvas.Width = Math.Abs(TextCanvas.ActualWidth - leftOffset - rightOffset)
    ChartCanvas.Height = Math.Abs(TextCanvas.ActualHeight - bottomOffset - size.Height / 2)
    Dim chartRect As New Rectangle()
    chartRect.Stroke = Brushes.Black
    chartRect.Width = ChartCanvas.Width
    chartRect.Height = ChartCanvas.Height
    ChartCanvas.Children.Add(chartRect)

    If (Xmin <> Xmax) Then
      xScale = ChartCanvas.Width / (Xmax - Xmin)
    End If
    If (Ymin <> Ymax) Then
      yScale = ChartCanvas.Height / (Ymax - Ymin)
    End If
    xSpacing = optimalXSpacing / xScale
    xTick = OptimalSpacing(xSpacing)
    ySpacing = optimalYSpacing / yScale
    yTick = OptimalSpacing(ySpacing)
    xStart = CInt(Math.Ceiling(Xmin / xTick))
    xEnd = CInt(Math.Floor(Xmax / xTick))
    yStart = CInt(Math.Ceiling(Ymin / yTick))
    yEnd = CInt(Math.Floor(Ymax / yTick))

    If Not VerticalLines Is Nothing Then
      For Each vline As Double In Me.VerticalLines
        Dim v As New Line()
        v.Stroke = Brushes.Red
        v.StrokeThickness = 3
        v.StrokeDashArray = New DoubleCollection(New Double() {4, 3})
        v.X1 = NormalizePoint(New Point(vline, Ymin)).X
        v.Y1 = NormalizePoint(New Point(vline, Ymin)).Y
        v.X2 = NormalizePoint(New Point(vline, Ymax)).X
        v.Y2 = NormalizePoint(New Point(vline, Ymax)).Y
        ChartCanvas.Children.Add(v)
      Next
    End If

    '==Create vertical gridlines
    If IsYGrid Then
      If Not DataString Is Nothing Then
        For Each dt As String In DataString
          gridline = New Line()
          AddLinePattern()
          dx = DateToDouble(Date.Parse(dt))
          gridline.X1 = NormalizePoint(New Point(dx, Ymin)).X
          gridline.Y1 = NormalizePoint(New Point(dx, Ymin)).Y
          gridline.X2 = NormalizePoint(New Point(dx, Ymax)).X
          gridline.Y2 = NormalizePoint(New Point(dx, Ymax)).Y
          ChartCanvas.Children.Add(gridline)

          pt = NormalizePoint(New Point(dx, Ymin))
          tick = New Line()
          tick.Stroke = Brushes.Black
          tick.X1 = pt.X
          tick.Y1 = pt.Y
          tick.X2 = pt.X
          tick.Y2 = pt.Y - 5
          ChartCanvas.Children.Add(tick)

          tb = New TextBlock()
          Dim myDate As Date = DoubleToDate(dx)
          tb.Text = myDate.ToString("m")
          tb.Measure(New Size(Double.PositiveInfinity, Double.PositiveInfinity))
          size = tb.DesiredSize
          TextCanvas.Children.Add(tb)
          Canvas.SetLeft(tb, leftOffset + pt.X - size.Width / 2)
          Canvas.SetTop(tb, pt.Y + 2 + size.Height / 2)
        Next
      Else
        For i As Integer = xStart To xEnd
          gridline = New Line
          AddLinePattern()
          dx = i * xTick
          gridline.X1 = NormalizePoint(New Point(dx, Ymin)).X
          gridline.Y1 = NormalizePoint(New Point(dx, Ymin)).Y
          gridline.X2 = NormalizePoint(New Point(dx, Ymax)).X
          gridline.Y2 = NormalizePoint(New Point(dx, Ymax)).Y
          ChartCanvas.Children.Add(gridline)

          pt = NormalizePoint(New Point(dx, Ymin))
          tick = New Line()
          tick.Stroke = Brushes.Black
          tick.X1 = pt.X
          tick.Y1 = pt.Y
          tick.X2 = pt.X
          tick.Y2 = pt.Y - 5
          ChartCanvas.Children.Add(tick)

          tb = New TextBlock()
          tb.Text = dx.ToString()
          tb.Measure(New Size(Double.PositiveInfinity, Double.PositiveInfinity))
          size = tb.DesiredSize
          TextCanvas.Children.Add(tb)
          Canvas.SetLeft(tb, leftOffset + pt.X - size.Width / 2)
          Canvas.SetTop(tb, pt.Y + 2 + size.Height / 2)
        Next
      End If
    End If

      '==Create horizontal gridlines
      If IsXGrid Then
        For i As Integer = yStart To yEnd
          gridline = New Line()
          AddLinePattern()
          dy = i * yTick
          gridline.X1 = NormalizePoint(New Point(Xmin, dy)).X
          gridline.Y1 = NormalizePoint(New Point(Xmin, dy)).Y
          gridline.X2 = NormalizePoint(New Point(Xmax, dy)).X
          gridline.Y2 = NormalizePoint(New Point(Xmax, dy)).Y
          ChartCanvas.Children.Add(gridline)

          pt = NormalizePoint(New Point(Xmin, dy))
          tick = New Line()
          tick.Stroke = Brushes.Black
          tick.X1 = pt.X
          tick.Y1 = pt.Y
          tick.X2 = pt.X + 5
          tick.Y2 = pt.Y
          ChartCanvas.Children.Add(tick)

          tb = New TextBlock()
          tb.Text = dy.ToString()
          tb.Measure(New Size(Double.PositiveInfinity, Double.PositiveInfinity))
          size = tb.DesiredSize
          TextCanvas.Children.Add(tb)
          Canvas.SetRight(tb, ChartCanvas.Width + 10)
          Canvas.SetTop(tb, pt.Y)
        Next
      End If



      ' Add title and labels:
      tbTitle.Text = Title
      tbXLabel.Text = XLabel
      tbYLabel.Text = YLabel
      tbXLabel.Margin = New Thickness(leftOffset + 2, 2, 2, 2)
      tbTitle.Margin = New Thickness(leftOffset + 2, 2, 2, 2)
  End Sub
  Public Sub AddLinePattern()
    gridline.Stroke = GridlineColor
    gridline.StrokeThickness = 1
    Select Case GridlinePattern
      Case GridlinePatternEnum.Dash
        gridline.StrokeDashArray = New DoubleCollection(New Double() {4, 3})
      Case GridlinePatternEnum.Dot
        gridline.StrokeDashArray = New DoubleCollection(New Double() {1, 2})
      Case GridlinePatternEnum.DashDot
        gridline.StrokeDashArray = New DoubleCollection(New Double() {4, 2, 1, 2})
    End Select
  End Sub
  Public Enum GridlinePatternEnum
    Solid = 1
    Dash = 2
    Dot = 3
    DashDot = 4
  End Enum
End Class
