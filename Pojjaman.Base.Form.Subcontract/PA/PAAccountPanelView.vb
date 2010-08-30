Option Strict On
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Gui
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Drawing.Printing
Imports Longkong.Pojjaman.Gui.Components
Imports System.Globalization
Imports System.Reflection
Imports Longkong.Pojjaman.TextHelper
Imports Longkong.Pojjaman.Gui.ReportsAndDocs
Namespace Longkong.Pojjaman.Gui.Panels
  Public Class PAAccountPanelView
    Inherits AbstractEntityDetailPanelView
    Implements IValidatable, Commands.IPreviewable

#Region " Windows Form Designer generated code "
    Friend WithEvents lblCode As System.Windows.Forms.Label
    Friend WithEvents lblDocDate As System.Windows.Forms.Label
    Friend WithEvents tgItem As Longkong.Pojjaman.Gui.Components.TreeGrid
    Friend WithEvents lblSupplier As System.Windows.Forms.Label
    Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents grbDetail As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents lblItem As System.Windows.Forms.Label
    Friend WithEvents txtDocDate As System.Windows.Forms.TextBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents txtCostCenterName As System.Windows.Forms.TextBox
    Friend WithEvents lblCostCenter As System.Windows.Forms.Label
    Friend WithEvents txtCostCenterCode As System.Windows.Forms.TextBox
    Friend WithEvents cmbCode As System.Windows.Forms.ComboBox
    Friend WithEvents txtSCCode As System.Windows.Forms.TextBox
    Friend WithEvents lblSCCode As System.Windows.Forms.Label
    Friend WithEvents txtSubContractorCode As System.Windows.Forms.TextBox
    Friend WithEvents txtSubContractorName As System.Windows.Forms.TextBox
    Friend WithEvents txtDirectorName As System.Windows.Forms.TextBox
    Friend WithEvents txtDirectorCode As System.Windows.Forms.TextBox
    Friend WithEvents lblDirector As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Protected Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container
      Me.tgItem = New Longkong.Pojjaman.Gui.Components.TreeGrid
      Me.lblCode = New System.Windows.Forms.Label
      Me.lblDocDate = New System.Windows.Forms.Label
      Me.lblSupplier = New System.Windows.Forms.Label
      Me.txtSubContractorCode = New System.Windows.Forms.TextBox
      Me.txtSubContractorName = New System.Windows.Forms.TextBox
      Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider
      Me.txtDocDate = New System.Windows.Forms.TextBox
      Me.txtCostCenterCode = New System.Windows.Forms.TextBox
      Me.txtCostCenterName = New System.Windows.Forms.TextBox
      Me.txtSCCode = New System.Windows.Forms.TextBox
      Me.txtDirectorName = New System.Windows.Forms.TextBox
      Me.txtDirectorCode = New System.Windows.Forms.TextBox
      Me.lblItem = New System.Windows.Forms.Label
      Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
      Me.lblDirector = New System.Windows.Forms.Label
      Me.lblSCCode = New System.Windows.Forms.Label
      Me.cmbCode = New System.Windows.Forms.ComboBox
      Me.lblCostCenter = New System.Windows.Forms.Label
      Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
      CType(Me.tgItem, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.grbDetail.SuspendLayout()
      Me.SuspendLayout()
      '
      'tgItem
      '
      Me.tgItem.AllowDrop = True
      Me.tgItem.AllowNew = False
      Me.tgItem.AllowSorting = False
      Me.tgItem.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.tgItem.AutoColumnResize = True
      Me.tgItem.CaptionVisible = False
      Me.tgItem.Cellchanged = False
      Me.tgItem.ColorList.AddRange(New System.Drawing.Color() {System.Drawing.Color.FromArgb(CType(255, Byte), CType(128, Byte), CType(0, Byte)), System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(128, Byte))})
      Me.tgItem.DataMember = ""
      Me.tgItem.HeaderBackColor = System.Drawing.Color.Khaki
      Me.tgItem.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.tgItem.HeaderForeColor = System.Drawing.SystemColors.ControlText
      Me.tgItem.Location = New System.Drawing.Point(8, 143)
      Me.tgItem.Name = "tgItem"
      Me.tgItem.Size = New System.Drawing.Size(760, 393)
      Me.tgItem.SortingArrowColor = System.Drawing.Color.Red
      Me.tgItem.TabIndex = 8
      Me.tgItem.TreeManager = Nothing
      '
      'lblCode
      '
      Me.lblCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCode.Location = New System.Drawing.Point(8, 16)
      Me.lblCode.Name = "lblCode"
      Me.lblCode.Size = New System.Drawing.Size(88, 18)
      Me.lblCode.TabIndex = 11
      Me.lblCode.Text = "รหัส:"
      Me.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblDocDate
      '
      Me.lblDocDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDocDate.Location = New System.Drawing.Point(376, 16)
      Me.lblDocDate.Name = "lblDocDate"
      Me.lblDocDate.Size = New System.Drawing.Size(72, 18)
      Me.lblDocDate.TabIndex = 14
      Me.lblDocDate.Text = "วันที่:"
      Me.lblDocDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblSupplier
      '
      Me.lblSupplier.BackColor = System.Drawing.Color.Transparent
      Me.lblSupplier.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblSupplier.Location = New System.Drawing.Point(16, 64)
      Me.lblSupplier.Name = "lblSupplier"
      Me.lblSupplier.Size = New System.Drawing.Size(80, 18)
      Me.lblSupplier.TabIndex = 20
      Me.lblSupplier.Text = "ผู้รับเหมา:"
      Me.lblSupplier.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtSubContractorCode
      '
      Me.Validator.SetDataType(Me.txtSubContractorCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtSubContractorCode, "")
      Me.Validator.SetGotFocusBackColor(Me.txtSubContractorCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtSubContractorCode, System.Drawing.Color.Empty)
      Me.txtSubContractorCode.Location = New System.Drawing.Point(96, 64)
      Me.txtSubContractorCode.MaxLength = 20
      Me.Validator.SetMaxValue(Me.txtSubContractorCode, "")
      Me.Validator.SetMinValue(Me.txtSubContractorCode, "")
      Me.txtSubContractorCode.Name = "txtSubContractorCode"
      Me.txtSubContractorCode.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtSubContractorCode, "")
      Me.Validator.SetRequired(Me.txtSubContractorCode, False)
      Me.txtSubContractorCode.Size = New System.Drawing.Size(72, 21)
      Me.txtSubContractorCode.TabIndex = 4
      Me.txtSubContractorCode.Text = ""
      '
      'txtSubContractorName
      '
      Me.txtSubContractorName.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtSubContractorName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtSubContractorName, "")
      Me.Validator.SetGotFocusBackColor(Me.txtSubContractorName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtSubContractorName, System.Drawing.Color.Empty)
      Me.txtSubContractorName.Location = New System.Drawing.Point(168, 64)
      Me.Validator.SetMaxValue(Me.txtSubContractorName, "")
      Me.Validator.SetMinValue(Me.txtSubContractorName, "")
      Me.txtSubContractorName.Name = "txtSubContractorName"
      Me.txtSubContractorName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtSubContractorName, "")
      Me.Validator.SetRequired(Me.txtSubContractorName, False)
      Me.txtSubContractorName.Size = New System.Drawing.Size(192, 21)
      Me.txtSubContractorName.TabIndex = 24
      Me.txtSubContractorName.TabStop = False
      Me.txtSubContractorName.Text = ""
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
      'txtDocDate
      '
      Me.Validator.SetDataType(Me.txtDocDate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtDocDate, "")
      Me.Validator.SetGotFocusBackColor(Me.txtDocDate, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtDocDate, -13)
      Me.Validator.SetInvalidBackColor(Me.txtDocDate, System.Drawing.Color.Empty)
      Me.txtDocDate.Location = New System.Drawing.Point(448, 16)
      Me.Validator.SetMaxValue(Me.txtDocDate, "")
      Me.Validator.SetMinValue(Me.txtDocDate, "")
      Me.txtDocDate.Name = "txtDocDate"
      Me.txtDocDate.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtDocDate, "")
      Me.Validator.SetRequired(Me.txtDocDate, True)
      Me.txtDocDate.Size = New System.Drawing.Size(136, 21)
      Me.txtDocDate.TabIndex = 1
      Me.txtDocDate.Text = ""
      '
      'txtCostCenterCode
      '
      Me.Validator.SetDataType(Me.txtCostCenterCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtCostCenterCode, "")
      Me.Validator.SetGotFocusBackColor(Me.txtCostCenterCode, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtCostCenterCode, -15)
      Me.Validator.SetInvalidBackColor(Me.txtCostCenterCode, System.Drawing.Color.Empty)
      Me.txtCostCenterCode.Location = New System.Drawing.Point(96, 88)
      Me.Validator.SetMaxValue(Me.txtCostCenterCode, "")
      Me.Validator.SetMinValue(Me.txtCostCenterCode, "")
      Me.txtCostCenterCode.Name = "txtCostCenterCode"
      Me.txtCostCenterCode.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtCostCenterCode, "")
      Me.Validator.SetRequired(Me.txtCostCenterCode, False)
      Me.txtCostCenterCode.Size = New System.Drawing.Size(72, 21)
      Me.txtCostCenterCode.TabIndex = 5
      Me.txtCostCenterCode.Text = ""
      '
      'txtCostCenterName
      '
      Me.txtCostCenterName.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtCostCenterName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtCostCenterName, "")
      Me.Validator.SetGotFocusBackColor(Me.txtCostCenterName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtCostCenterName, System.Drawing.Color.Empty)
      Me.txtCostCenterName.Location = New System.Drawing.Point(168, 88)
      Me.Validator.SetMaxValue(Me.txtCostCenterName, "")
      Me.Validator.SetMinValue(Me.txtCostCenterName, "")
      Me.txtCostCenterName.Name = "txtCostCenterName"
      Me.txtCostCenterName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtCostCenterName, "")
      Me.Validator.SetRequired(Me.txtCostCenterName, False)
      Me.txtCostCenterName.Size = New System.Drawing.Size(192, 21)
      Me.txtCostCenterName.TabIndex = 25
      Me.txtCostCenterName.TabStop = False
      Me.txtCostCenterName.Text = ""
      '
      'txtSCCode
      '
      Me.Validator.SetDataType(Me.txtSCCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtSCCode, "")
      Me.txtSCCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtSCCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtSCCode, System.Drawing.Color.Empty)
      Me.txtSCCode.Location = New System.Drawing.Point(96, 40)
      Me.Validator.SetMaxValue(Me.txtSCCode, "")
      Me.Validator.SetMinValue(Me.txtSCCode, "")
      Me.txtSCCode.Name = "txtSCCode"
      Me.txtSCCode.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtSCCode, "")
      Me.Validator.SetRequired(Me.txtSCCode, False)
      Me.txtSCCode.Size = New System.Drawing.Size(184, 21)
      Me.txtSCCode.TabIndex = 334
      Me.txtSCCode.TabStop = False
      Me.txtSCCode.Text = ""
      '
      'txtDirectorName
      '
      Me.txtDirectorName.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtDirectorName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtDirectorName, "")
      Me.Validator.SetGotFocusBackColor(Me.txtDirectorName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtDirectorName, System.Drawing.Color.Empty)
      Me.txtDirectorName.Location = New System.Drawing.Point(520, 40)
      Me.Validator.SetMaxValue(Me.txtDirectorName, "")
      Me.Validator.SetMinValue(Me.txtDirectorName, "")
      Me.txtDirectorName.Name = "txtDirectorName"
      Me.txtDirectorName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtDirectorName, "")
      Me.Validator.SetRequired(Me.txtDirectorName, False)
      Me.txtDirectorName.Size = New System.Drawing.Size(240, 21)
      Me.txtDirectorName.TabIndex = 375
      Me.txtDirectorName.TabStop = False
      Me.txtDirectorName.Text = ""
      '
      'txtDirectorCode
      '
      Me.Validator.SetDataType(Me.txtDirectorCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtDirectorCode, "")
      Me.Validator.SetGotFocusBackColor(Me.txtDirectorCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtDirectorCode, System.Drawing.Color.Empty)
      Me.txtDirectorCode.Location = New System.Drawing.Point(448, 40)
      Me.Validator.SetMaxValue(Me.txtDirectorCode, "")
      Me.Validator.SetMinValue(Me.txtDirectorCode, "")
      Me.txtDirectorCode.Name = "txtDirectorCode"
      Me.txtDirectorCode.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtDirectorCode, "")
      Me.Validator.SetRequired(Me.txtDirectorCode, False)
      Me.txtDirectorCode.Size = New System.Drawing.Size(72, 21)
      Me.txtDirectorCode.TabIndex = 373
      Me.txtDirectorCode.Text = ""
      '
      'lblItem
      '
      Me.lblItem.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblItem.Location = New System.Drawing.Point(8, 115)
      Me.lblItem.Name = "lblItem"
      Me.lblItem.Size = New System.Drawing.Size(88, 18)
      Me.lblItem.TabIndex = 33
      Me.lblItem.Text = "รายการรับงาน"
      Me.lblItem.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'grbDetail
      '
      Me.grbDetail.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.grbDetail.Controls.Add(Me.txtDirectorName)
      Me.grbDetail.Controls.Add(Me.txtDirectorCode)
      Me.grbDetail.Controls.Add(Me.lblDirector)
      Me.grbDetail.Controls.Add(Me.lblSCCode)
      Me.grbDetail.Controls.Add(Me.txtSCCode)
      Me.grbDetail.Controls.Add(Me.cmbCode)
      Me.grbDetail.Controls.Add(Me.txtCostCenterName)
      Me.grbDetail.Controls.Add(Me.lblCostCenter)
      Me.grbDetail.Controls.Add(Me.txtCostCenterCode)
      Me.grbDetail.Controls.Add(Me.txtDocDate)
      Me.grbDetail.Controls.Add(Me.txtSubContractorName)
      Me.grbDetail.Controls.Add(Me.tgItem)
      Me.grbDetail.Controls.Add(Me.lblCode)
      Me.grbDetail.Controls.Add(Me.lblDocDate)
      Me.grbDetail.Controls.Add(Me.lblItem)
      Me.grbDetail.Controls.Add(Me.lblSupplier)
      Me.grbDetail.Controls.Add(Me.txtSubContractorCode)
      Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbDetail.Location = New System.Drawing.Point(0, 0)
      Me.grbDetail.Name = "grbDetail"
      Me.grbDetail.Size = New System.Drawing.Size(776, 544)
      Me.grbDetail.TabIndex = 0
      Me.grbDetail.TabStop = False
      Me.grbDetail.Text = "รายละเอียด"
      '
      'lblDirector
      '
      Me.lblDirector.BackColor = System.Drawing.Color.Transparent
      Me.lblDirector.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDirector.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblDirector.Location = New System.Drawing.Point(360, 40)
      Me.lblDirector.Name = "lblDirector"
      Me.lblDirector.Size = New System.Drawing.Size(88, 18)
      Me.lblDirector.TabIndex = 374
      Me.lblDirector.Text = "ผู้สั่งจ้าง:"
      Me.lblDirector.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblSCCode
      '
      Me.lblSCCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblSCCode.ForeColor = System.Drawing.Color.Black
      Me.lblSCCode.Location = New System.Drawing.Point(8, 40)
      Me.lblSCCode.Name = "lblSCCode"
      Me.lblSCCode.Size = New System.Drawing.Size(88, 18)
      Me.lblSCCode.TabIndex = 335
      Me.lblSCCode.Text = "เลขที่ SC:"
      Me.lblSCCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'cmbCode
      '
      Me.cmbCode.BackColor = System.Drawing.SystemColors.Control
      Me.cmbCode.Enabled = False
      Me.cmbCode.Location = New System.Drawing.Point(96, 16)
      Me.cmbCode.Name = "cmbCode"
      Me.cmbCode.Size = New System.Drawing.Size(184, 21)
      Me.cmbCode.TabIndex = 333
      '
      'lblCostCenter
      '
      Me.lblCostCenter.BackColor = System.Drawing.Color.Transparent
      Me.lblCostCenter.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCostCenter.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblCostCenter.Location = New System.Drawing.Point(16, 88)
      Me.lblCostCenter.Name = "lblCostCenter"
      Me.lblCostCenter.Size = New System.Drawing.Size(80, 18)
      Me.lblCostCenter.TabIndex = 21
      Me.lblCostCenter.Text = "CostCenter:"
      Me.lblCostCenter.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'PAAccountPanelView
      '
      Me.Controls.Add(Me.grbDetail)
      Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Name = "PAAccountPanelView"
      Me.Size = New System.Drawing.Size(784, 552)
      CType(Me.tgItem, System.ComponentModel.ISupportInitialize).EndInit()
      Me.grbDetail.ResumeLayout(False)
      Me.ResumeLayout(False)

    End Sub
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
#End Region

