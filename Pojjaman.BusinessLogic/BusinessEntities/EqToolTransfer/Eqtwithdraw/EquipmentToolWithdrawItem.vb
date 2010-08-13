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
  Public Class EquipmentToolWithdrawItem
    Inherits EqtItem
    Implements IWBSAllocatableItem

#Region "Members"
    Private m_eqtWithdraw As EquipmentToolWithdraw
    Private m_sequenceRefedto As Integer 'อาจไม่ต้องมีแล้ว

    'Private m_sequence As Integer


    'Private m_rentalqty As Integer
    'Private m_rentalperday As Decimal
    Private m_amount As Decimal
    Private m_pritem As PRItem

    Private m_WBSDistributeCollection As WBSDistributeCollection
    'Private m_internalChargeCollection As InternalChargeCollection
#End Region

#Region "Constructors"
    Public Sub New()
      MyBase.New()
      Me.m_pritem = New PRItem
      Me.m_pritem.Pr = New PR
      Me.Entity = New BlankEqItem()
      m_WBSDistributeCollection = New WBSDistributeCollection
      AddHandler m_WBSDistributeCollection.PropertyChanged, AddressOf Me.WBSChangedHandler
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

        .m_rentalperday = deh.GetValue(Of Decimal)(aliasPrefix & "eqtstocki_rentalrate")

        If dr.Table.Columns.Contains("eqtstock_id") Then
          .m_eqtWithdraw = New EquipmentToolWithdraw
          .m_eqtWithdraw.Id = deh.GetValue(Of Integer)("eqtstock_id")
          .m_eqtWithdraw.Code = deh.GetValue(Of String)("eqtstock_code")
          .m_eqtWithdraw.DocDate = deh.GetValue(Of Date)("eqtstock_docdate")

          If dr.Table.Columns.Contains("pri_entitytype") Then
            .m_pritem = New PRItem(dr, "")
          End If
        End If

        .m_unit = Unit.GetUnitById(deh.GetValue(Of Integer)("eqtstocki_unit"))

        .m_pritem = New PRItem
        .m_pritem.Pr = New PR(deh.GetValue(Of Integer)("eqtstock_refdoc"))
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
    Public Property WBSDistributeCollection() As WBSDistributeCollection Implements IWBSAllocatableItem.WBSDistributeCollection      Get        Return m_WBSDistributeCollection      End Get      Set(ByVal Value As WBSDistributeCollection)        m_WBSDistributeCollection = Value      End Set    End Property
    Public Property PRItem As PRItem
      Get
        Return m_pritem
      End Get
      Set(ByVal value As PRItem)
        m_pritem = value
      End Set
    End Property
    'Public Property InternalChargeCollection() As InternalChargeCollection    '  Get    '    If m_internalChargeCollection Is Nothing Then    '      m_internalChargeCollection = New InternalChargeCollection(Me)
    '    End If    '    Return m_internalChargeCollection    '  End Get    '  Set(ByVal Value As InternalChargeCollection)    '    m_internalChargeCollection = Value    '  End Set    'End Property

    'Public ReadOnly Property Sequence() As Integer    '  Get    '    Return m_sequence    '  End Get    'End Property
    Public Property RentalPerDay() As Decimal
      Get        Return m_rentalperday
      End Get      Set(ByVal value As Decimal)
        m_rentalperday = value
      End Set
    End Property

    Public Overrides Property Amount() As Decimal      Get        Return m_amount      End Get      Set(ByVal value As Decimal)
        m_amount = value
        If m_rentalqty > 0 Then
          m_rentalperday = m_amount / m_rentalqty
        End If
      End Set    End Property

    Public Property EquipmentToolWithdraw() As EquipmentToolWithdraw
      Get        Return m_eqtWithdraw      End Get      Set(ByVal Value As EquipmentToolWithdraw)        m_eqtWithdraw = Value      End Set    End Property
    Public Property SequenceRefedto() As Integer      Get        Return m_sequenceRefedto      End Get      Set(ByVal Value As Integer)        m_sequenceRefedto = Value      End Set    End Property    Public Function DupCode(ByVal myCode As String) As Boolean      If Me.EquipmentToolWithdraw Is Nothing Then
        Return False
      End If      If myCode Is Nothing OrElse myCode.Length = 0 Then
        Return False
      End If
      For Each item As EquipmentToolWithdrawItem In Me.EquipmentToolWithdraw.ItemCollection
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
    End Function    'ไปใช้ของแม่ Eqtitem    'Public Sub SetItemCode(ByVal theCode As String)    '  Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
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
    Public Overrides Sub Clear()
      'Me.Entity = New EquipmentToolWithdrawItem
      Me.Qty = 0
      Me.Note = ""
    End Sub
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
        Me.EquipmentToolWithdraw.IsInitialized = False
        'Dim rpd As Decimal = 0
        'Dim rentrate As Decimal = 0
        row("Linenumber") = Me.LineNumber
        row("Type") = Me.ItemType.Description
        If Not Me.Entity Is Nothing Then
          row("eqtstocki_entity") = Me.Entity.Id
          row("Code") = Me.Entity.Code
          row("Name") = Me.Entity.Name
          'If Not Me.Entity.Unit Is Nothing Then
          '  Me.Unit = Me.Entity.Unit
          '  row("UnitName") = Me.Entity.Unit.Name
          'End If
          'rentrate = Me.Entity.RentalRate
        End If
        If Not Me.Unit Is Nothing Then
          row("UnitName") = Me.Unit.Name
        End If

        'row("Name") = Me.name

        row("Button") = ""

        row("Note") = Me.Note

        If Me.Qty <> 0 Then
          row("QTY") = Configuration.FormatToString(Me.Qty, DigitConfig.Int)
        Else
          row("QTY") = ""
        End If
        'rpd = rentrate * Me.Qty
        'If Me.RentalPerDay <> 0 And rpd <> 0 Then
        If Me.RentalPerDay <> 0 Then
          row("RentalPerDay") = Configuration.FormatToString(Me.RentalPerDay, DigitConfig.Price)
          'Else
          '  row("RentalPerDay") = Configuration.FormatToString(rpd, DigitConfig.Price)
          '  Me.RentalPerDay = rpd
          'End If
        Else
          row("RentalPerDay") = ""
        End If

        Me.EquipmentToolWithdraw.IsInitialized = True
      Catch ex As Exception
        MessageBox.Show(ex.Message & "::" & ex.StackTrace)
      End Try
    End Sub
    Public Sub WBSChangedHandler(ByVal sender As Object, ByVal e As PropertyChangedEventArgs)

      If TypeOf sender Is WBSDistribute Then
        Dim wbsd As WBSDistribute = CType(sender, WBSDistribute)
        Select Case e.Name.ToLower
          Case "percent"
            'If Not Me.m_matWithdraw Is Nothing Then

            'End If
          Case "amount"
            'If Not Me.m_matWithdraw Is Nothing Then

            'End If
          Case "wbs"
            'Dim oldWBS As WBS = CType(e.OldValue, WBS)
            Dim newWBS As WBS = CType(e.Value, WBS)
            Dim theName As String = ""
            If Me.Entity IsNot Nothing Then
              theName = Me.Entity.Name
            End If

            wbsd.BudgetAmount = newWBS.GetTotalMatFromDB
            wbsd.BudgetQty = newWBS.GetTotalMatQtyFromDB(Me.Entity.Id)

            If wbsd.IsMarkup Then
              wbsd.BudgetRemain = newWBS.GetTotalMarkUpFromDB - newWBS.GetWBSActualFromDB(Me.EquipmentToolWithdraw.Id, Me.EquipmentToolWithdraw.EntityId, 42)
              wbsd.QtyRemain = 0
            Else
              wbsd.BudgetRemain = wbsd.BudgetAmount - newWBS.GetWBSActualFromDB(Me.EquipmentToolWithdraw.Id, Me.EquipmentToolWithdraw.EntityId, 42)
              wbsd.QtyRemain = wbsd.BudgetQty - newWBS.GetWBSQtyActualFromDB(Me.EquipmentToolWithdraw.Id, Me.EquipmentToolWithdraw.EntityId, Me.Entity.Id, _
                                                                           42, theName) 'แปลงเป็นหน่วยตาม boq เรียบร้อย
            End If

        End Select
      End If
    End Sub
    Public Sub UpdateWBSQty()
      'For Each wbsd As WBSDistribute In Me.InWbsdColl
      '  'Dim bfTax As Decimal = 0
      '  'Dim oldVal As Decimal = wbsd.TransferAmount
      '  'Dim transferAmt As Decimal = Me.Amount
      '  'wbsd.BaseCost = bfTax
      '  'wbsd.TransferBaseCost = transferAmt
      '  Dim boqConversion As Decimal = wbsd.WBS.GetBoqItemConversion(Me.Entity.Id, Me.Unit.Id)
      '  If boqConversion = 0 Then
      '    wbsd.BaseQty = Me.Qty
      '  Else
      '    wbsd.BaseQty = Me.Qty * (Me.Conversion / boqConversion)
      '  End If

      '  'Me.WBSChangedHandler(wbsd, New PropertyChangedEventArgs("Percent", wbsd.TransferAmount, oldVal))
      'Next
      For Each wbsd As WBSDistribute In Me.WBSDistributeCollection
        'Dim bfTax As Decimal = 0
        'Dim oldVal As Decimal = wbsd.TransferAmount
        'Dim transferAmt As Decimal = Me.Amount
        'wbsd.BaseCost = bfTax
        'wbsd.TransferBaseCost = transferAmt
        'Dim boqConversion As Decimal = wbsd.WBS.GetBoqItemConversion(Me.Entity.Id, Me.Unit.Id, 42)
        'If boqConversion = 0 Then
        '  wbsd.BaseQty = Me.Qty
        'Else
        '  wbsd.BaseQty = Me.Qty * (Me.Conversion / boqConversion)
        'End If

        wbsd.BaseQty = Me.Qty

        'Me.WBSChangedHandler(wbsd, New PropertyChangedEventArgs("Percent", wbsd.TransferAmount, oldVal))
      Next
    End Sub
