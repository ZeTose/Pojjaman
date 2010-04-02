Public Class ChartValueDTO
  Public Property XValue As Double
  Public Property XObject As Object
  Public Property YValue As Double
  Public Property YObject As Object
  Public Sub New(ByVal xv As Double, ByVal yv As Double)
    XValue = xv
    YValue = yv
  End Sub
End Class
Public Class DataSeriesDTO
  Public Property ChartValueList As List(Of ChartValueDTO)
  Public Sub New()
    ChartValueList = New List(Of ChartValueDTO)
  End Sub
  Property SeriesName As String

End Class
Public Class DataCollectionDTO
  Public Property DataSeries As List(Of DataSeriesDTO)
  Public Sub New()
    DataSeries = New List(Of DataSeriesDTO)
  End Sub
End Class
