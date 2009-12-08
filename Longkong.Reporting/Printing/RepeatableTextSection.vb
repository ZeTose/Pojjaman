Imports System
Imports System.Drawing
Imports System.Collections
Imports System.Drawing.Imaging
Imports System.Drawing.Drawing2D
Imports Microsoft.VisualBasic

Namespace Longkong.Reporting.Printing
    Public Class RepeatableTextSection
        Inherits SectionText

#Region "Members"
        Public TextEvenPage As String
        Public TextFirstPage As String
        Public TextOddPage As String
#End Region

#Region "Constructors"
        Public Sub New(ByVal [text] As String, ByVal textStyle As TextStyle)
            MyBase.New(text, textStyle)
        End Sub
#End Region

#Region "Methods"
        Protected Overrides Function GetText(ByVal reportDocument As ReportDocument) As String
            Dim text1 As String
            Dim num1 As Integer = reportDocument.GetCurrentPage
            If (num1 = 1) Then
                text1 = Me.TextFirstPage
            Else
                If ((num1 Mod 2) = 0) Then
                    text1 = Me.TextEvenPage
                Else
                    text1 = Me.TextOddPage
                End If
            End If
            If (text1 Is Nothing) Then
                If (MyBase.Text Is Nothing) Then
                    text1 = String.Empty
                Else
                    text1 = MyBase.Text
                End If
            End If
            Return text1.Replace("%p", num1.ToString)
        End Function
#End Region
    End Class
End Namespace