Imports Longkong.Core.AddIns.Codons
Imports Longkong.Core.Properties
Imports Longkong.Core.Services
Imports System.IO
Imports ICSharpCode.TextEditor
Namespace Longkong.Pojjaman.DefaultEditor.Gui.Editor
    Public Class ErrorDrawer

#Region "Members"
        Private m_errors As ArrayList
        Private m_textEditor As TextEditorControl
#End Region

#Region "Constructos"
        Public Sub New(ByVal textEditor As TextEditorControl)
            Me.m_errors = New ArrayList
            Me.m_textEditor = textEditor
            'Dim myTaskService As TaskService = CType(ServiceManager.Services.GetService(GetType(TaskService)), TaskService)
            'AddHandler myTaskService.TasksChanged, New EventHandler(AddressOf Me.SetErrors)
            AddHandler textEditor.FileNameChanged, New EventHandler(AddressOf Me.SetErrors)
        End Sub
#End Region

#Region "Methods"
        Private Sub ClearErrors()
            Dim markers As ArrayList = Me.m_textEditor.Document.MarkerStrategy.TextMarker
            Dim markersToremove As ArrayList
            For i As Integer = 0 To markers.Count - 1
                If TypeOf markers(i) Is VisualError Then
                    markersToremove.Add(markers(i))
                End If
            Next
            For Each marker As Object In markersToremove
                markers.Remove(marker)
            Next
        End Sub
        Private Sub SetErrors(ByVal sender As Object, ByVal e As EventArgs)
            Me.ClearErrors()
            'Dim myTaskService As TaskService = CType(ServiceManager.Services.GetService(GetType(TaskService)), TaskService)
            'For Each myTask As Task In myTaskService.Tasks
            '    If ((((task1.FileName Is Nothing) OrElse (task1.FileName.Length = 0)) OrElse ((task1.Column < 0) OrElse (Not Path.GetFullPath(task1.FileName).ToLower Is Path.GetFullPath(Me.textEditor.FileName).ToLower))) OrElse ((task1.TaskType <> TaskType.Warning) AndAlso (task1.TaskType <> TaskType.Error))) Then
            '        Continue()
            '    End If
            '    If ((task1.Line >= 0) AndAlso (task1.Line < Me.textEditor.Document.TotalNumberOfLines)) Then
            '        Dim segment1 As LineSegment = Me.textEditor.Document.GetLineSegment(task1.Line)
            '        If (Not segment1.Words Is Nothing) Then
            '            Dim num1 As Integer = (segment1.Offset + task1.Column)
            '            Dim word1 As TextWord
            '            For Each word1 In segment1.Words
            '                If ((task1.Column >= word1.Offset) AndAlso (task1.Column < (word1.Offset + word1.Length))) Then
            '                    Me.m_textEditor.Document.MarkerStrategy.TextMarker.Add(New VisualError(num1, word1.Length, task1.Description, (task1.TaskType = TaskType.Error)))
            '                    Exit For
            '                End If
            '            Next
            '        End If
            '    End If
            'Next
            Me.m_textEditor.Refresh()
        End Sub
#End Region

    End Class
End Namespace