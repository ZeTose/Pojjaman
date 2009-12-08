Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services

Namespace Longkong.Pojjaman.Gui.Panels
  Public Class SupplierFilterSubPanel
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
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents lblGroup As System.Windows.Forms.Label
    Friend WithEvents cmbProvince As System.Windows.Forms.ComboBox
    Friend WithEvents grbDetail As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents txtGroupCode As System.Windows.Forms.TextBox
    Friend WithEvents lblAddress As System.Windows.Forms.Label
    Friend WithEvents txtAddress As System.Windows.Forms.TextBox
    Friend WithEvents lblPhone As System.Windows.Forms.Label
    Friend WithEvents txtPhone As System.Windows.Forms.TextBox
    Friend WithEvents lblProvince As System.Windows.Forms.Label
    Friend WithEvents lblCode As System.Windows.Forms.Label
    Friend WithEvents txtCode As System.Windows.Forms.TextBox
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents btnReset As System.Windows.Forms.Button
    Friend WithEvents txtGroupName As System.Windows.Forms.TextBox
    Friend WithEvents btnGroupEdit As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents btnGroupFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents chkIncludeChildren As System.Windows.Forms.CheckBox
    Friend WithEvents cmbStatus As System.Windows.Forms.ComboBox
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(SupplierFilterSubPanel))
      Me.lblName = New System.Windows.Forms.Label
      Me.txtName = New System.Windows.Forms.TextBox
      Me.lblGroup = New System.Windows.Forms.Label
      Me.txtGroupCode = New System.Windows.Forms.TextBox
      Me.lblAddress = New System.Windows.Forms.Label
      Me.txtAddress = New System.Windows.Forms.TextBox
      Me.lblPhone = New System.Windows.Forms.Label
      Me.txtPhone = New System.Windows.Forms.TextBox
      Me.lblProvince = New System.Windows.Forms.Label
      Me.cmbProvince = New System.Windows.Forms.ComboBox
      Me.lblCode = New System.Windows.Forms.Label
      Me.txtCode = New System.Windows.Forms.TextBox
      Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
      Me.chkIncludeChildren = New System.Windows.Forms.CheckBox
      Me.btnGroupEdit = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.btnGroupFind = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.btnReset = New System.Windows.Forms.Button
      Me.btnSearch = New System.Windows.Forms.Button
      Me.txtGroupName = New System.Windows.Forms.TextBox
      Me.cmbStatus = New System.Windows.Forms.ComboBox
      Me.lblStatus = New System.Windows.Forms.Label
      Me.grbDetail.SuspendLayout()
      Me.SuspendLayout()
      '
      'lblName
      '
      Me.lblName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblName.ForeColor = System.Drawing.Color.Black
      Me.lblName.Location = New System.Drawing.Point(8, 49)
      Me.lblName.Name = "lblName"
      Me.lblName.Size = New System.Drawing.Size(104, 18)
      Me.lblName.TabIndex = 6
      Me.lblName.Text = "Name/Other Name:"
      Me.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtName
      '
      Me.txtName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.txtName.Location = New System.Drawing.Point(112, 48)
      Me.txtName.Name = "txtName"
      Me.txtName.Size = New System.Drawing.Size(224, 21)
      Me.txtName.TabIndex = 1
      Me.txtName.Text = ""
      '
      'lblGroup
      '
      Me.lblGroup.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblGroup.ForeColor = System.Drawing.Color.Black
      Me.lblGroup.Location = New System.Drawing.Point(344, 72)
      Me.lblGroup.Name = "lblGroup"
      Me.lblGroup.Size = New System.Drawing.Size(104, 18)
      Me.lblGroup.TabIndex = 4
      Me.lblGroup.Text = "Supplier Group:"
      Me.lblGroup.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtGroupCode
      '
      Me.txtGroupCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.txtGroupCode.Location = New System.Drawing.Point(456, 72)
      Me.txtGroupCode.Name = "txtGroupCode"
      Me.txtGroupCode.Size = New System.Drawing.Size(72, 21)
      Me.txtGroupCode.TabIndex = 5
      Me.txtGroupCode.Text = ""
      '
      'lblAddress
      '
      Me.lblAddress.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblAddress.ForeColor = System.Drawing.Color.Black
      Me.lblAddress.Location = New System.Drawing.Point(8, 73)
      Me.lblAddress.Name = "lblAddress"
      Me.lblAddress.Size = New System.Drawing.Size(104, 18)
      Me.lblAddress.TabIndex = 6
      Me.lblAddress.Text = "Address:"
      Me.lblAddress.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtAddress
      '
      Me.txtAddress.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.txtAddress.Location = New System.Drawing.Point(112, 72)
      Me.txtAddress.Name = "txtAddress"
      Me.txtAddress.Size = New System.Drawing.Size(224, 21)
      Me.txtAddress.TabIndex = 2
      Me.txtAddress.Text = ""
      '
      'lblPhone
      '
      Me.lblPhone.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblPhone.ForeColor = System.Drawing.Color.Black
      Me.lblPhone.Location = New System.Drawing.Point(344, 24)
      Me.lblPhone.Name = "lblPhone"
      Me.lblPhone.Size = New System.Drawing.Size(104, 18)
      Me.lblPhone.TabIndex = 6
      Me.lblPhone.Text = "Telephone/Fax:"
      Me.lblPhone.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtPhone
      '
      Me.txtPhone.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.txtPhone.Location = New System.Drawing.Point(456, 24)
      Me.txtPhone.Name = "txtPhone"
      Me.txtPhone.Size = New System.Drawing.Size(264, 21)
      Me.txtPhone.TabIndex = 4
      Me.txtPhone.Text = ""
      '
      'lblProvince
      '
      Me.lblProvince.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblProvince.ForeColor = System.Drawing.Color.Black
      Me.lblProvince.Location = New System.Drawing.Point(8, 96)
      Me.lblProvince.Name = "lblProvince"
      Me.lblProvince.Size = New System.Drawing.Size(104, 18)
      Me.lblProvince.TabIndex = 6
      Me.lblProvince.Text = "Province:"
      Me.lblProvince.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'cmbProvince
      '
      Me.cmbProvince.Location = New System.Drawing.Point(112, 96)
      Me.cmbProvince.Name = "cmbProvince"
      Me.cmbProvince.Size = New System.Drawing.Size(224, 21)
      Me.cmbProvince.TabIndex = 3
      '
      'lblCode
      '
      Me.lblCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCode.ForeColor = System.Drawing.Color.Black
      Me.lblCode.Location = New System.Drawing.Point(8, 25)
      Me.lblCode.Name = "lblCode"
      Me.lblCode.Size = New System.Drawing.Size(104, 18)
      Me.lblCode.TabIndex = 6
      Me.lblCode.Text = "Code:"
      Me.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtCode
      '
      Me.txtCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.txtCode.Location = New System.Drawing.Point(112, 24)
      Me.txtCode.Name = "txtCode"
      Me.txtCode.Size = New System.Drawing.Size(224, 21)
      Me.txtCode.TabIndex = 0
      Me.txtCode.Text = ""
      '
      'grbDetail
      '
      Me.grbDetail.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.grbDetail.Controls.Add(Me.chkIncludeChildren)
      Me.grbDetail.Controls.Add(Me.btnGroupEdit)
      Me.grbDetail.Controls.Add(Me.btnGroupFind)
      Me.grbDetail.Controls.Add(Me.btnReset)
      Me.grbDetail.Controls.Add(Me.btnSearch)
      Me.grbDetail.Controls.Add(Me.txtGroupCode)
      Me.grbDetail.Controls.Add(Me.txtName)
      Me.grbDetail.Controls.Add(Me.txtAddress)
      Me.grbDetail.Controls.Add(Me.cmbProvince)
      Me.grbDetail.Controls.Add(Me.txtCode)
      Me.grbDetail.Controls.Add(Me.txtPhone)
      Me.grbDetail.Controls.Add(Me.lblCode)
      Me.grbDetail.Controls.Add(Me.lblName)
      Me.grbDetail.Controls.Add(Me.lblPhone)
      Me.grbDetail.Controls.Add(Me.lblGroup)
      Me.grbDetail.Controls.Add(Me.lblProvince)
      Me.grbDetail.Controls.Add(Me.lblAddress)
      Me.grbDetail.Controls.Add(Me.txtGroupName)
      Me.grbDetail.Controls.Add(Me.cmbStatus)
      Me.grbDetail.Controls.Add(Me.lblStatus)
      Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbDetail.Location = New System.Drawing.Point(8, 8)
      Me.grbDetail.Name = "grbDetail"
      Me.grbDetail.Size = New System.Drawing.Size(736, 152)
      Me.grbDetail.TabIndex = 9
      Me.grbDetail.TabStop = False
      '
      'chkIncludeChildren
      '
      Me.chkIncludeChildren.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.chkIncludeChildren.Location = New System.Drawing.Point(456, 96)
      Me.chkIncludeChildren.Name = "chkIncludeChildren"
      Me.chkIncludeChildren.Size = New System.Drawing.Size(128, 16)
      Me.chkIncludeChildren.TabIndex = 253
      Me.chkIncludeChildren.Text = "Include Child Group"
      '
      'btnGroupEdit
      '
      Me.btnGroupEdit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnGroupEdit.Image = CType(resources.GetObject("btnGroupEdit.Image"), System.Drawing.Image)
      Me.btnGroupEdit.Location = New System.Drawing.Point(696, 72)
      Me.btnGroupEdit.Name = "btnGroupEdit"
      Me.btnGroupEdit.Size = New System.Drawing.Size(24, 23)
      Me.btnGroupEdit.TabIndex = 252
      Me.btnGroupEdit.TabStop = False
      Me.btnGroupEdit.ThemedImage = CType(resources.GetObject("btnGroupEdit.ThemedImage"), System.Drawing.Bitmap)
      '
      'btnGroupFind
      '
      Me.btnGroupFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnGroupFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnGroupFind.Image = CType(resources.GetObject("btnGroupFind.Image"), System.Drawing.Image)
      Me.btnGroupFind.Location = New System.Drawing.Point(672, 72)
      Me.btnGroupFind.Name = "btnGroupFind"
      Me.btnGroupFind.Size = New System.Drawing.Size(24, 23)
      Me.btnGroupFind.TabIndex = 251
      Me.btnGroupFind.TabStop = False
      Me.btnGroupFind.ThemedImage = CType(resources.GetObject("btnGroupFind.ThemedImage"), System.Drawing.Bitmap)
      '
      'btnReset
      '
      Me.btnReset.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnReset.Location = New System.Drawing.Point(552, 120)
      Me.btnReset.Name = "btnReset"
      Me.btnReset.TabIndex = 8
      Me.btnReset.Text = "Reset"
      '
      'btnSearch
      '
      Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnSearch.Location = New System.Drawing.Point(632, 120)
      Me.btnSearch.Name = "btnSearch"
      Me.btnSearch.TabIndex = 7
      Me.btnSearch.Text = "Search"
      '
      'txtGroupName
      '
      Me.txtGroupName.BackColor = System.Drawing.SystemColors.Control
      Me.txtGroupName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.txtGroupName.Location = New System.Drawing.Point(528, 72)
      Me.txtGroupName.Name = "txtGroupName"
      Me.txtGroupName.ReadOnly = True
      Me.txtGroupName.Size = New System.Drawing.Size(144, 21)
      Me.txtGroupName.TabIndex = 5
      Me.txtGroupName.Text = ""
      '
      'cmbStatus
      '
      Me.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbStatus.Location = New System.Drawing.Point(456, 48)
      Me.cmbStatus.Name = "cmbStatus"
      Me.cmbStatus.Size = New System.Drawing.Size(264, 21)
      Me.cmbStatus.TabIndex = 3
      '
      'lblStatus
      '
      Me.lblStatus.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblStatus.ForeColor = System.Drawing.Color.Black
      Me.lblStatus.Location = New System.Drawing.Point(352, 48)
      Me.lblStatus.Name = "lblStatus"
      Me.lblStatus.Size = New System.Drawing.Size(96, 18)
      Me.lblStatus.TabIndex = 6
      Me.lblStatus.Text = "Status:"
      Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'SupplierFilterSubPanel
      '
      Me.Controls.Add(Me.grbDetail)
      Me.Name = "SupplierFilterSubPanel"
      Me.Size = New System.Drawing.Size(752, 168)
      Me.grbDetail.ResumeLayout(False)
      Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Member"
    Private m_suppliergroup As New SupplierGroup
