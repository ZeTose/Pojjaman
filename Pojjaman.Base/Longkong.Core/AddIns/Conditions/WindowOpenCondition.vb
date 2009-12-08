Imports System
Imports System.Collections
Imports System.Reflection
Imports Longkong.Core.AddIns.Conditions
Imports System.IO
Imports Longkong.Pojjaman.Gui
Namespace Longkong.Core.AddIns
    <Condition()> _
    Public Class WindowOpenCondition
        Inherits AbstractCondition

#Region "Members"
        <XmlMemberAttributeAttribute("openwindow", IsRequired:=True)> _
        Private m_openwindow As String
#End Region

#Region "Constructors"
        Public Sub New()
        End Sub
#End Region

#Region "Properties"
        Public Property ActiveWindow() As String
            Get
                Return Me.m_openwindow
            End Get
            Set(ByVal value As String)
                Me.m_openwindow = value
            End Set
        End Property
#End Region

#Region "Methods"
        Public Overrides Function IsValid(ByVal caller As Object) As Boolean
            If (Not WorkbenchSingleton.Workbench Is Nothing) Then
                If (Me.m_openwindow Is "*") Then
                    Return (Not WorkbenchSingleton.Workbench.ActiveWorkbenchWindow Is Nothing)
                End If
                For Each myType As Type In WorkbenchSingleton.Workbench.ViewContentCollection
                    If (myType.ToString Is Me.m_openwindow) Then
                        Return True
                    End If
                    For Each iface As Type In myType.GetInterfaces
                        If (iface.ToString Is Me.m_openwindow) Then
                            Return True
                        End If
                    Next
                Next
            End If
            Return False
        End Function
#End Region

    End Class
End Namespace
