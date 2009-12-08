Imports System
Imports System.Diagnostics
Imports System.Drawing
Imports System.Reflection
Imports System.Windows.Forms
Imports System.Runtime.InteropServices

Namespace Longkong.Pojjaman.Gui.Components
    Public Class FloatWindow
        Inherits Form

#Region "Members"
        Private m_Child As Control
        Friend WithEvents Panel1 As System.Windows.Forms.Panel
        Private m_OwnerTopMost As Boolean ' TRUE if parent form has TopMost property set (special handling of showing/hiding tooltip necessary)
#End Region

#Region "Public Methods"
        Public Sub ShowAtControl(ByVal vControl As Control, ByVal mySize As Size)
            If Not IsHidden Then
                Exit Sub
            End If
            Dim pt As Point = vControl.Parent.PointToScreen(vControl.Location)
            pt.Y += vControl.Height
            Me.Bounds = New Rectangle(pt, mySize)
            ShowForm(vControl)
            Me.Update()
        End Sub
#End Region

#Region "Constructors and destructors"
        Public Sub New(ByVal vChild As Control)
            MyBase.New()
            InitializeComponent()

            m_Child = vChild
            ' create a form without border or anything
            'Me.BackColor = Color.White
            Me.FormBorderStyle = FormBorderStyle.None
            Me.StartPosition = FormStartPosition.Manual
            Me.ShowInTaskbar = False
            Me.Panel1.Controls.Add(m_Child)
            m_Child.Dock = DockStyle.Fill
            HideForm()
        End Sub
        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
            GC.SuppressFinalize(Me)
            m_Child = Nothing
            Me.Owner = Nothing
            MyBase.Dispose(disposing)
        End Sub

        Protected Overrides Sub Finalize()
            Me.Dispose(False)
            MyBase.Finalize()
        End Sub
#End Region

#Region "Win32"
        Private Declare Function ShowWindow Lib "user32" Alias "ShowWindow" (ByVal hwnd As Integer _
        , ByVal nCmdShow As Integer) As Integer
        Private Declare Function SetWindowPos Lib "user32" (ByVal hwnd As Integer _
        , ByVal hWndInsertAfter As Integer, ByVal x As Integer _
        , ByVal y As Integer, ByVal cx As Integer, ByVal cy As Integer _
        , ByVal wFlags As Integer) As Integer

        Private Const SW_SHOWNA As Integer = 8
        Private Const SWP_ASYNCWINDOWPOS As Integer = &H4000
        Private Const SWP_DEFERERASE As Integer = &H2000
        Private Const SWP_DRAWFRAME As Integer = SWP_FRAMECHANGED
        Private Const SWP_FRAMECHANGED As Integer = &H20
        Private Const SWP_HIDEWINDOW As Integer = &H80
        Private Const SWP_NOACTIVATE As Integer = &H10
        Private Const SWP_NOCOPYBITS As Integer = &H100
        Private Const SWP_NOMOVE As Integer = &H2
        Private Const SWP_NOOWNERZORDER As Integer = &H200
        Private Const SWP_NOREDRAW As Integer = &H8
        Private Const SWP_NOREPOSITION As Integer = SWP_NOOWNERZORDER
        Private Const SWP_NOSENDCHANGING As Integer = &H400
        Private Const SWP_NOSIZE As Integer = &H1
        Private Const SWP_NOZORDER As Integer = &H4
        Private Const SWP_SHOWWINDOW As Integer = &H40
        Private Const HWND_BOTTOM As Integer = 1
        Private Const HWND_BROADCAST As Integer = &HFFFF&
        Private Const HWND_DESKTOP As Integer = 0
        Private Const HWND_MESSAGE As Integer = -3
        Private Const HWND_NOTOPMOST As Integer = -2
        Private Const HWND_TOP As Integer = 0
        Private Const HWND_TOPMOST As Integer = -1
#End Region

#Region "Constructors"

#End Region

#Region "private methods"
        Private Sub ShowForm(ByVal vControl As Control)
            If Me.Owner Is Nothing Then
                ' get parent form and set it as owner
                Me.Owner = vControl.FindForm
                m_OwnerTopMost = Me.Owner.TopMost
            End If

            ' must make win32 api calls since the .NET framework can't display a non-active window
            If m_OwnerTopMost Then
                ' special treating if parent form is topmost (otherwise the tooltip would be behind the form)
                ShowWindow(Me.Handle.ToInt32, SW_SHOWNA)
                SetWindowPos(Me.Handle.ToInt32, HWND_TOPMOST, 0, 0, 0, 0, SWP_NOMOVE Or SWP_NOSIZE Or SWP_NOACTIVATE)
                SetWindowPos(Me.Owner.Handle.ToInt32, Me.Handle.ToInt32, 0, 0, 0, 0, SWP_NOMOVE Or SWP_NOSIZE Or SWP_NOACTIVATE)
            Else
                ShowWindow(Me.Handle.ToInt32, SW_SHOWNA)
            End If

        End Sub

        Private Sub HideForm()
            ' hide form: put it where it is invisible (don't set Me.Visible to false in order to suppress
            ' reactivation of the owner window)
            Me.Bounds = New Rectangle(-2, -2, 1, 1)
            If m_OwnerTopMost Then
                ' restore former topmost window
                SetWindowPos(Me.Owner.Handle.ToInt32, HWND_TOPMOST, 0, 0, 0, 0, SWP_NOMOVE Or SWP_NOSIZE Or SWP_NOACTIVATE)
            End If
        End Sub

        Private ReadOnly Property IsHidden() As Boolean
            Get
                If Me.Width = 2 AndAlso Me.Height = 2 Then Return True
                ' returns TRUE if the tooltip was hidden using HideForm
                If Me.Width = 1 AndAlso Me.Height = 1 Then Return True
                Return False
            End Get
        End Property
#End Region
        Friend WithEvents btnOK As System.Windows.Forms.Button
        Friend WithEvents btnCancel As System.Windows.Forms.Button

        Private Sub InitializeComponent()
            Me.Panel1 = New System.Windows.Forms.Panel
            Me.btnOK = New System.Windows.Forms.Button
            Me.btnCancel = New System.Windows.Forms.Button
            Me.SuspendLayout()
            '
            'Panel1
            '
            Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.Panel1.Location = New System.Drawing.Point(0, 0)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(456, 296)
            Me.Panel1.TabIndex = 0
            '
            'btnOK
            '
            Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnOK.Location = New System.Drawing.Point(288, 304)
            Me.btnOK.Name = "btnOK"
            Me.btnOK.TabIndex = 0
            Me.btnOK.Text = "OK"
            '
            'btnCancel
            '
            Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnCancel.Location = New System.Drawing.Point(368, 304)
            Me.btnCancel.Name = "btnCancel"
            Me.btnCancel.TabIndex = 1
            Me.btnCancel.Text = "Cancel"
            '
            'FloatWindow
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.Khaki
            Me.ClientSize = New System.Drawing.Size(456, 334)
            Me.Controls.Add(Me.Panel1)
            Me.Controls.Add(Me.btnCancel)
            Me.Controls.Add(Me.btnOK)
            Me.Name = "FloatWindow"
            Me.ResumeLayout(False)

        End Sub

        Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
            Me.HideForm()
        End Sub
    End Class
End Namespace

