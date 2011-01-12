Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.TextHelper
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Imports Longkong.Core.Properties
Imports Longkong.Core.AddIns
Namespace Longkong.Pojjaman.Gui.Panels

  Public Class CrystalReportSelectionView
    Inherits AbstractEntityDetailPanelView
    Implements IReversibleEntityProperty

#Region " Windows Form Designer generated code "
    'UserControl overrides dispose to clean up the component list.
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
    Friend WithEvents gbListSelect As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents btnOk As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    <System.Diagnostics.DebuggerStepThrough()> Protected Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Me.gbListSelect = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.ListView1 = New System.Windows.Forms.ListView()
      Me.btnOk = New System.Windows.Forms.Button()
      Me.btnCancel = New System.Windows.Forms.Button()
      Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
      Me.gbListSelect.SuspendLayout()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'gbListSelect
      '
      Me.gbListSelect.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.gbListSelect.Controls.Add(Me.ListView1)
      Me.gbListSelect.Controls.Add(Me.btnOk)
      Me.gbListSelect.Controls.Add(Me.btnCancel)
      Me.gbListSelect.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.gbListSelect.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.gbListSelect.ForeColor = System.Drawing.Color.Blue
      Me.gbListSelect.Location = New System.Drawing.Point(8, 8)
      Me.gbListSelect.Name = "gbListSelect"
      Me.gbListSelect.Size = New System.Drawing.Size(380, 255)
      Me.gbListSelect.TabIndex = 0
      Me.gbListSelect.TabStop = False
      Me.gbListSelect.Text = "ข้อมูลหลัก"
      '
      'ListView1
      '
      Me.ListView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.ListView1.Location = New System.Drawing.Point(7, 21)
      Me.ListView1.Name = "ListView1"
      Me.ListView1.Size = New System.Drawing.Size(364, 196)
      Me.ListView1.TabIndex = 6
      Me.ListView1.UseCompatibleStateImageBehavior = False
      '
      'btnOk
      '
      Me.btnOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK
      Me.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnOk.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnOk.ForeColor = System.Drawing.Color.Black
      Me.btnOk.Location = New System.Drawing.Point(171, 223)
      Me.btnOk.Name = "btnOk"
      Me.btnOk.Size = New System.Drawing.Size(96, 24)
      Me.btnOk.TabIndex = 4
      Me.btnOk.Text = "OK"
      '
      'btnCancel
      '
      Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnCancel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnCancel.ForeColor = System.Drawing.Color.Black
      Me.btnCancel.Location = New System.Drawing.Point(275, 223)
      Me.btnCancel.Name = "btnCancel"
      Me.btnCancel.Size = New System.Drawing.Size(96, 24)
      Me.btnCancel.TabIndex = 5
      Me.btnCancel.Text = "Cancel"
      '
      'Validator
      '
      Me.Validator.BackcolorChanging = False
      Me.Validator.DataTable = Nothing
      Me.Validator.ErrorProvider = Me.ErrorProvider1
      Me.Validator.GotFocusBackColor = System.Drawing.Color.Empty
      Me.Validator.HasNewRow = False
      Me.Validator.InvalidBackColor = System.Drawing.Color.Empty
      '
      'ErrorProvider1
      '
      Me.ErrorProvider1.ContainerControl = Me
      '
      'CrystalReportSelectionView
      '
      Me.Controls.Add(Me.gbListSelect)
      Me.Name = "CrystalReportSelectionView"
      Me.Size = New System.Drawing.Size(396, 271)
      Me.gbListSelect.ResumeLayout(False)
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

    End Sub

#End Region

