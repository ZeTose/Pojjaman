Imports System.IO
Imports Longkong.Pojjaman.Gui.XmlForms
Namespace Longkong.Pojjaman.Gui.Dialogs.OptionPanels
    Public Class LoadSavePanel
        Inherits AbstractOptionPanel

#Region "Members"
        Private Const createBackupCopyCheckBox As String = "createBackupCopyCheckBox"
        Private Const lineTerminatorStyleComboBox As String = "lineTerminatorStyleComboBox"
        Private Const loadUserDataCheckBox As String = "loadUserDataCheckBox"
#End Region

#Region "Constructors"
        Public Sub New()
        End Sub
#End Region

#Region "Methods"
        Public Overrides Sub LoadPanelContents()
            MyBase.SetupFromXml(Path.Combine(BasePojjamanUserControl.PropertyService.DataDirectory, "resources\panels\LoadSaveOptionPanel.xfrm"))
            CType(MyBase.ControlDictionary.Item("loadUserDataCheckBox"), CheckBox).Checked = BasePojjamanUserControl.PropertyService.GetProperty("Pojjaman.LoadDocumentProperties", True)
            CType(MyBase.ControlDictionary.Item("createBackupCopyCheckBox"), CheckBox).Checked = BasePojjamanUserControl.PropertyService.GetProperty("Pojjaman.CreateBackupCopy", False)
            CType(MyBase.ControlDictionary.Item("lineTerminatorStyleComboBox"), ComboBox).Items.Add(BasePojjamanUserControl.StringParserService.Parse("${res:Dialog.Options.IDEOptions.LoadSaveOptions.WindowsRadioButton}"))
            CType(MyBase.ControlDictionary.Item("lineTerminatorStyleComboBox"), ComboBox).Items.Add(BasePojjamanUserControl.StringParserService.Parse("${res:Dialog.Options.IDEOptions.LoadSaveOptions.MacintoshRadioButton}"))
            CType(MyBase.ControlDictionary.Item("lineTerminatorStyleComboBox"), ComboBox).Items.Add(BasePojjamanUserControl.StringParserService.Parse("${res:Dialog.Options.IDEOptions.LoadSaveOptions.UnixRadioButton}"))
            CType(MyBase.ControlDictionary.Item("lineTerminatorStyleComboBox"), ComboBox).SelectedIndex = CType(CType([Enum].Parse(GetType(LineTerminatorStyle), CStr(BasePojjamanUserControl.PropertyService.GetProperty("Pojjaman.LineTerminatorStyle", CType(LineTerminatorStyle.Windows, Object)))), LineTerminatorStyle), Integer)
        End Sub
        Public Overrides Function StorePanelContents() As Boolean
            BasePojjamanUserControl.PropertyService.SetProperty("Pojjaman.LoadDocumentProperties", CType(MyBase.ControlDictionary.Item("loadUserDataCheckBox"), CheckBox).Checked)
            BasePojjamanUserControl.PropertyService.SetProperty("Pojjaman.CreateBackupCopy", CType(MyBase.ControlDictionary.Item("createBackupCopyCheckBox"), CheckBox).Checked)
            BasePojjamanUserControl.PropertyService.SetProperty("Pojjaman.LineTerminatorStyle", CType(CType(MyBase.ControlDictionary.Item("lineTerminatorStyleComboBox"), ComboBox).SelectedIndex, LineTerminatorStyle))
            Return True
        End Function
#End Region

    End Class
End Namespace

