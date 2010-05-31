Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration
Imports System.Reflection
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.TextHelper
Imports Longkong.Pojjaman.Services
Namespace Longkong.Pojjaman.BusinessLogic
  Public Class MarkupStatus
    Inherits CodeDescription

#Region "Constructors"
    Public Sub New(ByVal value As Integer)
      MyBase.New(value)
    End Sub

    Public Sub New(ByVal ds As DataSet, ByVal aliasPrefix As String)
      MyBase.New(ds, aliasPrefix)
    End Sub

    Public Sub New(ByVal dr As DataRow, ByVal aliasPrefix As String)
      MyBase.New(dr, aliasPrefix)
    End Sub

#End Region

#Region "Properties"
    Public Overrides ReadOnly Property CodeName() As String
      Get
        Return "markup_status"
      End Get
    End Property
#End Region

  End Class
  Public Class CurrencyOrPercent
    Inherits CodeDescription

#Region "Constructors"
    Public Sub New(ByVal value As Integer)
      MyBase.New(value)
    End Sub

    Public Sub New(ByVal ds As DataSet, ByVal aliasPrefix As String)
      MyBase.New(ds, aliasPrefix)
    End Sub

    Public Sub New(ByVal dr As DataRow, ByVal aliasPrefix As String)
      MyBase.New(dr, aliasPrefix)
    End Sub

#End Region

#Region "Properties"
    Public Overrides ReadOnly Property CodeName() As String
      Get
        Return "CurrencyOrPercent"
      End Get
    End Property
#End Region

  End Class
  Public Class MarkupDistributionMethod
    Inherits CodeDescription

#Region "Constructors"
    Public Sub New(ByVal value As Integer)
      MyBase.New(value)
    End Sub

    Public Sub New(ByVal ds As DataSet, ByVal aliasPrefix As String)
      MyBase.New(ds, aliasPrefix)
    End Sub

    Public Sub New(ByVal dr As DataRow, ByVal aliasPrefix As String)
      MyBase.New(dr, aliasPrefix)
    End Sub

#End Region

#Region "Properties"
    Public Overrides ReadOnly Property CodeName() As String
      Get
        Return "markup_dmethod"
      End Get
    End Property
#End Region

  End Class
  Public Class MarkupCondition
    Inherits CodeDescription

#Region "Constructors"
    Public Sub New(ByVal value As Integer)
      MyBase.New(value)
    End Sub

    Public Sub New(ByVal ds As DataSet, ByVal aliasPrefix As String)
      MyBase.New(ds, aliasPrefix)
    End Sub

    Public Sub New(ByVal dr As DataRow, ByVal aliasPrefix As String)
      MyBase.New(dr, aliasPrefix)
    End Sub

#End Region

#Region "Properties"
    Public Overrides ReadOnly Property CodeName() As String
      Get
        Return "markup_condition"
      End Get
    End Property
#End Region

  End Class
  Public Class MarkupType
    Inherits CodeDescription

#Region "Constructors"
    Public Sub New(ByVal value As Integer)
      MyBase.New(value)
    End Sub
    Public Sub New(ByVal ds As DataSet, ByVal aliasPrefix As String)
      MyBase.New(ds, aliasPrefix)
    End Sub
    Public Sub New(ByVal dr As DataRow, ByVal aliasPrefix As String)
      MyBase.New(dr, aliasPrefix)
    End Sub
#End Region

#Region "Properties"
    Public Overrides ReadOnly Property CodeName() As String
      Get
        Return "markup_type"
      End Get
    End Property
    Public ReadOnly Property GroupId() As Integer
      Get
        Return CodeDescription.GetTag(Me.CodeName, Me.Value)
      End Get
    End Property
#End Region

  End Class
  Public Class Markup
    Inherits SimpleBusinessEntityBase
    Implements IDisposable

#Region "Members"
    Private m_boq As Boq
    Private m_name As String
    Private m_note As String
    Private m_condition As MarkupCondition
    Private m_conditionItems As MarkupConditionItemCollection
    Private m_type As MarkupType
    Private m_amount As Decimal
    Private m_distribuedAmount As Decimal
    Private m_unit As CurrencyOrPercent
    Private m_distributionMethod As MarkupDistributionMethod
    Private m_distributedItems As DistributedItemCollection
    Private m_status As MarkupStatus
    Private m_milestone As Milestone

    Private m_totalamount As Decimal
#End Region

