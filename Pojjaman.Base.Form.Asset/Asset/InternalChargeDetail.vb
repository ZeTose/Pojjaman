Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.TextHelper
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Imports System.Reflection
Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.Services
Imports System.Drawing.Printing
Imports Longkong.Pojjaman.Gui.ReportsAndDocs
Imports System.Drawing
Imports System.Drawing.Drawing2D


Namespace Longkong.Pojjaman.Gui.Panels
  Public Class InternalChargeDetail
    Inherits AbstractEntityDetailPanelView
    Implements IValidatable

#Region " Windows Form Designer generated code "
    Friend WithEvents lblItem As System.Windows.Forms.Label
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
    Friend WithEvents txtDocDate As System.Windows.Forms.TextBox
    Friend WithEvents txtCode As System.Windows.Forms.TextBox
    Friend WithEvents lblDocDate As System.Windows.Forms.Label
    Friend WithEvents lblCode As System.Windows.Forms.Label
    Friend WithEvents txtNote As System.Windows.Forms.TextBox
    Friend WithEvents lblNote As System.Windows.Forms.Label
    Friend WithEvents grbGeneral As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents tgItem As Longkong.Pojjaman.Gui.Components.TreeGrid
    Friend WithEvents ibtnAddWBS As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents ibtnDelWBS As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents lblWBS As System.Windows.Forms.Label
    Friend WithEvents tgWBS As Longkong.Pojjaman.Gui.Components.TreeGrid
    Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container
      Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(InternalChargeDetail))
      Me.lblItem = New System.Windows.Forms.Label
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider
      Me.txtDocDate = New System.Windows.Forms.TextBox
      Me.txtCode = New System.Windows.Forms.TextBox
      Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
      Me.txtNote = New System.Windows.Forms.TextBox
      Me.grbGeneral = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
      Me.lblNote = New System.Windows.Forms.Label
      Me.lblDocDate = New System.Windows.Forms.Label
      Me.lblCode = New System.Windows.Forms.Label
      Me.tgItem = New Longkong.Pojjaman.Gui.Components.TreeGrid
      Me.ibtnAddWBS = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.ibtnDelWBS = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.lblWBS = New System.Windows.Forms.Label
      Me.tgWBS = New Longkong.Pojjaman.Gui.Components.TreeGrid
      Me.grbGeneral.SuspendLayout()
      CType(Me.tgItem, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.tgWBS, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'lblItem
      '
      Me.lblItem.AutoSize = True
      Me.lblItem.BackColor = System.Drawing.Color.Transparent
      Me.lblItem.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblItem.Location = New System.Drawing.Point(16, 88)
      Me.lblItem.Name = "lblItem"
      Me.lblItem.Size = New System.Drawing.Size(140, 19)
      Me.lblItem.TabIndex = 4
      Me.lblItem.Text = "รายการเบิกเครื่องจักร:"
      Me.lblItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
      Me.ErrorProvider1.SetIconPadding(Me.txtDocDate, -15)
      Me.Validator.SetInvalidBackColor(Me.txtDocDate, System.Drawing.Color.Empty)
      Me.txtDocDate.Location = New System.Drawing.Point(376, 16)
      Me.Validator.SetMaxValue(Me.txtDocDate, "")
      Me.Validator.SetMinValue(Me.txtDocDate, "")
      Me.txtDocDate.Name = "txtDocDate"
      Me.txtDocDate.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtDocDate, "")
      Me.Validator.SetRequired(Me.txtDocDate, True)
      Me.txtDocDate.Size = New System.Drawing.Size(115, 21)
      Me.txtDocDate.TabIndex = 4
      Me.txtDocDate.Text = ""
      '
      'txtCode
      '
      Me.Validator.SetDataType(Me.txtCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtCode, "")
      Me.Validator.SetGotFocusBackColor(Me.txtCode, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtCode, -15)
      Me.Validator.SetInvalidBackColor(Me.txtCode, System.Drawing.Color.Empty)
      Me.txtCode.Location = New System.Drawing.Point(120, 16)
      Me.txtCode.MaxLength = 20
      Me.Validator.SetMaxValue(Me.txtCode, "")
      Me.Validator.SetMinValue(Me.txtCode, "")
      Me.txtCode.Name = "txtCode"
      Me.txtCode.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtCode, "")
      Me.Validator.SetRequired(Me.txtCode, False)
      Me.txtCode.Size = New System.Drawing.Size(144, 21)
      Me.txtCode.TabIndex = 1
      Me.txtCode.Text = ""
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
      'txtNote
      '
      Me.Validator.SetDataType(Me.txtNote, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtNote, "")
      Me.Validator.SetGotFocusBackColor(Me.txtNote, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtNote, System.Drawing.Color.Empty)
      Me.txtNote.Location = New System.Drawing.Point(120, 40)
      Me.txtNote.MaxLength = 255
      Me.Validator.SetMaxValue(Me.txtNote, "")
      Me.Validator.SetMinValue(Me.txtNote, "")
      Me.txtNote.Name = "txtNote"
      Me.txtNote.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtNote, "")
      Me.Validator.SetRequired(Me.txtNote, False)
      Me.txtNote.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal
      Me.txtNote.Size = New System.Drawing.Size(552, 21)
      Me.txtNote.TabIndex = 7
      Me.txtNote.Text = ""
      '
      'grbGeneral
      '
      Me.grbGeneral.Controls.Add(Me.txtNote)
      Me.grbGeneral.Controls.Add(Me.lblNote)
      Me.grbGeneral.Controls.Add(Me.txtDocDate)
      Me.grbGeneral.Controls.Add(Me.txtCode)
      Me.grbGeneral.Controls.Add(Me.lblDocDate)
      Me.grbGeneral.Controls.Add(Me.lblCode)
      Me.grbGeneral.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbGeneral.Location = New System.Drawing.Point(8, 8)
      Me.grbGeneral.Name = "grbGeneral"
      Me.grbGeneral.Size = New System.Drawing.Size(776, 72)
      Me.grbGeneral.TabIndex = 0
      Me.grbGeneral.TabStop = False
      Me.grbGeneral.Text = "ผู้ขอเบิก"
      '
      'lblNote
      '
      Me.lblNote.BackColor = System.Drawing.Color.Transparent
      Me.lblNote.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblNote.Location = New System.Drawing.Point(8, 40)
      Me.lblNote.Name = "lblNote"
      Me.lblNote.Size = New System.Drawing.Size(105, 18)
      Me.lblNote.TabIndex = 6
      Me.lblNote.Text = "หมายเหตุ:"
      Me.lblNote.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblDocDate
      '
      Me.lblDocDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDocDate.Location = New System.Drawing.Point(280, 16)
      Me.lblDocDate.Name = "lblDocDate"
      Me.lblDocDate.Size = New System.Drawing.Size(88, 18)
      Me.lblDocDate.TabIndex = 3
      Me.lblDocDate.Text = "วันที่เอกสาร:"
      Me.lblDocDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblCode
      '
      Me.lblCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCode.Location = New System.Drawing.Point(8, 16)
      Me.lblCode.Name = "lblCode"
      Me.lblCode.Size = New System.Drawing.Size(105, 18)
      Me.lblCode.TabIndex = 0
      Me.lblCode.Text = "เลขที่เอกสาร:"
      Me.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'tgItem
      '
      Me.tgItem.AllowNew = False
      Me.tgItem.AllowSorting = False
      Me.tgItem.AlternatingBackColor = System.Drawing.Color.Khaki
      Me.tgItem.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.tgItem.AutoColumnResize = True
      Me.tgItem.BackColor = System.Drawing.Color.LemonChiffon
      Me.tgItem.CaptionForeColor = System.Drawing.SystemColors.Window
      Me.tgItem.CaptionVisible = False
      Me.tgItem.Cellchanged = False
      Me.tgItem.DataMember = ""
      Me.tgItem.Font = New System.Drawing.Font("Tahoma", 8.25!)
      Me.tgItem.GridLineColor = System.Drawing.Color.FromArgb(CType(210, Byte), CType(200, Byte), CType(120, Byte))
      Me.tgItem.HeaderBackColor = System.Drawing.Color.DarkGoldenrod
      Me.tgItem.HeaderForeColor = System.Drawing.Color.White
      Me.tgItem.Location = New System.Drawing.Point(16, 104)
      Me.tgItem.Name = "tgItem"
      Me.tgItem.ParentRowsBackColor = System.Drawing.SystemColors.ControlText
      Me.tgItem.SelectionBackColor = System.Drawing.Color.Sienna
      Me.tgItem.Size = New System.Drawing.Size(768, 120)
      Me.tgItem.SortingArrowColor = System.Drawing.Color.Red
      Me.tgItem.TabIndex = 15
      Me.tgItem.TreeManager = Nothing
      '
      'ibtnAddWBS
      '
      Me.ibtnAddWBS.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.ibtnAddWBS.Image = CType(resources.GetObject("ibtnAddWBS.Image"), System.Drawing.Image)
      Me.ibtnAddWBS.Location = New System.Drawing.Point(120, 232)
      Me.ibtnAddWBS.Name = "ibtnAddWBS"
      Me.ibtnAddWBS.Size = New System.Drawing.Size(24, 24)
      Me.ibtnAddWBS.TabIndex = 34
      Me.ibtnAddWBS.TabStop = False
      Me.ibtnAddWBS.ThemedImage = CType(resources.GetObject("ibtnAddWBS.ThemedImage"), System.Drawing.Bitmap)
      '
      'ibtnDelWBS
      '
      Me.ibtnDelWBS.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.ibtnDelWBS.Image = CType(resources.GetObject("ibtnDelWBS.Image"), System.Drawing.Image)
      Me.ibtnDelWBS.Location = New System.Drawing.Point(144, 232)
      Me.ibtnDelWBS.Name = "ibtnDelWBS"
      Me.ibtnDelWBS.Size = New System.Drawing.Size(24, 24)
      Me.ibtnDelWBS.TabIndex = 35
      Me.ibtnDelWBS.TabStop = False
      Me.ibtnDelWBS.ThemedImage = CType(resources.GetObject("ibtnDelWBS.ThemedImage"), System.Drawing.Bitmap)
      '
      'lblWBS
      '
      Me.lblWBS.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.lblWBS.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblWBS.ForeColor = System.Drawing.Color.Black
      Me.lblWBS.Location = New System.Drawing.Point(16, 240)
      Me.lblWBS.Name = "lblWBS"
      Me.lblWBS.Size = New System.Drawing.Size(104, 18)
      Me.lblWBS.TabIndex = 33
      Me.lblWBS.Text = "รายการค่าเช่า:"
      Me.lblWBS.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'tgWBS
      '
      Me.tgWBS.AllowNew = False
      Me.tgWBS.AllowSorting = False
      Me.tgWBS.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.tgWBS.AutoColumnResize = True
      Me.tgWBS.CaptionVisible = False
      Me.tgWBS.Cellchanged = False
      Me.tgWBS.ColorList.AddRange(New System.Drawing.Color() {System.Drawing.Color.FromArgb(CType(255, Byte), CType(192, Byte), CType(128, Byte)), System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(192, Byte))})
      Me.tgWBS.DataMember = ""
      Me.tgWBS.HeaderForeColor = System.Drawing.SystemColors.ControlText
      Me.tgWBS.Location = New System.Drawing.Point(16, 256)
      Me.tgWBS.Name = "tgWBS"
      Me.tgWBS.Size = New System.Drawing.Size(768, 208)
      Me.tgWBS.SortingArrowColor = System.Drawing.Color.Red
      Me.tgWBS.TabIndex = 36
      Me.tgWBS.TreeManager = Nothing
      '
      'InternalCharegDetail
      '
      Me.Controls.Add(Me.tgWBS)
      Me.Controls.Add(Me.ibtnAddWBS)
      Me.Controls.Add(Me.ibtnDelWBS)
      Me.Controls.Add(Me.lblWBS)
      Me.Controls.Add(Me.tgItem)
      Me.Controls.Add(Me.grbGeneral)
      Me.Controls.Add(Me.lblItem)
      Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Name = "InternalCharegDetail"
      Me.Size = New System.Drawing.Size(800, 480)
      Me.grbGeneral.ResumeLayout(False)
      CType(Me.tgItem, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.tgWBS, System.ComponentModel.ISupportInitialize).EndInit()
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

