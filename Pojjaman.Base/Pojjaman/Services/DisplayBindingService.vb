Imports System.Windows.Forms
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Internal.Parser
Imports Longkong.Core.AddIns.Codons
Imports Longkong.Core.AddIns
Imports Longkong.Pojjaman.Gui
Namespace Longkong.Pojjaman.Services
    Public Class DisplayBindingService
        Inherits AbstractService

#Region "Members"
        Private m_bindings As DisplayBindingCodon()
        Private Shared ReadOnly m_displayBindingPath As String = "/Pojjaman/Workbench/DisplayBindings"
#End Region

#Region "Constructors"
        Public Sub New()
            Me.m_bindings = CType(AddInTreeSingleton.AddInTree.GetTreeNode(DisplayBindingService.m_displayBindingPath).BuildChildItems(Me).ToArray(GetType(DisplayBindingCodon)), DisplayBindingCodon())
        End Sub
#End Region

#Region "Methods"
        Public Sub AttachSubWindows(ByVal workbenchWindow As IWorkbenchWindow)
            For Each codon As DisplayBindingCodon In Me.m_bindings
                If ((Not codon.SecondaryDisplayBinding Is Nothing) AndAlso codon.SecondaryDisplayBinding.CanAttachTo(workbenchWindow.ViewContent)) Then
                    Dim contents As ISecondaryViewContent() = codon.SecondaryDisplayBinding.CreateSecondaryViewContent(workbenchWindow.ViewContent)
                    If (Not contents Is Nothing) Then
                        For Each content As ISecondaryViewContent In contents
                            workbenchWindow.AttachSecondaryViewContent(content)
                        Next
                    Else
                        Dim myMessageService As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
                        myMessageService.ShowError(("Can't attach secondary view content. " & workbenchWindow.ViewContent.FileName & " returned nothing." & ChrW(10) & "(should never happen)"))
                    End If
                End If
            Next
        End Sub
        Public Function GetBindingPerFileName(ByVal filename As String) As IDisplayBinding
            Dim codon As DisplayBindingCodon = Me.GetCodonPerFileName(filename)
            If (Not codon Is Nothing) Then
                Return codon.DisplayBinding
            End If
            Return Nothing
        End Function
        Public Function GetBindingPerLanguageName(ByVal languagename As String) As IDisplayBinding
            Dim codon As DisplayBindingCodon = Me.GetCodonPerLanguageName(languagename)
            If (Not codon Is Nothing) Then
                Return codon.DisplayBinding
            End If
            Return Nothing
        End Function
        Public Function GetCodonPerFileName(ByVal filename As String) As DisplayBindingCodon
            For Each codon As DisplayBindingCodon In Me.m_bindings
                If ((Not codon.DisplayBinding Is Nothing) AndAlso codon.DisplayBinding.CanCreateContentForFile(filename)) Then
                    Return codon
                End If
            Next
            Return Nothing
        End Function
        Public Function GetCodonPerLanguageName(ByVal languagename As String) As DisplayBindingCodon
            For Each codon As DisplayBindingCodon In Me.m_bindings
                If ((Not codon.DisplayBinding Is Nothing) AndAlso codon.DisplayBinding.CanCreateContentForLanguage(languagename)) Then
                    Return codon
                End If
            Next
            Return Nothing
        End Function
        Public Function GetCodonPerType(ByVal type As Type) As DisplayBindingCodon
            For Each codon As DisplayBindingCodon In Me.m_bindings
                If (Not codon.DisplayBinding Is Nothing) AndAlso codon.DisplayBinding.CanCreateContentForPanel(type) Then
                    Return codon
                End If
            Next
            Return Nothing
        End Function
#End Region

    End Class
End Namespace



