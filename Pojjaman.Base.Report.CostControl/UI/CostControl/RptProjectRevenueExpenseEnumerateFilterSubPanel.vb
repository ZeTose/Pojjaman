Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Imports System.Collections.Generic
Imports Longkong.Pojjaman.Gui.Components
Imports Syncfusion.XlsIO

Namespace Longkong.Pojjaman.Gui.Panels
  Public Class RptProjectRevenueExpenseEnumerateFilterSubPanel
    Inherits AbstractFilterSubPanel
    'Inherits UserControl
    Implements IReportFilterSubPanel, IExcellExportAble


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
    Friend WithEvents grbProject As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents txtDocDateEnd As System.Windows.Forms.TextBox
    Friend WithEvents dtpDocDateEnd As System.Windows.Forms.DateTimePicker
    Friend WithEvents chkNoDigit As System.Windows.Forms.CheckBox
    Friend WithEvents grbPeriod As System.Windows.Forms.GroupBox
    Friend WithEvents lblDocEndDate As System.Windows.Forms.Label
    Friend WithEvents txtDocStartDate As System.Windows.Forms.TextBox
    Friend WithEvents dtpDocStartDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents ibtnUp As System.Windows.Forms.Button
    Friend WithEvents ibtnDown As System.Windows.Forms.Button
    Friend WithEvents clbCostCenter As System.Windows.Forms.CheckedListBox
    Friend WithEvents chkIncClose As System.Windows.Forms.CheckBox
    Friend WithEvents chkOnlyChecked As System.Windows.Forms.CheckBox
    Friend WithEvents chkAll As System.Windows.Forms.CheckBox
    Friend WithEvents grbViews As System.Windows.Forms.GroupBox
    Friend WithEvents clbDataViews As System.Windows.Forms.CheckedListBox
    Friend WithEvents ibtnSaveAsExcel As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents btnSearchProject As System.Windows.Forms.Button
    Friend WithEvents txtSearchProject As System.Windows.Forms.TextBox
    Friend WithEvents lblDocStartDate As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RptProjectRevenueExpenseEnumerateFilterSubPanel))
      Me.grbMaster = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.chkNoDigit = New System.Windows.Forms.CheckBox()
      Me.grbViews = New System.Windows.Forms.GroupBox()
      Me.clbDataViews = New System.Windows.Forms.CheckedListBox()
      Me.grbPeriod = New System.Windows.Forms.GroupBox()
      Me.lblDocEndDate = New System.Windows.Forms.Label()
      Me.txtDocStartDate = New System.Windows.Forms.TextBox()
      Me.dtpDocStartDate = New System.Windows.Forms.DateTimePicker()
      Me.lblDocStartDate = New System.Windows.Forms.Label()
      Me.txtDocDateEnd = New System.Windows.Forms.TextBox()
      Me.dtpDocDateEnd = New System.Windows.Forms.DateTimePicker()
      Me.grbProject = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.chkAll = New System.Windows.Forms.CheckBox()
      Me.chkIncClose = New System.Windows.Forms.CheckBox()
      Me.chkOnlyChecked = New System.Windows.Forms.CheckBox()
      Me.clbCostCenter = New System.Windows.Forms.CheckedListBox()
      Me.btnSearch = New System.Windows.Forms.Button()
      Me.btnReset = New System.Windows.Forms.Button()
      Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
      Me.ibtnSaveAsExcel = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.ibtnDown = New System.Windows.Forms.Button()
      Me.ibtnUp = New System.Windows.Forms.Button()
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
      Me.txtSearchProject = New System.Windows.Forms.TextBox()
      Me.btnSearchProject = New System.Windows.Forms.Button()
      Me.grbMaster.SuspendLayout()
      Me.grbViews.SuspendLayout()
      Me.grbPeriod.SuspendLayout()
      Me.grbProject.SuspendLayout()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'grbMaster
      '
      Me.grbMaster.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
              Or System.Windows.Forms.AnchorStyles.Left) _
              Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.grbMaster.Controls.Add(Me.ibtnSaveAsExcel)
      Me.grbMaster.Controls.Add(Me.chkNoDigit)
      Me.grbMaster.Controls.Add(Me.grbViews)
      Me.grbMaster.Controls.Add(Me.grbPeriod)
      Me.grbMaster.Controls.Add(Me.grbProject)
      Me.grbMaster.Controls.Add(Me.btnSearch)
      Me.grbMaster.Controls.Add(Me.btnReset)
      Me.grbMaster.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbMaster.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.grbMaster.Location = New System.Drawing.Point(8, -1)
      Me.grbMaster.Name = "grbMaster"
      Me.grbMaster.Size = New System.Drawing.Size(618, 232)
      Me.grbMaster.TabIndex = 0
      Me.grbMaster.TabStop = False
      '
      'chkNoDigit
      '
      Me.chkNoDigit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.chkNoDigit.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.chkNoDigit.Location = New System.Drawing.Point(451, 30)
      Me.chkNoDigit.Name = "chkNoDigit"
      Me.chkNoDigit.Size = New System.Drawing.Size(100, 24)
      Me.chkNoDigit.TabIndex = 6
      Me.chkNoDigit.Text = "ไม่แสดงทศนิยม"
      '
      'grbViews
      '
      Me.grbViews.Controls.Add(Me.clbDataViews)
      Me.grbViews.Location = New System.Drawing.Point(522, 85)
      Me.grbViews.Name = "grbViews"
      Me.grbViews.Size = New System.Drawing.Size(184, 59)
      Me.grbViews.TabIndex = 7
      Me.grbViews.TabStop = False
      Me.grbViews.Text = "แสดงข้อมูล"
      Me.grbViews.Visible = False
      '
      'clbDataViews
      '
      Me.clbDataViews.FormattingEnabled = True
      Me.clbDataViews.Location = New System.Drawing.Point(6, 15)
      Me.clbDataViews.Name = "clbDataViews"
      Me.clbDataViews.Size = New System.Drawing.Size(162, 36)
      Me.clbDataViews.TabIndex = 0
      '
      'grbPeriod
      '
      Me.grbPeriod.Controls.Add(Me.lblDocEndDate)
      Me.grbPeriod.Controls.Add(Me.txtDocStartDate)
      Me.grbPeriod.Controls.Add(Me.dtpDocStartDate)
      Me.grbPeriod.Controls.Add(Me.lblDocStartDate)
      Me.grbPeriod.Controls.Add(Me.txtDocDateEnd)
      Me.grbPeriod.Controls.Add(Me.dtpDocDateEnd)
      Me.grbPeriod.Location = New System.Drawing.Point(522, 10)
      Me.grbPeriod.Name = "grbPeriod"
      Me.grbPeriod.Size = New System.Drawing.Size(184, 69)
      Me.grbPeriod.TabIndex = 3
      Me.grbPeriod.TabStop = False
      Me.grbPeriod.Text = "ต้องการเป็นช่วงเวลา"
      Me.grbPeriod.Visible = False
      '
      'lblDocEndDate
      '
      Me.lblDocEndDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDocEndDate.ForeColor = System.Drawing.Color.Black
      Me.lblDocEndDate.Location = New System.Drawing.Point(9, 40)
      Me.lblDocEndDate.Name = "lblDocEndDate"
      Me.lblDocEndDate.Size = New System.Drawing.Size(78, 18)
      Me.lblDocEndDate.TabIndex = 24
      Me.lblDocEndDate.Text = "ถึงวันที่:"
      Me.lblDocEndDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtDocStartDate
      '
      Me.Validator.SetDataType(Me.txtDocStartDate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtDocStartDate, "")
      Me.Validator.SetGotFocusBackColor(Me.txtDocStartDate, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtDocStartDate, -15)
      Me.Validator.SetInvalidBackColor(Me.txtDocStartDate, System.Drawing.Color.Empty)
      Me.txtDocStartDate.Location = New System.Drawing.Point(87, 18)
      Me.txtDocStartDate.MaxLength = 10
      Me.Validator.SetMaxValue(Me.txtDocStartDate, "")
      Me.Validator.SetMinValue(Me.txtDocStartDate, "")
      Me.txtDocStartDate.Name = "txtDocStartDate"
      Me.Validator.SetRegularExpression(Me.txtDocStartDate, "")
      Me.Validator.SetRequired(Me.txtDocStartDate, False)
      Me.txtDocStartDate.Size = New System.Drawing.Size(67, 21)
      Me.txtDocStartDate.TabIndex = 20
      '
      'dtpDocStartDate
      '
      Me.dtpDocStartDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpDocStartDate.Location = New System.Drawing.Point(86, 18)
      Me.dtpDocStartDate.Name = "dtpDocStartDate"
      Me.dtpDocStartDate.Size = New System.Drawing.Size(88, 21)
      Me.dtpDocStartDate.TabIndex = 22
      Me.dtpDocStartDate.TabStop = False
      '
      'lblDocStartDate
      '
      Me.lblDocStartDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDocStartDate.ForeColor = System.Drawing.Color.Black
      Me.lblDocStartDate.Location = New System.Drawing.Point(13, 18)
      Me.lblDocStartDate.Name = "lblDocStartDate"
      Me.lblDocStartDate.Size = New System.Drawing.Size(74, 18)
      Me.lblDocStartDate.TabIndex = 21
      Me.lblDocStartDate.Text = "จากวันที่:"
      Me.lblDocStartDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtDocDateEnd
      '
      Me.Validator.SetDataType(Me.txtDocDateEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtDocDateEnd, "")
      Me.Validator.SetGotFocusBackColor(Me.txtDocDateEnd, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtDocDateEnd, -15)
      Me.Validator.SetInvalidBackColor(Me.txtDocDateEnd, System.Drawing.Color.Empty)
      Me.txtDocDateEnd.Location = New System.Drawing.Point(86, 40)
      Me.txtDocDateEnd.MaxLength = 10
      Me.Validator.SetMaxValue(Me.txtDocDateEnd, "")
      Me.Validator.SetMinValue(Me.txtDocDateEnd, "")
      Me.txtDocDateEnd.Name = "txtDocDateEnd"
      Me.Validator.SetRegularExpression(Me.txtDocDateEnd, "")
      Me.Validator.SetRequired(Me.txtDocDateEnd, False)
      Me.txtDocDateEnd.Size = New System.Drawing.Size(67, 21)
      Me.txtDocDateEnd.TabIndex = 2
      '
      'dtpDocDateEnd
      '
      Me.dtpDocDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpDocDateEnd.Location = New System.Drawing.Point(86, 40)
      Me.dtpDocDateEnd.Name = "dtpDocDateEnd"
      Me.dtpDocDateEnd.Size = New System.Drawing.Size(88, 21)
      Me.dtpDocDateEnd.TabIndex = 17
      Me.dtpDocDateEnd.TabStop = False
      '
      'grbProject
      '
      Me.grbProject.Controls.Add(Me.btnSearchProject)
      Me.grbProject.Controls.Add(Me.txtSearchProject)
      Me.grbProject.Controls.Add(Me.chkAll)
      Me.grbProject.Controls.Add(Me.chkIncClose)
      Me.grbProject.Controls.Add(Me.ibtnDown)
      Me.grbProject.Controls.Add(Me.chkOnlyChecked)
      Me.grbProject.Controls.Add(Me.clbCostCenter)
      Me.grbProject.Controls.Add(Me.ibtnUp)
      Me.grbProject.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbProject.Location = New System.Drawing.Point(16, 11)
      Me.grbProject.Name = "grbProject"
      Me.grbProject.Size = New System.Drawing.Size(429, 211)
      Me.grbProject.TabIndex = 0
      Me.grbProject.TabStop = False
      Me.grbProject.Text = "โครงการ"
      '
      'chkAll
      '
      Me.chkAll.AutoSize = True
      Me.chkAll.Location = New System.Drawing.Point(10, 191)
      Me.chkAll.Name = "chkAll"
      Me.chkAll.Size = New System.Drawing.Size(85, 17)
      Me.chkAll.TabIndex = 24
      Me.chkAll.Text = "เลือกทั้งหมด"
      Me.chkAll.UseMnemonic = False
      Me.chkAll.UseVisualStyleBackColor = True
      '
      'chkIncClose
      '
      Me.chkIncClose.AutoSize = True
      Me.chkIncClose.Location = New System.Drawing.Point(299, 145)
      Me.chkIncClose.Name = "chkIncClose"
      Me.chkIncClose.Size = New System.Drawing.Size(123, 17)
      Me.chkIncClose.TabIndex = 23
      Me.chkIncClose.Text = "รวมโครงการที่ปิดแล้ว"
      Me.chkIncClose.UseVisualStyleBackColor = True
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
      'btnSearch
      '
      Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnSearch.Location = New System.Drawing.Point(532, 202)
      Me.btnSearch.Name = "btnSearch"
      Me.btnSearch.Size = New System.Drawing.Size(80, 23)
      Me.btnSearch.TabIndex = 2
      Me.btnSearch.Text = "ค้นหา"
      '
      'btnReset
      '
      Me.btnReset.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnReset.Location = New System.Drawing.Point(451, 202)
      Me.btnReset.Name = "btnReset"
      Me.btnReset.Size = New System.Drawing.Size(80, 23)
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
      'ibtnSaveAsExcel
      '
      Me.ibtnSaveAsExcel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.ibtnSaveAsExcel.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnSaveAsExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.ibtnSaveAsExcel.Location = New System.Drawing.Point(451, 71)
      Me.ibtnSaveAsExcel.Name = "ibtnSaveAsExcel"
      Me.ibtnSaveAsExcel.Size = New System.Drawing.Size(88, 32)
      Me.ibtnSaveAsExcel.TabIndex = 20
      Me.ibtnSaveAsExcel.TabStop = False
      Me.ibtnSaveAsExcel.Text = "  Export"
      Me.ibtnSaveAsExcel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.ibtnSaveAsExcel.ThemedImage = CType(resources.GetObject("ibtnSaveAsExcel.ThemedImage"), System.Drawing.Bitmap)
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
      'ibtnUp
      '
      Me.ibtnUp.Image = Global.My.Resources.Resources.Actions_go_up_icon32
      Me.ibtnUp.Location = New System.Drawing.Point(299, 41)
      Me.ibtnUp.Name = "ibtnUp"
      Me.ibtnUp.Size = New System.Drawing.Size(34, 37)
      Me.ibtnUp.TabIndex = 19
      Me.ibtnUp.UseVisualStyleBackColor = False
      '
      'ErrorProvider1
      '
      Me.ErrorProvider1.ContainerControl = Me
      '
      'txtSearchProject
      '
      Me.Validator.SetDataType(Me.txtSearchProject, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtSearchProject, "")
      Me.Validator.SetGotFocusBackColor(Me.txtSearchProject, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtSearchProject, System.Drawing.Color.Empty)
      Me.txtSearchProject.Location = New System.Drawing.Point(7, 17)
      Me.Validator.SetMaxValue(Me.txtSearchProject, "")
      Me.Validator.SetMinValue(Me.txtSearchProject, "")
      Me.txtSearchProject.Name = "txtSearchProject"
      Me.Validator.SetRegularExpression(Me.txtSearchProject, "")
      Me.Validator.SetRequired(Me.txtSearchProject, False)
      Me.txtSearchProject.Size = New System.Drawing.Size(235, 21)
      Me.txtSearchProject.TabIndex = 25
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
      'RptProjectRevenueExpenseEnumerateFilterSubPanel
      '
      Me.Controls.Add(Me.grbMaster)
      Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Name = "RptProjectRevenueExpenseEnumerateFilterSubPanel"
      Me.Size = New System.Drawing.Size(634, 239)
      Me.grbMaster.ResumeLayout(False)
      Me.grbViews.ResumeLayout(False)
      Me.grbPeriod.ResumeLayout(False)
      Me.grbPeriod.PerformLayout()
      Me.grbProject.ResumeLayout(False)
      Me.grbProject.PerformLayout()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

    End Sub

