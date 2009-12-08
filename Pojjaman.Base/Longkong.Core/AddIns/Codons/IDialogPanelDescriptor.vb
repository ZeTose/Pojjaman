Imports System
Imports System.Collections
Imports System.Reflection
Imports Longkong.Core.AddIns.Conditions
Namespace Longkong.Core.AddIns.Codons
    Public Interface IDialogPanelDescriptor
        ' Properties
        Property DialogPanel() As IDialogPanel
        Property DialogPanelDescriptors() As ArrayList
        ReadOnly Property ID() As String
        Property Label() As String
    End Interface
End Namespace
