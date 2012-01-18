Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.PanelDisplayBinding
Imports Longkong.Pojjaman.Gui
Imports Longkong.Pojjaman.Gui.Pads
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Core.Properties

Namespace Longkong.Pojjaman.Gui.Panels
  Public Class CrystalReportPanelView
    'Inherits UserControl
    Inherits AbstractEntityPanelViewContent
    Implements ISimpleListPanel

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
    Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents btnExport As System.Windows.Forms.Button
    Friend WithEvents Splitter2 As System.Windows.Forms.Splitter
    Friend WithEvents pnlFilter As System.Windows.Forms.Panel
    Friend WithEvents lblPage As System.Windows.Forms.Label
    Friend WithEvents btnNext As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents btnFirst As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents btnLast As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents btnBack As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents trZoom As System.Windows.Forms.TrackBar
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents btnSearch As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents btnFit As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtCurrentPage As System.Windows.Forms.TextBox
    Friend WithEvents cmbReportName As System.Windows.Forms.ComboBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
      Me.GroupBox1 = New System.Windows.Forms.GroupBox()
      Me.Panel2 = New System.Windows.Forms.Panel()
      Me.txtCurrentPage = New System.Windows.Forms.TextBox()
      Me.txtSearch = New System.Windows.Forms.TextBox()
      Me.lblPage = New System.Windows.Forms.Label()
      Me.btnExport = New System.Windows.Forms.Button()
      Me.btnNext = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.btnFirst = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.btnFit = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.btnSearch = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.btnLast = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.btnBack = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.btnPrint = New System.Windows.Forms.Button()
      Me.trZoom = New System.Windows.Forms.TrackBar()
      Me.Splitter2 = New System.Windows.Forms.Splitter()
      Me.pnlFilter = New System.Windows.Forms.Panel()
      Me.cmbReportName = New System.Windows.Forms.ComboBox()
      Me.GroupBox1.SuspendLayout()
      Me.Panel2.SuspendLayout()
      CType(Me.trZoom, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'CrystalReportViewer1
      '
      Me.CrystalReportViewer1.ActiveViewIndex = -1
      Me.CrystalReportViewer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.CrystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.CrystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default
      Me.CrystalReportViewer1.DisplayToolbar = False
      Me.CrystalReportViewer1.EnableDrillDown = False
      Me.CrystalReportViewer1.Location = New System.Drawing.Point(6, 29)
      Me.CrystalReportViewer1.Name = "CrystalReportViewer1"
      Me.CrystalReportViewer1.Size = New System.Drawing.Size(744, 426)
      Me.CrystalReportViewer1.TabIndex = 2
      Me.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
      '
      'GroupBox1
      '
      Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.GroupBox1.Controls.Add(Me.Panel2)
      Me.GroupBox1.Controls.Add(Me.Splitter2)
      Me.GroupBox1.Controls.Add(Me.pnlFilter)
      Me.GroupBox1.Location = New System.Drawing.Point(7, 2)
      Me.GroupBox1.Name = "GroupBox1"
      Me.GroupBox1.Size = New System.Drawing.Size(890, 479)
      Me.GroupBox1.TabIndex = 3
      Me.GroupBox1.TabStop = False
      '
      'Panel2
      '
      Me.Panel2.Controls.Add(Me.cmbReportName)
      Me.Panel2.Controls.Add(Me.txtCurrentPage)
      Me.Panel2.Controls.Add(Me.txtSearch)
      Me.Panel2.Controls.Add(Me.lblPage)
      Me.Panel2.Controls.Add(Me.btnExport)
      Me.Panel2.Controls.Add(Me.CrystalReportViewer1)
      Me.Panel2.Controls.Add(Me.btnNext)
      Me.Panel2.Controls.Add(Me.btnFirst)
      Me.Panel2.Controls.Add(Me.btnFit)
      Me.Panel2.Controls.Add(Me.btnSearch)
      Me.Panel2.Controls.Add(Me.btnLast)
      Me.Panel2.Controls.Add(Me.btnBack)
      Me.Panel2.Controls.Add(Me.btnPrint)
      Me.Panel2.Controls.Add(Me.trZoom)
      Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
      Me.Panel2.Location = New System.Drawing.Point(3, 16)
      Me.Panel2.Name = "Panel2"
      Me.Panel2.Size = New System.Drawing.Size(756, 460)
      Me.Panel2.TabIndex = 3
      '
      'txtCurrentPage
      '
      Me.txtCurrentPage.Location = New System.Drawing.Point(197, 5)
      Me.txtCurrentPage.Name = "txtCurrentPage"
      Me.txtCurrentPage.Size = New System.Drawing.Size(31, 20)
      Me.txtCurrentPage.TabIndex = 19
      Me.txtCurrentPage.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtSearch
      '
      Me.txtSearch.Location = New System.Drawing.Point(270, 5)
      Me.txtSearch.Name = "txtSearch"
      Me.txtSearch.Size = New System.Drawing.Size(140, 20)
      Me.txtSearch.TabIndex = 19
      '
      'lblPage
      '
      Me.lblPage.AutoSize = True
      Me.lblPage.Location = New System.Drawing.Point(227, 8)
      Me.lblPage.Name = "lblPage"
      Me.lblPage.Size = New System.Drawing.Size(18, 13)
      Me.lblPage.TabIndex = 17
      Me.lblPage.Text = "/0"
      '
      'btnExport
      '
      Me.btnExport.Location = New System.Drawing.Point(54, 3)
      Me.btnExport.Name = "btnExport"
      Me.btnExport.Size = New System.Drawing.Size(47, 23)
      Me.btnExport.TabIndex = 16
      Me.btnExport.Text = "Export"
      Me.btnExport.UseVisualStyleBackColor = True
      '
      'btnNext
      '
      Me.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnNext.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnNext.Location = New System.Drawing.Point(149, 3)
      Me.btnNext.Name = "btnNext"
      Me.btnNext.Size = New System.Drawing.Size(24, 24)
      Me.btnNext.TabIndex = 14
      Me.btnNext.TabStop = False
      Me.btnNext.Text = ">"
      Me.btnNext.ThemedImage = Nothing
      '
      'btnFirst
      '
      Me.btnFirst.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnFirst.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnFirst.Location = New System.Drawing.Point(103, 3)
      Me.btnFirst.Name = "btnFirst"
      Me.btnFirst.Size = New System.Drawing.Size(24, 24)
      Me.btnFirst.TabIndex = 14
      Me.btnFirst.TabStop = False
      Me.btnFirst.Text = "|<"
      Me.btnFirst.ThemedImage = Nothing
      '
      'btnFit
      '
      Me.btnFit.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnFit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnFit.Location = New System.Drawing.Point(466, 4)
      Me.btnFit.Name = "btnFit"
      Me.btnFit.Size = New System.Drawing.Size(40, 21)
      Me.btnFit.TabIndex = 13
      Me.btnFit.TabStop = False
      Me.btnFit.Text = "Fit"
      Me.btnFit.ThemedImage = Nothing
      '
      'btnSearch
      '
      Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnSearch.Location = New System.Drawing.Point(409, 4)
      Me.btnSearch.Name = "btnSearch"
      Me.btnSearch.Size = New System.Drawing.Size(51, 21)
      Me.btnSearch.TabIndex = 13
      Me.btnSearch.TabStop = False
      Me.btnSearch.Text = "Search"
      Me.btnSearch.ThemedImage = Nothing
      '
      'btnLast
      '
      Me.btnLast.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnLast.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnLast.Location = New System.Drawing.Point(172, 3)
      Me.btnLast.Name = "btnLast"
      Me.btnLast.Size = New System.Drawing.Size(24, 24)
      Me.btnLast.TabIndex = 13
      Me.btnLast.TabStop = False
      Me.btnLast.Text = ">|"
      Me.btnLast.ThemedImage = Nothing
      '
      'btnBack
      '
      Me.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnBack.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnBack.Location = New System.Drawing.Point(126, 3)
      Me.btnBack.Name = "btnBack"
      Me.btnBack.Size = New System.Drawing.Size(24, 24)
      Me.btnBack.TabIndex = 13
      Me.btnBack.TabStop = False
      Me.btnBack.Text = "<"
      Me.btnBack.ThemedImage = Nothing
      '
      'btnPrint
      '
      Me.btnPrint.Location = New System.Drawing.Point(6, 3)
      Me.btnPrint.Name = "btnPrint"
      Me.btnPrint.Size = New System.Drawing.Size(47, 23)
      Me.btnPrint.TabIndex = 16
      Me.btnPrint.Text = "Print"
      Me.btnPrint.UseVisualStyleBackColor = True
      '
      'trZoom
      '
      Me.trZoom.Location = New System.Drawing.Point(500, 2)
      Me.trZoom.Maximum = 8
      Me.trZoom.Name = "trZoom"
      Me.trZoom.Size = New System.Drawing.Size(104, 45)
      Me.trZoom.TabIndex = 18
      Me.trZoom.Value = 4
      '
      'Splitter2
      '
      Me.Splitter2.Dock = System.Windows.Forms.DockStyle.Right
      Me.Splitter2.Location = New System.Drawing.Point(759, 16)
      Me.Splitter2.Name = "Splitter2"
      Me.Splitter2.Size = New System.Drawing.Size(3, 460)
      Me.Splitter2.TabIndex = 1
      Me.Splitter2.TabStop = False
      '
      'pnlFilter
      '
      Me.pnlFilter.Dock = System.Windows.Forms.DockStyle.Right
      Me.pnlFilter.Location = New System.Drawing.Point(762, 16)
      Me.pnlFilter.Name = "pnlFilter"
      Me.pnlFilter.Size = New System.Drawing.Size(125, 460)
      Me.pnlFilter.TabIndex = 0
      '
      'cmbReportName
      '
      Me.cmbReportName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmbReportName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbReportName.FormattingEnabled = True
      Me.cmbReportName.Location = New System.Drawing.Point(636, 5)
      Me.cmbReportName.Name = "cmbReportName"
      Me.cmbReportName.Size = New System.Drawing.Size(114, 21)
      Me.cmbReportName.TabIndex = 20
      '
      'CrystalReportPanelView
      '
      Me.Controls.Add(Me.GroupBox1)
      Me.Name = "CrystalReportPanelView"
      Me.Size = New System.Drawing.Size(900, 488)
      Me.GroupBox1.ResumeLayout(False)
      Me.Panel2.ResumeLayout(False)
      Me.Panel2.PerformLayout()
      CType(Me.trZoom, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Members"
    Private m_filterSubPanel As IReportFilterSubPanel
    Private m_entity As CrystalReport

    Private m_treeManager As TreeManager
    Private m_pageCount As Integer
    Private WithEvents newReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
#End Region

#Region "Constructors"
    Public Sub New(ByVal entity As ISimpleEntity, ByVal handler As Object, ByVal basket As BasketDialog, ByVal filters As Filter(), ByVal entities As ArrayList)
      MyBase.New()

      InitializeComponent()
      m_entity = CType(entity, CrystalReport)

      Me.CheckAccessRight()

      Me.SetLabelText()
      Me.TitleName = Me.StringParserService.Parse(m_entity.ListPanelTitle)
      Me.PanelName = Me.Name

      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      m_filterSubPanel = myEntityPanelService.GetReportFilterSubPanel(m_entity)

      Dim filterControl As UserControl = CType(Me.m_filterSubPanel, UserControl)
      Me.pnlFilter.Controls.Add(filterControl)
      'Me.pnlFilter.Height = filterControl.Height
      Me.pnlFilter.Width = filterControl.Width
      AddHandler Me.m_filterSubPanel.SearchButton.Click, AddressOf btnSearch_Click

      AddHandler trZoom.ValueChanged, AddressOf trZoom_ValueChanged

      AddHandler txtCurrentPage.Validated, AddressOf txtCurrentPage_Validated
      AddHandler txtSearch.Validated, AddressOf txtSearch_Validated

      'AddHandler newReport.AfterFormatPage, AddressOf ReportDocument_AfterFormatPage

      'Dim dt As TreeTable = m_entity.GetSimpleSchemaTable
      'Dim dst As DataGridTableStyle = m_entity.CreateSimpleTableStyle
      'm_treeManager = New TreeManager(dt, tgItem)
      'm_treeManager.SetTableStyle(dst)
      'm_treeManager.AllowSorting = False
      'm_treeManager.AllowDelete = False

      ''Load All Report

      m_entity.PopupAvailableReport(cmbReportName)

      ''Load เลย
      'btnSearch_Click(Nothing, Nothing)
    End Sub
    Private Sub CheckAccessRight()
      Dim simpleentity As SimpleBusinessEntityBase = SimpleBusinessEntityBase.GetEntity(Me.m_entity.FullClassName)

      Dim secSrv As SecurityService = CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService)
      Dim accessId As Integer = Longkong.Pojjaman.BusinessLogic.Entity.GetAccessIdFromFullClassName(simpleentity.FullClassName)

      Dim level As Integer = secSrv.GetAccess(accessId)
      Dim checkString As String = BinaryHelper.DecToBin(level, 5)
      checkString = BinaryHelper.RevertString(checkString)
      Trace.WriteLine(checkString)
      If CBool(checkString.Substring(3, 1)) Then
        btnPrint.Enabled = True
        btnExport.Enabled = True
      Else
        btnPrint.Enabled = False
        btnExport.Enabled = False
      End If

    End Sub
#End Region

#Region "Properties"
    Public Property TotalPageCount As Integer
      Get
        Return m_pageCount
      End Get
      Set(ByVal value As Integer)
        m_pageCount = value
        If m_pageCount > 0 Then
          SetPageLabel()
        End If
      End Set
    End Property
    Public Property SearchLooPCout As Integer
    Public Property PercentZoom As String
    Public Property ReportName As String
#End Region

#Region "Methods"
    Public Sub ChangeTitle(ByVal sender As Object, ByVal e As EventArgs) Implements ISimpleListPanel.ChangeTitle
      If Me.WorkbenchWindow.ActiveViewContent Is Me Then
        Me.TitleName = Me.StringParserService.Parse(m_entity.ListPanelTitle)
        Return
      End If
      'If Not m_selectedEntity Is Nothing Then
      '    Me.TitleName = m_selectedEntity.TabPageText
      'End If
    End Sub
    Public Sub OnEntityPropertyChanged(ByVal sender As Object, ByVal e As EventArgs)
      RaiseEvent EntityPropertyChanged(sender, e)
    End Sub
#End Region

#Region "Event Handlers"
    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Dim filters As Filter() = Me.m_filterSubPanel.GetFilterArray
      'Dim fixVals As DocPrintingItemCollection = Me.m_filterSubPanel.GetFixValueCollection
      m_entity.Filters = filters
      'm_entity.FixValueCollection = fixVals
      'm_entity.RefreshDataSet()
      'm_entity.ListInGrid(m_treeManager)

      RefreshReport()
      btnFirst.Enabled = False
      btnBack.Enabled = False
    End Sub
    Private Sub RefreshEditableStatus()
      'WorkbenchSingleton.Workbench.RedrawAllComponents()
    End Sub

    Public Overridable Sub RefreshReport()
      If Me.m_entity Is Nothing Then
        Return
      End If

      Dim reportName As String = ""
      If cmbReportName.Items.Count = 0 Then
        Return
        'reportName = Me.m_entity.FullReportName
      Else
        reportName = Me.m_entity.GetSelectedFullReportName(cmbReportName)
      End If

      Me.RefreshReport(reportName, m_entity.Filters)
      'Me.RefreshReport(m_entity.FullReportName, m_entity.Filters)
    End Sub
    Public Overridable Sub RefreshReport(ByVal sReportName As String, ByVal filters As Filter(), Optional ByVal sSelectionFormula As String = "")
      If Me.m_entity Is Nothing Then
        Return
      End If

      If Not IO.File.Exists(sReportName) Then
        MessageBox.Show("Report File '" & sReportName & "' not found")
        Return
      End If

      Dim secSrv As SecurityService = CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService)
      Dim currentUserName As String = secSrv.CurrentUser.Name

      Dim myProperties As PropertyService = CType(ServiceManager.Services.GetService(GetType(PropertyService)), PropertyService)
      Dim culture As String = CType(myProperties.GetProperty("CoreProperties.UILanguage"), String)

      CrystalReportViewer1.SetProductLocale(culture)

      'Dim newReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
      Dim ConInfo As New CrystalDecisions.Shared.TableLogOnInfo
      Dim paraValue As New CrystalDecisions.Shared.ParameterDiscreteValue
      Dim currValue As New CrystalDecisions.Shared.ParameterValues

      Dim newSubReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
      Dim mySubReportObject As CrystalDecisions.CrystalReports.Engine.SubreportObject

      Dim strParValPair() As String
      Dim strVal() As String
      Dim index As Integer

      Try
        newReport.Load(sReportName)

        If Not filters Is Nothing Then
          For Each flr As Filter In filters
            paraValue.Value = flr.Value
            currValue = newReport.DataDefinition.ParameterFields(flr.Name).CurrentValues
            currValue.Add(paraValue)
            newReport.DataDefinition.ParameterFields(flr.Name).ApplyCurrentValues(currValue)

            'Trace.WriteLine(flr.Name & " : " & flr.Value.ToString)
          Next

          paraValue.Value = culture
          currValue = newReport.DataDefinition.ParameterFields("@Culture").CurrentValues
          currValue.Add(paraValue)
          newReport.DataDefinition.ParameterFields("@Culture").ApplyCurrentValues(currValue)

          paraValue.Value = currentUserName
          currValue = newReport.DataDefinition.ParameterFields("@CurrentUserName").CurrentValues
          currValue.Add(paraValue)
          newReport.DataDefinition.ParameterFields("@CurrentUserName").ApplyCurrentValues(currValue)

        End If

        'intCounter = newReport.DataDefinition.ParameterFields.Count

        'If intCounter = 1 Then
        '  If InStr(newReport.DataDefinition.ParameterFields(0).ParameterFieldName, ".", CompareMethod.Text) > 0 Then
        '    intCounter = 0
        '  End If
        'End If

        'If intCounter > 0 And Trim(param) <> "" Then
        '  strParValPair = param.Split("&")

        '  For index = 0 To UBound(strParValPair)
        '    If InStr(strParValPair(index), "=") > 0 Then
        '      strVal = strParValPair(index).Split("=")
        '      paraValue.Value = strVal(1)
        '      currValue = newReport.DataDefinition.ParameterFields(strVal(0)).CurrentValues
        '      currValue.Add(paraValue)
        '      newReport.DataDefinition.ParameterFields(strVal(0)).ApplyCurrentValues(currValue)
        '    End If
        '  Next
        'End If

        ConInfo.ConnectionInfo.UserID = SqlHelper.GetUserID(Me.m_entity.RealConnectionString)
        ConInfo.ConnectionInfo.Password = SqlHelper.GetPassword(Me.m_entity.RealConnectionString)
        ConInfo.ConnectionInfo.ServerName = SqlHelper.GetInstanceName(Me.m_entity.RealConnectionString)
        ConInfo.ConnectionInfo.DatabaseName = SqlHelper.GetDBName(Me.m_entity.RealConnectionString)

        'For intCounter = 0 To newReport.Database.Tables.Count - 1
        '  newReport.Database.Tables(intCounter).ApplyLogOnInfo(ConInfo)
        'Next

        'For index = 0 To newReport.ReportDefinition.Sections.Count - 1
        '  For intCounter = 0 To newReport.ReportDefinition.Sections(index).ReportObjects.Count - 1
        '    With newReport.ReportDefinition.Sections(index)
        '      If .ReportObjects(intCounter).Kind = CrystalDecisions.Shared.ReportObjectKind.SubreportObject Then
        '        mySubReportObject = CType(.ReportObjects(intCounter), CrystalDecisions.CrystalReports.Engine.SubreportObject)
        '        mySubRepDoc = mySubReportObject.OpenSubreport(mySubReportObject.SubreportName)
        '        For intCounter1 = 0 To mySubRepDoc.Database.Tables.Count - 1
        '          mySubRepDoc.Database.Tables(intCounter1).ApplyLogOnInfo(ConInfo)
        '          mySubRepDoc.Database.Tables(intCounter1).ApplyLogOnInfo(ConInfo)
        '        Next
        '      End If
        '    End With
        '  Next
        'Next

        For Each crTable As CrystalDecisions.CrystalReports.Engine.Table In newReport.Database.Tables
          crTable.ApplyLogOnInfo(ConInfo)
        Next
        For Each subReport As CrystalDecisions.CrystalReports.Engine.ReportDocument In newReport.Subreports
          For Each crTable As CrystalDecisions.CrystalReports.Engine.Table In subReport.Database.Tables
            crTable.ApplyLogOnInfo(ConInfo)
          Next
        Next

        If sSelectionFormula.Length > 0 Then
          newReport.RecordSelectionFormula = sSelectionFormula
        End If
        'Re setting control 
        CrystalReportViewer1.ReportSource = Nothing

        'Set the current report object to report.
        CrystalReportViewer1.ReportSource = newReport

        CrystalReportViewer1.Show()

        'Me.TotalPageCount = newReport.ReportRequestStatus.NumberOfPages
        'MessageBox.Show(newReport.ReportRequestStatus.NumberOfPages.ToString)

        'CrystalReportViewer1.Zoom(1)
        'CrystalReportViewer1.SetProductLocale("th-TH")


        'SetPageLabel()
        'TotalPageCount = newReport.ReportRequestStatus.NumberOfPages
        'MessageBox.Show(newReport.ReportRequestStatus.NumberOfPages.ToString)
      Catch ex As System.Exception
        MsgBox(ex.Message)
      End Try
    End Sub
