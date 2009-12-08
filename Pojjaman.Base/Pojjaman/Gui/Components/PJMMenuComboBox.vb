Imports Longkong.Core.AddIns.Conditions
Imports Longkong.Core.AddIns.Codons
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Services
Namespace Longkong.Pojjaman.Gui.Components
    Public Class PJMMenuComboBox
        Inherits CommandBarComboBox
        Implements IStatusUpdate

#Region "Members"
        Private m_id As String
        Private m_caller As Object
        Private m_conditionCollection As ConditionCollection
        Private m_description As String
        Private m_menuCommand As ICommand
        Private Shared m_stringParserService As StringParserService
#End Region

#Region "Constructors"
        Shared Sub New()
            PJMMenuComboBox.m_stringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
        End Sub
        Public Sub New(ByVal id As String, ByVal conditionCollection As ConditionCollection, ByVal caller As Object, ByVal menuCommand As ICommand)
            MyBase.New(String.Empty, New ComboBox)
            Me.m_id = id
            Me.m_description = String.Empty
            Me.m_menuCommand = Nothing
            Me.ComboBox.DropDownStyle = ComboBoxStyle.DropDownList
            AddHandler Me.ComboBox.SelectionChangeCommitted, New EventHandler(AddressOf Me.SelectionChanged)
            Me.m_caller = caller
            Me.m_conditionCollection = conditionCollection
            Me.m_menuCommand = menuCommand
        End Sub

#End Region

#Region "Properties"
        Public ReadOnly Property Id() As String            Get                Return m_id            End Get        End Property
        Public Property Command() As ICommand
            Get
                Return Me.m_menuCommand
            End Get
            Set(ByVal value As ICommand)
                Me.m_menuCommand = value
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
                Dim flag1 As Boolean = True
                If (Not Me.m_conditionCollection Is Nothing) Then
                    Dim action1 As ConditionFailedAction = Me.m_conditionCollection.GetCurrentConditionFailedAction(Me.m_caller)
                    flag1 = (flag1 And (action1 <> ConditionFailedAction.Disable))
                End If
                If ((Not Me.m_menuCommand Is Nothing) AndAlso TypeOf Me.m_menuCommand Is IComboBoxCommand) Then
                    flag1 = (flag1 And CType(Me.m_menuCommand, IComboBoxCommand).IsEnabled)
                End If
                Return flag1
            End Get
            Set(ByVal value As Boolean)
                MyBase.IsEnabled = value
            End Set
        End Property
        Public Overrides Property IsVisible() As Boolean
            Get
                Dim flag1 As Boolean = MyBase.IsVisible
                If (Not Me.m_conditionCollection Is Nothing) Then
                    Dim action1 As ConditionFailedAction = Me.m_conditionCollection.GetCurrentConditionFailedAction(Me.m_caller)
                    flag1 = (flag1 And (action1 <> ConditionFailedAction.Exclude))
                End If
                Return flag1
            End Get
            Set(ByVal value As Boolean)
                MyBase.IsVisible = value
            End Set
        End Property
#End Region

#Region "Methods"
        'Protected Overrides Sub OnClick(ByVal e As EventArgs)
        '    MyBase.OnClick(e)
        '    If (Not Me.m_menuCommand Is Nothing) Then
        '        Me.m_menuCommand.Run()
        '    End If
        'End Sub
        Private Sub SelectionChanged(ByVal sender As Object, ByVal e As EventArgs)
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
        End Sub
#End Region

    End Class
End Namespace