#End Region

#Region "Constructors"
    Public Sub New()
      MyBase.New()

      InitializeComponent()
      Initialize()
      SetLabelText()
      ClearCriterias()
    End Sub
#End Region

#Region "Methods"
    Private Sub Initialize()
      Province.ListProvinceInComboBox(Me.cmbProvince)
      With Me.cmbStatus
        .Items.Clear()
        .Items.Add(Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SupplierFilterSubPanel.CurrentUseStatus}"))
        .Items.Add(Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SupplierFilterSubPanel.CanceledStatus}"))
        .Items.Add(Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SupplierFilterSubPanel.NotSpecifiedStatus}"))
      End With
    End Sub
    Public Sub SetLabelText()
      Me.lblName.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SupplierFilterSubPanel.lblName}")
      Me.lblGroup.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SupplierFilterSubPanel.lblGroup}")
      Me.grbDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SupplierFilterSubPanel.grbDetail}")
      Me.lblAddress.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SupplierFilterSubPanel.lblAddress}")
      Me.lblPhone.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SupplierFilterSubPanel.lblPhone}")
      Me.lblProvince.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SupplierFilterSubPanel.lblProvince}")
      Me.lblCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SupplierFilterSubPanel.lblCode}")
      Me.btnSearch.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SupplierFilterSubPanel.btnSearch}")
      Me.btnReset.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SupplierFilterSubPanel.btnReset}")
      Me.lblStatus.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SupplierFilterSubPanel.lblStatus}")
    End Sub
    Public Overrides Function GetFilterString() As String

    End Function
    Public Overrides Function GetFilterArray() As Filter()
      Dim arr(8) As Filter
      arr(0) = New Filter("addressBillingAddress", IIf(Me.txtAddress.Text.Length = 0, DBNull.Value, Me.txtAddress.Text))
      arr(1) = New Filter("code", IIf(Me.txtCode.Text.Length = 0, DBNull.Value, Me.txtCode.Text))
      arr(2) = New Filter("spg_id", DBNull.Value)
      arr(3) = New Filter("nameAltName", IIf(Me.txtName.Text.Length = 0, DBNull.Value, Me.txtName.Text))
      arr(4) = New Filter("phoneFax", IIf(Me.txtPhone.Text.Length = 0, DBNull.Value, Me.txtPhone.Text))
      arr(5) = New Filter("province", IIf(Me.cmbProvince.Text.Length > 0, Me.cmbProvince.Text, DBNull.Value))
      arr(6) = New Filter("suppliergroup", IIf(Me.SupplierGroup.Valid, Me.SupplierGroup.Id, DBNull.Value))
      arr(7) = New Filter("IncludeChildSPG", Me.chkIncludeChildren.Checked)
      arr(8) = New Filter("Status", Me.cmbStatus.SelectedIndex)
      Return arr
    End Function
    Private Property SupplierGroup() As SupplierGroup
      Get
        Return m_suppliergroup
      End Get
      Set(ByVal Value As SupplierGroup)
        m_suppliergroup = Value
      End Set

    End Property
    Public Overrides ReadOnly Property SearchButton() As System.Windows.Forms.Button
      Get
        Return Me.btnSearch
      End Get
    End Property