#End Region

#Region "ISimpleListPanel"
    Public Event EntitySelected(ByVal e As ISimpleEntity) Implements ISimpleListPanel.EntitySelected
    Public Event EntityPropertyChanged(ByVal sender As Object, ByVal e As System.EventArgs) Implements ISimpleEntityPanel.EntityPropertyChanged

    Public Sub CheckFormEnable() Implements ISimpleEntityPanel.CheckFormEnable

    End Sub
    Public Sub ClearDetail() Implements ISimpleEntityPanel.ClearDetail

    End Sub

    Public Property Entity() As BusinessLogic.ISimpleEntity Implements ISimpleEntityPanel.Entity
      Get
        Return Me.m_entity
      End Get
      Set(ByVal Value As ISimpleEntity)
        Me.m_entity = CType(Value, CrystalReport)
      End Set
    End Property
    Public Sub Initialize() Implements ISimpleEntityPanel.Initialize

    End Sub
    Public Sub SetLabelText() Implements ISimpleEntityPanel.SetLabelText
      If Not m_entity Is Nothing Then
        Me.Text = Me.StringParserService.Parse(m_entity.ListPanelTitle)
      End If
    End Sub
    Public Sub UpdateEntityProperties() Implements ISimpleEntityPanel.UpdateEntityProperties

    End Sub
    Private Sub CloseHandler(ByVal sender As Object, ByVal e As EventArgs)
      'Dim dlg As Longkong.Pojjaman.Gui.Dialogs.PanelDialog = CType(sender, Longkong.Pojjaman.Gui.Dialogs.PanelDialog)
      'Dim row As DataRow = CType(dlg.Control, AssetSelectionView).SelectedRow
      'If dlg.DialogResult <> DialogResult.OK OrElse row Is Nothing Then
      '    Return
      'End If
      'm_selectedEntity = New Asset(row)
      'If Not m_selectedEntity Is Nothing Then
      '    AddHandler m_selectedEntity.TabPageTextChanged, AddressOf Me.ChangeTitle
      'End If
      'If TypeOf Me.WorkbenchWindow.ActiveViewContent Is ISecondaryViewContent Then
      '    For Each view As ISimpleEntityPanel In Me.WorkbenchWindow.SubViewContents
      '        view.Entity = m_selectedEntity
      '    Next
      'End If
      'If Not TypeOf Me.WorkbenchWindow.ActiveViewContent Is ISecondaryViewContent Then
      '    Me.WorkbenchWindow.SwitchView(1)
      'End If
    End Sub
    Public Sub AddNew() Implements ISimpleListPanel.AddNew

    End Sub
    Public Sub RefreshData(ByVal id As String) Implements ISimpleListPanel.RefreshData

    End Sub
    Public Property SelectedEntity() As BusinessLogic.ISimpleEntity Implements ISimpleListPanel.SelectedEntity
      Get
        Return Me.m_entity
      End Get
      Set(ByVal Value As BusinessLogic.ISimpleEntity)
        Me.m_entity = CType(Value, CrystalReport)
      End Set
    End Property
    Public ReadOnly Property Icon() As String Implements ISimplePanel.Icon
      Get
        Return Me.m_entity.ListPanelIcon
      End Get
    End Property
    Public Sub ShowInPad() Implements ISimplePanel.ShowInPad
      Return
    End Sub
    Public ReadOnly Property Title() As String Implements ISimplePanel.Title
      Get
        Return Me.m_entity.ListPanelTitle
      End Get
    End Property
