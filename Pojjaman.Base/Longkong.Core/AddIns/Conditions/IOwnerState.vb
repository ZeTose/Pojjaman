Imports System
Imports System.Collections
Imports System.Reflection
Imports Longkong.Core.AddIns.Conditions
Imports System.IO
Imports Longkong.Pojjaman.Gui
Namespace Longkong.Core.AddIns
    Public Interface IOwnerState
        ' Properties
        ReadOnly Property InternalState() As [Enum]
    End Interface
End Namespace
