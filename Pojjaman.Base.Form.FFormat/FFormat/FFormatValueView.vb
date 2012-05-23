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
  Public Class FFormatValueView
    Inherits AbstractEntityDetailPanelView
    Implements IValidatable

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
    Friend WithEvents lblItem As System.Windows.Forms.Label
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
    Friend WithEvents lblCode As System.Windows.Forms.Label
    Friend WithEvents txtCode As System.Windows.Forms.TextBox
    Friend WithEvents tgItem As Longkong.Pojjaman.Gui.Components.TreeGrid
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents cmbType As System.Windows.Forms.ComboBox
    Friend WithEvents lblType As System.Windows.Forms.Label
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents ibtnRefresh As Longkong.Pojjaman.Gui.Components.ImageButton
    <System.Diagnostics.DebuggerStepThrough()> Protected Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FFormatValueView))
      Me.lblItem = New System.Windows.Forms.Label()
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
      Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
      Me.txtCode = New System.Windows.Forms.TextBox()
      Me.txtName = New System.Windows.Forms.TextBox()
      Me.lblCode = New System.Windows.Forms.Label()
      Me.lblName = New System.Windows.Forms.Label()
      Me.tgItem = New Longkong.Pojjaman.Gui.Components.TreeGrid()
      Me.cmbType = New System.Windows.Forms.ComboBox()
      Me.lblType = New System.Windows.Forms.Label()
      Me.ibtnRefresh = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.tgItem, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'lblItem
      '
      Me.lblItem.BackColor = System.Drawing.Color.Transparent
      Me.lblItem.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblItem.Location = New System.Drawing.Point(8, 64)
      Me.lblItem.Name = "lblItem"
      Me.lblItem.Size = New System.Drawing.Size(64, 18)
      Me.lblItem.TabIndex = 15
      Me.lblItem.Text = "รายการ:"
      Me.lblItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'ErrorProvider1
      '
      Me.ErrorProvider1.ContainerControl = Me
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
      'txtCode
      '
      Me.Validator.SetDataType(Me.txtCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtCode, "")
      Me.txtCode.Enabled = False
      Me.txtCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtCode, System.Drawing.Color.Empty)
      Me.txtCode.Location = New System.Drawing.Point(96, 15)
      Me.txtCode.MaxLength = 20
      Me.Validator.SetMinValue(Me.txtCode, "")
      Me.txtCode.Name = "txtCode"
      Me.Validator.SetRegularExpression(Me.txtCode, "")
      Me.Validator.SetRequired(Me.txtCode, False)
      Me.txtCode.Size = New System.Drawing.Size(88, 21)
      Me.txtCode.TabIndex = 0
      Me.txtCode.TabStop = False
      '
      'txtName
      '
      Me.Validator.SetDataType(Me.txtName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtName, "")
      Me.txtName.Enabled = False
      Me.txtName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtName, System.Drawing.Color.Empty)
      Me.txtName.Location = New System.Drawing.Point(96, 39)
      Me.txtName.MaxLength = 255
      Me.Validator.SetMinValue(Me.txtName, "")
      Me.txtName.Name = "txtName"
      Me.Validator.SetRegularExpression(Me.txtName, "")
      Me.Validator.SetRequired(Me.txtName, False)
      Me.txtName.Size = New System.Drawing.Size(288, 21)
      Me.txtName.TabIndex = 2
      Me.txtName.TabStop = False
      '
      'lblCode
      '
      Me.lblCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCode.ForeColor = System.Drawing.Color.Black
      Me.lblCode.Location = New System.Drawing.Point(16, 16)
      Me.lblCode.Name = "lblCode"
      Me.lblCode.Size = New System.Drawing.Size(80, 18)
      Me.lblCode.TabIndex = 8
      Me.lblCode.Text = "เลขที่:"
      Me.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblName
      '
      Me.lblName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblName.ForeColor = System.Drawing.Color.Black
      Me.lblName.Location = New System.Drawing.Point(16, 40)
      Me.lblName.Name = "lblName"
      Me.lblName.Size = New System.Drawing.Size(80, 18)
      Me.lblName.TabIndex = 11
      Me.lblName.Text = "ชื่อรายงาน:"
      Me.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'tgItem
      '
      Me.tgItem.AllowNew = False
      Me.tgItem.AllowSorting = False
      Me.tgItem.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.tgItem.AutoColumnResize = False
      Me.tgItem.CaptionVisible = False
      Me.tgItem.Cellchanged = False
      Me.tgItem.DataMember = ""
      Me.tgItem.HeaderForeColor = System.Drawing.SystemColors.ControlText
      Me.tgItem.Location = New System.Drawing.Point(8, 80)
      Me.tgItem.Name = "tgItem"
      Me.tgItem.Size = New System.Drawing.Size(792, 312)
      Me.tgItem.SortingArrowColor = System.Drawing.Color.Red
      Me.tgItem.TabIndex = 7
      Me.tgItem.TreeManager = Nothing
      '
      'cmbType
      '
      Me.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbType.Enabled = False
      Me.cmbType.Location = New System.Drawing.Point(264, 16)
      Me.cmbType.Name = "cmbType"
      Me.cmbType.Size = New System.Drawing.Size(121, 21)
      Me.cmbType.TabIndex = 1
      '
      'lblType
      '
      Me.lblType.Enabled = False
      Me.lblType.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblType.ForeColor = System.Drawing.Color.Black
      Me.lblType.Location = New System.Drawing.Point(208, 16)
      Me.lblType.Name = "lblType"
      Me.lblType.Size = New System.Drawing.Size(56, 18)
      Me.lblType.TabIndex = 10
      Me.lblType.Text = "ประเภท:"
      Me.lblType.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'ibtnRefresh
      '
      Me.ibtnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnRefresh.Location = New System.Drawing.Point(392, 16)
      Me.ibtnRefresh.Name = "ibtnRefresh"
      Me.ibtnRefresh.Size = New System.Drawing.Size(32, 32)
      Me.ibtnRefresh.TabIndex = 16
      Me.ibtnRefresh.ThemedImage = CType(resources.GetObject("ibtnRefresh.ThemedImage"), System.Drawing.Bitmap)
      '
      'FFormatValueView
      '
      Me.Controls.Add(Me.ibtnRefresh)
      Me.Controls.Add(Me.cmbType)
      Me.Controls.Add(Me.tgItem)
      Me.Controls.Add(Me.lblCode)
      Me.Controls.Add(Me.txtCode)
      Me.Controls.Add(Me.lblName)
      Me.Controls.Add(Me.txtName)
      Me.Controls.Add(Me.lblItem)
      Me.Controls.Add(Me.lblType)
      Me.Name = "FFormatValueView"
      Me.Size = New System.Drawing.Size(808, 400)
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.tgItem, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

    End Sub