#Region " SetLabelText "
    Public Overrides Sub SetLabelText()
      If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)

      'Me.lblName.Text = Me.StringParserService.Parse("${res:Global.NameText}")
      'Me.lblCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CrystalReportSelectionView.lblCode}")

      'Me.lblbirthDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CrystalReportSelectionView.lblbirthDate}")
      'Me.Validator.SetDisplayName(Me.txtbirthdate, lblbirthDate.Text)

      'Me.lblHomePage.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CrystalReportSelectionView.lblHomePage}")
      'Me.Validator.SetDisplayName(Me.txtHomePage, lblHomePage.Text)

      'Me.lblLastContactDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CrystalReportSelectionView.lblLastContactDate}")
      'Me.Validator.SetDisplayName(Me.txtLastContactDate, Me.lblLastContactDate.Text)

      'Me.lblLastPayDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CrystalReportSelectionView.lblLastPayDate}")
      'Me.Validator.SetDisplayName(Me.txtLastPaydate, Me.lblLastPayDate.Text)

      'Me.lblSummaryDiscount.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CrystalReportSelectionView.lblSummaryDiscount}")
      'Me.Validator.SetDisplayName(Me.txtSummaryDiscount, Me.lblSummaryDiscount.Text)

      'Me.lblDetailDiscount.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CrystalReportSelectionView.lblDetailDiscount}")
      'Me.Validator.SetDisplayName(Me.txtDetailDiscount, Me.lblDetailDiscount.Text)

      'Me.lblTaxRate.Text = Me.StringParserService.Parse("${res:Global.TaxRateText}")
      'Me.Validator.SetDisplayName(Me.txtTaxRate, Me.lblTaxRate.Text)

      'Me.lblCreditType.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CrystalReportSelectionView.lblCreditType}")

      'Me.lblCreditPeriod.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CrystalReportSelectionView.lblCreditPeriod}")
      'Me.Validator.SetDisplayName(Me.txtCreditPeriod, Me.lblCreditPeriod.Text)

      'Me.lblCreditPeriodUnit.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CrystalReportSelectionView.lblCreditPeriodUnit}")

      'Me.lblCreditAmount.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CrystalReportSelectionView.lblCreditAmount}")
      'Me.Validator.SetDisplayName(Me.txtCreditAmount, Me.lblCreditAmount.Text)

      'Me.lblCreditPeriodFromTransport.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CrystalReportSelectionView.lblCreditPeriodFromTransport}")
      'Me.Validator.SetDisplayName(Me.txtCreditPeriodFromTransport, Me.lblCreditPeriodFromTransport.Text)

      Me.btnOk.Text = Me.StringParserService.Parse("${res:Global.OKButtonText}")
      Me.btnCancel.Text = Me.StringParserService.Parse("${res:Global.CancelButtonText}")

      'Me.btnShowMap.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CrystalReportSelectionView.btnShowMap}")
      'Me.btnLoadMap.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CrystalReportSelectionView.btnLoadMap}")
      'Me.btnLoadImage.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CrystalReportSelectionView.btnLoadImage}")

      'Me.lblReceiveDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CrystalReportSelectionView.lblReceiveDate}")
      'Me.Validator.SetDisplayName(Me.txtReceiveDates, Me.lblReceiveDate.Text)

      'Me.lblReceiveWeek.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CrystalReportSelectionView.lblReceiveWeek}")
      'Me.Validator.SetDisplayName(Me.txtReceiveWeeks, Me.lblReceiveWeek.Text)

      'Me.lblReceiveDay.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CrystalReportSelectionView.lblReceiveDay}")
      'Me.Validator.SetDisplayName(Me.txtReceiveDays, Me.lblReceiveDay.Text)

      'Me.lblBillRecWeek.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CrystalReportSelectionView.lblBillRecWeek}")
      'Me.Validator.SetDisplayName(Me.txtBillRecWeeks, Me.txtBillRecWeeks.Text)

      'Me.lblBillRecDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CrystalReportSelectionView.lblBillRecDate}")
      'Me.Validator.SetDisplayName(Me.txtBillRecDates, Me.txtBillRecDates.Text)

      'Me.lblBillRecDay.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CrystalReportSelectionView.lblBillRecDay}")
      'Me.Validator.SetDisplayName(Me.txtBillRecDays, Me.lblBillRecDay.Text)

      'Me.grbReceive.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CrystalReportSelectionView.grbReceive}")
      'Me.lblCheckAmountOnHand.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CrystalReportSelectionView.lblCheckAmountOnHand}")

    End Sub
#End Region

#Region "Member"
    Private m_entity As Supplier
    Private m_isInitialized As Boolean = False
#End Region

#Region "Constructor"
    Public Sub New()
      MyBase.New()
      Me.InitializeComponent()
      Me.SetLabelText()
      Initialize()
      EventWiring()
    End Sub
#End Region

#Region "Properties"

#End Region