#Region "Constructors"
    Public Sub New()
      MyBase.New()
      'm_conditionItems = New MarkupConditionItemCollection(Me)
      'm_distributedItems = New DistributedItemCollection(Me)
    End Sub
    Public Sub New(ByVal code As String)
      MyBase.New(code)
      'm_conditionItems = New MarkupConditionItemCollection(Me)
      'm_distributedItems = New DistributedItemCollection(Me)
    End Sub
    Public Sub New(ByVal id As Integer)
      MyBase.New(id)
      'm_conditionItems = New MarkupConditionItemCollection(Me)
      'm_distributedItems = New DistributedItemCollection(Me)
    End Sub
    Public Sub New(ByVal dr As System.Data.DataRow, ByVal aliasPrefix As String)
      Me.Construct(dr, aliasPrefix)
      'm_conditionItems = New MarkupConditionItemCollection(Me)
      'm_distributedItems = New DistributedItemCollection(Me)
    End Sub
    Public Sub New(ByVal dr As System.Data.DataRow, ByVal aliasPrefix As String, ByVal boq As Boq)
      Me.Construct(dr, aliasPrefix)
      Me.m_boq = boq
      'm_conditionItems = New MarkupConditionItemCollection(Me)
      'm_distributedItems = New DistributedItemCollection(Me)
    End Sub
    Protected Overloads Overrides Sub Construct()
      MyBase.Construct()
      With Me
        .m_type = New MarkupType(-1)
        .m_unit = New CurrencyOrPercent(0)
        .m_distributionMethod = New MarkupDistributionMethod(1)
        .m_condition = New MarkupCondition(0)
        .m_status = New MarkupStatus(-1)
        .m_milestone = New Milestone
      End With
    End Sub
    Private m_dr As DataRow
    Private m_aliasPrefix As String = ""
    Protected Overloads Overrides Sub Construct(ByVal dr As System.Data.DataRow, ByVal aliasPrefix As String)
      MyBase.Construct(dr, aliasPrefix)
      With Me
        'If dr.Table.Columns.Contains(aliasPrefix & "project_id") Then
        '    If Not dr.IsNull(aliasPrefix & "project_id") Then
        '        .m_boq = New Boq(dr, aliasPrefix & "")
        '    End If
        'Else
        '    If Not dr.IsNull(aliasPrefix & "boq_project") Then
        '        .m_boq = New Boq(CInt(dr(aliasPrefix & "boq_project")))
        '    End If
        'End If
        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_name") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_name") Then
          .m_name = CStr(dr(aliasPrefix & Me.Prefix & "_name"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_note") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_note") Then
          .m_note = CStr(dr(aliasPrefix & Me.Prefix & "_note"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_amt") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_amt") Then
          .m_amount = CDec(dr(aliasPrefix & Me.Prefix & "_amt"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_totalamt") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_totalamt") Then
          .m_totalamount = CDec(dr(aliasPrefix & Me.Prefix & "_totalamt"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_distributedamt") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_distributedamt") Then
          .m_distribuedAmount = CDec(dr(aliasPrefix & Me.Prefix & "_distributedamt"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_unit") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_unit") Then
          .m_unit = New CurrencyOrPercent(CInt(dr(aliasPrefix & Me.Prefix & "_unit")))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_condition") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_condition") Then
          .m_condition = New MarkupCondition(CInt(dr(aliasPrefix & Me.Prefix & "_condition")))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_dmethod") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_dmethod") Then
          .m_distributionMethod = New MarkupDistributionMethod(CInt(dr(aliasPrefix & Me.Prefix & "_dmethod")))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_type") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_type") Then
          .m_type = New MarkupType(CInt(dr(aliasPrefix & Me.Prefix & "_type")))
        End If
      End With
      m_dr = dr
      m_aliasPrefix = aliasPrefix
      'LoadMileStone()
    End Sub
    Public Sub LoadMileStone()
      If m_dr Is Nothing Then
        Return
      End If
      If m_dr.Table.Columns.Contains("milestone_id") Then
        If Not m_dr.IsNull("milestone_id") Then
          m_milestone = New Milestone(m_dr, "")
        End If
      Else
        If m_dr.Table.Columns.Contains(m_aliasPrefix & "wbs_milestone") AndAlso Not m_dr.IsNull(m_aliasPrefix & "wbs_milestone") Then
          m_milestone = New Milestone(CInt(m_dr(m_aliasPrefix & "wbs_milestone")))
        End If
      End If
    End Sub
    Protected Overloads Overrides Sub Construct(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
      Dim dr As DataRow = ds.Tables(0).Rows(0)
      Construct(dr, aliasPrefix)
    End Sub
#End Region

#Region "Methods"
    Public Sub PopulateCondition(ByVal dt As TreeTable)
      dt.Clear()
      Dim i As Integer = 0
      For Each myCndItem As MarkupConditionItem In Me.ConditionItems
        i += 1
        Dim tr As TreeRow = dt.Childs.Add
        tr("LineNumber") = i
        tr("Min") = Configuration.FormatToString(myCndItem.LowerBound, DigitConfig.Price)
        tr("Max") = Configuration.FormatToString(myCndItem.UpperBound, DigitConfig.Price)
        tr("Percent") = Configuration.FormatToString(myCndItem.Percent, DigitConfig.Price)
        tr.Tag = myCndItem
      Next
    End Sub
    Public Function GetActualMat(ByVal toDate As Date, ByVal view As Integer, Optional ByVal requestor As Integer = -99) As Decimal      Return WBS.GetAmountFromSproc("GetMatAmountForWBS", toDate, Me.Id, True, view, requestor)
    End Function
    Public Function GetActualEq(ByVal toDate As Date, ByVal view As Integer, Optional ByVal requestor As Integer = -99) As Decimal      Return WBS.GetAmountFromSproc("GetEqAmountForWBS", toDate, Me.Id, True, view, requestor)
    End Function
    Public Function GetActualLab(ByVal toDate As Date, ByVal view As Integer, Optional ByVal requestor As Integer = -99) As Decimal      Return WBS.GetAmountFromSproc("GetLabAmountForWBS", toDate, Me.Id, True, view, requestor)
    End Function
    Public Function GetActualTotal(ByVal toDate As Date, ByVal view As Integer, Optional ByVal requestor As Integer = -99) As Decimal      Return WBS.GetAmountFromSproc("GetTotalAmountForWBS", toDate, Me.Id, True, view, requestor)
    End Function
    Public Function GetActualDocTable(ByVal toDate As Date, ByVal view As Integer, Optional ByVal requestor As Integer = -99) As DataTable      Return WBS.GetTableFromSproc("GetDocsForWBS", toDate, Me.Id, True, view, requestor)
    End Function
    Public Function GetActualTotal(ByVal stock As ISimpleEntity, ByVal view As Integer, Optional ByVal requestor As Integer = -99) As Decimal      Return WBS.GetAmountFromSproc("GetTotalAmountForWbsWithoutThisStrock", Me.Id, True, view, stock.Id, requestor)
    End Function
    Public Function GetActualItemTable(ByVal toDate As Date, ByVal view As Integer, ByVal docId As Integer, ByVal requestor As Integer) As DataTable      Return WBS.GetTableFromSproc("GetItemsForMarkup", toDate, Me.Id, False, view, docId, requestor)
    End Function
#End Region

#Region "Properties"    Public Property DistributedItems() As DistributedItemCollection      Get        If m_distributedItems Is Nothing Then
          m_distributedItems = New DistributedItemCollection(Me)
        End If        Return m_distributedItems      End Get      Set(ByVal Value As DistributedItemCollection)        m_distributedItems = Value      End Set    End Property    Public Property ConditionItems() As MarkupConditionItemCollection      Get        If m_conditionItems Is Nothing Then          m_conditionItems = New MarkupConditionItemCollection(Me)
        End If        Return m_conditionItems      End Get      Set(ByVal Value As MarkupConditionItemCollection)        m_conditionItems = Value      End Set    End Property    Public Property Boq() As Boq      Get        Return m_boq      End Get      Set(ByVal Value As Boq)        m_boq = Value      End Set    End Property    Public Property Name() As String      Get        Return m_name      End Get      Set(ByVal Value As String)        m_name = Value      End Set    End Property    Public Property Note() As String      Get        Return m_note      End Get      Set(ByVal Value As String)        m_note = Value      End Set    End Property    Public Property Condition() As MarkupCondition      Get        Return m_condition      End Get      Set(ByVal Value As MarkupCondition)        m_condition = Value      End Set    End Property    Public Property Type() As MarkupType      Get        Return m_type      End Get      Set(ByVal Value As MarkupType)        m_type = Value      End Set    End Property    Public Property Amount() As Decimal      Get        Return m_amount      End Get      Set(ByVal Value As Decimal)        m_amount = Value      End Set    End Property    Public Property Unit() As CurrencyOrPercent      Get        Return m_unit      End Get      Set(ByVal Value As CurrencyOrPercent)        m_unit = Value      End Set    End Property    Public Overrides Property Status() As CodeDescription
      Get
        Return Me.m_status
      End Get
      Set(ByVal Value As CodeDescription)
        Me.m_status = CType(Value, MarkupStatus)
      End Set
    End Property    'ค่า Total ที่เก็บใน DB    Public ReadOnly Property StoredTotalAmount() As Decimal
      Get
        Return Me.m_totalamount
      End Get
    End Property    Public ReadOnly Property TotalAmount() As Decimal
      Get
        If Me.Condition.Value = 0 Then
          If Me.Unit.Value = 0 Then
            'เป็นเปอร์เซ็นต์ของ Direct cost
            Return (Me.Amount * Me.Boq.DirectCost) / 100
          Else
            'ระบุค่าตรงๆ
            Return Me.Amount
          End If
        End If
        Dim baseValue As Decimal = 0
        Select Case Me.Condition.Value
          Case 1 'ค่าของ
            baseValue = Me.Boq.MaterialCost
          Case 2 'ค่าแรง
            baseValue = Me.Boq.LaborCost
          Case 3 'ค่าเครื่องจักร
            baseValue = Me.Boq.EquipmentCost
          Case 4 'Direct Cost
            baseValue = Me.Boq.DirectCost
        End Select
        Dim percent As Decimal = m_conditionItems.GetPercent(baseValue)
        Return (percent * baseValue) / 100
      End Get
    End Property    Public Property DistributedAmount() As Decimal      Get        Return m_distribuedAmount      End Get      Set(ByVal Value As Decimal)        m_distribuedAmount = Value      End Set    End Property    Public ReadOnly Property RemainingAmount() As Decimal      Get
        Return TotalAmount - Me.DistributedAmount
      End Get
    End Property    Public Property DistributionMethod() As MarkupDistributionMethod      Get        Return m_distributionMethod      End Get      Set(ByVal Value As MarkupDistributionMethod)        m_distributionMethod = Value      End Set    End Property    Public Property Milestone() As Milestone      Get        Return m_milestone      End Get      Set(ByVal Value As Milestone)        m_milestone = Value      End Set    End Property    Public Overrides ReadOnly Property ClassName() As String
      Get
        Return "Markup"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.Markup.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.Markup"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.Markup"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.Markup.ListLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property Prefix() As String
      Get
        Return "markup"
      End Get
    End Property
    Public Overrides ReadOnly Property TabPageText() As String
      Get
        Dim tpt As String = Me.StringParserService.Parse(Me.DetailPanelTitle) & " (" & Me.Code & ")"
        If tpt.EndsWith("()") Then
          tpt.TrimEnd("()".ToCharArray)
        End If
        Return tpt
      End Get
    End Property
#End Region#Region "Overrides"    Public Overrides Function ToString() As String
      Dim nodeNote As String = ""
      If Not Me.Note Is Nothing AndAlso Me.Note.Length > 0 Then
        nodeNote = " (" & Me.Note & ")"
      End If
      If Me.Status.Value >= 3 Then
        nodeNote &= " <Ref>"
      End If
      Return Me.Name & nodeNote
    End Function
#End Region
#Region "IDisposable"
    Public Sub Dispose() Implements System.IDisposable.Dispose
      Dispose(True)
    End Sub
    Protected Overrides Sub Finalize()
      Dispose(False)
    End Sub
    Protected m_disposed As Boolean = False
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
      If m_disposed Then
        Return
      End If
      If disposing Then
        m_disposed = True
        Me.ConditionItems.Dispose()
        Me.DistributedItems.Dispose()
        GC.SuppressFinalize(Me)
      End If
      'Undone : clear all resource
      Me.m_boq = Nothing
    End Sub
#End Region

  End Class
  <Serializable(), DefaultMember("Item")> _
Public Class MarkupCollection
    Inherits CollectionBase
    Implements IDisposable

#Region "Members"
    Private m_boq As Boq
#End Region

#Region "Constructors"
    Public Sub New()
    End Sub
    Public Sub New(ByVal owner As Boq, ByVal ds As DataSet, ByVal aliasPrefix As String)
      Me.m_boq = owner
      If Me.m_boq.Originated Then
        Return
      End If
      For Each dr As DataRow In ds.Tables(1).Rows
        Dim item As New Markup(dr, aliasPrefix, owner)
        Me.Add(item)
      Next
    End Sub
    Public Sub New(ByVal owner As Boq, ByVal rows As DataRowCollection)
      Me.m_boq = owner
      For Each row As TreeRow In rows
        If row.Level = CType(row.Table, TreeTable).MaxLevel Then
          Dim item As New Markup(row, "", owner)
          Me.Add(item)
        End If
      Next
    End Sub
    Public Sub New(ByVal ownerId As Integer)
      Me.m_boq = New Boq
      Me.m_boq.Id = ownerId
      If Not Me.m_boq.Originated Then
        Return
      End If


      Dim sqlConString As String = RecentCompanies.CurrentCompany.SiteConnectionString


      Dim ds As DataSet = SqlHelper.ExecuteDataset(sqlConString _
      , CommandType.StoredProcedure _
      , "GetMarkups" _
      , New SqlParameter("@boq_id", Me.m_boq.Id) _
      )

      For Each row As DataRow In ds.Tables(0).Rows
        Dim item As New Markup(row, "", m_boq)
        Me.Add(item)
      Next
    End Sub
    Public Sub New(ByVal owner As Boq)
      Me.m_boq = owner
      If Not Me.m_boq.Originated Then
        Return
      End If


      Dim sqlConString As String = RecentCompanies.CurrentCompany.SiteConnectionString


      Dim ds As DataSet = SqlHelper.ExecuteDataset(sqlConString _
      , CommandType.StoredProcedure _
      , "GetMarkups" _
      , New SqlParameter("@boq_id", Me.m_boq.Id) _
      )

      For Each row As DataRow In ds.Tables(0).Rows
        Dim item As New Markup(row, "", owner)
        Me.Add(item)
      Next
    End Sub
#End Region

#Region "Properties"
    Public Property Boq() As Boq      Get        Return m_boq      End Get      Set(ByVal Value As Boq)        m_boq = Value      End Set    End Property    Default Public Property Item(ByVal index As Integer) As Markup
      Get
        Return CType(MyBase.List.Item(index), Markup)
      End Get
      Set(ByVal value As Markup)
        MyBase.List.Item(index) = value
      End Set
    End Property
#End Region

#Region "Class Methods"
    Public Function GetMarkupFromId(ByVal id As Integer) As Markup
      For Each mk As Markup In Me
        If mk.Id = id Then
          Return mk
        End If
      Next
    End Function
    Public Sub Populate(ByVal tvMarkup As TreeView)
      tvMarkup.Nodes.Clear()
      Dim currentGroupNode As New TreeNode("")
      Dim currentNode As TreeNode
      For Each mu As Markup In Me
        If mu.Type.Description <> currentGroupNode.Text Then
          currentGroupNode = tvMarkup.Nodes.Add(mu.Type.Description)
          currentGroupNode.Tag = mu.Type.Value
        End If
        currentNode = currentGroupNode.Nodes.Add(mu.ToString)
        currentNode.Tag = mu
      Next
    End Sub
    Public Sub PopulateAll(ByVal tvMarkup As TreeView, Optional ByVal clearNodes As Boolean = True)
      If clearNodes Then
        tvMarkup.Nodes.Clear()
      End If
      Dim typeTable As DataTable = CodeDescription.GetCodeList("markup_type")
      Dim currentGroupNode As New TreeNode("")
      Dim currentNode As TreeNode
      For Each row As DataRow In typeTable.Rows
        If row("code_description").ToString <> currentGroupNode.Text Then
          currentGroupNode = tvMarkup.Nodes.Add(row("code_description").ToString)
          currentGroupNode.Tag = row("code_value")
        End If
        For Each mu As Markup In Me
          If mu.Type.Description = currentGroupNode.Text Then
            currentNode = currentGroupNode.Nodes.Add(mu.ToString)
            currentNode.Tag = mu
          End If
        Next
      Next
    End Sub
    Public Sub PopulateAll(ByVal n As TreeNode, Optional ByVal excludeProfit As Boolean = False, Optional ByVal showMilestone As Boolean = False)
      Dim serv As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
      Dim typeTable As DataTable = CodeDescription.GetCodeList("markup_type")
      Dim currentGroupNode As New TreeNode("")
      Dim currentNode As TreeNode
      Dim parentNode As TreeNode = n.Nodes.Add(serv.Parse("${res:Global.OverheadTH}"))
      Dim drs As DataRow()
      If excludeProfit Then
        drs = typeTable.Select("code_tag<>1")
      Else
        drs = typeTable.Select
      End If
      For Each row As DataRow In drs
        If row("code_description").ToString <> currentGroupNode.Text Then
          currentGroupNode = parentNode.Nodes.Add(row("code_description").ToString)
          currentGroupNode.Tag = row("code_value")
        End If
        For Each mu As Markup In Me
          If Not excludeProfit OrElse mu.Type.GroupId <> 1 Then
            If mu.Type.Description = currentGroupNode.Text Then
              Dim nodeText As String = mu.ToString
              If showMilestone Then
                nodeText &= ":" & mu.Milestone.ToString
              End If
              currentNode = currentGroupNode.Nodes.Add(nodeText)
              currentNode.Tag = mu
            End If
          End If
        Next
      Next
    End Sub
    Public Function GetActualAmountForType(ByVal typeId As Integer, ByVal toDate As Date, ByVal view As Integer, ByVal requestor As Integer) As Decimal
      Dim amt As Decimal = 0
      For Each mu As Markup In Me
        If mu.Type.Value = typeId Then
          amt += mu.GetActualTotal(toDate, view, requestor)
        End If
      Next
      Return amt
    End Function
    Public Function GetAmountForType(ByVal typeId As Integer) As Decimal
      Dim amt As Decimal = 0
      For Each mu As Markup In Me
        If mu.Type.Value = typeId Then
          amt += mu.TotalAmount
        End If
      Next
      Return amt
    End Function
    Public Function GetDistributedAmountForType(ByVal typeId As Integer) As Decimal
      Dim amt As Decimal = 0
      For Each mu As Markup In Me
        If mu.Type.Value = typeId Then
          amt += mu.DistributedAmount
        End If
      Next
      Return amt
    End Function
    Public Function GetUnDistributedAmountForType(ByVal typeId As Integer) As Decimal
      Dim amt As Decimal = 0
      For Each mu As Markup In Me
        If mu.Type.Value = typeId Then
          amt += mu.TotalAmount - mu.DistributedAmount
        End If
      Next
      Return amt
    End Function
    Public Function GetAmount() As Decimal
      Dim amt As Decimal = 0
      For Each mu As Markup In Me
        amt += mu.TotalAmount
      Next
      Return amt
    End Function
    Public Function GetProfit() As Decimal
      Dim amt As Decimal = 0
      For Each mu As Markup In Me
        If mu.Type.GroupId = 1 Then
          amt += mu.TotalAmount
        End If
      Next
      Return amt
    End Function
    Public Function GetDistributedProfit() As Decimal
      Dim amt As Decimal = 0
      For Each mu As Markup In Me
        If mu.Type.GroupId = 1 Then
          amt += mu.DistributedAmount
        End If
      Next
      Return amt
    End Function
    Public Function GetUndistributedProfit() As Decimal
      Dim amt As Decimal = 0
      For Each mu As Markup In Me
        If mu.Type.GroupId = 1 Then
          amt += mu.TotalAmount - mu.DistributedAmount
        End If
      Next
      Return amt
    End Function
    Public Function GetOverhead() As Decimal
      Dim amt As Decimal = 0
      For Each mu As Markup In Me
        If mu.Type.GroupId = 0 Then
          amt += mu.TotalAmount
        End If
      Next
      Return amt
    End Function
    Public Function GetDistributedOverhead() As Decimal
      Dim amt As Decimal = 0
      For Each mu As Markup In Me
        If mu.Type.GroupId = 0 Then
          amt += mu.DistributedAmount
        End If
      Next
      Return amt
    End Function
    Public Function GetUndistributedOverhead() As Decimal
      Dim amt As Decimal = 0
      For Each mu As Markup In Me
        If mu.Type.GroupId = 0 Then
          amt += mu.TotalAmount - mu.DistributedAmount
        End If
      Next
      Return amt
    End Function
    Public Function GetMaterialAdj() As Decimal
      Dim amt As Decimal = 0
      For Each mu As Markup In Me
        If mu.DistributionMethod.Value = 1 Then
          amt += mu.DistributedAmount
        End If
      Next
      Return amt
    End Function
    Public Function GetLaborAdj() As Decimal
      Dim amt As Decimal = 0
      For Each mu As Markup In Me
        If mu.DistributionMethod.Value = 2 Then
          amt += mu.DistributedAmount
        End If
      Next
      Return amt
    End Function
    Public Function GetEquipmentAdj() As Decimal
      Dim amt As Decimal = 0
      For Each mu As Markup In Me
        If mu.DistributionMethod.Value = 3 Then
          amt += mu.DistributedAmount
        End If
      Next
      Return amt
    End Function
    Public Function GetDirectCostAdj() As Decimal
      Dim amt As Decimal = 0
      For Each mu As Markup In Me
        If mu.DistributionMethod.Value = 4 Then
          amt += mu.DistributedAmount
        End If
      Next
      Return amt
    End Function
#End Region

#Region "Collection Methods"
    Public Function Add(ByVal value As Markup) As Integer
      value.Boq = Me.m_boq
      Return MyBase.List.Add(value)
    End Function
    Public Sub AddRange(ByVal value As MarkupCollection)
      For i As Integer = 0 To value.Count - 1
        value(i).Boq = Me.m_boq
        Me.Add(value(i))
      Next
    End Sub
    Public Sub AddRange(ByVal value As Markup())
      For i As Integer = 0 To value.Length - 1
        value(i).Boq = Me.m_boq
        Me.Add(value(i))
      Next
    End Sub
    Public Function Contains(ByVal value As Markup) As Boolean
      Return MyBase.List.Contains(value)
    End Function
    Public Sub CopyTo(ByVal array As Markup(), ByVal index As Integer)
      MyBase.List.CopyTo(array, index)
    End Sub
    Public Shadows Function GetEnumerator() As MarkupEnumerator
      Return New MarkupEnumerator(Me)
    End Function
    Public Function IndexOf(ByVal value As Markup) As Integer
      Return MyBase.List.IndexOf(value)
    End Function
    Public Sub Insert(ByVal index As Integer, ByVal value As Markup)
      value.Boq = Me.m_boq
      MyBase.List.Insert(index, value)
    End Sub
    Public Sub Remove(ByVal value As Markup)
      MyBase.List.Remove(value)
    End Sub
    Public Sub Remove(ByVal index As Integer)
      MyBase.List.RemoveAt(index)
    End Sub
#End Region

#Region "IDisposable"
    Public Sub Dispose() Implements System.IDisposable.Dispose
      Dispose(True)
    End Sub
    Protected Overrides Sub Finalize()
      Dispose(False)
    End Sub
    Protected m_disposed As Boolean = False
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
      If m_disposed Then
        Return
      End If
      If disposing Then
        For Each item As Markup In Me
          item.Dispose()
          item = Nothing
        Next
        m_disposed = True
        GC.SuppressFinalize(Me)
      End If
      'Undone : clear all resource
      Me.m_boq = Nothing
    End Sub
#End Region

    Public Class MarkupEnumerator
      Implements IEnumerator

#Region "Members"
      Private m_baseEnumerator As IEnumerator
      Private m_temp As IEnumerable
#End Region

#Region "Construtor"
      Public Sub New(ByVal mappings As MarkupCollection)
        Me.m_temp = mappings
        Me.m_baseEnumerator = Me.m_temp.GetEnumerator
      End Sub
#End Region

      Public ReadOnly Property Current() As Object Implements System.Collections.IEnumerator.Current
        Get
          Return CType(Me.m_baseEnumerator.Current, Markup)
        End Get
      End Property

      Public Function MoveNext() As Boolean Implements System.Collections.IEnumerator.MoveNext
        Return Me.m_baseEnumerator.MoveNext
      End Function

      Public Sub Reset() Implements System.Collections.IEnumerator.Reset
        Me.m_baseEnumerator.Reset()
      End Sub
    End Class

  End Class

  Public Class MarkupConditionItem
    Implements IDisposable

#Region "Members"
    Private m_lowerBound As Decimal
    Private m_upperBound As Decimal
    Private m_markup As Markup
    Private m_percent As Decimal
#End Region

#Region "Costructors"
    Public Sub New()
      MyBase.New()
    End Sub
    Public Sub New(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
      Me.Construct(ds, aliasPrefix)
    End Sub
    Public Sub New(ByVal dr As DataRow, ByVal aliasPrefix As String)
      Me.Construct(dr, aliasPrefix)
    End Sub
    Protected Sub Construct(ByVal dr As DataRow, ByVal aliasPrefix As String)
      With Me
        If dr.Table.Columns.Contains(aliasPrefix & "markupc_lowerBound") AndAlso Not dr.IsNull(aliasPrefix & "markupc_lowerBound") Then
          .m_lowerBound = CDec(dr(aliasPrefix & "markupc_lowerBound"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "markupc_upperBound") AndAlso Not dr.IsNull(aliasPrefix & "markupc_upperBound") Then
          .m_upperBound = CDec(dr(aliasPrefix & "markupc_upperBound"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "markupc_percent") AndAlso Not dr.IsNull(aliasPrefix & "markupc_percent") Then
          .m_percent = CDec(dr(aliasPrefix & "markupc_percent"))
        End If
      End With
    End Sub
    Protected Sub Construct(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
      Dim dr As DataRow = ds.Tables(0).Rows(0)
      Me.Construct(dr, aliasPrefix)
    End Sub
#End Region

#Region "Properties"
    Public Property LowerBound() As Decimal      Get        Return m_lowerBound      End Get      Set(ByVal Value As Decimal)        m_lowerBound = Value      End Set    End Property    Public Property UpperBound() As Decimal      Get        Return m_upperBound      End Get      Set(ByVal Value As Decimal)        m_upperBound = Value      End Set    End Property    Public Property Markup() As Markup      Get        Return m_markup      End Get      Set(ByVal Value As Markup)        m_markup = Value      End Set    End Property    Public Property Percent() As Decimal      Get        Return m_percent      End Get      Set(ByVal Value As Decimal)        m_percent = Value      End Set    End Property
#End Region

#Region "IDisposable"
    Public Sub Dispose() Implements System.IDisposable.Dispose
      Dispose(True)
    End Sub
    Protected Overrides Sub Finalize()
      Dispose(False)
    End Sub
    Protected m_disposed As Boolean = False
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
      If m_disposed Then
        Return
      End If
      If disposing Then
        m_disposed = True
        GC.SuppressFinalize(Me)
      End If
      'Undone : clear all resource
      Me.m_markup = Nothing
    End Sub
#End Region

  End Class
  <Serializable(), DefaultMember("Item")> _
Public Class MarkupConditionItemCollection
    Inherits CollectionBase
    Implements IDisposable

#Region "Members"
    Private m_markup As Markup
#End Region

#Region "Constructors"
    Public Sub New()
    End Sub
    Public Sub New(ByVal owner As Markup, ByVal ds As DataSet, ByVal aliasPrefix As String)
      Me.m_markup = owner
      If Me.m_markup.Originated Then
        Return
      End If
      For Each dr As DataRow In ds.Tables(1).Rows
        Dim item As New MarkupConditionItem(dr, aliasPrefix)
        item.Markup = owner
        Me.Add(item)
      Next
    End Sub
    Public Sub New(ByVal owner As Markup, ByVal rows As DataRowCollection)
      Me.m_markup = owner
      For Each row As TreeRow In rows
        If row.Level = CType(row.Table, TreeTable).MaxLevel Then
          Dim item As New MarkupConditionItem(row, "")
          item.Markup = owner
          Me.Add(item)
        End If
      Next
    End Sub
    Public Sub New(ByVal owner As Markup)
      Me.m_markup = owner
      If Not Me.m_markup.Originated Then
        Return
      End If


      Dim sqlConString As String = RecentCompanies.CurrentCompany.SiteConnectionString


      Dim ds As DataSet = SqlHelper.ExecuteDataset(sqlConString _
      , CommandType.StoredProcedure _
      , "GetMarkupConditionItems" _
      , New SqlParameter("@Markup_id", Me.m_markup.Id) _
      )

      For Each row As DataRow In ds.Tables(0).Rows
        Dim item As New MarkupConditionItem(row, "")
        item.Markup = m_markup
        Me.Add(item)
      Next
    End Sub
#End Region

#Region "Properties"
    Public Property Markup() As Markup      Get        Return m_markup      End Get      Set(ByVal Value As Markup)        m_markup = Value      End Set    End Property    Default Public Property Item(ByVal index As Integer) As MarkupConditionItem
      Get
        Return CType(MyBase.List.Item(index), MarkupConditionItem)
      End Get
      Set(ByVal value As MarkupConditionItem)
        MyBase.List.Item(index) = value
      End Set
    End Property
#End Region

#Region "Class Methods"
    Public Function GetPercent(ByVal value As Decimal) As Decimal
      For Each mci As MarkupConditionItem In Me
        If mci.LowerBound = 0 And value = 0 Then
          Return mci.Percent
        End If
        If mci.LowerBound < value AndAlso value <= mci.UpperBound Then
          Return mci.Percent
        End If
      Next
      Return 0
    End Function
#End Region

#Region "Collection Methods"
    Public Function Add(ByVal value As MarkupConditionItem) As Integer
      Return MyBase.List.Add(value)
    End Function
    Public Sub AddRange(ByVal value As MarkupConditionItemCollection)
      For i As Integer = 0 To value.Count - 1
        Me.Add(value(i))
      Next
    End Sub
    Public Sub AddRange(ByVal value As MarkupConditionItem())
      For i As Integer = 0 To value.Length - 1
        Me.Add(value(i))
      Next
    End Sub
    Public Function Contains(ByVal value As MarkupConditionItem) As Boolean
      Return MyBase.List.Contains(value)
    End Function
    Public Sub CopyTo(ByVal array As MarkupConditionItem(), ByVal index As Integer)
      MyBase.List.CopyTo(array, index)
    End Sub
    Public Shadows Function GetEnumerator() As MarkupConditionItemEnumerator
      Return New MarkupConditionItemEnumerator(Me)
    End Function
    Public Function IndexOf(ByVal value As MarkupConditionItem) As Integer
      Return MyBase.List.IndexOf(value)
    End Function
    Public Sub Insert(ByVal index As Integer, ByVal value As MarkupConditionItem)
      MyBase.List.Insert(index, value)
    End Sub
    Public Sub Remove(ByVal value As MarkupConditionItem)
      MyBase.List.Remove(value)
    End Sub
    Public Sub Remove(ByVal index As Integer)
      MyBase.List.RemoveAt(index)
    End Sub
#End Region

#Region "IDisposable"
    Public Sub Dispose() Implements System.IDisposable.Dispose
      Dispose(True)
    End Sub
    Protected Overrides Sub Finalize()
      Dispose(False)
    End Sub
    Protected m_disposed As Boolean = False
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
      If m_disposed Then
        Return
      End If
      If disposing Then
        m_disposed = True
        For Each item As MarkupConditionItem In Me
          item.Dispose()
          item = Nothing
        Next
        GC.SuppressFinalize(Me)
      End If
      'Undone : clear all resource
      Me.m_markup = Nothing
    End Sub
#End Region

    Public Class MarkupConditionItemEnumerator
      Implements IEnumerator

#Region "Members"
      Private m_baseEnumerator As IEnumerator
      Private m_temp As IEnumerable
#End Region

#Region "Construtor"
      Public Sub New(ByVal mappings As MarkupConditionItemCollection)
        Me.m_temp = mappings
        Me.m_baseEnumerator = Me.m_temp.GetEnumerator
      End Sub
#End Region

      Public ReadOnly Property Current() As Object Implements System.Collections.IEnumerator.Current
        Get
          Return CType(Me.m_baseEnumerator.Current, MarkupConditionItem)
        End Get
      End Property

      Public Function MoveNext() As Boolean Implements System.Collections.IEnumerator.MoveNext
        Return Me.m_baseEnumerator.MoveNext
      End Function

      Public Sub Reset() Implements System.Collections.IEnumerator.Reset
        Me.m_baseEnumerator.Reset()
      End Sub
    End Class

  End Class

  <Serializable(), DefaultMember("Item")> _
Public Class DistributedItemCollection
    Inherits CollectionBase
    Implements IDisposable

#Region "Members"
    Private m_markup As Markup
#End Region

#Region "Constructors"
    Public Sub New()
    End Sub
    Public Sub New(ByVal boq As BOQ, ByVal type As Integer)
      'Undone
      m_markup = New Markup
      m_markup.Boq = boq
      If Not boq.Originated Then
        Return
      End If
      Dim sqlConString As String = RecentCompanies.CurrentCompany.SiteConnectionString
      Dim ds As DataSet = SqlHelper.ExecuteDataset(sqlConString _
      , CommandType.StoredProcedure _
      , "GetBOQAdjDistributionItems" _
      , New SqlParameter("@boq_id", boq.Id) _
      , New SqlParameter("@type", type) _
      )

      For Each row As DataRow In ds.Tables(0).Rows
        'Dim item As New BoqItem(row, "")
        Dim item As BoqItem
        For Each bitem As BoqItem In m_markup.Boq.ItemCollection
          If bitem.LineNumber = CInt(row("boqi_linenumber")) Then
            item = bitem
            Exit For
          End If
        Next
        If Not item Is Nothing Then
          Me.Add(item)
        End If
      Next
    End Sub
    Public Sub New(ByVal markup As Markup)
      Me.m_markup = markup
      If Not Me.m_markup.Originated Then
        Return
      End If

      Dim sqlConString As String = RecentCompanies.CurrentCompany.SiteConnectionString
      Dim ds As DataSet = SqlHelper.ExecuteDataset(sqlConString _
      , CommandType.StoredProcedure _
      , "GetMarkupDistributionItems" _
      , New SqlParameter("@markup_id", markup.Id) _
      )

      For Each row As DataRow In ds.Tables(0).Rows
        Dim item As BoqItem
        If m_markup.Boq Is Nothing Then
          item = New BoqItem(row, "")
        Else
          For Each bitem As BoqItem In m_markup.Boq.ItemCollection
            If bitem.LineNumber = CInt(row("boqi_linenumber")) Then
              item = bitem
              Exit For
            End If
          Next
        End If
        If Not item Is Nothing Then
          Me.Add(item)
        End If
      Next
    End Sub
#End Region

#Region "Properties"
    Public Property Markup() As Markup      Get        Return m_markup      End Get      Set(ByVal Value As Markup)        m_markup = Value      End Set    End Property    Default Public Property Item(ByVal index As Integer) As BoqItem
      Get
        Return CType(MyBase.List.Item(index), BoqItem)
      End Get
      Set(ByVal value As BoqItem)
        MyBase.List.Item(index) = value
      End Set
    End Property
    Public ReadOnly Property MatetialCost() As Decimal      Get        Return m_matetialCost      End Get    End Property    Public ReadOnly Property LaborCost() As Decimal      Get        Return m_laborCost      End Get    End Property    Public ReadOnly Property EquipmentCost() As Decimal      Get        Return m_equipmentCost      End Get    End Property    Public ReadOnly Property DirectCost() As Decimal      Get        Return m_directCost      End Get    End Property#End Region

#Region "Class Methods"
    Private m_matetialCost As Decimal
    Private m_laborCost As Decimal
    Private m_equipmentCost As Decimal
    Private m_directCost As Decimal
    Public Sub UpdateCost()
      m_matetialCost = GetMatAmount()
      m_laborCost = GetLabAmount()
      m_equipmentCost = GetEqAmount()
      m_directCost = m_matetialCost + m_laborCost + m_equipmentCost
    End Sub
    Public Function GetMatAmount() As Decimal
      Dim amt As Decimal = 0
      For Each item As BoqItem In Me
        amt += item.TotalMaterialCost
      Next
      Return amt
    End Function
    Public Function GetLabAmount() As Decimal
      Dim amt As Decimal = 0
      For Each item As BoqItem In Me
        amt += item.TotalLaborCost
      Next
      Return amt
    End Function
    Public Function GetEqAmount() As Decimal
      Dim amt As Decimal = 0
      For Each item As BoqItem In Me
        amt += item.TotalEquipmentCost
      Next
      Return amt
    End Function
    Public Sub SetAdj(ByVal items As BoqItemCollection)
      If m_markup Is Nothing Then
        Return
      End If
      For Each myItem As BoqItem In Me
        Dim item As BoqItem = items.FindItemFromItem(myItem)
        If Not item Is Nothing Then
          Dim adj As Decimal = 0
          Dim isDC As Boolean = False
          Select Case m_markup.DistributionMethod.Value
            Case 1 'วัสดุ
              If Me.MatetialCost = 0 Then
              Else
                adj = ((item.TotalMaterialCost / Me.MatetialCost) * m_markup.DistributedAmount)
                item.MatAdjust += adj
              End If
            Case 2 'ค่าแรง
              If Me.LaborCost = 0 Then
              Else
                adj = ((item.TotalLaborCost / Me.LaborCost) * m_markup.DistributedAmount)
                item.LabAdjust += adj
              End If
            Case 3 'เครื่องจักร
              If Me.EquipmentCost = 0 Then
              Else
                adj = ((item.TotalEquipmentCost / Me.EquipmentCost) * m_markup.DistributedAmount)
                item.EqAdjust += adj
              End If
            Case 4 'รวม
              If Me.DirectCost = 0 Then
              Else
                adj = ((item.TotalCost / Me.DirectCost) * m_markup.DistributedAmount)
                item.DirectCostAdjust += adj
                isDC = True
              End If
          End Select
          '**********************DISTRIBUTING DIRECT COST******************************
          If isDC And adj <> 0 Then
            item.MatAdjust += ((item.TotalMaterialCost / item.TotalCost) * adj)
            item.LabAdjust += ((item.TotalLaborCost / item.TotalCost) * adj)
            item.EqAdjust += ((item.TotalEquipmentCost / item.TotalCost) * adj)
          End If
          'บวกกลับ
          item.DirectCostAdjust = item.MatAdjust + item.LabAdjust + item.EqAdjust
          '****************************************************************************
        End If
      Next
    End Sub
    Public Function GetCollectionForWBS(ByVal wbs As WBS) As BoqItemCollection
      Dim myCollection As New BoqItemCollection
      myCollection.Boq = Me.m_markup.Boq
      For Each item As BoqItem In Me
        If item.WBS Is wbs Then
          myCollection.Add(item)
        ElseIf wbs.Id <> 0 And wbs.Id = item.WBS.Id Then
          myCollection.Add(item)
        End If
      Next
      Return myCollection
    End Function
    Public Function GetNextItem(ByVal bitem As BoqItem) As BoqItem
      Dim index As Integer = Me.IndexOf(bitem)
      If index > Me.Count - 2 Or index < 0 Then
        Return Nothing
      End If
      Dim thisWbs As WBS = bitem.WBS
      For i As Integer = index To Me.Count - 1
        Dim nextWbs As WBS = Me(i).WBS
        If thisWbs Is nextWbs Then
          Return Me(i)
        ElseIf thisWbs.Id <> 0 And thisWbs.Id = nextWbs.Id Then
          Return Me(i)
        End If
      Next
      Return Nothing
    End Function
#End Region

#Region "Collection Methods"
    Public Function Add(ByVal value As BoqItem) As Integer
      If Not Me.Contains(value) Then
        value.BOQ = m_markup.Boq
        Return MyBase.List.Add(value)
      End If
    End Function
    Public Sub AddRange(ByVal value As BoqItemCollection)
      For i As Integer = 0 To value.Count - 1
        value(i).BOQ = m_markup.Boq
        Me.Add(value(i))
      Next
    End Sub
    Public Sub AddRange(ByVal value As BoqItem())
      For i As Integer = 0 To value.Length - 1
        value(i).BOQ = m_markup.Boq
        Me.Add(value(i))
      Next
    End Sub
    Public Function Contains(ByVal value As BoqItem) As Boolean
      For Each myItem As BoqItem In Me
        If myItem.LineNumber = value.LineNumber Then
          Return True
        End If
      Next
      Return MyBase.List.Contains(value)
    End Function
    Public Sub CopyTo(ByVal array As BoqItem(), ByVal index As Integer)
      MyBase.List.CopyTo(array, index)
    End Sub
    Public Shadows Function GetEnumerator() As BoqItemEnumerator
      Return New BoqItemEnumerator(Me)
    End Function
    Public Function IndexOf(ByVal value As BoqItem) As Integer
      Return MyBase.List.IndexOf(value)
    End Function
    Public Sub Insert(ByVal index As Integer, ByVal value As BoqItem)
      value.BOQ = m_markup.Boq
      MyBase.List.Insert(index, value)
    End Sub
    Public Sub Remove(ByVal value As BoqItem)
      Try
        MyBase.List.Remove(value)
      Catch ex As Exception

      End Try
    End Sub
    Public Sub Remove(ByVal value As BoqItemCollection)
      For i As Integer = 0 To value.Count - 1
        Me.Remove(value(i))
      Next
    End Sub
    Public Sub Remove(ByVal index As Integer)
      MyBase.List.RemoveAt(index)
    End Sub
#End Region

#Region "IDisposable"
    Public Sub Dispose() Implements System.IDisposable.Dispose
      Dispose(True)
    End Sub
    Protected Overrides Sub Finalize()
      Dispose(False)
    End Sub
    Protected m_disposed As Boolean = False
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
      If m_disposed Then
        Return
      End If
      If disposing Then
        For Each item As BoqItem In Me
          item.Dispose()
          item = Nothing
        Next
        m_disposed = True
        GC.SuppressFinalize(Me)
      End If
      'Undone : clear all resource
      Me.m_markup = Nothing
    End Sub
#End Region

    Public Class BoqItemEnumerator
      Implements IEnumerator

#Region "Members"
      Private m_baseEnumerator As IEnumerator
      Private m_temp As IEnumerable
#End Region

#Region "Construtor"
      Public Sub New(ByVal mappings As DistributedItemCollection)
        Me.m_temp = mappings
        Me.m_baseEnumerator = Me.m_temp.GetEnumerator
      End Sub
#End Region

      Public ReadOnly Property Current() As Object Implements System.Collections.IEnumerator.Current
        Get
          Return CType(Me.m_baseEnumerator.Current, BoqItem)
        End Get
      End Property

      Public Function MoveNext() As Boolean Implements System.Collections.IEnumerator.MoveNext
        Return Me.m_baseEnumerator.MoveNext
      End Function

      Public Sub Reset() Implements System.Collections.IEnumerator.Reset
        Me.m_baseEnumerator.Reset()
      End Sub
    End Class

  End Class

End Namespace

