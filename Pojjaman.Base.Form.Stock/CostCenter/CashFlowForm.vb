Imports Longkong.Pojjaman.BusinessLogic
Imports System.Data.SqlClient
Imports System.Collections.Generic
Imports System.Windows.Forms.Integration
Imports LineChart
Imports Longkong.Pojjaman.Gui.Components

Public Class CashFlowForm
  Public Property CostCenter As CostCenter
  Private ctrlHost As ElementHost
  Private myChart As LineChart.LineChart
  Private Sub CashFlowForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    Me.lblName.Text = ""
    If Not CostCenter Is Nothing Then
      Me.lblName.Text = "Cash Flow For: " & CostCenter.Name
    End If

    ctrlHost = New ElementHost
    ctrlHost.Dock = DockStyle.Fill
    Panel2.Controls.Add(ctrlHost)
  End Sub
  Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
    If CostCenter Is Nothing Then
      Return
    End If
    Dim dataDate As Date = Me.DateTimePicker1.Value.Date
    Dim ds As DataSet = CostCenter.GetCashFlow(dataDate)
    Dim lists As New List(Of SortedList(Of Date, Decimal))
    For i As Integer = 0 To 7
      Dim list As New SortedList(Of Date, Decimal)
      For Each row As DataRow In ds.Tables(i).Rows
        Dim theDate As Date = CDate(row(0))
        Dim value As Decimal = CDec(row(1))
        list(theDate) = CDec(row(1))
      Next
      lists.Add(list)
    Next
    Dim minDate As Date = Date.MaxValue
    Dim maxDate As Date = Date.MinValue
    For Each list As SortedList(Of Date, Decimal) In lists
      If list.Count > 0 Then
        If list.Keys(0) < minDate Then
          minDate = list.Keys(0)
        End If
        If list.Keys(list.Count - 1) > maxDate Then
          maxDate = list.Keys(list.Count - 1)
        End If
      End If
    Next
    Dim currentDate As Date = minDate
    Dim allDays As New List(Of Date)
    Dim dataString As New List(Of String)
    While currentDate <= maxDate
      If currentDate.Day = 1 AndAlso currentDate > minDate Then
        dataString.Add(currentDate.AddDays(-1))
      End If
      allDays.Add(currentDate)
      currentDate = currentDate.AddDays(1)
    End While
    Dim dt As New DataTable("CF")
    Dim exp As DataRow = dt.NewRow
    dt.Rows.Add(exp)

    Dim accExp As DataRow = dt.NewRow
    dt.Rows.Add(accExp)

    Dim rev As DataRow = dt.NewRow
    dt.Rows.Add(rev)

    Dim accRev As DataRow = dt.NewRow
    dt.Rows.Add(accRev)

    Dim cf As DataRow = dt.NewRow
    dt.Rows.Add(cf)

    Dim remain As Decimal = 0
    Dim accExpVal As Decimal = 0
    Dim accRevVal As Decimal = 0
    Dim maxY As Decimal = Decimal.MinValue
    Dim minY As Decimal = Decimal.MaxValue
    Dim headcol As New DataColumn("Type", GetType(String))
    dt.Columns.Add(headcol)

    For Each d As Date In allDays
      Dim col As New DataColumn(d.ToShortDateString, GetType(String))
      dt.Columns.Add(col)
      Dim data0 As Decimal = 0
      Dim datalist As New List(Of Decimal)
      For i As Integer = 0 To 7
        If lists(i).ContainsKey(d) Then
          datalist.Add(lists(i)(d))
        Else
          datalist.Add(0)
        End If
      Next
      If d <= dataDate Then
        exp(col) = datalist(3) + datalist(4)
        remain = datalist(0) + datalist(1) + datalist(2)

        rev(col) = datalist(5) + datalist(6)
      ElseIf d = dataDate.AddDays(1) Then
        exp(col) = remain + datalist(0) + datalist(1) + datalist(2) + datalist(3) + datalist(4)

        rev(col) = datalist(7)
      Else
        exp(col) = datalist(0) + datalist(1) + datalist(2)

        rev(col) = datalist(7)
      End If

      accExpVal += exp(col)
      accExp(col) = accExpVal

      accRevVal += rev(col)
      accRev(col) = accRevVal

      cf(col) = accRevVal - accExpVal

      If accExpVal > maxY Then
        maxY = accExpVal
      End If
      If accRevVal > maxY Then
        maxY = accRevVal
      End If

      If accExpVal < minY Then
        minY = accExpVal
      End If
      If accRevVal < minY Then
        minY = accRevVal
      End If

      If exp(col) > maxY Then
        maxY = exp(col)
      End If
      If rev(col) > maxY Then
        maxY = rev(col)
      End If

      If exp(col) < minY Then
        minY = exp(col)
      End If
      If rev(col) < minY Then
        minY = rev(col)
      End If

      If cf(col) > maxY Then
        maxY = cf(col)
      End If
      If cf(col) < minY Then
        minY = cf(col)
      End If
    Next

    Dim myDC As New DataCollectionDTO()
    For m As Integer = 0 To 4
      Dim myDs As New DataSeriesDTO
      Select Case m
        Case 0
          myDs.SeriesName = "Total Expense"
        Case 1
          myDs.SeriesName = "Cumm Expense"
        Case 2
          myDs.SeriesName = "Total Revenue"
        Case 3
          myDs.SeriesName = "Cumm Revenue"
        Case 4
          myDs.SeriesName = "Cash Flow"
      End Select
      dt.Rows(m)(0) = myDs.SeriesName
      For n As Integer = 0 To allDays.Count - 1
        '===========================================================
        myDs.ChartValueList.Add(New ChartValueDTO(DateToDouble(allDays(n)), dt.Rows(m)(allDays(n).ToShortDateString)))
        '============================================================================
      Next
      myDC.DataSeries.Add(myDs)
    Next

    Dim verticalLines As New List(Of Double)
    verticalLines.Add(DateToDouble(dataDate))

    myChart = New LineChart.LineChart(myDC, DateToDouble(allDays(0)), DateToDouble(allDays(allDays.Count - 1)), minY * 1.1, maxY * 1.1, dataString, Me.CostCenter.Name, "Date", "Amount", verticalLines)
    myChart.InitializeComponent()
    ctrlHost.Child = myChart

    Dim dst As New DataGridTableStyle
    dst.MappingName = "CF"

    Dim csLineNumber As New TreeTextColumn
    csLineNumber.MappingName = "Type"
    csLineNumber.HeaderText = "Type"
    csLineNumber.NullText = ""
    csLineNumber.Width = 100
    csLineNumber.DataAlignment = HorizontalAlignment.Center
    csLineNumber.ReadOnly = True
    dst.GridColumnStyles.Add(csLineNumber)

    For Each col As DataColumn In dt.Columns
      If col.ColumnName.ToLower <> "type" Then
        Dim csCode As New TreeTextColumn
        csCode.MappingName = col.ColumnName
        csCode.HeaderText = col.ColumnName
        csCode.NullText = ""
        csCode.ReadOnly = True
        dst.GridColumnStyles.Add(csCode)
      End If
    Next

    Dim m_treeManager As New TreeManager(dt, tgItem)
    m_treeManager.SetTableStyle(dst)
    m_treeManager.AllowSorting = False
    m_treeManager.AllowDelete = False

  End Sub
  Public Function DateToDouble(ByVal dt As Date) As Double
    Return BitConverter.ToDouble(BitConverter.GetBytes(dt.Ticks), 0)
  End Function
End Class