#End Region

#Region " SetLabelText "
    Public Sub SetLabelText()

      'Me.lblType.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptWBSMonitorFilterSubPanel.lblType}")

      'Me.lblCostCenter.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptWBSMonitorFilterSubPanel.lblCostCenter}")
      'Me.Validator.SetDisplayName(txtStartCostCenterCode, lblCostCenter.Text)



      ' Global {ถึง}
      'Me.lblDocDateEnd.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")
      'Me.Validator.SetDisplayName(txtDocDateEnd, lblDocDateEnd.Text)

      ' Button
      Me.btnSearch.Text = Me.StringParserService.Parse("${res:Global.SearchButtonText}")
      Me.btnReset.Text = Me.StringParserService.Parse("${res:Global.ResetButtonText}")

      ' GroupBox
      Me.grbMaster.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptWBSMonitorFilterSubPanel.grbMaster}")
      Me.grbProject.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptWBSMonitorFilterSubPanel.grbProject}")

      Me.chkNoDigit.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptWBSMonitorFilterSubPanel.chkNoDigit}")
    End Sub
#End Region

#Region "Member"
    Private m_DocDateEnd As Date
    Private m_DocDateStart As Date


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
      clbDataViews.CheckOnClick = True

      SetLabelText()
      LoopControl(Me)
    End Sub
