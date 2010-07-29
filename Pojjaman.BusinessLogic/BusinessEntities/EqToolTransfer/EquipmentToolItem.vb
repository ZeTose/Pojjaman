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

  Public Interface IEqtItem
    Inherits IHasRentalRate
    Property Unit As Unit
  End Interface


  Public Class EqtItemType
    Inherits CodeDescription

#Region "Constructors"
    Public Sub New(ByVal value As Integer)
      MyBase.New(value)
    End Sub
#End Region

#Region "Properties"
    Public Overrides ReadOnly Property CodeName() As String
      Get
        Return "eqtstocki_entityType"
      End Get
    End Property
#End Region

  End Class

  Public Class EqtStatus
    Inherits CodeDescription

#Region "Constructors"
    Public Sub New(ByVal value As Integer)
      MyBase.New(value)
    End Sub
#End Region

#Region "Properties"
    Public Overrides ReadOnly Property CodeName() As String
      Get
        Return "eqtstatus"
      End Get
    End Property
#End Region

  End Class

  Public Class EqtItem

#Region "Members"
    Private m_lineNumber As Integer
    Private m_entityitem As IEqtItem
    Private m_name As String
    Private m_note As String
    'Private m_amount As Decimal

    Protected m_sequence As Integer

    Protected m_itemtype As EqtItemType
    Protected m_fromstatus As EqtStatus
    Protected m_tostatus As EqtStatus

    Protected m_unit As Unit
    Protected m_qty As Integer = 1
    Protected m_rentalqty As Integer
    Protected m_rentalperday As Decimal
    Protected m_ownercc As CostCenter

    Private m_WBSDistributeCollection As WBSDistributeCollection
#End Region

