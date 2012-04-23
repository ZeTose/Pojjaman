
Imports System.Text
Public Class SimpleListDialog
#Region "Constructors"

  Public Sub New(ByVal list As Generic.List(Of String), ByVal ListName As String)
    InitializeComponent()

    Me.lblSimpleListName.Text = ListName
    Me.lbTheList.Items.Clear()
    For Each item As String In list
      Me.lbTheList.Items.Add(item)
    Next
  End Sub
#End Region

  Private Sub CopyToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles CopyToolStripMenuItem.Click
    CopyListBoxToClipboard(lbTheList)
  End Sub

  Public Sub CopyListBoxToClipboard(ByVal lb As ListBox)

    Dim buffer As New StringBuilder

    For i As Integer = 0 To lb.Items.Count - 1
    Buffer.Append(lb.Items(i).ToString)
    Buffer.Append(vbCrLf)
    Next

    My.Computer.Clipboard.SetText(Buffer.ToString)

  End Sub

End Class
