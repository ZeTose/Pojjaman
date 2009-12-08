Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.Configuration
Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.Services
Imports System.IO
Namespace Longkong.Pojjaman.Gui.Components
    Public Class ImageHelper
        Public Shared Function Resize(ByVal picSource As Image, ByVal percent As Decimal) As Image
            ' Get the source bitmap.
            Dim bm_source As New Bitmap(picSource)

            ' Make a bitmap for the result.
            Dim bm_dest As New Bitmap( _
                CInt(bm_source.Width * percent / 100), _
                CInt(bm_source.Height * percent / 100))

            ' Make a Graphics object for the result Bitmap.
            Dim gr_dest As Graphics = Graphics.FromImage(bm_dest)

            ' Copy the source image into the destination bitmap.
            gr_dest.DrawImage(bm_source, 0, 0, _
                bm_dest.Width + 1, _
                bm_dest.Height + 1)
            Return bm_dest
        End Function
        Public Shared Function ResizeToFileSize(ByVal sourceFile As String, ByVal fileSize As Long) As Image
            Dim picSource As Image = Image.FromFile(sourceFile)

            Dim bm_source As New Bitmap(picSource)

            Dim tmp As String = Path.GetTempFileName
            bm_source.Save(tmp)

            Dim retSize As Long = (New FileInfo(tmp)).Length

            If retSize <= fileSize Then
                Return picSource
            End If

            Dim ret As Image = picSource
            'While retSize > fileSize
            '    ret = Resize1(ret, (fileSize / retSize) * 100)
            '    Dim tmp As String = Path.GetTempFileName
            '    ret.Save(tmp)
            '    retSize = (New FileInfo(tmp)).Length
            'End While
            Dim percent As Decimal = CDec(Math.Sqrt(fileSize * 0.88) / Math.Sqrt(retSize))
            ret = Resize(ret, (percent) * 100)
            Return ret

        End Function
    End Class

End Namespace
