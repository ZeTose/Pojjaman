Imports System
Imports System.Drawing
Imports System.Collections
Imports System.Drawing.Imaging
Imports System.Drawing.Drawing2D
Imports Microsoft.VisualBasic

Namespace Longkong.Reporting.Printing
    Public Class LinearRepeatableSections
        Inherits LinearSections

#Region "Members"
        Private m_divider As ReportSection
        Private m_showDividerFirst As Boolean
#End Region

#Region "Constructors"
        Public Sub New()
            MyBase.Direction = Direction.Vertical
        End Sub
        Public Sub New(ByVal direction As Direction)
            MyBase.Direction = direction
        End Sub
#End Region

#Region "Properties"
        Public Property Divider() As ReportSection
            Get
                Return Me.divider
            End Get
            Set(ByVal value As ReportSection)
                Me.divider = value
            End Set
        End Property
        Public Property ShowDividerFirst() As Boolean
            Get
                Return Me.showDividerFirst
            End Get
            Set(ByVal value As Boolean)
                Me.showDividerFirst = value
            End Set
        End Property
#End Region

#Region "Methods"
        Protected Overrides Function DoCalcSize(ByVal reportDocument As ReportDocument, ByVal g As Graphics, ByVal bounds As Bounds) As SectionSizeValues
            Dim values1 As SectionSizeValues
            values1 = New SectionSizeValues
            values1.RequiredSize = bounds.GetSizeF
            values1.Fits = True
            Return values1
        End Function
        Protected Overrides Sub DoPrint(ByVal reportDocument As ReportDocument, ByVal g As Graphics, ByVal bounds As Bounds)
            Dim ef1 As SizeF
            ef1 = New SizeF(0.0!, 0.0!)
            If (Me.ShowDividerFirst AndAlso (Not Me.Divider Is Nothing)) Then
                Me.m_divider.Print(reportDocument, g, bounds)
                MyBase.AdvancePointers(Me.m_divider.Size, bounds, ef1)
            End If
            Dim values1 As SectionSizeValues = MyBase.SizePrintLine(reportDocument, g, bounds, True, False)
            Dim flag1 As Boolean = values1.Fits
            Do While values1.Fits
                Dim bounds1 As Bounds = bounds.GetBounds(values1.RequiredSize)
                MyBase.SizePrintLine(reportDocument, g, bounds1, False, True)
                MyBase.AdvancePointers(values1.RequiredSize, bounds, ef1)
                If Not values1.Continued Then
                    Exit Do
                End If
                If (Not Me.Divider Is Nothing) Then
                    Me.m_divider.Print(reportDocument, g, bounds)
                    MyBase.AdvancePointers(Me.m_divider.Size, bounds, ef1)
                End If
                values1 = MyBase.SizePrintLine(reportDocument, g, bounds, True, False)
            Loop
            Me.SetSize(ef1, bounds)
            MyBase.SetFits(flag1)
            MyBase.SetContinued(values1.Continued)
        End Sub
#End Region

    End Class
End Namespace