Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration
Imports System.Reflection
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.TextHelper
Imports System.Text.RegularExpressions
Namespace Longkong.Pojjaman.BusinessLogic
  Public Delegate Sub CountDelegate(ByVal i As Integer)
  Public Class BOQStatus
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
        Return "boq_status"
      End Get
    End Property
#End Region

  End Class

  Public Class BudgetType
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
        Return "BudgetType"
      End Get
    End Property
#End Region

  End Class

  Public Class BOQ
    Inherits SimpleBusinessEntityBase
    Implements IPrintableEntity, IDisposable, IDuplicable

#Region "Members"
    Private m_project As Project
    Private m_estimator As Employee
    Private m_status As BOQStatus

    Private m_materialMarkup As Decimal    Private m_laborMarkup As Decimal    Private m_equipmentMarkup As Decimal

    Private m_materialMarkupMethod As MarkupDistributionMethod    Private m_laborMarkupMethod As MarkupDistributionMethod    Private m_equipmentMarkupMethod As MarkupDistributionMethod

    Private m_markupCollection As MarkupCollection
    Private m_WBSCollection As WBSCollection
    Private m_itemCollection As BoqItemCollection

    Private m_materialMarkupItems As DistributedItemCollection    Private m_laborMarkupItems As DistributedItemCollection    Private m_equipmentMarkupItems As DistributedItemCollection

    Private m_itemTable As TreeTable
    Private m_lvfgs As ArrayList

    Private m_taxAmount As Decimal

    Private m_markupState As String

    Private m_totalBudgetFromDB As Decimal
    Private m_finalbidpriceFromDB As Decimal

#End Region

