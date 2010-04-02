Public Class Symbols
  Public Property SymbolType As SymbolTypeEnum
  Public Property SymbolSize As Double
  Public Property BorderColor As Brush
  Public Property FillColor As Brush
  Public Property BorderThickness As Double
  Public Sub New()
    SymbolType = SymbolTypeEnum.None
    SymbolSize = 8.0
    BorderColor = Brushes.Black
    FillColor = Brushes.Black
    BorderThickness = 1.0
  End Sub
  Public Sub AddSymbol(ByVal symCanvas As Canvas, ByVal pt As Point)
    Dim plg As Polygon = New Polygon()
    plg.Stroke = BorderColor
    plg.StrokeThickness = BorderThickness
    plg.ToolTip = pt.ToString
    Dim ellipse As New Ellipse()
    ellipse.Stroke = BorderColor
    ellipse.StrokeThickness = BorderThickness
    ellipse.ToolTip = pt.ToString

    Dim line As New Line()
    Dim halfSize As Double = 0.5 * SymbolSize
    Canvas.SetZIndex(plg, 5)
    Canvas.SetZIndex(ellipse, 5)

    Select Case SymbolType
      Case SymbolTypeEnum.Square
        plg.Fill = Brushes.White
        plg.Points.Add(New Point(pt.X - halfSize, pt.Y - halfSize))
        plg.Points.Add(New Point(pt.X + halfSize, pt.Y - halfSize))
        plg.Points.Add(New Point(pt.X + halfSize, pt.Y + halfSize))
        plg.Points.Add(New Point(pt.X - halfSize, pt.Y + halfSize))
        symCanvas.Children.Add(plg)
      Case SymbolTypeEnum.OpenDiamond
        plg.Fill = Brushes.White
        plg.Points.Add(New Point(pt.X - halfSize, pt.Y))
        plg.Points.Add(New Point(pt.X, pt.Y - halfSize))
        plg.Points.Add(New Point(pt.X + halfSize, pt.Y))
        plg.Points.Add(New Point(pt.X, pt.Y + halfSize))
        symCanvas.Children.Add(plg)
      Case SymbolTypeEnum.Circle
        ellipse.Fill = Brushes.White
        ellipse.Width = SymbolSize
        ellipse.Height = SymbolSize
        Canvas.SetLeft(ellipse, pt.X - halfSize)
        Canvas.SetTop(ellipse, pt.Y - halfSize)
        symCanvas.Children.Add(ellipse)
      Case SymbolTypeEnum.OpenTriangle
        plg.Fill = Brushes.White
        plg.Points.Add(New Point(pt.X - halfSize, pt.Y + halfSize))
        plg.Points.Add(New Point(pt.X, pt.Y - halfSize))
        plg.Points.Add(New Point(pt.X + halfSize, pt.Y + halfSize))
        symCanvas.Children.Add(plg)
      Case SymbolTypeEnum.None
      Case SymbolTypeEnum.Cross
        line = New Line()
        Canvas.SetZIndex(line, 5)
        line.Stroke = BorderColor
        line.StrokeThickness = BorderThickness
        line.X1 = pt.X - halfSize
        line.Y1 = pt.Y + halfSize
        line.X2 = pt.X + halfSize
        line.Y2 = pt.Y - halfSize
        symCanvas.Children.Add(line)
        line = New Line()
        Canvas.SetZIndex(line, 5)
        line.Stroke = BorderColor
        line.StrokeThickness = BorderThickness
        line.X1 = pt.X - halfSize
        line.Y1 = pt.Y - halfSize
        line.X2 = pt.X + halfSize
        line.Y2 = pt.Y + halfSize
        symCanvas.Children.Add(line)
        Canvas.SetZIndex(line, 5)
      Case SymbolTypeEnum.Star
        line = New Line()
        Canvas.SetZIndex(line, 5)
        line.Stroke = BorderColor
        line.StrokeThickness = BorderThickness
        line.X1 = pt.X - halfSize
        line.Y1 = pt.Y + halfSize
        line.X2 = pt.X + halfSize
        line.Y2 = pt.Y - halfSize
        symCanvas.Children.Add(line)
        line = New Line()
        Canvas.SetZIndex(line, 5)
        line.Stroke = BorderColor
        line.StrokeThickness = BorderThickness
        line.X1 = pt.X - halfSize
        line.Y1 = pt.Y - halfSize
        line.X2 = pt.X + halfSize
        line.Y2 = pt.Y + halfSize
        symCanvas.Children.Add(line)
        line = New Line()
        Canvas.SetZIndex(line, 5)
        line.Stroke = BorderColor
        line.StrokeThickness = BorderThickness
        line.X1 = pt.X - halfSize
        line.Y1 = pt.Y
        line.X2 = pt.X + halfSize
        line.Y2 = pt.Y
        symCanvas.Children.Add(line)
        line = New Line()
        Canvas.SetZIndex(line, 5)
        line.Stroke = BorderColor
        line.StrokeThickness = BorderThickness
        line.X1 = pt.X
        line.Y1 = pt.Y - halfSize
        line.X2 = pt.X
        line.Y2 = pt.Y + halfSize
        symCanvas.Children.Add(line)
      Case SymbolTypeEnum.OpenInvertedTriangle
        plg.Fill = Brushes.White
        plg.Points.Add(New Point(pt.X, pt.Y + halfSize))
        plg.Points.Add(New Point(pt.X - halfSize, pt.Y - halfSize))
        plg.Points.Add(New Point(pt.X + halfSize, pt.Y - halfSize))
        symCanvas.Children.Add(plg)
      Case SymbolTypeEnum.Plus
        line = New Line()
        Canvas.SetZIndex(line, 5)
        line.Stroke = BorderColor
        line.StrokeThickness = BorderThickness
        line.X1 = pt.X - halfSize
        line.Y1 = pt.Y
        line.X2 = pt.X + halfSize
        line.Y2 = pt.Y
        symCanvas.Children.Add(line)
        line = New Line()
        Canvas.SetZIndex(line, 5)
        line.Stroke = BorderColor
        line.StrokeThickness = BorderThickness
        line.X1 = pt.X
        line.Y1 = pt.Y - halfSize
        line.X2 = pt.X
        line.Y2 = pt.Y + halfSize
        symCanvas.Children.Add(line)
      Case SymbolTypeEnum.Dot
        ellipse.Fill = FillColor
        ellipse.Width = SymbolSize
        ellipse.Height = SymbolSize
        Canvas.SetLeft(ellipse, pt.X - halfSize)
        Canvas.SetTop(ellipse, pt.Y - halfSize)
        symCanvas.Children.Add(ellipse)
      Case SymbolTypeEnum.Box
        plg.Fill = FillColor
        plg.Points.Add(New Point(pt.X - halfSize, pt.Y - halfSize))
        plg.Points.Add(New Point(pt.X + halfSize, pt.Y - halfSize))
        plg.Points.Add(New Point(pt.X + halfSize, pt.Y + halfSize))
        plg.Points.Add(New Point(pt.X - halfSize, pt.Y + halfSize))
        symCanvas.Children.Add(plg)
      Case SymbolTypeEnum.Diamond
        plg.Fill = FillColor
        plg.Points.Add(New Point(pt.X - halfSize, pt.Y))
        plg.Points.Add(New Point(pt.X, pt.Y - halfSize))
        plg.Points.Add(New Point(pt.X + halfSize, pt.Y))
        plg.Points.Add(New Point(pt.X, pt.Y + halfSize))
        symCanvas.Children.Add(plg)
      Case SymbolTypeEnum.InvertedTriangle
        plg.Fill = FillColor
        plg.Points.Add(New Point(pt.X, pt.Y + halfSize))
        plg.Points.Add(New Point(pt.X - halfSize, pt.Y - halfSize))
        plg.Points.Add(New Point(pt.X + halfSize, pt.Y - halfSize))
        symCanvas.Children.Add(plg)
      Case SymbolTypeEnum.Triangle
        plg.Fill = FillColor
        plg.Points.Add(New Point(pt.X - halfSize, pt.Y + halfSize))
        plg.Points.Add(New Point(pt.X, pt.Y - halfSize))
        plg.Points.Add(New Point(pt.X + halfSize, pt.Y + halfSize))
        symCanvas.Children.Add(plg)
    End Select
  End Sub
  Public Enum SymbolTypeEnum
    Box = 0
    Circle = 1
    Cross = 2
    Diamond = 3
    Dot = 4
    InvertedTriangle = 5
    None = 6
    OpenDiamond = 7
    OpenInvertedTriangle = 8
    OpenTriangle = 9
    Square = 10
    Star = 11
    Triangle = 12
    Plus = 13
  End Enum
End Class
