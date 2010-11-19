Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.Gui
Imports Longkong.Pojjaman.Gui.Panels
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Imports Longkong.Pojjaman

Public Class ToollotBoxForm

  Private m_entity As Tool

  Public Sub New(ByVal entity As Tool)
    InitializeComponent()

    If entity Is Nothing Then
      Return
    End If

    m_entity = entity

    UpdateEntityProperties()

    EventWiring()

    CheckFormEnable()
  End Sub

  Private Sub CheckFormEnable()
    Me.DialogResult = Windows.Forms.DialogResult.Cancel
  End Sub

  Private Sub UpdateEntityProperties()
    If m_entity Is Nothing Then
      Return
    End If

    Me.chkAutorun.Checked = Me.m_entity.ToolLot.Autogen
    UpdateAutogenStatus()

    Dim lot As ToolLot = Me.m_entity.ToolLot
    If lot Is Nothing Then
      Return
    End If

    'txtAssetCode.Text = lot.Asset.Code
    'txtAssetName.Text = lot.Asset.Name
    txtBuyCode.Text = lot.Buydoc.Code
    If Date.MinValue.Equals(lot.Buydate) Then
      txtBuyDate.Text = ""
    Else
      txtBuyDate.Text = lot.Buydate.ToShortDateString
    End If
    txtBuyQTY.Text = Configuration.FormatToString(lot.Buyqty, DigitConfig.Qty)
    txtUnitCost.Text = Configuration.FormatToString(lot.UnitCost, DigitConfig.Price)
    TxtAmount.Text = Configuration.FormatToString(0, DigitConfig.Price)
    TxtBrand.Text = lot.Brand
    txtDescription.Text = lot.Description
  End Sub

  Private Sub EventWiring()
    AddHandler cmbCode.TextChanged, AddressOf Me.ChangeProperty
    AddHandler cmbCode.SelectedIndexChanged, AddressOf Me.ChangeProperty

    'AddHandler txtAssetCode.TextChanged, AddressOf Me.ChangeProperty
    'AddHandler txtAssetCode.Validated, AddressOf Me.ValidatedProperties

    AddHandler txtBuyQTY.Validated, AddressOf Me.ValidatedProperties
    AddHandler txtUnitCost.Validated, AddressOf Me.ValidatedProperties

    AddHandler TxtBrand.TextChanged, AddressOf Me.ChangeProperty
    AddHandler txtDescription.TextChanged, AddressOf Me.ChangeProperty
  End Sub

  Public Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)
    If Me.m_entity Is Nothing Then
      Return
    End If
    Dim lot As ToolLot = Me.m_entity.ToolLot
    If lot Is Nothing Then
      Return
    End If
    Select Case CType(sender, Control).Name.ToLower
      Case cmbCode.Name.ToLower
        lot.Code = cmbCode.Text
      Case TxtBrand.Name.ToLower
        lot.Brand = TxtBrand.Text
      Case txtDescription.Name.ToLower
        lot.Description = txtDescription.Text
        'Case txtAssetCode.Name.ToLower
        'Asset.GetAsset(txtAssetCode, txtAssetName, lot.Asset)
    End Select
  End Sub
  Public Sub ValidatedProperties(ByVal sender As Object, ByVal e As EventArgs)
    If Me.m_entity Is Nothing Then
      Return
    End If
    Dim lot As ToolLot = Me.m_entity.ToolLot
    If lot Is Nothing Then
      Return
    End If
    Select Case CType(sender, Control).Name.ToLower
      'Case txtAssetCode.Name.ToLower
      '  Asset.GetAsset(txtAssetCode, txtAssetName, lot.Asset)
      Case txtBuyQTY.Name.ToLower
        If IsNumeric(txtBuyQTY.Text) Then
          lot.Buyqty = CDec(txtBuyQTY.Text)
          txtBuyQTY.Text = Configuration.FormatToString(lot.Buyqty, DigitConfig.Price)
        End If
      Case txtUnitCost.Name.ToLower
        If IsNumeric(txtUnitCost.Text) Then
          lot.UnitCost = CDec(txtUnitCost.Text)
          txtUnitCost.Text = Configuration.FormatToString(lot.UnitCost, DigitConfig.Price)
        End If
    End Select
  End Sub

  Private Sub UpdateAutogenStatus()
    If Me.m_entity Is Nothing Then
      Return
    End If

    Dim lot As ToolLot = Me.m_entity.ToolLot
    If lot Is Nothing Then
      Return
    End If

    If Me.chkAutorun.Checked Then
      Me.cmbCode.DropDownStyle = ComboBoxStyle.DropDownList
      Dim currentUserId As Integer = Me.SecurityService.CurrentUser.Id
      BusinessLogic.Entity.NewPopulateCodeCombo(Me.cmbCode, lot.EntityId, currentUserId)
      'BusinessLogic.Entity.PopulateCodeCombo(Me.cmbCode, lot.EntityId)
      If lot.Code Is Nothing OrElse lot.Code.Length = 0 Then
        If Me.cmbCode.Items.Count > 0 Then
          lot.Code = CType(Me.cmbCode.Items(0), AutoCodeFormat).Format
          Me.cmbCode.SelectedIndex = 0
          lot.AutoCodeFormat = CType(Me.cmbCode.Items(0), AutoCodeFormat)
        End If
      Else
        Me.cmbCode.SelectedIndex = Me.cmbCode.FindStringExact(lot.Code)
        If TypeOf Me.cmbCode.SelectedItem Is AutoCodeFormat Then
          lot.AutoCodeFormat = CType(Me.cmbCode.SelectedItem, AutoCodeFormat)
        End If
      End If
      lot.Autogen = True
    Else
      'Me.Validator.SetRequired(Me.txtCode, True)
      'If TypeOf Me.cmbCode.SelectedItem Is AutoCodeFormat Then
      '  Me.m_entity.AutoCodeFormat = CType(Me.cmbCode.SelectedItem, AutoCodeFormat)
      'End If
      Me.cmbCode.DropDownStyle = ComboBoxStyle.Simple
      Me.cmbCode.Items.Clear()
      Me.cmbCode.Text = lot.Code
      lot.Autogen = False
    End If
  End Sub

  Private m_securityService As SecurityService
  Public ReadOnly Property SecurityService() As SecurityService
    Get
      If m_securityService Is Nothing Then
        m_securityService = CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService)
      End If
      Return m_securityService
    End Get
  End Property

  Private Sub ImageButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImageButton1.Click
    Dim filters(0) As Filter
    filters(0) = New Filter("id", 0)
    Dim dlg As New BasketDialog

    AddHandler dlg.EmptyBasket, AddressOf SetItems

    Dim Entities As New ArrayList
    Dim view As AbstractEntityPanelViewContent = New GoodsReceiptSelectionView(Me.m_entity, 0, dlg, filters, Entities)
    dlg.Lists.Add(view)

    Dim myDialog As New Longkong.Pojjaman.Gui.Dialogs.PanelDockingDialog(view, dlg)
    myDialog.ShowDialog()
  End Sub
  Private Sub SetItems(ByVal items As BasketItemCollection)

    Dim newCode As String = ""
    Dim currentUserId As Integer = Me.SecurityService.CurrentUser.Id

    Me.m_entity.ItemCollection.SetItems(items, newCode, currentUserId)
    If Me.m_entity.ItemCollection.Contains(Me.m_entity.ItemCollection(Me.m_entity.ItemCollection.Count - 1)) Then
      Me.m_entity.ToolLot = Me.m_entity.ItemCollection(Me.m_entity.ItemCollection.Count - 1)
    End If
    'Me.WorkbenchWindow.ViewContent.IsDirty = True
  End Sub

  'Private Sub btnAssetFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
  '  Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
  '  myEntityPanelService.OpenListDialog(New Asset, AddressOf SetAssetDialog)
  'End Sub
  'Private Sub SetAssetDialog(ByVal e As ISimpleEntity)
  '  Dim lot As ToolLot = Me.m_entity.ToolLot
  '  If lot Is Nothing Then
  '    Return
  '  End If
  '  Me.txtAssetCode.Text = e.Code
  '  Asset.GetAsset(txtAssetCode, txtAssetName, lot.Asset)
  'End Sub

  Private Sub chkAutorun_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAutorun.CheckedChanged
    UpdateAutogenStatus()
  End Sub

  Private Sub cmbCode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbCode.KeyDown, _
     txtBuyQTY.KeyDown, txtUnitCost.KeyDown, TxtBrand.KeyDown, txtDescription.KeyDown, txtAssetCode.KeyDown
    If e.KeyCode = Keys.Enter Then
      If CType(sender, TextBox).Name = txtDescription.Name Then
        ibtnSave.Focus()
      Else
        CType(sender, TextBox).SelectAll()
        SendKeys.Send("{tab}")
      End If
    End If
  End Sub

  Private Sub ibtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnCancel.Click
    Me.DialogResult = Windows.Forms.DialogResult.Cancel
  End Sub

  Private Sub ibtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnSave.Click
    If Me.m_entity Is Nothing OrElse Me.m_entity.ToolLot Is Nothing Then
      Return
    End If

    If Me.m_entity.SaveLot(SecurityService.CurrentUser.Id) Then
      Me.DialogResult = Windows.Forms.DialogResult.OK
      Me.Close()
    End If

  End Sub

  Private Sub btnAssetFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAssetFind.Click

  End Sub
End Class