#Region " SetLabelText "
    Public Overrides Sub SetLabelText()
      If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
      Me.lblCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetWithdrawDetail.lblCode}")
      Me.Validator.SetDisplayName(txtCode, lblCode.Text)

      Me.lblDocDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetWithdrawDetail.lblDocDate}")
      Me.Validator.SetDisplayName(txtDocDate, lblDocDate.Text)

      Me.lblItem.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetWithdrawDetail.lblItem}")

      Me.lblNote.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetWithdrawDetail.lblNote}")
      Me.Validator.SetDisplayName(txtNote, lblNote.Text)

      Me.grbGeneral.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetWithdrawDetail.grbGeneral}")
    End Sub
#End Region

#Region " Members "
    Private m_entity As AssetWithdraw
    Private m_isInitialized As Boolean = False
    Private m_treeManager As TreeManager
    Private m_tableStyleEnable As Hashtable

    Private m_treeManager2 As TreeManager
    Private m_itcInitialized As Boolean
#End Region

#Region " Constructors "
    Public Sub New()
      MyBase.New()
      Me.InitializeComponent()
      Me.SetLabelText()
      Initialize()

      Dim dt As TreeTable = AssetWithdraw.GetSchemaTable()
      Dim dst As DataGridTableStyle = Me.CreateTableStyle()
      m_treeManager = New TreeManager(dt, tgItem)
      m_treeManager.SetTableStyle(dst)
      m_treeManager.AllowSorting = False
      m_treeManager.AllowDelete = False
      tgItem.AllowNew = False

      AddHandler dt.ColumnChanging, AddressOf ItemTreetable_ColumnChanging
      AddHandler dt.ColumnChanged, AddressOf ItemTreetable_ColumnChanged
      AddHandler dt.RowDeleted, AddressOf dtItemDelete

      Dim dt2 As TreeTable = InternalChargeCollection.GetSchemaTable()
      Dim dst2 As DataGridTableStyle = Me.CreateTableStyle2()
      m_treeManager2 = New TreeManager(dt2, tgWBS)
      m_treeManager2.SetTableStyle(dst2)

      'HACK!!!
      CType(dst2.GridColumnStyles(5), DataGridCheckBoxColumn).RemoveHandlers()

      m_treeManager2.AllowSorting = False
      m_treeManager2.AllowDelete = False

      AddHandler dt2.ColumnChanging, AddressOf Treetable_ColumnChanging
      AddHandler dt2.ColumnChanged, AddressOf Treetable_ColumnChanged
      AddHandler dt2.RowDeleted, AddressOf ItemDelete

      EventWiring()
    End Sub