#Region "Constructors"
    Public Sub New()
      MyBase.New()
    End Sub
    Public Sub New(ByVal code As String)
      MyBase.New(code)
    End Sub
    Public Sub New(ByVal id As Integer)
      MyBase.New(id)
    End Sub
    Public Sub New(ByVal dr As System.Data.DataRow, ByVal aliasPrefix As String)
      Me.Construct(dr, aliasPrefix)
    End Sub
    Protected Overloads Overrides Sub Construct()
      MyBase.Construct()
      With Me
        .m_project = New Project
        .m_estimator = New Employee
        .m_status = New BOQStatus(-1)
        m_materialMarkupMethod = New MarkupDistributionMethod(1)        m_laborMarkupMethod = New MarkupDistributionMethod(2)        m_equipmentMarkupMethod = New MarkupDistributionMethod(3)

        m_WBSCollection = New WBSCollection(Me)
        m_itemCollection = New BoqItemCollection(Me)
        m_markupCollection = New MarkupCollection(Me)

        m_materialMarkupItems = New DistributedItemCollection(Me, 1)        m_laborMarkupItems = New DistributedItemCollection(Me, 2)        m_equipmentMarkupItems = New DistributedItemCollection(Me, 3)
        m_lvfgs = New ArrayList
      End With
    End Sub
    Protected Overloads Overrides Sub Construct(ByVal dr As System.Data.DataRow, ByVal aliasPrefix As String)
      MyBase.Construct(dr, aliasPrefix)
      With Me
        If dr.Table.Columns.Contains(aliasPrefix & "project_id") Then
          If Not dr.IsNull(aliasPrefix & "project_id") Then
            .m_project = New Project(dr, aliasPrefix & "")
          End If
        Else
          If Not dr.IsNull(aliasPrefix & "boq_project") Then
            .m_project = New Project(CInt(dr(aliasPrefix & "boq_project")))
          End If
        End If
        If dr.Table.Columns.Contains("employee_id") Then
          If Not dr.IsNull("employee_id") Then
            .m_estimator = New Employee(dr, "")
          End If
        Else
          If Not dr.IsNull(aliasPrefix & "boq_employee") Then
            .m_estimator = New Employee(CInt(dr(aliasPrefix & "boq_employee")))
          End If
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "boq_status") AndAlso Not dr.IsNull(aliasPrefix & "boq_status") Then
          .m_status = New BOQStatus(CInt(dr(aliasPrefix & "boq_status")))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "boq_materialMarkup") AndAlso Not dr.IsNull(aliasPrefix & "boq_materialMarkup") Then
          .m_materialMarkup = CDec(dr(aliasPrefix & "boq_materialMarkup"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "boq_laborMarkup") AndAlso Not dr.IsNull(aliasPrefix & "boq_laborMarkup") Then
          .m_laborMarkup = CDec(dr(aliasPrefix & "boq_laborMarkup"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "boq_equipmentMarkup") AndAlso Not dr.IsNull(aliasPrefix & "boq_equipmentMarkup") Then
          .m_equipmentMarkup = CDec(dr(aliasPrefix & "boq_equipmentMarkup"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "boq_taxamt") AndAlso Not dr.IsNull(aliasPrefix & "boq_taxamt") Then
          .m_taxAmount = CDec(dr(aliasPrefix & "boq_taxamt"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "boq_finalbidprice") AndAlso Not dr.IsNull(aliasPrefix & "boq_finalbidprice") Then
          .m_finalbidpriceFromDB = CDec(dr(aliasPrefix & "boq_finalbidprice"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "boq_totalBudget") AndAlso Not dr.IsNull(aliasPrefix & "boq_totalBudget") Then
          .m_totalBudgetFromDB = CDec(dr(aliasPrefix & "boq_totalBudget"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "boq_markupstate") AndAlso Not dr.IsNull(aliasPrefix & "boq_markupstate") Then
          .m_markupState = CStr(dr(aliasPrefix & "boq_markupstate"))
        End If
      End With

      m_WBSCollection = New WBSCollection(Me)
      m_itemCollection = New BoqItemCollection(Me)
      m_markupCollection = New MarkupCollection(Me)

      m_materialMarkupItems = New DistributedItemCollection(Me, 1)      m_laborMarkupItems = New DistributedItemCollection(Me, 2)      m_equipmentMarkupItems = New DistributedItemCollection(Me, 3)
    End Sub
    Protected Overloads Overrides Sub Construct(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
      Dim dr As DataRow = ds.Tables(0).Rows(0)
      Construct(dr, aliasPrefix)
    End Sub
    Private Lazy As Boolean = False
    Public Sub LazyConstruct(ByVal dr As System.Data.DataRow, ByVal aliasPrefix As String)
      With Me
        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_code") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_code") Then
          .Code = CStr(dr(aliasPrefix & Me.Prefix & "_code"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_id") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_id") Then
          .Id = CInt(dr(aliasPrefix & Me.Prefix & "_id"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "boq_finalbidprice") AndAlso Not dr.IsNull(aliasPrefix & "boq_finalbidprice") Then
          .m_finalbidpriceFromDB = CDec(dr(aliasPrefix & "boq_finalbidprice"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "boq_totalBudget") AndAlso Not dr.IsNull(aliasPrefix & "boq_totalBudget") Then
          .m_totalBudgetFromDB = CDec(dr(aliasPrefix & "boq_totalBudget"))
        End If
        Lazy = True
      End With
    End Sub
    Public Sub Import(ByVal dt As DataTable)
      Dim levelHash As New Hashtable
      Dim currLevel As Integer = 0
      Dim currWBS As WBS
      If Me.WBSCollection.Count = 0 Then
        currWBS = New WBS
        currWBS.Code = Me.Project.Code
        currWBS.Name = Me.Project.Name
        currWBS.Parent = currWBS
        currWBS.Level = 0
        levelHash(0) = currWBS
        Me.WBSCollection.Add(currWBS)
      Else
        currWBS = Me.WBSCollection.GetRoot
      End If
      For Each row As DataRow In dt.Rows
        If Not row.IsNull("Type") Then
          Select Case CStr(row("Type")).ToLower
            Case "wbs"
              If IsNumeric(row("Level")) Then
                Dim newLevel As Integer = CInt(row("Level"))
                Dim newWbs As WBS
                Dim canAdd As Boolean = True
                If newLevel = 0 Then 'มี root อีกอัน
                  newWbs = New WBS
                  newWbs.Parent = newWbs
                  newWbs.Level = 0
                ElseIf newLevel = currLevel + 1 Then 'เป็นลูกอันก่อน
                  newWbs = New WBS(currWBS)
                ElseIf newLevel = currLevel Then 'เป็นพี่น้อง
                  newWbs = New WBS(CType(currWBS.Parent, WBS))
                ElseIf newLevel < currLevel Then 'เป็นพี่น้อง
                  If Not levelHash(newLevel - 1) Is Nothing Then
                    Dim parent As WBS = CType(levelHash(newLevel - 1), WBS)
                    newWbs = New WBS(parent)
                  Else
                    canAdd = False
                  End If
                Else
                  canAdd = False
                End If
                If canAdd AndAlso Not newWbs Is Nothing Then
                  If Not row.IsNull("Code") Then
                    newWbs.Code = CStr(row("Code"))
                  End If
                  If Not row.IsNull("Description") Then
                    newWbs.Name = CStr(row("Description"))
                  End If
                  If Not row.IsNull("Note") Then
                    newWbs.Note = CStr(row("Note"))
                  End If

                  '------------------------TWC--------------------------
                  If Not row.IsNull(("Unit")) Then
                    newWbs.Unit = New Unit(CStr(row("Unit")))
                  Else
                    newWbs.Unit = New Unit
                  End If
                  If Not row.IsNull(("Qty")) Then
                    If CStr(row("Qty")).Length <> 0 Then
                      newWbs.Qty = CDec(row("Qty"))
                      'Else
                      '  newWbs.Qty = 0
                    End If
                  End If
                  '------------------------END TWC----------------------

                  currWBS = newWbs
                  currLevel = newLevel
                  levelHash(newLevel) = currWBS
                  Me.WBSCollection.Add(currWBS)
                End If
              End If

            Case "item"
              If Not currWBS Is Nothing Then
                Dim item As New BoqItem

                If Not row.IsNull(("Unit")) Then
                  item.Unit = New Unit(CStr(row("Unit")))
                Else
                  item.Unit = New Unit
                End If

                If Not row.IsNull(("EntityType")) Then
                  Dim entityType As Integer = 0
                  Select Case CStr(row("EntityType")).ToLower
                    Case "eq"
                      entityType = 20
                    Case "lab"
                      entityType = 18
                    Case "lci"
                      entityType = 42
                    Case "other"
                      entityType = 0
                  End Select
                  item.ItemType = New BOQItemType(entityType)
                  Select Case entityType
                    Case 0 'Blank
                      If Not row.IsNull(("Description")) Then
                        item.Entity = New BlankItem(row("Description").ToString)
                        item.EntityName = row("Description").ToString
                      Else
                        item.Entity = New BlankItem("")
                        item.EntityName = ""
                      End If
                    Case Else
                      If Not row.IsNull(("Code")) Then
                        item.Entity = CType(SimpleBusinessEntityBase.GetEntity(BusinessLogic.Entity.GetFullClassName(entityType), CStr(row("Code"))), IHasName)
                      End If
                      If Not row.IsNull(("Description")) Then
                        Dim suffix As String = "<" & item.Entity.Name & ">"
                        Dim s As String = row("Description").ToString
                        If s.EndsWith(suffix) Then
                          item.EntityName = s.Remove(s.Length - suffix.Length, suffix.Length)
                        End If
                      Else
                        item.EntityName = ""
                      End If
                      item.Conversion = 1
                      If Not item.Unit Is Nothing AndAlso item.Unit.Originated Then
                        If TypeOf item.Entity Is LCIItem Then
                          Dim lci As LCIItem = CType(item.Entity, LCIItem)
                          item.Conversion = lci.GetConversion(item.Unit)
                        Else
                          item.Conversion = 1
                        End If
                      End If
                  End Select
                End If

                If Not row.IsNull(("Qty")) Then
                  If CStr(row("Qty")).Length = 0 Then
                    item.Qty = 0
                  Else
                    item.Qty = CDec(row("Qty"))
                  End If
                End If
                If Not row.IsNull(("UMC")) Then
                  If CStr(row("UMC")).Length = 0 Then
                    item.UMC = 0
                  Else
                    item.UMC = CDec(row("UMC"))
                  End If
                End If
                If Not row.IsNull(("ULC")) Then
                  If CStr(row("ULC")).Length = 0 Then
                    item.ULC = 0
                  Else
                    item.ULC = CDec(row("ULC"))
                  End If
                End If
                If Not row.IsNull(("UEC")) Then
                  If CStr(row("UEC")).Length = 0 Then
                    item.UEC = 0
                  Else
                    item.UEC = CDec(row("UEC"))
                  End If
                End If

                If Not row.IsNull("Note") Then
                  item.Note = CStr(row("Note"))
                End If

                item.WBS = currWBS
                Me.ItemCollection.Add(item)
              End If
          End Select
        End If
      Next
    End Sub
#End Region

#Region "Properties"    Public Property MarkupState() As String      Get
        Return m_markupState
      End Get
      Set(ByVal Value As String)
        m_markupState = Value
      End Set
    End Property    Public Property TaxAmount() As Decimal
      Get
        Return m_taxAmount
      End Get
      Set(ByVal Value As Decimal)
        m_taxAmount = Value
      End Set
    End Property    Public ReadOnly Property LevelConfigs() As ArrayList
      Get
        Dim maxLevel As Integer = 0
        For Each myWbs As WBS In Me.WBSCollection
          maxLevel = Math.Max(maxLevel, myWbs.Level)
        Next
        If m_lvfgs.Count > maxLevel + 1 Then
          For i As Integer = maxLevel To m_lvfgs.Count - 1
            m_lvfgs.Remove(m_lvfgs(m_lvfgs.Count - 1))
          Next
        ElseIf m_lvfgs.Count < maxLevel + 1 Then
          For i As Integer = m_lvfgs.Count To maxLevel
            m_lvfgs.Add(New LevelConfig(i))
          Next
        End If
        Return m_lvfgs
      End Get
    End Property    Public Property ItemTable() As TreeTable      Get        Return m_itemTable      End Get      Set(ByVal Value As TreeTable)        m_itemTable = Value      End Set    End Property    Public Property Project() As Project      Get        Return m_project      End Get      Set(ByVal Value As Project)        m_project = Value        ChangeProject()      End Set    End Property    Private Sub ChangeProject()      If Me.WBSCollection.Count = 0 Then
        Dim newWbs As New WBS
        newWbs.Parent = newWbs
        newWbs.Code = Me.Project.Code
        newWbs.Name = Me.Project.Name
        newWbs.Note = "<Default>"
        Me.WBSCollection.Add(newWbs)
      Else
        Dim rootWbs As WBS = Me.WBSCollection.GetRoot
        If Not rootWbs Is Nothing Then
          rootWbs.Code = Me.Project.Code
          rootWbs.Name = Me.Project.Name
          rootWbs.Note = "<Default>"
        End If
      End If
    End Sub    Public Property Estimator() As Employee      Get        Return m_estimator      End Get      Set(ByVal Value As Employee)        m_estimator = Value      End Set    End Property    Public ReadOnly Property MaterialCost() As Decimal
      Get
        Dim amt As Decimal
        For Each item As BoqItem In Me.ItemCollection
          amt += item.TotalMaterialCost
        Next
        Return amt
      End Get
    End Property    Public ReadOnly Property LaborCost() As Decimal
      Get
        Dim amt As Decimal
        For Each item As BoqItem In Me.ItemCollection
          amt += item.TotalLaborCost
        Next
        Return amt
      End Get
    End Property    Public ReadOnly Property EquipmentCost() As Decimal
      Get
        Dim amt As Decimal
        For Each item As BoqItem In Me.ItemCollection
          amt += item.TotalEquipmentCost
        Next
        Return amt
      End Get
    End Property    Public ReadOnly Property DirectCost() As Decimal
      Get
        Return Me.MaterialCost + Me.LaborCost + Me.EquipmentCost
      End Get
    End Property    Public ReadOnly Property Profit() As Decimal
      Get
        Return Me.m_markupCollection.GetProfit
      End Get
    End Property    Public ReadOnly Property Overhead() As Decimal
      Get
        Return Me.m_markupCollection.GetOverhead
      End Get
    End Property    Public ReadOnly Property TotalAmount() As Decimal
      Get
        Return Me.DirectCost + Me.Profit + Me.Overhead
      End Get
    End Property    Public ReadOnly Property TotalBudget() As Decimal
      Get
        If Lazy Then
          Return Me.m_totalBudgetFromDB
        End If
        Return Me.DirectCost + Me.Overhead
      End Get
    End Property    Public Property MaterialMarkup() As Decimal
      Get
        Return m_materialMarkup
      End Get
      Set(ByVal Value As Decimal)
        m_materialMarkup = Value
      End Set
    End Property    Public Property MaterialMarkupItems() As DistributedItemCollection      Get        Return m_materialMarkupItems      End Get      Set(ByVal Value As DistributedItemCollection)        m_materialMarkupItems = Value      End Set    End Property    Public Property MaterialMarkupMethod() As MarkupDistributionMethod      Get
        Return m_materialMarkupMethod
      End Get
      Set(ByVal Value As MarkupDistributionMethod)
        m_materialMarkupMethod = Value
      End Set
    End Property    Public Function GetAdj(ByVal type As Integer) As Decimal
      Dim amt As Decimal = 0
      If MaterialMarkupMethod.Value = type Then
        amt += Me.MaterialMarkup
      End If
      If LaborMarkupMethod.Value = type Then
        amt += Me.LaborMarkup
      End If
      If EquipmentMarkupMethod.Value = type Then
        amt += Me.EquipmentMarkup
      End If
      Return amt
    End Function    Public ReadOnly Property MaterialAdj() As Decimal
      Get
        Return GetAdj(1)
      End Get
    End Property    Public Property LaborMarkup() As Decimal      Get
        Return m_laborMarkup
      End Get
      Set(ByVal Value As Decimal)
        m_laborMarkup = Value
      End Set
    End Property    Public Property LaborMarkupItems() As DistributedItemCollection      Get        Return m_laborMarkupItems      End Get      Set(ByVal Value As DistributedItemCollection)        m_laborMarkupItems = Value      End Set    End Property    Public Property LaborMarkupMethod() As MarkupDistributionMethod      Get
        Return m_laborMarkupMethod
      End Get
      Set(ByVal Value As MarkupDistributionMethod)
        m_laborMarkupMethod = Value
      End Set
    End Property    Public ReadOnly Property LaborAdj() As Decimal
      Get
        Return GetAdj(2)
      End Get
    End Property    Public Property EquipmentMarkup() As Decimal
      Get
        Return m_equipmentMarkup
      End Get
      Set(ByVal Value As Decimal)
        m_equipmentMarkup = Value
      End Set
    End Property    Public Property EquipmentMarkupItems() As DistributedItemCollection      Get        Return m_equipmentMarkupItems      End Get      Set(ByVal Value As DistributedItemCollection)        m_equipmentMarkupItems = Value      End Set    End Property    Public Property EquipmentMarkupMethod() As MarkupDistributionMethod      Get
        Return m_equipmentMarkupMethod
      End Get
      Set(ByVal Value As MarkupDistributionMethod)
        m_equipmentMarkupMethod = Value
      End Set
    End Property    Public ReadOnly Property EquipmentAdj() As Decimal
      Get
        Return GetAdj(3)
      End Get
    End Property    Public ReadOnly Property DirectCostMarkup() As Decimal
      Get
        Return Me.MaterialMarkup + Me.LaborMarkup + Me.EquipmentMarkup
      End Get
    End Property    Public ReadOnly Property DirectCostAdj() As Decimal
      Get
        Return GetAdj(4)
      End Get
    End Property    Public ReadOnly Property TargetMaterialCost() As Decimal
      Get
        Return Me.MaterialCost + Me.MaterialMarkup
      End Get
    End Property    Public ReadOnly Property TargetLaborCost() As Decimal
      Get
        Return Me.LaborCost + Me.LaborMarkup
      End Get
    End Property    Public ReadOnly Property TargetEquipmentCost() As Decimal      Get
        Return Me.EquipmentCost + Me.EquipmentMarkup
      End Get
    End Property    Public ReadOnly Property TargetDirectCost() As Decimal      Get
        Return Me.TargetMaterialCost + Me.TargetLaborCost + Me.TargetEquipmentCost
      End Get
    End Property    Public ReadOnly Property TargetBidPrice() As Decimal
      Get
        Return Me.TargetDirectCost + Me.Overhead + Me.Profit
      End Get
    End Property    Public ReadOnly Property FinalMaterialCost() As Decimal
      Get
        If Me.DirectCost = 0 Then
          Return 0
        End If
        Return Me.MaterialCost + Me.MaterialAdj + Me.MarkupCollection.GetMaterialAdj _
        + ((Me.MaterialCost / Me.DirectCost) * GetFinalDirectCostAdj())
      End Get
    End Property    Public ReadOnly Property FinalLaborCost() As Decimal
      Get
        If Me.DirectCost = 0 Then
          Return 0
        End If
        Return Me.LaborCost + Me.LaborAdj + Me.MarkupCollection.GetLaborAdj _
        + ((Me.LaborCost / Me.DirectCost) * GetFinalDirectCostAdj())
      End Get
    End Property    Public ReadOnly Property FinalEquipmentCost() As Decimal
      Get
        If Me.DirectCost = 0 Then
          Return 0
        End If
        Return Me.EquipmentCost + Me.EquipmentAdj + Me.MarkupCollection.GetEquipmentAdj _
        + ((Me.EquipmentCost / Me.DirectCost) * GetFinalDirectCostAdj())
      End Get
    End Property    Private Function GetFinalDirectCostAdj() As Decimal      Return Me.DirectCostAdj + Me.MarkupCollection.GetDirectCostAdj
    End Function    Public ReadOnly Property FinalDirectCost() As Decimal
      Get
        Return Me.FinalMaterialCost + Me.FinalLaborCost + Me.FinalEquipmentCost
      End Get
    End Property    Public ReadOnly Property FinalOverhead() As Decimal
      Get
        Return Me.MarkupCollection.GetUndistributedOverhead
      End Get
    End Property    Public ReadOnly Property FinalProfit() As Decimal
      Get
        Return Me.MarkupCollection.GetUndistributedProfit
      End Get
    End Property    Public ReadOnly Property FinalBidPrice() As Decimal
      Get
        If Lazy Then
          Return Me.m_finalbidpriceFromDB
        End If
        Return Me.FinalDirectCost + Me.FinalOverhead + Me.FinalProfit
      End Get
    End Property    Public ReadOnly Property FinalBidPriceWithVat() As Decimal
      Get
        Return Me.FinalDirectCost + Me.FinalOverhead + Me.FinalProfit + Me.TaxAmount
      End Get
    End Property    Public Property MarkupCollection() As MarkupCollection      Get        Return m_markupCollection      End Get      Set(ByVal Value As MarkupCollection)        m_markupCollection = Value      End Set    End Property    Public Property WBSCollection() As WBSCollection      Get        Return m_WBSCollection      End Get      Set(ByVal Value As WBSCollection)        m_WBSCollection = Value      End Set    End Property    Public Property ItemCollection() As BoqItemCollection      Get        Return m_itemCollection      End Get      Set(ByVal Value As BoqItemCollection)        m_itemCollection = Value      End Set    End Property    Public ReadOnly Property HasMaterialCost() As Boolean      Get        If Me.Project Is Nothing Then          Return False
        End If        Return Me.Project.HasMaterialCost      End Get    End Property    Public ReadOnly Property HasLaborCost() As Boolean      Get        If Me.Project Is Nothing Then          Return False
        End If        Return Me.Project.HasLaborCost      End Get    End Property    Public ReadOnly Property HasEquipmentCost() As Boolean      Get        If Me.Project Is Nothing Then          Return False
        End If        Return Me.Project.HasEquipmentCost      End Get    End Property    Public Overrides Property Status() As CodeDescription
      Get
        Return Me.m_status
      End Get
      Set(ByVal Value As CodeDescription)
        m_status = CType(Value, BOQStatus)
      End Set
    End Property

    Public Overrides ReadOnly Property ClassName() As String
      Get
        Return "BOQ"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.BOQ.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.BOQ"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.BOQ"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.BOQ.ListLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property Prefix() As String
      Get
        Return "boq"
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
    Public Overrides ReadOnly Property UseSiteConnString() As Boolean
      Get
        Return True
      End Get
    End Property
#End Region
#Region "Shared"
    Public Shared Function GetBOQ(ByVal boqId As Integer) As BOQ
      Dim ds As DataSet = SqlHelper.ExecuteDataset(SiteConnectionString _
      , CommandType.StoredProcedure _
      , "GetBOQ" _
      , New SqlParameter("@boq_id", boqId) _
      )
      Dim entity As New BOQ
      If ds.Tables(0).Rows.Count = 1 Then
        entity.LazyConstruct(ds.Tables(0).Rows(0), "")
      End If
      Return entity
    End Function
    Public Shared Function GetBOQ(ByVal txtCode As TextBox, ByRef oldEntity As BOQ) As Boolean
      Dim ds As DataSet = SqlHelper.ExecuteDataset(SiteConnectionString _
      , CommandType.StoredProcedure _
      , "GetBOQ" _
      , New SqlParameter("@boq_code", txtCode.Text) _
      )
      Dim entity As New BOQ
      If ds.Tables(0).Rows.Count = 1 Then
        entity.LazyConstruct(ds.Tables(0).Rows(0), "")
      End If

      If txtCode.Text.Length <> 0 AndAlso Not entity.Originated Then
        MessageBox.Show(txtCode.Text & " ไม่มีในระบบ")
        entity = oldEntity
      End If
      txtCode.Text = entity.Code
      If oldEntity.Id <> entity.Id Then
        oldEntity = entity
        Return True
      End If
      Return False
    End Function
    Public Shared Function GetSchemaTable() As TreeTable
      Dim myDatatable As New TreeTable("BOQ")
      Dim selectedCol As New DataColumn("Selected", GetType(Boolean))
      selectedCol.DefaultValue = False
      myDatatable.Columns.Add(selectedCol)
      myDatatable.Columns.Add(New DataColumn("boqi_linenumber", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("boqi_wbs", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("boqi_entity", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("boqi_entityType", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("boqi_entityTypeDesc", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("boqi_itemName", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Code", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Button", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("boqi_unit", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Unit", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("UnitButton", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("boqi_qty", GetType(String)))

      myDatatable.Columns.Add(New DataColumn("QtyPerWBS", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("WBSQty", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("TotalPerWBS", GetType(String)))

      myDatatable.Columns.Add(New DataColumn("boqi_umc", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("TotalMaterialCost", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("boqi_ulc", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("TotalLaborCost", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("boqi_uec", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("TotalEquipmentCost", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Total", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("boqi_note", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("wbsList_number", GetType(String)))
      Return myDatatable
    End Function
#End Region

#Region "Methods"
    Public Sub PopulateItemListing(ByVal tm As TreeManager, ByVal ditc As DistributedItemCollection, Optional ByVal SetWorkDone As CountDelegate = Nothing)
      Dim dt As TreeTable = CType(tm.Treetable.Clone, TreeTable)
      PopulateItemListing(dt, ditc, SetWorkDone)
      tm.Treetable = dt
    End Sub
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="dt"></param>
    ''' <param name="ditc"></param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[KRISS]	08/01/2549	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Private Sub PopulateItemListing(ByVal dt As TreeTable, ByVal ditc As DistributedItemCollection, Optional ByVal SetWorkDone As CountDelegate = Nothing)
      dt.Clear()
      Dim cnt As Integer
      For Each myWbs As WBS In Me.WBSCollection
        If Not SetWorkDone Is Nothing Then
          cnt += 1
          SetWorkDone(cnt)
        End If
        Dim parentNodes As TreeRow.TreeRowCollection = Nothing
        If myWbs.Parent Is myWbs Then
          parentNodes = dt.Childs
        ElseIf myWbs.Parent.Id <> 0 And myWbs.Parent.Id = myWbs.Id Then
          parentNodes = dt.Childs
        Else
          Dim parentNode As TreeRow = FindRow(dt, CType(myWbs.Parent, WBS))
          If Not parentNode Is Nothing Then
            parentNodes = parentNode.Childs
          End If
        End If
        If Not parentNodes Is Nothing Then
          Dim tr As TreeRow = parentNodes.Add
          tr("boqi_itemname") = myWbs.Code & "-" & myWbs.Name
          tr("Button") = "invisible"
          tr("UnitButton") = "invisible"
          tr("boqi_note") = myWbs.Note
          'tr("TotalMaterialCost") = Configuration.FormatToString(myWbs.GetTotalMat, DigitConfig.Price)
          'tr("TotalLaborCost") = Configuration.FormatToString(myWbs.GetTotalLab, DigitConfig.Price)
          'tr("TotalEquipmentCost") = Configuration.FormatToString(myWbs.GetTotalEq, DigitConfig.Price)
          'tr("Total") = Configuration.FormatToString(myWbs.GetTotal, DigitConfig.Price)
          tr.Tag = myWbs
          tr.State = RowExpandState.Expanded
          Dim coll As BoqItemCollection = ditc.GetCollectionForWBS(myWbs)
          For Each item As BoqItem In coll
            If Not SetWorkDone Is Nothing Then
              cnt += 1
              SetWorkDone(cnt)
            End If
            Dim itr As TreeRow = tr.Childs.Add()
            itr("Code") = item.Entity.Code
            If item.ItemType.Value = 0 OrElse item.EntityName Is Nothing OrElse item.EntityName.Length = 0 Then
              itr("boqi_itemName") = item.Entity.Name
            Else
              itr("boqi_itemName") = item.EntityName & "<" & item.Entity.Name & ">"
            End If
            itr("boqi_note") = item.Note
            itr("Selected") = True
            itr.Tag = item
            itr("boqi_wbs") = myWbs.Id
            itr("boqi_entity") = item.Entity.Id
            If Not item.ItemType Is Nothing Then
              itr("boqi_entityType") = item.ItemType.Value
              itr("boqi_entityTypeDesc") = item.ItemType.Description
              Select Case item.ItemType.Value
                Case 0
                  itr("Button") = "invisible"
                Case Else
                  itr("Button") = ""
              End Select
            Else
              itr("Button") = ""
            End If
            itr("boqi_unit") = item.Unit.Id
            itr("Unit") = item.Unit.Name
            itr("UnitButton") = ""
            itr("boqi_qty") = Configuration.FormatToString(item.Qty, DigitConfig.Qty)
            itr("boqi_umc") = Configuration.FormatToString(item.UMC, DigitConfig.UnitPrice)
            itr("TotalMaterialCost") = Configuration.FormatToString(item.TotalMaterialCost, DigitConfig.Price)
            itr("boqi_ulc") = Configuration.FormatToString(item.ULC, DigitConfig.UnitPrice)
            itr("TotalLaborCost") = Configuration.FormatToString(item.TotalLaborCost, DigitConfig.Price)
            itr("boqi_uec") = Configuration.FormatToString(item.UEC, DigitConfig.UnitPrice)
            itr("TotalEquipmentCost") = Configuration.FormatToString(item.TotalEquipmentCost, DigitConfig.Price)
            itr("Total") = Configuration.FormatToString(item.TotalCost, DigitConfig.Price)
            itr("boqi_note") = item.Note
          Next 'item
          coll = Nothing
        End If
      Next
      Dim i As Integer = 0
      For Each row As DataRow In dt.Rows
        i += 1
        row("boqi_linenumber") = i
      Next
      If i > 0 Then
        dt.AcceptChanges()
      End If
    End Sub
    Public Sub PopulateItemListing(ByVal tm As TreeManager, ByVal fiters As Filter(), ByVal ditc As DistributedItemCollection, Optional ByVal SetWorkDone As CountDelegate = Nothing)
      Dim dt As TreeTable = CType(tm.Treetable.Clone, TreeTable)
      PopulateItemListing(dt, fiters, ditc, SetWorkDone)
      tm.Treetable = dt
    End Sub
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' ใช้ filter + เฉพาะที่ถูกเลือก
    ''' </summary>
    ''' <param name="dt"></param>
    ''' <param name="fiters"></param>
    ''' <param name="ditc"></param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[KRISS]	08/01/2549	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Private Sub PopulateItemListing(ByVal dt As TreeTable, ByVal fiters As Filter(), ByVal ditc As DistributedItemCollection, Optional ByVal SetWorkDone As CountDelegate = Nothing)
      dt.Clear()
      Dim valueFrom As Object = DBNull.Value
      Dim valueTo As Object = DBNull.Value
      Dim containName As Object = DBNull.Value
      Dim underWBS As Object = DBNull.Value
      For Each myFilter As Filter In fiters
        Select Case myFilter.Name.ToLower
          Case "valuefrom"
            valueFrom = myFilter.Value
          Case "valueto"
            valueTo = myFilter.Value
          Case "containname"
            containName = myFilter.Value
          Case "underwbs"
            underWBS = myFilter.Value
        End Select
      Next
      If IsDBNull(valueFrom) Then
        valueFrom = Decimal.MinValue
      End If
      If IsDBNull(valueTo) Then
        valueTo = Decimal.MaxValue
      End If
      If IsDBNull(containName) Then
        containName = ""
      End If
      Dim coll As WBSCollection
      If underWBS Is DBNull.Value Then
        coll = Me.WBSCollection
      ElseIf TypeOf underWBS Is WBS Then
        coll = Me.WBSCollection.GetSubOrdinatesOf(CType(underWBS, WBS))
      End If
      If coll Is Nothing Then
        Return
      End If
      Dim cnt As Integer = 0
      For Each myWbs As WBS In coll
        If Not SetWorkDone Is Nothing Then
          cnt += 1
          SetWorkDone(cnt)
        End If
        Dim parentNodes As TreeRow.TreeRowCollection = Nothing
        If myWbs.Parent Is myWbs Then
          parentNodes = dt.Childs
        ElseIf myWbs.Parent Is Nothing OrElse (myWbs.Parent.Id <> 0 And myWbs.Parent.Id = myWbs.Id) Then
          parentNodes = dt.Childs
        Else
          Dim parentNode As TreeRow = FindRow(dt, CType(myWbs.Parent, WBS))
          If Not parentNode Is Nothing Then
            parentNodes = parentNode.Childs
          Else
            parentNodes = dt.Childs
          End If
        End If

        If Not parentNodes Is Nothing Then
          Dim tr As TreeRow = parentNodes.Add
          tr("boqi_itemname") = myWbs.Code & "-" & myWbs.Name
          tr("Button") = "invisible"
          tr("UnitButton") = "invisible"
          tr("boqi_note") = myWbs.Note
          'tr("TotalMaterialCost") = Configuration.FormatToString(myWbs.GetTotalMat, DigitConfig.Price)
          'tr("TotalLaborCost") = Configuration.FormatToString(myWbs.GetTotalLab, DigitConfig.Price)
          'tr("TotalEquipmentCost") = Configuration.FormatToString(myWbs.GetTotalEq, DigitConfig.Price)
          'tr("Total") = Configuration.FormatToString(myWbs.GetTotal, DigitConfig.Price)
          tr.Tag = myWbs
          tr.State = RowExpandState.Expanded
          Dim myColl As BoqItemCollection = Me.ItemCollection.GetCollectionForWBS(myWbs)
          For Each item As BoqItem In myColl
            Dim value As Decimal = item.TotalCost
            If value >= CDec(valueFrom) And value <= CDec(valueTo) Then
              Dim displayName As String = ""
              If item.ItemType.Value = 0 OrElse item.EntityName Is Nothing OrElse item.EntityName.Length = 0 Then
                displayName = item.Entity.Name
              Else
                displayName = item.EntityName & "<" & item.Entity.Name & ">"
              End If
              If containName.ToString.Length = 0 OrElse displayName.ToLower.IndexOf(containName.ToString.ToLower) >= 0 OrElse item.Entity.Code.ToLower.IndexOf(containName.ToString.ToLower) >= 0 Then
                If Not SetWorkDone Is Nothing Then
                  cnt += 1
                  SetWorkDone(cnt)
                End If
                Dim itr As TreeRow = tr.Childs.Add()
                itr("Code") = item.Entity.Code
                itr("boqi_itemName") = displayName
                itr("boqi_note") = item.Note
                itr("Selected") = ditc.Contains(item)
                itr.Tag = item
                itr("boqi_wbs") = myWbs.Id
                itr("boqi_entity") = item.Entity.Id
                If Not item.ItemType Is Nothing Then
                  itr("boqi_entityType") = item.ItemType.Value
                  itr("boqi_entityTypeDesc") = item.ItemType.Description
                  Select Case item.ItemType.Value
                    Case 0
                      itr("Button") = "invisible"
                    Case Else
                      itr("Button") = ""
                  End Select
                Else
                  itr("Button") = ""
                End If
                itr("boqi_unit") = item.Unit.Id
                itr("Unit") = item.Unit.Name
                itr("UnitButton") = ""
                itr("boqi_qty") = Configuration.FormatToString(item.Qty, DigitConfig.Qty)
                itr("boqi_umc") = Configuration.FormatToString(item.UMC, DigitConfig.UnitPrice)
                itr("TotalMaterialCost") = Configuration.FormatToString(item.TotalMaterialCost, DigitConfig.Price)
                itr("boqi_ulc") = Configuration.FormatToString(item.ULC, DigitConfig.UnitPrice)
                itr("TotalLaborCost") = Configuration.FormatToString(item.TotalLaborCost, DigitConfig.Price)
                itr("boqi_uec") = Configuration.FormatToString(item.UEC, DigitConfig.UnitPrice)
                itr("TotalEquipmentCost") = Configuration.FormatToString(item.TotalEquipmentCost, DigitConfig.Price)
                itr("Total") = Configuration.FormatToString(item.TotalCost, DigitConfig.Price)
                itr("boqi_note") = item.Note
              End If
            End If
          Next 'item
          myColl = Nothing
        End If
      Next
      Dim i As Integer = 0
      For Each row As DataRow In dt.Rows
        i += 1
        row("boqi_linenumber") = i
      Next
      If i > 0 Then
        dt.AcceptChanges()
      End If
    End Sub
    Public Sub PopulateItemListing(ByVal tm As TreeManager, ByVal fiters As Filter(), Optional ByVal SetWorkDone As CountDelegate = Nothing)
      Dim dt As TreeTable = CType(tm.Treetable.Clone, TreeTable)
      PopulateItemListing(dt, fiters, SetWorkDone)
      tm.Treetable = dt
    End Sub
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' ใช้ filter 
    ''' </summary>
    ''' <param name="dt"></param>
    ''' <param name="fiters"></param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[KRISS]	08/01/2549	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Private Sub PopulateItemListing(ByVal dt As TreeTable, ByVal fiters As Filter(), Optional ByVal SetWorkDone As CountDelegate = Nothing)
      dt.Clear()
      Dim valueFrom As Object = DBNull.Value
      Dim valueTo As Object = DBNull.Value
      Dim containName As Object = DBNull.Value
      Dim underWBS As Object = DBNull.Value
      For Each myFilter As Filter In fiters
        Select Case myFilter.Name.ToLower
          Case "valuefrom"
            valueFrom = myFilter.Value
          Case "valueto"
            valueTo = myFilter.Value
          Case "containname"
            containName = myFilter.Value
          Case "underwbs"
            underWBS = myFilter.Value
        End Select
      Next
      If IsDBNull(valueFrom) Then
        valueFrom = Decimal.MinValue
      End If
      If IsDBNull(valueTo) Then
        valueTo = Decimal.MaxValue
      End If
      If IsDBNull(containName) Then
        containName = ""
      End If
      Dim coll As WBSCollection
      If underWBS Is DBNull.Value Then
        coll = Me.WBSCollection
      ElseIf TypeOf underWBS Is WBS Then
        coll = Me.WBSCollection.GetSubOrdinatesOf(CType(underWBS, WBS))
      End If
      If coll Is Nothing Then
        Return
      End If
      Dim cnt As Integer = 0
      For Each myWbs As WBS In coll
        If Not SetWorkDone Is Nothing Then
          cnt += 1
          SetWorkDone(cnt)
        End If
        Dim parentNodes As TreeRow.TreeRowCollection = Nothing
        If myWbs.Parent Is myWbs Then
          parentNodes = dt.Childs
        ElseIf myWbs.Parent Is Nothing OrElse (myWbs.Parent.Id <> 0 And myWbs.Parent.Id = myWbs.Id) Then
          parentNodes = dt.Childs
        Else
          Dim parentNode As TreeRow = FindRow(dt, CType(myWbs.Parent, WBS))
          If Not parentNode Is Nothing Then
            parentNodes = parentNode.Childs
          Else
            parentNodes = dt.Childs
          End If
        End If

        If Not parentNodes Is Nothing Then
          Dim tr As TreeRow = parentNodes.Add
          tr("boqi_itemname") = myWbs.Code & "-" & myWbs.Name
          tr("Button") = "invisible"
          tr("UnitButton") = "invisible"
          tr("boqi_note") = myWbs.Note
          'tr("TotalMaterialCost") = Configuration.FormatToString(myWbs.GetTotalMat, DigitConfig.Price)
          'tr("TotalLaborCost") = Configuration.FormatToString(myWbs.GetTotalLab, DigitConfig.Price)
          'tr("TotalEquipmentCost") = Configuration.FormatToString(myWbs.GetTotalEq, DigitConfig.Price)
          'tr("Total") = Configuration.FormatToString(myWbs.GetTotal, DigitConfig.Price)
          tr.Tag = myWbs
          tr.State = RowExpandState.Expanded
          Dim myColl As BoqItemCollection = Me.ItemCollection.GetCollectionForWBS(myWbs)
          For Each item As BoqItem In myColl
            Dim value As Decimal = item.TotalCost
            If value >= CDec(valueFrom) And value <= CDec(valueTo) Then
              Dim displayName As String = ""
              If item.ItemType.Value = 0 OrElse item.EntityName Is Nothing OrElse item.EntityName.Length = 0 Then
                displayName = item.Entity.Name
              Else
                displayName = item.EntityName & "<" & item.Entity.Name & ">"
              End If
              If containName.ToString.Length = 0 OrElse displayName.ToLower.IndexOf(containName.ToString.ToLower) >= 0 OrElse item.Entity.Code.ToLower.IndexOf(containName.ToString.ToLower) >= 0 Then
                If Not SetWorkDone Is Nothing Then
                  cnt += 1
                  SetWorkDone(cnt)
                End If
                Dim itr As TreeRow = tr.Childs.Add()
                itr("Code") = item.Entity.Code
                itr("boqi_itemName") = displayName
                itr("boqi_note") = item.Note
                itr.Tag = item
                itr("boqi_wbs") = myWbs.Id
                itr("boqi_entity") = item.Entity.Id
                If Not item.ItemType Is Nothing Then
                  itr("boqi_entityType") = item.ItemType.Value
                  itr("boqi_entityTypeDesc") = item.ItemType.Description
                  Select Case item.ItemType.Value
                    Case 0
                      itr("Button") = "invisible"
                    Case Else
                      itr("Button") = ""
                  End Select
                Else
                  itr("Button") = ""
                End If
                itr("boqi_unit") = item.Unit.Id
                itr("Unit") = item.Unit.Name
                itr("UnitButton") = ""
                itr("boqi_qty") = Configuration.FormatToString(item.Qty, DigitConfig.Qty)
                itr("boqi_umc") = Configuration.FormatToString(item.UMC, DigitConfig.UnitPrice)
                itr("TotalMaterialCost") = Configuration.FormatToString(item.TotalMaterialCost, DigitConfig.Price)
                itr("boqi_ulc") = Configuration.FormatToString(item.ULC, DigitConfig.UnitPrice)
                itr("TotalLaborCost") = Configuration.FormatToString(item.TotalLaborCost, DigitConfig.Price)
                itr("boqi_uec") = Configuration.FormatToString(item.UEC, DigitConfig.UnitPrice)
                itr("TotalEquipmentCost") = Configuration.FormatToString(item.TotalEquipmentCost, DigitConfig.Price)
                itr("Total") = Configuration.FormatToString(item.TotalCost, DigitConfig.Price)
                itr("boqi_note") = item.Note
              End If
            End If
          Next 'item
          myColl = Nothing
        End If
      Next
      Dim i As Integer = 0
      For Each row As DataRow In dt.Rows
        i += 1
        row("boqi_linenumber") = i
      Next
      If i > 0 Then
        dt.AcceptChanges()
      End If
    End Sub
    Public Sub PopulateItemListing(ByVal tm As TreeManager, ByVal ditc As DistributedItemCollection, ByVal check As Boolean, Optional ByVal SetWorkDone As CountDelegate = Nothing)
      Dim dt As TreeTable = CType(tm.Treetable.Clone, TreeTable)
      PopulateItemListing(dt, ditc, check, SetWorkDone)
      tm.Treetable = dt
    End Sub
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' เฉพาะ Item ที่ distribute
    ''' </summary>
    ''' <param name="dt"></param>
    ''' <param name="ditc"></param>
    ''' <param name="check"></param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[KRISS]	08/01/2549	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Private Sub PopulateItemListing(ByVal dt As TreeTable, ByVal ditc As DistributedItemCollection, ByVal check As Boolean, Optional ByVal SetWorkDone As CountDelegate = Nothing)
      dt.Clear()
      If Not check Then
        Return
      End If
      Dim cnt As Integer = 0
      For Each myWbs As WBS In Me.WBSCollection
        If Not SetWorkDone Is Nothing Then
          cnt += 1
          SetWorkDone(cnt)
        End If
        Dim parentNodes As TreeRow.TreeRowCollection = Nothing
        If myWbs.Parent Is myWbs Then
          parentNodes = dt.Childs
        ElseIf myWbs.Parent.Id <> 0 And myWbs.Parent.Id = myWbs.Id Then
          parentNodes = dt.Childs
        Else
          Dim parentNode As TreeRow = FindRow(dt, CType(myWbs.Parent, WBS))
          If Not parentNode Is Nothing Then
            parentNodes = parentNode.Childs
          End If
        End If
        If Not parentNodes Is Nothing Then
          Dim tr As TreeRow = parentNodes.Add
          tr("boqi_itemname") = myWbs.Code & "-" & myWbs.Name
          tr("Button") = "invisible"
          tr("UnitButton") = "invisible"
          tr("boqi_note") = myWbs.Note
          'tr("TotalMaterialCost") = Configuration.FormatToString(myWbs.GetTotalMat, DigitConfig.Price)
          'tr("TotalLaborCost") = Configuration.FormatToString(myWbs.GetTotalLab, DigitConfig.Price)
          'tr("TotalEquipmentCost") = Configuration.FormatToString(myWbs.GetTotalEq, DigitConfig.Price)
          'tr("Total") = Configuration.FormatToString(myWbs.GetTotal, DigitConfig.Price)
          tr.Tag = myWbs
          tr.State = RowExpandState.Expanded
          Dim myColl As BoqItemCollection = Me.ItemCollection.GetCollectionForWBS(myWbs)
          For Each item As BoqItem In myColl
            If Not SetWorkDone Is Nothing Then
              cnt += 1
              SetWorkDone(cnt)
            End If
            Dim itr As TreeRow = tr.Childs.Add()
            itr("Code") = item.Entity.Code
            If item.ItemType.Value = 0 OrElse item.EntityName Is Nothing OrElse item.EntityName.Length = 0 Then
              itr("boqi_itemName") = item.Entity.Name
            Else
              itr("boqi_itemName") = item.EntityName & "<" & item.Entity.Name & ">"
            End If
            itr("boqi_note") = item.Note
            itr("Selected") = ditc.Contains(item)
            itr.Tag = item
            itr("boqi_wbs") = myWbs.Id
            itr("boqi_entity") = item.Entity.Id
            If Not item.ItemType Is Nothing Then
              itr("boqi_entityType") = item.ItemType.Value
              itr("boqi_entityTypeDesc") = item.ItemType.Description
              Select Case item.ItemType.Value
                Case 0
                  itr("Button") = "invisible"
                Case Else
                  itr("Button") = ""
              End Select
            Else
              itr("Button") = ""
            End If
            itr("boqi_unit") = item.Unit.Id
            itr("Unit") = item.Unit.Name
            itr("UnitButton") = ""
            itr("boqi_qty") = Configuration.FormatToString(item.Qty, DigitConfig.Qty)
            itr("boqi_umc") = Configuration.FormatToString(item.UMC, DigitConfig.UnitPrice)
            itr("TotalMaterialCost") = Configuration.FormatToString(item.TotalMaterialCost, DigitConfig.Price)
            itr("boqi_ulc") = Configuration.FormatToString(item.ULC, DigitConfig.UnitPrice)
            itr("TotalLaborCost") = Configuration.FormatToString(item.TotalLaborCost, DigitConfig.Price)
            itr("boqi_uec") = Configuration.FormatToString(item.UEC, DigitConfig.UnitPrice)
            itr("TotalEquipmentCost") = Configuration.FormatToString(item.TotalEquipmentCost, DigitConfig.Price)
            itr("Total") = Configuration.FormatToString(item.TotalCost, DigitConfig.Price)
            itr("boqi_note") = item.Note
          Next 'item
          myColl = Nothing
        End If
      Next
      Dim i As Integer = 0
      For Each row As DataRow In dt.Rows
        i += 1
        row("boqi_linenumber") = i
      Next
      If i > 0 Then
        dt.AcceptChanges()
      End If
    End Sub
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Testing
    ''' </summary>
    ''' <param name="tv"></param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Administrator]	17/2/2549	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Sub PopulateItemListing(ByVal tv As TreeView, Optional ByVal SetWorkDone As CountDelegate = Nothing)
      tv.BeginUpdate()
      tv.Nodes.Clear()
      Dim cnt As Integer = 0
      For Each myWbs As WBS In Me.WBSCollection
        If Not SetWorkDone Is Nothing Then
          cnt += 1
          SetWorkDone(cnt)
        End If
        Dim parentNodes As TreeNodeCollection = Nothing
        If myWbs.Parent Is myWbs Then
          parentNodes = tv.Nodes
        ElseIf myWbs.Parent.Id <> 0 And myWbs.Parent.Id = myWbs.Id Then
          parentNodes = tv.Nodes
        Else
          Dim parentNode As TreeNode = FindNode(tv, CType(myWbs.Parent, WBS))
          If Not parentNode Is Nothing Then
            parentNodes = parentNode.Nodes
          End If
        End If
        If Not parentNodes Is Nothing Then
          Dim tn As TreeNode = parentNodes.Add(myWbs.Code & "-" & myWbs.Name)
          tn.Tag = myWbs
          Dim myColl As BoqItemCollection = Me.ItemCollection.GetCollectionForWBS(myWbs)
          For Each item As BoqItem In myColl
            Dim itn As TreeNode = tn.Nodes.Add(item.EntityName)
            itn.Tag = item
          Next
          myColl = Nothing
        End If
      Next
      tv.EndUpdate()
    End Sub
    Public Sub PopulateItemListing(ByVal tm As TreeManager, Optional ByVal SetWorkDone As CountDelegate = Nothing)
      Dim dt As TreeTable = CType(tm.Treetable.Clone, TreeTable)
      PopulateItemListing(dt, SetWorkDone)
      tm.Treetable = dt
    End Sub
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' สร้าง TreeTable ของ WBS+BOQItem ที่ยังไม่มีการกระจาย
    ''' </summary>
    ''' <param name="dt"></param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[KRISS]	08/01/2549	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Private Sub PopulateItemListing(ByVal dt As TreeTable, Optional ByVal SetWorkDone As CountDelegate = Nothing)
      dt.Clear()
      dt.Initialized = False
      Dim includeQtyPerWBS As Boolean = False
      Dim icq As Object = Configuration.GetConfig("includeQtyPerWBS")
      If Not IsDBNull(icq) AndAlso Not icq Is Nothing Then
        includeQtyPerWBS = CBool(icq)
      End If
      Dim cnt As Integer = 0
      For Each myWbs As WBS In Me.WBSCollection
        If Not SetWorkDone Is Nothing Then
          cnt += 1
          SetWorkDone(cnt)
        End If
        Dim parentNodes As TreeRow.TreeRowCollection = Nothing
        If myWbs.Parent Is myWbs Then
          parentNodes = dt.Childs
        ElseIf myWbs.Parent.Id <> 0 And myWbs.Parent.Id = myWbs.Id Then
          parentNodes = dt.Childs
        Else
          Dim parentNode As TreeRow = FindRow(dt, CType(myWbs.Parent, WBS))
          If Not parentNode Is Nothing Then
            parentNodes = parentNode.Childs
          End If
        End If
        If Not parentNodes Is Nothing Then
          Dim tr As TreeRow = parentNodes.Add
          tr("boqi_itemname") = myWbs.Code & "-" & myWbs.Name
          tr("Button") = "invisible"
          tr("boqi_unit") = myWbs.Unit.Id
          tr("Unit") = myWbs.Unit.Name
          tr("UnitButton") = ""
          tr("boqi_note") = myWbs.Note

          Dim tmat As Decimal = myWbs.GetTotalMat
          Dim tlab As Decimal = myWbs.GetTotalLab
          Dim teq As Decimal = myWbs.GetTotalEq

          tr("TotalMaterialCost") = Configuration.FormatToString(tmat, DigitConfig.Price)
          tr("TotalLaborCost") = Configuration.FormatToString(tlab, DigitConfig.Price)
          tr("TotalEquipmentCost") = Configuration.FormatToString(teq, DigitConfig.Price)

          tr("Total") = Configuration.FormatToString(myWbs.GetTotal, DigitConfig.Price)

          tr("TotalPerWBS") = Configuration.FormatToString(myWbs.GetTotalPerWBS, DigitConfig.Price)

          If includeQtyPerWBS Then
            Dim allQ As Decimal = myWbs.AllQty
            tr("boqi_qty") = Configuration.FormatToString(allQ, DigitConfig.Qty)

            Dim wumc As Decimal = 0
            Dim wulc As Decimal = 0
            Dim wuec As Decimal = 0
            If allQ <> 0 Then
              wumc = tmat / allQ
              wulc = tlab / allQ
              wuec = teq / allQ
            End If
            tr("boqi_umc") = Configuration.FormatToString(wumc, DigitConfig.UnitPrice)
            tr("boqi_ulc") = Configuration.FormatToString(wulc, DigitConfig.UnitPrice)
            tr("boqi_uec") = Configuration.FormatToString(wuec, DigitConfig.UnitPrice)
          End If

          If myWbs.Qty <> 0 Then
            tr("WBSQty") = Configuration.FormatToString(myWbs.Qty, DigitConfig.Qty)
            tr("QtyPerWBS") = Configuration.FormatToString(myWbs.Qty, DigitConfig.Qty)
          End If

          tr.Tag = myWbs
          tr.State = myWbs.State
          Dim myColl As BoqItemCollection = Me.ItemCollection.GetCollectionForWBS(myWbs)
          For Each item As BoqItem In myColl
            If Not SetWorkDone Is Nothing Then
              cnt += 1
              SetWorkDone(cnt)
            End If
            Dim itr As TreeRow = tr.Childs.Add()
            itr("Code") = item.Entity.Code
            If item.ItemType.Value = 0 OrElse item.EntityName Is Nothing OrElse item.EntityName.Length = 0 Then
              itr("boqi_itemName") = item.Entity.Name
            Else
              itr("boqi_itemName") = item.EntityName & "<" & item.Entity.Name & ">"
            End If
            itr("boqi_note") = item.Note
            itr.Tag = item
            itr("boqi_wbs") = myWbs.Id
            itr("boqi_entity") = item.Entity.Id
            If Not item.ItemType Is Nothing Then
              itr("boqi_entityType") = item.ItemType.Value
              itr("boqi_entityTypeDesc") = item.ItemType.Description
              Select Case item.ItemType.Value
                Case 0
                  itr("Button") = "invisible"
                Case Else
                  itr("Button") = ""
              End Select
            Else
              itr("Button") = ""
            End If
            itr("boqi_unit") = item.Unit.Id
            itr("Unit") = item.Unit.Name
            itr("UnitButton") = ""
            itr("boqi_qty") = Configuration.FormatToString(item.Qty, DigitConfig.Qty)
            itr("boqi_umc") = Configuration.FormatToString(item.UMC, DigitConfig.UnitPrice)
            itr("TotalMaterialCost") = Configuration.FormatToString(item.TotalMaterialCost, DigitConfig.Price)
            itr("boqi_ulc") = Configuration.FormatToString(item.ULC, DigitConfig.UnitPrice)
            itr("TotalLaborCost") = Configuration.FormatToString(item.TotalLaborCost, DigitConfig.Price)
            itr("boqi_uec") = Configuration.FormatToString(item.UEC, DigitConfig.UnitPrice)
            itr("TotalEquipmentCost") = Configuration.FormatToString(item.TotalEquipmentCost, DigitConfig.Price)
            itr("Total") = Configuration.FormatToString(item.TotalCost, DigitConfig.Price)
            itr("boqi_note") = item.Note

            itr("QtyPerWBS") = Configuration.FormatToString(item.QtyPerWBS, DigitConfig.Qty)
            itr("TotalPerWBS") = Configuration.FormatToString(item.TotalPerWBS, DigitConfig.Price)

          Next 'item
          myColl = Nothing
        End If
      Next
      dt.Initialized = True
      Dim i As Integer = 0
      For Each row As DataRow In dt.Rows
        i += 1
        row("boqi_linenumber") = i
      Next
      If i > 0 Then
        dt.AcceptChanges()
      End If
    End Sub
    Public Sub PopulateFinalItemListing(ByVal tm As TreeManager, Optional ByVal SetWorkDone As CountDelegate = Nothing, Optional ByVal RemoveInvisible As Boolean = False, _
    Optional ByVal hasVat As Boolean = True, _
    Optional ByVal showItemCode As Boolean = True)
      Dim dt As TreeTable = CType(tm.Treetable.Clone, TreeTable)
      PopulateFinalItemListing(dt, SetWorkDone, RemoveInvisible, hasVat, showItemCode)
      tm.Treetable = dt
    End Sub
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="dt"></param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[KRISS]	08/01/2549	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Private Sub PopulateFinalItemListing(ByVal dt As TreeTable, _
    Optional ByVal SetWorkDone As CountDelegate = Nothing, _
    Optional ByVal RemoveInvisible As Boolean = False, _
    Optional ByVal hasVat As Boolean = True, _
    Optional ByVal showItemCode As Boolean = True)
      dt.Clear()
      dt.Initialized = False
      Me.ItemCollection.ResetItemsAdj()
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      '#####################UPDATE COST################################
      For Each mk As Markup In Me.MarkupCollection
        mk.DistributedItems.UpdateCost()
        If mk.DistributedAmount > 0 Then
          Select Case mk.DistributionMethod.Value
            Case 1 'วัสดุ
              If mk.DistributedItems.MatetialCost = 0 Then
                'msgServ.ShowMessageFormatted("${res:Global.Error.PleaseDistributeToItemWithMatCost}", New String() {mk.Name})
              End If
            Case 2 'ค่าแรง
              If mk.DistributedItems.LaborCost = 0 Then
                'msgServ.ShowMessageFormatted("${res:Global.Error.PleaseDistributeToItemWithLaborCost}", New String() {mk.Name})
              End If
            Case 3 'เครื่องจักร
              If mk.DistributedItems.EquipmentCost = 0 Then
                'msgServ.ShowMessageFormatted("${res:Global.Error.PleaseDistributeToItemWithEquipmentCost}", New String() {mk.Name})
              End If
            Case 4 'รวม
              If mk.DistributedItems.DirectCost = 0 Then
                'msgServ.ShowMessageFormatted("${res:Global.Error.PleaseDistributeToItemWithDirectCost}", New String() {mk.Name})
              End If
          End Select
        End If
        mk.DistributedItems.SetAdj(Me.ItemCollection)
      Next

      Me.MaterialMarkupItems.UpdateCost()
      Me.MaterialMarkupItems.SetAdj(Me.ItemCollection)

      Me.LaborMarkupItems.UpdateCost()
      Me.LaborMarkupItems.SetAdj(Me.ItemCollection)

      Me.EquipmentMarkupItems.UpdateCost()
      Me.EquipmentMarkupItems.SetAdj(Me.ItemCollection)

      '###############################################################
      Dim includeQtyPerWBS As Boolean = False
      Dim icq As Object = Configuration.GetConfig("includeQtyPerWBS")
      If Not IsDBNull(icq) AndAlso Not icq Is Nothing Then
        includeQtyPerWBS = CBool(icq)
      End If
      Dim cnt As Integer = 0
      For Each myWbs As WBS In Me.WBSCollection
        'MessageBox.Show(myWbs.Parent.Name & ":" & CType(myWbs.Parent, WBS).State.ToString & ":" & myWbs.Name & ":" & myWbs.State.ToString & ":" & myWbs.IsVisible.ToString)
        If Not SetWorkDone Is Nothing Then
          cnt += 1
          SetWorkDone(cnt)
        End If
        Dim parentNodes As TreeRow.TreeRowCollection = Nothing
        If myWbs.Parent Is myWbs Then
          parentNodes = dt.Childs
        ElseIf myWbs.Parent.Id <> 0 And myWbs.Parent.Id = myWbs.Id Then
          parentNodes = dt.Childs
        Else
          Dim parentNode As TreeRow = FindRow(dt, CType(myWbs.Parent, WBS))
          If Not parentNode Is Nothing Then
            parentNodes = parentNode.Childs
          End If
        End If
        If (Not parentNodes Is Nothing) And (Not RemoveInvisible Or myWbs.IsVisible) Then
          Dim tr As TreeRow = parentNodes.Add
          tr("boqi_itemname") = myWbs.Code & "-" & myWbs.Name
          tr("Button") = "invisible"
          tr("boqi_unit") = myWbs.Unit.Id
          tr("Unit") = myWbs.Unit.Name
          tr("UnitButton") = ""
          tr("boqi_note") = myWbs.Note

          Dim tmat As Decimal = myWbs.GetFinalMat
          Dim tlab As Decimal = myWbs.GetFinalLab
          Dim teq As Decimal = myWbs.GetFinalEq

          tr("TotalMaterialCost") = Configuration.FormatToString(tmat, DigitConfig.Price)
          tr("TotalLaborCost") = Configuration.FormatToString(tlab, DigitConfig.Price)
          tr("TotalEquipmentCost") = Configuration.FormatToString(teq, DigitConfig.Price)
          tr("Total") = Configuration.FormatToString(myWbs.GetFinalTotal, DigitConfig.Price)

          tr("TotalPerWBS") = Configuration.FormatToString(myWbs.GetTotalPerWBS, DigitConfig.Price)

          If includeQtyPerWBS Then
            Dim allQ As Decimal = myWbs.AllQty
            tr("boqi_qty") = Configuration.FormatToString(myWbs.AllQty, DigitConfig.Qty)

            Dim wumc As Decimal = 0
            Dim wulc As Decimal = 0
            Dim wuec As Decimal = 0
            If allQ <> 0 Then
              wumc = tmat / allQ
              wulc = tlab / allQ
              wuec = teq / allQ
            End If
            tr("boqi_umc") = Configuration.FormatToString(wumc, DigitConfig.UnitPrice)
            tr("boqi_ulc") = Configuration.FormatToString(wulc, DigitConfig.UnitPrice)
            tr("boqi_uec") = Configuration.FormatToString(wuec, DigitConfig.UnitPrice)
          End If

          If myWbs.Qty <> 0 Then
            tr("WBSQty") = Configuration.FormatToString(myWbs.Qty, DigitConfig.Qty)
            tr("QtyPerWBS") = Configuration.FormatToString(myWbs.Qty, DigitConfig.Qty)
          End If

          tr.Tag = myWbs
          tr.State = myWbs.State
          Dim myColl As BoqItemCollection = Me.ItemCollection.GetCollectionForWBS(myWbs)
          For Each item As BoqItem In myColl
            If Not SetWorkDone Is Nothing Then
              cnt += 1
              SetWorkDone(cnt)
            End If
            If Not RemoveInvisible Or myWbs.State <> RowExpandState.Collapsed Then
              Dim itr As TreeRow = tr.Childs.Add()
              If showItemCode Then
                itr("Code") = item.Entity.Code
              End If
              If item.ItemType.Value = 0 OrElse item.EntityName Is Nothing OrElse item.EntityName.Length = 0 Then
                itr("boqi_itemName") = item.Entity.Name
              Else
                itr("boqi_itemName") = item.EntityName & "<" & item.Entity.Name & ">"
              End If
              itr("boqi_note") = item.Note
              itr.Tag = item
              itr("boqi_wbs") = myWbs.Id
              itr("boqi_entity") = item.Entity.Id
              If Not item.ItemType Is Nothing Then
                itr("boqi_entityType") = item.ItemType.Value
                itr("boqi_entityTypeDesc") = item.ItemType.Description
                Select Case item.ItemType.Value
                  Case 0
                    itr("Button") = "invisible"
                  Case Else
                    itr("Button") = ""
                End Select
              Else
                itr("Button") = ""
              End If
              itr("boqi_unit") = item.Unit.Id
              itr("Unit") = item.Unit.Name
              itr("UnitButton") = ""
              itr("boqi_qty") = Configuration.FormatToString(item.Qty, DigitConfig.Qty)
              itr("boqi_umc") = Configuration.FormatToString(item.FinalUMC, DigitConfig.UnitPrice)
              itr("TotalMaterialCost") = Configuration.FormatToString(item.FinalMC, DigitConfig.Price)
              itr("boqi_ulc") = Configuration.FormatToString(item.FinalULC, DigitConfig.UnitPrice)
              itr("TotalLaborCost") = Configuration.FormatToString(item.FinalLC, DigitConfig.Price)
              itr("boqi_uec") = Configuration.FormatToString(item.FinalUEC, DigitConfig.UnitPrice)
              itr("TotalEquipmentCost") = Configuration.FormatToString(item.FinalEC, DigitConfig.Price)
              itr("Total") = Configuration.FormatToString(item.FinalTotal, DigitConfig.Price)

              itr("QtyPerWBS") = Configuration.FormatToString(item.QtyPerWBS, DigitConfig.Qty)
              itr("TotalPerWBS") = Configuration.FormatToString(item.TotalPerWBS, DigitConfig.Price)

              itr("boqi_note") = item.Note
            End If
          Next 'item
          myColl = Nothing
        End If
      Next
      'PopulateFinalOverHead(dt)
      'PopulateFinalProfit(dt)
      PopulateFinalOverHeadAndProfit(dt, RemoveInvisible)
      If Me.TaxAmount <> 0 And hasVat Then
        Dim vatRow As TreeRow = dt.Childs.Add
        vatRow("boqi_itemname") = Me.StringParserService.Parse("${res:Global.Vat}")
        vatRow("Total") = Configuration.FormatToString(Me.TaxAmount, DigitConfig.Price)
        vatRow.State = RowExpandState.UnderParent
      End If
      Dim totalRow As TreeRow = dt.Childs.Add
      totalRow("boqi_itemname") = Me.StringParserService.Parse("${res:Global.Total}")

      '*******************************************************************************************************
      'totalRow("TotalMaterialCost") = Configuration.FormatToString(Me.FinalMaterialCost, DigitConfig.Price)
      'totalRow("TotalLaborCost") = Configuration.FormatToString(Me.FinalLaborCost, DigitConfig.Price)
      'totalRow("TotalEquipmentCost") = Configuration.FormatToString(Me.FinalEquipmentCost, DigitConfig.Price)
      '*******************************************************************************************************

      totalRow("Total") = Configuration.FormatToString(Me.FinalBidPriceWithVat, DigitConfig.Price)  'Me.FinalBidPrice, DigitConfig.Price)
      totalRow.State = RowExpandState.UnderParent
      dt.Initialized = True
      Dim i As Integer = 0
      For Each row As DataRow In dt.Rows
        i += 1
        row("boqi_linenumber") = i
      Next
      If i > 0 Then
        dt.AcceptChanges()
      End If
    End Sub
    Public Function FindRow(ByVal dt As TreeTable, ByVal myWbs As WBS) As TreeRow
      Dim n As TreeRow
      For Each n In dt.Childs
        Dim tr As TreeRow = FindRow(n, myWbs)
        If Not tr Is Nothing Then
          Return tr
        End If
      Next
    End Function
    Private Function FindRow(ByVal n As TreeRow, ByVal myWbs As WBS) As TreeRow
      If TypeOf n.Tag Is WBS Then
        Dim nodeWbs As WBS = CType(n.Tag, WBS)
        If nodeWbs Is myWbs Then
          Return n
        End If
        If nodeWbs.Id <> 0 And nodeWbs.Id = myWbs.Id Then
          Return n
        End If
      End If
      Dim aNode As TreeRow
      For Each aNode In n.Childs
        Dim tr As TreeRow = FindRow(aNode, myWbs)
        If Not tr Is Nothing Then
          Return tr
        End If
      Next
    End Function
    Public Function FindNode(ByVal tv As TreeView, ByVal myWbs As WBS) As TreeNode
      Dim n As TreeNode
      For Each n In tv.Nodes
        Dim tn As TreeNode = FindNode(n, myWbs)
        If Not tn Is Nothing Then
          Return tn
        End If
      Next
    End Function
    Private Function FindNode(ByVal n As TreeNode, ByVal myWbs As WBS) As TreeNode
      If TypeOf n.Tag Is WBS Then
        Dim nodeWbs As WBS = CType(n.Tag, WBS)
        If nodeWbs Is myWbs Then
          Return n
        End If
        If nodeWbs.Id <> 0 And nodeWbs.Id = myWbs.Id Then
          Return n
        End If
      End If
      Dim aNode As TreeNode
      For Each aNode In n.Nodes
        Dim tn As TreeNode = FindNode(aNode, myWbs)
        If Not tn Is Nothing Then
          Return tn
        End If
      Next
    End Function
    Public Sub PopulateFinalOverHeadAndProfit(ByVal dt As TreeTable, Optional ByVal RemoveInvisible As Boolean = False)
      Dim totalOverHead As Decimal = Me.MarkupCollection.GetUndistributedOverhead
      Dim totalProfit As Decimal = Me.MarkupCollection.GetUnDistributedAmountForType(8) 'Hack
      If totalOverHead + totalProfit <> 0 Then
        Dim opNode As TreeRow = dt.Childs.Add
        opNode("boqi_itemName") = Me.StringParserService.Parse("${res:Global.OverheadAndProfit}")
        opNode("Total") = Configuration.FormatToString(totalOverHead + totalProfit, DigitConfig.Price)
        opNode.Tag = 99 'Hack 99
        opNode.State = Me.GetStateFromType(99) 'Hack 99
        If opNode.State <> RowExpandState.Collapsed Or Not RemoveInvisible Then
          If totalOverHead <> 0 Then
            Dim overheadNode As TreeRow = opNode.Childs.Add
            overheadNode("boqi_itemName") = Me.StringParserService.Parse("${res:Global.Overhead}")
            overheadNode("Total") = Configuration.FormatToString(totalOverHead, DigitConfig.Price)
            overheadNode.Tag = 0 'Hack 0
            overheadNode.State = Me.GetStateFromType(0) 'Hack 0
            If overheadNode.State <> RowExpandState.Collapsed Or Not RemoveInvisible Then
              PopulateFinalOverHead(overheadNode, RemoveInvisible)
            End If
          End If
          If totalProfit <> 0 Then
            PopulateFinalProfit(opNode, RemoveInvisible)
          End If
        End If
      End If
    End Sub
    Public Function GetStateFromType(ByVal type As Integer) As RowExpandState
      If Me.MarkupState Is Nothing OrElse Me.MarkupState.Length = 0 Then
        Return RowExpandState.Expanded
      End If
      Dim pattern As String = "\|(?<Type>\d+)\,(?<State>\d+)\|"
      Dim re As New Regex(pattern)
      For Each m As Match In re.Matches(Me.MarkupState)
        If CInt(m.Groups("Type").Value) = type Then
          Dim state As RowExpandState = CType([Enum].Parse(GetType(RowExpandState), CStr(m.Groups("State").Value)), RowExpandState)
          Return state
        End If
      Next
      Return RowExpandState.Expanded
    End Function
    Public Sub SetState(ByVal type As Integer, ByVal state As RowExpandState)
      Dim newState As String = "|" & CStr(type) & "," & CStr(CInt(state)) & "|"
      If Me.MarkupState Is Nothing OrElse Me.MarkupState.Length = 0 Then
        Me.MarkupState &= newState
        Return
      End If
      Dim pattern As String = "\|(?<Type>\d+)\,(?<State>\d+)\|"
      Dim re As New Regex(pattern)
      Dim currentState As String = ""
      For Each m As Match In re.Matches(Me.MarkupState)
        If CInt(m.Groups("Type").Value) = type Then
          currentState = m.Value
          Exit For
        End If
      Next
      If currentState.Length = 0 Then
        Me.MarkupState &= newState
      Else
        Me.MarkupState = Me.MarkupState.Replace(currentState, newState)
      End If
    End Sub
    Private Sub PopulateFinalOverHead(ByVal overheadNode As TreeRow, Optional ByVal RemoveInvisible As Boolean = False)
      Dim parentNode As TreeRow = Nothing
      For Each mu As Markup In Me.MarkupCollection
        If mu.Type.GroupId = 0 AndAlso mu.TotalAmount - mu.DistributedAmount > 0 Then
          If parentNode Is Nothing OrElse (mu.Type.Description <> parentNode("boqi_itemName").ToString) Then
            parentNode = overheadNode.Childs.Add
            parentNode("boqi_itemName") = mu.Type.Description
            parentNode("Total") = Configuration.FormatToString(Me.MarkupCollection.GetUnDistributedAmountForType(mu.Type.Value), DigitConfig.Price)
            parentNode.Tag = mu.Type.Value
            parentNode.State = Me.GetStateFromType(mu.Type.Value)
          End If
          If parentNode.State <> RowExpandState.Collapsed Or Not RemoveInvisible Then
            Dim childNode As TreeRow = parentNode.Childs.Add
            childNode("boqi_itemName") = mu.Name
            childNode("Total") = Configuration.FormatToString(mu.TotalAmount - mu.DistributedAmount, DigitConfig.Price)
          End If
        End If
      Next
    End Sub
    Private Sub PopulateFinalProfit(ByVal opNode As TreeRow, Optional ByVal RemoveInvisible As Boolean = False)
      Dim parentNode As TreeRow = Nothing
      For Each mu As Markup In Me.MarkupCollection
        If mu.Type.GroupId = 1 AndAlso mu.TotalAmount - mu.DistributedAmount > 0 Then
          If parentNode Is Nothing OrElse (mu.Type.Description <> parentNode("boqi_itemName").ToString) Then
            parentNode = opNode.Childs.Add
            parentNode("boqi_itemName") = mu.Type.Description
            parentNode("Total") = Configuration.FormatToString(Me.MarkupCollection.GetUnDistributedAmountForType(mu.Type.Value), DigitConfig.Price)
            parentNode.Tag = mu.Type.Value
            parentNode.State = Me.GetStateFromType(mu.Type.Value)
          End If
          If parentNode.State <> RowExpandState.Collapsed Or Not RemoveInvisible Then
            Dim childNode As TreeRow = parentNode.Childs.Add
            childNode("boqi_itemName") = mu.Name
            childNode("Total") = Configuration.FormatToString(mu.TotalAmount - mu.DistributedAmount, DigitConfig.Price)
          End If
        End If
      Next
    End Sub
#End Region

#Region "Cost Control"

#Region "ExpenseIncome"

#Region "Style"
    Public Shared Function CreateExpenseIncomeTableStyle() As DataGridTableStyle
      Dim dst As New DataGridTableStyle
      dst.MappingName = "BOQ"
      Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)

      Dim csLineNumber As New TreeTextColumn
      csLineNumber.MappingName = "boqi_linenumber"
      csLineNumber.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.LineNumberHeaderText}")
      csLineNumber.NullText = ""
      csLineNumber.Width = 30
      csLineNumber.DataAlignment = HorizontalAlignment.Center
      csLineNumber.ReadOnly = True
      csLineNumber.TextBox.Name = "boqi_linenumber"

      Dim csName As New PlusMinusTreeTextColumn
      csName.MappingName = "boqi_itemName"
      csName.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.DescriptionHeaderText}")
      csName.NullText = ""
      csName.Width = 350
      csName.TextBox.Name = "Description"
      csName.ReadOnly = True

      Dim csExpense As New TreeTextColumn
      csExpense.MappingName = "Expense"
      csExpense.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.ExpenseHeaderText}")
      csExpense.NullText = ""
      csExpense.Width = 100
      csExpense.DataAlignment = HorizontalAlignment.Right
      csExpense.Format = "#,###.##"
      csExpense.TextBox.Name = "Expense"
      csExpense.ReadOnly = True

      Dim csIncome As New TreeTextColumn
      csIncome.MappingName = "Income"
      csIncome.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.IncomeHeaderText}")
      csIncome.NullText = ""
      csIncome.Width = 100
      csIncome.DataAlignment = HorizontalAlignment.Right
      csIncome.Format = "#,###.##"
      csIncome.TextBox.Name = "Income"
      csIncome.ReadOnly = True

      Dim csDiff As New TreeTextColumn
      csDiff.MappingName = "Diff"
      csDiff.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.DifferenceHeaderText}")
      csDiff.NullText = ""
      csDiff.Width = 100
      csDiff.DataAlignment = HorizontalAlignment.Right
      csDiff.Format = "#,###.##"
      csDiff.TextBox.Name = "Diff"
      csDiff.ReadOnly = True

      Dim csPerCentDiff As New TreeTextColumn
      csPerCentDiff.MappingName = "PerCentDiff"
      csPerCentDiff.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.PercentDiffHeaderText}")
      csPerCentDiff.NullText = ""
      csPerCentDiff.Width = 100
      csPerCentDiff.DataAlignment = HorizontalAlignment.Right
      'csPerCentDiff.Format = "#,###.##"
      csPerCentDiff.TextBox.Name = "PerCentDiff"
      csPerCentDiff.ReadOnly = True

      dst.GridColumnStyles.Add(csLineNumber)
      dst.GridColumnStyles.Add(csName)

      dst.GridColumnStyles.Add(csExpense)
      dst.GridColumnStyles.Add(csIncome)
      dst.GridColumnStyles.Add(csDiff)
      dst.GridColumnStyles.Add(csPerCentDiff)

      Return dst
    End Function
#End Region

#Region "Schema"
    Public Shared Function GetExpenseIncomeSchemaTable() As TreeTable
      Dim myDatatable As New TreeTable("BOQ")
      Dim selectedCol As New DataColumn("Selected", GetType(Boolean))
      selectedCol.DefaultValue = False
      myDatatable.Columns.Add(selectedCol)
      myDatatable.Columns.Add(New DataColumn("boqi_linenumber", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("boqi_itemName", GetType(String)))

      myDatatable.Columns.Add(New DataColumn("Expense", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Income", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Diff", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("PerCentDiff", GetType(String)))

      Return myDatatable
    End Function
#End Region

#Region "Data"
    Public Sub PopulateExpenseIncomeListing(ByVal dt As TreeTable, ByVal toDate As Date, Optional ByVal type As BOQ.WBSReportType = WBSReportType.GoodsReceipt, Optional ByVal detailed As Boolean = False, Optional ByVal noDigit As Boolean = False)
      Dim view As Integer = 45
      Select Case type
        Case WBSReportType.GoodsReceipt
          view = 45
        Case WBSReportType.MatWithdraw
          view = 31
        Case WBSReportType.PO
          view = 6
        Case WBSReportType.PR
          view = 7
      End Select
      Dim dgt As DigitConfig = DigitConfig.Price
      If noDigit Then
        dgt = DigitConfig.Int
      End If
      dt.Clear()
      For Each myWbs As WBS In Me.WBSCollection
        Dim parentNodes As TreeRow.TreeRowCollection = Nothing
        If myWbs.Parent Is myWbs Then
          parentNodes = dt.Childs
        ElseIf myWbs.Parent.Id <> 0 And myWbs.Parent.Id = myWbs.Id Then
          parentNodes = dt.Childs
        Else
          Dim parentNode As TreeRow = FindRow(dt, CType(myWbs.Parent, WBS))
          If Not parentNode Is Nothing Then
            parentNodes = parentNode.Childs
          End If
        End If
        If Not parentNodes Is Nothing Then
          Dim tr As TreeRow = parentNodes.Add
          tr("boqi_itemname") = myWbs.Code & "-" & myWbs.Name
          Dim totalExpense As Decimal = myWbs.GetActualTotal(toDate, view)
          Dim totalIncome As Decimal = myWbs.GetActualIncome(toDate, view)
          Dim totalDiff As Decimal = totalIncome - totalExpense
          tr("Expense") = Configuration.FormatToString(totalExpense, dgt)
          tr("Income") = Configuration.FormatToString(totalIncome, dgt)
          tr("Diff") = Configuration.FormatToString(totalDiff, dgt)
          tr.Tag = myWbs
          tr.State = RowExpandState.Expanded
        End If
      Next
      Dim i As Integer = 0
      For Each row As DataRow In dt.Rows
        i += 1
        row("boqi_linenumber") = i
      Next
      If i > 0 Then
        dt.AcceptChanges()
      End If
    End Sub
#End Region

#End Region


#Region "WBSMonitor"

#Region "Style"
    Public Shared Function CreateWBSItemsMonitorTableStyle() As DataGridTableStyle
      Dim dst As New DataGridTableStyle
      dst.MappingName = "BOQ"
      Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)

      Dim csLineNumber As New TreeTextColumn
      csLineNumber.MappingName = "boqi_linenumber"
      csLineNumber.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.LineNumberHeaderText}")
      csLineNumber.NullText = ""
      csLineNumber.Width = 30
      csLineNumber.DataAlignment = HorizontalAlignment.Center
      csLineNumber.ReadOnly = True
      csLineNumber.TextBox.Name = "boqi_linenumber"

      Dim csName As New PlusMinusTreeTextColumn
      csName.MappingName = "boqi_itemName"
      csName.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.DescriptionHeaderText}")
      csName.NullText = ""
      csName.Width = 180
      csName.TextBox.Name = "Description"
      csName.ReadOnly = True

      Dim csItemUnitPrice As New TreeTextColumn
      csItemUnitPrice.MappingName = "ItemUnitPrice"
      csItemUnitPrice.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.ItemUnitPriceHeaderText}")
      csItemUnitPrice.NullText = ""
      csItemUnitPrice.DataAlignment = HorizontalAlignment.Right
      csItemUnitPrice.Format = "#,###.##"
      csItemUnitPrice.TextBox.Name = "ItemUnitPrice"
      csItemUnitPrice.ReadOnly = True

      Dim csItemQty As New TreeTextColumn
      csItemQty.MappingName = "ItemQty"
      csItemQty.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.ItemQtyHeaderText}")
      csItemQty.NullText = ""
      csItemQty.DataAlignment = HorizontalAlignment.Right
      csItemQty.Format = "#,###.##"
      csItemQty.TextBox.Name = "ItemQty"
      csItemQty.ReadOnly = True

      Dim csItemUnitName As New TreeTextColumn
      csItemUnitName.MappingName = "ItemUnitName"
      csItemUnitName.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.ItemUnitNameHeaderText}")
      csItemUnitName.NullText = ""
      csItemUnitName.Width = 100
      csItemUnitName.DataAlignment = HorizontalAlignment.Center
      csItemUnitName.TextBox.Name = "ItemUnitName"
      csItemUnitName.ReadOnly = True

      Dim csBarrier0 As New DataGridBarrierColumn
      csBarrier0.MappingName = "Barrier0"
      csBarrier0.HeaderText = ""
      csBarrier0.NullText = ""
      csBarrier0.ReadOnly = True

      Dim csTotalMC As New TreeTextColumn
      csTotalMC.MappingName = "TotalMaterialCost"
      csTotalMC.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.TotalMaterialCostHeaderText}")
      csTotalMC.NullText = ""
      csTotalMC.DataAlignment = HorizontalAlignment.Right
      csTotalMC.Format = "#,###.##"
      csTotalMC.TextBox.Name = "TotalMaterialCost"
      csTotalMC.ReadOnly = True

      Dim csActualTotalMC As New TreeTextColumn
      csActualTotalMC.MappingName = "ActualMaterialCost"
      csActualTotalMC.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.ActualMaterialCostHeaderText}")
      csActualTotalMC.NullText = ""
      csActualTotalMC.DataAlignment = HorizontalAlignment.Right
      csActualTotalMC.Format = "#,###.##"
      csActualTotalMC.TextBox.Name = "ActualMaterialCost"
      csActualTotalMC.ReadOnly = True

      Dim csMatDiff As New TreeTextColumn
      csMatDiff.MappingName = "MatDiff"
      csMatDiff.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.DifferenceHeaderText}")
      csMatDiff.NullText = ""
      csMatDiff.DataAlignment = HorizontalAlignment.Right
      csMatDiff.Format = "#,###.##"
      csMatDiff.TextBox.Name = "MatDiff"
      csMatDiff.ReadOnly = True

      Dim csBarrier1 As New DataGridBarrierColumn
      csBarrier1.MappingName = "Barrier1"
      csBarrier1.HeaderText = ""
      csBarrier1.NullText = ""
      csBarrier1.ReadOnly = True

      Dim csTotalLC As New TreeTextColumn
      csTotalLC.MappingName = "TotalLaborCost"
      csTotalLC.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.TotalLaborCostHeaderText}")
      csTotalLC.NullText = ""
      csTotalLC.DataAlignment = HorizontalAlignment.Right
      csTotalLC.Format = "#,###.##"
      csTotalLC.TextBox.Name = "TotalLaborCost"
      csTotalLC.ReadOnly = True

      Dim csActualTotalLC As New TreeTextColumn
      csActualTotalLC.MappingName = "ActualLaborCost"
      csActualTotalLC.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.ActualLaborCostHeaderText}")
      csActualTotalLC.NullText = ""
      csActualTotalLC.DataAlignment = HorizontalAlignment.Right
      csActualTotalLC.Format = "#,###.##"
      csActualTotalLC.TextBox.Name = "ActualLaborCost"
      csActualTotalLC.ReadOnly = True

      Dim csLabDiff As New TreeTextColumn
      csLabDiff.MappingName = "LabDiff"
      csLabDiff.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.DifferenceHeaderText}")
      csLabDiff.NullText = ""
      csLabDiff.DataAlignment = HorizontalAlignment.Right
      csLabDiff.Format = "#,###.##"
      csLabDiff.TextBox.Name = "LabDiff"
      csLabDiff.ReadOnly = True

      Dim csBarrier2 As New DataGridBarrierColumn
      csBarrier2.MappingName = "Barrier2"
      csBarrier2.HeaderText = ""
      csBarrier2.NullText = ""
      csBarrier2.ReadOnly = True

      Dim csTotalEC As New TreeTextColumn
      csTotalEC.MappingName = "TotalEquipmentCost"
      csTotalEC.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.TotalEquipmentCostHeaderText}")
      csTotalEC.NullText = ""
      csTotalEC.DataAlignment = HorizontalAlignment.Right
      csTotalEC.Format = "#,###.##"
      csTotalEC.TextBox.Name = "TotalEquipmentCost"
      csTotalEC.ReadOnly = True

      Dim csActualTotalEC As New TreeTextColumn
      csActualTotalEC.MappingName = "ActualEquipmentCost"
      csActualTotalEC.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.ActualEquipmentCostHeaderText}")
      csActualTotalEC.NullText = ""
      csActualTotalEC.DataAlignment = HorizontalAlignment.Right
      csActualTotalEC.Format = "#,###.##"
      csActualTotalEC.TextBox.Name = "ActualEquipmentCost"
      csActualTotalEC.ReadOnly = True

      Dim csEqDiff As New TreeTextColumn
      csEqDiff.MappingName = "EqDiff"
      csEqDiff.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.DifferenceHeaderText}")
      csEqDiff.NullText = ""
      csEqDiff.DataAlignment = HorizontalAlignment.Right
      csEqDiff.Format = "#,###.##"
      csEqDiff.TextBox.Name = "EqDiff"
      csEqDiff.ReadOnly = True

      Dim csBarrier3 As New DataGridBarrierColumn
      csBarrier3.MappingName = "Barrier3"
      csBarrier3.HeaderText = ""
      csBarrier3.NullText = ""
      csBarrier3.ReadOnly = True

      Dim csTotal As New TreeTextColumn
      csTotal.MappingName = "Total"
      csTotal.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.TotalCostHeaderText}")
      csTotal.NullText = ""
      csTotal.DataAlignment = HorizontalAlignment.Right
      csTotal.Format = "#,###.##"
      csTotal.TextBox.Name = "Total"
      csTotal.ReadOnly = True

      Dim csActualTotal As New TreeTextColumn
      csActualTotal.MappingName = "Actual"
      csActualTotal.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.ActualCostHeaderText}")
      csActualTotal.NullText = ""
      csActualTotal.DataAlignment = HorizontalAlignment.Right
      csActualTotal.Format = "#,###.##"
      csActualTotal.TextBox.Name = "Actual"
      csActualTotal.ReadOnly = True

      Dim csTotalDiff As New TreeTextColumn
      csTotalDiff.MappingName = "TotalDiff"
      csTotalDiff.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.DifferenceHeaderText}")
      csTotalDiff.NullText = ""
      csTotalDiff.DataAlignment = HorizontalAlignment.Right
      csTotalDiff.Format = "#,###.##"
      csTotalDiff.TextBox.Name = "TotalDiff"
      csTotalDiff.ReadOnly = True

      Dim csTotalPercentDiff As New TreeTextColumn
      csTotalPercentDiff.MappingName = "TotalPercentDiff"
      csTotalPercentDiff.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.PercentDiffHeaderText}")
      csTotalPercentDiff.NullText = ""
      csTotalPercentDiff.DataAlignment = HorizontalAlignment.Right
      'csTotalPercentDiff.Format = "#,###.##"
      csTotalPercentDiff.TextBox.Name = "TotalPercentDiff"
      csTotalPercentDiff.ReadOnly = True

      dst.GridColumnStyles.Add(csLineNumber)
      dst.GridColumnStyles.Add(csName)
      dst.GridColumnStyles.Add(csItemUnitPrice)
      dst.GridColumnStyles.Add(csItemQty)
      dst.GridColumnStyles.Add(csItemUnitName)

      dst.GridColumnStyles.Add(csBarrier0)

      dst.GridColumnStyles.Add(csTotalMC)
      dst.GridColumnStyles.Add(csActualTotalMC)
      dst.GridColumnStyles.Add(csMatDiff)

      dst.GridColumnStyles.Add(csBarrier1)

      dst.GridColumnStyles.Add(csTotalLC)
      dst.GridColumnStyles.Add(csActualTotalLC)
      dst.GridColumnStyles.Add(csLabDiff)

      dst.GridColumnStyles.Add(csBarrier2)

      dst.GridColumnStyles.Add(csTotalEC)
      dst.GridColumnStyles.Add(csActualTotalEC)
      dst.GridColumnStyles.Add(csEqDiff)

      dst.GridColumnStyles.Add(csBarrier3)

      dst.GridColumnStyles.Add(csTotal)
      dst.GridColumnStyles.Add(csActualTotal)
      dst.GridColumnStyles.Add(csTotalDiff)
      dst.GridColumnStyles.Add(csTotalPercentDiff)

      Return dst
    End Function
    Public Shared Function CreateWBSMonitorTableStyle() As DataGridTableStyle
      Dim dst As New DataGridTableStyle
      dst.MappingName = "BOQ"
      Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)

      Dim csLineNumber As New TreeTextColumn
      csLineNumber.MappingName = "boqi_linenumber"
      csLineNumber.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.LineNumberHeaderText}")
      csLineNumber.NullText = ""
      csLineNumber.Width = 30
      csLineNumber.DataAlignment = HorizontalAlignment.Center
      csLineNumber.ReadOnly = True
      csLineNumber.TextBox.Name = "boqi_linenumber"

      Dim csName As New PlusMinusTreeTextColumn
      csName.MappingName = "boqi_itemName"
      csName.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.DescriptionHeaderText}")
      csName.NullText = ""
      csName.Width = 180
      csName.TextBox.Name = "Description"
      csName.ReadOnly = True

      Dim csBarrier0 As New DataGridBarrierColumn
      csBarrier0.MappingName = "Barrier0"
      csBarrier0.HeaderText = ""
      csBarrier0.NullText = ""
      csBarrier0.ReadOnly = True

      Dim csTotalMC As New TreeTextColumn
      csTotalMC.MappingName = "TotalMaterialCost"
      csTotalMC.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.TotalMaterialCostHeaderText}")
      csTotalMC.NullText = ""
      csTotalMC.DataAlignment = HorizontalAlignment.Right
      csTotalMC.Format = "#,###.##"
      csTotalMC.TextBox.Name = "TotalMaterialCost"
      csTotalMC.ReadOnly = True

      Dim csActualTotalMC As New TreeTextColumn
      csActualTotalMC.MappingName = "ActualMaterialCost"
      csActualTotalMC.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.ActualMaterialCostHeaderText}")
      csActualTotalMC.NullText = ""
      csActualTotalMC.DataAlignment = HorizontalAlignment.Right
      csActualTotalMC.Format = "#,###.##"
      csActualTotalMC.TextBox.Name = "ActualMaterialCost"
      csActualTotalMC.ReadOnly = True

      Dim csMatDiff As New TreeTextColumn
      csMatDiff.MappingName = "MatDiff"
      csMatDiff.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.DifferenceHeaderText}")
      csMatDiff.NullText = ""
      csMatDiff.DataAlignment = HorizontalAlignment.Right
      csMatDiff.Format = "#,###.##"
      csMatDiff.TextBox.Name = "MatDiff"
      csMatDiff.ReadOnly = True

      Dim csBarrier1 As New DataGridBarrierColumn
      csBarrier1.MappingName = "Barrier1"
      csBarrier1.HeaderText = ""
      csBarrier1.NullText = ""
      csBarrier1.ReadOnly = True

      Dim csTotalLC As New TreeTextColumn
      csTotalLC.MappingName = "TotalLaborCost"
      csTotalLC.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.TotalLaborCostHeaderText}")
      csTotalLC.NullText = ""
      csTotalLC.DataAlignment = HorizontalAlignment.Right
      csTotalLC.Format = "#,###.##"
      csTotalLC.TextBox.Name = "TotalLaborCost"
      csTotalLC.ReadOnly = True

      Dim csActualTotalLC As New TreeTextColumn
      csActualTotalLC.MappingName = "ActualLaborCost"
      csActualTotalLC.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.ActualLaborCostHeaderText}")
      csActualTotalLC.NullText = ""
      csActualTotalLC.DataAlignment = HorizontalAlignment.Right
      csActualTotalLC.Format = "#,###.##"
      csActualTotalLC.TextBox.Name = "ActualLaborCost"
      csActualTotalLC.ReadOnly = True

      Dim csLabDiff As New TreeTextColumn
      csLabDiff.MappingName = "LabDiff"
      csLabDiff.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.DifferenceHeaderText}")
      csLabDiff.NullText = ""
      csLabDiff.DataAlignment = HorizontalAlignment.Right
      csLabDiff.Format = "#,###.##"
      csLabDiff.TextBox.Name = "LabDiff"
      csLabDiff.ReadOnly = True

      Dim csBarrier2 As New DataGridBarrierColumn
      csBarrier2.MappingName = "Barrier2"
      csBarrier2.HeaderText = ""
      csBarrier2.NullText = ""
      csBarrier2.ReadOnly = True

      Dim csTotalEC As New TreeTextColumn
      csTotalEC.MappingName = "TotalEquipmentCost"
      csTotalEC.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.TotalEquipmentCostHeaderText}")
      csTotalEC.NullText = ""
      csTotalEC.DataAlignment = HorizontalAlignment.Right
      csTotalEC.Format = "#,###.##"
      csTotalEC.TextBox.Name = "TotalEquipmentCost"
      csTotalEC.ReadOnly = True

      Dim csActualTotalEC As New TreeTextColumn
      csActualTotalEC.MappingName = "ActualEquipmentCost"
      csActualTotalEC.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.ActualEquipmentCostHeaderText}")
      csActualTotalEC.NullText = ""
      csActualTotalEC.DataAlignment = HorizontalAlignment.Right
      csActualTotalEC.Format = "#,###.##"
      csActualTotalEC.TextBox.Name = "ActualEquipmentCost"
      csActualTotalEC.ReadOnly = True

      Dim csEqDiff As New TreeTextColumn
      csEqDiff.MappingName = "EqDiff"
      csEqDiff.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.DifferenceHeaderText}")
      csEqDiff.NullText = ""
      csEqDiff.DataAlignment = HorizontalAlignment.Right
      csEqDiff.Format = "#,###.##"
      csEqDiff.TextBox.Name = "EqDiff"
      csEqDiff.ReadOnly = True

      Dim csBarrier3 As New DataGridBarrierColumn
      csBarrier3.MappingName = "Barrier3"
      csBarrier3.HeaderText = ""
      csBarrier3.NullText = ""
      csBarrier3.ReadOnly = True

      Dim csTotal As New TreeTextColumn
      csTotal.MappingName = "Total"
      csTotal.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.TotalCostHeaderText}")
      csTotal.NullText = ""
      csTotal.DataAlignment = HorizontalAlignment.Right
      csTotal.Format = "#,###.##"
      csTotal.TextBox.Name = "Total"
      csTotal.ReadOnly = True

      Dim csActualTotal As New TreeTextColumn
      csActualTotal.MappingName = "Actual"
      csActualTotal.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.ActualCostHeaderText}")
      csActualTotal.NullText = ""
      csActualTotal.DataAlignment = HorizontalAlignment.Right
      csActualTotal.Format = "#,###.##"
      csActualTotal.TextBox.Name = "Actual"
      csActualTotal.ReadOnly = True

      Dim csTotalDiff As New TreeTextColumn
      csTotalDiff.MappingName = "TotalDiff"
      csTotalDiff.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.DifferenceHeaderText}")
      csTotalDiff.NullText = ""
      csTotalDiff.DataAlignment = HorizontalAlignment.Right
      csTotalDiff.Format = "#,###.##"
      csTotalDiff.TextBox.Name = "TotalDiff"
      csTotalDiff.ReadOnly = True

      Dim csTotalPercentDiff As New TreeTextColumn
      csTotalPercentDiff.MappingName = "TotalPercentDiff"
      csTotalPercentDiff.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.PercentDiffHeaderText}")
      csTotalPercentDiff.NullText = ""
      csTotalPercentDiff.DataAlignment = HorizontalAlignment.Right
      'csTotalPercentDiff.Format = "#,###.##"
      csTotalPercentDiff.TextBox.Name = "TotalPercentDiff"
      csTotalPercentDiff.ReadOnly = True

      dst.GridColumnStyles.Add(csLineNumber)
      dst.GridColumnStyles.Add(csName)

      dst.GridColumnStyles.Add(csBarrier0)

      dst.GridColumnStyles.Add(csTotalMC)
      dst.GridColumnStyles.Add(csActualTotalMC)
      dst.GridColumnStyles.Add(csMatDiff)

      dst.GridColumnStyles.Add(csBarrier1)

      dst.GridColumnStyles.Add(csTotalLC)
      dst.GridColumnStyles.Add(csActualTotalLC)
      dst.GridColumnStyles.Add(csLabDiff)

      dst.GridColumnStyles.Add(csBarrier2)

      dst.GridColumnStyles.Add(csTotalEC)
      dst.GridColumnStyles.Add(csActualTotalEC)
      dst.GridColumnStyles.Add(csEqDiff)

      dst.GridColumnStyles.Add(csBarrier3)

      dst.GridColumnStyles.Add(csTotal)
      dst.GridColumnStyles.Add(csActualTotal)
      dst.GridColumnStyles.Add(csTotalDiff)
      dst.GridColumnStyles.Add(csTotalPercentDiff)

      Return dst
    End Function