#Region "Methods"
    Private Function ConvertItemsToValueArray(ByVal list As String) As String
      Dim result As String = ""
      If list Is Nothing OrElse list.Length = 0 Then
        Return Nothing
      Else
        For Each item As String In list.Split(","c)
          result &= CStr(CInt(item) + 1) & ","
        Next
        If result.Length <> 0 Then
          result = result.TrimEnd(","c)
        End If
        Return result
      End If
    End Function
#End Region

#Region "IListDetail"

    ' ตรวจสอบสถานะของฟอร์ม
    Public Overrides Sub CheckFormEnable()
      'If m_entity.Canceled Then
      '  For Each ctrl As Control In gbListSelect.Controls
      '    If ctrl.Name.ToLower <> "btncancel" Then
      '      ctrl.Enabled = False
      '    End If
      '  Next
      '  grbSupplier.Enabled = False
      '  grbReceive.Enabled = False
      '  grbBillRec.Enabled = False
      '  grbFinancial.Enabled = False
      '  grbCredit.Enabled = False
      '  grbMap.Enabled = False
      'Else
      '  For Each ctrl As Control In gbListSelect.Controls
      '    ctrl.Enabled = True
      '  Next
      '  grbSupplier.Enabled = True
      '  grbReceive.Enabled = True
      '  grbBillRec.Enabled = True
      '  grbFinancial.Enabled = True
      '  grbCredit.Enabled = True
      '  grbMap.Enabled = True
      'End If
    End Sub

    ' เคลียร์ข้อมูลลูกค้าใน control
    Public Overrides Sub ClearDetail()
      For Each crlt As Control In gbListSelect.Controls
        If TypeOf crlt Is TextBox Then
          crlt.Text = ""
        End If
      Next

      txtbirthdate.Text = Me.StringParserService.Parse("${res:Global.BlankDateText}")
      txtLastContactDate.Text = Me.StringParserService.Parse("${res:Global.BlankDateText}")
      txtLastPaydate.Text = Me.StringParserService.Parse("${res:Global.BlankDateText}")

      dtpBirthDate.Value = Now.Date
      dtpLastContactDate.Value = Now.Date
      dtpLastPayDate.Value = Now.Date

      cmbCreditType.SelectedIndex = -1
      cmbCreditType.SelectedIndex = -1

    End Sub

    Protected Overrides Sub EventWiring()
      AddHandler dtpBirthDate.ValueChanged, AddressOf Me.ChangeProperty
      AddHandler dtpLastContactDate.ValueChanged, AddressOf Me.ChangeProperty
      AddHandler dtpLastPayDate.ValueChanged, AddressOf Me.ChangeProperty

      AddHandler txtbirthdate.Validated, AddressOf Me.ChangeProperty
      AddHandler txtLastContactDate.Validated, AddressOf Me.ChangeProperty
      AddHandler txtLastPaydate.Validated, AddressOf Me.ChangeProperty

      AddHandler txtHomePage.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtBillRecDates.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtBillRecWeeks.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtReceiveDates.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtReceiveWeeks.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtSummaryDiscount.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtDetailDiscount.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtTaxRate.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtCheckAmountOnHand.TextChanged, AddressOf Me.ChangeProperty

      AddHandler cmbCreditType.SelectedValueChanged, AddressOf Me.ChangeProperty

      AddHandler txtCreditPeriod.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtCreditAmount.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtCreditPeriodFromTransport.TextChanged, AddressOf Me.ChangeProperty
    End Sub
    ' แสดงค่าข้อมูลของลูกค้าลงใน control ที่อยู่บนฟอร์ม
    Public Overrides Sub UpdateEntityProperties()
      m_isInitialized = False
      ClearDetail()
      If m_entity Is Nothing Then
        Return
      End If

      txtCode.Text = Me.m_entity.Code
      txtName.Text = Me.m_entity.Name

      picImage.Image = Me.m_entity.Image
      CheckLabelImgSize()
      picMap.Image = Me.m_entity.Map

      dtpBirthDate.Value = MinDateToNow(Me.m_entity.BirthDate)
      txtbirthdate.Text = MinDateToNull(Me.m_entity.BirthDate, Me.StringParserService.Parse("${res:Global.BlankDateText}"))

      dtpLastContactDate.Value = MinDateToNow(Me.m_entity.LastContactDate)
      txtLastContactDate.Text = MinDateToNull(Me.m_entity.LastContactDate, Me.StringParserService.Parse("${res:Global.BlankDateText}"))

      dtpLastPayDate.Value = MinDateToNow(Me.m_entity.LastPayDate)
      txtLastPaydate.Text = MinDateToNull(Me.m_entity.LastPayDate, Me.StringParserService.Parse("${res:Global.BlankDateText}"))


      txtHomePage.Text = Me.m_entity.HomePage

      txtBillRecDays.Text = DateTimeService.GetDayStrings(Me.m_entity.BillrecDays, False)
      txtBillRecDates.Text = ConvertItemsToValueArray(Me.m_entity.BillRecDates)
      txtBillRecWeeks.Text = ConvertItemsToValueArray(Me.m_entity.BillRecWeeks)
      txtReceiveDays.Text = DateTimeService.GetDayStrings(Me.m_entity.ReceiveDays, False)
      txtReceiveDates.Text = ConvertItemsToValueArray(Me.m_entity.ReceiveDates)
      txtReceiveWeeks.Text = ConvertItemsToValueArray(Me.m_entity.ReceiveWeeks)

      txtSummaryDiscount.Text = Me.m_entity.SummaryDiscount.Rate
      txtDetailDiscount.Text = Me.m_entity.DetailDiscount.Rate

      txtTaxRate.Text = Me.m_entity.TaxRate.ToString
      txtCheckAmountOnHand.Text = Me.m_entity.CheckAmountOnHand.ToString

      cmbCreditType.SelectedValue = Me.m_entity.CreditType.Value

      txtCreditPeriod.Text = Me.m_entity.CreditPeriod.ToString
      txtCreditAmount.Text = Me.m_entity.CreditAmount.ToString
      txtCreditPeriodFromTransport.Text = Me.m_entity.CreditPeriodFromTransport.ToString

      SetLabelText()
      CheckFormEnable()

      m_isInitialized = True
    End Sub
    Public Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)
      If Me.m_entity Is Nothing Or Not m_isInitialized Then
        Return
      End If
      Try
        Select Case CType(sender, Control).Name.ToLower
          Case "dtpbirthdate"
            DateToString(dtpBirthDate, txtbirthdate)
            Me.m_entity.BirthDate = dtpBirthDate.Value

          Case "txthomepage"
            Me.m_entity.HomePage = txtHomePage.Text

          Case "dtplastcontactdate"
            DateToString(dtpLastContactDate, txtLastContactDate)
            Me.m_entity.LastContactDate = dtpLastContactDate.Value

          Case "dtplastpaydate"
            DateToString(dtpLastPayDate, txtLastPaydate)
            Me.m_entity.LastPayDate = dtpLastPayDate.Value

          Case "txtdetaildiscount"
            Me.m_entity.DetailDiscount.Rate = txtDetailDiscount.Text

          Case "txtsummarydiscount"
            Me.m_entity.SummaryDiscount.Rate = txtSummaryDiscount.Text

          Case "txttaxrate"
            If IsNumeric(txtTaxRate.Text) Then
              Me.m_entity.TaxRate = CDec(txtTaxRate.Text)
            Else
              Me.m_entity.TaxRate = Nothing
            End If

          Case "txtcheckamountonhand"
            If IsNumeric(txtCheckAmountOnHand.Text) Then
              Me.m_entity.CheckAmountOnHand = CDec(txtCheckAmountOnHand.Text)
            Else
              Me.m_entity.CheckAmountOnHand = Nothing
            End If

          Case "cmbcredittype"
            Me.m_entity.CreditType.Value = CInt(cmbCreditType.SelectedValue)

          Case "txtcreditperiod"
            If IsNumeric(txtCreditPeriod.Text) Then
              Me.m_entity.CreditPeriod = CInt(txtCreditPeriod.Text)
            Else
              Me.m_entity.CreditPeriod = Nothing
            End If

          Case "txtcreditamount"
            If IsNumeric(txtCreditAmount.Text) Then
              Me.m_entity.CreditAmount = CDec(txtCreditAmount.Text)
            Else
              Me.m_entity.CreditAmount = Nothing
            End If

          Case "txtcreditperiodfromtransport"
            If IsNumeric(txtCreditPeriodFromTransport.Text) Then
              Me.m_entity.CreditPeriodFromTransport = CInt(txtCreditPeriodFromTransport.Text)
            Else
              Me.m_entity.CreditPeriodFromTransport = Nothing
            End If

          Case "txtbirthdate"
            Dim dt As DateTime = StringToDate(txtbirthdate, dtpBirthDate)
            Me.m_entity.BirthDate = dt

          Case "txtlastcontactdate"
            Dim dt As DateTime = StringToDate(txtLastContactDate, dtpLastContactDate)
            Me.m_entity.LastContactDate = dt

          Case "txtlastpaydate"
            Dim dt As DateTime = StringToDate(txtLastPaydate, dtpLastPayDate)
            Me.m_entity.LastPayDate = dt

        End Select
      Catch ex As Exception

      End Try
      'Hack
      Dim myContent As IViewContent = WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ViewContent
      myContent.IsDirty = True
    End Sub
    Public Overrides Property Entity() As ISimpleEntity
      Get
        Return Me.m_entity
      End Get
      Set(ByVal Value As ISimpleEntity)
        Me.m_entity = Nothing
        Me.m_entity = CType(Value, Supplier)
        Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
        Me.SaveProperties()
        'Me.m_entity.OnTabPageTextChanged(m_entity, EventArgs.Empty)
        UpdateEntityProperties()
      End Set
    End Property

    Public Overrides Sub Initialize()
      Dim propService As PropertyService = CType(ServiceManager.Services.GetService(GetType(PropertyService)), PropertyService)
      Dim culture As String = propService.GetProperty("CoreProperties.UILanguage", "th")
      culture = culture & "-" & culture.ToUpper
      'Me.DateTimeService.ListDaysInComboBox(Me.cmbBillrecDay, False, culture)
      'Me.DateTimeService.ListDaysInComboBox(Me.cmbReceiveDay, False, culture)

      Me.cmbCreditType.DataSource = CodeDescription.GetCodeList("credit_type")
      Me.cmbCreditType.DisplayMember = "code_description"
      Me.cmbCreditType.ValueMember = "code_value"
    End Sub