#End Region

#Region "Members"
    Private m_entity As FFormat
    Private m_isInitialized As Boolean = False
    Private m_treeManager As TreeManager

    Private m_tableStyleEnable As Hashtable

    Private m_enableState As Hashtable
#End Region

#Region "Constructors"
    Public Sub New()
      MyBase.New()
      Me.InitializeComponent()
      Me.SetLabelText()
      Initialize()

      SaveEnableState()
      EventWiring()
    End Sub
    Private Sub SaveEnableState()
      m_enableState = New Hashtable
      For Each ctrl As Control In Me.Controls
        m_enableState.Add(ctrl, ctrl.Enabled)
      Next
    End Sub
#End Region

#Region "Properties"
    Private ReadOnly Property CurrentItem() As FFormatItem
      Get
        Dim row As TreeRow = Me.m_treeManager.SelectedRow
        If row Is Nothing Then
          Return Nothing
        End If
        If Not TypeOf row.Tag Is FFormatItem Then
          Return Nothing
        End If
        Return CType(row.Tag, FFormatItem)
      End Get
    End Property
#End Region

#Region "TreeTable Handlers"
    Private Sub Treetable_ColumnChanged(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs)
      If Not m_isInitialized Then
        Return
      End If
      Dim index As Integer = Me.m_treeManager.Treetable.Childs.IndexOf(CType(e.Row, TreeRow))
      If ValidateRow(CType(e.Row, TreeRow)) Then
        Dim pe As New PropertyChangedEventArgs("ItemChanged", "", "")
      End If
      Me.WorkbenchWindow.ViewContent.IsDirty = True
      RefreshDocs()
      tgItem.CurrentRowIndex = index
    End Sub
    Private Sub Treetable_ColumnChanging(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs)
      Try
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
        Dim item As FFormatItem = Me.CurrentItem
        If item Is Nothing Then
          item = New FFormatItem(Me.m_entity)
          Me.m_entity.ItemCollection.Add(item)
          Me.m_treeManager.SelectedRow.Tag = item
        End If
        '            myDatatable.Columns.Add(New DataColumn("ffi_linenumber", GetType(Integer)))

        '    myDatatable.Columns.Add(New DataColumn("ffi_code", GetType(String)))

        'Dim i As Integer = 0
        '    For Each col As FFormatColumn In Me.ColumnCollection
        '        i += 1
        '        myDatatable.Columns.Add(New DataColumn("ffi_formula" & i.ToString, GetType(String)))
        '        myDatatable.Columns.Add(New DataColumn("btn_account" & i.ToString, GetType(String)))
        '    Next

        '    myDatatable.Columns.Add(New DataColumn("ffi_isnewpage", GetType(Boolean)))
        '    myDatatable.Columns.Add(New DataColumn("ffi_linestyle", GetType(Integer)))
        '    myDatatable.Columns.Add(New DataColumn("ffi_invisible", GetType(String)))
        '    myDatatable.Columns.Add(New DataColumn("ffi_style", GetType(String)))
        '    myDatatable.Columns.Add(New DataColumn("btn_style", GetType(String)))
        Select Case e.Column.ColumnName.ToLower
          Case "ffi_style"
            If Not IsDBNull(e.ProposedValue) Then
              item.Style = CStr(e.ProposedValue)
            Else
              item.Style = ""
            End If
          Case "ffi_isnewpage"
            If Not IsDBNull(e.ProposedValue) Then
              item.IsNewPage = CBool(e.ProposedValue)
            Else
              item.IsNewPage = False
            End If
          Case "ffi_invisible"
            If Not IsDBNull(e.ProposedValue) Then
              item.IsInvisible = CBool(e.ProposedValue)
            Else
              item.IsInvisible = False
            End If
          Case "ffi_linestyle"
            If Not IsDBNull(e.ProposedValue) Then
              item.LineStyle = CInt(e.ProposedValue)
            Else
              item.LineStyle = 0
            End If
        End Select
        For Each col As FFormatColumn In Me.m_entity.ColumnCollection
          If e.Column.ColumnName.ToLower = "ffi_formula" & col.LineNumber.ToString Then
            If IsDBNull(e.ProposedValue) Then
              e.ProposedValue = ""
            End If
            item.DataCollection(col).Formula = CStr(e.ProposedValue)
          End If
        Next
        ValidateRow(e)
      Catch ex As Exception
        MessageBox.Show(ex.ToString)
      End Try
    End Sub
    Public Sub ValidateRow(ByVal e As DataColumnChangeEventArgs)
      ''Dim proposedCode As Object = e.Row("ffi_code")
      'Dim proposedName As Object = e.Row("ffi_name")

      'Select Case e.Column.ColumnName.ToLower
      '    Case "ffi_code"
      '        'proposedCode = e.ProposedValue
      '    Case "ffi_name"
      '        proposedName = e.ProposedValue
      '    Case Else
      '        Return
      'End Select

      'If IsDBNull(proposedName) OrElse CStr(proposedName).Length = 0 Then
      '    e.Row.SetColumnError("ffi_name", Me.StringParserService.Parse("${res:Global.Error.ItemNameMissing}"))
      'Else
      '    e.Row.SetColumnError("ffi_name", "")
      'End If
    End Sub
    Public Function ValidateRow(ByVal row As TreeRow) As Boolean
      Return row.Tag Is Nothing
    End Function
    Private Sub ItemDelete(ByVal sender As Object, ByVal e As System.Data.DataRowChangeEventArgs)
    End Sub
