Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.TextHelper
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Namespace Longkong.Pojjaman.Gui.Panels
    Public Interface IAccessPanel
        Property AccessValue() As Integer
        Property Value() As Decimal
        Sub SetToFull()
        Sub SetToNone()
    End Interface
End Namespace