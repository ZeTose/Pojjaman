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
Imports Longkong.ColorPicker

Namespace Longkong.Pojjaman.Gui.Dialogs
    Public Class ColorPickerDialog
        Inherits Form
        Friend WithEvents btnOK As System.Windows.Forms.Button
        Friend WithEvents btnCancel As System.Windows.Forms.Button
        Friend WithEvents ColorPanel1 As Longkong.ColorPicker.Controls.ColorPanel
        Public Sub New()
            InitializeComponent()
            Dim myResourceService As ResourceService = CType(ServiceManager.Services.GetService(GetType(Longkong.Core.Services.IResourceService)), ResourceService)
            Me.btnOK.Text = myResourceService.GetString("Global.OKButtonText")
            Me.btnCancel.Text = myResourceService.GetString("Global.CancelButtonText")
            Me.Text = myResourceService.GetString("Dialog.ColorPickerDialog.DialogName")
        End Sub
        Public Sub New(ByVal color As Color)
            Me.New()
            Me.ColorPanel1.SelectedColor = color
        End Sub
        Private Sub InitializeComponent()
            Me.ColorPanel1 = New Longkong.ColorPicker.Controls.ColorPanel
            Me.btnOK = New System.Windows.Forms.Button
            Me.btnCancel = New System.Windows.Forms.Button
            Me.SuspendLayout()
            '
            'ColorPanel1
            '
            Me.ColorPanel1.AllowDrop = True
            Me.ColorPanel1.Location = New System.Drawing.Point(0, 0)
            Me.ColorPanel1.Name = "ColorPanel1"
            Me.ColorPanel1.SelectedColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(0, Byte))
            Me.ColorPanel1.Size = New System.Drawing.Size(568, 278)
            Me.ColorPanel1.TabIndex = 0
            '
            'btnOK
            '
            Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnOK.Location = New System.Drawing.Point(576, 8)
            Me.btnOK.Name = "btnOK"
            Me.btnOK.TabIndex = 1
            '
            'btnCancel
            '
            Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnCancel.Location = New System.Drawing.Point(576, 40)
            Me.btnCancel.Name = "btnCancel"
            Me.btnCancel.TabIndex = 2
            '
            'ColorPickerDialog
            '
            Me.AcceptButton = Me.btnOK
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.CancelButton = Me.btnCancel
            Me.ClientSize = New System.Drawing.Size(664, 278)
            Me.Controls.Add(Me.btnCancel)
            Me.Controls.Add(Me.btnOK)
            Me.Controls.Add(Me.ColorPanel1)
            Me.Name = "ColorPickerDialog"
            Me.ShowInTaskbar = False
            Me.ResumeLayout(False)

        End Sub
    End Class
End Namespace

