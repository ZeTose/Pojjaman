Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Services
Imports System.Collections.Generic

Public Class MultiAllocateWBSForm



#Region "Member"
    Private m_treeManager As TreeManager
    Private m_ListMultiAllocate As List(Of MultiAllocate)
    Private m_isInitialized As Boolean = False
    Public SelectedCostcenter As CostCenter
#End Region

#Region "Construct"
    Public Sub New(ByVal mlallocate As List(Of MultiAllocate), ByVal setCostcenter As CostCenter)
        InitializeComponent()
        m_ListMultiAllocate = mlallocate

        Dim dtWBS As TreeTable = GetSchemaTable()
        Dim dstWBS As DataGridTableStyle = Me.CreateTableStyle()
        m_treeManager = New TreeManager(dtWBS, tgToCC)
        m_treeManager.SetTableStyle(dstWBS)
        m_treeManager.AllowSorting = False
        m_treeManager.AllowDelete = False
        SelectedCostcenter = setCostcenter
        m_isInitialized = False
        Me.RefreshDocs()
        m_isInitialized = True

        AddHandler dtWBS.ColumnChanging, AddressOf WBSTreetable_ColumnChanging
        AddHandler dtWBS.ColumnChanged, AddressOf WBSTreetable_ColumnChanged
        AddHandler dtWBS.RowDeleted, AddressOf WBSItemDelete
    End Sub
#End Region

#Region "Properties"
    Private ReadOnly Property CurrentItem() As MultiAllocate
        Get
            Dim row As TreeRow = Me.m_treeManager.SelectedRow
            If row Is Nothing Then
                Return Nothing
            End If
            If Not TypeOf row.Tag Is MultiAllocate Then
                row.Tag = New MultiAllocate
            End If
            Return CType(row.Tag, MultiAllocate)
        End Get
    End Property
    Public Sub WBStgButtonClicked(ByVal e As ButtonColumnEventArgs)
        If e.Column = 1 Then
            Me.CCButtonClicked(e)
        ElseIf e.Column = 3 Then
            Me.CBSButtonClicked(e)
        ElseIf e.Column = 5 Then
            Me.WBSButtonClicked(e)
        Else

        End If
    End Sub
#End Region

