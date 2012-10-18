Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Imports System.Collections.Generic

Namespace Longkong.Pojjaman.Gui.Panels
    Public Class RptWBSBudgetByCCFilterSubPanel
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
        Friend WithEvents btnSearch As System.Windows.Forms.Button
        Friend WithEvents btnReset As System.Windows.Forms.Button
        Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
        Friend WithEvents grbDetail As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents txtDocDateEnd As System.Windows.Forms.TextBox
        Friend WithEvents dtpDocDateEnd As System.Windows.Forms.DateTimePicker
        Friend WithEvents lblDocDateEnd As System.Windows.Forms.Label
        Friend WithEvents cmbReportType As System.Windows.Forms.ComboBox
        Friend WithEvents grbProject As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents btnSearchProject As System.Windows.Forms.Button
        Friend WithEvents txtSearchProject As System.Windows.Forms.TextBox
        Friend WithEvents chkAll As System.Windows.Forms.CheckBox
        Friend WithEvents ibtnDown As System.Windows.Forms.Button
        Friend WithEvents chkOnlyChecked As System.Windows.Forms.CheckBox
        Friend WithEvents clbCostCenter As System.Windows.Forms.CheckedListBox
        Friend WithEvents ibtnUp As System.Windows.Forms.Button
        Friend WithEvents lblReportType As System.Windows.Forms.Label
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            Me.grbMaster = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
            Me.grbProject = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
            Me.btnSearchProject = New System.Windows.Forms.Button()
            Me.txtSearchProject = New System.Windows.Forms.TextBox()
            Me.chkAll = New System.Windows.Forms.CheckBox()
            Me.ibtnDown = New System.Windows.Forms.Button()
            Me.chkOnlyChecked = New System.Windows.Forms.CheckBox()
            Me.clbCostCenter = New System.Windows.Forms.CheckedListBox()
            Me.ibtnUp = New System.Windows.Forms.Button()
            Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
            Me.lblReportType = New System.Windows.Forms.Label()
            Me.cmbReportType = New System.Windows.Forms.ComboBox()
            Me.txtDocDateEnd = New System.Windows.Forms.TextBox()
            Me.dtpDocDateEnd = New System.Windows.Forms.DateTimePicker()
            Me.lblDocDateEnd = New System.Windows.Forms.Label()
            Me.btnSearch = New System.Windows.Forms.Button()
            Me.btnReset = New System.Windows.Forms.Button()
            Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
            Me.grbMaster.SuspendLayout()
            Me.grbProject.SuspendLayout()
            Me.grbDetail.SuspendLayout()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'grbMaster
            '
            Me.grbMaster.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.grbMaster.Controls.Add(Me.grbProject)
            Me.grbMaster.Controls.Add(Me.grbDetail)
            Me.grbMaster.Controls.Add(Me.btnSearch)
            Me.grbMaster.Controls.Add(Me.btnReset)
            Me.grbMaster.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbMaster.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.grbMaster.Location = New System.Drawing.Point(8, 8)
            Me.grbMaster.Name = "grbMaster"
            Me.grbMaster.Size = New System.Drawing.Size(741, 242)
            Me.grbMaster.TabIndex = 0
            Me.grbMaster.TabStop = False
            Me.grbMaster.Text = "ค้นหา"
            '
            'grbProject
            '
            Me.grbProject.Controls.Add(Me.btnSearchProject)
            Me.grbProject.Controls.Add(Me.txtSearchProject)
            Me.grbProject.Controls.Add(Me.chkAll)
            Me.grbProject.Controls.Add(Me.ibtnDown)
            Me.grbProject.Controls.Add(Me.chkOnlyChecked)
            Me.grbProject.Controls.Add(Me.clbCostCenter)
            Me.grbProject.Controls.Add(Me.ibtnUp)
            Me.grbProject.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbProject.Location = New System.Drawing.Point(6, 20)
            Me.grbProject.Name = "grbProject"
            Me.grbProject.Size = New System.Drawing.Size(429, 211)
            Me.grbProject.TabIndex = 3
            Me.grbProject.TabStop = False
            Me.grbProject.Text = "โครงการ"
            '
            'btnSearchProject
            '
            Me.btnSearchProject.Location = New System.Drawing.Point(242, 16)
            Me.btnSearchProject.Name = "btnSearchProject"
            Me.btnSearchProject.Size = New System.Drawing.Size(51, 23)
            Me.btnSearchProject.TabIndex = 26
            Me.btnSearchProject.Text = "ค้นหา"
            Me.btnSearchProject.UseVisualStyleBackColor = True
            '
            'txtSearchProject
            '
            Me.Validator.SetDataType(Me.txtSearchProject, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtSearchProject, "")
            Me.Validator.SetGotFocusBackColor(Me.txtSearchProject, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtSearchProject, System.Drawing.Color.Empty)
            Me.txtSearchProject.Location = New System.Drawing.Point(7, 17)
            Me.Validator.SetMinValue(Me.txtSearchProject, "")
            Me.txtSearchProject.Name = "txtSearchProject"
            Me.Validator.SetRegularExpression(Me.txtSearchProject, "")
            Me.Validator.SetRequired(Me.txtSearchProject, False)
            Me.txtSearchProject.Size = New System.Drawing.Size(235, 21)
            Me.txtSearchProject.TabIndex = 25
            '
            'chkAll
            '
            Me.chkAll.AutoSize = True
            Me.chkAll.Location = New System.Drawing.Point(299, 152)
            Me.chkAll.Name = "chkAll"
            Me.chkAll.Size = New System.Drawing.Size(85, 17)
            Me.chkAll.TabIndex = 24
            Me.chkAll.Text = "เลือกทั้งหมด"
            Me.chkAll.UseMnemonic = False
            Me.chkAll.UseVisualStyleBackColor = True
            '
            'ibtnDown
            '
            Me.ibtnDown.Image = Global.My.Resources.Resources.Actions_go_down_icon32
            Me.ibtnDown.Location = New System.Drawing.Point(299, 78)
            Me.ibtnDown.Name = "ibtnDown"
            Me.ibtnDown.Size = New System.Drawing.Size(34, 37)
            Me.ibtnDown.TabIndex = 20
            Me.ibtnDown.UseVisualStyleBackColor = False
            '
            'chkOnlyChecked
            '
            Me.chkOnlyChecked.AutoSize = True
            Me.chkOnlyChecked.Location = New System.Drawing.Point(299, 129)
            Me.chkOnlyChecked.Name = "chkOnlyChecked"
            Me.chkOnlyChecked.Size = New System.Drawing.Size(113, 17)
            Me.chkOnlyChecked.TabIndex = 22
            Me.chkOnlyChecked.Text = "แสดงเฉพาะที่เลือก"
            Me.chkOnlyChecked.UseMnemonic = False
            Me.chkOnlyChecked.UseVisualStyleBackColor = True
            '
            'clbCostCenter
            '
            Me.clbCostCenter.FormattingEnabled = True
            Me.clbCostCenter.Location = New System.Drawing.Point(7, 41)
            Me.clbCostCenter.Name = "clbCostCenter"
            Me.clbCostCenter.Size = New System.Drawing.Size(286, 148)
            Me.clbCostCenter.TabIndex = 21
            '
            'ibtnUp
            '
            Me.ibtnUp.Image = Global.My.Resources.Resources.Actions_go_up_icon32
            Me.ibtnUp.Location = New System.Drawing.Point(299, 41)
            Me.ibtnUp.Name = "ibtnUp"
            Me.ibtnUp.Size = New System.Drawing.Size(34, 37)
            Me.ibtnUp.TabIndex = 19
            Me.ibtnUp.UseVisualStyleBackColor = False
            '
            'grbDetail
            '
            Me.grbDetail.Controls.Add(Me.lblReportType)
            Me.grbDetail.Controls.Add(Me.cmbReportType)
            Me.grbDetail.Controls.Add(Me.txtDocDateEnd)
            Me.grbDetail.Controls.Add(Me.dtpDocDateEnd)
            Me.grbDetail.Controls.Add(Me.lblDocDateEnd)
            Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbDetail.Location = New System.Drawing.Point(439, 20)
            Me.grbDetail.Name = "grbDetail"
            Me.grbDetail.Size = New System.Drawing.Size(292, 78)
            Me.grbDetail.TabIndex = 0
            Me.grbDetail.TabStop = False
            Me.grbDetail.Text = "ข้อมูลทั่วไป"
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
            Me.Validator.SetMinValue(Me.txtDocDateEnd, "")
            Me.txtDocDateEnd.Name = "txtDocDateEnd"
            Me.Validator.SetRegularExpression(Me.txtDocDateEnd, "")
            Me.Validator.SetRequired(Me.txtDocDateEnd, False)
            Me.txtDocDateEnd.Size = New System.Drawing.Size(99, 21)
            Me.txtDocDateEnd.TabIndex = 4
            '
            'dtpDocDateEnd
            '
            Me.dtpDocDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
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
            'btnSearch
            '
            Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnSearch.Location = New System.Drawing.Point(651, 205)
            Me.btnSearch.Name = "btnSearch"
            Me.btnSearch.Size = New System.Drawing.Size(75, 23)
            Me.btnSearch.TabIndex = 2
            Me.btnSearch.Text = "ค้นหา"
            '
            'btnReset
            '
            Me.btnReset.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnReset.Location = New System.Drawing.Point(571, 205)
            Me.btnReset.Name = "btnReset"
            Me.btnReset.Size = New System.Drawing.Size(75, 23)
            Me.btnReset.TabIndex = 1
            Me.btnReset.TabStop = False
            Me.btnReset.Text = "เคลียร์"
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
            'RptWBSBudgetByCCFilterSubPanel
            '
            Me.Controls.Add(Me.grbMaster)
            Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Name = "RptWBSBudgetByCCFilterSubPanel"
            Me.Size = New System.Drawing.Size(762, 266)
            Me.grbMaster.ResumeLayout(False)
            Me.grbProject.ResumeLayout(False)
            Me.grbProject.PerformLayout()
            Me.grbDetail.ResumeLayout(False)
            Me.grbDetail.PerformLayout()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

