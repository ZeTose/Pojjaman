Imports System.Windows.Forms
Imports System.ComponentModel
Namespace Longkong.Pojjaman.Gui.ErrorDialogs
    Public Class LoadingError
        Inherits Form

#Region "Members"
        Private button1 As Button
        Private components As Container
        Private label1 As Label
        Private label3 As Label
        Private textBox1 As TextBox
#End Region

#Region "Constructors"
        Public Sub New(ByVal e As Exception)
            Dim flag1 As Boolean
            Me.InitializeComponent()
            Me.textBox1.Text = e.ToString
            MyBase.TopMost = True
            MyBase.StartPosition = FormStartPosition.CenterScreen
            MyBase.FormBorderStyle = FormBorderStyle.FixedDialog
            MyBase.ControlBox = (flag1 = False)
            MyBase.MinimizeBox = (flag1 = flag1)
            MyBase.MaximizeBox = flag1
            MyBase.Icon = Nothing
        End Sub
#End Region

#Region "Methods"
        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing AndAlso (Not Me.components Is Nothing)) Then
                Me.components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub
        Private Sub InitializeComponent()
            Me.components = New Container
            Me.button1 = New Button
            Me.label1 = New Label
            Me.textBox1 = New TextBox
            Me.label3 = New Label
            Me.button1.Location = New Point(152, 184)
            Me.button1.DialogResult = DialogResult.OK
            Me.button1.Size = New Size(75, 23)
            Me.button1.TabIndex = 4
            Me.button1.Text = "OK"
            Me.label1.Location = New Point(8, 8)
            Me.label1.Text = "An error occured while loading Sharp Develop, the execution can't be continued, please reinstall"
            Me.label1.Size = New Size(344, 32)
            Me.label1.TabIndex = 0
            Me.textBox1.Location = New Point(8, 64)
            Me.textBox1.ReadOnly = True
            Me.textBox1.Multiline = True
            Me.textBox1.TabIndex = 3
            Me.textBox1.Size = New Size(344, 112)
            Me.label3.Location = New Point(8, 48)
            Me.label3.Text = "Description:"
            Me.label3.Size = New Size(72, 16)
            Me.label3.TabIndex = 2
            Me.Text = "Loading Error"
            Me.AutoScaleBaseSize = New Size(5, 13)
            MyBase.ClientSize = New Size(360, 213)
            MyBase.Controls.Add(Me.button1)
            MyBase.Controls.Add(Me.textBox1)
            MyBase.Controls.Add(Me.label3)
            MyBase.Controls.Add(Me.label1)
        End Sub
#End Region

    End Class
End Namespace