#End Region

#Region "Properties"

    Public Property DocDateEnd() As Date      Get        Return m_DocDateEnd      End Get      Set(ByVal Value As Date)        m_DocDateEnd = Value      End Set    End Property    Public Property DocDateStart() As Date      Get        Return m_DocDateStart      End Get      Set(ByVal Value As Date)        m_DocDateStart = Value      End Set    End Property#End Region

#Region "Methods"
    Private Sub btnSearchProject_Click(sender As Object, e As System.EventArgs) Handles btnSearchProject.Click
      If txtSearchProject.Text.Trim.Length = 0 Then
        RefreshCheckCCListBox()
      Else
        RefreshCheckCCListBoxFilter(txtSearchProject.Text.Trim)
      End If
    End Sub
    Private Sub RefreshCheckCCListBoxFilter(textFilter As String)
      Dim notonlychecked As Boolean = Not chkOnlyChecked.Checked
      Dim IncClose As Boolean = chkIncClose.Checked

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
        If (kv.Value.IsActive OrElse IncClose) AndAlso (notonlychecked OrElse chkCode.Contains(kv.Key)) Then
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
    Private Sub LoadCostCenter() Handles chkIncClose.CheckedChanged
      Dim currentuserid As Integer = CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id

      CCList = New Dictionary(Of String, CostCenter)


      CCList = CostCenter.CostCenterRightList(currentuserid)


      RefreshCheckCCListBox()

      'clbCostCenter.Items.Clear()

      'Dim i As Integer = 0
      'If CCList.Count > 0 Then
      '  For Each kv As KeyValuePair(Of String, CostCenter) In CCList
      '    If kv.Value.IsActive OrElse IncClose Then
      '      Dim list As String = kv.Value.Code & ":" & kv.Value.Name
      '      clbCostCenter.Items.Add(list, True)
      '      CCIndexList.Add(i, kv.Value.Code)
      '      clbCostCenter.Items(0).tag = kv.Value
      '      i += 1
      '    End If
      '  Next

      'End If

    End Sub
    Private Sub Initialize()
      CCIndexList = New Dictionary(Of Integer, Integer)
      LoadCostCenter()
      LoadDataViews()
      ClearCriterias()
    End Sub
    Private Sub LoadDataViews()

      Dim idp As IdValuePair

      With clbDataViews
        .Items.Clear()
        idp = New IdValuePair(7, Me.StringParserService.Parse("${res:Global.AllocationType.PR}"))
        .Items.Add(idp, True)
        idp = New IdValuePair(6, Me.StringParserService.Parse("${res:Global.AllocationType.PO}"))
        .Items.Add(idp, True)
        idp = New IdValuePair(45, Me.StringParserService.Parse("${res:Global.AllocationType.GR}"))
        .Items.Add(idp, True)
        idp = New IdValuePair(31, Me.StringParserService.Parse("${res:Global.AllocationType.MR}"))
        .Items.Add(idp, True)

      End With

    End Sub
    Private Function CheckedViewsString() As String
      Dim chkView As New List(Of String)
      For Each chki As Object In clbDataViews.CheckedItems
        Dim i As Integer = CType(chki, IdValuePair).Id
        chkView.Add("|" & i.ToString & "|")
      Next
      Return String.Join(",", chkView)
    End Function
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
      m_dateSetting = True

      Me.DocDateStart = Date.MinValue
      Me.txtDocStartDate.Text = MinDateToNull(Me.DocDateStart, "")
      Me.dtpDocStartDate.Value = Date.Now

      Me.DocDateEnd = Date.Now
      Me.txtDocDateEnd.Text = MinDateToNull(Me.DocDateEnd, "")
      Me.dtpDocDateEnd.Value = Me.DocDateEnd


      chkAll.Checked = False
      chkIncClose.Checked = False
      chkOnlyChecked.Checked = False
      chkNoDigit.Checked = False


      'Me.CCIndexList = ""
      Me.CCIdList = ""

      For i As Integer = 0 To Me.clbDataViews.Items.Count - 1
        Me.clbDataViews.SetItemChecked(i, True)
      Next

      'Try
      '  If Me.cmbType.Items.Count > 0 Then
      '    Me.cmbType.SelectedIndex = 1
      '  End If
      '  If Me.cmbReportType.Items.Count > 0 Then
      '    Me.cmbReportType.SelectedIndex = 0
      '  End If
      'Catch ex As Exception

      'End Try
    End Sub
    Public Overrides Function GetFilterString() As String

    End Function
    Public Overrides Function GetFilterArray() As Filter()


      Dim arr(1) As Filter
      arr(0) = New Filter("CCCodeList", CheckedCCListString)
      'arr(1) = New Filter("DocDateEnd", IIf(Me.DocDateEnd.Equals(Date.MinValue), DBNull.Value, Me.DocDateEnd))
      arr(1) = New Filter("NoDigit", Me.chkNoDigit.Checked)
      'arr(3) = New Filter("DocDateStart", IIf(Me.DocDateStart.Equals(Date.MinValue), DBNull.Value, Me.DocDateStart))
      'arr(4) = New Filter("DataViews", CheckedViewsString)

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
      'AddHandler txtDocEndDate.Validated, AddressOf Me.ChangeProperty
      'AddHandler dtpDocEndDate.ValueChanged, AddressOf Me.ChangeProperty
      AddHandler txtDocStartDate.Validated, AddressOf Me.ChangeProperty
      AddHandler dtpDocStartDate.ValueChanged, AddressOf Me.ChangeProperty

    End Sub

    Private m_dateSetting As Boolean
    Private Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)

      Select Case CType(sender, Control).Name.ToLower
        Case "dtpdocdateend"
          If Not Me.DocDateEnd.Equals(dtpDocDateEnd.Value) Then
            If Not m_dateSetting Then
              Me.txtDocDateEnd.Text = MinDateToNull(dtpDocDateEnd.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
              Me.DocDateEnd = dtpDocDateEnd.Value
              'Me.txtDocEndDate.Text = MinDateToNull(Me.DocDateEnd, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
            End If
          End If
          m_dateSetting = False
        Case "txtdocdateend"
          m_dateSetting = True
          If Not Me.txtDocDateEnd.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtDocDateEnd) = "" Then
            Dim theDate As Date = CDate(Me.txtDocDateEnd.Text)
            If Not Me.DocDateEnd.Equals(theDate) Then
              dtpDocDateEnd.Value = theDate
              Me.DocDateEnd = dtpDocDateEnd.Value
              'Me.txtDocEndDate.Text = MinDateToNull(Me.DocDateEnd, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
            End If
          Else
            Me.dtpDocDateEnd.Value = Date.Now
            Me.DocDateEnd = Date.MinValue
          End If
          m_dateSetting = False
          'Case "dtpdocenddate"
          '  If Not Me.DocDateEnd.Equals(dtpDocEndDate.Value) Then
          '    If Not m_dateSetting Then
          '      Me.txtDocEndDate.Text = MinDateToNull(dtpDocEndDate.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
          '      Me.txtDocDateEnd.Text = MinDateToNull(dtpDocEndDate.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
          '      Me.DocDateEnd = dtpDocEndDate.Value
          '    End If
          '  End If
          '  m_dateSetting = False
          'Case "txtdocenddate"
          '  m_dateSetting = True
          '  If Not Me.txtDocEndDate.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtDocEndDate) = "" Then
          '    Dim theDate As Date = CDate(Me.txtDocEndDate.Text)
          '    If Not Me.DocDateEnd.Equals(theDate) Then
          '      dtpDocEndDate.Value = theDate
          '      Me.txtDocDateEnd.Text = MinDateToNull(dtpDocEndDate.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
          '      Me.DocDateEnd = dtpDocEndDate.Value
          '      Me.txtDocEndDate.Text = MinDateToNull(Me.DocDateEnd, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
          '    End If
          '  Else
          '    Me.dtpDocDateEnd.Value = Date.Now
          '    Me.DocDateEnd = Date.MinValue
          '  End If
          '  m_dateSetting = False
        Case "dtpdocstartdate"
          If Not Me.DocDateStart.Equals(dtpDocStartDate.Value) Then
            If Not m_dateSetting Then
              Me.txtDocStartDate.Text = MinDateToNull(dtpDocStartDate.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
              Me.DocDateStart = dtpDocStartDate.Value
            End If
          End If
          m_dateSetting = False
        Case "txtdocstartdate"
          m_dateSetting = True
          If Not Me.txtDocStartDate.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtDocStartDate) = "" Then
            Dim theDate As Date = CDate(Me.txtDocStartDate.Text)
            If Not Me.DocDateStart.Equals(theDate) Then
              dtpDocStartDate.Value = theDate
              Me.DocDateStart = dtpDocStartDate.Value
            End If
          Else
            Me.dtpDocStartDate.Value = Date.Now
            Me.DocDateStart = Date.MinValue
          End If
          m_dateSetting = False

        Case Else

      End Select
    End Sub
