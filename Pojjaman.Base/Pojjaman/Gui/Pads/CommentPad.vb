Imports System.Windows.Forms
Imports System.ComponentModel.Design
Imports Longkong.Core.Services
Imports Longkong.Core.Properties
Imports System.Drawing
Imports Longkong.Pojjaman.Services
Imports System.IO
Imports System.Reflection
Imports System.Xml
Imports Microsoft.Win32
Imports System.Text
Imports System.Threading
Imports Longkong.Pojjaman.FormDisplayBinding

Namespace Longkong.Pojjaman.Gui.Pads
    Public Class CommentPad
        Inherits UserControl
        Friend WithEvents RichTextBox1 As System.Windows.Forms.RichTextBox

        Private Sub InitializeComponent()
            Me.RichTextBox1 = New System.Windows.Forms.RichTextBox
            Me.SuspendLayout()
            '
            'RichTextBox1
            '
            Me.RichTextBox1.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(192, Byte))
            Me.RichTextBox1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.RichTextBox1.Location = New System.Drawing.Point(0, 0)
            Me.RichTextBox1.Name = "RichTextBox1"
            Me.RichTextBox1.Size = New System.Drawing.Size(304, 280)
            Me.RichTextBox1.TabIndex = 0
            Me.RichTextBox1.Text = ""
            '
            'CommentPad
            '
            Me.Controls.Add(Me.RichTextBox1)
            Me.Name = "CommentPad"
            Me.Size = New System.Drawing.Size(304, 280)
            Me.ResumeLayout(False)

        End Sub
    End Class
End Namespace

