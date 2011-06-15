Imports Longkong.Pojjaman.Gui.Components
Namespace Longkong.Pojjaman.Gui.Panels
    Public Interface IValidatable

        ReadOnly Property FormValidator() As PJMTextboxValidator

  End Interface

  Public Interface ISecurityValidatable
    ReadOnly Property FormSecurityValidator() As SecurityValidator
  End Interface
End Namespace