#End Region

#Region "IClipboardHandler Overrides"
    'Public Overrides ReadOnly Property EnablePaste() As Boolean
    '  Get
    '    Dim data As IDataObject = Clipboard.GetDataObject
    '    If data.GetDataPresent(m_startcc.FullClassName) Then
    '      If Not Me.ActiveControl Is Nothing Then
    '        Select Case Me.ActiveControl.Name.ToLower

    '          Case "txttoccstart", "txttoccend"
    '            Return True
    '        End Select
    '      End If
    '    End If
    '    'If data.GetDataPresent(m_requestor.FullClassName) Then
    '    '    If Not Me.ActiveControl Is Nothing Then
    '    '        Select Case Me.ActiveControl.Name.ToLower

    '    '            Case "txtrequestorcode"
    '    '                Return True
    '    '        End Select
    '    '    End If
    '    'End If
    '  End Get
    'End Property
    'Public Overrides Sub Paste(ByVal sender As Object, ByVal e As System.EventArgs)
    '  Dim data As IDataObject = Clipboard.GetDataObject
    '  If data.GetDataPresent(m_startcc.FullClassName) Then
    '    Dim id As Integer = CInt(data.GetData(m_startcc.FullClassName))
    '    Dim entity As New CostCenter(id)
    '    If Not Me.ActiveControl Is Nothing Then
    '      Select Case Me.ActiveControl.Name.ToLower

    '        Case "txttoccstart"
    '          Me.SetStartCostCenter(entity)


    '      End Select
    '    End If
    '    'If Not Me.ActiveControl Is Nothing Then
    '    '    Select Case Me.ActiveControl.Name.ToLower

    '    '        Case "txtrequestorcode"
    '    '            Me.SetEmployee(entity)


    '    '    End Select
    '    'End If
    '  End If
    'End Sub