#End Region

#Region "Event Handlers"
    Private Sub btnLoadImage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Dim dlg As New OpenFileDialog
      Dim fileFilters As String() = CType(AddInTreeSingleton.AddInTree.GetTreeNode("/Pojjaman/Workbench/Image/FileFilter").BuildChildItems(Me).ToArray(GetType(String)), String())
      dlg.Filter = String.Join("|", fileFilters)
      If dlg.ShowDialog = DialogResult.OK Then
        Dim img As Image = Image.FromFile(dlg.FileName)
        If img.Size.Height > Me.picImage.Height OrElse img.Size.Width >= Me.picImage.Width Then
          Dim percent As Decimal = 100 * (Math.Min(Me.picImage.Height / img.Size.Height, Me.picImage.Width / img.Size.Width))
          img = ImageHelper.Resize(img, percent)
        End If
        Me.picImage.Image = img
        m_entity.Image = img
        'Hack
        Dim myContent As IViewContent = WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ViewContent
        myContent.IsDirty = True
        CheckLabelImgSize()
      End If
    End Sub

    Private Sub btnLoadMap_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Dim dlg As New OpenFileDialog
      Dim fileFilters As String() = CType(AddInTreeSingleton.AddInTree.GetTreeNode("/Pojjaman/Workbench/Image/FileFilter").BuildChildItems(Me).ToArray(GetType(String)), String())
      dlg.Filter = String.Join("|", fileFilters)
      If dlg.ShowDialog = DialogResult.OK Then
        Dim img As Image = Image.FromFile(dlg.FileName)
        Me.picMap.Image = img
        m_entity.Map = img
        'Hack
        Dim myContent As IViewContent = WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ViewContent
        myContent.IsDirty = True
        Dim myDialog As New Longkong.Pojjaman.Gui.Dialogs.PanelDialog(New Longkong.Pojjaman.Gui.Panels.MapDialog(m_entity, Me))
        myDialog.ShowDialog()
      End If
    End Sub

    Private Sub btnShowMap_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Dim myDialog As New Longkong.Pojjaman.Gui.Dialogs.PanelDialog(New Longkong.Pojjaman.Gui.Panels.MapDialog(m_entity, Me))
      myDialog.ShowDialog()
      Me.picMap.Invalidate()
    End Sub
    Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
      Me.RevertProperties()
    End Sub
    Private Sub ImbBillRecDate_Click(ByVal sender As Object, ByVal e As System.EventArgs)
      Dim dates(30) As Object
      For i As Integer = 1 To 31
        dates(i - 1) = i
      Next
      Dim chkdlg As New Longkong.Pojjaman.Gui.Panels.CheckListDialog(dates, Me.m_entity.BillRecDates)
      Dim myDialog As New Longkong.Pojjaman.Gui.Dialogs.PanelDialog(chkdlg)
      If myDialog.ShowDialog() = DialogResult.OK Then
        Me.txtBillRecDates.Text = chkdlg.CheckedItemsString
        Me.m_entity.BillRecDates = chkdlg.CheckedValuesString
        Dim myContent As IViewContent = WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ViewContent
        myContent.IsDirty = True
      End If
    End Sub
    Private Sub ImbBillRecDay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Dim days As Object() = Me.DateTimeService.GetDays(False).ToArray
      Dim chkdlg As New Longkong.Pojjaman.Gui.Panels.CheckListDialog(days, Me.m_entity.BillrecDays)
      Dim myDialog As New Longkong.Pojjaman.Gui.Dialogs.PanelDialog(chkdlg)
      If myDialog.ShowDialog() = DialogResult.OK Then
        Me.txtBillRecDays.Text = chkdlg.CheckedItemsString
        Me.m_entity.BillrecDays = chkdlg.CheckedValuesString
        Dim myContent As IViewContent = WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ViewContent
        myContent.IsDirty = True
      End If
    End Sub
    Private Sub ImbBillRecWeek_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Dim weeks(3) As Object
      For i As Integer = 1 To 4
        weeks(i - 1) = i
      Next
      Dim chkdlg As New Longkong.Pojjaman.Gui.Panels.CheckListDialog(weeks, Me.m_entity.BillRecWeeks)
      Dim myDialog As New Longkong.Pojjaman.Gui.Dialogs.PanelDialog(chkdlg)
      If myDialog.ShowDialog() = DialogResult.OK Then
        Me.txtBillRecWeeks.Text = chkdlg.CheckedItemsString
        Me.m_entity.BillRecWeeks = chkdlg.CheckedValuesString
        Dim myContent As IViewContent = WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ViewContent
        myContent.IsDirty = True
      End If
    End Sub
    Private Sub ImbReceiveDay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Dim days As Object() = Me.DateTimeService.GetDays(False).ToArray
      Dim chkdlg As New Longkong.Pojjaman.Gui.Panels.CheckListDialog(days, Me.m_entity.ReceiveDays)
      Dim myDialog As New Longkong.Pojjaman.Gui.Dialogs.PanelDialog(chkdlg)
      If myDialog.ShowDialog() = DialogResult.OK Then
        Me.txtReceiveDays.Text = chkdlg.CheckedItemsString
        Me.m_entity.ReceiveDays = chkdlg.CheckedValuesString
        Dim myContent As IViewContent = WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ViewContent
        myContent.IsDirty = True
      End If
    End Sub
    Private Sub ImbReceiveDate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Dim dates(30) As Object
      For i As Integer = 1 To 31
        dates(i - 1) = i
      Next
      Dim chkdlg As New Longkong.Pojjaman.Gui.Panels.CheckListDialog(dates, Me.m_entity.ReceiveDates)
      Dim myDialog As New Longkong.Pojjaman.Gui.Dialogs.PanelDialog(chkdlg)
      If myDialog.ShowDialog() = DialogResult.OK Then
        Me.txtReceiveDates.Text = chkdlg.CheckedItemsString
        Me.m_entity.ReceiveDates = chkdlg.CheckedValuesString
        Dim myContent As IViewContent = WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ViewContent
        myContent.IsDirty = True
      End If
    End Sub
    Private Sub ImbReceiveWeek_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Dim weeks(3) As Object
      For i As Integer = 1 To 4
        weeks(i - 1) = i
      Next
      Dim chkdlg As New Longkong.Pojjaman.Gui.Panels.CheckListDialog(weeks, Me.m_entity.ReceiveWeeks)
      Dim myDialog As New Longkong.Pojjaman.Gui.Dialogs.PanelDialog(chkdlg)
      If myDialog.ShowDialog() = DialogResult.OK Then
        Me.txtReceiveWeeks.Text = chkdlg.CheckedItemsString
        Me.m_entity.ReceiveWeeks = chkdlg.CheckedValuesString
        Dim myContent As IViewContent = WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ViewContent
        myContent.IsDirty = True
      End If
    End Sub
    Private Sub picMap_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs)
      Dim g As Graphics = e.Graphics
      Dim pn As New Pen(Color.Red, 3)
      Dim top As Integer = Me.m_entity.MapPosition.Y - 10
      If top < 0 Then top = 0
      Dim left As Integer = Me.m_entity.MapPosition.X - 10
      If left < 0 Then left = 0
      Dim bottom As Integer = Me.m_entity.MapPosition.Y + 10
      If bottom > picMap.Height Then bottom = picMap.Height
      Dim right As Integer = Me.m_entity.MapPosition.X + 10
      If right > picMap.Width Then right = picMap.Width
      g.DrawLine(pn, left, top, right, bottom)
      g.DrawLine(pn, right, top, left, bottom)
      pn.Dispose()
    End Sub
    Private m_Ticks As Long
    Private m_canDrag As Boolean = False
    Const TICKS_OFFSET As Long = 0
    Private Sub picMap_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
      Dim ts As New TimeSpan(Now.Ticks - m_Ticks)
      If m_canDrag And e.Button = MouseButtons.Left And ts.TotalMilliseconds > TICKS_OFFSET Then
        If picMap.Bounds.Contains(New Point(e.X, e.Y)) Then
          Me.m_entity.MapPosition = New Point(e.X, e.Y)
          picMap.Invalidate()
          m_Ticks = Now.Ticks
        End If
      End If
    End Sub
    Private Sub picMap_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
      'Dim top As Integer = Me.m_entity.MapPosition.Y - 10
      'If top < 0 Then top = 0
      'Dim left As Integer = Me.m_entity.MapPosition.X - 10
      'If left < 0 Then left = 0
      'Dim bottom As Integer = Me.m_entity.MapPosition.Y + 10
      'If bottom > picMap.Height Then bottom = picMap.Height
      'Dim right As Integer = Me.m_entity.MapPosition.X + 10
      'If right > picMap.Width Then right = picMap.Width

      'Dim xBounds As New Rectangle(left, top, 20, 20)
      'If xBounds.Contains(New Point(e.X, e.Y)) Then
      '    m_canDrag = True
      'End If

      m_canDrag = True
      If picMap.Bounds.Contains(New Point(e.X, e.Y)) Then
        Me.m_entity.MapPosition = New Point(e.X, e.Y)
        picMap.Invalidate()
        'Hack
        Dim myContent As IViewContent = WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ViewContent
        myContent.IsDirty = True
      End If
    End Sub
    Private Sub picMap_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
      If picMap.Bounds.Contains(New Point(e.X, e.Y)) Then
        Me.m_entity.MapPosition = New Point(e.X, e.Y)
        'Hack
        Dim myContent As IViewContent = WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ViewContent
        myContent.IsDirty = True
      End If
      m_canDrag = False
    End Sub