#Region "Constructors"
    Public Sub New()
      MyBase.New()
      m_WBSDistributeCollection = New WBSDistributeCollection
    End Sub
    Public Sub New(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
      Me.Construct(ds, aliasPrefix)
    End Sub
    Public Sub New(ByVal dr As DataRow, ByVal aliasPrefix As String)
      Me.Construct(dr, aliasPrefix)
    End Sub
    Protected Overridable Sub Construct(ByVal dr As DataRow, ByVal aliasPrefix As String)
      With Me
        ' Line number ...
        If dr.Table.Columns.Contains(aliasPrefix & "eqtstocki_lineNumber") AndAlso Not dr.IsNull(aliasPrefix & "eqtstocki_lineNumber") Then
          .m_lineNumber = CInt(dr(aliasPrefix & "eqtstocki_lineNumber"))
        End If



        If dr.Table.Columns.Contains(aliasPrefix & "eqtstocki_entityType") AndAlso Not dr.IsNull(aliasPrefix & "eqtstocki_entityType") Then
          .m_itemtype = New EqtItemType(CInt(dr(aliasPrefix & "eqtstocki_entityType")))
        End If

        Dim itemId As Integer

        If dr.Table.Columns.Contains(aliasPrefix & "eqtstocki_entity") AndAlso Not dr.IsNull(aliasPrefix & "eqtstocki_entity") Then
          itemId = CInt(dr(aliasPrefix & "eqtstocki_entity"))
        End If

        Select Case .m_itemtype.Value
          Case 19 '"tool"
            If dr.Table.Columns.Contains("tool_id") AndAlso Not dr.IsNull("tool_id") Then
              If Not dr.IsNull("tool_id") Then
                .m_entityitem = New Tool(dr, "")
              End If
            Else
              .m_entityitem = New Tool(itemId)
            End If
          Case 28
            If dr.Table.Columns.Contains("asset_id") AndAlso Not dr.IsNull("asset_id") Then
              If Not dr.IsNull("asset_id") Then
                .m_entityitem = New Asset(dr, "")
              End If
            Else
              .m_entityitem = New Asset(itemId)
            End If
          Case 342
            If dr.Table.Columns.Contains("eqi_id") AndAlso Not dr.IsNull("eqi_id") Then
              If Not dr.IsNull("eqi_id") Then
                .m_entityitem = New EquipmentItem(dr, "")
              End If
            Else
              .m_entityitem = New EquipmentItem(itemId)
            End If
        End Select

        If dr.Table.Columns.Contains(aliasPrefix & "eqtstocki_name") AndAlso Not dr.IsNull(aliasPrefix & "eqtstocki_name") Then
          .m_name = CStr(dr(aliasPrefix & "eqtstocki_name"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "eqtstocki_qty") AndAlso Not dr.IsNull(aliasPrefix & "eqtstocki_qty") Then
          .m_qty = CInt(dr(aliasPrefix & "eqtstocki_qty"))
        End If
        ' Stock Note ...
        If dr.Table.Columns.Contains(aliasPrefix & "eqtstocki_note") AndAlso Not dr.IsNull(aliasPrefix & "eqtstocki_note") Then
          .m_note = CStr(dr(aliasPrefix & "eqtstocki_note"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "eqtstocki_sequence") AndAlso Not dr.IsNull(aliasPrefix & "eqtstocki_sequence") Then
          m_sequence = CInt(dr(aliasPrefix & "eqtstocki_sequence"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "owner_cc") AndAlso Not dr.IsNull(aliasPrefix & "owner_cc") Then
          m_ownercc = CostCenter.GetCCMinDataById(CInt(dr(aliasPrefix & "owner_cc")))
        End If

        'If dr.Table.Columns.Contains(aliasPrefix & "eqtstocki_amt") AndAlso Not dr.IsNull(aliasPrefix & "eqtstocki_amt") Then
        '  m_amount = CDec(dr(aliasPrefix & "eqtstocki_amt"))
        'End If
      End With
    End Sub
    Protected Overridable Sub Construct(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
      Dim dr As DataRow = ds.Tables(0).Rows(0)
      Me.Construct(dr, aliasPrefix)
    End Sub
#End Region

#Region "Properties"
    Public Property WBSDistributeCollection() As WBSDistributeCollection      Get        Return m_WBSDistributeCollection      End Get      Set(ByVal Value As WBSDistributeCollection)        m_WBSDistributeCollection = Value      End Set    End Property
    'Public Property InternalChargeCollection() As InternalChargeCollection    '  Get    '    If m_internalChargeCollection Is Nothing Then    '      m_internalChargeCollection = New InternalChargeCollection(Me)
    '    End If    '    Return m_internalChargeCollection    '  End Get    '  Set(ByVal Value As InternalChargeCollection)    '    m_internalChargeCollection = Value    '  End Set    'End Property
    Public Property ItemType() As EqtItemType      Get        Return m_itemtype      End Get      Set(ByVal Value As EqtItemType)        Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
        If m_itemtype Is Nothing Then
          m_itemtype = Value
          Me.Clear()
          Return
        End If
        If Not Value Is Nothing AndAlso Value.Value = m_itemtype.Value Then
          'ผ่านโลด
          Return
        End If
        If m_itemtype Is Nothing OrElse m_itemtype.Value = 0 OrElse msgServ.AskQuestion("${res:Global.Question.ChangeAssetWithdrawEntityType}") Then
          m_itemtype = Value
          'Me.Clear()
        End If      End Set    End Property
    Public Property FromStatus As EqtStatus
      Get
        Return m_fromstatus
      End Get
      Set(ByVal value As EqtStatus)
        m_fromstatus = value
      End Set
    End Property
    Public Property ToStatus As EqtStatus
      Get
        Return m_tostatus
      End Get
      Set(ByVal value As EqtStatus)
        m_tostatus = value
      End Set
    End Property
    Public Property Name() As String      Get        Return m_name      End Get      Set(ByVal value As String)
        m_name = value
      End Set    End Property

    Public ReadOnly Property Sequence() As Integer      Get        Return m_sequence      End Get    End Property
    'Public Property RentalPerDay() As Decimal    '  Get    '    Return m_rentalperday    '  End Get    '  Set(ByVal value As Decimal)
    '    m_rentalperday = value
    '    m_amount = m_rentalperday * m_rentalqty
    '  End Set    'End Property
    'Public Property Amount() As Decimal    '  Get    '    Return m_amount    '  End Get    '  Set(ByVal value As Decimal)
    '    m_amount = value
    '    If m_rentalqty > 0 Then
    '      m_rentalperday = m_amount / m_rentalqty

    '    End If
    '  End Set    'End Property
    Public ReadOnly Property OwnerCostcenter As CostCenter      Get
        Return m_ownercc
      End Get
    End Property    Public Property LineNumber() As Integer      Get        Return m_lineNumber      End Get      Set(ByVal Value As Integer)        m_lineNumber = Value      End Set    End Property    Public Sub SetItemCode(ByVal theCode As String)      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      If Me.ItemType Is Nothing Then
        'ไม่มี Type
        msgServ.ShowMessage("${res:Global.Error.NoItemType}")
        Return
      End If
      'If DupCode(theCode) Then
      '    msgServ.ShowMessageFormatted("${res:Global.Error.AlreadyHasCode}", New String() {"Asset", theCode})
      '    Return
      'End If
      Select Case Me.ItemType.Value
        Case 342 'F/A
          If theCode Is Nothing OrElse theCode.Length = 0 Then
            If Me.Entity.Code.Length <> 0 Then
              If msgServ.AskQuestionFormatted("${res:Global.Question.DeleteAssetDetail}", New String() {Me.Entity.Code}) Then
                Me.Clear()
              End If
            End If
            Return
          End If
          Dim myEquipment As New EquipmentItem(theCode)
          If Not myEquipment.Originated Then
            msgServ.ShowMessageFormatted("${res:Global.Error.NoAsset}", New String() {theCode})
            Return
          Else
            Me.m_entityitem = myEquipment
          End If
        Case 19 'Tool
          If theCode Is Nothing OrElse theCode.Length = 0 Then
            If Me.Entity.Code.Length <> 0 Then
              If msgServ.AskQuestionFormatted("${res:Global.Question.DeleteToolDetail}", New String() {Me.Entity.Code}) Then
                Me.Clear()
              End If
            End If
            Return
          End If
          Dim myTool As New Tool(theCode)
          If Not myTool.Originated Then
            msgServ.ShowMessageFormatted("${res:Global.Error.NoTool}", New String() {theCode})
            Return
          Else
            Me.m_entityitem = myTool
          End If
        Case Else
          msgServ.ShowMessage("${res:Global.Error.NoItemType}")
          Return
      End Select
      Me.m_qty = 1
    End Sub    Public Property Entity() As IEqtItem      Get        Return m_entityitem      End Get      Set(ByVal Value As IEqtItem)        m_entityitem = Value      End Set    End Property    Public Property Note() As String      Get        Return m_note      End Get      Set(ByVal Value As String)        m_note = Value      End Set    End Property    Public Overridable Property Qty() As Integer      Get        If Not Me.m_itemtype Is Nothing Then          If Me.m_itemtype.Value = 342 OrElse Me.m_itemtype.Value = 28 Then
            m_qty = 1
          End If
        End If        Return m_qty      End Get      Set(ByVal Value As Integer)        Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
        If Me.ItemType Is Nothing Then
          'ไม่มี Type
          msgServ.ShowMessage("${res:Global.Error.NoItemType}")
          Return
        End If
        If Me.ItemType.Value = 160 Or Me.ItemType.Value = 162 Then
          'เป็นหมายเหตุ/หมายเหตุอ้างอิง มีปริมาณไม่ได้
          msgServ.ShowMessage("${res:Global.Error.NoteCannotHaveQty}")
          Return
        End If        m_qty = CInt(Configuration.Format(Value, DigitConfig.Int))      End Set    End Property    Public Property Unit As Unit
      Get
        Return m_unit
      End Get
      Set(ByVal value As Unit)
        m_unit = value
      End Set
    End Property#End Region

#Region "Methods"
    Public Sub Clear()
      Me.m_entityitem = New Asset
      Me.m_qty = 0
      Me.m_note = ""
    End Sub
    Public Overridable Sub ItemValidateRow(ByVal row As DataRow)
      Dim code As Object = row("Code")
    End Sub
    Public Overridable Sub CopyToDataRow(ByVal row As TreeRow)

      If row Is Nothing Then
        Return
      End If
      Try
        'Me.EqtWithdraw.IsInitialized = False

        row("Linenumber") = Me.LineNumber
        row("Type") = Me.ItemType.Value
        If Not Me.Entity Is Nothing Then
          row("Code") = Me.Entity.Code
          row("Name") = Me.Entity.Name
        End If
        row("Button") = ""

        row("Note") = Me.Note

        If Me.Qty <> 0 Then
          row("QTY") = Configuration.FormatToString(Me.Qty, DigitConfig.Int)
        Else
          row("QTY") = ""
        End If

        'Me.EqtWithdraw.IsInitialized = True
      Catch ex As Exception
        MessageBox.Show(ex.Message & "::" & ex.StackTrace)
      End Try
    End Sub
#End Region

#Region "Shared"
    Public Shared Function GetListDatatable(ByVal procName As String, ByVal ParamArray filters() As Filter) As DataTable
      Dim sqlConString As String = RecentCompanies.CurrentCompany.ConnectionString
      Dim params() As SqlParameter
      If Not filters Is Nothing AndAlso filters.Length > 0 Then
        ReDim params(filters.Length - 1)
        For i As Integer = 0 To filters.Length - 1
          params(i) = New SqlParameter("@" & filters(i).Name, filters(i).Value)
        Next
      End If
      Dim ds As DataSet = SqlHelper.ExecuteDataset(sqlConString, CommandType.StoredProcedure, procName, params)
      Return ds.Tables(0)
    End Function
#End Region

  End Class

  '<Serializable(), DefaultMember("Item")> _
  '  Public Class eqtItemCollection
  '    Inherits CollectionBase

  '#Region "Members"
  '    Private m_eqtWithdraw As EquipmentToolWithdraw
  '#End Region

  '#Region "Constructors"
  '    Public Sub New()
  '    End Sub
  '    Public Sub New(ByVal owner As EquipmentToolWithdraw)
  '      Me.m_eqtWithdraw = owner
  '      If Not Me.m_eqtWithdraw.Originated Then
  '        Return
  '      End If

  '      Dim sqlConString As String = RecentCompanies.CurrentCompany.ConnectionString

  '      Dim ds As DataSet = SqlHelper.ExecuteDataset(sqlConString _
  '      , CommandType.StoredProcedure _
  '      , "GetEquipmentToolWithdrawItems" _
  '      , New SqlParameter("@eqtstock_id", Me.m_eqtWithdraw.Id) _
  '      )

  '      For Each row As DataRow In ds.Tables(0).Rows
  '        Dim item As New EquipmentToolWithdrawItem(row, "")
  '        item.EqtWithdraw = m_eqtWithdraw
  '        Me.Add(item)
  '        'Dim wbsdColl As WBSDistributeCollection = New WBSDistributeCollection
  '        'item.WBSDistributeCollection = wbsdColl
  '        'For Each wbsRow As DataRow In ds.Tables(1).Select("stockiw_sequence=" & item.Sequence)
  '        '  Dim wbsd As New WBSDistribute(wbsRow, "")
  '        '  wbsdColl.Add(wbsd)
  '        'Next

  '        'Dim itcColl As New InternalChargeCollection(item)
  '        'item.InternalChargeCollection = itcColl
  '        'For Each itcRow As DataRow In ds.Tables(2).Select("itci_refsequence=" & item.Sequence)
  '        '  Dim itc As New InternalCharge(itcRow, "")
  '        '  itcColl.Add(itc)
  '        'Next
  '      Next
  '    End Sub
  '#End Region

  '#Region "Properties"
  '    Public Property EqtWithdraw() As EquipmentToolWithdraw  '      Get  '        Return m_eqtWithdraw  '      End Get  '      Set(ByVal Value As EquipmentToolWithdraw)  '        m_eqtWithdraw = Value  '      End Set  '    End Property  '    Default Public Property Item(ByVal index As Integer) As EquipmentToolWithdrawItem
  '      Get
  '        Return CType(MyBase.List.Item(index), EquipmentToolWithdrawItem)
  '      End Get
  '      Set(ByVal value As EquipmentToolWithdrawItem)
  '        MyBase.List.Item(index) = value
  '      End Set
  '    End Property
  '#End Region

  '#Region "Class Methods"
  '    Public Sub Populate(ByVal dt As TreeTable)
  '      dt.Clear()
  '      Dim i As Integer = 0
  '      For Each gri As EquipmentToolWithdrawItem In Me
  '        i += 1
  '        Dim newRow As TreeRow = dt.Childs.Add()
  '        gri.CopyToDataRow(newRow)
  '        gri.ItemValidateRow(newRow)
  '        newRow.Tag = gri
  '      Next
  '      dt.AcceptChanges()
  '    End Sub
  '#End Region

  '#Region "Collection Methods"
  '    Public Overridable Function Add(ByVal value As EquipmentToolWithdrawItem) As Integer
  '      If Not m_eqtWithdraw Is Nothing Then
  '        value.EqtWithdraw = m_eqtWithdraw
  '      End If
  '      Return MyBase.List.Add(value)
  '    End Function
  '    Public Sub AddRange(ByVal value As eqtItemCollection)
  '      For i As Integer = 0 To value.Count - 1
  '        Me.Add(value(i))
  '      Next
  '    End Sub
  '    Public Sub AddRange(ByVal value As EqtItem())
  '      For i As Integer = 0 To value.Length - 1
  '        Me.Add(value(i))
  '      Next
  '    End Sub
  '    Public Function Contains(ByVal value As EqtItem) As Boolean
  '      Return MyBase.List.Contains(value)
  '    End Function
  '    Public Sub CopyTo(ByVal array As EqtItem(), ByVal index As Integer)
  '      MyBase.List.CopyTo(array, index)
  '    End Sub
  '    Public Shadows Function GetEnumerator() As EqtItemEnumerator
  '      Return New EqtItemEnumerator(Me)
  '    End Function
  '    Public Function IndexOf(ByVal value As EqtItem) As Integer
  '      Return MyBase.List.IndexOf(value)
  '    End Function
  '    Public Overridable Sub Insert(ByVal index As Integer, ByVal value As EqtItem)
  '      If Not m_eqtWithdraw Is Nothing Then
  '        value.EqtWithdraw = m_eqtWithdraw
  '      End If
  '      MyBase.List.Insert(index, value)
  '    End Sub
  '    Public Sub Remove(ByVal value As EqtItem)
  '      MyBase.List.Remove(value)
  '    End Sub
  '    Public Sub Remove(ByVal value As eqtItemCollection)
  '      For i As Integer = 0 To value.Count - 1
  '        Me.Remove(value(i))
  '      Next
  '    End Sub
  '    Public Sub Remove(ByVal index As Integer)
  '      MyBase.List.RemoveAt(index)
  '    End Sub
  '#End Region

  '    Public Class EqtItemEnumerator
  '      Implements IEnumerator

  '#Region "Members"
  '      Private m_baseEnumerator As IEnumerator
  '      Private m_temp As IEnumerable
  '#End Region

  '#Region "Construtor"
  '      Public Sub New(ByVal mappings As EquipmentToolWithdrawItemCollection)
  '        Me.m_temp = mappings
  '        Me.m_baseEnumerator = Me.m_temp.GetEnumerator
  '      End Sub
  '#End Region

  '      Public ReadOnly Property Current() As Object Implements System.Collections.IEnumerator.Current
  '        Get
  '          Return CType(Me.m_baseEnumerator.Current, EquipmentToolWithdrawItem)
  '        End Get
  '      End Property

  '      Public Function MoveNext() As Boolean Implements System.Collections.IEnumerator.MoveNext
  '        Return Me.m_baseEnumerator.MoveNext
  '      End Function

  '      Public Sub Reset() Implements System.Collections.IEnumerator.Reset
  '        Me.m_baseEnumerator.Reset()
  '      End Sub
  '    End Class
  '  End Class


End Namespace
