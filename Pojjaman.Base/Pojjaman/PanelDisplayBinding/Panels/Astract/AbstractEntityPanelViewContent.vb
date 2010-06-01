Imports System.IO
Imports Longkong.Pojjaman.Gui.Panels
Imports Longkong.Pojjaman.Gui
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Imports System.ComponentModel
Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.Commands
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Properties
Imports System.Reflection

Namespace Longkong.Pojjaman.Gui
  Public Class AbstractEntityPanelViewContent
    Inherits AbstractBaseEntityPanelViewContent
    Implements IViewContent, IBasketCollectable, IEditable, IClipboardHandler, IKeyReceiver _
    , ISecurityValidatable, IPrintable

#Region "Members"
    Private m_panelName As String
    Private m_fileName As String
    Private m_isDirty As Boolean
    Private m_titleName As String
    Private m_untitledName As String
    Private m_securityService As SecurityService
    Private m_messageService As MessageService
    Private m_StringParserService As StringParserService
    Private m_statusbarService As IStatusBarService
    Private m_accessTale As DataTable
#End Region

#Region "Events"
    Public Event FileNameChanged As EventHandler
#End Region

#Region "Constructrs"
    Public Sub New()
      Me.m_untitledName = String.Empty
      Me.m_titleName = Nothing
      Me.m_fileName = Nothing
      Me.m_isDirty = False
      If TypeOf Me Is ISimpleEntityPanel Then
        AddHandler CType(Me, ISimpleEntityPanel).EntityPropertyChanged, AddressOf Me.PropertyChanged
      End If
    End Sub
    Private Sub AbstractEntityPanelViewContent_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
      Dim fullName As String = Me.GetType.FullName
      'm_accessTale = Access.GetFormAccessTable(fullName)
      'If Not FormSecurityValidator Is Nothing AndAlso Not m_accessTale Is Nothing Then
      '    LoopSecurity(Me)
      'End If
      LoopControl(Me)
    End Sub
#End Region

#Region "Methods"
    Public Sub LoopSecurity(ByVal thisCtrl As Control)
      For Each ctrl As Control In thisCtrl.Controls
        Dim rows As DataRow() = m_accessTale.Select("form_controlname='" & ctrl.Name & "'")
        If rows.Length = 1 Then
          Dim row As DataRow = rows(0)
          Dim accessId As Integer = CInt(row("form_accessID"))
          Dim requiredLevel As Integer = CInt(row("form_requiredlevel"))
          Dim action As FailAction = CType([Enum].Parse(GetType(FailAction), row("form_failaction").ToString), FailAction)
          Me.FormSecurityValidator.SetAccessId(ctrl, accessId)
          Me.FormSecurityValidator.SetFailAction(ctrl, action)
          Me.FormSecurityValidator.SetRequiredLevel(ctrl, requiredLevel)
        End If
        LoopSecurity(ctrl)
      Next
    End Sub
    Public Sub LoopControl(ByVal thisCtr As Control)
      Dim ctr As Control
      For Each ctr In thisCtr.Controls
        If TypeOf ctr Is TextBox Then
          RemoveHandler ctr.GotFocus, AddressOf ControlFocus
          AddHandler ctr.GotFocus, AddressOf ControlFocus
        End If
        If Not TypeOf ctr Is DataGrid Then
          LoopControl(ctr)
        End If
      Next
    End Sub
    Private Sub ControlFocus(ByVal sender As Object, ByVal e As EventArgs)
      'WorkbenchSingleton.Workbench.RedrawEditComponents()
    End Sub
    Private Sub PropertyChanged(ByVal sender As Object, ByVal e As EventArgs)
      Me.IsDirty = True
    End Sub
    Protected Overridable Sub OnDirtyChanged(ByVal e As EventArgs)
      RaiseEvent DirtyChanged(Me, e)
    End Sub
    Protected Overridable Sub OnFileNameChanged(ByVal e As EventArgs)
      RaiseEvent FileNameChanged(Me, e)
    End Sub
    Protected Overridable Sub OnSaved(ByVal e As SaveEventArgs)
      RaiseEvent Saved(Me, e)
    End Sub
    Protected Overridable Sub OnSaving(ByVal e As EventArgs)
      RaiseEvent Saving(Me, e)
    End Sub
    Protected Overridable Sub OnTitleNameChanged(ByVal e As EventArgs)
      RaiseEvent TitleNameChanged(Me, e)
    End Sub
    Protected Overridable Sub SetTitleAndFileName(ByVal fileName As String)
      Me.TitleName = Path.GetFileName(fileName)
      Me.FileName = fileName
      Me.IsDirty = False
    End Sub
