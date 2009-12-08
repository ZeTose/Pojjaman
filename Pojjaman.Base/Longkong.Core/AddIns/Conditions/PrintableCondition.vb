Imports System
Imports System.Collections
Imports System.Reflection
Imports Longkong.Core.AddIns.Conditions
Imports Longkong.Pojjaman.Gui
Imports Longkong.Pojjaman.Gui.Panels
Imports System.IO
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.BusinessLogic
Namespace Longkong.Core.AddIns
    <Condition()> _
    Public Class PrintableCondition
        Inherits AbstractCondition

#Region "Members"
        <XmlMemberAttributeAttribute("printable", IsRequired:=True)> _
        Private m_printable As Boolean
#End Region

#Region "Constructors"
        Public Sub New()
        End Sub
#End Region

#Region "Properties"
        Public Property Printable() As Boolean
            Get
                Return Me.m_printable
            End Get
            Set(ByVal value As Boolean)
                Me.m_printable = value
            End Set
        End Property
#End Region

#Region "Methods"
        Public Overrides Function IsValid(ByVal caller As Object) As Boolean
            If (((Not WorkbenchSingleton.Workbench Is Nothing) AndAlso (Not WorkbenchSingleton.Workbench.ActiveWorkbenchWindow Is Nothing)) AndAlso (Not WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ActiveViewContent Is Nothing)) Then
                If TypeOf WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ActiveViewContent Is IPrintable Then
                    Try
                        If CType(WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ActiveViewContent, IPrintable).CanPrint Then
                            Return m_printable
                        End If
                    Catch ex As Exception

                    End Try
                End If
            End If
            Return Not m_printable
        End Function
#End Region

    End Class
    <Condition()> _
    Public Class HasprintableViewCondition
        Inherits AbstractCondition

#Region "Members"
        <XmlMemberAttributeAttribute("hasprintableview", IsRequired:=True)> _
        Private m_hasPrintableView As Boolean
#End Region

#Region "Constructors"
        Public Sub New()
        End Sub
#End Region

#Region "Properties"
        Public Property HasprintableView() As Boolean
            Get
                Return Me.m_hasPrintableView
            End Get
            Set(ByVal value As Boolean)
                Me.m_hasPrintableView = value
            End Set
        End Property
#End Region

#Region "Methods"
        Public Overrides Function IsValid(ByVal caller As Object) As Boolean
            If (((Not WorkbenchSingleton.Workbench Is Nothing) AndAlso (Not WorkbenchSingleton.Workbench.ActiveWorkbenchWindow Is Nothing)) AndAlso (Not WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.SubViewContents Is Nothing)) Then
                For Each view As Object In WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.SubViewContents
                    If TypeOf view Is IPrintable Then
                        Try
                            If CType(view, IPrintable).CanPrint Then
                                Return m_hasPrintableView
                            End If
                        Catch ex As Exception

                        End Try
                    End If
                Next
            End If
            Return Not m_hasPrintableView
        End Function
#End Region

    End Class
End Namespace
