Imports Longkong.Core
Imports Longkong.Core.AddIns
Imports Longkong.Core.AddIns.Codons
Imports Longkong.Core.Properties
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Services
Imports Longkong.Pojjaman.Gui
Imports Longkong.Pojjaman.Gui.Pads
Imports System.IO
Imports System.Windows.Forms
Imports ICSharpCode.TextEditor
Imports ICSharpCode.TextEditor.Document
Imports ICSharpCode.TextEditor.Actions
Imports System.Drawing
Namespace Longkong.Pojjaman.DefaultEditor.Gui.Editor
    Public Class PojjamanTextAreaControl
        Inherits TextEditorControl

#Region "Members"
        'Friend codeCompletionWindow As CodeCompletionWindow
        'Private errorDrawer As ErrorDrawer
        'Private insightWindow As InsightWindow
        'Private quickClassBrowserPanel As QuickClassBrowserPanel
        Private Shared ReadOnly m_contextMenuPath As String
        Private Shared ReadOnly m_editActionsPath As String
        Private Shared ReadOnly m_formatingStrategyPath As String
#End Region

#Region "Constructors"
        Shared Sub New()
            PojjamanTextAreaControl.m_contextMenuPath = "/SharpDevelop/ViewContent/DefaultTextEditor/ContextMenu"
            PojjamanTextAreaControl.m_editActionsPath = "/AddIns/DefaultTextEditor/EditActions"
            PojjamanTextAreaControl.m_formatingStrategyPath = "/AddIns/DefaultTextEditor/Formater"
        End Sub
        Public Sub New()
            GenerateEditActions()
        End Sub
#End Region

