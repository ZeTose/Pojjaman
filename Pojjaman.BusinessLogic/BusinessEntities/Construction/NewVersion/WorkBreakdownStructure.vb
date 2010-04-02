Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration
Imports System.Reflection
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Pojjaman.Services
Imports System.Windows.Forms.Design
Imports System.ComponentModel.Design
Imports System.ComponentModel
Imports System.Collections.Generic

Namespace Longkong.Pojjaman.BusinessLogic
  Public Class CBS

#Region "Shared"

    Public Shared ReadOnly Property Count As Integer
      Get
        Return 0
      End Get
    End Property
    Private Shared CBSIdList As Dictionary(Of Integer, CBS)
    Private Shared CBSCodeList As Dictionary(Of String, CBS)

    Private Shared m_tree As List(Of CBS)
    Public Shared ReadOnly Property CBSTree As List(Of CBS)
      Get
        If m_tree Is Nothing Then
          RefreshTree()
        End If
        Return m_tree
      End Get
    End Property
    Public Shared Sub RefreshTree()
      m_tree = New List(Of CBS)
      CBSIdList = New Dictionary(Of Integer, CBS)
      CBSCodeList = New Dictionary(Of String, CBS)
      Dim sqlConString As String = RecentCompanies.CurrentCompany.SiteConnectionString
      Dim ds As DataSet = SqlHelper.ExecuteDataset(sqlConString _
      , CommandType.StoredProcedure _
      , "GetCBSTree" _
      )
      Dim parentList As New Dictionary(Of Integer, CBS)
      Dim orphans As New List(Of CBS) 'ลูกกำพร้า
      For Each row As DataRow In ds.Tables(0).Rows
        Dim c As New CBS(row)
        parentList.Add(c.Id, c)
        If Not c.ParentId.HasValue OrElse c.ParentId.Value = c.Id Then
          m_tree.Add(c)
        Else
          Dim tryParent As CBS = Nothing
          If parentList.TryGetValue(c.ParentId.Value, tryParent) _
          AndAlso tryParent IsNot Nothing Then
            'TODO: จริงๆไม่น่าจะต้องเช็ค nothing อีกนะ ว่างๆลองดูหน่อย
            tryParent.Childs.Add(c)
            c.Parent = tryParent
          Else
            orphans.Add(c)
          End If
        End If
        CBSIdList.Add(c.Id, c)
        CBSCodeList.Add(c.Code, c)
      Next
      m_tree.AddRange(orphans)
    End Sub
    Public Shared Function GetById(ByVal idToFind As Integer) As CBS
      Dim c As CBS = Nothing
      If CBSIdList Is Nothing Then
        RefreshTree()
      End If
      If CBSIdList.TryGetValue(idToFind, c) Then
        Return c
      End If
      Return New CBS
    End Function
    Public Shared Function GetByCode(ByVal codeToFind As String) As CBS
      Dim c As CBS = Nothing
      If CBSCodeList Is Nothing Then
        RefreshTree()
      End If
      For Each kv As KeyValuePair(Of String, CBS) In CBSCodeList
        If kv.Key.ToLower = codeToFind.ToLower Then
          Return kv.Value
        End If
      Next
      Return New CBS
    End Function
#End Region

#Region "Constructors"
    Public Sub New()

    End Sub

    Public Sub New(ByVal dr As DataRow)
      Dim dh As New DataRowHelper(dr)
      Id = dh.GetValue(Of Integer)("cbs_id")
      Code = dh.GetValue(Of String)("cbs_code")
      Name = dh.GetValue(Of String)("cbs_name")
      AlternateName = dh.GetValue(Of String)("cbs_altname")
      Note = dh.GetValue(Of String)("cbs_note")

      ParentId = dh.GetValue(Of Integer)("cbs_parid")
    End Sub
#End Region