#End Region

#Region "Schema"
    Public Shared Function GetWBSItemsMonitorSchemaTable() As TreeTable
      Dim myDatatable As New TreeTable("BOQ")
      Dim selectedCol As New DataColumn("Selected", GetType(Boolean))
      selectedCol.DefaultValue = False
      myDatatable.Columns.Add(selectedCol)
      myDatatable.Columns.Add(New DataColumn("boqi_linenumber", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("boqi_itemName", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("ItemUnitPrice", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("ItemQty", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("ItemUnitName", GetType(String)))

      myDatatable.Columns.Add(New DataColumn("Barrier0", GetType(String)))


      myDatatable.Columns.Add(New DataColumn("MatQty", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("MatUnitPrice", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("TotalMaterialCost", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("ActualMaterialCost", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("MatDiff", GetType(String)))

      myDatatable.Columns.Add(New DataColumn("Barrier1", GetType(String)))

      myDatatable.Columns.Add(New DataColumn("LaborQty", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("LaborUnitPrice", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("TotalLaborCost", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("ActualLaborCost", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("LabDiff", GetType(String)))

      myDatatable.Columns.Add(New DataColumn("Barrier2", GetType(String)))

      myDatatable.Columns.Add(New DataColumn("EquipmentQty", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("EquipmentUnitPrice", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("TotalEquipmentCost", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("ActualEquipmentCost", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("EqDiff", GetType(String)))

      myDatatable.Columns.Add(New DataColumn("Barrier3", GetType(String)))

      myDatatable.Columns.Add(New DataColumn("Qty", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("UnitPrice", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Total", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Actual", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("TotalDiff", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("TotalPerCentDiff", GetType(String)))

      Return myDatatable
    End Function
    Public Shared Function GetWBSMonitorSchemaTable() As TreeTable
      Dim myDatatable As New TreeTable("BOQ")
      Dim selectedCol As New DataColumn("Selected", GetType(Boolean))
      selectedCol.DefaultValue = False
      myDatatable.Columns.Add(selectedCol)
      myDatatable.Columns.Add(New DataColumn("boqi_linenumber", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("boqi_itemName", GetType(String)))

      myDatatable.Columns.Add(New DataColumn("Barrier0", GetType(String)))

      myDatatable.Columns.Add(New DataColumn("TotalMaterialCost", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("ActualMaterialCost", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("MatDiff", GetType(String)))

      myDatatable.Columns.Add(New DataColumn("Barrier1", GetType(String)))

      myDatatable.Columns.Add(New DataColumn("TotalLaborCost", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("ActualLaborCost", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("LabDiff", GetType(String)))

      myDatatable.Columns.Add(New DataColumn("Barrier2", GetType(String)))

      myDatatable.Columns.Add(New DataColumn("TotalEquipmentCost", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("ActualEquipmentCost", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("EqDiff", GetType(String)))

      myDatatable.Columns.Add(New DataColumn("Barrier3", GetType(String)))

      myDatatable.Columns.Add(New DataColumn("Total", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Actual", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("TotalDiff", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("TotalPercentDiff", GetType(String)))

      Return myDatatable
    End Function
#End Region

#Region "Data"

#Region "Master"
    Public Enum WBSReportType
      PR = 7
      PO = 6
      GoodsReceipt = 45
      MatWithdraw = 31
    End Enum
    Private m_WBSReportType As WBSReportType = WBSReportType.GoodsReceipt
    Private Function GetAmountFromSproc(ByVal sproc As String, ByVal toDate As Date, ByVal view As Integer, ByVal requestor As Integer) As Decimal
      Try
        Dim ds As DataSet = SqlHelper.ExecuteDataset( _
                Me.ConnectionString _
                , CommandType.StoredProcedure _
                , sproc _
                , New SqlParameter("@boq_id", Me.Id) _
                , New SqlParameter("@toDate", toDate) _
                , New SqlParameter("@view", view) _
                , New SqlParameter("@requestor", IIf(requestor = -99, DBNull.Value, requestor)) _
                )
        'MsgBox(requestor.ToString)
        Dim tableIndex As Integer = 0
        'Select Case m_WBSReportType
        '    Case WBSReportType.GoodsReceipt, WBSReportType.MatWithdraw
        '        tableIndex = 0
        '    Case WBSReportType.PR
        '        tableIndex = 1
        '    Case WBSReportType.PO
        '        tableIndex = 2
        'End Select
        If ds.Tables.Count > tableIndex Then
          If ds.Tables(tableIndex).Rows.Count > 0 Then
            If ds.Tables(tableIndex).Rows(0).IsNull(0) Then
              Return 0
            End If
            Return CDec(ds.Tables(tableIndex).Rows(0)(0))
          End If
        End If
      Catch ex As Exception
      End Try
    End Function
    Public Function GetActualOverhead(ByVal toDate As Date, ByVal view As Integer, Optional ByVal detailed As Integer = 0, Optional ByVal requestor As Integer = -99) As Decimal
      Dim sproc As String = ""
      Select Case detailed
        Case 0
          sproc = "GetActualOverheadForBoq"
        Case 1
          sproc = "GetActualOverheadForBoqDetailed"
        Case 2
          sproc = "GetActualOverheadForBoqDetailedList"
      End Select
      Return Me.GetAmountFromSproc(sproc, toDate, view, requestor)
    End Function
    Public Function GetActualTotal(ByVal toDate As Date, ByVal view As Integer, Optional ByVal detailed As Integer = 0, Optional ByVal requestor As Integer = -99) As Decimal
      Dim sproc As String = ""
      Select Case detailed
        Case 0
          sproc = "GetActualTotalForBoq"
        Case 1
          sproc = "GetActualTotalForBoqDetailed"
        Case 2
          sproc = "GetActualTotalForBoqDetailedList"
      End Select
      Return Me.GetAmountFromSproc(sproc, toDate, view, requestor)
    End Function
    Public Sub PopulateWBSMonitorListing(ByVal tm As TreeManager, ByVal toDate As Date, Optional ByVal type As WBSReportType = WBSReportType.GoodsReceipt, Optional ByVal detailed As Integer = 0, Optional ByVal noDigit As Boolean = False, Optional ByVal requestor As Integer = -99)
      m_WBSReportType = type
      WBS.WBSReportType = type
      Dim view As Integer = 45
      Select Case type
        Case WBSReportType.GoodsReceipt
          view = 45
        Case WBSReportType.MatWithdraw
          view = 31
        Case WBSReportType.PO
          view = 6
        Case WBSReportType.PR
          view = 7
      End Select
      Dim dt As TreeTable = CType(tm.Treetable.Clone, TreeTable)
      Select Case detailed
        Case 0
          PopulateWBSMonitorListing(dt, toDate, view, noDigit, requestor)
        Case 1
          PopulateWBSMonitorListingDetailed(dt, toDate, view, noDigit, requestor)
        Case 2
          PopulateWBSMonitorListingDetailedItemList(dt, toDate, view, noDigit, requestor)
        Case 3
          PopulateWBSMonitorListingDetailedItemOnlyList(dt, toDate, view, noDigit, requestor)
      End Select
      tm.Treetable = dt
      dt.AcceptChanges()
    End Sub
    Private Function GetActualTable(ByVal sproc As String, ByVal toDate As Date, ByVal id As Integer, ByVal isMarkup As Boolean, ByVal view As Integer, ByVal requestor As Integer) As DataTable
      Try
        Dim ds As DataSet = SqlHelper.ExecuteDataset( _
                ConnectionString _
                , CommandType.StoredProcedure _
                , sproc _
                , New SqlParameter("@boq_id", id) _
                , New SqlParameter("@toDate", toDate) _
                , New SqlParameter("@stockiw_ismarkup", isMarkup) _
                , New SqlParameter("@view", view) _
                , New SqlParameter("@requestor", IIf(requestor = -99, DBNull.Value, requestor)) _
                )
        Dim tableIndex As Integer = 0
        If ds.Tables.Count > tableIndex Then
          If ds.Tables(tableIndex).Rows.Count > 0 Then
            Return ds.Tables(tableIndex)
          End If
        End If
      Catch ex As Exception
      End Try
    End Function
#End Region

#Region "Basic"
    Private Function GetWBSActualFromDatatable(ByVal dt As DataTable, ByVal wbs As WBS, ByVal column As String) As Decimal
      If dt Is Nothing Then
        Return 0
      End If
      Dim ret As Decimal = 0
      For Each row As DataRow In dt.Select("wbs_path like('" & wbs.Path & "%')")
        If IsNumeric(row(column)) Then
          ret += CDec(row(column))
        End If
      Next
      Return ret
    End Function
    Private Sub PopulateWBSMonitorListing(ByVal dt As TreeTable, ByVal toDate As Date, ByVal view As Integer, Optional ByVal noDigit As Boolean = False, Optional ByVal requestor As Integer = -99)
      dt.Clear()
      Dim dgt As DigitConfig = DigitConfig.Price
      If noDigit Then
        dgt = DigitConfig.Int
      End If
      Dim actualDT As DataTable = GetActualTable("GetAmountForWbs", toDate, Me.Id, False, view, requestor)

      For Each myWbs As WBS In Me.WBSCollection
        Dim parentNodes As TreeRow.TreeRowCollection = Nothing
        If myWbs.Parent Is myWbs Then
          parentNodes = dt.Childs
        ElseIf myWbs.Parent.Id <> 0 And myWbs.Parent.Id = myWbs.Id Then
          parentNodes = dt.Childs
        Else
          Dim parentNode As TreeRow = FindRow(dt, CType(myWbs.Parent, WBS))
          If Not parentNode Is Nothing Then
            parentNodes = parentNode.Childs
          End If
        End If
        If Not parentNodes Is Nothing Then
          Dim tr As TreeRow = parentNodes.Add
          tr("boqi_itemname") = myWbs.Code & "-" & myWbs.Name

          Dim matBudget As Decimal = myWbs.GetTotalMat
          Dim matActual As Decimal = Me.GetWBSActualFromDatatable(actualDT, myWbs, "actualmat") 'myWbs.GetActualMat(toDate, view, requestor)
          Dim matDiff As Decimal = matBudget - matActual
          tr("TotalMaterialCost") = Configuration.FormatToString(matBudget, dgt)
          tr("ActualMaterialCost") = Configuration.FormatToString(matActual, dgt)
          tr("MatDiff") = Configuration.FormatToString(matDiff, dgt)

          Dim labBudget As Decimal = myWbs.GetTotalLab
          Dim labActual As Decimal = Me.GetWBSActualFromDatatable(actualDT, myWbs, "actuallab") 'myWbs.GetActualLab(toDate, view, requestor)
          Dim labDiff As Decimal = labBudget - labActual
          tr("TotalLaborCost") = Configuration.FormatToString(labBudget, dgt)
          tr("ActualLaborCost") = Configuration.FormatToString(labActual, dgt)
          tr("LabDiff") = Configuration.FormatToString(labDiff, dgt)

          Dim eqBudget As Decimal = myWbs.GetTotalEq
          Dim eqActual As Decimal = Me.GetWBSActualFromDatatable(actualDT, myWbs, "actualeq") 'myWbs.GetActualEq(toDate, view, requestor)
          Dim eqDiff As Decimal = eqBudget - eqActual
          tr("TotalEquipmentCost") = Configuration.FormatToString(eqBudget, dgt)
          tr("ActualEquipmentCost") = Configuration.FormatToString(eqActual, dgt)
          tr("EqDiff") = Configuration.FormatToString(eqDiff, dgt)

          Dim totalBudget As Decimal = myWbs.GetTotal
          Dim totalActual As Decimal = matActual + labActual + eqActual 'myWbs.GetActualTotal(toDate, view, requestor)
          Dim totalDiff As Decimal = totalBudget - totalActual
          tr("Total") = Configuration.FormatToString(totalBudget, dgt)
          tr("Actual") = Configuration.FormatToString(totalActual, dgt)
          tr("TotalDiff") = Configuration.FormatToString(totalDiff, dgt)
          tr.Tag = myWbs
          tr.State = RowExpandState.Expanded
        End If
      Next
      PopulateWBSMonitorOverHead(dt, toDate, view, noDigit, requestor)
      Dim totalRow As TreeRow = dt.Childs.Add
      Dim totalTotalBudget As Decimal = Me.TotalBudget 'Me.FinalBidPrice
      Dim totalTotalActual As Decimal = Me.GetActualTotal(toDate, view, , requestor) + Me.GetActualOverhead(toDate, view, , requestor)  '****** Undone:Neng
      Dim totalTotalDiff As Decimal = totalTotalBudget - totalTotalActual
      totalRow("boqi_itemname") = Me.StringParserService.Parse("${res:Global.Total}")
      totalRow("Total") = Configuration.FormatToString(totalTotalBudget, dgt)
      totalRow("Actual") = Configuration.FormatToString(totalTotalActual, dgt)
      totalRow("TotalDiff") = Configuration.FormatToString(totalTotalDiff, dgt)
      totalRow.State = RowExpandState.UnderParent
      PopulateWBSMonitorProfit(dt, toDate, view, noDigit, requestor)
      Dim actualProfitRow As TreeRow = dt.Childs.Add
      actualProfitRow("boqi_itemname") = Me.StringParserService.Parse("กำไร(ขาดทุน)สุทธิ") 'Hack
      actualProfitRow("Total") = Configuration.FormatToString(Me.Profit + totalTotalDiff, dgt)
      actualProfitRow("Actual") = Configuration.FormatToString(0, dgt)
      actualProfitRow("TotalDiff") = Configuration.FormatToString(Me.Profit + totalTotalDiff, dgt)
      actualProfitRow.State = RowExpandState.UnderParent
      Dim i As Integer = 0
      For Each row As DataRow In dt.Rows
        i += 1
        row("boqi_linenumber") = i
      Next
      If i > 0 Then
        dt.AcceptChanges()
      End If
    End Sub
    Private Sub PopulateWBSMonitorOverHead(ByVal dt As TreeTable, ByVal toDate As Date, ByVal view As Integer, Optional ByVal noDigit As Boolean = False, Optional ByVal requestor As Integer = -99)
      Dim dgt As DigitConfig = DigitConfig.Price
      If noDigit Then
        dgt = DigitConfig.Int
      End If
      Dim overheadNode As TreeRow = dt.Childs.Add
      Dim overheadBudget As Decimal = Me.Overhead
      Dim overheadActual As Decimal = Me.GetActualOverhead(toDate, view, , requestor)
      Dim overheadDiff As Decimal = overheadBudget - overheadActual
      overheadNode("boqi_itemName") = Me.StringParserService.Parse("${res:Global.Overhead}")
      overheadNode("Total") = Configuration.FormatToString(overheadBudget, dgt)
      overheadNode("Actual") = Configuration.FormatToString(overheadActual, dgt)
      overheadNode("TotalDiff") = Configuration.FormatToString(overheadDiff, dgt)
      overheadNode.State = RowExpandState.Expanded
      Dim parentNode As TreeRow = Nothing
      For Each mu As Markup In Me.MarkupCollection
        If mu.Type.GroupId = 0 AndAlso mu.TotalAmount > 0 Then
          If parentNode Is Nothing OrElse (mu.Type.Description <> parentNode("boqi_itemName").ToString) Then
            parentNode = overheadNode.Childs.Add
            Dim parentBudget As Decimal = Me.MarkupCollection.GetAmountForType(mu.Type.Value)
            Dim parentActual As Decimal = Me.MarkupCollection.GetActualAmountForType(mu.Type.Value, toDate, view, requestor) '****** Undone:Neng
            Dim parentDiff As Decimal = parentBudget - parentActual
            parentNode("boqi_itemName") = mu.Type.Description
            parentNode("Total") = Configuration.FormatToString(parentBudget, dgt)
            parentNode("Actual") = Configuration.FormatToString(parentActual, dgt)
            parentNode("TotalDiff") = Configuration.FormatToString(parentDiff, dgt)
            parentNode.State = RowExpandState.Expanded
          End If
          Dim childNode As TreeRow = parentNode.Childs.Add
          Dim childBudget As Decimal = mu.TotalAmount
          Dim childActual As Decimal = mu.GetActualTotal(toDate, view, requestor) '****** Undone:Neng
          Dim childDiff As Decimal = childBudget - childActual
          childNode("boqi_itemName") = mu.Name '****** Undone:Neng
          childNode("Total") = Configuration.FormatToString(childBudget, dgt)
          childNode("Actual") = Configuration.FormatToString(childActual, dgt)
          childNode("TotalDiff") = Configuration.FormatToString(childDiff, dgt)
        End If
      Next
    End Sub
    Private Sub PopulateWBSMonitorProfit(ByVal dt As TreeTable, ByVal toDate As Date, ByVal view As Integer, Optional ByVal noDigit As Boolean = False, Optional ByVal requestor As Integer = -99)
      Dim dgt As DigitConfig = DigitConfig.Price
      If noDigit Then
        dgt = DigitConfig.Int
      End If
      Dim parentNode As TreeRow = Nothing
      For Each mu As Markup In Me.MarkupCollection
        If mu.Type.GroupId = 1 AndAlso mu.TotalAmount > 0 Then
          If parentNode Is Nothing OrElse (mu.Type.Description <> parentNode("boqi_itemName").ToString) Then
            parentNode = dt.Childs.Add
            Dim parentBudget As Decimal = Me.Profit
            Dim parentActual As Decimal = 0
            Dim parentDiff As Decimal = parentBudget - parentActual
            parentNode("boqi_itemName") = mu.Type.Description & "<ประเมิน>" 'Hack
            parentNode("Total") = Configuration.FormatToString(parentBudget, dgt)
            parentNode("Actual") = Configuration.FormatToString(parentActual, dgt)
            parentNode("TotalDiff") = Configuration.FormatToString(parentDiff, dgt)
            parentNode.State = RowExpandState.Expanded
          End If
          Dim childNode As TreeRow = parentNode.Childs.Add
          Dim childBudget As Decimal = mu.TotalAmount
          Dim childActual As Decimal = 0
          Dim childDiff As Decimal = childBudget - childActual
          childNode("boqi_itemName") = mu.Name & "<ประเมิน>" 'Hack
          childNode("Total") = Configuration.FormatToString(childBudget, dgt)
          childNode("Actual") = Configuration.FormatToString(childActual, dgt)
          childNode("TotalDiff") = Configuration.FormatToString(childDiff, dgt)
        End If
      Next
    End Sub
#End Region

#Region "Detailed"
    Private Sub PopulateWBSMonitorListingDetailed(ByVal dt As TreeTable, ByVal toDate As Date, ByVal view As Integer, Optional ByVal noDigit As Boolean = False, Optional ByVal requestor As Integer = -99)
      dt.Clear()
      Dim dgt As DigitConfig = DigitConfig.Price
      If noDigit Then
        dgt = DigitConfig.Int
      End If
      Dim actualDT As DataTable = GetActualTable("GetAmountForWbs", toDate, Me.Id, False, view, requestor)

      For Each myWbs As WBS In Me.WBSCollection
        Dim parentNodes As TreeRow.TreeRowCollection = Nothing
        If myWbs.Parent Is myWbs Then
          parentNodes = dt.Childs
        ElseIf myWbs.Parent.Id <> 0 And myWbs.Parent.Id = myWbs.Id Then
          parentNodes = dt.Childs
        Else
          Dim parentNode As TreeRow = FindRow(dt, CType(myWbs.Parent, WBS))
          If Not parentNode Is Nothing Then
            parentNodes = parentNode.Childs
          End If
        End If
        If Not parentNodes Is Nothing Then
          Dim tr As TreeRow = parentNodes.Add
          tr("boqi_itemname") = myWbs.Code & "-" & myWbs.Name

          Dim matBudget As Decimal = myWbs.GetTotalMat
          Dim matActual As Decimal = Me.GetWBSActualFromDatatable(actualDT, myWbs, "actualmat") 'myWbs.GetActualMat(toDate, view, requestor)
          Dim matDiff As Decimal = matBudget - matActual
          tr("TotalMaterialCost") = Configuration.FormatToString(matBudget, dgt)
          tr("ActualMaterialCost") = Configuration.FormatToString(matActual, dgt)
          tr("MatDiff") = Configuration.FormatToString(matDiff, dgt)

          Dim labBudget As Decimal = myWbs.GetTotalLab
          Dim labActual As Decimal = Me.GetWBSActualFromDatatable(actualDT, myWbs, "actuallab") 'myWbs.GetActualLab(toDate, view, requestor)
          Dim labDiff As Decimal = labBudget - labActual
          tr("TotalLaborCost") = Configuration.FormatToString(labBudget, dgt)
          tr("ActualLaborCost") = Configuration.FormatToString(labActual, dgt)
          tr("LabDiff") = Configuration.FormatToString(labDiff, dgt)

          Dim eqBudget As Decimal = myWbs.GetTotalEq
          Dim eqActual As Decimal = Me.GetWBSActualFromDatatable(actualDT, myWbs, "actualeq") 'myWbs.GetActualEq(toDate, view, requestor)
          Dim eqDiff As Decimal = eqBudget - eqActual
          tr("TotalEquipmentCost") = Configuration.FormatToString(eqBudget, dgt)
          tr("ActualEquipmentCost") = Configuration.FormatToString(eqActual, dgt)
          tr("EqDiff") = Configuration.FormatToString(eqDiff, dgt)

          Dim totalBudget As Decimal = myWbs.GetTotal
          Dim totalActual As Decimal = matActual + labActual + eqActual 'myWbs.GetActualTotal(toDate, view, requestor)
          Dim totalDiff As Decimal = totalBudget - totalActual
          tr("Total") = Configuration.FormatToString(totalBudget, dgt)
          tr("Actual") = Configuration.FormatToString(totalActual, dgt)
          tr("TotalDiff") = Configuration.FormatToString(totalDiff, dgt)
          tr.Tag = myWbs
          tr.State = RowExpandState.Expanded

          Dim docTable As DataTable = myWbs.GetActualDocTable(toDate, view, requestor)
          If Not docTable Is Nothing Then
            For Each myRow As DataRow In docTable.Rows
              Dim docRow As TreeRow = tr.Childs.Add
              docRow("boqi_itemname") = myRow("DocCode")
              Dim docMat As Decimal = 0
              Dim docLab As Decimal = 0
              Dim docEq As Decimal = 0
              Dim docTotal As Decimal = 0

              If IsNumeric(myRow.IsNull("DocMat")) Then
                docMat = CDec(myRow("DocMat"))
              End If
              If IsNumeric(myRow.IsNull("DocLab")) Then
                docLab = CDec(myRow("DocLab"))
              End If
              If IsNumeric(myRow.IsNull("DocEq")) Then
                docEq = CDec(myRow("DocEq"))
              End If
              docTotal = docMat + docLab + docEq

              docRow("ActualMaterialCost") = Configuration.FormatToString(docMat, dgt)
              docRow("ActualLaborCost") = Configuration.FormatToString(docLab, dgt)
              docRow("ActualEquipmentCost") = Configuration.FormatToString(docEq, dgt)
              docRow("Actual") = Configuration.FormatToString(docTotal, dgt)
              'docRow.Tag = myWbs
              'docRow.State = RowExpandState.Expanded
            Next
          End If
        End If
      Next
      PopulateWBSMonitorOverHeadDetailed(dt, toDate, view, noDigit, requestor)
      Dim totalRow As TreeRow = dt.Childs.Add
      Dim totalTotalBudget As Decimal = Me.TotalBudget 'Me.FinalBidPrice
      Dim totalTotalActual As Decimal = Me.GetActualTotal(toDate, view, , requestor) + Me.GetActualOverhead(toDate, view, , requestor) '****** Undone:Neng
      Dim totalTotalDiff As Decimal = totalTotalBudget - totalTotalActual
      totalRow("boqi_itemname") = Me.StringParserService.Parse("${res:Global.Total}")
      totalRow("Total") = Configuration.FormatToString(totalTotalBudget, dgt)
      totalRow("Actual") = Configuration.FormatToString(totalTotalActual, dgt)
      totalRow("TotalDiff") = Configuration.FormatToString(totalTotalDiff, dgt)
      totalRow.State = RowExpandState.UnderParent
      PopulateWBSMonitorProfitDetailed(dt, toDate, view, noDigit, requestor)
      Dim actualProfitRow As TreeRow = dt.Childs.Add
      actualProfitRow("boqi_itemname") = Me.StringParserService.Parse("กำไร(ขาดทุน)สุทธิ") 'Hack
      actualProfitRow("Total") = Configuration.FormatToString(Me.Profit + totalTotalDiff, dgt)
      actualProfitRow("Actual") = Configuration.FormatToString(0, dgt)
      actualProfitRow("TotalDiff") = Configuration.FormatToString(Me.Profit + totalTotalDiff, dgt)
      actualProfitRow.State = RowExpandState.UnderParent
      Dim i As Integer = 0
      For Each row As DataRow In dt.Rows
        i += 1
        row("boqi_linenumber") = i
      Next
      If i > 0 Then
        dt.AcceptChanges()
      End If
    End Sub
    Private Sub PopulateWBSMonitorOverHeadDetailed(ByVal dt As TreeTable, ByVal toDate As Date, ByVal view As Integer, Optional ByVal noDigit As Boolean = False, Optional ByVal requestor As Integer = -99)
      Dim dgt As DigitConfig = DigitConfig.Price
      If noDigit Then
        dgt = DigitConfig.Int
      End If
      Dim overheadNode As TreeRow = dt.Childs.Add
      Dim overheadBudget As Decimal = Me.Overhead
      Dim overheadActual As Decimal = Me.GetActualOverhead(toDate, view, , requestor) '****** Undone:Neng
      Dim overheadDiff As Decimal = overheadBudget - overheadActual
      overheadNode("boqi_itemName") = Me.StringParserService.Parse("${res:Global.Overhead}")
      overheadNode("Total") = Configuration.FormatToString(overheadBudget, dgt)
      overheadNode("Actual") = Configuration.FormatToString(overheadActual, dgt)
      overheadNode("TotalDiff") = Configuration.FormatToString(overheadDiff, dgt)
      If overheadBudget = 0 Then
        overheadNode("TotalPercentDiff") = Configuration.FormatToString(0, dgt) & " %"
      Else
        overheadNode("TotalPercentDiff") = Configuration.FormatToString((overheadDiff / overheadBudget) * 100, dgt) & " %"
      End If
      overheadNode.State = RowExpandState.Expanded
      Dim parentNode As TreeRow = Nothing
      For Each mu As Markup In Me.MarkupCollection
        If mu.Type.GroupId = 0 AndAlso mu.TotalAmount > 0 Then
          If parentNode Is Nothing OrElse (mu.Type.Description <> parentNode("boqi_itemName").ToString) Then
            parentNode = overheadNode.Childs.Add
            Dim parentBudget As Decimal = Me.MarkupCollection.GetAmountForType(mu.Type.Value)
            Dim parentActual As Decimal = Me.MarkupCollection.GetActualAmountForType(mu.Type.Value, toDate, view, requestor) '****** Undone:Neng
            Dim parentDiff As Decimal = parentBudget - parentActual
            parentNode("boqi_itemName") = mu.Type.Description
            parentNode("Total") = Configuration.FormatToString(parentBudget, dgt)
            parentNode("Actual") = Configuration.FormatToString(parentActual, dgt)
            parentNode("TotalDiff") = Configuration.FormatToString(parentDiff, dgt)
            If parentBudget = 0 Then
              parentNode("TotalPercentDiff") = Configuration.FormatToString(0, dgt) & " %"
            Else
              parentNode("TotalPercentDiff") = Configuration.FormatToString((parentDiff / parentBudget) * 100, dgt) & " %"
            End If
            parentNode.State = RowExpandState.Expanded
          End If
          Dim childNode As TreeRow = parentNode.Childs.Add
          Dim childBudget As Decimal = mu.TotalAmount
          Dim childActual As Decimal = mu.GetActualTotal(toDate, view, requestor) '****** Undone:Neng
          Dim childDiff As Decimal = childBudget - childActual
          childNode("boqi_itemName") = mu.Name '****** Undone:Neng
          childNode("Total") = Configuration.FormatToString(childBudget, dgt)
          childNode("Actual") = Configuration.FormatToString(childActual, dgt)
          childNode("TotalDiff") = Configuration.FormatToString(childDiff, dgt)
          If childBudget = 0 Then
            childNode("TotalPercentDiff") = Configuration.FormatToString(0, dgt) & " %"
          Else
            childNode("TotalPercentDiff") = Configuration.FormatToString((childDiff / childBudget) * 100, dgt) & " %"
          End If
          Dim docTable As DataTable = mu.GetActualDocTable(toDate, view, requestor)
          If Not docTable Is Nothing Then
            For Each myRow As DataRow In docTable.Rows
              Dim docRow As TreeRow = childNode.Childs.Add
              docRow("boqi_itemname") = myRow("DocCode")

              Dim docTotal As Decimal = 0

              If IsNumeric(myRow.IsNull("DocAmount")) Then
                docTotal = CDec(myRow("DocAmount"))
              End If

              docRow("Actual") = Configuration.FormatToString(docTotal, dgt)
              'docRow.Tag = myWbs
              'docRow.State = RowExpandState.Expanded

              Dim ItemTable As DataTable = mu.GetActualItemTable(toDate, view, CInt(myRow("DocId")), requestor)
              If Not ItemTable Is Nothing Then
                For Each myItemRow As DataRow In ItemTable.Rows
                  Dim itemRow As TreeRow = docRow.Childs.Add
                  itemRow("boqi_itemname") = myItemRow("ItemCode").ToString & " : " & myItemRow("ItemName").ToString
                  Dim itemMat As Decimal = 0
                  Dim itemLab As Decimal = 0
                  Dim itemEq As Decimal = 0
                  Dim itemTotal As Decimal = 0

                  If IsNumeric(myItemRow.IsNull("itemMat")) Then
                    itemMat = CDec(myItemRow("itemMat"))
                  End If
                  If IsNumeric(myItemRow.IsNull("itemLab")) Then
                    itemLab = CDec(myItemRow("itemLab"))
                  End If
                  If IsNumeric(myItemRow.IsNull("itemEq")) Then
                    itemEq = CDec(myItemRow("itemEq"))
                  End If
                  itemTotal = itemMat + itemLab + itemEq

                  itemRow("ActualMaterialCost") = Configuration.FormatToString(itemMat, dgt)
                  itemRow("ActualLaborCost") = Configuration.FormatToString(itemLab, dgt)
                  itemRow("ActualEquipmentCost") = Configuration.FormatToString(itemEq, dgt)
                  itemRow("Actual") = Configuration.FormatToString(itemTotal, dgt)
                  'itemRow.Tag = myWbs
                  'itemRow.State = RowExpandState.Expanded
                  'itemRow.AcceptChanges()
                Next
              End If
            Next
          End If
        End If
      Next
    End Sub
    Private Sub PopulateWBSMonitorProfitDetailed(ByVal dt As TreeTable, ByVal toDate As Date, ByVal view As Integer, Optional ByVal noDigit As Boolean = False, Optional ByVal requestor As Integer = -99)
      Dim dgt As DigitConfig = DigitConfig.Price
      If noDigit Then
        dgt = DigitConfig.Int
      End If
      Dim parentNode As TreeRow = Nothing
      For Each mu As Markup In Me.MarkupCollection
        If mu.Type.GroupId = 1 AndAlso mu.TotalAmount > 0 Then
          If parentNode Is Nothing OrElse (mu.Type.Description <> parentNode("boqi_itemName").ToString) Then
            parentNode = dt.Childs.Add
            Dim parentBudget As Decimal = Me.Profit
            Dim parentActual As Decimal = 0
            Dim parentDiff As Decimal = parentBudget - parentActual
            parentNode("boqi_itemName") = mu.Type.Description & "<ประเมิน>" 'Hack
            parentNode("Total") = Configuration.FormatToString(parentBudget, dgt)
            parentNode("Actual") = Configuration.FormatToString(parentActual, dgt)
            parentNode("TotalDiff") = Configuration.FormatToString(parentDiff, dgt)
            If parentBudget = 0 Then
              parentNode("TotalPercentDiff") = Configuration.FormatToString(0, dgt) & " %"
            Else
              parentNode("TotalPercentDiff") = Configuration.FormatToString((parentDiff / parentBudget) * 100, dgt) & " %"
            End If
            parentNode.State = RowExpandState.Expanded
          End If
          Dim childNode As TreeRow = parentNode.Childs.Add
          Dim childBudget As Decimal = mu.TotalAmount
          Dim childActual As Decimal = 0 '****** Undone
          Dim childDiff As Decimal = childBudget - childActual
          childNode("boqi_itemName") = mu.Name & "<ประเมิน>" 'Hack
          childNode("Total") = Configuration.FormatToString(childBudget, dgt)
          childNode("Actual") = Configuration.FormatToString(childActual, dgt)
          childNode("TotalDiff") = Configuration.FormatToString(childDiff, dgt)
          If childBudget = 0 Then
            childNode("TotalPercentDiff") = Configuration.FormatToString(0, dgt) & " %"
          Else
            childNode("TotalPercentDiff") = Configuration.FormatToString((childDiff / childBudget) * 100, dgt) & " %"
          End If
          Dim docTable As DataTable = mu.GetActualDocTable(toDate, view, requestor)
          If Not docTable Is Nothing Then
            For Each myRow As DataRow In docTable.Rows
              Dim docRow As TreeRow = childNode.Childs.Add
              docRow("boqi_itemname") = myRow("DocCode")

              Dim docTotal As Decimal = 0

              If IsNumeric(myRow.IsNull("DocAmount")) Then
                docTotal = CDec(myRow("DocAmount"))
              End If

              docRow("Actual") = Configuration.FormatToString(docTotal, dgt)
              'docRow.Tag = myWbs
              'docRow.State = RowExpandState.Expanded
            Next
          End If
        End If
      Next
    End Sub
#End Region

#Region "DetailedItemList"
    Private Sub PopulateWBSMonitorListingDetailedItemList(ByVal dt As TreeTable, ByVal toDate As Date, ByVal view As Integer, Optional ByVal noDigit As Boolean = False, Optional ByVal requestor As Integer = -99)
      dt.Clear()
      Dim dgt As DigitConfig = DigitConfig.Price
      If noDigit Then
        dgt = DigitConfig.Int
      End If
      Dim actualDT As DataTable = GetActualTable("GetAmountForWbs", toDate, Me.Id, False, view, requestor)

      For Each myWbs As WBS In Me.WBSCollection
        Dim parentNodes As TreeRow.TreeRowCollection = Nothing
        If myWbs.Parent Is myWbs Then
          parentNodes = dt.Childs
        ElseIf myWbs.Parent.Id <> 0 And myWbs.Parent.Id = myWbs.Id Then
          parentNodes = dt.Childs
        Else
          Dim parentNode As TreeRow = FindRow(dt, CType(myWbs.Parent, WBS))
          If Not parentNode Is Nothing Then
            parentNodes = parentNode.Childs
          End If
        End If
        If Not parentNodes Is Nothing Then
          Dim tr As TreeRow = parentNodes.Add
          tr("boqi_itemname") = myWbs.Code & "-" & myWbs.Name

          Dim matBudget As Decimal = myWbs.GetTotalMat
          Dim matActual As Decimal = Me.GetWBSActualFromDatatable(actualDT, myWbs, "actualmat") 'myWbs.GetActualMat(toDate, view, requestor)
          Dim matDiff As Decimal = matBudget - matActual
          tr("TotalMaterialCost") = Configuration.FormatToString(matBudget, dgt)
          tr("ActualMaterialCost") = Configuration.FormatToString(matActual, dgt)
          tr("MatDiff") = Configuration.FormatToString(matDiff, dgt)

          Dim labBudget As Decimal = myWbs.GetTotalLab
          Dim labActual As Decimal = Me.GetWBSActualFromDatatable(actualDT, myWbs, "actuallab") 'myWbs.GetActualLab(toDate, view, requestor)
          Dim labDiff As Decimal = labBudget - labActual
          tr("TotalLaborCost") = Configuration.FormatToString(labBudget, dgt)
          tr("ActualLaborCost") = Configuration.FormatToString(labActual, dgt)
          tr("LabDiff") = Configuration.FormatToString(labDiff, dgt)

          Dim eqBudget As Decimal = myWbs.GetTotalEq
          Dim eqActual As Decimal = Me.GetWBSActualFromDatatable(actualDT, myWbs, "actualeq") 'myWbs.GetActualEq(toDate, view, requestor)
          Dim eqDiff As Decimal = eqBudget - eqActual
          tr("TotalEquipmentCost") = Configuration.FormatToString(eqBudget, dgt)
          tr("ActualEquipmentCost") = Configuration.FormatToString(eqActual, dgt)
          tr("EqDiff") = Configuration.FormatToString(eqDiff, dgt)

          Dim totalBudget As Decimal = myWbs.GetTotal
          Dim totalActual As Decimal = matActual + labActual + eqActual 'myWbs.GetActualTotal(toDate, view, requestor)
          Dim totalDiff As Decimal = totalBudget - totalActual
          tr("Total") = Configuration.FormatToString(totalBudget, dgt)
          tr("Actual") = Configuration.FormatToString(totalActual, dgt)
          tr("TotalDiff") = Configuration.FormatToString(totalDiff, dgt)
          tr.Tag = myWbs
          tr.State = RowExpandState.Expanded

          Dim docTable As DataTable = myWbs.GetActualDocTable(toDate, view, requestor)
          If Not docTable Is Nothing Then
            For Each myRow As DataRow In docTable.Rows
              Dim docRow As TreeRow = tr.Childs.Add
              docRow("boqi_itemname") = "(เอกสาร) " & myRow("DocCode").ToString
              Dim docMat As Decimal = 0
              Dim docLab As Decimal = 0
              Dim docEq As Decimal = 0
              Dim docTotal As Decimal = 0

              If IsNumeric(myRow.IsNull("DocMat")) Then
                docMat = CDec(myRow("DocMat"))
              End If
              If IsNumeric(myRow.IsNull("DocLab")) Then
                docLab = CDec(myRow("DocLab"))
              End If
              If IsNumeric(myRow.IsNull("DocEq")) Then
                docEq = CDec(myRow("DocEq"))
              End If
              docTotal = docMat + docLab + docEq

              docRow("ActualMaterialCost") = Configuration.FormatToString(docMat, dgt)
              docRow("ActualLaborCost") = Configuration.FormatToString(docLab, dgt)
              docRow("ActualEquipmentCost") = Configuration.FormatToString(docEq, dgt)
              docRow("Actual") = Configuration.FormatToString(docTotal, dgt)
              'docRow.Tag = myWbs
              docRow.State = RowExpandState.Expanded
              'docRow.AcceptChanges()

              Dim ItemTable As DataTable = myWbs.GetActualItemTable(toDate, view, CInt(myRow("DocId")), requestor)
              If Not ItemTable Is Nothing Then
                For Each myItemRow As DataRow In ItemTable.Rows
                  Dim itemRow As TreeRow = docRow.Childs.Add
                  itemRow("boqi_itemname") = myItemRow("ItemCode").ToString & " : " & myItemRow("ItemName").ToString
                  Dim itemMat As Decimal = 0
                  Dim itemLab As Decimal = 0
                  Dim itemEq As Decimal = 0
                  Dim itemTotal As Decimal = 0

                  If IsNumeric(myItemRow.IsNull("itemMat")) Then
                    itemMat = CDec(myItemRow("itemMat"))
                  End If
                  If IsNumeric(myItemRow.IsNull("itemLab")) Then
                    itemLab = CDec(myItemRow("itemLab"))
                  End If
                  If IsNumeric(myItemRow.IsNull("itemEq")) Then
                    itemEq = CDec(myItemRow("itemEq"))
                  End If
                  itemTotal = itemMat + itemLab + itemEq

                  itemRow("ActualMaterialCost") = Configuration.FormatToString(itemMat, dgt)
                  itemRow("ActualLaborCost") = Configuration.FormatToString(itemLab, dgt)
                  itemRow("ActualEquipmentCost") = Configuration.FormatToString(itemEq, dgt)
                  itemRow("Actual") = Configuration.FormatToString(itemTotal, dgt)
                  'itemRow.Tag = myWbs
                  'itemRow.State = RowExpandState.Expanded
                  'itemRow.AcceptChanges()
                Next
              End If
            Next
          End If
        End If
      Next
      PopulateWBSMonitorOverHeadDetailed(dt, toDate, view, noDigit, requestor)
      Dim totalRow As TreeRow = dt.Childs.Add
      Dim totalTotalBudget As Decimal = Me.TotalBudget 'Me.FinalBidPrice
      Dim totalTotalActual As Decimal = Me.GetActualTotal(toDate, view, , requestor) + Me.GetActualOverhead(toDate, view, , requestor) '****** Undone:Neng
      Dim totalTotalDiff As Decimal = totalTotalBudget - totalTotalActual
      totalRow("boqi_itemname") = Me.StringParserService.Parse("${res:Global.Total}")
      totalRow("Total") = Configuration.FormatToString(totalTotalBudget, dgt)
      totalRow("Actual") = Configuration.FormatToString(totalTotalActual, dgt)
      totalRow("TotalDiff") = Configuration.FormatToString(totalTotalDiff, dgt)
      totalRow.State = RowExpandState.UnderParent
      PopulateWBSMonitorProfitDetailed(dt, toDate, view, noDigit, requestor)
      Dim actualProfitRow As TreeRow = dt.Childs.Add
      actualProfitRow("boqi_itemname") = Me.StringParserService.Parse("กำไร(ขาดทุน)สุทธิ") 'Hack
      actualProfitRow("Total") = Configuration.FormatToString(Me.Profit + totalTotalDiff, dgt)
      actualProfitRow("Actual") = Configuration.FormatToString(0, dgt)
      actualProfitRow("TotalDiff") = Configuration.FormatToString(Me.Profit + totalTotalDiff, dgt)
      actualProfitRow.State = RowExpandState.UnderParent
      Dim i As Integer = 0
      For Each row As DataRow In dt.Rows
        i += 1
        row("boqi_linenumber") = i
      Next
      If i > 0 Then
        dt.AcceptChanges()
      End If
    End Sub
#End Region

#Region "DetailedItemOnlyList"
    Private Sub PopulateWBSMonitorListingDetailedItemOnlyList(ByVal dt As TreeTable, ByVal toDate As Date, ByVal view As Integer, Optional ByVal noDigit As Boolean = False, Optional ByVal requestor As Integer = -99)
      dt.Clear()
      Dim dgt As DigitConfig = DigitConfig.Price
      If noDigit Then
        dgt = DigitConfig.Int
      End If
      Dim actualDT As DataTable = GetActualTable("GetAmountForWbs", toDate, Me.Id, False, view, requestor)

      For Each myWbs As WBS In Me.WBSCollection
        Dim parentNodes As TreeRow.TreeRowCollection = Nothing
        If myWbs.Parent Is myWbs Then
          parentNodes = dt.Childs
        ElseIf myWbs.Parent.Id <> 0 And myWbs.Parent.Id = myWbs.Id Then
          parentNodes = dt.Childs
        Else
          Dim parentNode As TreeRow = FindRow(dt, CType(myWbs.Parent, WBS))
          If Not parentNode Is Nothing Then
            parentNodes = parentNode.Childs
          End If
        End If
        If Not parentNodes Is Nothing Then
          Dim tr As TreeRow = parentNodes.Add
          tr("boqi_itemname") = myWbs.Code & "-" & myWbs.Name

          Dim matBudget As Decimal = myWbs.GetTotalMat
          Dim matActual As Decimal = Me.GetWBSActualFromDatatable(actualDT, myWbs, "actualmat") 'myWbs.GetActualMat(toDate, view, requestor)
          Dim matDiff As Decimal = matBudget - matActual
          tr("TotalMaterialCost") = Configuration.FormatToString(matBudget, dgt)
          tr("ActualMaterialCost") = Configuration.FormatToString(matActual, dgt)
          tr("MatDiff") = Configuration.FormatToString(matDiff, dgt)

          Dim labBudget As Decimal = myWbs.GetTotalLab
          Dim labActual As Decimal = Me.GetWBSActualFromDatatable(actualDT, myWbs, "actuallab") 'myWbs.GetActualLab(toDate, view, requestor)
          Dim labDiff As Decimal = labBudget - labActual
          tr("TotalLaborCost") = Configuration.FormatToString(labBudget, dgt)
          tr("ActualLaborCost") = Configuration.FormatToString(labActual, dgt)
          tr("LabDiff") = Configuration.FormatToString(labDiff, dgt)

          Dim eqBudget As Decimal = myWbs.GetTotalEq
          Dim eqActual As Decimal = Me.GetWBSActualFromDatatable(actualDT, myWbs, "actualeq") 'myWbs.GetActualEq(toDate, view, requestor)
          Dim eqDiff As Decimal = eqBudget - eqActual
          tr("TotalEquipmentCost") = Configuration.FormatToString(eqBudget, dgt)
          tr("ActualEquipmentCost") = Configuration.FormatToString(eqActual, dgt)
          tr("EqDiff") = Configuration.FormatToString(eqDiff, dgt)

          Dim totalBudget As Decimal = myWbs.GetTotal
          Dim totalActual As Decimal = matActual + labActual + eqActual 'myWbs.GetActualTotal(toDate, view, requestor)
          Dim totalDiff As Decimal = totalBudget - totalActual
          tr("Total") = Configuration.FormatToString(totalBudget, dgt)
          tr("Actual") = Configuration.FormatToString(totalActual, dgt)
          tr("TotalDiff") = Configuration.FormatToString(totalDiff, dgt)
          If totalBudget = 0 Then
            tr("TotalPercentDiff") = Configuration.FormatToString(0, dgt) & " %"
          Else
            tr("TotalPercentDiff") = Configuration.FormatToString(((totalDiff / totalBudget) * 100), dgt) & " %"
          End If
          tr.Tag = myWbs
          tr.State = RowExpandState.Expanded

          Dim itemTable As DataTable = myWbs.GetActualItemOnlyTable(toDate, view, requestor)
          If Not itemTable Is Nothing Then
            For Each myItemRow As DataRow In itemTable.Rows
              Dim itemRow As TreeRow = tr.Childs.Add
              itemRow("boqi_itemname") = myItemRow("ItemCode").ToString & " : " & myItemRow("ItemName").ToString
              If IsNumeric(myItemRow.IsNull("ItemUnitPrice")) Then
                itemRow("ItemUnitPrice") = Configuration.FormatToString(CDec(myItemRow("ItemUnitPrice")), dgt)
              End If
              If IsNumeric(myItemRow.IsNull("ItemQty")) Then
                itemRow("ItemQty") = Configuration.FormatToString(CDec(myItemRow("ItemQty")), dgt)
              End If
              If Not itemRow("ItemUnitName") Is Nothing Then
                itemRow("ItemUnitName") = myItemRow("ItemUnitName").ToString
              End If

              Dim itemMat As Decimal = 0
              Dim itemLab As Decimal = 0
              Dim itemEq As Decimal = 0
              Dim itemTotal As Decimal = 0

              If IsNumeric(myItemRow.IsNull("ItemMat")) Then
                itemMat = CDec(myItemRow("ItemMat"))
              End If
              If IsNumeric(myItemRow.IsNull("ItemLab")) Then
                itemLab = CDec(myItemRow("ItemLab"))
              End If
              If IsNumeric(myItemRow.IsNull("ItemEq")) Then
                itemEq = CDec(myItemRow("ItemEq"))
              End If
              itemTotal = itemMat + itemLab + itemEq

              itemRow("ActualMaterialCost") = Configuration.FormatToString(itemMat, dgt)
              itemRow("ActualLaborCost") = Configuration.FormatToString(itemLab, dgt)
              itemRow("ActualEquipmentCost") = Configuration.FormatToString(itemEq, dgt)
              itemRow("Actual") = Configuration.FormatToString(itemTotal, dgt)
              'itemRow.Tag = myWbs
              'itemRow.State = RowExpandState.Expanded
              'itemRow.AcceptChanges()
            Next
          End If
        End If
      Next
      PopulateWBSMonitorOverHeadDetailed(dt, toDate, view, noDigit, requestor)
      Dim totalRow As TreeRow = dt.Childs.Add
      Dim totalTotalBudget As Decimal = Me.TotalBudget 'Me.FinalBidPrice
      Dim totalTotalActual As Decimal = Me.GetActualTotal(toDate, view, , requestor) + Me.GetActualOverhead(toDate, view, , requestor) '****** Undone:Neng
      Dim totalTotalDiff As Decimal = totalTotalBudget - totalTotalActual
      totalRow("boqi_itemname") = Me.StringParserService.Parse("${res:Global.Total}")
      totalRow("Total") = Configuration.FormatToString(totalTotalBudget, dgt)
      totalRow("Actual") = Configuration.FormatToString(totalTotalActual, dgt)
      totalRow("TotalDiff") = Configuration.FormatToString(totalTotalDiff, dgt)
      If totalTotalBudget = 0 Then
        totalRow("TotalPercentDiff") = Configuration.FormatToString(0, dgt) & " %"
      Else
        totalRow("TotalPercentDiff") = Configuration.FormatToString(((totalTotalDiff / totalTotalBudget) * 100), dgt) & " %"
      End If
      totalRow.State = RowExpandState.UnderParent
      PopulateWBSMonitorProfitDetailed(dt, toDate, view, noDigit, requestor)
      Dim actualProfitRow As TreeRow = dt.Childs.Add
      actualProfitRow("boqi_itemname") = Me.StringParserService.Parse("กำไร(ขาดทุน)สุทธิ") 'Hack
      actualProfitRow("Total") = Configuration.FormatToString(Me.Profit + totalTotalDiff, dgt)
      actualProfitRow("Actual") = Configuration.FormatToString(0, dgt)
      actualProfitRow("TotalDiff") = Configuration.FormatToString(Me.Profit + totalTotalDiff, dgt)
      If Me.Profit + totalTotalDiff = 0 Then
        actualProfitRow("TotalPercentDiff") = Configuration.FormatToString(0, dgt) & " %"
      Else
        actualProfitRow("TotalPercentDiff") = Configuration.FormatToString((((Me.Profit + totalTotalDiff) / (Me.Profit + totalTotalDiff)) * 100), dgt) & " %"
      End If
      actualProfitRow.State = RowExpandState.UnderParent
      Dim i As Integer = 0
      For Each row As DataRow In dt.Rows
        i += 1
        row("boqi_linenumber") = i
      Next
      If i > 0 Then
        dt.AcceptChanges()
      End If
    End Sub
#End Region

#End Region

#End Region

#Region "WBSBudgetByCC"
    'ใช้ Style/Schema ของ WBSMonitor
#Region "Data"
    Public Shared Sub PopulateWBSMonitorListing(ByVal tm As TreeManager, ByVal toDate As Date, ByVal ccStart As Object, ByVal ccEnd As Object, Optional ByVal type As WBSReportType = WBSReportType.GoodsReceipt)
      Try
        Dim ds As DataSet = SqlHelper.ExecuteDataset( _
                ConnectionString _
                , CommandType.StoredProcedure _
                , "GetCCAndBOQ" _
                , New SqlParameter("@ccStart", ccStart) _
                , New SqlParameter("@ccEnd", ccEnd) _
                )
        Dim ccDt As DataTable = ds.Tables(0)
        Dim dt As TreeTable = CType(tm.Treetable.Clone, TreeTable)
        dt.Clear()
        Dim view As Integer = 45
        Select Case type
          Case WBSReportType.GoodsReceipt
            view = 45
          Case WBSReportType.MatWithdraw
            view = 31
          Case WBSReportType.PO
            view = 6
          Case WBSReportType.PR
            view = 7
        End Select
        For Each row As DataRow In ccDt.Rows
          Dim ccCode As String = row("CCCode").ToString
          Dim ccName As String = row("CCName").ToString
          Dim boqID As Integer = CInt(row("BOQId"))
          Dim theBOQ As New BOQ(boqID)
          theBOQ.m_WBSReportType = type
          WBS.WBSReportType = type
          Dim parentRow As TreeRow = dt.Childs.Add
          parentRow("boqi_itemname") = ccCode & "-" & ccName
          theBOQ.PopulateWBSMonitorListingForCC(parentRow, toDate, view)
          parentRow.State = RowExpandState.Expanded
        Next
        tm.Treetable = dt
        Dim i As Integer = 0
        For Each row As DataRow In dt.Rows
          i += 1
          row("boqi_linenumber") = i
        Next
        If i > 0 Then
          dt.AcceptChanges()
        End If
      Catch ex As Exception
        MessageBox.Show(ex.ToString)
      End Try
    End Sub
    Private Sub PopulateWBSMonitorListingForCC(ByVal parentRow As TreeRow, ByVal toDate As Date, ByVal view As Integer)
      Dim myWbs As WBS = Me.WBSCollection.GetRoot()
      Dim tr As TreeRow = parentRow.Childs.Add
      tr("boqi_itemname") = "ต้นทุนทางตรง"

      Dim matBudget As Decimal = myWbs.GetTotalMat
      Dim matActual As Decimal = myWbs.GetActualMat(toDate, view) '****** Undone:Neng
      Dim matDiff As Decimal = matBudget - matActual
      tr("TotalMaterialCost") = Configuration.FormatToString(matBudget, DigitConfig.Price)
      tr("ActualMaterialCost") = Configuration.FormatToString(matActual, DigitConfig.Price)
      tr("MatDiff") = Configuration.FormatToString(matDiff, DigitConfig.Price)

      Dim labBudget As Decimal = myWbs.GetTotalLab
      Dim labActual As Decimal = myWbs.GetActualLab(toDate, view) '****** Undone:Neng
      Dim labDiff As Decimal = labBudget - labActual
      tr("TotalLaborCost") = Configuration.FormatToString(labBudget, DigitConfig.Price)
      tr("ActualLaborCost") = Configuration.FormatToString(labActual, DigitConfig.Price)
      tr("LabDiff") = Configuration.FormatToString(labDiff, DigitConfig.Price)

      Dim eqBudget As Decimal = myWbs.GetTotalEq
      Dim eqActual As Decimal = myWbs.GetActualEq(toDate, view) '****** Undone:Neng
      Dim eqDiff As Decimal = eqBudget - eqActual
      tr("TotalEquipmentCost") = Configuration.FormatToString(eqBudget, DigitConfig.Price)
      tr("ActualEquipmentCost") = Configuration.FormatToString(eqActual, DigitConfig.Price)
      tr("EqDiff") = Configuration.FormatToString(eqDiff, DigitConfig.Price)

      Dim totalBudget As Decimal = myWbs.GetTotal
      Dim totalActual As Decimal = myWbs.GetActualTotal(toDate, view) '****** Undone:Neng
      Dim totalDiff As Decimal = totalBudget - totalActual
      tr("Total") = Configuration.FormatToString(totalBudget, DigitConfig.Price)
      tr("Actual") = Configuration.FormatToString(totalActual, DigitConfig.Price)
      tr("TotalDiff") = Configuration.FormatToString(totalDiff, DigitConfig.Price)
      If totalBudget = 0 Then
        tr("TotalPercentDiff") = Configuration.FormatToString(0, DigitConfig.Price) & " %"
      Else
        tr("TotalPercentDiff") = Configuration.FormatToString((totalDiff / totalBudget) * 100, DigitConfig.Price) & " %"
      End If
      tr.Tag = myWbs
      tr.State = RowExpandState.Expanded

      PopulateWBSMonitorOverHeadForCC(parentRow, toDate, view)

      Dim totalRow As TreeRow = parentRow.Childs.Add
      Dim totalTotalBudget As Decimal = Me.TotalBudget 'Me.FinalBidPrice
      Dim totalTotalActual As Decimal = Me.GetActualTotal(toDate, view) + Me.GetActualOverhead(toDate, view) '****** Undone:Neng
      Dim totalTotalDiff As Decimal = totalTotalBudget - totalTotalActual
      totalRow("boqi_itemname") = Me.StringParserService.Parse("${res:Global.Total}")
      totalRow("Total") = Configuration.FormatToString(totalTotalBudget, DigitConfig.Price)
      totalRow("Actual") = Configuration.FormatToString(totalTotalActual, DigitConfig.Price)
      totalRow("TotalDiff") = Configuration.FormatToString(totalTotalDiff, DigitConfig.Price)
      If totalTotalBudget = 0 Then
        totalRow("TotalPercentDiff") = Configuration.FormatToString(0, DigitConfig.Price) & " %"
      Else
        totalRow("TotalPercentDiff") = Configuration.FormatToString((totalTotalDiff / totalTotalBudget) * 100, DigitConfig.Price) & " %"
      End If
      totalRow.State = RowExpandState.UnderParent

      PopulateWBSMonitorProfitForCC(parentRow, toDate, view)

      Dim actualProfitRow As TreeRow = parentRow.Childs.Add
      actualProfitRow("boqi_itemname") = Me.StringParserService.Parse("กำไร(ขาดทุน)สุทธิ") 'Hack
      actualProfitRow("Total") = Configuration.FormatToString(Me.Profit + totalTotalDiff, DigitConfig.Price)
      actualProfitRow("Actual") = Configuration.FormatToString(0, DigitConfig.Price)
      actualProfitRow("TotalDiff") = Configuration.FormatToString(Me.Profit + totalTotalDiff, DigitConfig.Price)
      If Me.Profit + totalTotalDiff = 0 Then
        actualProfitRow("TotalPercentDiff") = Configuration.FormatToString(0, DigitConfig.Price) & " %"
      Else
        actualProfitRow("TotalPercentDiff") = Configuration.FormatToString(((Me.Profit + totalTotalDiff) / (Me.Profit + totalTotalDiff)) * 100, DigitConfig.Price) & " %"
      End If
      actualProfitRow.State = RowExpandState.UnderParent
    End Sub
    Private Sub PopulateWBSMonitorOverHeadForCC(ByVal parentRow As TreeRow, ByVal toDate As Date, ByVal view As Integer)
      Dim overheadNode As TreeRow = parentRow.Childs.Add
      Dim overheadBudget As Decimal = Me.Overhead
      Dim overheadActual As Decimal = Me.GetActualOverhead(toDate, view) '****** Undone:Neng
      Dim overheadDiff As Decimal = overheadBudget - overheadActual
      overheadNode("boqi_itemName") = Me.StringParserService.Parse("${res:Global.Overhead}")
      overheadNode("Total") = Configuration.FormatToString(overheadBudget, DigitConfig.Price)
      overheadNode("Actual") = Configuration.FormatToString(overheadActual, DigitConfig.Price)
      overheadNode("TotalDiff") = Configuration.FormatToString(overheadDiff, DigitConfig.Price)
      If overheadBudget = 0 Then
        overheadNode("TotalPercentDiff") = Configuration.FormatToString(0, DigitConfig.Price) & " %"
      Else
        overheadNode("TotalPercentDiff") = Configuration.FormatToString((overheadDiff / overheadBudget) * 100, DigitConfig.Price) & " %"
      End If
      overheadNode.State = RowExpandState.Expanded
    End Sub
    Private Sub PopulateWBSMonitorProfitForCC(ByVal parentRow As TreeRow, ByVal toDate As Date, ByVal view As Integer)
      Dim parentNode As TreeRow = parentRow.Childs.Add
      Dim parentBudget As Decimal = Me.Profit
      Dim parentActual As Decimal = 0
      Dim parentDiff As Decimal = parentBudget - parentDiff
      parentNode("boqi_itemName") = "กำไร<ประเมิน>" 'Hack
      parentNode("Total") = Configuration.FormatToString(parentBudget, DigitConfig.Price)
      parentNode("Actual") = Configuration.FormatToString(parentActual, DigitConfig.Price)
      parentNode("TotalDiff") = Configuration.FormatToString(parentDiff, DigitConfig.Price)
      If parentBudget = 0 Then
        parentNode("TotalPercentDiff") = Configuration.FormatToString(0, DigitConfig.Price) & " %"
      Else
        parentNode("TotalPercentDiff") = Configuration.FormatToString((parentDiff / parentBudget) * 100, DigitConfig.Price) & " %"
      End If
      parentNode.State = RowExpandState.Expanded
    End Sub
#End Region

#End Region

#End Region

#Region "Saving"
    Private Function InsertUpdate(ByVal currentUserId As Integer) As SaveErrorException
      If Me.DuplicateCode(Me.Code) Then
        Return New SaveErrorException("${res:Global.Error.AlreadyHasThisCode}", New String() {Me.Code})
      End If
      Dim trans As SqlTransaction
      Dim conn As New SqlConnection(Me.ConnectionString)
      conn.Open()
      trans = conn.BeginTransaction()

      Try
        Dim theTime As Date = Now
        Dim theUserId As Integer = currentUserId

        Dim daBoq As SqlDataAdapter
        Dim daWbs As SqlDataAdapter
        Dim daBoqItem As SqlDataAdapter
        Dim daMarkup As SqlDataAdapter
        Dim daMarkupC As SqlDataAdapter
        Dim daMarkupD As SqlDataAdapter
        Dim daBoqAD As SqlDataAdapter
        If Me.Originated Then
          ''----------------HACK------------------------------------
          'Dim cmd As New SqlCommand("update boqitem set boqi_wbs = null where boqi_boq=" & Me.Id, conn)
          'cmd.Connection = conn
          'cmd.Transaction = trans
          'cmd.ExecuteNonQuery()
          'cmd.CommandText = "delete wbs where wbs_boq=" & Me.Id.ToString
          'cmd.ExecuteNonQuery()
          ''----------------HACK------------------------------------

          daBoq = New SqlDataAdapter("Select * from boq where boq_id=" & Me.Id, conn)
          daWbs = New SqlDataAdapter("select * from wbs where wbs_boq=" & Me.Id & " order by wbs_level desc", conn)
          daBoqItem = New SqlDataAdapter("select * from boqitem where boqi_boq=" & Me.Id, conn)
          daMarkup = New SqlDataAdapter("select * from markup where markup_boq=" & Me.Id, conn)
          daMarkupC = New SqlDataAdapter("select * from markupcondition where markupc_markup in (select markup_id from markup where markup_boq=" & Me.Id & ")", conn)
          daMarkupD = New SqlDataAdapter("select * from markupdistribution where markupd_markup in (select markup_id from markup where markup_boq=" & Me.Id & ")", conn)
          daBoqAD = New SqlDataAdapter("select * from boqadjdistribution where boqadj_boq=" & Me.Id, conn)
        Else
          daBoq = New SqlDataAdapter("Select * from boq where 1=2", conn)
          daWbs = New SqlDataAdapter("select * from wbs where 1=2", conn)
          daBoqItem = New SqlDataAdapter("select * from boqitem where 1=2", conn)
          daMarkup = New SqlDataAdapter("select * from markup where 1=2", conn)
          daMarkupC = New SqlDataAdapter("select * from markupcondition where 1=2", conn)
          daMarkupD = New SqlDataAdapter("select * from markupdistribution where 1=2", conn)
          daBoqAD = New SqlDataAdapter("select * from boqadjdistribution where 1=2", conn)
        End If

        Dim ds As New DataSet

        '***********----BOQ ----****************
        Dim cb As New SqlCommandBuilder(daBoq)
        daBoq.SelectCommand.Transaction = trans

        daBoq.DeleteCommand = cb.GetDeleteCommand
        daBoq.DeleteCommand.Transaction = trans

        daBoq.InsertCommand = cb.GetInsertCommand
        daBoq.InsertCommand.Transaction = trans

        daBoq.UpdateCommand = cb.GetUpdateCommand
        daBoq.UpdateCommand.Transaction = trans

        daBoq.InsertCommand.CommandText &= "; Select * From boq Where boq_id= @@IDENTITY"
        daBoq.InsertCommand.UpdatedRowSource = UpdateRowSource.FirstReturnedRecord
        cb = Nothing

        daBoq.FillSchema(ds, SchemaType.Mapped, "boq")
        daBoq.Fill(ds, "boq")
        '***********----BOQ ----****************

        '***********----WBS ----****************
        cb = New SqlCommandBuilder(daWbs)
        daWbs.SelectCommand.Transaction = trans

        daWbs.DeleteCommand = cb.GetDeleteCommand
        daWbs.DeleteCommand.Transaction = trans

        daWbs.InsertCommand = cb.GetInsertCommand
        daWbs.InsertCommand.Transaction = trans

        daWbs.UpdateCommand = cb.GetUpdateCommand
        daWbs.UpdateCommand.Transaction = trans

        daWbs.InsertCommand.CommandText &= ";" & _
        "update wbs set wbs_parid = wbs_id where wbs_parid is null and wbs_id=@@IDENTITY;" & _
        "update wbs set wbs_path ='|'+convert(nvarchar,wbs_id)+'|' where wbs_id = @@IDENTITY and wbs_parid= @@IDENTITY;" & _
        "update wbs set wbs.wbs_path = (select parent.wbs_path from wbs parent where parent.wbs_id=wbs.wbs_parid) + '|'+convert(nvarchar,wbs.wbs_id)+'|' where wbs.wbs_id = @@IDENTITY and wbs.wbs_parid <> @@IDENTITY ;" & _
        " Select * From wbs Where wbs_id= @@IDENTITY"
        daWbs.InsertCommand.UpdatedRowSource = UpdateRowSource.FirstReturnedRecord
        cb = Nothing

        daWbs.FillSchema(ds, SchemaType.Mapped, "wbs")
        daWbs.Fill(ds, "wbs")
        ds.Relations.Add("boq_wbs", ds.Tables!boq.Columns!boq_id, ds.Tables!wbs.Columns!wbs_boq)
        ds.Relations.Add("wbsTree", ds.Tables!wbs.Columns!wbs_id, ds.Tables!wbs.Columns!wbs_parid)
        '***********----WBS ----****************

        '***********----Markup ----****************
        cb = New SqlCommandBuilder(daMarkup)
        daMarkup.SelectCommand.Transaction = trans

        daMarkup.DeleteCommand = cb.GetDeleteCommand
        daMarkup.DeleteCommand.Transaction = trans

        daMarkup.InsertCommand = cb.GetInsertCommand
        daMarkup.InsertCommand.Transaction = trans

        daMarkup.UpdateCommand = cb.GetUpdateCommand
        daMarkup.UpdateCommand.Transaction = trans

        daMarkup.InsertCommand.CommandText &= "; Select * From markup Where markup_id= @@IDENTITY"
        daMarkup.InsertCommand.UpdatedRowSource = UpdateRowSource.FirstReturnedRecord
        cb = Nothing

        daMarkup.FillSchema(ds, SchemaType.Mapped, "markup")
        daMarkup.Fill(ds, "markup")
        ds.Relations.Add("boq_markup", ds.Tables!boq.Columns!boq_id, ds.Tables!markup.Columns!markup_boq)
        '***********----Markup ----****************

        '***********----MarkupCondition ----****************
        cb = New SqlCommandBuilder(daMarkupC)
        daMarkupC.SelectCommand.Transaction = trans

        daMarkupC.DeleteCommand = cb.GetDeleteCommand
        daMarkupC.DeleteCommand.Transaction = trans

        daMarkupC.InsertCommand = cb.GetInsertCommand
        daMarkupC.InsertCommand.Transaction = trans

        daMarkupC.UpdateCommand = cb.GetUpdateCommand
        daMarkupC.UpdateCommand.Transaction = trans
        cb = Nothing

        daMarkupC.FillSchema(ds, SchemaType.Mapped, "markupcondition")
        daMarkupC.Fill(ds, "markupcondition")
        ds.Relations.Add("markup_markupcondition", ds.Tables!markup.Columns!markup_id, ds.Tables!markupcondition.Columns!markupc_markup)
        '***********----MarkupCondition ----****************


        '***********----Item ----****************
        cb = New SqlCommandBuilder(daBoqItem)
        daBoqItem.SelectCommand.Transaction = trans

        daBoqItem.DeleteCommand = cb.GetDeleteCommand
        daBoqItem.DeleteCommand.Transaction = trans

        daBoqItem.InsertCommand = cb.GetInsertCommand
        daBoqItem.InsertCommand.Transaction = trans

        daBoqItem.UpdateCommand = cb.GetUpdateCommand
        daBoqItem.UpdateCommand.Transaction = trans
        cb = Nothing

        daBoqItem.FillSchema(ds, SchemaType.Mapped, "boqitem")
        daBoqItem.Fill(ds, "boqitem")
        ds.Relations.Add("boq_boqitem", ds.Tables!boq.Columns!boq_id, ds.Tables!boqitem.Columns!boqi_boq)
        ds.Relations.Add("wbs_boqitem", ds.Tables!wbs.Columns!wbs_id, ds.Tables!boqitem.Columns!boqi_wbs)
        '***********----Item ----****************

        '***********----BOQAdjDistribution ----****************
        cb = New SqlCommandBuilder(daBoqAD)
        daBoqAD.SelectCommand.Transaction = trans

        daBoqAD.DeleteCommand = cb.GetDeleteCommand
        daBoqAD.DeleteCommand.Transaction = trans

        daBoqAD.InsertCommand = cb.GetInsertCommand
        daBoqAD.InsertCommand.Transaction = trans

        daBoqAD.UpdateCommand = cb.GetUpdateCommand
        daBoqAD.UpdateCommand.Transaction = trans
        cb = Nothing

        daBoqAD.FillSchema(ds, SchemaType.Mapped, "boqadjdistribution")
        daBoqAD.Fill(ds, "boqadjdistribution")
        ds.Relations.Add("boq_boqadjdistribution", ds.Tables!boq.Columns!boq_id, ds.Tables!boqadjdistribution.Columns!boqadj_boq)
        '***********----BOQAdjDistribution ----****************

        '***********----MarkupDistribution ----****************
        cb = New SqlCommandBuilder(daMarkupD)
        daMarkupD.SelectCommand.Transaction = trans

        daMarkupD.DeleteCommand = cb.GetDeleteCommand
        daMarkupD.DeleteCommand.Transaction = trans

        daMarkupD.InsertCommand = cb.GetInsertCommand
        daMarkupD.InsertCommand.Transaction = trans

        daMarkupD.UpdateCommand = cb.GetUpdateCommand
        daMarkupD.UpdateCommand.Transaction = trans
        cb = Nothing

        daMarkupD.FillSchema(ds, SchemaType.Mapped, "markupdistribution")
        daMarkupD.Fill(ds, "markupdistribution")
        ds.Relations.Add("markup_markupdistribution", ds.Tables!markup.Columns!markup_id, ds.Tables!markupdistribution.Columns!markupd_markup)
        '***********----MarkupDistribution ----****************

        Dim dtBoq As DataTable
        Dim dtWbs As DataTable
        Dim dtMarkup As DataTable
        Dim dtBoqItem As DataTable
        Dim dtMarkupC As DataTable
        Dim dtBoqAD As DataTable
        Dim dtMarkupD As DataTable
        Dim dc As DataColumn

        dtBoq = ds.Tables("boq")
        dc = dtBoq.Columns!boq_id
        dc.AutoIncrement = True
        dc.AutoIncrementSeed = -1
        dc.AutoIncrementStep = -1

        dtWbs = ds.Tables("wbs")
        dc = dtWbs.Columns!wbs_id
        dc.AutoIncrement = True
        dc.AutoIncrementSeed = Integer.MaxValue
        dc.AutoIncrementStep = -1

        dtMarkup = ds.Tables("markup")
        dc = dtMarkup.Columns!markup_id
        dc.AutoIncrement = True
        dc.AutoIncrementSeed = Integer.MaxValue
        dc.AutoIncrementStep = -1

        dtMarkupC = ds.Tables("markupcondition")

        dtBoqItem = ds.Tables("boqitem")

        dtBoqAD = ds.Tables("boqadjdistribution")

        dtMarkupD = ds.Tables("markupdistribution")

        Dim tmpBoqDa As New SqlDataAdapter
        tmpBoqDa.DeleteCommand = daBoq.DeleteCommand
        tmpBoqDa.InsertCommand = daBoq.InsertCommand
        tmpBoqDa.UpdateCommand = daBoq.UpdateCommand

        Dim tmpwbsDa As New SqlDataAdapter
        tmpwbsDa.DeleteCommand = daWbs.DeleteCommand
        tmpwbsDa.InsertCommand = daWbs.InsertCommand
        tmpwbsDa.UpdateCommand = daWbs.UpdateCommand

        Dim tmpMarkupDa As New SqlDataAdapter
        tmpMarkupDa.DeleteCommand = daMarkup.DeleteCommand
        tmpMarkupDa.InsertCommand = daMarkup.InsertCommand
        tmpMarkupDa.UpdateCommand = daMarkup.UpdateCommand

        AddHandler tmpBoqDa.RowUpdated, AddressOf tmpDa_MyRowUpdated
        AddHandler tmpwbsDa.RowUpdated, AddressOf tmpwbsDa_MyRowUpdated
        AddHandler tmpMarkupDa.RowUpdated, AddressOf tmpMarkupDa_MyRowUpdated
        AddHandler daMarkupC.RowUpdated, AddressOf daMarkupC_MyRowUpdated
        AddHandler daBoqItem.RowUpdated, AddressOf daBoqitem_MyRowUpdated
        AddHandler daBoqAD.RowUpdated, AddressOf daBoqAD_MyRowUpdated
        AddHandler daMarkupD.RowUpdated, AddressOf daMarkupD_MyRowUpdated

        If Me.Status.Value = -1 Then
          Me.Status.Value = 2
        End If

        Dim drBoq As DataRow
        If Not Me.Originated Then
          drBoq = dtBoq.NewRow
        Else
          drBoq = dtBoq.Rows(0)
        End If
        drBoq(Me.Prefix & "_code") = Me.Code
        drBoq(Me.Prefix & "_project") = Me.ValidIdOrDBNull(Me.Project)
        drBoq(Me.Prefix & "_estimator") = Me.ValidIdOrDBNull(Me.Estimator)
        drBoq(Me.Prefix & "_materialMarkup") = Me.MaterialMarkup
        drBoq(Me.Prefix & "_materialDmethod") = Me.MaterialMarkupMethod.Value
        drBoq(Me.Prefix & "_laborMarkup") = Me.LaborMarkup
        drBoq(Me.Prefix & "_laborDmethod") = Me.LaborMarkupMethod.Value
        drBoq(Me.Prefix & "_equipmentMarkup") = Me.EquipmentMarkup
        drBoq(Me.Prefix & "_equipmentDmethod") = Me.EquipmentMarkupMethod.Value
        drBoq(Me.Prefix & "_status") = Me.Status.Value
        drBoq(Me.Prefix & "_taxamt") = Me.TaxAmount
        drBoq(Me.Prefix & "_markupstate") = Me.MarkupState
        drBoq(Me.Prefix & "_finalbidprice") = Me.FinalBidPrice
        drBoq(Me.Prefix & "_totalbudget") = Me.TotalBudget

        Me.SetOriginEditCancelStatus(drBoq, theTime, currentUserId)

        If Not Me.Originated Then
          dtBoq.Rows.Add(drBoq)
        End If

        Dim rowsToDelete As New ArrayList
        For Each dr As DataRow In dtWbs.Rows
          Dim found As Boolean = False
          For Each testWbs As WBS In Me.WBSCollection
            If testWbs.Id = CInt(dr("wbs_id")) Then
              found = True
              Exit For
            End If
          Next
          If Not found Then
            If Not rowsToDelete.Contains(dr) Then
              rowsToDelete.Add(dr)
            End If
          End If
        Next
        For Each dr As DataRow In rowsToDelete
          dr.Delete()
        Next
        Dim rootWbs As WBS = Me.WBSCollection.GetRoot
        If Not rootWbs Is Nothing Then
          Dim drWbs As DataRow
          Dim drs As DataRow() = dtWbs.Select("wbs_id=" & rootWbs.Id)
          If drs.Length = 0 Then
            drWbs = dtWbs.NewRow
          Else
            drWbs = drs(0)
          End If
          'drWbs("wbs_id") = ""
          drWbs("wbs_boq") = drBoq(Me.Prefix & "_id")
          drWbs("wbs_level") = 0
          drWbs("wbs_code") = rootWbs.Code
          drWbs("wbs_name") = rootWbs.Name
          drWbs("wbs_altName") = rootWbs.AlternateName
          drWbs("wbs_note") = rootWbs.Note
          drWbs("wbs_control") = DBNull.Value
          drWbs("wbs_path") = ""
          drWbs("wbs_linenumber") = 1
          drWbs("wbs_state") = CInt(rootWbs.State)
          If rootWbs.Status.Value = -1 Then
            rootWbs.Status.Value = 2
          End If
          drWbs("wbs_status") = rootWbs.Status.Value
          drWbs("wbs_noqtycontrol") = rootWbs.NoQtyControl
          drWbs("wbs_startdate") = rootWbs.StartDate
          drWbs("wbs_finishdate") = rootWbs.FinishDate
          drWbs("wbs_qty") = rootWbs.Qty
          drWbs("wbs_unit") = ValidIdOrDBNull(rootWbs.Unit)
          If drs.Length = 0 Then
            dtWbs.Rows.Add(drWbs)
            Dim oldParId As Integer = rootWbs.Id
            rootWbs.Id = CInt(drWbs("wbs_id"))
            Me.WBSCollection.UpdateParentId(oldParId, rootWbs.Id)
            Me.ItemCollection.UpdateWbsId(oldParId, rootWbs.Id)
          End If
          Dim collForRoot As WBSCollection = Me.WBSCollection.GetChildsOf(rootWbs)
          LoopWbs(collForRoot, 1, dtWbs, drBoq)
          collForRoot = Nothing
        End If

        For Each dr As DataRow In dtMarkupC.Rows
          dr.Delete()
        Next
        rowsToDelete = New ArrayList
        For Each dr As DataRow In dtMarkup.Rows
          Dim found As Boolean = False
          For Each testMarkup As Markup In Me.MarkupCollection
            If testMarkup.Id = CInt(dr("markup_id")) Then
              found = True
              Exit For
            End If
          Next
          If Not found Then
            If Not rowsToDelete.Contains(dr) Then
              rowsToDelete.Add(dr)
            End If
          End If
        Next
        For Each dr As DataRow In rowsToDelete
          dr.Delete()
        Next
        For Each mrkp As Markup In Me.MarkupCollection
          Dim drMarkup As DataRow
          Dim drs As DataRow() = dtMarkup.Select("markup_id=" & mrkp.Id)
          If drs.Length = 0 Then
            drMarkup = dtMarkup.NewRow
          Else
            drMarkup = drs(0)
          End If
          'drWbs("markup_id") = ""
          drMarkup("markup_boq") = drBoq(Me.Prefix & "_id")
          drMarkup("markup_name") = mrkp.Name
          drMarkup("markup_note") = mrkp.Note
          drMarkup("markup_type") = mrkp.Type.Value
          drMarkup("markup_condition") = mrkp.Condition.Value
          drMarkup("markup_amt") = mrkp.Amount
          drMarkup("markup_unit") = mrkp.Unit.Value
          drMarkup("markup_totalamt") = mrkp.TotalAmount
          drMarkup("markup_distributedamt") = mrkp.DistributedAmount
          drMarkup("markup_dmethod") = mrkp.DistributionMethod.Value
          If mrkp.Status.Value = -1 Then
            mrkp.Status.Value = 2
          End If
          drMarkup("markup_status") = mrkp.Status.Value
          If drs.Length = 0 Then
            dtMarkup.Rows.Add(drMarkup)
            mrkp.Id = CInt(drMarkup("markup_id"))
          End If
          Dim markupCLine As Integer = 1
          For Each mrkpc As MarkupConditionItem In mrkp.ConditionItems
            Dim drMarkupC As DataRow = dtMarkupC.NewRow
            drMarkupC("markupc_markup") = mrkp.Id
            drMarkupC("markupc_linenumber") = markupCLine
            drMarkupC("markupc_lowerbound") = mrkpc.LowerBound
            drMarkupC("markupc_upperbound") = mrkpc.UpperBound
            drMarkupC("markupc_percent") = mrkpc.Percent
            dtMarkupC.Rows.Add(drMarkupC)
            markupCLine += 1
          Next
        Next

        For Each dr As DataRow In dtBoqItem.Rows
          dr.Delete()
        Next
        Dim boqLine As Integer = 1
        For Each item As BoqItem In Me.ItemCollection
          Dim drItem As DataRow = dtBoqItem.NewRow
          drItem("boqi_boq") = drBoq(Me.Prefix & "_id")
          drItem("boqi_linenumber") = boqLine
          drItem("boqi_wbs") = item.WBS.Id
          drItem("boqi_entity") = item.Entity.Id
          drItem("boqi_entityType") = item.ItemType.Value
          drItem("boqi_itemName") = item.EntityName
          drItem("boqi_qtyperwbs") = item.QtyPerWBS
          Select Case item.ItemType.Value
            Case 42
              Dim lci As New LCIItem(item.Entity.Id)
              If Not lci.Originated Then
                trans.Rollback()
                Return New SaveErrorException("${res:Global.Error.LCIIsInvalid}", New String() {item.Entity.Name})
              ElseIf Not lci.ValidUnit(item.Unit) Then
                trans.Rollback()
                Return New SaveErrorException("${res:Global.Error.LCIInvalidUnit}", New String() {lci.Code, item.Unit.Name})
              End If
            Case 19
              Dim myTool As New Tool(item.Entity.Id)
              If Not myTool.Originated Then
                trans.Rollback()
                Return New SaveErrorException("${res:Global.Error.ToolIsInvalid}", New String() {item.Entity.Name})
              ElseIf myTool.Unit.Id <> item.Unit.Id Then
                trans.Rollback()
                Return New SaveErrorException("${res:Global.Error.ToolInvalidUnit}", New String() {myTool.Code, item.Unit.Name})
              End If
            Case 18
              Dim myLabor As New Labor(item.Entity.Id)
              If Not myLabor.Originated Then
                trans.Rollback()
                Return New SaveErrorException("${res:Global.Error.LaborIsInvalid}", New String() {item.Entity.Name})
              ElseIf myLabor.Unit.Id <> item.Unit.Id Then
                trans.Rollback()
                Return New SaveErrorException("${res:Global.Error.LaborInvalidUnit}", New String() {myLabor.Code, item.Unit.Name})
              End If
            Case 20
              Dim myEqCost As New EqCost(item.Entity.Id)
              If Not myEqCost.Originated Then
                trans.Rollback()
                Return New SaveErrorException("${res:Global.Error.EqCostIsInvalid}", New String() {item.Entity.Name})
              ElseIf myEqCost.Unit.Id <> item.Unit.Id Then
                trans.Rollback()
                Return New SaveErrorException("${res:Global.Error.EqCostInvalidUnit}", New String() {myEqCost.Code, item.Unit.Name})
              End If
          End Select
          drItem("boqi_unit") = item.Unit.Id
          drItem("boqi_qty") = item.Qty
          drItem("boqi_umc") = item.UMC
          drItem("boqi_ulc") = item.ULC
          drItem("boqi_uec") = item.UEC
          drItem("boqi_note") = item.Note
          dtBoqItem.Rows.Add(drItem)
          item.LineNumber = boqLine
          boqLine += 1
        Next

        '*************** BOQADJ ****************************
        For Each dr As DataRow In dtBoqAD.Rows
          dr.Delete()
        Next
        For Each dbi As BoqItem In Me.MaterialMarkupItems
          Dim drBoqAD As DataRow = dtBoqAD.NewRow
          drBoqAD("boqadj_boq") = drBoq(Me.Prefix & "_id")
          drBoqAD("boqadj_boqilinenumber") = dbi.LineNumber
          drBoqAD("boqadj_type") = 1
          dtBoqAD.Rows.Add(drBoqAD)
        Next

        For Each dbi As BoqItem In Me.LaborMarkupItems
          Dim drBoqAD As DataRow = dtBoqAD.NewRow
          drBoqAD("boqadj_boq") = drBoq(Me.Prefix & "_id")
          drBoqAD("boqadj_boqilinenumber") = dbi.LineNumber
          drBoqAD("boqadj_type") = 2
          dtBoqAD.Rows.Add(drBoqAD)
        Next

        For Each dbi As BoqItem In Me.EquipmentMarkupItems
          Dim drBoqAD As DataRow = dtBoqAD.NewRow
          drBoqAD("boqadj_boq") = drBoq(Me.Prefix & "_id")
          drBoqAD("boqadj_boqilinenumber") = dbi.LineNumber
          drBoqAD("boqadj_type") = 3
          dtBoqAD.Rows.Add(drBoqAD)
        Next
        '*************** BOQADJ ****************************

        For Each dr As DataRow In dtMarkupD.Rows
          dr.Delete()
        Next
        For Each mrkp As Markup In Me.MarkupCollection
          For Each mrkpD As BoqItem In mrkp.DistributedItems
            Dim drMarkupD As DataRow = dtMarkupD.NewRow
            drMarkupD("markupd_markup") = mrkp.Id
            drMarkupD("markupd_boqilinenumber") = mrkpD.LineNumber
            dtMarkupD.Rows.Add(drMarkupD)
          Next
        Next

        If Not rootWbs Is Nothing Then
          '--------------------------SAVING EXTENDERS---------------------
          For Each extender As Object In Me.Extenders
            If TypeOf extender Is IExtender Then
              Dim saveDetailError As SaveErrorException = CType(extender, IExtender).Save(conn, trans)
              If Not IsNumeric(saveDetailError.Message) Then
                trans.Rollback()
                'ResetID(oldid)
                Return saveDetailError
              Else
                Select Case CInt(saveDetailError.Message)
                  Case -1, -2, -5
                    trans.Rollback()
                    'ResetID(oldid)
                    Return saveDetailError
                  Case Else
                End Select
              End If
            End If
          Next
          '--------------------------END SAVING EXTENDERS---------------------
        End If

        daMarkupD.Update(GetDeletedRows(dtMarkupD))
        daBoqAD.Update(GetDeletedRows(dtBoqAD))
        daBoqItem.Update(GetDeletedRows(dtBoqItem))
        daMarkupC.Update(GetDeletedRows(dtMarkupC))
        tmpMarkupDa.Update(GetDeletedRows(dtMarkup))
        tmpwbsDa.Update(GetDeletedRows(dtWbs))
        tmpBoqDa.Update(GetDeletedRows(dtBoq))

        tmpBoqDa.Update(dtBoq.Select("", "", DataViewRowState.ModifiedCurrent))
        tmpwbsDa.Update(dtWbs.Select("", "", DataViewRowState.ModifiedCurrent))
        tmpMarkupDa.Update(dtMarkup.Select("", "", DataViewRowState.ModifiedCurrent))
        daMarkupC.Update(dtMarkupC.Select("", "", DataViewRowState.ModifiedCurrent))
        daBoqItem.Update(dtBoqItem.Select("", "", DataViewRowState.ModifiedCurrent))
        daBoqAD.Update(dtBoqAD.Select("", "", DataViewRowState.ModifiedCurrent))
        daMarkupD.Update(dtMarkupD.Select("", "", DataViewRowState.ModifiedCurrent))

        tmpBoqDa.Update(dtBoq.Select("", "", DataViewRowState.Added))


        ds.EnforceConstraints = False

        tmpwbsDa.Update(dtWbs.Select("", "", DataViewRowState.Added))
        tmpMarkupDa.Update(dtMarkup.Select("", "", DataViewRowState.Added))
        daMarkupC.Update(dtMarkupC.Select("", "", DataViewRowState.Added))
        daBoqItem.Update(dtBoqItem.Select("", "", DataViewRowState.Added))
        daBoqAD.Update(dtBoqAD.Select("", "", DataViewRowState.Added))
        daMarkupD.Update(dtMarkupD.Select("", "", DataViewRowState.Added))

        ds.EnforceConstraints = True
        Dim theId As Integer = Me.Id
        If Not Me.Originated Then
          theId = CInt(drBoq("boq_id"))
        End If
        SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "CleanWBs", New SqlParameter() {New SqlParameter("@boq_id", theId)})

        ''=== Insert Update Budget and Actual ======================================================
        SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "DeleteSwang_WBSBudget", New SqlParameter() {New SqlParameter("@boq", theId)})
        SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "InsertSwang_WBSBudget ", New SqlParameter() {New SqlParameter("@boq", theId)})
        SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "InsertUpdateAllActual")
        ''=== Insert Update Budget and Actual ======================================================

        'SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "swang_InsertBOQProcedure", New SqlParameter() {New SqlParameter("@boq", theId)})
        trans.Commit()
        If Not Me.Originated Then
          Me.Id = CInt(drBoq("boq_id"))
        End If
        Return New SaveErrorException("0")
      Catch ex As SqlException
        trans.Rollback()
        'Hack
        Return New SaveErrorException("${res:Global.Error.BOQHasWBSOrMarkupRefedCannotDelete}")
      Catch ex As Exception
        trans.Rollback()
        Return New SaveErrorException(ex.ToString)
      Finally
        conn.Close()
      End Try
      Return New SaveErrorException("0")
    End Function
    Private Sub LoopWbs(ByVal coll As WBSCollection, ByVal level As Integer, ByVal dtWbs As DataTable, ByVal drBoq As DataRow)
      Dim line As Integer = 1
      For Each myWbs As WBS In coll
        Dim drWbs As DataRow
        Dim drs As DataRow() = dtWbs.Select("wbs_id=" & myWbs.Id)
        If drs.Length = 0 Then
          drWbs = dtWbs.NewRow
        Else
          drWbs = drs(0)
        End If
        'drWbs("wbs_id") = ""
        drWbs("wbs_boq") = drBoq(Me.Prefix & "_id")
        drWbs("wbs_parid") = myWbs.Parent.Id
        drWbs("wbs_level") = level
        drWbs("wbs_code") = myWbs.Code
        drWbs("wbs_name") = myWbs.Name
        drWbs("wbs_altName") = myWbs.AlternateName
        drWbs("wbs_note") = myWbs.Note
        drWbs("wbs_control") = DBNull.Value
        drWbs("wbs_path") = ""
        drWbs("wbs_linenumber") = line
        drWbs("wbs_state") = CInt(myWbs.State)
        If myWbs.Status.Value = -1 Then
          myWbs.Status.Value = 2
        End If
        drWbs("wbs_status") = myWbs.Status.Value
        drWbs("wbs_noqtycontrol") = myWbs.NoQtyControl
        drWbs("wbs_startdate") = myWbs.StartDate
        drWbs("wbs_finishdate") = myWbs.FinishDate
        drWbs("wbs_qty") = myWbs.Qty
        drWbs("wbs_unit") = ValidIdOrDBNull(myWbs.Unit)
        If drs.Length = 0 Then
          dtWbs.Rows.Add(drWbs)
          Dim oldParId As Integer = myWbs.Id
          myWbs.Id = CInt(drWbs("wbs_id"))
          Me.WBSCollection.UpdateParentId(oldParId, myWbs.Id)
          Me.ItemCollection.UpdateWbsId(oldParId, myWbs.Id)
        End If
        line += 1
        Dim childs As WBSCollection = Me.WBSCollection.GetChildsOf(myWbs)
        LoopWbs(childs, level + 1, dtWbs, drBoq)
        childs = Nothing
      Next
    End Sub
    Private Sub tmpDa_MyRowUpdated(ByVal sender As Object, ByVal e As System.Data.SqlClient.SqlRowUpdatedEventArgs)
      If e.StatementType = StatementType.Insert Then e.Status = UpdateStatus.SkipCurrentRow
      If e.StatementType = StatementType.Delete Then e.Status = UpdateStatus.SkipCurrentRow
    End Sub
    Private Sub tmpwbsDa_MyRowUpdated(ByVal sender As Object, ByVal e As System.Data.SqlClient.SqlRowUpdatedEventArgs)
      ' When the primary key propagates down to the child row's foreign key field, the field
      ' does not receive an OriginalValue with pseudo key value and a CurrentValue with the
      ' actual key value. Therefore, when the merge occurs, this row is  appended to the DataSet
      ' on the client tier, instead of being merged with the original row that was added.
      If e.StatementType = StatementType.Insert Then
        e.Status = UpdateStatus.SkipCurrentRow
        Dim currentkey As Object = e.Row("wbs_boq")
        Dim currentInternalKey As Object = e.Row("wbs_parid")
        e.Row!wbs_boq = e.Row.GetParentRow("boq_wbs")("boq_id", DataRowVersion.Original)
        If Not e.Row.GetParentRow("wbsTree") Is Nothing AndAlso e.Row.GetParentRow("wbsTree").HasVersion(DataRowVersion.Original) Then
          e.Row!wbs_parid = e.Row.GetParentRow("wbsTree")("wbs_id", DataRowVersion.Original)
        End If
        'If e.Row.IsNull("wbs_parid") Then
        '    e.Row!wbs_parid = e.Row!wbs_id
        'End If
        e.Row.AcceptChanges()
        e.Row!wbs_boq = currentkey
        e.Row!wbs_parid = currentInternalKey
      End If
      If e.StatementType = StatementType.Delete Then e.Status = UpdateStatus.SkipCurrentRow
    End Sub
    Private Sub tmpMarkupDa_MyRowUpdated(ByVal sender As Object, ByVal e As System.Data.SqlClient.SqlRowUpdatedEventArgs)
      If e.StatementType = StatementType.Insert Then
        e.Status = UpdateStatus.SkipCurrentRow
        Dim currentkey As Object = e.Row("markup_boq")
        e.Row!markup_boq = e.Row.GetParentRow("boq_markup")("boq_id", DataRowVersion.Original)
        e.Row.AcceptChanges()
        e.Row!markup_boq = currentkey
      End If
      If e.StatementType = StatementType.Delete Then e.Status = UpdateStatus.SkipCurrentRow
    End Sub
    Private Sub daBoqitem_MyRowUpdated(ByVal sender As Object, ByVal e As System.Data.SqlClient.SqlRowUpdatedEventArgs)
      If e.StatementType = StatementType.Insert Then
        e.Status = UpdateStatus.SkipCurrentRow
        Dim currentkey As Object = e.Row("boqi_boq")
        Dim currentWbsKey As Object = e.Row("boqi_wbs")
        e.Row!boqi_boq = e.Row.GetParentRow("boq_boqitem")("boq_id", DataRowVersion.Original)
        e.Row!boqi_wbs = e.Row.GetParentRow("wbs_boqitem")("wbs_id", DataRowVersion.Original)
        e.Row.AcceptChanges()
        e.Row!boqi_boq = currentkey
        e.Row!boqi_wbs = currentWbsKey
      End If
      If e.StatementType = StatementType.Delete Then e.Status = UpdateStatus.SkipCurrentRow
    End Sub
    Private Sub daMarkupC_MyRowUpdated(ByVal sender As Object, ByVal e As System.Data.SqlClient.SqlRowUpdatedEventArgs)
      If e.StatementType = StatementType.Insert Then
        e.Status = UpdateStatus.SkipCurrentRow
        Dim currentkey As Object = e.Row("markupc_markup")
        e.Row!markupc_markup = e.Row.GetParentRow("markup_markupcondition")("markup_id", DataRowVersion.Original)
        e.Row.AcceptChanges()
        e.Row!markupc_markup = currentkey
      End If
      If e.StatementType = StatementType.Delete Then e.Status = UpdateStatus.SkipCurrentRow
    End Sub
    Private Sub daBoqAD_MyRowUpdated(ByVal sender As Object, ByVal e As System.Data.SqlClient.SqlRowUpdatedEventArgs)
      If e.StatementType = StatementType.Insert Then
        e.Status = UpdateStatus.SkipCurrentRow
        Dim currentkey As Object = e.Row("boqadj_boq")
        e.Row!boqadj_boq = e.Row.GetParentRow("boq_boqadjdistribution")("boq_id", DataRowVersion.Original)
        e.Row.AcceptChanges()
        e.Row!boqadj_boq = currentkey
      End If
      If e.StatementType = StatementType.Delete Then e.Status = UpdateStatus.SkipCurrentRow
    End Sub
    Private Sub daMarkupD_MyRowUpdated(ByVal sender As Object, ByVal e As System.Data.SqlClient.SqlRowUpdatedEventArgs)
      If e.StatementType = StatementType.Insert Then
        e.Status = UpdateStatus.SkipCurrentRow
        Dim currentkey As Object = e.Row("markupd_markup")
        e.Row!markupd_markup = e.Row.GetParentRow("markup_markupdistribution")("markup_id", DataRowVersion.Original)
        e.Row.AcceptChanges()
        e.Row!markupd_markup = currentkey
      End If
      If e.StatementType = StatementType.Delete Then e.Status = UpdateStatus.SkipCurrentRow
    End Sub
    Private Function GetDeletedRows(ByVal dt As DataTable) As DataRow()
      Dim Rows() As DataRow
      If dt Is Nothing Then Return Rows
      Rows = dt.Select("", "", DataViewRowState.Deleted)
      If Rows.Length = 0 OrElse Not (Rows(0) Is Nothing) Then Return Rows
      '
      ' Workaround:
      ' With a remoted DataSet, Select returns the array elements
      ' filled with Nothing/null, instead of DataRow objects.
      '
      Dim r As DataRow, I As Integer = 0
      For Each r In dt.Rows
        If r.RowState = DataRowState.Deleted Then
          Rows(I) = r
          I += 1
        End If
      Next
      Return Rows
    End Function
    Public Overloads Overrides Function Save(ByVal currentUserId As Integer) As SaveErrorException

      Return InsertUpdate(currentUserId)

    End Function
#End Region

#Region "IPrintableEntity"
    Public Function GetDefaultFormPath() As String Implements IPrintableEntity.GetDefaultFormPath
      Return "C:\Documents and Settings\Administrator\Desktop\Forms\Documents\PO.dfm"
    End Function
    Public Function GetDefaultForm() As String Implements IPrintableEntity.GetDefaultForm

    End Function
    Public Function GetDocPrintingEntries() As DocPrintingItemCollection Implements IPrintableEntity.GetDocPrintingEntries
      Dim dpiColl As New DocPrintingItemCollection
      Dim dpi As DocPrintingItem
      'Code
      dpi = New DocPrintingItem
      dpi.Mapping = "Code"
      dpi.Value = Me.Code
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'Project
      dpi = New DocPrintingItem
      dpi.Mapping = "Project"
      dpi.Value = Me.Project.Code & ":" & Me.Project.Name
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'SumTotalMaterialCost
      dpi = New DocPrintingItem
      dpi.Mapping = "SumTotalMaterialCost"
      dpi.Value = Configuration.FormatToString(Me.FinalMaterialCost, DigitConfig.Price)
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'SumTotalLaborCost
      dpi = New DocPrintingItem
      dpi.Mapping = "SumTotalLaborCost"
      dpi.Value = Configuration.FormatToString(Me.FinalLaborCost, DigitConfig.Price)
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'SumTotalEquipmentCost
      dpi = New DocPrintingItem
      dpi.Mapping = "SumTotalEquipmentCost"
      dpi.Value = Configuration.FormatToString(Me.FinalEquipmentCost, DigitConfig.Price)
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'SumTotal
      dpi = New DocPrintingItem
      dpi.Mapping = "SumTotal"
      dpi.Value = Configuration.FormatToString(Me.FinalBidPriceWithVat, DigitConfig.Price)
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'Address
      dpi = New DocPrintingItem
      dpi.Mapping = "Address"
      dpi.Value = m_project.Address
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'Province
      dpi = New DocPrintingItem
      dpi.Mapping = "Province"
      dpi.Value = m_project.Province
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'CustomerCode
      dpi = New DocPrintingItem
      dpi.Mapping = "CustomerCode"
      dpi.Value = m_project.Customer.Code
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'CustomerName
      dpi = New DocPrintingItem
      dpi.Mapping = "CustomerName"
      dpi.Value = m_project.Customer.Name
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'Customer
      dpi = New DocPrintingItem
      dpi.Mapping = "Customer"
      dpi.Value = m_project.Customer.Code & ":" & m_project.Customer.Name
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'CompletionDate
      dpi = New DocPrintingItem
      dpi.Mapping = "CompletionDate"
      dpi.Value = m_project.CompletionDate.ToShortDateString
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      Return dpiColl

    End Function
#End Region

#Region "Overrides"
    Public Overrides Function ToString() As String
      Return Me.Code
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
        Try
          Me.ItemCollection.Dispose()
          Me.WBSCollection.Dispose()
          Me.MarkupCollection.Dispose()
          Me.LaborMarkupItems.Dispose()
          Me.EquipmentMarkupItems.Dispose()
          Me.MaterialMarkupItems.Dispose()
        Catch ex As Exception

        End Try
        m_disposed = True
        GC.SuppressFinalize(Me)
      End If
      'Undone : clear all resource
    End Sub
#End Region

#Region "IDuplicable"
    Public Function GetNewEntity() As Object Implements IDuplicable.GetNewEntity
      If Not Me.Originated Then
        Return Me
      End If
      Me.Id = 0
      Me.Code = "Copy of " & Me.Code
      For Each myWbs As WBS In Me.WBSCollection
        Dim parent As WBS = Me.WBSCollection.GetParentOf(myWbs)
        If parent Is Nothing Then
          parent = myWbs
        End If
        myWbs.Parent = parent
      Next
      For Each myWbs As WBS In Me.WBSCollection
        myWbs.Id = 0
        myWbs.Status.Value = -1
      Next
      For Each mk As Markup In Me.MarkupCollection
        mk.Id = 0
        mk.Status.Value = -1
      Next
      Return Me
    End Function
#End Region

#Region "Delete"
    Public Overrides ReadOnly Property CanDelete() As Boolean
      Get
        Return True 'Hack
      End Get
    End Property
    Public Overrides Function Delete() As SaveErrorException
      If Not Me.Originated Then
        Return New SaveErrorException("${res:Global.Error.NoIdError}")
      End If
      Dim myMessage As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      Dim format(0) As String
      format(0) = Me.Code
      If Not myMessage.AskQuestionFormatted("${res:Global.ConfirmDeleteBoq}", format) Then
        Return New SaveErrorException("${res:Global.CencelDelete}")
      End If
      Dim trans As SqlTransaction
      Dim conn As New SqlConnection(Me.ConnectionString)
      conn.Open()
      trans = conn.BeginTransaction()
      Try
        Dim returnVal As System.Data.SqlClient.SqlParameter = New SqlParameter
        returnVal.ParameterName = "RETURN_VALUE"
        returnVal.DbType = DbType.Int32
        returnVal.Direction = ParameterDirection.ReturnValue
        returnVal.SourceVersion = DataRowVersion.Current
        SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "DeleteBoq", New SqlParameter() {New SqlParameter("@boq_id", Me.Id), returnVal})
        If IsNumeric(returnVal.Value) Then
          Select Case CInt(returnVal.Value)
            Case -1
              trans.Rollback()
              Return New SaveErrorException("${res:Global.BoqIsReferencedCannotBeDeleted}")
            Case Else
          End Select
        ElseIf IsDBNull(returnVal.Value) OrElse Not IsNumeric(returnVal.Value) Then
          trans.Rollback()
          Return New SaveErrorException(returnVal.Value.ToString)
        End If
        trans.Commit()
        Return New SaveErrorException("1")
      Catch ex As SqlException
        trans.Rollback()
        Return New SaveErrorException(ex.Message)
      Catch ex As Exception
        trans.Rollback()
        Return New SaveErrorException(ex.Message)
      Finally
        conn.Close()
      End Try
    End Function
#End Region

  End Class

  Public Class BOQForSelection
    Inherits BOQ

    Public Overrides ReadOnly Property CodonName() As String
      Get
        Return "BOQForSelection"
      End Get
    End Property
  End Class

  Public Class BOQWBSForSelection
    Inherits BOQ

    Public Overrides ReadOnly Property CodonName() As String
      Get
        Return "BOQWBSForSelection"
      End Get
    End Property
  End Class

End Namespace