#End Region

#Region "IViewContent"
    Public Event DirtyChanged(ByVal sender As Object, ByVal e As System.EventArgs) Implements IViewContent.DirtyChanged
    Public Event TitleNameChanged(ByVal sender As Object, ByVal e As System.EventArgs) Implements IViewContent.TitleNameChanged
    Public Event Saved(ByVal sender As Object, ByVal e As SaveEventArgs) Implements IViewContent.Saved
    Public Event Saving(ByVal sender As Object, ByVal e As System.EventArgs) Implements IViewContent.Saving
    <Browsable(False)> _
    Public Overridable ReadOnly Property CreateAsSubViewContent() As Boolean Implements IViewContent.CreateAsSubViewContent
      Get
        Return False
      End Get
    End Property
    <Browsable(False)> _
    Public Overridable Property FileName() As String Implements IViewContent.FileName
      Get
        Return Me.m_fileName
      End Get
      Set(ByVal value As String)
        Me.m_fileName = value
        Me.OnFileNameChanged(EventArgs.Empty)
      End Set
    End Property
    <Browsable(False)> _
    Public Overridable Property IsDirty() As Boolean Implements IViewContent.IsDirty
      Get
        Return Me.m_isDirty
      End Get
      Set(ByVal value As Boolean)
        If value Then
          If Not WorkbenchSingleton.Workbench.ActiveWorkbenchWindow Is Nothing Then
            If Not WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ViewContent Is Nothing Then
              If TypeOf WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ViewContent Is ISimpleListPanel Then
                Dim panel As ISimpleListPanel = CType(WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ViewContent, ISimpleListPanel)
                If Not panel.Entity Is Nothing Then
                  Dim fcn As String = panel.Entity.Namespace & "." & panel.Entity.CodonName
                  If TypeOf panel.Entity Is TreeBaseEntity Then
                    fcn = panel.Entity.FullClassName
                  End If
                  Dim accessID As Integer = Longkong.Pojjaman.BusinessLogic.Entity.GetAccessIdFromFullClassName(fcn)
                  If accessID = 0 Then
                    Me.m_isDirty = value
                    Me.OnDirtyChanged(EventArgs.Empty)
                    Return
                  End If
                  Dim secSrv As SecurityService = CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService)
                  Dim level As Integer = secSrv.GetAccess(accessID)
                  Dim checkString As String = BinaryHelper.DecToBin(level, 5)
                  checkString = BinaryHelper.RevertString(checkString)
                  If Not CBool(checkString.Substring(1, 1)) Then
                    Return
                  End If
                End If
              End If
            End If
          End If
        End If
        Me.m_isDirty = value
        If Not WorkbenchSingleton.Workbench.ActiveWorkbenchWindow Is Nothing Then
          Dim wbw As IWorkbenchWindow = WorkbenchSingleton.Workbench.ActiveWorkbenchWindow
          If Not wbw.ActiveViewContent Is Nothing Then
            If TypeOf wbw.ActiveViewContent Is IAuxTab Then
              Dim obj As IDirtyAble = CType(wbw.ActiveViewContent, IAuxTab).AuxEntity
              If Not obj Is Nothing Then
                obj.IsDirty = value
              End If
            ElseIf TypeOf wbw.ActiveViewContent Is ISimpleEntityPanel Then
              Dim obj As ISimpleEntity = CType(wbw.ActiveViewContent, ISimpleEntityPanel).Entity
              If Not obj Is Nothing AndAlso TypeOf obj Is IDirtyAble Then
                CType(obj, IDirtyAble).IsDirty = value
              End If
            End If
          End If
        End If
        Me.OnDirtyChanged(EventArgs.Empty)
      End Set
    End Property
    <Browsable(False)> _
    Public Overridable ReadOnly Property IsReadOnly() As Boolean Implements IViewContent.IsReadOnly
      Get
        Return False
      End Get
    End Property
    <Browsable(False)> _
    Public Overridable ReadOnly Property IsUntitled() As Boolean Implements IViewContent.IsUntitled
      Get
        Return (Me.m_titleName Is Nothing)
      End Get
    End Property
    <Browsable(False)> _
    Public Overridable ReadOnly Property IsViewOnly() As Boolean Implements IViewContent.IsViewOnly
      Get
        Return False
      End Get
    End Property
    Public Sub LoadFile(ByVal fileName As String) Implements IViewContent.Load
      Return
    End Sub
    Public Overridable Overloads Sub Save() Implements IViewContent.Save
      OnSaving(New EventArgs)
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      Dim currentUserId As Integer = currentUserId
      If SecurityService.CurrentUser Is Nothing Then
        msgServ.ShowMessage("${res:Global.Error.NoUser}")
        Me.OnSaved(New SaveEventArgs(False))
        SecurityService.UpdateAccessTable()
        WorkbenchSingleton.Workbench.RedrawEditComponents()
        Return
      End If
      currentUserId = SecurityService.CurrentUser.Id
      If Not Me.WorkbenchWindow.SubViewContents Is Nothing AndAlso Me.WorkbenchWindow.SubViewContents.Count > 0 Then
        For Each content As IBaseViewContent In Me.WorkbenchWindow.SubViewContents
          If TypeOf content Is IValidatable Then
            Dim validator As Gui.Components.PJMTextboxValidator = CType(content, IValidatable).FormValidator
            If Not validator Is Nothing Then
              If Not validator.ValidationSummary Is Nothing AndAlso validator.ValidationSummary.Length > 0 Then
                msgServ.ShowMessage(validator.ValidationSummary)
                Me.OnSaved(New SaveEventArgs(False))
                SecurityService.UpdateAccessTable()
                WorkbenchSingleton.Workbench.RedrawEditComponents()
                Return
              End If
            End If
          End If
        Next
      End If

      Dim t As Date = Now

      If TypeOf Me Is IHasTreeTable Then
        Dim hasTree As IHasTreeTable = CType(Me, IHasTreeTable)
        If Not hasTree.CanSaveBy Is Nothing Then
          Dim errorMessage As String = hasTree.CanSaveBy.SaveTreeTable(hasTree.TreeTable).Message
          If Not IsNumeric(errorMessage) Then 'Todo
            msgServ.ShowMessage(errorMessage)
            Me.OnSaved(New SaveEventArgs(False))
          Else
            msgServ.ShowMessage("${res:Global.Info.DataSaved}")
            Me.IsDirty = False
            Me.OnSaved(New SaveEventArgs(True))
          End If
        End If
      ElseIf TypeOf Me Is ISimpleListPanel Then
        Dim myEntity As ISimpleEntity = CType(Me, ISimpleListPanel).SelectedEntity
        If myEntity Is Nothing Then
          msgServ.ShowMessage("${res:Global.Error.EntityIsNull}")
          Me.OnSaved(New SaveEventArgs(False))
          SecurityService.UpdateAccessTable()
          WorkbenchSingleton.Workbench.RedrawEditComponents()
          Return
        End If

        '-------------------Check AccountPeriod-------------------
        If TypeOf myEntity Is ICheckPeriod Then
          Dim docDate As Date = CType(myEntity, ICheckPeriod).DocDate
          If Not AccountPeriod.ValidDate(docdate) Then
            msgServ.ShowMessage("${res:Global.Error.CannotSavePeriodIsClosed}")
            Me.OnSaved(New SaveEventArgs(False))
            SecurityService.UpdateAccessTable()
            WorkbenchSingleton.Workbench.RedrawEditComponents()
            Return
          End If
        End If
        '-------------------End Check AccountPeriod-------------------

        If TypeOf myEntity Is IGLAble Then
          'มี GL
          Dim glAble As IGLAble = CType(myEntity, IGLAble)
          Dim docDateLocking As AccountPeriodLock = AccountPeriod.GetLockingForDate(glAble.Date)
          If docDateLocking <> AccountPeriodLock.NoLock Then
            msgServ.ShowMessage("${res:Global.Error.AccountPeriodIsLocked}")
            Me.OnSaved(New SaveEventArgs(False))
            SecurityService.UpdateAccessTable()
            WorkbenchSingleton.Workbench.RedrawEditComponents()
            Return
          ElseIf Not glAble.JournalEntry Is Nothing Then
            Dim glDateLocking As AccountPeriodLock = AccountPeriod.GetLockingForDate(glAble.JournalEntry.DocDate)
            If glDateLocking <> AccountPeriodLock.NoLock Then
              msgServ.ShowMessage("${res:Global.Error.AccountPeriodIsLocked}")
              Me.OnSaved(New SaveEventArgs(False))
              SecurityService.UpdateAccessTable()
              WorkbenchSingleton.Workbench.RedrawEditComponents()
              Return
            End If
          End If
        ElseIf TypeOf myEntity Is JournalEntry Then
          'JV
          Dim jv As JournalEntry = CType(myEntity, JournalEntry)
          Dim docDateLocking As AccountPeriodLock = AccountPeriod.GetLockingForDate(jv.DocDate)
          If docDateLocking <> AccountPeriodLock.NoLock Then
            msgServ.ShowMessage("${res:Global.Error.AccountPeriodIsLocked}")
            Me.OnSaved(New SaveEventArgs(False))
            SecurityService.UpdateAccessTable()
            WorkbenchSingleton.Workbench.RedrawEditComponents()
            Return
          Else
            Dim glDateLocking As AccountPeriodLock = AccountPeriod.GetLockingForDate(jv.DocDate)
            If glDateLocking <> AccountPeriodLock.NoLock Then
              msgServ.ShowMessage("${res:Global.Error.AccountPeriodIsLocked}")
              Me.OnSaved(New SaveEventArgs(False))
              SecurityService.UpdateAccessTable()
              WorkbenchSingleton.Workbench.RedrawEditComponents()
              Return
            End If
          End If
        Else
          'ไม่มี GL
          Dim ty As Type = CType(myEntity, Object).GetType
          Dim pi As PropertyInfo = ty.GetProperty("DocDate")
          Dim docDate As Date = Date.MinValue
          If Not pi Is Nothing Then
            Dim d As Object = pi.GetValue(myEntity, Nothing)
            If IsDate(d) Then
              docDate = CDate(d)
            End If
          End If

          'HACK by Pla <--- Good!
          If TypeOf myEntity Is Banking Then
            docDate = CType(myEntity, Banking).Docdate
          End If

          If Not docDate.Equals(Date.MinValue) Then
            Dim docDateLocking As AccountPeriodLock = AccountPeriod.GetLockingForDate(docDate)
            If docDateLocking = AccountPeriodLock.AllLock Then
              msgServ.ShowMessage("${res:Global.Error.AccountPeriodIsLocked}")
              Me.OnSaved(New SaveEventArgs(False))
              SecurityService.UpdateAccessTable()
              WorkbenchSingleton.Workbench.RedrawEditComponents()
              Return
            End If
          End If

        End If

        Dim saveError As SaveErrorException = myEntity.Save(currentUserId)
        If Not IsNumeric(saveError.Message) Then  'Todo
          If Not saveError.Params Is Nothing AndAlso saveError.Params.Length > 0 Then
            msgServ.ShowMessageFormatted(saveError.Message, saveError.Params)
          Else
            msgServ.ShowMessage(saveError.Message)
          End If
          Me.OnSaved(New SaveEventArgs(False))
        ElseIf CInt(saveError.Message) = -1 Then
          'code ซ้ำ
          'Todo
          msgServ.ShowMessageFormatted("${res:Global.Error.AlreadyHasThisCode}", New String() {myEntity.Code})
          Me.OnSaved(New SaveEventArgs(False))
        ElseIf CInt(saveError.Message) = -2 Then
          'Status >=3
          'Todo
          msgServ.ShowMessageFormatted("${res:Global.Error.InvalidStatus}", New String() {myEntity.Code})
          Me.OnSaved(New SaveEventArgs(False))
        ElseIf CInt(saveError.Message) = -5 Then
          'ปิดงวดไปแล้ว
          'Todo
          msgServ.ShowMessageFormatted("${res:Global.Error.CannotSavePeriodIsClosed}", New String() {"ใช้เวลา: " & Now.Subtract(t).Seconds.ToString & " วินาที " & myEntity.Code})
          Me.OnSaved(New SaveEventArgs(False))
        Else
          msgServ.ShowMessageFormatted("${res:Global.Info.DataSavedWithCode}", New String() {myEntity.TabPageText})

          Me.IsDirty = False
          Me.OnSaved(New SaveEventArgs(True))
        End If
      ElseIf TypeOf Me Is ISimpleEntityPanel Then
        Dim saveError As SaveErrorException = CType(Me, ISimpleEntityPanel).Entity.Save(currentUserId)
        If Not IsNumeric(saveError.Message) Then 'Todo
          msgServ.ShowMessage(saveError.Message)
          Me.OnSaved(New SaveEventArgs(False))
        Else
          msgServ.ShowMessage("${res:Global.Info.DataSaved}" & "ใช้เวลา: " & Now.Subtract(t).Seconds.ToString & " วินาที ")
          Me.IsDirty = False
          Me.OnSaved(New SaveEventArgs(True))
        End If
      End If
      SecurityService.UpdateAccessTable()
      WorkbenchSingleton.Workbench.RedrawEditComponents()
      GC.Collect()
    End Sub
    Public Overridable Overloads Sub Save(ByVal fileName As String) Implements IViewContent.Save
      Throw New NotImplementedException
    End Sub
    <Browsable(False)> _
    Public Overridable Property TitleName() As String Implements IViewContent.TitleName
      Get
        If Not Me.IsUntitled Then
          Return Me.m_titleName
        End If
        Return Me.m_untitledName
      End Get
      Set(ByVal value As String)
        Me.m_titleName = value
        Me.OnTitleNameChanged(EventArgs.Empty)
      End Set
    End Property
    <Browsable(False)> _
    Public Overridable Property UntitledName() As String Implements IViewContent.UntitledName
      Get
        Return Me.m_untitledName
      End Get
      Set(ByVal value As String)
        Me.m_untitledName = value
      End Set
    End Property
    <Browsable(False)> _
    Public Overridable Property PanelName() As String Implements IViewContent.PanelName
      Get
        Return m_panelName
      End Get
      Set(ByVal Value As String)
        m_panelName = Value
      End Set
    End Property
