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
      For i As Integer = 0 To ds.LineSeries.Points.Count - 1
        ds.LineSeries.Points(i) = cs.NormalizePoint(ds.LineSeries.Points(i))
        ds.Symbols.AddSymbol(cs.ChartCanvas, ds.LineSeries.Points(i))
      Next
      cs.ChartCanvas.Children.Add(ds.LineSeries)
      j += 1
    Next
  End Sub
End Class
