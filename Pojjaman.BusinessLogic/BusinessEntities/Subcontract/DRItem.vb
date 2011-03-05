Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration
Imports System.Reflection
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Services
Namespace Longkong.Pojjaman.BusinessLogic
  Public Class DRIItemType
    Inherits CodeDescription

#Region "Constructors"
    Public Sub New(ByVal value As Integer)
      MyBase.New(value)
    End Sub
#End Region

#Region "Properties"
    Public Overrides ReadOnly Property CodeName() As String
      Get
        Return "dri_entityType"
      End Get
    End Property
#End Region

  End Class
  Public Class DRItem
    Implements IWBSAllocatableItem ', IAllowWBSAllocatableItem
    
#Region "Members"
    Private m_dr As DR
    Private m_sequence As Integer
    Private m_sc As SC
    Private m_lineNumber As Integer
    Private m_drdescription As String
    Private m_dritem As DRItem
    Private m_entity As IHasName
    Private m_entityName As String
    Private m_unit As Unit
    Private m_originQty As Decimal
    Private m_originAmt As Decimal
    Private m_qty As Decimal
    Private m_unitPrice As Decimal
    Private m_mat As Decimal
    Private m_lab As Decimal
    Private m_eq As Decimal
    Private m_amount As Decimal
    Private m_note As String

    Private m_unvatable As Boolean = False
    Private m_discount As New Discount("")
    Private m_conversion As Decimal = 1
    Private m_itemType As DRIItemType

    'Private m_receiptQty As Decimal
    Private m_unitCost As Decimal

    Private m_receivedAmount As Decimal
    Private m_receivedMat As Decimal
    Private m_receivedLab As Decimal
    Private m_receivedEq As Decimal
    Private m_receivedQty As Decimal

    Private m_oldAmount As Decimal
    Private m_oldMat As Decimal
    Private m_oldLab As Decimal
    Private m_oldEq As Decimal
    Private m_oldQty As Decimal

    'Private m_ToCCWBSDistributeCollection As WBSDistributeCollection
    Private m_FromCCWBSDistributeCollection As WBSDistributeCollection
#End Region