#Region " SetLabelText "
        Public Sub SetLabelText()

            'Me.lblStartCostCenter.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptWBSBudgetByCCFilterSubPanel.lblStartCostCenter}")
            'Me.Validator.SetDisplayName(txtStartCostCenterCode, lblStartCostCenter.Text)

            'Me.lblEndCostCenter.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptWBSBudgetByCCFilterSubPanel.lblEndCostCenter}")
            'Me.Validator.SetDisplayName(txtEndCostCenterCode, lblEndCostCenter.Text)

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

            Me.grbProject.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptWBSMonitorFilterSubPanel.grbProject}")
            Me.chkAll.Text = Me.StringParserService.Parse("${res:Global.chkSelectAll}")
            Me.chkOnlyChecked.Text = Me.StringParserService.Parse("${res:Global.chkOnlyChecked}")

            Me.btnSearchProject.Text = Me.StringParserService.Parse("${res:Global.SearchButtonText}")


        End Sub
#End Region

#Region "Member"
        Private m_DocDateEnd As Date
        Private m_startcc As CostCenter
        Private m_endcc As CostCenter

        Private DocList As String
        Private CCIdList As String
        Private CCIndexList As IDictionary(Of Integer, Integer)
        Private CCList As Dictionary(Of String, CostCenter)
