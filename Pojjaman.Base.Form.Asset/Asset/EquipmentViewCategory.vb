Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.TextHelper
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.AddIns
Namespace Longkong.Pojjaman.Gui.Panels
  Public Class EquipmentCategoryView
    Inherits AbstractEntityDetailPanelView
    Implements IValidatable

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
    Friend WithEvents grbDetail As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents btnAssetAuxDetail As System.Windows.Forms.Button
    Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents chkAutorun As System.Windows.Forms.CheckBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents lblEQTCode As System.Windows.Forms.Label
    Friend WithEvents Grbeqi As System.Windows.Forms.GroupBox
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents cmbCode As System.Windows.Forms.ComboBox
    <System.Diagnostics.DebuggerStepThrough()> Protected Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EquipmentCategoryView))
      Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.Grbeqi = New System.Windows.Forms.GroupBox()
      Me.cmbCode = New System.Windows.Forms.ComboBox()
      Me.DataGridView1 = New System.Windows.Forms.DataGridView()
      Me.lblEQTCode = New System.Windows.Forms.Label()
      Me.lblName = New System.Windows.Forms.Label()
      Me.txtName = New System.Windows.Forms.TextBox()
      Me.chkAutorun = New System.Windows.Forms.CheckBox()
      Me.btnAssetAuxDetail = New System.Windows.Forms.Button()
      Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
      Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
      Me.grbDetail.SuspendLayout()
      Me.Grbeqi.SuspendLayout()
      CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'grbDetail
      '
      Me.grbDetail.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.grbDetail.Controls.Add(Me.Grbeqi)
      Me.grbDetail.Controls.Add(Me.btnAssetAuxDetail)
      Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbDetail.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.grbDetail.ForeColor = System.Drawing.Color.Blue
      Me.grbDetail.Location = New System.Drawing.Point(8, 5)
      Me.grbDetail.Name = "grbDetail"
      Me.grbDetail.Size = New System.Drawing.Size(534, 421)
      Me.grbDetail.TabIndex = 0
      Me.grbDetail.TabStop = False
      Me.grbDetail.Text = "ข้อมูลสินทรัพย์ : "
      '
      'Grbeqi
      '
      Me.Grbeqi.Controls.Add(Me.cmbCode)
      Me.Grbeqi.Controls.Add(Me.DataGridView1)
      Me.Grbeqi.Controls.Add(Me.lblEQTCode)
      Me.Grbeqi.Controls.Add(Me.lblName)
      Me.Grbeqi.Controls.Add(Me.txtName)
      Me.Grbeqi.Controls.Add(Me.chkAutorun)
      Me.Grbeqi.Location = New System.Drawing.Point(6, 20)
      Me.Grbeqi.Name = "Grbeqi"
      Me.Grbeqi.Size = New System.Drawing.Size(500, 384)
      Me.Grbeqi.TabIndex = 208
      Me.Grbeqi.TabStop = False
      Me.Grbeqi.Text = "รายละเอียดเครื่องจักรรายตัว"
      '
      'cmbCode
      '
      Me.cmbCode.Location = New System.Drawing.Point(122, 66)
      Me.cmbCode.Name = "cmbCode"
      Me.cmbCode.Size = New System.Drawing.Size(120, 21)
      Me.cmbCode.TabIndex = 333
      '
      'DataGridView1
      '
      Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
      Me.DataGridView1.Location = New System.Drawing.Point(48, 137)
      Me.DataGridView1.Name = "DataGridView1"
      Me.DataGridView1.Size = New System.Drawing.Size(387, 164)
      Me.DataGridView1.TabIndex = 5
      '
      'lblEQTCode
      '
      Me.lblEQTCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblEQTCode.ForeColor = System.Drawing.Color.Black
      Me.lblEQTCode.Location = New System.Drawing.Point(17, 64)
      Me.lblEQTCode.Name = "lblEQTCode"
      Me.lblEQTCode.Size = New System.Drawing.Size(104, 23)
      Me.lblEQTCode.TabIndex = 0
      Me.lblEQTCode.Text = "รหัสชนิดเครื่องจักร:"
      Me.lblEQTCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblName
      '
      Me.lblName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblName.ForeColor = System.Drawing.Color.Black
      Me.lblName.Location = New System.Drawing.Point(33, 39)
      Me.lblName.Name = "lblName"
      Me.lblName.Size = New System.Drawing.Size(88, 18)
      Me.lblName.TabIndex = 4
      Me.lblName.Text = "ชื่อชนิดเครื่องจักร :"
      Me.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtName
      '
      Me.Validator.SetDataType(Me.txtName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtName, "")
      Me.txtName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtName, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtName, -15)
      Me.Validator.SetInvalidBackColor(Me.txtName, System.Drawing.Color.Empty)
      Me.txtName.Location = New System.Drawing.Point(121, 39)
      Me.txtName.MaxLength = 255
      Me.Validator.SetMinValue(Me.txtName, "")
      Me.txtName.Name = "txtName"
      Me.Validator.SetRegularExpression(Me.txtName, "")
      Me.Validator.SetRequired(Me.txtName, True)
      Me.txtName.Size = New System.Drawing.Size(314, 21)
      Me.txtName.TabIndex = 3
      '
      'chkAutorun
      '
      Me.chkAutorun.Appearance = System.Windows.Forms.Appearance.Button
      Me.chkAutorun.Image = CType(resources.GetObject("chkAutorun.Image"), System.Drawing.Image)
      Me.chkAutorun.Location = New System.Drawing.Point(243, 65)
      Me.chkAutorun.Name = "chkAutorun"
      Me.chkAutorun.Size = New System.Drawing.Size(21, 21)
      Me.chkAutorun.TabIndex = 1
      Me.chkAutorun.TabStop = False
      '
      'btnAssetAuxDetail
      '
      Me.btnAssetAuxDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnAssetAuxDetail.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnAssetAuxDetail.ForeColor = System.Drawing.Color.Black
      Me.btnAssetAuxDetail.Location = New System.Drawing.Point(762, 877)
      Me.btnAssetAuxDetail.Name = "btnAssetAuxDetail"
      Me.btnAssetAuxDetail.Size = New System.Drawing.Size(96, 24)
      Me.btnAssetAuxDetail.TabIndex = 46
      Me.btnAssetAuxDetail.TabStop = False
      Me.btnAssetAuxDetail.Text = "ข้อมูลเพิ่มเติม"
      '
      'Validator
      '
      Me.Validator.BackcolorChanging = False
      Me.Validator.DataTable = Nothing
      Me.Validator.ErrorProvider = Me.ErrorProvider1
      Me.Validator.GotFocusBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
      Me.Validator.HasNewRow = False
      Me.Validator.InvalidBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
      '
      'ErrorProvider1
      '
      Me.ErrorProvider1.ContainerControl = Me
      '
      'EquitmentCategoryView
      '
      Me.Controls.Add(Me.grbDetail)
      Me.Name = "EquipmentCategoryView"
      Me.Size = New System.Drawing.Size(550, 437)
      Me.grbDetail.ResumeLayout(False)
      Me.Grbeqi.ResumeLayout(False)
      Me.Grbeqi.PerformLayout()
      CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

    End Sub

