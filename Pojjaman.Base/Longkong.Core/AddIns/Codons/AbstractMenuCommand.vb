Imports Longkong.Core.AddIns.Codons
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Gui
Imports Longkong.Pojjaman.Gui.Panels
Imports Longkong.Pojjaman.Gui.Pads
Imports Longkong.Pojjaman.Gui.Dialogs
Imports Longkong.Core.Properties
Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.PanelDisplayBinding
Namespace Longkong.Core.AddIns.Codons
    Public MustInherit Class AbstractMenuCommand
        Inherits AbstractCommand
        Implements IMenuCommand

#Region "Members"
        Private m_isEnabled As Boolean
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

#Region "IMenuCommand"
        Public Overridable Property IsEnabled() As Boolean Implements IMenuCommand.IsEnabled
            Get
                Return Me.m_isEnabled
            End Get
            Set(ByVal value As Boolean)
                Me.m_isEnabled = value
            End Set
        End Property
#End Region

    End Class

    Public Class AbstractEntityAccessCommand
        Inherits AbstractMenuCommand

#Region "Members"
        Private m_validLevel As Integer
#End Region

#Region "Properties"
        Public Overridable ReadOnly Property ValidLevel() As Integer            Get                Return m_validLevel            End Get        End Property
#End Region

#Region "Overrides"
        Public ReadOnly Property IsEnabledWithChecking() As Boolean
            Get
                Dim panel As ISimpleListPanel = CType(WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ViewContent, ISimpleListPanel)
                If Not panel.Entity Is Nothing Then
                    Dim fcn As String = panel.Entity.Namespace & "." & panel.Entity.CodonName
                    If TypeOf panel.Entity Is TreeBaseEntity Then
                        fcn = panel.Entity.FullClassName
                    End If
                    Dim accessID As Integer = Longkong.Pojjaman.BusinessLogic.Entity.GetAccessIdFromFullClassName(fcn)
                    If accessID = 0 Then
                        Return False 'MyBase.IsEnabled
                    End If
                    Dim secSrv As SecurityService = CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService)
                    Dim level As Integer = secSrv.GetAccess(accessID)
                    Dim checkString As String = BinaryHelper.DecToBin(level, 5)
                    checkString = BinaryHelper.RevertString(checkString)
                    Return CBool(checkString.Substring(ValidLevel, 1)) And MyBase.IsEnabled
                End If
                Return MyBase.IsEnabled
            End Get
        End Property
#End Region

    End Class
End Namespace
