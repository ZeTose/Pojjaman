Imports System
Imports System.Drawing
Imports System.Collections
Imports System.Drawing.Imaging
Imports System.Drawing.Drawing2D
Imports Microsoft.VisualBasic

Namespace Longkong.Reporting.Printing
    Public Enum Direction
        Horizontal = 1
        Vertical = 0
    End Enum
    Public Class LinearSections
        Inherits SectionContainer

#Region "Members"
        Private m_direction As direction
        Private m_skipAmount As Single
#End Region

#Region "Constructors"
        Public Sub New()
            Me.m_direction = Direction.Vertical
        End Sub
        Public Sub New(ByVal direction As Direction)
            Me.m_direction = direction
        End Sub
#End Region

#Region "Properties"
        Public Property Direction() As Direction            Get                Return m_direction            End Get            Set(ByVal Value As Direction)                m_direction = Value            End Set        End Property        Public Property SkipAmount() As Single            Get                Return m_skipAmount            End Get            Set(ByVal Value As Single)                m_skipAmount = Value            End Set        End Property
#End Region

#Region "Methods"
        Protected Sub AdvancePointers(ByVal size As SizeF, ByRef bounds As Bounds, ByRef requiredSize As SizeF)
            Select Case Me.m_direction
                Case Direction.Vertical
                    bounds.Position.Y = (bounds.Position.Y + size.Height)
                    requiredSize.Height = (requiredSize.Height + size.Height)
                    bounds.Position.Y = (bounds.Position.Y + Me.SkipAmount)
                    requiredSize.Height = (requiredSize.Height + Me.SkipAmount)
                    requiredSize.Width = Math.Max(requiredSize.Width, size.Width)
                    Return
                Case Direction.Horizontal
                    bounds.Position.X = (bounds.Position.X + size.Width)
                    requiredSize.Width = (requiredSize.Width + size.Width)
                    bounds.Position.X = (bounds.Position.X + Me.SkipAmount)
                    requiredSize.Width = (requiredSize.Width + Me.SkipAmount)
                    requiredSize.Height = Math.Max(requiredSize.Height, size.Height)
                    Return
            End Select
        End Sub
        Protected Overrides Sub DoBeginPrint(ByVal g As Graphics)
            Me.m_sectionIndex = 0
        End Sub
        Protected Overrides Function DoCalcSize(ByVal reportDocument As ReportDocument, ByVal g As Graphics, ByVal bounds As Bounds) As SectionSizeValues
            Return Me.SizePrintLine(reportDocument, g, bounds, True, False)
        End Function
        Protected Overrides Sub DoPrint(ByVal reportDocument As ReportDocument, ByVal g As Graphics, ByVal bounds As Bounds)
            If Not Me.UseFullWidth Then
                bounds.Limit.X = (bounds.Position.X + MyBase.RequiredSize.Width)
            End If
            If Not Me.UseFullHeight Then
                bounds.Limit.Y = (bounds.Position.Y + MyBase.RequiredSize.Height)
            End If
            Me.SizePrintLine(reportDocument, g, bounds, False, True)
        End Sub
        Protected Function SizePrintLine(ByVal reportDocument As ReportDocument, ByVal g As Graphics, ByVal bounds As Bounds, ByVal sizeOnly As Boolean, ByVal advanceSectionIndex As Boolean) As SectionSizeValues
            Dim values1 As SectionSizeValues
            values1 = New SectionSizeValues
            values1.Fits = False
            Dim num1 As Integer = Me.m_sectionIndex
            Do While (Me.m_sectionIndex < Me.SectionCount)
                MyBase.CurrentSection.CalcSize(reportDocument, g, bounds)
                If MyBase.CurrentSection.Fits Then
                    values1.Fits = True
                    If Not sizeOnly Then
                        MyBase.CurrentSection.Print(reportDocument, g, bounds)
                    End If
                    Me.AdvancePointers(MyBase.CurrentSection.Size, bounds, values1.RequiredSize)
                    If MyBase.CurrentSection.Continued Then
                        Exit Do
                    End If
                    Me.m_sectionIndex += 1
                Else
                    MyBase.CurrentSection.ResetSize()
                    Exit Do
                End If
            Loop
            values1.Continued = (Me.m_sectionIndex < Me.SectionCount)
            If Not advanceSectionIndex Then
                Me.m_sectionIndex = num1
            End If
            Return values1
        End Function
#End Region

    End Class
End Namespace