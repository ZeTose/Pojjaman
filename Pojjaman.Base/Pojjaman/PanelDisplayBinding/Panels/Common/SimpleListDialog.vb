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
End Class