#End Region

#Region " Style "
    Public Function CreateTableStyle2() As DataGridTableStyle
      Dim dst As New DataGridTableStyle
      dst.MappingName = "InternalCharge"
      Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)

      Dim csLineNumber As New TreeTextColumn
      csLineNumber.MappingName = "LineNumber"
      csLineNumber.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.LineNumberHeaderText}")
      csLineNumber.NullText = ""
      csLineNumber.Width = 30
      csLineNumber.DataAlignment = HorizontalAlignment.Center
      csLineNumber.ReadOnly = True
      csLineNumber.TextBox.Name = "LineNumber"

      Dim csName As New TreeTextColumn
      csName.MappingName = "Name"
      csName.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.InternalCharegDetail.NameHeaderText}")
      csName.NullText = ""
      csName.Width = 200

      Dim csStartDate As New DataGridTimePickerColumn
      csStartDate.MappingName = "StartDate"
      csStartDate.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.InternalCharegDetail.StartDateHeaderText}")
      csStartDate.NullText = ""
      csStartDate.Width = 100

      Dim csEndDate As New DataGridTimePickerColumn
      csEndDate.MappingName = "EndDate"
      csEndDate.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.InternalCharegDetail.EndDateHeaderText}")
      csEndDate.NullText = ""
      csEndDate.Width = 100

      Dim csRate As New TreeTextColumn
      csRate.MappingName = "Rate"
      csRate.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.InternalCharegDetail.RateHeaderText}")
      csRate.NullText = ""
      csRate.Alignment = HorizontalAlignment.Right
      csRate.DataAlignment = HorizontalAlignment.Right
      csRate.Format = "#,###.##"
      csRate.TextBox.Name = "Rate"

      Dim csIsPercent As New DataGridCheckBoxColumn
      csIsPercent.MappingName = "IsPercent"
      csIsPercent.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.InternalCharegDetail.IsPercentHeaderText}")

      Dim csIsFixed As New DataGridCheckBoxColumn
      csIsFixed.MappingName = "IsFixed"
      csIsFixed.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.InternalCharegDetail.IsFixedHeaderText}")

      Dim csAmount As New TreeTextColumn
      csAmount.MappingName = "Amount"
      csAmount.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.InternalCharegDetail.AmountHeaderText}")
      csAmount.NullText = ""
      csAmount.Alignment = HorizontalAlignment.Right
      csAmount.DataAlignment = HorizontalAlignment.Right
      csAmount.Format = "#,###.##"
      csAmount.TextBox.Name = "Amount"
      csAmount.ReadOnly = True

      Dim csNote As New TreeTextColumn
      csNote.MappingName = "Note"
      csNote.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.InternalCharegDetail.NoteHeaderText}")
      csNote.NullText = ""
      csNote.Alignment = HorizontalAlignment.Center
      csNote.DataAlignment = HorizontalAlignment.Left
      csNote.Width = 200

      dst.GridColumnStyles.Add(csLineNumber) '0
      dst.GridColumnStyles.Add(csName) '1
      dst.GridColumnStyles.Add(csStartDate) '2
      dst.GridColumnStyles.Add(csEndDate) '3
      dst.GridColumnStyles.Add(csRate) '4
      dst.GridColumnStyles.Add(csIsPercent) '5
      dst.GridColumnStyles.Add(csAmount) '6
      dst.GridColumnStyles.Add(csNote) '7
      dst.GridColumnStyles.Add(csIsFixed) '8
      For Each colStyle As DataGridColumnStyle In dst.GridColumnStyles
        m_tableStyleEnable.Add(colStyle, colStyle.ReadOnly)
      Next
      Return dst
    End Function
    Private ReadOnly Property CurrentITC() As InternalCharge
      Get
        Dim row As TreeRow = Me.m_treeManager2.SelectedRow
        If row Is Nothing Then
          Return Nothing
        End If
        Return CType(row.Tag, InternalCharge)
      End Get
    End Property
    Protected Function CreateTableStyle() As DataGridTableStyle
      Dim dst As New DataGridTableStyle
      dst.MappingName = "AssetWithdraw"
      Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)

      Dim csName As New TreeTextColumn
      csName.MappingName = "Name"
      csName.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetWithdrawDetail.NameHeaderText}")
      csName.NullText = ""
      csName.Alignment = HorizontalAlignment.Center
      csName.DataAlignment = HorizontalAlignment.Left
      csName.Width = 180
      csName.ReadOnly = True


      Dim csNote As New TreeTextColumn
      csNote.MappingName = "Note"
      csNote.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetWithdrawDetail.NoteHeaderText}")
      csNote.NullText = ""
      csNote.Alignment = HorizontalAlignment.Center
      csNote.DataAlignment = HorizontalAlignment.Left
      csNote.Width = 200
      csNote.ReadOnly = False

      ' Fill Column Style
      dst.GridColumnStyles.Add(csName)
      dst.GridColumnStyles.Add(csNote)

      m_tableStyleEnable = New Hashtable
      For Each colStyle As DataGridColumnStyle In dst.GridColumnStyles
        m_tableStyleEnable.Add(colStyle, colStyle.ReadOnly)
      Next

      Return dst
    End Function
