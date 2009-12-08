Imports System
Imports System.Collections
Imports System.Reflection
Imports Longkong.Core.AddIns.Conditions
Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Namespace Longkong.Core.AddIns.Codons
    Public MustInherit Class AbstractEntityMenuCommand
        Inherits AbstractCommand
        Implements IEntityMenuCommand

#Region "Members"
        Private m_isEnabled As Boolean
        Private m_entity As String
#End Region

#Region "Constructors"
        Protected Sub New()
            Me.m_isEnabled = True
        End Sub
#End Region

#Region "Methods"
        Public Overrides Sub Run()
        End Sub
#End Region

#Region "IEntityMenuCommand"
        Public Overridable Property IsEnabled() As Boolean Implements IMenuCommand.IsEnabled
            Get
                Dim secSrv As SecurityService = CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService)
                If Not secSrv.CurrentUser Is Nothing AndAlso secSrv.CurrentUser.Originated Then
                    Dim accessID As Integer = Longkong.Pojjaman.BusinessLogic.Entity.GetAccessIdFromFullClassName(Me.Entity)
                    If accessID = 0 Then
                        Return False 'Me.m_isEnabled
                    End If
                    Dim level As Integer = secSrv.GetAccess(accessID)
                    Dim checkString As String = BinaryHelper.DecToBin(level, 5)
                    checkString = BinaryHelper.RevertString(checkString)
                    Return CBool(checkString.Substring(0, 1)) And Me.m_isEnabled
                End If
                Return Me.m_isEnabled
            End Get
            Set(ByVal value As Boolean)
                Me.m_isEnabled = value
            End Set
        End Property
        Public Overridable Property Entity() As String Implements IEntityMenuCommand.Entity
            Get
                Return m_entity
            End Get
            Set(ByVal Value As String)
                m_entity = Value
            End Set
        End Property
#End Region


    End Class
End Namespace
