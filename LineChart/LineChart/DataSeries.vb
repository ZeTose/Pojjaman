Public Class DataSeries
  Public Const DEFAULT_NAME As String = "Default Name"
  Public Property LineSeries As New Polyline
  Public Property LineColor As Brush
  Public Property LineThickness As Double = -1
  Public Property LinePattern As LinePatternEnum = LinePatternEnum.Solid
  Public Property SeriesName As String = DEFAULT_NAME
  Public Property Symbols As Symbols
  Public Sub New()
    LineColor = Brushes.Black
    Symbols = New Symbols
  End Sub

  Public Sub AddLinePattern()
    LineSeries.Stroke = LineColor
    LineSeries.StrokeThickness = LineThickness

    Select Case LinePattern
      Case LinePatternEnum.Dash
        LineSeries.StrokeDashArray = New DoubleCollection(New Double() {4, 3})
      Case LinePatternEnum.Dot
        LineSeries.StrokeDashArray = New DoubleCollection(New Double() {1, 2})
      Case LinePatternEnum.DashDot
        LineSeries.StrokeDashArray = New DoubleCollection(New Double() {4, 2, 1, 2})
      Case LinePatternEnum.None
        LineSeries.Stroke = Brushes.Transparent
    End Select
  End Sub

  Public Enum LinePatternEnum
    Solid = 1
    Dash = 2
    Dot = 3
    DashDot = 4
    None = 5
  End Enum

End Class
