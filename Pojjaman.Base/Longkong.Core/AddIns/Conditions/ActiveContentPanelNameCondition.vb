Imports System
Imports System.Collections
Imports System.Reflection
Imports Longkong.Core.AddIns.Conditions
Imports Longkong.Pojjaman.Gui
Imports Longkong.Pojjaman.Gui.Panels
Imports System.IO
Namespace Longkong.Core.AddIns
    <Condition()> _
    Public Class ActiveContentPanelNameCondition
        Inherits AbstractCondition

#Region "Members"
        <XmlMemberAttributeAttribute("activepanelname", IsRequired:=True)> _
        Private m_activePanelName As String
#End Region

#Region "Constructors"
        Public Sub New()
        End Sub
#End Region

#Region "Properties"
        Public Property ActivePanelName() As String
            Get
                Return m_activePanelName
            End Get
            Set(ByVal value As String)
                m_activePanelName = value
            End Set
        End Property
#End Region

#Region "Methods"
        Public Overrides Function IsValid(ByVal caller As Object) As Boolean
            Dim valid As Boolean
            If (((WorkbenchSingleton.Workbench Is Nothing) OrElse (WorkbenchSingleton.Workbench.ActiveWorkbenchWindow Is Nothing)) OrElse (WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ViewContent Is Nothing)) Then
                Return False
            End If
            Try
                valid = (WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ViewContent.PanelName.ToUpper = m_activePanelName.ToUpper)
            Catch ex As Exception
                valid = False
            End Try
            Return valid
        End Function
#End Region

    End Class
End Namespace