#End Region

#Region " SetLabelText "
    Public Overrides Sub SetLabelText()
      If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
      Me.lblName.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetDetailView.lblName}")
      Me.Validator.SetDisplayName(Me.txtName, StringHelper.GetRidOfAtEnd(Me.lblName.Text, ":"))


      Me.btnAssetAuxDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetDetailView.btnAssetAuxDetail}")
      Me.btnAssetAuxDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetDetailView.btnAssetAuxDetail}")

      'Me.grbStatus.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetDetailView.grbStatus}")
      Me.grbDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetDetailView.grbDetail}")
      'Me.chkCancel.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetDetailView.chkCancel}")
      'Me.chkDecay.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetDetailView.chkDecay}")


    End Sub
#End Region

#Region "Member"
    Private m_entity As Equipment
    Private m_isInitialized As Boolean = False

#End Region

#Region "Constructor"
    Public Sub New()
      MyBase.New()
      Me.InitializeComponent()
      Me.Initialize()

      Me.EventWiring()
      Me.SetLabelText()

      Me.UpdateEntityProperties()

    End Sub
#End Region

#Region "Method"
    'Public Overrides Sub Initialize()
    '  ' กำหนดการคำนวณค่าเสื่อมราคา
    '  AssetCalcType.ListCodeDescriptionInComboBox(cmbCalcType, "asset_calctype")
    '  ' กำหนดอัตราค่าเช่าพื้นฐาน
    'End Sub
    ' แสดงค่าข้อมูลลงใน control ที่อยู่บนฟอร์ม
    Public Overrides Sub UpdateEntityProperties()
      Me.m_isInitialized = False
      If m_entity Is Nothing Then
        ClearDetail()
        Return
      End If

      ' autogencode
      cmbCode.Text = m_entity.Code
      Me.m_oldCode = Me.m_entity.Code
      Me.chkAutorun.Checked = Me.m_entity.AutoGen
      Me.UpdateAutogenStatus()

      Me.txtName.Text = m_entity.Name

      SetLabelText()
      CheckFormEnable()
      Me.m_isInitialized = True
    End Sub

    Protected Overrides Sub EventWiring()
      ' สถานะสินทรัพย์
      'AddHandler chkCancel.CheckedChanged, AddressOf Me.ChangeStatus
      'AddHandler chkDecay.CheckedChanged, AddressOf Me.ChangeStatus

      'AddHandler txtCode.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtName.TextChanged, AddressOf Me.ChangeProperty
      'AddHandler txtDetail.TextChanged, AddressOf Me.ChangeProperty

      'AddHandler txtGLCode.Validated, AddressOf Me.ChangeProperty
      'AddHandler txtDepreOpeningAcctCode.Validated, AddressOf Me.ChangeProperty
      'AddHandler txtDepreAcctCode.Validated, AddressOf Me.ChangeProperty

      'AddHandler txtCostcenterCode.Validated, AddressOf Me.ChangeProperty
      'AddHandler txtTypeCode.Validated, AddressOf Me.ChangeProperty

      'AddHandler txtLocation.TextChanged, AddressOf Me.ChangeProperty
      'AddHandler txtNote.TextChanged, AddressOf Me.ChangeProperty

      'AddHandler cmbCalcType.SelectedIndexChanged, AddressOf Me.ChangeProperty

      'AddHandler txtAge.TextChanged, AddressOf Me.ChangeProperty

      'AddHandler txtStartCalcDate.Validated, AddressOf Me.ChangeProperty
      'AddHandler dtpStartCalcDate.ValueChanged, AddressOf Me.ChangeProperty

      ''AddHandler txtCalcRate.TextChanged, AddressOf Me.ChangeProperty
      'AddHandler txtStartCalcAmt.TextChanged, AddressOf Me.ChangeProperty
      'AddHandler txtSalvage.TextChanged, AddressOf Me.ChangeProperty
      'AddHandler txtDepreOpenning.TextChanged, AddressOf Me.ChangeProperty
      'AddHandler txtRemainingValue.TextChanged, AddressOf Me.ChangeProperty

      'AddHandler txtTransferDate.Validated, AddressOf Me.ChangeProperty
      'AddHandler dtpTransferDate.ValueChanged, AddressOf Me.ChangeProperty

      'AddHandler txtBuyDate.Validated, AddressOf Me.ChangeProperty
      'AddHandler dtpBuyDate.ValueChanged, AddressOf Me.ChangeProperty

      'AddHandler txtBuyPrice.TextChanged, AddressOf Me.ChangeProperty
      'AddHandler txtBuyDocCode.TextChanged, AddressOf Me.ChangeProperty

      'AddHandler txtBuyDocDate.Validated, AddressOf Me.ChangeProperty
      'AddHandler dtpBuyDocDate.ValueChanged, AddressOf Me.ChangeProperty

      'AddHandler txtBuyFrom.TextChanged, AddressOf Me.ChangeProperty

      ''AddHandler txtRent.TextChanged, AddressOf Me.ChangeProperty

      '' numeric format  
      ''AddHandler txtRent.Validated, AddressOf Me.NumerberTextBoxChange
      'AddHandler txtAge.Validated, AddressOf Me.NumerberTextBoxChange
      'AddHandler txtCalcRate.Validated, AddressOf Me.NumerberTextBoxChange

      'AddHandler txtStartCalcAmt.Validated, AddressOf Me.NumerberTextBoxChange
      'AddHandler txtDepreOpenning.Validated, AddressOf Me.NumerberTextBoxChange

      'AddHandler txtSalvage.Validated, AddressOf Me.NumerberTextBoxChange
      'AddHandler txtBuyPrice.Validated, AddressOf Me.NumerberTextBoxChange

      '' SetDefault value  
      'AddHandler cmbCalcType.SelectedIndexChanged, AddressOf Me.SetValue
      'AddHandler txtAge.Validated, AddressOf Me.SetValue
      'AddHandler txtStartCalcAmt.Validated, AddressOf Me.SetValue
      'AddHandler dtpStartCalcDate.Validated, AddressOf Me.SetValue

      'AddHandler txtStartCalcAmt.Validated, AddressOf Me.SetValue
      'AddHandler txtDepreOpenning.Validated, AddressOf Me.SetValue

      'AddHandler txtSalvage.Validated, AddressOf Me.SetValue
      'AddHandler txtBuyPrice.Validated, AddressOf Me.SetValue

    End Sub
    'Public Sub ChangeStatus(ByVal sender As Object, ByVal e As EventArgs)
    '    If Me.m_entity Is Nothing Or Not Me.m_isInitialized Then
    '        Return
    '    End If
    '    Dim dirtyFlag As Boolean = False
    '    Select Case CType(sender, Control).Name.ToLower
    '        Case "chkcancel"
    '            Me.m_entity.Canceled = chkCancel.Checked
    '            dirtyFlag = True
    '        Case "chkdecay"
    '            If chkDecay.Checked Then
    '                Me.m_entity.Status.Value = 4
    '            Else
    '                Me.m_entity.Status.Value = 2
    '            End If
    '            dirtyFlag = True
    '    End Select
    '    Me.WorkbenchWindow.ViewContent.IsDirty = Me.WorkbenchWindow.ViewContent.IsDirty Or dirtyFlag
    '    CheckFormEnable()
    'End Sub
    'Public Sub SetValueFromAssetType()
    '  If Not Me.m_entity.Type Is Nothing _
    '  AndAlso Not Me.m_entity.Type.DepreAble Then
    '    'txtUnitCode.Enabled = False
    '    'txtUnitName.Enabled = False
    '    'btnUnitEdit.Enabled = False
    '    'btnUnitFind.Enabled = False
    '    'txtUnitCode.Text = Me.m_entity.Type.Unit.Code
    '    'txtUnitName.Text = Me.m_entity.Type.Unit.Name
    '  Else
    '    ''txtUnitCode.Text = ""
    '    ''txtUnitName.Text = ""
    '    'txtUnitCode.Enabled = True
    '    'txtUnitName.Enabled = True
    '    'btnUnitEdit.Enabled = True
    '    'btnUnitFind.Enabled = True
    '  End If
    '  Dim flag As Boolean = Me.m_isInitialized
    '  Me.m_isInitialized = False
    '  If Not Me.m_entity.Account Is Nothing Then
    '    txtGLCode.Text = Me.m_entity.Account.Code
    '    txtGLName.Text = Me.m_entity.Account.Name
    '  End If
    '  If Not Me.m_entity.DepreOpeningAccount Is Nothing Then
    '    txtDepreOpeningAcctCode.Text = Me.m_entity.DepreOpeningAccount.Code
    '    txtDepreOpeningAcctName.Text = Me.m_entity.DepreOpeningAccount.Name
    '  End If
    '  If Not Me.m_entity.DepreAccount Is Nothing Then
    '    txtDepreAcctCode.Text = Me.m_entity.DepreAccount.Code
    '    txtDepreAcctName.Text = Me.m_entity.DepreAccount.Name
    '  End If
    '  Me.m_isInitialized = flag
    'End Sub
    'Public Sub NumerberTextBoxChange(ByVal sender As Object, ByVal e As EventArgs)
    '  If Me.m_entity Is Nothing Or Not Me.m_isInitialized Then
    '    Return
    '  End If
    '  Select Case CType(sender, Control).Name.ToLower
    '    'Case "txtrent"
    '    '    txtRent.Text = Configuration.FormatToString(Me.m_entity.RentalRate, DigitConfig.Price)
    '    Case "txtage"
    '      txtAge.Text = Configuration.FormatToString(Me.m_entity.Age, DigitConfig.Int)
    '    Case "txtcalcrate"
    '      txtCalcRate.Text = Configuration.FormatToString(Me.m_entity.CalcRate, DigitConfig.Qty)
    '    Case "txtstartcalcamt"
    '      txtStartCalcAmt.Text = Configuration.FormatToString(Me.m_entity.StartCalcAmt, DigitConfig.Price)
    '    Case "txtsalvage"
    '      txtSalvage.Text = Configuration.FormatToString(Me.m_entity.Salvage, DigitConfig.Price)
    '    Case "txtdepreopenning"
    '      txtDepreOpenning.Text = Configuration.FormatToString(Me.m_entity.DepreOpening, DigitConfig.Price)
    '    Case "txtremainingvalue"
    '      txtRemainingValue.Text = Configuration.FormatToString(Me.m_entity.RemainValue, DigitConfig.Price)

    '    Case "txtbuyprice"
    '      txtBuyPrice.Text = Configuration.FormatToString(Me.m_entity.BuyPrice, DigitConfig.Price)
    '  End Select
    'End Sub
    'Private m_dateSetting As Boolean = False
    Public Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)

      If Me.m_entity Is Nothing Or Not Me.m_isInitialized Then
        Return
      End If
      Dim dirtyFlag As Boolean = False
      Dim tmpFlag As Boolean = Me.m_isInitialized
      Me.m_isInitialized = False
      Select Case CType(sender, Control).Name.ToLower
        'Case "txtcode"
        '  Me.m_entity.Code = txtCode.Text
        '  dirtyFlag = True
        Case "txtname"
          Me.m_entity.Name = txtName.Text
          dirtyFlag = True
          'Case "txtdetail"
          '  Me.m_entity.Detail = txtDetail.Text
          '  dirtyFlag = True

          'Case "txtglcode"
          '  dirtyFlag = Account.GetAccount(txtGLCode, txtGLName, Me.m_entity.Account)
          'Case "txtdepreopeningacctcode"
          '  dirtyFlag = Account.GetAccount(txtDepreOpeningAcctCode, txtDepreOpeningAcctName, Me.m_entity.DepreOpeningAccount)
          'Case "txtdepreacctcode"
          '  dirtyFlag = Account.GetAccount(txtDepreAcctCode, txtDepreAcctName, Me.m_entity.DepreAccount)
          'Case "txtcostcentercode"
          '  dirtyFlag = CostCenter.GetCostCenter(txtCostcenterCode, txtCostcenterName, Me.m_entity.Costcenter)
          'Case "txttypecode"
          '  dirtyFlag = AssetType.GetAssetType(txtTypeCode, txtTypeName, Me.m_entity.Type)
          '  Me.SetValueFromAssetType()
          'Case "txtlocation"
          '  Me.m_entity.Location = txtLocation.Text
          '  dirtyFlag = True

          '  'Case "txtrent"
          '  '    If txtRent.TextLength > 0 Then
          '  '        Me.m_entity.RentalRate = CDec(txtRent.Text)
          '  '    Else
          '  '        Me.m_entity.RentalRate = Nothing
          '  '    End If
          '  '    dirtyFlag = True

          'Case "txtnote"
          '  Me.m_entity.Note = txtNote.Text
          '  dirtyFlag = True
          'Case "cmbcalctype"
          '  Dim idPair As IdValuePair = CType(Me.cmbCalcType.SelectedItem, IdValuePair)
          '  Me.m_entity.CalcType.Value = idPair.Id
          '  Me.m_entity.CalcType.Description = idPair.Value
          '  dirtyFlag = True

          'Case "txtage"
          '  If txtAge.TextLength > 0 AndAlso Me.Validator.GetErrorMessage(txtAge).Length = 0 Then
          '    Me.m_entity.Age = CInt(txtAge.Text)
          '  Else
          '    Me.m_entity.Age = Nothing
          '  End If
          '  dirtyFlag = True

          'Case "dtpstartcalcdate"
          '  If Not Me.m_entity.StartCalcDate.Equals(dtpStartCalcDate.Value) Then
          '    If Not m_dateSetting Then
          '      Me.txtStartCalcDate.Text = MinDateToNull(dtpStartCalcDate.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
          '      Me.m_entity.StartCalcDate = dtpStartCalcDate.Value
          '    End If
          '    dirtyFlag = True
          '  End If
          'Case "txtstartcalcdate"
          '  m_dateSetting = True
          '  If Not Me.txtStartCalcDate.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtStartCalcDate) = "" Then
          '    Dim theDate As Date = CDate(Me.txtStartCalcDate.Text)
          '    If Not Me.m_entity.StartCalcDate.Equals(theDate) Then
          '      dtpStartCalcDate.Value = theDate
          '      Me.m_entity.StartCalcDate = dtpStartCalcDate.Value
          '      dirtyFlag = True
          '    End If
          '  Else
          '    dtpStartCalcDate.Value = Date.Now
          '    Me.m_entity.StartCalcDate = Date.MinValue
          '    dirtyFlag = True
          '  End If
          '  m_dateSetting = False

          'Case "txtstartcalcamt"
          '  If txtStartCalcAmt.TextLength > 0 Then
          '    Me.m_entity.StartCalcAmt = CDec(txtStartCalcAmt.Text)
          '  Else
          '    Me.m_entity.StartCalcAmt = Nothing
          '  End If
          '  txtDepreOpenning.Text = Configuration.FormatToString(Me.m_entity.DepreOpening, DigitConfig.Price)
          '  dirtyFlag = True

          'Case "txtdepreopenning"
          '  If txtDepreOpenning.TextLength > 0 Then
          '    Me.m_entity.DepreOpening = CDec(txtDepreOpenning.Text)
          '  Else
          '    Me.m_entity.DepreOpening = Nothing
          '  End If
          '  txtStartCalcAmt.Text = Configuration.FormatToString(Me.m_entity.StartCalcAmt, DigitConfig.Price)
          '  dirtyFlag = True

          'Case "dtptransferdate"
          '  If Not Me.m_entity.TransferDate.Equals(dtpTransferDate.Value) Then
          '    If Not m_dateSetting Then
          '      Me.txtTransferDate.Text = MinDateToNull(dtpTransferDate.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
          '      Me.m_entity.TransferDate = dtpTransferDate.Value
          '    End If
          '    dirtyFlag = True
          '  End If
          'Case "txttransferdate"
          '  m_dateSetting = True
          '  If Not Me.txtTransferDate.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtTransferDate) = "" Then
          '    Dim theDate As Date = CDate(Me.txtTransferDate.Text)
          '    If Not Me.m_entity.TransferDate.Equals(theDate) Then
          '      dtpTransferDate.Value = theDate
          '      Me.m_entity.TransferDate = dtpTransferDate.Value
          '      dirtyFlag = True
          '    End If
          '  Else
          '    dtpTransferDate.Value = Date.Now
          '    Me.m_entity.TransferDate = Date.MinValue
          '    dirtyFlag = True
          '  End If
          '  m_dateSetting = False

          'Case "dtpbuydate"
          '  If Not Me.m_entity.BuyDate.Equals(dtpBuyDate.Value) Then
          '    If Not m_dateSetting Then
          '      Me.txtBuyDate.Text = MinDateToNull(dtpBuyDate.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
          '      Me.m_entity.BuyDate = dtpBuyDate.Value
          '    End If
          '    dirtyFlag = True
          '  End If
          'Case "txtbuydate"
          '  m_dateSetting = True
          '  If Not Me.txtBuyDate.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtBuyDate) = "" Then
          '    Dim theDate As Date = CDate(Me.txtBuyDate.Text)
          '    If Not Me.m_entity.BuyDate.Equals(theDate) Then
          '      dtpBuyDate.Value = theDate
          '      Me.m_entity.BuyDate = dtpBuyDate.Value
          '      dirtyFlag = True
          '    End If
          '  Else
          '    dtpBuyDate.Value = Date.Now
          '    Me.m_entity.BuyDate = Date.MinValue
          '    dirtyFlag = True
          '  End If
          '  m_dateSetting = False
          'Case "txtbuyprice"
          '  dirtyFlag = True
          '  If txtBuyPrice.TextLength > 0 Then
          '    Me.m_entity.BuyPrice = CDec(txtBuyPrice.Text)
          '  Else
          '    Me.m_entity.BuyPrice = Nothing
          '  End If

          'Case "txtbuydoccode"
          '  Me.m_entity.BuyDocCode = txtBuyDocCode.Text
          '  dirtyFlag = True

          'Case "txtbuydocdate"
          '  Dim dt As DateTime = StringToDate(txtBuyDocDate, dtpBuyDocDate)
          '  Me.m_entity.BuyDocDate = dt
          '  dirtyFlag = True

          'Case "dtpbuydocdate"
          '  txtBuyDocDate.Text = MinDateToNull(dtpBuyDocDate.Value, "")
          '  Me.m_entity.BuyDocDate = dtpBuyDocDate.Value
          '  dirtyFlag = True

          'Case "txtbuyfrom"
          '  Me.m_entity.BuyFrom = txtBuyFrom.Text
          '  dirtyFlag = True

          'Case "txtsalvage"
          '  If txtSalvage.TextLength > 0 Then
          '    Me.m_entity.Salvage = CDec(txtSalvage.Text)
          '  Else
          '    Me.m_entity.Salvage = Nothing
          '  End If
          '  dirtyFlag = True

      End Select
      Me.m_isInitialized = tmpFlag
      Me.WorkbenchWindow.ViewContent.IsDirty = Me.WorkbenchWindow.ViewContent.IsDirty Or dirtyFlag

      CheckFormEnable()
    End Sub
    'Private Sub CalcDepreEndCalcDate()
    '  txtEndCalcDate.Text = MinDateToNull(Me.m_entity.EndCalcDate, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
    'End Sub
    'Private Sub CalcDepreCalcRate()
    '  txtCalcRate.Text = Configuration.FormatToString(Me.m_entity.CalcRate, DigitConfig.Qty)
    'End Sub
    'Private Sub SetValue(ByVal sender As Object, ByVal e As EventArgs)
    '  If Me.m_entity Is Nothing Or Not Me.m_isInitialized Then
    '    Return
    '  End If
    '  ' คำนวณค่าเริ่มต้นที่สำคัญ
    '  Select Case CType(sender, Control).Name.ToLower
    '    ' คำนวณเกี่ยวกับวันที่เริ่มต้น
    '    Case "cmbcalctype"
    '      CalcDepreEndCalcDate()
    '      CalcDepreCalcRate()
    '    Case "txtage"
    '      CalcDepreEndCalcDate()
    '      CalcDepreCalcRate()

    '    Case "txtstartcalcdate"
    '      CalcDepreEndCalcDate()

    '    Case "dtpstartcalcdate"
    '      CalcDepreEndCalcDate()

    '    Case "txtsalvage", "txtbuyprice", "txtdepreopenning", "txtstartcalcamt"
    '      txtRemainingValue.Text = Configuration.FormatToString(Me.m_entity.RemainValue, DigitConfig.Price)
    '  End Select
    'End Sub
