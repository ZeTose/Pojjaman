Imports System
Imports System.Collections
Imports System.Reflection
Imports Longkong.Core.AddIns.Conditions
Imports Longkong.Pojjaman.Gui
Imports Longkong.Pojjaman.Gui.Panels
Imports System.IO
Namespace Longkong.Core.AddIns
    <Condition()> _
    Public Class ActiveContentEntityNameCondition
        Inherits AbstractCondition

#Region "Members"
        <XmlMemberAttributeAttribute("activeentityname", IsRequired:=True)> _
        Private m_activeEntityName As String
#End Region

#Region "Constructors"
        Public Sub New()
        End Sub
#End Region

#Region "Properties"
        Public Property ActiveEntityName() As String
            Get
                Return m_activeEntityName
            End Get
            Set(ByVal value As String)
                m_activeEntityName = value
            End Set
        End Property
#End Region

#Region "Methods"
        Public Overrides Function IsValid(ByVal caller As Object) As Boolean
            If (Not WorkbenchSingleton.Workbench Is Nothing) Then
                Dim valid As Boolean
                If (Me.m_activeEntityName = "*") Then
                    Return Not WorkbenchSingleton.Workbench.ActiveWorkbenchWindow Is Nothing
                End If
                Try
                    Dim entityName As String
                    If TypeOf WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ActiveViewContent Is AbstractEntityDetailPanelView Then
            'entityName = CType(WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ViewContent, IEntityPanel).Entity.ClassName
                    Else
                        valid = False
                    End If
                    valid = (entityName.ToUpper = m_activeEntityName.ToUpper)
                Catch ex As Exception
                    valid = False
                End Try
                Return valid
            End If
        End Function
#End Region

    End Class
End Namespace