#Region "Method"
    Private m_hashWBS As Hashtable
    Private Sub RefreshDocs()
        Me.m_treeManager.Treetable.Clear()

        m_hashWBS = New Hashtable
        Dim key As String = ""
        Dim i As Integer = 0
        Dim foundblank As Boolean = False
        For Each ml As MultiAllocate In Me.m_ListMultiAllocate
            Dim wbsRow As TreeRow = Me.m_treeManager.Treetable.Childs.Add
            'wbsRow.FixLevel = -1
            wbsRow("Linenumber") = i
            wbsRow("Description") = ml.CostCenter.Code & " : " & ml.CostCenter.Name
            If ml.CBS Is Nothing Or ml.WBS Is Nothing Then
                foundblank = True
            Else
                wbsRow("CBS") = ml.CBS.Code & ":" & ml.CBS.Name
                wbsRow("WBS") = ml.WBS.Code & " : " & ml.WBS.Name
                key = ml.CostCenter.Id.ToString & ":" & ml.WBS.Id.ToString
                m_hashWBS(key) = ml
            End If
            wbsRow("Percent") = Configuration.FormatToString(ml.Percent, DigitConfig.Price)

            ml.LineNumber = i
            i += 1

            wbsRow.Tag = ml

        Next

        If 100 - Me.GetSumPercent > 0 Then

            If Not foundblank Then
                Dim row As TreeRow = Me.m_treeManager.Treetable.Childs.Add
                Dim doc As New MultiAllocate
                row("Linenumber") = i
                doc.LineNumber = i
                If Not SelectedCostcenter Is Nothing Then
                    doc.CostCenter = SelectedCostcenter
                    row("Description") = doc.CostCenter.Code & " : " & doc.CostCenter.Name

                End If


                row.Tag = doc
                Me.m_ListMultiAllocate.Add(doc)
            End If

        End If

        Me.m_treeManager.Treetable.AcceptChanges()

        SetSumPercent()

    End Sub

    Public Sub CCButtonClicked(ByVal e As ButtonColumnEventArgs)
        Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
        Dim entity As New CostCenter
        Dim entities As New ArrayList
        myEntityPanelService.OpenListDialog(entity, AddressOf SetCostCenter)
    End Sub
    Private Sub SetCostCenter(ByVal myEntity As ISimpleEntity)
        Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
        Dim row As TreeRow = Me.m_treeManager.SelectedRow
        Dim doc As New MultiAllocate
        If row.Tag Is Nothing Then
            row.Tag = doc
            Me.m_ListMultiAllocate.Add(doc)
        End If
        If TypeOf myEntity Is CostCenter Then
            Dim newCC As CostCenter = CType(myEntity, CostCenter)

            If newCC Is Nothing Then
                msgServ.ShowMessage("${res:Global.Error.SpecifyCC}")
                Return
            End If

            CType(row.Tag, MultiAllocate).CostCenter = CType(myEntity, CostCenter)
            If CType(row.Tag, MultiAllocate).CBS Is Nothing Then
                CType(row.Tag, MultiAllocate).CBS = New CBS
            End If
            CType(row.Tag, MultiAllocate).WBS = New WBS
            CType(row.Tag, MultiAllocate).Percent = 100 - GetSumPercent()
        End If

        m_isInitialized = False
        Me.RefreshDocs()
        m_isInitialized = True
    End Sub
    Public Sub CBSButtonClicked(ByVal c As ButtonColumnEventArgs)
        Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
        Dim entity As New CBS
        Dim entities As New ArrayList
        myEntityPanelService.OpenListDialog(entity, AddressOf SetCBS)
    End Sub
    Private Sub SetCBS(ByVal myEntity As ISimpleEntity)
        Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
        Dim row As TreeRow = Me.m_treeManager.SelectedRow
        Dim doc As New MultiAllocate
        If row.Tag Is Nothing Then
            row.Tag = doc
            Me.m_ListMultiAllocate.Add(doc)
        End If
        If TypeOf myEntity Is CBS Then
            Dim newCBS As CBS = CType(myEntity, CBS)

            If newCBS Is Nothing Then
                msgServ.ShowMessage("${res:Global.Error.SpecifyCBS}")
                Return
            End If

            If CType(row.Tag, MultiAllocate).CostCenter Is Nothing Then
                CType(row.Tag, MultiAllocate).CostCenter = New CostCenter
            End If
            CType(row.Tag, MultiAllocate).CBS = CType(myEntity, CBS)
            If CType(row.Tag, MultiAllocate).WBS Is Nothing Then
                CType(row.Tag, MultiAllocate).WBS = New WBS
            End If
            'CType(row.Tag, MultiAllocate).Percent = 100 - GetSumPercent()
        End If

        m_isInitialized = False
        Me.RefreshDocs()
        m_isInitialized = True
    End Sub

    Public Sub WBSButtonClicked(ByVal e As ButtonColumnEventArgs)
        Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)

        Dim row As TreeRow = Me.m_treeManager.SelectedRow
        If row.Tag Is Nothing Then
            msgServ.ShowMessageFormatted("${res:Global.Error.CCBefore}") '"${res:Global.Error.CCHasNotBOQ}", New String() {doc.CostCenter.Code & " : " & doc.CostCenter.Name})
            Return
        End If



        If Not TypeOf row.Tag Is MultiAllocate Then
            msgServ.ShowMessageFormatted("${res:Global.Error.CCBefore}") '"${res:Global.Error.CCHasNotBOQ}", New String() {doc.CostCenter.Code & " : " & doc.CostCenter.Name})
            Return
        End If

        Dim doc As MultiAllocate = CType(row.Tag, MultiAllocate)

        If doc Is Nothing Then
            msgServ.ShowMessageFormatted("${res:Global.Error.CCBefore}") '"${res:Global.Error.CCHasNotBOQ}", New String() {doc.CostCenter.Code & " : " & doc.CostCenter.Name})
            Return
        End If
        If doc.CostCenter.BoqId = 0 Then
            msgServ.ShowMessageFormatted("${res:Global.Error.CCHasNotBOQ}", New String() {doc.CostCenter.Code & " : " & doc.CostCenter.Name})
            Return
        End If
        'Dim doc As WBSDistribute = Me.CurrentWsbsd
        'If doc Is Nothing Then
        '  Return
        'End If
        '-----------------------------------------------------------*****
        'Dim myCostCenter As CostCenter = Nothing
        'If Me.RefDocAllocationType = AllocationType.AllocationFromOnly Then
        '  If Me.RefDoc.FromCostCenter Is Nothing Then
        '    Return
        '  End If
        '  myCostCenter = Me.RefDoc.FromCostCenter
        'ElseIf Me.RefDocAllocationType = AllocationType.AllocationToOnly Then
        '  If Me.RefDoc.ToCostCenter Is Nothing Then
        '    Return
        '  End If
        '  myCostCenter = Me.RefDoc.ToCostCenter
        'ElseIf Me.RefDocAllocationType = AllocationType.AllocationFromAndTo Then

        'End If
        'If Me.RefDoc.ToCostCenter.BoqId = 0 Then
        '  Return
        'End If
        'If doc.CostCenter.BoqId = 0 Then
        '  msgServ.ShowMessageFormatted("${res:Global.Error.CCHasNotBOQ}", New String() {doc.CostCenter.Code & " : " & doc.CostCenter.Name})
        '  Return
        'End If
        Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
        Dim entity As New WBS
        Dim filters() As Filter

        'Dim row As TreeRow = Me.m_wbsTreeManager.SelectedRow
        Dim rowIndex As Integer = row.Index
        Dim myBOQId As Integer = doc.CostCenter.BoqId

        Dim m_wbsColl As WBSCollection = Nothing
        Dim m_mrkColl As MarkupCollection = Nothing

        'If Not doc.CostCenter Is Nothing _
        '  AndAlso doc.CostCenter.BoqId > 0 Then
        '  myBOQId = doc.CostCenter.BoqId
        '  'MessageBox.Show("1" & myBOQId.ToString)
        'Else
        '  myBOQId = myCostCenter.BoqId
        '  doc.CostCenter = myCostCenter
        '  'MessageBox.Show("2 " & myBOQId.ToString)
        'End If
        If m_wbsColl Is Nothing OrElse m_wbsColl.Boq.Id <> myBOQId Then
            m_wbsColl = New WBSCollection(myBOQId)
        End If
        If m_mrkColl Is Nothing OrElse m_mrkColl.Boq.Id <> myBOQId Then
            m_mrkColl = New MarkupCollection(myBOQId)
        End If
        'If m_wbsColl Is Nothing OrElse m_wbsColl.Boq.Id <> Me.RefDoc.ToCostCenter.BoqId Then
        '    m_wbsColl = New WBSCollection(Me.RefDoc.ToCostCenter.BoqId)
        'End If
        'If m_mrkColl Is Nothing OrElse m_mrkColl.Boq.Id <> Me.RefDoc.ToCostCenter.BoqId Then
        '    m_mrkColl = New MarkupCollection(Me.RefDoc.ToCostCenter.BoqId)
        'End If
        filters = New Filter() {New Filter("mrkColl", m_mrkColl) _
                                , New Filter("wbsColl", m_wbsColl)}
        Dim entities As New ArrayList
        myEntityPanelService.OpenListDialog(entity, AddressOf SetWBS, filters, entities)

        entities.Add(entity)


    End Sub
    Private Sub SetWBS(ByVal myEntity As ISimpleEntity)
        Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
        Dim row As TreeRow = Me.m_treeManager.SelectedRow
        'Dim doc As New MultiAllocate
        If row.Tag Is Nothing Then
            'row.Tag = doc
            'Me.m_ListMultiAllocate.Add(doc)
            Return
        End If
        If TypeOf myEntity Is WBS Then
            Dim newWBS As WBS = CType(myEntity, WBS)

            If newWBS Is Nothing Then
                msgServ.ShowMessage("${res:Global.Error.SpecifyWBS}")
                Return
            End If
            Dim key As String = ""
            key = CType(row.Tag, MultiAllocate).CostCenter.Id.ToString & ":" & newWBS.Id.ToString
            If m_hashWBS.ContainsKey(key) Then
                msgServ.ShowMessageFormatted("WBS Code '" & newWBS.Code & "' " & "${res:Global.Error.Already}")
                'msgServ.ShowMessageFormatted("${res:Global.Error.WBSCodeNameMissMatch}", New String() {wbscode(0).Trim})
                Return
            End If

            'CType(row.Tag, MultiAllocate).CostCenter = CType(myEntity, CostCenter)
            If CType(row.Tag, MultiAllocate).CBS Is Nothing Then
                CType(row.Tag, MultiAllocate).CBS = New CBS
            End If
            CType(row.Tag, MultiAllocate).WBS = CType(myEntity, WBS)
            CType(row.Tag, MultiAllocate).Percent = 100 - GetSumPercent()
        End If

        m_isInitialized = False
        Me.RefreshDocs()
        m_isInitialized = True
    End Sub

    Private Sub SetSumPercent()
        Dim pc As Decimal = Me.GetSumPercent
        lblSumPercent.Text = ""
        If pc > 0 Then
            lblSumPercent.Text = Configuration.FormatToString(pc, DigitConfig.Price) & " %"
        End If

    End Sub
    Private Function GetSumPercent() As Decimal
        Dim pc As Decimal = 0
        For Each ml As MultiAllocate In Me.m_ListMultiAllocate
            If Not Me.CurrentItem.Equals(ml) Then
                pc += ml.Percent
            ElseIf ml.Percent > 0 Then
                pc += ml.Percent
            End If
        Next
        Return pc
    End Function

    'Private Function CheckDuplicateWBS(ByVal cc As CostCenter, ByVal wbs As WBS, ByVal row As TreeRow) As Boolean
    '  Dim rowIndex As Integer = -1
    '  If Not Not row.Tag Is Nothing Then
    '    rowIndex = CType(row.Tag, MultiAllocate).LineNumber
    '  End If
    '  For Each ml As MultiAllocate In Me.m_ListMultiAllocate
    '    If rowIndex <> ml.LineNumber Then

    '    End If
    '  Next
    'End Function