#End Region

#Region "IListDetail"
    'Private Sub CheckIsDepreciated(ByVal flag As Boolean)
    '  ' ผังบัญชี
    '  txtGLCode.Enabled = Not flag
    '  txtGLName.Enabled = Not flag
    '  btnGLEdit.Enabled = Not flag
    '  btnGLFind.Enabled = Not flag
    '  ' ผังบัญชีค่าเสื่อมสะสม
    '  txtDepreOpeningAcctCode.Enabled = Not flag
    '  txtDepreOpeningAcctName.Enabled = Not flag
    '  btnDepreOpeningAcctEdit.Enabled = Not flag
    '  btnDepreOpeningAcctFind.Enabled = Not flag
    '  ' ผังบัญชีค่าเสื่อม
    '  txtDepreAcctCode.Enabled = Not flag
    '  txtDepreAcctName.Enabled = Not flag
    '  btnDepreAcctEdit.Enabled = Not flag
    '  btnDepreAcctFind.Enabled = Not flag
    '  ' cost center
    '  txtCostcenterCode.Enabled = Not flag
    '  txtCostcenterName.Enabled = Not flag
    '  btnCostcenterEdit.Enabled = Not flag
    '  btnCostcenterFind.Enabled = Not flag
    '  ' การคำนวณ
    '  grbCalcDetail.Enabled = Not flag
    '  ' การซื้อ 
    '  grbBuyDetail.Enabled = Not flag
    'End Sub

    ' ตรวจสอบสถานะของฟอร์ม
    Public Overrides Sub CheckFormEnable()
      ' Protected from ...
      If Me.m_entity.Canceled Then
        For Each crlt As Control In grbDetail.Controls
          crlt.Enabled = False
        Next
        'For Each crlt As Control In grbStatus.Controls
        '    crlt.Enabled = False
        'Next
        'grbCalcDetail.Enabled = False
        'grbBuyDetail.Enabled = False
        'chkCancel.Enabled = True
      Else
        For Each crlt As Control In grbDetail.Controls
          crlt.Enabled = True
        Next
        'For Each ctrl As Control In grbStatus.Controls
        '    ctrl.Enabled = True
        'Next

      End If

    End Sub

    ' เคลียร์ข้อมูลใน control
    Public Overrides Sub ClearDetail()
      For Each ctrl As Control In grbDetail.Controls
        If TypeOf ctrl Is FixedGroupBox OrElse TypeOf ctrl Is GroupBox Then
          For Each child As Control In ctrl.Controls
            If TypeOf child Is TextBox Then
              child.Text = ""
            End If
          Next
        ElseIf TypeOf ctrl Is TextBox Then
          ctrl.Text = ""
        End If
      Next

    End Sub

    Public Overrides Property Entity() As ISimpleEntity
      Get
        Return Me.m_entity
      End Get
      Set(ByVal Value As ISimpleEntity)

        If Not Object.ReferenceEquals(Me.m_entity, Value) Then
          Me.m_entity = Nothing
          Me.m_entity = CType(Value, Equipment)
          'Me.m_entity.LoadImage()
        End If

        'Hack:
        Me.m_entity.OnTabPageTextChanged(m_entity, EventArgs.Empty)


        UpdateEntityProperties()
      End Set
    End Property



