Imports Longkong.Core.AddIns.Codons
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.AddIns.Conditions
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Gui
Namespace Longkong.Pojjaman.Commands
    Public Class SelectionMenuBuilder
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
            Dim content As IPadContent
            For Each content In WorkbenchSingleton.Workbench.PadContentCollection
                If (content.Category = Me.Category) Then
                    items.Add(New MyMenuItem(content))
                End If
            Next
            Return CType(items.ToArray(GetType(CommandBarItem)), CommandBarItem())
        End Function
#End Region

#Region "MyMenuItem Class"
        Private Class MyMenuItem
            Inherits PJMMenuCommand

#Region "Members"
            Private m_padContent As IPadContent
#End Region

#Region "Constructors"
            Public Sub New(ByVal padContent As IPadContent)
                MyBase.New(CType(Nothing, ConditionCollection), CType(Nothing, Object), padContent.Title)
                Me.m_padContent = padContent
                If (Not padContent.Icon Is Nothing) Then
                    Dim myIconService As IconService = CType(ServiceManager.Services.GetService(GetType(IconService)), IconService)
                    MyBase.Image = myIconService.GetBitmap(padContent.Icon)
                End If
                If (padContent.Shortcut Is Nothing) Then
                    Return
                End If
                Try
                    Dim shortcuts As String() = padContent.Shortcut
                    For Each shortcut As String In shortcuts
                        MyBase.Shortcut = (MyBase.Shortcut Or CType([Enum].Parse(GetType(Keys), shortcut), Keys))
                    Next
                Catch ex As Exception
                    MyBase.Shortcut = Keys.None
                End Try
            End Sub
#End Region

#Region "Methods"
            Protected Overrides Sub OnClick(ByVal e As EventArgs)
                MyBase.OnClick(e)
                Me.m_padContent.BringPadToFront()
            End Sub
#End Region

        End Class
#End Region

    End Class
End Namespace
