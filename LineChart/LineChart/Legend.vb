Public Class Legend
  Public Property IsLegend As Boolean
  Public Property IsBorder As Boolean
  Public Property LegendCanvas As Canvas
  Public Property LegendPosition As LegendPositionEnum
  Public Sub New()
    IsLegend = False
    IsBorder = True
    LegendPosition = LegendPositionEnum.NorthEast
  End Sub
  Public Sub AddLegend(ByVal chartCanvas As Canvas, ByVal dc As DataCollection)
    Dim tb As New TextBlock
    If dc.DataList.Count < 1 OrElse Not IsLegend Then
      Return
    End If
    Dim legendLabels(dc.DataList.Count) As String
    Dim n As Integer = 0
    For Each ds As DataSeries In dc.DataList
      legendLabels(n) = ds.SeriesName
      n += 1
    Next
    Dim legendWidth As Double = 0
    Dim size As New Size(0, 0)
    For Each legendLabel As String In legendLabels
      tb = New TextBlock
      tb.Text = legendLabel
      tb.Measure(New Size(Double.PositiveInfinity, Double.PositiveInfinity))
      size = tb.DesiredSize
      If legendWidth < size.Width Then
        legendWidth = size.Width
      End If
    Next

    legendWidth += 50
    LegendCanvas.Width = legendWidth + 5
    Dim legendHeight As Double = 17 * dc.DataList.Count
    Dim sx As Double = 6
    Dim sy As Double = 0
    Dim textHeight As Double = size.Height
    Dim lineLength As Double = 34
    Dim legendRect As New Rectangle()
    legendRect.Stroke = Brushes.Black
    legendRect.Fill = Brushes.White
    legendRect.Width = legendWidth
    legendRect.Height = legendHeight

    If IsLegend AndAlso IsBorder Then
      LegendCanvas.Children.Add(legendRect)
    End If
    Canvas.SetZIndex(LegendCanvas, 10)
    'LegendCanvas.SetValue(Canvas.ZIndexProperty, 1000)
    'MessageBox.Show(LegendCanvas.GetValue(Canvas.ZIndexProperty).ToString)


    n = 1
    For Each ds As DataSeries In dc.DataList
      Dim xSymbol As Double = sx + lineLength / 2
      Dim xText As Double = 2 * sx + lineLength
      Dim yText As Double = n * sy + (2 * n - 1) * textHeight / 2
      Dim line As New Line()
      AddLinePattern(line, ds)
      line.X1 = sx
      line.Y1 = yText
      line.X2 = sx + lineLength
      line.Y2 = yText
      LegendCanvas.Children.Add(line)
      'ds.Symbols.AddSymbol(LegendCanvas, New Point(0.5 * (line.X2 - line.X1 + ds.Symbols.SymbolSize) + 1, line.Y1))
      tb = New TextBlock()
      tb.Text = ds.SeriesName
      LegendCanvas.Children.Add(tb)
      Canvas.SetTop(tb, yText - size.Height / 2)
      Canvas.SetLeft(tb, xText)
      n += 1
    Next
    LegendCanvas.Width = legendRect.Width
    LegendCanvas.Height = legendRect.Height
    Dim offSet As Double = 7.0
    Select Case LegendPosition
      Case LegendPositionEnum.East
        Canvas.SetRight(LegendCanvas, offSet)
        Canvas.SetTop(LegendCanvas,
        chartCanvas.Height / 2 - legendRect.Height / 2)
      Case LegendPositionEnum.NorthEast
        Canvas.SetTop(LegendCanvas, offSet)
        Canvas.SetRight(LegendCanvas, offSet)
      Case LegendPositionEnum.North
        Canvas.SetTop(LegendCanvas, offSet)
        Canvas.SetLeft(LegendCanvas,
        chartCanvas.Width / 2 - legendRect.Width / 2)
      Case LegendPositionEnum.NorthWest
        Canvas.SetTop(LegendCanvas, offSet)
        Canvas.SetLeft(LegendCanvas, offSet)
      Case LegendPositionEnum.West
        Canvas.SetTop(LegendCanvas,
        chartCanvas.Height / 2 - legendRect.Height / 2)
        Canvas.SetLeft(LegendCanvas, offSet)
      Case LegendPositionEnum.SouthWest
        Canvas.SetBottom(LegendCanvas, offSet)
        Canvas.SetLeft(LegendCanvas, offSet)
      Case LegendPositionEnum.South
        Canvas.SetBottom(LegendCanvas, offSet)
        Canvas.SetLeft(LegendCanvas,
        chartCanvas.Width / 2 - legendRect.Width / 2)
      Case LegendPositionEnum.SouthEast
        Canvas.SetBottom(LegendCanvas, offSet)
        Canvas.SetRight(LegendCanvas, offSet)
    End Select
  End Sub
  Public Sub AddLinePattern(ByVal line As Line, ByVal ds As DataSeries)
    line.Stroke = ds.LineColor
    line.StrokeThickness = ds.LineThickness
    Select Case ds.LinePattern
      Case DataSeries.LinePatternEnum.Dash
        line.StrokeDashArray =
        New DoubleCollection(New Double() {4, 3})
      Case DataSeries.LinePatternEnum.Dot
        line.StrokeDashArray =
        New DoubleCollection(New Double() {1, 2})
      Case DataSeries.LinePatternEnum.DashDot
        line.StrokeDashArray =
        New DoubleCollection(New Double() {4, 2, 1, 2})
      Case DataSeries.LinePatternEnum.None
        line.Stroke = Brushes.Transparent
    End Select
  End Sub
  Public Enum LegendPositionEnum
    North
    NorthWest
    West
    SouthWest
    South
    SouthEast
    East
    NorthEast
  End Enum

End Class
