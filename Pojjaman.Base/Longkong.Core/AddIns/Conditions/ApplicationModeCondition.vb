Imports System
Imports System.Collections
Imports System.Reflection
Imports Longkong.Core.AddIns.Conditions
Imports Longkong.Pojjaman.Gui
Imports Longkong.Pojjaman.Gui.Panels
Imports System.IO
Namespace Longkong.Core.AddIns
    <Condition()> _
    Public Class ApplicationModeCondition
        Inherits AbstractCondition

#Region "Members"
        <XmlMemberAttributeAttribute("noapplicationmode", IsRequired:=False)> _
        Private m_noApplicationMode As ApplicationMode
        <XmlMemberAttributeAttribute("applicationmode", IsRequired:=True)> _
        Private m_applicationMode As ApplicationMode
#End Region

#Region "Constructors"
        Public Sub New()
            Me.m_applicationMode = ApplicationMode.None
            Me.m_noApplicationMode = ApplicationMode.None
        End Sub
#End Region

#Region "Properties"

#End Region

#Region "Methods"
        Public Overrides Function IsValid(ByVal caller As Object) As Boolean
            If WorkbenchSingleton.Workbench Is Nothing Then
                Return False
            End If
            Dim valid As Boolean = False
            If (Me.m_applicationMode <> ApplicationMode.None) Then
                If ((Me.m_applicationMode And ApplicationMode.Accounting) > ApplicationMode.None) Then
                    valid = (valid Or ((WorkbenchSingleton.Workbench.ApplicationMode And ApplicationMode.Accounting) > ApplicationMode.None))
                End If
                If ((Me.m_applicationMode And ApplicationMode.Bidding) > ApplicationMode.None) Then
                    valid = (valid Or ((WorkbenchSingleton.Workbench.ApplicationMode And ApplicationMode.Bidding) > ApplicationMode.None))
                End If
                If ((Me.m_applicationMode And ApplicationMode.CostControl) > ApplicationMode.None) Then
                    valid = (valid Or ((WorkbenchSingleton.Workbench.ApplicationMode And ApplicationMode.CostControl) > ApplicationMode.None))
                End If
            Else
                valid = True
            End If
            If (Me.m_noApplicationMode <> ApplicationMode.None) Then
                If ((Me.m_applicationMode And ApplicationMode.Accounting) > ApplicationMode.None) Then
                    valid = (valid And Not ((WorkbenchSingleton.Workbench.ApplicationMode And ApplicationMode.Accounting) > ApplicationMode.None))
                End If
                If ((Me.m_applicationMode And ApplicationMode.Bidding) > ApplicationMode.None) Then
                    valid = (valid And Not ((WorkbenchSingleton.Workbench.ApplicationMode And ApplicationMode.Bidding) > ApplicationMode.None))
                End If
                If ((Me.m_applicationMode And ApplicationMode.CostControl) > ApplicationMode.None) Then
                    valid = (valid And Not ((WorkbenchSingleton.Workbench.ApplicationMode And ApplicationMode.CostControl) > ApplicationMode.None))
                End If
            End If
            Return valid
        End Function
#End Region

    End Class
    Public Enum ApplicationMode
        None = 0
        Bidding = 1
        Accounting = 2
        CostControl = 4
    End Enum
End Namespace