#Region "Methods"
        Public Overrides Sub OptionsChanged()
            MyBase.OptionsChanged()
        End Sub
        Private Sub GenerateEditActions()
            Try
                For Each action As IEditAction In CType(AddInTreeSingleton.AddInTree.GetTreeNode(PojjamanTextAreaControl.m_editActionsPath).BuildChildItems(Me).ToArray(GetType(IEditAction)), IEditAction())
                    Dim keysArray1 As Keys() = action.Keys
                    For i As Integer = 0 To keysArray1.Length - 1
                        Dim keys1 As Keys = keysArray1(i)
                        Me.editactions.Item(keys1) = action
                    Next
                Next
            Catch ex As TreePathNotFoundException
                Console.WriteLine((PojjamanTextAreaControl.m_editActionsPath & " doesn't exists in the AddInTree"))
            End Try
        End Sub
        Protected Overrides Sub InitializeTextAreaControl(ByVal newControl As TextAreaControl)
            MyBase.InitializeTextAreaControl(newControl)
            Dim myMenuService As MenuService = CType(ServiceManager.Services.GetService(GetType(MenuService)), MenuService)
            newControl.ContextMenu = myMenuService.CreateContextMenu(Me, PojjamanTextAreaControl.m_contextMenuPath)
            AddHandler newControl.TextArea.KeyEventHandler, New ICSharpCode.TextEditor.KeyEventHandler(AddressOf Me.HandleKeyPress)
            AddHandler newControl.SelectionManager.SelectionChanged, New EventHandler(AddressOf Me.SelectionChanged)
            AddHandler newControl.Document.DocumentChanged, New DocumentEventHandler(AddressOf Me.DocumentChanged)
            AddHandler newControl.TextArea.ClipboardHandler.CopyText, New CopyTextEventHandler(AddressOf Me.ClipboardHandlerCopyText)
            AddHandler newControl.MouseWheel, New MouseEventHandler(AddressOf Me.TextAreaMouseWheel)
            newControl.DoHandleMousewheel = False

            'AddHandler newControl.TextArea.IconBarMargin.Painted, New MarginPaintEventHandler(AddressOf Me.PaintIconBarBreakPoints)
            'AddHandler newControl.TextArea.IconBarMargin.MouseDown, New MarginMouseEventHandler(AddressOf Me.IconBarMouseDown)
            'AddHandler newControl.Caret.PositionChanged, New EventHandler(AddressOf Me.CaretPositionChanged)

        End Sub
        Private Function HandleKeyPress(ByVal ch As Char) As Boolean
            'Todo: implement me!!
        End Function
        Private Sub SelectionChanged(ByVal sender As Object, ByVal e As EventArgs)
            CType(WorkbenchSingleton.Workbench, PojjamanWorkbench).UpdateToolbars()
        End Sub
        Private Sub TextAreaMouseWheel(ByVal sender As Object, ByVal e As MouseEventArgs)
            Dim myTextAreaControl As TextAreaControl = CType(sender, TextAreaControl)
            'If (((Not Me.insightWindow Is Nothing) AndAlso Not Me.insightWindow.IsDisposed) AndAlso Me.insightWindow.Visible) Then
            '    Me.insightWindow.HandleMouseWheel(e)
            'Else
            '    If (((Not Me.codeCompletionWindow Is Nothing) AndAlso Not Me.codeCompletionWindow.IsDisposed) AndAlso Me.codeCompletionWindow.Visible) Then
            '        Me.codeCompletionWindow.HandleMouseWheel(e)
            '    Else
            '        myTextAreaControl.HandleMouseWheel(e)
            '    End If
            'End If
            'Todo:
            myTextAreaControl.HandleMouseWheel(e)
        End Sub
        Private Sub ClipboardHandlerCopyText(ByVal sender As Object, ByVal e As CopyTextEventArgs)
            SideBarView.PutInClipboardRing(e.Text)
        End Sub
        Private Sub DocumentChanged(ByVal sender As Object, ByVal e As DocumentEventArgs)
            CType(WorkbenchSingleton.Workbench, PojjamanWorkbench).UpdateToolbars()
        End Sub
        'Protected Overridable Sub IconBarMouseDown(ByVal iconBar As AbstractMargin, ByVal mousepos As Point, ByVal mouseButtons As MouseButtons)
        '    Dim lineIndex As Integer = iconBar.TextArea.TextView.GetLogicalLine(mousepos)
        '    If ((lineIndex >= 0) AndAlso (lineIndex < iconBar.TextArea.Document.TotalNumberOfLines)) Then
        '        Dim myDebuggerService As DebuggerService = CType(ServiceManager.Services.GetService(GetType(DebuggerService)), DebuggerService)
        '        If ((Not myDebuggerService Is Nothing) AndAlso myDebuggerService.CurrentDebugger.SupportsExecutionControl) Then
        '            myDebuggerService.ToggleBreakpointAt(MyBase.FileName, (lineIndex + 1), 0)
        '            iconBar.TextArea.Refresh(iconBar)
        '        End If
        '    End If
        'End Sub
        'Protected Overridable Sub PaintIconBarBreakPoints(ByVal iconBar As AbstractMargin, ByVal g As Graphics, ByVal rect As Rectangle)
        '    Dim service1 As DebuggerService = CType(ServiceManager.Services.GetService(GetType(DebuggerService)), DebuggerService)
        '    If (Not service1 Is Nothing) Then
        '        SyncLock service1.Breakpoints
        '            Dim breakpoint1 As Breakpoint
        '            For Each breakpoint1 In service1.Breakpoints
        '                Try
        '                    If (Path.GetFullPath(breakpoint1.FileName) Is Path.GetFullPath(MyBase.FileName)) Then
        '                        Dim num1 As Integer = iconBar.TextArea.Document.GetVisibleLine((breakpoint1.LineNumber - 1))
        '                        Dim num2 As Integer = ((num1 * iconBar.TextArea.TextView.FontHeight) - iconBar.TextArea.VirtualTop.Y)
        '                        If ((num2 >= rect.Y) AndAlso (num2 <= rect.Bottom)) Then
        '                            CType(iconBar, IconBarMargin).DrawBreakpoint(g, num2, breakpoint1.IsEnabled)
        '                        End If
        '                    End If
        '                    Continue()
        '                Catch exception1 As Exception
        '                    Continue()
        '                End Try
        '            Next
        '        End SyncLock
        '    End If
        'End Sub
#End Region

    End Class
End Namespace