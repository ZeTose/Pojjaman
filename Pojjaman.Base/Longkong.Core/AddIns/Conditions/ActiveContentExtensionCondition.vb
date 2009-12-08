Imports System
Imports System.Collections
Imports System.Reflection
Imports Longkong.Core.AddIns.Conditions
Imports Longkong.Pojjaman.Gui
Imports System.IO
Namespace Longkong.Core.AddIns
    <Condition()> _
    Public Class ActiveContentExtensionCondition
        Inherits AbstractCondition

#Region "Members"
        <XmlMemberAttributeAttribute("activeextension", IsRequired:=True)> _
        Private m_activeExtension As String
#End Region

#Region "Constructors"
        Public Sub New()
        End Sub
#End Region

#Region "Properties"
        Public Property ActiveExtension() As String
            Get
                Return Me.m_activeExtension
            End Get
            Set(ByVal value As String)
                Me.m_activeExtension = value
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
                Dim extName As String
                If WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ViewContent.IsUntitled Then
                    extName = WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ViewContent.UntitledName
                Else
                    extName = WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ViewContent.FileName
                End If
                If (extName Is Nothing) Then
                    Return False
                End If
                Dim ext As String = Path.GetExtension(extName)
                valid = (ext.ToUpper = Me.m_activeExtension.ToUpper)
            Catch ex As Exception
                valid = False
            End Try
            Return valid
        End Function
#End Region

    End Class
End Namespace