#End Region

#Region " IValidatable "
    Public ReadOnly Property FormValidator() As Components.PJMTextboxValidator Implements IValidatable.FormValidator
      Get
        Return Me.Validator
      End Get
    End Property
#End Region

#Region "Image button"
    'Private Sub btnLoadImage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '  Dim dlg As New OpenFileDialog
    '  Dim fileFilters As String() = CType(AddInTreeSingleton.AddInTree.GetTreeNode("/Pojjaman/Workbench/Image/FileFilter").BuildChildItems(Me).ToArray(GetType(String)), String())
    '  dlg.Filter = String.Join("|", fileFilters)
    '  If dlg.ShowDialog = DialogResult.OK Then
    '    Dim img As Image = Image.FromFile(dlg.FileName)
    '    If img.Size.Height > Me.picImage.Height OrElse img.Size.Width >= Me.picImage.Width Then
    '      Dim percent As Decimal = 100 * (Math.Min(Me.picImage.Height / img.Size.Height, Me.picImage.Width / img.Size.Width))
    '      img = ImageHelper.Resize(img, percent)
    '    End If
    '    Me.picImage.Image = img
    '    m_entity.Image = img
    '    Dim myContent As IViewContent = WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ViewContent
    '    myContent.IsDirty = True
    '    CheckLabelImgSize()
    '  End If
    'End Sub
    'Private Sub btnClearImage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '  m_entity.Image = Nothing
    '  Me.picImage.Image = Nothing
    '  Dim myContent As IViewContent = WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ViewContent
    '  myContent.IsDirty = True
    '  CheckLabelImgSize()
    'End Sub
