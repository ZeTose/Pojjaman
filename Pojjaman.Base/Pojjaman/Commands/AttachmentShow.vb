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
Imports System.Data.SqlClient
Namespace Longkong.Pojjaman.Commands
    Public Class AttachmentShow
        Inherits AbstractEntityAccessCommand

#Region "Constructors"
        Public Sub New()
        End Sub
#End Region

#Region "Methods"
        Public Overrides Sub Run()
            If TypeOf CType(WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ActiveViewContent, ISimpleEntityPanel).Entity Is ISimpleEntity Then
                ShowAttachment()
            End If
        End Sub
    Private Sub ShowAttachment()
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      Dim newEntity As ISimpleEntity = CType(WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ActiveViewContent, ISimpleEntityPanel).Entity
      Dim frm As New AttachmentForm(newEntity)
      Select Case frm.ShowDialog
        Case DialogResult.OK
          If Not frm.AttachmentColl Is Nothing Then
            frm.AttachmentColl.Save()
          End If
        Case Else

      End Select
      If TypeOf newEntity Is SimpleBusinessEntityBase Then
        Dim tmp As Boolean = CType(newEntity, SimpleBusinessEntityBase).hasAttachment(True)
      End If
    End Sub
        Public Overrides Property IsEnabled() As Boolean
            Get
                If WorkbenchSingleton.Workbench.ActiveWorkbenchWindow Is Nothing Then
                    Return MyBase.IsEnabled
                End If
                If WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ViewContent Is Nothing Then
                    Return MyBase.IsEnabled
                End If
                If Not TypeOf WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ViewContent Is ISimpleListPanel Then
                    Return MyBase.IsEnabled
                End If
                Return MyBase.IsEnabledWithChecking
            End Get
            Set(ByVal Value As Boolean)
                MyBase.IsEnabled = Value
            End Set
        End Property
        Public Overrides ReadOnly Property ValidLevel() As Integer
            Get
                Return 1
            End Get
        End Property
#End Region


    End Class
End Namespace