#Region "Properties"
    Public ReadOnly Property IdOrNull As Nullable(Of Integer)
      Get
        Dim ret As Nullable(Of Integer) = Nothing
        If Id <> 0 Then
          ret = Id
        End If
        Return ret
      End Get
    End Property
    Public Property Id As Integer
    Public Property Code As String
    Public Property Name As String
    Public Property AlternateName As String
    Public Property Note As String
    Public Property ParentId As Nullable(Of Integer)
    Public Property Parent As CBS
    Public ReadOnly Property Level As Integer
      Get
        If Parent Is Nothing Then
          Return 0
        End If
        Return Me.Parent.Level + 1
      End Get
    End Property
    Private m_childs As List(Of CBS)
    Public ReadOnly Property Childs As List(Of CBS)
      Get
        If m_childs Is Nothing Then
          m_childs = New List(Of CBS)
        End If
        Return m_childs
      End Get
    End Property
#End Region

  End Class
  Public Class WorkBreakdownStructure

#Region "Constructors"
    Public Sub New()
      Unit = New Unit
      CBS = New CBS
      Me.PlannedStartDate = Now
      Me.PlannedFinishDate = Now
      Me.StartDate = Now
      Me.FinishDate = Now
    End Sub
    Public Sub New(ByVal dr As DataRow)
      Dim dh As New DataRowHelper(dr)
      Id = dh.GetValue(Of Integer)("wbs_id")
      Code = dh.GetValue(Of String)("wbs_code")
      Name = dh.GetValue(Of String)("wbs_name")
      AlternateName = dh.GetValue(Of String)("wbs_altname")
      Note = dh.GetValue(Of String)("wbs_note")
      StatusId = dh.GetValue(Of Integer)("wbs_status")
      m_qty = dh.GetValue(Of Decimal)("wbs_qty")
      m_unitPrice = dh.GetValue(Of Decimal)("wbs_unitprice")
      m_amount = dh.GetValue(Of Decimal)("wbs_amount")
      PlannedStartDate = dh.GetValue(Of Date)("wbs_startdate")
      PlannedFinishDate = dh.GetValue(Of Date)("wbs_finishdate")
      StartDate = dh.GetValue(Of Date)("wbs_realstartdate")
      FinishDate = dh.GetValue(Of Date)("wbs_realfinishdate")

      ParentId = dh.GetValue(Of Integer)("wbs_parid")
      Dim unitId As Integer = dh.GetValue(Of Integer)("wbs_unit", 0)
      Unit = New Unit(unitId)

      Dim cbsId As Integer = dh.GetValue(Of Integer)("wbs_cbs", 0)
      CBS = CBS.GetById(cbsId)

      Me.State = CType([Enum].Parse(GetType(RowExpandState), dh.GetValue(Of String)("wbs_state", "1")), RowExpandState)

    End Sub
#End Region

#Region "Properties"
    Public Property Id As Integer
    Public Property Code As String
    Public Property Name As String
    Public Property AlternateName As String
    Public Property Note As String
    Public Property StatusId As Nullable(Of Integer)
    Public Property ParentId As Nullable(Of Integer)
    Public Property Unit As Unit
    Public Property State As RowExpandState = RowExpandState.Expanded

    Public Property CBS As CBS
    Private m_qty As Nullable(Of Decimal) = Nothing
    Public Property Qty As Nullable(Of Decimal)
      Get
        Return m_qty
      End Get
      Set(ByVal value As Nullable(Of Decimal))
        m_qty = value
        If m_unitPrice.HasValue AndAlso m_qty.HasValue Then
          m_amount = m_unitPrice.Value * m_qty.Value
        End If
      End Set
    End Property
    Private m_unitPrice As Nullable(Of Decimal) = Nothing
    Public Property UnitPrice As Nullable(Of Decimal)
      Get
        Return m_unitPrice
      End Get
      Set(ByVal value As Nullable(Of Decimal))
        m_unitPrice = value
        If m_unitPrice.HasValue AndAlso m_qty.HasValue Then
          m_amount = m_unitPrice.Value * m_qty.Value
        End If
      End Set
    End Property
    Private m_amount As Decimal = 0
    Public Property Amount As Decimal
      Get
        Return m_amount
      End Get
      Set(ByVal value As Decimal)
        m_amount = value
        If Qty.HasValue AndAlso Qty.Value <> 0 Then
          m_unitPrice = m_amount / Qty.Value
        Else
          m_unitPrice = Nothing
        End If
      End Set
    End Property
    Public ReadOnly Property Budget As Decimal
      Get
        Dim ret As Decimal = Me.Amount
        For Each child As WorkBreakdownStructure In Me.Childs
          ret += child.Budget
        Next
        Return ret
      End Get
    End Property
    Public Property PlannedStartDate As Nullable(Of Date)
    Public Property PlannedFinishDate As Nullable(Of Date)

    Public Property StartDate As Nullable(Of Date)
    Public Property FinishDate As Nullable(Of Date)

    Public Property Boq As BOQ
    Public Property Parent As WorkBreakdownStructure
    Public ReadOnly Property Level As Integer
      Get
        If Parent Is Nothing Then
          Return 0
        End If
        Return Me.Parent.Level + 1
      End Get
    End Property
    Private m_childs As List(Of WorkBreakdownStructure)
    Public ReadOnly Property Childs As List(Of WorkBreakdownStructure)
      Get
        If m_childs Is Nothing Then
          m_childs = New List(Of WorkBreakdownStructure)
        End If
        Return m_childs
      End Get
    End Property
