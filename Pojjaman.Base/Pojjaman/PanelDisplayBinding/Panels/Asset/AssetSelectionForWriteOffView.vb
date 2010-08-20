Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.PanelDisplayBinding
Imports Longkong.Pojjaman.Gui
Imports Longkong.Pojjaman.Gui.Pads
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.DataAccessLayer
Namespace Longkong.Pojjaman.Gui.Panels
  Public Class AssetSelectionForWriteOffView
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
      'AssetSelectionForWriteOffView
      '
      Me.Controls.Add(Me.tgItem)
      Me.Controls.Add(Me.Splitter1)
      Me.Controls.Add(Me.pnlFilter)
      Me.Name = "AssetSelectionForWriteOffView"
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
      m_filterSubPanel = New AssetSelectionForWriteOffFilterSubPanel
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
        If CBool(row("haschilds")) Then
          Dim checkCount As Integer = -1
          For Each childRow As TreeRow In row.Childs
            If e.Row = row.Index Then
              'คลิกโดนแม่
              childRow("Selected") = row("Selected")
            End If
            If CBool(childRow("Selected")) Then
              checkCount += 1
            End If
          Next
          If checkCount + 1 = row.Childs.Count Then
            row("Selected") = True
          ElseIf checkCount = -1 Then
            row("Selected") = False
          Else
            row("Selected") = DBNull.Value
          End If
        Else
          If e.Row = row.Index Then
            'row("Selected") = True
            If CBool(row("Selected")) Then
              row("Selected") = True
            Else
              row("Selected") = False
            End If
          End If
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

      If TypeOf m_entity Is AssetSelectionForWriteOff Then
        Dim ds As DataSet = Nothing
        Dim procName As String = "Get" & m_entity.ClassName & "List"
        ds = AssetWriteOff.GetListDatatable(procName, newfilters)
        PopDataStyle(ds)
      End If

    End Sub

    'Private Sub PopDataStyle(ByVal ds As DataSet)
    '  Dim equipmentString As String = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetSelectionForWriteOffView.EquipmentItem}")
    '  Dim toollotString As String = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetSelectionForWriteOffView.ToolLot}")
    '  Dim assetdt As DataTable = ds.Tables(0)
    '  Dim eqtdt As DataTable = ds.Tables(1)
    '  Dim dt As TreeTable = GetSchemaTable()
    '  dt.Clear()
    '  Dim parRow As TreeRow
    '  Dim currentAsset As Integer = -1
    '  Dim indent As String = Space(3)
    '  Dim itemString As New Hashtable
    '  itemString(342) = equipmentString
    '  itemString(348) = toollotString

    '  Dim parName As String = assetdt.TableName & "."
    '  For Each dc As DataColumn In assetdt.Columns
    '    If eqtdt.Columns.Contains(dc.ColumnName) Then
    '      dc.ColumnName = parName & dc.ColumnName
    '    End If
    '    eqtdt.Columns.Add(New DataColumn(dc.ColumnName))
    '  Next

    '  For Each AssetRow As DataRow In assetdt.Rows
    '    Dim drh As New DataRowHelper(AssetRow)
    '    Dim assetid As Integer = drh.GetValue(Of Integer)("asset_id")
    '    Dim assetCode As String = drh.GetValue(Of String)("asset_code")
    '    Dim assetName As String = drh.GetValue(Of String)("asset_name")
    '    'Dim Eqt As String = drh.GetValue(Of String)("eqtinfo")
    '    'Dim Unit As String = drh.GetValue(Of String)("unit_name")
    '    'Dim Qty As Decimal = drh.GetValue(Of Decimal)("eqtstocki_Qty")
    '    Dim BuyPrice As Decimal = drh.GetValue(Of Decimal)("asset_buyprice")
    '    Dim accdepre As Decimal = drh.GetValue(Of Decimal)("accdepre")
    '    Dim hasChilds As Boolean = drh.GetValue(Of Integer)("hasChilds") > 0
    '    'Dim LineNumber As Integer = drh.GetValue(Of Integer)("eqtstocki_linenumber")

    '    If currentAsset <> assetid Then
    '      parRow = dt.Childs.Add
    '      parRow("Selected") = False
    '      'parRow("TypeID") = drh.GetValue(Of Integer)("Type")
    '      parRow("Type") = drh.GetValue(Of String)("EntityType")
    '      parRow("Code") = assetCode
    '      parRow("name") = assetName
    '      parRow("Unit") = ""
    '      parRow("Qty") = ""
    '      parRow("BuyPrice") = Configuration.FormatToString(BuyPrice, DigitConfig.Price)
    '      'parRow("BuyCost") = ""
    '      parRow("AccDepre") = Configuration.FormatToString(accdepre, DigitConfig.Price)
    '      parRow("hasChilds") = hasChilds
    '      parRow("parent") = assetid
    '      parRow.CustomFontStyle = FontStyle.Bold
    '      parRow.Tag = AssetRow
    '      currentAsset = assetid
    '    End If

    '    For Each eqtrow As DataRow In eqtdt.Select("asset =" & currentAsset.ToString)
    '      Dim childRow As TreeRow = parRow.Childs.Add
    '      Dim drh2 As New DataRowHelper(eqtrow)
    '      childRow("Selected") = False
    '      'childRow("TypeID") = drh2.GetValue(Of Integer)("Type")
    '      childRow("Type") = indent & CType(itemString(drh2.GetValue(Of Integer)("Type")), String)
    '      childRow("Code") = indent & drh2.GetValue(Of String)("eqtcode")
    '      childRow("name") = indent & drh2.GetValue(Of String)("eqtname")
    '      childRow("Unit") = drh2.GetValue(Of String)("unit_name")
    '      childRow("Qty") = Configuration.FormatToString(drh2.GetValue(Of Integer)("remainQty"), DigitConfig.Price)
    '      'childRow("BuyPrice") = ""
    '      'childRow("BuyCost") = Configuration.FormatToString(drh2.GetValue(Of Decimal)("eqi_buycost"), DigitConfig.Price)
    '      childRow("BuyPrice") = Configuration.FormatToString(drh2.GetValue(Of Decimal)("eqi_buycost"), DigitConfig.Price)
    '      childRow("parent") = drh2.GetValue(Of Integer)("asset")

    '      Me.AddParentCollumnToChild(eqtrow, AssetRow)
    '      childRow.Tag = eqtrow
    '    Next
    '    'If Not parRow Is Nothing Then
    '    '  Dim childRow As TreeRow = parRow.Childs.Add
    '    '  childRow("Selected") = False
    '    '  childRow("Code") = ""
    '    '  childRow("EquipmentTool") = Eqt
    '    '  childRow("Unit") = Unit
    '    '  childRow("Qty") = Configuration.FormatToString(Qty, DigitConfig.Price)
    '    '  childRow("RentRate") = Configuration.FormatToString(RentalRate, DigitConfig.Price)
    '    '  childRow("Linenumber") = Configuration.FormatToString(LineNumber, DigitConfig.Int)
    '    '  'Dim eqtwitem As New EquipmentToolWithdrawItem
    '    '  'eqtwitem.EquipmentToolWithdraw = New EquipmentToolWithdraw
    '    '  'eqtwitem.EquipmentToolWithdraw.Id = eqtwid
    '    '  'eqtwitem.LineNumber = LineNumber
    '    '  childRow.Tag = AssetRow
    '    'End If
    '  Next

    '  'For Each eqtrow As DataRow In eqtdt.Select("asset = 0")
    '  '  Dim drh2 As New DataRowHelper(eqtrow)

    '  '  parRow = dt.Childs.Add
    '  '  parRow("Selected") = False
    '  '  parRow("Type") = drh2.GetValue(Of String)("EntityType")
    '  '  parRow("Code") = drh2.GetValue(Of String)("eqi_code")
    '  '  parRow("name") = drh2.GetValue(Of String)("eqi_name")
    '  '  parRow("Unit") = drh2.GetValue(Of String)("unit_name")
    '  '  parRow("Qty") = Configuration.FormatToString(drh2.GetValue(Of Integer)("remainQty"), DigitConfig.Price)
    '  '  parRow("BuyCost") = Configuration.FormatToString(drh2.GetValue(Of Decimal)("eqi_buycost"), DigitConfig.Price)
    '  '  parRow.CustomFontStyle = FontStyle.Bold
    '  '  parRow.Tag = eqtrow
    '  'Next

    '  dt.AcceptChanges()

    '  Dim dst As DataGridTableStyle = CreateListTableStyle2()
    '  m_treeManager = New TreeManager(dt, tgItem)
    '  m_treeManager.SetTableStyle(dst)
    '  m_treeManager.AllowSorting = False
    '  m_treeManager.AllowDelete = False
    'End Sub

    Private Class WQty
      Public Property Id As Integer
      Public Property typeId As Integer
      Public Property Qty As Integer

      Public Sub New(ByVal dr As DataRow)
        Dim drh As New DataRowHelper(dr)
        Id = drh.GetValue(Of Integer)("eqtstocki_entity")
        typeId = drh.GetValue(Of Integer)("eqtstocki_entityType")
        Qty = drh.GetValue(Of Integer)("wqty")
      End Sub

    End Class

    Private Sub PopDataStyle(ByVal ds As DataSet)
      Dim equipmentString As String = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetSelectionForWriteOffView.EquipmentItem}")
      Dim toollotString As String = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetSelectionForWriteOffView.ToolLot}")
      'Dim assetString As String = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.AssetSelectionForWriteOffView.Asset}")

      'Dim dt As DataTable = ds.Tables(0)
      'Dim eqtdt As DataTable = ds.Tables(1)

      Dim dt As TreeTable = GetSchemaTable()
      dt.Clear()

      Dim parRow As TreeRow
      Dim childRow As TreeRow
      Dim currentAsset As Integer = -1

      Dim indent As String = Space(3)

      Dim itemString As New Hashtable
      itemString(346) = equipmentString
      itemString(348) = toollotString
      'itemString(28) = assetString

      Dim assetHash As New Hashtable
      Dim key As Integer = 0
      'Dim oldAssetType As Integer = 0

      Dim HWqty As New Hashtable
      Dim dtWqty As DataTable = ds.Tables(1)

      For Each row As DataRow In dtWqty.Rows
        Dim drh As New DataRowHelper(row)
        HWqty(drh.GetValue(Of Integer)("eqtstocki_entity").ToString & ":" & drh.GetValue(Of Integer)("eqtstocki_entitytype").ToString) = New WQty(row)
      Next


      For Each row As DataRow In ds.Tables(0).Rows
        Dim drh As New DataRowHelper(row)
        key = drh.GetValue(Of Integer)("asset_id")

        If Not assetHash.Contains(key) Then
          parRow = dt.Childs.Add
          parRow.CustomFontStyle = FontStyle.Bold
          parRow.State = RowExpandState.Expanded

          parRow("Selected") = False
          parRow("Type") = drh.GetValue(Of String)("asset_entityType")
          parRow("Code") = drh.GetValue(Of String)("asset_code")
          parRow("name") = drh.GetValue(Of String)("asset_name")
          parRow("Unit") = ""
          parRow("Qty") = ""
          parRow("BuyPrice") = Configuration.FormatToString(drh.GetValue(Of Decimal)("asset_buyprice"), DigitConfig.Price)
          parRow("AccDepre") = Configuration.FormatToString(drh.GetValue(Of Decimal)("accdepre"), DigitConfig.Price)
          parRow("hasChilds") = drh.GetValue(Of Integer)("hasChilds") > 0
          parRow("parent") = drh.GetValue(Of Integer)("asset_id")
          'oldAssetType = drh.GetValue(Of Integer)("type")
          'row("type") = 28 '
          parRow.CustomFontStyle = FontStyle.Bold
          parRow.Tag = row

          assetHash(key) = parRow

          If drh.GetValue(Of Integer)("haschilds") > 0 Then
            childRow = parRow.Childs.Add
            childRow("Selected") = False
            childRow("Type") = indent & CType(itemString(drh.GetValue(Of Integer)("Type")), String)
            'oldAssetType = drh.GetValue(Of Integer)("type")
            'row("type") = oldAssetType '
            childRow("Code") = indent & drh.GetValue(Of String)("eqtcode")
            childRow("name") = indent & drh.GetValue(Of String)("eqtname")
            childRow("Unit") = drh.GetValue(Of String)("unit_name")
            Dim curWqty As WQty = CType(HWqty(drh.GetValue(Of Integer)("eqtid").ToString & ":" & drh.GetValue(Of Integer)("type").ToString), WQty)
            Dim qty As Integer = drh.GetValue(Of Integer)("remainQty")
            If curWqty IsNot Nothing Then
              If curWqty.Qty >= qty Then
                childRow("Qty") = Configuration.FormatToString(qty, DigitConfig.Price)
                curWqty.Qty = curWqty.Qty - qty
              Else
                childRow("Qty") = Configuration.FormatToString(curWqty.Qty, DigitConfig.Price)
                curWqty.Qty = 0
                row("remainQty") = curWqty.Qty
              End If
            Else
              childRow("Qty") = Configuration.FormatToString(qty, DigitConfig.Price)
            End If
            childRow("BuyPrice") = Configuration.FormatToString(drh.GetValue(Of Decimal)("eqi_buycost"), DigitConfig.Price)
            childRow("parent") = drh.GetValue(Of Integer)("asset")

            childRow.Tag = row
          End If

        Else
          parRow = CType(assetHash(key), TreeRow)
          Dim newRow As DataRow = CType(parRow.Tag, DataRow)
          Dim drh2 As New DataRowHelper(newRow)

          Trace.WriteLine(drh2.GetValue(Of Integer)("asset_id").ToString & ":" & drh.GetValue(Of Integer)("asset_id").ToString)

          If drh2.GetValue(Of Integer)("asset_id") = drh.GetValue(Of Integer)("asset_id") Then
            childRow = parRow.Childs.Add
            childRow("Selected") = False
            childRow("Type") = indent & CType(itemString(drh.GetValue(Of Integer)("Type")), String)
            'oldAssetType = drh.GetValue(Of Integer)("type")
            'row("type") = oldAssetType '
            childRow("Code") = indent & drh.GetValue(Of String)("eqtcode")
            childRow("name") = indent & drh.GetValue(Of String)("eqtname")
            childRow("Unit") = drh.GetValue(Of String)("unit_name")
            Dim curWqty As WQty = CType(HWqty(drh.GetValue(Of Integer)("eqtid").ToString & ":" & drh.GetValue(Of Integer)("type").ToString), WQty)
            Dim qty As Integer = drh.GetValue(Of Integer)("remainQty")
            If curWqty IsNot Nothing Then
              If curWqty.Qty >= qty Then
                childRow("Qty") = Configuration.FormatToString(qty, DigitConfig.Price)
                curWqty.Qty = curWqty.Qty - qty
              Else
                childRow("Qty") = Configuration.FormatToString(curWqty.Qty, DigitConfig.Price)
                curWqty.Qty = 0
                row("remainQty") = curWqty.Qty
              End If
            Else
              childRow("Qty") = Configuration.FormatToString(qty, DigitConfig.Price)
            End If
            childRow("BuyPrice") = Configuration.FormatToString(drh.GetValue(Of Decimal)("eqi_buycost"), DigitConfig.Price)
            childRow("parent") = drh.GetValue(Of Integer)("asset")

            childRow.Tag = row
          End If

          End If

          row("entityType") = CType(itemString(drh.GetValue(Of Integer)("Type")), String)
      Next

      'For Each AssetRow As DataRow In assetdt.Rows
      '  Dim drh As New DataRowHelper(AssetRow)
      '  Dim assetid As Integer = drh.GetValue(Of Integer)("asset_id")
      '  Dim assetCode As String = drh.GetValue(Of String)("asset_code")
      '  Dim assetName As String = drh.GetValue(Of String)("asset_name")
      '  'Dim Eqt As String = drh.GetValue(Of String)("eqtinfo")
      '  'Dim Unit As String = drh.GetValue(Of String)("unit_name")
      '  'Dim Qty As Decimal = drh.GetValue(Of Decimal)("eqtstocki_Qty")
      '  Dim BuyPrice As Decimal = drh.GetValue(Of Decimal)("asset_buyprice")
      '  Dim accdepre As Decimal = drh.GetValue(Of Decimal)("accdepre")
      '  Dim hasChilds As Boolean = drh.GetValue(Of Integer)("hasChilds") > 0
      '  'Dim LineNumber As Integer = drh.GetValue(Of Integer)("eqtstocki_linenumber")

      '  If currentAsset <> assetid Then
      '    parRow = dt.Childs.Add
      '    parRow("Selected") = False
      '    'parRow("TypeID") = drh.GetValue(Of Integer)("Type")
      '    parRow("Type") = drh.GetValue(Of String)("EntityType")
      '    parRow("Code") = assetCode
      '    parRow("name") = assetName
      '    parRow("Unit") = ""
      '    parRow("Qty") = ""
      '    parRow("BuyPrice") = Configuration.FormatToString(BuyPrice, DigitConfig.Price)
      '    'parRow("BuyCost") = ""
      '    parRow("AccDepre") = Configuration.FormatToString(accdepre, DigitConfig.Price)
      '    parRow("hasChilds") = hasChilds
      '    parRow("parent") = assetid
      '    parRow.CustomFontStyle = FontStyle.Bold
      '    parRow.Tag = AssetRow
      '    currentAsset = assetid
      '  End If

      '  For Each eqtrow As DataRow In eqtdt.Select("asset =" & currentAsset.ToString)
      '    Dim childRow As TreeRow = parRow.Childs.Add
      '    Dim drh2 As New DataRowHelper(eqtrow)
      '    childRow("Selected") = False
      '    'childRow("TypeID") = drh2.GetValue(Of Integer)("Type")
      '    childRow("Type") = indent & CType(itemString(drh2.GetValue(Of Integer)("Type")), String)
      '    childRow("Code") = indent & drh2.GetValue(Of String)("eqtcode")
      '    childRow("name") = indent & drh2.GetValue(Of String)("eqtname")
      '    childRow("Unit") = drh2.GetValue(Of String)("unit_name")
      '    childRow("Qty") = Configuration.FormatToString(drh2.GetValue(Of Integer)("remainQty"), DigitConfig.Price)
      '    'childRow("BuyPrice") = ""
      '    'childRow("BuyCost") = Configuration.FormatToString(drh2.GetValue(Of Decimal)("eqi_buycost"), DigitConfig.Price)
      '    childRow("BuyPrice") = Configuration.FormatToString(drh2.GetValue(Of Decimal)("eqi_buycost"), DigitConfig.Price)
      '    childRow("parent") = drh2.GetValue(Of Integer)("asset")

      '    Me.AddParentCollumnToChild(eqtrow, AssetRow)
      '    childRow.Tag = eqtrow
      '  Next
      '  'If Not parRow Is Nothing Then
      '  '  Dim childRow As TreeRow = parRow.Childs.Add
      '  '  childRow("Selected") = False
      '  '  childRow("Code") = ""
      '  '  childRow("EquipmentTool") = Eqt
      '  '  childRow("Unit") = Unit
      '  '  childRow("Qty") = Configuration.FormatToString(Qty, DigitConfig.Price)
      '  '  childRow("RentRate") = Configuration.FormatToString(RentalRate, DigitConfig.Price)
      '  '  childRow("Linenumber") = Configuration.FormatToString(LineNumber, DigitConfig.Int)
      '  '  'Dim eqtwitem As New EquipmentToolWithdrawItem
      '  '  'eqtwitem.EquipmentToolWithdraw = New EquipmentToolWithdraw
      '  '  'eqtwitem.EquipmentToolWithdraw.Id = eqtwid
      '  '  'eqtwitem.LineNumber = LineNumber
      '  '  childRow.Tag = AssetRow
      '  'End If
      'Next

      'For Each eqtrow As DataRow In eqtdt.Select("asset = 0")
      '  Dim drh2 As New DataRowHelper(eqtrow)

      '  parRow = dt.Childs.Add
      '  parRow("Selected") = False
      '  parRow("Type") = drh2.GetValue(Of String)("EntityType")
      '  parRow("Code") = drh2.GetValue(Of String)("eqi_code")
      '  parRow("name") = drh2.GetValue(Of String)("eqi_name")
      '  parRow("Unit") = drh2.GetValue(Of String)("unit_name")
      '  parRow("Qty") = Configuration.FormatToString(drh2.GetValue(Of Integer)("remainQty"), DigitConfig.Price)
      '  parRow("BuyCost") = Configuration.FormatToString(drh2.GetValue(Of Decimal)("eqi_buycost"), DigitConfig.Price)
      '  parRow.CustomFontStyle = FontStyle.Bold
      '  parRow.Tag = eqtrow
      'Next

      dt.AcceptChanges()

      Dim dst As DataGridTableStyle = CreateListTableStyle2()
      m_treeManager = New TreeManager(dt, tgItem)
      m_treeManager.SetTableStyle(dst)
      m_treeManager.AllowSorting = False
      m_treeManager.AllowDelete = False
    End Sub

    Public Shared Function GetSchemaTable() As TreeTable
      Dim myDatatable As New TreeTable("AsstItems")

      myDatatable.Columns.Add(New DataColumn("Selected", GetType(Boolean)))
      myDatatable.Columns.Add(New DataColumn("TypeID", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("Type", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Code", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Name", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Unit", GetType(String)))
      'myDatatable.Columns.Add(New DataColumn("CostCenter", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Qty", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("BuyPrice", GetType(String)))
      'myDatatable.Columns.Add(New DataColumn("BuyCost", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("AccDepre", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("hasChilds", GetType(Boolean)))
      myDatatable.Columns.Add(New DataColumn("parent", GetType(Integer)))
      'myDatatable.Columns.Add(New DataColumn("Linenumber", GetType(Integer)))
      'For Parent 
      'myDatatable.Columns.Add(New DataColumn("ParType", GetType(String)))
      'myDatatable.Columns.Add(New DataColumn("ParId", GetType(String)))
      'myDatatable.Columns.Add(New DataColumn("ParCode", GetType(String)))
      'myDatatable.Columns.Add(New DataColumn("AccDepre", GetType(String)))
      'myDatatable.Columns.Add(New DataColumn("AccDepre", GetType(String)))
      'myDatatable.Columns.Add(New DataColumn("AccDepre", GetType(String)))
      'myDatatable.Columns.Add(New DataColumn("AccDepre", GetType(String)))


      'parRow("Type") = drh.GetValue(Of String)("EntityType")
      'parRow("Code") = assetCode
      'parRow("name") = assetName
      'parRow("Unit") = ""
      'parRow("Qty") = ""
      'parRow("BuyPrice") = Configuration.FormatToString(BuyPrice, DigitConfig.Price)
      ''parRow("BuyCost") = ""
      'parRow("AccDepre") = Configuration.FormatToString(accdepre, DigitConfig.Price)
      'parRow("hasChilds") = hasChilds
      'parRow("parent") = assetid
      'parRow.CustomFontStyle = FontStyle.Bold
      'parRow.Tag = AssetRow
      'currentAsset = assetid

      Return myDatatable
    End Function
    Private Sub AddParentCollumnToChild(ByRef ChildDr As DataRow, ByVal ParDr As DataRow)
      For Each dc As DataColumn In ParDr.Table.Columns
        'If Not ChildDr.Table.Columns.Contains(dc.ColumnName) Then
        For Each dr As DataRow In ParDr.Table.Rows
          ChildDr(dc.ColumnName) = dr.Table.Columns(dc.ColumnName)
        Next
        'End If
      Next

      'Dim c(5) As DataColumn
      'c(0) = New DataColumn("asset_id")
      'c(0) = New DataColumn("asset_code")
      'c(0) = DataColumn("asset_name")
      'c(0) = DataColumn("asset_buyprice")
      'c(0) = DataColumn("accdepre")
      'c(0) = DataColumn("hasChilds")

      'dr.Table.Columns.Add(cid)

      'Dim assetid As Integer = drh.GetValue(Of Integer)("asset_id")
      'Dim assetCode As String = drh.GetValue(Of String)("asset_code")
      'Dim assetName As String = drh.GetValue(Of String)("asset_name")
      ''Dim Eqt As String = drh.GetValue(Of String)("eqtinfo")
      ''Dim Unit As String = drh.GetValue(Of String)("unit_name")
      ''Dim Qty As Decimal = drh.GetValue(Of Decimal)("eqtstocki_Qty")
      'Dim BuyPrice As Decimal = drh.GetValue(Of Decimal)("asset_buyprice")
      'Dim accdepre As Decimal = drh.GetValue(Of Decimal)("accdepre")
      'Dim hasChilds As Boolean = drh.GetValue(Of Integer)("hasChilds") > 0
    End Sub
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
      dst.MappingName = "AsstItems"

      Dim csSelected As New DataGridCheckBoxColumn
      csSelected.MappingName = "Selected"
      csSelected.HeaderText = ""
      AddHandler csSelected.Click, AddressOf RowIcon_Click

      Dim csType As New TreeTextColumn
      csType.MappingName = "Type"
      csType.HeaderText = "ชนิด"
      csType.NullText = ""
      csType.Width = 80
      csType.ReadOnly = True

      Dim csCode As New TreeTextColumn
      csCode.MappingName = "Code"
      csCode.HeaderText = "รหัส"
      csCode.NullText = ""
      csCode.Width = 80
      csCode.ReadOnly = True

      Dim csName As New TreeTextColumn
      csName.MappingName = "Name"
      csName.HeaderText = "รายการ"
      csName.NullText = ""
      csName.Width = 190
      csName.ReadOnly = True

      Dim csUnit As New TreeTextColumn
      csUnit.MappingName = "Unit"
      csUnit.HeaderText = "หน่วย"
      csUnit.NullText = ""
      csUnit.Width = 70
      csUnit.DataAlignment = HorizontalAlignment.Center
      csUnit.ReadOnly = True

      Dim csQty As New TreeTextColumn
      csQty.MappingName = "Qty"
      csQty.HeaderText = "ปริมาณ"
      csQty.DataAlignment = HorizontalAlignment.Right
      csQty.NullText = ""
      csQty.Width = 90
      csQty.ReadOnly = True

      Dim csBuyPrice As New TreeTextColumn
      csBuyPrice.MappingName = "BuyPrice"
      csBuyPrice.HeaderText = "ราคาซื้อ"
      csBuyPrice.DataAlignment = HorizontalAlignment.Right
      csBuyPrice.NullText = ""
      csBuyPrice.Width = 90
      csBuyPrice.ReadOnly = True

      'Dim csBuyCost As New TreeTextColumn
      'csBuyCost.MappingName = "BuyCost"
      'csBuyCost.HeaderText = "ราคาซื้อ"
      'csBuyCost.DataAlignment = HorizontalAlignment.Right
      'csBuyCost.NullText = ""
      'csBuyCost.Width = 90
      'csBuyCost.ReadOnly = True

      Dim csAccDepre As New TreeTextColumn
      csAccDepre.MappingName = "AccDepre"
      csAccDepre.HeaderText = "ค่าเสื่อมสะสม"
      csAccDepre.DataAlignment = HorizontalAlignment.Right
      csAccDepre.NullText = ""
      csAccDepre.Width = 90
      csAccDepre.ReadOnly = True

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
      dst.GridColumnStyles.Add(csType)
      dst.GridColumnStyles.Add(csCode)
      dst.GridColumnStyles.Add(csName)
      dst.GridColumnStyles.Add(csUnit)
      dst.GridColumnStyles.Add(csQty)
      dst.GridColumnStyles.Add(csBuyPrice)
      'dst.GridColumnStyles.Add(csBuyCost)
      dst.GridColumnStyles.Add(csAccDepre)
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

        'Dim EwCode As String
        'Dim fullClassName As String
        'Dim entityName As String
        'Dim lineNumber As Integer
        'Dim qty As Decimal = 0

        Dim id As Integer = 0
        Dim parId As Integer = 0
        Dim itemCode As String = ""
        Dim entityType As Integer
        Dim textInBasket As String = ""
        Dim lineNumber As Integer = 0

        'Dim listItem As New ArrayList
        'For Each row As TreeRow In myTable.Childs
        '  If Not IsDBNull(row("Selected")) Then
        '    If CBool(row("Selected")) Then
        '      If TypeOf row.Tag Is DataRow Then
        '        Dim dr As DataRow = CType(row.Tag, DataRow)
        '        Dim drh As New DataRowHelper(dr)

        '        If drh.GetValue(Of Integer)("type") = 28 Then
        '          For Each childrow As TreeRow In row.Childs
        '            'Dim dr2 As DataRow = 

        '            'EwCode = 
        '            'Dim fullClassName As String
        '            'Dim entityName As String
        '            'Dim lineNumber As Integer
        '            'Dim qty As Decimal = 0

        '            If Not IsDBNull(childrow("Selected")) Then
        '              If CBool(childrow("Selected")) Then

        '              End If
        '            End If


        '          Next
        '        End If

        '      End If
        '    End If
        '  End If
        'Next

        For Each row As TreeRow In myTable.Childs
          'Row แม่ ที่ไม่มีลูก
          If CBool(row("haschilds")) Then
            If Not IsDBNull(row("Selected")) Then
              If CBool(row("Selected")) Then

                Dim EwCode As String = CStr(row("Code"))
                Dim fullClassName As String = "Longkong.Pojjaman.BusinessLogic.AssetWriteOffItem"
                Dim entityName As String = CStr(row("Name"))
                'Dim lineNumber As Integer = CInt(childRow("LineNumber"))
                Dim qty As Decimal = 0
                If Not IsNumeric(CStr(row("Qty"))) Then
                  qty = 0
                Else
                  qty = CDec(row("Qty"))
                End If

                If TypeOf row.Tag Is DataRow Then
                  Dim drh As New DataRowHelper(CType(row.Tag, DataRow))
                  id = drh.GetValue(Of Integer)("Asset_id")
                  'id += 1
                  parId = id
                  entityType = drh.GetValue(Of Integer)("type")
                  itemCode = drh.GetValue(Of String)("eqtcode")
                  textInBasket = "(" & itemCode & ")" & entityName & ":" & qty.ToString
                  lineNumber = drh.GetValue(Of Integer)("linenumber")

                  Dim bi As New EqtBasketItem(id, EwCode, fullClassName, textInBasket, lineNumber, entityType, qty, entityName, 0, True)
                  bi.Tag = CType(row.Tag, DataRow)
                  m_basketItems.Add(bi)
                End If

                ' Row ลูกของแม่ ที่ select all
                For Each childRow As TreeRow In row.Childs
                  If Not IsDBNull(childRow("Selected")) Then
                    If CBool(childRow("Selected")) Then
                      Dim cEwCode As String = CStr(row("Code"))
                      Dim cfullClassName As String = "Longkong.Pojjaman.BusinessLogic.AssetWriteOffItem"
                      Dim centityName As String = CStr(childRow("Name"))
                      'Dim lineNumber As Integer = CInt(childRow("LineNumber"))

                      Dim cqty As Decimal = CDec(childRow("Qty"))


                      If TypeOf childRow.Tag Is DataRow Then
                        Dim drh As New DataRowHelper(CType(childRow.Tag, DataRow))
                        id = drh.GetValue(Of Integer)("eqtid")
                        'id += 1
                        entityType = drh.GetValue(Of Integer)("type")
                        itemCode = drh.GetValue(Of String)("eqtcode")
                        textInBasket = "(" & itemCode & ")" & centityName & ":" & cqty.ToString
                        lineNumber = drh.GetValue(Of Integer)("linenumber")

                        Dim bi As New EqtBasketItem(id, cEwCode, cfullClassName, textInBasket, lineNumber, entityType, cqty, centityName, 1, parId)
                        bi.Tag = CType(childRow.Tag, DataRow)
                        m_basketItems.Add(bi)
                      End If

                    End If
                  End If
                Next
              End If
            ElseIf IsDBNull(row("Selected")) Then
              Dim EwCode As String = CStr(row("Code"))
              Dim fullClassName As String = "Longkong.Pojjaman.BusinessLogic.AssetWriteOffItem"
              Dim entityName As String = CStr(row("Name"))
              'Dim lineNumber As Integer = CInt(childRow("LineNumber"))
              Dim qty As Decimal = 0
              If Not IsNumeric(CStr(row("Qty"))) Then
                qty = 0
              Else
                qty = CDec(row("Qty"))
              End If

              If TypeOf row.Tag Is DataRow Then
                Dim drh As New DataRowHelper(CType(row.Tag, DataRow))
                id = drh.GetValue(Of Integer)("Asset_id")
                'id += 1
                parId = id
                entityType = drh.GetValue(Of Integer)("type")
                itemCode = drh.GetValue(Of String)("eqtcode")
                textInBasket = "(" & itemCode & ")" & entityName & ":" & qty.ToString
                lineNumber = drh.GetValue(Of Integer)("linenumber")

                Dim bi As New EqtBasketItem(id, EwCode, fullClassName, textInBasket, lineNumber, entityType, qty, entityName, 0, True)
                bi.Tag = CType(row.Tag, DataRow)
                m_basketItems.Add(bi)
              End If

              ' Row ลูกของแม่ ที่ Selcted บางส่วน
              For Each childRow As TreeRow In row.Childs
                If Not IsDBNull(childRow("Selected")) Then
                  If CBool(childRow("Selected")) Then
                    Dim cEwCode As String = CStr(row("Code"))  'เอา code แม่
                    Dim cfullClassName As String = "Longkong.Pojjaman.BusinessLogic.AssetWriteOffItem"
                    Dim centityName As String = CStr(childRow("Name"))
                    'Dim lineNumber As Integer = CInt(childRow("LineNumber"))

                    Dim cqty As Decimal = CDec(childRow("Qty"))

                    'Dim ctextInBasket As String = "(" & EwCode & ")" & centityName & ":" & cqty.ToString
                    If TypeOf childRow.Tag Is DataRow Then
                      Dim drh As New DataRowHelper(CType(childRow.Tag, DataRow))
                      id = drh.GetValue(Of Integer)("eqtid")
                      'id += 1
                      Dim centityType As Integer = drh.GetValue(Of Integer)("type")
                      itemCode = drh.GetValue(Of String)("eqtcode")
                      textInBasket = "(" & itemCode & ")" & centityName & ":" & cqty.ToString
                      lineNumber = drh.GetValue(Of Integer)("linenumber")

                      Dim bi As New EqtBasketItem(id, cEwCode, cfullClassName, textInBasket, lineNumber, centityType, cqty, centityName, 1, parId)
                      bi.Tag = CType(childRow.Tag, DataRow)
                      m_basketItems.Add(bi)
                    End If
                  Else
                    Dim cEwCode As String = CStr(row("Code"))
                    Dim cfullClassName As String = "Longkong.Pojjaman.BusinessLogic.AssetWriteOffItem"
                    Dim centityName As String = CStr(childRow("Name"))
                    'Dim lineNumber As Integer = CInt(childRow("LineNumber"))

                    Dim cqty As Decimal = 0

                    'Dim ctextInBasket As String = "(" & EwCode & ")" & centityName & ":" & cqty.ToString
                    If TypeOf row.Tag Is DataRow Then
                      Dim drh As New DataRowHelper(CType(childRow.Tag, DataRow))
                      id = drh.GetValue(Of Integer)("Asset_id")
                      'id += 1
                      Dim centityType As Integer = drh.GetValue(Of Integer)("type")
                      itemCode = drh.GetValue(Of String)("eqtcode")
                      textInBasket = "(" & itemCode & ")" & centityName & ":" & cqty.ToString
                      lineNumber = drh.GetValue(Of Integer)("linenumber")

                      Dim bi As New EqtBasketItem(id, cEwCode, cfullClassName, textInBasket, lineNumber, centityType, cqty, centityName, 1, parId)
                      bi.Tag = CType(childRow.Tag, DataRow)
                      m_basketItems.Add(bi)
                    End If
                  End If
                End If
              Next

            End If

          Else
            'Row แม่ที่ไม่มีลูก
            If Not IsDBNull(row("Selected")) Then
              If CBool(row("Selected")) Then
                Dim EwCode As String = CStr(row("Code"))
                Dim fullClassName As String = "Longkong.Pojjaman.BusinessLogic.AssetWriteOffItem"
                Dim entityName As String = CStr(row("Name"))
                'Dim lineNumber As Integer = CInt(childRow("LineNumber"))

                Dim qty As Decimal = 0

                'Dim textInBasket As String = "(" & EwCode & ")" & entityName & ":" & qty.ToString
                If TypeOf row.Tag Is DataRow Then
                  Dim drh As New DataRowHelper(CType(row.Tag, DataRow))
                  id = drh.GetValue(Of Integer)("Asset_id")
                  'id += 1
                  entityType = drh.GetValue(Of Integer)("type")
                  itemCode = drh.GetValue(Of String)("eqtcode")
                  textInBasket = "(" & EwCode & ") " & entityName & ":" & qty.ToString
                  lineNumber = drh.GetValue(Of Integer)("linenumber")

                  Dim bi As New EqtBasketItem(id, EwCode, fullClassName, textInBasket, lineNumber, entityType, qty, entityName, 0, False)
                  bi.Tag = CType(row.Tag, DataRow)
                  m_basketItems.Add(bi)
                End If
              End If
            End If
          End If
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

