Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.TextHelper
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Namespace Longkong.Pojjaman.Gui.Panels
  Public Class AssetWithdrawReturnView
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
    Friend WithEvents tgItem As Longkong.Pojjaman.Gui.Components.TreeGrid
    Friend WithEvents lblTool As System.Windows.Forms.Label
    Friend WithEvents lblItem As System.Windows.Forms.Label
    Friend WithEvents grbDetail As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents lblLocation As System.Windows.Forms.Label
    Friend WithEvents lblDate As System.Windows.Forms.Label
    Friend WithEvents txtLocation As System.Windows.Forms.TextBox
    Friend WithEvents lblPrice As System.Windows.Forms.Label
    Friend WithEvents lblBaht As System.Windows.Forms.Label
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
    Friend WithEvents cmbStatus As System.Windows.Forms.ComboBox
    Friend WithEvents txtAssetCode As System.Windows.Forms.TextBox
    Friend WithEvents txtAssetName As System.Windows.Forms.TextBox
    Friend WithEvents txtBuyDate As System.Windows.Forms.TextBox
    Friend WithEvents txtBuyPrice As System.Windows.Forms.TextBox
    Friend WithEvents txtLocation1 As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Protected Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container
      Me.tgItem = New Longkong.Pojjaman.Gui.Components.TreeGrid
      Me.lblItem = New System.Windows.Forms.Label
      Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
      Me.cmbStatus = New System.Windows.Forms.ComboBox
      Me.lblTool = New System.Windows.Forms.Label
      Me.txtAssetCode = New System.Windows.Forms.TextBox
      Me.txtAssetName = New System.Windows.Forms.TextBox
      Me.lblStatus = New System.Windows.Forms.Label
      Me.lblLocation = New System.Windows.Forms.Label
      Me.txtBuyDate = New System.Windows.Forms.TextBox
      Me.lblDate = New System.Windows.Forms.Label
      Me.txtLocation = New System.Windows.Forms.TextBox
      Me.txtLocation1 = New System.Windows.Forms.TextBox
      Me.txtBuyPrice = New System.Windows.Forms.TextBox
      Me.lblPrice = New System.Windows.Forms.Label
      Me.lblBaht = New System.Windows.Forms.Label
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider
      Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
      CType(Me.tgItem, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.grbDetail.SuspendLayout()
      Me.SuspendLayout()
      '
      'tgItem
      '
      Me.tgItem.AllowNew = True
      Me.tgItem.AllowSorting = False
      Me.tgItem.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.tgItem.AutoColumnResize = True
      Me.tgItem.CaptionVisible = False
      Me.tgItem.Cellchanged = False
      Me.tgItem.DataMember = ""
      Me.tgItem.HeaderForeColor = System.Drawing.SystemColors.ControlText
      Me.tgItem.Location = New System.Drawing.Point(16, 152)
      Me.tgItem.Name = "tgItem"
      Me.tgItem.Size = New System.Drawing.Size(632, 272)
      Me.tgItem.SortingArrowColor = System.Drawing.Color.Red
      Me.tgItem.TabIndex = 165
      Me.tgItem.TreeManager = Nothing
      '
      'lblItem
      '
      Me.lblItem.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblItem.ForeColor = System.Drawing.Color.Black
      Me.lblItem.Location = New System.Drawing.Point(16, 136)
      Me.lblItem.Name = "lblItem"
      Me.lblItem.Size = New System.Drawing.Size(168, 18)
      Me.lblItem.TabIndex = 200
      Me.lblItem.Text = "บันทีกการใช้งานเครื่องจักร"
      Me.lblItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'grbDetail
      '
      Me.grbDetail.Controls.Add(Me.cmbStatus)
      Me.grbDetail.Controls.Add(Me.lblTool)
      Me.grbDetail.Controls.Add(Me.txtAssetCode)
      Me.grbDetail.Controls.Add(Me.txtAssetName)
      Me.grbDetail.Controls.Add(Me.lblStatus)
      Me.grbDetail.Controls.Add(Me.lblLocation)
      Me.grbDetail.Controls.Add(Me.txtBuyDate)
      Me.grbDetail.Controls.Add(Me.lblDate)
      Me.grbDetail.Controls.Add(Me.txtLocation)
      Me.grbDetail.Controls.Add(Me.txtLocation1)
      Me.grbDetail.Controls.Add(Me.txtBuyPrice)
      Me.grbDetail.Controls.Add(Me.lblPrice)
      Me.grbDetail.Controls.Add(Me.lblBaht)
      Me.grbDetail.Location = New System.Drawing.Point(8, 8)
      Me.grbDetail.Name = "grbDetail"
      Me.grbDetail.Size = New System.Drawing.Size(560, 120)
      Me.grbDetail.TabIndex = 208
      Me.grbDetail.TabStop = False
      Me.grbDetail.Text = "ข้อมูลเครื่องจักร"
      '
      'cmbStatus
      '
      Me.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbStatus.Enabled = False
      Me.cmbStatus.Location = New System.Drawing.Point(88, 40)
      Me.cmbStatus.Name = "cmbStatus"
      Me.cmbStatus.Size = New System.Drawing.Size(96, 21)
      Me.cmbStatus.TabIndex = 201
      '
      'lblTool
      '
      Me.lblTool.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblTool.ForeColor = System.Drawing.Color.Black
      Me.lblTool.Location = New System.Drawing.Point(8, 16)
      Me.lblTool.Name = "lblTool"
      Me.lblTool.Size = New System.Drawing.Size(80, 18)
      Me.lblTool.TabIndex = 200
      Me.lblTool.Text = "Equipment:"
      Me.lblTool.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtAssetCode
      '
      Me.Validator.SetDataType(Me.txtAssetCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtAssetCode, "")
      Me.txtAssetCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtAssetCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtAssetCode, System.Drawing.Color.Empty)
      Me.txtAssetCode.Location = New System.Drawing.Point(88, 16)
      Me.Validator.SetMaxValue(Me.txtAssetCode, "")
      Me.Validator.SetMinValue(Me.txtAssetCode, "")
      Me.txtAssetCode.Name = "txtAssetCode"
      Me.txtAssetCode.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtAssetCode, "")
      Me.Validator.SetRequired(Me.txtAssetCode, False)
      Me.txtAssetCode.Size = New System.Drawing.Size(96, 22)
      Me.txtAssetCode.TabIndex = 199
      Me.txtAssetCode.Text = ""
      '
      'txtAssetName
      '
      Me.Validator.SetDataType(Me.txtAssetName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtAssetName, "")
      Me.txtAssetName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtAssetName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtAssetName, System.Drawing.Color.Empty)
      Me.txtAssetName.Location = New System.Drawing.Point(184, 16)
      Me.Validator.SetMaxValue(Me.txtAssetName, "")
      Me.Validator.SetMinValue(Me.txtAssetName, "")
      Me.txtAssetName.Name = "txtAssetName"
      Me.txtAssetName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtAssetName, "")
      Me.Validator.SetRequired(Me.txtAssetName, False)
      Me.txtAssetName.Size = New System.Drawing.Size(264, 22)
      Me.txtAssetName.TabIndex = 199
      Me.txtAssetName.Text = ""
      '
      'lblStatus
      '
      Me.lblStatus.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblStatus.ForeColor = System.Drawing.Color.Black
      Me.lblStatus.Location = New System.Drawing.Point(8, 42)
      Me.lblStatus.Name = "lblStatus"
      Me.lblStatus.Size = New System.Drawing.Size(80, 18)
      Me.lblStatus.TabIndex = 200
      Me.lblStatus.Text = "สถานะ:"
      Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblLocation
      '
      Me.lblLocation.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblLocation.ForeColor = System.Drawing.Color.Black
      Me.lblLocation.Location = New System.Drawing.Point(8, 64)
      Me.lblLocation.Name = "lblLocation"
      Me.lblLocation.Size = New System.Drawing.Size(80, 18)
      Me.lblLocation.TabIndex = 200
      Me.lblLocation.Text = "Location ล่าสุด:"
      Me.lblLocation.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtBuyDate
      '
      Me.Validator.SetDataType(Me.txtBuyDate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtBuyDate, "")
      Me.txtBuyDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtBuyDate, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtBuyDate, System.Drawing.Color.Empty)
      Me.txtBuyDate.Location = New System.Drawing.Point(88, 88)
      Me.Validator.SetMaxValue(Me.txtBuyDate, "")
      Me.Validator.SetMinValue(Me.txtBuyDate, "")
      Me.txtBuyDate.Name = "txtBuyDate"
      Me.txtBuyDate.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtBuyDate, "")
      Me.Validator.SetRequired(Me.txtBuyDate, False)
      Me.txtBuyDate.Size = New System.Drawing.Size(96, 22)
      Me.txtBuyDate.TabIndex = 199
      Me.txtBuyDate.Text = ""
      '
      'lblDate
      '
      Me.lblDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDate.ForeColor = System.Drawing.Color.Black
      Me.lblDate.Location = New System.Drawing.Point(8, 88)
      Me.lblDate.Name = "lblDate"
      Me.lblDate.Size = New System.Drawing.Size(80, 18)
      Me.lblDate.TabIndex = 200
      Me.lblDate.Text = "วันที่ซื้อ:"
      Me.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtLocation
      '
      Me.Validator.SetDataType(Me.txtLocation, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtLocation, "")
      Me.txtLocation.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtLocation, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtLocation, System.Drawing.Color.Empty)
      Me.txtLocation.Location = New System.Drawing.Point(88, 64)
      Me.Validator.SetMaxValue(Me.txtLocation, "")
      Me.Validator.SetMinValue(Me.txtLocation, "")
      Me.txtLocation.Name = "txtLocation"
      Me.txtLocation.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtLocation, "")
      Me.Validator.SetRequired(Me.txtLocation, False)
      Me.txtLocation.Size = New System.Drawing.Size(96, 22)
      Me.txtLocation.TabIndex = 199
      Me.txtLocation.Text = ""
      '
      'txtLocation1
      '
      Me.Validator.SetDataType(Me.txtLocation1, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtLocation1, "")
      Me.txtLocation1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtLocation1, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtLocation1, System.Drawing.Color.Empty)
      Me.txtLocation1.Location = New System.Drawing.Point(184, 64)
      Me.Validator.SetMaxValue(Me.txtLocation1, "")
      Me.Validator.SetMinValue(Me.txtLocation1, "")
      Me.txtLocation1.Name = "txtLocation1"
      Me.txtLocation1.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtLocation1, "")
      Me.Validator.SetRequired(Me.txtLocation1, False)
      Me.txtLocation1.Size = New System.Drawing.Size(264, 22)
      Me.txtLocation1.TabIndex = 199
      Me.txtLocation1.Text = ""
      '
      'txtBuyPrice
      '
      Me.Validator.SetDataType(Me.txtBuyPrice, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtBuyPrice, "")
      Me.txtBuyPrice.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtBuyPrice, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtBuyPrice, System.Drawing.Color.Empty)
      Me.txtBuyPrice.Location = New System.Drawing.Point(296, 88)
      Me.Validator.SetMaxValue(Me.txtBuyPrice, "")
      Me.Validator.SetMinValue(Me.txtBuyPrice, "")
      Me.txtBuyPrice.Name = "txtBuyPrice"
      Me.txtBuyPrice.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtBuyPrice, "")
      Me.Validator.SetRequired(Me.txtBuyPrice, False)
      Me.txtBuyPrice.Size = New System.Drawing.Size(120, 22)
      Me.txtBuyPrice.TabIndex = 199
      Me.txtBuyPrice.Text = ""
      '
      'lblPrice
      '
      Me.lblPrice.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblPrice.ForeColor = System.Drawing.Color.Black
      Me.lblPrice.Location = New System.Drawing.Point(192, 88)
      Me.lblPrice.Name = "lblPrice"
      Me.lblPrice.Size = New System.Drawing.Size(104, 18)
      Me.lblPrice.TabIndex = 200
      Me.lblPrice.Text = "Purchase price:"
      Me.lblPrice.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblBaht
      '
      Me.lblBaht.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblBaht.ForeColor = System.Drawing.Color.Black
      Me.lblBaht.Location = New System.Drawing.Point(416, 88)
      Me.lblBaht.Name = "lblBaht"
      Me.lblBaht.Size = New System.Drawing.Size(32, 18)
      Me.lblBaht.TabIndex = 200
      Me.lblBaht.Text = "บาท"
      Me.lblBaht.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'ErrorProvider1
      '
      Me.ErrorProvider1.ContainerControl = Me
      '
      'Validator
      '
      Me.Validator.BackcolorChanging = False
      Me.Validator.DataTable = Nothing
      Me.Validator.ErrorProvider = Me.ErrorProvider1
      Me.Validator.GotFocusBackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
      Me.Validator.HasNewRow = False
      Me.Validator.InvalidBackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(128, Byte), CType(0, Byte))
      '
      'AssetWithdrawReturnView
      '
      Me.Controls.Add(Me.grbDetail)
      Me.Controls.Add(Me.tgItem)
      Me.Controls.Add(Me.lblItem)
      Me.Name = "AssetWithdrawReturnView"
      Me.Size = New System.Drawing.Size(656, 432)
      CType(Me.tgItem, System.ComponentModel.ISupportInitialize).EndInit()
      Me.grbDetail.ResumeLayout(False)
      Me.ResumeLayout(False)

    End Sub

