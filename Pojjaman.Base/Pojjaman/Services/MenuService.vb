Imports Longkong.Core.Services
Imports System.Windows.Forms
Imports System.Drawing
Imports Longkong.Pojjaman.Gui
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.AddIns.Codons
Imports Longkong.Core.AddIns
Namespace Longkong.Pojjaman.Services
    Public Class MenuService
        Inherits AbstractService

#Region "Methods"
        Private Sub ContextMenuPopupHandler(ByVal sender As Object, ByVal e As EventArgs)
            Dim menu1 As CommandBarContextMenu = CType(sender, CommandBarContextMenu)
            Dim obj1 As Object
            For Each obj1 In menu1.Items
                If TypeOf obj1 Is IStatusUpdate Then
                    CType(obj1, IStatusUpdate).UpdateStatus()
                End If
            Next
        End Sub
        Public Function CreateContextMenu(ByVal owner As Object, ByVal addInTreePath As String) As ContextMenu
            Dim menu2 As ContextMenu
            Try
                Dim list1 As ArrayList = AddInTreeSingleton.AddInTree.GetTreeNode(addInTreePath).BuildChildItems(owner)
                Dim menu1 As New CommandBarContextMenu
                AddHandler menu1.Popup, New EventHandler(AddressOf Me.ContextMenuPopupHandler)
                Dim obj1 As Object
                For Each obj1 In list1
                    If TypeOf obj1 Is CommandBarItem Then
                        menu1.Items.Add(CType(obj1, CommandBarItem))
                    Else
                        Dim builder1 As ISubmenuBuilder = CType(obj1, ISubmenuBuilder)
                        menu1.Items.AddRange(builder1.BuildSubmenu(Nothing, owner))
                    End If
                Next
                menu2 = menu1
            Catch exception1 As TreePathNotFoundException
                Console.WriteLine(("Warning tree path '" & addInTreePath & "' not found."))
                menu2 = Nothing
            End Try
            Return menu2
        End Function
        Public Sub CreateQuickInsertMenu(ByVal targetControl As TextBoxBase, ByVal popupControl As Control, ByVal quickInsertMenuItems(,) As String)
            Dim stringParserService As stringParserService = CType(ServiceManager.Services.GetService(GetType(stringParserService)), stringParserService)

            Dim contextMenu As New CommandBarContextMenu
            Dim i As Integer

            While i < quickInsertMenuItems.GetLength(0)
                If quickInsertMenuItems(i, 0) = "-" Then
                    contextMenu.Items.Add(New PJMMenuSeparator)
                Else
                    Dim cmd As New PJMMenuCommand(Me, stringParserService.Parse(quickInsertMenuItems(i, 0)), New QuickInsertMenuHandler(targetControl, quickInsertMenuItems(i, 1)).EventHandler)
                    contextMenu.Items.Add(cmd)
                End If
            End While
        End Sub
        Public Sub ShowContextMenu(ByVal owner As Object, ByVal addInTreePath As String, ByVal parent As Control, ByVal x As Integer, ByVal y As Integer)
            Me.CreateContextMenu(owner, addInTreePath).Show(parent, New Point(x, y))
        End Sub
#End Region

        Private Class QuickInsertHandler
#Region "Members"
            Private m_popupControl As Control
            Private m_quickInsertMenu As CommandBarContextMenu
#End Region

#Region "Constructors"
            Public Sub New(ByVal popupControl As Control, ByVal quickInsertMenu As CommandBarContextMenu)
                Me.m_popupControl = popupControl
                Me.m_quickInsertMenu = quickInsertMenu
                AddHandler popupControl.Click, New EventHandler(AddressOf Me.showQuickInsertMenu)
            End Sub
#End Region

#Region "Methods"
            Private Sub showQuickInsertMenu(ByVal sender As Object, ByVal e As EventArgs)
                Dim point1 As Point
                point1 = New Point(Me.m_popupControl.Width, 0)
                Me.m_quickInsertMenu.Show(Me.m_popupControl, point1)
            End Sub
#End Region
        End Class

        Private Class QuickInsertMenuHandler

#Region "Members"
            Private m_targetControl As TextBoxBase
            Private m_text As String
#End Region

#Region "Constructors"
            Public Sub New(ByVal targetControl As TextBoxBase, ByVal [text] As String)
                Me.m_targetControl = targetControl
                Me.m_text = text
            End Sub
#End Region

#Region "Properties"
            Public ReadOnly Property EventHandler() As EventHandler
                Get
                    Return New EventHandler(AddressOf Me.PopupMenuHandler)
                End Get
            End Property
#End Region

#Region "Methods"
            Private Sub PopupMenuHandler(ByVal sender As Object, ByVal e As EventArgs)
                Me.m_targetControl.SelectedText = (Me.m_targetControl.SelectedText & Me.m_text)
            End Sub
#End Region

        End Class
    End Class
End Namespace

