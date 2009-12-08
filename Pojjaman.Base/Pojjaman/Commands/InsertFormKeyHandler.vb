Imports Longkong.Core.AddIns.Codons
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Gui
Imports Longkong.Pojjaman.Gui.Dialogs
Namespace Longkong.Pojjaman.Commands
    Public Class InsertFormKeyHandler
        Inherits AbstractCommand

        Public Overloads Overrides Sub Run()
            '[Assembly].LoadFrom(Path.Combine(HttpRuntime.ClrInstallDirectory, "Microsoft.VisualBasic.dll"))
            Application.AddMessageFilter(New FormKeyHandler)
        End Sub

    End Class

    Public Class FormKeyHandler
        Implements IMessageFilter
        Const keyPressedMessage As Integer = 256
        Const leftMouseButtonDownMessage As Integer = 514

#Region "Constructors"
        Public Sub New()
        End Sub
#End Region

#Region "Methods"
        Public Function PreFilterMessage(ByRef m As Message) As Boolean Implements IMessageFilter.PreFilterMessage
            If Not (m.Msg = keyPressedMessage) AndAlso Not (m.Msg = leftMouseButtonDownMessage) Then
                Return False
            End If
            If WorkbenchSingleton.Workbench.ActiveWorkbenchWindow Is Nothing OrElse WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ActiveViewContent Is Nothing Then
                Return False
            End If
            If Not TypeOf WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ActiveViewContent Is IKeyReceiver Then
                Return False
            End If
            If m.Msg = leftMouseButtonDownMessage Then
                Return False
            End If
            Dim keyPressed As Keys = CType(m.WParam.ToInt32, Keys) Or Control.ModifierKeys
            If keyPressed = Keys.F1 Then
                Return False
            End If
            If keyPressed = Keys.Escape Then
                Return True
            End If
            Dim receiver As IKeyReceiver = CType(WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ActiveViewContent, IKeyReceiver)
            If Not (receiver Is Nothing) Then
                Return receiver.ProcessKey(keyPressed)
            End If
            Return Not ((System.Windows.Forms.Control.ModifierKeys And Keys.Alt) = Keys.Alt) AndAlso Not ((System.Windows.Forms.Control.ModifierKeys And Keys.Control) = Keys.Control)
        End Function
#End Region

    End Class

#Region "IKeyReceiver"
    Public Interface IKeyReceiver
        Function ProcessKey(ByVal keyPressed As Keys) As Boolean
    End Interface
#End Region

End Namespace