#End Region

#Region "IReversibleEntityProperty"

#Region "Members"
    Private m_oldStatusIsDirty As Boolean
    Private m_oldBirthdate As Date
    Private m_oldHomePage As String
    Private m_oldLastContactDate As Date
    Private m_oldBillrecDay As DayOfWeek
    Private m_oldBillRecDate As Integer
    Private m_oldBillRecWeek As Integer
    Private m_oldReceiveDay As DayOfWeek
    Private m_oldReceiveDate As Integer
    Private m_oldReceiveWeek As Integer
    Private m_oldLastPayDate As Date
    Private m_oldSummaryDiscount As Discount
    Private m_oldDetailDiscount As Discount
    Private m_oldTaxRate As Decimal
    Private m_oldCheckAmountOnHand As Decimal
    Private m_oldCreditType As CreditType
    Private m_oldCreditPeriod As Integer
    Private m_oldCreditAmount As Decimal
    Private m_oldCreditPeriodFromTransport As Integer
    Private m_oldMap As Image
    Private m_oldImage As Image
    Private m_oldMapPosition As Point
#End Region

    Public Sub RevertProperties() Implements IReversibleEntityProperty.RevertProperties
      Dim myContent As IViewContent = WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ViewContent
      myContent.IsDirty = m_oldStatusIsDirty
      Me.m_entity.BirthDate = m_oldBirthdate
      Me.m_entity.HomePage = m_oldHomePage
      Me.m_entity.LastContactDate = m_oldLastContactDate
      'Me.m_entity.BillrecDay = m_oldBillrecDay
      'Me.m_entity.BillRecDate = m_oldBillRecDate
      'Me.m_entity.BillRecWeek = m_oldBillRecWeek
      'Me.m_entity.ReceiveDays = m_oldReceiveDay
      'Me.m_entity.ReceiveDate = m_oldReceiveDate
      'Me.m_entity.ReceiveWeek = m_oldReceiveWeek
      Me.m_entity.LastPayDate = m_oldLastPayDate
      Me.m_entity.SummaryDiscount = m_oldSummaryDiscount
      Me.m_entity.DetailDiscount = m_oldDetailDiscount
      Me.m_entity.TaxRate = m_oldTaxRate
      Me.m_entity.CheckAmountOnHand = m_oldCheckAmountOnHand
      Me.m_entity.CreditType = m_oldCreditType
      Me.m_entity.CreditPeriod = m_oldCreditPeriod
      Me.m_entity.CreditAmount = m_oldCreditAmount
      Me.m_entity.CreditPeriodFromTransport = m_oldCreditPeriodFromTransport
      Me.m_entity.Map = m_oldMap
      Me.m_entity.Image = m_oldImage
      Me.m_entity.MapPosition = m_oldMapPosition
      Me.m_entity.HtChangedProperties.Clear()
    End Sub
    Public Sub SaveProperties() Implements IReversibleEntityProperty.SaveProperties
      Dim myContent As IViewContent = WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ViewContent
      m_oldStatusIsDirty = myContent.IsDirty
      m_oldBirthdate = Me.m_entity.BirthDate
      m_oldHomePage = Me.m_entity.HomePage
      m_oldLastContactDate = Me.m_entity.LastContactDate
      'm_oldBillrecDay = Me.m_entity.BillrecDay
      'm_oldBillRecDate = Me.m_entity.BillRecDate
      'm_oldBillRecWeek = Me.m_entity.BillRecWeek
      'm_oldReceiveDay = Me.m_entity.ReceiveDays
      'm_oldReceiveDate = Me.m_entity.ReceiveDate
      'm_oldReceiveWeek = Me.m_entity.ReceiveWeek
      m_oldLastPayDate = Me.m_entity.LastPayDate
      m_oldSummaryDiscount = Me.m_entity.SummaryDiscount
      m_oldDetailDiscount = Me.m_entity.DetailDiscount
      m_oldTaxRate = Me.m_entity.TaxRate
      m_oldCheckAmountOnHand = Me.m_entity.CheckAmountOnHand
      m_oldCreditType = Me.m_entity.CreditType
      m_oldCreditPeriod = Me.m_entity.CreditPeriod
      m_oldCreditAmount = Me.m_entity.CreditAmount
      m_oldCreditPeriodFromTransport = Me.m_entity.CreditPeriodFromTransport
      m_oldMap = Me.m_entity.Map
      m_oldImage = Me.m_entity.Image
      m_oldMapPosition = Me.m_entity.MapPosition
    End Sub
#End Region

    Private Sub btnClearMap_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      m_entity.Map = Nothing
      Me.picMap.Image = Nothing
      Dim myContent As IViewContent = WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ViewContent
      myContent.IsDirty = True
    End Sub

    Private Sub btnClearImage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      m_entity.Image = Nothing
      Me.picImage.Image = Nothing
      Dim myContent As IViewContent = WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ViewContent
      myContent.IsDirty = True
      CheckLabelImgSize()
    End Sub
    Private Sub CheckLabelImgSize()
      Me.lblPicSize.Text = "120 X 120 pixel"
      If Me.m_entity.Image Is Nothing Then
        Me.lblPicSize.Visible = True
      Else
        Me.lblPicSize.Visible = False
      End If
    End Sub
  End Class

End Namespace