#Region "Members"
    Private m_entity As PA
    Private m_isInitialized As Boolean = False
    Private m_treeManager As TreeManager

    'Private dummyCC As New CostCenter
    'Private dummyEmployee As New Employee

    'Private m_treeManager2 As TreeManager
    'Private m_wbsdInitialized As Boolean

    Private m_enableState As Hashtable
    Private m_tableStyleEnable As Hashtable
#End Region

#Region "Constructors"
    Public Sub New()
      MyBase.New()
      Me.InitializeComponent()
      Me.SetLabelText()
      Initialize()

      SaveEnableState()

      Dim dt As TreeTable = PA.GetSchemaTable()
      Dim dst As DataGridTableStyle = Me.CreateTableStyle()
      m_treeManager = New TreeManager(dt, tgItem)
      m_treeManager.SetTableStyle(dst)
      m_treeManager.AllowSorting = False
      m_treeManager.AllowDelete = False
      Me.Validator.DataTable = m_treeManager.Treetable

      AddHandler dt.ColumnChanging, AddressOf ItemTreetable_ColumnChanging
      AddHandler dt.ColumnChanged, AddressOf ItemTreetable_ColumnChanged
      AddHandler dt.RowDeleted, AddressOf PAItemDelete

      EventWiring()
    End Sub
    Private Sub SaveEnableState()
      m_enableState = New Hashtable
      For Each ctrl As Control In Me.grbDetail.Controls
        m_enableState.Add(ctrl, ctrl.Enabled)
      Next
      For Each ctrl As Control In Me.Controls
        m_enableState.Add(ctrl, ctrl.Enabled)
      Next
    End Sub
#End Region

#Region "Style"
    Public Sub SetHilightValues(ByVal sender As Object, ByVal e As DataGridHilightEventArgs)
      '    e.HilightValue = False
      '    e.RedText = False
      '    Dim i As Integer = 0
      '    For Each row As DataRow In Me.m_treeManager2.Treetable.Rows
      '        For Each col As DataColumn In Me.m_treeManager2.Treetable.Columns
      '            If col.Ordinal > 0 Then
      '                If Not row.IsNull(col) AndAlso IsNumeric(row(col)) Then
      '                    If CDec(row(col)) < 0 Then
      '                        If e.Column = col.Ordinal And e.Row = i Then
      '                            e.HilightValue = True
      '                            e.RedText = True
      '                        End If
      '                    End If
      '                End If
      '            End If
      '        Next
      '        i += 1
      '    Next
    End Sub
    'ปุ่ม CC
    Public Sub CCButtonClicked(ByVal e As ButtonColumnEventArgs)
      If Me.m_entity Is Nothing Then
        Return
      End If
      If Me.m_entity.CostCenter Is Nothing Then
        Return
      End If
      If Me.m_entity.CostCenter.BoqId = 0 Then
        Return
      End If
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      Dim entity As New CostCenter
      Dim entities As New ArrayList
      myEntityPanelService.OpenListDialog(entity, AddressOf SetCostCenter)
    End Sub
    Private Sub SetCostCenter(ByVal myEntity As ISimpleEntity)
      'Dim doc As PAItem = Me.m_entity.ItemCollection.CurrentItem
      'If doc Is Nothing Then
      '    Return
      'End If
      'Dim dt As TreeTable = Me.m_treeManager2.Treetable
      'Dim wsdColl As WBSDistributeCollection = doc.WBSDistributeCollection
      'Dim row As TreeRow = Me.m_treeManager2.SelectedRow
      'If TypeOf myEntity Is CostCenter Then
      '    CType(row.Tag, WBSDistribute).CostCenter = CType(myEntity, CostCenter)
      '    CType(row.Tag, WBSDistribute).WBS = New WBS
      'End If
      'Dim view As Integer = 45
      'm_wbsdInitialized = False
      ''wsdColl.Populate(dt, doc, view)
      'm_wbsdInitialized = True
      'Me.WorkbenchWindow.ViewContent.IsDirty = True
    End Sub
    Private Function CreateTableStyle() As DataGridTableStyle
      Dim dst As New DataGridTableStyle
      dst.MappingName = "PA"
      Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)

      'PA Items
      Dim csLineNumber As New TreeTextColumn
      csLineNumber.MappingName = "pai_linenumber"
      csLineNumber.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PAPanelView.LineNumberHeaderText}")   '"No."
      csLineNumber.NullText = ""
      csLineNumber.Width = 30
      csLineNumber.DataAlignment = HorizontalAlignment.Center
      csLineNumber.ReadOnly = True
      csLineNumber.TextBox.Name = "pai_linenumber"

      'Dim csBarrier As New DataGridBarrierColumn
      'csBarrier.MappingName = "Barrier"
      'csBarrier.HeaderText = ""
      'csBarrier.NullText = ""
      'csBarrier.ReadOnly = True

      '"รายการ sc"
      Dim csPADesc As New TreeTextColumn
      csPADesc.MappingName = "pai_paDesc"
      csPADesc.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SCPanelView.DescriptionHeaderText}")
      csPADesc.NullText = ""
      csPADesc.Width = 175
      csPADesc.TextBox.Name = "pai_paDesc"
      csPADesc.ReadOnly = True

      '"อ้างอิง"
      Dim csRefCode As New TreeTextColumn
      csRefCode.MappingName = "pai_refDoc"
      csRefCode.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PAPanelView.RefDocHeaderText}")   '"เอกสารอ้างอิง"
      csRefCode.NullText = ""
      csRefCode.Width = 75
      csRefCode.ReadOnly = True
      csRefCode.TextBox.Name = "pai_refDoc"

      '"ประเภท"
      Dim csType As DataGridComboColumn
      csType = New DataGridComboColumn("pai_entityType" _
      , CodeDescription.GetCodeList("pai_entitytype") _
      , "code_description", "code_value")
      csType.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SCPanelView.TypeHeaderText}")
      csType.NullText = String.Empty
      csType.ReadOnly = True

      '"รหัส"
      Dim csCode As New TreeTextColumn
      csCode.MappingName = "Code"
      csCode.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PAPanelView.CodeHeaderText}")
      csCode.NullText = ""
      csCode.TextBox.Name = "Code"
      csCode.ReadOnly = True


      '"รายการ"
      Dim csName As New TreeTextColumn
      csName.MappingName = "pai_itemName"
      csName.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PAPanelView.DescriptionHeaderText}")
      csName.NullText = ""
      csName.Width = 210
      csName.TextBox.Name = "pai_itemName"
      csName.ReadOnly = True

      Dim csUnit As New TreeTextColumn
      csUnit.MappingName = "Unit"
      csUnit.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SCPanelView.UnitHeaderText}")
      csUnit.NullText = ""
      csUnit.Width = 60
      csUnit.TextBox.Name = "Unit"
      csUnit.ReadOnly = True


      '"มูลค่าตามสัญญา"
      Dim csSCCost As New TreeTextColumn
      csSCCost.MappingName = "CostAmount"
      csSCCost.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PAPanelView.SCCostHeaderText}")   '"มูลค่าตามสัญญา"
      csSCCost.NullText = ""
      csSCCost.DataAlignment = HorizontalAlignment.Right
      csSCCost.Format = "#,###.##"
      csSCCost.Width = 100
      csSCCost.ReadOnly = True
      csSCCost.TextBox.Name = "CostAmount"
      'AddHandler csUnit.TextBox.TextChanged, AddressOf ChangeProperty
      'csUnit.DataAlignment = HorizontalAlignment.Center

      '"ปริมาณตามสัญญา"
      Dim csSCQty As New TreeTextColumn
      csSCQty.MappingName = "QtyCostAmount"
      csSCQty.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PAPanelView.SCQtyHeaderText}")   '"ปริมาณตามสัญญา"
      csSCQty.NullText = ""
      csSCQty.DataAlignment = HorizontalAlignment.Right
      csSCQty.Format = "#,###.##"
      csSCQty.Width = 100
      csSCQty.ReadOnly = True
      csSCQty.TextBox.Name = "QtyCostAmount"
      'AddHandler csQty.TextBox.TextChanged, AddressOf ChangeProperty

      Dim csBarrier1 As New DataGridBarrierColumn
      csBarrier1.MappingName = "Barrier1"
      csBarrier1.HeaderText = ""
      csBarrier1.NullText = ""
      csBarrier1.ReadOnly = True


      '"รวม"
      Dim csAmount As New TreeTextColumn
      csAmount.MappingName = "Amount"
      csAmount.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PAPanelView.AmountHeaderText}")
      csAmount.NullText = ""
      csAmount.DataAlignment = HorizontalAlignment.Right
      csAmount.TextBox.Name = "Amount"
      csAmount.Width = 100
      csAmount.Format = "#,###.##"
      csAmount.ReadOnly = True
      'AddHandler csUnit.TextBox.TextChanged, AddressOf ChangeProperty
      'csUnit.DataAlignment = HorizontalAlignment.Center

      Dim csBarrier3 As New DataGridBarrierColumn
      csBarrier3.MappingName = "Barrier3"
      csBarrier3.HeaderText = ""
      csBarrier3.NullText = ""
      csBarrier3.ReadOnly = True

      Dim csMat As New TreeTextColumn
      csMat.MappingName = "pai_mat"
      csMat.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PAPanelView.MatHeaderText}")
      csMat.NullText = ""
      csMat.DataAlignment = HorizontalAlignment.Right
      csMat.ReadOnly = True
      csMat.TextBox.Name = "pai_mat"
      csMat.Width = 100
      csMat.Format = "#,###.##"
      'AddHandler csDiscount.TextBox.TextChanged, AddressOf ChangeProperty
      'csDiscount.DataAlignment = HorizontalAlignment.Center

      Dim csLab As New TreeTextColumn
      csLab.MappingName = "pai_lab"
      csLab.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PAPanelView.LABHeaderText}")
      csLab.NullText = ""
      csLab.DataAlignment = HorizontalAlignment.Right
      csLab.ReadOnly = True
      csLab.TextBox.Name = "pai_lab"
      csLab.Width = 100
      csLab.Format = "#,###.##"
      'AddHandler csDiscount.TextBox.TextChanged, AddressOf ChangeProperty
      'csDiscount.DataAlignment = HorizontalAlignment.Center

      Dim csEq As New TreeTextColumn
      csEq.MappingName = "pai_eq"
      csEq.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PAPanelView.EQHeaderText}")
      csEq.NullText = ""
      csEq.DataAlignment = HorizontalAlignment.Right
      csEq.ReadOnly = True
      csEq.TextBox.Name = "pai_eq"
      csEq.Width = 100
      csEq.Format = "#,###.##"
      'AddHandler csDiscount.TextBox.TextChanged, AddressOf ChangeProperty
      'csDiscount.DataAlignment = HorizontalAlignment.Center

      Dim csAccountCode As New TreeTextColumn
      csAccountCode.MappingName = "AccountCode"
      csAccountCode.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.AccountCodeHeaderText}")
      csAccountCode.NullText = ""
      csAccountCode.TextBox.Name = "AccountCode"

      Dim csAccountButton As New DataGridButtonColumn
      csAccountButton.MappingName = "AccountButton"
      csAccountButton.HeaderText = ""
      csAccountButton.NullText = ""
      AddHandler csAccountButton.Click, AddressOf ButtonClicked

      Dim csAccount As New TreeTextColumn
      csAccount.MappingName = "Account"
      csAccount.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.AccountHeaderText}")
      csAccount.NullText = ""
      csAccount.ReadOnly = True
      csAccount.TextBox.Name = "Account"

      Dim csVatable As New DataGridCheckBoxColumn
      csVatable.MappingName = "pai_unvatable"
      csVatable.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PAPanelView.UnVatableHeaderText}")
      csVatable.Width = 100
      csVatable.InvisibleWhenUnspcified = True



      'dst.GridColumnStyles.Add(csPADesc)
      dst.GridColumnStyles.Add(csRefCode)
      dst.GridColumnStyles.Add(csCode)
      dst.GridColumnStyles.Add(csName)
      dst.GridColumnStyles.Add(csAmount)
      dst.GridColumnStyles.Add(csType)
      dst.GridColumnStyles.Add(csAccountCode)
      dst.GridColumnStyles.Add(csAccount)
      dst.GridColumnStyles.Add(csAccountButton)

      m_tableStyleEnable = New Hashtable
      For Each colStyle As DataGridColumnStyle In dst.GridColumnStyles
        m_tableStyleEnable.Add(colStyle, colStyle.ReadOnly)
      Next
      Return dst
    End Function
    'สร้างปุ่ม Unit
    Private Sub ButtonClicked(ByVal e As ButtonColumnEventArgs)
       Me.AcctButtonClick(e)
    End Sub
