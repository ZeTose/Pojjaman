Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Imports Longkong.Core.Properties
Imports System.Xml
Imports System.IO
Namespace Longkong.Pojjaman.Gui.Dialogs
    Public Class TipOfTheDayDialog
        Inherits Form

#Region "Members"
        Private m_closeButton As Button
        Private m_nextTipButton As Button
        Private m_panel As Panel
        Private m_propertyService As PropertyService
        Private m_resourceService As ResourceService
        Private m_tipview As TipOfTheDayView
        Private m_viewTipsAtStartCheckBox As CheckBox
#End Region

#Region "Constructors"
        Public Sub New()
            Dim tipSize As Integer
            Me.m_panel = New Panel
            Me.m_resourceService = CType(ServiceManager.Services.GetService(GetType(IResourceService)), ResourceService)
            Me.m_propertyService = CType(ServiceManager.Services.GetService(GetType(PropertyService)), PropertyService)
            Me.InitializeComponent()
            MyBase.StartPosition = FormStartPosition.CenterScreen
            MyBase.Icon = Nothing
            Dim myPropertyService As PropertyService = CType(ServiceManager.Services.GetService(GetType(PropertyService)), PropertyService)
            Dim doc As New XmlDocument
            Dim objArray1 As Object() = New Object() {myPropertyService.DataDirectory, Path.DirectorySeparatorChar, "options", Path.DirectorySeparatorChar, "TipsOfTheDay.xml"}
            doc.Load(String.Concat(objArray1))
            Me.m_tipview = New TipOfTheDayView(doc.DocumentElement)
            Me.m_panel.Controls.Add(Me.m_tipview)
            MyBase.Controls.Add(Me.m_panel)
            tipSize = (MyBase.Width - 24)
            Me.m_tipview.Width = tipSize
            Me.m_panel.Width = tipSize
            tipSize = (Me.m_nextTipButton.Top - 15)
            Me.m_tipview.Height = tipSize
            Me.m_panel.Height = tipSize
            Me.m_panel.Location = New Point(8, 5)
            AddHandler Me.m_nextTipButton.Click, New EventHandler(AddressOf Me.NextTip)
            AddHandler Me.m_viewTipsAtStartCheckBox.CheckedChanged, New EventHandler(AddressOf Me.CheckChange)
            Me.m_viewTipsAtStartCheckBox.Checked = myPropertyService.GetProperty("Longkong.Pojjaman.Gui.Dialog.TipOfTheDayView.ShowTipsAtStartup", True)
            MyBase.MinimizeBox = False
            MyBase.MaximizeBox = False
            MyBase.ShowInTaskbar = False
        End Sub
#End Region

#Region "Methods"
        Private Sub CheckChange(ByVal sender As Object, ByVal e As EventArgs)
            Me.m_propertyService.SetProperty("Longkong.Pojjaman.Gui.Dialog.TipOfTheDayView.ShowTipsAtStartup", Me.m_viewTipsAtStartCheckBox.Checked)
        End Sub
        Private Sub ExitDialog(ByVal sender As Object, ByVal e As EventArgs)
            MyBase.Close()
            MyBase.Dispose()
        End Sub
        Private Sub InitializeComponent()
            Me.m_closeButton = New Button
            Me.m_viewTipsAtStartCheckBox = New CheckBox
            Me.m_nextTipButton = New Button
            Me.m_closeButton.Location = New Point(328, 232)
            AddHandler Me.m_closeButton.Click, New EventHandler(AddressOf Me.ExitDialog)
            Me.m_closeButton.Size = New Size(80, 24)
            Me.m_closeButton.TabIndex = 1
            Me.m_closeButton.Text = Me.m_resourceService.GetString("Global.CloseButtonText")
            Me.m_closeButton.FlatStyle = FlatStyle.System
            Me.m_viewTipsAtStartCheckBox.Location = New Point(8, 232)
            Me.m_viewTipsAtStartCheckBox.Text = Me.m_resourceService.GetString("Dialog.TipOfTheDay.checkBox1Text")
            Me.m_viewTipsAtStartCheckBox.Size = New Size(210, 24)
            Me.m_viewTipsAtStartCheckBox.TabIndex = 2
            Me.m_viewTipsAtStartCheckBox.TextAlign = ContentAlignment.MiddleLeft
            Me.m_viewTipsAtStartCheckBox.FlatStyle = FlatStyle.System
            Me.AutoScaleBaseSize = New Size(5, 13)
            Me.Text = Me.m_resourceService.GetString("Dialog.TipOfTheDay.DialogName")
            MyBase.FormBorderStyle = FormBorderStyle.FixedDialog
            MyBase.ClientSize = New Size(418, 263)
            Me.m_nextTipButton.Location = New Point(224, 232)
            Me.m_nextTipButton.Size = New Size(96, 24)
            Me.m_nextTipButton.TabIndex = 0
            Me.m_nextTipButton.Text = Me.m_resourceService.GetString("Dialog.TipOfTheDay.button1Text")
            Me.m_nextTipButton.FlatStyle = FlatStyle.System
            MyBase.Controls.Add(Me.m_viewTipsAtStartCheckBox)
            MyBase.Controls.Add(Me.m_closeButton)
            MyBase.Controls.Add(Me.m_nextTipButton)
        End Sub
        Private Sub NextTip(ByVal sender As Object, ByVal e As EventArgs)
            Me.m_tipview.NextTip()
        End Sub
#End Region
    End Class
End Namespace