#End Region

#Region "SetLabelText"
    Public Overrides Sub SetLabelText()
      If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
      Me.lblTool.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.EqRentalSummary.lblTool}")
      Me.lblItem.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.EqRentalSummary.lblItem}")
      Me.grbDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.EqRentalSummary.grbDetail}")
      Me.lblStatus.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.EqRentalSummary.lblStatus}")
      Me.lblLocation.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.EqRentalSummary.lblLocation}")
      Me.lblDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.EqRentalSummary.lblDate}")
      Me.lblPrice.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.EqRentalSummary.lblPrice}")
      Me.lblBaht.Text = Me.StringParserService.Parse("${res:Global.BahtText}")
    End Sub
#End Region

#Region "Members"
    Private m_entity As Asset
    Private m_isInitialized As Boolean = False
    Private m_treeManager As TreeManager
#End Region

#Region "Constructors"
    Public Sub New()
      MyBase.New()
      Me.InitializeComponent()
      Me.SetLabelText()
      Initialize()

      Dim dt As TreeTable = Asset.VGetSchemaTable()
      Dim dst As DataGridTableStyle = Asset.VCreateTableStyle()
      m_treeManager = New TreeManager(dt, tgItem)
      m_treeManager.SetTableStyle(dst)
      m_treeManager.AllowSorting = False
      m_treeManager.AllowDelete = False
      tgItem.AllowNew = False

      EventWiring()
    End Sub
