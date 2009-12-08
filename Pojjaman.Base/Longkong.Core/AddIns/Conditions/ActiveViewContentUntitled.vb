Imports System
Imports System.Collections
Imports System.Reflection
Imports Longkong.Core.AddIns.Conditions
Imports System.IO
Imports Longkong.Pojjaman.Gui
Namespace Longkong.Core.AddIns
    <Condition()> _
    Public Class ActiveViewContentUntitled
        Inherits AbstractCondition

#Region "Members"
        <XmlMemberAttributeAttribute("activewindowuntitled", IsRequired:=True)> _
         Private m_activeWindowUntitled As Boolean
#End Region

#Region "Constructors"
        Public Sub New()
        End Sub
#End Region

#Region "Properties"
        Public Property ActiveWindowUntitled() As Boolean
            Get
                Return Me.m_activeWindowUntitled
            End Get
            Set(ByVal value As Boolean)
                Me.m_activeWindowUntitled = value
            End Set
        End Property
#End Region

#Region "Methods"
        Public Overrides Function IsValid(ByVal caller As Object) As Boolean
            If (((Not WorkbenchSingleton.Workbench Is Nothing) AndAlso (Not WorkbenchSingleton.Workbench.ActiveWorkbenchWindow Is Nothing)) AndAlso (Not WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ViewContent Is Nothing)) Then
                If (WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ViewContent.IsUntitled AndAlso Me.m_activeWindowUntitled) Then
                    Return True
                End If
                If Not WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ViewContent.IsUntitled Then
                    Return Not Me.m_activeWindowUntitled
                End If
            End If
            Return False
        End Function
#End Region

    End Class
End Namespace
