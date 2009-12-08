Imports Longkong.Pojjaman.Gui.XmlForms
Imports Longkong.Pojjaman.Gui.Dialogs
Imports Longkong.Core.Services
Imports Longkong.Core.Properties
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.AddIns.Codons
Namespace Longkong.Pojjaman.Gui.Dialogs.OptionPanels
    Public Class PojjamanOptionPanel
        Inherits AbstractOptionPanel

#Region "Members"
        Private m_listView As listView
        Private m_newCulture As Label
        Private m_propertyService As PropertyService
        Private m_resourceService As ResourceService
        Private Shared ReadOnly m_uiLanguageProperty As String = "CoreProperties.UILanguage"
#End Region

#Region "Constructors"
        Public Sub New()
            Me.m_listView = New ListView
            Me.m_newCulture = New Label
            Me.m_resourceService = CType(ServiceManager.Services.GetService(GetType(IResourceService)), ResourceService)
            Me.m_propertyService = CType(ServiceManager.Services.GetService(GetType(PropertyService)), PropertyService)
            Dim service1 As LanguageService = CType(ServiceManager.Services.GetService(GetType(LanguageService)), LanguageService)
            Me.m_listView.Location = New Point(8, 8)
            Me.m_listView.Size = New Size(136, 200)
            Me.m_listView.LargeImageList = service1.LanguageImageList
            'Me.m_listView.SmallImageList = service1.LanguageImageList
            Me.m_listView.View = View.Details
            Me.m_listView.Columns.Add("Language", 300, HorizontalAlignment.Left)
            AddHandler Me.m_listView.ItemActivate, New EventHandler(AddressOf Me.ChangeCulture)
            Me.m_listView.Sorting = SortOrder.Ascending
            Me.m_listView.Activation = ItemActivation.OneClick
            Me.m_listView.HideSelection = False
            Me.m_listView.Anchor = (AnchorStyles.Right Or (AnchorStyles.Left Or AnchorStyles.Top))
            For Each language As language In service1.Languages
                Dim textArray1 As String() = New String() {language.Name, language.Code}
                Me.m_listView.Items.Add(New ListViewItem(textArray1, language.ImageIndex))
            Next
            MyBase.Controls.Add(Me.m_listView)

            Dim label1 As New Label
            label1.Location = New Point(8, 220)
            label1.Size = New Size(350, 16)
            label1.Anchor = (AnchorStyles.Right Or (AnchorStyles.Left Or AnchorStyles.Top))

            Me.Dock = DockStyle.Fill
            label1.Text = (Me.m_resourceService.GetString("Dialog.Options.IDEOptions.SelectCulture.CurrentUILanguageLabel") & " " & Me.GetCulture(Me.m_propertyService.GetProperty(PojjamanOptionPanel.m_uiLanguageProperty, "en")))
            MyBase.Controls.Add(label1)
            Dim label2 As New Label
            label2.Location = New Point(8, 280)
            label2.Size = New Size(390, 50)
            label2.Text = Me.m_resourceService.GetString("Dialog.Options.IDEOptions.SelectCulture.DescriptionText")
            label2.Anchor = (AnchorStyles.Right Or (AnchorStyles.Left Or AnchorStyles.Top))
            MyBase.Controls.Add(label2)
            Me.m_newCulture.Location = New Point(8, 240)
            Me.m_newCulture.Size = New Size(360, 50)
            Me.m_newCulture.Anchor = (AnchorStyles.Right Or (AnchorStyles.Left Or AnchorStyles.Top))
            MyBase.Controls.Add(Me.m_newCulture)
        End Sub
#End Region

#Region "Properties"
        Private ReadOnly Property SelectedCountry() As String
            Get
                If (Me.m_listView.SelectedItems.Count > 0) Then
                    Return Me.m_listView.SelectedItems(0).Text
                End If
                Return Nothing
            End Get
        End Property
        Private ReadOnly Property SelectedCulture() As String
            Get
                If (Me.m_listView.SelectedItems.Count > 0) Then
                    Return Me.m_listView.SelectedItems(0).SubItems(1).Text
                End If
                Return Nothing
            End Get
        End Property
#End Region

#Region "Methods"
        Private Sub ChangeCulture(ByVal sender As Object, ByVal e As EventArgs)
            Me.m_newCulture.Text = (Me.m_resourceService.GetString("Dialog.Options.IDEOptions.SelectCulture.UILanguageSetToLabel") & " " & Me.SelectedCountry)
        End Sub
        Private Function GetCulture(ByVal languageCode As String) As String
            Dim service1 As LanguageService = CType(ServiceManager.Services.GetService(GetType(LanguageService)), LanguageService)
            For Each language As language In service1.Languages
                If languageCode.StartsWith(language.Code) Then
                    Return language.Name
                End If
            Next
            Return "English"
        End Function
        Public Overrides Function ReceiveDialogMessage(ByVal message As DialogMessage) As Boolean
            If ((message = DialogMessage.OK) AndAlso (Not Me.SelectedCulture Is Nothing)) Then
                Me.m_propertyService.SetProperty(PojjamanOptionPanel.m_uiLanguageProperty, Me.SelectedCulture)
            End If
            Return True
        End Function
#End Region

    End Class
End Namespace