#End Region

#Region "Overrides"
    Public Overrides Sub Selected()
      If TypeOf Me Is ISimpleListPanel Then
        Dim simpleList As ISimpleListPanel = CType(Me, ISimpleListPanel)
        If TypeOf Me Is IGroupPanel Then
          'CType(Me, IGroupPanel).RefreshData(CType(CType(Me, IGroupPanel).SelectedEntity, TreeBaseEntity))

        ElseIf Not simpleList.SelectedEntity Is Nothing Then
          'simpleList.RefreshData(simpleList.SelectedEntity.Id.ToString)
        End If
        Me.TitleName = Me.StringParserService.Parse(simpleList.Entity.ListPanelTitle)
        If Not Me.WorkbenchWindow Is Nothing Then
          For Each content As Object In Me.WorkbenchWindow.SubViewContents
            If TypeOf content Is AbstractEntityDetailPanelView AndAlso Not content Is Me Then
              If TypeOf CType(content, AbstractEntityDetailPanelView).Entity Is IDisposable Then
                CType(CType(content, AbstractEntityDetailPanelView).Entity, IDisposable).Dispose()
              End If
              Try
                'Undone: เอา Try ออก
                CType(content, AbstractEntityDetailPanelView).Entity = Nothing
              Catch ex As Exception

              End Try
            End If
          Next
        End If
      End If
      GC.Collect()
    End Sub
