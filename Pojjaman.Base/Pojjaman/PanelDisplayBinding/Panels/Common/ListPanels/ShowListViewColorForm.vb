Imports Longkong.Pojjaman.BusinessLogic

Public Class ShowListViewColorForm

  Public Sub New(ByVal colortype As Integer, ByVal currentUserId As Integer, ByVal bt As Button)

    '' This call is required by the designer.
    InitializeComponent()

    Me.StartPosition = FormStartPosition.CenterParent
    Me.Text = "แสดงความหมายของสี"
    'Me.Location = New Point(bt.Location.X, bt.Location.Y)
    '' Add any initialization after the InitializeComponent() call.
    Me.ListView1.HeaderStyle = ColumnHeaderStyle.None

    Me.ListView1.AllowSort = True
    Me.ListView1.Dock = System.Windows.Forms.DockStyle.Fill
    Me.ListView1.FullRowSelect = True
    Me.ListView1.GridLines = True
    Me.ListView1.HideSelection = True
    Me.ListView1.MultiSelect = False
    Me.ListView1.UseCompatibleStateImageBehavior = False
    Me.ListView1.View = System.Windows.Forms.View.Details
    Me.ListView1.Font = New System.Drawing.Font("Tahoma", 9.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))

    Me.ListView1.Columns.Add("", 265)

    Me.ListView1.Items.Clear()

    Dim lvitem As ListViewItem
    If colortype = 0 Then
      'lblCancel.BackColor = ConfigurationUser.GetColorConfiguration(currentUserId, "color.approve")
      lvitem = ListView1.Items.Add("บันทึก,ยังไม่ถูกอ้างอิง")
      ListView1.SetColors(lvitem, ConfigurationUser.GetColorConfiguration(currentUserId, "color.normal"), Color.Black)
      lvitem = ListView1.Items.Add("ยกเลิก")
      ListView1.SetColors(lvitem, ConfigurationUser.GetColorConfiguration(currentUserId, "color.cancel"), Color.Black)
      lvitem = ListView1.Items.Add("ผ่านรายการแล้ว")
      ListView1.SetColors(lvitem, ConfigurationUser.GetColorConfiguration(currentUserId, "color.glpass"), Color.Black)
      lvitem = ListView1.Items.Add("ถูกอ้างอิงแล้ว")
      ListView1.SetColors(lvitem, ConfigurationUser.GetColorConfiguration(currentUserId, "color.reference"), Color.Black)
      lvitem = ListView1.Items.Add("ถูกอ้างอิงแล้วบางส่วน")
      ListView1.SetColors(lvitem, ConfigurationUser.GetColorConfiguration(currentUserId, "color.somereference"), Color.Black)
      lvitem = ListView1.Items.Add("ปิดแล้ว")
      ListView1.SetColors(lvitem, ConfigurationUser.GetColorConfiguration(currentUserId, "color.close"), Color.Black)
    Else
      lvitem = ListView1.Items.Add("ยังไม่อนุมัติ")
      ListView1.SetColors(lvitem, ConfigurationUser.GetColorConfiguration(currentUserId, "color.normal"), Color.Black)
      lvitem = ListView1.Items.Add("อนุมัติสูงสุดแล้ว(Authorized)")
      ListView1.SetColors(lvitem, ConfigurationUser.GetColorConfiguration(currentUserId, "color.authorize"), Color.Black)
      lvitem = ListView1.Items.Add("อนุมัติแล้ว(Approved)")
      ListView1.SetColors(lvitem, ConfigurationUser.GetColorConfiguration(currentUserId, "color.approve"), Color.Black)
      lvitem = ListView1.Items.Add("ถูกส่งกลับ")
      ListView1.SetColors(lvitem, ConfigurationUser.GetColorConfiguration(currentUserId, "color.reject"), Color.Black)
    End If
  End Sub

  'Private Sub ShowListViewColorForm_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseClick
  '  Me.Close()
  'End Sub

  Private Sub ListView1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.Click
    Me.Close()
  End Sub

End Class