Imports System
Imports System.Collections
Imports System.Reflection
Imports Longkong.Core.AddIns.Conditions
Imports System.IO
Imports Longkong.Pojjaman.Gui
Namespace Longkong.Core.AddIns
    <Condition()> _
    Public Class WindowActiveCondition
        Inherits AbstractCondition

#Region "Members"
        <XmlMemberAttributeAttribute("activewindow", IsRequired:=True)> _
        Private m_activewindow As String
        Private m_prevType As Type
        Private m_prevValidFlag As Boolean
#End Region

#Region "Constructors"
        Public Sub New()
            Me.m_prevType = Nothing
            Me.m_prevValidFlag = False
        End Sub
#End Region

#Region "Properties"
        Public Property ActiveWindow() As String
            Get
                Return Me.m_activewindow
            End Get
            Set(ByVal value As String)
                Me.m_activewindow = value
            End Set
        End Property
#End Region

#Region "Methods"
        Public Overrides Function IsValid(ByVal caller As Object) As Boolean
            If (Not WorkbenchSingleton.Workbench Is Nothing) Then
                If (Me.m_activewindow = "*") Then
                    Return (Not WorkbenchSingleton.Workbench.ActiveWorkbenchWindow Is Nothing)
                End If
                If ((WorkbenchSingleton.Workbench.ActiveWorkbenchWindow Is Nothing) OrElse (WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ActiveViewContent Is Nothing)) Then
                    Return False
                End If
                Dim activeContentype As Type = CType(WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ActiveViewContent, Object).GetType
                If activeContentype.Equals(Me.m_prevType) Then
                    Return Me.m_prevValidFlag
                End If
                Me.m_prevType = activeContentype
                If (activeContentype.ToString = Me.m_activewindow) Then
                    Me.m_prevValidFlag = True
                    Return True
                End If
                Dim interfaceArray As Type() = activeContentype.GetInterfaces
                Dim num1 As Integer
                For Each itf As Type In interfaceArray
                    If (itf.ToString = Me.m_activewindow) Then
                        Me.m_prevValidFlag = True
                        Return True
                    End If
                Next
                Me.m_prevValidFlag = False
            End If
            Return False
        End Function
#End Region

    End Class
End Namespace
