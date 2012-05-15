Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.TextHelper
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Namespace Longkong.Pojjaman.Gui.Panels
  Public Class EqRentalSummary
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
    Friend WithEvents lblDate As System.Windows.Forms.Label
    Friend WithEvents lblPrice As System.Windows.Forms.Label
    Friend WithEvents lblBaht As System.Windows.Forms.Label
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
    Friend WithEvents txtAssetCode As System.Windows.Forms.TextBox
    Friend WithEvents txtAssetName As System.Windows.Forms.TextBox
    Friend WithEvents txtBuyDate As System.Windows.Forms.TextBox
    Friend WithEvents txtBuyPrice As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Protected Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Me.tgItem = New Longkong.Pojjaman.Gui.Components.TreeGrid()
      Me.lblItem = New System.Windows.Forms.Label()
      Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.lblTool = New System.Windows.Forms.Label()
      Me.txtAssetCode = New System.Windows.Forms.TextBox()
      Me.txtAssetName = New System.Windows.Forms.TextBox()
      Me.txtBuyDate = New System.Windows.Forms.TextBox()
      Me.lblDate = New System.Windows.Forms.Label()
      Me.txtBuyPrice = New System.Windows.Forms.TextBox()
      Me.lblPrice = New System.Windows.Forms.Label()
      Me.lblBaht = New System.Windows.Forms.Label()
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
      Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
      CType(Me.tgItem, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.grbDetail.SuspendLayout()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
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
      Me.tgItem.Location = New System.Drawing.Point(16, 112)
      Me.tgItem.Name = "tgItem"
      Me.tgItem.Size = New System.Drawing.Size(632, 312)
      Me.tgItem.SortingArrowColor = System.Drawing.Color.Red
      Me.tgItem.TabIndex = 165
      Me.tgItem.TreeManager = Nothing
      '
      'lblItem
      '
      Me.lblItem.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblItem.ForeColor = System.Drawing.Color.Black
      Me.lblItem.Location = New System.Drawing.Point(13, 91)
      Me.lblItem.Name = "lblItem"
      Me.lblItem.Size = New System.Drawing.Size(232, 18)
      Me.lblItem.TabIndex = 200
      Me.lblItem.Text = "รายการเครื่องมือและเครื่องจักร"
      Me.lblItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'grbDetail
      '
      Me.grbDetail.Controls.Add(Me.lblTool)
      Me.grbDetail.Controls.Add(Me.txtAssetCode)
      Me.grbDetail.Controls.Add(Me.txtAssetName)
      Me.grbDetail.Controls.Add(Me.txtBuyDate)
      Me.grbDetail.Controls.Add(Me.lblDate)
      Me.grbDetail.Controls.Add(Me.txtBuyPrice)
      Me.grbDetail.Controls.Add(Me.lblPrice)
      Me.grbDetail.Controls.Add(Me.lblBaht)
      Me.grbDetail.Location = New System.Drawing.Point(8, 8)
      Me.grbDetail.Name = "grbDetail"
      Me.grbDetail.Size = New System.Drawing.Size(560, 80)
      Me.grbDetail.TabIndex = 208
      Me.grbDetail.TabStop = False
      Me.grbDetail.Text = "ข้อมูลเครื่องจักร"
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
      Me.Validator.SetMinValue(Me.txtAssetCode, "")
      Me.txtAssetCode.Name = "txtAssetCode"
      Me.txtAssetCode.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtAssetCode, "")
      Me.Validator.SetRequired(Me.txtAssetCode, False)
      Me.txtAssetCode.Size = New System.Drawing.Size(96, 22)
      Me.txtAssetCode.TabIndex = 199
      '
      'txtAssetName
      '
      Me.Validator.SetDataType(Me.txtAssetName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtAssetName, "")
      Me.txtAssetName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtAssetName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtAssetName, System.Drawing.Color.Empty)
      Me.txtAssetName.Location = New System.Drawing.Point(184, 16)
      Me.Validator.SetMinValue(Me.txtAssetName, "")
      Me.txtAssetName.Name = "txtAssetName"
      Me.txtAssetName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtAssetName, "")
      Me.Validator.SetRequired(Me.txtAssetName, False)
      Me.txtAssetName.Size = New System.Drawing.Size(264, 22)
      Me.txtAssetName.TabIndex = 199
      '
      'txtBuyDate
      '
      Me.Validator.SetDataType(Me.txtBuyDate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtBuyDate, "")
      Me.txtBuyDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtBuyDate, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtBuyDate, System.Drawing.Color.Empty)
      Me.txtBuyDate.Location = New System.Drawing.Point(88, 44)
      Me.Validator.SetMinValue(Me.txtBuyDate, "")
      Me.txtBuyDate.Name = "txtBuyDate"
      Me.txtBuyDate.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtBuyDate, "")
      Me.Validator.SetRequired(Me.txtBuyDate, False)
      Me.txtBuyDate.Size = New System.Drawing.Size(96, 22)
      Me.txtBuyDate.TabIndex = 199
      '
      'lblDate
      '
      Me.lblDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDate.ForeColor = System.Drawing.Color.Black
      Me.lblDate.Location = New System.Drawing.Point(8, 44)
      Me.lblDate.Name = "lblDate"
      Me.lblDate.Size = New System.Drawing.Size(80, 18)
      Me.lblDate.TabIndex = 200
      Me.lblDate.Text = "วันที่ซื้อ:"
      Me.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtBuyPrice
      '
      Me.Validator.SetDataType(Me.txtBuyPrice, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtBuyPrice, "")
      Me.txtBuyPrice.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtBuyPrice, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtBuyPrice, System.Drawing.Color.Empty)
      Me.txtBuyPrice.Location = New System.Drawing.Point(296, 44)
      Me.Validator.SetMinValue(Me.txtBuyPrice, "")
      Me.txtBuyPrice.Name = "txtBuyPrice"
      Me.txtBuyPrice.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtBuyPrice, "")
      Me.Validator.SetRequired(Me.txtBuyPrice, False)
      Me.txtBuyPrice.Size = New System.Drawing.Size(120, 22)
      Me.txtBuyPrice.TabIndex = 199
      '
      'lblPrice
      '
      Me.lblPrice.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblPrice.ForeColor = System.Drawing.Color.Black
      Me.lblPrice.Location = New System.Drawing.Point(192, 44)
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
      Me.lblBaht.Location = New System.Drawing.Point(416, 44)
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
      Me.Validator.GotFocusBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
      Me.Validator.HasNewRow = False
      Me.Validator.InvalidBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
      '
      'EqRentalSummary
      '
      Me.Controls.Add(Me.grbDetail)
      Me.Controls.Add(Me.tgItem)
      Me.Controls.Add(Me.lblItem)
      Me.Name = "EqRentalSummary"
      Me.Size = New System.Drawing.Size(656, 432)
      CType(Me.tgItem, System.ComponentModel.ISupportInitialize).EndInit()
      Me.grbDetail.ResumeLayout(False)
      Me.grbDetail.PerformLayout()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

    End Sub

