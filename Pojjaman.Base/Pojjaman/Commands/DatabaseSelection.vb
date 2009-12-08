Imports Longkong.Core.AddIns
Imports Longkong.Core.AddIns.Codons
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Gui
Imports Longkong.Pojjaman.Gui.Dialogs
Imports Longkong.Core.Properties
Imports Longkong.Core.AddIns.Conditions
Imports Longkong.Pojjaman.BusinessLogic
Imports Pojjaman.DatabaseSetting
Namespace Longkong.Pojjaman.Commands
    Public Class DatabaseSelection
        Inherits AbstractMenuCommand

#Region "Constructors"
        Public Sub New()
        End Sub
#End Region

#Region "Methods"
        Public Overrides Sub Run()
            Dim dlg As New DBSettingForm
            dlg.ShowDialog()
        End Sub
#End Region

        Public Overrides Property IsEnabled() As Boolean
            Get
                Dim secSrv As SecurityService = CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService)
                If Not secSrv.CurrentUser Is Nothing AndAlso secSrv.CurrentUser.Originated Then
                    Dim accessID As Integer = 18
                    Dim level As Integer = secSrv.GetAccess(accessID)
                    Dim checkString As String = BinaryHelper.DecToBin(level, 5)
                    checkString = BinaryHelper.RevertString(checkString)
                    Return CBool(checkString.Substring(0, 1)) And MyBase.IsEnabled
                End If
                Return MyBase.IsEnabled
            End Get
            Set(ByVal Value As Boolean)
                MyBase.IsEnabled = Value
            End Set
        End Property

    End Class
End Namespace