#End Region

#Region " Event Handlers "
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
      Dim IncClose As Boolean = chkIncClose.Checked

      Dim chkCode As New List(Of String)
      For Each chki As Object In clbCostCenter.CheckedItems
        Dim s As String = chki.ToString.Split(":")(0)
        chkCode.Add(s)
      Next

      clbCostCenter.Items.Clear()
      For Each kv As KeyValuePair(Of String, CostCenter) In CCList
        If (kv.Value.IsActive OrElse IncClose) AndAlso (notonlychecked OrElse chkCode.Contains(kv.Key)) Then
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


    'Private Sub txtToCostCenterCode_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '  Select Case CType(sender, Control).Name.ToLower
    '    Case "txtstartcostcentercode"
    '      CostCenter.GetCostCenter(txtStartCostCenterCode, Me.txtStartCostCenterName, Me.m_startcc)
    '    Case "txtendcostcentercode"
    '      CostCenter.GetCostCenter(txtEndCostcenterCode, Me.txtEndCostcenterName, Me.m_endcc)
    '  End Select

    'End Sub

    'Private Sub btnShowCostCenter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '  Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
    '  Select Case CType(sender, Control).Name.ToLower
    '    Case "btnshowstartcostcenter"
    '      myEntityPanelService.OpenListDialog(New CostCenter, AddressOf SetStartCostCenter)
    '    Case "btnshowendcostcenter"
    '      myEntityPanelService.OpenListDialog(New CostCenter, AddressOf SetEndCostCenter)
    '  End Select
    'End Sub

    'Private Sub SetStartCostCenter(ByVal e As ISimpleEntity)
    '  Me.txtStartCostCenterCode.Text = e.Code
    '  CostCenter.GetCostCenter(txtStartCostCenterCode, txtStartCostCenterName, Me.m_startcc)
    'End Sub
    'Private Sub SetEndCostCenter(ByVal e As ISimpleEntity)
    '  Me.txtEndCostcenterCode.Text = e.Code
    '  CostCenter.GetCostCenter(txtEndCostcenterCode, txtEndCostcenterName, Me.m_endcc)
    'End Sub