#End Region

#Region "Properties"
    Private ReadOnly Property CurrentItem() As AssetWithdrawItem
      Get
        Dim row As TreeRow = Me.m_treeManager.SelectedRow
        If row Is Nothing Then
          Return Nothing
        End If
        If Not TypeOf row.Tag Is AssetWithdrawItem Then
          Return Nothing
        End If
        Return CType(row.Tag, AssetWithdrawItem)
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
    Private Sub ItemTreetable_ColumnChanging(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs)
      If Not m_isInitialized Then
        Return
      End If
      If Me.m_treeManager.SelectedRow Is Nothing Then
        Return
      End If
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      If Me.m_entity Is Nothing Then
        Return
      End If
      Dim doc As AssetWithdrawItem = Me.CurrentItem
      If doc Is Nothing Then
        doc = New AssetWithdrawItem
        Me.m_entity.ItemCollection.Add(doc)
        Me.m_treeManager.SelectedRow.Tag = doc
      End If
      Try
        Select Case e.Column.ColumnName.ToLower
          Case "code"
            If IsDBNull(e.ProposedValue) OrElse e.ProposedValue Is Nothing Then
              e.ProposedValue = ""
            End If
            doc.SetItemCode(CStr(e.ProposedValue))
          Case "note"
            If IsDBNull(e.ProposedValue) Then
              e.ProposedValue = ""
            End If
            doc.Note = e.ProposedValue.ToString
        End Select
      Catch ex As Exception
        MessageBox.Show(ex.ToString)
      End Try
    End Sub
    Private Sub dtItemDelete(ByVal sender As Object, ByVal e As System.Data.DataRowChangeEventArgs)
    End Sub
