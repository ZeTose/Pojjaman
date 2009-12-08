Imports System
Imports System.Collections
Imports System.Reflection
Imports Longkong.Core.AddIns.Conditions
Imports Longkong.Pojjaman.Gui
Namespace Longkong.Core.AddIns.Codons
    Public Interface IDisplayBinding
        ' Methods
        Function CanCreateContentForPanel(ByVal type As Type) As Boolean
        Function CanCreateContentForFile(ByVal fileName As String) As Boolean
        Function CanCreateContentForLanguage(ByVal languageName As String) As Boolean
        Function CreateContentForPanel(ByVal type As Type, ByVal args As String) As IViewContent
        Function CreateContentForFile(ByVal fileName As String) As IViewContent
        Function CreateContentForLanguage(ByVal languageName As String, ByVal content As String) As IViewContent
    End Interface
End Namespace
