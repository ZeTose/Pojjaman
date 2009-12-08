Imports System
Imports System.Collections
Imports System.Reflection
Imports Longkong.Core.AddIns.Conditions
Namespace Longkong.Core.AddIns.Codons
    Public Enum DialogMessage
        Activated = 6
        Cancel = 1
        Finish = 5
        Help = 2
        [Next] = 3
        OK = 0
        Prev = 4
    End Enum
    Public Interface IDialogPanel
        ' Events
        Event EnableFinishChanged As EventHandler
        ' Methods
        Function ReceiveDialogMessage(ByVal message As DialogMessage) As Boolean
        ' Properties
        ReadOnly Property Control() As Control
        Property CustomizationObject() As Object
        Property EnableFinish() As Boolean
    End Interface
End Namespace
