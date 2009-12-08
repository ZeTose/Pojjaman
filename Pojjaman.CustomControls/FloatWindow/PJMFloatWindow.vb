Imports System
Imports System.Diagnostics
Imports System.Drawing
Imports System.Reflection
Imports System.Windows.Forms
Imports System.Runtime.InteropServices

Namespace Longkong.Pojjaman.Gui.Components
    Public Class PJMFloatWindow
        Inherits AbstractFloatWindow

#Region "Members"
        Private m_activecontrol As Control
        Private m_endOffset As Integer
        Private m_startOffset As Integer
        Private m_workingScreen As Rectangle
#End Region

#Region "Constructors"
        Public Sub New(ByVal parentForm As Form, ByVal control As UserControl, ByVal activeControl As Control)
            MyBase.New(parentForm, control, activeControl)
            MyBase.Controls.Add(control)
            Me.m_drawingSize = New Size(300, 300)
            Me.SetLocation()
        End Sub
#End Region

    End Class
End Namespace

