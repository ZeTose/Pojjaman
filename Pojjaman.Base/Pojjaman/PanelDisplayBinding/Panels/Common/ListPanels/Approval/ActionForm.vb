Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services

Public Class ActionForm
  Private m_entity As SimpleBusinessEntityBase
  Public Sub SetEntity(ByVal entity As SimpleBusinessEntityBase)
    m_entity = entity
    RefreshForm()
  End Sub
  Private Sub RefreshForm()
    For Each ctrl As Control In Me.FlowLayoutPanel1.Controls
      RemoveHandler ctrl.Click, AddressOf Button_Click
    Next
    Me.FlowLayoutPanel1.Controls.Clear()
    Me.FlowLayoutPanel1.Controls.Add(Me.btnPrint)
    If m_entity Is Nothing Then
      Return
    End If
    Dim mySService As SecurityService = CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService)
    m_entity.RefreshActionLogs() 'Maybe not neccessary
    Dim node As FlowNode = m_entity.GetActiveNode
    For Each atp As ActionPath In m_entity.GetPossibleActions(node, mySService.CurrentUser.Id)
      Dim btn As New Button
      btn.Text = atp.Action.Name
      If atp.PossibleRoles.Count > 0 Then
        btn.Text &= " ("
        For Each r As CCRole In atp.PossibleRoles
          btn.Text &= r.Code
          If atp.Tier.HasValue Then
            btn.Text &= "-" & atp.Tier.ToString
          End If
          btn.Text &= ","
        Next
        btn.Text = btn.Text.TrimEnd(","c)
        btn.Text &= ")"
      End If
      btn.AutoSize = True
      btn.AutoSizeMode = Windows.Forms.AutoSizeMode.GrowAndShrink
      btn.Tag = atp
      AddHandler btn.Click, AddressOf Button_Click
      Me.FlowLayoutPanel1.Controls.Add(btn)
    Next
  End Sub
  Private Sub Button_Click(ByVal sender As Object, ByVal e As EventArgs)
    If Not TypeOf sender Is Control Then
      Return
    End If
    Dim ctrl As Control = CType(sender, Control)
    If Not TypeOf ctrl.Tag Is ActionPath Then
      Return
    End If
    Dim mySService As SecurityService = CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService)
    Dim atp As ActionPath = CType(ctrl.Tag, ActionPath)

    Dim dlg As New ActionDialog
    dlg.Text = "Please specify remark for this action """ & atp.Action.Name & """"
    dlg.OK_Button.Text = atp.Action.Name
    If atp.WarningLimit.HasValue Then
      If TypeOf m_entity Is IApprovAble Then
        Dim amount As Decimal = CType(m_entity, IApprovAble).AmountToApprove
        If amount > atp.WarningLimit.Value Then
          dlg.SetWarning(atp.WarningLimit.Value, amount)
        End If
      End If
    End If
    If dlg.ShowDialog = Windows.Forms.DialogResult.OK Then
      Dim log As ActionLog = m_entity.CreatLog(atp, mySService.CurrentUser, dlg.TextBox1.Text)
      Dim err As SaveErrorException = log.Insert()
      If Not IsNumeric(err.Message) Then
        MessageBox.Show(err.Message)
      Else
        If atp.Approve Then
          If TypeOf m_entity Is IApprovAble Then
            Dim approveError As SaveErrorException = CType(m_entity, IApprovAble).ApproveData(m_entity.Id _
                                                    , mySService.CurrentUser.Id _
                                                    , Now)
            If Not IsNumeric(approveError.Message) Then
              MessageBox.Show(approveError.Message)
            End If
          End If
        End If
      End If
    Else
    End If
    'RefreshFlow()
    RefreshForm()
  End Sub
End Class
