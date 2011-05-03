Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration
Imports System.Reflection
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Pojjaman.Services
Namespace Longkong.Pojjaman.BusinessLogic
  Public Class BOQItemType
    Inherits CodeDescription

#Region "Constructors"
    Public Sub New(ByVal value As Integer)
      MyBase.New(value)
    End Sub
#End Region

#Region "Properties"
    Public Overrides ReadOnly Property CodeName() As String
      Get
        Return "boqi_entityType"
      End Get
    End Property
#End Region

  End Class
  Public Class BoqItem
    Implements IDisposable

#Region "Members"
    Private m_boq As BOQ
    Private m_lineNumber As Integer
    Private m_wbs As WBS
    Private m_itemType As BOQItemType
    Private m_entity As IHasName
    Private m_entityName As String
    Private m_unit As Unit
    Private m_qty As Decimal
    Private m_umc As Decimal
    Private m_ulc As Decimal
    Private m_uec As Decimal
    Private m_note As String
    Private m_conversion As Decimal = 1

    Private m_matAdjust As Decimal
    Private m_labAdjust As Decimal
    Private m_eqAdjust As Decimal
    Private m_dcAdjust As Decimal

    Private m_qtyPerWBS As Decimal

    Private m_mcbs As CBS
    Private m_lcbs As CBS
    Private m_ecbs As CBS


#End Region