#End Region

#Region "Shared"
    Public Shared Sub GetBoqChilds(ByVal budget As Budget)
      If budget Is Nothing Then
        Return
      End If
      budget.Childs = New List(Of WorkBreakdownStructure)

      Dim sqlConString As String = RecentCompanies.CurrentCompany.SiteConnectionString
      Dim ds As DataSet = SqlHelper.ExecuteDataset(sqlConString _
      , CommandType.StoredProcedure _
      , "GetWorkBreakdownStructures" _
      , New SqlParameter("@boq_id", budget.Id) _
      )
      budget.ChildrenCount = ds.Tables(0).Rows.Count
      Dim parentList As New Dictionary(Of Integer, WorkBreakdownStructure)
      Dim orphans As New List(Of WorkBreakdownStructure) 'ลูกกำพร้า
      For Each row As DataRow In ds.Tables(0).Rows
        Dim w As New WorkBreakdownStructure(row)
        parentList.Add(w.Id, w)
        If Not w.ParentId.HasValue OrElse w.ParentId.Value = w.Id Then
          budget.Childs.Add(w)
        Else
          Dim tryParent As WorkBreakdownStructure = Nothing
          If parentList.TryGetValue(w.ParentId.Value, tryParent) _
          AndAlso tryParent IsNot Nothing Then
            'TODO: จริงๆไม่น่าจะต้องเช็ค nothing อีกนะ ว่างๆลองดูหน่อย
            tryParent.Childs.Add(w)
            w.Parent = tryParent
          Else
            orphans.Add(w)
          End If
        End If
      Next
      budget.Childs.AddRange(orphans)
    End Sub
