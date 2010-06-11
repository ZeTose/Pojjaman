Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Imports System.Reflection
Imports System.Resources
Imports System.Net.Mail
Imports System.Net

Namespace Pojjaman
  Public Class ExceptionBox
    Inherits Form

#Region "Members"
    Private WithEvents continueButton As Button
    Private WithEvents reportButton As Button

    Private WithEvents exceptionTextBox As TextBox
    Private WithEvents label As Label
    Private WithEvents label3 As Label
    Private WithEvents pictureBox As PictureBox

    Private exceptionThrown As Exception

#End Region

#Region "Constructors"
    Public Sub New(ByVal e As Exception)
      Me.exceptionThrown = e
      Me.InitializeComponent()
      Me.exceptionTextBox.Text = e.ToString
      Dim resources As New ResourceManager("BitmapResources", [Assembly].GetEntryAssembly)
      Me.pictureBox.Image = CType(resources.GetObject("ErrorReport"), Bitmap)
    End Sub
#End Region

#Region "Methods"
    Private Sub buttonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles reportButton.Click
      Dim f As New ContactForm(Me.exceptionThrown.ToString, "[Pojjaman Error]")
      f.ShowDialog()
    End Sub
    Private Sub continueButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles continueButton.Click
      MyBase.DialogResult = DialogResult.Ignore
    End Sub
    Private Sub InitializeComponent()
      Me.pictureBox = New System.Windows.Forms.PictureBox()
      Me.reportButton = New System.Windows.Forms.Button()
      Me.continueButton = New System.Windows.Forms.Button()
      Me.label = New System.Windows.Forms.Label()
      Me.label3 = New System.Windows.Forms.Label()
      Me.exceptionTextBox = New System.Windows.Forms.TextBox()
      CType(Me.pictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'pictureBox
      '
      Me.pictureBox.Location = New System.Drawing.Point(0, 0)
      Me.pictureBox.Name = "pictureBox"
      Me.pictureBox.Size = New System.Drawing.Size(224, 464)
      Me.pictureBox.TabIndex = 0
      Me.pictureBox.TabStop = False
      '
      'reportButton
      '
      Me.reportButton.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.reportButton.Location = New System.Drawing.Point(232, 424)
      Me.reportButton.Name = "reportButton"
      Me.reportButton.Size = New System.Drawing.Size(216, 23)
      Me.reportButton.TabIndex = 4
      Me.reportButton.Text = "แจ้งความผิดพลาดให้ทีมงานพจมานทราบ"
      '
      'continueButton
      '
      Me.continueButton.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.continueButton.Location = New System.Drawing.Point(600, 424)
      Me.continueButton.Name = "continueButton"
      Me.continueButton.Size = New System.Drawing.Size(75, 23)
      Me.continueButton.TabIndex = 5
      Me.continueButton.Text = "ทำงานต่อ"
      '
      'label
      '
      Me.label.Location = New System.Drawing.Point(232, 8)
      Me.label.Name = "label"
      Me.label.Size = New System.Drawing.Size(448, 48)
      Me.label.TabIndex = 6
      Me.label.Text = "เกิดความผิดพลาดขึ้นในพจมานค่ะ ต้องขออภัยมา ณ ที่นี้ และพจมานจะขอบพระคุณท่านอย่างม" & _
          "าก หากท่านจะกรุณาแจ้งให้ทีมงานลองกอง สตูดิโอทราบ เพื่อแก้ไขค่ะ"
      '
      'label3
      '
      Me.label3.Location = New System.Drawing.Point(232, 64)
      Me.label3.Name = "label3"
      Me.label3.Size = New System.Drawing.Size(448, 23)
      Me.label3.TabIndex = 9
      Me.label3.Text = "ขอบคุณที่ท่านมีส่วนร่วมในการพัฒนาพจมานให้เป็นโปรแกรมที่ดีที่สุดต่อไป"
      '
      'exceptionTextBox
      '
      Me.exceptionTextBox.Location = New System.Drawing.Point(232, 96)
      Me.exceptionTextBox.Multiline = True
      Me.exceptionTextBox.Name = "exceptionTextBox"
      Me.exceptionTextBox.ReadOnly = True
      Me.exceptionTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
      Me.exceptionTextBox.Size = New System.Drawing.Size(448, 322)
      Me.exceptionTextBox.TabIndex = 1
      Me.exceptionTextBox.Text = "textBoxExceptionText"
      '
      'ExceptionBox
      '
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
      Me.ClientSize = New System.Drawing.Size(688, 453)
      Me.Controls.Add(Me.label3)
      Me.Controls.Add(Me.label)
      Me.Controls.Add(Me.continueButton)
      Me.Controls.Add(Me.reportButton)
      Me.Controls.Add(Me.exceptionTextBox)
      Me.Controls.Add(Me.pictureBox)
      Me.Font = New System.Drawing.Font("Tahoma", 8.25!)
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "ExceptionBox"
      Me.Text = "เกิดความผิดพลาดขึ้น"
      CType(Me.pictureBox, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

    End Sub

#End Region

  End Class
End Namespace