#End Region

#Region "TreeTable Handlers"
    Private Sub Treetable_ColumnChanged(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs)
      If Not m_itcInitialized Then
        Return
      End If
      Dim index As Integer = Me.m_treeManager2.Treetable.Childs.IndexOf(CType(e.Row, TreeRow))
      If ValidateRow(CType(e.Row, TreeRow)) Then
        Me.m_treeManager2.Treetable.AcceptChanges()
      End If
      RefreshInternalCharge()
      tgWBS.CurrentRowIndex = index
      Me.WorkbenchWindow.ViewContent.IsDirty = True
    End Sub
    Private Sub Treetable_ColumnChanging(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs)
      If Not m_itcInitialized Then
        Return
      End If
      'If tick checkbox that not in the current hilight row
      If e.Column.ColumnName.ToLower = "isfixed" OrElse e.Column.ColumnName.ToLower = "ispercent" Then
        Me.m_treeManager2.SelectedRow = e.Row
      End If
      Dim doc As InternalCharge = Me.CurrentITC
      Try
        Select Case e.Column.ColumnName.ToLower
          Case "name"
            If IsDBNull(e.ProposedValue) OrElse e.ProposedValue Is Nothing Then
              e.ProposedValue = ""
            End If
            doc.Name = CStr(e.ProposedValue)
          Case "note"
            If IsDBNull(e.ProposedValue) Then
              e.ProposedValue = ""
            End If
            doc.Note = e.ProposedValue.ToString
          Case "rate"
            If IsDBNull(e.ProposedValue) Then
              e.ProposedValue = ""
            End If
            Dim value As Decimal = CDec(TextHelper.TextParser.Evaluate(e.ProposedValue.ToString))
            doc.Rate = value
          Case "startdate"
            If IsDate(e.ProposedValue) Then
              doc.StartDate = CDate(e.ProposedValue)
            End If
          Case "enddate"
            If IsDate(e.ProposedValue) Then
              doc.EndDate = CDate(e.ProposedValue)
            End If
          Case "ispercent"
            If Not IsDBNull(e.ProposedValue) Then
              doc.Ispercent = CBool(e.ProposedValue)
            End If
          Case "isfixed"
            If Not IsDBNull(e.ProposedValue) Then
              doc.IsFixed = CBool(e.ProposedValue)
            End If
        End Select
      Catch ex As Exception
        MessageBox.Show(ex.ToString)
      End Try
    End Sub
    Public Sub ValidateRow(ByVal e As DataColumnChangeEventArgs)
      'Dim wbs As Object = e.Row("wbs")
      'Dim percent As Object = e.Row("percent")

      'Select Case e.Column.ColumnName.ToLower
      '    Case "wbs"
      '        wbs = e.ProposedValue
      '    Case "percent"
      '        percent = e.ProposedValue
      '    Case Else
      '        Return
      'End Select

      'Dim isBlankRow As Boolean = False
      'If IsDBNull(wbs) Then
      '    isBlankRow = True
      'End If

      'If Not isBlankRow Then
      '    If IsDBNull(percent) OrElse CDec(percent) <= 0 Then
      '        e.Row.SetColumnError("percent", Me.StringParserService.Parse("${res:Global.Error.PercentMissing}"))
      '    Else
      '        e.Row.SetColumnError("percent", "")
      '    End If
      '    If IsDBNull(wbs) OrElse wbs.ToString.Length = 0 Then
      '        e.Row.SetColumnError("wbs", Me.StringParserService.Parse("${res:Global.Error.WBSMissing}"))
      '    Else
      '        e.Row.SetColumnError("wbs", "")
      '    End If
      'End If

    End Sub
    Public Function ValidateRow(ByVal row As TreeRow) As Boolean
      'If row.IsNull("WBS") Then
      '    Return False
      'End If
      'Return True
    End Function
    Private m_updating As Boolean = False
    Private Sub ItemDelete(ByVal sender As Object, ByVal e As System.Data.DataRowChangeEventArgs)

    End Sub
