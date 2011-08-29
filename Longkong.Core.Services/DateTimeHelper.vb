Imports System.Globalization
Imports System.Reflection
Imports System.Windows.Forms
Namespace Longkong.Core.Services
  Public Class IdValuePair
    Implements IComparable
    Private m_id As Integer
    Private m_value As String

#Region "Constructors"
    Public Sub New(ByVal _id As Integer, ByVal _value As String)
      m_id = _id
      m_value = _value
    End Sub
#End Region

#Region "Properties"
    Public Property Id() As Integer      Get        Return m_id      End Get      Set(ByVal Value As Integer)        m_id = Value      End Set    End Property    Public Property Value() As String      Get        Dim myService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
        Return myService.Parse(m_value)      End Get      Set(ByVal Value As String)        m_value = Value      End Set    End Property
#End Region

#Region "Methods"
    Public Function IdValueString() As String
      Return Me.Id.ToString & ":" & Me.Value
    End Function
    Public Overrides Function ToString() As String
      Return Me.Value
    End Function
#End Region

    Public Function CompareTo(ByVal obj As Object) As Integer Implements System.IComparable.CompareTo
      Dim other As IdValuePair = CType(obj, IdValuePair)
      If other Is Nothing Then
        Return -1
      End If
      If other.Id = Me.Id And other.Value = Me.Value Then
        Return 0
      End If
    End Function
  End Class
  Public Class KeyValuePair
    Implements IComparable
    Private m_key As String
    Private m_value As String

#Region "Constructors"
    Public Sub New(ByVal _key As String, ByVal _value As String)
      m_key = _key
      m_value = _value
    End Sub
#End Region

#Region "Properties"
    Public Property Key() As String      Get        Return m_key      End Get      Set(ByVal Value As String)        m_key = Value      End Set    End Property    Public Property Value() As String      Get        Return m_value      End Get      Set(ByVal Value As String)        m_value = Value      End Set    End Property
#End Region

#Region "Methods"
    Public Function KeyValueString() As String
      Return Me.Key & ":" & Me.Value
    End Function
    Public Overrides Function ToString() As String
      Return Me.Key
    End Function