#End Region

#Region "Properties"
    <Browsable(False)> _
    Public ReadOnly Property StatusBarService() As IStatusBarService
      Get
        If m_statusbarService Is Nothing Then
          m_statusbarService = CType(ServiceManager.Services.GetService(GetType(IStatusBarService)), IStatusBarService)
        End If
        Return m_statusbarService
      End Get
    End Property
    <Browsable(False)> _
    Public ReadOnly Property StringParserService() As StringParserService
      Get
        If m_StringParserService Is Nothing Then
          m_StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
        End If
        Return m_StringParserService
      End Get
    End Property
    <Browsable(False)> _
    Public ReadOnly Property SecurityService() As SecurityService
      Get
        If m_securityService Is Nothing Then
          m_securityService = CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService)
        End If
        Return m_securityService
      End Get
    End Property
    <Browsable(False)> _
    Public ReadOnly Property MessageService() As MessageService
      Get
        If m_messageService Is Nothing Then
          m_messageService = CType(ServiceManager.Services.GetService(GetType(MessageService)), MessageService)
        End If
        Return m_messageService
      End Get
    End Property
#End Region

#Region "IBasketCollectable"
    Public Event EmptyBasket(ByVal items As BusinessLogic.BasketItemCollection) Implements Panels.IBasketCollectable.EmptyBasket
    Public Sub OnEmptyBasket(ByVal items As BusinessLogic.BasketItemCollection)
      RaiseEvent EmptyBasket(items)
    End Sub
    Public Overridable ReadOnly Property BasketItems() As BasketItemCollection Implements Panels.IBasketCollectable.BasketItems
      Get

      End Get
    End Property
    Public Overridable ReadOnly Property ProposedBasketItems() As BasketItemCollection Implements Panels.IBasketCollectable.ProposedBasketItems
      Get

      End Get
    End Property