#End Region

#Region " IListDetail "
    ' Check Enable 
    Public Overrides Sub CheckFormEnable()
      If Me.m_entity Is Nothing Then
        Return
      End If

      If Me.m_entity.Canceled _
      OrElse Me.m_entity.Status.Value = 0 _
      OrElse Me.m_entity.Status.Value >= 3 _
      OrElse m_entityRefed = 1 Then
        For Each ctrl As Control In Me.Controls
          ctrl.Enabled = False
        Next

        tgItem.Enabled = True
        For Each colStyle As DataGridColumnStyle In Me.m_treeManager.GridTableStyle.GridColumnStyles
          colStyle.ReadOnly = True
        Next
      Else
        For Each ctrl As Control In Me.Controls
          ctrl.Enabled = True
        Next
        For Each colStyle As DataGridColumnStyle In Me.m_treeManager.GridTableStyle.GridColumnStyles
          colStyle.ReadOnly = CBool(m_tableStyleEnable(colStyle))
        Next
      End If
      CheckWBSRight()
    End Sub
    Private Sub CheckWBSRight()
      Dim secSrv As SecurityService = CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService)
      Dim level As Integer = secSrv.GetAccess(256)
      Dim checkString As String = BinaryHelper.DecToBin(level, 5)
      checkString = BinaryHelper.RevertString(checkString)
      If Not CBool(checkString.Substring(0, 1)) Then
        'ห้ามเห็น
        Me.lblWBS.Visible = False
        Me.tgWBS.Visible = False
        Me.ibtnAddWBS.Visible = False
        Me.ibtnDelWBS.Visible = False
      ElseIf Not CBool(checkString.Substring(1, 1)) Then
        'ห้ามแก้
        Me.lblWBS.Visible = True
        Me.tgWBS.Visible = True
        Me.ibtnAddWBS.Visible = True
        Me.ibtnDelWBS.Visible = True

        Me.tgWBS.Enabled = False
        Me.ibtnAddWBS.Enabled = False
        Me.ibtnDelWBS.Enabled = False
      Else
        Me.lblWBS.Visible = True
        Me.tgWBS.Visible = True
        Me.ibtnAddWBS.Visible = True
        Me.ibtnDelWBS.Visible = True

        Me.tgWBS.Enabled = True
        Me.ibtnAddWBS.Enabled = True
        Me.ibtnDelWBS.Enabled = True
      End If
    End Sub
    ' Clear Detail
    Public Overrides Sub ClearDetail()
      For Each crlt As Control In Me.Controls
        If TypeOf crlt Is TextBox Then
          crlt.Text = ""
        ElseIf TypeOf crlt Is FixedGroupBox Then
          For Each ingrb As Control In crlt.Controls
            If TypeOf ingrb Is TextBox Then
              ingrb.Text = ""
            End If
          Next
        End If
      Next
    End Sub
    ' Addhandler events
    Protected Overrides Sub EventWiring()

    End Sub
    ' แสดงค่าข้อมูลของลูกค้าลงใน control ที่อยู่บนฟอร์ม
    Public Overrides Sub UpdateEntityProperties()
      m_isInitialized = False
      ClearDetail()
      If m_entity Is Nothing Then
        Return
      End If
      txtCode.Text = Me.m_entity.Code
      txtNote.Text = Me.m_entity.Note
      ' autogencode

      txtDocDate.Text = MinDateToNull(Me.m_entity.DocDate, "")

      RefreshDocs()

      SetStatus()
      SetLabelText()
      CheckFormEnable()

      m_isInitialized = True
    End Sub
    Private Sub RefreshDocs()
      Me.m_isInitialized = False
      Me.m_entity.ItemCollection.Populate(m_treeManager.Treetable)
      RefreshBlankGrid()
      Me.m_treeManager.Treetable.AcceptChanges()
      Me.UpdateAmount()
      Me.m_isInitialized = True

    End Sub
    Private m_dateSetting As Boolean = False
    Public Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)
      If Me.m_entity Is Nothing Or Not m_isInitialized Then
        Return
      End If
      Dim dirtyFlag As Boolean = False
      Select Case CType(sender, Control).Name.ToLower

      End Select

      Me.WorkbenchWindow.ViewContent.IsDirty = Me.WorkbenchWindow.ViewContent.IsDirty Or dirtyFlag

      CheckFormEnable()
    End Sub
    Private Sub UpdateAmount()
      Dim i As Integer = 0
      Dim rental As Decimal = 0
      'For Each item As TreeRow In Me.m_entity.ItemTable.Rows
      '    If Me.m_entity.ValidateRow(item) Then
      '        i += 1
      '        If IsNumeric(item("stocki_amt")) Then
      '            rental += CDec(item("stocki_amt"))
      '        End If
      '    End If
      'Next
      RefreshInternalCharge()
    End Sub
    Public Sub SetStatus()

    End Sub
    Private m_entityRefed As Integer = -1
    Public Overrides Property Entity() As ISimpleEntity
      Get
        Return Me.m_entity
      End Get
      Set(ByVal Value As ISimpleEntity)
        If Not m_entity Is Nothing Then
          Me.m_entity = Nothing
        End If
        Me.m_entity = CType(Value, AssetWithdraw)
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

