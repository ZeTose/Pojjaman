Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Namespace Longkong.Pojjaman.Gui.Panels
  Public Class CalcMatCostFilterSubPanel
    Inherits AbstractFilterSubPanel

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
    Friend WithEvents lblCode As System.Windows.Forms.Label
    Friend WithEvents txtCode As System.Windows.Forms.TextBox
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents btnReset As System.Windows.Forms.Button
    Friend WithEvents grbDocDate As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents lblDocDateStart As System.Windows.Forms.Label
    Friend WithEvents lblDocDateEnd As System.Windows.Forms.Label
    Friend WithEvents dtpDocDateStart As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpDocDateEnd As System.Windows.Forms.DateTimePicker
    Friend WithEvents grbMainDetail As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents txtFromCCPersonCode As System.Windows.Forms.TextBox
    Friend WithEvents ibtnFromCostCenterPanel As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtFromCostCenterCode As System.Windows.Forms.TextBox
    Friend WithEvents txtFromCCPersonName As System.Windows.Forms.TextBox
    Friend WithEvents lblFromCCPerson As System.Windows.Forms.Label
    Friend WithEvents txtFromCostCenterName As System.Windows.Forms.TextBox
    Friend WithEvents ibtnFromCostCenterDialog As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents ibtnFromCCPersonPanel As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents lblFromCostCenter As System.Windows.Forms.Label
    Friend WithEvents ibtnFromCCPersonDialog As Longkong.Pojjaman.Gui.Components.ImageButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CalcMatCostFilterSubPanel))
      Me.lblCode = New System.Windows.Forms.Label()
      Me.txtCode = New System.Windows.Forms.TextBox()
      Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.grbDocDate = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.lblDocDateStart = New System.Windows.Forms.Label()
      Me.lblDocDateEnd = New System.Windows.Forms.Label()
      Me.dtpDocDateStart = New System.Windows.Forms.DateTimePicker()
      Me.dtpDocDateEnd = New System.Windows.Forms.DateTimePicker()
      Me.btnSearch = New System.Windows.Forms.Button()
      Me.btnReset = New System.Windows.Forms.Button()
      Me.grbMainDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.txtFromCCPersonCode = New System.Windows.Forms.TextBox()
      Me.ibtnFromCostCenterPanel = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.txtFromCostCenterCode = New System.Windows.Forms.TextBox()
      Me.txtFromCCPersonName = New System.Windows.Forms.TextBox()
      Me.lblFromCCPerson = New System.Windows.Forms.Label()
      Me.txtFromCostCenterName = New System.Windows.Forms.TextBox()
      Me.ibtnFromCostCenterDialog = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.ibtnFromCCPersonPanel = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.lblFromCostCenter = New System.Windows.Forms.Label()
      Me.ibtnFromCCPersonDialog = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.grbDetail.SuspendLayout()
      Me.grbDocDate.SuspendLayout()
      Me.grbMainDetail.SuspendLayout()
      Me.SuspendLayout()
      '
      'lblCode
      '
      Me.lblCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCode.ForeColor = System.Drawing.Color.Black
      Me.lblCode.Location = New System.Drawing.Point(8, 16)
      Me.lblCode.Name = "lblCode"
      Me.lblCode.Size = New System.Drawing.Size(136, 18)
      Me.lblCode.TabIndex = 6
      Me.lblCode.Text = "รหัส:"
      Me.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtCode
      '
      Me.txtCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.txtCode.Location = New System.Drawing.Point(152, 16)
      Me.txtCode.Name = "txtCode"
      Me.txtCode.Size = New System.Drawing.Size(224, 21)
      Me.txtCode.TabIndex = 0
      '
      'grbDetail
      '
      Me.grbDetail.Controls.Add(Me.grbDocDate)
      Me.grbDetail.Controls.Add(Me.btnSearch)
      Me.grbDetail.Controls.Add(Me.btnReset)
      Me.grbDetail.Controls.Add(Me.grbMainDetail)
      Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbDetail.Location = New System.Drawing.Point(8, 8)
      Me.grbDetail.Name = "grbDetail"
      Me.grbDetail.Size = New System.Drawing.Size(728, 133)
      Me.grbDetail.TabIndex = 0
      Me.grbDetail.TabStop = False
      '
      'grbDocDate
      '
      Me.grbDocDate.Controls.Add(Me.lblDocDateStart)
      Me.grbDocDate.Controls.Add(Me.lblDocDateEnd)
      Me.grbDocDate.Controls.Add(Me.dtpDocDateStart)
      Me.grbDocDate.Controls.Add(Me.dtpDocDateEnd)
      Me.grbDocDate.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbDocDate.Location = New System.Drawing.Point(406, 19)
      Me.grbDocDate.Name = "grbDocDate"
      Me.grbDocDate.Size = New System.Drawing.Size(248, 72)
      Me.grbDocDate.TabIndex = 2
      Me.grbDocDate.TabStop = False
      Me.grbDocDate.Text = "วันที่เอกสาร"
      '
      'lblDocDateStart
      '
      Me.lblDocDateStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDocDateStart.ForeColor = System.Drawing.Color.Black
      Me.lblDocDateStart.Location = New System.Drawing.Point(8, 17)
      Me.lblDocDateStart.Name = "lblDocDateStart"
      Me.lblDocDateStart.Size = New System.Drawing.Size(80, 18)
      Me.lblDocDateStart.TabIndex = 11
      Me.lblDocDateStart.Text = "ตั้งแต่"
      Me.lblDocDateStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblDocDateEnd
      '
      Me.lblDocDateEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDocDateEnd.ForeColor = System.Drawing.Color.Black
      Me.lblDocDateEnd.Location = New System.Drawing.Point(8, 41)
      Me.lblDocDateEnd.Name = "lblDocDateEnd"
      Me.lblDocDateEnd.Size = New System.Drawing.Size(80, 18)
      Me.lblDocDateEnd.TabIndex = 11
      Me.lblDocDateEnd.Text = "ถึง"
      Me.lblDocDateEnd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'dtpDocDateStart
      '
      Me.dtpDocDateStart.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpDocDateStart.Location = New System.Drawing.Point(96, 16)
      Me.dtpDocDateStart.Name = "dtpDocDateStart"
      Me.dtpDocDateStart.Size = New System.Drawing.Size(136, 20)
      Me.dtpDocDateStart.TabIndex = 0
      '
      'dtpDocDateEnd
      '
      Me.dtpDocDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpDocDateEnd.Location = New System.Drawing.Point(96, 40)
      Me.dtpDocDateEnd.Name = "dtpDocDateEnd"
      Me.dtpDocDateEnd.Size = New System.Drawing.Size(136, 20)
      Me.dtpDocDateEnd.TabIndex = 1
      '
      'btnSearch
      '
      Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnSearch.Location = New System.Drawing.Point(648, 101)
      Me.btnSearch.Name = "btnSearch"
      Me.btnSearch.Size = New System.Drawing.Size(75, 23)
      Me.btnSearch.TabIndex = 1
      Me.btnSearch.Text = "Search"
      '
      'btnReset
      '
      Me.btnReset.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnReset.Location = New System.Drawing.Point(568, 101)
      Me.btnReset.Name = "btnReset"
      Me.btnReset.Size = New System.Drawing.Size(75, 23)
      Me.btnReset.TabIndex = 0
      Me.btnReset.Text = "Reset"
      '
      'grbMainDetail
      '
      Me.grbMainDetail.Controls.Add(Me.txtFromCCPersonCode)
      Me.grbMainDetail.Controls.Add(Me.ibtnFromCostCenterPanel)
      Me.grbMainDetail.Controls.Add(Me.txtFromCostCenterCode)
      Me.grbMainDetail.Controls.Add(Me.txtFromCCPersonName)
      Me.grbMainDetail.Controls.Add(Me.lblFromCCPerson)
      Me.grbMainDetail.Controls.Add(Me.txtFromCostCenterName)
      Me.grbMainDetail.Controls.Add(Me.ibtnFromCostCenterDialog)
      Me.grbMainDetail.Controls.Add(Me.ibtnFromCCPersonPanel)
      Me.grbMainDetail.Controls.Add(Me.lblFromCostCenter)
      Me.grbMainDetail.Controls.Add(Me.ibtnFromCCPersonDialog)
      Me.grbMainDetail.Controls.Add(Me.txtCode)
      Me.grbMainDetail.Controls.Add(Me.lblCode)
      Me.grbMainDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbMainDetail.Location = New System.Drawing.Point(8, 16)
      Me.grbMainDetail.Name = "grbMainDetail"
      Me.grbMainDetail.Size = New System.Drawing.Size(392, 97)
      Me.grbMainDetail.TabIndex = 0
      Me.grbMainDetail.TabStop = False
      Me.grbMainDetail.Text = "รายละเอียดทั่วไป"
      '
      'txtFromCCPersonCode
      '
      Me.txtFromCCPersonCode.Location = New System.Drawing.Point(153, 42)
      Me.txtFromCCPersonCode.Name = "txtFromCCPersonCode"
      Me.txtFromCCPersonCode.Size = New System.Drawing.Size(80, 20)
      Me.txtFromCCPersonCode.TabIndex = 3
      '
      'ibtnFromCostCenterPanel
      '
      Me.ibtnFromCostCenterPanel.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnFromCostCenterPanel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnFromCostCenterPanel.Location = New System.Drawing.Point(353, 66)
      Me.ibtnFromCostCenterPanel.Name = "ibtnFromCostCenterPanel"
      Me.ibtnFromCostCenterPanel.Size = New System.Drawing.Size(24, 23)
      Me.ibtnFromCostCenterPanel.TabIndex = 209
      Me.ibtnFromCostCenterPanel.TabStop = False
      Me.ibtnFromCostCenterPanel.ThemedImage = CType(resources.GetObject("ibtnFromCostCenterPanel.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtFromCostCenterCode
      '
      Me.txtFromCostCenterCode.Location = New System.Drawing.Point(153, 66)
      Me.txtFromCostCenterCode.Name = "txtFromCostCenterCode"
      Me.txtFromCostCenterCode.Size = New System.Drawing.Size(80, 20)
      Me.txtFromCostCenterCode.TabIndex = 4
      '
      'txtFromCCPersonName
      '
      Me.txtFromCCPersonName.Location = New System.Drawing.Point(233, 42)
      Me.txtFromCCPersonName.Name = "txtFromCCPersonName"
      Me.txtFromCCPersonName.ReadOnly = True
      Me.txtFromCCPersonName.Size = New System.Drawing.Size(96, 20)
      Me.txtFromCCPersonName.TabIndex = 208
      Me.txtFromCCPersonName.TabStop = False
      '
      'lblFromCCPerson
      '
      Me.lblFromCCPerson.BackColor = System.Drawing.Color.Transparent
      Me.lblFromCCPerson.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblFromCCPerson.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblFromCCPerson.Location = New System.Drawing.Point(9, 42)
      Me.lblFromCCPerson.Name = "lblFromCCPerson"
      Me.lblFromCCPerson.Size = New System.Drawing.Size(136, 18)
      Me.lblFromCCPerson.TabIndex = 205
      Me.lblFromCCPerson.Text = "ผู้คำนวณ:"
      Me.lblFromCCPerson.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtFromCostCenterName
      '
      Me.txtFromCostCenterName.Location = New System.Drawing.Point(233, 66)
      Me.txtFromCostCenterName.Name = "txtFromCostCenterName"
      Me.txtFromCostCenterName.ReadOnly = True
      Me.txtFromCostCenterName.Size = New System.Drawing.Size(96, 20)
      Me.txtFromCostCenterName.TabIndex = 207
      Me.txtFromCostCenterName.TabStop = False
      '
      'ibtnFromCostCenterDialog
      '
      Me.ibtnFromCostCenterDialog.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnFromCostCenterDialog.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnFromCostCenterDialog.ForeColor = System.Drawing.SystemColors.Control
      Me.ibtnFromCostCenterDialog.Location = New System.Drawing.Point(329, 66)
      Me.ibtnFromCostCenterDialog.Name = "ibtnFromCostCenterDialog"
      Me.ibtnFromCostCenterDialog.Size = New System.Drawing.Size(24, 23)
      Me.ibtnFromCostCenterDialog.TabIndex = 211
      Me.ibtnFromCostCenterDialog.TabStop = False
      Me.ibtnFromCostCenterDialog.ThemedImage = CType(resources.GetObject("ibtnFromCostCenterDialog.ThemedImage"), System.Drawing.Bitmap)
      '
      'ibtnFromCCPersonPanel
      '
      Me.ibtnFromCCPersonPanel.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnFromCCPersonPanel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnFromCCPersonPanel.Location = New System.Drawing.Point(353, 42)
      Me.ibtnFromCCPersonPanel.Name = "ibtnFromCCPersonPanel"
      Me.ibtnFromCCPersonPanel.Size = New System.Drawing.Size(24, 23)
      Me.ibtnFromCCPersonPanel.TabIndex = 210
      Me.ibtnFromCCPersonPanel.TabStop = False
      Me.ibtnFromCCPersonPanel.ThemedImage = CType(resources.GetObject("ibtnFromCCPersonPanel.ThemedImage"), System.Drawing.Bitmap)
      '
      'lblFromCostCenter
      '
      Me.lblFromCostCenter.BackColor = System.Drawing.Color.Transparent
      Me.lblFromCostCenter.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblFromCostCenter.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblFromCostCenter.Location = New System.Drawing.Point(1, 66)
      Me.lblFromCostCenter.Name = "lblFromCostCenter"
      Me.lblFromCostCenter.Size = New System.Drawing.Size(144, 18)
      Me.lblFromCostCenter.TabIndex = 206
      Me.lblFromCostCenter.Text = "Cost Center:"
      Me.lblFromCostCenter.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'ibtnFromCCPersonDialog
      '
      Me.ibtnFromCCPersonDialog.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnFromCCPersonDialog.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnFromCCPersonDialog.ForeColor = System.Drawing.SystemColors.Control
      Me.ibtnFromCCPersonDialog.Location = New System.Drawing.Point(329, 42)
      Me.ibtnFromCCPersonDialog.Name = "ibtnFromCCPersonDialog"
      Me.ibtnFromCCPersonDialog.Size = New System.Drawing.Size(24, 23)
      Me.ibtnFromCCPersonDialog.TabIndex = 212
      Me.ibtnFromCCPersonDialog.TabStop = False
      Me.ibtnFromCCPersonDialog.ThemedImage = CType(resources.GetObject("ibtnFromCCPersonDialog.ThemedImage"), System.Drawing.Bitmap)
      '
      'CalcMaterialCostFilterSubPanel
      '
      Me.Controls.Add(Me.grbDetail)
      Me.Name = "CalcMaterialCostFilterSubPanel"
      Me.Size = New System.Drawing.Size(744, 148)
      Me.grbDetail.ResumeLayout(False)
      Me.grbDocDate.ResumeLayout(False)
      Me.grbMainDetail.ResumeLayout(False)
      Me.grbMainDetail.PerformLayout()
      Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Constructors"
    Public Sub New()
      MyBase.New()

      InitializeComponent()
      Initialize()
      SetLabelText()
      Me.LoopControl(Me)
    End Sub
#End Region

#Region "Members"
    Private m_fromCCPerson As Employee
    Private m_fromCC As CostCenter
#End Region

#Region "Methods"
    Public Sub Initialize()
      'PopulateStatus()
      ClearCriterias()
    End Sub
    Private Sub ClearCriterias()
      Me.txtCode.Text = ""

      Me.txtFromCCPersonCode.Text = ""
      Me.txtFromCCPersonName.Text = ""
      Me.m_fromCCPerson = New Employee

      Me.txtFromCostCenterCode.Text = ""
      Me.txtFromCostCenterName.Text = ""
      Me.m_fromCC = New CostCenter



      Me.dtpDocDateStart.Value = Now.Subtract(New TimeSpan(7, 0, 0, 0))
      Me.dtpDocDateEnd.Value = Now.Date
    End Sub
    Private Sub PopulateStatus()
      'Dim dt As DataTable = CodeDescription.GetCodeList("mattransfer_status")
      'Me.cmbStatus.DataSource = dt
      'Me.cmbStatus.DisplayMember = "code_description"
      'Me.cmbStatus.ValueMember = "code_value"
    End Sub
    Public Sub SetLabelText()
      Me.grbDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MaterialTransferFilterSubPanel.grbDetail}")
      Me.lblCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MaterialTransferFilterSubPanel.lblCode}")
      Me.btnSearch.Text = Me.StringParserService.Parse("${res:Global.SearchButtonText}")
      Me.btnReset.Text = Me.StringParserService.Parse("${res:Global.ResetButtonText}")
      Me.grbDocDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MaterialTransferFilterSubPanel.grbDocDate}")
      Me.lblDocDateStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MaterialTransferFilterSubPanel.lblDocDateStart}")
      Me.lblDocDateEnd.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MaterialTransferFilterSubPanel.lblDocDateEnd}")
      'Me.lblStatus.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MaterialTransferFilterSubPanel.lblStatus}")
      Me.grbMainDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MaterialTransferFilterSubPanel.grbMainDetail}")
      Me.lblFromCCPerson.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MaterialTransferFilterSubPanel.lblFromCCPerson}")
      Me.lblFromCostCenter.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MaterialTransferFilterSubPanel.lblFromCostCenter}")
    End Sub
    Public Overrides Function GetFilterArray() As Filter()
      Dim arr(5) As Filter
      arr(0) = New Filter("code", IIf(Me.txtCode.Text.Length = 0, DBNull.Value, Me.txtCode.Text))
      arr(1) = New Filter("docdatestart", Me.dtpDocDateStart.Value.Date)
      arr(2) = New Filter("docdateend", Me.dtpDocDateEnd.Value.Date)
      arr(3) = New Filter("fromccperson", IIf(Me.m_fromCCPerson.Originated, Me.m_fromCCPerson.Id, DBNull.Value))
      arr(4) = New Filter("fromcc", IIf(Me.m_fromCC.Valid, Me.m_fromCC.Id, DBNull.Value))
      arr(5) = New Filter("userRight", CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
      Return arr
    End Function
    Public Overrides ReadOnly Property SearchButton() As System.Windows.Forms.Button
      Get
        Return Me.btnSearch
      End Get
    End Property
#End Region

#Region "Event Handlers"





    Private Sub txtFromCCPersonCode_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFromCCPersonCode.Validated
      Employee.GetEmployee(txtFromCCPersonCode, txtFromCCPersonName, Me.m_fromCCPerson)
    End Sub
    Private Sub btnFromCCPersonDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnFromCCPersonDialog.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenListDialog(New Employee, AddressOf SetFromCCPerson)
    End Sub
    Private Sub btnFromCCPersonPanel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnFromCCPersonPanel.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenPanel(New Employee)
    End Sub
    Private Sub SetFromCCPerson(ByVal e As ISimpleEntity)
      Me.txtFromCCPersonCode.Text = e.Code
      Employee.GetEmployee(txtFromCCPersonCode, txtFromCCPersonName, Me.m_fromCCPerson)
    End Sub






    Private Sub txtFromCostCenterCode_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFromCostCenterCode.Validated
      CostCenter.GetCostCenter(txtFromCostCenterCode, txtFromCostCenterName, Me.m_fromCC, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
    End Sub
    Private Sub btnFromCostCenterDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnFromCostCenterDialog.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenTreeDialog(New CostCenter, AddressOf SetFromCostCenter)
    End Sub
    Private Sub SetFromCostCenter(ByVal e As ISimpleEntity)
      Me.txtFromCostCenterCode.Text = e.Code
      CostCenter.GetCostCenter(txtFromCostCenterCode, txtFromCostCenterName, Me.m_fromCC, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
    End Sub
    Private Sub btnFromCostCenterPanel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnFromCostCenterPanel.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenPanel(New CostCenter)
    End Sub




    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
      ClearCriterias()
      Me.btnSearch.PerformClick()
    End Sub


#End Region

#Region "IClipboardHandler Overrides" 'Undone
    Public Overrides ReadOnly Property EnablePaste() As Boolean
      Get
        If Me.ActiveControl Is Nothing Then
          Return False
        End If
        Dim data As IDataObject = Clipboard.GetDataObject

        If data.GetDataPresent((New CostCenter).FullClassName) Then
          Select Case Me.ActiveControl.Name.ToLower
            Case "txttocostcentercode", "txttocostcentername", "txtfromcostcentercode", "txtfromcostcentername"
              Return True
          End Select
        End If
        If data.GetDataPresent((New Employee).FullClassName) Then
          Select Case Me.ActiveControl.Name.ToLower
            Case "txtfromccpersoncode", "txtfromccpersonname", "txttoccpersoncode", "txttoccpersoncode"
              Return True
          End Select
        End If
        If data.GetDataPresent((New LCIItem).FullClassName) Then
          Select Case Me.ActiveControl.Name.ToLower
            Case "txtlci", "txtlciname"
              Return True
          End Select
        End If
      End Get
    End Property
    Public Overrides Sub Paste(ByVal sender As Object, ByVal e As System.EventArgs)
      If Me.ActiveControl Is Nothing Then
        Return
      End If
      Dim data As IDataObject = Clipboard.GetDataObject
      If data.GetDataPresent((New CostCenter).FullClassName) Then
        Dim id As Integer = CInt(data.GetData((New CostCenter).FullClassName))
        Dim entity As New CostCenter(id)
        Select Case Me.ActiveControl.Name.ToLower

          Case "txtfromcostcentercode", "txtfromcostcentername"
            Me.SetFromCostCenter(entity)
        End Select
      End If
      If data.GetDataPresent((New Employee).FullClassName) Then
        Dim id As Integer = CInt(data.GetData((New Employee).FullClassName))
        Dim entity As New Employee(id)
        Select Case Me.ActiveControl.Name.ToLower

          Case "txtfromccpersoncode", "txtfromccpersoncode"
            Me.SetFromCCPerson(entity)
        End Select
      End If

    End Sub
#End Region

  End Class
End Namespace

