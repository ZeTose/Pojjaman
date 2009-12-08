Imports Longkong.Core.AddIns.Codons
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Gui
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Pojjaman.Gui.Dialogs
Namespace Longkong.Pojjaman.Commands
    Public Class ViewMenuBuilder
        Implements ISubmenuBuilder

#Region "Constructors"
        Public Sub New()
        End Sub
#End Region

#Region "Properties"
        Protected Overridable ReadOnly Property Category() As String
            Get
                Return Nothing
            End Get
        End Property
#End Region

#Region "ISubmenuBuilder"
        Public Function BuildSubmenu(ByVal conditionCollection As Core.AddIns.Conditions.ConditionCollection, ByVal owner As Object) As System.Windows.Forms.CommandBarItem() Implements Core.AddIns.Codons.ISubmenuBuilder.BuildSubmenu
            Dim items As New ArrayList
            For Each content As IPadContent In WorkbenchSingleton.Workbench.PadContentCollection
                If (content.Category = Me.Category) Then
                    items.Add(New MyMenuItem(content))
                End If
            Next
            Return CType(items.ToArray(GetType(CommandBarItem)), CommandBarItem())
        End Function
#End Region

#Region "MyMenuItem Class"
        Private Class MyMenuItem
            Inherits PJMMenuCheckBox

#Region "Members"
            Private m_padContent As IPadContent
#End Region

#Region "Constructors"
            Public Sub New(ByVal padContent As IPadContent)
                MyBase.New(Nothing, Nothing, padContent.Title)
                Me.m_padContent = padContent
                MyBase.IsChecked = Me.IsPadVisible
            End Sub
#End Region

#Region "Properties"
            Private ReadOnly Property IsPadVisible() As Boolean
                Get
                    Return WorkbenchSingleton.Workbench.WorkbenchLayout.IsVisible(Me.m_padContent)
                End Get
            End Property
#End Region

#Region "Methods"
            Protected Overrides Sub OnClick(ByVal e As EventArgs)
                MyBase.OnClick(e)
                If Me.IsPadVisible Then
                    WorkbenchSingleton.Workbench.WorkbenchLayout.HidePad(Me.m_padContent)
                Else
                    WorkbenchSingleton.Workbench.WorkbenchLayout.ShowPad(Me.m_padContent)
                End If
                MyBase.IsChecked = Me.IsPadVisible
            End Sub
            Public Overrides Sub UpdateStatus()
                MyBase.UpdateStatus()
                MyBase.IsChecked = Me.IsPadVisible
            End Sub
#End Region

        End Class
#End Region

    End Class
End Namespace
