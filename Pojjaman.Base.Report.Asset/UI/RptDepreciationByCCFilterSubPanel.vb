Imports Longkong.Pojjaman.BusinessLogic
Imports longkong.Pojjaman.Services
Imports Longkong.Core.Services

Namespace Longkong.Pojjaman.Gui.Panels
    Public Class RptDepreciationByCCFilterSubPanel
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
        Friend WithEvents txtTemp As System.Windows.Forms.TextBox
        Friend WithEvents lblPeriodEnd As System.Windows.Forms.Label
        Friend WithEvents lblYearAcct As System.Windows.Forms.Label
        Friend WithEvents lblPeriodStart As System.Windows.Forms.Label
        Friend WithEvents cmbPeriodEnd As System.Windows.Forms.ComboBox
        Friend WithEvents cmbYearAcct As System.Windows.Forms.ComboBox
        Friend WithEvents cmbPeriodStart As System.Windows.Forms.ComboBox
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container
            Me.grbMaster = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.txtTemp = New System.Windows.Forms.TextBox
            Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.cmbPeriodEnd = New System.Windows.Forms.ComboBox
            Me.lblPeriodEnd = New System.Windows.Forms.Label
            Me.cmbYearAcct = New System.Windows.Forms.ComboBox
            Me.lblYearAcct = New System.Windows.Forms.Label
            Me.cmbPeriodStart = New System.Windows.Forms.ComboBox
            Me.lblPeriodStart = New System.Windows.Forms.Label
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
            Me.grbMaster.Controls.Add(Me.txtTemp)
            Me.grbMaster.Controls.Add(Me.grbDetail)
            Me.grbMaster.Controls.Add(Me.btnSearch)
            Me.grbMaster.Controls.Add(Me.btnReset)
            Me.grbMaster.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbMaster.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.grbMaster.Location = New System.Drawing.Point(8, 8)
            Me.grbMaster.Name = "grbMaster"
            Me.grbMaster.Size = New System.Drawing.Size(472, 152)
            Me.grbMaster.TabIndex = 0
            Me.grbMaster.TabStop = False
            Me.grbMaster.Text = "ค้นหา"
            '
            'txtTemp
            '
            Me.Validator.SetDataType(Me.txtTemp, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtTemp, "")
            Me.Validator.SetGotFocusBackColor(Me.txtTemp, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtTemp, System.Drawing.Color.Empty)
            Me.txtTemp.Location = New System.Drawing.Point(488, 32)
            Me.txtTemp.MaxLength = 255
            Me.Validator.SetMaxValue(Me.txtTemp, "")
            Me.Validator.SetMinValue(Me.txtTemp, "")
            Me.txtTemp.Name = "txtTemp"
            Me.txtTemp.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtTemp, "")
            Me.Validator.SetRequired(Me.txtTemp, False)
            Me.txtTemp.Size = New System.Drawing.Size(104, 21)
            Me.txtTemp.TabIndex = 3
            Me.txtTemp.Text = ""
            Me.txtTemp.Visible = False
            '
            'grbDetail
            '
            Me.grbDetail.Controls.Add(Me.cmbPeriodEnd)
            Me.grbDetail.Controls.Add(Me.lblPeriodEnd)
            Me.grbDetail.Controls.Add(Me.cmbYearAcct)
            Me.grbDetail.Controls.Add(Me.lblYearAcct)
            Me.grbDetail.Controls.Add(Me.cmbPeriodStart)
            Me.grbDetail.Controls.Add(Me.lblPeriodStart)
            Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbDetail.Location = New System.Drawing.Point(16, 16)
            Me.grbDetail.Name = "grbDetail"
            Me.grbDetail.Size = New System.Drawing.Size(440, 88)
            Me.grbDetail.TabIndex = 0
            Me.grbDetail.TabStop = False
            Me.grbDetail.Text = "ข้อมูลทั่วไป"
            '
            'cmbPeriodEnd
            '
            Me.cmbPeriodEnd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbPeriodEnd.Location = New System.Drawing.Point(296, 40)
            Me.cmbPeriodEnd.Name = "cmbPeriodEnd"
            Me.cmbPeriodEnd.TabIndex = 3
            '
            'lblPeriodEnd
            '
            Me.lblPeriodEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblPeriodEnd.ForeColor = System.Drawing.Color.Black
            Me.lblPeriodEnd.Location = New System.Drawing.Point(264, 40)
            Me.lblPeriodEnd.Name = "lblPeriodEnd"
            Me.lblPeriodEnd.Size = New System.Drawing.Size(24, 18)
            Me.lblPeriodEnd.TabIndex = 37
            Me.lblPeriodEnd.Text = "ถึง"
            Me.lblPeriodEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'cmbYearAcct
            '
            Me.cmbYearAcct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbYearAcct.Location = New System.Drawing.Point(136, 16)
            Me.cmbYearAcct.Name = "cmbYearAcct"
            Me.cmbYearAcct.TabIndex = 0
            '
            'lblYearAcct
            '
            Me.lblYearAcct.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblYearAcct.ForeColor = System.Drawing.Color.Black
            Me.lblYearAcct.Location = New System.Drawing.Point(24, 16)
            Me.lblYearAcct.Name = "lblYearAcct"
            Me.lblYearAcct.Size = New System.Drawing.Size(104, 18)
            Me.lblYearAcct.TabIndex = 32
            Me.lblYearAcct.Text = "ปีภาษี"
            Me.lblYearAcct.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cmbPeriodStart
            '
            Me.cmbPeriodStart.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbPeriodStart.Location = New System.Drawing.Point(136, 40)
            Me.cmbPeriodStart.Name = "cmbPeriodStart"
            Me.cmbPeriodStart.TabIndex = 2
            '
            'lblPeriodStart
            '
            Me.lblPeriodStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblPeriodStart.ForeColor = System.Drawing.Color.Black
            Me.lblPeriodStart.Location = New System.Drawing.Point(24, 40)
            Me.lblPeriodStart.Name = "lblPeriodStart"
            Me.lblPeriodStart.Size = New System.Drawing.Size(104, 18)
            Me.lblPeriodStart.TabIndex = 35
            Me.lblPeriodStart.Text = "งวดบัญชี"
            Me.lblPeriodStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnSearch
            '
            Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnSearch.Location = New System.Drawing.Point(384, 120)
            Me.btnSearch.Name = "btnSearch"
            Me.btnSearch.TabIndex = 2
            Me.btnSearch.Text = "ค้นหา"
            '
            'btnReset
            '
            Me.btnReset.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnReset.Location = New System.Drawing.Point(304, 120)
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
            'RptAssetDepreciationFilterSubPanel
            '
            Me.Controls.Add(Me.grbMaster)
            Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Name = "RptAssetDepreciationFilterSubPanel"
            Me.Size = New System.Drawing.Size(488, 168)
            Me.grbMaster.ResumeLayout(False)
            Me.grbDetail.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

