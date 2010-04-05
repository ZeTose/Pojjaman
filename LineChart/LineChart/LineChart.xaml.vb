Public Class LineChart
  Private cs As ChartStyleGridLines
  Private dc As DataCollection
  Private ds As DataSeries
  Private lg As Legend

  Private startPoint As New Point()
  Private endPoint As New Point()

  Private rubberBand As Shape = Nothing
  Private dto As DataCollectionDTO
  Public Sub New(ByVal myDc As DataCollectionDTO, ByVal xmin As Double, ByVal xmax As Double, ByVal ymin As Double, ByVal ymax As Double _
                          , ByVal _yTickStrings As List(Of String) _
                          , ByVal _xTickStrings As List(Of String) _
                          , ByVal title As String _
                          , ByVal xLabel As String, ByVal yLabel As String _
                          , ByVal verticalTicks As List(Of Double) _
                          , ByVal horizontalTicks As List(Of Double))

    ' This call is required by the designer.
    InitializeComponent()

    ' Add any initialization after the InitializeComponent() call.
    cs = New ChartStyleGridLines()
    cs.Title = title
    cs.XLabel = xLabel
    cs.YLabel = yLabel
    cs.Xmin = xmin
    cs.Xmax = xmax
    cs.Ymin = ymin
    cs.Ymax = ymax
    cs.XTickStrings = _yTickStrings
    cs.YTickStrings = _xTickStrings
    cs.VerticalLines = verticalTicks
    cs.HorizontalLines = horizontalTicks
    dto = myDc
  End Sub
  Public Sub RefreshChart(ByVal xmin As Double, ByVal xmax As Double, ByVal ymin As Double, ByVal ymax As Double _
                          , ByVal _xTickStrings As List(Of String) _
                          , ByVal _yTickStrings As List(Of String) _
                          , ByVal title As String _
                          , ByVal xLabel As String, ByVal yLabel As String _
                          , ByVal verticalLines As List(Of Double) _
                          , ByVal horizontalLines As List(Of Double))
    dc = New DataCollection(dto)
    chartCanvas.Width = Math.Max(chartGrid.ActualWidth - 20, 0)
    chartCanvas.Height = Math.Max(chartGrid.ActualHeight - 20, 0)
    legendCanvas.Children.Clear()
    'chartCanvas.Children.Clear()
    'textCanvas.Children.Clear()

    chartCanvas.Children.RemoveRange(1, chartCanvas.Children.Count - 1)
    textCanvas.Children.RemoveRange(1, textCanvas.Children.Count - 1)

    cs = New ChartStyleGridLines()
    cs.Title = title
    cs.XLabel = xLabel
    cs.YLabel = yLabel
    cs.Xmin = xmin
    cs.Xmax = xmax
    cs.Ymin = ymin
    cs.Ymax = ymax
    cs.XTickStrings = _xTickStrings
    cs.YTickStrings = _yTickStrings
    cs.VerticalLines = verticalLines
    cs.HorizontalLines = horizontalLines

    lg = New Legend()
    cs.ChartCanvas = chartCanvas
    cs.TextCanvas = textCanvas
    cs.YTick = 0.5
    cs.GridlinePattern = ChartStyleGridLines.GridlinePatternEnum.Dot
    cs.GridlineColor = Brushes.Black
    cs.AddChartStyle(tbTitle, tbXLabel, tbYLabel)

    dc.AddLines(cs)

    lg.LegendCanvas = legendCanvas
    lg.IsLegend = True
    lg.IsBorder = True
    lg.LegendPosition = Legend.LegendPositionEnum.NorthWest
    lg.AddLegend(cs.ChartCanvas, dc)
  End Sub
  Private Sub chartGrid_SizeChanged(ByVal sender As Object, ByVal e As SizeChangedEventArgs)
    RefreshChart(cs.Xmin, cs.Xmax, cs.Ymin, cs.Ymax, cs.XTickStrings, cs.YTickStrings, cs.Title, cs.XLabel, cs.YLabel, cs.VerticalLines, cs.HorizontalLines)
  End Sub

  Private Sub chartCanvas_MouseLeftButtonDown(ByVal sender As System.Object, ByVal e As System.Windows.Input.MouseButtonEventArgs) Handles chartCanvas.MouseLeftButtonDown
    'If (Not chartCanvas.IsMouseCaptured) Then
    '  startPoint = e.GetPosition(chartCanvas)
    '  chartCanvas.CaptureMouse()
    'End If
  End Sub
  Private Sub chartCanvas_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Input.MouseEventArgs) Handles chartCanvas.MouseMove
    'If (chartCanvas.IsMouseCaptured) Then
    '  endPoint = e.GetPosition(chartCanvas)
    '  If rubberBand Is Nothing Then
    '    rubberBand = New Rectangle
    '    rubberBand.Stroke = Brushes.Red
    '    chartCanvas.Children.Add(rubberBand)
    '  End If
    '  rubberBand.Width = Math.Abs(startPoint.X - endPoint.X)
    '  rubberBand.Height = Math.Abs(startPoint.Y - endPoint.Y)
    '  Dim left As Double = Math.Min(startPoint.X, endPoint.X)
    '  Dim top As Double = Math.Min(startPoint.Y, endPoint.Y)
    '  Canvas.SetLeft(rubberBand, left)
    '  Canvas.SetTop(rubberBand, top)
    'End If
  End Sub
  Private Sub chartCanvas_MouseLeftButtonUp(ByVal sender As System.Object, ByVal e As System.Windows.Input.MouseButtonEventArgs) Handles chartCanvas.MouseLeftButtonUp
    'Dim x0 As Double = 0
    'Dim x1 As Double = 1
    'Dim y0 As Double = 0
    'Dim y1 As Double = 1
    'endPoint = e.GetPosition(chartCanvas)
    'If endPoint.X > startPoint.X Then
    '  x0 = cs.Xmin + (cs.Xmax - cs.Xmin) * startPoint.X / chartCanvas.Width
    '  x1 = cs.Xmin + (cs.Xmax - cs.Xmin) * endPoint.X / chartCanvas.Width
    'ElseIf endPoint.X < startPoint.X Then
    '  x1 = cs.Xmin + (cs.Xmax - cs.Xmin) * startPoint.X / chartCanvas.Width
    '  x0 = cs.Xmin + (cs.Xmax - cs.Xmin) * endPoint.X / chartCanvas.Width
    'End If

    'If endPoint.Y < startPoint.Y Then
    '  y0 = cs.Ymin + (cs.Ymax - cs.Ymin) * (chartCanvas.Height - startPoint.Y) / chartCanvas.Height
    '  y1 = cs.Ymin + (cs.Ymax - cs.Ymin) * (chartCanvas.Height - endPoint.Y) / chartCanvas.Height
    'ElseIf endPoint.Y > startPoint.Y Then
    '  y1 = cs.Ymin + (cs.Ymax - cs.Ymin) * (chartCanvas.Height - startPoint.Y) / chartCanvas.Height
    '  y0 = cs.Ymin + (cs.Ymax - cs.Ymin) * (chartCanvas.Height - endPoint.Y) / chartCanvas.Height
    'End If
    'RefreshChart(x0, x1, y0, y1, cs.DataString, cs.Title, cs.XTick, cs.YTick, cs.VerticalLines)

    'If Not rubberBand Is Nothing Then
    '  rubberBand = Nothing
    '  chartCanvas.ReleaseMouseCapture()
    'End If
  End Sub

  Private Sub chartCanvas_MouseRightButtonDown(ByVal sender As System.Object, ByVal e As System.Windows.Input.MouseButtonEventArgs) Handles chartCanvas.MouseRightButtonDown
    'RefreshChart(cs.Xmin, cs.Xmax, cs.Ymin, cs.Ymax, cs.DataString, cs.Title, cs.XLabel, cs.YLabel, cs.VerticalLines)
  End Sub
End Class
