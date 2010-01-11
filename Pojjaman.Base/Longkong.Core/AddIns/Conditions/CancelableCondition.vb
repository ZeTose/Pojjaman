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
  Public Class CancelableCondition
    Inherits AbstractCondition

#Region "Members"
    <XmlMemberAttributeAttribute("cancelable", IsRequired:=True)> _
    Private m_cancelable As Boolean
#End Region

#Region "Constructors"
    Public Sub New()
    End Sub
#End Region

#Region "Properties"
    Public Property Cancelable() As Boolean
      Get
        Return Me.m_cancelable
      End Get
      Set(ByVal value As Boolean)
        Me.m_cancelable = value
      End Set
    End Property
#End Region

#Region "Methods"
    Public Overrides Function IsValid(ByVal caller As Object) As Boolean
      If (((Not WorkbenchSingleton.Workbench Is Nothing) AndAlso (Not WorkbenchSingleton.Workbench.ActiveWorkbenchWindow Is Nothing)) AndAlso (Not WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ActiveViewContent Is Nothing)) Then
        If TypeOf WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ActiveViewContent Is ISimpleEntityPanel Then
          Try
            If TypeOf CType(WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ActiveViewContent, ISimpleEntityPanel).Entity Is ICancelable Then
              If CType(CType(WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ActiveViewContent, ISimpleEntityPanel).Entity, ICancelable).CanCancel Then
                Return m_cancelable
              End If
            End If
          Catch ex As Exception
            Return Not m_cancelable
          End Try
        End If
      End If
      Return Not m_cancelable
    End Function
#End Region

  End Class

  <Condition()> _
  Public Class DeletableCondition
    Inherits AbstractCondition

#Region "Members"
    <XmlMemberAttributeAttribute("deletable", IsRequired:=True)> _
    Private m_deletable As Boolean
#End Region

#Region "Constructors"
    Public Sub New()
    End Sub
#End Region

#Region "Properties"
    Public Property Deletable() As Boolean
      Get
        Return Me.m_deletable
      End Get
      Set(ByVal value As Boolean)
        Me.m_deletable = value
      End Set
    End Property
#End Region

#Region "Methods"
    Public Overrides Function IsValid(ByVal caller As Object) As Boolean
      If (((Not WorkbenchSingleton.Workbench Is Nothing) AndAlso (Not WorkbenchSingleton.Workbench.ActiveWorkbenchWindow Is Nothing)) AndAlso (Not WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ActiveViewContent Is Nothing)) Then
        If TypeOf WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ActiveViewContent Is ISimpleEntityPanel Then
          Try
            If TypeOf CType(WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ActiveViewContent, ISimpleEntityPanel).Entity Is IDeletable Then
              If CType(CType(WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ActiveViewContent, ISimpleEntityPanel).Entity, IDeletable).CanDelete Then
                If TypeOf CType(WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ActiveViewContent, ISimpleEntityPanel).Entity Is User Then
                  Dim secSrv As SecurityService = CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService)
                  If Not secSrv Is Nothing AndAlso Not secSrv.CurrentUser Is Nothing Then
                    If secSrv.CurrentUser.Id <> 0 And secSrv.CurrentUser.Id = CType(WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ActiveViewContent, ISimpleEntityPanel).Entity.Id Then
                      Return Not m_deletable
                    End If
                  End If
                End If
                Return m_deletable
              End If
            End If
          Catch ex As Exception
            Return Not m_deletable
          End Try
        End If
      End If
      Return Not m_deletable
    End Function
#End Region

  End Class

  <Condition()> _
  Public Class IsReferencedCondition
    Inherits AbstractCondition

#Region "Members"
    <XmlMemberAttributeAttribute("isreferenced", IsRequired:=True)> _
    Private m_isreferenced As Boolean
#End Region

#Region "Constructors"
    Public Sub New()
    End Sub
#End Region

#Region "Properties"
    Public Property IsReferenced() As Boolean
      Get
        Return Me.m_isreferenced
      End Get
      Set(ByVal value As Boolean)
        Me.m_isreferenced = value
      End Set
    End Property
#End Region

#Region "Methods"
    Public Overrides Function IsValid(ByVal caller As Object) As Boolean
      If (((Not WorkbenchSingleton.Workbench Is Nothing) AndAlso (Not WorkbenchSingleton.Workbench.ActiveWorkbenchWindow Is Nothing)) AndAlso (Not WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ActiveViewContent Is Nothing)) Then
        If TypeOf WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ActiveViewContent Is ISimpleEntityPanel Then
          Try
            Dim isreffed As Boolean = (CType(CType(WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ActiveViewContent, ISimpleEntityPanel).Entity, SimpleBusinessEntityBase).IsReferenced)
            Dim isreffed2 As Boolean = (CType(CType(WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ActiveViewContent, ISimpleEntityPanel).Entity, SimpleBusinessEntityBase).IsReferedFrom)
            If isreffed OrElse isreffed2 Then
              Return m_isreferenced
            End If
          Catch ex As Exception
            Return Not m_isreferenced
          End Try
        End If
      End If
      Return Not m_isreferenced
    End Function
#End Region

  End Class

  <Condition()> _
  Public Class CanBeAttachedCondition
    Inherits AbstractCondition

#Region "Members"
    <XmlMemberAttributeAttribute("canbeattached", IsRequired:=True)> _
    Private m_canBeAttached As Boolean
#End Region

#Region "Constructors"
    Public Sub New()
    End Sub
#End Region

#Region "Properties"
    Public Property CanBeAttached() As Boolean
      Get
        Return Me.m_canBeAttached
      End Get
      Set(ByVal value As Boolean)
        Me.m_canBeAttached = value
      End Set
    End Property
#End Region

#Region "Methods"
    Public Overrides Function IsValid(ByVal caller As Object) As Boolean
      If (((Not WorkbenchSingleton.Workbench Is Nothing) AndAlso (Not WorkbenchSingleton.Workbench.ActiveWorkbenchWindow Is Nothing)) AndAlso (Not WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ActiveViewContent Is Nothing)) Then
        If TypeOf WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ActiveViewContent Is ISimpleEntityPanel Then
          Try
            If (CType(CType(WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ActiveViewContent, ISimpleEntityPanel).Entity, SimpleBusinessEntityBase).Originated) _
            AndAlso CBool(Longkong.Pojjaman.BusinessLogic.Configuration.GetConfig("UseAttachment")) Then
              Return m_canBeAttached
            End If
          Catch ex As Exception
            Return Not m_canBeAttached
          End Try
        End If
      End If
      Return Not m_canBeAttached
    End Function
#End Region

  End Class


End Namespace