#Region " SetLabelText "
        Public Sub SetLabelText()
            ' Button
            Me.btnSearch.Text = Me.StringParserService.Parse("${res:Global.SearchButtonText}")
            Me.btnReset.Text = Me.StringParserService.Parse("${res:Global.ResetButtonText}")

            ' GroupBox
            Me.grbMaster.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptDepreciationByCCFilterSubPanel.grbMaster}") '"ค้นหา"
            Me.grbDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptDepreciationByCCFilterSubPanel.grbDetail}") '"รายละเอียดทั่วไป"
            Me.lblYearAcct.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptDepreciationByCCFilterSubPanel.lblYearAcct}") '"ปีภาษี"
            Me.lblPeriodStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptDepreciationByCCFilterSubPanel.lblPeriodStart}") '"งวดบัญชี"
            Me.lblPeriodEnd.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")
        End Sub
#End Region

#Region "Member"
        Private m_assetstart As Asset
        Private m_assetend As Asset

        Private m_assettypestart As AssetType
        Private m_assettypeend As AssetType

        Private m_assetacctstart As Account
        Private m_assetacctend As Account

        Private m_DocDateEnd As Date
        Private m_DocDateStart As Date

        Private m_cc As CostCenter
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
        Public Property AssetStart() As Asset
            Get
                Return m_assetstart
            End Get
            Set(ByVal Value As Asset)
                m_assetstart = Value
            End Set
        End Property
        Public Property AssetEnd() As Asset
            Get
                Return m_assetend
            End Get
            Set(ByVal Value As Asset)
                m_assetend = Value
            End Set
        End Property
        Public Property AssetTypeStart() As AssetType
            Get
                Return m_assettypestart
            End Get
            Set(ByVal Value As AssetType)
                m_assettypestart = Value
            End Set
        End Property
        Public Property AssetTypeEnd() As AssetType
            Get
                Return m_assettypeend
            End Get
            Set(ByVal Value As AssetType)
                m_assettypeend = Value
            End Set
        End Property
        Public Property AssetAcctStart() As Account
            Get
                Return m_assetacctstart
            End Get
            Set(ByVal Value As Account)
                m_assetacctstart = Value
            End Set
        End Property
        Public Property AssetAcctEnd() As Account
            Get
                Return m_assetacctend
            End Get
            Set(ByVal Value As Account)
                m_assetacctend = Value
            End Set
        End Property
        Public Property DocDateEnd() As Date            Get                Return m_DocDateEnd            End Get            Set(ByVal Value As Date)                m_DocDateEnd = Value            End Set        End Property        Public Property DocDateStart() As Date            Get                Return m_DocDateStart            End Get            Set(ByVal Value As Date)                m_DocDateStart = Value            End Set        End Property

        Public Property CostCenter() As CostCenter
            Get
                Return m_cc
            End Get
            Set(ByVal Value As CostCenter)
                m_cc = Value
            End Set
        End Property
