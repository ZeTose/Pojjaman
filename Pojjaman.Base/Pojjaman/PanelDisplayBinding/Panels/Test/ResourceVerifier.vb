Imports Longkong.Core.Services
Imports System.Text.RegularExpressions
Imports System.IO
Namespace Longkong.Pojjaman.Gui.Panels
    Public Class ResourceVerifier
        Inherits System.Windows.Forms.UserControl

#Region " Windows Form Designer generated code "

        Public Sub New()
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call

        End Sub

        'UserControl overrides dispose to clean up the component list.
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
        Friend WithEvents lsbMissingResource As System.Windows.Forms.ListBox
        Friend WithEvents btnSearch As System.Windows.Forms.Button
        Friend WithEvents btnSave As System.Windows.Forms.Button
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.lsbMissingResource = New System.Windows.Forms.ListBox
            Me.btnSearch = New System.Windows.Forms.Button
            Me.btnSave = New System.Windows.Forms.Button
            Me.SuspendLayout()
            '
            'lsbMissingResource
            '
            Me.lsbMissingResource.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lsbMissingResource.Location = New System.Drawing.Point(16, 56)
            Me.lsbMissingResource.Name = "lsbMissingResource"
            Me.lsbMissingResource.Size = New System.Drawing.Size(640, 368)
            Me.lsbMissingResource.TabIndex = 0
            '
            'btnSearch
            '
            Me.btnSearch.Location = New System.Drawing.Point(16, 16)
            Me.btnSearch.Name = "btnSearch"
            Me.btnSearch.TabIndex = 1
            Me.btnSearch.Text = "GO!!!"
            '
            'btnSave
            '
            Me.btnSave.Location = New System.Drawing.Point(104, 16)
            Me.btnSave.Name = "btnSave"
            Me.btnSave.TabIndex = 1
            Me.btnSave.Text = "Save"
            '
            'ResourceVerifier
            '
            Me.Controls.Add(Me.btnSearch)
            Me.Controls.Add(Me.lsbMissingResource)
            Me.Controls.Add(Me.btnSave)
            Me.Name = "ResourceVerifier"
            Me.Size = New System.Drawing.Size(688, 456)
            Me.ResumeLayout(False)

        End Sub

#End Region

        Private errCount As Integer = 0
        Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
            LoopDir("Z:\Pojjaman", 0)
            MessageBox.Show(errCount.ToString)
        End Sub

        Public Sub Test()
            '\("\${res:(?<Resource>.*)}"\)
            Dim fileUtil As FileUtilityService = CType(ServiceManager.Services.GetService(GetType(FileUtilityService)), FileUtilityService)

        End Sub
        Private Sub LoopDir(ByVal dir As String, ByVal level As Integer)
            Dim stp As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
            Try
                For Each fname As String In Directory.GetFiles(dir)
                    If fname.EndsWith(".vb") Then
                        Dim sr As New StreamReader(fname)
                        Dim fileContents As String = sr.ReadToEnd()
                        sr.Close()
                        Dim re As New Regex("\(""(?<ParseMe>\${res:(?<Resource>.*)})""\)")
                        For Each m As Match In re.Matches(fileContents)
                            Dim g As Group = m.Groups("ParseMe")
                            If stp.Parse(g.Value) = "TBD!" Then
                                If Not Me.lsbMissingResource.Items.Contains(m.Groups("Resource").Value) Then
                                    errCount += 1
                                    Me.lsbMissingResource.Items.Add(m.Groups("Resource").Value)
                                End If
                            End If
                        Next
                    End If
                Next
                For Each subdir As String In Directory.GetDirectories(dir)
                    LoopDir(subdir, level + 1)
                Next
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End Sub

        Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
            Dim sw As StreamWriter = File.CreateText("C:\Documents and Settings\Administrator\Desktop\MissingResource.txt")
            For Each item As String In Me.lsbMissingResource.Items
                sw.WriteLine(item)
            Next
            sw.Close()
        End Sub
    End Class
End Namespace