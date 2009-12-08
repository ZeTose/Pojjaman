Imports System
Imports System.Drawing
Imports System.Collections
Imports System.Drawing.Imaging
Imports System.Drawing.Drawing2D
Imports Microsoft.VisualBasic

Namespace Longkong.Reporting.Printing
    Public Class ReportBoolColumn
        Inherits ReportImageColumn

#Region "Members"
        Private Const DefaultTrueImageName As String = "check3.png"
        Public FalseImage As Image
        Public TrueImage As Image
#End Region

#Region "Constructors"
        Public Sub New(ByVal field As String, ByVal maxWidth As Single)
            MyBase.New(field, maxWidth)
            Dim bitmap1 As New Bitmap(MyBase.GetType, "check3.png")
            bitmap1.MakeTransparent()
            Me.TrueImage = bitmap1
        End Sub
#End Region

#Region "Mthods"
        Protected Overrides Function GetImage(ByVal drv As DataRowView) As Image
            If CType(drv.Item(MyBase.Field), Boolean) Then
                Return Me.TrueImage
            End If
            Return Me.FalseImage
        End Function
#End Region

    End Class
End Namespace