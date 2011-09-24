Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Imports System.Collections.Generic
Imports Longkong.Pojjaman.Gui.Components
Imports Syncfusion.XlsIO

Namespace Longkong.Pojjaman.Gui.Panels
  Public Class RptProjectRevenueExpenseFilterSubPanel
    Inherits AbstractFilterSubPanel
    Implements IReportFilterSubPanel, IExcellExportAble
    'Inherits UserControl

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
    Friend WithEvents chkNoDigit As System.Windows.Forms.CheckBox
    Friend WithEvents btnShowCostCenter As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtCostCenterCode As System.Windows.Forms.TextBox
    Friend WithEvents lblCostCenter As System.Windows.Forms.Label
    Friend WithEvents txtCostCenterName As System.Windows.Forms.TextBox
    Friend WithEvents ibtnSaveAsExcel As Longkong.Pojjaman.Gui.Components.ImageButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RptProjectRevenueExpenseFilterSubPanel))
      Me.grbMaster = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.ibtnSaveAsExcel = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.chkNoDigit = New System.Windows.Forms.CheckBox()
      Me.grbProject = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.btnSearch = New System.Windows.Forms.Button()
      Me.btnReset = New System.Windows.Forms.Button()
      Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
      Me.btnShowCostCenter = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.txtCostCenterCode = New System.Windows.Forms.TextBox()
      Me.lblCostCenter = New System.Windows.Forms.Label()
      Me.txtCostCenterName = New System.Windows.Forms.TextBox()
      Me.grbMaster.SuspendLayout()
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
      Me.grbMaster.Controls.Add(Me.grbProject)
      Me.grbMaster.Controls.Add(Me.btnSearch)
      Me.grbMaster.Controls.Add(Me.btnReset)
      Me.grbMaster.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbMaster.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.grbMaster.Location = New System.Drawing.Point(8, 3)
      Me.grbMaster.Name = "grbMaster"
      Me.grbMaster.Size = New System.Drawing.Size(448, 120)
      Me.grbMaster.TabIndex = 0
      Me.grbMaster.TabStop = False
      Me.grbMaster.Text = "ค้นหา"
      '
      'ibtnSaveAsExcel
      '
      Me.ibtnSaveAsExcel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.ibtnSaveAsExcel.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnSaveAsExcel.Location = New System.Drawing.Point(117, 87)
      Me.ibtnSaveAsExcel.Name = "ibtnSaveAsExcel"
      Me.ibtnSaveAsExcel.Size = New System.Drawing.Size(23, 24)
      Me.ibtnSaveAsExcel.TabIndex = 20
      Me.ibtnSaveAsExcel.TabStop = False
      Me.ibtnSaveAsExcel.ThemedImage = CType(resources.GetObject("ibtnSaveAsExcel.ThemedImage"), System.Drawing.Bitmap)
      '
      'chkNoDigit
      '
      Me.chkNoDigit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.chkNoDigit.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.chkNoDigit.Location = New System.Drawing.Point(23, 88)
      Me.chkNoDigit.Name = "chkNoDigit"
      Me.chkNoDigit.Size = New System.Drawing.Size(100, 24)
      Me.chkNoDigit.TabIndex = 6
      Me.chkNoDigit.Text = "ไม่แสดงทศนิยม"
      '
      'grbProject
      '
      Me.grbProject.Controls.Add(Me.btnShowCostCenter)
      Me.grbProject.Controls.Add(Me.txtCostCenterCode)
      Me.grbProject.Controls.Add(Me.lblCostCenter)
      Me.grbProject.Controls.Add(Me.txtCostCenterName)
      Me.grbProject.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbProject.Location = New System.Drawing.Point(16, 16)
      Me.grbProject.Name = "grbProject"
      Me.grbProject.Size = New System.Drawing.Size(423, 63)
      Me.grbProject.TabIndex = 0
      Me.grbProject.TabStop = False
      Me.grbProject.Text = "โครงการ"
      '
      'btnSearch
      '
      Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnSearch.Location = New System.Drawing.Point(360, 88)
      Me.btnSearch.Name = "btnSearch"
      Me.btnSearch.Size = New System.Drawing.Size(80, 23)
      Me.btnSearch.TabIndex = 2
      Me.btnSearch.Text = "ค้นหา"
      '
      'btnReset
      '
      Me.btnReset.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnReset.Location = New System.Drawing.Point(272, 88)
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
      'ErrorProvider1
      '
      Me.ErrorProvider1.ContainerControl = Me
      '
      'btnShowCostCenter
      '
      Me.btnShowCostCenter.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnShowCostCenter.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnShowCostCenter.ForeColor = System.Drawing.SystemColors.Control
      Me.btnShowCostCenter.Location = New System.Drawing.Point(374, 24)
      Me.btnShowCostCenter.Name = "btnShowCostCenter"
      Me.btnShowCostCenter.Size = New System.Drawing.Size(24, 22)
      Me.btnShowCostCenter.TabIndex = 20
      Me.btnShowCostCenter.TabStop = False
      Me.btnShowCostCenter.ThemedImage = CType(resources.GetObject("btnShowCostCenter.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtCostCenterCode
      '
      Me.Validator.SetDataType(Me.txtCostCenterCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtCostCenterCode, "")
      Me.txtCostCenterCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtCostCenterCode, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtCostCenterCode, -15)
      Me.Validator.SetInvalidBackColor(Me.txtCostCenterCode, System.Drawing.Color.Empty)
      Me.txtCostCenterCode.Location = New System.Drawing.Point(118, 24)
      Me.Validator.SetMinValue(Me.txtCostCenterCode, "")
      Me.txtCostCenterCode.Name = "txtCostCenterCode"
      Me.Validator.SetRegularExpression(Me.txtCostCenterCode, "")
      Me.Validator.SetRequired(Me.txtCostCenterCode, False)
      Me.txtCostCenterCode.Size = New System.Drawing.Size(72, 21)
      Me.txtCostCenterCode.TabIndex = 17
      '
      'lblCostCenter
      '
      Me.lblCostCenter.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCostCenter.ForeColor = System.Drawing.Color.Black
      Me.lblCostCenter.Location = New System.Drawing.Point(12, 24)
      Me.lblCostCenter.Name = "lblCostCenter"
      Me.lblCostCenter.Size = New System.Drawing.Size(106, 18)
      Me.lblCostCenter.TabIndex = 18
      Me.lblCostCenter.Text = "Cost Center:"
      Me.lblCostCenter.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtCostCenterName
      '
      Me.Validator.SetDataType(Me.txtCostCenterName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtCostCenterName, "")
      Me.txtCostCenterName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtCostCenterName, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtCostCenterName, -15)
      Me.Validator.SetInvalidBackColor(Me.txtCostCenterName, System.Drawing.Color.Empty)
      Me.txtCostCenterName.Location = New System.Drawing.Point(190, 24)
      Me.Validator.SetMinValue(Me.txtCostCenterName, "")
      Me.txtCostCenterName.Name = "txtCostCenterName"
      Me.txtCostCenterName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtCostCenterName, "")
      Me.Validator.SetRequired(Me.txtCostCenterName, False)
      Me.txtCostCenterName.Size = New System.Drawing.Size(184, 21)
      Me.txtCostCenterName.TabIndex = 19
      '
      'RptProjectRevenueExpenseFilterSubPanel
      '
      Me.Controls.Add(Me.grbMaster)
      Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Name = "RptProjectRevenueExpenseFilterSubPanel"
      Me.Size = New System.Drawing.Size(464, 131)
      Me.grbMaster.ResumeLayout(False)
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
    'Private m_cc As CostCenter
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
    Public Property CostCenter As CostCenter