#End Region

#Region "Properties"
    Private ReadOnly Property CurrentTagItem() As PAItem
      Get
        Dim row As TreeRow = Me.m_treeManager.SelectedRow
        If row Is Nothing Then
          Return Nothing
        End If
        If Not TypeOf row.Tag Is PAItem Then
          Return Nothing
        End If
        Return CType(row.Tag, PAItem)
      End Get
    End Property
    Private ReadOnly Property CurrentRealTagItem() As PAItem
      Get
        'Return CType(childRow.Tag, SCItem)
        Dim row As TreeRow = Me.m_treeManager.SelectedRow

        Try
          Dim lastIndex As Integer = row.Index
          Dim startIndex As Integer = row.Index

          For i As Integer = startIndex To Me.m_entity.ItemCollection.Count - 1
            If i > startIndex Then
              If CType(Me.m_treeManager.Treetable.Childs(i).Tag, PAItem).Level = 0 Then
                Exit For
              End If
              lastIndex = i
            End If
          Next

          Dim parentRow As TreeRow = Me.m_treeManager.Treetable.Childs(lastIndex)

          Return CType(parentRow.Tag, PAItem)
        Catch ex As Exception
          Return Nothing
        End Try

      End Get
    End Property
#End Region

#Region "ItemTreeTable Handlers"

    Private Sub ItemTreetable_ColumnChanged(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs)
      If Not m_isInitialized Then
        Return
      End If
      Me.WorkbenchWindow.ViewContent.IsDirty = True
      Dim index As Integer = Me.tgItem.CurrentRowIndex
      RefreshDocs()
      tgItem.CurrentRowIndex = index
    End Sub
    Dim doc As PAItem
    Private Sub ItemTreetable_ColumnChanging(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs)
      If Not m_isInitialized Then
        Return
      End If
      If Me.m_treeManager.SelectedRow Is Nothing Then
        Return
      End If
      If TypeOf Me.m_treeManager.SelectedRow.Parent Is TreeTable Then
        Return
      End If
      Dim tag As Object = m_treeManager.SelectedRow.Tag
      If tag Is Nothing Then
        Return
      End If

      Dim accType As String = "mataccount"
      If TypeOf tag Is PAItem Then
        doc = CType(tag, PAItem)
      Else
        doc = CType(CType(Me.m_treeManager.SelectedRow.Parent, TreeRow).Tag, PAItem)
        accType = CStr(tag)
      End If
      Try
        Select Case e.Column.ColumnName.ToLower
          Case "accountcode"
            If IsDBNull(e.ProposedValue) OrElse e.ProposedValue Is Nothing Then
              e.ProposedValue = ""
            End If
            Dim acct As New Account(e.ProposedValue.ToString)
            If acct Is Nothing OrElse Not acct.Originated Then
              e.ProposedValue = e.Row(e.Column)
              Return
            End If
            Select Case doc.ItemType.Value
              Case 289
                Select Case accType.ToLower
                  Case "mataccount"
                    doc.MatAccount = acct
                  Case "labaccount"
                    doc.LabAccount = acct
                  Case "eqaccount"
                    doc.EqAccount = acct
                End Select
              Case 88
                doc.LabAccount = acct
              Case 89
                doc.EqAccount = acct
              Case Else
                doc.MatAccount = acct
            End Select
        End Select
      Catch ex As Exception
        MessageBox.Show(ex.ToString)
      End Try
    End Sub

    Private Sub PAItemDelete(ByVal sender As Object, ByVal e As System.Data.DataRowChangeEventArgs)
    End Sub
#End Region

