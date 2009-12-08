Imports System
Imports System.Drawing
Imports System.Collections
Imports System.Drawing.Imaging
Imports System.Drawing.Drawing2D
Imports Microsoft.VisualBasic

Namespace Longkong.Reporting.Printing
    Public Enum PageOrientation
        ' Fields
        Landscape = 1
        Portrait = 0
    End Enum

    Public Class SectionBreak
        Inherits ReportSection

#Region "Members"
        Private m_firstTimeCalled As Boolean
        Private m_newPageOrientation As PageOrientation
        Private m_pageBreak As Boolean
        Private m_pageNumber As Integer
        Private m_setOrientation As Boolean
#End Region

#Region "Constructors"
        Public Sub New(ByVal pageBreak As Boolean)
            Me.m_setOrientation = False
            Me.PageBreak = pageBreak
        End Sub
        Public Sub New()
            Me.New(True)
            Me.m_requiresNonEmptyBounds = False
        End Sub
#End Region

#Region "Properties"
        Public WriteOnly Property NewPageOrientation() As PageOrientation
            Set(ByVal value As PageOrientation)
                Me.m_setOrientation = True
                Me.m_newPageOrientation = value
            End Set
        End Property
        Public Property PageBreak() As Boolean
            Get
                Return Me.m_pageBreak
            End Get
            Set(ByVal value As Boolean)
                Me.m_pageBreak = value
            End Set
        End Property
#End Region

#Region "Methods"
        Protected Overrides Function BoundsChanged(ByVal originalBounds As Bounds, ByVal newBounds As Bounds) As SectionSizeValues
            Me.ResetSize()
            Return MyBase.BoundsChanged(originalBounds, newBounds)
        End Function
        Protected Overrides Sub DoBeginPrint(ByVal g As Graphics)
            Me.m_firstTimeCalled = True
        End Sub
        Protected Overrides Function DoCalcSize(ByVal reportDocument As ReportDocument, ByVal g As Graphics, ByVal bounds As Bounds) As SectionSizeValues
            Dim values1 As SectionSizeValues
            values1 = New SectionSizeValues
            values1.Fits = True
            Dim num1 As Integer = reportDocument.GetCurrentPage
            If Me.m_firstTimeCalled Then
                Me.m_pageNumber = num1
                values1.Continued = Me.m_pageBreak
                values1.RequiredSize = bounds.GetSizeF
                Me.m_firstTimeCalled = False
                If Me.m_setOrientation Then
                    reportDocument.SetPageOrientation((num1 + 1), Me.m_newPageOrientation)
                End If
                Return values1
            End If
            If (Me.m_pageBreak AndAlso (num1 = Me.m_pageNumber)) Then
                values1.Continued = True
                values1.RequiredSize = bounds.GetSizeF
                Return values1
            End If
            values1.Continued = False
            values1.RequiredSize = New SizeF(0.0!, 0.0!)
            Return values1
        End Function
        Protected Overrides Sub DoPrint(ByVal reportDocument As ReportDocument, ByVal g As Graphics, ByVal bounds As Bounds)
        End Sub
#End Region

    End Class
End Namespace