#End Region

#Region "Constructors"
        Public Sub New()
            MyBase.New()
            InitializeComponent()
            EventWiring()
            Initialize()

            clbCostCenter.CheckOnClick = True

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
                .Items.Add(Me.StringParserService.Parse("${res:Global.AllocationType.PR}"))
                .Items.Add(Me.StringParserService.Parse("${res:Global.AllocationType.PO}"))
                .Items.Add(Me.StringParserService.Parse("${res:Global.AllocationType.GR}"))
                .Items.Add(Me.StringParserService.Parse("${res:Global.AllocationType.MR}"))
                .SelectedIndex = 2
            End With

        End Sub
        Private Sub Initialize()
            LoadCombo()
            ClearCriterias()

            CCIndexList = New Dictionary(Of Integer, Integer)
            LoadCostCenter()

        End Sub

        Private Sub btnSearchProject_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearchProject.Click
            If txtSearchProject.Text.Trim.Length = 0 Then
                RefreshCheckCCListBox()
            Else
                RefreshCheckCCListBoxFilter(txtSearchProject.Text.Trim)
            End If
        End Sub

        Private Sub RefreshCheckCCListBoxFilter(ByVal textFilter As String)
            Dim notonlychecked As Boolean = Not chkOnlyChecked.Checked
            'Dim IncClose As Boolean = chkIncClose.Checked

            Dim ccFilterList As Dictionary(Of String, CostCenter) = New Dictionary(Of String, CostCenter)
            Dim ccHash As New Hashtable
            Dim ccdt As DataTable = Me.CostCenterSchema
            For Each kv As KeyValuePair(Of String, CostCenter) In CCList
                Dim dr As DataRow = ccdt.NewRow
                dr("cc_code") = kv.Value.Code
                dr("cc_name") = kv.Value.Name
                ccdt.Rows.Add(dr)
                ccHash(kv.Value.Code) = kv.Value
            Next

            textFilter = Replace(Replace(Replace(Replace(textFilter, "%", ""), "'", ""), "?", ""), "*", "")

            Dim ccCode As String = ""
            Dim cc As CostCenter
            For Each dr_ As DataRow In ccdt.Select("cc_code like '%" & textFilter & "%' or cc_name like '%" & textFilter & "%'")
                ccCode = CStr(dr_("cc_code"))
                cc = CType(ccHash(ccCode), CostCenter)
                If Not ccFilterList.ContainsKey(ccCode) Then
                    ccFilterList.Add(ccCode, cc)
                End If
            Next

            Dim chkCode As New List(Of String)
            For Each chki As Object In clbCostCenter.CheckedItems
                Dim s As String = chki.ToString.Split(":")(0)
                If Not chkCode.Contains(s) Then
                    chkCode.Add(s)
                    cc = CType(ccHash(s), CostCenter)
                    If Not ccFilterList.ContainsKey(s) Then
                        ccFilterList.Add(s, cc)
                    End If
                End If
            Next

            clbCostCenter.Items.Clear()
            For Each kv As KeyValuePair(Of String, CostCenter) In ccFilterList
                If (kv.Value.IsActive) AndAlso (notonlychecked OrElse chkCode.Contains(kv.Key)) Then
                    Dim chk As Boolean = chkCode.Contains(kv.Key)
                    Dim list As String = kv.Value.Code & ":" & kv.Value.Name
                    Dim ob As New IdValuePair(kv.Value.Id, list)
                    clbCostCenter.Items.Add(ob, chk)
                End If
            Next


        End Sub

        Private Function CostCenterSchema() As DataTable
            Dim dt As New DataTable
            Dim dcc As New DataColumn("cc_code")
            Dim dcn As New DataColumn("cc_name")
            dt.Columns.Add(dcc)
            dt.Columns.Add(dcn)
            Return dt

        End Function

        Private Sub LoadCostCenter()
            Dim currentuserid As Integer = CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id

            CCList = New Dictionary(Of String, CostCenter)


            CCList = CostCenter.CostCenterRightList(currentuserid)


            RefreshCheckCCListBox()

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
            Dim arr(3) As Filter
            arr(0) = New Filter("DocDateEnd", IIf(Me.DocDateEnd.Equals(Date.MinValue), DBNull.Value, Me.DocDateEnd))
            'arr(1) = New Filter("CCStart", IIf(txtStartCostCenterCode.TextLength > 0, txtStartCostCenterCode.Text, DBNull.Value))
            'arr(2) = New Filter("CCEnd", IIf(txtEndCostCenterCode.TextLength > 0, txtEndCostCenterCode.Text, DBNull.Value))
            arr(1) = New Filter("CCCodeList", CheckedCCListString)

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
            arr(2) = New Filter("WBSReportType", type)
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
        'Public Overrides ReadOnly Property EnablePaste() As Boolean
        '    Get
        '        Dim data As IDataObject = Clipboard.GetDataObject
        '        If data.GetDataPresent(m_startcc.FullClassName) Then
        '            If Not Me.ActiveControl Is Nothing Then
        '                Select Case Me.ActiveControl.Name.ToLower

        '                    Case "txttoccstart", "txttoccend"
        '                        Return True
        '                End Select
        '            End If
        '        End If
        '        If data.GetDataPresent(m_endcc.FullClassName) Then
        '            If Not Me.ActiveControl Is Nothing Then
        '                Select Case Me.ActiveControl.Name.ToLower

        '                    Case "txttoccstart", "txttoccend"
        '                        Return True
        '                End Select
        '            End If
        '        End If
        '    End Get
        'End Property
        'Public Overrides Sub Paste(ByVal sender As Object, ByVal e As System.EventArgs)
        '    Dim data As IDataObject = Clipboard.GetDataObject
        '    If data.GetDataPresent(m_startcc.FullClassName) Then
        '        Dim id As Integer = CInt(data.GetData(m_startcc.FullClassName))
        '        Dim entity As New CostCenter(id)
        '        If Not Me.ActiveControl Is Nothing Then
        '            Select Case Me.ActiveControl.Name.ToLower

        '                Case "txttoccstart"
        '                    Me.SetStartCostCenter(entity)


        '            End Select
        '        End If
        '    End If
        'End Sub
