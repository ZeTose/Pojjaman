Imports System
Imports System.Drawing
Imports System.Collections
Imports System.Drawing.Imaging
Imports System.Drawing.Drawing2D
Imports Microsoft.VisualBasic

Namespace Longkong.Reporting.Printing
    Public Delegate Sub FormatSummaryRowHandler(ByVal sender As Object, ByVal e As FormatSummaryRowEventArgs)

    Public Class FormatSummaryRowEventArgs
        Inherits EventArgs

#Region "Members"
        Private m_field As String
        Private m_stringValue As String
#End Region

#Region "Constructors"
        Public Sub New()
        End Sub
#End Region

#Region "Properties"
        Public Property Field() As String            Get                Return m_field            End Get            Set(ByVal Value As String)                m_field = Value            End Set        End Property        Public Property StringValue() As String            Get                Return m_stringValue            End Get            Set(ByVal Value As String)                m_stringValue = Value            End Set        End Property
#End Region

    End Class
End Namespace