#End Region

#Region "IListDetail"
    Public Overrides Sub CheckFormEnable()
      If Me.m_entity Is Nothing Then
        Return
      End If
      If Me.m_entity.Status.Value = 0 _
      OrElse Me.m_entity.Status.Value >= 3 _
      Then
        Me.Enabled = False
      Else
        Me.Enabled = True
      End If
    End Sub
    Public Overrides Sub ClearDetail()
      For Each crlt As Control In Me.Controls
        If crlt.Name.StartsWith("txt") Then
          crlt.Text = ""
        End If
      Next
    End Sub
    Public Overrides Sub SetLabelText()
      If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
      Me.lblItem.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.FFormatValueView.lblItem}")
      Me.lblCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.FFormatValueView.lblCode}")
      Me.lblName.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.FFormatValueView.lblName}")
      Me.lblType.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.FFormatValueView.lblType}")
    End Sub
    Protected Overrides Sub EventWiring()

    End Sub
    ' แสดงค่าข้อมูลของลูกค้าลงใน control ที่อยู่บนฟอร์ม
    Public Overrides Sub UpdateEntityProperties()
      m_isInitialized = False
      ClearDetail()
      If m_entity Is Nothing Then
        Return
      End If

      txtCode.Text = m_entity.Code
      txtName.Text = m_entity.Name

      CodeDescription.ComboSelect(Me.cmbType, Me.m_entity.ReportType)

      Dim dt As TreeTable = m_entity.GetSchemaTable()
      Dim dst As DataGridTableStyle = m_entity.CreateValueTableStyle()

      m_tableStyleEnable = New Hashtable
      For Each colStyle As DataGridColumnStyle In dst.GridColumnStyles
        m_tableStyleEnable.Add(colStyle, colStyle.ReadOnly)
      Next

      m_treeManager = New TreeManager(dt, tgItem)
      m_treeManager.SetTableStyle(dst)
      m_treeManager.AllowSorting = False
      m_treeManager.AllowDelete = False
      tgItem.AllowNew = False

      RefreshDocs()

      m_value = False

      SetStatus()
      SetLabelText()
      CheckFormEnable()
      m_isInitialized = True
    End Sub
    Private Sub RefreshDocs()
      Me.m_isInitialized = False
      Me.m_entity.ItemCollection.Populate(m_treeManager.Treetable)
      RefreshBlankGrid()
      ReIndex()
      Me.m_isInitialized = True
    End Sub
    Private m_value As Boolean
    Private Function RefreshDocsValue() As Boolean
      Try
        Me.m_isInitialized = False
        If m_value Then
          Me.m_entity.ItemCollection.Populate(m_treeManager.Treetable)
        Else
          Me.m_entity.ItemCollection.PopulateValue(m_treeManager.Treetable)
        End If
        m_value = Not m_value
        RefreshBlankGrid()
        ReIndex()
        Me.m_isInitialized = True
        Me.m_treeManager.Treetable.AcceptChanges()
      Catch e As Exception
        Return False
      End Try
      Return True

    End Function
    Private Sub PropChanged(ByVal sender As Object, ByVal e As PropertyChangedEventArgs)
      If e.Name = "ItemChanged" Then
        Me.WorkbenchWindow.ViewContent.IsDirty = True
      End If
    End Sub
    Private m_optionsetting As Boolean = False
    Public Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)
      If Me.m_entity Is Nothing Or Not m_isInitialized Then
        Return
      End If
      Dim dirtyFlag As Boolean = False
      Select Case CType(sender, Control).Name.ToLower
        Case "txtcode"
          Me.m_entity.Code = txtCode.Text
          dirtyFlag = True
        Case "txtname"
          Me.m_entity.Name = txtName.Text
          dirtyFlag = True
      End Select
      Me.WorkbenchWindow.ViewContent.IsDirty = Me.WorkbenchWindow.ViewContent.IsDirty Or dirtyFlag
      CheckFormEnable()
    End Sub
    Public Sub SetStatus()
      'If m_entity.Canceled Then
      '    Me.StatusBarService.SetMessage("ยกเลิก: " & m_entity.CancelDate.ToShortDateString & _
      '    " " & m_entity.CancelDate.ToShortTimeString & _
      '    "  โดย:" & m_entity.CancelPerson.Name)
      'ElseIf m_entity.Edited Then
      '    Me.StatusBarService.SetMessage("แก้ไขล่าสุด: " & m_entity.LastEditDate.ToShortDateString & _
      '    " " & m_entity.LastEditDate.ToShortTimeString & _
      '    "  โดย:" & m_entity.LastEditor.Name)
      'ElseIf m_entity.Originated Then
      '    Me.StatusBarService.SetMessage("เพิ่มเข้าสู่ระบบ: " & m_entity.OriginDate.ToShortDateString & _
      '    " " & m_entity.OriginDate.ToShortTimeString & _
      '    "  โดย:" & m_entity.Originator.Name)
      'Else
      '    Me.StatusBarService.SetMessage("")
      'End If
    End Sub
    Public Overrides Property Entity() As ISimpleEntity
      Get
        Return Me.m_entity
      End Get
      Set(ByVal Value As ISimpleEntity)
        If Not m_entity Is Nothing Then
          RemoveHandler Me.m_entity.PropertyChanged, AddressOf PropChanged
          Me.m_entity = Nothing
        End If
        Me.m_entity = CType(Value, FFormat)
        'Hack:
        If Not m_entity Is Nothing Then
          Me.m_entity.OnTabPageTextChanged(m_entity, EventArgs.Empty)
        End If
        UpdateEntityProperties()
      End Set
    End Property

    Public Overrides Sub Initialize()
      PopulateType()
    End Sub
    Private Sub PopulateType()
      CodeDescription.ListCodeDescriptionInComboBox(Me.cmbType, "financialstatement_type")
    End Sub
