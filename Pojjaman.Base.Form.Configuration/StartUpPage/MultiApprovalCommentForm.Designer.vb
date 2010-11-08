<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MultiApprovalCommentForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MultiApprovalCommentForm))
    Me.GroupBox1 = New System.Windows.Forms.GroupBox()
    Me.txtComment = New System.Windows.Forms.TextBox()
    Me.btnReject = New System.Windows.Forms.Button()
    Me.btnApprove = New Longkong.Pojjaman.Gui.Components.ImageButton()
    Me.btnAdd = New System.Windows.Forms.Button()
    Me.GroupBox1.SuspendLayout()
    Me.SuspendLayout()
    '
    'GroupBox1
    '
    Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.GroupBox1.Controls.Add(Me.txtComment)
    Me.GroupBox1.Controls.Add(Me.btnReject)
    Me.GroupBox1.Controls.Add(Me.btnApprove)
    Me.GroupBox1.Controls.Add(Me.btnAdd)
    Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(422, 146)
    Me.GroupBox1.TabIndex = 15
    Me.GroupBox1.TabStop = False
    Me.GroupBox1.Text = "  ความเห็น  "
    '
    'txtComment
    '
    Me.txtComment.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.txtComment.Location = New System.Drawing.Point(16, 21)
    Me.txtComment.Multiline = True
    Me.txtComment.Name = "txtComment"
    Me.txtComment.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
    Me.txtComment.Size = New System.Drawing.Size(288, 112)
    Me.txtComment.TabIndex = 11
    '
    'btnReject
    '
    Me.btnReject.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.btnReject.FlatStyle = System.Windows.Forms.FlatStyle.System
    Me.btnReject.Location = New System.Drawing.Point(311, 83)
    Me.btnReject.Name = "btnReject"
    Me.btnReject.Size = New System.Drawing.Size(96, 23)
    Me.btnReject.TabIndex = 13
    Me.btnReject.Text = "ส่งกลับ"
    '
    'btnApprove
    '
    Me.btnApprove.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.btnApprove.FlatStyle = System.Windows.Forms.FlatStyle.System
    Me.btnApprove.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
    Me.btnApprove.Location = New System.Drawing.Point(311, 51)
    Me.btnApprove.Name = "btnApprove"
    Me.btnApprove.Size = New System.Drawing.Size(96, 23)
    Me.btnApprove.TabIndex = 12
    Me.btnApprove.Text = "อนุมัติ"
    Me.btnApprove.ThemedImage = CType(resources.GetObject("btnApprove.ThemedImage"), System.Drawing.Bitmap)
    '
    'btnAdd
    '
    Me.btnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.System
    Me.btnAdd.Location = New System.Drawing.Point(311, 19)
    Me.btnAdd.Name = "btnAdd"
    Me.btnAdd.Size = New System.Drawing.Size(96, 23)
    Me.btnAdd.TabIndex = 10
    Me.btnAdd.Text = "เพิ่มความเห็น"
    '
    'MultiApprovalCommentForm
    '
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
    Me.ClientSize = New System.Drawing.Size(446, 170)
    Me.Controls.Add(Me.GroupBox1)
    Me.Name = "MultiApprovalCommentForm"
    Me.Text = "Multi Approval Comments Box"
    Me.GroupBox1.ResumeLayout(False)
    Me.GroupBox1.PerformLayout()
    Me.ResumeLayout(False)

  End Sub
  Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
  Friend WithEvents txtComment As System.Windows.Forms.TextBox
  Friend WithEvents btnReject As System.Windows.Forms.Button
  Friend WithEvents btnApprove As Longkong.Pojjaman.Gui.Components.ImageButton
  Friend WithEvents btnAdd As System.Windows.Forms.Button
End Class