#Region "TreeTable Handlers"
    'Private Sub Treetable_ColumnChanged(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs)
    '    If Not m_wbsdInitialized Then
    '        Return
    '    End If
    '    Dim index As Integer = Me.m_treeManager2.Treetable.Childs.IndexOf(CType(e.Row, TreeRow))
    '    If ValidateRow(CType(e.Row, TreeRow)) Then
    '        'UpdateAmount(e)
    '        Me.m_treeManager2.Treetable.AcceptChanges()
    '    End If
    '    RefreshWBS()
    '    Me.WorkbenchWindow.ViewContent.IsDirty = True
    'End Sub
    'Private Sub UpdateAmount(ByVal e As DataColumnChangeEventArgs)
    '    Dim item As WBSDistribute = Me.CurrentWsbsd
    '    If item Is Nothing Then
    '        Return
    '    End If
    '    Dim view As Integer = 6
    '    Dim doc As PAItem = Me.m_entity.ItemCollection.CurrentItem
    '    If doc Is Nothing Then
    '        Return
    '    End If
    '    e.Row("Amount") = Configuration.FormatToString(item.Percent * doc.BeforeTax / 100, DigitConfig.Price)
    '    If Not item.IsMarkup Then
    '        e.Row("BudgetRemain") = Configuration.FormatToString(item.WBS.GetTotal - item.WBS.GetActualTotal(Me.m_entity, view) + Me.m_entity.GetCurrentAmountForWBS(item.WBS, doc.ItemType), DigitConfig.Price)
    '        e.Row("QtyRemain") = Configuration.FormatToString(0 - item.WBS.GetActualTotalQty(Me.m_entity, view) - 0, DigitConfig.Price)
    '    Else
    '        Dim mk As Markup = Me.m_entity.CostCenter.Boq.MarkupCollection.GetMarkupFromId(item.WBS.Id)
    '        If Not mk Is Nothing Then
    '            e.Row("BudgetRemain") = Configuration.FormatToString(mk.TotalAmount - mk.GetActualTotal(Me.m_entity, view) - Me.m_entity.GetCurrentAmountForMarkup(mk), DigitConfig.Price)
    '        End If
    '    End If
    'End Sub
    '-------------------------------------
    'Private Sub UpdateAmount()
    '    Dim flag As Boolean = m_isInitialized
    '    m_isInitialized = False
    '    Me.m_entity.RefreshTaxBase()

    '    'HACK: forceUpdateGross ต้องอยู่อันแรกนะจ๊ะ
    '    If forceUpdateGross OrElse (Not Me.m_entity.Originated AndAlso Me.m_entity.RealTaxBase <> Me.m_entity.TaxBase) Then
    '        Me.m_entity.RealGross = Me.m_entity.Gross
    '        forceUpdateGross = False
    '    End If
    '    If forceUpdateTaxBase OrElse (Not Me.m_entity.Originated AndAlso Me.m_entity.RealTaxBase <> Me.m_entity.TaxBase) Then
    '        Me.m_entity.RealTaxBase = Me.m_entity.TaxBase
    '        forceUpdateTaxBase = False
    '    End If
    '    If forceUpdateTaxAmount OrElse (Not Me.m_entity.Originated AndAlso Me.m_entity.RealTaxAmount <> Me.m_entity.TaxAmount) Then
    '        Me.m_entity.RealTaxAmount = Me.m_entity.TaxAmount
    '        forceUpdateTaxAmount = False
    '    End If

    '    txtGross.Text = Configuration.FormatToString(m_entity.Gross, DigitConfig.Price)
    '    txtDiscountAmount.Text = Configuration.FormatToString(m_entity.DiscountAmount, DigitConfig.Price)
    '    If m_entity.TaxType.Value = 0 OrElse m_entity.TaxType.Value = 1 Then
    '        txtAdvancePayAmount.Text = Configuration.FormatToString(m_entity.AdvancePayItemCollection.GetExcludeVATAmount, DigitConfig.Price)
    '    Else
    '        txtAdvancePayAmount.Text = Configuration.FormatToString(m_entity.AdvancePayItemCollection.GetAmount, DigitConfig.Price)
    '    End If
    '    txtBeforeTax.Text = Configuration.FormatToString(m_entity.BeforeTax, DigitConfig.Price)
    '    txtAfterTax.Text = Configuration.FormatToString(m_entity.AfterTax, DigitConfig.Price)
    '    txtTaxAmount.Text = Configuration.FormatToString(m_entity.TaxAmount, DigitConfig.Price)
    '    If IsNumeric(Me.m_entity.Discount.Rate) Then
    '        If Me.m_entity.Discount.Rate.IndexOf(".") > 0 Then
    '            Dim digit() As String
    '            Dim digit1 As String = 0
    '            digit = m_entity.Discount.Rate.Split(".")
    '            digit1 = digit(0)
    '            digit = Configuration.FormatToString(CDec("0." & digit(1)), DigitConfig.Price).Split(".")
    '            If DigitConfig.Price > 0 Then
    '                txtDiscountRate.Text = digit1 & "." & digit(1)
    '            Else
    '                txtDiscountRate.Text = m_entity.Discount.Rate
    '            End If
    '        Else
    '            txtDiscountRate.Text = m_entity.Discount.Rate
    '        End If
    '    Else
    '        txtDiscountRate.Text = m_entity.Discount.Rate
    '    End If

    '    txtTaxRate.Text = Configuration.FormatToString(m_entity.TaxRate, DigitConfig.Price)
    '    txtTaxBase.Text = Configuration.FormatToString(m_entity.TaxBase, DigitConfig.Price)
    '    CodeDescription.ComboSelect(Me.cmbTaxType, Me.m_entity.TaxType)

    '    txtRealGross.Text = Configuration.FormatToString(m_entity.RealGross, DigitConfig.Price)
    '    txtRealTaxAmount.Text = Configuration.FormatToString(m_entity.RealTaxAmount, DigitConfig.Price)
    '    txtRealTaxBase.Text = Configuration.FormatToString(m_entity.RealTaxBase, DigitConfig.Price)

    '    Me.txtRetention.Text = Configuration.FormatToString(Me.m_entity.Retention, DigitConfig.Price)
    '    m_isInitialized = flag
    '    'SetVatInputAfterAmountChange()
    '    'RefreshWBS()
    'End Sub
    '----------------------------------------------------
    'Private Sub Treetable_ColumnChanging(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs)
    '    If Not m_wbsdInitialized Then
    '        Return
    '    End If
    '    Try
    '        Select Case e.Column.ColumnName.ToLower
    '            Case "wbs"
    '                SetCode(e)
    '            Case "percent"
    '                SetPercent(e)
    '        End Select
    '        ValidateRow(e)
    '    Catch ex As Exception
    '        MessageBox.Show(ex.ToString)
    '    End Try
    'End Sub
    'Public Sub ValidateRow(ByVal e As DataColumnChangeEventArgs)
    '    Dim wbs As Object = e.Row("wbs")
    '    Dim percent As Object = e.Row("percent")

    '    Select Case e.Column.ColumnName.ToLower
    '        Case "wbs"
    '            wbs = e.ProposedValue
    '        Case "percent"
    '            percent = e.ProposedValue
    '        Case Else
    '            Return
    '    End Select

    '    Dim isBlankRow As Boolean = False
    '    If IsDBNull(wbs) Then
    '        isBlankRow = True
    '    End If

    '    If Not isBlankRow Then
    '        If IsDBNull(percent) OrElse CDec(percent) <= 0 Then
    '            e.Row.SetColumnError("percent", Me.StringParserService.Parse("${res:Global.Error.PercentMissing}"))
    '        Else
    '            e.Row.SetColumnError("percent", "")
    '        End If
    '        If IsDBNull(wbs) OrElse wbs.ToString.Length = 0 Then
    '            e.Row.SetColumnError("wbs", Me.StringParserService.Parse("${res:Global.Error.WBSMissing}"))
    '        Else
    '            e.Row.SetColumnError("wbs", "")
    '        End If
    '    End If

    'End Sub
    'Public Function ValidateRow(ByVal row As TreeRow) As Boolean
    '  If row.IsNull("WBS") Then
    '    Return False
    '  End If
    '  Return True
    'End Function
    'Private m_updating As Boolean = False
    'Public Sub SetPercent(ByVal e As DataColumnChangeEventArgs)
    '    If m_updating Then
    '        Return
    '    End If
    '    Dim item As WBSDistribute = Me.CurrentWsbsd
    '    If item Is Nothing Then
    '        Return
    '    End If
    '    If IsDBNull(e.ProposedValue) OrElse e.ProposedValue.ToString.Length = 0 Then
    '        e.ProposedValue = ""
    '        Return
    '    End If
    '    e.ProposedValue = Configuration.FormatToString(CDec(TextParser.Evaluate(e.ProposedValue.ToString)), DigitConfig.Price)
    '    Dim value As Decimal = CDec(e.ProposedValue)
    '    Dim oldvalue As Decimal = 0
    '    If Not e.Row.IsNull(e.Column) Then
    '        oldvalue = CDec(e.Row(e.Column))
    '    End If
    '    Dim doc As PAItem = Me.m_entity.ItemCollection.CurrentItem
    '    If doc Is Nothing Then
    '        Return
    '    End If
    '    Dim wsdColl As WBSDistributeCollection = doc.WBSDistributeCollection
    '    If wsdColl.GetSumPercent - oldvalue + value > 100 Then
    '        e.ProposedValue = e.Row(e.Column)
    '        Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
    '        msgServ.ShowMessage("${res:Global.Error.WBSPercentExceed100}")
    '        Return
    '    End If

    '    m_updating = True
    '    item.Percent = value
    '    m_updating = False
    'End Sub

    'Private Function DupCode(ByVal e As DataColumnChangeEventArgs) As Boolean
    '    If e.Row.IsNull("stocki_entityType") Then
    '        Return False
    '    End If
    '    If IsDBNull(e.ProposedValue) Then
    '        Return False
    '    End If
    '    '    For Each row As TreeRow In Me.ItemTable.Childs
    '    '        If Not row Is e.Row Then
    '    '            If Not row.IsNull("stocki_entityType") Then
    '    '                If CInt(row("stocki_entityType")) = CInt(e.Row("stocki_entityType")) Then
    '    '                    If Not row.IsNull("code") Then
    '    '                        If e.ProposedValue.ToString.ToLower = row("code").ToString.ToLower Then
    '    '                            Return True
    '    '                        End If
    '    '                    End If
    '    '                End If
    '    '            End If
    '    '        End If
    '    '    Next
    '    '    Return False
    'End Function
    'Public Sub SetCode(ByVal e As System.Data.DataColumnChangeEventArgs)
    '    If m_updating Then
    '        Return
    '    End If
    '    m_updating = True
    '    Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
    '    If e.Row.IsNull("stocki_entityType") Then
    '        msgServ.ShowMessage("${res:Global.Error.NoItemType}")
    '        e.ProposedValue = e.Row(e.Column)
    '        m_updating = False
    '        Return
    '    End If
    '    If DupCode(e) Then
    '        Dim item As New GoodsReceiptItem
    '        'item.CopyFromDataRow(CType(e.Row, TreeRow))
    '        msgServ.ShowMessageFormatted("${res:Global.Error.AlreadyHasCode}", New String() {item.ItemType.Description, e.ProposedValue.ToString})
    '        e.ProposedValue = e.Row(e.Column)
    '        m_updating = False
    '        Return
    '    End If
    '    'Select Case CInt(e.Row("stocki_entityType"))
    '    '    Case 0 'Blank
    '    '        msgServ.ShowMessage("${res:Global.Error.BlankItemCannotHaveCode}")
    '    '        e.ProposedValue = e.Row(e.Column)
    '    '        m_updating = False
    '    '        Return
    '    '    Case 28 'F/A
    '    '        msgServ.ShowMessage("${res:Global.Error.FACannotHaveCode}")
    '    '        e.ProposedValue = e.Row(e.Column)
    '    '        m_updating = False
    '    '        Return
    '    '    Case 19 'Tool
    '    '        If e.ProposedValue.ToString.Length = 0 Then
    '    '            If e.Row(e.Column).ToString.Length <> 0 Then
    '    '                If msgServ.AskQuestionFormatted("${res:Global.Question.DeleteToolDetail}", New String() {e.Row(e.Column).ToString}) Then
    '    '                    ClearRow(e)
    '    '                Else
    '    '                    e.ProposedValue = e.Row(e.Column)
    '    '                End If
    '    '            End If
    '    '            m_updating = False
    '    '            Return
    '    '        End If
    '    '        Dim myTool As New Tool(e.ProposedValue.ToString)
    '    '        If Not myTool.Originated Then
    '    '            msgServ.ShowMessageFormatted("${res:Global.Error.NoTool}", New String() {e.ProposedValue.ToString})
    '    '            e.ProposedValue = e.Row(e.Column)
    '    '            m_updating = False
    '    '            Return
    '    '        Else
    '    '            Dim myUnit As Unit = myTool.Unit
    '    '            e.Row("stocki_entity") = myTool.Id
    '    '            e.ProposedValue = myTool.Code
    '    '            e.Row("stocki_itemName") = myTool.Name
    '    '            If Not myUnit Is Nothing AndAlso myUnit.Originated Then
    '    '                e.Row("stocki_unit") = myUnit.Id
    '    '                e.Row("Unit") = myUnit.Name
    '    '            Else
    '    '                e.Row("stocki_unit") = DBNull.Value
    '    '                e.Row("Unit") = DBNull.Value
    '    '            End If
    '    '            Dim ga As GeneralAccount = GeneralAccount.GetGAForEntity(myTool.EntityId, Me.EntityId)
    '    '            If Not ga.Account Is Nothing AndAlso ga.Account.Originated Then
    '    '                e.Row("stocki_acct") = ga.Account.Id
    '    '                e.Row("AccountCode") = ga.Account.Code
    '    '                e.Row("Account") = ga.Account.Name & "<" & Me.StringParserService.Parse("${res:Global.Default}") & ">"
    '    '            Else
    '    '                e.Row("stocki_acct") = DBNull.Value
    '    '                e.Row("AccountCode") = DBNull.Value
    '    '                e.Row("Account") = DBNull.Value
    '    '            End If
    '    '        End If
    '    '    Case 42 'LCI
    '    '        If e.ProposedValue.ToString.Length = 0 Then
    '    '            If e.Row(e.Column).ToString.Length <> 0 Then
    '    '                If msgServ.AskQuestionFormatted("${res:Global.Question.DeleteLCIDetail}", New String() {e.Row(e.Column).ToString}) Then
    '    '                    ClearRow(e)
    '    '                Else
    '    '                    e.ProposedValue = e.Row(e.Column)
    '    '                End If
    '    '            End If
    '    '            m_updating = False
    '    '            Return
    '    '        End If
    '    '        Dim lci As New LCIItem(e.ProposedValue.ToString)
    '    '        If Not lci.Originated Then
    '    '            msgServ.ShowMessageFormatted("${res:Global.Error.NoLCI}", New String() {e.ProposedValue.ToString})
    '    '            e.ProposedValue = e.Row(e.Column)
    '    '            m_updating = False
    '    '            Return
    '    '        Else
    '    '            Dim myUnit As Unit = lci.DefaultUnit
    '    '            e.Row("stocki_entity") = lci.Id
    '    '            e.ProposedValue = lci.Code
    '    '            e.Row("stocki_itemName") = lci.Name
    '    '            If Not myUnit Is Nothing AndAlso myUnit.Originated Then
    '    '                e.Row("stocki_unit") = myUnit.Id
    '    '                e.Row("Unit") = myUnit.Name
    '    '            Else
    '    '                e.Row("stocki_unit") = DBNull.Value
    '    '                e.Row("Unit") = DBNull.Value
    '    '            End If
    '    '            If Not lci.Account Is Nothing AndAlso lci.Account.Originated Then
    '    '                e.Row("stocki_acct") = lci.Account.Id
    '    '                e.Row("AccountCode") = lci.Account.Code
    '    '                e.Row("Account") = lci.Account.Name & "<" & Me.StringParserService.Parse("${res:Global.Default}") & ">"
    '    '            Else
    '    '                e.Row("stocki_acct") = DBNull.Value
    '    '                e.Row("AccountCode") = DBNull.Value
    '    '                e.Row("Account") = DBNull.Value
    '    '            End If
    '    '        End If
    '    '    Case Else
    '    '        msgServ.ShowMessage("${res:Global.Error.NoItemType}")
    '    '        e.ProposedValue = e.Row(e.Column)
    '    '        m_updating = False
    '    '        Return
    '    'End Select
    '    e.Row("stocki_qty") = Configuration.FormatToString(1D, DigitConfig.Qty)
    '    m_updating = False
    'End Sub
    'Private Sub ItemDelete(ByVal sender As Object, ByVal e As System.Data.DataRowChangeEventArgs)

    'End Sub