#Region " Event Handlers "
    Private Sub ibtnAddWBS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnAddWBS.Click
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      Dim doc As AssetWithdrawItem = Me.CurrentItem
      If doc Is Nothing Then
        Return
      End If
      Dim dt As TreeTable = Me.m_treeManager2.Treetable
      dt.Clear()
      Dim itcColl As InternalChargeCollection = doc.InternalChargeCollection
      Dim itc As New InternalCharge
      itc.Ispercent = False
      itc.StartDate = Now.Date
      itc.EndDate = Now.Date
      itc.Rate = doc.Entity.RentalRate
      itcColl.Add(itc)
      m_itcInitialized = False
      itcColl.Populate(dt)
      m_itcInitialized = True
      Me.WorkbenchWindow.ViewContent.IsDirty = True
    End Sub
    Private Sub ibtnDelWBS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnDelWBS.Click
      Dim dt As TreeTable = Me.m_treeManager2.Treetable
      dt.Clear()
      Dim doc As AssetWithdrawItem = Me.CurrentItem
      If doc Is Nothing Then
        Return
      End If
      Dim itcColl As InternalChargeCollection = doc.InternalChargeCollection
      If itcColl.Count > 0 Then
        itcColl.Remove(itcColl.Count - 1)
        Me.WorkbenchWindow.ViewContent.IsDirty = True
      End If
      m_itcInitialized = False
      itcColl.Populate(dt)
      m_itcInitialized = True
    End Sub
    Private currentY As Integer
    Private Sub tgItem_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tgItem.CurrentCellChanged
      If tgItem.CurrentRowIndex <> currentY Then
        RefreshInternalCharge()
        currentY = tgItem.CurrentRowIndex
      End If
    End Sub
    Private Sub RefreshInternalCharge()
      Dim dt As TreeTable = Me.m_treeManager2.Treetable
      dt.Clear()
      If Me.CurrentItem Is Nothing Then
        Return
      End If
      Dim item As AssetWithdrawItem = Me.CurrentItem
      Dim itcColl As InternalChargeCollection = item.InternalChargeCollection
      m_itcInitialized = False
      itcColl.Populate(dt)
      m_itcInitialized = True
    End Sub
    Private Function GenIDListFromDataTable(ByVal type As Integer) As String
      Dim idlist As String = ""
      For Each item As AssetWithdrawItem In Me.m_entity.ItemCollection
        If Not item.Entity Is Nothing AndAlso item.Entity.Id <> 0 AndAlso Not item.ItemType Is Nothing AndAlso item.ItemType.Value = type Then
          idlist &= "|" & CStr(item.Entity.Id) & "|"
        End If
      Next
      Return idlist
    End Function