#End Region

#Region "Event Handler"
    Private Sub ibtnAddWBS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnAddWBS.Click
        Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)

        Dim row As TreeRow = Me.m_treeManager.SelectedRow
        If row Is Nothing Then
            Return
        End If

        If 100 - Me.GetSumPercent > 0 Then
            Me.m_treeManager.Treetable.Childs.InsertAt(row.Index + 1, row)

            Me.m_treeManager.Treetable.AcceptChanges()

            SetSumPercent()
        Else
            'msgServ.ShowMessage("${res:Global.Error.SpecifyCC}")
            msgServ.ShowMessage("ไม่อนุญาติให้จัดสรรเกิน 100 %")
            Return
        End If


        'If Me.m_entity Is Nothing Then
        '  Return
        'End If

        'Dim myCostCenter As CostCenter = Nothing
        'If Me.RefDocAllocationType = AllocationType.AllocationFromOnly Then
        '  If Me.RefDoc.FromCostCenter Is Nothing Then
        '    msgServ.ShowMessage("${res:Global.Error.SpecifyCC}")
        '    Return
        '  End If
        '  myCostCenter = Me.RefDoc.FromCostCenter
        'ElseIf Me.RefDocAllocationType = AllocationType.AllocationToOnly Then
        '  If Me.RefDoc.ToCostCenter Is Nothing Then
        '    msgServ.ShowMessage("${res:Global.Error.SpecifyCC}")
        '    Return
        '  End If
        '  myCostCenter = Me.RefDoc.ToCostCenter
        'ElseIf Me.RefDocAllocationType = AllocationType.AllocationFromAndTo Then
        '  myCostCenter = Me.RefDoc.ToCostCenter
        'End If
        ''If Me.RefDoc.ToCostCenter.BoqId = 0 Then
        ''  msgServ.ShowMessage("${res:Global.Error.SpecifyCCWithBOQ}")
        ''  Return
        ''End If
        'Dim doc As IWBSAllocatableItem = Me.CurrentItem
        'If doc Is Nothing Then
        '  Return
        'End If
        ''Dim dt As TreeTable = Me.m_wbsTreeManager.Treetable
        ''dt.Clear()
        ''Dim view As Integer = 7
        'Dim wsdColl As WBSDistributeCollection = doc.WBSDistributeCollection
        'If wsdColl.GetSumPercent >= 100 Then
        '  'msgServ.ShowMessage(wsdColl.GetSumPercent)
        '  msgServ.ShowMessage("${res:Global.Error.WBSPercentExceed100}")
        '  Return
        'ElseIf doc.AllocationErrorMessage.Length > 0 Then
        '  msgServ.ShowMessage(doc.AllocationErrorMessage)
        '  Return
        'Else
        '  Dim wbsd As New WBSDistribute
        '  wbsd.CostCenter = myCostCenter 'Me.RefDoc.ToCostCenter
        '  wbsd.Percent = 100 - wsdColl.GetSumPercent
        '  wsdColl.Add(wbsd)
        'End If
        'Dim flag As Boolean = m_isInitialized
        m_isInitialized = False
        Me.RefreshDocs()
        m_isInitialized = True
    End Sub
    Private Sub ibtnDelWBS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnDelWBS.Click
        'For Each obj As Object In Me.m_treeManager.SelectedRows
        '  If TypeOf obj Is TreeRow Then
        '    Dim row As TreeRow = CType(obj, TreeRow)
        '    If TypeOf row.Tag is  
        '    End If
        'Next

        'Dim row As TreeRow = Me.m_treeManager.SelectedRow
        'If row Is Nothing Then
        '  Return
        'End If

        Dim doc As MultiAllocate = Me.CurrentItem
        If doc Is Nothing Then
            Return
        End If
        If m_ListMultiAllocate.Contains(doc) Then
            m_ListMultiAllocate.Remove(doc)
        End If

        'Me.m_treeManager.Treetable.AcceptChanges()

        'SetSumPercent()

        'Dim dt As TreeTable = Me.m_wbsTreeManager.Treetable
        'dt.Clear()
        'Dim doc As WBSDistribute = Me.CurrentWsbsd
        'If doc Is Nothing Then
        '  Return
        'End If
        ''Dim doc As PRItem = Me.m_entity.ItemCollection.CurrentItem
        ''If doc Is Nothing Then
        ''    Return
        ''End If

        'If TypeOf m_entity Is IWBSAllocatable Then
        '  Dim al As IWBSAllocatable = CType(m_entity, IWBSAllocatable)
        '  'Dim dt As TreeTable = m_wbsTreeManager.Treetable
        '  'dt.Clear()
        '  For Each ali As IWBSAllocatableItem In al.GetWBSAllocatableItemCollection
        '    'Dim newRow As TreeRow = dt.Childs.Add()
        '    'newRow("ItemType") = ali.Type
        '    'newRow("Description") = ali.Description
        '    'newRow("ItemAmount") = Configuration.FormatToString(ali.ItemAmount, DigitConfig.Price)
        '    'newRow("CCButton") = "invisible"
        '    'newRow("Button") = "invisible"

        '    'newRow.Tag = ali
        '    If ali.WBSDistributeCollection.Contains(doc) Then
        '      ali.WBSDistributeCollection.Remove(doc)
        '      Me.WorkbenchWindow.ViewContent.IsDirty = True
        '    End If


        '    'For Each wbsd As WBSDistribute In ali.WBSDistributeCollection
        '    'Dim wbsRow As TreeRow = dt.Childs.Add()
        '    'wbsRow("CostCenter") = wbsd.CostCenter.Code & " : " & wbsd.CostCenter.Name
        '    'wbsRow("WBS") = wbsd.WBS.Code & " : " & wbsd.WBS.Name

        '    'wbsRow.Tag = wbsd

        '    'Next
        '  Next
        'End If

        ''Dim wsdColl As WBSDistributeCollection = doc.WBSDistributeCollection
        ''If wsdColl.Count > 0 Then
        ''    wsdColl.Remove(wsdColl.Count - 1)
        ''    Me.WorkbenchWindow.ViewContent.IsDirty = True
        ''End If
        ''Dim view As Integer = 7
        'Dim flag As Boolean = m_isInitialized
        m_isInitialized = False
        'wsdColl.Populate(dt, doc, View)
        Me.RefreshDocs()
        m_isInitialized = True
    End Sub