#End Region

#Region "Methods"

        Private Sub Initialize()
            RegisterDropdown()
            ClearCriterias()
        End Sub
        Private Sub RegisterDropdown()
            ' ปี
            Dim baseDate As Date = CDate(Configuration.GetConfig("BaseDate"))
            Dim years(9) As Date
            For i As Integer = 0 To 9
                years(i) = New Date(baseDate.Year + i, 1, 1)
            Next
            Dim myDateTimeService As DateTimeService = CType(ServiceManager.Services.GetService(GetType(DateTimeService)), DateTimeService)
            myDateTimeService.ListYearsInComboBox(Me.cmbYearAcct, years)

            ' งวดบัญชี
            Me.cmbPeriodStart.Items.Clear()
            Me.cmbPeriodEnd.Items.Clear()
            Dim period As String
            For i As Integer = 1 To 12
                period = i.ToString("0#")
                Me.cmbPeriodStart.Items.Add(period)
                Me.cmbPeriodEnd.Items.Add(period)
            Next

            'JournalEntryFilterOrderBy.ListCodeDescriptionInComboBox(Me.cmbFormat, "rpt_journalentryfilter")
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

            Me.CostCenter = New CostCenter

            Me.AssetStart = New Asset
            Me.AssetEnd = New Asset
            Me.AssetTypeStart = New AssetType
            Me.AssetTypeEnd = New AssetType
            Me.AssetAcctStart = New Account
            Me.AssetAcctEnd = New Account

            Dim dtStart As Date = Date.Now.Subtract(New TimeSpan(7, 0, 0, 0))
            Me.DocDateStart = dtStart
            'Me.txtDocDateStart.Text = MinDateToNull(Me.DocDateStart, "")
            'Me.dtpDocDateStart.Value = Me.DocDateStart

            Me.DocDateEnd = Date.Now
            'Me.txtDocDateEnd.Text = MinDateToNull(Me.DocDateEnd, "")
            'Me.dtpDocDateEnd.Value = Me.DocDateEnd

            Me.cmbYearAcct.SelectedIndex = (Date.Now.Year - CDate(Configuration.GetConfig("BaseDate")).Year)
            Me.cmbPeriodStart.SelectedIndex = 0
            Me.cmbPeriodEnd.SelectedIndex = 0
            'Me.chkOption.Checked = True
        End Sub
        Public Overrides Function GetFilterString() As String

        End Function
        Public Overrides Function GetFilterArray() As Filter()
            Dim arr(3) As Filter
            arr(0) = New Filter("YearAcct", cmbYearAcct.SelectedValue)
            arr(1) = New Filter("PeriodStart", IIf(Me.cmbPeriodStart.Text.Length > 0, Me.cmbPeriodStart.Text, DBNull.Value))
            arr(2) = New Filter("PeriodEnd", IIf(Me.cmbPeriodEnd.Text.Length > 0, Me.cmbPeriodEnd.Text, DBNull.Value))
            arr(3) = New Filter("userRight", CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
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

#Region " IReportFilterSubPanel "
        Public Function GetFixValueCollection() As BusinessLogic.DocPrintingItemCollection Implements IReportFilterSubPanel.GetFixValueCollection
            Dim dpiColl As New DocPrintingItemCollection
            Dim dpi As DocPrintingItem

            'If chkOption.Checked Then
            '    'year
            '    dpi = New DocPrintingItem
            '    dpi.Mapping = "year"
            '    dpi.Value = Me.cmbYearAcct.Text
            '    dpi.DataType = "System.String"
            '    dpiColl.Add(dpi)

            '    ' period start
            '    dpi = New DocPrintingItem
            '    dpi.Mapping = "periodstart"
            '    dpi.Value = cmbPeriodStart.Text
            '    dpi.DataType = "System.String"
            '    dpiColl.Add(dpi)

            '    ' period end
            '    dpi = New DocPrintingItem
            '    dpi.Mapping = "periodend"
            '    dpi.Value = cmbPeriodEnd.Text
            '    dpi.DataType = "System.String"
            '    dpiColl.Add(dpi)
            'Else
            '    'DocDateStart
            '    dpi = New DocPrintingItem
            '    dpi.Mapping = "DocDateStart"
            '    dpi.Value = Me.txtDocDateStart.Text
            '    dpi.DataType = "System.String"
            '    dpiColl.Add(dpi)

            '    'DocDateEnd
            '    dpi = New DocPrintingItem
            '    dpi.Mapping = "DocDateEnd"
            '    dpi.Value = Me.txtDocDateEnd.Text
            '    dpi.DataType = "System.String"
            '    dpiColl.Add(dpi)
            'End If

            '' EndDate
            'If chkOption.Checked Then
            '    If TypeOf cmbYearAcct.SelectedItem Is ValueDisplayPair Then
            '        Dim code As String = cmbYearAcct.SelectedText
            '        Dim myItem As ValueDisplayPair = CType(cmbYearAcct.SelectedItem, ValueDisplayPair)
            '        Dim dt As Date = CType(myItem.Value, Date)
            '        Dim period As AccountPeriod = AccountPeriod.GetAccountPeriod(dt, code)
            '        If period Is Nothing Then
            '            Dim acctPeriodcoll As AccountPeriodCollection = AccountPeriod.GetLastestAccountPeriod()
            '            period = acctPeriodcoll.Item(acctPeriodcoll.Count - 1)
            '        End If

            '        ' EndDateShort
            '        dpi = New DocPrintingItem
            '        dpi.Mapping = "enddateshort"
            '        dpi.Value = period.EndDate.ToShortDateString
            '        dpi.DataType = "System.String"
            '        dpiColl.Add(dpi)

            '        ' EndDateFull
            '        dpi = New DocPrintingItem
            '        dpi.Mapping = "enddatefull"
            '        dpi.Value = period.EndDate.ToLongDateString
            '        dpi.DataType = "System.String"
            '        dpiColl.Add(dpi)

            '    End If
            'Else
            '    ' EndDateShort
            '    dpi = New DocPrintingItem
            '    dpi.Mapping = "enddateshort"
            '    dpi.Value = DocDateStart.ToShortDateString
            '    dpi.DataType = "System.String"
            '    dpiColl.Add(dpi)

            '    ' EndDateFull
            '    dpi = New DocPrintingItem
            '    dpi.Mapping = "enddatefull"
            '    dpi.Value = DocDateStart.ToLongDateString
            '    dpi.DataType = "System.String"
            '    dpiColl.Add(dpi)
            'End If

            ''Asset Start
            'dpi = New DocPrintingItem
            'dpi.Mapping = "AssetStart"
            'dpi.Value = Me.txtAssetCodeStart.Text
            'dpi.DataType = "System.String"
            'dpiColl.Add(dpi)

            ''Asset End
            'dpi = New DocPrintingItem
            'dpi.Mapping = "AssetEnd"
            'dpi.Value = Me.txtAssetCodeEnd.Text
            'dpi.DataType = "System.String"
            'dpiColl.Add(dpi)

            ''AssetType Start
            'dpi = New DocPrintingItem
            'dpi.Mapping = "AssetTypeStart"
            'dpi.Value = Me.txtAssetTypeCodeStart.Text
            'dpi.DataType = "System.String"
            'dpiColl.Add(dpi)

            ''AssetType End
            'dpi = New DocPrintingItem
            'dpi.Mapping = "AssetTypeEnd"
            'dpi.Value = Me.txtAssetTypeCodeEnd.Text
            'dpi.DataType = "System.String"
            'dpiColl.Add(dpi)

            ''AssetAcct Start
            'dpi = New DocPrintingItem
            'dpi.Mapping = "AssetAcctStart"
            'dpi.Value = Me.txtAssetAcctCodeStart.Text
            'dpi.DataType = "System.String"
            'dpiColl.Add(dpi)

            ''AssetAcct End
            'dpi = New DocPrintingItem
            'dpi.Mapping = "AssetAcctEnd"
            'dpi.Value = Me.txtAssetAcctCodeEnd.Text
            'dpi.DataType = "System.String"
            'dpiColl.Add(dpi)

            ''CostCenterStart
            'dpi = New DocPrintingItem
            'dpi.Mapping = "CostcenterStart"
            'dpi.Value = Me.txtCCCodeStart.Text
            'dpi.DataType = "System.String"
            'dpiColl.Add(dpi)

            ''CostCenterEnd
            'dpi = New DocPrintingItem
            'dpi.Mapping = "CostcenterEnd"
            'dpi.Value = Me.txtCCCodeEnd.Text
            'dpi.DataType = "System.String"
            'dpiColl.Add(dpi)

            'today
            dpi = New DocPrintingItem
            dpi.Mapping = "today"
            dpi.Value = MinDateToNull(Now, "") + " : " + Now.ToShortTimeString
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)

            Return dpiColl
        End Function
