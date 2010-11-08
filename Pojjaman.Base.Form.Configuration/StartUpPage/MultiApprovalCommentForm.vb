Imports Longkong.Pojjaman.BusinessLogic

Public Class MultiApprovalCommentForm
  Private m_entity As MultiApproval

  Public Sub New(ByVal entity As MultiApproval)
    Me.InitializeComponent()

    m_entity = entity

    CheckFormEnable()
  End Sub

  'Private m_approvedType As MultiApproveResult
  'Public ReadOnly Property ApprovedType As MultiApproveResult
  '  Get
  '    Return m_approvedType
  '  End Get
  'End Property

  Private Sub CheckFormEnable()
    If m_entity Is Nothing Then
      Return
    End If

    ''Reset ------------------''
    'm_approvedType = MultiApproveResult.Non
    btnAdd.Enabled = True
    btnApprove.Enabled = True
    btnReject.Enabled = True
    ''Reset''

    Select Case m_entity.ApproveType
      Case MultiApproveType.WaitForApprove
        btnReject.Enabled = False
      Case MultiApproveType.Approved
        btnApprove.Enabled = False
      Case MultiApproveType.Rejected
        btnReject.Enabled = False
      Case MultiApproveType.NotAppreve
        btnReject.Enabled = False
    End Select
  End Sub

  Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
    Dim saveError As SaveErrorException = Me.m_entity.AddNewComment(txtComment.Text, True)
    If Not IsNumeric(saveError.Message) Then
      MessageBox.Show("บันทึกการเพิ่มความเห็นล้มเหลว" & vbCrLf & saveError.Message)
    Else
      MessageBox.Show("บันทึกการเพิ่มความเห็นเรียบร้อยแล้ว")
      'm_approvedType = MultiApproveResult.Comment
      Me.DialogResult = DialogResult.OK
      Me.Close()
    End If
  End Sub

  Private Sub btnApprove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApprove.Click
    Dim saveError As SaveErrorException = Me.m_entity.AddNewComment(txtComment.Text, False)
    If Not IsNumeric(saveError.Message) Then
      MessageBox.Show("บันทึกการอนุมัติล้มเหลว" & vbCrLf & saveError.Message)
    Else
      MessageBox.Show("บันทึกการอนุมัติเรียบร้อยแล้ว")
      'm_approvedType = MultiApproveResult.Approve
      Me.DialogResult = DialogResult.OK
      Me.Close()
    End If
  End Sub

  Private Sub btnReject_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReject.Click
    Dim saveError As SaveErrorException = Me.m_entity.AddNewComment(txtComment.Text, False, True)
    If Not IsNumeric(saveError.Message) Then
      MessageBox.Show("บันทึกการส่งกลับล้มเหลว" & vbCrLf & saveError.Message)
    Else
      MessageBox.Show("บันทึกการส่งกลับเรียบร้อยแล้ว")
      'm_approvedType = MultiApproveResult.Reject
      Me.DialogResult = DialogResult.OK
      Me.Close()
    End If
  End Sub
End Class