#End Region

#Region "CheckPJMModule"
    Private m_ApproveDocModule As New PJMModule("approvedoc")
#End Region

#Region "IListDetail"
    Public Overrides Sub CheckFormEnable()
      If Me.m_entity Is Nothing Then
        Return
      End If

      ''ถ้าไม่เปิดอนุมัติเอกสาร(ให้ซ่อนปุ่ม)
      ''If Not CBool(Configuration.GetConfig("ApprovePa")) Then
      ''	Me.btnApprove.Visible = False
      ''Else
      ''	Me.btnApprove.Visible = True
      ''End If

      ''จากการอนุมัติเอกสาร()
      'If CBool(Configuration.GetConfig("ApprovePa")) Then
      '	'ถ้าใช้การอนุมัติแบบใหม่(PJMModule)
      '	If m_ApproveDocModule.Activated Then
      '		Dim mySService As SecurityService = CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService)
      '		Dim ApprovalDocLevelColl As New ApprovalDocLevelCollection(mySService.CurrentUser)			'ระดับสิทธิแต่ละผู้ใช้
      '		Dim ApproveDocColl As New ApproveDocCollection(Me.m_entity)			'ระดับสิทธิที่ได้ทำการ approve
      '		If ApproveDocColl.MaxLevel > 0 Then
      '                       (ApprovalDocLevelColl.GetItem(m_entity.EntityId).Level < ApproveDocColl.MaxLevel) OrElse _
      '                       (Not Me.m_entity.ApproveDate.Equals(Date.MinValue) AndAlso Not Me.m_entity.ApprovePerson.Id = CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id) Then
      '			For Each ctrl As Control In grbDetail.Controls
      '				If Not ctrl.Name = "btnApprove" AndAlso Not ctrl.Name = "ibtnCopyMe" Then
      '					ctrl.Enabled = False
      '				End If
      '			Next
      '			tgItem.Enabled = True
      '			For Each colStyle As DataGridColumnStyle In Me.m_treeManager.GridTableStyle.GridColumnStyles
      '				colStyle.ReadOnly = True
      '			Next
      '			Me.btnApprove.Enabled = True
      '			CheckWBSRight()
      '			Return
      '		Else
      '			For Each ctrl As Control In grbDetail.Controls
      '				ctrl.Enabled = CBool(m_enableState(ctrl))
      '			Next
      '			For Each colStyle As DataGridColumnStyle In Me.m_treeManager.GridTableStyle.GridColumnStyles
      '				colStyle.ReadOnly = CBool(m_tableStyleEnable(colStyle))
      '			Next
      '		End If
      '	Else
      '		'ถ้าใช้การอนุมัติแบบเก่า()
      '		If Not Me.m_entity.ApproveDate.Equals(Date.MinValue) AndAlso Not Me.m_entity.ApprovePerson.Id = CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id Then
      '			For Each ctrl As Control In grbDetail.Controls
      '				If Not ctrl.Name = "btnApprove" AndAlso Not ctrl.Name = "ibtnCopyMe" Then
      '					ctrl.Enabled = False
      '				End If
      '			Next
      '			tgItem.Enabled = True
      '			For Each colStyle As DataGridColumnStyle In Me.m_treeManager.GridTableStyle.GridColumnStyles
      '				colStyle.ReadOnly = True
      '			Next
      '			'Me.btnApprove.Enabled = True
      '			CheckWBSRight()
      '			Return
      '		Else
      '			For Each ctrl As Control In grbDetail.Controls
      '				ctrl.Enabled = CBool(m_enableState(ctrl))
      '			Next
      '			For Each colStyle As DataGridColumnStyle In Me.m_treeManager.GridTableStyle.GridColumnStyles
      '				colStyle.ReadOnly = CBool(m_tableStyleEnable(colStyle))
      '			Next
      '		End If
      '	End If
      'End If


      ' จาก Status ของเอกสารเอง
      If Me.m_entity.Status.Value = 0 OrElse m_entityRefed = 1 Then
        For Each ctrl As Control In grbDetail.Controls
          If Not ctrl.Name = "btnApprove" AndAlso Not ctrl.Name = "ibtnCopyMe" Then
            ctrl.Enabled = False
          End If
        Next
        tgItem.Enabled = True
        'For Each colStyle As DataGridColumnStyle In Me.m_treeManager.GridTableStyle.GridColumnStyles
        '  colStyle.ReadOnly = True
        'Next
      Else
        For Each ctrl As Control In grbDetail.Controls
          ctrl.Enabled = CBool(m_enableState(ctrl))
        Next
        For Each colStyle As DataGridColumnStyle In Me.m_treeManager.GridTableStyle.GridColumnStyles
          colStyle.ReadOnly = CBool(m_tableStyleEnable(colStyle))
        Next
      End If

      'Me.chkClosed.Enabled = True
      'Me.ibtnCopyMe.Enabled = True

      'Me.btnApprove.Enabled = True
      'CheckWBSRight()
    End Sub
    Private Sub CheckWBSRight()
      Dim secSrv As SecurityService = CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService)
      Dim level As Integer = secSrv.GetAccess(256)
      Dim checkString As String = BinaryHelper.DecToBin(level, 5)
      checkString = BinaryHelper.RevertString(checkString)
      If Not CBool(checkString.Substring(0, 1)) Then
        'ห้ามเห็น
        'Me.lblWBS.Visible = False
        'Me.tgWBS.Visible = False
        'Me.ibtnAddWBS.Visible = False
        'Me.ibtnDelWBS.Visible = False
      ElseIf Not CBool(checkString.Substring(1, 1)) Then
        'ห้ามแก้
        'Me.lblWBS.Visible = True
        'Me.tgWBS.Visible = True
        'Me.ibtnAddWBS.Visible = True
        'Me.ibtnDelWBS.Visible = True

        'Me.tgWBS.Enabled = False
        'Me.ibtnAddWBS.Enabled = False
        'Me.ibtnDelWBS.Enabled = False
      Else
        'Me.lblWBS.Visible = True
        'Me.tgWBS.Visible = True
        'Me.ibtnAddWBS.Visible = True
        'Me.ibtnDelWBS.Visible = True

        'Me.tgWBS.Enabled = True
        'Me.ibtnAddWBS.Enabled = True
        'Me.ibtnDelWBS.Enabled = True
      End If
    End Sub
    Public Overrides Sub ClearDetail()
      For Each crlt As Control In grbDetail.Controls
        If crlt.Name.StartsWith("txt") Then
          crlt.Text = ""
        End If
      Next
      For Each ctrl As Control In Me.Controls
        If ctrl.Name.StartsWith("txt") Then
          ctrl.Text = ""
        End If
      Next
    End Sub
    Public Overrides Sub SetLabelText()
      '            If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)

      Me.lblCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PAPanelView.lblCode}")   '"เลขที่ PA:"

      Me.lblDocDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PAPanelView.lblDocDate}")
      Me.Validator.SetDisplayName(Me.txtDocDate, StringHelper.GetRidOfAtEnd(Me.lblDocDate.Text, ":"))
      Me.lblSCCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PAPanelView.lblSCCode}")   '"เลขที่ SC:"
      Me.lblSupplier.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PAPanelView.lblSupplier}")
      'Me.Validator.SetDisplayName(Me.txtSubContractorCode, StringHelper.GetRidOfAtEnd(Me.lblSupplier.Text, ":"))
      Me.lblCostCenter.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PAPanelView.lblCostCenter}")   '"Cost Center:"
      Me.lblDirector.Text = Me.StringParserService.Parse("${res:Global.DirectorText}")
      Me.Validator.SetDisplayName(Me.txtDirectorCode, StringHelper.GetRidOfAtEnd(Me.lblDirector.Text, ":"))

    End Sub
    Protected Overrides Sub EventWiring()
      
    End Sub
    Private m_dateSetting As Boolean = False

    Private oldCCId As Integer
    Private dirtyFlag As Boolean = False
    Private CCCodeBlankFlag As Boolean = False
    Private scCodeChanged As Boolean = False

    'Private ccCodeChanged As Boolean = False
    'Private subContractorChanged As Boolean = False
    Private directorCodeChanged As Boolean = False
    'Private retensionChanged As Boolean = False
    Private Sub TextHandler(ByVal sender As Object, ByVal e As EventArgs)
      
    End Sub
    Public Overrides Sub UpdateEntityProperties()
      m_isInitialized = False
      ClearDetail()
      If m_entity Is Nothing Then
        Return
      End If
      cmbCode.Items.Clear()
      cmbCode.DropDownStyle = ComboBoxStyle.Simple

      cmbCode.Text = m_entity.Code
      Me.m_oldCode = Me.m_entity.Code
      oldCCId = Me.m_entity.Sc.CostCenter.Id

      txtDocDate.Text = MinDateToNull(Me.m_entity.DocDate, Me.StringParserService.Parse("${res:Global.BlankDateText}"))

      txtSCCode.Text = Me.m_entity.Sc.Code

      txtSubContractorCode.Text = m_entity.Sc.SubContractor.Code
      txtSubContractorName.Text = m_entity.Sc.SubContractor.Name

      txtDirectorCode.Text = m_entity.Receiver.Code
      txtDirectorName.Text = m_entity.Receiver.Name

      txtCostCenterCode.Text = m_entity.Sc.CostCenter.Code
      txtCostCenterName.Text = m_entity.Sc.CostCenter.Name

      RefreshDocs()
      SetStatus()
      SetLabelText()
      CheckFormEnable()
      m_isInitialized = True
    End Sub
    '        Private Sub SetColumnOriginQty()
    '            For Each colStyle As DataGridColumnStyle In Me.tgItem.TableStyles(0).GridColumnStyles
    '                If colStyle.MappingName.ToLower = "Pai_originqty" Then
    '                    If Not Me.m_entity.Closed Then
    '                        colStyle.Width = 0
    '                    Else
    '                        colStyle.Width = 80
    '                    End If
    '                End If
    '            Next
    '        End Sub
    Private Sub RefreshDocs()
      Me.m_isInitialized = False

      Populate(m_entity.ItemCollection, m_treeManager.Treetable)

      RefreshBlankGrid()
      Me.m_treeManager.Treetable.AcceptChanges()
      Me.UpdateAmount()
      Me.m_isInitialized = True
    End Sub
    Private Sub Populate(ByVal coll As PAItemCollection, ByVal dt As TreeTable)
      dt.Clear()
      Dim parentRowHash As New Hashtable
      For Each item As PAItem In coll
        If item.ItemType.Value = 289 Then 'Parent
          Dim tr As TreeRow = dt.Childs.Add()
          item.CopyToDataRow(tr)
          tr.Tag = item
          parentRowHash(item.Sequence) = tr
        End If
      Next

      For Each item As PAItem In coll
        If item.Amount <> 0 AndAlso item.ItemType.Value <> 160 AndAlso item.ItemType.Value <> 162 Then

          Dim parentRow As TreeRow = CType(parentRowHash(item.Parent), TreeRow)
          If Not parentRow Is Nothing Then
            If Not parentRow.Tag Is item Then
              Dim tr As TreeRow = parentRow.Childs.Add()
              item.CopyToDataRow(tr)
              Dim acct As Account
              Select Case item.ItemType.Value
                Case 88, 291
                  acct = item.LabAccount
                Case 89
                  acct = item.EqAccount
                Case Else
                  acct = item.MatAccount
              End Select
              If Not acct Is Nothing Then
                tr("AccountCode") = acct.Code
                tr("Account") = acct.Name
              End If

              tr.Tag = item
            End If
          Else
            'TODO: กำพร้าแม่
          End If
        End If
      Next

      For Each parentRow As TreeRow In dt.Childs
        If parentrow.Childs.Count = 0 Then
          Dim item As PAItem = CType(parentRow.Tag, PAItem)
          If Not item Is Nothing Then
            If item.Mat <> 0 Then
              Dim tr As TreeRow = parentrow.Childs.Add
              tr("pai_itemName") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PAPanelView.MaterialAccountCode}")
              tr("Amount") = Configuration.FormatToString(item.Mat, DigitConfig.Price)

              If Not item.MatAccount Is Nothing Then
                tr("AccountCode") = item.MatAccount.Code
                tr("Account") = item.MatAccount.Name
              End If

              tr.FixLevel = -1
              tr.Tag = "MatAccount"
            End If
            If item.Lab <> 0 Then
              Dim tr As TreeRow = parentrow.Childs.Add
              tr("pai_itemName") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PAPanelView.LaborAccountCode}")
              tr("Amount") = Configuration.FormatToString(item.Lab, DigitConfig.Price)

              If Not item.LabAccount Is Nothing Then
                tr("AccountCode") = item.LabAccount.Code
                tr("Account") = item.LabAccount.Name
              End If

              tr.FixLevel = -1
              tr.Tag = "LabAccount"
            End If
            If item.eq <> 0 Then
              Dim tr As TreeRow = parentrow.Childs.Add
              tr("pai_itemName") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PAPanelView.EquipmentAccountCode}")
              tr("Amount") = Configuration.FormatToString(item.eq, DigitConfig.Price)

              If Not item.EqAccount Is Nothing Then
                tr("AccountCode") = item.EqAccount.Code
                tr("Account") = item.EqAccount.Name
              End If

              tr.FixLevel = -1
              tr.Tag = "EqAccount"
            End If
          End If
        End If
      Next
      dt.AcceptChanges()
    End Sub
    Private Sub PropChanged(ByVal sender As Object, ByVal e As PropertyChangedEventArgs)
      If e.Name = "ItemChanged" Or e.Name = "QtyChanged" Then
        If e.Name = "QtyChanged" Then
          Me.UpdateAmount()
        End If
        Me.WorkbenchWindow.ViewContent.IsDirty = True
      End If
    End Sub
    Private Sub SetCCCodeBlankFlag()
      If Me.txtCostCenterCode.Text.Length = 0 Then
        CCCodeBlankFlag = True
      Else
        CCCodeBlankFlag = False
      End If
    End Sub
    Public Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)

    End Sub
    Private Sub ibtnResetGross_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      If Me.m_entity.RealGross <> Me.m_entity.Gross Then
        Me.WorkbenchWindow.ViewContent.IsDirty = True
      End If
      Me.m_entity.RealGross = Me.m_entity.Gross
      UpdateAmount()
    End Sub
    'Private Sub ibtnResetTaxBase_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If Me.m_entity.RealTaxBase <> Me.m_entity.TaxBase Then
    '        Me.WorkbenchWindow.ViewContent.IsDirty = True
    '    End If
    '    Me.m_entity.RealTaxBase = Me.m_entity.TaxBase
    '    UpdateAmount(True)
    'End Sub
    Private Sub ibtnResetTaxAmount_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      If Me.m_entity.RealTaxAmount <> Me.m_entity.TaxAmount Then
        Me.WorkbenchWindow.ViewContent.IsDirty = True
      End If
      Me.m_entity.RealTaxAmount = Me.m_entity.TaxAmount
      UpdateAmount()
    End Sub
    Private forceUpdateTaxBase As Boolean = False
    Private forceUpdateGross As Boolean = False
    Private forceUpdateTaxAmount As Boolean = False
    Private Sub UpdateAmount()

    End Sub
    Public Sub SetStatus()

    End Sub
    Private m_entityRefed As Integer = -1
    Public Overrides Property Entity() As BusinessLogic.ISimpleEntity
      Get
        Return Me.m_entity
      End Get
      Set(ByVal Value As BusinessLogic.ISimpleEntity)
        If Not m_entity Is Nothing Then
          RemoveHandler Me.m_entity.PropertyChanged, AddressOf PropChanged
          Me.m_entity = Nothing
        End If
        Me.m_entity = CType(Value, PA)
        If Me.m_entity.IsReferenced Then
          m_entityRefed = 1
        Else
          m_entityRefed = 0
        End If
        'Hack:
        Me.m_entity.OnTabPageTextChanged(m_entity, EventArgs.Empty)
        UpdateEntityProperties()
      End Set
    End Property
    Public Overrides Sub Initialize()
    End Sub