#End Region

#Region "IWBSAllocatableItem"
    Public ReadOnly Property AllocationErrorMessage As String Implements IWBSAllocatableItem.AllocationErrorMessage
      Get
        Return ""
      End Get
    End Property

    Public ReadOnly Property AllocationType As String Implements IWBSAllocatableItem.AllocationType
      Get
        Return "eq"
      End Get
    End Property

    Public ReadOnly Property Description As String Implements IWBSAllocatableItem.Description
      Get
        Return Me.Entity.Code & " : " & Trim(Me.Entity.Name)
      End Get
    End Property

    Public ReadOnly Property ItemAmount As Decimal Implements IWBSAllocatableItem.ItemAmount
      Get
        Return Me.Amount
      End Get
    End Property

    Public ReadOnly Property Type As String Implements IWBSAllocatableItem.Type
      Get
        Dim strType As String = Me.ItemType.Description 'CodeDescription.GetDescription("eqtstocki_entityType", Me.ItemType.Value)
        Return strType
      End Get
    End Property

    Public Property WBSDistributeCollection2 As WBSDistributeCollection Implements IWBSAllocatableItem.WBSDistributeCollection2
      Get

      End Get
      Set(ByVal value As WBSDistributeCollection)

      End Set
    End Property
#End Region

  End Class

  <Serializable(), DefaultMember("Item")> _
  Public Class EquipmentToolWithdrawItemCollection
    Inherits CollectionBase

