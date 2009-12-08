Imports System
Imports System.Drawing
Imports System.Collections
Imports System.Drawing.Imaging
Imports System.Drawing.Drawing2D
Imports Microsoft.VisualBasic

Namespace Longkong.Reporting.Printing
    Public Class ReportBuilderException
        Inherits ApplicationException

#Region "Constructors"
        Public Sub New(ByVal msg As String)
            MyBase.New(msg)
        End Sub
        Public Sub New(ByVal msg As String, ByVal innerException As Exception)
            MyBase.New(msg, innerException)
        End Sub
#End Region

End Class



End Namespace