#End Region

#Region "IClipboardHandler Overrides"
    Public Overrides ReadOnly Property EnablePaste() As Boolean
      Get
        Dim data As IDataObject = Clipboard.GetDataObject
        If data.GetDataPresent((New Account).FullClassName) Then
          If Not Me.ActiveControl Is Nothing Then
            Select Case Me.ActiveControl.Name.ToLower
              Case "txtglcode", "txtglname"
                Return True
              Case "txtdepreopeningacctcode", "txtdepreopeningacctname"
                Return True
              Case "txtdepreacctcode", "txtdepreacctname"
                Return True
            End Select
          End If
        End If
        If data.GetDataPresent((New Unit).FullClassName) Then
          If Not Me.ActiveControl Is Nothing Then
            Select Case Me.ActiveControl.Name.ToLower
              Case "txtunitcode", "txtunitname"
                Return True
            End Select
          End If
        End If
        If data.GetDataPresent((New AssetType).FullClassName) Then
          If Not Me.ActiveControl Is Nothing Then
            Select Case Me.ActiveControl.Name.ToLower
              Case "txttypecode", "txttypename"
                Return True
            End Select
          End If
        End If
        If data.GetDataPresent((New CostCenter).FullClassName) Then
          If Not Me.ActiveControl Is Nothing Then
            Select Case Me.ActiveControl.Name.ToLower
              Case "txtcostcentercode", "txtcostcentername"
                Return True
            End Select
          End If
        End If
        Return False
      End Get
    End Property
    Public Overrides Sub Paste(ByVal sender As Object, ByVal e As System.EventArgs)
      'Dim data As IDataObject = Clipboard.GetDataObject
      'If data.GetDataPresent((New Account).FullClassName) Then
      '  Dim id As Integer = CInt(data.GetData((New Account).FullClassName))
      '  Dim entity As New Account(id)
      '  If Not Me.ActiveControl Is Nothing Then
      '    Select Case Me.ActiveControl.Name.ToLower
      '      Case "txtglcode", "txtglname"
      '        Me.SetAccountDialog(entity)
      '      Case "txtdepreopeningacctcode", "txtdepreopeningacctname"
      '        Me.SetDepreOpeningAccountDialog(entity)
      '      Case "txtdepreacctcode", "txtdepreacctname"
      '        Me.SetDepreAccountDialog(entity)
      '    End Select
      '  End If
      'End If
      'If data.GetDataPresent((New AssetType).FullClassName) Then
      '  Dim id As Integer = CInt(data.GetData((New AssetType).FullClassName))
      '  Dim entity As New AssetType(id)
      '  If Not Me.ActiveControl Is Nothing Then
      '    Select Case Me.ActiveControl.Name.ToLower
      '      Case "txttypecode", "txttypename"
      '        Me.SetAssetTypeDialog(entity)
      '    End Select
      '  End If
      'End If
      'If data.GetDataPresent((New CostCenter).FullClassName) Then
      '  Dim id As Integer = CInt(data.GetData((New CostCenter).FullClassName))
      '  Dim entity As New CostCenter(id)
      '  If Not Me.ActiveControl Is Nothing Then
      '    Select Case Me.ActiveControl.Name.ToLower
      '      Case "txtcostcentercode", "txtcostcentername"
      '        Me.SetCostCenterDialog(entity)
      '    End Select
      '  End If
      'End If
    End Sub
