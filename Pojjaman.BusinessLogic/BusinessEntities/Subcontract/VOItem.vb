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
  '    Public Class VOIItemType
  '        Inherits CodeDescription

  '#Region "Constructors"
  '        Public Sub New(ByVal value As Integer)
  '            MyBase.New(value)
  '        End Sub
  '#End Region

  '#Region "Properties"
  '        Public Overrides ReadOnly Property CodeName() As String
  '            Get
  '                Return "voi_entityType"
  '            End Get
  '        End Property
  '#End Region

  '    End Class
  Public Class VOItem
    Implements IWBSAllocatableItem

#Region "Members"
    Private m_vo As VO
    Private m_lineNumber As Integer
    Private m_scitem As scitem
    Private m_itemType As SCIItemType

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
    'Private m_receivedQty As Decimal
    Private m_unvatable As Boolean = False
    Private m_discount As New Discount("")
    Private m_conversion As Decimal = 1
    Private m_level As Integer
    Private m_sequence As Decimal
    Private m_refSequence As Decimal
    Private m_parent As Decimal
    Private m_isNotVoItem As Boolean
    Private m_unitCost As Decimal
    'Private m_receivedAmount As Decimal

    'Private m_sumChildMat As Decimal
    'Private m_sumChildLab As Decimal
    'Private m_sumChildEq As Decimal

    Private m_receivedAmount As Decimal
    Private m_receivedMat As Decimal
    Private m_receivedLab As Decimal
    Private m_receivedEq As Decimal
    Private m_receivedQty As Decimal

    Private m_oldQty As Decimal
    Private m_oldMat As Decimal
    Private m_oldLab As Decimal
    Private m_oldEq As Decimal
    Private m_oldAmount As Decimal

    Private m_isNotRefSc As Boolean

    Private m_WBSDistributeCollection As WBSDistributeCollection
#End Region

