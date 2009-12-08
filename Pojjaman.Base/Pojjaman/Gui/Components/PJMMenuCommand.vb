Imports Longkong.Core.AddIns.Conditions
Imports Longkong.Core.AddIns.Codons
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Services
Namespace Longkong.Pojjaman.Gui.Components
    Public Class PJMMenuCommand
        Inherits CommandBarButton
        Implements IStatusUpdate

#Region "Members"
        Private m_caller As Object
        Private m_conditionCollection As ConditionCollection
        Private m_description As String
        Private m_localizedText As String
        Private m_menuCommand As ICommand
        Private Shared m_stringParserService As StringParserService
#End Region

#Region "Constructors"
        Shared Sub New()
            PJMMenuCommand.m_stringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
        End Sub
        Public Sub New(ByVal conditionCollection As ConditionCollection, ByVal caller As Object, ByVal label As String)
            MyBase.New(PJMMenuCommand.m_stringParserService.Parse(label))
            Me.m_description = String.Empty
            Me.m_localizedText = String.Empty
            Me.m_menuCommand = Nothing
            Me.m_caller = caller
            Me.m_conditionCollection = conditionCollection
            Me.m_localizedText = label
            Me.UpdateStatus()
        End Sub
        Public Sub New(ByVal caller As Object, ByVal label As String, ByVal handler As EventHandler)
            MyBase.New(PJMMenuCommand.m_stringParserService.Parse(label), handler)
            Me.m_description = String.Empty
            Me.m_localizedText = String.Empty
            Me.m_menuCommand = Nothing
            Me.m_caller = caller
            Me.m_localizedText = label
            Me.UpdateStatus()
        End Sub
        Public Sub New(ByVal conditionCollection As ConditionCollection, ByVal caller As Object, ByVal label As String, ByVal menuCommand As ICommand)
            MyBase.New(PJMMenuCommand.m_stringParserService.Parse(label))
            Me.m_description = String.Empty
            Me.m_localizedText = String.Empty
            Me.m_menuCommand = Nothing
            Me.m_caller = caller
            Me.m_conditionCollection = conditionCollection
            Me.m_localizedText = label
            Me.m_menuCommand = menuCommand
            If TypeOf menuCommand Is Longkong.Pojjaman.Commands.EditEntity Then
                Dim e As Longkong.Pojjaman.Commands.EditEntity = CType(menuCommand, Longkong.Pojjaman.Commands.EditEntity)
                If e.Entity.ToLower.IndexOf(".rpt") >= 0 Then
                    Try
                    Me.m_localizedText &= " [" & BusinessLogic.Entity.GetIdFromClassName(e.Entity.Substring(32, e.Entity.Length - 32)) & "]"
                    Catch ex As Exception

                    End Try
                End If
            End If
            Me.UpdateStatus()
        End Sub
        Public Sub New(ByVal conditionCollection As ConditionCollection, ByVal caller As Object, ByVal label As String, ByVal handler As EventHandler)
            MyBase.New(PJMMenuCommand.m_stringParserService.Parse(label), handler)
            Me.m_description = String.Empty
            Me.m_localizedText = String.Empty
            Me.m_menuCommand = Nothing
            Me.m_caller = caller
            Me.m_conditionCollection = conditionCollection
            Me.m_localizedText = label
            Me.UpdateStatus()
        End Sub
#End Region

#Region "Properties"
        Public Property Command() As ICommand
            Get
                Return Me.m_menuCommand
            End Get
            Set(ByVal value As ICommand)
                Me.m_menuCommand = value
                Me.UpdateStatus()
            End Set
        End Property
        Public Property Description() As String
            Get
                Return Me.m_description
            End Get
            Set(ByVal value As String)
                Me.m_description = value
            End Set
        End Property
        Public Overrides Property IsEnabled() As Boolean
            Get
                Dim enable As Boolean = True
                If (Not Me.m_conditionCollection Is Nothing) Then
                    Dim action1 As ConditionFailedAction = Me.m_conditionCollection.GetCurrentConditionFailedAction(Me.m_caller)
                    enable = (enable And (action1 <> ConditionFailedAction.Disable))
                End If
                If ((Not Me.m_menuCommand Is Nothing) AndAlso TypeOf Me.m_menuCommand Is IMenuCommand) Then
                    enable = (enable And CType(Me.m_menuCommand, IMenuCommand).IsEnabled)
                End If
                Return enable
            End Get
            Set(ByVal value As Boolean)
                MyBase.IsEnabled = value
            End Set
        End Property
        Public Overrides Property IsVisible() As Boolean
            Get
                Dim visible As Boolean = MyBase.IsVisible
                If (Not Me.m_conditionCollection Is Nothing) Then
                    Dim action1 As ConditionFailedAction = Me.m_conditionCollection.GetCurrentConditionFailedAction(Me.m_caller)
                    visible = (visible And (action1 <> ConditionFailedAction.Exclude))
                End If
                Return visible
            End Get
            Set(ByVal value As Boolean)
                MyBase.IsVisible = value
            End Set
        End Property
#End Region

#Region "Methods"
        Protected Overrides Sub OnClick(ByVal e As EventArgs)
            MyBase.OnClick(e)
            If (Not Me.m_menuCommand Is Nothing) Then
                Me.m_menuCommand.Run()
            End If
        End Sub
#End Region

#Region "IStatusUpdate"
        Public Sub UpdateStatus() Implements IStatusUpdate.UpdateStatus
            If (Not Me.m_conditionCollection Is Nothing) Then
                Dim action1 As ConditionFailedAction = Me.m_conditionCollection.GetCurrentConditionFailedAction(Me.m_caller)
                Dim visible As Boolean = (action1 <> ConditionFailedAction.Exclude)
                If (MyBase.IsVisible <> visible) Then
                    MyBase.IsVisible = visible
                End If
                Dim enable As Boolean = (action1 <> ConditionFailedAction.Disable)
                If (MyBase.IsEnabled <> enable) Then
                    MyBase.IsEnabled = enable
                End If
            End If
            If ((Not Me.m_menuCommand Is Nothing) AndAlso TypeOf Me.m_menuCommand Is IMenuCommand) Then
                Dim enable As Boolean = (Me.IsEnabled And CType(Me.m_menuCommand, IMenuCommand).IsEnabled)
                If (MyBase.IsEnabled <> enable) Then
                    MyBase.IsEnabled = enable
                End If
            End If
            MyBase.Text = PJMMenuCommand.m_stringParserService.Parse(Me.m_localizedText)
        End Sub
#End Region

    End Class
End Namespace

