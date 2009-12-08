Imports System
Imports System.Drawing
Imports System.Collections
Imports System.Drawing.Imaging
Imports System.Drawing.Drawing2D
Imports Microsoft.VisualBasic

Namespace Longkong.Reporting.Printing
    Public Class LayeredSections
        Inherits SectionContainer

#Region "Constructors"
        Public Sub New(ByVal useFullWidth As Boolean, ByVal useFullHeight As Boolean)
            Me.UseFullWidth = useFullWidth
            Me.UseFullHeight = useFullHeight
        End Sub
#End Region

#Region "Methods"
        Protected Overrides Sub DoBeginPrint(ByVal g As System.Drawing.Graphics)

        End Sub
        Protected Overrides Function DoCalcSize(ByVal reportDocument As ReportDocument, ByVal g As Graphics, ByVal bounds As Bounds) As SectionSizeValues
            Dim values1 As SectionSizeValues
            values1 = New SectionSizeValues
            If (Me.m_sections.Count = 0) Then
                values1.Fits = True
                Return values1
            End If
            Dim section1 As ReportSection
            For Each section1 In Me.m_sections
                section1.CalcSize(reportDocument, g, bounds)
                values1.RequiredSize.Height = Math.Max(values1.RequiredSize.Height, section1.Size.Height)
                values1.RequiredSize.Width = Math.Max(values1.RequiredSize.Width, section1.Size.Width)
                If section1.Continued Then
                    values1.Continued = True
                End If
                If section1.Fits Then
                    values1.Fits = True
                End If
            Next
            Return values1
        End Function
        Protected Overrides Sub DoPrint(ByVal reportDocument As ReportDocument, ByVal g As Graphics, ByVal bounds As Bounds)
            If Not Me.UseFullHeight Then
                bounds.Limit.Y = (bounds.Position.Y + MyBase.RequiredSize.Height)
            End If
            If Not Me.UseFullWidth Then
                bounds.Limit.X = (bounds.Position.X + MyBase.RequiredSize.Width)
            End If
            Dim section1 As ReportSection
            For Each section1 In Me.m_sections
                section1.Print(reportDocument, g, bounds)
                If section1.Continued Then
                    MyBase.SetContinued(True)
                End If
            Next
        End Sub
#End Region

    End Class
End Namespace