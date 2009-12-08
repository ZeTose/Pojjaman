Imports System
Imports System.Diagnostics
Imports System.Drawing
Imports System.Reflection
Imports System.Windows.Forms
Imports System.Runtime.InteropServices

Namespace Longkong.Pojjaman.Gui.Components
    Public MustInherit Class AbstractFloatWindow
        Inherits Form

#Region "Members"
        Protected m_control As UserControl
        Protected m_drawingSize As Size

        Private m_activeControl As Control
        Private m_parentForm As Form
        Private m_workingScreen As Rectangle

        Public Shared ReadOnly SW_SHOWNA As Integer = 8

#End Region

#Region "Constructors"
        Protected Sub New(ByVal parentForm As Form, ByVal control As UserControl, ByVal activeControl As Control)
            Me.m_workingScreen = Screen.GetWorkingArea(parentForm)
            Me.m_parentForm = parentForm
            Me.m_control = control
            Me.m_activeControl = activeControl
            Me.SetLocation()
            MyBase.StartPosition = FormStartPosition.Manual
            MyBase.FormBorderStyle = FormBorderStyle.None
            MyBase.ShowInTaskbar = False
            MyBase.Size = New Size(1, 1)
        End Sub
#End Region

#Region "Methods"
        Protected Overridable Sub CaretOffsetChanged(ByVal sender As Object, ByVal e As EventArgs)
        End Sub
        Protected Overrides Sub OnClosed(ByVal e As EventArgs)
            MyBase.OnClosed(e)
            RemoveHandler Me.m_parentForm.LocationChanged, New EventHandler(AddressOf Me.ParentFormLocationChanged)
            'RemoveHandler Me.m_activeControl.LostFocus, New EventHandler(AddressOf Me.HostControlLostFocus)
            'RemoveHandler Me.m_control.Resize, New EventHandler(AddressOf Me.ParentFormLocationChanged)
            MyBase.Dispose()
        End Sub
        Private Sub ParentFormLocationChanged(ByVal sender As Object, ByVal e As EventArgs)
            Me.SetLocation()
        End Sub
        Public Overridable Function ProcessKeyEvent(ByVal ch As Char) As Boolean
            Return False
        End Function
        Protected Overridable Function ProcessTextAreaKey(ByVal keyData As Keys) As Boolean
            If MyBase.Visible Then
                Dim keys1 As Keys = keyData
                If (keys1 = Keys.Escape) Then
                    MyBase.Close()
                    Return True
                End If
            End If
            Return False
        End Function
        Protected Overridable Sub SetLocation()
            Dim pt As Point = Me.m_control.PointToScreen(m_activeControl.Location)
            Dim ptn As New Point(pt.X, pt.Y + Me.m_activeControl.Height)
            Dim drawRect As New Rectangle(ptn, Me.m_drawingSize)
            If Not Me.m_workingScreen.Contains(drawRect) Then
                'เกินไปทางขวา
                If (drawRect.Right > Me.m_workingScreen.Right) Then
                    drawRect.X = (Me.m_workingScreen.Right - drawRect.Width)
                End If
                'เกินไปทางซ้าย
                If (drawRect.Left < Me.m_workingScreen.Left) Then
                    drawRect.X = Me.m_workingScreen.Left
                End If
                'ขึ้นบน
                If (drawRect.Top < Me.m_workingScreen.Top) Then
                    drawRect.Y = Me.m_workingScreen.Top
                End If
                'ลงล่าง
                If (drawRect.Bottom > Me.m_workingScreen.Bottom) Then
                    'TODO:
                    drawRect.Y = ((drawRect.Y - drawRect.Height) - Me.m_activeControl.Height)
                    If (drawRect.Bottom > Me.m_workingScreen.Bottom) Then
                        drawRect.Y = (Me.m_workingScreen.Bottom - drawRect.Height)
                    End If
                End If
            End If
            MyBase.Bounds = drawRect
        End Sub

        Public Sub ShowCompletionWindow()
            MyBase.Owner = Me.ParentForm
            MyBase.Enabled = True
            AbstractFloatWindow.ShowWindow(MyBase.Handle, AbstractFloatWindow.SW_SHOWNA)
            Me.m_control.Focus()
            If (Not Me.m_parentForm Is Nothing) Then
                AddHandler Me.m_parentForm.LocationChanged, New EventHandler(AddressOf Me.ParentFormLocationChanged)
            End If
            'AddHandler Me.m_control.ActiveTextAreaControl.VScrollBar.ValueChanged, New EventHandler(AddressOf Me.ParentFormLocationChanged)
            'AddHandler Me.control.ActiveTextAreaControl.HScrollBar.ValueChanged, New EventHandler(AddressOf Me.ParentFormLocationChanged)
            'AddHandler Me.m_activeControl.ProcessDialogKey, AddressOf Me.ProcessTextAreaKey
            'AddHandler Me.control.ActiveTextAreaControl.Caret.PositionChanged, New EventHandler(AddressOf Me.CaretOffsetChanged)
            AddHandler Me.m_activeControl.LostFocus, New EventHandler(AddressOf Me.HostControlLostFocus)
            AddHandler Me.m_control.Resize, New EventHandler(AddressOf Me.ParentFormLocationChanged)
        End Sub
        <DllImport("user32")> _
        Public Shared Function ShowWindow(ByVal hWnd As IntPtr, ByVal nCmdShow As Integer) As Integer
        End Function
        Protected Sub HostControlLostFocus(ByVal sender As Object, ByVal e As EventArgs)
            If (Not Me.m_activeControl.Focused AndAlso Not MyBase.ContainsFocus) Then
                MyBase.Close()
            End If
        End Sub
#End Region

    End Class
End Namespace