#End Region

#Region "Style"       'add แค่ header เท่านั้น
    Private Function GetSchemaTable() As TreeTable
        Dim myDatatable As New TreeTable("WBS")
        myDatatable.Columns.Add(New DataColumn("Linenumber", GetType(Integer)))
        myDatatable.Columns.Add(New DataColumn("Description", GetType(String)))
        myDatatable.Columns.Add(New DataColumn("CostCenter", GetType(String)))
        myDatatable.Columns.Add(New DataColumn("CCButton", GetType(String)))
        myDatatable.Columns.Add(New DataColumn("CBS", GetType(String)))
        myDatatable.Columns.Add(New DataColumn("CBSButton", GetType(String)))
        myDatatable.Columns.Add(New DataColumn("WBS", GetType(String)))
        myDatatable.Columns.Add(New DataColumn("Button", GetType(String)))
        myDatatable.Columns.Add(New DataColumn("Percent", GetType(String)))
        Return myDatatable
    End Function
    Private Function CreateTableStyle() As DataGridTableStyle
        Dim dst As New DataGridTableStyle
        dst.MappingName = "WBS"
        Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)

        Dim csDescription As New TreeTextColumn
        csDescription.MappingName = "Description"
        csDescription.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.scWBSView.DescriptionHeaderText}") '"รายการ/Cost Center"
        csDescription.NullText = ""
        csDescription.Width = 175
        csDescription.TextBox.Name = "Description"

        Dim csCCButton As New DataGridButtonColumn
        csCCButton.MappingName = "CCButton"
        csCCButton.HeaderText = ""
        csCCButton.NullText = ""

        Dim csCBS As New TreeTextColumn
        csCBS.MappingName = "CBS"
        csCBS.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.scWBSView.CBSHeaderText}") 'CBS
        csCBS.NullText = ""
        csCBS.Width = 0 '175
        csCBS.TextBox.Name = "CBS"

        Dim csCBSButton As New DataGridButtonColumn
        csCBSButton.MappingName = "CBSButton"
        csCBSButton.HeaderText = ""
        csCBSButton.NullText = ""
        csCBSButton.Width = 0

        Dim csWBS As New TreeTextColumn
        csWBS.MappingName = "WBS"
        csWBS.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.scWBSView.WBSHeaderText}") 'WBS
        csWBS.NullText = ""
        csWBS.Width = 175
        csWBS.TextBox.Name = "WBS"

        Dim csButton As New DataGridButtonColumn
        csButton.MappingName = "Button"
        csButton.HeaderText = ""
        csButton.NullText = ""
        AddHandler csButton.Click, AddressOf WBStgButtonClicked

        Dim csPercent As New TreeTextColumn
        csPercent.MappingName = "Percent"
        csPercent.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.scWBSView.PercentHeaderText}") '%
        csPercent.NullText = ""
        csPercent.DataAlignment = HorizontalAlignment.Right
        csPercent.Format = "#,###.##"
        csPercent.Width = 50
        csPercent.TextBox.Name = "Percent"

        dst.GridColumnStyles.Add(csDescription)
        dst.GridColumnStyles.Add(csCCButton)
        dst.GridColumnStyles.Add(csCBS)
        dst.GridColumnStyles.Add(csCBSButton)
        dst.GridColumnStyles.Add(csWBS)
        dst.GridColumnStyles.Add(csButton)
        dst.GridColumnStyles.Add(csPercent)

        Return dst
    End Function

