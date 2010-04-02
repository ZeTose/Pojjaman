Public Class LineChart
  Private cs As ChartStyleGridLines
  Private dc As DataCollection
  Private ds As DataSeries
  Private lg As Legend

  Private startPoint As New Point()
  Private endPoint As New Point()

  Private rubberBand As Shape = Nothing
  Private dto As DataCollectionDTO
  Public Sub New(ByVal myDc As DataCollectionDTO, ByVal xmin As Double, ByVal xmax As Double, ByVal ymin As Double, ByVal ymax As Double, ByVal dataString As List(Of String) _
                          , ByVal title As String _
                          , ByVal xLabel As String, ByVal yLabel As String _
                          , ByVal verticalLines As List(Of Double))

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
    cs.DataString = dataString
    cs.VerticalLines = verticalLines
    dto = myDc
  End Sub
  Public Sub RefreshChart(ByVal xmin As Double, ByVal xmax As Double _
                          , ByVal ymin As Double, ByVal ymax As Double _
                          , ByVal dataString As List(Of String) _
                          , ByVal title As String _
                          , ByVal xLabel As String, ByVal yLabel As String _
                          , ByVal verticalLines As List(Of Double))
    dc = New DataCollection(dto)
    chartCanvas.Width = Math.Max(chartGrid.ActualWidth - 20, 0)
    chartCanvas.Height = Math.Max(chartGrid.ActualHeight - 20, 0)
    legendCanvas.Children.Clear()
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
    cs.DataString = dataString
    cs.VerticalLines = verticalLines

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
    RefreshChart(cs.Xmin, cs.Xmax, cs.Ymin, cs.Ymax, cs.DataString, cs.Title, cs.XLabel, cs.YLabel, cs.VerticalLines)
  End Sub

  Private Sub chartCanvas_MouseLeftButtonDown(ByVal sender As System.Object, ByVal e As System.Windows.Input.MouseButtonEventArgs) Handles chartCanvas.MouseLeftButtonDown
    'If (Not chartCanvas.IsMouseCaptured) Then
    '  startPoint = e.GetPosition(chartCanvas)
    '  chartCanvas.CaptureMouse()
    'End If
  End Sub

  Private Sub chartCanvas_MouseLeftButtonUp(ByVal sender As System.Object, ByVal e As System.Windows.Input.MouseButtonEventArgs) Handles chartCanvas.MouseLeftButtonUp
    'Dim dx As Double = 0
    'Dim dy As Double = 0
    'Dim x0 As Double = 0
    'Dim x1 As Double = 1
    'Dim y0 As Double = 0
    'Dim y1 As Double = 1
    'endPoint = e.GetPosition(chartCanvas)
    'dx = (cs.Xmax - cs.Xmin) * (endPoint.X - startPoint.X) /
    'chartCanvas.Width
    'dy = (cs.Ymax - cs.Ymin) * (endPoint.Y - startPoint.Y) /
    'chartCanvas.Height
    'x0 = cs.Xmin + dx
    'x1 = cs.Xmax + dx
    'y0 = cs.Ymin + dy
    'y1 = cs.Ymax + dy

    'RefreshChart(x0, x1, y0, y1)

    'chartCanvas.ReleaseMouseCapture()
    'chartCanvas.Cursor = Cursors.Arrow
  End Sub

  Private Sub chartCanvas_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Input.MouseEventArgs) Handles chartCanvas.MouseMove
    'If (chartCanvas.IsMouseCaptured) Then
    '  endPoint = e.GetPosition(chartCanvas)
    '  Dim tt As New TranslateTransform()
    '  tt.X = endPoint.X - startPoint.X
    '  tt.Y = endPoint.Y - startPoint.Y
    '  For i As Integer = 0 To dc.DataList.Count - 1
    '    dc.DataList(i).LineSeries.RenderTransform = tt
    '  Next
    'End If
  End Sub

  Private Sub chartCanvas_MouseRightButtonDown(ByVal sender As System.Object, ByVal e As System.Windows.Input.MouseButtonEventArgs) Handles chartCanvas.MouseRightButtonDown
    'RefreshChart(xmin0, xmax0, ymin0, ymax0)
  End Sub
End Class
