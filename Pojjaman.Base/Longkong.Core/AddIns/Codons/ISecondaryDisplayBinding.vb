Imports System
Imports System.Collections
Imports System.Reflection
Imports Longkong.Core.AddIns.Conditions
Imports Longkong.Pojjaman.Gui

Namespace Longkong.Core.AddIns.Codons
    Public Interface ISecondaryDisplayBinding
        ' Methods
        Function CanAttachTo(ByVal content As IViewContent) As Boolean
        Function CreateSecondaryViewContent(ByVal viewContent As IViewContent) As ISecondaryViewContent()
    End Interface
End Namespace
