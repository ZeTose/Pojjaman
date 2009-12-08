Imports Longkong.Pojjaman.Gui.XmlForms
Imports Longkong.Core.Properties
Imports Longkong.Core.Services
Imports Longkong.Core.AddIns.Codons
Imports Longkong.Core.AddIns
Imports System.IO
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Configuration
Imports System.Data.SqlClient
Imports Longkong.Pojjaman.Gui.Panels
Namespace Longkong.Pojjaman.Gui.Dialogs
    Public Class PanelDialog
        Inherits Form

#Region "Members"
        Private m_control As UserControl
#End Region

#Region "Constructors"
        Public Sub New(ByVal theControl As UserControl)
            InitializeComponent()
            m_control = theControl
            If TypeOf m_control Is MapDialog Then
                AddHandler m_control.Resize, AddressOf ControlResize
            Else
                Me.ClientSize = m_control.ClientSize
                m_control.Dock = DockStyle.Fill
            End If
            m_control.Location = New Point(0, 0)
            Debug.WriteLine(m_control.Size)
            'm_control.Dock = DockStyle.Fill
            Me.Controls.Add(theControl)
            Me.Text = m_control.Text
        End Sub
#End Region

#Region "Properties"
        Public ReadOnly Property Control() As UserControl
            Get
                Return m_control
            End Get
        End Property
#End Region

#Region "Methods"
        Private Sub ControlResize(ByVal sender As Object, ByVal e As System.EventArgs)
            Me.ClientSize = m_control.ClientSize
        End Sub
        Protected Sub InitializeComponent()
            '
            'PanelDialog
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(552, 414)
            Me.KeyPreview = True
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "PanelDialog"
            Me.ShowInTaskbar = False
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen

        End Sub
        Protected Overrides Sub OnKeyUp(ByVal e As System.Windows.Forms.KeyEventArgs)
            If e.KeyCode = Keys.Enter Then
                'If TypeOf Me.ActiveControl Is TextBox Then
                '    Dim tb As TextBox = DirectCast(Me.ActiveControl, TextBox)
                '    If tb.Multiline AndAlso e.Alt Then
                '        Dim pos As Integer = tb.SelectionStart
                '        If tb.SelectionLength > 0 Then
                '            tb.Text = tb.Text.Remove(tb.SelectionStart, tb.SelectionLength)
                '        End If
                '        tb.SelectionStart = pos
                '        tb.Text = tb.Text.Insert(tb.SelectionStart, Microsoft.VisualBasic.Constants.vbCrLf)
                '        tb.SelectionStart = pos + Len(Microsoft.VisualBasic.Constants.vbCrLf)
                '        tb.ScrollToCaret()
                '        e.Handled = False
                '        MyBase.OnKeyUp(e)
                '        Return
                '    End If
                'End If
                e.Handled = True
                SendKeys.Send("{Tab}")
            Else
                e.Handled = False
                MyBase.OnKeyUp(e)
            End If
        End Sub

#End Region

    End Class
End Namespace