#End Region

#Region "Event of Button controls"
    '' Account button
    'Private Sub btnGLEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '  Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
    '  myEntityPanelService.OpenPanel(New Account)
    'End Sub
    'Private Sub btnGLFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '  Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
    '  Select Case CType(sender, Control).Name.ToLower
    '    Case "btnglfind"
    '      myEntityPanelService.OpenTreeDialog(New Account, AddressOf SetAccountDialog)
    '    Case "btndepreopeningacctfind"
    '      myEntityPanelService.OpenTreeDialog(New Account, AddressOf SetDepreOpeningAccountDialog)
    '    Case "btndepreacctfind"
    '      myEntityPanelService.OpenTreeDialog(New Account, AddressOf SetDepreAccountDialog)
    '  End Select
    'End Sub
    'Private Sub SetAccountDialog(ByVal e As ISimpleEntity)
    '  Me.txtGLCode.Text = e.Code
    '  Me.WorkbenchWindow.ViewContent.IsDirty = _
    '      Me.WorkbenchWindow.ViewContent.IsDirty _
    '      Or Account.GetAccount(txtGLCode, txtGLName, Me.m_entity.Account)
    'End Sub
    'Private Sub SetDepreOpeningAccountDialog(ByVal e As ISimpleEntity)
    '  Me.txtDepreOpeningAcctCode.Text = e.Code
    '  Me.WorkbenchWindow.ViewContent.IsDirty = _
    '      Me.WorkbenchWindow.ViewContent.IsDirty _
    '      Or Account.GetAccount(txtDepreOpeningAcctCode, txtDepreOpeningAcctName, Me.m_entity.DepreOpeningAccount)
    'End Sub
    'Private Sub SetDepreAccountDialog(ByVal e As ISimpleEntity)
    '  Me.txtDepreAcctCode.Text = e.Code
    '  Me.WorkbenchWindow.ViewContent.IsDirty = _
    '      Me.WorkbenchWindow.ViewContent.IsDirty _
    '      Or Account.GetAccount(txtDepreAcctCode, txtDepreAcctName, Me.m_entity.DepreAccount)
    'End Sub
    '' Type button
    'Private Sub btnTypeEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '  Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
    '  myEntityPanelService.OpenPanel(New AssetType)
    'End Sub
    'Private Sub btnTypeFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '  Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
    '  myEntityPanelService.OpenTreeDialog(New AssetType, AddressOf SetAssetTypeDialog)
    'End Sub
    'Private Sub SetAssetTypeDialog(ByVal e As ISimpleEntity)
    '  Me.txtTypeCode.Text = e.Code
    '  Me.WorkbenchWindow.ViewContent.IsDirty = _
    '      Me.WorkbenchWindow.ViewContent.IsDirty _
    '      Or AssetType.GetAssetType(txtTypeCode, txtTypeName, Me.m_entity.Type)
    '  SetValueFromAssetType()
    'End Sub

    '' Costcenter button
    'Private Sub btnCostcenterEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '  Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
    '  myEntityPanelService.OpenPanel(New CostCenter)
    'End Sub
    'Private Sub btnCostcenterFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '  Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
    '  myEntityPanelService.OpenTreeDialog(New CostCenter, AddressOf SetCostCenterDialog)
    'End Sub
    'Private Sub SetCostCenterDialog(ByVal e As ISimpleEntity)
    '  Me.txtCostcenterCode.Text = e.Code
    '  Me.WorkbenchWindow.ViewContent.IsDirty = _
    '      Me.WorkbenchWindow.ViewContent.IsDirty _
    '      Or CostCenter.GetCostCenter(txtCostcenterCode, txtCostcenterName, Me.m_entity.Costcenter)
    'End Sub

    '' More detail
    'Private Sub btnAssetAuxDetail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAssetAuxDetail.Click
    '  Dim myAuxPanel As New Longkong.Pojjaman.Gui.Panels.AssetAuxDetail
    '  myAuxPanel.Entity = Me.m_entity
    '  Dim myDialog As New Longkong.Pojjaman.Gui.Dialogs.PanelDialog(myAuxPanel)
    '  If myDialog.ShowDialog() = DialogResult.Cancel Then
    '    Me.WorkbenchWindow.ViewContent.IsDirty = False
    '  End If
    'End Sub
