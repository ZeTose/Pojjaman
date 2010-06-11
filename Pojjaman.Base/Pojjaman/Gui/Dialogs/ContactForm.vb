Imports System.Net.Mail
Imports System.Net
Imports System.Reflection
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Gui

Public Class ContactForm
  Private ex As String
  Public subject As String
  Public Sub New()

    ' This call is required by the designer.
    InitializeComponent()

    ' Add any initialization after the InitializeComponent() call.

  End Sub
  Public Sub New(ByVal errorMsg As String, ByVal s As String)

    ' This call is required by the designer.
    InitializeComponent()

    ' Add any initialization after the InitializeComponent() call.
    ex = errorMsg
    subject = s
    Me.txtSubject.Text = s
  End Sub

  Private Function getClipboardString() As String
    Dim secServ As SecurityService = CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService)
    Dim config As Object = Longkong.Pojjaman.BusinessLogic.Configuration.GetConfig("CompanyName")
    Dim company As String = ""
    If Not config Is Nothing Then
      company = config.ToString
    End If
    Dim pjmVersion As Version = [Assembly].GetEntryAssembly.GetName.Version
    Dim pjmRealVersion As String = clsAssInfo.RealVersion
    Dim pjmVersionArray As Object() = New Object() {pjmVersion.Major, ".", _
                                                    pjmVersion.Minor.ToString("00"), ".", _
                                                    pjmVersion.Build.ToString("0000"), ".", _
                                                    pjmRealVersion}
    Dim str As String = ""
    str = "Name         : " & secServ.CurrentUser.Name & Environment.NewLine
    str &= "Company         : " & company & Environment.NewLine
    str &= "Email         : " & txtEmail.Text & Environment.NewLine
    str &= ".NET Version         : " & Environment.Version.ToString & Environment.NewLine
    str &= "OS Version           : " & Environment.OSVersion.ToString & Environment.NewLine
    str &= "Boot Mode            : " & SystemInformation.BootMode & Environment.NewLine
    str &= "Working Set Memory   : " & (Environment.WorkingSet / CType(1024, Long)) & "kb" & Environment.NewLine & Environment.NewLine
    str &= "PJM Version : " & String.Concat(pjmVersionArray) & Environment.NewLine
    str &= "DB Version : " & Longkong.Pojjaman.DataAccessLayer.SqlHelper.GetRealVersion & Environment.NewLine
    If Not String.IsNullOrEmpty(ex) Then
      str = (str & "Error: " & Environment.NewLine)
      str = (str & Me.ex & Environment.NewLine)
    End If
    str = (str & "ข้อความ: " & Environment.NewLine)
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
      If String.IsNullOrEmpty(ex) Then
        message.Subject = Me.txtSubject.Text & "[Pojjaman Contact]"
      ElseIf Me.txtSubject.TextLength = 0 OrElse Not Me.txtSubject.Text.Contains("[Pojjaman Error]") Then
        message.Subject = Me.txtSubject.Text & "[Pojjaman Error]"
      Else
        message.Subject = Me.txtSubject.Text
      End If
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