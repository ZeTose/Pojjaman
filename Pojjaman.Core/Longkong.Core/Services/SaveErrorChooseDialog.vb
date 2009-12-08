Imports System.Windows.Forms
Imports System.Drawing
Imports System.IO
Imports Longkong.Core.Services
Namespace Longkong.Core.Services
    Public Class SaveErrorChooseDialog
        Inherits Form

#Region "Members"
        Private chooseLocationButton As Button
        Private descriptionLabel As Label
        Private descriptionTextBox As TextBox
        Private displayMessage As String
        Private exceptionButton As Button
        Private exceptionGot As Exception
        Private ignoreButton As Button
        Private retryButton As Button
#End Region

#Region "Constructors"
        Public Sub New(ByVal fileName As String, ByVal message As String, ByVal dialogName As String, ByVal exceptionGot As Exception, ByVal chooseLocationEnabled As Boolean)
            Dim service1 As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
            Me.Text = service1.Parse(dialogName)
            Me.InitializeComponents(chooseLocationEnabled)
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
            Me.descriptionTextBox.Lines = service1.Parse(Me.displayMessage).Split(chArray1)
            Me.exceptionGot = exceptionGot
        End Sub
        Private Sub InitializeComponents(ByVal chooseLocationEnabled As Boolean)
            Dim service1 As IResourceService = CType(ServiceManager.Services.GetService(GetType(IResourceService)), IResourceService)
            MyBase.ClientSize = New Size(508, 320)
            MyBase.SuspendLayout()
            MyBase.MaximizeBox = False
            MyBase.MinimizeBox = False
            MyBase.Name = "SaveErrorChooseDialog"
            MyBase.FormBorderStyle = FormBorderStyle.FixedDialog
            MyBase.ShowInTaskbar = False
            MyBase.StartPosition = FormStartPosition.CenterScreen
            Me.descriptionLabel = New Label
            Me.descriptionLabel.Name = "descriptionLabel"
            Me.descriptionLabel.Location = New Point(8, 8)
            Me.descriptionLabel.Size = New Size(584, 24)
            Me.descriptionLabel.TabIndex = 3
            Me.descriptionLabel.Anchor = (AnchorStyles.Right Or (AnchorStyles.Left Or AnchorStyles.Top))
            Me.descriptionLabel.TextAlign = ContentAlignment.BottomLeft
            Me.descriptionLabel.Text = service1.GetString("Longong.Core.Services.ErrorDialogs.DescriptionLabel")
            MyBase.Controls.Add(Me.descriptionLabel)
            Me.descriptionTextBox = New TextBox
            Me.descriptionTextBox.Multiline = True
            Me.descriptionTextBox.Size = New Size(584, 237)
            Me.descriptionTextBox.Location = New Point(8, 40)
            Me.descriptionTextBox.TabIndex = 2
            Me.descriptionTextBox.Anchor = (AnchorStyles.Right Or (AnchorStyles.Left Or (AnchorStyles.Bottom Or AnchorStyles.Top)))
            Me.descriptionTextBox.ReadOnly = True
            Me.descriptionTextBox.Name = "descriptionTextBox"
            MyBase.Controls.Add(Me.descriptionTextBox)
            Me.retryButton = New Button
            Me.retryButton.DialogResult = DialogResult.Retry
            Me.retryButton.Name = "retryButton"
            Me.retryButton.TabIndex = 5
            Me.retryButton.Anchor = (AnchorStyles.Right Or AnchorStyles.Bottom)
            Me.retryButton.Text = service1.GetString("Global.RetryButtonText")
            Me.retryButton.Size = New Size(110, 27)
            Me.retryButton.Location = New Point(28, 285)
            MyBase.Controls.Add(Me.retryButton)
            Me.ignoreButton = New Button
            Me.ignoreButton.Name = "ignoreButton"
            Me.ignoreButton.DialogResult = DialogResult.Ignore
            Me.ignoreButton.TabIndex = 4
            Me.ignoreButton.Anchor = (AnchorStyles.Right Or AnchorStyles.Bottom)
            Me.ignoreButton.Text = service1.GetString("Global.IgnoreButtonText")
            Me.ignoreButton.Size = New Size(110, 27)
            Me.ignoreButton.Location = New Point(146, 285)
            MyBase.Controls.Add(Me.ignoreButton)
            Me.exceptionButton = New Button
            Me.exceptionButton.TabIndex = 1
            Me.exceptionButton.Anchor = (AnchorStyles.Right Or AnchorStyles.Bottom)
            Me.exceptionButton.Name = "exceptionButton"
            Me.exceptionButton.Text = service1.GetString("Longkong.Core.Services.ErrorDialogs.ShowExceptionButton")
            Me.exceptionButton.Size = New Size(110, 27)
            Me.exceptionButton.Location = New Point(382, 285)
            AddHandler Me.exceptionButton.Click, New EventHandler(AddressOf Me.ShowException)
            MyBase.Controls.Add(Me.exceptionButton)
            If chooseLocationEnabled Then
                Me.chooseLocationButton = New Button
                Me.chooseLocationButton.Name = "chooseLocationButton"
                Me.chooseLocationButton.DialogResult = DialogResult.OK
                Me.chooseLocationButton.TabIndex = 0
                Me.chooseLocationButton.Anchor = (AnchorStyles.Right Or AnchorStyles.Bottom)
                Me.chooseLocationButton.Text = service1.GetString("Global.ChooseLocationButtonText")
                Me.chooseLocationButton.Size = New Size(110, 27)
                Me.chooseLocationButton.Location = New Point(264, 285)
            End If
            MyBase.Controls.Add(Me.chooseLocationButton)
            MyBase.ResumeLayout(False)
            MyBase.Size = New Size(526, 262)
        End Sub
#End Region

#Region "Methods"
        Private Sub ShowException(ByVal sender As Object, ByVal e As EventArgs)
            Dim service1 As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
            Dim service2 As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
            service2.ShowMessage(Me.exceptionGot.ToString, service1.Parse("${res:Longkong.Core.Services.ErrorDialogs.ExceptionGotDescription}"))
        End Sub
#End Region

    End Class
End Namespace