#End Region

#Region " IValidatable "
    Public ReadOnly Property FormValidator() As components.PJMTextboxValidator Implements IValidatable.FormValidator
      Get
        Return Me.Validator
      End Get
    End Property
#End Region

#Region " Overrides "
    Public Overrides Sub NotifyBeforeSave()

    End Sub

    Public Overrides ReadOnly Property TabPageIcon() As String
      Get
        Return (New AssetWithdraw).DetailPanelIcon
      End Get
    End Property
#End Region

#Region " Event of Button controls "

#End Region

#Region " IClipboardHandler Overrides "

#End Region

#Region "Grid Resizing"
    Private Sub tgItem_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tgItem.Resize
      If Me.m_entity Is Nothing Then
        Return
      End If
      RefreshBlankGrid()
    End Sub
    Private Sub RefreshBlankGrid()
      If Me.tgItem.Height = 0 Then
        Return
      End If
      Dim dirtyFlag As Boolean = Me.WorkbenchWindow.ViewContent.IsDirty
      Dim index As Integer = tgItem.CurrentRowIndex
      Do Until Me.m_treeManager.Treetable.Rows.Count > tgItem.VisibleRowCount
        'เพิ่มแถวจนเต็ม
        Me.m_treeManager.Treetable.Childs.Add()
      Loop

      If Me.m_entity.ItemCollection.Count = Me.m_treeManager.Treetable.Childs.Count Then
        'เพิ่มอีก 1 แถว ถ้ามีข้อมูลจนถึงแถวสุดท้าย
        Me.m_treeManager.Treetable.Childs.Add()
      End If

      Me.m_treeManager.Treetable.AcceptChanges()
      tgItem.CurrentRowIndex = Math.Max(0, index)
      Me.WorkbenchWindow.ViewContent.IsDirty = dirtyFlag
    End Sub
#End Region

#Region " Private Methods "

#End Region

#Region " Autogencode "
#End Region

  End Class
End Namespace

