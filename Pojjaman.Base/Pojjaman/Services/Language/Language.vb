Imports System
Imports System.IO
Imports System.Windows.Forms
Imports System.Collections
Imports System.Threading
Imports System.Resources
Imports System.Drawing
Imports System.Diagnostics
Imports System.Reflection
Imports System.Xml
Imports System.Configuration
Imports System.Globalization
Imports Longkong.Core.Properties
Imports Longkong.Core.Services
Namespace Longkong.Pojjaman.Services
    Public Class Language
        Inherits AbstractService

#Region "Members"
        Private m_code As String
        Private m_imageIndex As Integer
        Private m_name As String
#End Region

#Region "Costructors"
        Public Sub New(ByVal name As String, ByVal code As String, ByVal imageIndex As Integer)
            Me.m_name = name
            Me.m_code = code
            Me.m_imageIndex = imageIndex
        End Sub
#End Region

#Region "Properties"
        Public ReadOnly Property Code() As String
            Get
                Return Me.m_code
            End Get
        End Property
        Public ReadOnly Property ImageIndex() As Integer
            Get
                Return Me.m_imageIndex
            End Get
        End Property
        Public ReadOnly Property Name() As String
            Get
                Return Me.m_name
            End Get
        End Property
#End Region

    End Class
End Namespace

