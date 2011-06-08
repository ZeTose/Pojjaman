
Imports Newtonsoft.Json
Imports System.Net
Imports System.IO
Imports System.Collections.Generic
Imports System.Text

'Namespace PojjamanLab
Public Class Lab_001
  Private blist As List(Of BuilkInfo)
  Private Sub Lab_001_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


    ' Create a request for the URL. 
    Dim request As WebRequest = _
      WebRequest.Create("http://www.builk.com/paymenttrack/requestbuilksupplier/?bid=12")
    ' If required by the server, set the credentials.
    request.Credentials = CredentialCache.DefaultCredentials
    ' Get the response.
    Dim response As WebResponse = request.GetResponse()
    ' Display the status.
    'Console.WriteLine(CType(response, HttpWebResponse).StatusDescription)
    ' Get the stream containing content returned by the server.
    Dim dataStream As Stream = response.GetResponseStream()
    ' Open the stream using a StreamReader for easy access.
    Dim reader As New StreamReader(dataStream)
    ' Read the content.
    Dim responseFromServer As String = reader.ReadToEnd()
    ' Display the content.
    'Console.WriteLine(responseFromServer)
    ' Clean up the streams and the response.
    reader.Close()
    response.Close()


    Me.TextBox1.Text = responseFromServer

    blist = JsonConvert.DeserializeObject(Of List(Of BuilkInfo))(responseFromServer)

  End Sub

  Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click


    ' Create a request using a URL that can receive a post. 
    Dim request As WebRequest = WebRequest.Create("http://www.builk.com/paymenttrack/approvebuilksupplier/?bid=12")
    'Dim request As WebRequest = WebRequest.Create("http://www.builk.com/paymenttrack/Transaction/?bid=12")
    ' Set the Method property of the request to POST.
    request.Method = "POST"
    ' Create POST data and convert it to a byte array.
    For Each bi As BuilkInfo In blist
      bi.IsApprove = True
    Next



    Dim postData As String = JsonConvert.SerializeObject(blist) '"This is a test that posts this string to a Web server."
    Dim byteArray As Byte() = Encoding.UTF8.GetBytes(postData)
    ' Set the ContentType property of the WebRequest.
    request.ContentType = "application/jason"
    request.ContentType = "text/plain"
    ' Set the ContentLength property of the WebRequest.
    request.ContentLength = byteArray.Length
    ' Get the request stream.
    Dim dataStream As Stream = request.GetRequestStream()
    ' Write the data to the request stream.
    dataStream.Write(byteArray, 0, byteArray.Length)
    ' Close the Stream object.
    dataStream.Close()
    ' Get the response.
    Dim response As WebResponse = request.GetResponse()
    ' Display the status.
    'Console.WriteLine(CType(response, HttpWebResponse).StatusDescription)
    ' Get the stream containing content returned by the server.
    dataStream = response.GetResponseStream()
    ' Open the stream using a StreamReader for easy access.
    Dim reader As New StreamReader(dataStream)
    ' Read the content.
    Dim responseFromServer As String = reader.ReadToEnd()
    ' Display the content.
    'Console.WriteLine(responseFromServer)
    ' Clean up the streams.

    Me.TextBox1.Text = responseFromServer

    reader.Close()
    dataStream.Close()
    response.Close()



  End Sub
End Class

Public Class BuilkInfo
  Public Bid As String
  Public IsApprove? As Boolean
  Public Bname As String
  Public Baddress As String
  Public Btid As String
End Class
'End Namespace