#Region "Constructors"
    Public Sub New()
      MyBase.New()
      m_WBSDistributeCollection = New WBSDistributeCollection
      AddHandler m_WBSDistributeCollection.PropertyChanged, AddressOf Me.WBSChangedHandler
    End Sub
    Public Sub New(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
      Me.Construct(ds, aliasPrefix)
    End Sub
    Public Sub New(ByVal dr As DataRow, ByVal aliasPrefix As String)
      Me.Construct(dr, aliasPrefix)
    End Sub
    Protected Sub Construct(ByVal dr As DataRow, ByVal aliasPrefix As String)
      With Me
        If dr.Table.Columns.Contains(aliasPrefix & "sci_id") AndAlso Not dr.IsNull("sci_id") Then
          Me.m_scitem = New scitem(dr, aliasPrefix)
          'Dim mySC As New SC

          'If dr.Table.Columns.Contains(aliasPrefix & "sci_sc") AndAlso Not dr.IsNull(aliasPrefix & "sci_sc") Then
          '  mySC.Id = CInt(dr(aliasPrefix & "sci_sc"))
          'End If
          'If dr.Table.Columns.Contains(aliasPrefix & "sc_code") AndAlso Not dr.IsNull(aliasPrefix & "sc_code") Then
          '  mySC.Code = CStr(dr(aliasPrefix & "sc_code"))
          'End If
          'Me.m_scitem.SC = mySC
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "voi_sequence") AndAlso Not dr.IsNull(aliasPrefix & "voi_sequence") Then
          .m_sequence = CDec(dr(aliasPrefix & "voi_sequence"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "voi_refsequence") AndAlso Not dr.IsNull(aliasPrefix & "voi_refsequence") Then
          .m_refSequence = CDec(dr(aliasPrefix & "voi_refsequence"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "voi_parent") AndAlso Not dr.IsNull(aliasPrefix & "voi_parent") Then
          .m_parent = CDec(dr(aliasPrefix & "voi_parent"))
        End If
        Dim itemId As Integer
        If dr.Table.Columns.Contains(aliasPrefix & "voi_entity") AndAlso Not dr.IsNull(aliasPrefix & "voi_entity") Then
          itemId = CInt(dr(aliasPrefix & "voi_entity"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "voi_entityType") AndAlso Not dr.IsNull(aliasPrefix & "voi_entityType") Then
          .m_itemType = New SCIItemType(CInt(dr(aliasPrefix & "voi_entityType")))
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

        If dr.Table.Columns.Contains(aliasPrefix & "voi_itemName") AndAlso Not dr.IsNull(aliasPrefix & "voi_itemName") Then
          .m_entityName = CStr(dr(aliasPrefix & "voi_itemName"))
        Else
          .m_entityName = ""
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "voi_lineNumber") AndAlso Not dr.IsNull(aliasPrefix & "voi_lineNumber") Then
          .m_lineNumber = CInt(dr(aliasPrefix & "voi_lineNumber"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "voi_originqty") AndAlso Not dr.IsNull(aliasPrefix & "voi_originqty") Then
          .m_originQty = CDec(dr(aliasPrefix & "voi_originqty"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "voi_originamt") AndAlso Not dr.IsNull(aliasPrefix & "voi_originamt") Then
          .m_originAmt = CDec(dr(aliasPrefix & "voi_originamt"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "voi_qty") AndAlso Not dr.IsNull(aliasPrefix & "voi_qty") Then
          .m_qty = CDec(dr(aliasPrefix & "voi_qty"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "voi_unitprice") AndAlso Not dr.IsNull(aliasPrefix & "voi_unitprice") Then
          .m_unitPrice = CDec(dr(aliasPrefix & "voi_unitprice"))
        End If
        'If dr.Table.Columns.Contains(aliasPrefix & "voi_receivedQty") AndAlso Not dr.IsNull(aliasPrefix & "voi_receivedQty") Then
        '  .m_receivedQty = CDec(dr(aliasPrefix & "voi_receivedQty"))
        'End If

        If dr.Table.Columns.Contains(aliasPrefix & "voi_mat") AndAlso Not dr.IsNull(aliasPrefix & "voi_mat") Then
          .m_mat = CDec(dr(aliasPrefix & "voi_mat"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "voi_lab") AndAlso Not dr.IsNull(aliasPrefix & "voi_lab") Then
          .m_lab = CDec(dr(aliasPrefix & "voi_lab"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "voi_eq") AndAlso Not dr.IsNull(aliasPrefix & "voi_eq") Then
          .m_eq = CDec(dr(aliasPrefix & "voi_eq"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "voi_amt") AndAlso Not dr.IsNull(aliasPrefix & "voi_amt") Then
          .m_amount = CDec(dr(aliasPrefix & "voi_amt"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "voi_unitCost") AndAlso Not dr.IsNull(aliasPrefix & "voi_unitCost") Then
          .m_unitCost = CDec(dr(aliasPrefix & "voi_unitCost"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "voi_level") AndAlso Not dr.IsNull(aliasPrefix & "voi_level") Then
          .m_level = CInt(dr(aliasPrefix & "voi_level"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "voi_note") AndAlso Not dr.IsNull(aliasPrefix & "voi_note") Then
          .m_note = CStr(dr(aliasPrefix & "voi_note"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "unit_id") AndAlso Not dr.IsNull(aliasPrefix & "unit_id") Then
          If Not dr.IsNull("unit_id") Then
            .m_unit = New Unit(dr, "")
          End If
        Else
          If dr.Table.Columns.Contains(aliasPrefix & "voi_unit") AndAlso Not dr.IsNull(aliasPrefix & "voi_unit") Then
            .m_unit = New Unit(CInt(dr(aliasPrefix & "voi_unit")))
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

        If dr.Table.Columns.Contains(aliasPrefix & "voio_qty") AndAlso Not dr.IsNull(aliasPrefix & "voio_qty") Then
          .m_oldQty = CDec(dr(aliasPrefix & "voio_qty"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "voio_mat") AndAlso Not dr.IsNull(aliasPrefix & "voio_mat") Then
          .m_oldMat = CDec(dr(aliasPrefix & "voio_mat"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "voio_lab") AndAlso Not dr.IsNull(aliasPrefix & "voio_lab") Then
          .m_oldLab = CDec(dr(aliasPrefix & "voio_lab"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "voio_eq") AndAlso Not dr.IsNull(aliasPrefix & "voio_eq") Then
          .m_oldEq = CDec(dr(aliasPrefix & "voio_eq"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "voio_amt") AndAlso Not dr.IsNull(aliasPrefix & "voio_amt") Then
          .m_oldAmount = CDec(dr(aliasPrefix & "voio_amt"))
        End If

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

        If dr.Table.Columns.Contains(aliasPrefix & "voi_discrate") AndAlso Not dr.IsNull(aliasPrefix & "voi_discrate") Then
          .m_discount = New Discount(CStr(dr(aliasPrefix & "voi_discrate")))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "voi_unvatable") AndAlso Not dr.IsNull(aliasPrefix & "voi_unvatable") Then
          .m_unvatable = CBool(dr(aliasPrefix & "voi_unvatable"))
        End If

      End With
    End Sub
    Protected Sub Construct(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
      Dim dr As DataRow = ds.Tables(0).Rows(0)
      Me.Construct(dr, aliasPrefix)
    End Sub
#End Region

#Region "Properties"
    Public Property VO() As VO      Get        Return m_vo      End Get      Set(ByVal Value As VO)        m_vo = Value      End Set    End Property    Public Property LineNumber() As Integer      Get        Return m_lineNumber      End Get      Set(ByVal Value As Integer)        m_lineNumber = Value      End Set    End Property    Public Property Sequence() As Decimal      Get
        Return m_sequence
      End Get
      Set(ByVal Value As Decimal)
        m_sequence = Value
      End Set
    End Property    Public Property RefSequence() As Decimal      Get
        Return m_refSequence
      End Get
      Set(ByVal Value As Decimal)
        m_refSequence = Value
      End Set
    End Property    Public Property scitem() As scitem      Get        Return m_scitem      End Get      Set(ByVal Value As scitem)        m_scitem = Value      End Set    End Property    Public Property ItemType() As SCIItemType      Get        Return m_itemType      End Get      Set(ByVal Value As SCIItemType)        Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
        If m_itemType Is Nothing Then
          m_itemType = Value
          Me.Clear()
          Return
        End If
        If Me.VO.ItemCollection.IndexOf(Me) = 0 AndAlso Value.Value <> 289 Then
          msgServ.ShowMessage("${res:Longkong.Pojjaman.Gui.Panels.SCItem.SCItemOnly}")
          Return
        End If
        If IsHasChild() Then
          msgServ.ShowMessage("${res:Longkong.Pojjaman.Gui.Panels.SCItem.SCItemOnly}")
          Return
        End If
        'If Not Value Is Nothing AndAlso Value.Value = m_itemType.Value Then
        '  'ผ่านโลด
        '  Return
        'End If
        'If msgServ.AskQuestion("${res:Global.Question.ChangePREntityType}") Then
        '  Dim oldType As Integer = m_itemType.Value
          m_itemType = Value
        'For Each wbsd As WBSDistribute In Me.WBSDistributeCollection
        '  Dim transferAmt As Decimal = Me.Amount
        '  wbsd.BaseCost = transferAmt
        '  wbsd.TransferBaseCost = transferAmt
        '  Select Case Me.ItemType.Value
        '    Case 0, 19, 42
        '      wbsd.BudgetAmount = wbsd.WBS.GetTotalMatFromDB
        '    Case 88
        '      wbsd.BudgetAmount = wbsd.WBS.GetTotalLabFromDB
        '    Case 89
        '      wbsd.BudgetAmount = wbsd.WBS.GetTotalEQFromDB
        '  End Select
        '  'Me.m_sc.SetActual(wbsd.WBS, wbsd.TransferAmount, 0, oldType)
        '  'Me.m_sc.SetActual(wbsd.WBS, 0, wbsd.TransferAmount, m_itemType.Value)
        'Next
          Me.Clear()
        'If Value.Value = 289 Then
        '  Me.Level = 0
        'Else
        '  Me.Level = 1
        'End If
        'End If      End Set    End Property    Public Property EntityName() As String      Get        Return m_entityName      End Get      Set(ByVal Value As String)        Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
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
          Case 289
            If Me.RefSequence <> 0 AndAlso Me.Level = 0 Then
              Return
            End If
            Me.m_entityName = Value 'รายการเปลี่ยนแปลงงานที่ไม่มีใน sc แต่มีใน vo
          Case Else     '0, 28, 88, 89, 160, 162
            Me.m_entityName = Value
        End Select      End Set    End Property    Public Property Unit() As Unit      Get        Return m_unit      End Get      Set(ByVal Value As Unit)        Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
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
        End If      End Set    End Property    Public Sub UpdateWBSQty()
      For Each wbsd As WBSDistribute In Me.WBSDistributeCollection
        'Dim bfTax As Decimal = 0
        'Dim oldVal As Decimal = wbsd.TransferAmount
        'Dim transferAmt As Decimal = Me.Amount
        'wbsd.BaseCost = bfTax
        'wbsd.TransferBaseCost = transferAmt
        Dim boqConversion As Decimal = wbsd.WBS.GetBoqItemConversion(Me.Entity.Id, Me.Unit.Id)
        If boqConversion = 0 Then
          wbsd.BaseQty = Me.Qty
        Else
          wbsd.BaseQty = Me.Qty * (Me.Conversion / boqConversion)
        End If

        'Me.WBSChangedHandler(wbsd, New PropertyChangedEventArgs("Percent", wbsd.TransferAmount, oldVal))
      Next
    End Sub    Public Property Qty() As Decimal      Get        Return m_qty      End Get      Set(ByVal Value As Decimal)        Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
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
        End Select        Dim amt As Decimal = Value * Me.UnitPrice
        Select Case Me.ItemType.Value
          Case 0, 19, 28, 42
            Me.m_mat = amt
            Me.m_lab = 0
            Me.m_eq = 0
          Case 88
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
        End Select        If IsNumeric(Value) Then          m_qty = Configuration.Format(Value, DigitConfig.Qty)
        Else
          m_qty = 0
        End If        'UpdateWBSQty()      End Set    End Property
    Public Property UnitPrice() As Decimal      Get        Return m_unitPrice      End Get      Set(ByVal Value As Decimal)        Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
        If Me.ItemType Is Nothing Then
          'ไม่มี Type
          msgServ.ShowMessage("${res:Global.Error.NoItemType}")
          Return
        End If
        Select Case Me.ItemType.Value
          Case 160, 162
            msgServ.ShowMessage("${res:Global.Error.NoteCannotHaveUnitPrice}")
            Return
        End Select        Dim amt As Decimal = Value * Me.Qty
        Select Case Me.ItemType.Value
          Case 0, 19, 28, 42
            Me.m_mat = amt
            Me.m_lab = 0
            Me.m_eq = 0
          Case 88
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
        End Select        m_unitPrice = Value      End Set    End Property    Public Property Mat() As Decimal
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
    'Public Property ReceivedAmount() As Decimal
    '  Get
    '    Return m_receivedAmount
    '  End Get
    '  Set(ByVal Value As Decimal)
    '    m_receivedAmount = Value
    '  End Set
    'End Property
    'Public Property SumChildMat() As Decimal
    '  Get
    '    Return m_sumChildMat
    '  End Get
    '  Set(ByVal Value As Decimal)
    '    m_sumChildMat = Value
    '  End Set
    'End Property
    'Public Property SumChildLab() As Decimal
    '  Get
    '    Return m_sumChildLab
    '  End Get
    '  Set(ByVal Value As Decimal)
    '    m_sumChildLab = Value
    '  End Set
    'End Property
    'Public Property SumChildEq() As Decimal
    '  Get
    '    Return m_sumChildEq
    '  End Get
    '  Set(ByVal Value As Decimal)
    '    m_sumChildEq = Value
    '  End Set
    'End Property
    Public ReadOnly Property StockQty() As Decimal      Get        Return Configuration.Format(Me.Conversion * Me.Qty, DigitConfig.Qty)      End Get    End Property
    Public ReadOnly Property Amount() As Decimal
      Get
        Return Configuration.Format((Me.UnitPrice * Me.Qty), DigitConfig.Price)
      End Get
    End Property    Public ReadOnly Property UnitCost() As Decimal
      Get
        If Me.StockQty <> 0 Then
          Dim tmpCost As Decimal = 0
          Dim tmpRealGrossNoVat As Decimal = 0

          tmpRealGrossNoVat = Me.VO.RealGross

          If tmpRealGrossNoVat = 0 Then
            Return 0
          End If

          tmpCost = Me.AmountWithDefaultUnit

          'tmpCost = tmpCost - ((tmpCost / tmpRealGrossNoVat) * Me.VO.Discount.Amount)

          If Me.VO.TaxType.Value = 2 Then
            If Not Me.UnVatable Then
              tmpCost = tmpCost * (100 / (100 + Me.VO.TaxRate))
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
    End Property    Public ReadOnly Property CostAmount() As Decimal Implements IWBSAllocatableItem.ItemAmount      Get
        Return Me.UnitCost * Me.StockQty
      End Get
    End Property    Public Property OldQty() As Decimal
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
    End Property    Public Property ReceivedAmount() As Decimal
      Get
        Return m_receivedAmount
      End Get
      Set(ByVal Value As Decimal)
        m_receivedAmount = Value
      End Set
    End Property
    'Public Property ReceivedQty() As Decimal
    '  Get
    '    Return m_receivedQty
    '  End Get
    '  Set(ByVal Value As Decimal)
    '    m_receivedQty = Value
    '  End Set
    'End Property

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
    End Property    Public ReadOnly Property AmountWithDefaultUnit() As Decimal
      Get
        If StockQty > 0 Then
          Return ((Me.UnitPrice / Me.Conversion) * StockQty) '- (Me.Discount.Amount / Me.Conversion)
        Else
          Return 0
        End If
      End Get
    End Property    Public Function ChildAmount() As Decimal
      Dim doc As VOItem = Me

      Dim m_childAmount As Decimal = 0
      Dim lastIndex As Integer = Me.VO.ItemCollection.IndexOf(doc)
      Dim startIndex As Integer = lastIndex

      For i As Integer = startIndex To Me.VO.ItemCollection.Count - 1
        If i > startIndex Then
          Dim voi As VOItem = Me.VO.ItemCollection(i)
          If voi.Level = 0 OrElse voi.ItemType.Value = 160 OrElse voi.ItemType.Value = 162 Then
            Exit For
          End If
          lastIndex = i
          m_childAmount += voi.Amount
        End If
      Next

      If startIndex = lastIndex Then
        Return Me.Amount
      End If

      Return m_childAmount
    End Function    Public Function GetChildAmount() As Decimal
      Dim doc As VOItem = Me

      Dim m_childAmount As Decimal = 0
      Dim lastIndex As Integer = Me.VO.ItemCollection.IndexOf(doc)
      Dim startIndex As Integer = lastIndex

      For i As Integer = startIndex To Me.VO.ItemCollection.Count - 1
        If i > startIndex Then
          Dim voi As VOItem = Me.VO.ItemCollection(i)
          If voi.Level = 0 Then
            Exit For
          End If
          lastIndex = i
          m_childAmount += voi.Amount
        End If
      Next

      'If startIndex = lastIndex Then
      '    Return Me.Amount
      'End If

      Return m_childAmount
    End Function    Public Property IsNotRefSC() As Boolean      Get
        Return m_isNotRefSc
      End Get
      Set(ByVal Value As Boolean)
        m_isNotRefSc = Value
      End Set
    End Property    Public Property Level() As Integer      Get
        Return m_level
      End Get
      Set(ByVal Value As Integer)
        m_level = Value
      End Set
    End Property    Public Property Entity() As IHasName      Get        Return m_entity      End Get      Set(ByVal Value As IHasName)        m_entity = Value        If TypeOf m_entity Is IHasUnit Then
          Me.m_unit = CType(m_entity, IHasUnit).DefaultUnit
        End If      End Set    End Property    Public Function DupCode(ByVal myCode As String) As Boolean      If Me.VO Is Nothing Then        Return False
      End If      If Me.ItemType Is Nothing Then
        Return False
      End If
      If Me.ItemType.Value = 42 Then
        'Material ใส่ Code เดียวกันได้
        Return False
      End If
      If myCode Is Nothing OrElse myCode.Length = 0 Then
        Return False
      End If
      For Each item As VOItem In Me.VO.ItemCollection
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
    End Function    Private Function GetAmountFromSproc(ByVal sproc As String, ByVal ParamArray filters() As SqlParameter) As Decimal
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
    End Function    Public Sub SetItemCode(ByVal theCode As String)      Dim unitPrice As Decimal = 0
      Dim pricing As Integer = CInt(Configuration.GetConfig("CompanyPOPricing"))      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
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
        Case 0, 289  ', 88, 89 'Blank
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
            '    Case 0
            '        unitPrice = myTool.FairPrice
            '    Case 1
            '        unitPrice = GetAmountFromSproc("GetPOPriceForSupplier" _
            '        , New SqlParameter("@vo_supcontractor", PO.ValidIdOrDBNull(VO.Supplier)) _
            '        , New SqlParameter("@voi_entity", myTool.Id) _
            '        , New SqlParameter("@voi_entitytype", myTool.EntityId) _
            '        )
            '    Case 2
            '        unitPrice = GetAmountFromSproc("GetPOPriceForSupplier" _
            '        , New SqlParameter("@po_supplier", DBNull.Value) _
            '        , New SqlParameter("@voi_entity", myTool.Id) _
            '        , New SqlParameter("@voi_entitytype", myTool.EntityId) _
            '        )
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
          Else
            'Select Case pricing
            '    Case 0
            '        unitPrice = lci.FairPrice
            '    Case 1
            '        unitPrice = GetAmountFromSproc("GetPOPriceForSupplier" _
            '        , New SqlParameter("@po_supplier", PO.ValidIdOrDBNull(PO.Supplier)) _
            '        , New SqlParameter("@voi_entity", lci.Id) _
            '        , New SqlParameter("@voi_entitytype", lci.EntityId) _
            '        )
            '    Case 2
            '        unitPrice = GetAmountFromSproc("GetPOPriceForSupplier" _
            '        , New SqlParameter("@po_supplier", DBNull.Value) _
            '        , New SqlParameter("@voi_entity", lci.Id) _
            '        , New SqlParameter("@voi_entitytype", lci.EntityId) _
            '        )
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
      Me.ReceivedQty = 0 'UNDONE
    End Sub    Public Function ChildMat() As Decimal
      Dim doc As VOItem = Me

      Dim m_childAmount As Decimal = 0
      Dim lastIndex As Integer = Me.VO.ItemCollection.IndexOf(doc)
      Dim startIndex As Integer = lastIndex

      For i As Integer = startIndex To Me.VO.ItemCollection.Count - 1
        'If Not Me.vo.ItemCollection(i).NewChild Then
        If i > startIndex Then
          Dim voi As VOItem = Me.VO.ItemCollection(i)
          If voi.Level = 0 OrElse voi.ItemType.Value = 160 OrElse voi.ItemType.Value = 162 Then
            Exit For
          End If
          lastIndex = i
          m_childAmount += voi.Mat
        End If
        'End If
      Next

      If startIndex = lastIndex Then
        Return Me.Mat
      End If

      Return m_childAmount
    End Function
    Public Function ChildLab() As Decimal
      Dim doc As VOItem = Me

      Dim m_childAmount As Decimal = 0
      Dim lastIndex As Integer = Me.VO.ItemCollection.IndexOf(doc)
      Dim startIndex As Integer = lastIndex

      For i As Integer = startIndex To Me.VO.ItemCollection.Count - 1
        'If Not Me.vo.ItemCollection(i).NewChild Then
        If i > startIndex Then
          Dim voi As VOItem = Me.VO.ItemCollection(i)
          If voi.Level = 0 OrElse voi.ItemType.Value = 160 OrElse voi.ItemType.Value = 162 Then
            Exit For
          End If
          lastIndex = i
          m_childAmount += voi.Lab
        End If
        'End If
      Next

      If startIndex = lastIndex Then
        Return Me.Lab
      End If

      Return m_childAmount
    End Function
    Public Function ChildEq() As Decimal
      Dim doc As VOItem = Me

      Dim m_childAmount As Decimal = 0
      Dim lastIndex As Integer = Me.VO.ItemCollection.IndexOf(doc)
      Dim startIndex As Integer = lastIndex

      For i As Integer = startIndex To Me.VO.ItemCollection.Count - 1
        'If Not Me.vo.ItemCollection(i).NewChild Then
        If i > startIndex Then
          Dim voi As VOItem = Me.VO.ItemCollection(i)
          If voi.Level = 0 OrElse voi.ItemType.Value = 160 OrElse voi.ItemType.Value = 162 Then
            Exit For
          End If
          lastIndex = i
          m_childAmount += voi.Eq
        End If
        'End If
      Next

      If startIndex = lastIndex Then
        Return Me.Eq
      End If

      Return m_childAmount
    End Function    Public Property OriginQty() As Decimal      Get
        Return m_originQty
      End Get
      Set(ByVal Value As Decimal)
        m_originQty = Value
      End Set
    End Property    Public Property OriginAmt() As Decimal      Get
        Return m_originAmt
      End Get
      Set(ByVal Value As Decimal)
        m_originAmt = Value
      End Set
    End Property    Public ReadOnly Property ItemDescription() As String      Get
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
    End Property    Public Property Note() As String      Get        Return m_note      End Get      Set(ByVal Value As String)        m_note = Value      End Set    End Property    Public Property ReceivedQty() As Decimal 'หน่วยตาม QTY ไม่ใช่ STOCKQTY      Get        Return m_receivedQty      End Get      Set(ByVal Value As Decimal)        m_receivedQty = Value      End Set    End Property    Public Property Conversion() As Decimal      Get        Return m_conversion      End Get      Set(ByVal Value As Decimal)        m_conversion = Value      End Set    End Property    Private Function CalcBeforeTax(ByVal amt As Decimal, ByVal tax As Decimal) As Decimal      If Me.VO Is Nothing Then
        Return 0
      End If      Dim myGross As Decimal = Me.VO.Gross
      Dim myDiscount As Decimal = Me.VO.DiscountAmount
      If myGross = 0 Then
        Return 0
      End If      Select Case Me.VO.TaxType.Value
        Case 0
          Return (amt - _
          ( _
          (amt / myGross) * myDiscount) _
          )
        Case 1
          Return (amt - _
          ( _
          (amt / myGross) * myDiscount) _
          )
        Case 2
          Return Me.CalcAfterTax(amt, tax) - tax
      End Select
    End Function    Private Function CalcAfterTax(ByVal amt As Decimal, ByVal tax As Decimal) As Decimal      If Me.VO Is Nothing Then
        Return 0
      End If      Dim myGross As Decimal = Me.VO.Gross
      Dim myDiscount As Decimal = Me.VO.DiscountAmount
      If myGross = 0 Then
        Return 0
      End If      Select Case Me.VO.TaxType.Value
        Case 0
          Return Me.CalcBeforeTax(amt, tax)
        Case 1
          Return Me.CalcBeforeTax(amt, tax) + tax
        Case 2
          Return (amt - _
          ( _
          (amt / myGross) * myDiscount) _
          )
      End Select
    End Function    Public Property UnVatable() As Boolean      Get        Return m_unvatable      End Get      Set(ByVal Value As Boolean)        m_unvatable = Value      End Set    End Property
    Public Property Parent() As Decimal      Get
        Return m_parent
      End Get
      Set(ByVal Value As Decimal)
        m_parent = Value
      End Set
    End Property
    Public Property IsNotVoItem() As Boolean
      Get
        Return m_isNotVoItem
      End Get
      Set(ByVal Value As Boolean)
        m_isNotVoItem = Value
      End Set
    End Property
#End Region

#Region "Methods"
    Public Sub ItemValidateRow(ByVal row As DataRow)
      Dim unit As Object = row("voi_unit")
      Dim code As Object = row("voi_code")
      Dim voi_itemName As Object = row("voi_itemName")
      Dim voi_qty As Object = row("voi_qty")
      Dim voi_unitprice As Object = row("voi_unitprice")
      Dim voi_entitytype As Object = row("voi_entitytype")

      'Dim isClosed As Boolean = False
      'isClosed = Me.VO.Closed

      Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
      Dim isBlankRow As Boolean = False
      If IsDBNull(voi_entitytype) Then
        isBlankRow = True
      End If

      If Not isBlankRow Then
        Select Case CInt(voi_entitytype)
          Case 160, 162 'Note
            row.SetColumnError("voi_qty", "")
            'row.SetColumnError("voi_unitprice", "")
            row.SetColumnError("voi_itemname", "")
            row.SetColumnError("voi_code", "")
          Case 0, 88, 89 'blank item /ค่าแรง/เครื่องจักร
            If IsDBNull(voi_itemName) OrElse voi_itemName.ToString.Length = 0 Then
              row.SetColumnError("voi_itemName", myStringParserService.Parse("${res:Global.Error.ItemNameMissing}"))
            Else
              row.SetColumnError("voi_itemName", "")
            End If
            If (Not IsNumeric(voi_qty) OrElse CDec(voi_qty) = 0) AndAlso Not Me.VO.Closing Then
              row.SetColumnError("voi_qty", myStringParserService.Parse("${res:Global.Error.ItemQtyMissing}"))
            Else
              row.SetColumnError("voi_qty", "")
            End If
            If Not IsNumeric(voi_unitprice) Then 'OrElse CDec(voi_unitprice) <= 0 Then
              row.SetColumnError("voi_unitprice", myStringParserService.Parse("${res:Global.Error.ItemUnitPriceMissing}"))
            Else
              row.SetColumnError("voi_unitprice", "")
            End If

            'row.SetColumnError("voi_unitprice", "")
            'row.SetColumnError("voi_code", "")
            'row.SetColumnError("voi_amount", "")
          Case 19 'เครื่องมือ
            If IsDBNull(code) OrElse code.ToString.Length = 0 Then
              row.SetColumnError("voi_code", myStringParserService.Parse("${res:Global.Error.ItemCodeMissing}"))
            Else
              row.SetColumnError("voi_code", "")
            End If
            If IsDBNull(voi_itemName) OrElse voi_itemName.ToString.Length = 0 Then
              row.SetColumnError("voi_itemName", myStringParserService.Parse("${res:Global.Error.ItemNameMissing}"))
            Else
              row.SetColumnError("voi_itemName", "")
            End If
            If (Not IsNumeric(voi_qty)) AndAlso Not Me.VO.Closing Then 'OrElse CDec(voi_qty) <= 0 Then
              row.SetColumnError("voi_qty", myStringParserService.Parse("${res:Global.Error.ItemQtyMissing}"))
            Else
              row.SetColumnError("voi_qty", "")
            End If
            If Not IsNumeric(voi_unitprice) Then 'OrElse CDec(voi_unitprice) <= 0 Then
              row.SetColumnError("voi_unitprice", myStringParserService.Parse("${res:Global.Error.ItemUnitPriceMissing}"))
            Else
              row.SetColumnError("voi_unitprice", "")
            End If
            'row.SetColumnError("voi_unitprice", "")
            'row.SetColumnError("voi_amount", "")
          Case 28 'F/A
            If IsDBNull(voi_itemName) OrElse voi_itemName.ToString.Length = 0 Then
              row.SetColumnError("voi_itemName", myStringParserService.Parse("${res:Global.Error.ItemNameMissing}"))
            Else
              row.SetColumnError("voi_itemName", "")
            End If
            If (Not IsNumeric(voi_qty)) AndAlso Not Me.VO.Closing Then 'OrElse CDec(voi_qty) <= 0 Then
              row.SetColumnError("voi_qty", myStringParserService.Parse("${res:Global.Error.ItemQtyMissing}"))
            Else
              row.SetColumnError("voi_qty", "")
            End If
            If Not IsNumeric(voi_unitprice) Then 'OrElse CDec(voi_unitprice) <= 0 Then
              row.SetColumnError("voi_unitprice", myStringParserService.Parse("${res:Global.Error.ItemUnitPriceMissing}"))
            Else
              row.SetColumnError("voi_unitprice", "")
            End If
            'row.SetColumnError("voi_unitprice", "")
            'row.SetColumnError("voi_code", "")
            'row.SetColumnError("voi_amount", "")
          Case 42 'LCI
            If IsDBNull(code) OrElse code.ToString.Length = 0 Then
              row.SetColumnError("voi_code", myStringParserService.Parse("${res:Global.Error.ItemCodeMissing}"))
            Else
              row.SetColumnError("voi_code", "")
            End If
            If IsDBNull(voi_itemName) OrElse voi_itemName.ToString.Length = 0 Then
              row.SetColumnError("voi_itemName", myStringParserService.Parse("${res:Global.Error.ItemNameMissing}"))
            Else
              row.SetColumnError("voi_itemName", "")
            End If
            If (Not IsNumeric(voi_qty) OrElse CDec(voi_qty) <= 0) AndAlso Not Me.VO.Closing Then
              row.SetColumnError("voi_qty", myStringParserService.Parse("${res:Global.Error.ItemQtyMissing}"))
            Else
              row.SetColumnError("voi_qty", "")
            End If
            If Not IsNumeric(voi_unitprice) Then ' OrElse CDec(voi_unitprice) <= 0 Then
              row.SetColumnError("voi_unitprice", myStringParserService.Parse("${res:Global.Error.ItemUnitPriceMissing}"))
            Else
              row.SetColumnError("voi_unitprice", "")
            End If
            'row.SetColumnError("voi_unitprice", "")
            'row.SetColumnError("voi_amount", "")
          Case Else
            Return
        End Select
      End If
    End Sub
    Public Sub CopyFromscitem(ByVal scitem As scitem)
      Me.m_scitem = scitem
      Me.RefSequence = scitem.Sequence
      Me.m_itemType = scitem.ItemType
      Me.m_entity = scitem.Entity
      Me.m_entityName = scitem.EntityName
      Me.m_unit = scitem.Unit
      Me.m_amount = scitem.Amount
      Me.m_qty = scitem.Qty
      Me.Level = 0
      'Me.m_mat = scitem.Mat
      'Me.m_lab = scitem.Lab
      'Me.m_eq = scitem.Eq
      Me.m_unitPrice = scitem.UnitPrice
      Me.m_note = scitem.Note
      Me.m_parent = scitem.Parent
    End Sub
    Public Sub Clear()
      Me.m_scitem = Nothing
      Me.m_entity = New BlankItem("")
      'Me.m_itemType = Nothing
      Me.m_entityName = ""
      Me.m_amount = 0
      Me.m_qty = 0
      Me.m_mat = 0
      Me.m_lab = 0
      Me.m_qty = 0
      Me.m_receivedQty = 0
      Me.m_unit = New Unit
      Me.m_unitPrice = 0
      Me.m_note = ""
      Me.m_discount = New Discount("")
      Me.m_unvatable = False
    End Sub
    Public Sub CopyToDataRow(ByVal row As TreeRow)
      If row Is Nothing Then
        Return
      End If
      Try
        Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)

        Me.VO.IsInitialized = False
        If Me.Level = 0 Then
          row.FixLevel = 1
        Else
          row.FixLevel = -1
        End If

        row("voi_linenumber") = Me.LineNumber
        row("voi_level") = Me.Level
        'row("voi_vodevo") = Me.voDevoription
        Dim m_Entity_Name As String = Space(5) & Trim(Me.Entity.Name)
        Dim m_EntityName As String = Space(5) & Trim(Me.EntityName)
        If Not Me.ItemType Is Nothing Then
          row("voi_entityType") = Me.ItemType.Value
          Select Case Me.ItemType.Value
            Case 19, 42
              If Not Me.Entity Is Nothing Then
                row("voi_entity") = Me.Entity.Id
                row("voi_itemName") = m_Entity_Name
                row("EntityName") = m_Entity_Name
                row("voi_code") = Me.Entity.Code
                If Not Me.EntityName Is Nothing AndAlso Me.EntityName.Length > 0 Then
                  If Me.Entity.Name <> Me.EntityName Then
                    row("voi_itemName") = EntityName & "<" & Me.Entity.Name & ">"
                  End If
                End If
              End If
              row("Button") = ""
            Case 88, 89
              If Not Me.Entity Is Nothing Then
                If TypeOf (Me.Entity) Is LCIItem Then
                  row("voi_entity") = Me.Entity.Id
                  row("voi_itemName") = m_Entity_Name
                  row("EntityName") = m_Entity_Name
                  row("voi_code") = Me.Entity.Code
                  If Not Me.EntityName Is Nothing AndAlso Me.EntityName.Length > 0 Then
                    If Me.Entity.Name <> Me.EntityName Then
                      row("voi_itemName") = m_EntityName & "<" & m_Entity_Name & ">"
                    End If
                  End If
                Else
                  row("Button") = "invisible"
                  row("voi_itemName") = m_EntityName
                End If
                row("Button") = ""
              End If
            Case 0, 28     ', 88, 89
              row("Button") = "invisible"
              row("voi_itemName") = m_EntityName
            Case 160, 162
              row("Button") = "invisible"
              row("UnitButton") = "invisible"
              row("voi_itemName") = m_EntityName
            Case 289
              row("Button") = "invisible"
              If Me.RefSequence = 0 And Me.Level = 0 Then
                If Trim(m_EntityName).Length > 0 Then
                  row("voi_itemName") = Trim(m_EntityName) '& "<" & myStringParserService.Parse("${res:Global.Error.ItemNotRefSC}") & ">"
                End If
              Else
                row("voi_itemName") = Trim(m_EntityName)
              End If
          End Select

        End If

        If Not Me.Unit Is Nothing Then
          row("voi_unit") = Me.Unit.Id
          row("voi_unitName") = Me.Unit.Name
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

        If Me.Qty <> 0 Then
          row("voi_qty") = Configuration.FormatToString(Me.Qty, DigitConfig.Qty)
        Else
          'If Me.Pr.Closed Then
          'row("voi_qty") = "0"
          'Else
          row("voi_qty") = ""
          'End If
        End If

        If Me.Qty <> 0 Then
          row("voi_qty") = Configuration.FormatToString(Me.Qty, DigitConfig.Qty)
        Else
          row("voi_qty") = ""
        End If

        If Me.Mat <> 0 Then
          row("voi_mat") = Configuration.FormatToString(Me.Mat, DigitConfig.Price)
        Else
          row("voi_mat") = ""
        End If
        If Me.Lab <> 0 Then
          row("voi_lab") = Configuration.FormatToString(Me.Lab, DigitConfig.Price)
        Else
          row("voi_lab") = ""
        End If
        If Me.Eq <> 0 Then
          row("voi_eq") = Configuration.FormatToString(Me.Eq, DigitConfig.Price)
        Else
          row("voi_eq") = ""
        End If

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

        row("voi_note") = Me.Note
        If Me.UnitPrice <> 0 Then
          row("voi_unitprice") = Configuration.FormatToString(Me.UnitPrice, DigitConfig.UnitPrice)
        Else
          row("voi_unitprice") = ""
        End If

        row("voi_unvatable") = Me.UnVatable

        Me.VO.IsInitialized = True
      Catch ex As NoConversionException
        MessageBox.Show("วัสดุ '" & ex.Lci.Code & "' ไม่มีหน่วยนับ '" & ex.Unit.Name & "'")
      Catch ex As Exception
        MessageBox.Show(ex.Message & "::" & ex.StackTrace)
      End Try
    End Sub
    Public Function IsHasChild() As Boolean
      Dim doc As VOItem = Me.VO.ItemCollection.CurrentItem
      If doc Is Nothing Then
        Return False
      End If
      If doc.Level = 1 Then
        Return False
      End If

      Dim lastIndex As Integer = Me.VO.ItemCollection.IndexOf(doc)
      Dim startIndex As Integer = lastIndex

      For i As Integer = startIndex To Me.VO.ItemCollection.Count - 1
        If i > startIndex Then
          If Me.VO.ItemCollection(i).Level = 0 Then
            Exit For
          End If
          lastIndex = i
        End If
      Next

      If startIndex < lastIndex Then
        Return True
      End If

      Return False

    End Function
    Public Sub SetUnitPrice(ByVal value As Decimal)
      m_unitPrice = value
    End Sub
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
    
    Public Sub WBSChangedHandler(ByVal sender As Object, ByVal e As PropertyChangedEventArgs)
      If TypeOf sender Is WBSDistribute Then
        Dim wbsd As WBSDistribute = CType(sender, WBSDistribute)
        Select Case e.Name.ToLower
          Case "percent"
            If Not Me.m_vo Is Nothing Then
              'Me.m_vo.SetActual(wbsd.WBS, CDec(e.OldValue), CDec(e.Value), Me.ItemType.Value)
            End If
          Case "wbs"
            'Dim oldWBS As WBS = CType(e.OldValue, WBS)
            Dim newWBS As WBS = CType(e.Value, WBS)
            Dim theName As String = Me.EntityName
            If theName Is Nothing Then
              theName = Me.Entity.Name
            End If
            Select Case Me.ItemType.Value
              Case 289
                wbsd.BudgetAmount = newWBS.GetTotalLabFromDB 'GetTotalMatFromDB
                wbsd.BudgetQty = newWBS.GetBudgetQtyForType0FromDB(theName)
              Case 0
                wbsd.BudgetAmount = newWBS.GetTotalMatFromDB
                wbsd.BudgetQty = newWBS.GetBudgetQtyForType0FromDB(theName)
                'wbsd.BudgetQty = wbsd.BudgetQty - (newWBS.GetActualType0Qty(Me.SC, 6) - Me.SC.GetCurrentTypeQtyForWBS(newWBS, theName, 0))
              Case 19
                wbsd.BudgetAmount = newWBS.GetTotalMatFromDB
                wbsd.BudgetQty = 0        'ไม่มี budget ให้เครื่องมือแน่ๆ
              Case 42
                wbsd.BudgetAmount = newWBS.GetTotalMatFromDB
                wbsd.BudgetQty = newWBS.GetTotalMatQtyFromDB(Me.Entity.Id)
              Case 88
                wbsd.BudgetAmount = newWBS.GetTotalLabFromDB
                wbsd.BudgetQty = newWBS.GetTotalLabQtyFromDB(theName)
              Case 89
                wbsd.BudgetAmount = newWBS.GetTotalEQFromDB
                wbsd.BudgetQty = newWBS.GetTotalEQQtyFromDB(theName)
            End Select
            wbsd.BudgetRemain = wbsd.BudgetAmount - newWBS.GetWBSActualFromDB(Me.VO.Id, Me.VO.EntityId, Me.ItemType.Value)
            wbsd.QtyRemain = wbsd.BudgetQty - newWBS.GetWBSQtyActualFromDB(Me.VO.Id, Me.VO.EntityId, Me.Entity.Id, _
                                                                           Me.ItemType.Value, theName) 'แปลงเป็นหน่วยตาม boq เรียบร้อย

            'UpdateWBSQty()

            'Me.m_vo.SetActual(oldWBS, wbsd.TransferAmount, 0, Me.ItemType.Value)
            'Me.m_vo.SetActual(newWBS, 0, wbsd.TransferAmount, Me.ItemType.Value)
        End Select
      End If
    End Sub

#Region "IWBSAllocatableItem"
    Public ReadOnly Property AllocationErrorMessage() As String Implements IWBSAllocatableItem.AllocationErrorMessage
      Get
        If Me.ItemType Is Nothing Then
          Return "No Item Type"
        End If
        Select Case Me.ItemType.Value
          Case 160, 162
            Return "${res:Global.Error.NoteCannotHaveWBS}"
          Case 289
            Return "${res:Global.Error.SCItemCannotHaveWBS}"
            'If Me.ChildAmount <> Me.Amount Then
            'Return "${res:Global.Error.CannotAllocate}"
            'End If
            'If Me.GetChildAmount > 0 Then
            'Return "${res:Global.Error.CannotAllocate}"
            'End If

        End Select
        Return ""
      End Get
    End Property

    Public ReadOnly Property Description() As String Implements IWBSAllocatableItem.Description
      Get
        Dim indent As String = ""
        If Me.ItemType.Value <> 289 Then
          indent = Space(5)
        End If
        If Me.Entity.Code.Length = 0 Then
          Return indent & Trim(Me.EntityName)
        End If
        Return indent & Me.Entity.Code & " : " & Trim(Me.Entity.Name)  '  Me.EntityName
      End Get
    End Property
    Public ReadOnly Property AllocationType As String Implements IWBSAllocatableItem.AllocationType
      Get
        Select Case Me.ItemType.Value
          Case 88, 289
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
        Dim indent As String = ""
        If Me.ItemType.Value <> 289 Then
          indent = Space(5)
        End If
        If Me.ItemType Is Nothing Then
          Return ""
        End If

        Return indent & ItemType.Description

      End Get
    End Property

    Public Property WBSDistributeCollection() As WBSDistributeCollection Implements IWBSAllocatableItem.WBSDistributeCollection
      Get
        Return m_WBSDistributeCollection
      End Get
      Set(ByVal Value As WBSDistributeCollection)
        m_WBSDistributeCollection = Value
      End Set
    End Property

    Public Property WBSDistributeCollection2() As WBSDistributeCollection Implements IWBSAllocatableItem.WBSDistributeCollection2
      Get

      End Get
      Set(ByVal Value As WBSDistributeCollection)

      End Set
    End Property
#End Region
  End Class

  <Serializable(), DefaultMember("Item")> _
Public Class VOItemCollection
    Inherits CollectionBase

#Region "Members"
    Private m_vo As VO
    'Private m_scHash As Hashtable
    Private m_currentItem As VOItem
    Private m_currentRealItem As VOItem
    Private m_parent As Hashtable
    Private m_child As Hashtable
#End Region

#Region "Constructors"
    Public Sub New(ByVal owner As VO)
      Me.m_vo = owner
      'm_scHash = New Hashtable
      If Not Me.m_vo.Originated Then
        Return
      End If

      Dim refSequence As Decimal = 0
      Dim sqlConString As String = RecentCompanies.CurrentCompany.ConnectionString

      Dim ds As DataSet = SqlHelper.ExecuteDataset(sqlConString _
      , CommandType.StoredProcedure _
      , "GetVOItems" _
      , New SqlParameter("@vo_id", Me.m_vo.Id) _
      )

      For Each row As DataRow In ds.Tables(0).Rows
        Dim item As New VOItem(row, "")

        If refSequence <> item.RefSequence Then
          refSequence = item.RefSequence
          If Not item.scitem Is Nothing Then
            Dim sci As SCItem = item.scitem
            Dim newItem As New VOItem
            newItem.CopyFromscitem(sci)
            newItem.VO = m_vo
            newItem.IsNotVoItem = True
            Me.Add(newItem)
          End If
        End If

        item.VO = m_vo
        item.IsNotVoItem = False
        Me.Add(item)
        Dim wbsdColl As WBSDistributeCollection = New WBSDistributeCollection
        AddHandler wbsdColl.PropertyChanged, AddressOf item.WBSChangedHandler
        item.WBSDistributeCollection = wbsdColl
        If ds.Tables.Count > 1 Then
          For Each wbsRow As DataRow In ds.Tables(1).Select("voiw_sequence=" & item.Sequence)
            Dim wbsd As New WBSDistribute(wbsRow, "")
            wbsdColl.Add(wbsd)
          Next
        End If
      Next
      'RefreshBudget()
      'RefreshAccumulateRemain()
    End Sub
    Public Sub RefreshBudget()
      '    If Not Me.m_vo Is Nothing Then
      '        Me.m_vo.RefreshTaxBase()
      '    End If
      '    For Each item As VOItem In Me
      '        Dim bfTax As Decimal = 0
      '        If Not item.Po Is Nothing Then 'AndAlso item.Po.Originated
      '            If item.Po.Closed Then
      '                bfTax = item.ReceivedBeforeTax
      '            Else
      '                bfTax = item.BeforeTax
      '            End If
      '        End If
      '        Dim transferAmt As Decimal = bfTax
      '        For Each wbsd As WBSDistribute In item.WBSDistributeCollection
      '            wbsd.BaseCost = bfTax
      '            wbsd.TransferBaseCost = transferAmt
      '            If Not wbsd.IsMarkup Then
      '                Dim actual As Decimal = 0
      '                Dim budget As Decimal = 0
      '                Dim budgetQty As Decimal = 0
      '                Dim actualQty As Decimal = 0

      '                Dim theName As String = item.EntityName
      '                If theName Is Nothing Then
      '                    theName = item.Entity.Name
      '                End If
      '                Select Case item.ItemType.Value
      '                    Case 0 'อื่นๆ
      '                        actual = wbsd.WBS.GetActualMat(item.Po, 6)
      '                        budget = wbsd.WBS.GetTotalMatFromDB

      '                        budgetQty = wbsd.WBS.GetBudgetQtyForType0FromDB(theName)
      '                        actualQty = wbsd.WBS.GetActualType0Qty(item.Po, 6)
      '                    Case 19 'Tool
      '                        actual = wbsd.WBS.GetActualMat(item.Po, 6)
      '                        budget = wbsd.WBS.GetTotalMatFromDB

      '                        budgetQty = 0 'ไม่มี budget ให้เครื่องมือแน่ๆ
      '                        actualQty = wbsd.WBS.GetActualMatQty(item.Po, 6, item.Entity.Id, 19)
      '                    Case 42 'Mat
      '                        actual = wbsd.WBS.GetActualMat(item.Po, 6)
      '                        budget = wbsd.WBS.GetTotalMatFromDB

      '                        budgetQty = wbsd.WBS.GetTotalMatQtyFromDB(item.Entity.Id)
      '                        actualQty = wbsd.WBS.GetActualMatQty(item.Po, 6, item.Entity.Id, 42)
      '                    Case 88 'Lab
      '                        actual = wbsd.WBS.GetActualLab(item.Po, 6)
      '                        budget = wbsd.WBS.GetTotalLabFromDB

      '                        budgetQty = wbsd.WBS.GetTotalLabQtyFromDB(theName)
      '                        actualQty = wbsd.WBS.GetActualLabQty(item.Po, 6)
      '                    Case 89 'Eq
      '                        actual = wbsd.WBS.GetActualEq(item.Po, 6)
      '                        budget = wbsd.WBS.GetTotalEQFromDB

      '                        budgetQty = wbsd.WBS.GetTotalEQQtyFromDB(theName)
      '                        actualQty = wbsd.WBS.GetActualEqQty(item.Po, 6)
      '                End Select

      '                Dim theHash As Hashtable
      '                Select Case item.ItemType.Value
      '                    Case 0, 19, 42
      '                        theHash = item.Po.MatActualHash
      '                    Case 88
      '                        theHash = item.Po.LabActualHash
      '                    Case 89
      '                        theHash = item.Po.EQActualHash
      '                End Select
      '                If Not theHash Is Nothing Then
      '                    'Dim o_n As OldNew
      '                    'If Not theHash.Contains(wbsd.WBS.Id) Then
      '                    '    o_n = New OldNew
      '                    '    o_n.OldValue = actual
      '                    '    o_n.NewValue = actual
      '                    '    theHash(wbsd.WBS.Id) = o_n
      '                    'Else
      '                    '    o_n = CType(theHash(wbsd.WBS.Id), OldNew)
      '                    '    o_n.OldValue += actual
      '                    '    o_n.NewValue += actual
      '                    'End If
      '                End If
      '                'MessageBox.Show(String.Format("{0}:{1}:{2}", actual, budget, current))
      '                Dim budgetRemain As Decimal = budget - actual
      '                If budgetRemain < 0 Then
      '                    wbsd.AmountOverBudget = True
      '                Else
      '                    wbsd.AmountOverBudget = False
      '                End If
      '                wbsd.BudgetAmount = budget
      '                wbsd.BudgetRemain = budgetRemain

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
      '                    wbsd.BudgetRemain = mk.StoredTotalAmount - mk.GetActualTotal(item.Po, 6) - item.Po.GetCurrentAmountForMarkup(mk)
      '                    'newRow("QtyRemain") = Configuration.FormatToString(wbsd.WBS.GetTotal, DigitConfig.scice)
      '                End If
      '            End If
      '        Next
      '    Next
    End Sub
#End Region

#Region "Properties"
    Public Property Parent() As Hashtable
      Get
        Return m_parent
      End Get
      Set(ByVal Value As Hashtable)
        m_parent = Value
      End Set
    End Property
    Public Property Child() As Hashtable
      Get
        Return m_child
      End Get
      Set(ByVal Value As Hashtable)
        m_child = Value
      End Set
    End Property
    Default Public Property Item(ByVal index As Integer) As VOItem
      Get
        Return CType(MyBase.List.Item(index), VOItem)
      End Get
      Set(ByVal value As VOItem)
        MyBase.List.Item(index) = value
      End Set
    End Property
    'Public ReadOnly Property Amount() As Decimal
    '    Get
    '        Dim amt As Decimal = 0    '        For Each item As VOItem In Me
    '            amt += Configuration.Format(item.Amount, DigitConfig.scice)
    '        Next
    '        Return amt
    '    End Get
    'End Property
    'Public ReadOnly Property SCHASH() As Hashtable
    '  Get
    '    Return m_scHash
    '  End Get
    'End Property
    Public Property CurrentItem() As VOItem
      Get
        Return m_currentItem
      End Get
      Set(ByVal Value As VOItem)
        m_currentItem = Value
      End Set
    End Property
    Public Property CurrentRealItem() As VOItem
      Get
        Return m_currentRealItem
      End Get
      Set(ByVal Value As VOItem)
        m_currentRealItem = Value
      End Set
    End Property
#End Region

#Region "Class Methods"
    Public Sub SetItems(ByVal items As BasketItemCollection, Optional ByVal targetType As Integer = -1)
      Dim arr As New ArrayList
      For i As Integer = 0 To items.Count - 1
        If Not TypeOf items(i) Is StockBasketItem Then
          '-----------------LCI Items--------------------
          Dim itemEntityLevel As Integer
          Dim item As BasketItem = CType(items(i), BasketItem)
          Dim newItem As IHasName
          Dim newType As Integer = -1
          Select Case item.FullClassName.ToLower
            Case "longkong.pojjaman.businesslogic.lciitem"
              newItem = New LCIItem(item.Id)
              If targetType > -1 Then
                newType = targetType
              Else
                newType = 42
              End If
              itemEntityLevel = CType(newItem, LCIItem).Level
            Case "longkong.pojjaman.businesslogic.tool"
              newItem = New Tool(item.Id)
              newType = 19
              itemEntityLevel = 5
          End Select
          If itemEntityLevel = 5 Then
            Dim doc As New VOItem
            If Not Me.CurrentItem Is Nothing Then
              doc = Me.CurrentItem
              doc.ItemType.Value = newType
              Me.CurrentItem = Nothing
            Else
              Me.Add(doc)
              'doc.ItemType = New itemType(newType)
            End If
            'doc.SetItemPrice(item.Code)
            'doc.Entity = newItem   'Lock LCI
            doc.SetItemCode(newItem.Code)
          End If
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

          Dim matDoc As VOItem
          Dim labDoc As VOItem
          Dim eqDoc As VOItem
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
                  matDoc = New VOItem
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
                  'If bitem.ItemType.Value = 0 Then
                  '    matDoc.EntityName = bitem.EntityName
                  'Else
                  '    matDoc.Entity = bitem.Entity
                  'End If
                  matDoc.Unit = bitem.Unit
                  matDoc.Qty = bitem.Qty
                  matDoc.UnitPrice = bitem.UMC

                  'If Not bitem.WBS Is Nothing Then
                  '    matWbsd.IsMarkup = False
                  '    matWbsd.CostCenter = Me.m_vo.CostCenter
                  '    matWbsd.WBS = bitem.WBS
                  '    matWbsd.Percent = 100
                  '    matWbsd.BaseCost = bitem.TotalMaterialCost
                  '    matWbsd.TransferBaseCost = bitem.TotalMaterialCost
                  '    matWbsd.IsOutWard = False
                  '    matWbsd.Toaccttype = 3
                  'End If
                End If
                If bitem.ULC <> 0 Then       '88
                  labDoc = New VOItem
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
                  'If itemType = 42 Then
                  '    labDoc.Entity = bitem.Entity
                  '    labDoc.EntityName = bitem.Entity.Name
                  'Else
                  '    labDoc.EntityName = bitem.Entity.Name
                  'End If
                  labDoc.Unit = bitem.Unit
                  labDoc.Qty = bitem.Qty
                  labDoc.UnitPrice = bitem.ULC
                  If Not bitem.WBS Is Nothing Then
                    labWbsd.IsMarkup = False
                    'labWbsd.CostCenter = Me.m_vo.CostCenter
                    labWbsd.WBS = bitem.WBS
                    labWbsd.Percent = 100
                    labWbsd.BaseCost = bitem.TotalLaborCost
                    labWbsd.TransferBaseCost = bitem.TotalLaborCost
                    labWbsd.IsOutWard = False
                    labWbsd.Toaccttype = 3
                  End If
                End If
                If bitem.UEC <> 0 Then       '89
                  eqDoc = New VOItem
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
                  'If itemType = 42 Then
                  '    eqDoc.Entity = bitem.Entity
                  '    eqDoc.EntityName = bitem.Entity.Name
                  'Else
                  '    eqDoc.EntityName = bitem.Entity.Name
                  'End If
                  eqDoc.Unit = bitem.Unit
                  eqDoc.Qty = bitem.Qty
                  eqDoc.UnitPrice = bitem.UEC
                  If Not bitem.WBS Is Nothing Then
                    eqWbsd.IsMarkup = False
                    'eqWbsd.CostCenter = Me.m_vo.CostCenter
                    eqWbsd.WBS = bitem.WBS
                    eqWbsd.Percent = 100
                    eqWbsd.BaseCost = bitem.TotalEquipmentCost
                    eqWbsd.TransferBaseCost = bitem.TotalEquipmentCost
                    eqWbsd.IsOutWard = False
                    eqWbsd.Toaccttype = 3
                  End If
                End If
              End If
            Case 88, 89
              Dim doc As VOItem
              Dim tempUnitPrice As Decimal
              If Me.Count = 0 Then
                If bitem.ItemType.Value = 88 Then
                  labDoc = New VOItem
                  doc = labDoc
                  tempUnitPrice = bitem.ULC
                End If
                If bitem.ItemType.Value = 89 Then
                  eqDoc = New VOItem
                  doc = eqDoc
                  tempUnitPrice = bitem.UEC
                End If
                Me.Add(doc)
              Else
                If bitem.ItemType.Value = 88 Then
                  labDoc = New VOItem
                  If Not Me.CurrentItem Is Nothing Then
                    labDoc = Me.CurrentItem
                  Else
                    Me.Add(labDoc)
                  End If
                  doc = labDoc
                  tempUnitPrice = bitem.ULC
                End If
                If bitem.ItemType.Value = 89 Then
                  eqDoc = New VOItem
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
              'doc.EntityName = bitem.Entity.Name
              doc.Unit = bitem.Unit
              doc.Qty = bitem.Qty
              doc.UnitPrice = tempUnitPrice
              'If bitem.ItemType.Value = 88 Then
              '    If Not bitem.WBS Is Nothing Then
              '        labWbsd.IsMarkup = False
              '        labWbsd.CostCenter = Me.m_vo.CostCenter
              '        labWbsd.WBS = bitem.WBS
              '        labWbsd.Percent = 100
              '        labWbsd.BaseCost = bitem.TotalLaborCost
              '        labWbsd.TransferBaseCost = bitem.TotalLaborCost
              '        labWbsd.IsOutWard = False
              '        labWbsd.Toaccttype = 3
              '    End If
              'End If
              'If bitem.ItemType.Value = 89 Then
              'If Not bitem.WBS Is Nothing Then
              '    eqWbsd.IsMarkup = False
              '    eqWbsd.CostCenter = Me.m_vo.CostCenter
              '    eqWbsd.WBS = bitem.WBS
              '    eqWbsd.Percent = 100
              '    eqWbsd.BaseCost = bitem.TotalEquipmentCost
              '    eqWbsd.TransferBaseCost = bitem.TotalEquipmentCost
              '    eqWbsd.IsOutWard = False
              '    eqWbsd.Toaccttype = 3
              'End If
              'End If
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
        ElseIf TypeOf items(i).Tag Is SCItem Then
          '-----------------PR Items--------------------
          Dim sci As SCItem = CType(items(i).Tag, SCItem)
          Dim voi As New VOItem
          voi.CopyFromscitem(sci)
          Me.Add(voi)
          arr.Add(voi)
          'If Not voi.scitem.SC.ReceivingDate.Equals(Date.MinValue) AndAlso voi.scitem.SC.ReceivingDate < Me.m_vo.ReceivingDate Then
          '    Me.m_vo.ReceivingDate = voi.scitem.SC.ReceivingDate
          'End If
        End If
      Next

      Me.m_vo.RefreshTaxBase()
      'For Each item As VOItem In arr
      '    Dim bfTax As Decimal = 0
      '    If Not Me.m_vo Is Nothing Then   'AndAlso item.Po.Originated
      '        If Me.m_vo.Closed Then
      '            bfTax = item.ReceivedBeforeTax
      '        Else
      '            bfTax = item.BeforeTax
      '        End If
      '    End If
      '    For Each wbsd As WBSDistribute In item.WBSDistributeCollection
      '        Me.m_vo.SetActual(wbsd.WBS, 0, bfTax * wbsd.Percent / 100, item.ItemType.Value)
      '        'Me.m_vo.SetActual(wbsd.WBS, 0, wbsd.TransferAmount, item.ItemType.Value)
      '    Next
      'Next
      'RefreshBudget()
    End Sub

    Public Sub Populate(ByVal dt As TreeTable)
      dt.Clear()
      Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
      'Dim i As Integer = 0
      'Dim j As Integer = 0

      'Dim key As String = ""
      'Dim parKey As String = ""

      Dim chkNoRefItem As Boolean = False
      Dim currItem As VOItem

      For Each voi As VOItem In Me
        'key = voi.Parent.ToString

        If voi.ItemType.Value = 289 Then
          Me(Me.IndexOf(voi)).Level = 0

        Else
          Me(Me.IndexOf(voi)).Level = 1

        End If

      Next

      currItem = Me.CurrentItem
      For Each voi As VOItem In Me
        Me.CurrentItem = voi

        Dim newRow As TreeRow
        If voi.Level = 0 AndAlso voi.RefSequence = 0 AndAlso Not chkNoRefItem Then
          chkNoRefItem = True
          newRow = dt.Childs.Add()
          newRow.FixLevel = 0
          newRow.CustomFontStyle = FontStyle.Bold
          newRow("Button") = "invisible"
          newRow("UnitButton") = "invisible"
          newRow("voi_itemName") = myStringParserService.Parse("${res:Global.Error.ItemNotRefSC}")

          '-- Summary MAT LAB EQ ลูก ๆ ไปให้รายการจัดจ้าง --
          If voi.Level = 0 AndAlso voi.IsHasChild Then
            voi.SetMat(voi.ChildMat)
            voi.SetLab(voi.ChildLab)
            voi.SetEq(voi.Childeq)
          End If
          '-- -- Summary MAT LAB EQ ----------------
        End If

        newRow = dt.Childs.Add()
        voi.CopyToDataRow(newRow)
        voi.ItemValidateRow(newRow)

        If chkNoRefItem Then
          voi.IsNotRefSC = True
        End If

        newRow.Tag = voi
      Next
      Me.CurrentItem = currItem
      dt.AcceptChanges()
    End Sub
    Public Shared Function FindRow(ByVal dt As TreeTable, ByVal theSC As SC) As TreeRow
      Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
      Dim noSCText As String = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.POPanelView.BlankPRText}")
      For Each row As TreeRow In dt.Childs
        If theSC Is Nothing Then
          If row.Tag Is Nothing Then
            If Not row.IsNull("scitemCode") AndAlso CStr(row("scitemCode")) = noSCText Then
              Return row
            End If
          End If
        End If
        If TypeOf row.Tag Is SC Then
          If CType(row.Tag, SC) Is theSC Then
            Return row
          End If
        End If
      Next

      '---->ไม่เจอ
      Dim newRow As TreeRow
      Dim desc As String = ""
      If theSC Is Nothing Then
        newRow = dt.Childs.Add
        desc = noSCText
      Else
        Dim noParentRow As TreeRow = FindRow(dt, Nothing)
        newRow = dt.Childs.InsertAt(dt.Childs.IndexOf(noParentRow))
        desc = theSC.Code
        newRow.Tag = theSC
      End If
      newRow("scitemCode") = desc
      newRow("Button") = "invisible"
      newRow("UnitButton") = "invisible"
      newRow.State = RowExpandState.Expanded
      Return newRow
    End Function
#End Region

#Region "Collection Methods"
    Public Function Add(ByVal value As VOItem) As Integer
      If Not m_vo Is Nothing Then
        value.VO = m_vo
      End If
      'If Not value.scitem Is Nothing Then
      '  If Not value.scitem.SC Is Nothing AndAlso value.scitem.SC.Originated Then
      '    If Not m_scHash.Contains(value.scitem.SC.Id) Then
      '      m_scHash(value.scitem.SC.Id) = New SC(value.scitem.SC.Id)
      '    End If
      '    value.scitem.SC = CType(m_scHash(value.scitem.SC.Id), SC)
      '  End If
      'End If
      Return MyBase.List.Add(value)
    End Function
    Public Sub AddRange(ByVal value As VOItemCollection)
      For i As Integer = 0 To value.Count - 1
        Me.Add(value(i))
      Next
    End Sub
    Public Sub AddRange(ByVal value As VOItem())
      For i As Integer = 0 To value.Length - 1
        Me.Add(value(i))
      Next
    End Sub
    Public Function Contains(ByVal value As VOItem) As Boolean
      Return MyBase.List.Contains(value)
    End Function
    Public Sub CopyTo(ByVal array As VOItem(), ByVal index As Integer)
      MyBase.List.CopyTo(array, index)
    End Sub
    Public Shadows Function GetEnumerator() As VOItemEnumerator
      Return New VOItemEnumerator(Me)
    End Function
    Public Function IndexOf(ByVal value As VOItem) As Integer
      Return MyBase.List.IndexOf(value)
    End Function
    Public Sub Insert(ByVal index As Integer, ByVal value As VOItem)
      If Not m_vo Is Nothing Then
        value.VO = m_vo
      End If
      'If Not value.scitem Is Nothing Then
      '  If Not value.scitem.SC Is Nothing AndAlso value.scitem.SC.Originated Then
      '    If Not m_scHash.Contains(value.scitem.SC.Id) Then
      '      m_scHash(value.scitem.SC.Id) = New SC(value.scitem.SC.Id)
      '    End If
      '    value.scitem.SC = CType(m_scHash(value.scitem.SC.Id), SC)
      '  End If
      'End If
      MyBase.List.Insert(index, value)
    End Sub
    Public Sub Remove(ByVal value As VOItem)
      For Each wbsd As WBSDistribute In value.WBSDistributeCollection
        value.WBSChangedHandler(wbsd, New PropertyChangedEventArgs("WBS", New WBS, wbsd.WBS))
      Next
      MyBase.List.Remove(value)
    End Sub
    Public Sub Remove(ByVal index As Integer)
      For Each wbsd As WBSDistribute In Me(index).WBSDistributeCollection
        Me(index).WBSChangedHandler(wbsd, New PropertyChangedEventArgs("WBS", New WBS, wbsd.WBS))
      Next
      MyBase.List.RemoveAt(index)
    End Sub
#End Region


    Public Class VOItemEnumerator
      Implements IEnumerator

#Region "Members"
      Private m_baseEnumerator As IEnumerator
      Private m_temp As IEnumerable
#End Region

#Region "Construtor"
      Public Sub New(ByVal mappings As VOItemCollection)
        Me.m_temp = mappings
        Me.m_baseEnumerator = Me.m_temp.GetEnumerator
      End Sub
#End Region

      Public ReadOnly Property Current() As Object Implements System.Collections.IEnumerator.Current
        Get
          Return CType(Me.m_baseEnumerator.Current, VOItem)
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