#End Region

#Region "IEditable"
    Public Overridable ReadOnly Property ClipboardHandler() As IClipboardHandler Implements IEditable.ClipboardHandler
      Get
        Return Me
      End Get
    End Property
    Public Overridable ReadOnly Property EnableRedo() As Boolean Implements IEditable.EnableRedo
      Get
        Return False
      End Get
    End Property
    Public Overridable ReadOnly Property EnableUndo() As Boolean Implements IEditable.EnableUndo
      Get
        Return False
      End Get
    End Property
    Public Overridable Sub Redo() Implements IEditable.Redo

    End Sub
    Public Overridable Property Text1() As String Implements IEditable.Text
      Get

      End Get
      Set(ByVal Value As String)

      End Set
    End Property
    Public Overridable Sub Undo() Implements IEditable.Undo

    End Sub
#End Region

#Region "IClipboardHandler"
    Public Overridable Sub Copy(ByVal sender As Object, ByVal e As System.EventArgs) Implements IClipboardHandler.Copy

    End Sub
    Public Overridable Sub Cut(ByVal sender As Object, ByVal e As System.EventArgs) Implements IClipboardHandler.Cut

    End Sub
    Public Overridable Sub Delete(ByVal sender As Object, ByVal e As System.EventArgs) Implements IClipboardHandler.Delete

    End Sub
    Public Overridable ReadOnly Property EnableCopy() As Boolean Implements IClipboardHandler.EnableCopy
      Get
        Return False
      End Get
    End Property
    Public Overridable ReadOnly Property EnableCut() As Boolean Implements IClipboardHandler.EnableCut
      Get
        Return False
      End Get
    End Property
    Public Overridable ReadOnly Property EnableDelete() As Boolean Implements IClipboardHandler.EnableDelete
      Get
        Return False
      End Get
    End Property
    Public Overridable ReadOnly Property EnablePaste() As Boolean Implements IClipboardHandler.EnablePaste
      Get
        Return False
      End Get
    End Property
    Public Overridable ReadOnly Property EnableSelectAll() As Boolean Implements IClipboardHandler.EnableSelectAll
      Get
        Return False
      End Get
    End Property
    Public Overridable Sub Paste(ByVal sender As Object, ByVal e As System.EventArgs) Implements IClipboardHandler.Paste

    End Sub
    Public Overridable Sub SelectAll(ByVal sender As Object, ByVal e As System.EventArgs) Implements IClipboardHandler.SelectAll

    End Sub
