Imports Longkong.Core.AddIns
Imports System.IO
Imports Longkong.Pojjaman.Gui.XmlForms
Namespace Longkong.Pojjaman.Gui.Dialogs.OptionPanels
    Public Class SelectStylePanel
        Inherits AbstractOptionPanel

#Region "Members"
        Private m_showExtensionsCheckBox As CheckBox
#End Region

#Region "Constructors"
        Public Sub New()
            Me.m_showExtensionsCheckBox = New CheckBox
        End Sub
#End Region

#Region "Methods"
        Public Overrides Sub LoadPanelContents()
            MyBase.SetupFromXml(Path.Combine(BasePojjamanUserControl.PropertyService.DataDirectory, "resources\panels\SelectStylePanel.xfrm"))
            CType(MyBase.ControlDictionary.Item("showExtensionsCheckBox"), CheckBox).Checked = BasePojjamanUserControl.PropertyService.GetProperty("Longkong.Pojjaman.Gui.ProjectBrowser.ShowExtensions", True)
            Dim rootNode As IAddInTreeNode = AddInTreeSingleton.AddInTree.GetTreeNode("/Pojjaman/Workbench/Ambiences")
            For Each node As IAddInTreeNode In rootNode.ChildNodes.Values
                CType(MyBase.ControlDictionary.Item("selectAmbienceComboBox"), ComboBox).Items.Add(node.Codon.ID)
            Next
            CType(MyBase.ControlDictionary.Item("selectAmbienceComboBox"), ComboBox).Text = BasePojjamanUserControl.PropertyService.GetProperty("Pojjaman.UI.CurrentAmbience", "CSharp")
        End Sub
        Public Overrides Function StorePanelContents() As Boolean
            BasePojjamanUserControl.PropertyService.SetProperty("Longkong.Pojjaman.Gui.ProjectBrowser.ShowExtensions", CType(MyBase.ControlDictionary.Item("showExtensionsCheckBox"), CheckBox).Checked)
            BasePojjamanUserControl.PropertyService.SetProperty("Pojjaman.UI.CurrentAmbience", CType(MyBase.ControlDictionary.Item("selectAmbienceComboBox"), ComboBox).Text)
            Return True
        End Function
#End Region

    End Class
End Namespace