#End Region

#Region " ChangeProperty "
        Private Sub EventWiring()
            'AddHandler btnAssetStartFind.Click, AddressOf Me.btnAssetFind_Click
            'AddHandler btnAssetEndFind.Click, AddressOf Me.btnAssetFind_Click

            'AddHandler btnAssetTypeStartFind.Click, AddressOf Me.btnAssetTypeFind_Click
            'AddHandler btnAssetTypeEndFind.Click, AddressOf Me.btnAssetTypeFind_Click

            'AddHandler btnAssetAcctStartFind.Click, AddressOf Me.btnAssetAcctFind_Click
            'AddHandler btnAssetAcctEndFind.Click, AddressOf Me.btnAssetAcctFind_Click

            'AddHandler btnCCStartFind.Click, AddressOf Me.btnCCFind_Click
            'AddHandler btnCCEndFind.Click, AddressOf Me.btnCCFind_Click

            'AddHandler txtDocDateStart.Validated, AddressOf Me.ChangeProperty
            'AddHandler txtDocDateEnd.Validated, AddressOf Me.ChangeProperty

            'AddHandler txtCCCodeStart.Validated, AddressOf Me.ChangeProperty
            'AddHandler txtCCCodeEnd.Validated, AddressOf Me.ChangeProperty

            'AddHandler dtpDocDateStart.ValueChanged, AddressOf Me.ChangeProperty
            'AddHandler dtpDocDateEnd.ValueChanged, AddressOf Me.ChangeProperty

            'AddHandler chkOption.CheckedChanged, AddressOf Me.ChangeProperty
        End Sub

        Private m_dateSetting As Boolean
        Private Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)

            Select Case CType(sender, Control).Name.ToLower
                'Case "txtcccodestart"
                '    CostCenter.GetCostCenter(txtCCCodeStart, txtTemp, Me.CostCenter, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)

                'Case "txtcccodeend"
                '    CostCenter.GetCostCenter(txtCCCodeEnd, txtTemp, Me.CostCenter, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)

            Case "chkoption"
                    'If chkOption.Checked Then
                    '    txtDocDateStart.Enabled = False
                    '    txtDocDateEnd.Enabled = False
                    '    dtpDocDateStart.Enabled = False
                    '    dtpDocDateEnd.Enabled = False

                    '    cmbPeriodStart.Enabled = True
                    '    cmbPeriodEnd.Enabled = True
                    '    cmbYearAcct.Enabled = True
                    'Else
                    '    txtDocDateStart.Enabled = True
                    '    txtDocDateEnd.Enabled = True
                    '    dtpDocDateStart.Enabled = True
                    '    dtpDocDateEnd.Enabled = True

                    '    cmbPeriodStart.Enabled = False
                    '    cmbPeriodEnd.Enabled = False
                    '    cmbYearAcct.Enabled = False
                    'End If
                    'Case "dtpdocdatestart"
                    '    'If Not Me.DocDateStart.Equals(dtpDocDateStart.Value) Then
                    '    '    If Not m_dateSetting Then
                    '    '        Me.txtDocDateStart.Text = MinDateToNull(dtpDocDateStart.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
                    '    '        Me.DocDateStart = dtpDocDateStart.Value
                    '    '    End If
                    '    'End If
                    'Case "txtdocdatestart"
                    '    m_dateSetting = True
                    '    If Not Me.txtDocDateStart.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtDocDateStart) = "" Then
                    '        Dim theDate As Date = CDate(Me.txtDocDateStart.Text)
                    '        If Not Me.DocDateStart.Equals(theDate) Then
                    '            dtpDocDateStart.Value = theDate
                    '            Me.DocDateStart = dtpDocDateStart.Value
                    '        End If
                    '    Else
                    '        Me.dtpDocDateStart.Value = Date.Now
                    '        Me.DocDateStart = Date.MinValue
                    '    End If
                    '    m_dateSetting = False

                    'Case "dtpdocdateend"
                    '    If Not Me.DocDateEnd.Equals(dtpDocDateEnd.Value) Then
                    '        If Not m_dateSetting Then
                    '            Me.txtDocDateEnd.Text = MinDateToNull(dtpDocDateEnd.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
                    '            Me.DocDateEnd = dtpDocDateEnd.Value
                    '        End If
                    '    End If
                    'Case "txtdocdateend"
                    '    m_dateSetting = True
                    '    If Not Me.txtDocDateEnd.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtDocDateEnd) = "" Then
                    '        Dim theDate As Date = CDate(Me.txtDocDateEnd.Text)
                    '        If Not Me.DocDateEnd.Equals(theDate) Then
                    '            dtpDocDateEnd.Value = theDate
                    '            Me.DocDateEnd = dtpDocDateEnd.Value
                    '        End If
                    '    Else
                    '        Me.dtpDocDateEnd.Value = Date.Now
                    '        Me.DocDateEnd = Date.MinValue
                    '    End If
                    m_dateSetting = False

                Case Else

            End Select
        End Sub
#End Region

#Region "IClipboardHandler Overrides"
        Public Overrides ReadOnly Property EnablePaste() As Boolean
            Get
                Dim data As IDataObject = Clipboard.GetDataObject
                If data.GetDataPresent((New Supplier).FullClassName) Then
                    If Not Me.ActiveControl Is Nothing Then
                        Select Case Me.ActiveControl.Name.ToLower
                            Case "txtassetcodestart", "txtassetcodeend"
                                Return True
                        End Select
                    End If
                End If
                ' CostCenter
                If data.GetDataPresent((New CostCenter).FullClassName) Then
                    If Not Me.ActiveControl Is Nothing Then
                        Select Case Me.ActiveControl.Name.ToLower
                            Case "txtcccodestart", "txtcccodeend"
                                Return True
                        End Select
                    End If
                End If
            End Get
        End Property
        Public Overrides Sub Paste(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim data As IDataObject = Clipboard.GetDataObject
            If data.GetDataPresent((New Supplier).FullClassName) Then
                Dim id As Integer = CInt(data.GetData((New Supplier).FullClassName))
                Dim entity As New Supplier(id)
                'If Not Me.ActiveControl Is Nothing Then
                '    Select Case Me.ActiveControl.Name.ToLower
                '        Case "txtassetcodestart"
                '            Me.SetAssetStartDialog(entity)

                '        Case "txtassetcodeend"
                '            Me.SetAssetEndDialog(entity)

                '    End Select
                'End If
            End If
            ' CostCenter
            If data.GetDataPresent((New CostCenter).FullClassName) Then
                Dim id As Integer = CInt(data.GetData((New CostCenter).FullClassName))
                Dim entity As New CostCenter(id)
                'If Not Me.ActiveControl Is Nothing Then
                '    Select Case Me.ActiveControl.Name.ToLower
                '        Case "txtcccodestart"
                '            Me.SetCCCodeStartDialog(entity)

                '        Case "txtcccodestart"
                '            Me.SetCCCodeStartDialog(entity)
                '    End Select
                'End If
            End If
        End Sub
#End Region

#Region " Event Handlers "
        'Private Sub btnAssetFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '    Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
        '    Select Case CType(sender, Control).Name.ToLower
        '        Case "btnassetstartfind"
        '            myEntityPanelService.OpenListDialog(New Asset, AddressOf SetAssetStartDialog)

        '        Case "btnassetendfind"
        '            myEntityPanelService.OpenListDialog(New Asset, AddressOf SetAssetEndDialog)
        '    End Select
        'End Sub
        'Private Sub btnAssetTypeFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '    Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
        '    Select Case CType(sender, Control).Name.ToLower
        '        Case "btnassettypestartfind"
        '            myEntityPanelService.OpenTreeDialog(New AssetType, AddressOf SetAssetTypeStartDialog)

        '        Case "btnassettypeendfind"
        '            myEntityPanelService.OpenTreeDialog(New AssetType, AddressOf SetAssetTypeEndDialog)
        '    End Select
        'End Sub
        'Private Sub btnAssetAcctFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '    Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
        '    Select Case CType(sender, Control).Name.ToLower
        '        Case "btnassetacctstartfind"
        '            myEntityPanelService.OpenTreeDialog(New Account, AddressOf SetAssetAcctStartDialog)

        '        Case "btnassetacctendfind"
        '            myEntityPanelService.OpenTreeDialog(New Account, AddressOf SetAssetAcctEndDialog)
        '    End Select
        'End Sub
        ' CostCenter
        'Private Sub btnCCFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '    Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
        '    Select Case CType(sender, Control).Name.ToLower
        '        Case "btnccstartfind"
        '            myEntityPanelService.OpenTreeDialog(New CostCenter, AddressOf SetCCCodeStartDialog)

        '        Case "btnccendfind"
        '            myEntityPanelService.OpenTreeDialog(New CostCenter, AddressOf SetCCCodeEndDialog)
        '    End Select
        'End Sub
        'Private Sub SetAssetStartDialog(ByVal e As ISimpleEntity)
        '    Me.txtAssetCodeStart.Text = e.Code
        '    Asset.GetAsset(txtAssetCodeStart, txtTemp, Me.AssetStart)
        'End Sub
        'Private Sub SetAssetEndDialog(ByVal e As ISimpleEntity)
        '    Me.txtAssetCodeEnd.Text = e.Code
        '    Asset.GetAsset(txtAssetCodeEnd, txtTemp, Me.AssetEnd)
        'End Sub
        'Private Sub SetAssetTypeStartDialog(ByVal e As ISimpleEntity)
        '    Me.txtAssetTypeCodeStart.Text = e.Code
        '    AssetType.GetAssetType(txtAssetTypeCodeStart, txtTemp, Me.AssetTypeStart)
        'End Sub
        'Private Sub SetAssetTypeEndDialog(ByVal e As ISimpleEntity)
        '    Me.txtAssetTypeCodeEnd.Text = e.Code
        '    AssetType.GetAssetType(txtAssetTypeCodeEnd, txtTemp, Me.AssetTypeEnd)
        'End Sub
        'Private Sub SetAssetAcctStartDialog(ByVal e As ISimpleEntity)
        '    Me.txtAssetAcctCodeStart.Text = e.Code
        '    Account.GetAccount(txtAssetAcctCodeStart, txtTemp, Me.AssetAcctStart)
        'End Sub
        'Private Sub SetAssetAcctEndDialog(ByVal e As ISimpleEntity)
        '    Me.txtAssetAcctCodeEnd.Text = e.Code
        '    Account.GetAccount(txtAssetAcctCodeEnd, txtTemp, Me.AssetAcctEnd)
        'End Sub
        'Private Sub SetCCCodeStartDialog(ByVal e As ISimpleEntity)
        '    Me.txtCCCodeStart.Text = e.Code
        '    CostCenter.GetCostCenter(txtCCCodeStart, txtTemp, Me.CostCenter, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
        'End Sub
        'Private Sub SetCCCodeEndDialog(ByVal e As ISimpleEntity)
        '    Me.txtCCCodeEnd.Text = e.Code
        '    CostCenter.GetCostCenter(txtCCCodeEnd, txtTemp, Me.CostCenter, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
        'End Sub
#End Region

    End Class
End Namespace