#End Region

#Region " Autogencode "
    Private Sub chkAutorun_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAutorun.CheckedChanged
      UpdateAutogenStatus()
    End Sub
    Private m_oldCode As String = ""
    Private Sub UpdateAutogenStatus()
      If Me.chkAutorun.Checked Then
        'Me.Validator.SetRequired(Me.txtCode, False)
        'Me.ErrorProvider1.SetError(Me.txtCode, "")
        Me.cmbCode.DropDownStyle = ComboBoxStyle.DropDownList
        Dim currentUserId As Integer = Me.SecurityService.CurrentUser.Id
        BusinessLogic.Entity.NewPopulateCodeCombo(Me.cmbCode, Me.m_entity.EntityId, currentUserId)
        If Me.m_entity.Code Is Nothing OrElse Me.m_entity.Code.Length = 0 Then
          If Me.cmbCode.Items.Count > 0 Then
            Me.m_entity.Code = CType(Me.cmbCode.Items(0), AutoCodeFormat).Format
            Me.cmbCode.SelectedIndex = 0
            Me.m_entity.AutoCodeFormat = CType(Me.cmbCode.Items(0), AutoCodeFormat)
          End If
        Else
          Me.cmbCode.SelectedIndex = Me.cmbCode.FindStringExact(Me.m_entity.Code)
          If TypeOf Me.cmbCode.SelectedItem Is AutoCodeFormat Then
            Me.m_entity.AutoCodeFormat = CType(Me.cmbCode.SelectedItem, AutoCodeFormat)
          End If
        End If
        m_oldCode = Me.cmbCode.Text
        Me.m_entity.Code = m_oldCode
        Me.m_entity.AutoGen = True
      Else
        'Me.Validator.SetRequired(Me.txtCode, True)
        Me.cmbCode.DropDownStyle = ComboBoxStyle.Simple
        Me.cmbCode.Items.Clear()
        Me.cmbCode.Text = m_oldCode
        Me.m_entity.Code = m_oldCode
        Me.m_entity.AutoGen = False
      End If
    End Sub
#End Region

    'Private Sub CheckLabelImgSize()
    '  Me.lblPicSize.Text = "272 X 204 pixel"
    '  If Me.m_entity.Image Is Nothing Then
    '    Me.lblPicSize.Visible = True
    '  Else
    '    Me.lblPicSize.Visible = False
    '  End If
    'End Sub

    'Private Sub Label4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    'End Sub

    'Private Sub DateTimePicker1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    'End Sub
  End Class

End Namespace
