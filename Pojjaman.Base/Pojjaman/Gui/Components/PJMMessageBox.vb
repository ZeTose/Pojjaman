Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Namespace Longkong.Pojjaman.Gui.Components
    Public Class PJMMessageBox
        Inherits Form

#Region "Members"
        Private m_buttons As Button()
        Private m_buttontexts As String()
        Private m_header As String
        Private m_retvalue As Integer
        Private m_text As String
#End Region

#Region "Constructors"
        Public Sub New(ByVal header As String, ByVal [text] As String, ByVal ParamArray buttontexts As String())
            Me.m_retvalue = -1
            Dim service1 As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
            Me.m_header = service1.Parse(header)
            Me.m_text = service1.Parse(text)
            Me.m_buttontexts = New String(buttontexts.Length - 1) {}
            Dim num1 As Integer
            For num1 = 0 To buttontexts.Length - 1
                Me.m_buttontexts(num1) = service1.Parse(buttontexts(num1))
            Next num1
            Me.InitializeComponents()
        End Sub
#End Region

#Region "Methods"
        Private Sub ButtonClick(ByVal sender As Object, ByVal e As EventArgs)
            For i As Integer = 0 To Me.m_buttons.Length - 1
                If (sender Is Me.m_buttons(i)) Then
                    Me.m_retvalue = i
                    Exit For
                End If
            Next
            MyBase.DialogResult = DialogResult.OK
        End Sub
        Private Sub InitializeComponents()
            Me.m_buttons = New Button(Me.m_buttontexts.Length - 1) {}
            Dim num1 As Integer
            For i As Integer = 0 To Me.m_buttontexts.Length - 1
                Me.m_buttons(i) = New Button
                Me.m_buttons(i).FlatStyle = FlatStyle.System
            Next
            Dim label1 As New Label
            label1.FlatStyle = FlatStyle.System
            MyBase.SuspendLayout()
            Me.Text = Me.m_header
            MyBase.FormBorderStyle = FormBorderStyle.FixedDialog
            MyBase.MinimizeBox = False
            MyBase.MaximizeBox = False
            MyBase.Owner = CType(WorkbenchSingleton.Workbench, Form)
            MyBase.StartPosition = FormStartPosition.CenterParent
            MyBase.Icon = Nothing
            MyBase.ShowInTaskbar = False
            Dim num2 As Integer = CInt((320 - (Me.m_buttontexts.Length * 100)) / 2)
            Dim num3 As Integer
            For num3 = 0 To Me.m_buttontexts.Length - 1
                Me.m_buttons(num3).Anchor = (AnchorStyles.Right Or AnchorStyles.Bottom)
                Me.m_buttons(num3).Location = New Point(((num2 + (num3 * 100)) + 3), 50)
                Me.m_buttons(num3).Size = New Size(96, 24)
                Me.m_buttons(num3).TabIndex = num3
                Me.m_buttons(num3).Text = Me.m_buttontexts(num3)
                AddHandler Me.m_buttons(num3).Click, New EventHandler(AddressOf Me.ButtonClick)
            Next num3
            label1.Location = New Point(8, 8)
            label1.Text = Me.Text
            label1.Size = New Size(312, 50)
            MyBase.AcceptButton = Me.m_buttons((Me.m_buttons.Length - 1))
            MyBase.CancelButton = Me.m_buttons((Me.m_buttons.Length - 1))
            Me.m_buttons((Me.m_buttons.Length - 1)).Select()
            MyBase.Controls.AddRange(Me.m_buttons)
            MyBase.Controls.Add(label1)
            Me.AutoScaleBaseSize = New Size(5, 13)
            MyBase.ClientSize = New Size(320, 80)
            MyBase.ResumeLayout(False)
        End Sub
        Public Function ShowMessageBox() As Integer
            MyBase.ShowDialog()
            Return Me.m_retvalue
        End Function
#End Region
    End Class
End Namespace