#End Region

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

#Region "Export Excel"

    Private m_tgItem As LKGrid
    Public Property tgItem As Components.LKGrid Implements IExcellExportAble.tgItem
      Get
        Return m_tgItem
      End Get
      Set(ByVal value As Components.LKGrid)
        m_tgItem = value
      End Set
    End Property
    Public Sub xlsexport()
      Dim xl As ExcelEngine = New ExcelEngine()
      Dim dialog1 As SaveFileDialog = New SaveFileDialog
      Dim ctime As Date

      ctime = CDate(IIf(Me.DocDateEnd.Equals(Date.MinValue), Date.Now, Me.DocDateEnd))
      Dim filename As String = "Export " & "RptProjectRevenueExpenseEnumerate" & ctime.ToString("yyyyMMdd") & ".xls"
      dialog1.OverwritePrompt = True
      dialog1.AddExtension = True
      dialog1.Filter = "Microsoft Excel (*.xls)|*.xls|All files|*.*"
      dialog1.FileName = filename
      If dialog1.ShowDialog = DialogResult.OK Then
        filename = dialog1.FileName
      Else
        Return
      End If

      Using xl
        'instantiate excel application object
        Dim xlApp As IApplication = xl.Excel


        'create a new workbook with 2 worksheets
        Dim wkbk As IWorkbook = xl.Excel.Workbooks.Create(1)


        'get a reference to both worksheets
        Dim sht1 As IWorksheet = wkbk.Worksheets(0)


        wkbk.Worksheets(0).Name = "RptProjectRevenueExpenseEnumerate"


        'add data to the first cell of each worksheet
        'sht1.Range("A1").Text = "Hello World"
        'sht2.Range("A1").Text = "Hello World 2"

        For i As Integer = 1 To tgItem.RowCount
          For j As Integer = 2 To tgItem.ColCount
            If tgItem(i, j).Text.Length > 0 AndAlso Configuration.IsFormatString(tgItem(i, j).Text, DigitConfig.Price) Then
              Replace(tgItem(i, j).Text, "(", "")
              Replace(tgItem(i, j).Text, ")", "")
              sht1.Range(i, j).Value = CStr(CDec(tgItem(i, j).Text))
            Else
              sht1.Range(i, j).Text = tgItem(i, j).Text

            End If
          Next
        Next



        wkbk.SaveAs(filename)
        wkbk.Close()
      End Using
      MessageBox.Show("Finish!")

    End Sub
    Private Sub ibtnSaveAsExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnSaveAsExcel.Click
      Try
        xlsexport()

      Catch ex As Exception
        MessageBox.Show(ex.Message)
      End Try
    End Sub

#End Region

    Private Sub chkNoDigit_CheckedChanged(sender As Object, e As System.EventArgs) Handles chkNoDigit.CheckedChanged

    End Sub
  End Class

End Namespace

