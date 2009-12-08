Imports System
Imports System.Drawing
Imports System.Collections
Imports System.Drawing.Imaging
Imports System.Drawing.Drawing2D
Imports Microsoft.VisualBasic

Namespace Longkong.Reporting.Printing
    Public MustInherit Class SectionContainer
        Inherits ReportSection

#Region "Members"
        Protected m_sectionIndex As Integer
        Protected m_sections As ArrayList
#End Region

#Region "Constructors"
        Public Sub New()
            Me.m_sections = New ArrayList
        End Sub
#End Region

#Region "Properties"
        Protected ReadOnly Property CurrentSection() As ReportSection
            Get
                If (Me.m_sectionIndex < Me.m_sections.Count) Then
                    Return CType(Me.m_sections(Me.m_sectionIndex), ReportSection)
                End If
                Return Nothing
            End Get
        End Property
        Public Overridable ReadOnly Property SectionCount() As Integer
            Get
                Return Me.m_sections.Count
            End Get
        End Property
#End Region

#Region "Methods"
        Public Overridable Function AddSection(ByVal section As ReportSection) As Integer
            Return Me.m_sections.Add(section)
        End Function
        Public Overridable Sub ClearSections()
            Me.m_sections.Clear()
        End Sub
        Public Overridable Function GetSection(ByVal index As Integer) As ReportSection
            Return CType(Me.m_sections(index), ReportSection)
        End Function
        Public Overridable Sub RemoveSection(ByVal index As Integer)
            Me.m_sections.RemoveAt(index)
        End Sub
        Public Overrides Sub Reset()
            MyBase.Reset()
            For Each section As ReportSection In Me.m_sections
                section.Reset()
            Next
        End Sub
        Public Overrides Sub ResetSize()
            MyBase.ResetSize()
            If (Not Me.CurrentSection Is Nothing) Then
                Me.CurrentSection.ResetSize()
            End If
        End Sub
#End Region


    End Class
End Namespace