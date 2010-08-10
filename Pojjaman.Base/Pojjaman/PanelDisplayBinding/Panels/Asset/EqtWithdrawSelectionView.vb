Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.PanelDisplayBinding
Imports Longkong.Pojjaman.Gui
Imports Longkong.Pojjaman.Gui.Pads
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.DataAccessLayer
Namespace Longkong.Pojjaman.Gui.Panels
  Public Class EqtWithdrawSelectionView
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
    Friend WithEvents pnlFilter As System.Windows.Forms.Panel
    Friend WithEvents Splitter1 As System.Windows.Forms.Splitter
    Friend WithEvents tgItem As Longkong.Pojjaman.Gui.Components.TreeGrid
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.pnlFilter = New System.Windows.Forms.Panel
      Me.Splitter1 = New System.Windows.Forms.Splitter
      Me.tgItem = New Longkong.Pojjaman.Gui.Components.TreeGrid
      CType(Me.tgItem, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'pnlFilter
      '
      Me.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top
      Me.pnlFilter.Location = New System.Drawing.Point(0, 0)
      Me.pnlFilter.Name = "pnlFilter"
      Me.pnlFilter.Size = New System.Drawing.Size(768, 152)
      Me.pnlFilter.TabIndex = 0
      '
      'Splitter1
      '
      Me.Splitter1.Dock = System.Windows.Forms.DockStyle.Top
      Me.Splitter1.Location = New System.Drawing.Point(0, 152)
      Me.Splitter1.Name = "Splitter1"
      Me.Splitter1.Size = New System.Drawing.Size(768, 3)
      Me.Splitter1.TabIndex = 1
      Me.Splitter1.TabStop = False
      '
      'tgItem
      '
      Me.tgItem.AllowNew = False
      Me.tgItem.AllowSorting = False
      Me.tgItem.AlternatingBackColor = System.Drawing.Color.FromArgb(CType(CType(217, Byte), Integer), CType(CType(222, Byte), Integer), CType(CType(236, Byte), Integer))
      'Me.tgItem.AlternatingBackColor = System.Drawing.SystemColors.InactiveCaptionText
      Me.tgItem.AutoColumnResize = True
      Me.tgItem.CaptionVisible = False
      Me.tgItem.Cellchanged = False
      Me.tgItem.DataMember = ""
      Me.tgItem.Dock = System.Windows.Forms.DockStyle.Fill
      Me.tgItem.HeaderBackColor = System.Drawing.Color.Khaki
      Me.tgItem.HeaderForeColor = System.Drawing.SystemColors.ControlText
      Me.tgItem.Location = New System.Drawing.Point(0, 155)
      Me.tgItem.Name = "tgItem"
      Me.tgItem.Size = New System.Drawing.Size(768, 328)
      Me.tgItem.SortingArrowColor = System.Drawing.Color.Red
      Me.tgItem.TabIndex = 7
      Me.tgItem.TreeManager = Nothing
      '
      'EqtWithdrawSelectionView
      '
      Me.Controls.Add(Me.tgItem)
      Me.Controls.Add(Me.Splitter1)
      Me.Controls.Add(Me.pnlFilter)
      Me.Name = "EqtWithdrawSelectionView"
      Me.Size = New System.Drawing.Size(768, 483)
      CType(Me.tgItem, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Members"
    Private m_filterSubPanel As IFilterSubPanel
    Private m_entity As ISimpleEntity
    Private m_selectedID As Integer

    Private m_basketItems As BasketItemCollection
    Private m_proposedBasketItems As BasketItemCollection
    Private m_treeManager As TreeManager

    Private m_selectionMode As Selection

    Private m_oldBasket As BasketItemCollection

    Private m_otherFilters As Filter()
#End Region

#Region "Constructors"
    Public Sub New(ByVal entity As ISimpleEntity, ByVal mode As Selection, ByVal basket As BasketDialog, ByVal filters As Filter(), ByVal entities As ArrayList)
      MyBase.New()

      InitializeComponent()
      m_entity = entity
      Me.SetLabelText()
      Me.TitleName = Me.StringParserService.Parse(m_entity.ListPanelTitle)
      Me.PanelName = Me.Name

      'Hack
      m_filterSubPanel = New EqtWithdrawForSelectFilterSubPanel
      m_filterSubPanel.Entities = entities

      Dim filterControl As UserControl = CType(Me.m_filterSubPanel, UserControl)
      Me.pnlFilter.Controls.Add(filterControl)
      Me.pnlFilter.Height = filterControl.Height
      m_otherFilters = filters

      AddHandler Me.m_filterSubPanel.SearchButton.Click, AddressOf btnSearch_Click
      Me.m_filterSubPanel.SearchButton.PerformClick()

      m_basketItems = New BasketItemCollection
      m_proposedBasketItems = New BasketItemCollection
      m_oldBasket = New BasketItemCollection

      m_selectionMode = mode
    End Sub
    Public Sub New(ByVal entity As ISimpleEntity, ByVal basket As BasketDialog, ByVal filters As Filter(), ByVal entities As ArrayList)
      Me.new(entity, Selection.MultiSelect, basket, filters, entities)
    End Sub
#End Region

#Region "Properties"
    Public Enum Selection
      None
      MultiSelect
      SingleSelect
    End Enum
    Public ReadOnly Property SelectionMode() As Selection
      Get
        Return Me.m_selectionMode
      End Get
    End Property
#End Region

#Region "Methods"
    Private Sub RowIcon_Click(ByVal e As ButtonColumnEventArgs)
      Dim myTable As TreeTable = Me.m_treeManager.Treetable
      Dim clickedRow As TreeRow = CType(myTable.Rows(e.Row), TreeRow)
      For Each row As TreeRow In myTable.Childs
        Dim checkCount As Integer = 0
        For Each childRow As TreeRow In row.Childs
          If e.Row = row.Index Then
            'คลิกโดนแม่
            childRow("Selected") = row("Selected")
          End If
          If CBool(childRow("Selected")) Then
            checkCount += 1
          End If
        Next
        If checkCount = row.Childs.Count Then
          row("Selected") = True
        ElseIf checkCount = 0 Then
          row("Selected") = False
        Else
          row("Selected") = DBNull.Value
        End If
      Next
    End Sub
    Public Sub ChangeTitle(ByVal sender As Object, ByVal e As EventArgs) Implements ISimpleListPanel.ChangeTitle
      If Me.WorkbenchWindow.ActiveViewContent Is Me Then
        Me.TitleName = Me.StringParserService.Parse(m_entity.ListPanelTitle)
        Return
      End If
      'If Not m_selectedEntity Is Nothing Then
      '    Me.TitleName = m_selectedEntity.TabPageText
      'End If
    End Sub
    Public Sub SearchData(ByVal order As String)

      Dim filters As Filter() = Me.m_filterSubPanel.GetFilterArray
      Dim otherLength As Integer = 0
      If Not m_otherFilters Is Nothing AndAlso m_otherFilters.Length > 0 Then
        otherLength = m_otherFilters.Length
      End If
      Dim newfilters(filters.Length + otherLength - 1) As Filter
      For i As Integer = 0 To filters.Length - 1
        newfilters(i) = filters(i)
      Next
      If otherLength > 0 Then
        For i As Integer = 0 To otherLength - 1
          newfilters(i + filters.Length) = m_otherFilters(i)
        Next
      End If

      If TypeOf m_entity Is EquipmentToolWithdrawforSelection Then
        Dim filterdt As DataTable = Nothing
        Dim procName As String = "Get" & m_entity.ClassName & "List"
        filterdt = EqtItem.GetListDatatable(procName, newfilters)
        PopDataStyle(filterdt)
      End If

    End Sub

    Private Sub PopDataStyle(ByVal filterdt As DataTable)
      Dim dt As TreeTable = GetSchemaTable()
      dt.Clear()
      Dim parRow As TreeRow
      Dim currentEqtW As Integer = -1

      For Each filteredRow As DataRow In filterdt.Rows
        Dim drh As New DataRowHelper(filteredRow)
        Dim eqtwid As Integer = drh.GetValue(Of Integer)("eqtstock_id")
        Dim eqtwCode As String = drh.GetValue(Of String)("eqtstock_code")
        Dim Eqt As String = drh.GetValue(Of String)("eqtinfo")
        Dim Unit As String = drh.GetValue(Of String)("unit_name")
        Dim Qty As Decimal = drh.GetValue(Of Decimal)("eqtstocki_Qty")
        Dim RentalRate As Decimal = drh.GetValue(Of Decimal)("eqtstocki_rentalrate")
        Dim LineNumber As Integer = drh.GetValue(Of Integer)("eqtstocki_linenumber")
        Dim sequence As Integer = drh.GetValue(Of Integer)("eqtstocki_sequence")

        If currentEqtW <> eqtwid Then
          parRow = dt.Childs.Add
          parRow("Selected") = False
          parRow("Code") = eqtwCode
          parRow("EquipmentTool") = eqtwCode
          parRow("Unit") = ""
          parRow("Qty") = ""
          parRow("RentRate") = ""
          parRow.CustomFontStyle = FontStyle.Bold
          currentEqtW = eqtwid
        End If
        If Not parRow Is Nothing Then
          Dim childRow As TreeRow = parRow.Childs.Add
          childRow("Selected") = False
          childRow("Code") = ""
          childRow("EquipmentTool") = Eqt
          childRow("Unit") = Unit
          childRow("Qty") = Configuration.FormatToString(Qty, DigitConfig.Price)
          childRow("RentRate") = Configuration.FormatToString(RentalRate, DigitConfig.Price)
          childRow("Linenumber") = Configuration.FormatToString(LineNumber, DigitConfig.Int)
          childRow("sequence") = sequence
          'Dim eqtwitem As New EquipmentToolWithdrawItem
          'eqtwitem.EquipmentToolWithdraw = New EquipmentToolWithdraw
          'eqtwitem.EquipmentToolWithdraw.Id = eqtwid
          'eqtwitem.LineNumber = LineNumber
          childRow.Tag = filteredRow
        End If
      Next
      dt.AcceptChanges()

      Dim dst As DataGridTableStyle = CreateListTableStyle2()
      m_treeManager = New TreeManager(dt, tgItem)
      m_treeManager.SetTableStyle(dst)
      m_treeManager.AllowSorting = False
      m_treeManager.AllowDelete = False
    End Sub

    Public Shared Function GetSchemaTable() As TreeTable
      Dim myDatatable As New TreeTable("EqtwItems")

      myDatatable.Columns.Add(New DataColumn("Selected", GetType(Boolean)))
      myDatatable.Columns.Add(New DataColumn("Code", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("EquipmentTool", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Unit", GetType(String)))
      'myDatatable.Columns.Add(New DataColumn("CostCenter", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Qty", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("RentRate", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Linenumber", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("sequence", GetType(Integer)))
      Return myDatatable
    End Function
#End Region
#Region "Style"
    Public Function CreateListTableStyle() As DataGridTableStyle
      Dim dst As New DataGridTableStyle
      dst.MappingName = "PRItems1"

      Dim csSelected As New DataGridCheckBoxColumn
      csSelected.MappingName = "Selected"
      csSelected.HeaderText = ""
      AddHandler csSelected.Click, AddressOf RowIcon_Click

      Dim csDescription As New TreeTextColumn
      csDescription.MappingName = "Material"
      csDescription.HeaderText = "Material"
      csDescription.NullText = ""
      csDescription.Width = 180
      csDescription.ReadOnly = True

      Dim csQty As New TreeTextColumn
      csQty.MappingName = "Qty"
      csQty.HeaderText = "Qty"
      csQty.NullText = ""
      csQty.ReadOnly = True

      Dim csOrderedQty As New TreeTextColumn
      csOrderedQty.MappingName = "OrderedQty"
      csOrderedQty.HeaderText = "OrderedQty"
      csOrderedQty.NullText = ""
      csOrderedQty.ReadOnly = True

      Dim csDate As New TreeTextColumn
      csDate.MappingName = "Date"
      csDate.HeaderText = "Date"
      csDate.NullText = ""
      csDate.DataAlignment = HorizontalAlignment.Center
      csDate.Width = 100
      csDate.Format = "d"
      csDate.ReadOnly = True

      Dim csReceivingDate As New TreeTextColumn
      csReceivingDate.MappingName = "ReceivingDate"
      csReceivingDate.HeaderText = "ReceivingDate"
      csReceivingDate.NullText = ""
      csReceivingDate.DataAlignment = HorizontalAlignment.Center
      csReceivingDate.Width = 100
      csReceivingDate.Format = "d"
      csReceivingDate.ReadOnly = True

      Dim csRequestor As New TreeTextColumn
      csRequestor.MappingName = "Requestor"
      csRequestor.HeaderText = "Requestor"
      csRequestor.NullText = ""
      csRequestor.DataAlignment = HorizontalAlignment.Center
      csRequestor.Width = 100
      csRequestor.ReadOnly = True

      Dim csCostCenter As New TreeTextColumn
      csCostCenter.MappingName = "CostCenter"
      csCostCenter.HeaderText = "CostCenter"
      csCostCenter.NullText = ""
      csCostCenter.DataAlignment = HorizontalAlignment.Center
      csCostCenter.Width = 100
      csCostCenter.ReadOnly = True

      dst.GridColumnStyles.Add(csSelected)
      dst.GridColumnStyles.Add(csDescription)
      dst.GridColumnStyles.Add(csQty)
      dst.GridColumnStyles.Add(csOrderedQty)
      dst.GridColumnStyles.Add(csDate)
      dst.GridColumnStyles.Add(csReceivingDate)
      Return dst
    End Function
    Public Function CreateListTableStyle2() As DataGridTableStyle
      Dim dst As New DataGridTableStyle
      dst.MappingName = "EqtwItems"

      Dim csSelected As New DataGridCheckBoxColumn
      csSelected.MappingName = "Selected"
      csSelected.HeaderText = ""
      AddHandler csSelected.Click, AddressOf RowIcon_Click

      Dim csDescription As New TreeTextColumn
      csDescription.MappingName = "EquipmentTool"
      csDescription.HeaderText = "เลขที่เอกสาร/เครื่องมือ"
      csDescription.NullText = ""
      csDescription.Width = 190
      csDescription.ReadOnly = True

      Dim csUnit As New TreeTextColumn
      csUnit.MappingName = "Unit"
      csUnit.HeaderText = "หน่วยมาตรฐาน"
      csUnit.NullText = ""
      csUnit.Width = 70
      csUnit.DataAlignment = HorizontalAlignment.Center
      csUnit.ReadOnly = True

      Dim csQty As New TreeTextColumn
      csQty.MappingName = "Qty"
      csQty.HeaderText = "ปริมาณ เบิก"
      csQty.DataAlignment = HorizontalAlignment.Right
      csQty.NullText = ""
      csQty.Width = 90
      csQty.ReadOnly = True

      Dim csRentRate As New TreeTextColumn
      csRentRate.MappingName = "RentRate"
      csRentRate.HeaderText = "ค่าเช่าต่อวัน"
      csRentRate.DataAlignment = HorizontalAlignment.Right
      csRentRate.NullText = ""
      csRentRate.Width = 90
      csRentRate.ReadOnly = True

      Dim csWithdrawQty As New TreeTextColumn
      csWithdrawQty.MappingName = "WithdrawQty"
      csWithdrawQty.HeaderText = "เบิกแล้ว"
      csWithdrawQty.DataAlignment = HorizontalAlignment.Right
      csWithdrawQty.NullText = ""
      csWithdrawQty.Width = 90
      csWithdrawQty.ReadOnly = True

      Dim csRemainingQty As New TreeTextColumn
      csRemainingQty.MappingName = "RemainingQty"
      csRemainingQty.HeaderText = "เบิกได้"
      csRemainingQty.DataAlignment = HorizontalAlignment.Right
      csRemainingQty.NullText = ""
      csRemainingQty.Width = 90
      csRemainingQty.ReadOnly = True

      dst.GridColumnStyles.Add(csSelected)
      dst.GridColumnStyles.Add(csDescription)
      dst.GridColumnStyles.Add(csUnit)
      dst.GridColumnStyles.Add(csQty)
      dst.GridColumnStyles.Add(csRentRate)
      'dst.GridColumnStyles.Add(csWithdrawQty)
      'dst.GridColumnStyles.Add(csRemainingQty)
      Return dst
    End Function
#End Region

#Region "Event Handlers"
    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Me.SearchData("")
    End Sub
#End Region

#Region "ISimpleListPanel"
    Public Event EntitySelected(ByVal e As ISimpleEntity) Implements ISimpleListPanel.EntitySelected
    Public Sub OnEntitySelected(ByVal e As ISimpleEntity)
      RaiseEvent EntitySelected(e)
    End Sub
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
        Me.m_entity = Value
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
    Public Sub AddNew() Implements ISimpleListPanel.AddNew

    End Sub
    Public Sub RefreshData(ByVal id As String) Implements ISimpleListPanel.RefreshData
      SearchData("")
    End Sub
    Public Property SelectedEntity() As BusinessLogic.ISimpleEntity Implements ISimpleListPanel.SelectedEntity
      Get
        'Return m_selectedEntity
      End Get
      Set(ByVal Value As BusinessLogic.ISimpleEntity)
        'If CType(m_selectedEntity, Object).Equals(Value) Then
        '    Return
        'End If
        'Me.m_selectedEntity = Value
        'If Not m_selectedEntity Is Nothing Then
        '    Me.RefreshData(m_selectedEntity.Id.ToString)
        'End If
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
        Return "รายการ"
      End Get
    End Property
    Public Overrides Sub Deselected()
      If Not Me.WorkbenchWindow.SubViewContents Is Nothing Then
        'If Not m_selectedEntity Is Nothing Then
        '    AddHandler m_selectedEntity.TabPageTextChanged, AddressOf Me.ChangeTitle
        'End If
        'CType(Me.WorkbenchWindow.SubViewContents(1), ISimpleEntityPanel).Entity = m_selectedEntity
      End If
    End Sub
    Public Overrides Sub Selected()
      Me.RefreshData(Me.SelectedEntity.Id.ToString)
      Me.TitleName = Me.StringParserService.Parse(m_entity.ListPanelTitle)
    End Sub
#End Region

#Region "IBasketCollectable"
    Private dlg As BasketDialog
    Public Overrides ReadOnly Property BasketItems() As BusinessLogic.BasketItemCollection
      Get
        m_basketItems.Clear()
        Dim myTable As TreeTable = CType(tgItem.DataSource, TreeTable)
        For Each row As TreeRow In myTable.Childs
          For Each childRow As TreeRow In row.Childs
            If Not IsDBNull(childRow("Selected")) Then
              If CBool(childRow("Selected")) Then
                Dim id As Integer
                Dim EwCode As String = CStr(childRow("Code"))
                Dim fullClassName As String = "Longkong.Pojjaman.BusinessLogic.EquipmentToolWithdrawItem"
                Dim entityName As String = CStr(childRow("EquipmentTool"))
                Dim lineNumber As Integer = CInt(childRow("LineNumber"))
                Dim sequence As Integer = CInt(childRow("sequence"))

                Dim qty As Decimal = CDec(childRow("Qty"))

                Dim textInBasket As String = entityName & ":" & qty.ToString
                If TypeOf childRow.Tag Is DataRow Then
                  Dim ewi As EquipmentToolWithdrawItem = New EquipmentToolWithdrawItem(CType(childRow.Tag, DataRow), "")
                  Dim theEw As EquipmentToolWithdraw = ewi.EquipmentToolWithdraw
                  'pri = New EquipmentToolWithdrawItem(pri.EqtWithdraw.Id, pri.LineNumber)
                  'ewi.EquipmentToolWithdraw = theEw
                  id = theEw.Id
                  Dim bi As New EqtBasketItem(id, EwCode, fullClassName, textInBasket, lineNumber, qty, entityName, 1)
                  bi.Tag = ewi
                  m_basketItems.Add(bi)
                End If
              End If
            End If
          Next
        Next
        Return m_basketItems
      End Get
    End Property
    Public Overrides ReadOnly Property ProposedBasketItems() As BusinessLogic.BasketItemCollection
      Get
        Return m_proposedBasketItems
      End Get
    End Property

#End Region

  End Class
End Namespace

