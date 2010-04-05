Public Class DataCollection
  Public Property DataList As List(Of DataSeries)
  Public Sub New()
    DataList = New List(Of DataSeries)
  End Sub
  Public Sub New(ByVal dc As DataCollectionDTO)
    Convert(dc)
  End Sub
  Public Sub Convert(ByVal dc As DataCollectionDTO)
    DataList = New List(Of DataSeries)
    Dim i As Integer = 0
    For Each ds As DataSeriesDTO In dc.DataSeries
      Dim myDs As New DataSeries
      Select Case i
        Case 0
          myDs.LineColor = System.Windows.Media.Brushes.Purple
          myDs.Symbols.BorderColor = System.Windows.Media.Brushes.AliceBlue
          myDs.Symbols.SymbolType = Symbols.SymbolTypeEnum.None
          myDs.LinePattern = DataSeries.LinePatternEnum.Solid
        Case 1
          myDs.LineColor = System.Windows.Media.Brushes.Red
          myDs.Symbols.BorderColor = System.Windows.Media.Brushes.Red
          myDs.Symbols.SymbolType = Symbols.SymbolTypeEnum.None
          myDs.LinePattern = DataSeries.LinePatternEnum.Solid
        Case 2
          myDs.LineColor = System.Windows.Media.Brushes.LawnGreen
          myDs.Symbols.BorderColor = System.Windows.Media.Brushes.LawnGreen
          myDs.Symbols.SymbolType = Symbols.SymbolTypeEnum.None
          myDs.LinePattern = DataSeries.LinePatternEnum.Solid
        Case 3
          myDs.LineColor = System.Windows.Media.Brushes.Violet
          myDs.Symbols.BorderColor = System.Windows.Media.Brushes.Violet
          myDs.Symbols.SymbolType = Symbols.SymbolTypeEnum.None
          myDs.LinePattern = DataSeries.LinePatternEnum.Solid
        Case 4
          myDs.LineColor = System.Windows.Media.Brushes.Blue
          myDs.Symbols.BorderColor = System.Windows.Media.Brushes.Blue
          myDs.Symbols.SymbolType = Symbols.SymbolTypeEnum.None
          myDs.LinePattern = DataSeries.LinePatternEnum.Solid
        Case Else
          myDs.LineColor = System.Windows.Media.Brushes.Violet
          myDs.Symbols.BorderColor = System.Windows.Media.Brushes.Violet
          myDs.Symbols.SymbolType = Symbols.SymbolTypeEnum.None
          myDs.LinePattern = DataSeries.LinePatternEnum.Solid
      End Select
      i += 1


      myDs.LineThickness = 2
      myDs.SeriesName = ds.SeriesName
      myDs.IsStairstep = ds.IsStairStep
      myDs.IsStem = ds.IsStem
      If myDs.IsStem Then
        myDs.Symbols.BorderColor = System.Windows.Media.Brushes.DarkGreen
        myDs.Symbols.FillColor = System.Windows.Media.Brushes.Yellow
        myDs.Symbols.SymbolType = Symbols.SymbolTypeEnum.Diamond
      End If
      For Each cv As ChartValueDTO In ds.ChartValueList
        myDs.LineSeries.Points.Add(New Point(cv.XValue, cv.YValue))
      Next
      DataList.Add(myDs)
    Next
  End Sub
  Public Sub AddLines(ByVal cs As ChartStyle)
    Dim j As Integer = 0
    For Each ds As DataSeries In DataList
      If ds.SeriesName = DataSeries.DEFAULT_NAME Then
        ds.SeriesName = "DataSeries" + j.ToString
      End If
      ds.AddLinePattern()
      If ds.IsStairstep Then
        Dim ptlist As New List(Of Point)
        Dim pts(2) As Point
        ds.AddLinePattern()
        For i As Integer = 0 To ds.LineSeries.Points.Count - 2
          pts(0) = ds.LineSeries.Points(i)
          pts(1) = ds.LineSeries.Points(i + 1)
          ptlist.Add(pts(0))
          ptlist.Add(New Point(pts(1).X, pts(0).Y))
        Next
        ds.LineSeries.Points.Clear()
        For i As Integer = 0 To ptlist.Count - 1
          ds.LineSeries.Points.Add(ptlist(i))
        Next
      End If
      If ds.IsStem Then
        Dim pts(2) As Point
        For i As Integer = 0 To ds.LineSeries.Points.Count - 1
          If ds.LineSeries.Points(i).Y <> 0 Then
            pts(0) = cs.NormalizePoint(New Point(ds.LineSeries.Points(i).X, 0))
            pts(1) = cs.NormalizePoint(ds.LineSeries.Points(i))

            Dim line As Line = New Line
            line.Stroke = ds.LineColor
            line.StrokeThickness = ds.LineThickness
            line.X1 = pts(0).X
            line.Y1 = pts(0).Y
            line.X2 = pts(1).X
            line.Y2 = pts(1).Y
            cs.ChartCanvas.Children.Add(line)
            ds.Symbols.AddSymbol(cs.ChartCanvas, cs.NormalizePoint(ds.LineSeries.Points(i)), ds.LineSeries.Points(i).Y.ToString("N2"))
          End If
        Next
      Else
        For i As Integer = 0 To ds.LineSeries.Points.Count - 1
          Dim tt As String = ds.LineSeries.Points(i).Y.ToString("N2")
          ds.LineSeries.Points(i) = cs.NormalizePoint(ds.LineSeries.Points(i))
          ds.Symbols.AddSymbol(cs.ChartCanvas, ds.LineSeries.Points(i), tt)
        Next
        cs.ChartCanvas.Children.Add(ds.LineSeries)
      End If
      j += 1
    Next
  End Sub
End Class
