Imports System
Imports System.Collections
Imports System.Reflection
Imports Longkong.Core.AddIns.Conditions
Imports System.IO
Imports Longkong.Pojjaman.Gui
Namespace Longkong.Core.AddIns
    Public Enum WindowState
        None = 0
        Untitled = 1
        Dirty = 2
        ViewOnly = 4
    End Enum
    <Condition()> _
    Public Class ActiveWindowStateCondition
        Inherits AbstractCondition

#Region "Members"
        <XmlMemberAttributeAttribute("nowindowstate", IsRequired:=False)> _
        Private m_noWindowState As WindowState
        <XmlMemberAttributeAttribute("windowstate", IsRequired:=True)> _
        Private m_windowState As WindowState
#End Region

#Region "Constructors"
        Public Sub New()
            Me.m_windowState = WindowState.None
            Me.m_noWindowState = WindowState.None
        End Sub
#End Region

#Region "Properties"

#End Region

#Region "Methods"
        Public Overrides Function IsValid(ByVal caller As Object) As Boolean
            If (((WorkbenchSingleton.Workbench Is Nothing) OrElse (WorkbenchSingleton.Workbench.ActiveWorkbenchWindow Is Nothing)) OrElse (WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ViewContent Is Nothing)) Then
                Return False
            End If
            Dim valid As Boolean = False
            If (Me.m_windowState <> WindowState.None) Then
                If ((Me.m_windowState And WindowState.Dirty) > WindowState.None) Then
                    valid = (valid Or WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ViewContent.IsDirty)
                End If
                If ((Me.m_windowState And WindowState.Untitled) > WindowState.None) Then
                    valid = (valid Or WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ViewContent.IsUntitled)
                End If
                If ((Me.m_windowState And WindowState.ViewOnly) > WindowState.None) Then
                    valid = (valid Or WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ViewContent.IsViewOnly)
                End If
            Else
                valid = True
            End If
            If (Me.m_noWindowState <> WindowState.None) Then
                If ((Me.m_noWindowState And WindowState.Dirty) > WindowState.None) Then
                    valid = (valid And Not WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ViewContent.IsDirty)
                End If
                If ((Me.m_noWindowState And WindowState.Untitled) > WindowState.None) Then
                    valid = (valid And Not WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ViewContent.IsUntitled)
                End If
                If ((Me.m_noWindowState And WindowState.ViewOnly) > WindowState.None) Then
                    valid = (valid And Not WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ViewContent.IsViewOnly)
                End If
            End If
            Return valid
        End Function
#End Region

    End Class
End Namespace