#End Region

#Region "Event Handler"
    'Private currentY As Integer = -1
    Private Sub tgItem_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tgItem.CurrentCellChanged
      'If tgItem.CurrentRowIndex <> currentY Then
      Me.m_entity.ItemCollection.CurrentItem = Me.CurrentTagItem
      Me.m_entity.ItemCollection.CurrentRealItem = Me.CurrentRealTagItem
      'RefreshWBS()
      'currentY = tgItem.CurrentRowIndex
      'End If
    End Sub
    Private m_oldCode As String = ""
    Public Sub UnitButtonClick(ByVal e As ButtonColumnEventArgs)
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      Dim filters(0) As Filter
      Dim doc As PAItem = Me.m_entity.ItemCollection.CurrentItem
      If doc Is Nothing Then
        doc = New PAItem
        doc.ItemType = New PAIItemType(289)
        doc.RefEntity = New RefEntity
        Me.m_entity.ItemCollection.Add(doc)
        Me.m_entity.ItemCollection.CurrentItem = doc
      End If

      Dim tr As TreeRow = Me.m_treeManager.SelectedRow
      Dim isSummaryRow As Boolean
      If Not tr.IsNull("isSummaryRow") Then
        isSummaryRow = CBool(tr("isSummaryRow"))
      End If

      If Not isSummaryRow Then
        Dim includeFilter As Boolean = False
        If TypeOf doc.Entity Is Tool Then
          Dim mytool As Tool = CType(doc.Entity, Tool)
          If Not mytool.Unit Is Nothing AndAlso mytool.Unit.Originated Then
            filters(0) = New Filter("includedId", mytool.Unit.Id)
            includeFilter = True
          End If
        ElseIf TypeOf doc.Entity Is LCIItem Then
          Dim idList As String = CType(doc.Entity, LCIItem).GetUnitIdList
          If idList.Length > 0 Then
            filters(0) = New Filter("includedId", idList)
            includeFilter = True
          End If
        End If
        If includeFilter Then
          myEntityPanelService.OpenListDialog(New Unit, AddressOf SetUnit, filters)
        Else
          myEntityPanelService.OpenListDialog(New Unit, AddressOf SetUnit)
        End If
      End If
    End Sub
    Private Sub SetUnit(ByVal unit As ISimpleEntity)
      Me.m_treeManager.SelectedRow("Unit") = unit.Code
    End Sub
    Public Sub AcctButtonClick(ByVal e As ButtonColumnEventArgs)
      If Me.m_treeManager.SelectedRow Is Nothing Then
        Return
      End If
      If TypeOf Me.m_treeManager.SelectedRow.Parent Is TreeTable Then
        Return
      End If
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenTreeDialog(New Account, AddressOf SetAcct)
    End Sub
    Private Sub SetAcct(ByVal acct As ISimpleEntity)
      Me.m_treeManager.SelectedRow("AccountCode") = acct.Code
    End Sub
    Private m_targetType As Integer
    Public Sub ItemButtonClick(ByVal e As ButtonColumnEventArgs)
      Try
        Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
        Dim doc As PAItem = Me.m_entity.ItemCollection.CurrentItem
        m_targetType = -1
        If doc Is Nothing Then
          doc = New PAItem
          doc.ItemType = New PAIItemType(0)
          Me.m_entity.ItemCollection.Add(doc)
          Me.m_entity.ItemCollection.CurrentItem = doc
        End If

        Dim tr As TreeRow = Me.m_treeManager.SelectedRow
        Dim isSummaryRow As Boolean
        If Not tr.IsNull("isSummaryRow") Then
          isSummaryRow = CBool(tr("isSummaryRow"))
        End If

        If (doc.ItemType.Value = 19 OrElse _
           doc.ItemType.Value = 42 OrElse _
           doc.ItemType.Value = 88 OrElse _
           doc.ItemType.Value = 89 OrElse _
           doc.ItemType.Value = 289) AndAlso _
           Not isSummaryRow AndAlso _
           doc.RefEntity.Id = 0 Then
          m_targetType = doc.ItemType.Value
          Dim entities(1) As ISimpleEntity
          entities(0) = New LCIItem
          entities(1) = New Tool
          Dim activeIndex As Integer = -1
          If Not doc.ItemType Is Nothing Then
            If doc.ItemType.Value = 19 Then
              activeIndex = 1
            ElseIf doc.ItemType.Value = 42 Or doc.ItemType.Value = 88 Or doc.ItemType.Value = 89 Or doc.ItemType.Value = 289 Then
              activeIndex = 0
            End If
          End If
          myEntityPanelService.OpenListDialog(entities, AddressOf SetItems, activeIndex)
        End If
      Catch ex1 As System.IndexOutOfRangeException
        Return
      End Try
    End Sub
    Private Sub SetItems(ByVal items As BasketItemCollection)
      If tgItem.CurrentRowIndex = 0 Then
        'Hack
        tgItem.CurrentRowIndex = 1
      End If
      Dim index As Integer = tgItem.CurrentRowIndex
      Me.m_entity.ItemCollection.SetItems(items, m_targetType)
      '    'Me.txtReceivingDate.Text = Me.m_entity.ReceivingDate.ToShortDateString
      tgItem.CurrentRowIndex = index
      '    Dim cc As CostCenter = Me.m_entity.GetCCFromPR
      '    If Not cc Is Nothing AndAlso cc.Id <> Me.m_entity.CostCenter.Id Then
      '        Me.SetCostCenterDialog(cc)
      '    End If
      forceUpdateTaxBase = True
      forceUpdateTaxAmount = True
      forceUpdateGross = True
      RefreshDocs()
      Me.WorkbenchWindow.ViewContent.IsDirty = True
      dirtyFlag = True
    End Sub
    Private Sub ibtnBlank_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      'Dim index As Integer = tgItem.CurrentRowIndex
      Dim doc As PAItem = Me.m_entity.ItemCollection.CurrentLastItem
      If doc Is Nothing Then
        If Me.m_entity.ItemCollection.Count = 0 Then
          doc = New PAItem
        End If
        Return
      End If
      'If Not doc.SCItem Is Nothing Then
      '    Return
      'End If
      Dim newItem As New BlankItem("")
      Dim theItem As New PAItem
      theItem.Entity = newItem
      theItem.RefEntity = New RefEntity
      theItem.Level = 0
      theItem.ItemType = New PAIItemType(289)
      theItem.Qty = 0
      'Dim index As Integer = Me.m_entity.ItemCollection.IndexOf(doc)
      Me.m_entity.ItemCollection.Insert(Me.m_entity.ItemCollection.IndexOf(doc) + 1, theItem)
      RefreshDocs()
      Dim index As Integer = Me.m_entity.ItemCollection.Count - 1
      tgItem.CurrentRowIndex = index
      Me.WorkbenchWindow.ViewContent.IsDirty = True
    End Sub
    Private Sub ibtnBlankSubItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      Dim index As Integer = tgItem.CurrentRowIndex
      Dim doc As PAItem = Me.m_entity.ItemCollection.CurrentItem
      If doc Is Nothing Then
        Return
      End If
      If doc.RefEntity.Id <> 0 Then
        msgServ.ShowMessage("${res:Longkong.Pojjaman.Gui.Panels.PAPanelView.ConnotHasSubItem}")
        Return
      End If
      Dim newItem As New BlankItem("")
      Dim theItem As New PAItem
      theItem.Level = 1
      theItem.Entity = newItem
      theItem.RefEntity = New RefEntity
      theItem.ItemType = New PAIItemType(0)
      theItem.Qty = 0
      Me.m_entity.ItemCollection.Insert(Me.m_entity.ItemCollection.IndexOf(doc) + 1, theItem)
      RefreshDocs()
      tgItem.CurrentRowIndex = index + 1
      Me.WorkbenchWindow.ViewContent.IsDirty = True
    End Sub
    Private Sub ibtnDelRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      'Dim doc As PAItem = Me.m_entity.ItemCollection.CurrentItem
      'If doc Is Nothing Then
      '  Return
      'End If
      'If Not Me.m_entity.ItemCollection.Contains(doc) Then
      '  Return
      'End If

      'Me.m_entity.ItemCollection.Remove(doc)

      Dim index As Integer = tgItem.CurrentRowIndex
      Dim isSetIndex As Boolean = False

      Dim hashParent As New Hashtable
      Dim hashChild As New Hashtable

      Dim key As String = ""
      Dim parent As String = ""
      Dim child As String = ""

      For Each Obj As Object In Me.m_treeManager.SelectedRows
        If Not Obj Is Nothing AndAlso TypeOf Obj Is TreeRow Then
          Dim row As TreeRow = CType(Obj, TreeRow)
          If Not row Is Nothing AndAlso TypeOf row.Tag Is PAItem Then

            Dim sitem As PAItem = CType(row.Tag, PAItem)
            key = sitem.RefDocType.ToString & ":" & sitem.Sequence.ToString
            If sitem.Level = 0 Then
              If Not hashParent.Contains(key) Then
                hashParent(key) = sitem
              End If
            Else
              If Not hashChild.Contains(key) Then
                hashChild(key) = sitem
              End If
            End If

          End If
        End If
      Next

      For Each sitem As PAItem In Me.m_entity.ItemCollection 'หาลูกทั้งหมด
        For Each pitem As PAItem In hashParent.Values
          If sitem.Parent = pitem.Parent AndAlso sitem.Level = 1 Then
            key = sitem.RefDocType.ToString & ":" & sitem.Sequence.ToString
            If Not hashChild.Contains(key) Then
              hashChild(key) = sitem
            End If
          End If
        Next
      Next

      For Each pitm As PAItem In hashChild.Values
        If Me.m_entity.ItemCollection.Contains(pitm) Then
          Me.m_entity.ItemCollection.Remove(pitm)
          Me.WorkbenchWindow.ViewContent.IsDirty = True
        End If
      Next

      For Each pitm As PAItem In hashParent.Values
        If Me.m_entity.ItemCollection.Contains(pitm) Then
          Me.m_entity.ItemCollection.Remove(pitm)
          Me.WorkbenchWindow.ViewContent.IsDirty = True
        End If
      Next



      'hashParent = New Hashtable
      'Dim countParent As Integer = 0
      'For Each pcol As PAItem In Me.m_entity.ItemCollection
      '  parent = pcol.Parent.ToString
      '  If pcol.Level = 0 Then
      '    hashParent(key) = pcol
      '  Else
      '    If hashParent.Contains(key) Then
      '      If pcol.Parent = CType(hashParent(key), PAItem).Parent Then
      '        countParent += 1

      '        'Dim ix As Integer = Me.m_entity.ItemCollection.IndexOf(CType(hashParent(key), PAItem))
      '        'If Me.m_entity.ItemCollection(ix).HashOnlyOneChild = True Then
      '        '  Me.m_entity.ItemCollection(ix).HashOnlyOneChild = False
      '        'Else
      '        '  Me.m_entity.ItemCollection(ix).HashOnlyOneChild = True
      '        'End If

      '      End If
      '    End If
      '  End If
      'Next

      'hashParent = New Hashtable
      'For Each pitm As PAItem In hashChild.Values
      '  For Each pcol As PAItem In Me.m_entity.ItemCollection
      '    If pitm.Parent = pcol.Parent Then
      '      parent = pitm.Parent.ToString
      '      If pcol.Level = 0 AndAlso pcol.HashOnlyOneChild Then
      '        'MessageBox.Show(pcol.Level.ToString & vbCrLf & pcol.HashOnlyOneChild.ToString)
      '        hashParent(parent) = pcol
      '      End If
      '    End If
      '  Next
      'Next
      'For Each itm As PAItem In hashParent.Values
      '  'MessageBox.Show(itm.EntityName)
      '  If Me.m_entity.ItemCollection.Contains(itm) Then
      '    Me.m_entity.ItemCollection.Remove(itm)
      '    Me.WorkbenchWindow.ViewContent.IsDirty = True
      '  End If
      'Next

      forceUpdateTaxBase = True
      forceUpdateTaxAmount = True
      forceUpdateGross = True
      RefreshDocs()

      If Me.m_entity.ItemCollection.Count = 0 Then
        tgItem.CurrentRowIndex = -1
        Return
      End If
      If index > 0 Then
        If index > Me.m_entity.ItemCollection.Count Then
          tgItem.CurrentRowIndex = Me.m_entity.ItemCollection.Count - 1
        Else
          tgItem.CurrentRowIndex = index - 1
        End If
      Else
        tgItem.CurrentRowIndex = 0
      End If

      'Me.WorkbenchWindow.ViewContent.IsDirty = True
    End Sub

