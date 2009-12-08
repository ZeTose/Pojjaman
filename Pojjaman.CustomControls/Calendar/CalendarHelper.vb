Imports System
Imports System.Diagnostics
Imports System.Drawing
Imports System.Reflection
Imports System.Windows.Forms
Imports System.ComponentModel
Imports System.Globalization
Imports Syncfusion.Windows.Forms.Grid
Namespace Longkong.Pojjaman.Gui.Components
    Public Class DateRange

#Region "Members"
        Private m_startDate As Date
        Private m_endDate As Date
#End Region

#Region "Constructors"
        Public Sub New(ByVal startDate As Date, ByVal endDate As Date)
            CheckEndAndStart(startDate, endDate)
            Me.m_startDate = startDate
            Me.m_endDate = endDate
        End Sub
        Public Sub CheckEndAndStart(ByVal startDate As Date, ByVal endDate As Date)
            If Not startDate.Equals(Date.MinValue) AndAlso Not endDate.Equals(Date.MinValue) Then
                If endDate < startDate Then
                    Throw New InvalidOperationException("Start Date must be less than or equal to End Date:" & startDate.ToShortDateString & ":" & endDate.ToShortDateString)
                End If
            End If
        End Sub
#End Region

#Region "Properties"
        Public ReadOnly Property TimeSpan() As TimeSpan
            Get
                Return m_endDate.Subtract(m_startDate)
            End Get
        End Property
        Public Property StartDate() As Date            Get                Return m_startDate            End Get            Set(ByVal Value As Date)                CheckEndAndStart(Value, m_endDate)                m_startDate = Value            End Set        End Property        Public Property EndDate() As Date            Get                Return m_endDate            End Get            Set(ByVal Value As Date)                CheckEndAndStart(m_startDate, Value)                m_endDate = Value            End Set        End Property
        Public Function Intersects(ByVal other As DateRange) As Boolean
            If Not Me.StartDate.Equals(Date.MinValue) AndAlso Not Me.EndDate.Equals(Date.MinValue) Then
                If Not other.StartDate.Equals(Date.MinValue) AndAlso Not other.EndDate.Equals(Date.MinValue) Then
                    If other.EndDate < Me.StartDate Then
                        Return False
                    End If
                    If other.StartDate > Me.EndDate Then
                        Return False
                    End If
                    If Me.EndDate < other.StartDate Then
                        Return False
                    End If
                    If Me.StartDate > other.EndDate Then
                        Return False
                    End If
                End If
            End If
            Return True
        End Function
        Public Shadows Function Equals(ByVal other As DateRange) As Boolean
            If other Is Nothing Then
                Return False
            End If
            Return (Me.StartDate = other.StartDate) AndAlso (Me.EndDate = other.EndDate)
        End Function
        Public Function GetIntersection(ByVal other As DateRange) As DateRange
            If Not Intersects(other) Then
                Return Nothing
            End If
            Return New DateRange(GetLaterStartDate(other.StartDate), GetEarlierEndDate(other.EndDate))
        End Function
        Private Function GetLaterStartDate(ByVal other As Date) As Date
            If m_startDate > other Then
                Return m_startDate
            Else
                Return other
            End If
        End Function
        Private Function GetEarlierEndDate(ByVal other As Date) As Date
            If m_endDate.Equals(other) Then
                Return other
            End If
            If Not m_endDate.Equals(Date.MinValue) AndAlso other.Equals(Date.MinValue) Then
                Return m_endDate
            End If
            If m_endDate.Equals(Date.MinValue) AndAlso Not other.Equals(Date.MinValue) Then
                Return other
            End If
            If m_endDate > other Then
                Return other
            Else
                Return m_endDate
            End If
        End Function
#End Region

    End Class
    <Serializable(), DefaultMember("Item")> _
Public Class DateRangeCollection
        Inherits CollectionBase

#Region "Constructors"
        Public Sub New()
        End Sub
#End Region

#Region "Properties"
        Default Public Property Item(ByVal index As Integer) As DateRange
            Get
                Return CType(MyBase.List.Item(index), DateRange)
            End Get
            Set(ByVal value As DateRange)
                MyBase.List.Item(index) = value
            End Set
        End Property
