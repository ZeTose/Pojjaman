Imports Longkong.Pojjaman.BusinessLogic
Imports longkong.Pojjaman.Services
Imports Longkong.Core.Services

Namespace Longkong.Pojjaman.Gui.Panels
    Public Class RptWBSBudgetByCCFilterSubPanel
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
        Friend WithEvents btnSearch As System.Windows.Forms.Button
        Friend WithEvents btnReset As System.Windows.Forms.Button
        Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
        Friend WithEvents grbDetail As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents txtDocDateEnd As System.Windows.Forms.TextBox
        Friend WithEvents dtpDocDateEnd As System.Windows.Forms.DateTimePicker
        Friend WithEvents lblDocDateEnd As System.Windows.Forms.Label
        Friend WithEvents cmbReportType As System.Windows.Forms.ComboBox
        Friend WithEvents lblReportType As System.Windows.Forms.Label
        Friend WithEvents btnShowStartCostCenter As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents txtStartCostCenterCode As System.Windows.Forms.TextBox
        Friend WithEvents lblStartCostCenter As System.Windows.Forms.Label
        Friend WithEvents txtStartCostCenterName As System.Windows.Forms.TextBox
        Friend WithEvents btnShowEndCostCenter As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents txtEndCostCenterCode As System.Windows.Forms.TextBox
        Friend WithEvents lblEndCostCenter As System.Windows.Forms.Label
        Friend WithEvents txtEndCostCenterName As System.Windows.Forms.TextBox
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(RptWBSBudgetByCCFilterSubPanel))
            Me.grbMaster = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.btnShowEndCostCenter = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.txtEndCostCenterCode = New System.Windows.Forms.TextBox
            Me.lblEndCostCenter = New System.Windows.Forms.Label
            Me.txtEndCostCenterName = New System.Windows.Forms.TextBox
            Me.lblReportType = New System.Windows.Forms.Label
            Me.cmbReportType = New System.Windows.Forms.ComboBox
            Me.txtDocDateEnd = New System.Windows.Forms.TextBox
            Me.dtpDocDateEnd = New System.Windows.Forms.DateTimePicker
            Me.lblDocDateEnd = New System.Windows.Forms.Label
            Me.btnShowStartCostCenter = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.txtStartCostCenterCode = New System.Windows.Forms.TextBox
            Me.lblStartCostCenter = New System.Windows.Forms.Label
            Me.txtStartCostCenterName = New System.Windows.Forms.TextBox
            Me.btnSearch = New System.Windows.Forms.Button
            Me.btnReset = New System.Windows.Forms.Button
            Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider
            Me.grbMaster.SuspendLayout()
            Me.grbDetail.SuspendLayout()
            Me.SuspendLayout()
            '
            'grbMaster
            '
            Me.grbMaster.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.grbMaster.Controls.Add(Me.grbDetail)
            Me.grbMaster.Controls.Add(Me.btnSearch)
            Me.grbMaster.Controls.Add(Me.btnReset)
            Me.grbMaster.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbMaster.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.grbMaster.Location = New System.Drawing.Point(8, 8)
            Me.grbMaster.Name = "grbMaster"
            Me.grbMaster.Size = New System.Drawing.Size(480, 192)
            Me.grbMaster.TabIndex = 0
            Me.grbMaster.TabStop = False
            Me.grbMaster.Text = "ค้นหา"
            '
            'grbDetail
            '
            Me.grbDetail.Controls.Add(Me.btnShowEndCostCenter)
            Me.grbDetail.Controls.Add(Me.txtEndCostCenterCode)
            Me.grbDetail.Controls.Add(Me.lblEndCostCenter)
            Me.grbDetail.Controls.Add(Me.txtEndCostCenterName)
            Me.grbDetail.Controls.Add(Me.lblReportType)
            Me.grbDetail.Controls.Add(Me.cmbReportType)
            Me.grbDetail.Controls.Add(Me.txtDocDateEnd)
            Me.grbDetail.Controls.Add(Me.dtpDocDateEnd)
            Me.grbDetail.Controls.Add(Me.lblDocDateEnd)
            Me.grbDetail.Controls.Add(Me.btnShowStartCostCenter)
            Me.grbDetail.Controls.Add(Me.txtStartCostCenterCode)
            Me.grbDetail.Controls.Add(Me.lblStartCostCenter)
            Me.grbDetail.Controls.Add(Me.txtStartCostCenterName)
            Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbDetail.Location = New System.Drawing.Point(16, 16)
            Me.grbDetail.Name = "grbDetail"
            Me.grbDetail.Size = New System.Drawing.Size(448, 136)
            Me.grbDetail.TabIndex = 0
            Me.grbDetail.TabStop = False
            Me.grbDetail.Text = "ข้อมูลทั่วไป"
            '
            'btnShowEndCostCenter
            '
            Me.btnShowEndCostCenter.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnShowEndCostCenter.ForeColor = System.Drawing.SystemColors.Control
            Me.btnShowEndCostCenter.Image = CType(resources.GetObject("btnShowEndCostCenter.Image"), System.Drawing.Image)
            Me.btnShowEndCostCenter.Location = New System.Drawing.Point(392, 96)
            Me.btnShowEndCostCenter.Name = "btnShowEndCostCenter"
            Me.btnShowEndCostCenter.Size = New System.Drawing.Size(24, 22)
            Me.btnShowEndCostCenter.TabIndex = 14
            Me.btnShowEndCostCenter.TabStop = False
            Me.btnShowEndCostCenter.ThemedImage = CType(resources.GetObject("btnShowEndCostCenter.ThemedImage"), System.Drawing.Bitmap)
            '
            'txtEndCostCenterCode
            '
            Me.Validator.SetDataType(Me.txtEndCostCenterCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtEndCostCenterCode, "")
            Me.txtEndCostCenterCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtEndCostCenterCode, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtEndCostCenterCode, -15)
            Me.Validator.SetInvalidBackColor(Me.txtEndCostCenterCode, System.Drawing.Color.Empty)
            Me.txtEndCostCenterCode.Location = New System.Drawing.Point(136, 96)
            Me.Validator.SetMaxValue(Me.txtEndCostCenterCode, "")
            Me.Validator.SetMinValue(Me.txtEndCostCenterCode, "")
            Me.txtEndCostCenterCode.Name = "txtEndCostCenterCode"
            Me.Validator.SetRegularExpression(Me.txtEndCostCenterCode, "")
            Me.Validator.SetRequired(Me.txtEndCostCenterCode, False)
            Me.txtEndCostCenterCode.Size = New System.Drawing.Size(72, 21)
            Me.txtEndCostCenterCode.TabIndex = 12
            Me.txtEndCostCenterCode.Text = ""
            '
            'lblEndCostCenter
            '
            Me.lblEndCostCenter.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblEndCostCenter.ForeColor = System.Drawing.Color.Black
            Me.lblEndCostCenter.Location = New System.Drawing.Point(8, 98)
            Me.lblEndCostCenter.Name = "lblEndCostCenter"
            Me.lblEndCostCenter.Size = New System.Drawing.Size(128, 18)
            Me.lblEndCostCenter.TabIndex = 11
            Me.lblEndCostCenter.Text = "ถึง Cost Center:"
            Me.lblEndCostCenter.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtEndCostCenterName
            '
            Me.Validator.SetDataType(Me.txtEndCostCenterName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtEndCostCenterName, "")
            Me.txtEndCostCenterName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtEndCostCenterName, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtEndCostCenterName, -15)
            Me.Validator.SetInvalidBackColor(Me.txtEndCostCenterName, System.Drawing.Color.Empty)
            Me.txtEndCostCenterName.Location = New System.Drawing.Point(208, 96)
            Me.Validator.SetMaxValue(Me.txtEndCostCenterName, "")
            Me.Validator.SetMinValue(Me.txtEndCostCenterName, "")
            Me.txtEndCostCenterName.Name = "txtEndCostCenterName"
            Me.txtEndCostCenterName.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtEndCostCenterName, "")
            Me.Validator.SetRequired(Me.txtEndCostCenterName, False)
            Me.txtEndCostCenterName.Size = New System.Drawing.Size(184, 21)
            Me.txtEndCostCenterName.TabIndex = 13
            Me.txtEndCostCenterName.Text = ""
            '
            'lblReportType
            '
            Me.lblReportType.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblReportType.ForeColor = System.Drawing.Color.Black
            Me.lblReportType.Location = New System.Drawing.Point(8, 24)
            Me.lblReportType.Name = "lblReportType"
            Me.lblReportType.Size = New System.Drawing.Size(128, 18)
            Me.lblReportType.TabIndex = 10
            Me.lblReportType.Text = "ประเภทรายงาน"
            Me.lblReportType.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cmbReportType
            '
            Me.cmbReportType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbReportType.Location = New System.Drawing.Point(136, 24)
            Me.cmbReportType.Name = "cmbReportType"
            Me.cmbReportType.Size = New System.Drawing.Size(120, 21)
            Me.cmbReportType.TabIndex = 2
            '
            'txtDocDateEnd
            '
            Me.Validator.SetDataType(Me.txtDocDateEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
            Me.Validator.SetDisplayName(Me.txtDocDateEnd, "")
            Me.Validator.SetGotFocusBackColor(Me.txtDocDateEnd, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtDocDateEnd, -15)
            Me.Validator.SetInvalidBackColor(Me.txtDocDateEnd, System.Drawing.Color.Empty)
            Me.txtDocDateEnd.Location = New System.Drawing.Point(136, 48)
            Me.txtDocDateEnd.MaxLength = 10
            Me.Validator.SetMaxValue(Me.txtDocDateEnd, "")
            Me.Validator.SetMinValue(Me.txtDocDateEnd, "")
            Me.txtDocDateEnd.Name = "txtDocDateEnd"
            Me.Validator.SetRegularExpression(Me.txtDocDateEnd, "")
            Me.Validator.SetRequired(Me.txtDocDateEnd, False)
            Me.txtDocDateEnd.Size = New System.Drawing.Size(99, 21)
            Me.txtDocDateEnd.TabIndex = 4
            Me.txtDocDateEnd.Text = ""
            '
            'dtpDocDateEnd
            '
            Me.dtpDocDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short
            Me.dtpDocDateEnd.Location = New System.Drawing.Point(136, 48)
            Me.dtpDocDateEnd.Name = "dtpDocDateEnd"
            Me.dtpDocDateEnd.Size = New System.Drawing.Size(120, 21)
            Me.dtpDocDateEnd.TabIndex = 5
            Me.dtpDocDateEnd.TabStop = False
            '
            'lblDocDateEnd
            '
            Me.lblDocDateEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblDocDateEnd.ForeColor = System.Drawing.Color.Black
            Me.lblDocDateEnd.Location = New System.Drawing.Point(8, 48)
            Me.lblDocDateEnd.Name = "lblDocDateEnd"
            Me.lblDocDateEnd.Size = New System.Drawing.Size(128, 18)
            Me.lblDocDateEnd.TabIndex = 3
            Me.lblDocDateEnd.Text = "เรียกข้อมูลถึงวันที่:"
            Me.lblDocDateEnd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnShowStartCostCenter
            '
            Me.btnShowStartCostCenter.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnShowStartCostCenter.ForeColor = System.Drawing.SystemColors.Control
            Me.btnShowStartCostCenter.Image = CType(resources.GetObject("btnShowStartCostCenter.Image"), System.Drawing.Image)
            Me.btnShowStartCostCenter.Location = New System.Drawing.Point(392, 72)
            Me.btnShowStartCostCenter.Name = "btnShowStartCostCenter"
            Me.btnShowStartCostCenter.Size = New System.Drawing.Size(24, 22)
            Me.btnShowStartCostCenter.TabIndex = 9
            Me.btnShowStartCostCenter.TabStop = False
            Me.btnShowStartCostCenter.ThemedImage = CType(resources.GetObject("btnShowStartCostCenter.ThemedImage"), System.Drawing.Bitmap)
            '
            'txtStartCostCenterCode
            '
            Me.Validator.SetDataType(Me.txtStartCostCenterCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtStartCostCenterCode, "")
            Me.txtStartCostCenterCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtStartCostCenterCode, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtStartCostCenterCode, -15)
            Me.Validator.SetInvalidBackColor(Me.txtStartCostCenterCode, System.Drawing.Color.Empty)
            Me.txtStartCostCenterCode.Location = New System.Drawing.Point(136, 72)
            Me.Validator.SetMaxValue(Me.txtStartCostCenterCode, "")
            Me.Validator.SetMinValue(Me.txtStartCostCenterCode, "")
            Me.txtStartCostCenterCode.Name = "txtStartCostCenterCode"
            Me.Validator.SetRegularExpression(Me.txtStartCostCenterCode, "")
            Me.Validator.SetRequired(Me.txtStartCostCenterCode, False)
            Me.txtStartCostCenterCode.Size = New System.Drawing.Size(72, 21)
            Me.txtStartCostCenterCode.TabIndex = 7
            Me.txtStartCostCenterCode.Text = ""
            '
            'lblStartCostCenter
            '
            Me.lblStartCostCenter.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblStartCostCenter.ForeColor = System.Drawing.Color.Black
            Me.lblStartCostCenter.Location = New System.Drawing.Point(8, 72)
            Me.lblStartCostCenter.Name = "lblStartCostCenter"
            Me.lblStartCostCenter.Size = New System.Drawing.Size(128, 18)
            Me.lblStartCostCenter.TabIndex = 6
            Me.lblStartCostCenter.Text = "ตั้งแต่ Cost Center:"
            Me.lblStartCostCenter.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtStartCostCenterName
            '
            Me.Validator.SetDataType(Me.txtStartCostCenterName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtStartCostCenterName, "")
            Me.txtStartCostCenterName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtStartCostCenterName, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtStartCostCenterName, -15)
            Me.Validator.SetInvalidBackColor(Me.txtStartCostCenterName, System.Drawing.Color.Empty)
            Me.txtStartCostCenterName.Location = New System.Drawing.Point(208, 72)
            Me.Validator.SetMaxValue(Me.txtStartCostCenterName, "")
            Me.Validator.SetMinValue(Me.txtStartCostCenterName, "")
            Me.txtStartCostCenterName.Name = "txtStartCostCenterName"
            Me.txtStartCostCenterName.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtStartCostCenterName, "")
            Me.Validator.SetRequired(Me.txtStartCostCenterName, False)
            Me.txtStartCostCenterName.Size = New System.Drawing.Size(184, 21)
            Me.txtStartCostCenterName.TabIndex = 8
            Me.txtStartCostCenterName.Text = ""
            '
            'btnSearch
            '
            Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnSearch.Location = New System.Drawing.Point(388, 160)
            Me.btnSearch.Name = "btnSearch"
            Me.btnSearch.TabIndex = 2
            Me.btnSearch.Text = "ค้นหา"
            '
            'btnReset
            '
            Me.btnReset.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnReset.Location = New System.Drawing.Point(308, 160)
            Me.btnReset.Name = "btnReset"
            Me.btnReset.TabIndex = 1
            Me.btnReset.TabStop = False
            Me.btnReset.Text = "เคลียร์"
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
            'ErrorProvider1
            '
            Me.ErrorProvider1.ContainerControl = Me
            '
            'RptWBSBudgetByCCFilterSubPanel
            '
            Me.Controls.Add(Me.grbMaster)
            Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Name = "RptWBSBudgetByCCFilterSubPanel"
            Me.Size = New System.Drawing.Size(512, 200)
            Me.grbMaster.ResumeLayout(False)
            Me.grbDetail.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

