Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.TextHelper
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Imports System.Data.SqlClient
Imports Longkong.Pojjaman.Services
Imports System.Threading
Imports Longkong.Pojjaman.DataTransfer
Imports System.Text
Imports System.IO


Namespace Longkong.Pojjaman.Gui.Panels
    Public Class AttachmentForm
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

        'NOTE: The following procedure is required by the Windows Form Designer
        'It can be modified using the Windows Form Designer.  
        'Do not modify it using the code editor.
        Friend WithEvents lblItem As System.Windows.Forms.Label
        Friend WithEvents fileName As System.Windows.Forms.ColumnHeader
        Friend WithEvents lineNumber As System.Windows.Forms.ColumnHeader
        Friend WithEvents fileSize As System.Windows.Forms.ColumnHeader
        Friend WithEvents btnDel As System.Windows.Forms.Button
        Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
        Friend WithEvents btnUpload As System.Windows.Forms.Button
        Friend WithEvents btnDownload As System.Windows.Forms.Button
        Friend WithEvents lvAttchs As System.Windows.Forms.ListView
        Friend WithEvents Timer1 As System.Windows.Forms.Timer
        Friend WithEvents lblStatus As System.Windows.Forms.Label
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container
            Me.lblItem = New System.Windows.Forms.Label
            Me.lvAttchs = New System.Windows.Forms.ListView
            Me.lineNumber = New System.Windows.Forms.ColumnHeader
            Me.fileName = New System.Windows.Forms.ColumnHeader
            Me.fileSize = New System.Windows.Forms.ColumnHeader
            Me.btnDel = New System.Windows.Forms.Button
            Me.ProgressBar1 = New System.Windows.Forms.ProgressBar
            Me.btnUpload = New System.Windows.Forms.Button
            Me.btnDownload = New System.Windows.Forms.Button
            Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
            Me.lblStatus = New System.Windows.Forms.Label
            Me.SuspendLayout()
            '
            'lblItem
            '
            Me.lblItem.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblItem.Location = New System.Drawing.Point(16, 8)
            Me.lblItem.Name = "lblItem"
            Me.lblItem.TabIndex = 1
            Me.lblItem.Text = "ÃÒÂ¡ÒÃä¿Åìá¹º"
            '
            'lvAttchs
            '
            Me.lvAttchs.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lvAttchs.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.lineNumber, Me.fileName, Me.fileSize})
            Me.lvAttchs.FullRowSelect = True
            Me.lvAttchs.GridLines = True
            Me.lvAttchs.HideSelection = False
            Me.lvAttchs.Location = New System.Drawing.Point(16, 24)
            Me.lvAttchs.MultiSelect = False
            Me.lvAttchs.Name = "lvAttchs"
            Me.lvAttchs.Size = New System.Drawing.Size(592, 360)
            Me.lvAttchs.TabIndex = 2
            Me.lvAttchs.View = System.Windows.Forms.View.Details
            '
            'lineNumber
            '
            Me.lineNumber.Text = "ÅÓ´Ñº·Õè"
            Me.lineNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            '
            'fileName
            '
            Me.fileName.Text = "ª×èÍä¿Åì"
            Me.fileName.Width = 378
            '
            'fileSize
            '
            Me.fileSize.Text = "¢¹Ò´ä¿Åì"
            Me.fileSize.Width = 129
            '
            'btnDel
            '
            Me.btnDel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.btnDel.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnDel.Location = New System.Drawing.Point(16, 392)
            Me.btnDel.Name = "btnDel"
            Me.btnDel.Size = New System.Drawing.Size(96, 23)
            Me.btnDel.TabIndex = 6
            Me.btnDel.Text = "Delete"
            '
            'ProgressBar1
            '
            Me.ProgressBar1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ProgressBar1.Location = New System.Drawing.Point(0, 424)
            Me.ProgressBar1.Name = "ProgressBar1"
            Me.ProgressBar1.Size = New System.Drawing.Size(616, 16)
            Me.ProgressBar1.TabIndex = 10
            '
            'btnUpload
            '
            Me.btnUpload.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnUpload.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnUpload.Location = New System.Drawing.Point(408, 392)
            Me.btnUpload.Name = "btnUpload"
            Me.btnUpload.Size = New System.Drawing.Size(96, 23)
            Me.btnUpload.TabIndex = 5
            Me.btnUpload.Text = "Upload"
            '
            'btnDownload
            '
            Me.btnDownload.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnDownload.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnDownload.Location = New System.Drawing.Point(512, 392)
            Me.btnDownload.Name = "btnDownload"
            Me.btnDownload.Size = New System.Drawing.Size(96, 23)
            Me.btnDownload.TabIndex = 5
            Me.btnDownload.Text = "Download"
            '
            'Timer1
            '
            '
            'lblStatus
            '
            Me.lblStatus.Location = New System.Drawing.Point(128, 400)
            Me.lblStatus.Name = "lblStatus"
            Me.lblStatus.Size = New System.Drawing.Size(264, 16)
            Me.lblStatus.TabIndex = 11
            Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'AttachmentForm
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(616, 438)
            Me.Controls.Add(Me.lblStatus)
            Me.Controls.Add(Me.ProgressBar1)
            Me.Controls.Add(Me.btnDel)
            Me.Controls.Add(Me.lvAttchs)
            Me.Controls.Add(Me.lblItem)
            Me.Controls.Add(Me.btnUpload)
            Me.Controls.Add(Me.btnDownload)
            Me.Name = "AttachmentForm"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            Me.Text = "Attachments"
            Me.ResumeLayout(False)

        End Sub