#End Region

#Region "IValidatable"
    Public ReadOnly Property FormValidator() As components.PJMTextboxValidator Implements IValidatable.FormValidator
      Get
        Return Me.Validator
      End Get
    End Property
#End Region

#Region "Overrides"
    Public Overrides ReadOnly Property TabPageIcon() As String
      Get
        Return (New PA).DetailPanelIcon
      End Get
    End Property
#End Region

#Region "Event of Button controls"
    ' Requestor
    Private Sub btnDirectorEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenPanel(Me.m_entity.Receiver)
    End Sub
    Private Sub btnRequestorFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Dim myEntityPanelService As IEntityPanelService = _
      CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenListDialog(Me.m_entity.Receiver, AddressOf SetEmployeeDialog)
    End Sub

    Private Sub SetEmployeeDialog(ByVal e As ISimpleEntity)
      Me.txtDirectorCode.Text = e.Code
      Me.WorkbenchWindow.ViewContent.IsDirty = _
          Me.WorkbenchWindow.ViewContent.IsDirty _
          Or Employee.GetEmployee(txtDirectorCode, txtDirectorName, Me.m_entity.Receiver)
    End Sub
    ' Costcenter
    'PO
    Private Sub ibtnShowSCDialog_click(ByVal sendr As System.Object, ByVal e As System.EventArgs)
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      If Me.m_entity.Sc Is Nothing OrElse Not Me.m_entity.Sc.Originated OrElse _
          msgServ.AskQuestion("${res:Longkong.Pojjaman.Gui.Panels.PADetail.Message.ChangeSC}", _
          "${res:Longkong.Pojjaman.Gui.Panels.PADetail.Caption.ChangeSC}") Then
        Dim myEntityPanelService As IEntityPanelService = _
        CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
        Dim entities As New ArrayList
        entities.Add(New SC)
        If Not Me.m_entity.CostCenter Is Nothing Then
          entities.Add(Me.m_entity.CostCenter)
        End If

        'If Me.m_entity.Sc.SubContractor.Originated Then
        '    entities.Add(Me.m_entity.Sc.SubContractor)
        'End If
        'If Me.m_entity.Sc.CostCenter.Originated Then
        '    entities.Add(Me.m_entity.Sc.CostCenter)
        'End If

        'Dim poNeedsApproval As Boolean = False
        'poNeedsApproval = CBool(Configuration.GetConfig("ApprovePO"))
        'Dim filters(3) As Filter
        'filters(0) = New Filter("poNeedsApproval", poNeedsApproval)
        'filters(1) = New Filter("excludeCanceled", True)
        'filters(2) = New Filter("excludedepleted", True)
        'filters(3) = New Filter("excludeclosed", True)
        myEntityPanelService.OpenListDialog(Me.m_entity.Sc, AddressOf SetSC, entities)
      End If
    End Sub
    Private Sub SetSC(ByVal e As ISimpleEntity)
      'Dim scNeedsApproval As Boolean = False
      'scNeedsApproval = CBool(Configuration.GetConfig("ApprovePO"))
      'Dim newSc As SC = CType(e, SC)
      If Me.m_entity Is Nothing Then
        Return
      End If

      If Me.m_entity.Sc Is Nothing Then
        Me.m_entity.Sc = New SC
      End If
      Me.txtSCCode.Text = e.Code
      Me.WorkbenchWindow.ViewContent.IsDirty = _
       Me.WorkbenchWindow.ViewContent.IsDirty _
       Or SC.GetSC(txtSCCode, Me.m_entity.Sc)
      Me.txtSCCode.Text = Me.m_entity.Sc.Code

      Dim flag As Boolean = m_isInitialized
      m_isInitialized = False
      Me.txtSubContractorCode.Text = Me.m_entity.Sc.SubContractor.Code
      Me.txtSubContractorName.Text = Me.m_entity.Sc.SubContractor.Name
      Me.txtCostCenterCode.Text = Me.m_entity.Sc.CostCenter.Code
      Me.txtCostCenterName.Text = Me.m_entity.Sc.CostCenter.Name
      'For Each vitem As VatItem In Me.m_entity.Vat.ItemCollection
      '    vitem.PrintName = Me.m_entity.Supplier.Name
      '    vitem.PrintAddress = Me.m_entity.Supplier.BillingAddress
      'Next
      'Me.m_entity.AdvancePayItemCollection.Clear()
      m_isInitialized = flag

      RefreshDocs()

      UpdateAmount()
      'scCodeChanged = False
    End Sub
    'Private Sub btnCCFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCCFind.Click
    '    Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
    '    Dim myEntityPanelService As IEntityPanelService = _
    '                CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
    '    myEntityPanelService.OpenTreeDialog(Me.m_entity.CostCenter, AddressOf SetCostCenterDialog)
    'End Sub
    'Private Sub SetCostCenterDialog(ByVal e As ISimpleEntity)
    '    If Me.txtCostCenterCode.Text <> e.Code AndAlso Me.txtCostCenterCode.Text.Length > 0 Then
    '        Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
    '        If msgServ.AskQuestion("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.Message.ChangeCC}", "${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.Caption.ChangeCC}") Then
    '            If Me.txtCostCenterCode.TextLength = 0 Then
    '                Me.m_entity.CostCenter = New CostCenter
    '            End If
    '            Me.txtCostCenterCode.Text = e.Code
    '            dirtyFlag = CostCenter.GetCostCenter(txtCostCenterCode, txtCostCenterName, Me.m_entity.CostCenter, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
    '            If dirtyFlag Then
    '                UpdateDestAdmin()
    '            End If
    '            Try
    '                If oldCCId <> Me.m_entity.CostCenter.Id Then
    '                    Me.WorkbenchWindow.ViewContent.IsDirty = True
    '                    oldCCId = Me.m_entity.CostCenter.Id
    '                    ChangeCC()
    '                End If
    '            Catch ex As Exception
    '            End Try
    '            ccCodeChanged = False
    '        Else
    '            Me.txtCostCenterCode.Text = Me.m_entity.CostCenter.Code
    '            ccCodeChanged = False
    '        End If
    '    ElseIf Me.txtCostCenterCode.Text.Length = 0 Then
    '        Me.txtCostCenterCode.Text = e.Code
    '        Me.WorkbenchWindow.ViewContent.IsDirty = True
    '        dirtyFlag = CostCenter.GetCostCenter(txtCostCenterCode, txtCostCenterName, Me.m_entity.CostCenter, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
    '        If dirtyFlag Then
    '            UpdateDestAdmin()
    '        End If
    '    End If
    '    SetCCCodeBlankFlag()
    'End Sub
    'Private Sub btnCCEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCCEdit.Click
    '    Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
    '    myEntityPanelService.OpenPanel(Me.m_entity.CostCenter)
    'End Sub
    'Private Sub ChangeCC()
    '    'For Each item As PAItem In Me.m_entity.ItemCollection
    '    '    item.WBSDistributeCollection.Clear()
    '    'Next
    '    'RefreshWBS()
    'End Sub
    Private Sub UpdateDestAdmin()
      If Me.m_entity Is Nothing Then
        Return
      End If
      Dim flag As Boolean = Me.m_isInitialized
      Me.m_isInitialized = False
      Try
        'Me.m_entity.Requestor = Me.m_entity.CostCenter.Admin
        'Me.txtRequestorCode.Text = m_entity.Requestor.Code
        'txtRequestorName.Text = m_entity.Requestor.Name
      Catch ex As Exception
      Finally
        Me.m_isInitialized = flag
      End Try
    End Sub
    'Private Sub ibtnShowPR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim dlg As New BasketDialog
    '    AddHandler dlg.EmptyBasket, AddressOf SetItems

    '    Dim filters(4) As Filter
    '    Dim excludeList As Object = ""
    '    excludeList = GetPRExcludeList()
    '    If excludeList.ToString.Length = 0 Then
    '        excludeList = DBNull.Value
    '    End If
    '    Dim prNeedsApproval As Boolean = False
    '    Dim prNeedsStoreApproval As Boolean = False
    '    prNeedsApproval = CBool(Configuration.GetConfig("ApprovePR"))
    '    prNeedsStoreApproval = CBool(Configuration.GetConfig("PRNeedStoreApprove"))
    '    filters(0) = New Filter("excludeList", excludeList)
    '    filters(1) = New Filter("prNeedsApproval", prNeedsApproval)
    '    filters(2) = New Filter("excludeCanceled", True)
    '    filters(3) = New Filter("PRNeedStoreApprove", prNeedsStoreApproval)
    '    filters(4) = New Filter("formEntity", Me.m_entity.EntityId)

    '    Dim Entities As New ArrayList
    '    If Not Me.m_entity.CostCenter Is Nothing AndAlso Me.m_entity.CostCenter.Originated Then
    '        Entities.Add(Me.m_entity.CostCenter)
    '    End If

    '    Dim view As AbstractEntityPanelViewContent = New PRSelectionView(New PR, New BasketDialog, filters, Entities)
    '    dlg.Lists.Add(view)
    '    Dim myDialog As New Longkong.Pojjaman.Gui.Dialogs.PanelDockingDialog(view, dlg)
    '    myDialog.ShowDialog()
    'End Sub
    'Private Function GetPRExcludeList() As String
    '    Dim ret As String = ""
    '    For Each item As PaItem In Me.m_entity.ItemCollection
    '        If Not item.Pritem Is Nothing Then
    '            ret &= "|" & item.Pritem.Pr.Id.ToString & ":" & item.Pritem.LineNumber.ToString & "|"
    '        End If
    '    Next
    '    Return ret
    'End Function
    'Private Sub ibtnGetFromBOQ_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim arr As New ArrayList
    '    arr.Add(Me.m_entity.CostCenter)
    '    Dim myEntityPanelService As IEntityPanelService = _
    '                CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
    '    myEntityPanelService.OpenListDialog(New BOQForSelection, AddressOf SetItems, arr)
    'End Sub

    ' Supplier
    'Private Sub btnSupplierEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSupplierEdit.Click
    '    Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
    '    myEntityPanelService.OpenPanel(New Supplier)
    'End Sub
    'Private Sub btnSupplierFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSupplierFind.Click
    '    Dim myEntityPanelService As IEntityPanelService = _
    '    CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
    '    myEntityPanelService.OpenListDialog(New Supplier, AddressOf SetSupplierDialog)
    'End Sub
    'Private Sub SetSupplierDialog(ByVal e As ISimpleEntity)
    '    Me.txtSubContractorCode.Text = e.Code
    '    Me.WorkbenchWindow.ViewContent.IsDirty = _
    '        Me.WorkbenchWindow.ViewContent.IsDirty _
    '        Or Supplier.GetSupplier(txtSubContractorCode, txtSubContractorName, Me.m_entity.Sc.SubContractor, True)
    '    m_isInitialized = False
    '    '    'Me.txtCreditPrd.Text = Configuration.FormatToString(Me.m_entity.CreditPeriod, DigitConfig.Int)
    '    '    'Me.dtpDueDate.Value = MaxDtpDate(Me.m_entity.DueDate)
    '    '    m_isInitialized = True
    'End Sub
    'Private Sub btnApprove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    ''PJMModule
    '    'Dim x As Form
    '    '   If m_ApproveDocModule.Activated Then
    '    '	x = New AdvanceApprovalCommentForm(Me.Entity)
    '    '   Else
    '    '	x = New ApprovalCommentForm(Me.Entity)
    '    'End If
    '    'x.ShowDialog()
    '    'CheckFormEnable()
    'End Sub
    Private Sub ibtnShowAdvancePay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Dim dlg As New AdvancePaySelection(Me.m_entity)
      Dim myDialog As New Longkong.Pojjaman.Gui.Dialogs.PanelDialog(dlg)
      If myDialog.ShowDialog() = DialogResult.OK Then
        forceUpdateTaxBase = True
        forceUpdateTaxAmount = True
        forceUpdateGross = True
        UpdateAmount()
        Me.WorkbenchWindow.ViewContent.IsDirty = True
      End If
    End Sub