#Region " SetLabelText "
        Public Sub SetLabelText()

            Me.lblStartCostCenter.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptWBSBudgetByCCFilterSubPanel.lblStartCostCenter}")
            Me.Validator.SetDisplayName(txtStartCostCenterCode, lblStartCostCenter.Text)

            Me.lblEndCostCenter.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptWBSBudgetByCCFilterSubPanel.lblEndCostCenter}")
            Me.Validator.SetDisplayName(txtEndCostCenterCode, lblEndCostCenter.Text)

            ' Global {ถึง}
            Me.lblDocDateEnd.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")
            Me.Validator.SetDisplayName(txtDocDateEnd, lblDocDateEnd.Text)

            ' Button
            Me.btnSearch.Text = Me.StringParserService.Parse("${res:Global.SearchButtonText}")
            Me.btnReset.Text = Me.StringParserService.Parse("${res:Global.ResetButtonText}")

            ' GroupBox
            Me.grbMaster.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptWBSBudgetByCCFilterSubPanel.grbMaster}")
            Me.grbDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptWBSBudgetByCCFilterSubPanel.grbDetail}")
            Me.lblReportType.Text = Me.StringParserService.Parse("${res:Global.ReportType}")

        End Sub
#End Region

#Region "Member"
        Private m_DocDateEnd As Date
        Private m_startcc As CostCenter
        Private m_endcc As CostCenter
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

        Public Property DocDateEnd() As Date            Get                Return m_DocDateEnd            End Get            Set(ByVal Value As Date)                m_DocDateEnd = Value            End Set        End Property#End Region

