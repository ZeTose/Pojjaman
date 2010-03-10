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
  Public Class DeleteEntity
    Inherits AbstractEntityAccessCommand

#Region "Constructors"
    Public Sub New()
    End Sub
#End Region

#Region "Methods"
    Public Overrides Sub Run()
      If TypeOf CType(WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ActiveViewContent, ISimpleEntityPanel).Entity Is GLFormat Then
        If TypeOf WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ActiveViewContent Is IEditable Then
          Dim editable As IEditable = CType(WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ActiveViewContent, IEditable)
          If editable.ClipboardHandler.EnableDelete Then
            editable.ClipboardHandler.Delete(Nothing, Nothing)
          End If
        End If
      ElseIf TypeOf CType(WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ActiveViewContent, ISimpleEntityPanel).Entity Is ISimpleEntity Then
        Dim delErr As SaveErrorException = Delete()
        If IsNumeric(delErr.Message) Then
          Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
          msgServ.ShowMessage("${res:Global.Deleted}")


          'HACK================================================================
          Try
            If TypeOf CType(WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ViewContent, ISimpleEntityPanel).Entity Is LCIItem Then
              Dim lci As LCIItem = CType(CType(WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ViewContent, ISimpleEntityPanel).Entity, LCIItem)
              Dim currentEntity As LCIItem = CType(CType(WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ActiveViewContent, ISimpleEntityPanel).Entity, LCIItem)
              Dim deletedRow As DataRow = CType(LCIItem.AllLciitems(currentEntity.Id.ToString), DataRow)
              LCIItem.AllLciitems.Remove(currentEntity.Id)
              LCIItem.LciitemTable.Rows.Remove(deletedRow)
              CType(WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ViewContent, ISimpleListPanel).RefreshData("")
            End If
          Catch ex As Exception

          End Try
          'HACK================================================================


          WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.SwitchView(0)
          CType(WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ViewContent, ISimpleListPanel).RefreshData("")
        End If
      End If
    End Sub
    Private Function Delete() As SaveErrorException
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      Try
        Dim newEntity As ISimpleEntity = CType(WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ActiveViewContent, ISimpleEntityPanel).Entity
        Dim myService As SecurityService = CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService)

        '*************************************ป้องกัน LEVEL***************************************
        Dim ApprovalDocLevel As New ApprovalDocLevelCollection(myService.CurrentUser)
        Dim approveDocColl As New ApproveDocCollection(newEntity)
        'Dim currentApproveId As Integer = Me.ApprovePerson.Id
        Dim myMessage As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
        If ApprovalDocLevel.GetItem(newEntity.EntityId).Level <= approveDocColl.MaxLevel AndAlso approveDocColl.MaxLevelPersonId <> 0 AndAlso myService.CurrentUser.Id <> approveDocColl.MaxLevelPersonId Then
          msgServ.ShowMessage("${res:Global.NotEnoughLevelToDelete}")
          Return New SaveErrorException("${res:Global.NotEnoughLevelToDelete}")
        End If
        '*************************************END ป้องกัน LEVEL***************************************

        Dim saveError As SaveErrorException
        Dim canDeleteWithLog As Boolean = False
        If TypeOf newEntity Is IDeletableWithLog Then
          Try
            saveError = CType(newEntity, IDeletableWithLog).DeleteWithLog(myService.CurrentUser.Id, Now)
            canDeleteWithLog = True
          Catch ex As Exception
            canDeleteWithLog = False
          End Try
        End If

        '-------------------Check Locking Period-------------------
        If TypeOf newEntity Is IGLAble Then
          'มี GL
          Dim glAble As IGLAble = CType(newEntity, IGLAble)
          Dim docDateLocking As AccountPeriodLock = AccountPeriod.GetLockingForDate(glAble.Date)
          If docDateLocking <> AccountPeriodLock.NoLock Then
            msgServ.ShowMessage("${res:Global.Error.AccountPeriodIsLocked}")
            Return New SaveErrorException("${res:Global.AccountPeriodIsLocked}")
          ElseIf Not glAble.JournalEntry Is Nothing Then
            Dim glDateLocking As AccountPeriodLock = AccountPeriod.GetLockingForDate(glAble.JournalEntry.DocDate)
            If glDateLocking <> AccountPeriodLock.NoLock Then
              msgServ.ShowMessage("${res:Global.Error.AccountPeriodIsLocked}")
              Return New SaveErrorException("${res:Global.AccountPeriodIsLocked}")
            End If
          End If
        ElseIf TypeOf newEntity Is JournalEntry Then
          'JV
          Dim jv As JournalEntry = CType(newEntity, JournalEntry)
          Dim docDateLocking As AccountPeriodLock = AccountPeriod.GetLockingForDate(jv.DocDate)
          If docDateLocking <> AccountPeriodLock.NoLock Then
            msgServ.ShowMessage("${res:Global.Error.AccountPeriodIsLocked}")
            Return New SaveErrorException("${res:Global.AccountPeriodIsLocked}")
          Else
            Dim glDateLocking As AccountPeriodLock = AccountPeriod.GetLockingForDate(jv.DocDate)
            If glDateLocking <> AccountPeriodLock.NoLock Then
              msgServ.ShowMessage("${res:Global.Error.AccountPeriodIsLocked}")
              Return New SaveErrorException("${res:Global.AccountPeriodIsLocked}")
            End If
          End If
        Else
          'ไม่มี GL
          Dim ty As Type = CType(newEntity, Object).GetType
          Dim pi As System.Reflection.PropertyInfo = ty.GetProperty("DocDate")
          Dim docDate As Date = Date.MinValue
          If Not pi Is Nothing Then
            Dim d As Object = pi.GetValue(newEntity, Nothing)
            If IsDate(d) Then
              docDate = CDate(d)
            End If
          End If

          'HACK by Pla <--- Good!
          If TypeOf newEntity Is Banking Then
            docDate = CType(newEntity, Banking).Docdate
          End If

          If Not docDate.Equals(Date.MinValue) Then
            Dim docDateLocking As AccountPeriodLock = AccountPeriod.GetLockingForDate(docDate)
            If docDateLocking = AccountPeriodLock.AllLock Then
              msgServ.ShowMessage("${res:Global.Error.AccountPeriodIsLocked}")
                Return New SaveErrorException("${res:Global.AccountPeriodIsLocked}")
            End If
          End If

        End If
        '-------------------End Check Locking Period-------------------

        If Not canDeleteWithLog OrElse saveError Is Nothing Then
          saveError = newEntity.Delete
          If Not IsNumeric(saveError.Message) Then
            If Not saveError.Params Is Nothing AndAlso saveError.Params.Length > 0 Then
              msgServ.ShowMessageFormatted(saveError.Message, saveError.Params)
            Else
              msgServ.ShowMessage(saveError.Message)
            End If
          End If
        End If
        Return saveError
      Catch ex As SqlException
        Return New SaveErrorException(ex.ToString)
      Catch ex As Exception
        Return New SaveErrorException(ex.ToString)
      Finally

      End Try
    End Function
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
        Return 4
      End Get
    End Property
#End Region


  End Class
End Namespace
