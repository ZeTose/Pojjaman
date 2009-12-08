Imports Longkong.Core.AddIns.Conditions
Imports Longkong.Core.AddIns.Codons
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Services
Namespace Longkong.Pojjaman.Gui.Components
    Public Class PJMMenu
        Inherits CommandBarMenu
        Implements IStatusUpdate

#Region "Members"
        Private m_caller As Object
        Private m_conditionCollection As conditionCollection
        Private m_localizedText As String
        Private Shared m_stringParserService As StringParserService
        Public SubItems As ArrayList
#End Region

#Region "Constructors"
        Shared Sub New()
            PJMMenu.m_stringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
        End Sub
        Public Sub New(ByVal conditionCollection As ConditionCollection, ByVal caller As Object, ByVal [text] As String)
            MyBase.New(PJMMenu.m_stringParserService.Parse(text))
            Me.m_localizedText = String.Empty
            Me.SubItems = New ArrayList
            Me.m_conditionCollection = conditionCollection
            Me.m_caller = caller
            Me.m_localizedText = text
        End Sub
#End Region

#Region "Methods"
        Protected Overrides Sub OnDropDown(ByVal e As EventArgs)
            MyBase.OnDropDown(e)
            Dim obj1 As Object
            For Each obj1 In MyBase.Items
                If TypeOf obj1 Is IStatusUpdate Then
                    CType(obj1, IStatusUpdate).UpdateStatus()
                End If
            Next
        End Sub
#End Region

#Region "IStatusUpdate"
        Public Sub UpdateStatus() Implements IStatusUpdate.UpdateStatus
            If (Not Me.m_conditionCollection Is Nothing) Then
                Dim action1 As ConditionFailedAction = Me.m_conditionCollection.GetCurrentConditionFailedAction(Me.m_caller)
                Me.IsEnabled = (action1 <> ConditionFailedAction.Disable)
                Me.IsVisible = (action1 <> ConditionFailedAction.Exclude)
            End If
            If Me.IsVisible Then
                MyBase.Items.Clear()
                Dim obj1 As Object
                For Each obj1 In Me.SubItems
                    If TypeOf obj1 Is CommandBarItem Then
                        If TypeOf obj1 Is IStatusUpdate Then
                            CType(obj1, IStatusUpdate).UpdateStatus()
                        End If
                        MyBase.Items.Add(CType(obj1, CommandBarItem))
                    Else
                        Dim builder1 As ISubmenuBuilder = CType(obj1, ISubmenuBuilder)
                        MyBase.Items.AddRange(builder1.BuildSubmenu(Me.m_conditionCollection, Me.m_caller))
                    End If
                Next
            End If
            MyBase.Text = PJMMenu.m_stringParserService.Parse(Me.m_localizedText)
        End Sub
#End Region

    End Class
End Namespace

