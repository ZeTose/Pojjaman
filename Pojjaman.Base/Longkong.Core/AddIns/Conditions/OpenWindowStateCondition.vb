Imports System
Imports System.Collections
Imports System.Reflection
Imports Longkong.Core.AddIns.Conditions
Imports System.IO
Imports Longkong.Pojjaman.Gui
Namespace Longkong.Core.AddIns
    <Condition()> _
    Public Class OpenWindowStateCondition
        Inherits AbstractCondition

#Region "Members"
        <XmlMemberAttributeAttribute("noopenwindowstate", IsRequired:=False)> _
          Private m_noWindowState As windowState
        <XmlMemberAttributeAttribute("openwindowstate", IsRequired:=True)> _
        Private m_windowState As windowState
#End Region

#Region "Consructors"
        Public Sub New()
            Me.m_windowState = WindowState.None
            Me.m_noWindowState = WindowState.None
        End Sub
#End Region

#Region "Methods"
        Private Function IsStateOk(ByVal window As IWorkbenchWindow) As Boolean
            If (window.ViewContent Is Nothing) Then
                Return False
            End If
            Dim stateOK As Boolean = False
            If (Me.m_windowState <> WindowState.None) Then
                If ((Me.m_windowState And WindowState.Dirty) > WindowState.None) Then
                    stateOK = (stateOK Or window.ViewContent.IsDirty)
                End If
                If ((Me.m_windowState And WindowState.Untitled) > WindowState.None) Then
                    stateOK = (stateOK Or window.ViewContent.IsUntitled)
                End If
                If ((Me.m_windowState And WindowState.ViewOnly) > WindowState.None) Then
                    stateOK = (stateOK Or window.ViewContent.IsViewOnly)
                End If
            Else
                stateOK = True
            End If
            If (Me.m_noWindowState <> WindowState.None) Then
                If ((Me.m_noWindowState And WindowState.Dirty) > WindowState.None) Then
                    stateOK = (stateOK And Not window.ViewContent.IsDirty)
                End If
                If ((Me.m_noWindowState And WindowState.Untitled) > WindowState.None) Then
                    stateOK = (stateOK And Not window.ViewContent.IsUntitled)
                End If
                If ((Me.m_noWindowState And WindowState.ViewOnly) > WindowState.None) Then
                    stateOK = (stateOK And Not window.ViewContent.IsViewOnly)
                End If
            End If
            Return stateOK
        End Function
        Public Overrides Function IsValid(ByVal caller As Object) As Boolean
            If (Not WorkbenchSingleton.Workbench Is Nothing) Then
                If ((WorkbenchSingleton.Workbench.ActiveWorkbenchWindow Is Nothing) OrElse (WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ViewContent Is Nothing)) Then
                    Return False
                End If
                For Each content As IViewContent In WorkbenchSingleton.Workbench.ViewContentCollection
                    If Me.IsStateOk(content.WorkbenchWindow) Then
                        Return True
                    End If
                Next
            End If
            Return False
        End Function
#End Region

    End Class
End Namespace