#End Region

#Region "ISimpleListPanel"
    ' Initialize
    Public Overrides Sub Initialize()
      CodeDescription.ListCodeDescriptionInComboBox(Me.cmbStatus, "asset_status")
    End Sub
    ' CheckFormEnable
    Public Overrides Sub CheckFormEnable()

    End Sub
    ' ClearDetail
    Public Overrides Sub ClearDetail()
      For Each grbCtrl As Control In Me.Controls
        If TypeOf grbCtrl Is FixedGroupBox Then
          For Each Ctrl As Control In grbCtrl.Controls
            If TypeOf Ctrl Is TextBox Then
              Ctrl.Text = ""
            End If
          Next
        End If
      Next
    End Sub
    ' EventWiring
    Protected Overrides Sub EventWiring()
    End Sub
    ' UpdateEntityProperties
    Public Overrides Sub UpdateEntityProperties()
      m_isInitialized = False
      ClearDetail()
      If m_entity Is Nothing Then
        Return
      End If

      If Not m_entity Is Nothing Then

        txtAssetCode.Text = m_entity.Code
        txtAssetName.Text = m_entity.Name

        CodeDescription.ComboSelect(Me.cmbStatus, Me.m_entity.Status)

        txtLocation.Text = m_entity.LastLocation.Code
        txtLocation1.Text = m_entity.LastLocation.Name

        txtBuyDate.Text = MinDateToNull(Me.m_entity.BuyDate, "")

        txtBuyDate.Text = Me.MinDateToNull(m_entity.BuyDate, "")

        txtBuyPrice.Text = Configuration.FormatToString(m_entity.BuyPrice, DigitConfig.Price)
      End If

      'Load Items**********************************************************
      Me.m_entity.VReLoadItems()
      Me.m_treeManager.Treetable = Me.m_entity.VItemTable
      Me.Validator.DataTable = m_treeManager.Treetable
      '********************************************************************

      SetStatus()
      SetLabelText()
      CheckFormEnable()
      m_isInitialized = True
    End Sub
    ' ChangeProperty  (ไม่ได้ใช้งาน)
    Public Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)
      If Me.m_entity Is Nothing Or Not m_isInitialized Then
        Return
      End If
      Dim dirtyFlag As Boolean = False
      Select Case CType(sender, Control).Name.ToLower
        Case ""

      End Select
      Me.WorkbenchWindow.ViewContent.IsDirty = Me.WorkbenchWindow.ViewContent.IsDirty Or dirtyFlag
      CheckFormEnable()
    End Sub
    ' SetStatus
    Public Sub SetStatus()
      ' TODO : Check for entity status
    End Sub
    ' Entity
    Public Overrides Property Entity() As BusinessLogic.ISimpleEntity
      Get
        Return Me.m_entity
      End Get
      Set(ByVal Value As ISimpleEntity)
        Me.m_entity = Nothing
        Me.m_entity = CType(Value, Asset)
        'Hack:
        If Not m_entity Is Nothing Then
          Me.m_entity.OnTabPageTextChanged(m_entity, EventArgs.Empty)
          UpdateEntityProperties()
        End If

      End Set
    End Property
#End Region

#Region "Event Handlers"

#End Region

#Region "IValidatable"
    Public ReadOnly Property FormValidator() As components.PJMTextboxValidator Implements IValidatable.FormValidator
      Get
        Return Me.Validator
      End Get
    End Property
#End Region

#Region " Buttons Envent "

#End Region

    Public Overrides Sub NotifyAfterSave(ByVal successful As Boolean)

    End Sub

  End Class
End Namespace