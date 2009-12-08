Imports System
Imports System.Collections
Imports System.Reflection
Imports Longkong.Core.AddIns.Conditions
Namespace Longkong.Core.AddIns.Codons
    Public Interface IWizardPanel
        Inherits IDialogPanel
        ' Events
        Event EnableCancelChanged As EventHandler
        Event EnableNextChanged As EventHandler
        Event EnablePreviousChanged As EventHandler
        Event FinishPanelRequested As EventHandler
        Event IsLastPanelChanged As EventHandler
        Event NextWizardPanelIDChanged As EventHandler

        ' Properties
        Property EnableCancel() As Boolean
        Property EnableNext() As Boolean
        Property EnablePrevious() As Boolean
        Property IsLastPanel() As Boolean
        Property NextWizardPanelID() As String
    End Interface

End Namespace
