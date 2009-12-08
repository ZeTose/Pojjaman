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
    Public Class SecurityLevelCondition
        Inherits AbstractCondition

#Region "Members"
        <XmlMemberAttributeAttribute("accessid", IsRequired:=True)> _
        Private m_accessId As Integer
        <XmlMemberAttributeAttribute("acesslevel", IsRequired:=True)> _
        Private m_accessLevel As String
#End Region

#Region "Constructors"
        Public Sub New()
            Me.m_accessId = 0
            Me.m_accessLevel = "0"
        End Sub
#End Region

#Region "Properties"

#End Region

#Region "Methods"
        Public Overrides Function IsValid(ByVal caller As Object) As Boolean
            If m_accessLevel = "*" Then
                Return True
            End If
            Dim secSvc As SecurityService = CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService)
            If secSvc Is Nothing Then
                'Service ยังไม่ start
                Return True
            End If
            Dim CurrentUser As User = secSvc.CurrentUser
            If CurrentUser Is Nothing OrElse Not CurrentUser.Originated Then
                Return True
            End If
            If CInt(m_accessLevel) <= secSvc.GetAccess(Me.m_accessId) Then
                Return True
            End If
            Return False
        End Function
#End Region

    End Class
End Namespace
