Imports Longkong.Core.AddIns.Codons
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.AddIns.Conditions
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Gui
Imports Longkong.Pojjaman.Gui.Components
Namespace Longkong.Pojjaman.Commands
    Public Class OpenContentsMenuBuilder
        Implements ISubmenuBuilder

#Region "Constructors"
        Public Sub New()
        End Sub
#End Region

#Region "ISubmenuBuilder"
        Public Function BuildSubmenu(ByVal conditionCollection As Core.AddIns.Conditions.ConditionCollection, ByVal owner As Object) As System.Windows.Forms.CommandBarItem() Implements Core.AddIns.Codons.ISubmenuBuilder.BuildSubmenu
            Dim count As Integer = WorkbenchSingleton.Workbench.ViewContentCollection.Count
            If (count = 0) Then
                Return New CommandBarItem(0 - 1) {}
            End If
            Dim items As CommandBarItem() = New CommandBarItem((count + 1) - 1) {}
            items(0) = New PJMMenuSeparator(Nothing, Nothing)
            For i As Integer = 0 To count - 1
                Dim content As IViewContent = WorkbenchSingleton.Workbench.ViewContentCollection.Item(i)
                Dim item As New MyMenuItem(content.WorkbenchWindow)
                item.Tag = content.WorkbenchWindow
                item.IsChecked = (WorkbenchSingleton.Workbench.ActiveWorkbenchWindow Is content.WorkbenchWindow)
                item.Description = "Activate this window "
                items((i + 1)) = item
            Next
            Return items
        End Function
#End Region

#Region "MyMenuItem Class"
        Private Class MyMenuItem
            Inherits PJMMenuCheckBox

#Region "Members"
            Private m_window As IWorkbenchWindow
#End Region

#Region "Constructors"
            Public Sub New(ByVal window As IWorkbenchWindow)
                MyBase.New(Nothing, Nothing, window.ViewContent.TitleName)
                Me.m_window = window
            End Sub
#End Region

#Region "Methods"
            Protected Overrides Sub OnClick(ByVal e As EventArgs)
                MyBase.OnClick(e)
                CType(Me.Tag, IWorkbenchWindow).SelectWindow()
                MyBase.IsChecked = True
            End Sub
            Public Overrides Sub UpdateStatus()
                If (Not Me.m_window Is Nothing) Then
                    Me.m_localizedText = Me.m_window.ViewContent.TitleName
                End If
                MyBase.UpdateStatus()
            End Sub
#End Region

        End Class
#End Region

    End Class
End Namespace