#End Region

    Public Function CompareTo(ByVal obj As Object) As Integer Implements System.IComparable.CompareTo
      Dim other As KeyValuePair = CType(obj, KeyValuePair)
      If other Is Nothing Then
        Return -1
      End If
      If other.Key = Me.Key And other.Value = Me.Value Then
        Return 0
      End If
    End Function
  End Class
  Public Class DateTimeService
    Inherits AbstractService
    Public Shared Function GetDays(ByVal abb As Boolean, Optional ByVal culture As String = "th-TH") As ArrayList
      Dim anyCulture As New CultureInfo(culture)
      Dim arr As New ArrayList
      Dim fldInfos As FieldInfo() = GetType(DayOfWeek).GetFields
      Dim i As Integer = 0
      For Each fnfo As FieldInfo In fldInfos
        If fnfo.IsLiteral Then
          If abb Then
            arr.Add(New IdValuePair(i, anyCulture.DateTimeFormat.GetAbbreviatedDayName(CType(fnfo.GetValue(Nothing), DayOfWeek))))
          Else
            arr.Add(New IdValuePair(i, anyCulture.DateTimeFormat.GetDayName(CType(fnfo.GetValue(Nothing), DayOfWeek))))
          End If
          i += 1
        End If
      Next
      Return arr
    End Function
    Public Shared Function GetDayStrings(ByVal list As String, ByVal abb As Boolean, Optional ByVal culture As String = "th-TH") As String
      If list Is Nothing Then
        Return ""
      End If
      Dim anyCulture As New CultureInfo(culture)
      Dim arr As New ArrayList
      Dim fldInfos As FieldInfo() = GetType(DayOfWeek).GetFields
      Dim items As String() = list.Split(","c)
      ' Huaneng : แก้กรณี items(x)= "" ทำให้ convert to integer Error
      For i As Integer = 0 To items.Length - 1
        If items(i).Length = 0 Then items(i) = Nothing
      Next

      Dim result As String = ""
      Dim days As ArrayList = GetDays(abb, culture)
      Dim offset As Integer = 0
      For Each item As Integer In items
        For i As Integer = offset To days.Count - 1
          If item = i Then
            result &= days(i).ToString & ","
            offset = i + 1
            Exit For
          End If
        Next
      Next
      If result.Length = 0 Then
        Return result
      End If

      Return result.TrimEnd(","c)
    End Function
    Public Function GetMonths(ByVal abb As Boolean, Optional ByVal culture As String = "th-TH") As ArrayList
      Dim arr As New ArrayList
      Dim anyCulture As New CultureInfo(culture)
      For i As Integer = 1 To 12
        If abb Then
          arr.Add(anyCulture.DateTimeFormat.GetAbbreviatedMonthName(i))
        Else
          arr.Add(anyCulture.DateTimeFormat.GetMonthName(i))
        End If
      Next
      Return arr
    End Function
    Public Shared Sub ListDaysInComboBox(ByVal cmb As ComboBox, ByVal abb As Boolean, Optional ByVal culture As String = "th-TH", Optional ByVal hasBlankDay As Boolean = True)
      Dim arr As ArrayList = GetDays(abb, culture)
      If hasBlankDay Then
        arr.Insert(0, New IdValuePair(-1, ""))
      End If
      cmb.DataSource = arr
      cmb.DisplayMember = "Value"
      cmb.ValueMember = "Id"
    End Sub
    Public Shared Sub ListMonthsInComboBox(ByVal cmb As ComboBox, ByVal abb As Boolean, Optional ByVal culture As String = "th-TH", Optional ByVal hasBlankMonth As Boolean = True)
      cmb.Items.Clear()
      Dim anyCulture As New CultureInfo(culture)
      If hasBlankMonth Then
        cmb.Items.Insert(0, New IdValuePair(-1, ""))
      End If
      For i As Integer = 1 To 12
        If abb Then
          cmb.Items.Add(anyCulture.DateTimeFormat.GetAbbreviatedMonthName(i))
        Else
          cmb.Items.Add(anyCulture.DateTimeFormat.GetMonthName(i))
        End If
      Next
    End Sub
    Public Shared Sub ListMonthsInComboBoxWithIdValue(ByVal cmb As ComboBox, ByVal abb As Boolean, Optional ByVal culture As String = "th-TH", Optional ByVal hasBlankMonth As Boolean = True)
      cmb.Items.Clear()
      Dim anyCulture As New CultureInfo(culture)
      If hasBlankMonth Then
        cmb.Items.Insert(0, New IdValuePair(-1, ""))
      End If
      For i As Integer = 1 To 12
        If abb Then
          Dim newIdV As New IdValuePair(i, anyCulture.DateTimeFormat.GetAbbreviatedMonthName(i))
          cmb.Items.Add(newIdV)
        Else
          Dim newIdV As New IdValuePair(i, anyCulture.DateTimeFormat.GetMonthName(i))
          cmb.Items.Add(newIdV)
        End If
      Next
    End Sub
    Public Shared Sub ListYearsInComboBox(ByVal cmb As ComboBox, ByVal years As Date())
      cmb.Items.Clear()
      Dim arr As New ArrayList
      For i As Integer = 0 To years.Length - 1
        Dim myItem As New ValueDisplayPair(years(i), DatePart(DateInterval.Year, years(i)))
        arr.Add(myItem)
      Next
      cmb.DataSource = arr
      cmb.DisplayMember = "Display"
      cmb.ValueMember = "Value"
    End Sub
    Public Shared Function ConvertToString(ByVal val As Date) As String
      Return DatePart(DateInterval.Year, val) & "-" & DatePart(DateInterval.Month, val) & "-" & DatePart(DateInterval.Day, val)
    End Function
  End Class
  Public Class ValueDisplayPair

#Region "Members"
    Private m_value As Object
    Private m_display As Object
#End Region

#Region "Constructors"
    Public Sub New(ByVal _value As Object, ByVal _display As Object)
      m_display = _display
      m_value = _value
    End Sub
#End Region

#Region "Properties"
    Public Property Value() As Object      Get        Return m_value      End Get      Set(ByVal Value As Object)        m_value = Value      End Set    End Property    Public Property Display() As Object      Get        Return m_display      End Get      Set(ByVal Value As Object)        m_display = Value      End Set    End Property
#End Region

#Region "Methods"

#End Region

  End Class
End Namespace

