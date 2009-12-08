Imports System
Imports System.Drawing
Imports System.Runtime.InteropServices
Imports System.Convert
Namespace Longkong.Pojjaman.Gui.Components
    Public NotInheritable Class ScreenImage

        Private Declare Function BitBlt Lib "gdi32.dll" Alias "BitBlt" (ByVal handlerToDestinationDeviceContext As IntPtr, _
         ByVal x As Integer, ByVal y As Integer, ByVal nWidth As Integer, _
         ByVal nHeight As Integer, ByVal handlerToSourceDeviceContext As IntPtr, _
         ByVal xSrc As Integer, ByVal ySrc As Integer, ByVal opCode As Integer) As Boolean


        Private Declare Function GetWindowDC Lib "user32.dll" Alias "GetWindowDC" (ByVal windowHandle As IntPtr) As IntPtr

        Private Declare Function ReleaseDC Lib "user32.dll" Alias "ReleaseDC" (ByVal windowHandle As IntPtr, ByVal dc As IntPtr) As Integer

        ' Private Shared SRCCOPY As Integer = &HCC0020
        Private Shared SRCCOPY As Integer = 13369376


        Public Function GetScreenshot(ByVal windowHandle As IntPtr, ByVal location As Point, ByVal size As Size) As Image

            Dim myImage As Image = New Bitmap(size.Width, size.Height)
            Dim g As Graphics = Graphics.FromImage(myImage)

            Dim destDeviceContext As IntPtr = g.GetHdc()
            Dim srcDeviceContext As IntPtr = GetWindowDC(windowHandle)

            BitBlt(destDeviceContext, 0, 0, size.Width, size.Height, srcDeviceContext, location.X, location.Y, SRCCOPY)
            ReleaseDC(windowHandle, srcDeviceContext)
            g.ReleaseHdc(destDeviceContext)

            g.Dispose()

            Return myImage

        End Function

    End Class
End Namespace