#End Region

#Region "Event Handlers"
    Private Sub ibtnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnRefresh.Click
      'If Me.BackgroundWorker1.IsBusy Then
      '  Return
      'End If

      'Me.BackgroundWorker1.RunWorkerAsync()
      RefreshDocsValue()
    End Sub
    Private Sub ibtnBlank_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Dim index As Integer = tgItem.CurrentRowIndex
      If index > Me.m_entity.ItemCollection.Count - 1 Then
        Return
      End If
      Me.m_entity.ItemCollection.Insert(index, New FFormatItem(Me.m_entity))
      RefreshDocs()
      tgItem.CurrentRowIndex = index
      Dim re As New DataColumnChangeEventArgs(Me.m_treeManager.Treetable.Rows(index) _
      , Me.m_treeManager.Treetable.Columns("ffi_code") _
      , Me.CurrentItem.Code)
      Me.ValidateRow(re)
      Me.WorkbenchWindow.ViewContent.IsDirty = True
    End Sub
    Private Sub ibtnDelRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Dim index As Integer = Me.tgItem.CurrentRowIndex
      Dim row As TreeRow = Me.m_treeManager.SelectedRow
      If row Is Nothing Then
        Return
      End If
      Dim doc As FFormatItem = Me.CurrentItem
      If doc Is Nothing Then
        Return
      End If
      Me.WorkbenchWindow.ViewContent.IsDirty = True
      Me.m_entity.ItemCollection.Remove(doc)
      RefreshDocs()
      Me.tgItem.CurrentRowIndex = index
    End Sub
    Private Sub ReIndex()
      Dim i As Integer = 0
      For Each row As DataRow In Me.m_treeManager.Treetable.Rows
        row("ffi_linenumber") = i + 1
        i += 1
      Next
    End Sub
    Private ReadOnly Property StandardFont() As Font
      Get
        Return New Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      End Get
    End Property
    Public Sub SetFontStyle(ByVal e As ButtonColumnEventArgs)
      Dim theRow As TreeRow = m_treeManager.SelectedRow
      If theRow Is Nothing Then
        Return
      End If
      Dim fnt As System.Drawing.Font
      Dim dialog As New FontDialog
      With dialog
        .MinSize = 6
        .MaxSize = 72
        Select Case e.Column
          Case 3
            .Font = FFormat.StringToFont(CStr(IIf(theRow.IsNull("ffi_namestyle"), "", theRow("ffi_namestyle"))))
          Case 6
            .Font = FFormat.StringToFont(CStr(IIf(theRow.IsNull("ffi_notestyle"), "", theRow("ffi_notestyle"))))
          Case 8
            .Font = FFormat.StringToFont(CStr(IIf(theRow.IsNull("ffi_formulastyle"), "", theRow("ffi_formulastyle"))))
          Case Else
            .Font = Me.StandardFont
        End Select
        If .ShowDialog = DialogResult.OK Then
          fnt = .Font
        End If
      End With

      Dim fntstr As String = FFormat.FontToString(fnt)
      Select Case e.Column
        Case 3
          theRow("ffi_namestyle") = fntstr
        Case 6
          theRow("ffi_notestyle") = fntstr
        Case 8
          theRow("ffi_formulastyle") = fntstr
        Case Else

      End Select
    End Sub
    Private m_currentColName As String = ""
    Public Sub AccountButtonClicked(ByVal e As ButtonColumnEventArgs)
      Dim theRow As TreeRow = m_treeManager.SelectedRow
      Dim item As FFormatItem = Me.CurrentItem
      m_currentColName = "ffi_formula" & CStr(e.Column / 2)
      If item Is Nothing Then
        Return
      End If
      If Not Me.m_treeManager.Treetable.Columns.Contains(m_currentColName) Then
        Return
      End If
      Dim filters(0) As Filter
      filters(0) = New Filter("CodeList", GenIDListFromDataTable(theRow, m_currentColName))
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenTreeDialog(New Account, AddressOf SetAccts, filters, Nothing)
    End Sub
    Private Sub SetAccts(ByVal items As BasketItemCollection)
      Dim acctList As String = ""
      For i As Integer = 0 To items.Count - 1
        Dim item As BasketItem = CType(items(i), BasketItem)
        Dim myItem As New Account(item.Id)
        If myItem.IsControlGroup Then
          ' ToDo :
        Else
          acctList += "|" & myItem.Code & "|"
        End If
      Next
      Dim theRow As TreeRow = m_treeManager.SelectedRow
      theRow(m_currentColName) = acctList
      Me.m_treeManager.Treetable.AcceptChanges()
      'RefreshBlankGrid()
    End Sub
    Private Function GenIDListFromDataTable(ByVal theRow As TreeRow, ByVal colName As String) As String
      Dim idlist As String = ""
      Me.m_treeManager.Treetable.AcceptChanges()
      For Each row As TreeRow In Me.m_treeManager.Treetable.Rows
        If Not row Is theRow Then
          If Not row.IsNull(colName) Then
            Dim formula As String = CStr(row(colName))
            idlist += formula
          End If
        End If
      Next
      Return idlist
    End Function
#End Region

#Region "IValidatable"
    Public ReadOnly Property FormValidator() As components.PJMTextboxValidator Implements IValidatable.FormValidator
      Get
        Return Me.Validator
      End Get
    End Property
#End Region

#Region "Overrides"
    Public Overrides Sub NotifyBeforeSave()

    End Sub
    Public Overrides ReadOnly Property TabPageIcon() As String
      Get
        Return "Icons.16x16.FFormatValueView" '(New PR).DetailPanelIcon
      End Get
    End Property
#End Region

#Region "Event of Button controls"

#End Region

#Region "Grid Resizing"
    Private Sub tgItem_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs)
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

#Region "After the main entity has been saved"
    Public Overrides Sub NotifyAfterSave(ByVal successful As Boolean)
      If Not successful Then
        Return
      End If
      Me.Entity = CType(Me.WorkbenchWindow.SubViewContents(1), ISimpleEntityPanel).Entity
    End Sub
#End Region

    Private Sub BackgroundWorker1_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
      e.Result = RefreshDocsValue()

    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted

    End Sub
  End Class
End Namespace