Imports System
Imports System.Drawing
Imports System.Collections
Imports System.Drawing.Imaging
Imports System.Drawing.Drawing2D
Imports Microsoft.VisualBasic
Imports System.Runtime.InteropServices
Namespace Longkong.Reporting.Printing
    Friend Class PrinterMarginInfo

#Region "Members"
        Private hardBottomMargin As Single
        Private hardLeftMargin As Single
        Private hardRightMargin As Single
        Private hardTopMargin As Single
        Private Const HORZRES As Short = 8
        Private Const HORZSIZE As Short = 4
        Private Const PHYSICALOFFSETX As Short = 112
        Private Const PHYSICALOFFSETY As Short = 113
        Private Const VERTRES As Short = 10
        Private Const VERTSIZE As Short = 6
#End Region

#Region "Constructors"
        Public Sub New(ByVal deviceHandle As Integer)
            Me.hardLeftMargin = 0.0!
            Me.hardTopMargin = 0.0!
            Me.hardRightMargin = 0.0!
            Me.hardBottomMargin = 0.0!
            Dim single1 As Single = Convert.ToSingle(PrinterMarginInfo.GetDeviceCaps(deviceHandle, 112))
            Dim single2 As Single = Convert.ToSingle(PrinterMarginInfo.GetDeviceCaps(deviceHandle, 113))
            Dim single3 As Single = Convert.ToSingle(PrinterMarginInfo.GetDeviceCaps(deviceHandle, 8))
            Dim single4 As Single = Convert.ToSingle(PrinterMarginInfo.GetDeviceCaps(deviceHandle, 10))
            Dim single5 As Single = (Convert.ToSingle(PrinterMarginInfo.GetDeviceCaps(deviceHandle, 4)) / 25.4!)
            Dim single6 As Single = (Convert.ToSingle(PrinterMarginInfo.GetDeviceCaps(deviceHandle, 6)) / 25.4!)
            Dim single7 As Single = (single3 / single5)
            Dim single8 As Single = (single4 / single6)
            Me.hardLeftMargin = ((single1 / single7) * 100.0!)
            Me.hardTopMargin = ((single2 / single7) * 100.0!)
            Me.hardBottomMargin = (Me.hardTopMargin + (single6 * 100.0!))
            Me.hardRightMargin = (Me.hardLeftMargin + (single5 * 100.0!))
        End Sub
#End Region

#Region "Methods"
        Public Function GetBounds(ByVal pageRectangle As Rectangle, ByVal desiredMargins As Rectangle, ByVal scale As Single) As Bounds
            Dim bounds1 As Bounds
            Dim single1 As Single = (desiredMargins.Left - Me.hardLeftMargin)
            Dim single2 As Single = (desiredMargins.Top - Me.hardTopMargin)
            Dim single3 As Single = (desiredMargins.Right - Me.hardLeftMargin)
            Dim single4 As Single = (desiredMargins.Bottom - Me.hardTopMargin)
            single1 = (single1 * scale)
            single2 = (single2 * scale)
            single3 = (single3 * scale)
            single4 = (single4 * scale)
            bounds1 = New Bounds(single1, single2, single3, single4)
            Return bounds1
        End Function
        <DllImport("gdi32.dll")> _
        Private Shared Function GetDeviceCaps(<MarshalAs(UnmanagedType.U4)> ByVal hDc As Integer, <MarshalAs(UnmanagedType.U2)> ByVal funct As Short) As Short
        End Function
#End Region

    End Class
End Namespace