#End Region

#Region "Members"
        Private m_entity As ISimpleEntity
        Private m_attachment As Attachment
        Private m_attachmentColl As AttachmentCollection

        Private m_ftp As New FtpClient
        Private m_server As String
        Private m_username As String
        Private m_password As String
        Private sPath As String
        Private sFile As String
        Private sFileInServer As String
        Private sFileSize As Long
        Private sLocalFile As String
        Private m_result As String
#End Region

#Region "SetLabelText"
        Dim StringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
        Public Sub SetLabelText()
            Me.lblItem.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Dialogs.AttachmentForm.lblItem}")
            Me.btnDel.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Dialogs.AttachmentForm.btnDel}")
            Me.btnUpload.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Dialogs.AttachmentForm.btnUpload}")
            Me.btnDownload.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Dialogs.AttachmentForm.btnDownload}")

            Me.lvAttchs.Columns(0).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Dialogs.AttachmentForm.Col0}")
            Me.lvAttchs.Columns(1).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Dialogs.AttachmentForm.Col1}")
            Me.lvAttchs.Columns(2).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Dialogs.AttachmentForm.Col2}")
        End Sub
#End Region

#Region "Constructors"
        Public Sub New(ByVal entity As ISimpleEntity)
            MyBase.New()
            InitializeComponent()
            SetLabelText()
            ConfigConnectionParam()
            m_entity = entity
            If Not m_entity.Originated Then
                Return
            End If
            Populate()
        End Sub
        Private Sub Populate()
            Me.lvAttchs.Items.Clear()
            'If m_attachmentColl Is Nothing Then
            '    Return
            'End If
            m_attachmentColl = New AttachmentCollection(m_entity)
            For Each file As Attachment In m_attachmentColl
                Dim lvi As ListViewItem = Me.lvAttchs.Items.Add(CStr(file.LineNumber))
                lvi.SubItems.Add(file.FileName)
                lvi.SubItems.Add(Format(file.FileSize, "0,000"))
                lvi.Tag = file
            Next
        End Sub
        Private Sub ConfigConnectionParam()
            'm_ftp = New FtpClient
            m_server = CStr(Configuration.GetConfig("InternalFTPServer"))
            If Not IsUsingPrivateNetwork() Then
                m_server = CStr(Configuration.GetConfig("ExternalFTPServer"))
            End If
            m_username = CStr(Configuration.GetConfig("FTPUsername"))
            m_password = CStr(Configuration.GetConfig("FTPPassword"))
            sPath = CStr(Configuration.GetConfig("FTPDefaultPath"))
            AddHandler m_ftp.TransferEvent, AddressOf Status
            ClearProgressBar()
        End Sub
#End Region

