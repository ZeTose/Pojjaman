Namespace Longkong.Pojjaman.DataTransfer

    Public Class HiResTimer

        Private Structure LARGE_INTEGER
            Public lowpart As Integer
            Public highpart As Integer
        End Structure

        Private Declare Function QueryPerformanceCounter Lib "kernel32.dll" Alias "QueryPerformanceCounter" (ByRef lpPerformanceCount As LARGE_INTEGER) As Integer
        Private Declare Function QueryPerformanceFrequency Lib "kernel32.dll" Alias "QueryPerformanceFrequency" (ByRef lpFrequency As LARGE_INTEGER) As Integer

        Private period As Double = 0
        Private startTime As Double = 0
        Private timerFrequency As Double = 0
        Private bhasHiResCounter As Boolean = False

        Public Sub StartTimer()
            Dim res As LARGE_INTEGER = New LARGE_INTEGER
            Dim lR As Long = QueryPerformanceCounter(res)
            startTime = res.lowpart
            startTime += res.highpart * &H100000000
        End Sub

        Public Sub StopTimer()
            Dim res As LARGE_INTEGER = New LARGE_INTEGER
            Dim lR As Long = QueryPerformanceCounter(res)
            Dim endTime As Double = res.lowpart
            endTime += res.highpart * &H100000000
            period = endTime - startTime
        End Sub

        Public ReadOnly Property ElapsedTime() As Double
            Get
                Return period / timerFrequency
            End Get
        End Property

        Public ReadOnly Property HasHiResCounter() As Boolean
            Get
                Return bhasHiResCounter
            End Get
        End Property

        Public ReadOnly Property Frequency() As Double
            Get
                Return timerFrequency
            End Get
        End Property

        Public Sub New()
            ' If the installed hardware supports a high-resolution performance counter, 
            ' the return value is nonzero.
            ' If the function fails, the return value is zero. To get extended error 
            ' information, call GetLastError. For example, if the installed hardware 
            ' does not support a high-resolution performance counter, the function fails. 
            Dim res As LARGE_INTEGER = New LARGE_INTEGER
            Dim r As Long = QueryPerformanceFrequency(res)
            If (r <> 0) Then
                bhasHiResCounter = True
                timerFrequency = res.lowpart
                timerFrequency += res.highpart * &H100000000
            End If
        End Sub


    End Class
End Namespace