#End Region

#Region "Overrides"
    Public Overrides ReadOnly Property TabPageText() As String
      Get
        Return Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CrystalReportPanelView.TabPageText}")
      End Get
    End Property
#End Region

#Region "IClipboardHandler"
    Public Overrides ReadOnly Property EnablePaste() As Boolean
      Get
        If Not Me.m_filterSubPanel Is Nothing Then
          Return Me.m_filterSubPanel.EnablePaste
        End If
      End Get
    End Property
    Public Overrides Sub Paste(ByVal sender As Object, ByVal e As System.EventArgs)
      If Not Me.m_filterSubPanel Is Nothing AndAlso Me.m_filterSubPanel.EnablePaste Then
        Me.m_filterSubPanel.Paste(sender, e)
      End If
    End Sub
#End Region

    'Private Sub ReportDocument_AfterFormatPage(ByVal e As CrystalDecisions.CrystalReports.Engine.FormatPageEventArgs)
    '  'TotalPageCount = newReport.ReportRequestStatus.NumberOfPages
    '  Dim newReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
    '  'MessageBox.Show(newReport.ReportRequestStatus.NumberOfPages.ToString)

    'End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
      CrystalReportViewer1.PrintReport()
    End Sub

    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click
      CrystalReportViewer1.AllowedExportFormats = ExportReportFormats()
      CrystalReportViewer1.ExportReport()
    End Sub
    Private Function ExportReportFormats() As Integer
      Dim myExpf As Integer = CrystalDecisions.Shared.ViewerExportFormats.PdfFormat Or CrystalDecisions.Shared.ViewerExportFormats.CsvFormat Or _
                              CrystalDecisions.Shared.ViewerExportFormats.ExcelFormat Or CrystalDecisions.Shared.ViewerExportFormats.XLSXFormat Or _
                              CrystalDecisions.Shared.ViewerExportFormats.XmlFormat
      Return myExpf
      'myExpf = CrystalDecisions.Shared.ViewerExportFormats.PdfFormat
      'myExpf = CrystalDecisions.Shared.ViewerExportFormats.RptFormat
      'myExpf = CrystalDecisions.Shared.ViewerExportFormats.RptFormat
      'myExpf = CrystalDecisions.Shared.ViewerExportFormats.RptFormat
      'myExpf = CrystalDecisions.Shared.ViewerExportFormats.RptFormat

      'int myFOpts = (int)(CrystalDecisions.Shared.ViewerExportFormats.RptFormat | CrystalDecisions.Shared.ViewerExportFormats.PdfFormat | CrystalDecisions.Shared.ViewerExportFormats.RptrFormat | CrystalDecisions.Shared.ViewerExportFormats.XLSXFormat );
    End Function

    Private Sub btnMove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFirst.Click, btnBack.Click, btnNext.Click, btnLast.Click, btnFit.Click
      Select Case CType(sender, Button).Name
        Case btnFirst.Name
          CrystalReportViewer1.ShowFirstPage()
        Case btnBack.Name
          CrystalReportViewer1.ShowPreviousPage()
        Case btnNext.Name
          CrystalReportViewer1.ShowNextPage()
        Case btnLast.Name
          CrystalReportViewer1.ShowLastPage()
        Case btnFit.Name
          CrystalReportViewer1.Zoom(1)

          RemoveHandler trZoom.ValueChanged, AddressOf trZoom_ValueChanged
          trZoom.Value = 4
          AddHandler trZoom.ValueChanged, AddressOf trZoom_ValueChanged
      End Select
      SetPageLabel()
      SetEnableButton()
    End Sub
    'Private Sub btnSelectReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectReport.Click
    '  'Dim myAuxPanel As New Longkong.Pojjaman.Gui.Panels.SupplierAuxDetailView
    '  'myAuxPanel.Entity = Me.m_entity
    '  'Dim myDialog As New Longkong.Pojjaman.Gui.Dialogs.PanelDialog(myAuxPanel)
    '  'If myDialog.ShowDialog() = DialogResult.Cancel Then
    '  '  Me.WorkbenchWindow.ViewContent.IsDirty = False
    '  'End If
    'End Sub
    Private Sub SetPageLabel()
      If Me.TotalPageCount > 0 Then
        RemoveHandler txtCurrentPage.Validated, AddressOf txtCurrentPage_Validated
        If CrystalReportViewer1.GetCurrentPageNumber = -1 Then
          Me.txtCurrentPage.Text = "1"
        Else
          Me.txtCurrentPage.Text = CrystalReportViewer1.GetCurrentPageNumber.ToString
        End If

        AddHandler txtCurrentPage.Validated, AddressOf txtCurrentPage_Validated
      End If

      Me.lblPage.Text = "/" & Me.TotalPageCount.ToString
    End Sub
    Private Sub SetEnableButton()

      If Me.TotalPageCount = 1 Then
        btnFirst.Enabled = False
        btnBack.Enabled = False
        btnNext.Enabled = False
        btnLast.Enabled = False
      ElseIf CrystalReportViewer1.GetCurrentPageNumber = 1 Then
        btnFirst.Enabled = False
        btnBack.Enabled = False
        btnNext.Enabled = True
        btnLast.Enabled = True
      ElseIf CrystalReportViewer1.GetCurrentPageNumber = Me.TotalPageCount Then
        btnFirst.Enabled = True
        btnBack.Enabled = True
        btnNext.Enabled = False
        btnLast.Enabled = False
      Else
        btnFirst.Enabled = True
        btnBack.Enabled = True
        btnNext.Enabled = True
        btnLast.Enabled = True
      End If
    End Sub

    Private Sub trZoom_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs)
      Dim direction As Int16
      Select Case trZoom.Value
        Case Is = 4
          direction = 0
        Case Is < 4
          direction = -1
        Case Is > 4
          direction = 1
      End Select
      Dim x As Integer = (Math.Abs(4 - trZoom.Value) * 2) - 1
      x = (x * 15) * direction
      x = 100 + x

      If x < 0 Then
        PercentZoom = ""
      Else
        PercentZoom = x.ToString & " %"
        CrystalReportViewer1.Zoom(x)
      End If

    End Sub

    'Private Sub CrystalReportViewer1_ReportRefresh(ByVal source As Object, ByVal e As CrystalDecisions.Windows.Forms.ViewerEventArgs) Handles CrystalReportViewer1.ReportRefresh
    '  Dim newReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
    '  newReport = CType(CrystalReportViewer1.ReportSource, CrystalDecisions.CrystalReports.Engine.ReportDocument)
    '  MessageBox.Show(newReport.ReportRequestStatus.NumberOfPages.ToString)
    'End Sub

    Private Sub CrystalReportViewer1_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles CrystalReportViewer1.Paint
      If CrystalReportViewer1.ReportSource Is Nothing Then
        Return
      End If
      Dim newReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
      newReport = CType(CrystalReportViewer1.ReportSource, CrystalDecisions.CrystalReports.Engine.ReportDocument)
      Me.TotalPageCount = newReport.ReportRequestStatus.NumberOfPages
    End Sub

    'Private Sub CrystalReportViewer1_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CrystalReportViewer1.Validated
    '  If CrystalReportViewer1.ReportSource Is Nothing Then
    '    Return
    '  End If
    '  Dim newReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
    '  newReport = CType(CrystalReportViewer1.ReportSource, CrystalDecisions.CrystalReports.Engine.ReportDocument)
    '  Me.TotalPageCount = newReport.ReportRequestStatus.NumberOfPages
    'End Sub

    Private Sub txtSearch_Validated(ByVal sender As Object, ByVal e As System.EventArgs)
      Me.SearchForText(CType(sender, TextBox).Text)
    End Sub
    Private Sub txtCurrentPage_Validated(ByVal sender As Object, ByVal e As System.EventArgs)
      If IsNumeric(CType(sender, TextBox).Text) Then
        Dim val As Integer = CInt(CType(sender, TextBox).Text)
        If val > Me.TotalPageCount Then
          val = Me.TotalPageCount
        ElseIf val <= 0 Then
          val = 1
        End If
        Try
          CrystalReportViewer1.ShowNthPage(val)
        Catch ex As Exception

        End Try
      End If
      Me.SetPageLabel()
    End Sub

    Private Sub btnSearch_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
      Me.SearchForText(txtSearch.Text)
    End Sub
    Private Function SearchForText(ByVal text As String) As Boolean
      If Me.CrystalReportViewer1.SearchForText(text) Then
        Me.SetPageLabel()
        Me.SetEnableButton()
        Me.SearchLooPCout = 0
        Return True
      Else
        If Me.SearchLooPCout >= 1 Then
          Me.SetPageLabel()
          Me.SetEnableButton()
          Me.SearchLooPCout = 0
          MessageBox.Show("Not found '" & text.Trim & "'")
          Return False
        Else
          Me.SearchLooPCout += 1
          Me.CrystalReportViewer1.ShowFirstPage()
          Me.SearchForText(text)
        End If
      End If
    End Function

    Private Sub trZoom_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles trZoom.MouseLeave
      btnFit.Text = "Fit"
    End Sub

    Private Sub trZoom_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles trZoom.MouseUp
      btnFit.Text = Me.PercentZoom
    End Sub

  End Class
End Namespace

