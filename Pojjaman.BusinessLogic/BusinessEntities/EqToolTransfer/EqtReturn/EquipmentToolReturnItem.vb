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

  Public Class EquipmentToolReturnItem
    Inherits EqtItem
    Implements IWBSAllocatableItem

#Region "Members"
    Private m_eqtReturn As EquipmentToolReturn
    Private m_Refsequence As Integer 'อาจไม่ต้องมีแล้ว
    Private m_refdoc As EquipmentToolWithdraw

    Private m_ewi As EquipmentToolWithdrawItem
    'Private m_rentalqty As Integer
    'Private m_rentalperday As Decimal
    Private m_rentalAmt As Decimal


    '' อ้างอิงใบเบิกเดิม

    Private m_WBSDistributeCollection As WBSDistributeCollection
    'Private m_internalChargeCollection As InternalChargeCollection
#End Region

#Region "Constructors"
    Public Sub New()
      MyBase.New()
      m_ewi = New EquipmentToolWithdrawItem

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
        .m_rentalqty = deh.GetValue(Of Integer)(aliasPrefix & "eqtstocki_rentalqty")
        .m_rentalAmt = deh.GetValue(Of Decimal)(aliasPrefix & "eqtstocki_Amount")

        ' Sequence Refed to ...
        .m_Refsequence = deh.GetValue(Of Integer)(aliasPrefix & "eqtstocki_refsequence")

        .m_refdoc = New EquipmentToolWithdraw
        .m_refdoc.Id = deh.GetValue(Of Integer)(aliasPrefix & "eqtstock_id")
        .m_refdoc.Code = deh.GetValue(Of String)(aliasPrefix & "eqtstock_code")
        .m_refdoc.DocDate = deh.GetValue(Of Date)(aliasPrefix & "eqtstock_docdate")

        .m_ewi = New EquipmentToolWithdrawItem(dr, "")

      End With
    End Sub
    Protected Overrides Sub Construct(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
      Dim dr As DataRow = ds.Tables(0).Rows(0)
      Me.Construct(dr, aliasPrefix)
    End Sub
#End Region

#Region "Properties"
    Public Property WBSDistributeCollection() As WBSDistributeCollection Implements IWBSAllocatableItem.WBSDistributeCollection      Get        Return m_WBSDistributeCollection      End Get      Set(ByVal Value As WBSDistributeCollection)        m_WBSDistributeCollection = Value      End Set    End Property

    Public Overrides Property Qty() As Integer      Get        If Not Me.m_itemtype Is Nothing Then          If Me.m_itemtype.Value = 342 OrElse Me.m_itemtype.Value = 28 Then
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
        End If        m_qty = CInt(Configuration.Format(Value, DigitConfig.Int))        RentalPerDay = m_qty * Entity.RentalRate      End Set    End Property
    Public Property RentalPerDay() As Decimal      Get        Return m_rentalperday      End Get      Set(ByVal value As Decimal)
        m_rentalperday = value
        m_rentalAmt = m_rentalperday * m_rentalqty
      End Set    End Property
    Public Property RentalQty() As Integer
      Get        Return m_rentalqty
      End Get      Set(ByVal value As Integer)
        m_rentalqty = value
        m_rentalAmt = m_rentalperday * m_rentalqty
      End Set
    End Property
    Public Overrides Property Amount() As Decimal      Get        Return m_rentalAmt      End Get      Set(ByVal value As Decimal)
        m_rentalAmt = value
        If m_rentalqty > 0 Then
          m_rentalperday = m_rentalAmt / m_rentalqty

        End If
      End Set    End Property
    Public Property EqtReturn() As EquipmentToolReturn
      Get        Return m_eqtReturn      End Get      Set(ByVal Value As EquipmentToolReturn)        m_eqtReturn = Value      End Set    End Property    Public Property RefDoc As EquipmentToolWithdraw
      Get
        Return m_refdoc
      End Get
      Set(ByVal value As EquipmentToolWithdraw)
        m_refdoc = value
      End Set
    End Property

    Public Property RefItem() As EquipmentToolWithdrawItem      Get        Return m_ewi      End Get      Set(ByVal Value As EquipmentToolWithdrawItem)        m_ewi = Value      End Set    End Property

    Public Property RefSequence() As Integer      Get        Return m_Refsequence      End Get      Set(ByVal Value As Integer)        m_Refsequence = Value      End Set    End Property    Public Function DupCode(ByVal myCode As String) As Boolean      If Me.EqtReturn Is Nothing Then
        Return False
      End If      If myCode Is Nothing OrElse myCode.Length = 0 Then
        Return False
      End If
      For Each item As EquipmentToolReturnItem In Me.EqtReturn.ItemCollection
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
    End Function    'Public Sub SetItemCode(ByVal theCode As String)    '  Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
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
        Me.EqtReturn.IsInitialized = False
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
        rpd = rentrate * Me.Qty
        If Me.RentalPerDay <> 0 And rpd <> 0 Then
          If Me.RentalPerDay <> 0 Then
            row("RentalPerDay") = Configuration.FormatToString(Me.RentalPerDay, DigitConfig.Price)
          Else
            row("RentalPerDay") = Configuration.FormatToString(rpd, DigitConfig.Price)
            Me.RentalPerDay = rpd
          End If
        Else
          row("RentalPerDay") = ""
        End If
        row("RentalQty") = Configuration.FormatToString(Me.RentalQty, DigitConfig.Price)
        row("RentalAmount") = Configuration.FormatToString(Me.Amount, DigitConfig.Price)
        Me.EqtReturn.IsInitialized = True
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
              wbsd.BudgetRemain = newWBS.GetTotalMarkUpFromDB - newWBS.GetWBSActualFromDB(Me.EqtReturn.Id, Me.EqtReturn.EntityId, 42)
              wbsd.QtyRemain = 0
            Else
              wbsd.BudgetRemain = wbsd.BudgetAmount - newWBS.GetWBSActualFromDB(Me.EqtReturn.Id, Me.EqtReturn.EntityId, 42)
              wbsd.QtyRemain = wbsd.BudgetQty - newWBS.GetWBSQtyActualFromDB(Me.EqtReturn.Id, Me.EqtReturn.EntityId, Me.Entity.Id, _
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
      If Me.WBSDistributeCollection IsNot Nothing Then
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
      Else
        Me.WBSDistributeCollection = New WBSDistributeCollection
      End If
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
  Public Class EquipmentToolReturnItemCollection
    Inherits CollectionBase

#Region "Members"
    Private m_eqtReturn As EquipmentToolReturn
#End Region

#Region "Constructors"
    Public Sub New()
    End Sub
    Public Sub New(ByVal owner As EquipmentToolReturn)
      Me.m_eqtReturn = owner
      If Not Me.m_eqtReturn.Originated Then
        Return
      End If

      Dim sqlConString As String = RecentCompanies.CurrentCompany.ConnectionString

      Dim ds As DataSet = SqlHelper.ExecuteDataset(sqlConString _
      , CommandType.StoredProcedure _
      , "GetEquipmentToolReturnItems" _
      , New SqlParameter("@eqtstock_id", Me.m_eqtReturn.Id) _
      )

      For Each row As DataRow In ds.Tables(0).Rows
        Dim item As New EquipmentToolReturnItem(row, "")
        item.EqtReturn = m_eqtReturn
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
    Public Property EqtReturn() As EquipmentToolReturn
      Get        Return m_eqtReturn
      End Get      Set(ByVal Value As EquipmentToolReturn)        m_eqtReturn = Value
      End Set    End Property    Default Public Property Item(ByVal index As Integer) As EquipmentToolReturnItem
      Get
        Return CType(MyBase.List.Item(index), EquipmentToolReturnItem)
      End Get
      Set(ByVal value As EquipmentToolReturnItem)
        MyBase.List.Item(index) = value
      End Set
    End Property
    Public Property CurrentItem() As EquipmentToolReturnItem
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
        For Each Item As EquipmentToolReturnItem In Me
          ret += Item.Amount
        Next
        Return ret
      End Get
    End Property
#End Region

#Region "Class Methods"
    Public Sub SetItems(ByVal items As BasketItemCollection)
      Dim sequnces As New ArrayList
      For i As Integer = items.Count - 1 To 0 Step -1
        Dim item As EqtBasketItem = CType(items(i), EqtBasketItem)
        Dim refItem As EquipmentToolWithdrawItem
        Dim newEntity As IEqtItem
        Dim doc As New EquipmentToolReturnItem
        Dim itemType As Integer
        If TypeOf item.Tag Is EquipmentToolWithdrawItem Then
          refItem = CType(item.Tag, EquipmentToolWithdrawItem)
          newEntity = CType(item.Tag, EquipmentToolWithdrawItem).Entity
          itemType = CType(item.Tag, EquipmentToolWithdrawItem).ItemType.Value
        Else
          Select Case item.FullClassName.ToLower
            Case "longkong.pojjaman.businesslogic.equipmentitem"
              newEntity = New EquipmentItem
              itemType = 342
            Case "longkong.pojjaman.businesslogic.tool"
              newEntity = New Tool(item.Id)
              itemType = 19
          End Select
        End If


        If Not itemType = 0 Then
          'Dim doc As New EquipmentToolReturnItem
          If Not Me.CurrentItem Is Nothing Then
            doc = Me.CurrentItem
            doc.ItemType.Value = itemType
            'Me.m_treeManager.SelectedRow.Tag = Nothing
          Else
            Me.m_eqtReturn.ItemCollection.Add(doc)
            doc.ItemType = New EqtItemType(itemType)
          End If
          doc.RefItem = refItem
          doc.RefDoc = refItem.EquipmentToolWithdraw
          doc.Entity = newEntity
          doc.Unit = CType(newEntity, IEqtItem).Unit
          doc.ToStatus = New EqtStatus(3)
          If itemType = 19 Then
            If refItem IsNot Nothing Then
              doc.Qty = refItem.Qty
            Else
              doc.Qty = 1
            End If
            doc.RentalPerDay = CType(newEntity, IEqtItem).RentalRate * doc.Qty
          Else
            doc.Qty = 1
            doc.RentalPerDay = CType(newEntity, IEqtItem).RentalRate
          End If
        End If
        sequnces.Add(refItem.Sequence)
        'สร้างการจัดสรร
      Next
      Dim theList As String = String.Join(",", sequnces.ToArray)
      SetWBSCollections(theList)

    End Sub
    Private Sub SetWBSCollections(ByVal theList As String)
      Dim sqlConString As String = RecentCompanies.CurrentCompany.ConnectionString

      Dim ds As DataSet = SqlHelper.ExecuteDataset(sqlConString _
      , CommandType.StoredProcedure _
      , "GetEqtStockWbsfromList" _
      , New SqlParameter("@List", theList) _
      )

      If ds.Tables(0).Rows.Count > 0 Then
        For Each Item As EquipmentToolReturnItem In Me
          Dim wbsdColl As WBSDistributeCollection = New WBSDistributeCollection
          AddHandler wbsdColl.PropertyChanged, AddressOf Item.WBSChangedHandler
          If Item.WBSDistributeCollection Is Nothing Then
            Item.WBSDistributeCollection = wbsdColl
          Else
            wbsdColl = Item.WBSDistributeCollection
          End If
          For Each wbsRow As DataRow In ds.Tables(0).Select("eqtstockiw_sequence=" & Item.RefItem.Sequence)
            Dim wbsd As New WBSDistribute(wbsRow, "")
            wbsdColl.Add(wbsd)
          Next
        Next
      End If
    End Sub
    Public Sub Populate(ByVal dt As TreeTable)
      dt.Clear()
      'Dim i As Integer = 0
      'For Each gri As EquipmentToolReturnItem In Me
      '  i += 1
      '  Dim newRow As TreeRow = dt.Childs.Add()
      '  gri.CopyToDataRow(newRow)
      '  gri.ItemValidateRow(newRow)
      '  newRow.Tag = gri
      'Next
      'dt.AcceptChanges()

      Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
      Dim prRowHash As New Hashtable
      Dim parRow As TreeRow

      For Each eri As EquipmentToolReturnItem In Me
        parRow = Nothing
        If Not eri.RefItem Is Nothing _
         AndAlso eri.RefDoc.Originated Then
          If Not prRowHash.Contains(eri.RefDoc.Id) Then
            parRow = dt.Childs.Add
            parRow("Code") = eri.RefDoc.Code
            parRow("Name") = eri.RefDoc.DocDate.ToString
            parRow("Button") = "invisible"
            parRow.State = RowExpandState.Expanded
            prRowHash(eri.RefDoc.Id) = parRow
          Else
            parRow = CType(prRowHash(eri.RefDoc.Id), TreeRow)
          End If
          'Else ''ต้องมีการอ้างอิงเท่านั้น
          '  'แบบไม่มี PR
          '  If Not prRowHash.Contains(0) Then
          '    parRow = dt.Childs.Add
          '    parRow("PRItemCode") = noPRText
          '    parRow("Button") = "invisible"
          '    parRow("UnitButton") = "invisible"
          '    parRow.State = RowExpandState.Expanded
          '    prRowHash(0) = parRow
          '  Else
          '    parRow = CType(prRowHash(0), TreeRow)
          '  End If
        End If

        Dim newRow As TreeRow = parRow.Childs.Add()
        eri.CopyToDataRow(newRow)
        eri.ItemValidateRow(newRow)
        newRow.Tag = eri
      Next
      dt.AcceptChanges()
    End Sub
#End Region

#Region "Collection Methods"
    Public Overridable Function Add(ByVal value As EquipmentToolReturnItem) As Integer
      If Not m_eqtReturn Is Nothing Then
        value.EqtReturn = m_eqtReturn
      End If
      Return MyBase.List.Add(value)
    End Function
    Public Sub AddRange(ByVal value As EquipmentToolReturnItemCollection)
      For i As Integer = 0 To value.Count - 1
        Me.Add(value(i))
      Next
    End Sub
    Public Sub AddRange(ByVal value As EquipmentToolReturnItem())
      For i As Integer = 0 To value.Length - 1
        Me.Add(value(i))
      Next
    End Sub
    Public Function Contains(ByVal value As EquipmentToolReturnItem) As Boolean
      Return MyBase.List.Contains(value)
    End Function
    Public Sub CopyTo(ByVal array As EquipmentToolReturnItem(), ByVal index As Integer)
      MyBase.List.CopyTo(array, index)
    End Sub
    Public Shadows Function GetEnumerator() As EquipmentToolReturnItemEnumerator
      Return New EquipmentToolReturnItemEnumerator(Me)
    End Function
    Public Function IndexOf(ByVal value As EquipmentToolReturnItem) As Integer
      Return MyBase.List.IndexOf(value)
    End Function
    Public Overridable Sub Insert(ByVal index As Integer, ByVal value As EquipmentToolReturnItem)
      If Not m_eqtReturn Is Nothing Then
        value.EqtReturn = m_eqtReturn
      End If
      MyBase.List.Insert(index, value)
    End Sub
    Public Sub Remove(ByVal value As EquipmentToolReturnItem)
      MyBase.List.Remove(value)
    End Sub
    Public Sub Remove(ByVal value As EquipmentToolReturnItemCollection)
      For i As Integer = 0 To value.Count - 1
        Me.Remove(value(i))
      Next
    End Sub
    Public Sub Remove(ByVal index As Integer)
      MyBase.List.RemoveAt(index)
    End Sub
#End Region

    Public Class EquipmentToolReturnItemEnumerator
      Implements IEnumerator

#Region "Members"
      Private m_baseEnumerator As IEnumerator
      Private m_temp As IEnumerable
#End Region

#Region "Construtor"
      Public Sub New(ByVal mappings As EquipmentToolReturnItemCollection)
        Me.m_temp = mappings
        Me.m_baseEnumerator = Me.m_temp.GetEnumerator
      End Sub
#End Region

      Public ReadOnly Property Current() As Object Implements System.Collections.IEnumerator.Current
        Get
          Return CType(Me.m_baseEnumerator.Current, EquipmentToolReturnItem)
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
      For Each i As EquipmentToolReturnItem In Me
        If TypeOf i.Entity Is EquipmentItem Then
          list.Add(i.Entity.Id.ToString)
        End If
      Next
      Return String.Join(",", list)

    End Function

  End Class

 
End Namespace