#Region "Constructors"
    Public Sub New()
      MyBase.New()
      Me.m_entity = New BlankItem("")
      Me.m_unit = New Unit
      Me.m_itemType = New BOQItemType(42)
      Me.m_mcbs = New CBS
      Me.m_lcbs = New CBS
      Me.m_ecbs = New CBS
    End Sub
    Public Sub New(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
      Me.Construct(ds, aliasPrefix)
    End Sub
    Public Sub New(ByVal dr As DataRow, ByVal aliasPrefix As String)
      Me.Construct(dr, aliasPrefix)
    End Sub
    Public Sub New(ByVal dr As DataRow, ByVal aliasPrefix As String, ByVal boq As BOQ)
      Me.Construct(dr, aliasPrefix, boq)
    End Sub
    Protected Sub Construct(ByVal dr As DataRow, ByVal aliasPrefix As String, ByVal boq As BOQ)
      With Me
        Dim drh As New DataRowHelper(dr)
        If dr.Table.Columns.Contains(aliasPrefix & "boqi_lineNumber") AndAlso Not dr.IsNull(aliasPrefix & "boqi_lineNumber") Then
          .m_lineNumber = CInt(dr(aliasPrefix & "boqi_lineNumber"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "boqi_note") AndAlso Not dr.IsNull(aliasPrefix & "boqi_note") Then
          .m_note = CStr(dr(aliasPrefix & "boqi_note"))
        End If

        If Not boq Is Nothing AndAlso boq.Originated Then
          If dr.Table.Columns.Contains(aliasPrefix & "boqi_wbs") AndAlso Not dr.IsNull(aliasPrefix & "boqi_wbs") Then
            Dim wbsId As Integer = CInt(dr(aliasPrefix & "boqi_wbs"))
            For Each myWbs As WBS In boq.WBSCollection
              If myWbs.Id = wbsId Then
                .m_wbs = myWbs
                Exit For
              End If
            Next
          End If
        Else
          If dr.Table.Columns.Contains(aliasPrefix & "wbs_id") AndAlso Not dr.IsNull(aliasPrefix & "wbs_id") Then
            If Not dr.IsNull("wbs_id") Then
              .m_wbs = New WBS(dr, "")
            End If
          Else
            If dr.Table.Columns.Contains(aliasPrefix & "boqi_wbs") AndAlso Not dr.IsNull(aliasPrefix & "boqi_wbs") Then
              .m_wbs = New WBS(CInt(dr(aliasPrefix & "boqi_wbs")))
            End If
          End If
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "boqi_entityType") AndAlso Not dr.IsNull(aliasPrefix & "boqi_entityType") Then
          .m_itemType = New BOQItemType(CInt(dr(aliasPrefix & "boqi_entityType")))
        End If
        Dim itemId As Integer
        If dr.Table.Columns.Contains(aliasPrefix & "boqi_entity") AndAlso Not dr.IsNull(aliasPrefix & "boqi_entity") Then
          itemId = CInt(dr(aliasPrefix & "boqi_entity"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "boqi_itemName") AndAlso Not dr.IsNull(aliasPrefix & "boqi_itemName") Then
          .m_entityName = CStr(dr(aliasPrefix & "boqi_itemName"))
        Else
          .m_entityName = ""
        End If

        Select Case .m_itemType.Value
          Case 0 'Blank
            .m_entity = New BlankItem(.m_entityName)
          Case 18 'ค่าแรง
            .m_entity = New Labor(itemId)
          Case 20 'ค่าเครื่องจักร
            .m_entity = New EqCost(itemId)
          Case 42
            If dr.Table.Columns.Contains("lci_id") AndAlso Not dr.IsNull("lci_id") Then
              If Not dr.IsNull("lci_id") Then
                .m_entity = New LCIItem(dr, "")
              End If
            Else
              .m_entity = New LCIItem(itemId)
            End If
          Case Else
        End Select
        If dr.Table.Columns.Contains(aliasPrefix & "unit_id") AndAlso Not dr.IsNull(aliasPrefix & "unit_id") Then

          If Not dr.IsNull("unit_id") Then
            .m_unit = New Unit(dr, "")
          End If
        Else
          If dr.Table.Columns.Contains(aliasPrefix & "boqi_unit") AndAlso Not dr.IsNull(aliasPrefix & "boqi_unit") Then
            .m_unit = Unit.GetUnitById(CInt(dr(aliasPrefix & "boqi_unit")))
            '.m_unit = New Unit(CInt(dr(aliasPrefix & "boqi_unit")))
          End If
        End If

        If Not Me.Unit Is Nothing AndAlso Me.Unit.Originated Then
          If TypeOf Me.Entity Is LCIItem Then
            Dim lci As LCIItem = CType(Me.Entity, LCIItem)
            Try
              Me.Conversion = lci.GetConversion(Me.Unit)
            Catch ex As Exception
              Me.Conversion = 1
            End Try
          Else
            Me.Conversion = 1
          End If
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "boqi_qty") AndAlso Not dr.IsNull(aliasPrefix & "boqi_qty") Then
          .m_qty = CDec(dr(aliasPrefix & "boqi_qty"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "boqi_umc") AndAlso Not dr.IsNull(aliasPrefix & "boqi_umc") Then
          .m_umc = CDec(dr(aliasPrefix & "boqi_umc"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "boqi_ulc") AndAlso Not dr.IsNull(aliasPrefix & "boqi_ulc") Then
          .m_ulc = CDec(dr(aliasPrefix & "boqi_ulc"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "boqi_uec") AndAlso Not dr.IsNull(aliasPrefix & "boqi_uec") Then
          .m_uec = CDec(dr(aliasPrefix & "boqi_uec"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "boqi_qtyPerWBS") AndAlso Not dr.IsNull(aliasPrefix & "boqi_qtyPerWBS") Then
          .m_qtyPerWBS = CDec(dr(aliasPrefix & "boqi_qtyPerWBS"))
        End If

        .m_mcbs = New CBS(drh.GetValue(Of Integer)("boqi_mcbs"))
        .m_lcbs = New CBS(drh.GetValue(Of Integer)("boqi_lcbs"))
        .m_ecbs = New CBS(drh.GetValue(Of Integer)("boqi_ecbs"))

      End With
    End Sub
    Protected Sub Construct(ByVal dr As DataRow, ByVal aliasPrefix As String)
      Construct(dr, aliasPrefix, Nothing)
    End Sub
    Protected Sub Construct(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
      Dim dr As DataRow = ds.Tables(0).Rows(0)
      Me.Construct(dr, aliasPrefix)
    End Sub
#End Region

#Region "Properties"
    Public Property BOQ() As BOQ      Get        Return m_boq      End Get      Set(ByVal Value As BOQ)        m_boq = Value      End Set    End Property    Public Property LineNumber() As Integer      Get        Return m_lineNumber      End Get      Set(ByVal Value As Integer)        m_lineNumber = Value      End Set    End Property    Public Property WBS() As WBS      Get        Return m_wbs      End Get      Set(ByVal Value As WBS)        m_wbs = Value      End Set    End Property    Public Property ItemType() As BOQItemType      Get        Return m_itemType      End Get      Set(ByVal Value As BOQItemType)        m_itemType = Value      End Set    End Property    '--------------------ธวัชชัย----------------------------------    Public Property QtyPerWBS() As Decimal      Get        Return m_qtyPerWBS      End Get      Set(ByVal Value As Decimal)        m_qtyPerWBS = Value      End Set    End Property    Public ReadOnly Property TotalPerWBS() As Decimal      Get      
        Return Me.QtyPerWBS * (Me.UMC + Me.UEC + Me.ULC)
      End Get
    End Property    Public Property Qty() As Decimal      Get        Dim includeQtyPerWBS As Boolean = False
        Dim icq As Object = Configuration.GetConfig("includeQtyPerWBS")
        If Not IsDBNull(icq) AndAlso Not icq Is Nothing Then
          includeQtyPerWBS = CBool(icq)
        End If        If includeQtyPerWBS Then          If m_qtyPerWBS <> 0 Then            m_qty = m_qtyPerWBS * Me.WBS.AllQty
          End If        End If        Return m_qty
      End Get      Set(ByVal Value As Decimal)        Dim includeQtyPerWBS As Boolean = False
        Dim icq As Object = Configuration.GetConfig("includeQtyPerWBS")
        If Not IsDBNull(icq) AndAlso Not icq Is Nothing Then
          includeQtyPerWBS = CBool(icq)
        End If        If Not includeQtyPerWBS Then          Dim aq As Decimal = 0          If Not Me.WBS Is Nothing Then            aq = Me.WBS.AllQty
          End If          'Dim aq As Decimal = Me.WBS.AllQty          If aq <> 0 Then            m_qtyPerWBS = m_qty / aq          Else            m_qtyPerWBS = 0          End If        End If        m_qty = Value      End Set    End Property    '--------------------END ธวัชชัย----------------------------------    Public Property Entity() As IHasName      Get        Return m_entity      End Get      Set(ByVal Value As IHasName)        m_entity = Value      End Set    End Property    Public Property EntityName() As String      Get        Return m_entityName      End Get      Set(ByVal Value As String)        m_entityName = Value      End Set    End Property    Public Property Conversion() As Decimal      Get        Return m_conversion      End Get      Set(ByVal Value As Decimal)        m_conversion = Value      End Set    End Property    Public Property Unit() As Unit      Get        Return m_unit      End Get      Set(ByVal Value As Unit)        m_unit = Value      End Set    End Property    Public Property MatAdjust() As Decimal      Get        Return m_matAdjust      End Get      Set(ByVal Value As Decimal)        m_matAdjust = Value      End Set    End Property    Public Property LabAdjust() As Decimal      Get        Return m_labAdjust      End Get      Set(ByVal Value As Decimal)        m_labAdjust = Value      End Set    End Property    Public Property EqAdjust() As Decimal      Get        Return m_eqAdjust      End Get      Set(ByVal Value As Decimal)        m_eqAdjust = Value      End Set    End Property    Public Property DirectCostAdjust() As Decimal      Get        Return m_dcAdjust      End Get      Set(ByVal Value As Decimal)        m_dcAdjust = Value      End Set    End Property    Public ReadOnly Property StockQty() As Decimal      Get        Return Me.Conversion * Me.Qty      End Get    End Property    Public Property UMC() As Decimal      Get        Return m_umc      End Get      Set(ByVal Value As Decimal)        m_umc = Value      End Set    End Property    Public ReadOnly Property TotalMaterialCost() As Decimal
      Get
        Return Me.Qty * Me.UMC
      End Get
    End Property    Public ReadOnly Property FinalMC() As Decimal
      Get
        Return TotalMaterialCost + MatAdjust
      End Get
    End Property    Public ReadOnly Property FinalUMC() As Decimal      Get
        If Qty = 0 Then
          Return 0
        End If
        Return FinalMC / Qty
      End Get
    End Property    Public Property ULC() As Decimal      Get        Return m_ulc      End Get      Set(ByVal Value As Decimal)        m_ulc = Value      End Set    End Property    Public ReadOnly Property TotalLaborCost() As Decimal
      Get
        Return Me.Qty * Me.ULC
      End Get
    End Property    Public ReadOnly Property FinalLC() As Decimal
      Get
        Return TotalLaborCost + LabAdjust
      End Get
    End Property    Public ReadOnly Property FinalULC() As Decimal      Get
        If Qty = 0 Then
          Return 0
        End If
        Return FinalLC / Qty
      End Get
    End Property    Public Property UEC() As Decimal      Get        Return m_uec      End Get      Set(ByVal Value As Decimal)        m_uec = Value      End Set    End Property    Public ReadOnly Property TotalEquipmentCost() As Decimal
      Get
        Return Me.Qty * Me.UEC
      End Get
    End Property    Public ReadOnly Property FinalEC() As Decimal
      Get
        Return TotalEquipmentCost + EqAdjust
      End Get
    End Property    Public ReadOnly Property FinalUEC() As Decimal      Get
        If Qty = 0 Then
          Return 0
        End If
        Return FinalEC / Qty
      End Get
    End Property    Public ReadOnly Property TotalUC() As Decimal
      Get
        Return Me.UEC + Me.ULC + Me.UMC
      End Get
    End Property    Public ReadOnly Property TotalCost() As Decimal
      Get
        Return Me.TotalEquipmentCost + Me.TotalLaborCost + Me.TotalMaterialCost
      End Get
    End Property    Public ReadOnly Property FinalTotal() As Decimal      Get
        Return TotalCost + Me.DirectCostAdjust
      End Get
    End Property    Public Property Note() As String      Get        Return m_note      End Get      Set(ByVal Value As String)        m_note = Value      End Set    End Property

    Public Property MatCBS As CBS
      Get
        Return m_mcbs
      End Get
      Set(ByVal value As CBS)
        m_mcbs = value
      End Set
    End Property
    Public Property LabCBS As CBS
      Get
        Return m_lcbs
      End Get
      Set(ByVal value As CBS)
        m_lcbs = value
      End Set
    End Property
    Public Property EqCBS As CBS
      Get
        Return m_ecbs
      End Get
      Set(ByVal value As CBS)
        m_ecbs = value
      End Set
    End Property

#End Region

#Region "Methods"
    Public Sub CopyToDataRow(ByVal row As TreeRow)
      If row Is Nothing Then
        Return
      End If
      Me.BOQ.IsInitialized = False
      row("boqi_linenumber") = Me.LineNumber
      If Not Me.WBS Is Nothing Then
        row("boqi_wbs") = Me.WBS.Id
      End If

      If Not Me.Entity Is Nothing Then
        row("boqi_entity") = Me.Entity.Id
        row("boqi_entityType") = Me.ItemType.Value
        row("Code") = Me.Entity.Code
        row("boqi_itemName") = Me.Entity.Name
        If Not Me.ItemType.Value = 0 Then
          If Not Me.EntityName Is Nothing AndAlso Me.EntityName.Length > 0 Then
            row("boqi_itemName") = Me.EntityName & "<" & Me.Entity.Name & ">"
          End If
        End If
      End If

      If Not Me.Unit Is Nothing Then
        row("boqi_unit") = Me.Unit.Id
        row("Unit") = Me.Unit.Name
      End If

      row("boqi_qty") = ""
      row("boqi_umc") = ""
      row("TotalMaterialCost") = ""
      row("boqi_ulc") = ""
      row("TotalLaborCost") = ""
      row("boqi_uec") = ""
      row("TotalEquipmentCost") = ""

      If Me.Qty <> 0 Then
        row("boqi_qty") = Me.Qty
        If Me.UMC <> 0 Then
          row("boqi_umc") = Me.UMC
          row("TotalMaterialCost") = Me.TotalMaterialCost
        End If
        If Me.ULC <> 0 Then
          row("boqi_ulc") = Me.ULC
          row("TotalLaborCost") = Me.TotalLaborCost
        End If
        If Me.UEC <> 0 Then
          row("boqi_uec") = Me.UEC
          row("TotalEquipmentCost") = Me.TotalEquipmentCost
        End If
        If Me.QtyPerWBS <> 0 Then
          row("QtyPerWBS") = Configuration.FormatToString(Me.QtyPerWBS, DigitConfig.Qty)
        End If
        If Me.TotalPerWBS <> 0 Then
          row("TotalPerWBS") = Configuration.FormatToString(Me.TotalPerWBS, DigitConfig.Qty)
        End If
      End If

      row("boqi_note") = Me.Note

      Me.BOQ.IsInitialized = True
    End Sub
    Public Sub CopyFromDataRow(ByVal row As TreeRow)
      If row Is Nothing Then
        Return
      End If
      Try
        If Not row.IsNull(("boqi_linenumber")) Then
          Me.LineNumber = CInt(row("boqi_linenumber"))
        End If

        If Not row.IsNull(("boqi_wbs")) Then
          Me.WBS = New WBS(CInt(row("boqi_wbs")))
        Else
          Me.WBS = New WBS
        End If

        If Not row.IsNull(("boqi_unit")) Then
          Me.Unit = New Unit(CInt(row("boqi_unit")))
        Else
          Me.Unit = New Unit
        End If

        If Not row.IsNull(("boqi_entityType")) Then
          Me.ItemType = New BOQItemType(CInt(row("boqi_entityType")))
          Select Case CInt(row("boqi_entityType"))
            Case 0 'Blank
              If Not row.IsNull(("boqi_itemName")) Then
                Me.Entity = New BlankItem(row("boqi_itemName").ToString)
                Me.EntityName = row("boqi_itemName").ToString
              Else
                Me.Entity = New BlankItem("")
                Me.EntityName = ""
              End If
            Case Else
              If Not row.IsNull(("boqi_entity")) Then
                Me.Entity = CType(SimpleBusinessEntityBase.GetEntity(BusinessLogic.Entity.GetFullClassName(CInt(row("boqi_entityType"))), CInt(row("boqi_entity"))), IHasName)
              End If
              If Not row.IsNull(("boqi_itemName")) Then
                Dim suffix As String = "<" & Me.Entity.Name & ">"
                Dim s As String = row("boqi_itemName").ToString
                If s.EndsWith(suffix) Then
                  Me.EntityName = s.Remove(s.Length - suffix.Length, suffix.Length)
                End If
              Else
                Me.EntityName = ""
              End If
              Me.Conversion = 1
              If Not Me.Unit Is Nothing AndAlso Me.Unit.Originated Then
                If TypeOf Me.Entity Is LCIItem Then
                  Dim lci As LCIItem = CType(Me.Entity, LCIItem)
                  Me.Conversion = lci.GetConversion(Me.Unit)
                Else
                  Me.Conversion = 1
                End If
              End If
          End Select
        End If

        If Not row.IsNull(("boqi_qty")) Then
          If CStr(row("boqi_qty")).Length = 0 Then
            Me.Qty = 0
          Else
            Me.Qty = CDec(row("boqi_qty"))
          End If
        End If
        If Not row.IsNull(("boqi_umc")) Then
          If CStr(row("boqi_umc")).Length = 0 Then
            Me.UMC = 0
          Else
            Me.UMC = CDec(row("boqi_umc"))
          End If
        End If
        If Not row.IsNull(("boqi_ulc")) Then
          If CStr(row("boqi_ulc")).Length = 0 Then
            Me.ULC = 0
          Else
            Me.ULC = CDec(row("boqi_ulc"))
          End If
        End If
        If Not row.IsNull(("boqi_uec")) Then
          If CStr(row("boqi_uec")).Length = 0 Then
            Me.UEC = 0
          Else
            Me.UEC = CDec(row("boqi_uec"))
          End If
        End If
        If Not row.IsNull(("boqi_note")) Then
          Me.Note = CStr(row("boqi_note"))
        End If

      Catch ex As Exception
        MessageBox.Show(ex.Message & "::" & ex.StackTrace)
      End Try

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
        GC.SuppressFinalize(Me)
      End If
      'Undone : clear all resource
      Me.m_boq = Nothing
      Me.m_wbs = Nothing
    End Sub
#End Region

  End Class

  <Serializable(), DefaultMember("Item")> _
Public Class BoqItemCollection
    Inherits CollectionBase
    Implements IDisposable

#Region "Members"
    Private m_boq As Boq
#End Region

#Region "Constructors"
    Public Sub New()
    End Sub
    Public Sub New(ByVal owner As Boq)
      Me.m_boq = owner
      If Not Me.m_boq.Originated Then
        Return
      End If

      Dim sqlConString As String = RecentCompanies.CurrentCompany.SiteConnectionString

      Dim ds As DataSet = SqlHelper.ExecuteDataset(sqlConString _
      , CommandType.StoredProcedure _
      , "GetBoqItems" _
      , New SqlParameter("@boq_id", Me.m_boq.Id) _
      )

      For Each row As DataRow In ds.Tables(0).Rows
        Dim item As New BoqItem(row, "", m_boq)
        item.BOQ = m_boq
        Me.Add(item)
      Next
    End Sub
#End Region

#Region "Properties"
    Public Property Boq() As Boq      Get        Return m_boq      End Get      Set(ByVal Value As Boq)        m_boq = Value      End Set    End Property    Default Public Property Item(ByVal index As Integer) As BoqItem
      Get
        Return CType(MyBase.List.Item(index), BoqItem)
      End Get
      Set(ByVal value As BoqItem)
        MyBase.List.Item(index) = value
      End Set
    End Property
#End Region

#Region "Class Methods"
    Public Sub ResetItemsAdj()
      For Each item As BoqItem In Me
        item.MatAdjust = 0
        item.LabAdjust = 0
        item.EqAdjust = 0
        item.DirectCostAdjust = 0
      Next
    End Sub
    Public Function GetBudgetQtyForType0(ByVal name As String) As Decimal
      Dim ret As Decimal = 0
      For Each item As BoqItem In Me
        If item.ItemType.Value = 0 AndAlso item.EntityName.ToLower = name.ToLower Then
          ret += item.StockQty
        End If
      Next
      Return ret
    End Function
    Public Function GetTotalMat() As Decimal
      Dim ret As Decimal = 0
      For Each item As BoqItem In Me
        ret += item.TotalMaterialCost
      Next
      Return ret
    End Function
    Public Function GetTotalMatQty(ByVal matId As Integer) As Decimal
      Dim ret As Decimal = 0
      For Each item As BoqItem In Me
        If item.ItemType.Value = 42 AndAlso item.Entity.Id = matId Then
          ret += item.StockQty
        End If
      Next
      Return ret
    End Function
    Public Function GetFinalMat() As Decimal
      Dim ret As Decimal = 0
      For Each item As BoqItem In Me
        ret += item.FinalMC
      Next
      Return ret
    End Function
    Public Function GetTotalLab() As Decimal
      Dim ret As Decimal = 0
      For Each item As BoqItem In Me
        ret += item.TotalLaborCost
      Next
      Return ret
    End Function
    Public Function GetTotalLabQty(ByVal name As String) As Decimal
      Dim ret As Decimal = 0
      For Each item As BoqItem In Me
        If item.ItemType.Value = 88 AndAlso item.Entity.Name.ToLower = name.ToLower Then
          ret += item.StockQty
        End If
      Next
      Return ret
    End Function
    Public Function GetFinalLab() As Decimal
      Dim ret As Decimal = 0
      For Each item As BoqItem In Me
        ret += item.FinalLC
      Next
      Return ret
    End Function
    Public Function GetTotalEq() As Decimal
      Dim ret As Decimal = 0
      For Each item As BoqItem In Me
        ret += item.TotalEquipmentCost
      Next
      Return ret
    End Function
    Public Function GetTotalEqQty(ByVal name As String) As Decimal
      Dim ret As Decimal = 0
      For Each item As BoqItem In Me
        If item.ItemType.Value = 89 AndAlso item.Entity.Name.ToLower = name.ToLower Then
          ret += item.StockQty
        End If
      Next
      Return ret
    End Function
    Public Function GetFinalEq() As Decimal
      Dim ret As Decimal = 0
      For Each item As BoqItem In Me
        ret += item.FinalEC
      Next
      Return ret
    End Function
    Public Function GetTotal() As Decimal
      Dim ret As Decimal = 0
      For Each item As BoqItem In Me
        ret += item.TotalCost
      Next
      Return ret
    End Function
    Public Function GetTotalPerWbs() As Decimal
      Dim ret As Decimal = 0
      For Each item As BoqItem In Me
        ret += item.TotalPerWBS
      Next
      Return ret
    End Function
    Public Function GetTotalQty() As Decimal
      Dim ret As Decimal = 0
      For Each item As BoqItem In Me
        ret += item.Qty
      Next
      Return ret
    End Function
    Public Function GetFinalTotal() As Decimal
      Dim ret As Decimal = 0
      For Each item As BoqItem In Me
        ret += item.FinalTotal
      Next
      Return ret
    End Function
    Public Sub UpdateWbsId(ByVal oldParid As Integer, ByVal newParid As Integer)
      For Each boqi As BoqItem In Me
        If Not Me.Boq.WBSCollection.Contains(boqi.WBS) Then
          If boqi.WBS.Id = oldParid Then
            boqi.WBS.Id = newParid
          End If
        End If
      Next
    End Sub
    Public Function GetCollectionForWBS(ByVal wbs As WBS) As BoqItemCollection
      Dim myCollection As New BoqItemCollection
      myCollection.Boq = Me.Boq
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
    Public Function FindItemFromItem(ByVal item As BoqItem) As BoqItem
      For Each myItem As BoqItem In Me
        If myItem Is item Then
          Return myItem
        ElseIf myItem.LineNumber = item.LineNumber Then
          Return myItem
        End If
      Next
    End Function
#End Region

#Region "Collection Methods"
    Public Function Add(ByVal value As BoqItem) As Integer
      value.BOQ = m_boq
      Return MyBase.List.Add(value)
    End Function
    Public Sub AddRange(ByVal value As BoqItemCollection)
      For i As Integer = 0 To value.Count - 1
        value(i).BOQ = m_boq
        Me.Add(value(i))
      Next
    End Sub
    Public Sub AddRange(ByVal value As BoqItem())
      For i As Integer = 0 To value.Length - 1
        value(i).BOQ = m_boq
        Me.Add(value(i))
      Next
    End Sub
    Public Function Contains(ByVal value As BoqItem) As Boolean
      'For Each myItem As BoqItem In Me
      '    If value.BOQ Is myItem.BOQ Then
      '        If myItem.LineNumber = value.LineNumber Then
      '            Return True
      '        End If
      '    ElseIf value.BOQ.Originated And value.BOQ.Id = myItem.BOQ.Id Then
      '        If myItem.LineNumber = value.LineNumber Then
      '            Return True
      '        End If
      '    End If
      'Next
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
      value.BOQ = m_boq
      MyBase.List.Insert(index, value)
    End Sub
    Public Sub Remove(ByVal value As BoqItem)
      MyBase.List.Remove(value)
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
      Me.m_boq = Nothing
    End Sub
#End Region


    Public Class BoqItemEnumerator
      Implements IEnumerator

#Region "Members"
      Private m_baseEnumerator As IEnumerator
      Private m_temp As IEnumerable
#End Region

#Region "Construtor"
      Public Sub New(ByVal mappings As BoqItemCollection)
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

