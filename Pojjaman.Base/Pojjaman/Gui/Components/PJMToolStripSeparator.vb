Imports Longkong.Core.AddIns.Conditions
Imports Longkong.Core.AddIns.Codons
Imports Longkong.Core.Services
Namespace Longkong.Pojjaman.Gui.Components
  Public Class PJMToolStripSeparator
    Inherits ToolStripSeparator
    Implements IStatusUpdate

#Region "Members"
    Private m_caller As Object
    Private m_conditionCollection As ConditionCollection
#End Region

#Region "Constructors"
    Public Sub New()
    End Sub
    Public Sub New(ByVal conditionCollection As ConditionCollection, ByVal caller As Object)
      Me.m_caller = caller
      Me.m_conditionCollection = conditionCollection
    End Sub
#End Region

#Region "IStatusUpdate"
    Public Sub UpdateStatus() Implements IStatusUpdate.UpdateStatus
      If (Not Me.m_conditionCollection Is Nothing) Then
        Dim action1 As ConditionFailedAction = Me.m_conditionCollection.GetCurrentConditionFailedAction(Me.m_caller)
        Me.Enabled = (action1 <> ConditionFailedAction.Disable)
        Me.Visible = (action1 <> ConditionFailedAction.Exclude)
      End If
    End Sub
#End Region

  End Class
End Namespace