#End Region

#Region "TreeTable Handler"
    Private Sub WBSTreetable_ColumnChanged(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs)
        If Not m_isInitialized Then
            Return
        End If
        'Dim index As Integer = Me.m_wbsTreeManager.Treetable.Childs.IndexOf(CType(e.Row, TreeRow))
        'If WBSValidateRow(CType(e.Row, TreeRow)) Then
        'UpdateAmount(e)
        'Me.m_wbsTreeManager.Treetable.AcceptChanges()
        'End If
        m_isInitialized = False
        Me.RefreshDocs()
        m_isInitialized = True
        'Me.WorkbenchWindow.ViewContent.IsDirty = True
    End Sub
    Private Sub WBSTreetable_ColumnChanging(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs)
        If Not m_isInitialized Then
            Return
        End If
        Try
            Select Case e.Column.ColumnName.ToLower
                Case "description"
                    SetCostCenterCode(e)
                Case "cbs"
                    SetCBSCode(e)
                Case "wbs"
                    SetWBSCode(e)
                Case "percent"
                    SetWBSPercent(e)
            End Select
            WBSValidateRow(e)
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
    Private Sub WBSItemDelete(ByVal sender As Object, ByVal e As System.Data.DataRowChangeEventArgs)

    End Sub
    Public Sub WBSValidateRow(ByVal e As DataColumnChangeEventArgs)
        Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
        Dim cc As Object = e.Row("description")
        Dim wbs As Object = e.Row("wbs")
        Dim percent As Object = e.Row("percent")
        'Dim amount As Object = e.Row("amount")

        Select Case e.Column.ColumnName.ToLower
            Case "description"
                cc = e.ProposedValue
            Case "wbs"
                wbs = e.ProposedValue
            Case "percent"
                percent = e.ProposedValue
                'Case "amount"
                '  amount = e.ProposedValue
            Case Else
                Return
        End Select

        Dim isBlankRow As Boolean = False
        If IsDBNull(wbs) Then
            isBlankRow = True
        End If

        If Not isBlankRow Then
            If IsDBNull(cc) OrElse cc.ToString.Length <= 0 Then
                e.Row.SetColumnError("description", myStringParserService.Parse("${res:Global.Error.CostCenterMissing}"))
            Else
                e.Row.SetColumnError("description", "")
            End If
            If IsDBNull(percent) OrElse CDec(percent) <= 0 Then
                e.Row.SetColumnError("percent", myStringParserService.Parse("${res:Global.Error.PercentMissing}"))
            Else
                e.Row.SetColumnError("percent", "")
            End If
            If IsDBNull(wbs) OrElse wbs.ToString.Replace(":", "").Length = 0 Then
                e.Row.SetColumnError("wbs", myStringParserService.Parse("${res:Global.Error.WBSMissing}"))
            Else
                e.Row.SetColumnError("wbs", "")
            End If
            'If IsDBNull(amount) OrElse CDec(amount) <= 0 Then
            '  e.Row.SetColumnError("amount", Me.StringParserService.Parse("${res:Global.Error.RealAmountMissing}"))
            'Else
            '  e.Row.SetColumnError("amount", "")
            'End If
        End If

    End Sub
    Public Function WBSValidateRow(ByVal row As TreeRow) As Boolean
        If row.IsNull("WBS") Then
            Return False
        End If
        Return True
    End Function
    Private m_wbsUpdating As Boolean = False
    Public Sub SetCostCenterCode(ByVal e As System.Data.DataColumnChangeEventArgs)
        If m_wbsUpdating Then
            Return
        End If
        'm_wbsUpdating = True
        Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)

        Dim row As TreeRow = Me.m_treeManager.SelectedRow
        Dim doc As New MultiAllocate
        If row.Tag Is Nothing Then
            row.Tag = doc
            Me.m_ListMultiAllocate.Add(doc)
        End If

        If Not IsDBNull(e.ProposedValue) OrElse e.ProposedValue.ToString.Length > 0 Then
            Dim cccodename As String = e.ProposedValue.ToString
            Dim cccode As String() = cccodename.Split(":"c)

            Dim cc As CostCenter = CostCenter.GetCostCenter(cccode(0).Trim)
            If cc Is Nothing Then
                msgServ.ShowMessageFormatted("${res:Global.Error.CostCenterCodeNameMissMatch}", New String() {cccode(0).Trim})
                Return
            End If

            CType(row.Tag, MultiAllocate).CostCenter = cc
            If CType(row.Tag, MultiAllocate).CBS Is Nothing Then
                CType(row.Tag, MultiAllocate).CBS = New CBS
            End If
            CType(row.Tag, MultiAllocate).WBS = New WBS
            CType(row.Tag, MultiAllocate).Percent = 100 - GetSumPercent()
        End If
    End Sub
    Public Sub SetCBSCode(ByVal e As System.Data.DataColumnChangeEventArgs)
        Dim myString As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
        Dim myMsg As MessageService = CType(ServiceManager.Services.GetService(GetType(MessageService)), MessageService)
        If m_wbsUpdating Then
            Return
        End If
        Dim isItem As Boolean = False
        'Dim wbsd As WBSDistribute = Me.CurrentWsbsd
        'Dim item As IWBSAllocatableItem = Me.CurrentItem
        'If wbsd Is Nothing AndAlso item Is Nothing Then
        '  Return
        'ElseIf Not item Is Nothing Then
        '  isItem = True
        'End If

        Dim row As TreeRow = Me.m_treeManager.SelectedRow
        Dim doc As New MultiAllocate
        If row.Tag Is Nothing Then
            row.Tag = doc
            Me.m_ListMultiAllocate.Add(doc)
        End If

        If IsDBNull(e.ProposedValue) OrElse e.ProposedValue.ToString.Length = 0 Then
            e.ProposedValue = ""
            Return
        End If

        Dim oldCodeValue As String = CStr(e.Row(e.Column))

        Dim value As String = SplitCodeCBS(CStr(e.ProposedValue))
        Dim myCBS As CBS = CBS.GetByCode(value)

        If myCBS Is Nothing OrElse myCBS.Id = 0 Then
            myMsg.ShowMessageFormatted(myString.Parse("${res:Longkong.Pojjaman.Gui.Panels.scWBSView.ValidCBS}"), New String() {value})
            e.ProposedValue = oldCodeValue
            Return
        End If

        m_wbsUpdating = True

        If CType(row.Tag, MultiAllocate).CostCenter Is Nothing Then
            CType(row.Tag, MultiAllocate).CostCenter = New CostCenter
        End If
        CType(row.Tag, MultiAllocate).CBS = myCBS
        If CType(row.Tag, MultiAllocate).WBS Is Nothing Then
            CType(row.Tag, MultiAllocate).WBS = New WBS
        End If

        m_wbsUpdating = False
    End Sub
    Public Sub SetWBSCode(ByVal e As System.Data.DataColumnChangeEventArgs)
        If m_wbsUpdating Then
            Return
        End If
        'm_wbsUpdating = True
        Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)

        Dim row As TreeRow = Me.m_treeManager.SelectedRow
        If row.Tag Is Nothing Then
            msgServ.ShowMessageFormatted("${res:Global.Error.CCBefore}") '"${res:Global.Error.CCHasNotBOQ}", New String() {doc.CostCenter.Code & " : " & doc.CostCenter.Name})
            Return
        End If
        If Not TypeOf row.Tag Is MultiAllocate Then
            msgServ.ShowMessageFormatted("${res:Global.Error.CCBefore}") '"${res:Global.Error.CCHasNotBOQ}", New String() {doc.CostCenter.Code & " : " & doc.CostCenter.Name})
            Return
        End If

        Dim doc As MultiAllocate = CType(row.Tag, MultiAllocate)

        If doc Is Nothing Then
            msgServ.ShowMessageFormatted("${res:Global.Error.CCBefore}") '"${res:Global.Error.CCHasNotBOQ}", New String() {doc.CostCenter.Code & " : " & doc.CostCenter.Name})
            Return
        End If
        If doc.CostCenter.BoqId = 0 Then
            msgServ.ShowMessageFormatted("${res:Global.Error.CCHasNotBOQ}", New String() {doc.CostCenter.Code & " : " & doc.CostCenter.Name})
            Return
        End If

        If Not IsDBNull(e.ProposedValue) OrElse e.ProposedValue.ToString.Length > 0 Then
            Dim wbscodename As String = e.ProposedValue.ToString
            Dim wbscode As String() = wbscodename.Split(":"c)

            Dim wbs As WBS = wbs.GetWBS(wbscode(0).Trim, doc.CostCenter.Id)
            If wbs Is Nothing Then
                msgServ.ShowMessageFormatted("${res:Global.Error.WBSCodeNameMissMatch}", New String() {wbscode(0).Trim})
                Return
            End If
            Dim key As String = ""
            key = doc.CostCenter.Id.ToString & ":" & wbs.Id.ToString
            If m_hashWBS.ContainsKey(key) Then
                msgServ.ShowMessageFormatted("WBS Code '" & wbscode(0).Trim & "' " & "${res:Global.Error.Already}")
                'msgServ.ShowMessageFormatted("${res:Global.Error.WBSCodeNameMissMatch}", New String() {wbscode(0).Trim})
                Return
            End If

            If CType(row.Tag, MultiAllocate).CBS Is Nothing Then
                CType(row.Tag, MultiAllocate).CBS = New CBS
            End If
            CType(row.Tag, MultiAllocate).WBS = wbs
        End If
    End Sub
    Public Sub SetWBSPercent(ByVal e As DataColumnChangeEventArgs)
        Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
        If m_wbsUpdating Then
            Return
        End If
        Dim row As TreeRow = Me.m_treeManager.SelectedRow
        Dim doc As New MultiAllocate
        If row.Tag Is Nothing Then
            row.Tag = doc
            Me.m_ListMultiAllocate.Add(doc)
        End If

        If IsDBNull(e.ProposedValue) OrElse e.ProposedValue.ToString.Length = 0 Then
            e.ProposedValue = ""
            Return
        End If
        'e.ProposedValue = Configuration.FormatToString(CDec(TextParser.Evaluate(e.ProposedValue.ToString)), DigitConfig.Price)
        Dim oldvalue As Decimal = 0
        If Not e.Row.IsNull(e.Column) Then
            oldvalue = CDec(e.Row(e.Column))
        End If

        Dim value As Decimal = 0
        If Not IsNumeric(e.ProposedValue) Then
            e.ProposedValue = oldvalue
        End If

        value = CDec(e.ProposedValue)

        If value = 0 Then
            msgServ.ShowMessage("${res:Global.Error.PercentNotZero}")
            Return
        End If

        If (GetSumPercent()) - oldvalue + value > 100 Then
            msgServ.ShowMessage("${res:Global.Error.WBSPercentExceed100}")
            Return
        End If

        m_wbsUpdating = True
        CType(row.Tag, MultiAllocate).Percent = value
        m_wbsUpdating = False
    End Sub
    Private Function SplitCodeCBS(ByVal value As String) As String
        Dim spCodeName() As String
        spCodeName = value.Split(CChar(":"))
        If Not spCodeName Is Nothing AndAlso spCodeName(0).Length > 0 Then
            Return spCodeName(0)
        End If
        Return ""
    End Function
#End Region

End Class