Imports System
Imports System.Drawing
Imports System.Collections
Imports System.Drawing.Imaging
Imports System.Drawing.Drawing2D
Imports Microsoft.VisualBasic

Namespace Longkong.Reporting.Printing
    Public Delegate Sub UpdateMathHandler(ByVal sender As Object, ByVal e As UpdateMathEventArgs)

    Public Class UpdateMathEventArgs

#Region "Members"
        Private m_count As Double
        Private m_dataRowView As DataRowView
        Private m_originalValue As Object
        Private m_stringRepresentation As String
        Private m_sum As Double
#End Region

#Region "Constructor"
        Public Sub New(ByVal drv As DataRowView, ByVal obj As Object, ByVal str As String)
            Me.m_originalValue = obj
            Me.m_dataRowView = drv
            Me.m_stringRepresentation = str
        End Sub
#End Region

#Region "Properties"
        Public Property Count() As Double
            Get
                Return Me.m_count
            End Get
            Set(ByVal value As Double)
                Me.m_count = value
            End Set
        End Property
        Public ReadOnly Property DataRowView() As DataRowView
            Get
                Return Me.m_dataRowView
            End Get
        End Property
        Public ReadOnly Property OriginalValue() As Object
            Get
                Return Me.m_originalValue
            End Get
        End Property
        Public ReadOnly Property StringRepresentation() As String
            Get
                Return Me.m_stringRepresentation
            End Get
        End Property
        Public Property Sum() As Double
            Get
                Return Me.m_sum
            End Get
            Set(ByVal value As Double)
                Me.m_sum = value
            End Set
        End Property
#End Region

    End Class
End Namespace