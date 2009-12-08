Option Strict Off
Imports System
Imports System.IO
Imports System.Net
Imports System.Net.Sockets
Imports System.Text

Namespace Longkong.Pojjaman.DataTransfer
    Public Class FtpClient

        '///////  Class Variables  ///////
        Private bConnected As Boolean = False   ' indicate connection to host
        Private bLoggedIn As Boolean = False   ' indicate user is logged on
        Private bVerbrose As Boolean = True    ' send feedback
        Private nPortFTP As Integer = 21    ' default FTP port
        Private m_tcpClient As TcpClient = Nothing   ' command channel
        Private m_comRead As StreamReader = Nothing   ' text reader
        Private m_comWrite As StreamWriter = Nothing  ' text writer

        '/// <summary>
        '/// flags for directory description
        '/// </summary>
        Public Enum DirMode As Integer
            Complete
            NamesOnly
        End Enum

        '/////////////////  PUBLIC EVENTS  //////////////////

        '/// <summary>
        '/// Delegate to supply all commands sent and replies to user
        '/// </summary>
        Public Delegate Sub CmdEventHandler(ByVal sCmd As String)
        Public Delegate Sub TransferStatus(ByVal bytes As Long)

        '/// <summary>
        '/// receive all commands
        '/// </summary>
        Public Event cmdEvent As CmdEventHandler
        Public Event TransferEvent As TransferStatus


        '/////////////////  PUBLIC METHODS  //////////////////

        '//////////////////////////////////////////////////////////////
        '/// <summary>
        '/// Constructor: Default
        '/// </summary>
        Public Sub FtpClient()

        End Sub

        '/////////////////////////////////////////////////////////////
        '/// <summary>
        '/// Connect to the remote Host FTP server
        '/// </summary>
        '/// <param name="sHost">Host name of FTP server</param>
        Public Sub Connect(ByVal sHost As String)
            If bConnected Then
                Throw New FtpClientException("Connection already open")
            End If
            bVerbrose = True '// send all commands and replies to CmdEvent handlers
            Try
                '// create a TcpClient control for Transport connection
                m_tcpClient = New TcpClient(sHost, nPortFTP) '// use default port 21
                m_tcpClient.ReceiveTimeout = 10000 '// wait 10 seconds before aborting read
                m_tcpClient.SendTimeout = 10000 '// wait 10 seconds before aborting write
                m_comRead = New StreamReader(m_tcpClient.GetStream())  '// reads lines of text
                m_comWrite = New StreamWriter(m_tcpClient.GetStream()) '// write lines of text
                bConnected = True
            Catch ex As Exception
                Throw New FtpClientException("Cannot establish a connection with " + sHost, ex)
            End Try
            Dim sReply As String = ReadReply() '// 220 reply(multiline) if successful
            If sReply.Substring(0, 1) <> "2" Then
                Throw New FtpClientException(sReply)
            End If
        End Sub

        '/////////////////////////////////////////////////////////////
        '/// <summary>
        '/// Log in user to a connected remote FTP server
        '/// </summary>
        '/// <param name="sUsername">User name</param>
        '/// <param name="sPassword">User Password</param>
        Public Sub Login(ByVal sUsername As String, ByVal sPassword As String)
            If Not bConnected Then
                Throw New FtpClientException("Not Connected to Host")
            End If
            If sUsername = "" Then
                sUsername = "anonymous"
            End If
            If sPassword = "" Then
                sPassword = "anonymous"
            End If
            Dim sReply As String = SendCommand("USER " & sUsername)
            '// the server must reply with 331
            If sReply.Substring(0, 1) <> "3" Then
                Throw New FtpClientException(sReply)
            End If
            sReply = SendCommand("PASS " & sPassword)
            '// the server must reply with 230, which is a successful login
            If sReply.Substring(0, 1) <> "2" Then
                Throw New FtpClientException(sReply)
            End If
            bLoggedIn = True
        End Sub

        '////////////////////////////////////////////////////////////////////
        '/// <summary>
        '/// Sets the current remote directory
        '/// </summary>
        '/// <param name="sDirectory">Directory name</param>
        Public Function SetCurrentDirectory(ByVal sDirectory As String) As Boolean
            If Not bLoggedIn Then
                Return False
            End If
            Dim sReply As String = SendCommand("CWD " & sDirectory)
            '// server must reply with 250, else the directory does not exist
            If sReply.Substring(0, 1) <> "2" Then
                Throw New FtpClientException(sReply)
            End If
            Return True
        End Function

        '///////////////////////////////////////////////////////////////////////
        '/// <summary>
        '/// Delete a file from a directory
        Public Function Delete(ByVal remFilename As String) As String
            If Not bLoggedIn Then
                Return "0User not logged in"
                'Throw New FtpClientException("User not logged in")
            End If
            If remFilename = "" Then
                Return "0Remote Filename Empty"
                'Throw New FtpClientException("Remote Filename Empty")
            End If

            Dim dSocket As Socket = CreateDataSocket()  '// set for data transfer
            Dim sReply As String = SendCommand("DELE " & remFilename) '// request a file
            dSocket.Close() '// close data connection
            If sReply.Substring(0, 1) <> "2" Then
                Return "0" & sReply
                'Throw New FtpClientException(sReply)
            End If
            Return "1"
        End Function

        '///////////////////////////////////////////////////////////////////////
        '/// <summary>
        '/// Download a file to a directory (using same filename)
        '/// </summary>
        '/// <param name="remFilename">Filename on host</param>
        '/// <param name="locDir">Directory on local computer</param>
        Public Function Download(ByVal remFilename As String, ByVal locFilename As String) As String
            If Not bLoggedIn Then
                Return "0User not logged in"
                'Throw New FtpClientException("User not logged in")
            End If
            If remFilename = "" Then
                Return "0Remote Filename Empty"
                'Throw New FtpClientException("Remote Filename Empty")
            End If

            Dim dSocket As Socket = CreateDataSocket()  '// set for data transfer
            Dim sReply As String = SendCommand("RETR " & remFilename) '// request a file
            If sReply.Substring(0, 1) <> "1" Then
                Return "0" & sReply
                'Throw New FtpClientException(sReply)
            End If
            Dim bytes As Byte() = New Byte(1024) {}  '// read buffer
            Dim nBytes As Integer = 0
            Dim SentBytes As Long = 0
            Dim fs As FileStream = New FileStream(locFilename, FileMode.Create)
            nBytes = dSocket.Receive(bytes, bytes.Length, 0)
            While nBytes > 0
                SentBytes += nBytes
                WriteTransferStatus(SentBytes)
                fs.Write(bytes, 0, nBytes)
                nBytes = dSocket.Receive(bytes, bytes.Length, 0)
            End While
            fs.Close()  '// close filestream
            dSocket.Close() '// close data connection
            sReply = ReadReply() '// wait for result code 226 Transfer complete
            If sReply.Substring(0, 1) <> "2" Then
                Return "0" & sReply
                'Throw New FtpClientException(sReply)
            End If
            Return "1"
        End Function

        Public Function GetFileSize(ByVal remFilename As String) As String
            If Not bLoggedIn Then
                Throw New FtpClientException("User not logged in")
            End If
            If remFilename = "" Then
                Throw New FtpClientException("Remote Filename Empty")
            End If
            Dim sReply As String = SendCommand("SIZE " & remFilename)
            If sReply.Substring(0, 1) <> "2" Then
                Throw New FtpClientException(sReply)
            End If
            Return sReply.Substring(4, sReply.Length - 4)
        End Function

        '      ///////////////////////////////////////////////////////////////
        '/// <summary>
        '/// Upload a file to a server directory (using same filename)
        '/// </summary>
        '/// <param name="locFilename">Filename on local computer</param>
        '/// <param name="remDir">Directory to upload to on host. ("" = Current Working Directory)</param>
        Public Function Upload(ByVal locFilename As String, ByVal encodedFileName As String, ByVal remDir As String) As String
            Dim fs As FileStream = New FileStream(locFilename, FileMode.Open)
            Return Upload(encodedFileName, remDir, fs)
        End Function

        '///////////////////////////////////////////////////////////////
        '/// <summary>
        '/// Upload a stream to a server directory
        '/// </summary>
        '/// <param name="Filename">Filename on local computer</param>
        '/// <param name="remDir">Directory to upload to on host. ("" = CurrentWorkingDirectory)</param>
        '/// <param name="SourceStream">Stream with source content</param>
        Public Function Upload(ByVal Filename As String, ByVal remDir As String, ByVal SourceStream As Stream) As String
            If Not bLoggedIn Then
                Return "0User not logged in"
                'Throw New FtpClientException("User not logged in")
            End If
            If SourceStream.Length = 0 Then
                Return "0Source stream empty"
                'Throw New FtpClientException("Source stream empty")
            End If
            If remDir <> "" Then
                If remDir.Substring(remDir.Length - 1, 1) <> "/" Then
                    remDir &= "/"  '// ensure there is a seperator
                End If
            End If

            Dim remFilename As String = remDir & Filename '// file path to store under
            'string remFilename = remDir + Path.GetFileName(Filename); // file path to store under
            Dim dSocket As Socket = CreateDataSocket() '// create data connection with host
            Dim sReply As String = SendCommand("STOR " & remFilename)
            If sReply.Substring(0, 1) <> "1" Then
                Return "0" & sReply
                'Throw New FtpClientException(sReply)
            End If
            Dim bytes As Byte() = New Byte(1024) {}
            Dim nBytes As Integer = 0
            Dim SentBytes As Long = 0
            nBytes = SourceStream.Read(bytes, 0, bytes.Length)
            While nBytes > 0   '// read data
                SentBytes += nBytes
                WriteTransferStatus(SentBytes)
                dSocket.Send(bytes, nBytes, 0) '// send to host
                nBytes = SourceStream.Read(bytes, 0, bytes.Length)
            End While
            SourceStream.Close() '// close filestream
            dSocket.Close() '// close data connection
            sReply = ReadReply() '// wait for message 226 Transfer Complete
            If sReply.Substring(0, 1) <> "2" Then
                Return "0" & sReply
                'Throw New FtpClientException(sReply)
            End If
            Return "1"
        End Function

        '///////////////////////////////////////////////////////////////
        '/// <summary>
        '/// disconnect remote host
        '/// </summary>
        Public Sub Disconnect()
            If bConnected Then
                SendCommand("QUIT")
            End If
            Close()
        End Sub

        '////////////////////////////////////////////////////////////////////
        '/// <summary>
        '/// Closes TcpClient and cleans up
        '/// </summary>
        Public Sub Close()
            If Not bConnected Then
                Return
            End If
            m_comRead.Close()  '// close text reader
            m_comWrite.Close()  '// close text writer
            m_tcpClient.Close() '// close command channel
            bConnected = False
            bLoggedIn = False
        End Sub

        '//////////////////////////////////////////////////////////////////
        '/// <summary>
        '/// Sends a command to remote host and waits for reply
        '/// </summary>
        '/// <param name="sCmd">command to server</param>
        Public Function SendCommand(ByVal sCmd As String) As String
            If Not bConnected Then
                Return "000"
            End If
            WriteLog(sCmd)
            Try
                m_comWrite.WriteLine(sCmd)
                m_comWrite.Flush() '// send the data
            Catch ex As Exception
                WriteLog("Write timeout Error:" & ex.Message)
                Close() '// disconnect and cleanup
                Throw New FtpClientException("Write Failed: Closing connection", ex)
            End Try
            Return ReadReply() '// wait for reply from Host
        End Function

        '//////////////////////////////////////////////////////////
        '/// <summary>
        '/// Get List of host files and directories from UNIX server
        '/// Send filenames to "dirEvent" subscribers 
        '/// </summary>
        '/// <param name="sDir">Directory path. "" = CWD</param>
        '/// <param name="nFlag">Mode</param>
        Public Function GetDir(ByVal sDir As String, ByVal nFlag As DirMode) As String()
            If Not bConnected Then
                Throw New FtpClientException("Not connected to Host")
            End If
            If Not bLoggedIn Then
                Throw New FtpClientException("User not logged in")
            End If
            WriteLog("Reading Directory: " & sDir)
            bVerbrose = False '// disable feedback
            Dim dSocket As Socket = CreateDataSocket()
            Dim sCmd As String = "LIST " & sDir
            If nFlag = DirMode.NamesOnly Then
                sCmd = "NLST " & sDir
            End If
            Dim sReply As String = SendCommand(sCmd.Trim())
            If sReply.Substring(0, 1) <> "1" Then
                Throw New FtpClientException(sReply)
            End If
            Dim bytes As Byte() = New Byte(4096) {} '// buffer to receive data bytes
            Dim nBytes As Integer = 0 '// number of bytes read
            Dim s As String = "" '// string to hold all converted ASCII data
            '//FileStream fs = File.Create("Dir.txt");
            nBytes = dSocket.Receive(bytes, bytes.Length, 0)
            While nBytes > 0
                '//fs.Write(bytes,0,nBytes); // save to file
                '//s += Encoding.ASCII.GetString(bytes,0,nBytes); // convert to ASCII
                s &= Encoding.Default.GetString(bytes, 0, nBytes)
                nBytes = dSocket.Receive(bytes, bytes.Length, 0)
            End While
            '//fs.Close();
            dSocket.Close() '// close data connection
            sReply = ReadReply() '// 226- Transfer Complete
            bVerbrose = True '// re-enable feedback
            If sReply.Substring(0, 1) <> "2" Then
                Throw New FtpClientException(sReply)
            End If
            WriteLog("Done!")
            If s.Length > 0 AndAlso s.Substring(s.Length - 1) = Chr(10) Then
                s = s.Substring(0, s.Length) '// remove last "\n"
            End If
            Return s.Replace(Chr(13), "").Split(Chr(10))   '// convert to string array
        End Function

        '/////////////////////  LOCAL METHODS  //////////////////////

        '// Read entire (multi-line) replies from server
        Private Function ReadReply() As String
            Dim s As String = ""
            Try
                s = m_comRead.ReadLine()  '// get first line of reply
                Dim sEnd As String = s.Substring(0, 3) + " " '// save reply number plus space
                While s.Substring(0, 4) <> sEnd
                    WriteLog(s)    '// log line
                    s = m_comRead.ReadLine() '// read multi-line replies
                End While
                WriteLog(s)     '// log last line
            Catch ex As Exception
                WriteLog("Timeout Error:" & ex.Message)
                Close() '// disconnect and cleanup
                Throw New FtpClientException("Read Error: Closing connection", ex)
            End Try
            If s.Length < 4 Then
                Throw New FtpClientException("Invalid Reply From Server")
            End If
            If s.Substring(0, 1) <> "2" Then
                WriteLog("") '// add blank line - end of sequence
            End If
            Return s '// return last line read
        End Function

        '// create socket for data transfer
        '// returns null on error
        Private Function CreateDataSocket() As Socket
            Dim sReply As String = SendCommand("PASV") '// request a data connection
            '// returns: "227 Entering Passive Mode (204,127,12,38,13,193)."
            If sReply.Substring(0, 1) <> "2" Then
                Throw New FtpClientException(sReply)
            End If
            '// extract IP Address and Port number
            Dim n1 As Integer = sReply.IndexOf("(")
            Dim n2 As Integer = sReply.IndexOf(")")
            Dim sa As String() = sReply.Substring(n1 + 1, n2 - n1 - 1).Split(",")
            Dim sIPAddress As String = sa(0) + "." + sa(1) + "." + sa(2) + "." + sa(3)
            Dim nPort As Integer = Integer.Parse(sa(4)) * 256 + Integer.Parse(sa(5))
            Dim socket As socket = Nothing  '// data transfer socket
            Try '// connect to host data channel
                socket = New socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
                socket.Connect(New IPEndPoint(IPAddress.Parse(sIPAddress), nPort))
            Catch ex As Exception
                If Not socket Is Nothing Then
                    socket.Close()
                End If
                WriteLog(ex.Message)
                Throw New FtpClientException("Error creating data connection", ex)
            End Try
            Return socket
        End Function

        '// supply commands and replies to "cmdEvent" subscribers
        Private Sub WriteTransferStatus(ByVal bytes As Long)
            RaiseEvent TransferEvent(bytes)
        End Sub

        Private Sub WriteLog(ByVal sLog As String)
            RaiseEvent cmdEvent(sLog)
        End Sub
    End Class

    '/// <summary>
    '/// FTP exception class
    '/// </summary>
    Public Class FtpClientException
        Inherits Exception
        '/// <summary>
        '/// An instance of FtpClientException
        '/// </summary>
        '/// <param name="sMsg">Explains what happend</param>
        Public Sub New(ByVal sMsg As String)
            MyBase.New(sMsg)
        End Sub

        '/// <summary>
        '/// An instance of FtpClientException
        '/// </summary>
        '/// <param name="sMsg">Explains what happend</param>
        '/// <param name="ex">InnerException</param>
        Public Sub New(ByVal sMsg As String, ByVal ex As Exception)
            MyBase.new(sMsg, ex)
        End Sub
    End Class
End Namespace


