Imports Longkong.Core.AddIns.Conditions
Imports Longkong.Core.AddIns.Codons
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Services
Namespace Longkong.Pojjaman.Gui.Components
    Public Class PJMMenuCheckBox
        Inherits CommandBarCheckBox
        Implements IStatusUpdate

#Region "Members"
        Private m_caller As Object
        Private m_conditionCollection As conditionCollection
        Private m_description As String
        Protected m_localizedText As String
        Private m_menuCommand As ICheckableMenuCommand
        Private Shared m_stringParserService As stringParserService
#End Region

#Region "Constructors"
        Shared Sub New()
            PJMMenuCheckBox.m_stringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
        End Sub
        Public Sub New(ByVal conditionCollection As ConditionCollection, ByVal caller As Object, ByVal label As String)
            MyBase.New(PJMMenuCheckBox.m_stringParserService.Parse(label))
            Me.m_description = String.Empty
            Me.m_localizedText = String.Empty
            Me.m_caller = caller
            Me.m_conditionCollection = conditionCollection
            Me.m_localizedText = label
            Me.UpdateStatus()
        End Sub
        Public Sub New(ByVal conditionCollection As ConditionCollection, ByVal caller As Object, ByVal label As String, ByVal menuCommand As ICheckableMenuCommand)
            MyBase.New(PJMMenuCheckBox.m_stringParserService.Parse(label))
            Me.m_description = String.Empty
            Me.m_localizedText = String.Empty
            Me.m_menuCommand = menuCommand
            Me.m_caller = caller
            Me.m_conditionCollection = conditionCollection
            Me.m_localizedText = label
            Me.UpdateStatus()
        End Sub
#End Region

#Region "Properties"
        Public Property Description() As String
            Get
                Return Me.m_description
            End Get
            Set(ByVal value As String)
                Me.m_description = value
            End Set
        End Property
        Public Property Command() As ICheckableMenuCommand
            Get
                Return Me.m_menuCommand
            End Get
            Set(ByVal value As ICheckableMenuCommand)
                Me.m_menuCommand = value
                Me.UpdateStatus()
            End Set
        End Property
#End Region

#Region "Methods"
        Protected Overrides Sub OnClick(ByVal e As EventArgs)
            MyBase.OnClick(e)
            If (Not Me.m_menuCommand Is Nothing) Then
                Me.m_menuCommand.IsChecked = MyBase.IsChecked
            End If
        End Sub
#End Region

#Region "IStatusUpdate"
        Public Overridable Sub UpdateStatus() Implements IStatusUpdate.UpdateStatus
            If (Not Me.m_conditionCollection Is Nothing) Then
                Dim action1 As ConditionFailedAction = Me.m_conditionCollection.GetCurrentConditionFailedAction(Me.m_caller)
                Me.IsEnabled = (action1 <> ConditionFailedAction.Disable)
                Me.IsVisible = (action1 <> ConditionFailedAction.Exclude)
            End If
            MyBase.Text = PJMMenuCheckBox.m_stringParserService.Parse(Me.m_localizedText)
            If (Not Me.m_menuCommand Is Nothing) Then
                MyBase.IsChecked = Me.m_menuCommand.IsChecked
            End If
        End Sub
#End Region

    End Class
End Namespace