#End Region
    Public Sub CreateOrUpdate(ByVal dtWbs As DataTable, ByVal drBoq As DataRow)
      Dim drWbs As DataRow
      Dim drs As DataRow() = dtWbs.Select("wbs_id=" & Me.Id)
      If drs.Length = 0 Then
        drWbs = dtWbs.NewRow
      Else
        drWbs = drs(0)
      End If
      drWbs("wbs_boq") = drBoq("boq_id")

      If Not Me.Parent Is Nothing AndAlso Me.Parent.Id <> 0 Then
        drWbs("wbs_parid") = Me.Parent.Id
      Else
        drWbs("wbs_parid") = DBNull.Value
      End If

      drWbs("wbs_level") = Me.Level
      drWbs("wbs_code") = Me.Code
      If Not Me.CBS Is Nothing AndAlso Me.CBS.Id <> 0 Then
        drWbs("wbs_cbs") = Me.CBS.Id
      Else
        drWbs("wbs_cbs") = DBNull.Value
      End If
      drWbs("wbs_name") = Me.Name
      drWbs("wbs_altName") = Me.AlternateName
      drWbs("wbs_note") = Me.Note
      drWbs("wbs_control") = (Me.Childs.Count > 0)
      drWbs("wbs_path") = ""
      drWbs("wbs_linenumber") = 1
      drWbs("wbs_state") = CInt(Me.State)

      If Not Me.StatusId.HasValue Then
        Me.StatusId = 2
      End If
      drWbs("wbs_status") = Me.StatusId.Value
      If Me.PlannedStartDate.HasValue Then
        drWbs("wbs_startdate") = Me.PlannedStartDate.Value
      End If
      If Me.PlannedFinishDate.HasValue Then
        drWbs("wbs_finishdate") = Me.PlannedFinishDate.Value
      End If
      If Me.Qty.HasValue Then
        drWbs("wbs_qty") = Me.Qty
      Else
        drWbs("wbs_qty") = DBNull.Value
      End If
      If Me.UnitPrice.HasValue Then
        drWbs("wbs_unitprice") = Me.UnitPrice
      Else
        drWbs("wbs_unitprice") = DBNull.Value
      End If
      drWbs("wbs_budget") = Me.Budget
      drWbs("wbs_amount") = Me.Amount

      drWbs("wbs_unit") = SimpleBusinessEntityBase.ValidIdOrDBNull(Me.Unit)
      If drs.Length = 0 Then
        dtWbs.Rows.Add(drWbs)
        Me.Id = CInt(drWbs("wbs_id"))
        If Me.Level = 0 OrElse drWbs.IsNull("wbs_parid") Then
          drWbs("wbs_parid") = DBNull.Value
        End If
      End If
      For Each child As WorkBreakdownStructure In Me.Childs
        child.CreateOrUpdate(dtWbs, drBoq)
      Next
    End Sub
    Public Sub PopulateRow(ByVal tr As TreeRow, ByVal SetWorkDone As CountDelegate, ByVal current As Integer, ByVal includeChildren As Boolean)
      If tr Is Nothing Then
        Return
      End If
      If Not SetWorkDone Is Nothing Then
        current += 1
        SetWorkDone(current)
      End If
      tr("Code") = Me.Code
      If Not Me.CBS Is Nothing AndAlso Me.CBS.IdOrNull.HasValue Then
        tr("CBS") = Me.CBS.Code
      Else
        tr("CBS") = ""
      End If
      tr("Name") = Me.Name
      tr("Unit") = Me.Unit.Name
      tr("UnitButton") = ""
      tr("Note") = Me.Note

      Dim tmat As Decimal = 0 'Me.GetTotalMat
      Dim tlab As Decimal = 0 'Me.GetTotalLab
      Dim teq As Decimal = 0 'Me.GetTotalEq
      Dim t As Decimal = 0 'Me.GetTotal
      Dim tpw As Decimal = 0 'Me.GetTotalPerWBS

      If Me.UnitPrice.HasValue Then
        tr("Unitprice") = Configuration.FormatToString(Me.UnitPrice.Value, DigitConfig.UnitPrice)
      Else
        tr("Unitprice") = ""
      End If

      If Me.Qty.HasValue Then
        tr("QTY") = Configuration.FormatToString(Me.Qty.Value, DigitConfig.UnitPrice)
      Else
        tr("QTY") = ""
      End If

      tr("Amount") = Configuration.FormatToString(Me.Amount, DigitConfig.Price)
      tr("Budget") = Configuration.FormatToString(Me.Budget, DigitConfig.Price)

      If Me.PlannedStartDate.HasValue Then
        tr("StartDate") = Me.PlannedStartDate.Value
      Else
        tr("StartDate") = DBNull.Value
      End If
      If Me.PlannedFinishDate.HasValue Then
        tr("FinishDate") = Me.PlannedFinishDate.Value
      Else
        tr("FinishDate") = DBNull.Value
      End If

      tr.State = Me.State

      tr.Tag = Me

      If includeChildren Then
        For Each child As WorkBreakdownStructure In Me.Childs
          child.PopulateRow(tr.Childs.Add, SetWorkDone, current, includeChildren)
        Next
      End If
    End Sub

    Public Function FindWbs(ByVal id As Integer) As WorkBreakdownStructure
      For Each child As WorkBreakdownStructure In Me.Childs
        If child.Id = id Then
          Return child
        End If
        Dim founded As WorkBreakdownStructure = child.FindWbs(id)
        If Not founded Is Nothing Then
          Return founded
        End If
      Next
    End Function
  End Class
End Namespace