#Region "Members"
    Private m_eqtWithdraw As EquipmentToolWithdraw
#End Region

#Region "Constructors"
    Public Sub New()
    End Sub
    Public Sub New(ByVal owner As EquipmentToolWithdraw)
      Me.m_eqtWithdraw = owner
      If Not Me.m_eqtWithdraw.Originated Then
        Return
      End If

      Dim sqlConString As String = RecentCompanies.CurrentCompany.ConnectionString

      Dim ds As DataSet = SqlHelper.ExecuteDataset(sqlConString _
      , CommandType.StoredProcedure _
      , "GetEquipmentToolWithdrawItems" _
      , New SqlParameter("@eqtstock_id", Me.m_eqtWithdraw.Id) _
      )

      For Each row As DataRow In ds.Tables(0).Rows
        Dim item As New EquipmentToolWithdrawItem(row, "")
        item.EquipmentToolWithdraw = m_eqtWithdraw
        Me.Add(item)

        Dim wbsdColl As WBSDistributeCollection = New WBSDistributeCollection
        AddHandler wbsdColl.PropertyChanged, AddressOf item.WBSChangedHandler
        item.WBSDistributeCollection = wbsdColl
        For Each wbsRow As DataRow In ds.Tables(1).Select("eqtstockiw_sequence=" & item.Sequence)
          Dim wbsd As New WBSDistribute(wbsRow, "")
          wbsdColl.Add(wbsd)
        Next

        'Dim itcColl As New InternalChargeCollection(item)
        'item.InternalChargeCollection = itcColl
        'For Each itcRow As DataRow In ds.Tables(2).Select("itci_refsequence=" & item.Sequence)
        '  Dim itc As New InternalCharge(itcRow, "")
        '  itcColl.Add(itc)
        'Next
      Next
    End Sub
