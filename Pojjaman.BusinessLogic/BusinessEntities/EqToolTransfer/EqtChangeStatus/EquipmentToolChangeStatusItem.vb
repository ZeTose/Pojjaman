Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration
Imports Longkong.Pojjaman.Services
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Imports System.Reflection
Imports Syncfusion.Windows.Forms.Grid

Namespace Longkong.Pojjaman.BusinessLogic

  Public Class EquipmentToolChangeStatusItem
    Inherits EqtItem

#Region "Members"
    Private m_eqtChangeStatus As EquipmentToolChangeStatus
    Private m_sequenceRefedto As Integer 'อาจไม่ต้องมีแล้ว

    Private m_itemcollection As StockItemCollection
    'Private m_rentalqty As Integer
    'Private m_rentalperday As Decimal
    Private m_Amt As Decimal
    Private m_Note As String
    'Private m_WBSDistributeCollection As WBSDistributeCollection
    'Private m_internalChargeCollection As InternalChargeCollection
#End Region

#Region "Constructors"
    Public Sub New()
      MyBase.New()
      'm_WBSDistributeCollection = New WBSDistributeCollection
    End Sub
    Public Sub New(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
      Me.Construct(ds, aliasPrefix)
    End Sub
    Public Sub New(ByVal dr As DataRow, ByVal aliasPrefix As String)
      Me.Construct(dr, aliasPrefix)
    End Sub
    Protected Overrides Sub Construct(ByVal dr As DataRow, ByVal aliasPrefix As String)
      MyBase.Construct(dr, aliasPrefix)
      With Me
        Dim deh As New DataRowHelper(dr)

        '.m_rentalperday = deh.GetValue(Of Decimal)(aliasPrefix & "eqtstocki_rentalrate")
        '.m_rentalqty = deh.GetValue(Of Integer)(aliasPrefix & "eqtstocki_rentalqty")
        .m_Amt = deh.GetValue(Of Decimal)(aliasPrefix & "eqtstocki_Amount")
        '' Sequence Refed to ...
        'If dr.Table.Columns.Contains(aliasPrefix & "refto") AndAlso Not dr.IsNull(aliasPrefix & "refto") Then
        '  .m_sequenceRefedto = CInt(dr(aliasPrefix & "refto"))
        'End If

        'If dr.Table.Columns.Contains(aliasPrefix & "stocki_sequence") AndAlso Not dr.IsNull(aliasPrefix & "stocki_sequence") Then
        '  m_sequence = CInt(dr(aliasPrefix & "stocki_sequence"))
        'End If


      End With
    End Sub
    Protected Overrides Sub Construct(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
      Dim dr As DataRow = ds.Tables(0).Rows(0)
      Me.Construct(dr, aliasPrefix)
    End Sub
#End Region


#Region "Properties"
    'Public Property WBSDistributeCollection() As WBSDistributeCollection    '  Get    '    Return m_WBSDistributeCollection    '  End Get    '  Set(ByVal Value As WBSDistributeCollection)    '    m_WBSDistributeCollection = Value    '  End Set    'End Property
    'Public Property InternalChargeCollection() As InternalChargeCollection    '  Get    '    If m_internalChargeCollection Is Nothing Then    '      m_internalChargeCollection = New InternalChargeCollection(Me)
    '    End If    '    Return m_internalChargeCollection    '  End Get    '  Set(ByVal Value As InternalChargeCollection)    '    m_internalChargeCollection = Value    '  End Set    'End Property

    Public Property ExpItemCollection As StockItemCollection
      Get
        Return m_itemcollection
      End Get
      Set(ByVal value As StockItemCollection)
        m_itemcollection = value
      End Set
    End Property  
    Public Overrides Property Amount() As Decimal      Get        If ExpItemCollection IsNot Nothing Then          Return ExpItemCollection.amount        End If      End Get      Set(ByVal value As Decimal)
        m_Amt = value
      End Set    End Property
    Public Property EqtChangeStatus() As EquipmentToolChangeStatus
      Get        Return m_eqtChangeStatus      End Get      Set(ByVal Value As EquipmentToolChangeStatus)        m_eqtChangeStatus = Value      End Set    End Property
    Public Property SequenceRefedto() As Integer      Get        Return m_sequenceRefedto      End Get      Set(ByVal Value As Integer)        m_sequenceRefedto = Value      End Set    End Property    Public Function DupCode(ByVal myCode As String) As Boolean      If Me.EqtChangeStatus Is Nothing Then
        Return False
      End If      If myCode Is Nothing OrElse myCode.Length = 0 Then
        Return False
      End If
      For Each item As EquipmentToolChangeStatusItem In Me.EqtChangeStatus.ItemCollection
        If Not item Is Me Then
          Dim theCode As String = ""
          If Not item.Entity Is Nothing Then
            theCode = item.Entity.Code
          End If
          If Not theCode Is Nothing AndAlso theCode.Length > 0 Then
            If myCode.ToLower = theCode.ToLower Then
              Return True
            End If
          End If
        End If
      Next
      Return False
    End Function    'Protected Overrides Function GetLimitQty() As Decimal
    '  Dim sqlConString As String = RecentCompanies.CurrentCompany.ConnectionString

    '  Dim ds As DataSet = SqlHelper.ExecuteDataset(sqlConString, CommandType.StoredProcedure, "GetEqtLimitQty", _
    '                                                                                              New SqlParameter("@stockid", Me.EqtChangeStatus.Id), _
    '                                                                                              New SqlParameter("@eqtid", Me.Entity.Id), _
    '                                                                                              New SqlParameter("@fromCC", Me.EqtChangeStatus.StoreCostcenter), _
    '                                                                                              New SqlParameter("@EntityType", Me.Entity.EntityId), _
    '                                                New SqlParameter("@eqtstatus", Me.FromStatus.Value))
    'End Function    'Public Sub SetItemCode(ByVal theCode As String)    '  Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
    '  If Me.ItemType Is Nothing Then
    '    'ไม่มี Type
    '    msgServ.ShowMessage("${res:Global.Error.NoItemType}")
    '    Return
    '  End If
    '  'If DupCode(theCode) Then
    '  '    msgServ.ShowMessageFormatted("${res:Global.Error.AlreadyHasCode}", New String() {"Asset", theCode})
    '  '    Return
    '  'End If
    '  Select Case Me.ItemType.Value
    '    Case 342 'F/A
    '      If theCode Is Nothing OrElse theCode.Length = 0 Then
    '        If Me.Entity.Code.Length <> 0 Then
    '          If msgServ.AskQuestionFormatted("${res:Global.Question.DeleteAssetDetail}", New String() {Me.Entity.Code}) Then
    '            Me.Clear()
    '          End If
    '        End If
    '        Return
    '      End If
    '      Dim myEquipment As New EquipmentItem(theCode)
    '      If Not myEquipment.Originated Then
    '        msgServ.ShowMessageFormatted("${res:Global.Error.NoAsset}", New String() {theCode})
    '        Return
    '      Else
    '        Me.Entity = myEquipment
    '      End If
    '    Case 19 'Tool
    '      If theCode Is Nothing OrElse theCode.Length = 0 Then
    '        If Me.Entity.Code.Length <> 0 Then
    '          If msgServ.AskQuestionFormatted("${res:Global.Question.DeleteToolDetail}", New String() {Me.Entity.Code}) Then
    '            Me.Clear()
    '          End If
    '        End If
    '        Return
    '      End If
    '      Dim myTool As New Tool(theCode)
    '      If Not myTool.Originated Then
    '        msgServ.ShowMessageFormatted("${res:Global.Error.NoTool}", New String() {theCode})
    '        Return
    '      Else
    '        Me.Entity = myTool
    '      End If
    '    Case Else
    '      msgServ.ShowMessage("${res:Global.Error.NoItemType}")
    '      Return
    '  End Select
    '  Me.Qty = 1
    'End Sub
#End Region

#Region "Methods"
    'Public Sub Clear()
    '  'Me.Entity = New EquipmentToolReturnItem
    '  Me.Qty = 0
    '  Me.Note = ""
    'End Sub
    Public Overrides Sub ItemValidateRow(ByVal row As DataRow)
      MyBase.ItemValidateRow(row)
      'Dim code As Object = row("Code")
    End Sub
    Public Overrides Sub CopyToDataRow(ByVal row As TreeRow)
      'MyBase.CopyToDataRow(row)
      If row Is Nothing Then
        Return
      End If
      Try
        Me.EqtChangeStatus.IsInitialized = False
        Dim rpd As Decimal = 0
        Dim rentrate As Decimal = 0
        row("Linenumber") = Me.LineNumber
        row("Type") = Me.ItemType.Value
        If Not Me.Entity Is Nothing Then
          row("eqtstocki_entity") = Me.Entity.Id
          row("Code") = Me.Entity.Code
          row("Name") = Me.Entity.Name
          If Not Me.Entity.Unit Is Nothing Then
            Me.Unit = Me.Entity.Unit
            row("UnitName") = Me.Entity.Unit.Name
          End If
          rentrate = Me.Entity.RentalRate
        End If

        'row("Name") = Me.name

        row("Button") = ""

        row("Note") = Me.Note

        If Me.Qty <> 0 Then
          row("QTY") = Configuration.FormatToString(Me.Qty, DigitConfig.Int)
        Else
          row("QTY") = ""
        End If
        If Me.ExpItemCollection IsNot Nothing Then
          If Me.ExpItemCollection.Amount <> 0 Then
            row("Amount") = CDec(Configuration.FormatToString(Me.ExpItemCollection.Amount, DigitConfig.Price))
          Else
            row("Amount") = ""
          End If
        End If
        Me.EqtChangeStatus.IsInitialized = True
      Catch ex As Exception
        MessageBox.Show(ex.Message & "::" & ex.StackTrace)
      End Try
    End Sub
    '''To do เอาไว้ก่อนแล้วกัน
    'Public Sub RefreshLimitQty()
    '  If Not Me.m_eqtChangeStatus.Originated Then
    '    Return
    '  End If

    '  Dim sqlConString As String = RecentCompanies.CurrentCompany.ConnectionString

    '  Dim ds As DataSet = SqlHelper.ExecuteDataset(sqlConString _
    '  , CommandType.StoredProcedure _
    '  , "GetEqtNewLimitQty" _
    '  , New SqlParameter("@entity_id", Me.Entity.Id) _
    '  , New SqlParameter("@entity_type", Me.ItemType.Value) _
    '  , New SqlParameter("@fromStatus", Me.FromStatus.Value) _
    '  )
    '  Dim dtExp As DataTable = ds.Tables(1)
    'End Sub
#End Region

  End Class

  <Serializable(), DefaultMember("Item")> _
  Public Class EquipmentToolChangeStatusItemCollection
    Inherits CollectionBase

#Region "Members"
    Private m_eqtChangeStatus As EquipmentToolChangeStatus
#End Region

#Region "Constructors"
    Public Sub New()
    End Sub
    Public Sub New(ByVal owner As EquipmentToolChangeStatus)
      Me.m_eqtChangeStatus = owner
      If Not Me.m_eqtChangeStatus.Originated Then
        Return
      End If

      Dim sqlConString As String = RecentCompanies.CurrentCompany.ConnectionString

      Dim ds As DataSet = SqlHelper.ExecuteDataset(sqlConString _
      , CommandType.StoredProcedure _
      , "GetEquipmentToolChangeStatusItems" _
      , New SqlParameter("@eqtstock_id", Me.m_eqtChangeStatus.Id) _
      )
      Dim dtExp As DataTable = ds.Tables(1)

      For Each row As DataRow In ds.Tables(0).Rows
        Dim item As New EquipmentToolChangeStatusItem(row, "")
        item.EqtChangeStatus = m_eqtChangeStatus
        If item.ExpItemCollection Is Nothing Then
          item.ExpItemCollection = New StockItemCollection
        End If
        Me.Add(item)
        For Each exprow As DataRow In dtExp.Select("es_eqtstockisequence =" & item.Sequence)
          Dim si As New StockItem(exprow, "", True)
          If item.ExpItemCollection Is Nothing Then
            item.ExpItemCollection = New StockItemCollection
          End If
          item.ExpItemCollection.Add(si)
          si.RefEqtItem = item
        Next
      Next
    End Sub
#End Region

#Region "Properties"
    Public Property EqtChangeStatus() As EquipmentToolChangeStatus
      Get        Return m_eqtChangeStatus
      End Get      Set(ByVal Value As EquipmentToolChangeStatus)        m_eqtChangeStatus = Value
      End Set    End Property    Default Public Property Item(ByVal index As Integer) As EquipmentToolChangeStatusItem
      Get
        Return CType(MyBase.List.Item(index), EquipmentToolChangeStatusItem)
      End Get
      Set(ByVal value As EquipmentToolChangeStatusItem)
        MyBase.List.Item(index) = value
      End Set
    End Property
    Public Property CurrentItem() As EquipmentToolChangeStatusItem
    '  Get
    '    Return m_currentItem
    '  End Get
    '  Set(ByVal Value As EqtItem)
    '    m_currentItem = Value
    '  End Set
    'End Property
    Public ReadOnly Property Gross As Decimal
      Get
        Dim ret As Decimal = 0
        For Each Item As EquipmentToolChangeStatusItem In Me
          ret += Item.Amount
        Next
        Return ret
      End Get
    End Property
    Public ReadOnly Property RealAmount As Decimal
      Get
        Dim amt As Decimal = 0
        For Each eqti As EquipmentToolChangeStatusItem In Me
          If Not eqti.ExpItemCollection Is Nothing Then
            amt += eqti.ExpItemCollection.Amount
          End If
        Next
        Return amt
      End Get
    End Property
#End Region

#Region "Class Methods"
    Public Sub Populate(ByVal dt As TreeTable)
      dt.Clear()
      Dim i As Integer = 0
      For Each gri As EquipmentToolChangeStatusItem In Me
        i += 1
        Dim newRow As TreeRow = dt.Childs.Add()
        gri.CopyToDataRow(newRow)
        gri.ItemValidateRow(newRow)
        newRow.Tag = gri
      Next
      dt.AcceptChanges()
    End Sub
#End Region

#Region "Collection Methods"
    Public Overridable Function Add(ByVal value As EquipmentToolChangeStatusItem) As Integer
      If Not m_eqtChangeStatus Is Nothing Then
        value.EqtChangeStatus = m_eqtChangeStatus
      End If
      Return MyBase.List.Add(value)
    End Function
    Public Sub AddRange(ByVal value As EquipmentToolChangeStatusItemCollection)
      For i As Integer = 0 To value.Count - 1
        Me.Add(value(i))
      Next
    End Sub
    Public Sub AddRange(ByVal value As EquipmentToolChangeStatusItem())
      For i As Integer = 0 To value.Length - 1
        Me.Add(value(i))
      Next
    End Sub
    Public Function Contains(ByVal value As EquipmentToolChangeStatusItem) As Boolean
      Return MyBase.List.Contains(value)
    End Function
    Public Sub CopyTo(ByVal array As EquipmentToolChangeStatusItem(), ByVal index As Integer)
      MyBase.List.CopyTo(array, index)
    End Sub
    Public Shadows Function GetEnumerator() As EquipmentToolChangeStatusItemEnumerator
      Return New EquipmentToolChangeStatusItemEnumerator(Me)
    End Function
    Public Function IndexOf(ByVal value As EquipmentToolChangeStatusItem) As Integer
      Return MyBase.List.IndexOf(value)
    End Function
    Public Overridable Sub Insert(ByVal index As Integer, ByVal value As EquipmentToolChangeStatusItem)
      If Not m_eqtChangeStatus Is Nothing Then
        value.EqtChangeStatus = m_eqtChangeStatus
      End If
      MyBase.List.Insert(index, value)
    End Sub
    Public Sub Remove(ByVal value As EquipmentToolChangeStatusItem)
      MyBase.List.Remove(value)
    End Sub
    Public Sub Remove(ByVal value As EquipmentToolChangeStatusItemCollection)
      For i As Integer = 0 To value.Count - 1
        Me.Remove(value(i))
      Next
    End Sub
    Public Sub Remove(ByVal index As Integer)
      MyBase.List.RemoveAt(index)
    End Sub
#End Region

    Public Class EquipmentToolChangeStatusItemEnumerator
      Implements IEnumerator

#Region "Members"
      Private m_baseEnumerator As IEnumerator
      Private m_temp As IEnumerable
#End Region

#Region "Construtor"
      Public Sub New(ByVal mappings As EquipmentToolChangeStatusItemCollection)
        Me.m_temp = mappings
        Me.m_baseEnumerator = Me.m_temp.GetEnumerator
      End Sub
#End Region

      Public ReadOnly Property Current() As Object Implements System.Collections.IEnumerator.Current
        Get
          Return CType(Me.m_baseEnumerator.Current, EquipmentToolChangeStatusItem)
        End Get
      End Property

      Public Function MoveNext() As Boolean Implements System.Collections.IEnumerator.MoveNext
        Return Me.m_baseEnumerator.MoveNext
      End Function

      Public Sub Reset() Implements System.Collections.IEnumerator.Reset
        Me.m_baseEnumerator.Reset()
      End Sub
    End Class

    Function EqIdList() As Object
      Dim list As New Generic.List(Of String)
      For Each i As EquipmentToolChangeStatusItem In Me
        If TypeOf i.Entity Is EquipmentItem Then
          list.Add(i.Entity.Id.ToString)
        End If
      Next
      Return String.Join(",", list)

    End Function

  End Class

 
End Namespace