#End Region

#Region "IClipboardHandler Overrides"
    Public Overrides ReadOnly Property EnablePaste() As Boolean
      Get
        Dim data As IDataObject = Clipboard.GetDataObject
        If data.GetDataPresent((New Supplier).FullClassName) Then
          If Not Me.ActiveControl Is Nothing Then
            Select Case Me.ActiveControl.Name.ToLower
              Case "txtsuppliercode", "txtsuppliername"
                Return True
            End Select
          End If
        End If
        Return False
      End Get
    End Property
    Public Overrides Sub Paste(ByVal sender As Object, ByVal e As System.EventArgs)
      Dim data As IDataObject = Clipboard.GetDataObject
      If data.GetDataPresent((New Supplier).FullClassName) Then
        Dim id As Integer = CInt(data.GetData((New Supplier).FullClassName))
        Dim entity As New Supplier(id)
        If Not Me.ActiveControl Is Nothing Then
          Select Case Me.ActiveControl.Name.ToLower
            'Case "txtsuppliercode", "txtsuppliername"
            '    Me.SetSupplierDialog(entity)
          Case ""
          End Select
        End If
      End If
    End Sub
#End Region

#Region "IKeyReceiver"
    Public Overrides Function ProcessKey(ByVal keyPressed As System.Windows.Forms.Keys) As Boolean
      Try
        Select Case keyPressed
          Case Keys.Insert
            ibtnBlank_Click(Nothing, Nothing)
            Return True
          Case Keys.Delete
            If Me.tgItem.Focused Then
              ibtnDelRow_Click(Nothing, Nothing)
              Return True
            Else
              Return False
            End If
          Case Else
            Return False
        End Select
      Catch ex As Exception
        Throw ex
      End Try
    End Function
#End Region

#Region "Grid Resizing"
    Private Sub tgItem_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tgItem.Resize
      If Me.m_entity Is Nothing Then
        Return
      End If
      'RefreshBlankGrid()
    End Sub
    Private Sub RefreshBlankGrid()
      If Me.tgItem.Height = 0 Then
        Return
      End If
      Dim dirtyFlag As Boolean = Me.WorkbenchWindow.ViewContent.IsDirty
      Dim index As Integer = tgItem.CurrentRowIndex

      'Dim index As Integer = tgItem.CurrentRowIndex
      'Dim doc As SCItem = Me.m_entity.ItemCollection.CurrentRealItem
      'If doc Is Nothing Then
      '  Return
      'End If
      ''If Not doc.SCItem Is Nothing Then
      ''    Return
      ''End If
      ''Dim newItem As New BlankItem("")
      'Dim theItem As New SCItem
      ''theItem.Entity = newItem
      'theItem.Level = 0
      ''theItem.ItemType = New ItemType(0)
      'theItem.Qty = 0
      'Me.m_entity.ItemCollection.Insert(Me.m_entity.ItemCollection.IndexOf(doc) + 1, theItem)
      'RefreshDocs()
      'tgItem.CurrentRowIndex = index + 1
      'Me.WorkbenchWindow.ViewContent.IsDirty = True

      Do Until Me.m_treeManager.Treetable.Rows.Count > tgItem.VisibleRowCount
        'เพิ่มแถวจนเต็ม
        'Me.m_treeManager.Treetable.Childs.Add()
        Dim newRow As TreeRow
        newRow = Me.m_treeManager.Treetable.Childs.Add()
        newRow("pai_level") = 0
        newRow("Button") = "invisible"
      Loop

      If Me.m_entity.ItemCollection.Count = Me.m_treeManager.Treetable.Childs.Count Then
        'เพิ่มอีก 1 แถว ถ้ามีข้อมูลจนถึงแถวสุดท้าย
        'Me.m_treeManager.Treetable.Childs.Add()
        Dim newRow As TreeRow
        newRow = Me.m_treeManager.Treetable.Childs.Add()
        newRow("pai_level") = 0
        newRow("Button") = "invisible"
      End If

      'For rowIndex As Integer = 0 To Me.m_treeManager.Treetable.Rows.Count
      '  Dim n As TreeRow = Me.m_treeManager.Treetable.Childs(rowIndex)
      '  If n("sci_level") = 0 Then
      '    Me.tgItem.TableStyles(0).GridColumnStyles(0).c()
      '  End If
      'Next

      Me.m_treeManager.Treetable.AcceptChanges()
      tgItem.CurrentRowIndex = Math.Max(0, index)
      Me.WorkbenchWindow.ViewContent.IsDirty = dirtyFlag
    End Sub

#End Region

#Region "After the main entity has been saved"
    Public Overrides Sub NotifyAfterSave(ByVal successful As Boolean)
      If Not successful Then
        Return
      End If
      Me.Entity = CType(Me.WorkbenchWindow.SubViewContents(1), ISimpleEntityPanel).Entity
    End Sub
    Public Overrides Sub NotifyBeforeSave()
      MyBase.NotifyBeforeSave()
      Me.Entity = CType(Me.WorkbenchWindow.SubViewContents(1), ISimpleEntityPanel).Entity
    End Sub
#End Region

    Private Sub ibtnCopyMe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Dim newEntity As ISimpleEntity = CType(Me.m_entity.GetNewEntity, ISimpleEntity)
      CType(Me.WorkbenchWindow.ViewContent, ISimpleListPanel).SelectedEntity = newEntity
      Me.Entity = newEntity
      Me.WorkbenchWindow.ViewContent.IsDirty = True
    End Sub

    Private Sub chkClosed_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
      If Not m_isInitialized Then
        Return
      End If
      'Me.m_entity.Closed = Me.chkClosed.Checked
      'If Me.m_entity.Closed Then
      '    Me.chkClosed.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.POPanelView.chkClosedCancel}")
      'Else
      '    Me.chkClosed.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.POPanelView.chkClosed}")
      'End If
      'Me.SetColumnOriginQty()
      'Me.RefreshDocs()
      'Me.RefreshWBS()
      Me.WorkbenchWindow.ViewContent.IsDirty = True
    End Sub

#Region "Customization"
    Public Overrides ReadOnly Property CanPrint() As Boolean
      Get
        Try
          Dim approveDocColl As New ApproveDocCollection(m_entity)
          Dim paNeedsApproval As Boolean = CBool(Configuration.GetConfig("PaApproveBeforePrint"))
          If paNeedsApproval Then
            If Not approveDocColl.IsApproved Then
              Return False
            End If
          End If
        Catch ex As Exception
        End Try
        Return MyBase.CanPrint
      End Get
    End Property
#End Region

#Region "IPreviewable"
    Public ReadOnly Property CanPreview As Boolean Implements Commands.IPreviewable.CanPreview
      Get
        Return True
      End Get
    End Property
#End Region

  End Class
End Namespace

