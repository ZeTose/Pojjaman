Imports System.Net.Mail
Imports System.Net
Imports System.Reflection

Public Class ContactForm
  Private Function getClipboardString() As String
    Dim str As String = ""
    str = "Name         : " & txtName.Text & Environment.NewLine
    str &= "Company         : " & txtCompany.Text & Environment.NewLine
    str &= ".NET Version         : " & Environment.Version.ToString & Environment.NewLine
    str &= "OS Version           : " & Environment.OSVersion.ToString & Environment.NewLine
    str &= "Boot Mode            : " & SystemInformation.BootMode & Environment.NewLine
    str &= "Working Set Memory   : " & (Environment.WorkingSet / CType(1024, Long)) & "kb" & Environment.NewLine & Environment.NewLine
    Dim v As Version = [Assembly].GetEntryAssembly.GetName.Version
    str &= "PJM Version : " & v.Major & "." & v.Minor & "." & v.Revision & "." & v.Build & Environment.NewLine
    str = (str & "Exception thrown: " & Environment.NewLine)
    Return (str & Me.RichTextBox1.Text)
  End Function
  Private Sub btnSend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSend.Click
    Try
      Dim client As New SmtpClient("smtp.gmail.com", 587)
      client.Credentials = New NetworkCredential("bugreport@longkongstudio.com", "tmhctr")
      client.EnableSsl = True
      Dim s As New MailAddress("bugreport@longkongstudio.com", "Bug Report", System.Text.Encoding.UTF8)
      Dim r As New MailAddress("bugreport@longkongstudio.com")
      Dim message As New MailMessage(s, r)
      message.Body = getClipboardString()
      message.Subject = Me.txtSubject.Text & "[Pojjaman Contact]"
      message.SubjectEncoding = System.Text.Encoding.UTF8
      client.Send(message)
      MessageBox.Show("ทางเราได้รับการติดต่อเรียบร้อยค่ะ เราจะรีบติดต่อท่านกลับโดยเร็วค่ะ")
      Me.Close()
    Catch ex As Exception
      Console.WriteLine(ex.ToString)
    End Try
  End Sub
  Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
    Me.Close()
  End Sub
End Class