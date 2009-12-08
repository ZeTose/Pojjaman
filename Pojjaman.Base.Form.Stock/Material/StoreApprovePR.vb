Imports Longkong.Pojjaman.BusinessLogic
Public Class StoreApprovePR
  Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

  Public Sub New()
    MyBase.New()

    'This call is required by the Windows Form Designer.
    InitializeComponent()

    'Add any initialization after the InitializeComponent() call

  End Sub

  'Form overrides dispose to clean up the component list.
  Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
    If disposing Then
      If Not (components Is Nothing) Then
        components.Dispose()
      End If
    End If
    MyBase.Dispose(disposing)
  End Sub

  'Required by the Windows Form Designer
  Private components As System.ComponentModel.IContainer

  'NOTE: The following procedure is required by the Windows Form Designer
  'It can be modified using the Windows Form Designer.  
  'Do not modify it using the code editor.
  Friend WithEvents lstvPR As System.Windows.Forms.ListView
  Friend WithEvents btnApprove As System.Windows.Forms.Button
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.lstvPR = New System.Windows.Forms.ListView
    Me.btnApprove = New System.Windows.Forms.Button
    Me.SuspendLayout()
    '
    'lstvPR
    '
    Me.lstvPR.CheckBoxes = True
    Me.lstvPR.GridLines = True
    Me.lstvPR.Location = New System.Drawing.Point(16, 8)
    Me.lstvPR.Name = "lstvPR"
    Me.lstvPR.Size = New System.Drawing.Size(264, 192)
    Me.lstvPR.TabIndex = 0
    Me.lstvPR.View = System.Windows.Forms.View.Details
    '
    'btnApprove
    '
    Me.btnApprove.Location = New System.Drawing.Point(192, 216)
    Me.btnApprove.Name = "btnApprove"
    Me.btnApprove.Size = New System.Drawing.Size(88, 32)
    Me.btnApprove.TabIndex = 1
    Me.btnApprove.Text = "อนุมัติ"
    '
    'StoreApprovePR
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(292, 266)
    Me.Controls.Add(Me.btnApprove)
    Me.Controls.Add(Me.lstvPR)
    Me.Name = "StoreApprovePR"
    Me.Text = "ใบขอซื้อที่จะให้ผ่านการตรวจ"
    Me.ResumeLayout(False)

  End Sub

#End Region
#Region "member"
  Public Person As Integer
#End Region
  Private Sub StoreApprovePR_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    Me.lstvPR.Columns.Add("PR ที่เลือก", 200, HorizontalAlignment.Left)
  End Sub
  Private Sub btnApprove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApprove.Click
    Dim apr As PR
    Dim thetime As Date = Now

    For Each item As ListViewItem In lstvPR.Items
      If item.Checked Then
        apr = CType(item.Tag, PR)
        PR.ApproveStoreData(apr.Id, Person, thetime)
      End If
    Next
    Me.Close()
  End Sub
End Class