#End Region

#Region "Class Methods"

#End Region

#Region "Collection Methods"
        Public Function Add(ByVal value As DateRange) As Integer
            Return MyBase.List.Add(value)
        End Function
        Public Sub AddRange(ByVal value As DateRangeCollection)
            For i As Integer = 0 To value.Count - 1
                Me.Add(value(i))
            Next
        End Sub
        Public Sub AddRange(ByVal value As DateRange())
            For i As Integer = 0 To value.Length - 1
                Me.Add(value(i))
            Next
        End Sub
        Public Function Contains(ByVal value As DateRange) As Boolean
            Return MyBase.List.Contains(value)
        End Function
        Public Sub CopyTo(ByVal array As DateRange(), ByVal index As Integer)
            MyBase.List.CopyTo(array, index)
        End Sub
        Public Shadows Function GetEnumerator() As DateRangeEnumerator
            Return New DateRangeEnumerator(Me)
        End Function
        Public Function IndexOf(ByVal value As DateRange) As Integer
            Return MyBase.List.IndexOf(value)
        End Function
        Public Sub Insert(ByVal index As Integer, ByVal value As DateRange)
            MyBase.List.Insert(index, value)
        End Sub
        Public Sub Remove(ByVal value As DateRange)
            MyBase.List.Remove(value)
        End Sub
        Public Sub Remove(ByVal index As Integer)
            MyBase.List.RemoveAt(index)
        End Sub
#End Region


        Public Class DateRangeEnumerator
            Implements IEnumerator

#Region "Members"
            Private m_baseEnumerator As IEnumerator
            Private m_temp As IEnumerable
#End Region

#Region "Construtor"
            Public Sub New(ByVal mappings As DateRangeCollection)
                Me.m_temp = mappings
                Me.m_baseEnumerator = Me.m_temp.GetEnumerator
            End Sub
