Imports System.IO
Imports Longkong.Pojjaman.Gui.XmlForms
Namespace Longkong.Pojjaman.Gui.Dialogs.OptionPanels
    Public Class TaskListOptions
        Inherits AbstractOptionPanel

#Region "Members"
        Private Const addButton As String = "addButton"
        Private Const changeButton As String = "changeButton"
        Private Const nameTextBox As String = "nameTextBox"
        Private Const removeButton As String = "removeButton"
        Private Const taskListView As String = "taskListView"
#End Region

#Region "Constructors"
        Public Sub New()
        End Sub
#End Region

#Region "Methods"
        Public Overrides Sub LoadPanelContents()
            MyBase.SetupFromXml(Path.Combine(BasePojjamanUserControl.PropertyService.DataDirectory, "resources\panels\TaskListOptions.xfrm"))
            Dim taskListTokens As String = BasePojjamanUserControl.PropertyService.GetProperty("Pojjaman.TaskListTokens", "HACK;TODO;UNDONE;FIXME")
            Dim taskList As String() = taskListTokens.Split(New Char() {";"c})
            CType(MyBase.ControlDictionary(taskListView), ListView).BeginUpdate()
            For Each task As String In taskList
                CType(MyBase.ControlDictionary(taskListView), ListView).Items.Add(New ListViewItem(task))
            Next
            CType(MyBase.ControlDictionary(taskListView), ListView).EndUpdate()
            AddHandler CType(MyBase.ControlDictionary(taskListView), ListView).SelectedIndexChanged, New EventHandler(AddressOf Me.TaskListViewSelectedIndexChanged)
            AddHandler MyBase.ControlDictionary(changeButton).Click, New EventHandler(AddressOf Me.ChangeButtonClick)
            AddHandler MyBase.ControlDictionary(removeButton).Click, New EventHandler(AddressOf Me.RemoveButtonClick)
            AddHandler MyBase.ControlDictionary(addButton).Click, New EventHandler(AddressOf Me.AddButtonClick)
            Me.TaskListViewSelectedIndexChanged(Me, EventArgs.Empty)
        End Sub
        Public Overrides Function StorePanelContents() As Boolean
            Dim taskListTokens As New ArrayList
            For Each item As ListViewItem In CType(MyBase.ControlDictionary(taskListView), ListView).Items
                taskListTokens.Add(item.Text)
            Next
            BasePojjamanUserControl.PropertyService.SetProperty("Pojjaman.TaskListTokens", String.Join(";", CType(taskListTokens.ToArray(GetType(String)), String())))
            Return True
        End Function
        Private Sub AddButtonClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim name As String = MyBase.ControlDictionary(nameTextBox).Text
            For Each item As ListViewItem In CType(MyBase.ControlDictionary(taskListView), ListView).Items
                If (item.Text = name) Then
                    Return
                End If
            Next
            CType(MyBase.ControlDictionary(taskListView), ListView).Items.Add(New ListViewItem(name))
        End Sub
        Private Sub ChangeButtonClick(ByVal sender As Object, ByVal e As EventArgs)
            CType(MyBase.ControlDictionary(taskListView), ListView).SelectedItems(0).Text = MyBase.ControlDictionary(nameTextBox).Text
        End Sub
        Private Sub RemoveButtonClick(ByVal sender As Object, ByVal e As EventArgs)
            CType(MyBase.ControlDictionary(taskListView), ListView).Items.Remove(CType(MyBase.ControlDictionary(taskListView), ListView).SelectedItems(0))
        End Sub
        Private Sub TaskListViewSelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
            If (CType(MyBase.ControlDictionary(taskListView), ListView).SelectedItems.Count > 0) Then
                MyBase.ControlDictionary(nameTextBox).Text = CType(MyBase.ControlDictionary(taskListView), ListView).SelectedItems(0).Text
                MyBase.ControlDictionary(changeButton).Enabled = True
                MyBase.ControlDictionary(removeButton).Enabled = True
            Else
                MyBase.ControlDictionary(nameTextBox).Text = String.Empty
                MyBase.ControlDictionary(changeButton).Enabled = False
                MyBase.ControlDictionary(removeButton).Enabled = False
            End If
        End Sub
#End Region

    End Class
End Namespace