#End Region

#Region "IKeyReceiver"
    Public Overridable Function ProcessKey(ByVal keyPressed As System.Windows.Forms.Keys) As Boolean Implements Commands.IKeyReceiver.ProcessKey
      Select Case keyPressed
        Case Keys.Enter
          If TypeOf Me.ActiveControl Is TextBox Then
            If Me.ActiveControl.Name.ToLower.StartsWith("txt") Then
              If CType(Me.ActiveControl, TextBox).Multiline Then
                Dim tmpIndx As Integer = CType(Me.ActiveControl, TextBox).SelectionStart
                CType(Me.ActiveControl, TextBox).Text = CType(Me.ActiveControl, TextBox).Text.Insert(CType(Me.ActiveControl, TextBox).SelectionStart, vbCrLf)
                CType(Me.ActiveControl, TextBox).SelectionStart = tmpIndx + 2
                Return True
              End If
            End If
          End If
          SendKeys.Send("{tab}")
          Return True
      End Select
      Return False
    End Function
#End Region

#Region "ISecurityValidatable"
    Public Overridable ReadOnly Property FormSecurityValidator() As Components.SecurityValidator Implements Panels.ISecurityValidatable.FormSecurityValidator
      Get

      End Get
    End Property
#End Region

#Region "IPrintable"
    Public Overridable ReadOnly Property PrintDocument() As System.Drawing.Printing.PrintDocument Implements IPrintable.PrintDocument
      Get

      End Get
    End Property
    Public Overridable ReadOnly Property CanPrint() As Boolean Implements IPrintable.CanPrint
      Get
        Return True
      End Get
    End Property
    Public ReadOnly Property PrintDocuments() As System.Collections.ArrayList Implements IPrintable.PrintDocuments
      Get

      End Get
    End Property
#End Region

    Public Property ForceLabel As String Implements IViewContent.ForceLabel

  End Class
End Namespace
