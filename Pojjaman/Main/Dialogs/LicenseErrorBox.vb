Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Imports System.Reflection
Imports System.Resources
Namespace Pojjaman
    Public Class LicenseErrorBox
        Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "
        'Form overrides dispose to clean up the component list.
        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing Then
                If Not (components Is Nothing) Then
                    components.Dispose()
                End If
            End If
            MyBase.Dispose(disposing)
        End Sub
        'Required by the Windows Form Designer
        Private components As System.ComponentModel.IContainer
#End Region

#Region "Constructors"
        Public Sub New(ByVal e As Exception)
            Me.New()
            Me.TextBox1.Text = e.ToString
        End Sub
        Public Sub New()
            MyBase.New()

            InitializeComponent()
            Me.TextBox1.Text = "Please Register Pojjaman."
            Dim resources As New ResourceManager("BitmapResources", [Assembly].GetEntryAssembly)
            Me.picBranded.Image = CType(resources.GetObject("Branded"), Bitmap)
            Me.picLogo.Image = CType(resources.GetObject("LongkongLogo"), Bitmap)

        End Sub
        Friend WithEvents picBranded As System.Windows.Forms.PictureBox
        Friend WithEvents picLogo As System.Windows.Forms.PictureBox
        Friend WithEvents btnOK As System.Windows.Forms.Button
        Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
        Private Sub InitializeComponent()
            Me.picBranded = New System.Windows.Forms.PictureBox
            Me.picLogo = New System.Windows.Forms.PictureBox
            Me.btnOK = New System.Windows.Forms.Button
            Me.TextBox1 = New System.Windows.Forms.TextBox
            Me.SuspendLayout()
            '
            'picBranded
            '
            Me.picBranded.Location = New System.Drawing.Point(8, 8)
            Me.picBranded.Name = "picBranded"
            Me.picBranded.Size = New System.Drawing.Size(456, 280)
            Me.picBranded.TabIndex = 0
            Me.picBranded.TabStop = False
            '
            'picLogo
            '
            Me.picLogo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.picLogo.Location = New System.Drawing.Point(480, 8)
            Me.picLogo.Name = "picLogo"
            Me.picLogo.Size = New System.Drawing.Size(88, 88)
            Me.picLogo.TabIndex = 1
            Me.picLogo.TabStop = False
            '
            'btnOK
            '
            Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnOK.Location = New System.Drawing.Point(488, 104)
            Me.btnOK.Name = "btnOK"
            Me.btnOK.TabIndex = 2
            Me.btnOK.Text = "OK"
            '
            'TextBox1
            '
            Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
            Me.TextBox1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.TextBox1.Location = New System.Drawing.Point(16, 16)
            Me.TextBox1.Multiline = True
            Me.TextBox1.Name = "TextBox1"
            Me.TextBox1.ReadOnly = True
            Me.TextBox1.Size = New System.Drawing.Size(432, 168)
            Me.TextBox1.TabIndex = 3
            Me.TextBox1.Text = ""
            '
            'LicenseErrorBox
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
            Me.ClientSize = New System.Drawing.Size(576, 294)
            Me.Controls.Add(Me.TextBox1)
            Me.Controls.Add(Me.btnOK)
            Me.Controls.Add(Me.picLogo)
            Me.Controls.Add(Me.picBranded)
            Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "LicenseErrorBox"
            Me.ShowInTaskbar = False
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            Me.Text = "Please Register Pojjaman"
            Me.TopMost = True
            Me.ResumeLayout(False)

        End Sub
#End Region

    End Class
End Namespace
