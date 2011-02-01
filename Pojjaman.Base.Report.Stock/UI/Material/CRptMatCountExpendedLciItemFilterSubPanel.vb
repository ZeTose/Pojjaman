Imports Longkong.Pojjaman.BusinessLogic
Imports longkong.Pojjaman.Services
Imports Longkong.Core.Services
Imports Telerik.WinControls.UI
Imports Telerik.WinControls.Data
Imports Telerik.WinControls

Namespace Longkong.Pojjaman.Gui.Panels
  Public Class CRptMatCountExpandedLciItemFilterSubPanel
    'Inherits UserControl
    Inherits AbstractFilterSubPanel
    Implements IReportFilterSubPanel

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
    Friend WithEvents grbMaster As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents btnRefresh As System.Windows.Forms.Button
    Friend WithEvents btnReset As System.Windows.Forms.Button
    Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents lblToCCend As System.Windows.Forms.Label
    Friend WithEvents lblToCCstart As System.Windows.Forms.Label
    Friend WithEvents txtDocDateEnd As System.Windows.Forms.TextBox
    Friend WithEvents dtpDocDateEnd As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbCostCenterCodeEnd As Telerik.WinControls.UI.RadMultiColumnComboBox
    Friend WithEvents cmbCostCenterCodeStart As Telerik.WinControls.UI.RadMultiColumnComboBox
    Friend WithEvents cmbShownLevel As System.Windows.Forms.ComboBox
    Friend WithEvents lblShownLevel As System.Windows.Forms.Label
    Friend WithEvents lblDocDateEnd As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Me.grbMaster = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.cmbShownLevel = New System.Windows.Forms.ComboBox()
      Me.cmbCostCenterCodeEnd = New Telerik.WinControls.UI.RadMultiColumnComboBox()
      Me.cmbCostCenterCodeStart = New Telerik.WinControls.UI.RadMultiColumnComboBox()
      Me.txtDocDateEnd = New System.Windows.Forms.TextBox()
      Me.dtpDocDateEnd = New System.Windows.Forms.DateTimePicker()
      Me.btnRefresh = New System.Windows.Forms.Button()
      Me.lblDocDateEnd = New System.Windows.Forms.Label()
      Me.btnReset = New System.Windows.Forms.Button()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.lblShownLevel = New System.Windows.Forms.Label()
      Me.lblToCCstart = New System.Windows.Forms.Label()
      Me.lblToCCend = New System.Windows.Forms.Label()
      Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
      Me.grbMaster.SuspendLayout()
      CType(Me.cmbCostCenterCodeEnd, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.cmbCostCenterCodeStart, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'grbMaster
      '
      Me.grbMaster.Controls.Add(Me.cmbShownLevel)
      Me.grbMaster.Controls.Add(Me.cmbCostCenterCodeEnd)
      Me.grbMaster.Controls.Add(Me.cmbCostCenterCodeStart)
      Me.grbMaster.Controls.Add(Me.txtDocDateEnd)
      Me.grbMaster.Controls.Add(Me.dtpDocDateEnd)
      Me.grbMaster.Controls.Add(Me.btnRefresh)
      Me.grbMaster.Controls.Add(Me.lblDocDateEnd)
      Me.grbMaster.Controls.Add(Me.btnReset)
      Me.grbMaster.Controls.Add(Me.Label1)
      Me.grbMaster.Controls.Add(Me.lblShownLevel)
      Me.grbMaster.Controls.Add(Me.lblToCCstart)
      Me.grbMaster.Controls.Add(Me.lblToCCend)
      Me.grbMaster.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbMaster.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.grbMaster.Location = New System.Drawing.Point(8, 8)
      Me.grbMaster.Name = "grbMaster"
      Me.grbMaster.Size = New System.Drawing.Size(167, 330)
      Me.grbMaster.TabIndex = 0
      Me.grbMaster.TabStop = False
      '
      'cmbShownLevel
      '
      Me.cmbShownLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbShownLevel.FormattingEnabled = True
      Me.cmbShownLevel.Location = New System.Drawing.Point(12, 165)
      Me.cmbShownLevel.Name = "cmbShownLevel"
      Me.cmbShownLevel.Size = New System.Drawing.Size(141, 21)
      Me.cmbShownLevel.TabIndex = 4
      '
      'cmbCostCenterCodeEnd
      '
      '
      'cmbCostCenterCodeEnd.NestedRadGridView
      '
      Me.cmbCostCenterCodeEnd.EditorControl.BackColor = System.Drawing.SystemColors.Window
      Me.cmbCostCenterCodeEnd.EditorControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.cmbCostCenterCodeEnd.EditorControl.ForeColor = System.Drawing.SystemColors.ControlText
      Me.cmbCostCenterCodeEnd.EditorControl.Location = New System.Drawing.Point(0, 0)
      '
      '
      '
      Me.cmbCostCenterCodeEnd.EditorControl.MasterGridViewTemplate.AllowAddNewRow = False
      Me.cmbCostCenterCodeEnd.EditorControl.MasterGridViewTemplate.AllowCellContextMenu = False
      Me.cmbCostCenterCodeEnd.EditorControl.MasterGridViewTemplate.AllowColumnChooser = False
      Me.cmbCostCenterCodeEnd.EditorControl.MasterGridViewTemplate.EnableGrouping = False
      Me.cmbCostCenterCodeEnd.EditorControl.MasterGridViewTemplate.ShowFilteringRow = False
      Me.cmbCostCenterCodeEnd.EditorControl.Name = "NestedRadGridView"
      Me.cmbCostCenterCodeEnd.EditorControl.ReadOnly = True
      Me.cmbCostCenterCodeEnd.EditorControl.ShowGroupPanel = False
      Me.cmbCostCenterCodeEnd.EditorControl.Size = New System.Drawing.Size(240, 150)
      Me.cmbCostCenterCodeEnd.EditorControl.TabIndex = 0
      Me.cmbCostCenterCodeEnd.Location = New System.Drawing.Point(33, 110)
      Me.cmbCostCenterCodeEnd.Name = "cmbCostCenterCodeEnd"
      '
      '
      '
      Me.cmbCostCenterCodeEnd.RootElement.AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.WrapAroundChildren
      Me.cmbCostCenterCodeEnd.Size = New System.Drawing.Size(120, 21)
      Me.cmbCostCenterCodeEnd.TabIndex = 3
      Me.cmbCostCenterCodeEnd.TabStop = False
      Me.cmbCostCenterCodeEnd.Text = "RadMultiColumnComboBox2"
      '
      'cmbCostCenterCodeStart
      '
      '
      'cmbCostCenterCodeStart.NestedRadGridView
      '
      Me.cmbCostCenterCodeStart.EditorControl.BackColor = System.Drawing.SystemColors.Window
      Me.cmbCostCenterCodeStart.EditorControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.cmbCostCenterCodeStart.EditorControl.ForeColor = System.Drawing.SystemColors.ControlText
      Me.cmbCostCenterCodeStart.EditorControl.Location = New System.Drawing.Point(0, 0)
      '
      '
      '
      Me.cmbCostCenterCodeStart.EditorControl.MasterGridViewTemplate.AllowAddNewRow = False
      Me.cmbCostCenterCodeStart.EditorControl.MasterGridViewTemplate.AllowCellContextMenu = False
      Me.cmbCostCenterCodeStart.EditorControl.MasterGridViewTemplate.AllowColumnChooser = False
      Me.cmbCostCenterCodeStart.EditorControl.MasterGridViewTemplate.EnableGrouping = False
      Me.cmbCostCenterCodeStart.EditorControl.MasterGridViewTemplate.ShowFilteringRow = False
      Me.cmbCostCenterCodeStart.EditorControl.Name = "NestedRadGridView"
      Me.cmbCostCenterCodeStart.EditorControl.ReadOnly = True
      Me.cmbCostCenterCodeStart.EditorControl.ShowGroupPanel = False
      Me.cmbCostCenterCodeStart.EditorControl.Size = New System.Drawing.Size(240, 150)
      Me.cmbCostCenterCodeStart.EditorControl.TabIndex = 0
      Me.cmbCostCenterCodeStart.Location = New System.Drawing.Point(12, 86)
      Me.cmbCostCenterCodeStart.Name = "cmbCostCenterCodeStart"
      '
      '
      '
      Me.cmbCostCenterCodeStart.RootElement.AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.WrapAroundChildren
      Me.cmbCostCenterCodeStart.Size = New System.Drawing.Size(141, 21)
      Me.cmbCostCenterCodeStart.TabIndex = 2
      Me.cmbCostCenterCodeStart.TabStop = False
      Me.cmbCostCenterCodeStart.Text = "RadMultiColumnComboBox1"
      '
      'txtDocDateEnd
      '
      Me.Validator.SetDataType(Me.txtDocDateEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtDocDateEnd, "")
      Me.Validator.SetGotFocusBackColor(Me.txtDocDateEnd, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtDocDateEnd, -15)
      Me.Validator.SetInvalidBackColor(Me.txtDocDateEnd, System.Drawing.Color.Empty)
      Me.txtDocDateEnd.Location = New System.Drawing.Point(33, 33)
      Me.txtDocDateEnd.MaxLength = 10
      Me.Validator.SetMinValue(Me.txtDocDateEnd, "")
      Me.txtDocDateEnd.Name = "txtDocDateEnd"
      Me.Validator.SetRegularExpression(Me.txtDocDateEnd, "")
      Me.Validator.SetRequired(Me.txtDocDateEnd, False)
      Me.txtDocDateEnd.Size = New System.Drawing.Size(99, 21)
      Me.txtDocDateEnd.TabIndex = 1
      '
      'dtpDocDateEnd
      '
      Me.dtpDocDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpDocDateEnd.Location = New System.Drawing.Point(33, 33)
      Me.dtpDocDateEnd.Name = "dtpDocDateEnd"
      Me.dtpDocDateEnd.Size = New System.Drawing.Size(120, 21)
      Me.dtpDocDateEnd.TabIndex = 2
      Me.dtpDocDateEnd.TabStop = False
      '
      'btnRefresh
      '
      Me.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnRefresh.Location = New System.Drawing.Point(12, 204)
      Me.btnRefresh.Name = "btnRefresh"
      Me.btnRefresh.Size = New System.Drawing.Size(75, 64)
      Me.btnRefresh.TabIndex = 5
      Me.btnRefresh.Text = "Refresh"
      '
      'lblDocDateEnd
      '
      Me.lblDocDateEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDocDateEnd.ForeColor = System.Drawing.Color.Black
      Me.lblDocDateEnd.Location = New System.Drawing.Point(6, 35)
      Me.lblDocDateEnd.Name = "lblDocDateEnd"
      Me.lblDocDateEnd.Size = New System.Drawing.Size(24, 18)
      Me.lblDocDateEnd.TabIndex = 0
      Me.lblDocDateEnd.Text = "ถึง"
      Me.lblDocDateEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'btnReset
      '
      Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnReset.Location = New System.Drawing.Point(33, 274)
      Me.btnReset.Name = "btnReset"
      Me.btnReset.Size = New System.Drawing.Size(54, 23)
      Me.btnReset.TabIndex = 6
      Me.btnReset.TabStop = False
      Me.btnReset.Text = "Clear"
      '
      'Label1
      '
      Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Label1.ForeColor = System.Drawing.Color.Black
      Me.Label1.Location = New System.Drawing.Point(8, 14)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(136, 18)
      Me.Label1.TabIndex = 3
      Me.Label1.Text = "วันที่เอกสาร"
      Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'lblShownLevel
      '
      Me.lblShownLevel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblShownLevel.ForeColor = System.Drawing.Color.Black
      Me.lblShownLevel.Location = New System.Drawing.Point(12, 146)
      Me.lblShownLevel.Name = "lblShownLevel"
      Me.lblShownLevel.Size = New System.Drawing.Size(127, 18)
      Me.lblShownLevel.TabIndex = 3
      Me.lblShownLevel.Text = "แสดงผลรวม"
      Me.lblShownLevel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'lblToCCstart
      '
      Me.lblToCCstart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblToCCstart.ForeColor = System.Drawing.Color.Black
      Me.lblToCCstart.Location = New System.Drawing.Point(10, 68)
      Me.lblToCCstart.Name = "lblToCCstart"
      Me.lblToCCstart.Size = New System.Drawing.Size(136, 18)
      Me.lblToCCstart.TabIndex = 3
      Me.lblToCCstart.Text = "ตั้งแต่ Cost Center"
      Me.lblToCCstart.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'lblToCCend
      '
      Me.lblToCCend.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblToCCend.ForeColor = System.Drawing.Color.Black
      Me.lblToCCend.Location = New System.Drawing.Point(8, 112)
      Me.lblToCCend.Name = "lblToCCend"
      Me.lblToCCend.Size = New System.Drawing.Size(24, 18)
      Me.lblToCCend.TabIndex = 6
      Me.lblToCCend.Text = "ถึง"
      Me.lblToCCend.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
      'CRptMatCountExpandedLciItemFilterSubPanel
      '
      Me.Controls.Add(Me.grbMaster)
      Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Name = "CRptMatCountExpandedLciItemFilterSubPanel"
      Me.Size = New System.Drawing.Size(183, 347)
      Me.grbMaster.ResumeLayout(False)
      Me.grbMaster.PerformLayout()
      CType(Me.cmbCostCenterCodeEnd, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.cmbCostCenterCodeStart, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

    End Sub

#End Region

#Region " SetLabelText "
    Public Sub SetLabelText()

      'Me.lblToCCstart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptMatCountFilterSubPanel.lblToCCstart}")
      'Me.Validator.SetDisplayName(txtToCCstart, lblToCCstart.Text)

      '' Global {ถึง}
      'Me.lblDocDateEnd.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")
      'Me.Validator.SetDisplayName(txtDocDateEnd, lblDocDateEnd.Text)

      'Me.lblToCCend.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")
      'Me.Validator.SetDisplayName(txtToCCend, lblToCCend.Text)

      '' Button
      'Me.btnSearch.Text = Me.StringParserService.Parse("${res:Global.SearchButtonText}")
      'Me.btnReset.Text = Me.StringParserService.Parse("${res:Global.ResetButtonText}")

      '' GroupBox
      'Me.grbMaster.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptMatCountFilterSubPanel.grbMaster}")
      'Me.grbDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptMatCountFilterSubPanel.grbDetail}")

      'Me.chkNegativeOnly.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptMatCountFilterSubPanel.chkNegativeOnly}")
      'Me.chkNoZero.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptMatCountFilterSubPanel.chkNoZero}")
    End Sub
#End Region

#Region "Member"
    Private m_DocDateEnd As Date
    Private m_DocDateStart As Date
#End Region

#Region "Constructors"
    Public Sub New()
      MyBase.New()
      InitializeComponent()
      EventWiring()
      Initialize()

      SetLabelText()
      LoopControl(Me)
    End Sub
#End Region

#Region "Properties"

    Public Property DocDateEnd() As Date      Get        Return m_DocDateEnd      End Get      Set(ByVal Value As Date)        m_DocDateEnd = Value      End Set    End Property    Public Property DocDateStart() As Date      Get        Return m_DocDateStart      End Get      Set(ByVal Value As Date)        m_DocDateStart = Value      End Set    End Property
#End Region

#Region "Methods"
    Private Sub RegisterDropdown()
      ' เรียงตาม 
      'RptMatReturnFilterOrderBy.ListCodeDescriptionInComboBox(Me.cmbOrderBy, "rpt_matreturn")
      For i As Integer = 1 To 5
        Dim item As New IdValuePair(i, "ตาม Level " & i.ToString)
        cmbShownLevel.Items.Add(item)
      Next
    End Sub
    Private Sub Initialize()
      RegisterDropdown()
      InitialMultiCombo()
      ClearCriterias()
    End Sub

    Private Sub ClearCriterias()
      For Each grbCtrl As Control In grbMaster.Controls
        If TypeOf grbCtrl Is Longkong.Pojjaman.Gui.Components.FixedGroupBox Then
          For Each Ctrl As Control In grbCtrl.Controls
            If TypeOf grbCtrl Is RadMultiColumnComboBox Then
              SetAllRadMultiComboBoxFilter(grbCtrl)
            ElseIf TypeOf grbCtrl Is RadDateTimePicker Then
              CType(grbCtrl, RadDateTimePicker).SetToNullValue()
            ElseIf TypeOf grbCtrl Is TextBox Then
              grbCtrl.Text = ""
            End If
          Next
        End If
      Next

      Me.DocDateEnd = Date.Now
      Me.txtDocDateEnd.Text = MinDateToNull(Me.DocDateEnd, "")
      Me.dtpDocDateEnd.Value = Me.DocDateEnd

      If Me.cmbShownLevel.Items.Count >= 5 Then
        Me.cmbShownLevel.SelectedIndex = 4
      End If

    End Sub
    Private Sub SetAllRadMultiComboBoxFilter(ByVal ctrl As Object)
      Dim rmcb As RadMultiColumnComboBox = CType(ctrl, RadMultiColumnComboBox)
      rmcb.AutoFilter = True
      rmcb.DisplayMember = rmcb.MultiColumnComboBoxElement.Columns(0).FieldName  '"acct_code"
      Dim filter As New FilterExpression(rmcb.DisplayMember,
                                         FilterExpression.BinaryOperation.AND, GridKnownFunction.StartsWith, GridFilterCellElement.ParameterName)
      filter.Parameters.Add(GridFilterCellElement.ParameterName, String.Empty)

      Dim fiContain As Boolean = False
      For Each fi As FilterExpression In rmcb.EditorControl.MasterGridViewTemplate.FilterExpressions
        If fi.FieldName.Equals(filter.FieldName) Then
          fiContain = True
        End If
      Next
      If Not fiContain Then
        rmcb.EditorControl.MasterGridViewTemplate.FilterExpressions.Add(filter)
      End If

      rmcb.MultiColumnComboBoxElement.AutoCompleteMode = AutoCompleteMode.SuggestAppend
      'Me.cmbAccountCodeStart.DropDownStyle = RadDropDownStyle.DropDown
      'Me.SetAutoCompleteAble(cmbAccountCodeStart, False)
    End Sub
    Public Overrides Function GetFilterString() As String

    End Function
    Public Overrides Function GetFilterArray() As Longkong.Pojjaman.BusinessLogic.Filter()
      Dim arr(5) As Longkong.Pojjaman.BusinessLogic.Filter
      arr(0) = New Longkong.Pojjaman.BusinessLogic.Filter("@DocDateStart", DBNull.Value) 'From the beginning
      arr(1) = New Longkong.Pojjaman.BusinessLogic.Filter("@DocDateEnd", IIf(Me.DocDateEnd.Equals(Date.MinValue), DBNull.Value, Me.DocDateEnd))
      arr(2) = New Longkong.Pojjaman.BusinessLogic.Filter("@ToCCCodeStart", ValidCodeOrDBNullText(Me.cmbCostCenterCodeStart))
      arr(3) = New Longkong.Pojjaman.BusinessLogic.Filter("@ToCCCodeEnd", ValidCodeOrDBNullText(Me.cmbCostCenterCodeEnd))
      arr(4) = New Longkong.Pojjaman.BusinessLogic.Filter("@userRight", CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
      arr(5) = New Longkong.Pojjaman.BusinessLogic.Filter("@LevelToShow", CType(Me.cmbShownLevel.SelectedItem, IdValuePair).Id)
      ''arr(8) = New Filter("negativeonly", Me.chkNegativeOnly.Checked)
      Return arr
    End Function
    Private Function ValidCodeOrDBNullText(ByVal newCtl As Control) As Object
      If TypeOf newCtl Is RadDateTimePicker Then
        Dim rdtp As RadDateTimePicker = CType(newCtl, RadDateTimePicker)
        If rdtp.Value.Equals(Date.MinValue) Then
          Return DBNull.Value
        End If
        Return rdtp.Value
      Else
        If newCtl.Text.Length > 0 Then
          Return newCtl.Text
        End If
      End If
      Return DBNull.Value
    End Function
    Public Overrides ReadOnly Property SearchButton() As System.Windows.Forms.Button
      Get
        Return Me.btnRefresh
      End Get
    End Property

    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
      ClearCriterias()
      Me.btnRefresh.PerformClick()
    End Sub

    Private Sub InitialMultiCombo()
      Me.cmbCostCenterCodeStart.MultiColumnComboBoxElement.DropDownHeight = 500
      Me.cmbCostCenterCodeStart.MultiColumnComboBoxElement.DropDownWidth = 350
      Me.cmbCostCenterCodeEnd.MultiColumnComboBoxElement.DropDownHeight = 500
      Me.cmbCostCenterCodeEnd.MultiColumnComboBoxElement.DropDownWidth = 350

      'Add CostCenter Columns ==========================
      Dim element As Telerik.WinControls.UI.RadMultiColumnComboBoxElement = Me.cmbCostCenterCodeStart.MultiColumnComboBoxElement
      element.EditorControl.MasterGridViewTemplate.AutoGenerateColumns = False
      Dim col As New Telerik.WinControls.UI.GridViewTextBoxColumn("cc_code")
      col.HeaderText = "รหัส"
      col.Width = 100
      col.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft
      element.Columns.Add(col)
      col = New Telerik.WinControls.UI.GridViewTextBoxColumn("cc_name")
      col.HeaderText = "ชื่อ"
      col.Width = 200
      col.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft
      element.Columns.Add(col)
      For Each Column As Telerik.WinControls.UI.GridViewDataColumn In Me.cmbCostCenterCodeStart.MultiColumnComboBoxElement.Columns
        cmbCostCenterCodeEnd.MultiColumnComboBoxElement.Columns.Add(Column)
      Next
      'Refresh CostCenter List
      Dim costCenterDataSourceStart As DataTable = CostCenter.GetCostCenterSet
      Dim costCenterDataSourceEnd As DataTable = Me.CloneData(costCenterDataSourceStart)
      Me.cmbCostCenterCodeStart.DataSource = costCenterDataSourceStart
      Me.cmbCostCenterCodeEnd.DataSource = costCenterDataSourceEnd

    End Sub
    Private Function CloneData(ByVal dataSource As DataTable) As DataTable
      Dim newDt As New DataTable

      For Each col As DataColumn In dataSource.Columns
        newDt.Columns.Add(col.ColumnName)
      Next
      For Each row As DataRow In dataSource.Rows
        Dim dr As DataRow = newDt.NewRow
        For Each col As DataColumn In dataSource.Columns
          dr(col.ColumnName) = row(col.ColumnName)
        Next
        newDt.Rows.Add(dr)
      Next

      Return newDt
    End Function
#End Region

#Region "IReportFilterSubPanel"
    Public Function GetFixValueCollection() As BusinessLogic.DocPrintingItemCollection Implements IReportFilterSubPanel.GetFixValueCollection
      Dim dpiColl As New DocPrintingItemCollection
      Dim dpi As DocPrintingItem

      'DocDateEnd
      dpi = New DocPrintingItem
      dpi.Mapping = "DocDateEnd"
      dpi.Value = txtDocDateEnd.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      Return dpiColl
    End Function
#End Region

#Region " ChangeProperty "
    Private Sub EventWiring()

      'AddHandler btnToCCstart.Click, AddressOf Me.btnCostcenterFind_Click
      'AddHandler btnToCCend.Click, AddressOf Me.btnCostcenterFind_Click

      'AddHandler btnLcistart.Click, AddressOf Me.btnLCIFind_Click
      'AddHandler btnLciend.Click, AddressOf Me.btnLCIFind_Click

      'AddHandler txtToCCstart.Validated, AddressOf Me.ChangeProperty
      'AddHandler txtToCCend.Validated, AddressOf Me.ChangeProperty

      AddHandler txtDocDateEnd.Validated, AddressOf Me.ChangeProperty
      AddHandler dtpDocDateEnd.ValueChanged, AddressOf Me.ChangeProperty
    End Sub

    Private m_dateSetting As Boolean
    Private Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)

      Select Case CType(sender, Control).Name.ToLower
        'Case "txttoccstart"
        '  CostCenter.GetCostCenter(txtToCCstart, tempTxt, tempCC1, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
        'Case "txttoccend"
        '  CostCenter.GetCostCenter(txtToCCend, tempTxt, tempCC2, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)

        Case "dtpdocdateend"
          If Not Me.DocDateEnd.Equals(dtpDocDateEnd.Value) Then
            If Not m_dateSetting Then
              Me.txtDocDateEnd.Text = MinDateToNull(dtpDocDateEnd.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
              Me.DocDateEnd = dtpDocDateEnd.Value
            End If
          End If
        Case "txtdocdateend"
          m_dateSetting = True
          If Not Me.txtDocDateEnd.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtDocDateEnd) = "" Then
            Dim theDate As Date = CDate(Me.txtDocDateEnd.Text)
            If Not Me.DocDateEnd.Equals(theDate) Then
              dtpDocDateEnd.Value = theDate
              Me.DocDateEnd = dtpDocDateEnd.Value
            End If
          Else
            Me.dtpDocDateEnd.Value = Date.Now
            Me.DocDateEnd = Date.MinValue
          End If
          m_dateSetting = False

        Case Else

      End Select
    End Sub
#End Region

#Region "IClipboardHandler Overrides"
    Public Overrides ReadOnly Property EnablePaste() As Boolean
      Get
        Dim data As IDataObject = Clipboard.GetDataObject
        If data.GetDataPresent((New CostCenter).FullClassName) Then
          If Not Me.ActiveControl Is Nothing Then
            Select Case Me.ActiveControl.Name.ToLower

              Case "txttoccstart", "txttoccend"
                Return True
            End Select
          End If
        End If
      End Get
    End Property
    'Public Overrides Sub Paste(ByVal sender As Object, ByVal e As System.EventArgs)
    '  Dim data As IDataObject = Clipboard.GetDataObject
    '  If data.GetDataPresent((New CostCenter).FullClassName) Then
    '    Dim id As Integer = CInt(data.GetData((New CostCenter).FullClassName))
    '    Dim entity As New CostCenter(id)
    '    If Not Me.ActiveControl Is Nothing Then
    '      Select Case Me.ActiveControl.Name.ToLower

    '        Case "txttoccstart"
    '          Me.SetToCCStartDialog(entity)

    '        Case "txttoccend"
    '          Me.SetToCCEndDialog(entity)

    '      End Select
    '    End If
    '  End If
    'End Sub
#End Region

#Region " Event Handlers "
    'Private Sub btnCostcenterFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '  Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
    '  Select Case CType(sender, Control).Name.ToLower

    '    Case "btntoccstart"
    '      myEntityPanelService.OpenTreeDialog(New CostCenter, AddressOf SetToCCStartDialog)

    '    Case "btntoccend"
    '      myEntityPanelService.OpenTreeDialog(New CostCenter, AddressOf SetToCCEndDialog)

    '  End Select
    'End Sub
    'Private tempTxt As New TextBox
    'Private tempCC1 As New CostCenter
    'Private tempCC2 As New CostCenter
    'Private Sub SetToCCStartDialog(ByVal e As ISimpleEntity)
    '  Me.txtToCCstart.Text = e.Code
    '  CostCenter.GetCostCenter(txtToCCstart, tempTxt, tempCC1, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
    'End Sub
    'Private Sub SetToCCEndDialog(ByVal e As ISimpleEntity)
    '  Me.txtToCCend.Text = e.Code
    '  CostCenter.GetCostCenter(txtToCCend, tempTxt, tempCC2, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
    'End Sub

    ' LCI item ..
    'Private Sub btnLCIFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '  Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
    '  Select Case CType(sender, Control).Name.ToLower
    '    Case "btnlcistart"
    '      myEntityPanelService.OpenListDialog(New LCIItem, AddressOf SetLCIStartDialog)
    '    Case "btnlciend"
    '      myEntityPanelService.OpenListDialog(New LCIItem, AddressOf SetLCIEndDialog)
    '  End Select

    'End Sub

    'Private Sub SetLCIStartDialog(ByVal e As ISimpleEntity)
    '  Me.txtLcistart.Text = e.Code
    'End Sub
    'Private Sub SetLCIEndDialog(ByVal e As ISimpleEntity)
    '  Me.txtLciend.Text = e.Code
    'End Sub
#End Region


  End Class

  '    ' เรียงตาม 
  '    Public Class RptMatReturnFilterOrderBy
  '        Inherits CodeDescription

  '#Region "Construtors"
  '        Public Sub New(ByVal value As Integer)
  '            MyBase.New(value)
  '        End Sub
  '#End Region

  '#Region "Properties"
  '        Public Overrides ReadOnly Property CodeName() As String
  '            Get
  '                Return "rpt_matreturn"
  '            End Get
  '        End Property
  '#End Region

  '    End Class
End Namespace

