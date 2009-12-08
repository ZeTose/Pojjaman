Imports System
Imports System.Drawing
Imports System.Collections
Imports System.Drawing.Imaging
Imports System.Drawing.Drawing2D
Imports Microsoft.VisualBasic

Namespace Longkong.Reporting.Printing
    Public Delegate Sub FormatColumnHandler(ByVal sender As Object, ByVal e As FormatColumnEventArgs)
    Public Class FormatColumnEventArgs
        Inherits EventArgs

#Region "Members"
        Private m_originalValue As Object
        Private m_stringValue As String
#End Region

#Region "Constructors"
        Public Sub New()
        End Sub
#End Region

#Region "Properties"
        Public Property OriginalValue() As Object            Get                Return m_originalValue            End Get            Set(ByVal Value As Object)                m_originalValue = Value            End Set        End Property        Public Property StringValue() As String            Get                Return m_stringValue            End Get            Set(ByVal Value As String)                m_stringValue = Value            End Set        End Property
#End Region

    End Class
End Namespace