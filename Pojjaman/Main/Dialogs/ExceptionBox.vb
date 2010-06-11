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

    Private WithEvents copyErrorCheckBox As CheckBox
    Private WithEvents exceptionTextBox As TextBox
    Private WithEvents includeSysInfoCheckBox As CheckBox
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
      Try
        Me.CopyInfoToClipboard()
        Dim client As New SmtpClient("smtp.gmail.com", 587)
        client.Credentials = New NetworkCredential("bugreport@longkongstudio.com", "tmhctr")
        client.EnableSsl = True
        Dim s As New MailAddress("bugreport@longkongstudio.com", "Bug Report", System.Text.Encoding.UTF8)
        Dim r As New MailAddress("bugreport@longkongstudio.com")
        Dim message As New MailMessage(s, r)
        message.Body = getClipboardString()
        message.Subject = "[Pojjaman Error Report]"
        message.SubjectEncoding = System.Text.Encoding.UTF8        
        client.Send(message)
        MessageBox.Show("ส่ง Error เรียบร้อยค่ะ")
        Me.Close()
      Catch ex As Exception
        Console.WriteLine(ex.ToString)
      End Try
    End Sub
    Private Sub continueButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles continueButton.Click
      MyBase.DialogResult = DialogResult.Ignore
    End Sub
    Private Sub CopyInfoToClipboard()
      If Not Me.copyErrorCheckBox.Checked Then
        Return
      End If
      Try
        Clipboard.SetDataObject(New DataObject(DataFormats.Text, Me.getClipboardString), True)
      Catch e As Exception
      End Try
    End Sub
    Private Function getClipboardString() As String
      Dim str As String = ""
      If Me.includeSysInfoCheckBox.Checked Then
        str = ".NET Version         : " & Environment.Version.ToString & Environment.NewLine
        str &= "OS Version           : " & Environment.OSVersion.ToString & Environment.NewLine
        str &= "Boot Mode            : " & SystemInformation.BootMode & Environment.NewLine
        str &= "Working Set Memory   : " & (Environment.WorkingSet / CType(1024, Long)) & "kb" & Environment.NewLine & Environment.NewLine
        Dim v As Version = [Assembly].GetEntryAssembly.GetName.Version
        str &= "PJM Version : " & v.Major & "." & v.Minor & "." & v.Revision & "." & v.Build & Environment.NewLine
      End If
      str = (str & "Exception thrown: " & Environment.NewLine)
      Return (str & Me.exceptionThrown.ToString)
    End Function
    Private Sub InitializeComponent()
      Me.pictureBox = New System.Windows.Forms.PictureBox
      Me.reportButton = New System.Windows.Forms.Button
      Me.continueButton = New System.Windows.Forms.Button
      Me.label = New System.Windows.Forms.Label
      Me.label3 = New System.Windows.Forms.Label
      Me.includeSysInfoCheckBox = New System.Windows.Forms.CheckBox
      Me.copyErrorCheckBox = New System.Windows.Forms.CheckBox
      Me.exceptionTextBox = New System.Windows.Forms.TextBox
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
      Me.continueButton.TabIndex = 5
      Me.continueButton.Text = "ทำงานต่อ"
      '
      'label
      '
      Me.label.Location = New System.Drawing.Point(232, 8)
      Me.label.Name = "label"
      Me.label.Size = New System.Drawing.Size(448, 48)
      Me.label.TabIndex = 6
      Me.label.Text = "เกิดความผิดพลาดขึ้นในพจมานค่ะ ต้องขออภัยมา ณ ที่นี้ และพจมานจะขอบพระคุณ" & _
      "ท่านอย่างมาก หากท่านจะกรุณาแจ้งให้ทีมงานลองกอง สตูดิโอทราบ เพื่อแก้ไขค่ะ"
      '
      'label3
      '
      Me.label3.Location = New System.Drawing.Point(232, 64)
      Me.label3.Name = "label3"
      Me.label3.Size = New System.Drawing.Size(448, 23)
      Me.label3.TabIndex = 9
      Me.label3.Text = "ขอบคุณที่ท่านมีส่วนร่วมในการพัฒนาพจมานให้เป็นโปรแกรมที่ดีที่สุดต่อไป"
      '
      'includeSysInfoCheckBox
      '
      Me.includeSysInfoCheckBox.Checked = True
      Me.includeSysInfoCheckBox.CheckState = System.Windows.Forms.CheckState.Checked
      Me.includeSysInfoCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.includeSysInfoCheckBox.Location = New System.Drawing.Point(232, 392)
      Me.includeSysInfoCheckBox.Name = "includeSysInfoCheckBox"
      Me.includeSysInfoCheckBox.Size = New System.Drawing.Size(440, 24)
      Me.includeSysInfoCheckBox.TabIndex = 3
      Me.includeSysInfoCheckBox.Text = "ส่งรายละเอียดเกี่ยวกับระบบ (version of Windows, .NET framework)"
      '
      'copyErrorCheckBox
      '
      Me.copyErrorCheckBox.Checked = True
      Me.copyErrorCheckBox.CheckState = System.Windows.Forms.CheckState.Checked
      Me.copyErrorCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.copyErrorCheckBox.Location = New System.Drawing.Point(232, 368)
      Me.copyErrorCheckBox.Name = "copyErrorCheckBox"
      Me.copyErrorCheckBox.Size = New System.Drawing.Size(440, 24)
      Me.copyErrorCheckBox.TabIndex = 2
      Me.copyErrorCheckBox.Text = "Copy ข้อความแสดงความผิดพลาดนี้ไว้ใน clipboard"
      '
      'exceptionTextBox
      '
      Me.exceptionTextBox.Location = New System.Drawing.Point(232, 96)
      Me.exceptionTextBox.Multiline = True
      Me.exceptionTextBox.Name = "exceptionTextBox"
      Me.exceptionTextBox.ReadOnly = True
      Me.exceptionTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
      Me.exceptionTextBox.Size = New System.Drawing.Size(448, 264)
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
      Me.Controls.Add(Me.includeSysInfoCheckBox)
      Me.Controls.Add(Me.copyErrorCheckBox)
      Me.Controls.Add(Me.exceptionTextBox)
      Me.Controls.Add(Me.pictureBox)
      Me.Font = New System.Drawing.Font("Tahoma", 8.25!)
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "ExceptionBox"
      Me.Text = "เกิดความผิดพลาดขึ้น"
      Me.ResumeLayout(False)

    End Sub

#End Region

  End Class
End Namespace