#End Region

#Region "Properties"
    Public Property EqtWithdraw() As EquipmentToolWithdraw
      Get        Return m_eqtWithdraw
      End Get      Set(ByVal Value As EquipmentToolWithdraw)        m_eqtWithdraw = Value
      End Set    End Property    Default Public Property Item(ByVal index As Integer) As EquipmentToolWithdrawItem
      Get
        Return CType(MyBase.List.Item(index), EquipmentToolWithdrawItem)
      End Get
      Set(ByVal value As EquipmentToolWithdrawItem)
        MyBase.List.Item(index) = value
      End Set
    End Property
    Public Property CurrentItem() As EquipmentToolWithdrawItem
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
        For Each Item As EquipmentToolWithdrawItem In Me
          ret += Item.RentalPerDay
        Next
        Return ret
      End Get
    End Property
#End Region

#Region "Class Methods"
    Public Sub Populate(ByVal dt As TreeTable, ByVal tg As DataGrid)
      dt.Clear()
      Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
      Dim noPRText As String = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.POPanelView.BlankPRText}")
      Dim prRowHash As New Hashtable
      Dim parRow As TreeRow = Nothing

      If Me.List.Count = 0 Then
        parRow = dt.Childs.Add()
        parRow.State = RowExpandState.Expanded
        'parRow.CustomFontStyle = FontStyle.Bold
        parRow("Type") = noPRText
        parRow("Button") = ""
        prRowHash(0) = parRow
      End If
      Dim i As Integer = 1

      For Each eqi As EquipmentToolWithdrawItem In Me
        parRow = Nothing

        If Not eqi.PRItem Is Nothing AndAlso Not eqi.PRItem.Pr Is Nothing AndAlso eqi.PRItem.Pr.Originated Then
          If Not prRowHash.Contains(eqi.PRItem.Pr.Id) Then
            parRow = dt.Childs.Add()
            parRow.State = RowExpandState.Expanded
            'parRow.CustomFontStyle = FontStyle.Bold
            parRow("Code") = eqi.PRItem.Pr.Code
            parRow("Button") = ""
            prRowHash(eqi.PRItem.Pr.Id) = parRow
          Else
            parRow = CType(prRowHash(eqi.PRItem.Pr.Id), TreeRow)
            parRow.State = RowExpandState.Expanded
          End If
        Else
          If Not prRowHash.Contains(0) Then
            'parRow.CustomFontStyle = FontStyle.Bold
            parRow = dt.Childs.Add()
            parRow.State = RowExpandState.Expanded
            parRow("Code") = noPRText
            parRow("Button") = ""
            prRowHash(0) = parRow
          Else
            parRow = CType(prRowHash(0), TreeRow)
            parRow.State = RowExpandState.Expanded
          End If
        End If

        If Not parRow Is Nothing Then
          Dim newRow As TreeRow = parRow.Childs.Add()
          eqi.LineNumber = i
          i += 1
          eqi.CopyToDataRow(newRow)
          eqi.ItemValidateRow(newRow)
          newRow.Tag = eqi
        End If

      Next
      dt.AcceptChanges()

      Do Until dt.Rows.Count > tg.VisibleRowCount
        'เพิ่มแถวจนเต็ม
        dt.Childs.Add()
      Loop

      Try
        If (Not dt.Rows(dt.Rows.Count - 1).IsNull("Code")) OrElse (Not CType(dt.Rows(dt.Rows.Count - 1), TreeRow).Tag Is Nothing) Then
          '  'เพิ่มอีก 1 แถว ถ้ามีข้อมูลจนถึงแถวสุดท้าย
          dt.Childs.Add()
        End If
      Catch ex As Exception

      End Try

      dt.AcceptChanges()
    End Sub