#End Region

            Public ReadOnly Property Current() As Object Implements System.Collections.IEnumerator.Current
                Get
                    Return CType(Me.m_baseEnumerator.Current, DateRange)
                End Get
            End Property

            Public Function MoveNext() As Boolean Implements System.Collections.IEnumerator.MoveNext
                Return Me.m_baseEnumerator.MoveNext
            End Function

            Public Sub Reset() Implements System.Collections.IEnumerator.Reset
                Me.m_baseEnumerator.Reset()
            End Sub

        End Class
    End Class
    Public Class CalendarHelper
        Public Shared Function WriteCalendar(ByVal today As Date, ByVal grid As GridControl, Optional ByVal firstDayOfWeek As DayOfWeek = DayOfWeek.Sunday) As ArrayList
            grid.BeginUpdate()
            grid.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.SystemTheme
            grid.Model.Options.NumberedColHeaders = False
            grid.Model.Options.WrapCellBehavior = Syncfusion.Windows.Forms.Grid.GridWrapCellBehavior.WrapRow
            CreateHeader(grid, firstDayOfWeek)

            Dim arr As New ArrayList
            Dim daysInMonth As Integer = Date.DaysInMonth(today.Year, today.Month)
            Dim firstDate As New Date(today.Year, today.Month, 1)
            Dim x As Integer = DayNumber(firstDayOfWeek, firstDate.DayOfWeek)
            Dim weeks As Integer = CInt(Math.Ceiling((daysInMonth - (7 - x)) / 7)) + 1
            For week As Integer = 0 To weeks - 1
                grid.RowCount += 1
                'grid.RowHeights(grid.RowCount) = 34
                grid.RowStyles(grid.RowCount).VerticalAlignment = GridVerticalAlignment.Middle
                grid.RowStyles(grid.RowCount).ReadOnly = True
                For d As Integer = 0 To 6
                    Dim value As Integer
                    value = (d - x) + (7 * week) + 1
                    If value > 0 And value <= daysInMonth Then
                        arr.Add(grid(grid.RowCount, d + 1))
                        grid(grid.RowCount, d + 1).CellValue = value
                    End If
                Next
            Next
            grid.EndUpdate()
            Return arr
        End Function
        Private Shared Sub CreateHeader(ByVal grid As GridControl, Optional ByVal firstDayOfWeek As DayOfWeek = DayOfWeek.Sunday)
            grid.RowCount = 0
            grid.ColCount = 7
            grid.HideCols(0) = True
            Dim culture As String = "th-TH"
            For i As Integer = 0 To 6
                Dim day As Integer = GetDayFromDayNumber(firstDayOfWeek, i)
                Dim header As String = GetDay(day, culture)
                grid(0, i + 1).Text = header
                'grid.ColWidths(i + 1) = 100
                grid.ColStyles(i + 1).HorizontalAlignment = GridHorizontalAlignment.Center
            Next

        End Sub
        Public Shared Sub WriteCalendar(ByVal today As Date, ByVal dt As TreeTable, Optional ByVal firstDayOfWeek As DayOfWeek = DayOfWeek.Sunday)
            dt.Clear()
            Dim daysInMonth As Integer = Date.DaysInMonth(today.Year, today.Month)
            Dim firstDate As New Date(today.Year, today.Month, 1)
            Dim x As Integer = DayNumber(firstDayOfWeek, firstDate.DayOfWeek)
            Dim weeks As Integer = CInt(Math.Ceiling((daysInMonth - (7 - x)) / 7)) + 1
            For week As Integer = 0 To weeks - 1
                Dim row As TreeRow = dt.Childs.Add
                For d As Integer = 0 To 6
                    Dim value As Integer
                    value = (d - x) + (7 * week) + 1
                    If value > 0 And value <= daysInMonth Then
                        row(d) = value
                    End If
                Next
            Next
        End Sub
        Private Shared Function DayNumber(ByVal firstDayOfWeek As DayOfWeek, ByVal day As DayOfWeek) As Integer
            Dim ret As Integer = 7 + (day - firstDayOfWeek)
            Return ret Mod 7
        End Function
        Private Shared Function GetDayFromDayNumber(ByVal firstDayOfWeek As DayOfWeek, ByVal dayNum As Integer) As Integer
            Dim ret As Integer = (firstDayOfWeek + dayNum) Mod 7
            Return ret
        End Function
        Public Shared Function GetSchemaTable() As TreeTable
            Dim myDatatable As New TreeTable("Calendar")
            ' Get from StockItem ...
            For i As Integer = 0 To 6
                myDatatable.Columns.Add(New DataColumn(i.ToString, GetType(String)))
            Next
            Return myDatatable
        End Function
        Public Shared Function CreateTableStyle(ByVal firstDayOfWeek As DayOfWeek, Optional ByVal culture As String = "th-TH") As DataGridTableStyle
            Dim dst As New DataGridTableStyle
            dst.MappingName = "Calendar"
            For i As Integer = 0 To 6
                Dim day As Integer = GetDayFromDayNumber(firstDayOfWeek, i)
                Dim header As String = GetDay(day, culture)
                Dim csDay As New TreeTextColumn
                csDay.MappingName = i.ToString
                csDay.HeaderText = header
                csDay.NullText = ""
                csDay.Width = 100
                csDay.Alignment = HorizontalAlignment.Center
                csDay.DataAlignment = HorizontalAlignment.Left
                csDay.ReadOnly = False
                dst.GridColumnStyles.Add(csDay)
            Next
            Return dst
        End Function
        Private Shared Function GetDay(ByVal day As Integer, Optional ByVal culture As String = "th-TH") As String
            Dim ret As String = ""
            Dim anyCulture As New CultureInfo(culture)
            Dim arr As New ArrayList
            Dim fldInfos As FieldInfo() = GetType(DayOfWeek).GetFields
            Dim x As Integer = 0
            For Each fnfo As FieldInfo In fldInfos
                If fnfo.IsLiteral Then
                    If x = day Then
                        ret = anyCulture.DateTimeFormat.GetAbbreviatedDayName(CType(fnfo.GetValue(Nothing), DayOfWeek))
                        Exit For
                    End If
                    x += 1
                End If
            Next
            Return ret
        End Function
    End Class
End Namespace

