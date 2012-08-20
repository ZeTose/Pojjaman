Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Imports System.Text.RegularExpressions
Imports System.Collections.Generic

Public Class ProjectNACCEnumerateView

  Private m_entity As Project

  Public Sub New(_entity As Project)
    MyBase.New()
    Me.InitializeComponent()
    Me.Initial()

    m_entity = _entity

    Try
      Dim err As SaveErrorException = m_entity.InsertProjectNACC()
      If Not IsNumeric(err.Message) Then
        MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
      End If

      m_entity.LoadProjectNACC()

      UpdateEntityProperties()

      EventWiring()
    Catch ex As Exception
      Me.Close()
    End Try
  End Sub
  Private Sub Initial()
    Province.ListProvinceInComboBox(Me.cProvince)
  End Sub
  Private Sub UpdateEntityProperties()
    If Not m_entity.ProjectNACC Is Nothing Then
      'RemoveEventWiring()
      Dim _nacc As ProjectNACC = m_entity.ProjectNACC
      With Me
        .tContractNo.Text = _nacc.ContractNO
        .teGPContractNo.Text = _nacc.eGPContractNO
        .tTaxId.Text = _nacc.TaxID
        .tIDNo.Text = _nacc.IDNO
        .tCompanyName.Text = _nacc.Name
        .tBuildingName.Text = _nacc.BuildingName
        .tRoomNo.Text = _nacc.RoomNO
        .tFloorNo.Text = _nacc.FloorNo
        .tVillage.Text = _nacc.VillageName
        .tNumber.Text = _nacc.Number
        .tMoo.Text = _nacc.Moo
        .tSubStreet.Text = _nacc.Substreet
        .tStreet.Text = _nacc.Street
        .tTambon.Text = _nacc.Tambon
        .tDistrict.Text = _nacc.District
        Dim cmbIndex As Integer = .cProvince.FindStringExact(_nacc.Province)
        If cmbIndex = -1 Then
          .cProvince.Text = _nacc.Province
        Else
          .cProvince.SelectedIndex = cmbIndex
        End If
        .tPostalCode.Text = _nacc.PostalCode
        .tPhone.Text = _nacc.Phone

        .tContractName.Text = _nacc.ContractName
        If Not _nacc.ActiveDate.Equals(Date.MinValue) Then
          .tActiveDate.Text = _nacc.ActiveDate.ToShortDateString
          .tActiveDate.EditValue = _nacc.ActiveDate
        End If
        If Not _nacc.CompletionDate.Equals(Date.MinValue) Then
          .tCompleteDate.Text = _nacc.CompletionDate
          .tCompleteDate.EditValue = _nacc.CompletionDate
        End If
        .tContractYear.Text = _nacc.ContractYear
        .tContractMonth.Text = _nacc.ContractMonth
        .tContractDay.Text = _nacc.ContractDay
        .tGuaranteeYear.Text = _nacc.GuaranteeYear
        .tGuaranteeMonth.Text = _nacc.GuaranteeMonth
        .tGuaranteeDay.Text = _nacc.GuaranteeDay

        For Each bi As BankAccountItem In _nacc.BankAccountList
          Me.SetBankAccountDialog(bi.BankAccount)
        Next

      End With
      'EventWiring()
    End If
  End Sub
  Protected Sub EventWiring()
    AddHandler tContractNo.TextChanged, AddressOf Me.ChangeProperty
    AddHandler teGPContractNo.TextChanged, AddressOf Me.ChangeProperty
    AddHandler tTaxId.TextChanged, AddressOf Me.ChangeProperty
    AddHandler tIDNo.TextChanged, AddressOf Me.ChangeProperty
    AddHandler tCompanyName.TextChanged, AddressOf Me.ChangeProperty
    AddHandler tBuildingName.TextChanged, AddressOf Me.ChangeProperty
    AddHandler tRoomNo.TextChanged, AddressOf Me.ChangeProperty

    AddHandler tFloorNo.TextChanged, AddressOf Me.ChangeProperty
    AddHandler tVillage.TextChanged, AddressOf Me.ChangeProperty
    AddHandler tNumber.TextChanged, AddressOf Me.ChangeProperty
    AddHandler tMoo.TextChanged, AddressOf Me.ChangeProperty
    AddHandler tSubStreet.TextChanged, AddressOf Me.ChangeProperty
    AddHandler tStreet.TextChanged, AddressOf Me.ChangeProperty
    AddHandler tTambon.TextChanged, AddressOf Me.ChangeProperty

    AddHandler tDistrict.TextChanged, AddressOf Me.ChangeProperty
    AddHandler tPostalCode.TextChanged, AddressOf Me.ChangeProperty
    AddHandler tPhone.TextChanged, AddressOf Me.ChangeProperty
    AddHandler tContractName.TextChanged, AddressOf Me.ChangeProperty
    AddHandler tActiveDate.TextChanged, AddressOf Me.ChangeProperty
    AddHandler tCompleteDate.TextChanged, AddressOf Me.ChangeProperty
    AddHandler tContractYear.TextChanged, AddressOf Me.ChangeProperty

    AddHandler tContractMonth.TextChanged, AddressOf Me.ChangeProperty
    AddHandler tContractDay.TextChanged, AddressOf Me.ChangeProperty
    AddHandler tGuaranteeYear.TextChanged, AddressOf Me.ChangeProperty
    AddHandler tGuaranteeMonth.TextChanged, AddressOf Me.ChangeProperty
    AddHandler tGuaranteeDay.TextChanged, AddressOf Me.ChangeProperty
  End Sub
  'Protected Sub RemoveEventWiring()
  '  RemoveHandler tContractNo.TextChanged, AddressOf Me.ChangeProperty
  '  RemoveHandler teGPContractNo.TextChanged, AddressOf Me.ChangeProperty
  '  RemoveHandler tTaxId.TextChanged, AddressOf Me.ChangeProperty
  '  RemoveHandler tIDNo.TextChanged, AddressOf Me.ChangeProperty
  '  RemoveHandler tCompanyName.TextChanged, AddressOf Me.ChangeProperty
  '  RemoveHandler tBuildingName.TextChanged, AddressOf Me.ChangeProperty
  '  RemoveHandler tRoomNo.TextChanged, AddressOf Me.ChangeProperty

  '  RemoveHandler tFloorNo.TextChanged, AddressOf Me.ChangeProperty
  '  RemoveHandler tVillage.TextChanged, AddressOf Me.ChangeProperty
  '  RemoveHandler tNumber.TextChanged, AddressOf Me.ChangeProperty
  '  RemoveHandler tMoo.TextChanged, AddressOf Me.ChangeProperty
  '  RemoveHandler tSubStreet.TextChanged, AddressOf Me.ChangeProperty
  '  RemoveHandler tStreet.TextChanged, AddressOf Me.ChangeProperty
  '  RemoveHandler tTambon.TextChanged, AddressOf Me.ChangeProperty

  '  RemoveHandler tDistrict.TextChanged, AddressOf Me.ChangeProperty
  '  RemoveHandler tPostalCode.TextChanged, AddressOf Me.ChangeProperty
  '  RemoveHandler tPhone.TextChanged, AddressOf Me.ChangeProperty
  '  RemoveHandler tContractName.TextChanged, AddressOf Me.ChangeProperty
  '  RemoveHandler tActiveDate.TextChanged, AddressOf Me.ChangeProperty
  '  RemoveHandler tCompleteDate.TextChanged, AddressOf Me.ChangeProperty
  '  RemoveHandler tContractYear.TextChanged, AddressOf Me.ChangeProperty

  '  RemoveHandler tContractMonth.TextChanged, AddressOf Me.ChangeProperty
  '  RemoveHandler tContractDay.TextChanged, AddressOf Me.ChangeProperty
  '  RemoveHandler tGuaranteeYear.TextChanged, AddressOf Me.ChangeProperty
  '  RemoveHandler tGuaranteeMonth.TextChanged, AddressOf Me.ChangeProperty
  '  RemoveHandler tGuaranteeDay.TextChanged, AddressOf Me.ChangeProperty
  'End Sub
  Private Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)
    If Not m_entity.ProjectNACC Is Nothing Then
      Dim _nacc As ProjectNACC = m_entity.ProjectNACC
      With Me
        _nacc.ContractNO = .tContractNo.Text
        _nacc.eGPContractNO = .teGPContractNo.Text
        _nacc.TaxID = .tTaxId.Text
        _nacc.IDNO = .tIDNo.Text
        _nacc.Name = .tCompanyName.Text
        _nacc.BuildingName = .tBuildingName.Text
        _nacc.RoomNO = .tRoomNo.Text
        _nacc.FloorNo = .tFloorNo.Text
        _nacc.VillageName = .tVillage.Text
        _nacc.Number = .tNumber.Text
        _nacc.Moo = .tMoo.Text
        _nacc.Substreet = .tSubStreet.Text
        _nacc.Street = .tStreet.Text
        _nacc.Tambon = .tTambon.Text
        _nacc.District = .tDistrict.Text
        _nacc.Province = .cProvince.Text
        _nacc.PostalCode = .tPostalCode.Text
        _nacc.Phone = .tPhone.Text

        _nacc.ContractName = .tContractName.Text
        _nacc.ActiveDate = IIf(.tActiveDate.Text.Trim.Length = 0, Date.MinValue, .tActiveDate.Text)
        _nacc.CompletionDate = IIf(.tCompleteDate.Text.Trim.Length = 0, Date.MinValue, .tCompleteDate.Text)
        '_nacc.ContractYear = IIf(.tContractYear.Text.Trim.Length = 0 Or Not IsNumeric(.tContractYear.Text), 0, .tContractYear.Text)
        '_nacc.ContractMonth = IIf(.tContractMonth.Text.Trim.Length = 0 Or Not IsNumeric(.tContractMonth.Text), 0, .tContractMonth.Text)
        '_nacc.ContractDay = IIf(.tContractDay.Text.Trim.Length = 0 Or Not IsNumeric(.tContractDay.Text), 0, .tContractDay.Text)
        _nacc.GuaranteeYear = IIf(.tGuaranteeYear.Text.Trim.Length = 0 Or Not IsNumeric(.tGuaranteeYear.Text), 0, .tGuaranteeYear.Text)
        _nacc.GuaranteeMonth = IIf(.tGuaranteeMonth.Text.Trim.Length = 0 Or Not IsNumeric(.tGuaranteeMonth.Text), 0, .tGuaranteeMonth.Text)
        _nacc.GuaranteeDay = IIf(.tGuaranteeDay.Text.Trim.Length = 0 Or Not IsNumeric(.tGuaranteeDay.Text), 0, .tGuaranteeDay.Text)

        _nacc.BankAccountList = New List(Of BankAccountItem)
        For Each itm As ListViewItem In ListView1.Items
          If TypeOf itm.Tag Is BankAccountItem Then
            _nacc.BankAccountList.Add(CType(itm.Tag, BankAccountItem))
          End If
        Next

        'Dim d1 As Date = IIf(.tActiveDate.Text.Trim.Length = 0, Date.MinValue, .tActiveDate.Text)
        'Dim d2 As Date = IIf(.tCompleteDate.Text.Trim.Length = 0, Date.MinValue, .tCompleteDate.Text)

        'Dim c1 As Integer = IIf(.tContractYear.Text.Trim.Length = 0, 0, .tContractYear.Text)
        'Dim c2 As Integer = IIf(.tContractMonth.Text.Trim.Length = 0, 0, .tContractMonth.Text)
        'Dim c3 As Integer = IIf(.tContractDay.Text.Trim.Length = 0, 0, .tContractDay.Text)
        Select Case CType(sender, Control).Name.ToLower
          Case tActiveDate.Name.ToLower
            .tContractYear.Text = _nacc.ContractYear
            .tContractMonth.Text = _nacc.ContractMonth
            .tContractDay.Text = _nacc.ContractDay
            'CalContractDayFromActiveDate(d1, d2)
            '_nacc.ContractYear = .tContractYear.Text
            '_nacc.ContractMonth = .tContractMonth.Text
            '_nacc.ContractDay = .tContractDay.Text
          Case tCompleteDate.Name.ToLower
            .tContractYear.Text = _nacc.ContractYear
            .tContractMonth.Text = _nacc.ContractMonth
            .tContractDay.Text = _nacc.ContractDay
            'CalContractDayFromActiveDate(d1, d2)
            '_nacc.ContractYear = .tContractYear.Text
            '_nacc.ContractMonth = .tContractMonth.Text
            '_nacc.ContractDay = .tContractDay.Text
            'Case tContractYear.Name.ToLower
            '  CalCompleteDateFromContractDay(d1, c1, c2, c3)
            '  _nacc.CompletionDate = IIf(.tCompleteDate.Text.Trim.Length = 0, DBNull.Value, .tCompleteDate.Text)
            'Case tContractMonth.Name.ToLower
            '  CalCompleteDateFromContractDay(d1, c1, c2, c3)
            '  _nacc.CompletionDate = IIf(.tCompleteDate.Text.Trim.Length = 0, DBNull.Value, .tCompleteDate.Text)
            'Case tContractDay.Name.ToLower
            '  CalCompleteDateFromContractDay(d1, c1, c2, c3)
            '  _nacc.CompletionDate = IIf(.tCompleteDate.Text.Trim.Length = 0, DBNull.Value, .tCompleteDate.Text)
        End Select
      End With
      'UpdateEntityProperties()
    End If
  End Sub
  'Private Sub CalCompleteDateFromContractDay(startDate As Date, cyear As Integer, cmonth As Integer, cday As Integer)
  '  If Date.MinValue.Equals(startDate) Then
  '    'Do nothing
  '  Else
  '    'ignorePropertyChange = True
  '    Dim completeDate As Date = Nothing
  '    completeDate = DateAdd(DateInterval.Year, cyear, startDate)
  '    completeDate = DateAdd(DateInterval.Month, cmonth, completeDate)
  '    completeDate = DateAdd(DateInterval.Day, cday, completeDate)
  '    If Not Date.MinValue.Equals(completeDate) Then
  '      tCompleteDate.EditValue = completeDate
  '      tCompleteDate.Text = completeDate.ToShortDateString
  '    End If
  '    'ignorePropertyChange = False
  '  End If
  'End Sub

  'Dim ignorePropertyChange As Boolean = False
  'Private Sub CalContractDayFromActiveDate(startDate As Date, endDate As Date)
  '  If Date.MinValue.Equals(startDate) OrElse Date.MinValue.Equals(endDate) Then
  '    'Do nothing
  '  Else
  '    ignorePropertyChange = True
  '    'Dim totalDiff As Integer = DateDiff(DateInterval.Day, startDate, endDate) 'Total Diff Day

  '    'Dim endDayOfEndYearString As String = endDate.ToString("yyyy") & "-01-01'"
  '    'Dim endDayOfPreviousYear As Date = DateAdd(DateInterval.Day, -1, CDate(endDayOfEndYearString))

  '    'Dim totalYear As Integer = 

  '    Dim totalYear As Integer = DateDiff(DateInterval.Year, startDate, endDate)

  '    Dim totalMonth As Integer = DateDiff(DateInterval.Month, DateAdd(DateInterval.Year, totalYear, startDate), endDate)

  '    Dim totalDay As Integer = DateDiff(DateInterval.Day, DateAdd(DateInterval.Month, totalMonth, DateAdd(DateInterval.Year, totalYear, startDate)), endDate) + 1

  '    If totalYear > 0 Then
  '      tContractYear.Text = totalYear
  '    Else
  '      tContractYear.Text = 0
  '    End If
  '    If totalMonth > 0 Then
  '      tContractMonth.Text = totalMonth
  '    Else
  '      tContractMonth.Text = 0
  '    End If
  '    If totalDay > 0 Then
  '      tContractDay.Text = totalDay
  '    Else
  '      tContractDay.Text = 0
  '    End If

  '    'ignorePropertyChange = False
  '  End If
  'End Sub

  Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs) Handles btnSave.Click
    Me.ChangeProperty(sender, e)
    Dim err As SaveErrorException = m_entity.UpdateProjectNACC()
    If Not IsNumeric(err.Message) Then
      MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
    Else

      Me.Close()
    End If
  End Sub

  Private Function GetExcludeIdList() As String
    Dim idL As New ArrayList
    For Each itm As ListViewItem In ListView1.Items
      If Not itm.Tag Is Nothing AndAlso TypeOf itm.Tag Is BankAccountItem Then
        idL.Add(CType(itm.Tag, BankAccountItem).BankAccount.Id)
      End If
    Next
    Return String.Join(",", idL.ToArray)
  End Function

  Private Sub ibtnBlank_Click(sender As System.Object, e As System.EventArgs) Handles ibtnBlank.Click

    Dim filters(0) As Filter
    filters(0) = New Filter("ExcludeIdList", Me.GetExcludeIdList)

    Dim myEntityPanelService As IEntityPanelService = _
       CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
    myEntityPanelService.OpenListDialog(New BankAccount, AddressOf SetBankAccountDialog, filters)
  End Sub
  Private Sub SetBankAccountDialog(ByVal e As ISimpleEntity)
    'Me.txtBankAccountCode.Text = e.Code
    'Me.WorkbenchWindow.ViewContent.IsDirty = _
    '    Me.WorkbenchWindow.ViewContent.IsDirty _
    '    Or
    'BankAccount.GetBankAccountBankBranch(txtBankAccountCode, txtBankAccountName, txtBankBranch, Me.m_entity.Bankacct)

    'ListView1.Items.Clear()

    Dim lvRowsCount As Integer = ListView1.Items.Count
    lvRowsCount += 1
    Dim cThai As String = Me.Rep(lvRowsCount)

    Dim bacct As BankAccount = CType(e, BankAccount)

    Dim item1 As New ListViewItem(cThai)
    If Not bacct.BankBranch Is Nothing AndAlso Not bacct.BankBranch.Bank Is Nothing Then
      item1.SubItems.Add(bacct.BankBranch.Bank.Name)
      item1.SubItems.Add(bacct.BankBranch.Name)
    Else
      item1.SubItems.Add("")
      item1.SubItems.Add("")
    End If
    item1.SubItems.Add(bacct.BankCode)

    Dim bi As New BankAccountItem(cThai, Me.m_entity, bacct)
    item1.Tag = bi

    ListView1.Items.Add(item1)
  End Sub
  Private Function Rep(input As String) As String
    Dim hs As New Hashtable
    hs.Add("1", "๑")
    hs.Add("2", "๒")
    hs.Add("3", "๓")
    hs.Add("4", "๔")
    hs.Add("5", "๕")
    hs.Add("6", "๖")
    hs.Add("7", "๗")
    hs.Add("8", "๘")
    hs.Add("9", "๙")
    hs.Add("0", "๐")

    Dim output As String = ""
    For i As Integer = 1 To input.Length
      output &= hs(Mid(input, i, 1))
    Next

    Return output

    'Dim reg As New Regex("\b\d+\b")

    'Dim pattern As String = "[0-9]" '"\b\d+\b"
    'Dim output As String = input

    'Dim cthai() As String = {"๐", "๑", "๒", "๓", "๔", "๕", "๖", "๗", "๘", "๙"}

    'While Regex.IsMatch(output, pattern)
    '  For index As Integer = 0 To cthai.Length - 1
    '    input = input Mod 10
    '    output = Regex.Replace(input, pattern, cthai(input))
    '  Next
    'End While

    'Return output

  End Function

  Private Sub ibtnDelRow_Click(sender As System.Object, e As System.EventArgs) Handles ibtnDelRow.Click
    Dim obj As Object = ListView1.SelectedItems
    If Not obj Is Nothing Then
      For Each itm As ListViewItem In obj
        ListView1.Items.Remove(itm)
      Next
    End If

    Dim lineNumber As String = ""
    Dim cThai As String = ""
    For Each itm As ListViewItem In ListView1.Items
      lineNumber = (itm.Index + 1).ToString
      cThai = Me.Rep(lineNumber)
      itm.Text = cThai
      CType(itm.Tag, BankAccountItem).ThaiNumber = cThai
    Next
  End Sub
End Class