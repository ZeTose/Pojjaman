Imports Longkong.Pojjaman.Gui.XmlForms
Imports Longkong.Core.Properties
Imports System.IO
Imports Longkong.Core.AddIns
Imports Longkong.Core.AddIns.Codons
Namespace Longkong.Pojjaman.Gui.Dialogs
    Public Class TabbedOptions
        Inherits BasePojjamanForm

#Region "Members"
        Private m_optionPanels As ArrayList
        Private m_properties As IProperties
#End Region

#Region "Constructors"
        Public Sub New(ByVal dialogName As String, ByVal properties As IProperties, ByVal node As IAddInTreeNode)
            Me.m_optionPanels = New ArrayList
            Me.m_properties = Nothing
            Me.m_properties = properties
            MyBase.SetupFromXml(Path.Combine(BasePojjamanForm.PropertyService.DataDirectory, "resources\dialogs\TabbedOptionsDialog.xfrm"))
            Me.Text = dialogName
            AddHandler MyBase.ControlDictionary("okButton").Click, New EventHandler(AddressOf Me.AcceptEvent)
            MyBase.Icon = Nothing
            MyBase.Owner = CType(WorkbenchSingleton.Workbench, Form)
            Me.AddOptionPanels(node.BuildChildItems(Me))
        End Sub
#End Region

#Region "Methods"
        Private Sub AcceptEvent(ByVal sender As Object, ByVal e As EventArgs)
            Dim panel As AbstractOptionPanel
            For Each panel In Me.m_optionPanels
                If Not panel.ReceiveDialogMessage(DialogMessage.OK) Then
                    Return
                End If
            Next
            MyBase.DialogResult = DialogResult.OK
        End Sub
        Private Sub AddOptionPanels(ByVal dialogPanelDescriptors As ArrayList)
            For Each desc As IDialogPanelDescriptor In dialogPanelDescriptors
                If (((Not desc Is Nothing) AndAlso (Not desc.DialogPanel Is Nothing)) AndAlso (Not desc.DialogPanel.Control Is Nothing)) Then
                    desc.DialogPanel.CustomizationObject = Me.m_properties
                    desc.DialogPanel.Control.Dock = DockStyle.Fill
                    desc.DialogPanel.ReceiveDialogMessage(DialogMessage.Activated)
                    Me.m_optionPanels.Add(desc.DialogPanel)
                    Dim page1 As New TabPage(desc.Label)
                    page1.Controls.Add(desc.DialogPanel.Control)
                    CType(MyBase.ControlDictionary.Item("optionPanelTabControl"), TabControl).TabPages.Add(page1)
                End If
                If (Not desc.DialogPanelDescriptors Is Nothing) Then
                    Me.AddOptionPanels(desc.DialogPanelDescriptors)
                End If
            Next
        End Sub
#End Region

    End Class
End Namespace

