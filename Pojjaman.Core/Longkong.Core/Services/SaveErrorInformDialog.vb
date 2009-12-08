Imports System.Windows.Forms
Imports System.Drawing
Imports System.IO
Imports Longkong.Core.Services
Namespace Longkong.Core.Services
    Public Class SaveErrorInformDialog
        Inherits System.Windows.Forms.Form

#Region "Members"
        Private descriptionLabel As Label
        Private descriptionTextBox As TextBox
        Private displayMessage As String
        Private exceptionButton As Button
        Private exceptionGot As Exception
        Private okButton As Button
#End Region

#Region "Constructors"
        Public Sub New(ByVal fileName As String, ByVal message As String, ByVal dialogName As String, ByVal exceptionGot As Exception)
            Dim service1 As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
            Me.Text = service1.Parse(dialogName)
            Me.InitializeComponent()
            Dim textArray1(,) As String = New String(4 - 1, 2 - 1) {}
            textArray1(0, 0) = "FileName"
            textArray1(0, 1) = fileName
            textArray1(1, 0) = "Path"
            textArray1(1, 1) = Path.GetDirectoryName(fileName)
            textArray1(2, 0) = "FileNameWithoutPath"
            textArray1(2, 1) = Path.GetFileName(fileName)
            textArray1(3, 0) = "Exception"
            textArray1(3, 1) = exceptionGot.GetType.FullName
            Me.displayMessage = service1.Parse(message, textArray1)
            Dim chArray1 As Char() = New Char() {ChrW(10)}
            Me.descriptionTextBox.Lines = Me.displayMessage.Split(chArray1)
            Me.exceptionGot = exceptionGot
        End Sub
        Private Sub InitializeComponent()
            Dim service1 As IResourceService = CType(ServiceManager.Services.GetService(GetType(IResourceService)), IResourceService)
            MyBase.ClientSize = New Size(508, 320)
            MyBase.SuspendLayout()
            Me.descriptionLabel = New Label
            Me.descriptionLabel.Location = New Point(8, 8)
            Me.descriptionLabel.Size = New Size(584, 24)
            Me.descriptionLabel.TabIndex = 3
            Me.descriptionLabel.Anchor = (AnchorStyles.Right Or (AnchorStyles.Left Or AnchorStyles.Top))
            Me.descriptionLabel.TextAlign = ContentAlignment.BottomLeft
            Me.descriptionLabel.Text = service1.GetString("Longkong.Core.Services.ErrorDialogs.DescriptionLabel")
            Me.descriptionLabel.Name = "descriptionLabel"
            MyBase.Controls.Add(Me.descriptionLabel)
            Me.descriptionTextBox = New TextBox
            Me.descriptionTextBox.Name = "descriptionTextBox"
            Me.descriptionTextBox.Multiline = True
            Me.descriptionTextBox.Size = New Size(584, 237)
            Me.descriptionTextBox.Location = New Point(8, 40)
            Me.descriptionTextBox.TabIndex = 2
            Me.descriptionTextBox.Anchor = (AnchorStyles.Right Or (AnchorStyles.Left Or (AnchorStyles.Bottom Or AnchorStyles.Top)))
            Me.descriptionTextBox.ReadOnly = True
            MyBase.Controls.Add(Me.descriptionTextBox)
            Me.exceptionButton = New Button
            Me.exceptionButton.TabIndex = 1
            Me.exceptionButton.Name = "exceptionButton"
            Me.exceptionButton.Anchor = (AnchorStyles.Right Or AnchorStyles.Bottom)
            Me.exceptionButton.Text = service1.GetString("Longkong.Core.Services.ErrorDialogs.ShowExceptionButton")
            Me.exceptionButton.Size = New Size(120, 27)
            Me.exceptionButton.Location = New Point(372, 285)
            AddHandler Me.exceptionButton.Click, New EventHandler(AddressOf Me.ShowException)
            MyBase.Controls.Add(Me.exceptionButton)
            Me.okButton = New Button
            Me.okButton.Name = "okButton"
            Me.okButton.TabIndex = 0
            Me.okButton.Anchor = (AnchorStyles.Right Or AnchorStyles.Bottom)
            Me.okButton.Text = service1.GetString("Global.OKButtonText")
            Me.okButton.Size = New Size(120, 27)
            Me.okButton.Location = New Point(244, 285)
            Me.okButton.DialogResult = DialogResult.OK
            MyBase.Controls.Add(Me.okButton)
            MyBase.MaximizeBox = False
            MyBase.Name = "SaveErrorInformDialog"
            MyBase.MinimizeBox = False
            MyBase.FormBorderStyle = FormBorderStyle.FixedDialog
            MyBase.ShowInTaskbar = False
            MyBase.StartPosition = FormStartPosition.CenterScreen
            MyBase.ResumeLayout(False)
            MyBase.Size = New Size(526, 262)
        End Sub
#End Region

#Region "Methods"
        Private Sub ShowException(ByVal sender As Object, ByVal e As EventArgs)
            Dim service1 As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
            service1.ShowMessage(Me.exceptionGot.ToString, "Exception got")
        End Sub
#End Region

    End Class
End Namespace