#End Region

#Region "Methods"
    Private Sub Initialize()
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
      m_dateSetting = True

      Me.CostCenter = New CostCenter

    End Sub
    Public Overrides Function GetFilterString() As String

    End Function
    Public Overrides Function GetFilterArray() As Filter()

      Dim arr(1) As Filter
      arr(0) = New Filter("cc_id", Me.CostCenter.Id)
      arr(1) = New Filter("chkNoDigit", IIf(chkNoDigit.Checked, 1, 0))
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
      AddHandler txtCostCenterCode.Validated, AddressOf Me.ChangeProperty

    End Sub

    Private m_dateSetting As Boolean
    Private Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)

      Select CType(sender, Control).Name.ToLower
        Case txtCostCenterCode.Name.ToLower
          CostCenter.GetCostCenter(txtCostCenterCode, txtCostCenterName, Me.CostCenter)
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

#End Region

    Private Sub btnShowCostCenter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShowCostCenter.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)

      Dim entities As New ArrayList
      Dim cc As New CostCenter
      cc.Type = New CostCenterType(2)
      entities.Add(cc)

      Select Case CType(sender, Control).Name.ToLower
        Case "btnshowcostcenter"
          myEntityPanelService.OpenListDialog(New CostCenter, AddressOf SetCostCenter, Entities)
      End Select
    End Sub
    Private Sub SetCostCenter(ByVal e As ISimpleEntity)
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      If CType(e, CostCenter).BoqId = 0 Then
        msgServ.ShowWarning("${res:Global.Error.SpecifyCCWithBOQ}")
        Return
      End If
      Me.txtCostCenterCode.Text = e.Code
      CostCenter.GetCostCenter(txtCostCenterCode, txtCostCenterName, Me.CostCenter)
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
      Dim filename As String = "Export " & "RptProjectRevenueExpense[" & Me.CostCenter.Code & "]_" & Now.ToString("yyyyMMdd") & ".xls"
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

        wkbk.Worksheets(0).Name = "RptProjectRevenueExpense"

        For rowindex As Integer = 1 To tgItem.RowCount
          For colindex As Integer = 2 To tgItem.ColCount
            If tgItem(rowindex, colindex).Text.Length > 0 AndAlso Configuration.IsFormatString(tgItem(rowindex, colindex).Text, DigitConfig.Price) Then
              Replace(Replace(tgItem(rowindex, colindex).Text, "(", ""), ")", "")
              sht1.Range(rowindex, colindex).Value = CDec(tgItem(rowindex, colindex).Text).ToString
            Else
              sht1.Range(rowindex, colindex).Text = tgItem(rowindex, colindex).Text
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

  End Class

End Namespace