#Region "Methods"
        Private Sub LoadCombo()
            'CodeDescription.ListCodeDescriptionInComboBox(Me.cmbType, "CostControlReportType")
            With cmbReportType
                .Items.Clear()
                .Items.Add("ใบขอซื้อ")
                .Items.Add("ใบสั่งซื้อ")
                .Items.Add("ใบรับของ")
                .Items.Add("เบิกของ")
                .SelectedIndex = 2
            End With

        End Sub
        Private Sub Initialize()
            LoadCombo()
            ClearCriterias()
        End Sub

        Private Sub ClearCriterias()
            For Each grbCtrl As Control In grbMaster.Controls
                If TypeOf grbCtrl Is Longkong.Pojjaman.Gui.Components.FixedGroupBox Then
                    For Each Ctrl As Control In grbCtrl.Controls
                        If TypeOf Ctrl Is TextBox Then
                            Ctrl.Text = ""
                        End If
                    Next
                End If
            Next

            Me.DocDateEnd = Date.Now
            Me.txtDocDateEnd.Text = MinDateToNull(Me.DocDateEnd, "")
            Me.dtpDocDateEnd.Value = Me.DocDateEnd
            m_startcc = New CostCenter
            m_endcc = New CostCenter
            If Me.cmbReportType.Items.Count > 0 Then
                Me.cmbReportType.SelectedIndex = 0
            End If
        End Sub
    Public Overrides Function GetFilterArray() As Filter()
      Dim arr(4) As Filter
      arr(0) = New Filter("DocDateEnd", IIf(Me.DocDateEnd.Equals(Date.MinValue), DBNull.Value, Me.DocDateEnd))
      arr(1) = New Filter("CCStart", IIf(txtStartCostCenterCode.TextLength > 0, txtStartCostCenterCode.Text, DBNull.Value))
      arr(2) = New Filter("CCEnd", IIf(txtEndCostCenterCode.TextLength > 0, txtEndCostCenterCode.Text, DBNull.Value))
      Dim type As BOQ.WBSReportType = BOQ.WBSReportType.GoodsReceipt
      Select Case cmbReportType.SelectedIndex
        Case 0
          type = BOQ.WBSReportType.PR
        Case 1
          type = BOQ.WBSReportType.PO
        Case 2
          type = BOQ.WBSReportType.GoodsReceipt
        Case 3
          type = BOQ.WBSReportType.MatWithdraw
      End Select
      arr(3) = New Filter("WBSReportType", type)
      arr(4) = New Filter("userRight", CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
      Return arr
    End Function
        Public Overrides ReadOnly Property SearchButton() As System.Windows.Forms.Button
            Get
                Return Me.btnSearch
            End Get
        End Property

        Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
            ClearCriterias()
            Me.btnSearch.PerformClick()
        End Sub
#End Region

#Region "IReportFilterSubPanel"
        Public Function GetFixValueCollection() As BusinessLogic.DocPrintingItemCollection Implements IReportFilterSubPanel.GetFixValueCollection

        End Function
#End Region

#Region " ChangeProperty "
        Private Sub EventWiring()
            AddHandler txtDocDateEnd.Validated, AddressOf Me.ChangeProperty
            AddHandler dtpDocDateEnd.ValueChanged, AddressOf Me.ChangeProperty
        End Sub

        Private m_dateSetting As Boolean
        Private Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)

            Select Case CType(sender, Control).Name.ToLower
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
                If data.GetDataPresent(m_startcc.FullClassName) Then
                    If Not Me.ActiveControl Is Nothing Then
                        Select Case Me.ActiveControl.Name.ToLower

                            Case "txttoccstart", "txttoccend"
                                Return True
                        End Select
                    End If
                End If
                If data.GetDataPresent(m_endcc.FullClassName) Then
                    If Not Me.ActiveControl Is Nothing Then
                        Select Case Me.ActiveControl.Name.ToLower

                            Case "txttoccstart", "txttoccend"
                                Return True
                        End Select
                    End If
                End If
            End Get
        End Property
        Public Overrides Sub Paste(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim data As IDataObject = Clipboard.GetDataObject
            If data.GetDataPresent(m_startcc.FullClassName) Then
                Dim id As Integer = CInt(data.GetData(m_startcc.FullClassName))
                Dim entity As New CostCenter(id)
                If Not Me.ActiveControl Is Nothing Then
                    Select Case Me.ActiveControl.Name.ToLower

                        Case "txttoccstart"
                            Me.SetStartCostCenter(entity)


                    End Select
                End If
            End If
        End Sub
#End Region

#Region " Event Handlers "
        Private Sub txtToStartCostCenterCode_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtStartCostCenterCode.Validated
            CostCenter.GetCostCenter(txtStartCostCenterCode, Me.txtStartCostCenterName, Me.m_startcc)
        End Sub
        Private Sub btnShowStartCostCenter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShowStartCostCenter.Click
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            myEntityPanelService.OpenTreeDialog(New CostCenter, AddressOf SetStartCostCenter)
        End Sub
        Private Sub SetStartCostCenter(ByVal e As ISimpleEntity)
            Me.txtStartCostCenterCode.Text = e.Code
            CostCenter.GetCostCenter(txtStartCostCenterCode, txtStartCostCenterName, Me.m_startcc)
        End Sub
        Private Sub txtToEndCostCenterCode_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtEndCostCenterCode.Validated
            CostCenter.GetCostCenter(txtEndCostCenterCode, Me.txtEndCostCenterName, Me.m_endcc)
        End Sub
        Private Sub btnShowEndCostCenter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShowEndCostCenter.Click
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            myEntityPanelService.OpenTreeDialog(New CostCenter, AddressOf SetEndCostCenter)
        End Sub
        Private Sub SetEndCostCenter(ByVal e As ISimpleEntity)
            Me.txtEndCostCenterCode.Text = e.Code
            CostCenter.GetCostCenter(txtEndCostCenterCode, txtEndCostCenterName, Me.m_endcc)
        End Sub
#End Region

    End Class

End Namespace