#End Region

#Region "IClipboardHandler Overrides"
    Public Overrides ReadOnly Property EnablePaste() As Boolean
      Get
        Dim data As IDataObject = Clipboard.GetDataObject
        If data.GetDataPresent((New SupplierGroup).FullClassName) Then
          If Not Me.ActiveControl Is Nothing Then
            Select Case Me.ActiveControl.Name.ToLower
              Case "txtgroupcode", "txtgroupname"
                Return True
            End Select
          End If
        End If
      End Get
    End Property
    Public Overrides Sub Paste(ByVal sender As Object, ByVal e As System.EventArgs)
      Dim data As IDataObject = Clipboard.GetDataObject
      If data.GetDataPresent((New SupplierGroup).FullClassName) Then
        Dim id As Integer = CInt(data.GetData((New SupplierGroup).FullClassName))
        Dim entity As New SupplierGroup(id)
        If Not Me.ActiveControl Is Nothing Then
          Select Case Me.ActiveControl.Name.ToLower
            Case "txtgroupcode", "txtgroupname"
              Me.SetSupplierGroupDialog(entity)
          End Select
        End If
      End If
    End Sub
#End Region

    Private Sub ClearCriterias()
      Me.txtCode.Text = ""
      Me.txtName.Text = ""
      Me.txtAddress.Text = ""
      Me.txtPhone.Text = ""
      Me.txtGroupCode.Text = ""
      Me.txtGroupName.Text = ""
      Me.SupplierGroup = New SupplierGroup
      Me.cmbProvince.SelectedIndex = -1
      'Me.cmbProvince.SelectedIndex = -1
      If Me.cmbStatus.Items.Count > 0 Then Me.cmbStatus.SelectedIndex = 0
    End Sub

    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
      ClearCriterias()
      Me.btnSearch.PerformClick()
    End Sub

    Private Sub txtGroupCode_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtGroupCode.Validated
      SupplierGroup.GetSupplierGroup(txtGroupCode, txtGroupName, Me.SupplierGroup, True)
    End Sub

    Private Sub btnGroupFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGroupFind.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenTreeDialog(New SupplierGroup, AddressOf SetSupplierGroupDialog)
    End Sub

    Private Sub SetSupplierGroupDialog(ByVal e As ISimpleEntity)
      Me.txtGroupCode.Text = e.Code
      SupplierGroup.GetSupplierGroup(txtGroupCode, txtGroupName, Me.SupplierGroup, True)
    End Sub

    Private Sub btnGroupEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGroupEdit.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenPanel(New SupplierGroup)
    End Sub

    Private Sub txtName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtName.TextChanged

    End Sub

    Protected Overrides ReadOnly Property ShowFocusCues() As Boolean
      Get

      End Get
    End Property

    Private Sub txtAddress_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAddress.TextChanged

    End Sub
  End Class
End Namespace