#Region "Method"
    Private Function MakeConnection() As Exception

      Try
        m_ftp.Connect(m_server)
        m_ftp.Login(m_username, m_password)
        Return New Exception("1")
      Catch ex As Exception
        Return ex
      End Try
    End Function
        Private Sub Disconnect()
            Try
                m_ftp.Disconnect()
                lvAttchs.Items.Clear()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End Sub
        Private Function IsUsingPrivateNetwork() As Boolean
            Dim mySService As SecurityService = CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService)
            Dim CurrentConn As String = mySService.CurrentUser.ConnectionString
            Dim CurrentConnArr As String() = CurrentConn.Split(CChar(";"))
            Dim CurrentConnFields As New Hashtable
            For Each x As String In CurrentConnArr
                'Data Source=Some.Ip,1433
                CurrentConnFields(x.Split(CChar("="))(0)) = x.Split(CChar("="))(1).Split(CChar(","))(0)
            Next
            Dim myDataSource As String = CStr(CurrentConnFields("Data Source"))
            'lk03\pjmserver
            myDataSource = myDataSource.Split(CChar("\"))(0)
            If myDataSource = "(local)" Then
                Return True
            End If
            myDataSource = GetIPAddress(myDataSource)

            Dim myIP As String() = myDataSource.Split(CChar("."))
            If CInt(myIP(0)) = 10 Then
                Return True
            ElseIf CInt(myIP(0)) = 172 AndAlso CInt(myIP(1)) >= 16 AndAlso CInt(myIP(1)) <= 31 Then
                Return True
            ElseIf CInt(myIP(0)) = 192 AndAlso CInt(myIP(1)) = 168 Then
                Return True
            ElseIf CInt(myIP(0)) = 169 AndAlso CInt(myIP(1)) = 254 Then
                Return True
            End If
            Return False
        End Function
        Private Function GetIPAddress(ByVal hostname As String) As String
            Dim i As Integer
            Dim ipE As System.Net.IPHostEntry = System.Net.Dns.GetHostByName(hostname)
            Dim IpA() As System.Net.IPAddress = ipE.AddressList
            'For i = 0 To IpA.GetUpperBound(0)
            '    'Console.Write("IP Address {0}: {1} ", i, IpA(i).ToString)
            'Next
            Return IpA(0).ToString
        End Function
        Private Sub ClearProgressBar()
            Timer1.Enabled = False
            ProgressBar1.Minimum = 0
            ProgressBar1.Value = 0
            ProgressBar1.Maximum = 100
        End Sub
#End Region

#Region "Event Handlers"
        Dim useProgressBar As Boolean = True
        Private Sub btnDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDel.Click
            If Not m_entity.Originated Then
                Return
            End If
            If m_attachmentColl Is Nothing Then
                Return
            End If
            If Me.lvAttchs.SelectedItems.Count <= 0 Then
                MessageBox.Show(Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Dialogs.AttachmentForm.NotSelectedFileForDelete}"))
                Return
            End If
            Dim mySelected As Attachment = CType(Me.lvAttchs.SelectedItems(0).Tag, Attachment)
            Dim mySService As SecurityService = CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService)
            If Not mySelected.Originator = mySService.CurrentUser.Id Then
                Return
            End If
            Try
                MakeConnection()
        sFile = sPath & "/" & mySelected.FileNameInServer
        DisableButton()
                Dim t As New Thread(AddressOf Delete)
                Timer1.Interval = 1
                Timer1.Enabled = True
                useProgressBar = False
                t.Name = "Delete"
                t.Start()
                tempThread = t
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Delete Error")
            End Try
        End Sub
        Private Sub lvAttchs_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvAttchs.SelectedIndexChanged
            If lvAttchs.SelectedItems.Count <= 0 Then
                m_attachment = Nothing
                Return
            End If
            m_attachment = CType(lvAttchs.SelectedItems(0).Tag, Attachment)
        End Sub
        Private Sub btnUpload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpload.Click
            If Not m_entity.Originated Then
                Return
            End If
            Dim dlgopen As New OpenFileDialog
            If dlgopen.ShowDialog() = DialogResult.OK Then
                Try
                    'Transfer File
                    MakeConnection()
                    sFile = dlgopen.FileName
                    sFileSize = Microsoft.VisualBasic.FileLen(sFile)
                    'MessageBox.Show((Microsoft.VisualBasic.GetAttr(sFile) And FileAttribute.ReadOnly).ToString)
                    If (Microsoft.VisualBasic.GetAttr(sFile) And FileAttribute.ReadOnly) = FileAttribute.ReadOnly Then
                        Disconnect()
                        MessageBox.Show("Do not allow upload READONLY file!")
                        Return
                    End If
          sFileInServer = m_entity.EntityId & "_" & m_entity.Id & "_" & EncodeFileName(sFile)
          DisableButton()
                    Dim t As New Thread(AddressOf Upload)
                    Timer1.Interval = 50
                    If sFileSize < 10485760 Then 'Less Interval for small file
                        Timer1.Interval = 1
                    End If
                    Timer1.Enabled = True
                    t.Name = "Upload"
                    t.Start()
                    tempThread = t
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Upload Error")
                End Try
            End If
        End Sub
        Private Sub btnDownload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDownload.Click
            If Not m_entity.Originated Then
                Return
            End If
            If m_attachmentColl Is Nothing Then
                Return
            End If
            If Me.lvAttchs.SelectedItems.Count <= 0 Then
                MessageBox.Show(Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Dialogs.AttachmentForm.NotSelectedFileForDownload}"))
                Return
            End If
            Dim mySelected As Attachment = CType(Me.lvAttchs.SelectedItems(0).Tag, Attachment)
            Dim dlgSave As New SaveFileDialog
            dlgSave.FileName = mySelected.FileName
            If dlgSave.ShowDialog() <> DialogResult.OK Then
                Return
            End If
            Try
                MakeConnection()
                sFile = sPath & "/" & mySelected.FileNameInServer
                sFileSize = mySelected.FileSize     'sFileSize = CLng(m_ftp.GetFileSize(sFile))
        sLocalFile = dlgSave.FileName
        DisableButton()
                Dim t As New Thread(AddressOf Download)
                Timer1.Interval = 50
                If sFileSize < 10485760 Then
                    Timer1.Interval = 1
                End If
                Timer1.Enabled = True
                t.Name = "Download"
                t.Start()
        tempThread = t
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Download Error")
            End Try
        End Sub
    Private Sub Upload()
      Try
        lblStatus.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Dialogs.AttachmentForm.Uploading}")
        m_result = m_ftp.Upload(sFile, sFileInServer, sPath)
      Catch ex As Exception

      End Try
    End Sub
    Private Sub Download()
      Try
        lblStatus.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Dialogs.AttachmentForm.Downloading}")
        m_result = m_ftp.Download(sFile, sLocalFile)
        Process.Start(sLocalFile)
      Catch ex As Exception

      End Try
    End Sub
        Private Sub Delete()
            lblStatus.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Dialogs.AttachmentForm.Deleting}")
            m_result = m_ftp.Delete(sFile)
        End Sub
        Private Sub DisableButton()
            Me.btnDel.Enabled = False
            Me.btnDownload.Enabled = False
            Me.btnUpload.Enabled = False
        End Sub
        Private Sub EnableButton()
            Me.btnDel.Enabled = True
            Me.btnDownload.Enabled = True
            Me.btnUpload.Enabled = True
        End Sub
        Dim tempThread As Thread
        Dim SentBytes As Long
        Dim Percent As Long
        Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
            If tempThread.IsAlive Then
                If useProgressBar Then
                    Percent = CLng(SentBytes / sFileSize * 100)
                    If Percent > ProgressBar1.Maximum Then
                        Percent = ProgressBar1.Maximum
                    End If
                    ProgressBar1.Value = CInt(Percent)
                End If
            Else
                Timer1.Enabled = False
                If Not m_result Is Nothing AndAlso m_result.Length > 0 AndAlso m_result.Substring(0, 1) = "1" Then
                    If tempThread.Name = "Upload" Then
                        'Record file info to class
                        m_attachment = New Attachment
                        If Not Me.m_entity Is Nothing Then
                            m_attachment.EntityId = m_entity.Id
                            m_attachment.EntityType = m_entity.EntityId
                        End If
                        m_attachment.FileName = Path.GetFileName(sFile)
                        m_attachment.FileSize = CInt(sFileSize)
                        m_attachment.FileNameInServer = sFileInServer
                        m_attachment.LineNumber = m_attachmentColl.Count + 1
                        'Record uploader
                        Dim mySService As SecurityService = CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService)
                        m_attachment.Originator = mySService.CurrentUser.Id
                        m_attachment.OriginDate = Now
                        'Add attachment to collection
                        m_attachmentColl.Add(m_attachment)
                        m_attachmentColl.Save()
                    ElseIf tempThread.Name = "Delete" Then
                        m_attachmentColl.Remove(m_attachment)
                        m_attachmentColl.Save()
                    End If

                    MessageBox.Show(tempThread.Name & " Completed!")
                Else
                    MessageBox.Show(tempThread.Name & " Failed!" & CStr(IIf(Not m_result Is Nothing AndAlso m_result.Length > 1, " - " & m_result.Substring(1, m_result.Length - 1), "")))
                End If
                Disconnect()
                ClearProgressBar()
                EnableButton()
                lblStatus.Text = ""
                m_result = ""
                useProgressBar = True
                Populate()
            End If
        End Sub
        Private Sub Status(ByVal bytes As Long)
            SentBytes = bytes
        End Sub
        Private Function EncodeFileName(ByVal fileName As String) As String
            Dim mybyte As Byte() = Encoding.Unicode.GetBytes(Path.GetFileName(fileName))
            Dim myfile As String = Convert.ToBase64String(mybyte)
            Return myfile
        End Function
#End Region

#Region "Properties"
        Public ReadOnly Property AttachmentColl() As AttachmentCollection
            Get
                Return m_attachmentColl
            End Get
        End Property
#End Region

    End Class
End Namespace

