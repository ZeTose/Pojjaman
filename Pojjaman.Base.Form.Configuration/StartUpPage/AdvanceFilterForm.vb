Imports Longkong.Pojjaman.BusinessLogic

Public Class AdvanceFilterForm
  Private m_entity As MultiApproval

  Public Sub New(ByVal entity As MultiApproval)
    Me.InitializeComponent()
    m_entity = entity

    Me.Initail()

  End Sub

  'Private m_approvedType As MultiApproveResult
  'Public ReadOnly Property ApprovedType As MultiApproveResult
  '  Get
  '    Return m_approvedType
  '  End Get
  'End Property

  Private Sub Initail()
    Dim ccName As String
    chkCostCenterList.Items.Clear()
    For Each obj As Object In CostCenter.AllCCMinData.Values
      If TypeOf obj Is DataRow Then
        Dim row As DataRow = CType(obj, DataRow)
        ccName = String.Format("{0} : {1}", row("cc_code"), row("cc_name"))
        If m_entity.AdvanceFilter.CostCenterCodeHashTable.ContainsKey(row("cc_code").ToString) Then
          chkCostCenterList.Items.Add(ccName, True)
        Else
          chkCostCenterList.Items.Add(ccName)
        End If
      End If
    Next
    chkCostCenterList.Sorted = True

    If Not Me.m_entity Is Nothing AndAlso Not Me.m_entity.AdvanceFilter Is Nothing Then
      ''Me.txtCodePrefix.Text = Me.m_entity.AdvanceFilter.CodePrefix
      ''Me.txtDocDateStart.Text = IIf(Me.m_entity.AdvanceFilter.DocDateStart.Equals(Date.MinValue), "", Me.m_entity.AdvanceFilter.DocDateStart.ToShortDateString)
      ''Me.txtDocDateEnd.Text = IIf(Me.m_entity.AdvanceFilter.DocDateEnd.Equals(Date.MinValue), "", Me.m_entity.AdvanceFilter.DocDateEnd.ToShortDateString)
    End If
  End Sub

  Private Sub Mapping()
    If Me.m_entity.AdvanceFilter Is Nothing Then
      Me.m_entity.AdvanceFilter = New MultiApproveAdvanceFilter
    End If

    ''Me.m_entity.AdvanceFilter.CodePrefix = Me.txtCodePrefix.Text.Trim
    ''Me.m_entity.AdvanceFilter.DocDateStart = IIf(Me.txtDocDateStart.Text.Trim.Length > 0, Me.txtDocDateStart.Text, Date.MinValue)
    ''Me.m_entity.AdvanceFilter.DocDateEnd = IIf(Me.txtDocDateEnd.Text.Trim.Length > 0, Me.txtDocDateEnd.Text, Date.MinValue)

    Dim ccItem As String
    For Each item As String In Me.chkCostCenterList.CheckedItems
      ccItem = item.ToString.Split(":"c)(0).Trim

      Me.m_entity.AdvanceFilter.CostCenterCodeCollection.Add(ccItem)

      Me.m_entity.AdvanceFilter.CostCenterCollection.Add(item)
    Next
  End Sub

  Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
    'Dim saveError As SaveErrorException = Me.m_entity.AddNewComment(txtComment.Text, True)
    'If Not IsNumeric(saveError.Message) Then
    '  MessageBox.Show("บันทึกการเพิ่มความเห็นล้มเหลว" & vbCrLf & saveError.Message)
    'Else
    '  MessageBox.Show("บันทึกการเพิ่มความเห็นเรียบร้อยแล้ว")
    '  'm_approvedType = MultiApproveResult.Comment
    Me.DialogResult = DialogResult.OK
    If Me.m_entity.AdvanceFilter.IsAdvanceFiltering Then
      Me.m_entity.AdvanceFilter = New MultiApproveAdvanceFilter
      'Me.Initail()
    End If
    Me.Mapping()
    Me.Close()
    'End If
  End Sub

  Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
    If Me.m_entity.AdvanceFilter.IsAdvanceFiltering Then
      Me.m_entity.AdvanceFilter = New MultiApproveAdvanceFilter
      'Me.Mapping()
      Me.Initail()
      Return
    Else
      Me.Close()
    End If
    'Dim saveError As SaveErrorException = Me.m_entity.AddNewComment(txtComment.Text, False, True)
    'If Not IsNumeric(saveError.Message) Then
    '  MessageBox.Show("บันทึกการส่งกลับล้มเหลว" & vbCrLf & saveError.Message)
    'Else
    '  MessageBox.Show("บันทึกการส่งกลับเรียบร้อยแล้ว")
    '  'm_approvedType = MultiApproveResult.Reject
    '  Me.DialogResult = DialogResult.OK
    'Me.Close()
    'End If
  End Sub

  'Private Sub chkCostCenterList_ItemCheck(sender As Object, e As System.Windows.Forms.ItemCheckEventArgs) Handles chkCostCenterList.ItemCheck
  '  Dim i As Integer = 0
  '  i += 1
  'End Sub

End Class