#End Region

#Region "SetLabelText"
    Public Overrides Sub SetLabelText()
      If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
      Me.lblTool.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.EqRentalSummary.lblTool}")
      Me.lblItem.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.EqRentalSummary.lblItem}")
      Me.grbDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.EqRentalSummary.grbDetail}")
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

      Dim dt As TreeTable = Asset.GetSchemaTable()
      Dim dst As DataGridTableStyle = Asset.CreateTableStyle()
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



        txtBuyDate.Text = MinDateToNull(Me.m_entity.BuyDate, "")

        txtBuyDate.Text = Me.MinDateToNull(m_entity.BuyDate, "")

        txtBuyPrice.Text = Configuration.FormatToString(m_entity.BuyPrice, DigitConfig.Price)
      End If

      'Load Items**********************************************************
      Me.m_entity.ReLoadItems()
      Me.m_treeManager.Treetable = Me.m_entity.ItemTable
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
        If m_entity Is Nothing Then
          m_entity = New Asset
        End If
        'Hack:
        Me.m_entity.OnTabPageTextChanged(m_entity, EventArgs.Empty)
        UpdateEntityProperties()
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

    Private Sub lblItem_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblItem.TextChanged

    End Sub

    Protected Overrides Sub Finalize()
      MyBase.Finalize()
    End Sub

#Region " Overrides "
    Public Overrides ReadOnly Property TabPageIcon() As String
      Get
        Return "Icons.16x16.EqRentalSummary"
      End Get
    End Property
#End Region

  End Class
End Namespace