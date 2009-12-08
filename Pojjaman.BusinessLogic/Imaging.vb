Imports System.Drawing.Imaging
Imports System.Drawing.Drawing2D
Imports System.IO
Namespace Longkong.Pojjaman.Graphix
    Public Class Imaging
#Region "Convert Image To Byte Array"
        Public Shared Function ConvertImageToByteArray(ByVal myImage As System.Drawing.Image) As Byte()
            If IsNothing(myImage) Then
                Return Nothing
            End If
            Dim Ret As Byte()
            Try
                Dim oStream As New MemoryStream
                myImage.Save(oStream, ImageFormat.Jpeg)
                Ret = oStream.ToArray()
                oStream.Close()
            Catch e As Exception
                Throw e
            End Try
            Return Ret
        End Function
#End Region

#Region "Convert Byte Array To Image "
        Public Shared Function ConvertByteArrayToImage(ByVal ImageArray As Byte()) As System.Drawing.Image
            If IsNothing(ImageArray) Then
                Return Nothing
            End If
            Dim Ret As System.Drawing.Image
            Try
                Dim oStream As New MemoryStream(ImageArray, 0, ImageArray.Length)
                oStream.Write(ImageArray, 0, ImageArray.Length)
                Ret = Image.FromStream(oStream, True)
                oStream.Close()
            Catch e As Exception
                Throw e
            End Try
            Return Ret
        End Function
#End Region

    End Class
End Namespace