#Region "Constructors"
    Public Sub New()
      MyBase.New()
      'm_ToCCWBSDistributeCollection = New WBSDistributeCollection
      m_FromCCWBSDistributeCollection = New WBSDistributeCollection
      'AddHandler m_ToCCWBSDistributeCollection.PropertyChanged, AddressOf Me.WBSChangedHandler
      AddHandler m_FromCCWBSDistributeCollection.PropertyChanged, AddressOf Me.WBSChangedHandler
    End Sub
    Public Sub New(ByVal id As Integer, ByVal line As Integer)
      Dim connString As String = RecentCompanies.CurrentCompany.ConnectionString
      Dim ds As DataSet = SqlHelper.ExecuteDataset(connString _
      , CommandType.StoredProcedure _
      , "GetDRItems" _
      , New SqlParameter("@dr_id", id) _
      , New SqlParameter("@dri_linenumber", line) _
      )
      Me.Construct(ds.Tables(0).Rows(0), "")

      'Dim wbsdToCCColl As WBSDistributeCollection = New WBSDistributeCollection
      Dim wbsdFromCCColl As WBSDistributeCollection = New WBSDistributeCollection
      'AddHandler wbsdToCCColl.PropertyChanged, AddressOf Me.WBSChangedHandler
      AddHandler wbsdFromCCColl.PropertyChanged, AddressOf Me.WBSChangedHandler
      'm_ToCCWBSDistributeCollection = wbsdToCCColl
      m_FromCCWBSDistributeCollection = wbsdFromCCColl
      If ds.Tables.Count > 1 Then
        'For Each wbsRow As DataRow In ds.Tables(1).Select("driw_sequence=" & Me.Sequence)
        '  Dim wbsd As New WBSDistribute(wbsRow, "")
        '  wbsdToCCColl.Add(wbsd)
        'Next
        For Each wbsRow As DataRow In ds.Tables(2).Select("driw_sequence=" & Me.Sequence)
          Dim wbsd As New WBSDistribute(wbsRow, "")
          wbsdFromCCColl.Add(wbsd)
        Next
      End If
    End Sub
    Public Sub New(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
      Me.Construct(ds, aliasPrefix)
    End Sub
    Public Sub New(ByVal dr As DataRow, ByVal aliasPrefix As String)
      Me.Construct(dr, aliasPrefix)
    End Sub
    Protected Sub Construct(ByVal dr As DataRow, ByVal aliasPrefix As String)
      With Me
        If dr.Table.Columns.Contains(aliasPrefix & "dri_sc") AndAlso Not dr.IsNull(aliasPrefix & "dri_sc") Then
          .m_dr = New DR(CInt(dr(aliasPrefix & "dri_sc")))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "dri_sequence") AndAlso Not dr.IsNull(aliasPrefix & "dri_sequence") Then
          .m_sequence = CInt(dr("dri_sequence"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "dri_sc") AndAlso Not dr.IsNull(aliasPrefix & "dri_sc") Then
          .m_sc = New SC(CInt(dr(aliasPrefix & "dri_sc")))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "dri_linenumber") AndAlso Not dr.IsNull(aliasPrefix & "dri_linenumber") Then
          .m_lineNumber = CInt(dr("dri_linenumber"))
        End If
        Dim itemId As Integer
        If dr.Table.Columns.Contains(aliasPrefix & "dri_entity") AndAlso Not dr.IsNull(aliasPrefix & "dri_entity") Then
          itemId = CInt(dr(aliasPrefix & "dri_entity"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "dri_itemName") AndAlso Not dr.IsNull(aliasPrefix & "dri_itemName") Then
          .m_entityName = CStr(dr(aliasPrefix & "dri_itemName"))
        Else
          .m_entityName = ""
        End If

        'dri_unvatable
        If dr.Table.Columns.Contains(aliasPrefix & "dri_unvatable") AndAlso Not dr.IsNull(aliasPrefix & "dri_unvatable") Then
          .m_unvatable = CBool(dr("dri_unvatable"))
        End If
        'If dr.Table.Columns.Contains(aliasPrefix & "ReceiptAmount") AndAlso Not dr.IsNull(aliasPrefix & "ReceiptAmount") Then
        '  .m_receiptAmount = CDec(dr("ReceiptAmount"))
        'End If
        'If dr.Table.Columns.Contains(aliasPrefix & "ReceiptQty") AndAlso Not dr.IsNull(aliasPrefix & "ReceiptQty") Then
        '  .m_receiptQty = CDec(dr("ReceiptQty"))
        'End If

        If dr.Table.Columns.Contains(aliasPrefix & "dri_entityType") AndAlso Not dr.IsNull(aliasPrefix & "dri_entityType") Then

          .m_itemType = New DRIItemType(CInt(dr(aliasPrefix & "dri_entityType")))

          Select Case .m_itemType.Value
            Case 42 '"lci"
              If dr.Table.Columns.Contains("lci_id") AndAlso Not dr.IsNull("lci_id") Then
                If Not dr.IsNull("lci_id") Then
                  .m_entity = New LCIItem(dr, "")
                End If
              Else
                .m_entity = New LCIItem(itemId)
              End If
            Case 19 '"tool"
              If dr.Table.Columns.Contains("tool_id") AndAlso Not dr.IsNull("tool_id") Then
                If Not dr.IsNull("tool_id") Then
                  .m_entity = New Tool(dr, "")
                End If
              Else
                .m_entity = New Tool(itemId)
              End If
            Case 88, 89
              If itemId > 0 Then
                If dr.Table.Columns.Contains("lci_id") AndAlso Not dr.IsNull("lci_id") Then
                  If Not dr.IsNull("lci_id") Then
                    .m_entity = New LCIItem(dr, "")
                  End If
                Else
                  .m_entity = New LCIItem(itemId)
                End If
              Else
                .m_entity = New BlankItem(.m_entityName)
              End If
            Case Else    '0, 28, 88, 89, 160, 162
              .m_entity = New BlankItem(.m_entityName)
          End Select

        End If


        If dr.Table.Columns.Contains(aliasPrefix & "unit_id") AndAlso Not dr.IsNull(aliasPrefix & "unit_id") Then
          If Not dr.IsNull("unit_id") Then
            .m_unit = New Unit(dr, "")
          End If
        Else
          If dr.Table.Columns.Contains(aliasPrefix & "dri_unit") AndAlso Not dr.IsNull(aliasPrefix & "dri_unit") Then
            .m_unit = New Unit(CInt(dr(aliasPrefix & "dri_unit")))
          End If
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "dri_qty") AndAlso Not dr.IsNull(aliasPrefix & "dri_qty") Then
          .m_qty = CDec(dr(aliasPrefix & "dri_qty"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "dri_unitprice") AndAlso Not dr.IsNull(aliasPrefix & "dri_unitprice") Then
          .m_unitPrice = CDec(dr(aliasPrefix & "dri_unitprice"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "dri_mat") AndAlso Not dr.IsNull(aliasPrefix & "dri_mat") Then
          .m_mat = CDec(dr(aliasPrefix & "dri_mat"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "dri_lab") AndAlso Not dr.IsNull(aliasPrefix & "dri_lab") Then
          .m_lab = CDec(dr(aliasPrefix & "dri_lab"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "dri_eq") AndAlso Not dr.IsNull(aliasPrefix & "dri_eq") Then
          .m_eq = CDec(dr(aliasPrefix & "dri_eq"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "dri_amt") AndAlso Not dr.IsNull(aliasPrefix & "dri_amt") Then
          .m_amount = CDec(dr(aliasPrefix & "dri_amt"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "dri_unitCost") AndAlso Not dr.IsNull(aliasPrefix & "dri_unitCost") Then
          .m_unitCost = CDec(dr(aliasPrefix & "dri_unitCost"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "dri_note") AndAlso Not dr.IsNull(aliasPrefix & "dri_note") Then
          .m_note = CStr(dr(aliasPrefix & "dri_note"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "dri_unit") AndAlso Not dr.IsNull(aliasPrefix & "dri_unit") Then
          .m_unit = New Unit(CInt(dr(aliasPrefix & "dri_unit")))
        End If
        'End If

        If Not Me.Unit Is Nothing AndAlso Me.Unit.Originated Then
          If TypeOf Me.Entity Is LCIItem Then
            Dim lci As LCIItem = CType(Me.Entity, LCIItem)
            Try
              Me.Conversion = lci.GetConversion(Me.Unit)
            Catch ex As NoConversionException
              Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
              If Not msgServ Is Nothing Then
                msgServ.ShowErrorFormatted("วัสดุ {0} ไม่มีหน่วยนับ {1} ระบุไว้", New String() {ex.Lci.Code, ex.Unit.Name})
              End If
            End Try
          Else
            Me.Conversion = 1
          End If
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "receivedAmount") AndAlso Not dr.IsNull(aliasPrefix & "receivedAmount") Then
          .m_receivedAmount = CDec(dr(aliasPrefix & "receivedAmount"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "receivedMat") AndAlso Not dr.IsNull(aliasPrefix & "receivedMat") Then
          .m_receivedMat = CDec(dr(aliasPrefix & "receivedMat"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "receivedLab") AndAlso Not dr.IsNull(aliasPrefix & "receivedLab") Then
          .m_receivedLab = CDec(dr(aliasPrefix & "receivedLab"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "receivedEq") AndAlso Not dr.IsNull(aliasPrefix & "receivedEq") Then
          .m_receivedEq = CDec(dr(aliasPrefix & "receivedEq"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "receivedQty") AndAlso Not dr.IsNull(aliasPrefix & "receivedQty") Then
          .m_receivedQty = CDec(dr(aliasPrefix & "receivedQty"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "drio_qty") AndAlso Not dr.IsNull(aliasPrefix & "drio_qty") Then
          .m_oldQty = CDec(dr(aliasPrefix & "drio_qty"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "drio_mat") AndAlso Not dr.IsNull(aliasPrefix & "drio_mat") Then
          .m_oldMat = CDec(dr(aliasPrefix & "drio_mat"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "drio_lab") AndAlso Not dr.IsNull(aliasPrefix & "drio_lab") Then
          .m_oldLab = CDec(dr(aliasPrefix & "drio_lab"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "drio_eq") AndAlso Not dr.IsNull(aliasPrefix & "drio_eq") Then
          .m_oldEq = CDec(dr(aliasPrefix & "drio_eq"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "drio_amt") AndAlso Not dr.IsNull(aliasPrefix & "drio_amt") Then
          .m_oldAmount = CDec(dr(aliasPrefix & "drio_amt"))
        End If

      End With
    End Sub
    Protected Sub Construct(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
      Dim dr As DataRow = ds.Tables(0).Rows(0)
      Me.Construct(dr, aliasPrefix)
    End Sub
#End Region

#Region "Properties"
    Public ReadOnly Property AllocationErrorMessage() As String Implements IWBSAllocatableItem.AllocationErrorMessage
      Get
        If Me.ItemType Is Nothing Then
          Return "No Item Type"
        End If
        Select Case Me.ItemType.Value
          Case 160, 162
            Return "${res:Global.Error.CannotAllocate}"
            'Case 289
            '    If Me.ChildAmount <> Me.Amount Then
            '        Return "รายการนี้ไม่อนุญาติให้จัดสรร"
            '    End If
            '    If Me.GetChildAmount > 0 Then
            '        Return "รายการนี้ไม่อนุญาติให้จัดสรร"
            '    End If

        End Select
        Return ""
      End Get
    End Property
    Public ReadOnly Property Description() As String Implements IWBSAllocatableItem.Description
      Get
        Dim indent As String = ""
        'If Me.ItemType.Value <> 289 Then
        '    indent = Space(5)
        'End If
        If Me.Entity.Code.Length = 0 Then
          Return indent & Trim(Me.EntityName)
        End If
        Return indent & Me.Entity.Code & " : " & Trim(Me.Entity.Name)  '  Me.EntityName
      End Get
    End Property
    Public Property WBSDistributeCollection() As WBSDistributeCollection Implements IWBSAllocatableItem.WBSDistributeCollection
      Get
        Return m_FromCCWBSDistributeCollection
      End Get
      Set(ByVal Value As WBSDistributeCollection)
        m_FromCCWBSDistributeCollection = Value
      End Set
    End Property
    Public Property WBSDistributeCollection2() As WBSDistributeCollection Implements IWBSAllocatableItem.WBSDistributeCollection2
      Get
        'Return m_FromCCWBSDistributeCollection
      End Get
      Set(ByVal Value As WBSDistributeCollection)
        'm_FromCCWBSDistributeCollection = Value
      End Set
    End Property
    'Public ReadOnly Property AllowWBSAllocateFrom() As Boolean Implements IAllowWBSAllocatableItem.AllowWBSAllocateFrom
    '  Get
    '    'If Me.ItemType.Value = 291 Then
    '    '  Return False
    '    'Else
    '    Return True
    '    'End If
    '  End Get
    'End Property
    'Public ReadOnly Property AllowWBSAllocateTo() As Boolean Implements IAllowWBSAllocatableItem.AllowWBSAllocateTo
    '  Get
    '    'If Me.ItemType.Value = 160 OrElse Me.ItemType.Value = 162 Then
    '    Return False
    '    'Else
    '    'Return True
    '    'End If
    '  End Get
    'End Property
    Public ReadOnly Property Sequence() As Integer
      Get
        Return m_sequence
      End Get
    End Property
    Public ReadOnly Property AllocationType As String Implements IWBSAllocatableItem.AllocationType
      Get
        Select Case Me.ItemType.Value
          Case 88, 289, 291
            Return "lab"
          Case 89
            Return "eq"
          Case Else
            Return "mat"
        End Select
      End Get
    End Property
    Public ReadOnly Property Type() As String Implements IWBSAllocatableItem.Type
      Get
        If Me.ItemType Is Nothing Then
          Return ""
        End If
        Return ItemType.Description
      End Get
    End Property
    Public Property Dr() As DR
      Get
        Return m_dr
      End Get
      Set(ByVal Value As DR)
        m_dr = Value
      End Set
    End Property
    Public Property Linenumber() As Integer
      Get
        Return m_lineNumber
      End Get
      Set(ByVal Value As Integer)
        m_lineNumber = Value
      End Set
    End Property
    Public Property DRDescription() As String
      Get
        Return m_drdescription
      End Get
      Set(ByVal Value As String)
        m_drdescription = Value
      End Set
    End Property
    Public Property ItemType() As DRIItemType
      Get
        Return m_itemType
      End Get
      Set(ByVal Value As DRIItemType)
        Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
        If m_itemType Is Nothing Then
          m_itemType = Value
          Me.Clear()
          Return
        End If
        If Not Value Is Nothing AndAlso Value.Value = m_itemType.Value Then
          'ผ่านโลด
          Return
        End If
        'If Value.Value = 291 Then
        '  Me.FromCCWBSDistributeCollection.Clear()
        'End If
        'If msgServ.AskQuestion("${res:Global.Question.ChangePREntityType}") Then
        '  Dim oldType As Integer = m_itemType.Value
        m_itemType = Value
        'For Each wbsd As WBSDistribute In Me.WBSDistributeCollection
        '    Dim transferAmt As Decimal = Me.Amount
        '    wbsd.BaseCost = transferAmt
        '    wbsd.TransferBaseCost = transferAmt
        '    Select Case Me.ItemType.Value
        '        Case 0, 19, 42
        '            wbsd.BudgetAmount = wbsd.WBS.GetTotalMatFromDB
        '        Case 88
        '            wbsd.BudgetAmount = wbsd.WBS.GetTotalLabFromDB
        '        Case 89
        '            wbsd.BudgetAmount = wbsd.WBS.GetTotalEQFromDB
        '    End Select
        '    'Me.m_dr.SetActual(wbsd.WBS, wbsd.TransferAmount, 0, oldType)
        '    'Me.m_dr.SetActual(wbsd.WBS, 0, wbsd.TransferAmount, m_itemType.Value)
        'Next
        Me.Clear()
        'End If
      End Set
    End Property
    Public Property Entity() As IHasName
      Get
        Return m_entity
      End Get
      Set(ByVal Value As IHasName)
        m_entity = Value
        If TypeOf m_entity Is IHasUnit Then
          Me.m_unit = CType(m_entity, IHasUnit).DefaultUnit
        End If
      End Set
    End Property
    Public Property ItemName() As String
      Get
        Return m_entityName
      End Get
      Set(ByVal Value As String)
        m_entityName = Value
      End Set
    End Property
    Public Property UnitPrice() As Decimal
      Get
        Return m_unitPrice
      End Get
      Set(ByVal Value As Decimal)
        Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
        If Me.ItemType Is Nothing Then
          'ไม่มี Type
          msgServ.ShowMessage("${res:Global.Error.NoItemType}")
          Return
        End If
        Select Case Me.ItemType.Value
          Case 160, 162
            msgServ.ShowMessage("${res:Global.Error.NoteCannotHaveUnitPrice}")
            Return
        End Select
        Dim amt As Decimal = Value * Me.Qty

        Select Case Me.ItemType.Value
          Case 0, 19, 28, 42
            Me.m_mat = amt
            Me.m_lab = 0
            Me.m_eq = 0
          Case 88, 291
            Me.m_mat = 0
            Me.m_lab = amt
            Me.m_eq = 0
          Case 89
            Me.m_mat = 0
            Me.m_lab = 0
            Me.m_eq = amt
          Case 289
            If amt <= Me.Amount Then
              Me.m_mat = 0
              Me.m_lab = amt
              Me.m_eq = 0
            Else
              Dim amt2 As Decimal = Me.Mat + Me.Lab + Me.Eq
              m_lab = (amt - amt2) + Me.Lab
            End If
        End Select
        m_unitPrice = Value

      End Set
    End Property
    Public Property Qty() As Decimal
      Get
        Return m_qty
      End Get
      Set(ByVal Value As Decimal)
        Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
        If Me.ItemType Is Nothing Then
          'ไม่มี Type
          msgServ.ShowMessage("${res:Global.Error.NoItemType}")
          Return
        End If
        Select Case Me.ItemType.Value
          Case 160, 162
            'เป็นหมายเหตุ/หมายเหตุอ้างอิง มีปริมาณไม่ได้
            msgServ.ShowMessage("${res:Global.Error.NoteCannotHaveUnitPrice}")
            Return
        End Select

        Dim amt As Decimal = Value * Me.UnitPrice

        Select Case Me.ItemType.Value
          Case 0, 19, 28, 42
            Me.m_mat = amt
            Me.m_lab = 0
            Me.m_eq = 0
          Case 88, 291
            Me.m_mat = 0
            Me.m_lab = amt
            Me.m_eq = 0
          Case 89
            Me.m_mat = 0
            Me.m_lab = 0
            Me.m_eq = amt
          Case 289
            If amt <= Me.Amount Then
              Me.m_mat = 0
              Me.m_lab = amt
              Me.m_eq = 0
            Else
              Dim amt2 As Decimal = Me.Mat + Me.Lab + Me.Eq
              m_lab = (amt - amt2) + Me.Lab
            End If
        End Select
        If IsNumeric(Value) Then
          m_qty = Configuration.Format(Value, DigitConfig.Qty)
        Else
          m_qty = 0
        End If
        UpdateFromWBSQty()
        'UpdateToWBSQty()
      End Set
    End Property
    Public Property Unit() As Unit
      Get
        Return m_unit
      End Get
      Set(ByVal Value As Unit)
        Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
        If Me.ItemType Is Nothing Then
          'ไม่มี Type
          msgServ.ShowMessage("${res:Global.Error.NoItemType}")
          Return
        End If
        If Me.ItemType.Value = 160 Or Me.ItemType.Value = 162 Then
          msgServ.ShowMessage("${res:Global.Error.NoteCannotHaveUnit}")
          Return
        End If
        Dim oldConversion As Decimal = Me.Conversion
        Dim newConversion As Decimal = 1
        Dim err As String = ""
        If Not Value Is Nothing AndAlso Value.Originated Then
          If TypeOf Me.Entity Is LCIItem Then
            If CType(Me.Entity, LCIItem).Level < 5 Then
              newConversion = 1
            Else
              If Not CType(Me.Entity, LCIItem).ValidUnit(Value) Then
                err = "${res:Global.Error.NoUnitConversion}"
              Else
                newConversion = CType(Me.Entity, LCIItem).GetConversion(Value)
              End If
            End If
          ElseIf TypeOf Me.Entity Is Tool Then
            If Not (Not CType(Me.Entity, Tool).Unit Is Nothing AndAlso CType(Me.Entity, Tool).Unit.Id = Value.Id) Then
              err = "${res:Global.Error.NoUnitConversion}"
            End If
          End If
        Else
          err = "${res:Global.Error.InvalidUnit}"
        End If
        If err.Length = 0 Then
          If Me.m_qty <> 0 Then
            'Me.m_qty = (oldConversion / newConversion) * Me.m_qty
            Me.Qty = (Me.Qty * oldConversion) / newConversion
          End If
          If Me.UnitPrice <> 0 Then
            'Me.m_unitprice = (newConversion / oldConversion) * Me.m_unitprice
            Me.UnitPrice = (Me.UnitPrice / oldConversion) * newConversion
          End If
          m_unit = Value
        Else
          msgServ.ShowMessage(err)
        End If
      End Set
    End Property
    Public Property Mat() As Decimal
      Get
        Return m_mat
      End Get
      Set(ByVal Value As Decimal)
        If Me.ItemType.Value = 88 OrElse _
                Me.ItemType.Value = 89 OrElse _
                Me.ItemType.Value = 160 Then
          Return
        End If
        If Value >= Me.Amount Then
          m_mat = Me.Amount
          m_lab = 0
          m_eq = 0
        End If
        If Me.ItemType.Value = 289 Then
          m_lab = Me.Amount - Value - Me.Eq
        End If
        Dim m_value As Decimal = Value + Me.Lab + Me.Eq
        If m_value > Me.Amount Then
          Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
          msgServ.ShowMessageFormatted("${res:Longkong.Pojjaman.Gui.Panels.SCItem.OverAmount}", _
          New String() {Me.ItemDescription, Configuration.FormatToString(Me.Amount, DigitConfig.Price), _
                       Configuration.FormatToString(m_value, DigitConfig.Price)})
          Return
        Else
          m_mat = Value
        End If
      End Set
    End Property
    Public Property Lab() As Decimal
      Get
        Return m_lab
      End Get
      Set(ByVal Value As Decimal)
        If Me.ItemType.Value = 88 OrElse _
           Me.ItemType.Value = 289 Then
          If Value >= Me.Amount Then
            m_mat = 0
            m_lab = Me.Amount
            m_eq = 0
          End If
          Dim m_value As Decimal = Me.Mat + Value + Me.Eq
          If m_value > Me.Amount Then
            Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
            msgServ.ShowMessageFormatted("${res:Longkong.Pojjaman.Gui.Panels.SCItem.OverAmount}", _
            New String() {Me.ItemDescription, Configuration.FormatToString(Me.Amount, DigitConfig.Price), _
                         Configuration.FormatToString(m_value, DigitConfig.Price)})
            Return
          Else
            m_lab = Value
          End If
        End If
      End Set
    End Property
    Public Property Eq() As Decimal
      Get
        Return m_eq
      End Get
      Set(ByVal Value As Decimal)
        If Me.ItemType.Value = 89 OrElse _
           Me.ItemType.Value = 289 Then
          If Value >= Me.Amount Then
            m_mat = 0
            m_lab = 0
            m_eq = Me.Amount
          End If
          If Me.ItemType.Value = 289 Then
            m_lab = Me.Amount - Me.Mat - Value
          End If
          Dim m_value As Decimal = Me.Mat + Me.Lab + Value
          If m_value > Me.Amount Then
            Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
            msgServ.ShowMessageFormatted("${res:Longkong.Pojjaman.Gui.Panels.SCItem.OverAmount}", _
            New String() {Me.ItemDescription, Configuration.FormatToString(Me.Amount, DigitConfig.Price), _
                         Configuration.FormatToString(m_value, DigitConfig.Price)})
            Return
          Else
            m_eq = Value
          End If
        End If
      End Set
    End Property
    Public ReadOnly Property StockQty() As Decimal
      Get
        Return Configuration.Format(Me.Conversion * Me.Qty, DigitConfig.Qty)
      End Get
    End Property
    Public ReadOnly Property Amount() As Decimal 'Implements IWBSAllocatableItem.ItemAmount
      Get
        If Not Me.Dr Is Nothing AndAlso Me.Dr.Closing Then
          Return Me.ReceivedAmount
        End If
        Return Configuration.Format((Me.UnitPrice * Me.Qty), DigitConfig.Price)
      End Get
    End Property
    Public ReadOnly Property UnitCost() As Decimal
      Get
        If Me.StockQty <> 0 Then
          Dim tmpCost As Decimal = 0
          Dim tmpRealGrossNoVat As Decimal = 0

          tmpRealGrossNoVat = Me.Dr.RealGross

          If tmpRealGrossNoVat = 0 Then
            Return 0
          End If

          tmpCost = Me.AmountWithDefaultUnit

          tmpCost = tmpCost - ((tmpCost / tmpRealGrossNoVat) * Me.Dr.Discount.Amount)

          If Me.Dr.TaxType.Value = 2 Then
            If Not Me.UnVatable Then
              tmpCost = tmpCost * (100 / (100 + Me.Dr.TaxRate))
            End If
          End If

          If Me.StockQty = 0 Then
            Return 0
          End If

          tmpCost = tmpCost / Me.StockQty

          Return tmpCost
        End If
        Return 0
      End Get
    End Property
    Public ReadOnly Property CostAmount() As Decimal Implements IWBSAllocatableItem.ItemAmount
      Get
        Return Me.UnitCost * Me.StockQty
      End Get
    End Property
    Public ReadOnly Property AmountWithDefaultUnit() As Decimal
      Get
        If StockQty > 0 Then
          Return ((Me.UnitPrice / Me.Conversion) * StockQty) '- (Me.Discount.Amount / Me.Conversion)
        Else
          Return 0
        End If
      End Get
    End Property
    Public Property OldQty() As Decimal
      Get
        Return m_oldQty
      End Get
      Set(ByVal Value As Decimal)
        m_oldQty = Value
      End Set
    End Property
    Public Property OldMat() As Decimal
      Get
        Return m_oldMat
      End Get
      Set(ByVal Value As Decimal)
        m_oldMat = Value
      End Set
    End Property
    Public Property OldLab() As Decimal
      Get
        Return m_oldLab
      End Get
      Set(ByVal Value As Decimal)
        m_oldLab = Value
      End Set
    End Property
    Public Property OldEq() As Decimal
      Get
        Return m_oldEq
      End Get
      Set(ByVal Value As Decimal)
        m_oldEq = Value
      End Set
    End Property
    Public Property OldAmount() As Decimal
      Get
        Return m_oldAmount
      End Get
      Set(ByVal Value As Decimal)
        m_oldAmount = Value
      End Set
    End Property
    Public Property ReceivedAmount() As Decimal
      Get
        Return m_receivedAmount
      End Get
      Set(ByVal Value As Decimal)
        m_receivedAmount = Value
      End Set
    End Property
    Public Property ReceivedMat() As Decimal
      Get
        Return m_receivedMat
      End Get
      Set(ByVal Value As Decimal)
        m_receivedMat = Value
      End Set
    End Property
    Public Property ReceivedLab() As Decimal
      Get
        Return m_receivedLab
      End Get
      Set(ByVal Value As Decimal)
        m_receivedLab = Value
      End Set
    End Property
    Public Property ReceivedEq() As Decimal
      Get
        Return m_receivedEq
      End Get
      Set(ByVal Value As Decimal)
        m_receivedEq = Value
      End Set
    End Property
    Public Property ReceivedQty() As Decimal
      Get
        Return m_receivedQty
      End Get
      Set(ByVal Value As Decimal)
        m_receivedQty = Value
      End Set
    End Property
    Public Function DupCode(ByVal myCode As String) As Boolean
      If Me.Dr Is Nothing Then
        Return False
      End If
      If Me.ItemType Is Nothing Then
        Return False
      End If
      If Me.ItemType.Value = 42 OrElse Me.ItemType.Value = 88 OrElse Me.ItemType.Value = 89 Then
        'Material ใส่ Code เดียวกันได้
        Return False
      End If
      If myCode Is Nothing OrElse myCode.Length = 0 Then
        Return False
      End If
      For Each item As DRItem In Me.Dr.ItemCollection
        If Not item Is Me Then
          If item.ItemType.Value = Me.ItemType.Value Then
            Dim theCode As String = ""
            If Not item.Entity Is Nothing Then
              theCode = item.Entity.Code
            End If
            If Not theCode Is Nothing AndAlso theCode.Length > 0 Then
              If myCode.ToLower = theCode.ToString.ToLower Then
                Return True
              End If
            End If
          End If
        End If
      Next
      Return False
    End Function

    'Public Property dritem() As DRItem
    '    Get
    '        Return m_dritem
    '    End Get
    '    Set(ByVal Value As dritem)
    '        m_dritem = Value
    '    End Set
    'End Property
    'Public Property ItemType() As ItemType
    '    Get
    '        Return m_itemType
    '    End Get
    '    Set(ByVal Value As ItemType)
    '        Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
    '        If m_itemType Is Nothing Then
    '            m_itemType = Value
    '            Me.Clear()
    '            Return
    '        End If
    '        If Not Value Is Nothing AndAlso Value.Value = m_itemType.Value Then
    '            'ผ่านโลด
    '            Return
    '        End If
    '        If msgServ.AskQuestion("${res:Global.Question.ChangePOEntityType}") Then
    '            Dim oldType As Integer = m_itemType.Value
    '            m_itemType = Value
    '            For Each wbsd As WBSDistribute In Me.WBSDistributeCollection
    '                Dim bfTax As Decimal = 0
    '                If Not Me.Po Is Nothing Then 'AndAlso item.Po.Originated
    '                    If Me.Po.Closed Then
    '                        bfTax = Me.ReceivedBeforeTax
    '                    Else
    '                        bfTax = Me.BeforeTax
    '                    End If
    '                End If
    '                Dim transferAmt As Decimal = bfTax
    '                wbsd.BaseCost = bfTax
    '                wbsd.TransferBaseCost = transferAmt
    '                Select Case Me.ItemType.Value
    '                    Case 0, 19, 42
    '                        wbsd.BudgetAmount = wbsd.WBS.GetTotalMatFromDB
    '                    Case 88
    '                        wbsd.BudgetAmount = wbsd.WBS.GetTotalLabFromDB
    '                    Case 89
    '                        wbsd.BudgetAmount = wbsd.WBS.GetTotalEQFromDB
    '                End Select
    '                Me.m_po.SetActual(wbsd.WBS, wbsd.TransferAmount, 0, oldType)
    '                Me.m_po.SetActual(wbsd.WBS, 0, wbsd.TransferAmount, m_itemType.Value)
    '            Next
    '            'Me.Clear()
    '        End If
    '    End Set
    'End Property

    Private Function GetAmountFromSproc(ByVal sproc As String, ByVal ParamArray filters() As SqlParameter) As Decimal
      Try
        Dim ds As DataSet = SqlHelper.ExecuteDataset( _
                RecentCompanies.CurrentCompany.SiteConnectionString _
                , CommandType.StoredProcedure _
                , sproc _
                , filters _
                )
        If ds.Tables(0).Rows(0).IsNull(0) Then
          Return 0
        End If
        Return CDec(ds.Tables(0).Rows(0)(0))
      Catch ex As Exception
      End Try
    End Function
    Public Sub SetItemCode(ByVal theCode As String)
      Dim unitPrice As Decimal = 0
      'Dim pricing As Integer = CInt(Configuration.GetConfig("CompanyPOPricing"))
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      If Me.ItemType Is Nothing Then
        'ไม่มี Type
        msgServ.ShowMessage("${res:Global.Error.NoItemType}")
        Return
      End If
      If DupCode(theCode) Then
        msgServ.ShowMessageFormatted("${res:Global.Error.AlreadyHasCode}", New String() {Me.ItemType.Description, theCode})
        Return
      End If
      Select Case Me.ItemType.Value
        Case 160, 162 'Note
          msgServ.ShowMessage("${res:Global.Error.NoteCannotHaveCode}")
          Return
        Case 0  ', 88, 89 'Blank
          msgServ.ShowMessage("${res:Global.Error.BlankItemORLaborOrEQCannotHaveCode}")
          Return
        Case 28   'F/A
          msgServ.ShowMessage("${res:Global.Error.FACannotHaveCode}")
          Return
        Case 19   'Tool
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
          ElseIf myTool.Canceled Then
            msgServ.ShowMessageFormatted("${res:Global.Error.ToolIsCanceled}", New String() {theCode})
            Return
          Else
            'Select Case pricing
            '  Case 0
            unitPrice = myTool.FairPrice
            '  Case 2
            '    unitPrice = GetAmountFromSproc("GetPOPriceForSupplier" _
            '    , New SqlParameter("@dri_entity", myTool.Id) _
            '    , New SqlParameter("@dri_entitytype", myTool.EntityId) _
            '    )
            'End Select
            Dim myUnit As Unit = myTool.Unit
            Me.m_unit = myUnit
            Me.m_entity = myTool
            If Me.Conversion <> 0 Then
              unitPrice = unitPrice * Conversion
            End If
            Me.UnitPrice = unitPrice
          End If
        Case 42, 88, 89   'LCI
          If theCode Is Nothing OrElse theCode.Length = 0 Then
            If Me.Entity.Code.Length <> 0 Then
              If msgServ.AskQuestionFormatted("${res:Global.Question.DeleteLCIDetail}", New String() {Me.Entity.Code}) Then
                Me.Clear()
              End If
            End If
            If Me.ItemType.Value = 42 Then
              Return
            Else
              Exit Select
            End If
          End If
          Dim lci As New LCIItem(theCode)
          If Not lci.Originated Then
            msgServ.ShowMessageFormatted("${res:Global.Error.NoLCI}", New String() {theCode})
            Return
          ElseIf lci.Canceled Then
            msgServ.ShowMessageFormatted("${res:Global.Error.LCIIsCanceled}", New String() {theCode})
            Return
          ElseIf lci.Level <> 5 Then
            msgServ.ShowMessageFormatted("${res:Global.LCI.Level5Only}", New String() {theCode})
            Return
          Else
            'Select Case pricing
            '  Case 0
            unitPrice = lci.FairPrice
            '  Case 2
            '    unitPrice = GetAmountFromSproc("GetPOPriceForSupplier" _
            '    , New SqlParameter("@dri_entity", lci.Id) _
            '    , New SqlParameter("@dri_entitytype", lci.EntityId) _
            '    )
            'End Select
            Dim myUnit As Unit = lci.DefaultUnit
            Me.m_unit = myUnit
            Me.m_entity = lci
            If Me.Conversion <> 0 Then
              unitPrice = unitPrice * Conversion
            End If
            Me.UnitPrice = unitPrice
          End If

        Case Else
          msgServ.ShowMessage("${res:Global.Error.NoItemType}")
          Return
      End Select
      Me.Qty = 1
      'Me.ReceivedQty = 0 'UNDONE
    End Sub
    Public Sub SetItemPrice(ByVal theCode As String)
      Dim unitPrice As Decimal = 0
      Dim pricing As Integer = CInt(Configuration.GetConfig("CompanyDRPricing"))
      Select Case Me.ItemType.Value
        Case 19 'Tool
          If theCode Is Nothing OrElse theCode.Length = 0 Then
            Return
          End If
          Dim myTool As New Tool(theCode)

          Select Case pricing
            Case 0
              unitPrice = myTool.FairPrice
            Case 2
              unitPrice = GetAmountFromSproc("GetDRPriceForSupplier" _
              , New SqlParameter("@dri_entity", myTool.Id) _
              , New SqlParameter("@dri_entitytype", myTool.EntityId) _
              )
          End Select


          If Me.Conversion <> 0 Then
            unitPrice = unitPrice * Conversion
          End If
          Me.UnitPrice = unitPrice

        Case 42, 88, 89  'LCI
          If theCode Is Nothing OrElse theCode.Length = 0 Then
            Return
          End If
          Dim lci As New LCIItem(theCode)

          Select Case pricing
            Case 0
              unitPrice = lci.FairPrice
            Case 2
              unitPrice = GetAmountFromSproc("GetPOPriceForSupplier" _
              , New SqlParameter("@po_supplier", DBNull.Value) _
              , New SqlParameter("@poi_entity", lci.Id) _
              , New SqlParameter("@poi_entitytype", lci.EntityId) _
              )
          End Select
          If Me.Conversion <> 0 Then
            unitPrice = unitPrice * Conversion
          End If
          Me.UnitPrice = unitPrice
      End Select
      Me.Qty = 1
      Me.ReceivedQty = 0  'UNDONE
    End Sub
    Public Property EntityName() As String
      Get
        Return m_entityName
      End Get
      Set(ByVal Value As String)
        Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
        If Me.ItemType Is Nothing Then
          'ไม่มี Type
          msgServ.ShowMessage("${res:Global.Error.NoItemType}")
          Return
        End If
        Select Case Me.ItemType.Value
          Case 19, 42
            If Not Me.Entity.Code Is Nothing AndAlso Me.Entity.Code.Length > 0 Then
              'มี Code อยู่ ---> 
              Me.m_entityName = Value
            Else
              msgServ.ShowMessage("${res:Global.Error.ItemCodeMissing}")
            End If
          Case Else '0, 28, 88, 89, 160, 162
            Me.m_entityName = Value
        End Select
      End Set
    End Property
    Public ReadOnly Property ItemDescription() As String
      Get
        If Me.ItemType.Value = 19 OrElse Me.ItemType.Value = 42 OrElse _
           Me.ItemType.Value = 88 OrElse Me.ItemType.Value = 89 Then
          If Me.EntityName.Length > 0 Then
            Return Me.EntityName & "<" & Me.Entity.Name & ">"
          End If
          Return Me.Entity.Name
        Else
          Return Me.EntityName
        End If
      End Get
    End Property
    Public Property Note() As String
      Get
        Return m_note
      End Get
      Set(ByVal Value As String)
        m_note = Value
      End Set
    End Property
    'Public Property ReceivedQty() As Decimal 'หน่วยตาม QTY ไม่ใช่ STOCKQTY
    '  Get
    '    Return m_receivedQty
    '  End Get
    '  Set(ByVal Value As Decimal)
    '    m_receivedQty = Value
    '  End Set
    'End Property
    Public Property Conversion() As Decimal
      Get
        Return m_conversion
      End Get
      Set(ByVal Value As Decimal)
        m_conversion = Value
      End Set
    End Property
    Private Function CalcTaxAmount(ByVal amt As Decimal) As Decimal
      If Me.Dr Is Nothing Then
        Return 0
      End If
      Return (Me.Dr.TaxRate * amt) / 100
    End Function
    Public ReadOnly Property TaxAmount() As Decimal
      Get
        'Return Me.CalcTaxAmount(Me.TaxBase)
      End Get
    End Property
    Public Property UnVatable() As Boolean
      Get
        Return m_unvatable
      End Get
      Set(ByVal Value As Boolean)
        m_unvatable = Value
      End Set
    End Property
#End Region

#Region "Methods"
    Public Sub UpdateWBSQty()
        Select Case Me.ItemType.Value
          Case 88, 89, 160, 162
            For Each wbsd As WBSDistribute In Me.WBSDistributeCollection
              wbsd.BaseQty = 0
            Next
          Case Else
            For Each wbsd As WBSDistribute In Me.WBSDistributeCollection
              If wbsd.IsMarkup Then
                wbsd.BaseQty = 0
              Else
                Dim boqConversion As Decimal = wbsd.WBS.GetBoqItemConversion(Me.Entity.Id, Me.Unit.Id, Me.ItemType.Value)
                If boqConversion = 0 Then
                  wbsd.BaseQty = Me.Qty
                Else
                  wbsd.BaseQty = Me.Qty * (Me.Conversion / boqConversion)
                End If
              End If
            Next
        End Select
    End Sub
    'Public Sub UpdateWBSQty()
    '  If (Me.ItemType.Value = 160 OrElse
    '  Me.ItemType.Value = 162 OrElse
    '  Me.ItemType.Value = 88 OrElse
    '  Me.ItemType.Value = 89) Then
    '    For Each wbsd As WBSDistribute In Me.WBSDistributeCollection
    '      wbsd.BaseQty = 0
    '      wbsd.QtyRemain = 0
    '    Next
    '    Return
    '  End If
    '  For Each wbsd As WBSDistribute In Me.WBSDistributeCollection
    '    'Dim bfTax As Decimal = 0
    '    'Dim oldVal As Decimal = wbsd.TransferAmount
    '    'Dim transferAmt As Decimal = Me.Amount
    '    'wbsd.BaseCost = bfTax
    '    'wbsd.TransferBaseCost = transferAmt
    '    Dim boqConversion As Decimal = wbsd.WBS.GetBoqItemConversion(Me.Entity.Id, Me.Unit.Id, Me.ItemType.Value)
    '    If boqConversion = 0 Then
    '      wbsd.BaseQty = Me.Qty
    '    Else
    '      wbsd.BaseQty = Me.Qty * (Me.Conversion / boqConversion)
    '    End If

    '    'Me.WBSChangedHandler(wbsd, New PropertyChangedEventArgs("Percent", wbsd.TransferAmount, oldVal))
    '  Next
    '  'For Each wbsd As WBSDistribute In Me.FromCCWBSDistributeCollection
    '  '  'Dim bfTax As Decimal = 0
    '  '  'Dim oldVal As Decimal = wbsd.TransferAmount
    '  '  'Dim transferAmt As Decimal = Me.Amount
    '  '  'wbsd.BaseCost = bfTax
    '  '  'wbsd.TransferBaseCost = transferAmt
    '  '  Dim boqConversion As Decimal = wbsd.WBS.GetBoqItemConversion(Me.Entity.Id, Me.Unit.Id)
    '  '  If boqConversion = 0 Then
    '  '    wbsd.BaseQty = Me.Qty
    '  '  Else
    '  '    wbsd.BaseQty = Me.Qty * (Me.Conversion / boqConversion)
    '  '  End If

    '  '  'Me.WBSChangedHandler(wbsd, New PropertyChangedEventArgs("Percent", wbsd.TransferAmount, oldVal))
    '  'Next
    'End Sub
    Public Sub ItemValidateRow(ByVal row As DataRow)
      Dim unit As Object = row("unit")
      Dim code As Object = row("Code")
      Dim dri_itemName As Object = row("dri_itemName")
      Dim dri_qty As Object = row("dri_qty")
      Dim dri_unitprice As Object = row("dri_unitprice")
      Dim dri_entitytype As Object = row("dri_entitytype")

      'Dim isClosed As Boolean = False
      'isClosed = Me.Dr.Closed

      Dim isBlankRow As Boolean = False
      If IsDBNull(dri_entitytype) Then
        isBlankRow = True
      End If
      Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
      If Not isBlankRow Then
        Select Case CInt(dri_entitytype)
          Case 160, 162 'Note
            row.SetColumnError("dri_qty", "")
            'row.SetColumnError("dri_unitprice", "")
            row.SetColumnError("dri_itemname", "")
            row.SetColumnError("code", "")
          Case 0, 88, 89 'blank item /ค่าแรง/เครื่องจักร
            If IsDBNull(dri_itemName) OrElse dri_itemName.ToString.Length = 0 Then
              row.SetColumnError("dri_itemName", myStringParserService.Parse("${res:Global.Error.ItemNameMissing}"))
            Else
              row.SetColumnError("dri_itemName", "")
            End If
            If Not IsNumeric(dri_qty) AndAlso Not Me.Dr.Closing Then 'OrElse CDec(poi_qty) <= 0 Then
              'If isClosed Then
              '    row.SetColumnError("poi_qty", "")
              'Else
              row.SetColumnError("dri_qty", myStringParserService.Parse("${res:Global.Error.ItemQtyMissing}"))
              'End If
            Else
              row.SetColumnError("dri_qty", "")
            End If
            row.SetColumnError("code", "")
            'If Not IsNumeric(poi_unitprice) Then 'OrElse CDec(poi_unitprice) <= 0 Then
            '    row.SetColumnError("poi_unitprice", myStringParserService.Parse("${res:Global.Error.ItemUnitPriceMissing}"))
            'Else
            '    row.SetColumnError("poi_unitprice", "")
            'End If

            row.SetColumnError("dri_unitprice", "")
          Case 19 'เครื่องมือ
            If IsDBNull(code) OrElse code.ToString.Length = 0 Then
              row.SetColumnError("code", myStringParserService.Parse("${res:Global.Error.ItemCodeMissing}"))
            Else
              row.SetColumnError("code", "")
            End If
            If IsDBNull(dri_itemName) OrElse dri_itemName.ToString.Length = 0 Then
              row.SetColumnError("dri_itemName", myStringParserService.Parse("${res:Global.Error.ItemNameMissing}"))
            Else
              row.SetColumnError("dri_itemName", "")
            End If
            If (Not IsNumeric(dri_qty)) AndAlso Not Me.Dr.Closing Then 'OrElse CDec(poi_qty) <= 0 Then
              'If isClosed Then
              '    row.SetColumnError("poi_qty", "")
              'Else
              row.SetColumnError("dri_qty", myStringParserService.Parse("${res:Global.Error.ItemQtyMissing}"))
              'End If
            Else
              row.SetColumnError("dri_qty", "")
            End If
            'If Not IsNumeric(poi_unitprice) Then 'OrElse CDec(poi_unitprice) <= 0 Then
            '    row.SetColumnError("poi_unitprice", myStringParserService.Parse("${res:Global.Error.ItemUnitPriceMissing}"))
            'Else
            '    row.SetColumnError("poi_unitprice", "")
            'End If
            row.SetColumnError("dri_unitprice", "")
          Case 28 'F/A
            If IsDBNull(dri_itemName) OrElse dri_itemName.ToString.Length = 0 Then
              row.SetColumnError("dri_itemName", myStringParserService.Parse("${res:Global.Error.ItemNameMissing}"))
            Else
              row.SetColumnError("dri_itemName", "")
            End If
            If (Not IsNumeric(dri_qty)) AndAlso Not Me.Dr.Closing Then 'OrElse CDec(poi_qty) <= 0 Then
              'If isClosed Then
              '    row.SetColumnError("poi_qty", "")
              'Else
              row.SetColumnError("dri_qty", myStringParserService.Parse("${res:Global.Error.ItemQtyMissing}"))
              'End If
            Else
              row.SetColumnError("dri_qty", "")
            End If
            'If Not IsNumeric(poi_unitprice) Then 'OrElse CDec(poi_unitprice) <= 0 Then
            '    row.SetColumnError("poi_unitprice", myStringParserService.Parse("${res:Global.Error.ItemUnitPriceMissing}"))
            'Else
            '    row.SetColumnError("poi_unitprice", "")
            'End If
            row.SetColumnError("dri_unitprice", "")
            row.SetColumnError("code", "")
          Case 42 'LCI
            If IsDBNull(code) OrElse code.ToString.Length = 0 Then
              row.SetColumnError("code", myStringParserService.Parse("${res:Global.Error.ItemCodeMissing}"))
            Else
              row.SetColumnError("code", "")
            End If
            If IsDBNull(dri_itemName) OrElse dri_itemName.ToString.Length = 0 Then
              row.SetColumnError("dri_itemName", myStringParserService.Parse("${res:Global.Error.ItemNameMissing}"))
            Else
              row.SetColumnError("dri_itemName", "")
            End If
            If (Not IsNumeric(dri_qty)) AndAlso Not Me.Dr.Closing Then 'OrElse CDec(poi_qty) <= 0 Then
              'If isClosed Then
              '    row.SetColumnError("dri_qty", "")
              'Else
              row.SetColumnError("dri_qty", myStringParserService.Parse("${res:Global.Error.ItemQtyMissing}"))
              'End If
            Else
              row.SetColumnError("dri_qty", "")
            End If
            'If Not IsNumeric(poi_unitprice) Then ' OrElse CDec(poi_unitprice) <= 0 Then
            '    row.SetColumnError("poi_unitprice", myStringParserService.Parse("${res:Global.Error.ItemUnitPriceMissing}"))
            'Else
            '    row.SetColumnError("poi_unitprice", "")
            'End If
            row.SetColumnError("dri_unitprice", "")
          Case Else
            Return
        End Select
      End If
    End Sub
    '----------------------------copy from SC---------------------------------
    'Public Sub CopyFromPRItem(ByVal prItem As PRItem)
    '    Me.m_pritem = prItem
    '    'Me.m_itemType = prItem.ItemType
    '    Me.m_entity = prItem.Entity
    '    Me.m_entityName = prItem.EntityName
    '    Me.m_unit = prItem.Unit
    '    Me.m_qty = Math.Max(prItem.Qty - (prItem.WithdrawnQty + prItem.OrderedQty), 0)
    '    Me.m_unitPrice = prItem.UnitPrice
    '    Me.m_note = prItem.Note
    '    If Not prItem.WBSDistributeCollection Is Nothing Then
    '        'Me.WBSDistributeCollection = prItem.WBSDistributeCollection.Clone(Me)

    '        'เพิ่มตรงนี้มา --> เพราะของเดิมแก้ % , wbs แล้วค่าคงเหลือไม่เปลี่ยน
    '        AddHandler Me.WBSDistributeCollection.PropertyChanged, AddressOf Me.WBSChangedHandler

    '    End If
    'End Sub
    Public Sub Clear()
      Me.m_entity = New BlankItem("")
      Me.m_entityName = ""
      Me.m_qty = 0
      Me.m_unit = New Unit
      Me.m_unitPrice = 0
      Me.m_note = ""
    End Sub
    Public Sub CopyToDataRow(ByVal row As TreeRow)
      If row Is Nothing Then
        Return
      End If
      Try
        Me.Dr.IsInitialized = False
        row("dri_linenumber") = Me.Linenumber
        '*************row("dri_drdesc") = Me.SCDescription

        If Not Me.ItemType Is Nothing Then
          row("dri_entityType") = Me.ItemType.Value
          Select Case Me.ItemType.Value
            Case 19, 42
              If Not Me.Entity Is Nothing Then
                row("dri_entity") = Me.Entity.Id
                row("dri_itemName") = Me.Entity.Name
                row("EntityName") = Me.Entity.Name
                row("Code") = Me.Entity.Code
                If Not Me.EntityName Is Nothing AndAlso Me.EntityName.Length > 0 Then
                  If Me.Entity.Name <> Me.EntityName Then
                    row("dri_itemName") = Me.EntityName & "<" & Me.Entity.Name & ">"
                  End If
                End If
              End If
              row("Button") = ""
            Case 88, 89
              If Not Me.Entity Is Nothing Then
                row("dri_entity") = Me.Entity.Id
                row("dri_itemName") = Me.Entity.Name
                row("EntityName") = Me.Entity.Name
                row("Code") = Me.Entity.Code
                If Not Me.EntityName Is Nothing AndAlso Me.EntityName.Length > 0 Then
                  If Me.Entity.Name <> Me.EntityName Then
                    row("dri_itemName") = Me.EntityName & "<" & Me.Entity.Name & ">"
                  End If
                End If
              End If
              row("Button") = ""
            Case 0, 28, 291   ', 88, 89
              row("Button") = "invisible"
              row("dri_itemName") = Me.EntityName
            Case 160, 162
              row("Button") = "invisible"
              row("UnitButton") = "invisible"
              row("dri_itemName") = Me.EntityName
          End Select
        End If

        If Not Me.Unit Is Nothing Then
          row("dri_unit") = Me.Unit.Id
          row("Unit") = Me.Unit.Name
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

        'Dim parent As Dr = Me.Dr
        'If parent Is Nothing Then parent = New Dr

        If Me.Qty <> 0 Then
          row("dri_qty") = Configuration.FormatToString(Me.Qty, DigitConfig.Qty)
        Else
          row("dri_qty") = ""
        End If
        Select Case Me.ItemType.Value
          Case 88
            row("dri_mat") = ""
            If Me.Lab <> 0 Then
              row("dri_lab") = Configuration.FormatToString(Me.Lab, DigitConfig.Price)
            Else
              row("dri_lab") = ""
            End If
            row("dri_eq") = ""
          Case 89
            row("dri_mat") = ""
            row("dri_lab") = ""
            If Me.Eq <> 0 Then
              row("dri_eq") = Configuration.FormatToString(Me.Eq, DigitConfig.Price)
            Else
              row("dri_eq") = ""
            End If
          Case 289
            row("dri_mat") = ""
            row("dri_lab") = ""
            row("dri_eq") = ""
          Case Else
            If Me.Mat <> 0 Then
              row("dri_mat") = Configuration.FormatToString(Me.Mat, DigitConfig.Price)
            Else
              row("dri_mat") = ""
            End If
            If Me.Lab <> 0 Then
              row("dri_lab") = Configuration.FormatToString(Me.Lab, DigitConfig.Price)
            Else
              row("dri_lab") = ""
            End If
            If Me.Eq <> 0 Then
              row("dri_eq") = Configuration.FormatToString(Me.Eq, DigitConfig.Price)
            Else
              row("dri_eq") = ""
            End If
        End Select

        If Me.UnitPrice <> 0 Then
          row("dri_unitprice") = Configuration.FormatToString(Me.UnitPrice, DigitConfig.UnitPrice)
        Else
          row("dri_unitprice") = ""
        End If

        'row("dri_discrate") = Me.Discount.Rate
        If Me.Amount <> 0 Then
          row("Amount") = Configuration.FormatToString(Me.Amount, DigitConfig.Price)
        Else
          row("Amount") = ""
        End If

        If Me.ReceivedAmount <> 0 Then
          row("ReceivedAmount") = Configuration.FormatToString(Me.ReceivedAmount, DigitConfig.Price)
        Else
          row("ReceivedAmount") = ""
        End If

        row("dri_note") = Me.Note

        row("dri_unvatable") = Me.UnVatable

        Me.Dr.IsInitialized = True
      Catch ex As NoConversionException
        MessageBox.Show("วัสดุ '" & ex.Lci.Code & "' ไม่มีหน่วยนับ '" & ex.Unit.Name & "'")
      Catch ex As Exception
        MessageBox.Show(ex.Message & "::" & ex.StackTrace)
      End Try
    End Sub
    Public Sub UpdateFromWBSQty()
      For Each wbsd As WBSDistribute In Me.WBSDistributeCollection
        'Dim bfTax As Decimal = 0
        'Dim oldVal As Decimal = wbsd.TransferAmount
        'Dim transferAmt As Decimal = Me.Amount
        'wbsd.BaseCost = bfTax
        'wbsd.TransferBaseCost = transferAmt
        Dim boqConversion As Decimal = wbsd.WBS.GetBoqItemConversion(Me.Entity.Id, Me.Unit.Id, ItemType.Value)
        If boqConversion = 0 Then
          wbsd.BaseQty = Me.Qty
        Else
          wbsd.BaseQty = Me.Qty * (Me.Conversion / boqConversion)
        End If

        'Me.WBSChangedHandler(wbsd, New PropertyChangedEventArgs("Percent", wbsd.TransferAmount, oldVal))
      Next
    End Sub
    'Public Sub UpdateToWBSQty()
    '  For Each wbsd As WBSDistribute In Me.ToCCWBSDistributeCollection
    '    'Dim bfTax As Decimal = 0
    '    'Dim oldVal As Decimal = wbsd.TransferAmount
    '    'Dim transferAmt As Decimal = Me.Amount
    '    'wbsd.BaseCost = bfTax
    '    'wbsd.TransferBaseCost = transferAmt
    '    Dim boqConversion As Decimal = wbsd.WBS.GetBoqItemConversion(Me.Entity.Id, Me.Unit.Id)
    '    If boqConversion = 0 Then
    '      wbsd.BaseQty = Me.Qty
    '    Else
    '      wbsd.BaseQty = Me.Qty * (Me.Conversion / boqConversion)
    '    End If

    '    'Me.WBSChangedHandler(wbsd, New PropertyChangedEventArgs("Percent", wbsd.TransferAmount, oldVal))
    '  Next
    'End Sub
    Public Sub SetMat(ByVal value As Decimal)
      m_mat = value
    End Sub
    Public Sub SetLab(ByVal value As Decimal)
      m_lab = value
    End Sub
    Public Sub SetEq(ByVal value As Decimal)
      m_eq = value
    End Sub
    Public Sub SetQty(ByVal value As Decimal)
      m_qty = value
    End Sub
#End Region

#Region "Shared"
    Public Shared Function GetListDatatable(ByVal ParamArray filters() As Filter) As TreeTable

      'Dim sqlConString As String = RecentCompanies.CurrentCompany.ConnectionString
      'Dim params() As SqlParameter
      'If Not filters Is Nothing AndAlso filters.Length > 0 Then
      '    ReDim params(filters.Length - 1)
      '    For i As Integer = 0 To filters.Length - 1
      '        params(i) = New SqlParameter("@" & filters(i).Name, filters(i).Value)
      '    Next
      'End If
      'Dim dt As DataTable
      'Dim ds As DataSet = SqlHelper.ExecuteDataset(sqlConString, CommandType.StoredProcedure, "GetDRItemsList", params)
      'dt = ds.Tables(0)

      Dim myDatatable As New TreeTable("DRItems")
      myDatatable.Columns.Add(New DataColumn("Selected", GetType(Boolean)))
      myDatatable.Columns.Add(New DataColumn("Code", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("m_sc", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("Linenumber", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Entity", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Qty", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("OrderedQty", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Date", GetType(Date)))
      myDatatable.Columns.Add(New DataColumn("DummyDate", GetType(Date)))
      myDatatable.Columns.Add(New DataColumn("ReceivingDate", GetType(Date)))
      myDatatable.Columns.Add(New DataColumn("DummyReceivingDate", GetType(Date)))
      myDatatable.Columns.Add(New DataColumn("Requestor", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("CostCenter", GetType(String)))

      'Dim inValidIds As ArrayList = GetPRIdWithOnlyNoteItem(dt)
      'For Each tableRow As DataRow In dt.Rows
      '    If Not inValidIds.Contains(CInt(tableRow("dri_sc"))) Then
      '        Dim dri As New DRItem(tableRow, "")
      '        Dim row As TreeRow = myDatatable.Childs.Add
      '        row("Selected") = False
      '        row("Code") = tableRow("dr_code")
      '        row("m_dr") = tableRow("dri_dr")

      '        Dim drId As Integer
      '        If Not row.IsNull("m_dr") Then
      '            drId = CInt(row("m_dr"))
      '        End If

      '        row("Linenumber") = tableRow("dri_linenumber")
      '        row("Date") = tableRow("dr_docdate")
      '        row("ReceivingDate") = tableRow("dr_receivingdate")

      '        Dim entityText As String = ""
      '        If Not dri.ItemType Is Nothing Then
      '            entityText &= dri.ItemType.Description & ":"
      '        End If
      '        If Not dri.Entity.Code Is Nothing AndAlso dri.Entity.Code.Length > 0 Then
      '            entityText &= dri.Entity.Code & ":"
      '        End If
      '        If Not dri.Entity.Name Is Nothing AndAlso dri.Entity.Name.Length > 0 Then
      '            entityText &= dri.Entity.Name
      '        End If
      '        row("Entity") = entityText
      '        row("Qty") = dri.Qty
      '        row("Requestor") = tableRow("requestorinfo")
      '        row("CostCenter") = tableRow("ccinfo")
      '        row.State = RowExpandState.None

      '        dri.Dr = New Dr
      '        dri.Dr.Id = drId
      '        row.Tag = dri
      '    End If
      'Next
      Return myDatatable
    End Function
    'Private Shared Function GetPRIdWithOnlyNoteItem(ByVal dt As DataTable) As ArrayList
    '    Dim arr As New ArrayList
    '    Dim tmpId As Integer = 0
    '    For Each tableRow As DataRow In dt.Rows
    '        If tmpId <> CInt(tableRow("dri_sc")) Then
    '            tmpId = CInt(tableRow("dri_sc"))
    '            If Not arr.Contains(tmpId) Then
    '                arr.Add(tmpId)
    '            End If
    '        End If
    '    Next
    '    Dim realArr As New ArrayList
    '    For Each id As Integer In arr
    '        Dim rows As DataRow() = dt.Select("dri_dr = " & id)
    '        Dim found As Boolean = False
    '        For Each row As DataRow In rows
    '            Dim sci As New DRItem(row, "")
    '            'If sci.OrderedQty <> 0 Or sci.Qty <> 0 Then
    '            '    found = True
    '            '    Exit For
    '            'End If
    '        Next
    '        If Not found Then
    '            If Not realArr.Contains(id) Then
    '                realArr.Add(id)
    '            End If
    '        End If
    '    Next
    '    Return realArr
    'End Function
#End Region

    Public Sub WBSChangedHandler(ByVal sender As Object, ByVal e As PropertyChangedEventArgs) Implements IWBSAllocatableItem.WBSChangedHandler
      If TypeOf sender Is WBSDistribute Then
        Dim wbsd As WBSDistribute = CType(sender, WBSDistribute)
        Select Case e.Name.ToLower
          Case "percent"
            'If Not Me.m_dr Is Nothing Then
            '    Me.m_dr.SetActual(wbsd.WBS, CDec(e.OldValue), CDec(e.Value), Me.ItemType.Value)
            'End If
          Case "wbs"
            'Dim oldWBS As WBS = CType(e.OldValue, WBS)
            Dim newWBS As WBS = CType(e.Value, WBS)
            Dim theName As String = Me.EntityName
            If theName Is Nothing Then
              theName = Me.Entity.Name
            End If
            Select Case Me.ItemType.Value
              Case 289, 291
                wbsd.BudgetAmount = newWBS.GetTotalLabFromDB 'GetTotalMatFromDB
                wbsd.BudgetQty = newWBS.GetBudgetQtyForType0FromDB(theName)
                wbsd.OwnerBudgetAmount = newWBS.OwnerMatBudgetAmount
              Case 0
                wbsd.BudgetAmount = newWBS.GetTotalMatFromDB
                wbsd.BudgetQty = newWBS.GetBudgetQtyForType0FromDB(theName)
                wbsd.OwnerBudgetAmount = newWBS.OwnerMatBudgetAmount
                'wbsd.BudgetQty = wbsd.BudgetQty - (newWBS.GetActualType0Qty(Me.SC, 6) - Me.SC.GetCurrentTypeQtyForWBS(newWBS, theName, 0))
              Case 19
                wbsd.BudgetAmount = newWBS.GetTotalMatFromDB
                wbsd.BudgetQty = 0        'ไม่มี budget ให้เครื่องมือแน่ๆ
                wbsd.OwnerBudgetAmount = newWBS.OwnerMatBudgetAmount
              Case 42
                wbsd.BudgetAmount = newWBS.GetTotalMatFromDB
                wbsd.BudgetQty = newWBS.GetTotalMatQtyFromDB(Me.Entity.Id)
                wbsd.OwnerBudgetAmount = newWBS.OwnerMatBudgetAmount
              Case 88
                wbsd.BudgetAmount = newWBS.GetTotalLabFromDB
                wbsd.BudgetQty = newWBS.GetTotalLabQtyFromDB(theName)
                wbsd.OwnerBudgetAmount = newWBS.OwnerLabBudgetAmount
              Case 89
                wbsd.BudgetAmount = newWBS.GetTotalEQFromDB
                wbsd.BudgetQty = newWBS.GetTotalEQQtyFromDB(theName)
                wbsd.OwnerBudgetAmount = newWBS.OwnerEqBudgetAmount
            End Select
            If wbsd.IsMarkup Then
              wbsd.BudgetRemain = newWBS.GetTotalMarkUpFromDB - newWBS.GetWBSActualFromDB(Me.Dr.Id, Me.Dr.EntityId, Me.ItemType.Value)
              wbsd.QtyRemain = 0
            Else
              wbsd.BudgetRemain = wbsd.BudgetAmount - newWBS.GetWBSActualFromDB(Me.Dr.Id, Me.Dr.EntityId, Me.ItemType.Value, wbsd.IsOutWard)
              If Me.ItemType.Value <> 88 And Me.ItemType.Value <> 89 Then
                wbsd.QtyRemain = wbsd.BudgetQty - newWBS.GetWBSQtyActualFromDB(Me.Dr.Id, Me.Dr.EntityId, Me.Entity.Id, _
                                                                          Me.ItemType.Value, theName) 'แปลงเป็นหน่วยตาม boq เรียบร้อย
              Else
                wbsd.QtyRemain = 0
              End If
            End If

            'Me.m_dr.SetActual(oldWBS, wbsd.TransferAmount, 0, Me.ItemType.Value)
            'Me.m_dr.SetActual(newWBS, 0, wbsd.TransferAmount, Me.ItemType.Value)
        End Select
      End If
    End Sub
  End Class

  <Serializable(), DefaultMember("Item")> _
  Public Class DRItemCollection
    Inherits CollectionBase

#Region "Members"
    Private m_dr As Dr
    Private m_currentItem As DRItem
#End Region

#Region "Constructors"
    Public Sub New(ByVal owner As Dr)
      Me.m_dr = owner
      If Not Me.m_dr.Originated Then
        Return
      End If

      Dim sqlConString As String = RecentCompanies.CurrentCompany.ConnectionString

      Dim ds As DataSet = SqlHelper.ExecuteDataset(sqlConString _
      , CommandType.StoredProcedure _
      , "GetDRItems" _
      , New SqlParameter("@dr_id", Me.m_dr.Id) _
      )

      For Each row As DataRow In ds.Tables(0).Rows
        Dim item As New DRItem(row, "")
        item.Dr = m_dr

        'RefreshBudget()
        Me.Add(item)
        'Dim wbsdToCCColl As WBSDistributeCollection = New WBSDistributeCollection
        Dim wbsdFromCCColl As WBSDistributeCollection = New WBSDistributeCollection
        'AddHandler wbsdToCCColl.PropertyChanged, AddressOf item.WBSChangedHandler
        AddHandler wbsdFromCCColl.PropertyChanged, AddressOf item.WBSChangedHandler
        'item.ToCCWBSDistributeCollection = wbsdToCCColl
        item.WBSDistributeCollection = wbsdFromCCColl
        If ds.Tables.Count > 1 Then
          'For Each wbsRow As DataRow In ds.Tables(1).Select("driw_sequence=" & item.Sequence)
          '  Dim wbsd As New WBSDistribute(wbsRow, "")
          '  wbsd.IsOutWard = False 'ฝั่งรับเข้า
          '  wbsdToCCColl.Add(wbsd)
          'Next
          For Each wbsRow As DataRow In ds.Tables(1).Select("driw_sequence=" & item.Sequence)
            Dim wbsd As New WBSDistribute(wbsRow, "")
            wbsd.IsOutWard = True 'ผั่งจ่ายออก
            wbsdFromCCColl.Add(wbsd)
          Next
        End If
      Next
    End Sub
    'Public Sub RefreshBudget()

    '    If Not Me.m_dr Is Nothing Then
    '        'Me.m_dr.RefreshTaxBase()
    '    End If
    '    For Each item As DRItem In Me
    '        'Dim bfTax As Decimal = 0
    '        'If Not item.Dr Is Nothing Then 'AndAlso item.Po.Originated
    '        '    If item.Dr.Closed Then
    '        '        bfTax = item.ReceivedBeforeTax
    '        '    Else
    '        '        bfTax = item.BeforeTax
    '        '    End If
    '        'End If
    '        Dim transferAmt As Decimal = item.Amount
    '        For Each wbsd As WBSDistribute In item.WBSDistributeCollection
    '            wbsd.BaseCost = transferAmt
    '            wbsd.TransferBaseCost = transferAmt
    '            If Not wbsd.IsMarkup Then
    '                Dim actual As Decimal = 0
    '                Dim budget As Decimal = 0
    '                Dim current As Decimal = 0
    '                Dim budgetQty As Decimal = 0
    '                Dim actualQty As Decimal = 0
    '                Dim currentQty As Decimal = 0

    '                Dim theName As String = item.EntityName
    '                If theName Is Nothing Then
    '                    theName = item.Entity.Name
    '                End If
    '                Select Case item.ItemType.Value
    '                    Case 0 'อื่นๆ
    '                        actual = wbsd.WBS.GetActualMat(item.Dr, 6)
    '                        budget = wbsd.WBS.GetTotalMatFromDB

    '                        budgetQty = wbsd.WBS.GetBudgetQtyForType0FromDB(theName)
    '                        actualQty = wbsd.WBS.GetActualType0Qty(item.Dr, 6)
    '                    Case 19 'Tool
    '                        actual = wbsd.WBS.GetActualMat(item.Dr, 6)
    '                        budget = wbsd.WBS.GetTotalMatFromDB

    '                        budgetQty = 0 'ไม่มี budget ให้เครื่องมือแน่ๆ
    '                        actualQty = wbsd.WBS.GetActualMatQty(item.Dr, 6, item.Entity.Id, 19)
    '                    Case 42 'Mat
    '                        actual = wbsd.WBS.GetActualMat(item.Dr, 6)
    '                        budget = wbsd.WBS.GetTotalMatFromDB

    '                        budgetQty = wbsd.WBS.GetTotalMatQtyFromDB(item.Entity.Id)
    '                        actualQty = wbsd.WBS.GetActualMatQty(item.Dr, 6, item.Entity.Id, 42)
    '                    Case 88 'Lab
    '                        actual = wbsd.WBS.GetActualLab(item.Dr, 6)
    '                        budget = wbsd.WBS.GetTotalLabFromDB

    '                        budgetQty = wbsd.WBS.GetTotalLabQtyFromDB(theName)
    '                        actualQty = wbsd.WBS.GetActualLabQty(item.Dr, 6)
    '                    Case 89 'Eq
    '                        actual = wbsd.WBS.GetActualEq(item.Dr, 6)
    '                        budget = wbsd.WBS.GetTotalEQFromDB

    '                        budgetQty = wbsd.WBS.GetTotalEQQtyFromDB(theName)
    '                        actualQty = wbsd.WBS.GetActualEqQty(item.Dr, 6)
    '                End Select

    '                'Dim theHash As Hashtable
    '                'Select Case item.ItemType.Value
    '                '    Case 0, 19, 42
    '                '        theHash = item.Dr.MatActualHash
    '                '    Case 88
    '                '        theHash = item.Dr.LabActualHash
    '                '    Case 89
    '                '        theHash = item.Dr.EQActualHash
    '                'End Select
    '                'If Not theHash Is Nothing Then
    '                '    Dim o_n As OldNew
    '                '    If Not theHash.Contains(wbsd.WBS.Id) Then
    '                '        o_n = New OldNew
    '                '        o_n.OldValue = actual
    '                '        o_n.NewValue = actual
    '                '        theHash(wbsd.WBS.Id) = o_n
    '                '    Else
    '                '        o_n = CType(theHash(wbsd.WBS.Id), OldNew)
    '                '        o_n.OldValue += actual
    '                '        o_n.NewValue += actual
    '                '    End If
    '                'End If
    '                'MessageBox.Show(String.Format("{0}:{1}:{2}", actual, budget, current))
    '                'Dim budgetRemain As Decimal = budget - actual
    '                'If budgetRemain < 0 Then
    '                '    wbsd.AmountOverBudget = True
    '                'Else
    '                '    wbsd.AmountOverBudget = False
    '                'End If
    '                'wbsd.BudgetAmount = budget
    '                'wbsd.BudgetRemain = budgetRemain

    '                'MessageBox.Show(String.Format("{0}:{1}:{2}", budgetQty, actualQty, currentQty))
    '                Dim qtyRemain As Decimal = budgetQty - actualQty
    '                If qtyRemain < 0 AndAlso Not wbsd.WBS.NoQtyControl Then
    '                    wbsd.QtyOverBudget = True
    '                Else
    '                    wbsd.QtyOverBudget = False
    '                End If
    '                wbsd.BudgetQty = budgetQty
    '                wbsd.QtyRemain = qtyRemain
    '            Else
    '                Dim mk As New Markup(wbsd.WBS.Id)
    '                If Not mk Is Nothing Then
    '                    wbsd.BudgetRemain = mk.StoredTotalAmount - mk.GetActualTotal(item.Dr, 6) - item.Dr.GetCurrentAmountForMarkup(mk)
    '                    'newRow("QtyRemain") = Configuration.FormatToString(wbsd.WBS.GetTotal, DigitConfig.Price)
    '                End If
    '            End If
    '        Next
    '    Next
    'End Sub
#End Region

#Region "Properties"
    Default Public Property Item(ByVal index As Integer) As DRItem
      Get
        Return CType(MyBase.List.Item(index), DRItem)
      End Get
      Set(ByVal value As DRItem)
        MyBase.List.Item(index) = value
      End Set
    End Property
    Public ReadOnly Property Amount() As Decimal
      Get
        Dim amt As Decimal = 0
        For Each item As DRItem In Me
          amt += Configuration.Format(item.Amount, DigitConfig.Price)
        Next
        Return amt
      End Get
    End Property

    Public Property CurrentItem() As DRItem
      Get
        Return m_currentItem
      End Get
      Set(ByVal Value As DRItem)
        m_currentItem = Value
      End Set
    End Property
    Public Property Dr() As Dr
      Get
        Return m_dr
      End Get
      Set(ByVal Value As Dr)
        m_dr = Value
      End Set
    End Property
#End Region

#Region "Shared"
    Public Shared Function CreateListTableStyle() As DataGridTableStyle
      Dim dst As New DataGridTableStyle
      dst.MappingName = "DRItems"

      Dim csSelected As New DataGridCheckBoxColumn
      csSelected.MappingName = "Selected"
      csSelected.HeaderText = ""

      Dim csDescription As New PlusMinusTreeTextColumn
      csDescription.MappingName = "Entity"
      csDescription.HeaderText = "Entity"
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
      csDate.MappingName = "DummyDate"
      csDate.HeaderText = "Date"
      csDate.NullText = ""
      csDate.DataAlignment = HorizontalAlignment.Center
      csDate.Width = 100
      csDate.Format = "d"
      csDate.ReadOnly = True

      Dim csReceivingDate As New TreeTextColumn
      csReceivingDate.MappingName = "DummyReceivingDate"
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
      'dst.GridColumnStyles.Add(csRequestor)
      'dst.GridColumnStyles.Add(csCostCenter)
      Return dst
    End Function
#End Region

#Region "Class Methods"
    Public Sub SetItems(ByVal items As BasketItemCollection, Optional ByVal targetType As Integer = -1)
      Dim arr As New ArrayList
      Dim currItem As DRItem = Nothing
      For i As Integer = 0 To items.Count - 1
        If Not TypeOf items(i) Is StockBasketItem Then
          '-----------------LCI Items--------------------
          Dim itemEntityLevel As Integer
          Dim item As BasketItem = CType(items(i), BasketItem)
          Dim newItem As IHasName
          Dim newType As Integer = -1
          Select Case item.FullClassName.ToLower
            Case "longkong.pojjaman.businesslogic.lciitem", "longkong.pojjaman.businesslogic.lciforlist"
              newItem = New LCIItem(item.Id)
              If targetType > -1 Then
                newType = targetType
              Else
                newType = 42
              End If
            Case "longkong.pojjaman.businesslogic.tool"
              newItem = New Tool(item.Id)
              newType = 19
              itemEntityLevel = 0 'CType(newItem, LCIItem).Level
          End Select

          Dim doc As New DRItem
          If Not Me.CurrentItem Is Nothing Then
            doc = Me.CurrentItem
            doc.ItemType.Value = newType
            Me.CurrentItem = Nothing
            currItem = doc
          Else
            'Me.Add(doc)
            Me.Insert(Me.IndexOf(currItem), doc)
            doc.ItemType = New DRIItemType(newType)
            currItem = doc
          End If
          doc.SetItemPrice(item.Code)
          doc.SetItemCode(newItem.Code)
        ElseIf TypeOf items(i).Tag Is BoqItem Then
          '-----------------BOQ Items--------------------
          Dim bitem As BoqItem = CType(items(i).Tag, BoqItem)
          If bitem.ItemType.Value = 18 Then   'ค่าแรง
            bitem.ItemType.Value = 88
            bitem.Entity.Id = 0
          End If
          If bitem.ItemType.Value = 20 Then   'ค่าเครื่องจักร
            bitem.ItemType.Value = 89
            bitem.Entity.Id = 0
          End If

          Dim matWbsd As New WBSDistribute
          Dim labWbsd As New WBSDistribute
          Dim eqWbsd As New WBSDistribute

          Dim matDoc As DRItem
          Dim labDoc As DRItem
          Dim eqDoc As DRItem
          Dim itemType As Integer
          itemType = bitem.ItemType.Value
          Select Case bitem.ItemType.Value
            Case 19, 42, 0
              Dim itemEntityLevel As Integer = 5
              If bitem.ItemType.Value = 42 Then
                If TypeOf bitem.Entity Is LCIItem Then
                  itemEntityLevel = CType(bitem.Entity, LCIItem).Level
                End If
              End If
              If itemEntityLevel = 5 Then
                If bitem.UMC <> 0 Then
                  matDoc = New DRItem
                  If Me.Count = 0 Then
                    Me.Add(matDoc)
                  Else
                    If Not Me.CurrentItem Is Nothing Then
                      matDoc = Me.CurrentItem
                    Else
                      Me.Add(matDoc)
                    End If
                  End If
                  'matDoc.ItemType = New itemType(bitem.ItemType.Value)
                  If bitem.ItemType.Value = 0 Then
                    matDoc.EntityName = bitem.EntityName
                  Else
                    matDoc.Entity = bitem.Entity
                  End If
                  matDoc.Unit = bitem.Unit
                  matDoc.Qty = bitem.Qty
                  matDoc.UnitPrice = bitem.UMC

                  If Not bitem.WBS Is Nothing Then
                    matWbsd.IsMarkup = False
                    matWbsd.CostCenter = Me.m_dr.ToCostCenter
                    matWbsd.WBS = bitem.WBS
                    matWbsd.Percent = 100
                    matWbsd.BaseCost = bitem.TotalMaterialCost
                    'matWbsd.TransferBaseCost = bitem.TotalMaterialCost
                    matWbsd.IsOutWard = False
                    matWbsd.Toaccttype = 3
                  End If
                End If
                If bitem.ULC <> 0 Then       '88
                  labDoc = New DRItem
                  If Me.Count = 0 Then
                    Me.Add(labDoc)
                  Else
                    If Not Me.CurrentItem Is Nothing Then
                      labDoc = Me.CurrentItem
                    Else
                      Me.Add(labDoc)
                    End If
                  End If
                  'labDoc.ItemType = New itemType(88)
                  If itemType = 42 Then
                    labDoc.Entity = bitem.Entity
                    labDoc.EntityName = bitem.Entity.Name
                  Else
                    labDoc.EntityName = bitem.Entity.Name
                  End If
                  labDoc.Unit = bitem.Unit
                  labDoc.Qty = bitem.Qty
                  labDoc.UnitPrice = bitem.ULC
                  If Not bitem.WBS Is Nothing Then
                    labWbsd.IsMarkup = False
                    labWbsd.CostCenter = Me.m_dr.ToCostCenter
                    labWbsd.WBS = bitem.WBS
                    labWbsd.Percent = 100
                    labWbsd.BaseCost = bitem.TotalLaborCost
                    ''labWbsd.TransferBaseCost = bitem.TotalLaborCost
                    labWbsd.IsOutWard = False
                    labWbsd.Toaccttype = 3
                  End If
                End If
                If bitem.UEC <> 0 Then       '89
                  eqDoc = New DRItem
                  If Me.Count = 0 Then
                    Me.Add(eqDoc)
                  Else
                    If Not Me.CurrentItem Is Nothing Then
                      eqDoc = Me.CurrentItem
                    Else
                      Me.Add(eqDoc)
                    End If
                  End If
                  'eqDoc.ItemType = New itemType(89)
                  If itemType = 42 Then
                    eqDoc.Entity = bitem.Entity
                    eqDoc.EntityName = bitem.Entity.Name
                  Else
                    eqDoc.EntityName = bitem.Entity.Name
                  End If
                  eqDoc.Unit = bitem.Unit
                  eqDoc.Qty = bitem.Qty
                  eqDoc.UnitPrice = bitem.UEC
                  If Not bitem.WBS Is Nothing Then
                    eqWbsd.IsMarkup = False
                    eqWbsd.CostCenter = Me.m_dr.ToCostCenter
                    eqWbsd.WBS = bitem.WBS
                    eqWbsd.Percent = 100
                    eqWbsd.BaseCost = bitem.TotalEquipmentCost
                    'eqWbsd.TransferBaseCost = bitem.TotalEquipmentCost
                    eqWbsd.IsOutWard = False
                    eqWbsd.Toaccttype = 3
                  End If
                End If
              End If
            Case 88, 89
              Dim doc As DRItem
              Dim tempUnitPrice As Decimal
              If Me.Count = 0 Then
                If bitem.ItemType.Value = 88 Then
                  labDoc = New DRItem
                  doc = labDoc
                  tempUnitPrice = bitem.ULC
                End If
                If bitem.ItemType.Value = 89 Then
                  eqDoc = New DRItem
                  doc = eqDoc
                  tempUnitPrice = bitem.UEC
                End If
                Me.Add(doc)
              Else
                If bitem.ItemType.Value = 88 Then
                  labDoc = New DRItem
                  If Not Me.CurrentItem Is Nothing Then
                    labDoc = Me.CurrentItem
                  Else
                    Me.Add(labDoc)
                  End If
                  doc = labDoc
                  tempUnitPrice = bitem.ULC
                End If
                If bitem.ItemType.Value = 89 Then
                  eqDoc = New DRItem
                  If Not Me.CurrentItem Is Nothing Then
                    eqDoc = Me.CurrentItem
                  Else
                    Me.Add(eqDoc)
                  End If
                  doc = eqDoc
                  tempUnitPrice = bitem.UEC
                End If
              End If
              'doc.ItemType = New itemType(bitem.ItemType.Value)
              doc.Entity = bitem.Entity
              doc.EntityName = bitem.Entity.Name
              doc.Unit = bitem.Unit
              doc.Qty = bitem.Qty
              doc.UnitPrice = tempUnitPrice
              If bitem.ItemType.Value = 88 Then
                If Not bitem.WBS Is Nothing Then
                  labWbsd.IsMarkup = False
                  labWbsd.CostCenter = Me.m_dr.ToCostCenter
                  labWbsd.WBS = bitem.WBS
                  labWbsd.Percent = 100
                  labWbsd.BaseCost = bitem.TotalLaborCost
                  'labWbsd.TransferBaseCost = bitem.TotalLaborCost
                  labWbsd.IsOutWard = False
                  labWbsd.Toaccttype = 3
                End If
              End If
              If bitem.ItemType.Value = 89 Then
                If Not bitem.WBS Is Nothing Then
                  eqWbsd.IsMarkup = False
                  eqWbsd.CostCenter = Me.m_dr.ToCostCenter
                  eqWbsd.WBS = bitem.WBS
                  eqWbsd.Percent = 100
                  eqWbsd.BaseCost = bitem.TotalEquipmentCost
                  'eqWbsd.TransferBaseCost = bitem.TotalEquipmentCost
                  eqWbsd.IsOutWard = False
                  eqWbsd.Toaccttype = 3
                End If
              End If
          End Select

          'If matWbsd.Percent = 100 Then
          '    If Not matDoc Is Nothing Then
          '        matDoc.WBSDistributeCollection.Add(matWbsd)
          '        arr.Add(matDoc)
          '    End If
          'End If
          'If labWbsd.Percent = 100 Then
          '    If Not labDoc Is Nothing Then
          '        labDoc.WBSDistributeCollection.Add(labWbsd)
          '        arr.Add(labDoc)
          '    End If
          'End If
          'If eqWbsd.Percent = 100 Then
          '    If Not eqDoc Is Nothing Then
          '        eqDoc.WBSDistributeCollection.Add(eqWbsd)
          '        arr.Add(eqDoc)
          '    End If
          'End If
        ElseIf TypeOf items(i).Tag Is DRItem Then
          ''-----------------PR Items--------------------
          'Dim dri As DRItem = CType(items(i).Tag, DRItem)
          ''Dim dri As New DRItem
          'dri.CopyFromdrItem(dri)
          'Me.Add(dri)
          'arr.Add(dri)
          'If Not dri.Pritem.Pr.ReceivingDate.Equals(Date.MinValue) AndAlso poi.Pritem.Pr.ReceivingDate < Me.m_po.ReceivingDate Then
          '    Me.m_dr.ReceivingDate = poi.Pritem.Pr.ReceivingDate
          'End If
        End If
      Next

      'Me.m_po.RefreshTaxBase()
      'For Each item As POItem In arr
      '    Dim bfTax As Decimal = 0
      '    If Not Me.m_po Is Nothing Then   'AndAlso item.Po.Originated
      '        If Me.m_po.Closed Then
      '            bfTax = item.ReceivedBeforeTax
      '        Else
      '            bfTax = item.BeforeTax
      '        End If
      '    End If
      '    For Each wbsd As WBSDistribute In item.WBSDistributeCollection
      '        Me.m_po.SetActual(wbsd.WBS, 0, bfTax * wbsd.Percent / 100, item.ItemType.Value)
      '        'Me.m_po.SetActual(wbsd.WBS, 0, wbsd.TransferAmount, item.ItemType.Value)
      '    Next

      'RefreshBudget()
    End Sub
    Public Sub Populate(ByVal dt As TreeTable)
      dt.Clear()
      Dim i As Integer = 0
      For Each dri As DRItem In Me
        i += 1
        Dim newRow As TreeRow = dt.Childs.Add()
        newRow.Tag = dri
        dri.CopyToDataRow(newRow)
        dri.ItemValidateRow(newRow)
      Next
    End Sub
    'Public Shared Function FindRow(ByVal dt As TreeTable, ByVal thePR As PR) As TreeRow
    '    Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
    '    Dim noPRText As String = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.POPanelView.BlankPRText}")
    '    For Each row As TreeRow In dt.Childs
    '        If thePR Is Nothing Then
    '            If row.Tag Is Nothing Then
    '                If Not row.IsNull("PRItemCode") AndAlso CStr(row("PRItemCode")) = noPRText Then
    '                    Return row
    '                End If
    '            End If
    '        End If
    '        If TypeOf row.Tag Is PR Then
    '            If CType(row.Tag, PR) Is thePR Then
    '                Return row
    '            End If
    '        End If
    '    Next

    '    '---->ไม่เจอ
    '    Dim newRow As TreeRow
    '    Dim desc As String = ""
    '    If thePR Is Nothing Then
    '        newRow = dt.Childs.Add
    '        desc = noPRText
    '    Else
    '        Dim noParentRow As TreeRow = FindRow(dt, Nothing)
    '        newRow = dt.Childs.InsertAt(dt.Childs.IndexOf(noParentRow))
    '        desc = thePR.Code
    '        newRow.Tag = thePR
    '    End If
    '    newRow("PRItemCode") = desc
    '    newRow("Button") = "invisible"
    '    newRow("UnitButton") = "invisible"
    '    newRow.State = RowExpandState.Expanded
    '    Return newRow
    'End Function
#End Region

#Region "Collection Methods"
    Public Function Add(ByVal value As DRItem) As Integer
      If Not m_dr Is Nothing Then
        value.Dr = m_dr
      End If
      Return MyBase.List.Add(value)
    End Function
    Public Sub AddRange(ByVal value As DRItemCollection)
      For i As Integer = 0 To value.Count - 1
        Me.Add(value(i))
      Next
    End Sub
    Public Sub AddRange(ByVal value As DRItem())
      For i As Integer = 0 To value.Length - 1
        Me.Add(value(i))
      Next
    End Sub
    Public Function Contains(ByVal value As DRItem) As Boolean
      Return MyBase.List.Contains(value)
    End Function
    Public Sub CopyTo(ByVal array As DRItem(), ByVal index As Integer)
      MyBase.List.CopyTo(array, index)
    End Sub
    Public Shadows Function GetEnumerator() As DRItemEnumerator
      Return New DRItemEnumerator(Me)
    End Function
    Public Function IndexOf(ByVal value As DRItem) As Integer
      Return MyBase.List.IndexOf(value)
    End Function
    Public Sub Insert(ByVal index As Integer, ByVal value As DRItem)
      If Not m_dr Is Nothing Then
        value.Dr = m_dr
      End If
      '    If Not value.Pritem Is Nothing Then
      '        If Not value.Pritem.Pr Is Nothing AndAlso value.Pritem.Pr.Originated Then
      '            If Not m_prHash.Contains(value.Pritem.Pr.Id) Then
      '                m_prHash(value.Pritem.Pr.Id) = New PR(value.Pritem.Pr.Id)
      '            End If
      '            value.Pritem.Pr = CType(m_prHash(value.Pritem.Pr.Id), PR)
      '        End If
      '    End If
      MyBase.List.Insert(index, value)
    End Sub
    Public Sub Remove(ByVal value As DRItem)
      'For Each wbsd As WBSDistribute In value.ToCCWBSDistributeCollection
      '  value.WBSChangedHandler(wbsd, New PropertyChangedEventArgs("WBS", New WBS, wbsd.WBS))
      'Next
      For Each wbsd As WBSDistribute In value.WBSDistributeCollection
        value.WBSChangedHandler(wbsd, New PropertyChangedEventArgs("WBS", New WBS, wbsd.WBS))
      Next
      MyBase.List.Remove(value)
    End Sub
    Public Sub Remove(ByVal index As Integer)
      'For Each wbsd As WBSDistribute In Me(index).ToCCWBSDistributeCollection
      '  Me(index).WBSChangedHandler(wbsd, New PropertyChangedEventArgs("WBS", New WBS, wbsd.WBS))
      'Next
      For Each wbsd As WBSDistribute In Me(index).WBSDistributeCollection
        Me(index).WBSChangedHandler(wbsd, New PropertyChangedEventArgs("WBS", New WBS, wbsd.WBS))
      Next
      MyBase.List.RemoveAt(index)
    End Sub
#End Region


    Public Class DRItemEnumerator
      Implements IEnumerator

#Region "Members"
      Private m_baseEnumerator As IEnumerator
      Private m_temp As IEnumerable
#End Region

#Region "Construtor"
      Public Sub New(ByVal mappings As DRItemCollection)
        Me.m_temp = mappings
        Me.m_baseEnumerator = Me.m_temp.GetEnumerator
      End Sub
#End Region

      Public ReadOnly Property Current() As Object Implements System.Collections.IEnumerator.Current
        Get
          Return CType(Me.m_baseEnumerator.Current, DRItem)
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