#End Region

#Region "Collection Methods"
    Public Overridable Function Add(ByVal value As EquipmentToolWithdrawItem) As Integer
      If Not m_eqtWithdraw Is Nothing Then
        value.EquipmentToolWithdraw = m_eqtWithdraw
      End If
      Return MyBase.List.Add(value)
    End Function
    Public Sub AddRange(ByVal value As EquipmentToolWithdrawItemCollection)
      For i As Integer = 0 To value.Count - 1
        Me.Add(value(i))
      Next
    End Sub
    Public Sub AddRange(ByVal value As EquipmentToolWithdrawItem())
      For i As Integer = 0 To value.Length - 1
        Me.Add(value(i))
      Next
    End Sub
    Public Function Contains(ByVal value As EquipmentToolWithdrawItem) As Boolean
      Return MyBase.List.Contains(value)
    End Function
    Public Sub CopyTo(ByVal array As EquipmentToolWithdrawItem(), ByVal index As Integer)
      MyBase.List.CopyTo(array, index)
    End Sub
    Public Shadows Function GetEnumerator() As EquipmentToolWithdrawItemEnumerator
      Return New EquipmentToolWithdrawItemEnumerator(Me)
    End Function
    Public Function IndexOf(ByVal value As EquipmentToolWithdrawItem) As Integer
      Return MyBase.List.IndexOf(value)
    End Function
    Public Overridable Sub Insert(ByVal index As Integer, ByVal value As EquipmentToolWithdrawItem)
      If Not m_eqtWithdraw Is Nothing Then
        value.EquipmentToolWithdraw = m_eqtWithdraw
      End If
      MyBase.List.Insert(index, value)
    End Sub
    Public Sub Remove(ByVal value As EquipmentToolWithdrawItem)
      MyBase.List.Remove(value)
    End Sub
    Public Sub Remove(ByVal value As EquipmentToolWithdrawItemCollection)
      For i As Integer = 0 To value.Count - 1
        Me.Remove(value(i))
      Next
    End Sub
    Public Sub Remove(ByVal index As Integer)
      MyBase.List.RemoveAt(index)
    End Sub
#End Region

    Public Class EquipmentToolWithdrawItemEnumerator
      Implements IEnumerator

#Region "Members"
      Private m_baseEnumerator As IEnumerator
      Private m_temp As IEnumerable
#End Region

#Region "Construtor"
      Public Sub New(ByVal mappings As EquipmentToolWithdrawItemCollection)
        Me.m_temp = mappings
        Me.m_baseEnumerator = Me.m_temp.GetEnumerator
      End Sub
#End Region

      Public ReadOnly Property Current() As Object Implements System.Collections.IEnumerator.Current
        Get
          Return CType(Me.m_baseEnumerator.Current, EquipmentToolWithdrawItem)
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
      For Each i As EquipmentToolWithdrawItem In Me
        If TypeOf i.Entity Is EquipmentItem Then
          list.Add(i.Entity.Id.ToString)
        End If
      Next
      Return String.Join(",", list)

    End Function

  End Class

  
End Namespace
