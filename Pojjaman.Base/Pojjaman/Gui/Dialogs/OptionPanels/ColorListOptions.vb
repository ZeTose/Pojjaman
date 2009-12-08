Imports System.IO
Imports Longkong.Pojjaman.Gui.XmlForms
Namespace Longkong.Pojjaman.Gui.Dialogs.OptionPanels
    Public Class ColorListOptions
        Inherits AbstractOptionPanel

#Region "Members"
        Private addButton As Button
        Private changeButton As Button
        Private removeButton As Button
        Private colorListBox As ListBox
        Private moveUpButton As Button
        Private moveDownButton As Button
        Private defaultButton As Button

#End Region

#Region "Constructors"
        Public Sub New()
        End Sub
#End Region

#Region "Methods"
        Public Overrides Sub LoadPanelContents()
            MyBase.SetupFromXml(Path.Combine(BasePojjamanUserControl.PropertyService.DataDirectory, "resources\panels\ColorListOptions.xfrm"))
            addButton = CType(MyBase.ControlDictionary("addButton"), Button)
            changeButton = CType(MyBase.ControlDictionary("changeButton"), Button)
            removeButton = CType(MyBase.ControlDictionary("removeButton"), Button)
            colorListBox = CType(MyBase.ControlDictionary("colorListBox"), ListBox)
            moveUpButton = CType(MyBase.ControlDictionary("moveUpButton"), Button)
            moveDownButton = CType(MyBase.ControlDictionary("moveDownButton"), Button)
            defaultButton = CType(MyBase.ControlDictionary("defaultButton"), Button)
            Dim colorListTokens As String = BasePojjamanUserControl.PropertyService.GetProperty("Pojjaman.ColorList", "0,0,0")
            UpdateListBox(colorListTokens)
            AddHandler colorListBox.SelectedIndexChanged, New EventHandler(AddressOf Me.colorListBoxSelectedIndexChanged)
            AddHandler colorListBox.DrawItem, AddressOf Me.ListBox_DrawItem
            AddHandler changeButton.Click, New EventHandler(AddressOf Me.ChangeButtonClick)
            AddHandler removeButton.Click, New EventHandler(AddressOf Me.RemoveButtonClick)
            AddHandler addButton.Click, New EventHandler(AddressOf Me.AddButtonClick)
            AddHandler moveUpButton.Click, New EventHandler(AddressOf Me.MoveUpButtonClick)
            AddHandler moveDownButton.Click, New EventHandler(AddressOf Me.MoveDownButtonClick)
            AddHandler defaultButton.Click, New EventHandler(AddressOf Me.DefaultButtonButtonClick)
            Me.colorListBoxSelectedIndexChanged(Me, EventArgs.Empty)
        End Sub
        Private Sub UpdateListBox(ByVal colorListTokens As String)
            colorListBox.Items.Clear()
            If Not colorListTokens = "" Then
                Dim colorList As String() = colorListTokens.Split(New Char() {";"c})
                colorListBox.DrawMode = DrawMode.OwnerDrawFixed
                colorListBox.ItemHeight = 24
                colorListBox.BeginUpdate()
                For Each task As String In colorList
                    colorListBox.Items.Add(task)
                Next
                colorListBox.EndUpdate()
            End If
        End Sub
        Public Overrides Function StorePanelContents() As Boolean
            Dim taskListTokens As New ArrayList
            For Each item As String In colorListBox.Items
                taskListTokens.Add(item)
            Next
            BasePojjamanUserControl.PropertyService.SetProperty("Pojjaman.ColorList", String.Join(";", CType(taskListTokens.ToArray(GetType(String)), String())))
            Return True
        End Function
        Private Sub AddButtonClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim dialog As New ColorPickerDialog
            If dialog.ShowDialog(Me) = DialogResult.OK Then
                Dim myColor As Color = dialog.ColorPanel1.SelectedColor
                Dim colorString As String = myColor.R & "," & myColor.G & "," & myColor.B
                colorListBox.Items.Add(colorString)
            End If
        End Sub
        Private Sub ChangeButtonClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim colorRgbString As String = CStr(colorListBox.SelectedItem)
            Dim colorRgb As String() = colorRgbString.Split(New Char() {","c})
            Dim color As color = color.FromArgb(CInt(colorRgb(0)), CInt(colorRgb(1)), CInt(colorRgb(2)))
            Dim dialog As New ColorPickerDialog(color)
            If dialog.ShowDialog(Me) = DialogResult.OK Then
                Dim myColor As color = dialog.ColorPanel1.SelectedColor
                Dim colorString As String = myColor.R & "," & myColor.G & "," & myColor.B
                colorListBox.Items(colorListBox.SelectedIndex) = colorString
            End If
        End Sub
        Private Sub RemoveButtonClick(ByVal sender As Object, ByVal e As EventArgs)
            colorListBox.Items.Remove(colorListBox.SelectedItem)
        End Sub
        Private Sub MoveUpButtonClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim tmpObj As Object = colorListBox.SelectedItem
            colorListBox.Items(colorListBox.SelectedIndex) = colorListBox.Items(colorListBox.SelectedIndex - 1)
            colorListBox.Items(colorListBox.SelectedIndex - 1) = tmpObj
            colorListBox.SelectedIndex -= 1
        End Sub
        Private Sub MoveDownButtonClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim tmpObj As Object = colorListBox.SelectedItem
            colorListBox.Items(colorListBox.SelectedIndex) = colorListBox.Items(colorListBox.SelectedIndex + 1)
            colorListBox.Items(colorListBox.SelectedIndex + 1) = tmpObj
            colorListBox.SelectedIndex += 1
        End Sub
        Private Sub DefaultButtonButtonClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim colorListTokens As String = BasePojjamanUserControl.PropertyService.GetProperty("Pojjaman.DefaultColorList", "0,0,0")
            UpdateListBox(colorListTokens)
        End Sub
        Private Sub colorListBoxSelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
            If (colorListBox.SelectedItems.Count > 0) Then
                changeButton.Enabled = True
                removeButton.Enabled = True
                If colorListBox.Items.Count = 1 Then
                    moveUpButton.Enabled = False
                    moveDownButton.Enabled = False
                ElseIf colorListBox.SelectedIndex = 0 Then
                    moveUpButton.Enabled = False
                    moveDownButton.Enabled = True
                ElseIf colorListBox.SelectedIndex = colorListBox.Items.Count - 1 Then
                    moveUpButton.Enabled = True
                    moveDownButton.Enabled = False
                Else
                    moveUpButton.Enabled = True
                    moveDownButton.Enabled = True
                End If
            Else
                changeButton.Enabled = False
                removeButton.Enabled = False
                moveUpButton.Enabled = False
                moveDownButton.Enabled = False
            End If
        End Sub
        Private Sub ListBox_DrawItem(ByVal sender As Object, ByVal e As DrawItemEventArgs)
            Dim theListBox As ListBox = CType(sender, ListBox)
            If theListBox.Items.Count = 0 OrElse e.Index < 0 OrElse e.Index > theListBox.Items.Count - 1 Then
                Return
            End If
            Dim rect As Rectangle = e.Bounds

            If CBool(e.State And DrawItemState.Selected) Then
                e.Graphics.FillRectangle(SystemBrushes.Highlight, rect)
            Else
                e.Graphics.FillRectangle(SystemBrushes.Window, rect)
            End If

            Dim colorRgbString As String = CStr(theListBox.Items(e.Index))
            Dim colorRgb As String() = colorRgbString.Split(New Char() {","c})
            Dim b As New SolidBrush(Color.FromArgb(CInt(colorRgb(0)), CInt(colorRgb(1)), CInt(colorRgb(2))))

            rect.Inflate(-16, -2)
            e.Graphics.FillRectangle(b, rect)
            e.Graphics.DrawRectangle(Pens.Black, rect)

            Dim b2 As Brush
            If CInt(b.Color.R) + CInt(b.Color.G) + CInt(b.Color.B) > 128 * 3 Then
                b2 = Brushes.Black
            Else
                b2 = Brushes.White
            End If
            e.Graphics.DrawString(CStr(e.Index + 1), e.Font, b2, CSng((e.Bounds.Width / 2) - 4), rect.Y + 2)

            b.Dispose()
        End Sub
#End Region

    End Class
End Namespace