#End Region

#Region " Event Handlers "
        'Private Sub txtToStartCostCenterCode_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '    CostCenter.GetCostCenter(txtStartCostCenterCode, Me.txtStartCostCenterName, Me.m_startcc)
        'End Sub
        'Private Sub btnShowStartCostCenter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '    Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
        '    myEntityPanelService.OpenTreeDialog(New CostCenter, AddressOf SetStartCostCenter)
        'End Sub
        'Private Sub SetStartCostCenter(ByVal e As ISimpleEntity)
        '    Me.txtStartCostCenterCode.Text = e.Code
        '    CostCenter.GetCostCenter(txtStartCostCenterCode, txtStartCostCenterName, Me.m_startcc)
        'End Sub
        'Private Sub txtToEndCostCenterCode_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '    CostCenter.GetCostCenter(txtEndCostCenterCode, Me.txtEndCostCenterName, Me.m_endcc)
        'End Sub
        'Private Sub btnShowEndCostCenter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '    Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
        '    myEntityPanelService.OpenTreeDialog(New CostCenter, AddressOf SetEndCostCenter)
        'End Sub
        'Private Sub SetEndCostCenter(ByVal e As ISimpleEntity)
        '    Me.txtEndCostCenterCode.Text = e.Code
        '    CostCenter.GetCostCenter(txtEndCostCenterCode, txtEndCostCenterName, Me.m_endcc)
        'End Sub
        Private Function CheckedCCListString() As String

            Dim chkId As New List(Of String)
            Dim order As Integer = 0
            For Each chki As Object In clbCostCenter.CheckedItems
                Dim s As String = CType(chki, IdValuePair).Value.Split(":")(0)
                s = s & "|" & order.ToString
                chkId.Add(s)
                order += 1
            Next

            Return String.Join(",", chkId)
        End Function
        Private Sub RefreshCheckCCListBox() Handles chkOnlyChecked.CheckedChanged
            Dim notonlychecked As Boolean = Not chkOnlyChecked.Checked
            'Dim IncClose As Boolean = chkIncClose.Checked

            Dim chkCode As New List(Of String)
            For Each chki As Object In clbCostCenter.CheckedItems
                Dim s As String = chki.ToString.Split(":")(0)
                chkCode.Add(s)
            Next

            clbCostCenter.Items.Clear()
            For Each kv As KeyValuePair(Of String, CostCenter) In CCList
                If (kv.Value.IsActive) AndAlso (notonlychecked OrElse chkCode.Contains(kv.Key)) Then
                    Dim chk As Boolean = chkCode.Contains(kv.Key)
                    Dim list As String = kv.Value.Code & ":" & kv.Value.Name
                    Dim ob As New IdValuePair(kv.Value.Id, list)
                    clbCostCenter.Items.Add(ob, chk)
                End If
            Next


        End Sub
        Private checking As Boolean = False
        Private Sub CheckedALLCC() Handles chkAll.CheckedChanged
            If checking Then
                Return
            End If
            Dim chk As Boolean = chkAll.Checked
            For i As Integer = 0 To Me.clbCostCenter.Items.Count - 1
                Me.clbCostCenter.SetItemChecked(i, chk)
            Next

        End Sub
        Private Sub clbCostCenter_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles clbCostCenter.MouseUp
            CheckChanged()
        End Sub
        Private Sub clbCostCenter_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles clbCostCenter.KeyUp
            CheckChanged()
        End Sub
        Private Sub CheckChanged()
            checking = True
            If clbCostCenter.CheckedItems.Count = 0 Then
                chkAll.CheckState = CheckState.Unchecked
            ElseIf clbCostCenter.CheckedItems.Count = clbCostCenter.Items.Count Then
                chkAll.CheckState = CheckState.Checked
            Else
                chkAll.CheckState = CheckState.Indeterminate
            End If
            checking = False
        End Sub

        Private Sub ibtnUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnUp.Click
            Dim code As String = clbCostCenter.SelectedItem.ToString
            Dim index As Integer = clbCostCenter.SelectedIndex
            Dim chk As Boolean = clbCostCenter.CheckedItems.Contains(clbCostCenter.SelectedItem)
            Dim swap As Object = clbCostCenter.SelectedItem
            If Not (swap Is Nothing) AndAlso index >= 1 Then               'If something is selected...
                clbCostCenter.Items.RemoveAt(index)                   'Remove it
                clbCostCenter.Items.Insert(index - 1, swap)           'Add it back in one spot up
                clbCostCenter.SetItemChecked(index - 1, chk)
                clbCostCenter.SelectedItem = swap                     'Keep this item selected

            End If

        End Sub

        Private Sub ibtnDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnDown.Click
            Dim index As Integer = clbCostCenter.SelectedIndex
            Dim swap As Object = clbCostCenter.SelectedItem
            Dim chk As Boolean = clbCostCenter.CheckedItems.Contains(clbCostCenter.SelectedItem)
            If Not (swap Is Nothing) AndAlso index < clbCostCenter.Items.Count - 1 Then     'If something is selected...
                clbCostCenter.Items.RemoveAt(index)                   'Remove it
                clbCostCenter.Items.Insert(index + 1, swap)           'Add it back in one spot up
                clbCostCenter.SetItemChecked(index + 1, chk)
                clbCostCenter.SelectedItem = swap                     'Keep this item selected
            End If
        End Sub
#End Region

    End Class

End Namespace

