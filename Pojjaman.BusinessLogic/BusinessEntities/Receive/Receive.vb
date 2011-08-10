Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.TextHelper
Imports System.Reflection
Imports Longkong.Pojjaman.Services
Imports System.Collections.Generic

Namespace Longkong.Pojjaman.BusinessLogic
  Public Class ReceiveStatus
    Inherits CodeDescription

#Region "Constructors"
    Public Sub New(ByVal value As Integer)
      MyBase.New(value)
    End Sub
#End Region

#Region "Properties"
    Public Overrides ReadOnly Property CodeName() As String
      Get
        Return "receive_status"
      End Get
    End Property
#End Region

  End Class
  Public Class Receive
    Inherits SimpleBusinessEntityBase
    Implements IPrintableEntity, IHasToCostCenter, IHasFromCostCenter, IHasMainDoc

#Region "Members"
    Private receive_docDate As Date
    Private receive_note As String

    Private receive_status As ReceiveStatus

    Private receive_refDoc As IReceivable

    Private receive_discountAmount As Decimal 'ส่วนลดรับ
    Private receive_otherRevenue As Decimal 'รายได้อื่นๆ
    Private receive_interest As Decimal 'ดอกเบี้ยจ่าย
    Private receive_bankcharge As Decimal 'ค่าธรรมเนียมธนาคาร
    Private receive_otherExpense As Decimal 'ค่าใช้จ่ายอื่นๆ
    Private receive_ccId As Integer

    Private m_itemTable As TreeTable

    Private m_debitCollection As ReceiveAccountItemCollection
    Private m_creditCollection As ReceiveAccountItemCollection

    'Private m_itemSavedCheckHash As Hashtable
    Private m_oldReceiveItemList As List(Of ReceiveItem)
#End Region

#Region "Constructors"
    Public Sub UnWire()
      RemoveHandler m_itemTable.ColumnChanging, AddressOf Treetable_ColumnChanging
      RemoveHandler m_itemTable.ColumnChanged, AddressOf Treetable_ColumnChanged
      RemoveHandler m_itemTable.RowDeleted, AddressOf ItemDelete
    End Sub
    Public Sub Wire()
      'WrapperArrayList.AddItemAddedHandler(m_itemTable, AddressOf ItemAdded)
      AddHandler m_itemTable.ColumnChanging, AddressOf Treetable_ColumnChanging
      AddHandler m_itemTable.ColumnChanged, AddressOf Treetable_ColumnChanged
      AddHandler m_itemTable.RowDeleted, AddressOf ItemDelete
    End Sub
    Public Sub New()
      MyBase.New()
      ReLoadItems()
      m_debitCollection = New ReceiveAccountItemCollection(Me, True)
      m_creditCollection = New ReceiveAccountItemCollection(Me, False)
      Wire()
    End Sub
    Public Sub New(ByVal code As String)
      MyBase.New(code)
      ReLoadItems()
      m_debitCollection = New ReceiveAccountItemCollection(Me, True)
      m_creditCollection = New ReceiveAccountItemCollection(Me, False)
      Wire()
    End Sub
    Public Sub New(ByVal id As Integer)
      MyBase.New(id)
      ReLoadItems()
      m_debitCollection = New ReceiveAccountItemCollection(Me, True)
      m_creditCollection = New ReceiveAccountItemCollection(Me, False)
      Wire()
    End Sub
    Public Sub New(ByVal refDoc As IReceivable)
      Me.New(refDoc.Id, CType(refDoc, IObjectReflectable).EntityId)
      m_debitCollection = New ReceiveAccountItemCollection(Me, True)
      m_creditCollection = New ReceiveAccountItemCollection(Me, False)
      Me.RefDoc = refDoc
    End Sub
    Private Sub New(ByVal refId As Integer, ByVal refType As Integer)
      If refId = 0 Then
        m_itemTable = GetSchemaTable()
        m_debitCollection = New ReceiveAccountItemCollection(Me, True)
        m_creditCollection = New ReceiveAccountItemCollection(Me, False)
        Wire()
        Return
      End If
      Dim ds As DataSet = SqlHelper.ExecuteDataset(Me.ConnectionString _
      , CommandType.StoredProcedure _
      , "GetReceive" _
      , New SqlParameter("@receive_refDoc", refId), New SqlParameter("@receive_refDocType", refType))
      If ds.Tables.Count > 0 AndAlso ds.Tables(0).Rows.Count = 1 Then
        Construct(ds.Tables(0).Rows(0), "")
      End If
      ReLoadItems()
      m_debitCollection = New ReceiveAccountItemCollection(Me, True)
      m_creditCollection = New ReceiveAccountItemCollection(Me, False)
      Wire()
    End Sub
    Public Sub New(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
      Me.Construct(ds, aliasPrefix)
      ReLoadItems(ds, aliasPrefix)
      m_debitCollection = New ReceiveAccountItemCollection(Me, True)
      m_creditCollection = New ReceiveAccountItemCollection(Me, False)
      Wire()
    End Sub
    Public Sub New(ByVal dr As System.Data.DataRow, ByVal aliasPrefix As String)
      Me.Construct(dr, aliasPrefix)
      ReLoadItems()
      m_debitCollection = New ReceiveAccountItemCollection(Me, True)
      m_creditCollection = New ReceiveAccountItemCollection(Me, False)
      Wire()
    End Sub
    Protected Overloads Overrides Sub Construct()
      MyBase.Construct()
      With Me
        .receive_refDoc = New GenericReceivable
        .receive_refDoc.Id = 0
        .receive_refDoc.Date = Date.MinValue
        .receive_refDoc.Code = ""
        .receive_status = New ReceiveStatus(-1)
        Me.LoadOldReceievItem()
      End With
    End Sub
    Protected Overloads Overrides Sub Construct(ByVal dr As System.Data.DataRow, ByVal aliasPrefix As String)
      MyBase.Construct(dr, aliasPrefix)
      With Me
        Try
          If Not dr.IsNull(aliasPrefix & "receive_docDate") Then
            .receive_docDate = CDate(dr(aliasPrefix & "receive_docDate"))
          End If

          If Not dr.IsNull(aliasPrefix & "receive_note") Then
            .receive_note = CStr(dr(aliasPrefix & "receive_note"))
          End If

          Dim refDocType As Integer
          Dim refDocId As Integer
          Dim refDocCode As String
          Dim refDocDate As Date
          If dr.Table.Columns.Contains(aliasPrefix & "receive_refDocType") AndAlso Not dr.IsNull(aliasPrefix & "receive_refDocType") Then
            refDocType = CInt(dr(aliasPrefix & "receive_refDocType"))
          End If
          If dr.Table.Columns.Contains(aliasPrefix & "receive_refid") AndAlso Not dr.IsNull(aliasPrefix & "receive_refid") Then
            refDocId = CInt(dr(aliasPrefix & "receive_refid"))
          End If
          If dr.Table.Columns.Contains(aliasPrefix & "receive_refcode") AndAlso Not dr.IsNull(aliasPrefix & "receive_refcode") Then
            refDocCode = CStr(dr(aliasPrefix & "receive_refcode"))
          End If
          If dr.Table.Columns.Contains(aliasPrefix & "receive_refdate") AndAlso Not dr.IsNull(aliasPrefix & "receive_refdate") Then
            refDocDate = CDate(dr(aliasPrefix & "receive_refdate"))
          End If

          'Hack: harcoded
          If refDocType = 0 Then
            .receive_refDoc = New GenericReceivable
            .receive_refDoc.Id = refDocId
            .receive_refDoc.Code = refDocCode
            .receive_refDoc.Date = refDocDate
          Else
            .receive_refDoc = CType(SimpleBusinessEntityBase.GetEntity(Longkong.Pojjaman.BusinessLogic.Entity.GetFullClassName(refDocType), refDocId), IReceivable)
          End If

          If dr.Table.Columns.Contains(aliasPrefix & "receive_status") AndAlso Not dr.IsNull(aliasPrefix & "receive_status") Then
            .receive_status = New ReceiveStatus(CInt(dr(aliasPrefix & "receive_status")))
          End If

          If Not dr.IsNull(aliasPrefix & "receive_discount") Then
            .receive_discountAmount = CDec(dr(aliasPrefix & "receive_discount"))
          End If
          If Not dr.IsNull(aliasPrefix & "receive_otherRevenue") Then
            .receive_otherRevenue = CDec(dr(aliasPrefix & "receive_otherRevenue"))
          End If
          If Not dr.IsNull(aliasPrefix & "receive_interest") Then
            .receive_interest = CDec(dr(aliasPrefix & "receive_interest"))
          End If
          If Not dr.IsNull(aliasPrefix & "receive_bankcharge") Then
            .receive_bankcharge = CDec(dr(aliasPrefix & "receive_bankcharge"))
          End If
          If Not dr.IsNull(aliasPrefix & "receive_otherExpense") Then
            .receive_otherExpense = CDec(dr(aliasPrefix & "receive_otherExpense"))
          End If
          If dr.Table.Columns.Contains(aliasPrefix & "receive_cc") AndAlso Not dr.IsNull(aliasPrefix & "receive_cc") Then
            .receive_ccId = CInt(dr(aliasPrefix & "receive_cc"))
          End If

          IsRefenceByCheckDeposit = Me.GetCheckDepositRef
        Catch ex As Exception
        End Try
      End With
    End Sub
    Protected Overloads Overrides Sub Construct(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
      Dim dr As DataRow = ds.Tables(0).Rows(0)
      Construct(dr, aliasPrefix)
    End Sub
#End Region

#Region "Properties"
    ' ''' <summary>
    ' ''' !!! ItemSavedCheckHash : จะเกิด Collection ของ Check หลังจาก Save แล้วเท่านั้น
    ' ''' </summary>
    ' ''' <value></value>
    ' ''' <returns></returns>
    ' ''' <remarks></remarks>
    'Public ReadOnly Property ItemSavedCheckHash As Hashtable
    '  Get
    '    If m_itemSavedCheckHash Is Nothing Then
    '      m_itemSavedCheckHash = New Hashtable
    '    End If
    '    Return m_itemSavedCheckHash
    '  End Get
    'End Property
    Public Property IsRefenceByCheckDeposit As Boolean
    Public ReadOnly Property Maindoc() As ISimpleEntity Implements IHasMainDoc.MainDoc
      Get
        Return CType(receive_refDoc, ISimpleEntity)
      End Get
    End Property

    Public Property CcId() As Integer      Get        Return receive_ccId      End Get      Set(ByVal Value As Integer)        receive_ccId = Value      End Set    End Property
    Public ReadOnly Property CostCenter() As CostCenter
      Get
        Return New CostCenter(receive_ccId)
      End Get
    End Property
    Public Property ItemTable() As TreeTable      Get        Return m_itemTable      End Get      Set(ByVal Value As TreeTable)        m_itemTable = Value      End Set    End Property
    Public Property DebitCollection() As ReceiveAccountItemCollection
      Get        Return m_debitCollection
      End Get      Set(ByVal Value As ReceiveAccountItemCollection)
        m_debitCollection = Value
      End Set    End Property
    Public Property CreditCollection() As ReceiveAccountItemCollection
      Get        Return m_creditCollection
      End Get      Set(ByVal Value As ReceiveAccountItemCollection)
        m_creditCollection = Value
      End Set    End Property
    Public ReadOnly Property DebitAmount() As Decimal
      Get
        Return Me.DebitCollection.GetAmount
      End Get
    End Property
    Public ReadOnly Property CreditAmount() As Decimal
      Get
        Return Me.CreditCollection.GetAmount
      End Get
    End Property
    Private m_gross As Decimal
    Public ReadOnly Property Gross() As Decimal
      Get
        Return m_gross
      End Get
    End Property
    Public Sub UpdateGross()
      If Me.ItemTable Is Nothing OrElse Me.ItemTable.Rows.Count = 0 Then        m_gross = 0
      Else
        Dim amt As Decimal = 0        For Each row As TreeRow In Me.ItemTable.Rows
          If Not row.IsNull("receivei_amt") AndAlso IsNumeric(row("receivei_amt")) Then
            amt += CDec(row("receivei_amt"))
          End If
        Next        m_gross = amt
      End If
    End Sub
    Public ReadOnly Property SumCreditAmount() As Decimal
      Get
        Return CreditAmount + Me.OtherExpense + Me.DiscountAmount + Me.BankCharge + Me.WitholdingTax
      End Get
    End Property
    Public ReadOnly Property SumDebitAmount() As Decimal
      Get
        Return DebitAmount + Me.OtherRevenue + Me.Interest
      End Get
    End Property
    Public ReadOnly Property Amount() As Decimal
      Get
        Return Me.RefDoc.AmountToReceive - Me.SumCreditAmount + Me.SumDebitAmount
      End Get
    End Property
    Public Property DocDate() As Date      Get        Return receive_docDate      End Get      Set(ByVal Value As Date)        receive_docDate = Value      End Set    End Property    Public Property Note() As String      Get        Return receive_note      End Get      Set(ByVal Value As String)        receive_note = Value      End Set    End Property    Public Property DiscountAmount() As Decimal      Get        Return receive_discountAmount      End Get      Set(ByVal Value As Decimal)        receive_discountAmount = Value      End Set    End Property    Public Property OtherRevenue() As Decimal      Get        Return receive_otherRevenue      End Get      Set(ByVal Value As Decimal)        receive_otherRevenue = Value      End Set    End Property    Public ReadOnly Property WitholdingTax() As Decimal      Get        If Me.RefDoc Is Nothing Then          Return 0
        End If        If Not TypeOf Me.RefDoc Is IWitholdingTaxable Then
          Return 0
        End If        Return CType(Me.RefDoc, IWitholdingTaxable).WitholdingTaxCollection.Amount      End Get    End Property    Public Property Interest() As Decimal      Get        Return receive_interest      End Get      Set(ByVal Value As Decimal)        receive_interest = Value      End Set    End Property    Public Property BankCharge() As Decimal      Get        Return receive_bankcharge      End Get      Set(ByVal Value As Decimal)        receive_bankcharge = Value      End Set    End Property    Public Property OtherExpense() As Decimal      Get        Return receive_otherExpense      End Get      Set(ByVal Value As Decimal)        receive_otherExpense = Value      End Set    End Property    Public Overrides Property Status() As CodeDescription      Get        Return receive_status      End Get      Set(ByVal Value As CodeDescription)        receive_status = CType(Value, ReceiveStatus)      End Set    End Property    Public Property RefDoc() As IReceivable      Get        Return receive_refDoc      End Get      Set(ByVal Value As IReceivable)        receive_refDoc = Value      End Set    End Property
    Public Overrides ReadOnly Property ClassName() As String
      Get
        Return "Receive"
      End Get
    End Property
    Public Overrides ReadOnly Property TableName() As String
      Get
        Return "Receive"
      End Get
    End Property
    Public Overrides ReadOnly Property Prefix() As String
      Get
        Return "receive"
      End Get
    End Property

    Public Overrides ReadOnly Property DetailPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.Receive.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.Receive"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.Receive"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.Receive.ListLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property TabPageText() As String
      Get
        Dim tpt As String = Me.StringParserService.Parse(Me.DetailPanelTitle) & " (" & Me.Code & ")"
        Dim blankSuffix As String = "()"
        If tpt.EndsWith(blankSuffix) Then
          tpt = tpt.Remove(tpt.Length - blankSuffix.Length, blankSuffix.Length)
        End If
        Return tpt
      End Get
    End Property
#End Region

#Region "Shared"
    Public Shared Function GetSchemaTable() As TreeTable
      Dim myDatatable As New TreeTable("Receive")
      myDatatable.Columns.Add(New DataColumn("receivei_linenumber", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("receivei_entity", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("receivei_entityType", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("Code", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Button", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("receivei_bankacct", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("receivei_oldbankacct", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("BACode", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("BAButton", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("BAName", GetType(String)))

      Dim dateCol As New DataColumn("DueDate", GetType(Date))
      dateCol.DefaultValue = Date.MinValue
      myDatatable.Columns.Add(dateCol)
      myDatatable.Columns.Add(New DataColumn("RealAmount", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("receivei_amt", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("receivei_note", GetType(String)))
      Return myDatatable
    End Function
#End Region

#Region "Methods"
    Private Sub ResetID(ByVal oldid As Integer)
      Me.Id = oldid
    End Sub
    Public Function BeforeSave(ByVal currentUserId As Integer) As SaveErrorException

      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      Me.UpdateGross()
      If TypeOf Me.RefDoc Is VariationOrderDe Then
        If Configuration.Compare(Me.Gross, Me.Amount) = 0 Then
          Return New SaveErrorException("${res:Global.Error.ReceiveGrossExceedAmount}", Configuration.FormatToString(Me.Gross, DigitConfig.Price), Configuration.FormatToString(Me.Amount, DigitConfig.Price))
        ElseIf Configuration.Compare(Me.Amount, Me.Gross) > 0 Then
          If Not TypeOf Me.RefDoc Is AdvanceReceive AndAlso Not TypeOf Me.RefDoc Is PettyCashClosed Then
            'If Not TypeOf Me.RefDoc Is AROpeningBalance AndAlso Not TypeOf Me.RefDoc Is Milestone AndAlso Not TypeOf Me.RefDoc Is EquipmentReturn AndAlso Not msgServ.AskQuestionFormatted("${res:Global.Question.ReceiveAmountExceedGross}", New String() {Configuration.FormatToString(Me.Gross, DigitConfig.Price), Configuration.FormatToString(Me.Amount, DigitConfig.Price), Configuration.FormatToString(Me.Amount - Me.Gross, DigitConfig.Price)}) Then
            '    Return New SaveErrorException("${res:Global.Error.SaveCanceled}")
            'End If
          Else
            Return New SaveErrorException("${res:Global.Error.ReceiveAmountExceedGross}", New String() {Configuration.FormatToString(Me.Gross, DigitConfig.Price), Configuration.FormatToString(Me.Amount, DigitConfig.Price)})
          End If
        End If
      Else
        If Configuration.Compare(Me.Gross, Me.Amount) > 0 Then
          Return New SaveErrorException("${res:Global.Error.ReceiveGrossExceedAmount}", Configuration.FormatToString(Me.Gross, DigitConfig.Price), Configuration.FormatToString(Me.Amount, DigitConfig.Price))
        ElseIf Configuration.Compare(Me.Amount, Me.Gross) > 0 Then
          If Not TypeOf Me.RefDoc Is AdvanceReceive AndAlso Not TypeOf Me.RefDoc Is PettyCashClosed Then
            'If Not TypeOf Me.RefDoc Is AROpeningBalance AndAlso Not TypeOf Me.RefDoc Is Milestone AndAlso Not TypeOf Me.RefDoc Is EquipmentReturn AndAlso Not msgServ.AskQuestionFormatted("${res:Global.Question.ReceiveAmountExceedGross}", New String() {Configuration.FormatToString(Me.Gross, DigitConfig.Price), Configuration.FormatToString(Me.Amount, DigitConfig.Price), Configuration.FormatToString(Me.Amount - Me.Gross, DigitConfig.Price)}) Then
            '    Return New SaveErrorException("${res:Global.Error.SaveCanceled}")
            'End If
          Else
            Return New SaveErrorException("${res:Global.Error.ReceiveAmountExceedGross}", New String() {Configuration.FormatToString(Me.Gross, DigitConfig.Price), Configuration.FormatToString(Me.Amount, DigitConfig.Price)})
          End If
        End If
      End If



      Return New SaveErrorException("0")
    End Function
    Public Overloads Overrides Function Save(ByVal currentUserId As Integer, ByVal conn As System.Data.SqlClient.SqlConnection, ByVal trans As System.Data.SqlClient.SqlTransaction) As SaveErrorException
      With Me
        Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
        'If Me.MaxRowIndex < 0 Then
        '    Return New SaveErrorException(Me.StringParserService.Parse("${res:Global.Error.NoReceiveItem}"))
        'End If

        'For Each row As DataRow In Me.m_itemTable.Rows
        '  Dim drh As New DataRowHelper(row)
        '  If drh.GetValue(Of Date)("DueDate") <> Date.MinValue AndAlso Me.RefDoc.Date < drh.GetValue(Of Date)("DueDate") Then
        '    Return New SaveErrorException("${res:Global.Error.BeforeCreateDate}")
        '  End If
        'Next



        Dim returnVal As System.Data.SqlClient.SqlParameter = New SqlParameter
        returnVal.ParameterName = "RETURN_VALUE"
        returnVal.DbType = DbType.Int32
        returnVal.Direction = ParameterDirection.ReturnValue
        returnVal.SourceVersion = DataRowVersion.Current

        ' สร้าง ArrayList จาก Item ของ  SqlParameter ...
        Dim paramArrayList As New ArrayList

        paramArrayList.Add(returnVal)

        If Me.Originated Then
          paramArrayList.Add(New SqlParameter("@receive_id", Me.Id))
        End If

        Dim theTime As Date = Now
        Dim theUser As New User(currentUserId)

        If Me.Status.Value = -1 Then
          Me.Status.Value = 2
        End If

        If Me.AutoGen AndAlso Me.Code.Length > 0 Then
          Me.Code = Me.GetNextCode
        End If
        Me.AutoGen = False
        If IsDBNull(Me.ValidDateOrDBNull(Me.DocDate)) Then
          Me.DocDate = Me.RefDoc.Date
        End If
        If Me.Gross > 0 Then
          paramArrayList.Add(New SqlParameter("@receive_code", Me.Code))
        Else
          paramArrayList.Add(New SqlParameter("@receive_code", DBNull.Value))
        End If
        paramArrayList.Add(New SqlParameter("@receive_docDate", Me.ValidDateOrDBNull(Me.DocDate)))

        If TypeOf Me.RefDoc Is SimpleBusinessEntityBase Then
          paramArrayList.Add(New SqlParameter("@receive_refDocType", CType(Me.RefDoc, SimpleBusinessEntityBase).EntityId))
        ElseIf TypeOf Me.RefDoc Is Milestone Then
          paramArrayList.Add(New SqlParameter("@receive_refDocType", CType(Me.RefDoc, Milestone).EntityId))
        End If
        paramArrayList.Add(New SqlParameter("@receive_refDoc", IIf(Me.RefDoc.Id <> 0, Me.RefDoc.Id, DBNull.Value)))
        paramArrayList.Add(New SqlParameter("@receive_refDocDate", IIf(Me.RefDoc.Id <> 0, Me.ValidDateOrDBNull(Me.RefDoc.Date), DBNull.Value)))
        paramArrayList.Add(New SqlParameter("@receive_refDocCode", IIf(Me.RefDoc.Id <> 0, Me.RefDoc.Code, DBNull.Value)))
        paramArrayList.Add(New SqlParameter("@receive_refDocNote", IIf(Me.RefDoc.Id <> 0, Me.RefDoc.Note, DBNull.Value)))
        If Not Me.RefDoc.Payer Is Nothing AndAlso TypeOf Me.RefDoc.Payer Is SimpleBusinessEntityBase Then
          Dim payer As SimpleBusinessEntityBase = CType(Me.RefDoc.Payer, SimpleBusinessEntityBase)
          paramArrayList.Add(New SqlParameter("@receive_refDocEntity", ValidIdOrDBNull(payer)))
          paramArrayList.Add(New SqlParameter("@receive_refDocEntityType", payer.EntityId))
        End If
        paramArrayList.Add(New SqlParameter("@receive_gross", Me.Gross))
        paramArrayList.Add(New SqlParameter("@receive_discount", Me.DiscountAmount))
        paramArrayList.Add(New SqlParameter("@receive_otherRevenue", Me.OtherRevenue))
        paramArrayList.Add(New SqlParameter("@receive_witholdingTax", Me.WitholdingTax))
        paramArrayList.Add(New SqlParameter("@receive_interest", Me.Interest))
        paramArrayList.Add(New SqlParameter("@receive_bankcharge", Me.BankCharge))
        paramArrayList.Add(New SqlParameter("@receive_otherExpense", Me.OtherExpense))
        paramArrayList.Add(New SqlParameter("@receive_amt", Configuration.Format(Me.Amount, DigitConfig.Price)))
        paramArrayList.Add(New SqlParameter("@receive_debitamt", Me.DebitAmount))
        paramArrayList.Add(New SqlParameter("@receive_creditamt", Me.CreditAmount))
        paramArrayList.Add(New SqlParameter("@receive_note", Me.Note))
        paramArrayList.Add(New SqlParameter("@receive_status", Me.Status.Value))
        paramArrayList.Add(New SqlParameter("@receive_cc", Me.CcId))

        SetOriginEditCancelStatus(paramArrayList, currentUserId, theTime)

        ' สร้าง SqlParameter จาก ArrayList ...
        Dim sqlparams() As SqlParameter
        sqlparams = CType(paramArrayList.ToArray(GetType(SqlParameter)), SqlParameter())
        Dim oldid As Integer = Me.Id
        Try
          Me.ExecuteSaveSproc(conn, trans, returnVal, sqlparams, theTime, theUser)
          If IsNumeric(returnVal.Value) Then
            Select Case CInt(returnVal.Value)
              Case -1
                Return New SaveErrorException("${res:Global.Error.DuplicatedReceiveCode}", Me.Code)
              Case -2, -5
                Return New SaveErrorException(returnVal.Value.ToString)
              Case Else
            End Select
          ElseIf IsDBNull(returnVal.Value) OrElse Not IsNumeric(returnVal.Value) Then
            Return New SaveErrorException(returnVal.Value.ToString)
          End If
          Dim detailError As SaveErrorException = SaveDetail(Me.Id, conn, trans, currentUserId)
          If Not IsNumeric(detailError.Message) Then
            Return detailError
          Else
            Select Case CInt(detailError.Message)
              Case -1, -5
                Return New SaveErrorException(returnVal.Value.ToString)
              Case -2
                Return New SaveErrorException(returnVal.Value.ToString)
              Case Else
            End Select
          End If
          ChangeOldItemEntityStatus(conn, trans)
          Return New SaveErrorException(returnVal.Value.ToString)
        Catch ex As SqlException
          Me.ResetID(oldid)
          Return New SaveErrorException(ex.ToString)
        Catch ex As Exception
          Me.ResetID(oldid)
          Return New SaveErrorException(ex.ToString)
        End Try
      End With
    End Function
    Public Overrides Function GetNextCode() As String
      Dim autoCodeFormat As String = Me.Code    'Entity.GetAutoCodeFormat(Me.EntityId)
      Dim pattern As String = CodeGenerator.GetPattern(autoCodeFormat, Me)

      pattern = CodeGenerator.GetPattern(pattern)

      Dim lastCode As String = Me.GetLastCode(pattern)
      Dim newCode As String = _
      CodeGenerator.Generate(autoCodeFormat, lastCode, Me)
      While DuplicateCode(newCode)
        newCode = CodeGenerator.Generate(autoCodeFormat, newCode, Me)
      End While
      Return newCode
    End Function
    Private Function GetItemCheckListFromOldItems() As String
      Dim checkList As New ArrayList
      For Each item As ReceiveItem In Me.m_oldReceiveItemList
        If TypeOf item.Entity Is IncomingCheck Then
          checkList.Add(item.Entity.Id)
        End If
      Next
      Return String.Join(",", checkList.ToArray)
    End Function
    Private Function GetItemAdvanceReceiveListFromOldItems() As String
      Dim advList As New ArrayList
      For Each item As ReceiveItem In Me.m_oldReceiveItemList
        If TypeOf item.Entity Is AdvanceReceive Then
          advList.Add(item.Entity.Id)
        End If
      Next
      Return String.Join(",", advList.ToArray)
    End Function
    Private Sub ChangeOldItemEntityStatus(ByVal conn As SqlConnection, ByVal trans As SqlTransaction)
      If Not Me.Originated Then
        Return
      End If
      'SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdateReceiveItemEntityStatus", New SqlParameter("@receive_id", Me.Id))
      SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdateCheckStatusFromItems", _
                                New SqlParameter("@receive_id", Me.Id), _
                                New SqlParameter("@checkItemList", Me.GetItemCheckListFromOldItems))
      SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdateAdvanceReceiveStatusFromItems", _
                                New SqlParameter("@receive_id", Me.Id), _
                                New SqlParameter("@advrItemList", Me.GetItemAdvanceReceiveListFromOldItems))
    End Sub
    Private Function GetItemCheckListFromItems() As String
      Dim checkList As New ArrayList
      For n As Integer = 0 To Me.MaxRowIndex
        Dim itemRow As TreeRow = Me.m_itemTable.Childs(n)
        If ValidateRow(itemRow) Then
          If CInt(itemRow("receivei_entityType")) = 27 Then
            checkList.Add(CLng(itemRow("receivei_entity")))
          End If
        End If
      Next
      Return String.Join(",", checkList.ToArray)
    End Function
    Private Function GetItemAdvanceReceiveListFromItems() As String
      Dim advList As New ArrayList
      For n As Integer = 0 To Me.MaxRowIndex
        Dim itemRow As TreeRow = Me.m_itemTable.Childs(n)
        If ValidateRow(itemRow) Then
          If CInt(itemRow("receivei_entityType")) = 71 Then
            advList.Add(CLng(itemRow("receivei_entity")))
          End If
        End If
      Next
      Return String.Join(",", advList.ToArray)
    End Function
    Private Sub ChangeItemEntityStatus(ByVal conn As SqlConnection, ByVal trans As SqlTransaction)
      If Not Me.Originated Then
        Return
      End If
      'SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdateReceiveItemEntityStatus", New SqlParameter("@receive_id", Me.Id))
      SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdateCheckStatusFromItems", _
                                New SqlParameter("@receive_id", Me.Id), _
                                New SqlParameter("@checkItemList", Me.GetItemCheckListFromItems))
      SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdateAdvanceReceiveStatusFromItems", _
                                New SqlParameter("@receive_id", Me.Id), _
                                New SqlParameter("@advrItemList", Me.GetItemAdvanceReceiveListFromItems))
    End Sub
    Private Function SaveDetail(ByVal parentID As Integer, ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByVal currentUserId As Integer) As SaveErrorException
      Try
        Dim da As New SqlDataAdapter("Select * from receiveitem where receivei_receive=" & Me.Id, conn)

        Dim cmdBuilder As New SqlCommandBuilder(da)

        Dim ds As New DataSet

        da.SelectCommand.Transaction = trans

        'ต้องอยู่ต่อจาก da.SelectCommand.Transaction = trans
        cmdBuilder.GetDeleteCommand.Transaction = trans
        cmdBuilder.GetInsertCommand.Transaction = trans
        cmdBuilder.GetUpdateCommand.Transaction = trans

        da.Fill(ds, "receiveitem")

        Dim dbCount As Integer = ds.Tables("receiveitem").Rows.Count
        Dim itemCount As Integer = Me.ItemTable.Childs.Count
        Dim i As Integer = 0
        With ds.Tables("receiveitem")
          For Each row As DataRow In .Rows
            row.Delete()
          Next
          Dim CurrentCheckCode As String = ""
          For n As Integer = 0 To Me.MaxRowIndex
            Dim itemRow As TreeRow = Me.m_itemTable.Childs(n)
            If ValidateRow(itemRow) Then
              i += 1
              Dim dr As DataRow = .NewRow
              Select Case CInt(itemRow("receivei_entityType"))
                Case 0         'สด
                  dr("receivei_duedate") = itemRow("DueDate")
                Case 27        'เช็ครับ
                  'Dim check As New IncomingCheck
                  'Dim isOldCheck As Boolean
                  'If CInt(itemRow("receivei_entity")) = 0 Then
                  '  check = ReceiveItem.GetNewCheckFromitemRow(itemRow, Me)
                  '  check.beforeCode = CurrentCheckCode
                  '  check.DocDate = Me.DocDate
                  '  If Not itemRow.IsNull("receivei_amt") Then
                  '    check.Amount = CDec(itemRow("receivei_amt"))
                  '  End If
                  '  If Not itemRow.IsNull("receivei_bankacct") AndAlso IsNumeric(itemRow("receivei_bankacct")) Then
                  '    check.BankAccount = New BankAccount(CInt(itemRow("receivei_bankacct")))
                  '    check.Bank = check.BankAccount.BankBranch.Bank
                  '    check.CustBankBranch = check.BankAccount.BankBranch.Name
                  '  End If

                  '  Dim checkSaveError As SaveErrorException = check.Save(currentUserId, conn, trans)
                  '  If Not IsNumeric(checkSaveError.Message) Then
                  '    Return checkSaveError
                  '  Else
                  '    Select Case CInt(checkSaveError.Message)
                  '      Case -1, -5
                  '        Return New SaveErrorException(checkSaveError.Message)
                  '      Case -2
                  '        Return New SaveErrorException(checkSaveError.Message)
                  '      Case Else
                  '    End Select
                  '  End If

                  '  'Dim errCheck As SaveErrorException = check.CheckUpdateBackAccountAndCheckDeposit(currentUserId, conn, trans, Me.DocDate)
                  '  'If Not IsNumeric(errCheck.Message) Then
                  '  '  Return New SaveErrorException(errCheck.Message)
                  '  'End If

                  '  'check.IsOldCheck = False
                  '  CurrentCheckCode = check.Code
                  'Else

                  '  check.Id = CInt(itemRow("receivei_entity"))
                  '  'check.DocDate = Me.DocDate
                  '  'If Not itemRow.IsNull("receivei_amt") Then
                  '  '  check.Amount = CDec(itemRow("receivei_amt"))
                  '  'End If
                  '  If Not itemRow.IsNull("receivei_bankacct") AndAlso IsNumeric(itemRow("receivei_bankacct")) Then
                  '    check.BankAccount = New BankAccount(CInt(itemRow("receivei_bankacct")))
                  '    If Not check.BankAccount.BankBranch Is Nothing Then
                  '      If Not check.BankAccount.BankBranch.Bank Is Nothing Then
                  '        check.Bank = check.BankAccount.BankBranch.Bank
                  '      End If
                  '      check.CustBankBranch = check.BankAccount.BankBranch.Name
                  '    End If
                  '  End If
                  '  'If Not itemRow.IsNull("receivei_oldbankacct") AndAlso IsNumeric(itemRow("receivei_oldbankacct")) Then
                  '  '  check.OldBankAccount = New BankAccount(CInt(itemRow("receivei_oldbankacct")))
                  '  'End If

                  '  'check.AutoGen = False
                  '  'Dim checkSaveError As SaveErrorException = check.Save(currentUserId, conn, trans)
                  '  'If Not IsNumeric(checkSaveError.Message) Then
                  '  '  Return checkSaveError
                  '  'Else
                  '  '  Select Case CInt(checkSaveError.Message)
                  '  '    Case -1, -5
                  '  '      Return New SaveErrorException(checkSaveError.Message)
                  '  '    Case -2
                  '  '      Return New SaveErrorException(checkSaveError.Message)
                  '  '    Case Else
                  '  '  End Select
                  '  'End If

                  '  'Dim m_checkDictionary As New Dictionary(Of Integer, IncomingCheck)

                  '  Dim errCheck As SaveErrorException = check.CheckUpdateBackAccountAndCheckDeposit(currentUserId, conn, trans, Me.DocDate)
                  '  If Not IsNumeric(errCheck.Message) Then
                  '    Return New SaveErrorException(errCheck.Message)
                  '  End If

                  '  'check.IsOldCheck = True
                  'End If
                  'If Not check.Originated Then
                  '  Return New SaveErrorException("Cannot Save Check 2")
                  'End If
                  'dr("receivei_entity") = check.Id
                  'If Not ItemSavedCheckHash.ContainsKey(check.Id) Then
                  '  ItemSavedCheckHash(check.Id) = check
                  'End If
                  dr("receivei_entity") = itemRow("receivei_entity")
                  dr("receivei_duedate") = itemRow("duedate")
                  dr("receivei_bankacct") = itemRow("receivei_bankacct")
                Case 71        'มัดจำ
                  dr("receivei_entity") = itemRow("receivei_entity")
                Case 72        'โอน
                  dr("receivei_duedate") = itemRow("DueDate")
                  dr("receivei_bankacct") = itemRow("receivei_bankacct")
                Case Else
              End Select
              dr("receivei_receive") = Me.Id
              dr("receivei_linenumber") = i
              dr("receivei_entityType") = itemRow("receivei_entityType")
              dr("receivei_amt") = itemRow("receivei_amt")
              dr("receivei_note") = itemRow("receivei_note")
              dr("receivei_status") = Me.Status.Value
              .Rows.Add(dr)
            End If
          Next
        End With
        Dim dt As DataTable = ds.Tables("receiveitem")
        ' First process deletes.
        da.Update(dt.Select(Nothing, Nothing, DataViewRowState.Deleted))
        ' Next process updates.
        da.Update(dt.Select(Nothing, Nothing, DataViewRowState.ModifiedCurrent))
        ' Finally process inserts.
        da.Update(dt.Select(Nothing, Nothing, DataViewRowState.Added))

        Dim daDrCr As New SqlDataAdapter("Select * from receiveaccount where receivea_receive=" & Me.Id, conn)
        cmdBuilder = New SqlCommandBuilder(daDrCr)


        daDrCr.SelectCommand.Transaction = trans

        'ต้องอยู่ต่อจาก da.SelectCommand.Transaction = trans
        cmdBuilder.GetDeleteCommand.Transaction = trans
        cmdBuilder.GetInsertCommand.Transaction = trans
        cmdBuilder.GetUpdateCommand.Transaction = trans

        daDrCr.Fill(ds, "receiveaccount")

        With ds.Tables("receiveaccount")
          For Each row As DataRow In .Rows
            row.Delete()
          Next
          For Each item As ReceiveAccountItem In Me.DebitCollection
            Dim dr As DataRow = .NewRow
            dr("receivea_receive") = Me.Id
            dr("receivea_acct") = Me.ValidIdOrDBNull(item.Account)
            dr("receivea_isdebit") = item.IsDebit
            dr("receivea_amt") = item.Amount
            .Rows.Add(dr)
          Next
          For Each item As ReceiveAccountItem In Me.CreditCollection
            Dim dr As DataRow = .NewRow
            dr("receivea_receive") = Me.Id
            dr("receivea_acct") = Me.ValidIdOrDBNull(item.Account)
            dr("receivea_isdebit") = item.IsDebit
            dr("receivea_amt") = item.Amount
            .Rows.Add(dr)
          Next
        End With
        dt = ds.Tables("receiveaccount")
        ' First process deletes.
        daDrCr.Update(dt.Select(Nothing, Nothing, DataViewRowState.Deleted))
        ' Next process updates.
        daDrCr.Update(dt.Select(Nothing, Nothing, DataViewRowState.ModifiedCurrent))
        ' Finally process inserts.
        daDrCr.Update(dt.Select(Nothing, Nothing, DataViewRowState.Added))
      Catch ex As Exception
        Return New SaveErrorException(ex.ToString)
      End Try
      Return New SaveErrorException("0")
    End Function
    Public Function AutoGenerateCheck(ByVal currentUserId As Integer, ByVal conn As SqlConnection, ByVal trans As SqlTransaction) As SaveErrorException
      Dim CurrentCheckCode As String = ""
      For n As Integer = 0 To Me.MaxRowIndex
        Dim itemRow As TreeRow = Me.m_itemTable.Childs(n)
        If ValidateRow(itemRow) Then
          Select Case CInt(itemRow("receivei_entityType"))
            Case 27  'เช็ครับ
              Dim check As New IncomingCheck
              Dim isOldCheck As Boolean
              If CInt(itemRow("receivei_entity")) = 0 OrElse itemRow.IsNull("receivei_entity") Then

                check = ReceiveItem.GetNewCheckFromitemRow(itemRow, Me)
                check.beforeCode = CurrentCheckCode
                check.DocDate = Me.DocDate
                If Not itemRow.IsNull("receivei_amt") Then
                  check.Amount = CDec(itemRow("receivei_amt"))
                End If
                If Not itemRow.IsNull("receivei_bankacct") AndAlso IsNumeric(itemRow("receivei_bankacct")) Then
                  check.BankAccount = New BankAccount(CInt(itemRow("receivei_bankacct")))
                  check.Bank = check.BankAccount.BankBranch.Bank
                  check.CustBankBranch = check.BankAccount.BankBranch.Name
                End If

                Dim checkSaveError As SaveErrorException = check.Save(currentUserId, conn, trans)
                If Not IsNumeric(checkSaveError.Message) Then
                  Return checkSaveError
                Else
                  Select Case CInt(checkSaveError.Message)
                    Case -1, -5
                      Return New SaveErrorException(checkSaveError.Message)
                    Case -2
                      Return New SaveErrorException(checkSaveError.Message)
                    Case Else
                  End Select
                End If
                CurrentCheckCode = check.Code

                itemRow("receivei_entity") = check.Id
              Else

                check.Id = CInt(itemRow("receivei_entity"))
                If Not itemRow.IsNull("receivei_bankacct") AndAlso IsNumeric(itemRow("receivei_bankacct")) Then
                  check.BankAccount = New BankAccount(CInt(itemRow("receivei_bankacct")))
                  If Not check.BankAccount.BankBranch Is Nothing Then
                    If Not check.BankAccount.BankBranch.Bank Is Nothing Then
                      check.Bank = check.BankAccount.BankBranch.Bank
                    End If
                    check.CustBankBranch = check.BankAccount.BankBranch.Name
                  End If
                End If
                Dim errCheck As SaveErrorException = check.CheckUpdateBackAccountAndCheckDeposit(currentUserId, conn, trans, Me.DocDate)
                If Not IsNumeric(errCheck.Message) Then
                  Return New SaveErrorException(errCheck.Message)
                End If

              End If
            Case Else
          End Select
        End If
      Next

      Return New SaveErrorException("0")
    End Function
    Public Function AutoGenerateUpdateDepositCheck(ByVal currentUserId As Integer, ByVal conn As SqlConnection, ByVal trans As SqlTransaction) As SaveErrorException
      Try

        Dim ds As DataSet = Me.GetCheckReceiveItemFromDB(conn, trans)
        For Each drow As DataRow In ds.Tables(0).Rows
          Dim drh As New DataRowHelper(drow)
          If drh.GetValue(Of Integer)("cqupdatei_entity") = 0 AndAlso drh.GetValue(Of Integer)("receivei_bankacct") > 0 Then
            Dim check As New IncomingCheck(drow, "")

            Dim upd As New UpdateCheckDeposit
            upd.AutoGen = True

            Dim cmbCode As New ComboBox
            BusinessLogic.Entity.NewPopulateCodeCombo(cmbCode, upd.EntityId, currentUserId)
            If cmbCode.Items.Count > 0 Then
              upd.Code = CType(cmbCode.Items(0), AutoCodeFormat).Format
              cmbCode.SelectedIndex = 0
              upd.AutoCodeFormat = CType(cmbCode.Items(0), AutoCodeFormat)
            End If

            upd.DocDate = check.DocDate
            upd.BankAccount = check.BankAccount
            upd.TotalAmount = check.Amount

            Dim upditem As New UpdateCheckDepositItem
            upditem.BeforeStatus = New IncomingCheckDocStatus(1)
            upditem.Entity = check
            upditem.LineNumber = 1
            upd.ListOfUpdateCheckDepositItem.Add(upditem)

            'upd.ExternalForce = True
            Dim saveerr As SaveErrorException = upd.Save(currentUserId, conn, trans)
            If Not IsNumeric(saveerr.Message) Then
              Return New SaveErrorException(saveerr.Message)
            End If
            Dim saveerr2 As SaveErrorException = upd.UpdateCheckDeposit_IncomingCheckRef(conn, trans, Me.RefDoc.Id, CType(Me.RefDoc, SimpleBusinessEntityBase).EntityId)
            If Not IsNumeric(saveerr2.Message) Then
              Return New SaveErrorException(saveerr2.Message)
            End If
            Dim saveerr3 As SaveErrorException = upd.UpdateCheckDeposit_ReceiveRefRef(conn, trans, Me.RefDoc.Id, CType(Me.RefDoc, SimpleBusinessEntityBase).EntityId)
            If Not IsNumeric(saveerr3.Message) Then
              Return New SaveErrorException(saveerr3.Message)
            End If

          Else '--เก็บ Reference ด้วย--
            Dim upd As New UpdateCheckDeposit
            upd.Id = drh.GetValue(Of Integer)("cqupdatei_cqupdateid")
            Dim saveerr3 As SaveErrorException = upd.UpdateCheckDeposit_ReceiveRefRef(conn, trans, Me.RefDoc.Id, CType(Me.RefDoc, SimpleBusinessEntityBase).EntityId)
            If Not IsNumeric(saveerr3.Message) Then
              Return New SaveErrorException(saveerr3.Message)
            End If
          End If

        Next

        'Dim saveerr3 As SaveErrorException = upd.UpdateCheckDeposit_ReceiveRefRef(conn, trans, Me.RefDoc.Id, CType(Me.RefDoc, SimpleBusinessEntityBase).EntityId)
        'If Not IsNumeric(saveerr3.Message) Then
        '  Return New SaveErrorException(saveerr3.Message)
        'End If

        ChangeItemEntityStatus(conn, trans)
      Catch ex As Exception
        Return New SaveErrorException(ex.Message)
      End Try

      Return New SaveErrorException("0")
    End Function
    'Public Function UpdateCheckDeposit_IncomingCheckRef(ByVal conn As SqlConnection, ByVal trans As SqlTransaction) As SaveErrorException
    '  Try
    '    SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdateCheckDeposit_IncomingCheckRef", New SqlParameter("@entity_id", Me.RefDoc.Id), New SqlParameter("@entity_type", CType(Me.RefDoc, SimpleBusinessEntityBase).EntityId))
    '  Catch ex As Exception
    '    Return New SaveErrorException(ex.InnerException.ToString)
    '  End Try
    '  Return New SaveErrorException("0")
    'End Function
    Private Function GetCheckReceiveItemFromDB(ByVal conn As SqlConnection, ByVal trans As SqlTransaction) As DataSet
      Dim ds As DataSet = SqlHelper.ExecuteDataset(conn, trans, CommandType.StoredProcedure, "GetCheckReceiveItemFromDB", New SqlParameter("@receive_id", Me.Id))
      Return ds
    End Function
    Private Function GetCheckDepositRef() As Boolean
      Dim ds As DataSet = SqlHelper.ExecuteDataset(SimpleBusinessEntityBase.ConnectionString, CommandType.StoredProcedure, "GetCheckDepositRef", New SqlParameter("@receive_id", Me.Id))
      If Not ds.Tables(0).Rows(0).IsNull(0) Then
        Return CBool(ds.Tables(0).Rows(0)(0))
      End If
      Return False
    End Function
    Private Sub LoadOldReceievItem()
      m_oldReceiveItemList = New List(Of ReceiveItem)
      For i As Integer = 0 To Me.MaxRowIndex
        Dim itemRow As TreeRow = CType(Me.m_itemTable.Rows(i), TreeRow)
        If ValidateRow(itemRow) Then
          Dim item As New ReceiveItem
          item.CopyFromDataRow(itemRow)
          'Dim itIsCash As Boolean = (TypeOf item.Entity Is CashItem)
          m_oldReceiveItemList.Add(item)
        End If
      Next
    End Sub
    ''' <summary>
    ''' !!!CheckUpdateBackAccountAndCheckDeposit ไม่ค่อยอยากใช้ pattern นี้สักเท่าไหร่ แต่ design เก่าบังคับให้ทำ ฉะนั้น Funcion นี้สงวนไว้สำหรับ SubSave อย่างเดียวเพราะมี ตัวแปรบางตัวที่จะมี value ได้ต้องผ่านsub savedetail มาก่อน
    ''' </summary>
    ''' <param name="currentUserId"></param>
    ''' <param name="conn"></param>
    ''' <param name="trans"></param>
    ''' <param name="receiveDate"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    'Public Function CheckUpdateBackAccountAndCheckDeposit(ByVal currentUserId As Integer, _
    '                                                      ByVal conn As System.Data.SqlClient.SqlConnection, _
    '                                                      ByVal trans As System.Data.SqlClient.SqlTransaction, _
    '                                                      ByVal receiveDate As DateTime) As SaveErrorException
    'If ItemSavedCheckHash Is Nothing Then
    '  Return New SaveErrorException("o")
    'End If

    'For Each check As IncomingCheck In ItemSavedCheckHash.Values
    '  Try
    '    SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, _
    '                       "CheckUpdateBackAccountAndCheckDeposit", _
    '                       New SqlParameter() {New SqlParameter("@check_id", check.Id), _
    '                                           New SqlParameter("@check_bankacct", SimpleBusinessEntityBase.ValidIdOrDBNull(check.BankAccount)), _
    '                                           New SqlParameter("@check_bank", SimpleBusinessEntityBase.ValidIdOrDBNull(check.Bank)), _
    '                                           New SqlParameter("@check_custbankbranch", check.CustBankBranch), _
    '                                           New SqlParameter("@check_receivedate", receiveDate), _
    '                                           New SqlParameter("@check_amt", check.Amount), _
    '                                           New SqlParameter("@check_lasteditor", currentUserId), _
    '                                           New SqlParameter("@isOldCheck", check.IsOldCheck)})

    '  Catch ex As SqlException
    '    Return New SaveErrorException(ex.Message)
    '  Catch ex As Exception
    '    Return New SaveErrorException(ex.Message)
    '  End Try
    'Next

    '  Return New SaveErrorException("1")

    'End Function
    ''' <summary>
    ''' !!!AutoSaveUpdateCheckDeposit ไม่ค่อยอยากใช้ pattern นี้สักเท่าไหร่ แต่ design เก่าบังคับให้ทำ ฉะนั้น Funcion นี้สงวนไว้สำหรับ SubSave อย่างเดียวเพราะมี ตัวแปรบางตัวที่จะมี value ได้ต้องผ่านsub savedetail มาก่อน
    ''' </summary>
    ''' <param name="currentUserId"></param>
    ''' <param name="conn"></param>
    ''' <param name="trans"></param>
    ''' <param name="receiveDate"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    'Public Function AutoSaveUpdateCheckDeposit(ByVal currentUserId As Integer, _
    '                                           ByVal receiveDate As DateTime) As SaveErrorException
    'ByVal conn As System.Data.SqlClient.SqlConnection, _
    'ByVal trans As System.Data.SqlClient.SqlTransaction, _
    'ByVal receiveDate As DateTime) As SaveErrorException
    'If ItemSavedCheckHash Is Nothing Then
    '  Return New SaveErrorException("o")
    'End If

    'For Each check As IncomingCheck In ItemSavedCheckHash.Values
    '  Try
    '    If Not check.BankAccount Is Nothing AndAlso check.BankAccount.Originated Then
    '      'If check.BankAccount.Id <> check.OldBankAccount.Id Then
    '      If Not check.GetUpdateCheckDepositRight() Then

    '        Dim upd As New UpdateCheckDeposit
    '        upd.AutoGen = True

    '        Dim cmbCode As New ComboBox
    '        BusinessLogic.Entity.NewPopulateCodeCombo(cmbCode, upd.EntityId, currentUserId)
    '        If cmbCode.Items.Count > 0 Then
    '          upd.Code = CType(cmbCode.Items(0), AutoCodeFormat).Format
    '          cmbCode.SelectedIndex = 0
    '          upd.AutoCodeFormat = CType(cmbCode.Items(0), AutoCodeFormat)
    '        End If

    '        upd.DocDate = check.DocDate
    '        upd.BankAccount = check.BankAccount
    '        upd.TotalAmount = check.Amount

    '        Dim upditem As New UpdateCheckDepositItem
    '        upditem.BeforeStatus = New IncomingCheckDocStatus(1)
    '        upditem.Entity = check
    '        upditem.LineNumber = 1
    '        upd.Add(upditem)

    '        upd.ExternalForce = True
    '        Dim saveerr As SaveErrorException = upd.Save(currentUserId)
    '        If Not IsNumeric(saveerr.Message) Then
    '          Return New SaveErrorException(saveerr.Message)
    '        End If
    '      End If
    '      'End If
    '    End If

    '  Catch ex As SqlException
    '    Return New SaveErrorException(ex.Message)
    '  Catch ex As Exception
    '    Return New SaveErrorException(ex.Message)
    '  End Try
    'Next

    '  Return New SaveErrorException("1")

    'End Function
#End Region

#Region "Items"
    Public Overloads Sub ReLoadItems()
      Me.IsInitialized = False
      m_itemTable = GetSchemaTable()
      LoadItems()
      LoadOldReceievItem()
      Me.IsInitialized = True
    End Sub
    Public Overloads Sub ReloadItems(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
      Me.IsInitialized = False
      m_itemTable = GetSchemaTable()
      LoadItems(ds, aliasPrefix)
      Me.IsInitialized = True
    End Sub
    Private Sub LoadItems()
      If Not Me.Originated Then
        Return
      End If
      Dim ds As DataSet = SqlHelper.ExecuteDataset(Me.ConnectionString _
      , CommandType.StoredProcedure _
      , "GetReceiveItems" _
      , New SqlParameter("@receive_id", Me.Id) _
      )

      For Each row As DataRow In ds.Tables(0).Rows
        Dim item As New ReceiveItem(row, "")
        item.Receive = Me
        Me.Add(item)
      Next
    End Sub
    Private Sub LoadItems(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
      For Each dr As DataRow In ds.Tables(1).Rows
        Dim item As New ReceiveItem(dr, aliasPrefix)
        item.Receive = Me
        Me.Add(item)
      Next
    End Sub
    Public Sub AddBlankRow(ByVal count As Integer)
      For i As Integer = 0 To count - 1
        Dim myItem As New ReceiveItem
        Me.ItemTable.AcceptChanges()
        Me.Add(myItem)
      Next
    End Sub
    Public Function Add(ByVal item As ReceiveItem) As TreeRow
      Dim myRow As TreeRow = Me.ItemTable.Childs.Add
      item.LineNumber = Me.ItemTable.Childs.Count
      item.Receive = Me
      item.CopyToDataRow(myRow)
      Return myRow
    End Function
    Public Function Insert(ByVal index As Integer, ByVal item As ReceiveItem) As TreeRow
      Dim myRow As TreeRow = Me.ItemTable.Childs.InsertAt(index)
      item.LineNumber = Me.ItemTable.Childs.IndexOf(myRow) + 1
      item.Receive = Me
      item.CopyToDataRow(myRow)
      ReIndex(index + 1)
      Return myRow
    End Function
    Public Sub Remove(ByVal index As Integer)
      Me.ItemTable.Childs.Remove(Me.ItemTable.Childs(index))
      ReIndex()
    End Sub
    Private Sub ReIndex()
      ReIndex(0)
    End Sub
    Private Sub ReIndex(ByVal index As Integer)
      If index < 0 OrElse index > Me.ItemTable.Childs.Count - 1 Then
        Return
      End If
      For i As Integer = index To Me.ItemTable.Childs.Count - 1
        Me.ItemTable.Childs(i)("receivei_linenumber") = i + 1
      Next
    End Sub
    Public Function MaxRowIndex() As Integer
      If Me.m_itemTable Is Nothing Then
        Return -1
      End If
      'ให้ index ของแถวสุดท้ายที่มีข้อมูล
      For i As Integer = Me.m_itemTable.Childs.Count - 1 To 0 Step -1
        Dim row As TreeRow = Me.m_itemTable.Childs(i)
        If ValidateRow(row) Then
          Return i
        End If
      Next
      Return -1   'ไม่มีข้อมูลเลย
    End Function
#End Region

#Region "TreeTable Handlers"
    Private Sub Treetable_ColumnChanged(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs)
      If Not Me.IsInitialized Then
        Return
      End If
      Dim index As Integer = Me.m_itemTable.Childs.IndexOf(CType(e.Row, TreeRow))
      If ValidateRow(CType(e.Row, TreeRow)) Then
        If index = Me.m_itemTable.Childs.Count - 1 Then
          Me.AddBlankRow(1)
        End If
        Me.UpdateGross()
        Dim pe As New PropertyChangedEventArgs("ItemChanged", "", "")
        Me.OnPropertyChanged(Me, pe)
        Me.m_itemTable.AcceptChanges()
      End If
    End Sub
    Private Sub Treetable_ColumnChanging(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs)
      If Not Me.IsInitialized Then
        Return
      End If
      Try
        Select Case e.Column.ColumnName.ToLower
          Case "code"
            SetCode(e)
          Case "receivei_entitytype"
            SetEntityType(e)
          Case "bacode"
            SetBankAccount(e)
          Case "duedate"
            SetDueDate(e)
          Case "realamount"
            SetRealAmount(e)
          Case "receivei_amt"
            SetAmount(e)
        End Select
        ValidateRow(e)
      Catch ex As Exception
        MessageBox.Show(ex.ToString)
      End Try
    End Sub
    Public Sub ValidateRow(ByVal e As DataColumnChangeEventArgs)
      Dim code As Object = e.Row("code")
      Dim receivei_entitytype As Object = e.Row("receivei_entitytype")
      Dim bacode As Object = e.Row("bacode")
      Dim duedate As Object = e.Row("duedate")
      Dim realamount As Object = e.Row("realamount")
      Dim receivei_amt As Object = e.Row("receivei_amt")

      Select Case e.Column.ColumnName.ToLower
        Case "code"
          code = e.ProposedValue
        Case "receivei_entitytype"
          receivei_entitytype = e.ProposedValue
        Case "bacode"
          bacode = e.ProposedValue
        Case "duedate"
          duedate = e.ProposedValue
        Case "realamount"
          realamount = e.ProposedValue
        Case "receivei_amt"
          receivei_amt = e.ProposedValue
        Case Else
          Return
      End Select

      Dim isBlankRow As Boolean = False
      If IsDBNull(receivei_entitytype) Then
        isBlankRow = True
      End If
      If Not isBlankRow Then
        Select Case CInt(receivei_entitytype)
          Case 0      'สด
            If IsDBNull(duedate) OrElse CDate(duedate).Equals(Date.MinValue) Then
              e.Row.SetColumnError("duedate", Me.StringParserService.Parse("${res:Global.Error.DateMissing}"))
            Else
              e.Row.SetColumnError("duedate", "")
            End If
            If Not IsNumeric(receivei_amt) OrElse CDec(receivei_amt) <= 0 Then
              e.Row.SetColumnError("receivei_amt", Me.StringParserService.Parse("${res:Global.Error.ReceiveAmountMissing}"))
            Else
              e.Row.SetColumnError("receivei_amt", "")
            End If
            e.Row.SetColumnError("code", "")
            e.Row.SetColumnError("bacode", "")
            e.Row.SetColumnError("realamount", "")
          Case 27     'เช็ครับ
            If IsDBNull(code) OrElse code.ToString.Length = 0 Then
              e.Row.SetColumnError("code", Me.StringParserService.Parse("${res:Global.Error.CheckCodeMissing}"))
            Else
              e.Row.SetColumnError("code", "")
            End If
            If IsDBNull(duedate) OrElse CDate(duedate).Equals(Date.MinValue) Then
              e.Row.SetColumnError("duedate", Me.StringParserService.Parse("${res:Global.Error.DateMissing}"))
            Else
              e.Row.SetColumnError("duedate", "")
            End If
            If Not IsNumeric(realamount) OrElse CDec(realamount) <= 0 Then
              e.Row.SetColumnError("realamount", Me.StringParserService.Parse("${res:Global.Error.RealAmountMissing}"))
            Else
              e.Row.SetColumnError("realamount", "")
            End If
            If Not IsNumeric(receivei_amt) OrElse (IsNumeric(receivei_amt) AndAlso CDec(receivei_amt) <= 0) Then
              e.Row.SetColumnError("receivei_amt", Me.StringParserService.Parse("${res:Global.Error.ReceiveAmountMissing}"))
            Else
              e.Row.SetColumnError("receivei_amt", "")
            End If
            e.Row.SetColumnError("bacode", "")
          Case 71     'มัดจำ
            If IsDBNull(code) OrElse code.ToString.Length = 0 Then
              e.Row.SetColumnError("code", Me.StringParserService.Parse("${res:Global.Error.AdvanceReceiveCodeMissing}"))
            Else
              e.Row.SetColumnError("code", "")
            End If
            If Not IsNumeric(receivei_amt) OrElse CDec(receivei_amt) <= 0 Then
              e.Row.SetColumnError("receivei_amt", Me.StringParserService.Parse("${res:Global.Error.ReceiveAmountMissing}"))
            Else
              e.Row.SetColumnError("receivei_amt", "")
            End If
            e.Row.SetColumnError("bacode", "")
            e.Row.SetColumnError("realamount", "")
            e.Row.SetColumnError("duedate", "")
          Case 72     'โอน
            If IsDBNull(duedate) OrElse CDate(duedate).Equals(Date.MinValue) Then
              e.Row.SetColumnError("duedate", Me.StringParserService.Parse("${res:Global.Error.DateMissing}"))
            Else
              e.Row.SetColumnError("duedate", "")
            End If
            If Not IsNumeric(receivei_amt) OrElse (IsNumeric(receivei_amt) AndAlso CDec(receivei_amt) <= 0) Then
              e.Row.SetColumnError("receivei_amt", Me.StringParserService.Parse("${res:Global.Error.ReceiveAmountMissing}"))
            Else
              e.Row.SetColumnError("receivei_amt", "")
            End If
            If IsDBNull(bacode) OrElse bacode.ToString.Length = 0 Then
              e.Row.SetColumnError("bacode", Me.StringParserService.Parse("${res:Global.Error.BACodeMissing}"))
            Else
              e.Row.SetColumnError("bacode", "")
            End If
            e.Row.SetColumnError("code", "")
            e.Row.SetColumnError("realamount", "")
          Case Else
            Return
        End Select
      End If

    End Sub
    Public Function ValidateRow(ByVal row As TreeRow) As Boolean
      If row.IsNull("receivei_entitytype") Then
        Return False
      End If
      Return True
    End Function
    Private m_updating As Boolean = False
    Public Sub SetAmount(ByVal e As DataColumnChangeEventArgs)
      If m_updating Then
        Return
      End If
      If IsDBNull(e.ProposedValue) OrElse e.ProposedValue.ToString.Length = 0 Then
        e.ProposedValue = ""
        Return
      End If
      e.ProposedValue = Configuration.FormatToString(CDec(TextParser.Evaluate(e.ProposedValue.ToString)), DigitConfig.Price)
      Dim value As Decimal = CDec(e.ProposedValue)
      Dim oldAmount As Decimal
      If e.Row.IsNull("receivei_amt") OrElse CStr(e.Row("receivei_amt")).Length = 0 Then
        oldAmount = 0
      Else
        oldAmount = CDec(e.Row("receivei_amt"))
      End If
      Dim oldRealAmount As Decimal
      If e.Row.IsNull("RealAmount") OrElse CStr(e.Row("RealAmount")).Length = 0 Then
        oldRealAmount = 0
      Else
        oldRealAmount = CDec(e.Row("RealAmount"))
      End If
      UpdateGross()
      m_updating = True
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      If e.Row.IsNull("receivei_entityType") Then
        msgServ.ShowMessage("${res:Global.Error.NoReceiveType}")
        e.ProposedValue = e.Row(e.Column)
        m_updating = False
        Return
      End If
      Select Case CInt(e.Row("receivei_entityType"))
        Case 0     'สด
          If Configuration.Compare(Me.Amount, (Me.Gross + value - oldAmount)) < 0 Then
            msgServ.ShowMessage("${res:Global.Error.AmountExceedReceivingAmount}")
            e.ProposedValue = e.Row(e.Column)
            m_updating = False
            Return
          Else
            e.Row("RealAmount") = e.ProposedValue
          End If
        Case 27    'เช็ครับ
          If Configuration.Compare(Me.Amount, (Me.Gross + value - oldAmount)) < 0 Then
            msgServ.ShowMessage("${res:Global.Error.AmountExceedReceivingAmount}")
            e.ProposedValue = e.Row(e.Column)
            m_updating = False
            Return
          Else
            If Configuration.Compare(oldRealAmount, oldAmount) < 0 Then
              msgServ.ShowMessage("${res:Global.Error.ReceiveRealAmountLessThanAmount}")
              e.ProposedValue = e.Row(e.Column)
              m_updating = False
              Return
            End If
          End If
        Case 71    'มัดจำ
          If Configuration.Compare(Me.Amount, (Me.Gross + value - oldAmount)) < 0 Then
            msgServ.ShowMessage("${res:Global.Error.AmountExceedReceivingAmount}")
            e.ProposedValue = e.Row(e.Column)
            m_updating = False
            Return
          Else
            If Configuration.Compare(oldRealAmount, oldAmount) < 0 Then
              msgServ.ShowMessage("${res:Global.Error.ReceiveRealAmountLessThanAmount}")
              e.ProposedValue = e.Row(e.Column)
              m_updating = False
              Return
            End If
          End If
        Case 72    'โอน
          If Configuration.Compare(Me.Amount, (Me.Gross + value - oldAmount)) < 0 Then
            msgServ.ShowMessage("${res:Global.Error.AmountExceedReceivingAmount}")
            e.ProposedValue = e.Row(e.Column)
            m_updating = False
            Return
          Else
            e.Row("RealAmount") = e.ProposedValue
          End If
        Case Else
          msgServ.ShowMessage("${res:Global.Error.NoReceiveType}")
          e.ProposedValue = e.Row(e.Column)
          m_updating = False
          Return
      End Select
      m_updating = False
    End Sub
    Public Sub SetRealAmount(ByVal e As DataColumnChangeEventArgs)
      If m_updating Then
        Return
      End If
      If IsDBNull(e.ProposedValue) OrElse e.ProposedValue.ToString.Length = 0 Then
        e.ProposedValue = ""
        Return
      End If
      e.ProposedValue = Configuration.FormatToString(CDec(TextParser.Evaluate(e.ProposedValue.ToString)), DigitConfig.Price)
      Dim value As Decimal = CDec(e.ProposedValue)
      Dim oldAmount As Decimal
      If e.Row.IsNull("receivei_amt") OrElse CStr(e.Row("receivei_amt")).Length = 0 Then
        oldAmount = 0
      Else
        oldAmount = CDec(e.Row("receivei_amt"))
      End If
      UpdateGross()
      m_updating = True
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      If e.Row.IsNull("receivei_entityType") Then
        msgServ.ShowMessage("${res:Global.Error.NoReceiveType}")
        e.ProposedValue = e.Row(e.Column)
        m_updating = False
        Return
      End If
      Select Case CInt(e.Row("receivei_entityType"))
        Case 0     'สด
          If Configuration.Compare(Me.Amount, (Me.Gross + value - oldAmount)) < 0 Then
            msgServ.ShowMessage("${res:Global.Error.AmountExceedReceivingAmount}")
            e.ProposedValue = e.Row(e.Column)
            m_updating = False
            Return
          Else
            e.Row("receivei_amt") = e.ProposedValue
          End If
        Case 27    'เช็ครับ
          Dim item As New ReceiveItem
          item.Receive = Me
          item.CopyFromDataRow(CType(e.Row, TreeRow))
          Dim check As IncomingCheck = CType(item.Entity, IncomingCheck)
          If Not check Is Nothing AndAlso check.Originated Then
            msgServ.ShowMessage("${res:Global.Error.CannotChangeOldCheckAmount}")
            e.ProposedValue = e.Row(e.Column)
            m_updating = False
            Return
          Else
            If Configuration.Compare(value, oldAmount) < 0 Then
              msgServ.ShowMessage("${res:Global.Error.ReceiveRealAmountLessThanAmount}")
              e.ProposedValue = e.Row(e.Column)
              m_updating = False
              Return
            End If
          End If
        Case 71    'มัดจำ
          msgServ.ShowMessage("${res:Global.Error.CannotChangeAdvanceReceiveAmount}")
          e.ProposedValue = e.Row(e.Column)
          m_updating = False
          Return
        Case 72    'โอน
          If Configuration.Compare(Me.Amount, (Me.Gross + value - oldAmount)) < 0 Then
            msgServ.ShowMessage("${res:Global.Error.AmountExceedReceivingAmount}")
            e.ProposedValue = e.Row(e.Column)
            m_updating = False
            Return
          Else
            e.Row("receivei_amt") = e.ProposedValue
          End If
        Case Else
          msgServ.ShowMessage("${res:Global.Error.NoReceiveType}")
          e.ProposedValue = e.Row(e.Column)
          m_updating = False
          Return
      End Select
      m_updating = False
    End Sub
    Public Sub SetDueDate(ByVal e As DataColumnChangeEventArgs)
      If m_updating Then
        Return
      End If
      m_updating = True
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      If e.Row.IsNull("receivei_entityType") Then
        msgServ.ShowMessage("${res:Global.Error.NoReceiveType}")
        e.ProposedValue = e.Row(e.Column)
        m_updating = False
        Return
      End If
      Select Case CInt(e.Row("receivei_entityType"))
        Case 0     'สด
          'ผ่าน
        Case 27    'เช็ครับ
          Dim item As New ReceiveItem
          item.Receive = Me
          item.CopyFromDataRow(CType(e.Row, TreeRow))
          Dim check As IncomingCheck = CType(item.Entity, IncomingCheck)
          If Not check Is Nothing AndAlso check.Originated Then
            msgServ.ShowMessage("${res:Global.Error.CannotChangeOldCheckDate}")
            e.ProposedValue = e.Row(e.Column)
            m_updating = False
            Return
          Else
            'ผ่าน
          End If
        Case 71    'มัดจำ
          msgServ.ShowMessage("${res:Global.Error.CannotChangeAdvanceReceiveDate}")
          e.ProposedValue = e.Row(e.Column)
          m_updating = False
          Return
        Case 72    'โอน
          'ผ่าน
        Case Else
          msgServ.ShowMessage("${res:Global.Error.NoReceiveType}")
          e.ProposedValue = e.Row(e.Column)
          m_updating = False
          Return
      End Select
      m_updating = False
    End Sub
    Public Sub SetBankAccount(ByVal e As DataColumnChangeEventArgs)
      If m_updating Then
        Return
      End If
      m_updating = True
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      If e.Row.IsNull("receivei_entityType") Then
        msgServ.ShowMessage("${res:Global.Error.NoReceiveType}")
        e.ProposedValue = e.Row(e.Column)
        m_updating = False
        Return
      End If
      Select Case CInt(e.Row("receivei_entityType"))
        Case 0     'สด
          msgServ.ShowMessage("${res:Global.Error.IncomingCheckCannotHaveBankAccount}")
          e.ProposedValue = e.Row(e.Column)
          m_updating = False
          Return
        Case 27    'เช็ครับ
          'msgServ.ShowMessage("${res:Global.Error.CashCannotHaveBankAccount}")
          'e.ProposedValue = e.Row(e.Column)
          'm_updating = False
          'Return
          Dim ba As New BankAccount(e.ProposedValue.ToString)
          e.ProposedValue = ba.Code
          e.Row("BAName") = ba.Name
          e.Row("receivei_bankacct") = ba.Id
        Case 71    'มัดจำ
          msgServ.ShowMessage("${res:Global.Error.AdvanceReceiveCannotHaveBankAccount}")
          e.ProposedValue = e.Row(e.Column)
          m_updating = False
          Return
        Case 72    'โอน
          Dim ba As New BankAccount(e.ProposedValue.ToString)
          If ba.Originated Then
            e.ProposedValue = ba.Code
            e.Row("BAName") = ba.Name
            e.Row("receivei_bankacct") = ba.Id
          Else
            msgServ.ShowMessageFormatted("${res:Global.Error.BankAccountNotFound}", New String() {e.ProposedValue.ToString})
            e.ProposedValue = e.Row(e.Column)
            m_updating = False
            Return
          End If
        Case Else
          msgServ.ShowMessage("${res:Global.Error.NoReceiveType}")
          e.ProposedValue = e.Row(e.Column)
          m_updating = False
          Return
      End Select
      m_updating = False
    End Sub
    Private Function HasCash(ByVal e As DataColumnChangeEventArgs) As Boolean
      For Each row As TreeRow In Me.ItemTable.Childs
        If Not row Is e.Row Then
          If Not row.IsNull("receivei_entityType") AndAlso CInt(row("receivei_entityType")) = 0 Then
            Return True
          End If
        End If
      Next
      Return False
    End Function
    Public Sub SetEntityType(ByVal e As DataColumnChangeEventArgs)
      If m_updating Then
        Return
      End If
      m_updating = True
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      UpdateGross()
      Dim oldAmount As Decimal
      If e.Row.IsNull("receivei_amt") OrElse CStr(e.Row("receivei_amt")).Length = 0 Then
        oldAmount = 0
      Else
        oldAmount = CDec(e.Row("receivei_amt"))
      End If
      If IsNumeric(e.ProposedValue) AndAlso CInt(e.ProposedValue) = 0 Then
        If HasCash(e) Then
          msgServ.ShowMessage("${res:Global.Error.AlreadyHasCash}")
          e.ProposedValue = e.Row(e.Column)
          m_updating = False
          Return
        End If
      End If
      If e.Row.IsNull(e.Column) Then
        If IsNumeric(e.ProposedValue) AndAlso (CInt(e.ProposedValue) = 0 Or CInt(e.ProposedValue) = 72) Then
          e.Row("receivei_amt") = Configuration.FormatToString(Math.Max(Me.Amount - Me.Gross + oldAmount, 0), DigitConfig.Price)
          e.Row("RealAmount") = Configuration.FormatToString(Math.Max(Me.Amount - Me.Gross + oldAmount, 0), DigitConfig.Price)
          e.Row("DueDate") = Me.RefDoc.Date
          e.Row("Button") = "invisible"
          If CInt(e.ProposedValue) = 0 Then
            e.Row("BAButton") = "invisible"
          Else
            e.Row("BAButton") = ""
          End If
        Else
          e.Row("receivei_amt") = DBNull.Value
          e.Row("RealAmount") = DBNull.Value
          e.Row("DueDate") = Date.MinValue
          e.Row("Button") = ""
          If CInt(e.ProposedValue) = 71 Then 'Or CInt(e.ProposedValue) = 27 Then
            e.Row("BAButton") = "invisible"
          Else
            e.Row("BAButton") = ""
          End If
        End If
        m_updating = False
        Return
      End If

      If CInt(e.ProposedValue) = CInt(e.Row(e.Column)) Then
        'ผ่านโลด
        m_updating = False
        Return
      End If
      If msgServ.AskQuestion("${res:Global.Question.ChangeReceiveEntityType}") Then

        e.Row("receivei_entity") = CInt(e.ProposedValue) 'DBNull.Value
        e.Row("receivei_bankacct") = DBNull.Value
        If IsNumeric(e.ProposedValue) AndAlso (CInt(e.ProposedValue) = 0 Or CInt(e.ProposedValue) = 72) Then
          '****** + oldAmount
          e.Row("receivei_amt") = Configuration.FormatToString(Math.Max(Me.Amount - Me.Gross + oldAmount, 0), DigitConfig.Price)
          e.Row("RealAmount") = Configuration.FormatToString(Math.Max(Me.Amount - Me.Gross + oldAmount, 0), DigitConfig.Price)
          e.Row("DueDate") = Me.RefDoc.Date
          e.Row("Button") = "invisible"
          If CInt(e.ProposedValue) = 0 Then
            e.Row("BAButton") = "invisible"
          Else
            e.Row("BAButton") = ""
          End If
        Else
          e.Row("receivei_amt") = DBNull.Value
          e.Row("RealAmount") = DBNull.Value
          e.Row("DueDate") = Date.MinValue
          e.Row("Button") = ""
          If CInt(e.ProposedValue) = 71 Then 'Or CInt(e.ProposedValue) = 27 Then
            e.Row("BAButton") = "invisible"
          Else
            e.Row("BAButton") = ""
          End If
        End If
        e.Row("code") = DBNull.Value
        e.Row("receivei_bankacct") = DBNull.Value
        e.Row("BACode") = DBNull.Value
        e.Row("BAName") = DBNull.Value

        e.Row("DueDate") = Date.MinValue
      Else
        e.ProposedValue = e.Row(e.Column)
        m_updating = False
        Return
      End If
      m_updating = False
    End Sub
    Private Function DupCode(ByVal e As DataColumnChangeEventArgs) As Boolean
      If e.Row.IsNull("receivei_entityType") Then
        Return False
      End If
      If IsDBNull(e.ProposedValue) Then
        Return False
      End If
      For Each row As TreeRow In Me.ItemTable.Childs
        If Not row Is e.Row Then
          If Not row.IsNull("receivei_entityType") Then
            If CInt(row("receivei_entityType")) = CInt(e.Row("receivei_entityType")) Then
              If Not row.IsNull("code") Then
                If e.ProposedValue.ToString.ToLower = row("code").ToString.ToLower Then
                  Return True
                End If
              End If
            End If
          End If
        End If
      Next
      Return False
    End Function
    Public Sub SetCode(ByVal e As DataColumnChangeEventArgs)
      If m_updating Then
        Return
      End If
      m_updating = True
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      UpdateGross()
      Dim oldAmount As Decimal
      If e.Row.IsNull("receivei_amt") OrElse CStr(e.Row("receivei_amt")).Length = 0 Then
        oldAmount = 0
      Else
        oldAmount = CDec(e.Row("receivei_amt"))
      End If
      If e.Row.IsNull("receivei_entityType") Then
        msgServ.ShowMessage("${res:Global.Error.NoReceiveType}")
        e.ProposedValue = e.Row(e.Column)
        m_updating = False
        Return
      End If
      If DupCode(e) Then
        Dim item As New ReceiveItem
        item.Receive = Me
        item.CopyFromDataRow(CType(e.Row, TreeRow))
        msgServ.ShowMessageFormatted("${res:Global.Error.AlreadyHasCode}", New String() {item.EntityType.Description, e.ProposedValue.ToString})
        e.ProposedValue = e.Row(e.Column)
        m_updating = False
        Return
      End If
      Select Case CInt(e.Row("receivei_entityType"))
        Case 0     'สด
          msgServ.ShowMessage("${res:Global.Error.CashCannotHaveCode}")
          e.ProposedValue = e.Row(e.Column)
          m_updating = False
          Return
        Case 27    'เช็ครับ
          If e.ProposedValue.ToString.Length = 0 Then
            If e.Row(e.Column).ToString.Length <> 0 Then
              If msgServ.AskQuestionFormatted("${res:Global.Question.DeleteIncomingingCheckDetail}", New String() {e.Row(e.Column).ToString}) Then
                e.Row("receivei_entity") = DBNull.Value
                e.Row("receivei_bankacct") = DBNull.Value
                e.Row("RealAmount") = DBNull.Value
                e.Row("receivei_amt") = DBNull.Value
                e.Row("receivei_bankacct") = DBNull.Value
                e.Row("BACode") = DBNull.Value
                e.Row("BAName") = DBNull.Value
                e.Row("DueDate") = Date.MinValue
              Else
                e.ProposedValue = e.Row(e.Column)
              End If
            End If
            m_updating = False
            Return
          End If
          Dim check As New IncomingCheck(e.ProposedValue.ToString)
          If Not check.Originated Then
            If msgServ.AskQuestionFormatted("${res:Global.Question.CreateNewIncomingCheck}", New String() {e.ProposedValue.ToString}) Then
              e.Row("receivei_entity") = 0
              e.Row("receivei_bankacct") = DBNull.Value
              e.Row("RealAmount") = Configuration.FormatToString(Math.Max(Me.Amount - Me.Gross + oldAmount, 0), DigitConfig.Price)
              e.Row("receivei_amt") = Configuration.FormatToString(Math.Max(Me.Amount - Me.Gross + oldAmount, 0), DigitConfig.Price)
              e.Row("receivei_bankacct") = DBNull.Value
              e.Row("BACode") = DBNull.Value
              e.Row("BAName") = DBNull.Value
              e.Row("DueDate") = Me.RefDoc.Date
            Else
              e.ProposedValue = e.Row(e.Column)
              m_updating = False
              Return
            End If
          Else
            If check.Customer.Id <> Me.RefDoc.Payer.Id Then
              msgServ.ShowMessageFormatted("${res:Global.Error.CheckReceivedFromOther}", New String() {e.ProposedValue.ToString, Me.RefDoc.Payer.Name})
              e.ProposedValue = e.Row(e.Column)
              m_updating = False
              Return
            End If
            If check.DocStatus.Value = 0 Then
              msgServ.ShowMessageFormatted("${res:Global.Error.CheckIsCanceled}", New String() {e.ProposedValue.ToString})
              e.ProposedValue = e.Row(e.Column)
              m_updating = False
              Return
            End If
            Dim remain As Decimal = check.GetRemainingAmount(Me.Id)
            If remain <= 0 Then
              msgServ.ShowMessageFormatted("${res:Global.Error.ZeroOrLessCheckAmount}", New String() {e.ProposedValue.ToString})
              e.ProposedValue = e.Row(e.Column)
              m_updating = False
              Return
            End If
            e.ProposedValue = check.CqCode
            If DupCode(e) Then
              Dim item As New ReceiveItem
              item.Receive = Me
              item.CopyFromDataRow(CType(e.Row, TreeRow))
              msgServ.ShowMessageFormatted("${res:Global.Error.AlreadyHasCode}", New String() {item.EntityType.Description, e.ProposedValue.ToString})
              e.ProposedValue = e.Row(e.Column)
              m_updating = False
              Return
            End If
            e.Row("receivei_entity") = check.Id
            e.Row("RealAmount") = Configuration.FormatToString(check.Amount, DigitConfig.Price)
            e.Row("receivei_amt") = Configuration.FormatToString(Math.Max(Math.Min(Me.Amount - Me.Gross + oldAmount, remain), 0), DigitConfig.Price)
            e.Row("receivei_bankacct") = DBNull.Value
            e.Row("BACode") = DBNull.Value
            e.Row("BAName") = DBNull.Value
            e.Row("DueDate") = check.DueDate
          End If
        Case 71    'มัดจำ
          If e.ProposedValue.ToString.Length = 0 Then
            If e.Row(e.Column).ToString.Length <> 0 Then
              If msgServ.AskQuestionFormatted("${res:Global.Question.DeleteAdvanceReceiveDetail}", New String() {e.Row(e.Column).ToString}) Then
                e.Row("receivei_entity") = DBNull.Value
                e.Row("receivei_bankacct") = DBNull.Value
                e.Row("RealAmount") = DBNull.Value
                e.Row("receivei_amt") = DBNull.Value
                e.Row("receivei_bankacct") = DBNull.Value
                e.Row("BACode") = DBNull.Value
                e.Row("BAName") = DBNull.Value
                e.Row("DueDate") = Date.MinValue
              Else
                e.ProposedValue = e.Row(e.Column)
              End If
            End If
            m_updating = False
            Return
          End If
          Dim avr As New AdvanceReceive(e.ProposedValue.ToString)
          If Not avr.Originated Then
            msgServ.ShowMessageFormatted("${res:Global.Error.NoAdvanceReceive}", New String() {e.ProposedValue.ToString})
            e.ProposedValue = e.Row(e.Column)
            m_updating = False
            Return
          Else
            If avr.Status.Value = 0 Then
              msgServ.ShowMessageFormatted("${res:Global.Error.AdvanceReceiveIsCanceled}", New String() {e.ProposedValue.ToString})
              e.ProposedValue = e.Row(e.Column)
              m_updating = False
              Return
            End If
            Dim remain As Decimal = avr.GetRemainingAmount(Me.Id)
            If remain <= 0 Then
              msgServ.ShowMessageFormatted("${res:Global.Error.ZeroOrLessAdvanceReceiveAmount}", New String() {e.ProposedValue.ToString})
              e.ProposedValue = e.Row(e.Column)
              m_updating = False
              Return
            End If
            e.Row("receivei_entity") = avr.Id
            e.ProposedValue = avr.Code
            'e.Row("RealAmount") = Configuration.FormatToString(avr.AfterTax, DigitConfig.Price)
            e.Row("RealAmount") = Configuration.FormatToString(avr.GetRemainingAmount, DigitConfig.Price)
            e.Row("receivei_amt") = Configuration.FormatToString(Math.Max(Math.Min(Me.Amount - Me.Gross + oldAmount, remain), 0), DigitConfig.Price)
            e.Row("receivei_bankacct") = DBNull.Value
            e.Row("BACode") = DBNull.Value
            e.Row("BAName") = DBNull.Value
            e.Row("DueDate") = avr.DocDate
          End If
        Case 72    'โอน
          msgServ.ShowMessage("${res:Global.Error.BankTransferInCannotHaveCode}")
          e.ProposedValue = e.Row(e.Column)
          m_updating = False
          Return
        Case Else
          msgServ.ShowMessage("${res:Global.Error.NoReceiveType}")
          e.ProposedValue = e.Row(e.Column)
          m_updating = False
          Return
      End Select
      m_updating = False
    End Sub
    Private Sub ItemAdded(ByVal sender As Object, ByVal e As ITemAddedEventArgs)
      Try
        If Not Me.IsInitialized Then
          Return
        End If
        Dim pe As New PropertyChangedEventArgs("ItemChanged", "", "")
        Me.OnPropertyChanged(Me, pe)
        e.Row.SetColumnError("Code", "")
      Catch ex As Exception
        MessageBox.Show(ex.ToString)
      End Try
    End Sub
    Private Sub ItemDelete(ByVal sender As Object, ByVal e As System.Data.DataRowChangeEventArgs)
    End Sub
#End Region

#Region "Shared AccTable"
    Public Shared Function GetDebitCreditSchemaTable() As TreeTable
      Dim myDatatable As New TreeTable("OtherReceive")
      myDatatable.Columns.Add(New DataColumn("Linenumber", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("Code", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Button", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Name", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("receivea_amt", GetType(String)))
      Return myDatatable
    End Function
#End Region

#Region "GetJournalEntries"
    Public Function GetJournalEntries() As JournalEntryItemCollection
      Dim jiColl As New JournalEntryItemCollection

      'ดอกเบี้ย
      Dim ji As JournalEntryItem
      If Me.Interest > 0 Then
        ji = New JournalEntryItem
        ji.Mapping = "RV1.7"
        ji.Amount = Me.Interest
        If Me.CostCenter.Originated Then
          ji.CostCenter = Me.CostCenter
        Else
          ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
        End If
        jiColl.Add(ji)
      End If

      'รายจ่ายอื่นๆ
      If Me.OtherExpense > 0 Then
        ji = New JournalEntryItem
        ji.Mapping = "RV1.5"
        ji.Amount = Me.OtherExpense
        If Me.CostCenter.Originated Then
          ji.CostCenter = Me.CostCenter
        Else
          ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
        End If
        jiColl.Add(ji)
      End If

      If Me.CreditCollection.Count > 0 Then
        For Each item As ReceiveAccountItem In Me.CreditCollection
          ji = New JournalEntryItem
          ji.Mapping = "Through"
          ji.Amount = item.Amount
          ji.Account = item.Account
          ji.IsDebit = True
          ji.Note = StringParserService.Parse("${res:Global.OtherCredit}")
          If Me.CostCenter.Originated Then
            ji.CostCenter = Me.CostCenter
          Else
            ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
          End If
          jiColl.Add(ji)
        Next
      End If

      'ค่าธรรมเนียมธนาคาร
      If Me.BankCharge > 0 Then
        ji = New JournalEntryItem
        ji.Mapping = "RV1.6"
        ji.Amount = Me.BankCharge
        If Me.CostCenter.Originated Then
          ji.CostCenter = Me.CostCenter
        Else
          ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
        End If
        jiColl.Add(ji)
      End If

      'รายได้อื่นๆ
      If Me.OtherRevenue > 0 Then
        ji = New JournalEntryItem
        ji.Mapping = "RV1.8"
        ji.Amount = Me.OtherRevenue
        If Me.CostCenter.Originated Then
          ji.CostCenter = Me.CostCenter
        Else
          ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
        End If
        jiColl.Add(ji)
      End If

      If Me.DebitCollection.Count > 0 Then
        'Undone
        For Each item As ReceiveAccountItem In Me.DebitCollection
          ji = New JournalEntryItem
          ji.Mapping = "Through"
          ji.Amount = item.Amount
          ji.Account = item.Account
          ji.IsDebit = False
          ji.Note = StringParserService.Parse("${res:Global.OtherDebit}")
          If Me.CostCenter.Originated Then
            ji.CostCenter = Me.CostCenter
          Else
            ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
          End If
          jiColl.Add(ji)
        Next
      End If

      'ส่วนลดรับ
      If Me.DiscountAmount > 0 Then
        ji = New JournalEntryItem
        ji.Mapping = "RV1.4"
        ji.Amount = Me.DiscountAmount
        If Me.CostCenter.Originated Then
          ji.CostCenter = Me.CostCenter
        Else
          ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
        End If
        jiColl.Add(ji)
      End If

      jiColl.AddRange(GetCashCheckJournalEntries)
      jiColl.AddRange(GetBankTransferJournalEntries)
      Return jiColl
    End Function
    Private Function GetCashCheckJournalEntries() As JournalEntryItemCollection
      Dim jiColl As New JournalEntryItemCollection
      Dim sumCheck As Decimal = 0
      Dim sumCash As Decimal = 0
      Dim sumAvr As Decimal = 0
      For i As Integer = 0 To Me.MaxRowIndex
        If Not Me.ItemTable.Childs(i).IsNull("receivei_entityType") _
        AndAlso IsNumeric(Me.ItemTable.Childs(i)("receivei_entityType")) _
        Then
          If Not Me.ItemTable.Childs(i).IsNull(("receivei_amt")) AndAlso IsNumeric(Me.ItemTable.Childs(i)("receivei_amt")) Then
            Select Case CInt(Me.ItemTable.Childs(i)("receivei_entityType"))
              Case 27       'Check
                sumCheck += CDec(Me.ItemTable.Childs(i)(("receivei_amt")))
              Case 0        'Cash
                sumCash += CDec(Me.ItemTable.Childs(i)(("receivei_amt")))
              Case 71       'AdvanceReceive
                sumAvr += CDec(Me.ItemTable.Childs(i)(("receivei_amt")))
            End Select
          End If
        End If
      Next
      Dim ji As JournalEntryItem
      If sumCash > 0 Then
        ji = New JournalEntryItem
        ji.Mapping = "RV1.1"
        ji.Amount = sumCash
        If Me.CostCenter.Originated Then
          ji.CostCenter = Me.CostCenter
        Else
          ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
        End If
        jiColl.Add(ji)
      End If
      If sumCheck > 0 Then
        ji = New JournalEntryItem
        ji.Mapping = "RV1.2"
        ji.Amount = sumCheck
        If Me.CostCenter.Originated Then
          ji.CostCenter = Me.CostCenter
        Else
          ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
        End If
        jiColl.Add(ji)
      End If
      If sumAvr > 0 Then
        ji = New JournalEntryItem
        ji.Mapping = "RV1.9"
        ji.Amount = sumAvr
        If Me.CostCenter.Originated Then
          ji.CostCenter = Me.CostCenter
        Else
          ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
        End If
        jiColl.Add(ji)
      End If
      Return jiColl
    End Function
    Private Function GetBankTransferJournalEntries() As JournalEntryItemCollection
      Dim jiColl As New JournalEntryItemCollection
      Dim ji As New JournalEntryItem
      For i As Integer = 0 To Me.MaxRowIndex
        If Not Me.ItemTable.Childs(i).IsNull("receivei_entityType") _
        AndAlso IsNumeric(Me.ItemTable.Childs(i)("receivei_entityType")) _
        AndAlso CInt(Me.ItemTable.Childs(i)("receivei_entityType")) = 72 Then
          Dim item As New ReceiveItem
          item.CopyFromDataRow(Me.ItemTable.Childs(i))
          Dim bto As BankTransferIn = CType(item.Entity, BankTransferIn)
          If Not bto Is Nothing AndAlso Not bto.BankAccount Is Nothing _
          AndAlso Not bto.BankAccount.Account Is Nothing AndAlso bto.BankAccount.Account.Originated Then
            Dim matched As Boolean = False
            For Each addedJi As JournalEntryItem In jiColl
              If addedJi.Account.Id = bto.BankAccount.Account.Id And addedJi.Mapping = "RV1.3" Then
                'เจอ Account เดียวกัน
                addedJi.Amount += item.Amount
                matched = True
              End If
            Next
            If Not matched Then
              ji = New JournalEntryItem
              ji.Account = bto.BankAccount.Account
              ji.Mapping = "RV1.3"
              ji.Amount = item.Amount
              If Me.CostCenter.Originated Then
                ji.CostCenter = Me.CostCenter
              Else
                ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
              End If
              jiColl.Add(ji)
            End If
          End If
        End If
      Next
      Return jiColl
    End Function
    ' Define Owner costcenter
    Public Function GetJournalEntries(ByVal CCOwner As CostCenter) As JournalEntryItemCollection
      Dim jiColl As New JournalEntryItemCollection

      'ดอกเบี้ย
      If Not CCOwner Is Nothing AndAlso Not CCOwner.Originated Then
        CCOwner = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
      End If
      Dim ji As JournalEntryItem
      If Me.Interest > 0 Then
        ji = New JournalEntryItem
        ji.Mapping = "RV1.7"
        ji.Amount = Me.Interest
        ji.CostCenter = CCOwner
        jiColl.Add(ji)
      End If

      'รายจ่ายอื่นๆ
      If Me.OtherExpense > 0 Then
        ji = New JournalEntryItem
        ji.Mapping = "RV1.5"
        ji.Amount = Me.OtherExpense
        ji.CostCenter = CCOwner
        jiColl.Add(ji)
      End If


      'ค่าธรรมเนียมธนาคาร
      If Me.BankCharge > 0 Then
        ji = New JournalEntryItem
        ji.Mapping = "RV1.6"
        ji.Amount = Me.BankCharge
        ji.CostCenter = CCOwner
        jiColl.Add(ji)
      End If

      'รายได้อื่นๆ
      If Me.OtherRevenue > 0 Then
        ji = New JournalEntryItem
        ji.Mapping = "RV1.8"
        ji.Amount = Me.OtherRevenue
        ji.CostCenter = CCOwner
        jiColl.Add(ji)
      End If

      'ส่วนลดรับ
      If Me.DiscountAmount > 0 Then
        ji = New JournalEntryItem
        ji.Mapping = "RV1.4"
        ji.Amount = Me.DiscountAmount
        ji.CostCenter = CCOwner
        jiColl.Add(ji)
      End If

      jiColl.AddRange(GetCashCheckJournalEntries(CCOwner))
      jiColl.AddRange(GetBankTransferJournalEntries(CCOwner))
      Return jiColl
    End Function
    Private Function GetCashCheckJournalEntries(ByVal CCOwner As CostCenter) As JournalEntryItemCollection
      If Not CCOwner Is Nothing AndAlso Not CCOwner.Originated Then
        CCOwner = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
      End If
      Dim jiColl As New JournalEntryItemCollection
      Dim sumCheck As Decimal = 0
      Dim sumCash As Decimal = 0
      Dim sumAvr As Decimal = 0
      For i As Integer = 0 To Me.MaxRowIndex
        If Not Me.ItemTable.Childs(i).IsNull("receivei_entityType") _
        AndAlso IsNumeric(Me.ItemTable.Childs(i)("receivei_entityType")) _
        Then
          If Not Me.ItemTable.Childs(i).IsNull(("receivei_amt")) AndAlso IsNumeric(Me.ItemTable.Childs(i)("receivei_amt")) Then
            Select Case CInt(Me.ItemTable.Childs(i)("receivei_entityType"))
              Case 27       'Check
                sumCheck += CDec(Me.ItemTable.Childs(i)(("receivei_amt")))
              Case 0        'Cash
                sumCash += CDec(Me.ItemTable.Childs(i)(("receivei_amt")))
              Case 71       'AdvanceReceive
                sumAvr += CDec(Me.ItemTable.Childs(i)(("receivei_amt")))
            End Select
          End If
        End If
      Next
      Dim ji As JournalEntryItem
      If sumCash > 0 Then
        ji = New JournalEntryItem
        ji.Mapping = "RV1.1"
        ji.Amount = sumCash
        ji.CostCenter = CCOwner
        jiColl.Add(ji)
      End If
      If sumCheck > 0 Then
        ji = New JournalEntryItem
        ji.Mapping = "RV1.2"
        ji.Amount = sumCheck
        ji.CostCenter = CCOwner
        jiColl.Add(ji)
      End If
      If sumAvr > 0 Then
        ji = New JournalEntryItem
        ji.Mapping = "RV1.9"
        ji.Amount = sumAvr
        ji.CostCenter = CCOwner
        jiColl.Add(ji)
      End If
      Return jiColl
    End Function
    Private Function GetBankTransferJournalEntries(ByVal CCOwner As CostCenter) As JournalEntryItemCollection
      If Not CCOwner Is Nothing AndAlso Not CCOwner.Originated Then
        CCOwner = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
      End If
      Dim jiColl As New JournalEntryItemCollection
      Dim ji As New JournalEntryItem
      For i As Integer = 0 To Me.MaxRowIndex
        If Not Me.ItemTable.Childs(i).IsNull("receivei_entityType") _
        AndAlso IsNumeric(Me.ItemTable.Childs(i)("receivei_entityType")) _
        AndAlso CInt(Me.ItemTable.Childs(i)("receivei_entityType")) = 72 Then
          Dim item As New ReceiveItem
          item.CopyFromDataRow(Me.ItemTable.Childs(i))
          Dim bto As BankTransferIn = CType(item.Entity, BankTransferIn)
          If Not bto Is Nothing AndAlso Not bto.BankAccount Is Nothing _
          AndAlso Not bto.BankAccount.Account Is Nothing AndAlso bto.BankAccount.Account.Originated Then
            Dim matched As Boolean = False
            For Each addedJi As JournalEntryItem In jiColl
              If addedJi.Account.Id = bto.BankAccount.Account.Id And addedJi.Mapping = "RV1.3" Then
                'เจอ Account เดียวกัน
                addedJi.Amount += item.Amount
                matched = True
              End If
            Next
            If Not matched Then
              ji = New JournalEntryItem
              ji.Account = bto.BankAccount.Account
              ji.Mapping = "RV1.3"
              ji.Amount = item.Amount
              ji.CostCenter = CCOwner
              jiColl.Add(ji)
            End If
          End If
        End If
      Next
      Return jiColl
    End Function
#End Region

#Region "IPrintableEntity"
    Public Function GetDefaultFormPath() As String Implements IPrintableEntity.GetDefaultFormPath
      Return "C:\Documents and Settings\Administrator\Desktop\Forms\Documents\PV.dfm"
    End Function
    Public Function GetDefaultForm() As String Implements IPrintableEntity.GetDefaultForm
      Return "RV"
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

      'DocDate
      dpi = New DocPrintingItem
      dpi.Mapping = "DocDate"
      dpi.Value = Me.DocDate.ToShortDateString
      dpi.DataType = "System.DateTime"
      dpiColl.Add(dpi)

      'RefCode
      dpi = New DocPrintingItem
      dpi.Mapping = "RefCode"
      dpi.Value = Me.RefDoc.Code
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'RefDocDate
      dpi = New DocPrintingItem
      dpi.Mapping = "RefDocDate"
      dpi.Value = Me.RefDoc.Date.ToShortDateString
      dpi.DataType = "System.DateTime"
      dpiColl.Add(dpi)

      'Note
      dpi = New DocPrintingItem
      dpi.Mapping = "Note"
      dpi.Value = Me.Note
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      If Not Me.RefDoc.Payer Is Nothing Then
        'Customer
        dpi = New DocPrintingItem
        dpi.Mapping = "Customer"
        dpi.Value = Me.RefDoc.Payer.Code & ":" & Me.RefDoc.Payer.Name
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'CustomerCode
        dpi = New DocPrintingItem
        dpi.Mapping = "CustomerCode"
        dpi.Value = Me.RefDoc.Payer.Code
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'CustomerName
        dpi = New DocPrintingItem
        dpi.Mapping = "CustomerName"
        dpi.Value = Me.RefDoc.Payer.Name
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'CustomerAddress
        dpi = New DocPrintingItem
        dpi.Mapping = "CustomerAddress"
        dpi.Value = Me.RefDoc.Payer.BillingAddress
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'CustomerCurrentAddress
        dpi = New DocPrintingItem
        dpi.Mapping = "CustomerCurrentAddress"
        dpi.Value = Me.RefDoc.Payer.Address
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)
      End If

      If TypeOf (Me.RefDoc) Is AdvanceMoneyClosed Then
        Dim advmc As AdvanceMoneyClosed = CType(Me.RefDoc, AdvanceMoneyClosed)

        'Employee Code
        dpi = New DocPrintingItem
        dpi.Mapping = "RefEmployeeCode"
        dpi.Value = advmc.AdvanceMoney.Employee.Code
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'Employee Name
        dpi = New DocPrintingItem
        dpi.Mapping = "RefEmployeeName"
        dpi.Value = advmc.AdvanceMoney.Employee.Name
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'Employee 
        dpi = New DocPrintingItem
        dpi.Mapping = "RefEmployeeInfo"
        dpi.Value = advmc.AdvanceMoney.Employee.Code & ":" & advmc.AdvanceMoney.Employee.Name
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'Cost center
        dpi = New DocPrintingItem
        dpi.Mapping = "RefCostCenterInfo"
        dpi.Value = advmc.AdvanceMoney.Costcenter.Code & ":" & advmc.AdvanceMoney.Costcenter.Name
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'Note
        dpi = New DocPrintingItem
        dpi.Mapping = "RefNote"
        dpi.Value = advmc.Note
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'Amount
        dpi = New DocPrintingItem
        dpi.Mapping = "Amount"
        dpi.Value = Configuration.FormatToString(Me.Amount, DigitConfig.Price)
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'RemainingAmount
        dpi = New DocPrintingItem
        dpi.Mapping = "RemainingAmount"
        dpi.Value = Configuration.FormatToString(Me.Amount - Me.Gross, DigitConfig.Price)
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'ReceiveGrossAmount
        dpi = New DocPrintingItem
        dpi.Mapping = "ReceiveGrossAmount"
        dpi.Value = Configuration.FormatToString(Me.Gross, DigitConfig.Price)
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'OtherCutReceiveAmount
        dpi = New DocPrintingItem
        dpi.Mapping = "OtherCutReceiveAmount"
        dpi.Value = Configuration.FormatToString(Me.DebitAmount, DigitConfig.UnitPrice)
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)
      End If

      Dim TotalCash As Decimal = 0
      Dim TotalPettyCash As Decimal = 0
      Dim TotalAdvancePay As Decimal = 0
      Dim TotalCheck As Decimal = 0
      Dim TotalTransferIn As Decimal = 0
      Dim CheckCode As String = ""
      Dim BankName As String = ""
      For tableType As Integer = 0 To 2
        'tableType 0 = เฉพาะเช็ค
        'tableType 1 = เฉพาะโอน
        'tableType 2 = ทั้งหมด

        Dim tableName As String
        Select Case tableType
          Case 0
            tableName = "ReceiveItem"
          Case 1
            tableName = "ReceiveItemBTI"       'BTI = Bank Transfer In
          Case 2
            tableName = "ReceiveItemAll"
        End Select

        Dim n As Integer = 0
        For i As Integer = 0 To Me.MaxRowIndex
          Dim itemRow As TreeRow = CType(Me.m_itemTable.Rows(i), TreeRow)
          If ValidateRow(itemRow) Then
            Dim item As New ReceiveItem
            item.CopyFromDataRow(itemRow)

            Dim entityType As Integer = item.EntityType.Value
            'ReceiveItem.LineNumber
            dpi = New DocPrintingItem
            dpi.Mapping = "ReceiveItem.LineNumber"
            dpi.Value = n + 1
            dpi.DataType = "System.Int32"
            dpi.Row = n + 1
            dpi.Table = tableName
            dpiColl.Add(dpi)



            Dim itIsCheck As Boolean = (TypeOf item.Entity Is IncomingCheck)
            Dim itIsBto As Boolean = (TypeOf item.Entity Is BankTransferIn)
            Dim itIsCash As Boolean = (TypeOf item.Entity Is CashItem)
            Dim itIsPC As Boolean = (TypeOf item.Entity Is PettyCash)
            Dim itIsADVP As Boolean = (TypeOf item.Entity Is AdvancePay)
            Dim btf As BankTransferIn
            If itIsCheck Then
              If CheckCode Is Nothing OrElse CheckCode.Length = 0 Then
                CheckCode = CType(item.Entity, IncomingCheck).CqCode
              End If
            End If

            If (itIsCheck And tableType = 0) _
             Or (itIsBto And tableType = 1) _
             Or (itIsCheck Or itIsBto) And tableType = 2 _
             Then
              If itIsCheck Then
                'ReceiveItem.DueDate
                dpi = New DocPrintingItem
                dpi.Mapping = tableName & ".DueDate"
                dpi.Value = CType(item.Entity, IncomingCheck).DueDate.ToShortDateString
                dpi.DataType = "System.DateTime"
                dpi.Row = n + 1
                dpi.Table = tableName
                dpiColl.Add(dpi)

                'ReceiveItem.CustBankName
                dpi = New DocPrintingItem
                dpi.Mapping = tableName & ".CustBankName"
                dpi.Value = CType(item.Entity, IncomingCheck).Bank.Name
                dpi.DataType = "System.String"
                dpi.Row = n + 1
                dpi.Table = tableName
                dpiColl.Add(dpi)

                'ReceiveItem.CustBankBranch
                dpi = New DocPrintingItem
                dpi.Mapping = tableName & ".CustBankBranch"
                dpi.Value = CType(item.Entity, IncomingCheck).CustBankBranch
                dpi.DataType = "System.String"
                dpi.Row = n + 1
                dpi.Table = tableName
                dpiColl.Add(dpi)

              End If


              'ReceiveItem.CqCode
              dpi = New DocPrintingItem
              dpi.Mapping = tableName & ".CqCode"
              If itIsCheck Then
                dpi.Value = CType(item.Entity, IncomingCheck).CqCode
              Else
                dpi.Value = item.Entity.Code
              End If
              dpi.DataType = "System.String"
              dpi.Row = n + 1
              dpi.Table = tableName
              dpiColl.Add(dpi)

              'ReceiveItem.Note
              dpi = New DocPrintingItem
              dpi.Mapping = tableName & ".Note"
              If itemRow.IsNull("receivei_note") Then
                dpi.Value = ""
              Else
                dpi.Value = itemRow("receivei_note")
              End If

              dpi.DataType = "System.String"
              dpi.Row = n + 1
              dpi.Table = tableName
              dpiColl.Add(dpi)

              If TypeOf item.Entity Is IHasAmount Then
                'ReceiveItem.Amount
                dpi = New DocPrintingItem
                dpi.Mapping = tableName & ".Amount"
                dpi.Value = Configuration.FormatToString(CType(item.Entity, IHasAmount).Amount, DigitConfig.Price)
                dpi.DataType = "System.Decimal"
                dpi.Row = n + 1
                dpi.Table = tableName
                dpiColl.Add(dpi)
              End If

              Dim hasBankAccount As IHasBankAccount
              Dim bankAcct As BankAccount             '= hasBankAccount.BankAccount
              Dim bankBranch As BankBranch
              Dim bank As Bank

              If TypeOf item.Entity Is IHasBankAccount Then
                hasBankAccount = CType(item.Entity, IHasBankAccount)
                bankAcct = hasBankAccount.BankAccount
              End If

              If itIsCheck Then
                bankAcct = CType(item.Entity, IncomingCheck).DepositBankAccount
              End If

              If Not bankAcct Is Nothing Then
                'ReceiveItem.BankAccount
                dpi = New DocPrintingItem
                dpi.Mapping = tableName & ".BankAccountName"
                dpi.Value = bankAcct.Name
                dpi.DataType = "System.String"
                dpi.Row = n + 1
                dpi.Table = tableName
                dpiColl.Add(dpi)

                'ReceiveItem.BankAccountCode
                dpi = New DocPrintingItem
                dpi.Mapping = tableName & ".BankAccountCode"
                dpi.Value = bankAcct.BankCode
                dpi.DataType = "System.String"
                dpi.Row = n + 1
                dpi.Table = tableName
                dpiColl.Add(dpi)

                bankBranch = bankAcct.BankBranch
                If Not bankBranch Is Nothing Then
                  'ReceiveItem.BankBranchName
                  dpi = New DocPrintingItem
                  dpi.Mapping = tableName & ".BankBranchName"
                  dpi.Value = bankBranch.Name
                  dpi.DataType = "System.String"
                  dpi.Row = n + 1
                  dpi.Table = tableName
                  dpiColl.Add(dpi)

                  bank = bankBranch.Bank
                  If Not bank Is Nothing Then
                    'ReceiveItem.BankName
                    dpi = New DocPrintingItem
                    dpi.Mapping = tableName & ".BankName"
                    dpi.Value = bank.Name
                    dpi.DataType = "System.String"
                    dpi.Row = n + 1
                    dpi.Table = tableName
                    dpiColl.Add(dpi)
                  End If
                End If
              End If

              If itIsBto Then
                Dim bti As BankTransferIn = CType(item.Entity, BankTransferIn)
                If Not bti Is Nothing Then
                  'ReceiveItem.BankName
                  dpi = New DocPrintingItem
                  dpi.Mapping = tableName & ".TransferDate"
                  dpi.Value = bti.DocDate.ToShortDateString
                  dpi.DataType = "System.String"
                  dpi.Row = n + 1
                  dpi.Table = tableName
                  dpiColl.Add(dpi)
                End If
              End If


              n += 1

            End If

            If tableType = 0 Then
              If itIsCheck Then
                TotalCheck += item.Amount
              ElseIf itIsBto Then
                TotalTransferIn += item.Amount
              ElseIf itIsCash Then
                TotalCash += item.Amount
              ElseIf itIsPC Then
                TotalPettyCash += item.Amount
              ElseIf itIsADVP Then
                TotalAdvancePay += item.Amount
              End If
            End If
          End If
        Next
      Next
      For i As Integer = 0 To Me.MaxRowIndex
        Dim itemRow2 As TreeRow = CType(Me.m_itemTable.Rows(i), TreeRow)
        If ValidateRow(itemRow2) Then
          Dim item As New ReceiveItem
          item.CopyFromDataRow(itemRow2)
          Dim itIsCash As Boolean = (TypeOf item.Entity Is CashItem)
          If itIsCash Then
            'ReceiveItem.Note
            dpi = New DocPrintingItem
            dpi.Mapping = "CashNote"
            If itemRow2.IsNull("receivei_note") Then
              dpi.Value = ""
            Else
              dpi.Value = itemRow2("receivei_note")
            End If
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)
          End If
        End If
      Next

      Dim totalOtherCutReceive As Decimal
      totalOtherCutReceive = Me.DiscountAmount + Me.BankCharge + Me.OtherExpense + Me.WitholdingTax + Me.CreditCollection.GetAmount
      'totalOtherCutReceive
      dpi = New DocPrintingItem
      dpi.Mapping = "TotalOtherCutReceive"
      dpi.Value = Configuration.FormatToString(totalOtherCutReceive, DigitConfig.Price)
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      Dim totalOtherReceive As Decimal
      totalOtherReceive = Me.Interest + Me.OtherRevenue + Me.DebitCollection.GetAmount
      'totalOtherReceive
      dpi = New DocPrintingItem
      dpi.Mapping = "TotalOtherReceive"
      dpi.Value = Configuration.FormatToString(totalOtherReceive, DigitConfig.Price)
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'DiscountAmount
      dpi = New DocPrintingItem
      dpi.Mapping = "DiscountAmount"
      dpi.Value = Configuration.FormatToString(Me.DiscountAmount, DigitConfig.Price)
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'TotalCash
      dpi = New DocPrintingItem
      dpi.Mapping = "TotalCash"
      dpi.Value = Configuration.FormatToString(TotalCash, DigitConfig.Price)
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'TotalPettyCash
      dpi = New DocPrintingItem
      dpi.Mapping = "TotalPettyCash"
      dpi.Value = Configuration.FormatToString(TotalPettyCash, DigitConfig.Price)
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'TotalAdvancePay
      dpi = New DocPrintingItem
      dpi.Mapping = "TotalAdvancePay"
      dpi.Value = Configuration.FormatToString(TotalAdvancePay, DigitConfig.Price)
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'TotalCheck
      dpi = New DocPrintingItem
      dpi.Mapping = "TotalCheck"
      dpi.Value = Configuration.FormatToString(TotalCheck, DigitConfig.Price)
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'CheckCode
      dpi = New DocPrintingItem
      dpi.Mapping = "CheckCode"
      dpi.Value = CheckCode
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'TotalTransferIn
      dpi = New DocPrintingItem
      dpi.Mapping = "TotalTransferIn"
      dpi.Value = Configuration.FormatToString(TotalTransferIn, DigitConfig.Price)
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'Gross
      dpi = New DocPrintingItem
      dpi.Mapping = "Gross"
      dpi.Value = Configuration.FormatToString(Me.Gross, DigitConfig.Price)
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      dpiColl.AddRange(GetGLDocPrintingEntries)
      dpiColl.AddRange(GetGoodsSoldDocPrintingEntries)
      dpiColl.AddRange(GetReceiveSelectionDocPrintingEntries)
      dpiColl.AddRange(GetPurchaseCNDocPrintingEntries)
      dpiColl.AddRange(GetPrettyCashClosedDocPrintingEntries)

      Return dpiColl
    End Function
    Private Function GetGLDocPrintingEntries() As DocPrintingItemCollection
      Dim dpiColl As New DocPrintingItemCollection
      Dim dpi As DocPrintingItem
      Dim SumCredit As Decimal = 0
      Dim SumDebit As Decimal = 0
      If TypeOf Me.RefDoc Is IGLAble Then
        Dim je As JournalEntry = CType(Me.RefDoc, IGLAble).JournalEntry
        If Not je Is Nothing Then

          'AccountBook
          dpi = New DocPrintingItem
          dpi.Mapping = "AccountBook"
          If Not je.AccountBook Is Nothing Then
            dpi.Value = je.AccountBook.Name
          End If
          dpi.DataType = "System.String"
          dpiColl.Add(dpi)

          'JournalName
          dpi = New DocPrintingItem
          dpi.Mapping = "JournalName"
          dpi.Value = je.AccountBook.TitleName
          dpi.DataType = "System.String"
          dpiColl.Add(dpi)

          Dim n As Integer = 0
          For Each item As JournalEntryItem In je.ItemCollection
            'Item.LineNumber
            dpi = New DocPrintingItem
            dpi.Mapping = "Item.LineNumber"
            dpi.Value = n + 1
            dpi.DataType = "System.Int32"
            dpi.Row = n + 1
            dpi.Table = "Item"
            dpiColl.Add(dpi)

            'Item.AccountCode
            dpi = New DocPrintingItem
            dpi.Mapping = "Item.AccountCode"
            If Not item.Account Is Nothing Then
              dpi.Value = item.Account.Code
            Else
              dpi.Value = ""
            End If
            dpi.DataType = "System.String"
            dpi.Row = n + 1
            dpi.Table = "Item"
            dpiColl.Add(dpi)

            Dim amt As String = Configuration.FormatToString(item.Amount, DigitConfig.Price)
            Dim Bfpoint As String = Trim(Split(Replace(amt, ",", ""), ".")(0))
            Dim Aftpoint As String = "00"
            If UBound(Split(amt, "."), 1) <> 0 Then
              Aftpoint = Left(Trim(Split(amt, ".")(1)), 2)
            End If
            amt = Configuration.FormatToString(item.Amount, DigitConfig.Price)
            Bfpoint = Trim(Split(Replace(amt, ",", ""), ".")(0))
            Aftpoint = "00"
            If UBound(Split(amt, "."), 1) <> 0 Then
              Aftpoint = Left(Trim(Split(amt, ".")(1)), 2)
            End If
            Dim space As String = ""
            If item.IsDebit Then
              'Item.Debit
              dpi = New DocPrintingItem
              dpi.Mapping = "Item.Debit"
              dpi.Value = Configuration.FormatToString(item.Amount, DigitConfig.Price)
              SumDebit += item.Amount
              dpi.DataType = "System.Decimal"
              dpi.Row = n + 1
              dpi.Table = "Item"
              dpiColl.Add(dpi)

              'Item.DebitBaht
              dpi = New DocPrintingItem
              dpi.Mapping = "Item.DebitBaht"
              dpi.Value = Configuration.FormatToString(CDec(Bfpoint), DigitConfig.Int)
              dpi.DataType = "System.String"
              dpi.Row = n + 1
              dpi.Table = "Item"
              dpiColl.Add(dpi)

              'Item.DebitSatang
              dpi = New DocPrintingItem
              dpi.Mapping = "Item.DebitSatang"
              dpi.Value = Aftpoint
              dpi.DataType = "System.String"
              dpi.Row = n + 1
              dpi.Table = "Item"
              dpiColl.Add(dpi)

              'Item.Amount
              dpi = New DocPrintingItem
              dpi.Mapping = "Item.Amount"
              dpi.Value = Configuration.FormatToString(item.Amount, DigitConfig.Price)
              dpi.DataType = "System.Decimal"
              dpi.Row = n + 1
              dpi.Table = "Item"
              dpiColl.Add(dpi)
            Else
              'Item.Credit
              dpi = New DocPrintingItem
              dpi.Mapping = "Item.Credit"
              dpi.Value = Configuration.FormatToString(item.Amount, DigitConfig.Price)
              SumCredit += item.Amount
              dpi.DataType = "System.Decimal"
              dpi.Row = n + 1
              dpi.Table = "Item"
              dpiColl.Add(dpi)

              'Item.CreditBaht
              dpi = New DocPrintingItem
              dpi.Mapping = "Item.CreditBaht"
              dpi.Value = Configuration.FormatToString(CDec(Bfpoint), DigitConfig.Int)
              dpi.DataType = "System.String"
              dpi.Row = n + 1
              dpi.Table = "Item"
              dpiColl.Add(dpi)

              'Item.CreditSatang
              dpi = New DocPrintingItem
              dpi.Mapping = "Item.CreditSatang"
              dpi.Value = Aftpoint
              dpi.DataType = "System.String"
              dpi.Row = n + 1
              dpi.Table = "Item"
              dpiColl.Add(dpi)

              'Item.Amount
              dpi = New DocPrintingItem
              dpi.Mapping = "Item.Amount"
              dpi.Value = Configuration.FormatToString(item.Amount, DigitConfig.Price)
              dpi.DataType = "System.Decimal"
              dpi.Row = n + 1
              dpi.Table = "Item"
              dpiColl.Add(dpi)

              space = "  "
            End If

            'Item.AccountName
            dpi = New DocPrintingItem
            dpi.Mapping = "Item.AccountName"
            If Not item.Account Is Nothing Then
              dpi.Value = space & item.Account.Name
            Else
              dpi.Value = ""
            End If
            dpi.DataType = "System.String"
            dpi.Row = n + 1
            dpi.Table = "Item"
            dpiColl.Add(dpi)

            'Item.CostCenterCode
            dpi = New DocPrintingItem
            dpi.Mapping = "Item.CostCenterCode"
            If Not item.CostCenter Is Nothing Then
              dpi.Value = item.CostCenter.Code
            Else
              dpi.Value = ""
            End If
            dpi.DataType = "System.String"
            dpi.Row = n + 1
            dpi.Table = "Item"
            dpiColl.Add(dpi)

            'Item.CostCenterName
            dpi = New DocPrintingItem
            dpi.Mapping = "Item.CostCenterName"
            If Not item.CostCenter Is Nothing Then
              dpi.Value = item.CostCenter.Name
            Else
              dpi.Value = ""
            End If
            dpi.DataType = "System.String"
            dpi.Row = n + 1
            dpi.Table = "Item"
            dpiColl.Add(dpi)

            'Item.CostCenterCodeName
            dpi = New DocPrintingItem
            dpi.Mapping = "Item.CostCenterCodeName"
            If Not item.CostCenter Is Nothing Then
              dpi.Value = item.CostCenter.Code & ":" & item.CostCenter.Name
            Else
              dpi.Value = ""
            End If
            dpi.DataType = "System.String"
            dpi.Row = n + 1
            dpi.Table = "Item"
            dpiColl.Add(dpi)

            n += 1
          Next
          'SumCredit
          dpi = New DocPrintingItem
          dpi.Mapping = "SumCredit"
          dpi.Value = Configuration.FormatToString(SumCredit, DigitConfig.Price)
          dpi.DataType = "System.String"
          dpiColl.Add(dpi)

          'SumDebit
          dpi = New DocPrintingItem
          dpi.Mapping = "SumDebit"
          dpi.Value = Configuration.FormatToString(SumDebit, DigitConfig.Price)
          dpi.DataType = "System.String"
          dpiColl.Add(dpi)
        End If

      End If
      Return dpiColl
    End Function
    Private Function GetGoodsSoldDocPrintingEntries() As DocPrintingItemCollection
      Dim n As Integer
      Dim dpiColl As New DocPrintingItemCollection
      Dim dpi As DocPrintingItem
      If TypeOf Me.RefDoc Is GoodsSold Then
        Dim gs As GoodsSold = CType(Me.RefDoc, GoodsSold)
        If Not gs Is Nothing Then
          If Not gs.FromCostCenter Is Nothing Then
            'ToCostCenterInfo
            dpi = New DocPrintingItem
            dpi.Mapping = "CostCenterInfo"
            dpi.Value = gs.FromCostCenter.Code & ":" & gs.FromCostCenter.Name
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)

            'ToCostCenterCode
            dpi = New DocPrintingItem
            dpi.Mapping = "CostCenterCode"
            dpi.Value = gs.FromCostCenter.Code
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)

            'ToCostCenterName
            dpi = New DocPrintingItem
            dpi.Mapping = "CostCenterName"
            dpi.Value = gs.FromCostCenter.Name
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)
          End If

          'RefDocGross (am เพิ่ม)
          dpi = New DocPrintingItem
          dpi.Mapping = "RefDocGross"
          dpi.Value = Configuration.FormatToString(gs.RealGross, DigitConfig.Price)
          dpi.DataType = "System.String"
          dpiColl.Add(dpi)

          'RefDocDiscountRate (am เพิ่ม)
          dpi = New DocPrintingItem
          dpi.Mapping = "RefDocDiscountRate"
          dpi.Value = gs.Discount.Rate
          dpi.DataType = "System.String"
          dpiColl.Add(dpi)

          'RefDocDiscountAmount (am เพิ่ม)
          dpi = New DocPrintingItem
          dpi.Mapping = "RefDocDiscountAmount"
          dpi.Value = Configuration.FormatToString(gs.DiscountAmount, DigitConfig.Price)
          dpi.DataType = "System.String"
          dpiColl.Add(dpi)

          'RefDocBeforeTax (am เพิ่ม)
          dpi = New DocPrintingItem
          dpi.Mapping = "RefDocBeforeTax"
          dpi.Value = Configuration.FormatToString(gs.BeforeTax, DigitConfig.Price)
          dpi.DataType = "System.String"
          dpiColl.Add(dpi)

          'RefDocTaxAmount
          dpi = New DocPrintingItem
          dpi.Mapping = "RefDocTaxAmount"
          dpi.Value = Configuration.FormatToString(gs.TaxAmount, DigitConfig.UnitPrice)
          dpi.DataType = "System.String"
          dpiColl.Add(dpi)

          'RefDocAfterTax
          dpi = New DocPrintingItem
          dpi.Mapping = "RefDocAfterTax"
          dpi.Value = Configuration.FormatToString(gs.AfterTax, DigitConfig.UnitPrice)
          dpi.DataType = "System.String"
          dpiColl.Add(dpi)

          'Interest(INT) (am เพิ่ม)
          dpi = New DocPrintingItem
          dpi.Mapping = "Interest"
          dpi.Value = Configuration.FormatToString(Interest, DigitConfig.Price)
          dpi.DataType = "System.String"
          dpiColl.Add(dpi)

          'AdvanceAmount
          dpi = New DocPrintingItem
          dpi.Mapping = "AdvanceAmount"
          If gs.TaxType.Value = 0 OrElse gs.TaxType.Value = 1 Then
            dpi.Value = Configuration.FormatToString(gs.AdvanceReceiveItemCollection.GetExcludeVATAmount, DigitConfig.Price)
          Else
            dpi.Value = Configuration.FormatToString(gs.AdvanceReceiveItemCollection.GetAmount, DigitConfig.Price)
          End If
          dpi.DataType = "System.String"
          dpiColl.Add(dpi)

          Dim sumRefDocItemAmount As Decimal = 0
          Dim line As Integer = 0

          Dim m As Integer = 0
          For Each item As GoodsSoldItem In gs.ItemCollection
            'RefDocItem.Code
            dpi = New DocPrintingItem
            dpi.Mapping = "RefDocItem.Code"
            dpi.Value = item.Entity.Code
            dpi.DataType = "System.String"
            dpi.Row = m + 1
            dpi.Table = "RefDocItem"
            dpiColl.Add(dpi)

            If (item.ItemType.Value <> 160 And item.ItemType.Value <> 162) Then
              line += 1
              'Item.LineNumber
              '************** เอามาไว้เป็นอันที่ 2
              'RefDocItem.LineNumber
              dpi = New DocPrintingItem
              dpi.Mapping = "RefDocItem.LineNumber"
              dpi.Value = line
              dpi.DataType = "System.Int32"
              dpi.Row = m + 1
              dpi.Table = "RefDocItem"
              dpiColl.Add(dpi)

              'RefDocItem.Unit
              dpi = New DocPrintingItem
              dpi.Mapping = "RefDocItem.Unit"
              dpi.Value = item.Unit.Name
              dpi.DataType = "System.String"
              dpi.Row = m + 1
              dpi.Table = "RefDocItem"
              dpiColl.Add(dpi)

              'RefDocItem.Qty
              dpi = New DocPrintingItem
              dpi.Mapping = "RefDocItem.Qty"
              dpi.Value = Configuration.FormatToString(item.Qty, DigitConfig.Qty)
              dpi.DataType = "System.String"
              dpi.Row = m + 1
              dpi.Table = "RefDocItem"
              dpiColl.Add(dpi)

              'RefDocItem.UnitPrice
              dpi = New DocPrintingItem
              dpi.Mapping = "RefDocItem.UnitPrice"
              If item.UnitPrice = 0 Then
                dpi.Value = ""
              Else
                dpi.Value = Configuration.FormatToString(item.UnitPrice, DigitConfig.UnitPrice)
              End If
              dpi.DataType = "System.String"
              dpi.Row = m + 1
              dpi.Table = "RefDocItem"
              dpiColl.Add(dpi)

              'RefDocItem.DiscountRate
              dpi = New DocPrintingItem
              dpi.Mapping = "Item.DiscountRate"
              dpi.Value = item.Discount.Rate
              dpi.DataType = "System.String"
              dpi.Row = m + 1
              dpi.Table = "Item"
              dpiColl.Add(dpi)

              'RefDocItem.DiscountAmount
              dpi = New DocPrintingItem
              dpi.Mapping = "RefDocItem.DiscountAmount"
              If item.Discount.Amount = 0 Then

                dpi.Value = ""
              Else
                dpi.Value = Configuration.FormatToString(item.Discount.Amount, DigitConfig.Price)
              End If
              dpi.DataType = "System.String"
              dpi.Row = m + 1
              dpi.Table = "RefDocItem"
              dpiColl.Add(dpi)

              'RefDocItem.Amount
              dpi = New DocPrintingItem
              dpi.Mapping = "RefDocItem.Amount"
              If item.Amount = 0 Then
                dpi.Value = ""
              Else
                dpi.Value = Configuration.FormatToString(item.Amount, DigitConfig.Price)
                sumRefDocItemAmount += item.Amount
              End If
              dpi.DataType = "System.String"
              dpi.Row = m + 1
              dpi.Table = "RefDocItem"
              dpiColl.Add(dpi)

              'RefDocItem.ZeroVat
              dpi = New DocPrintingItem
              dpi.Mapping = "RefDocItem.ZeroVat"
              dpi.Value = item.UnVatable
              dpi.DataType = "System.Boolean"
              dpi.Row = m + 1
              dpi.Table = "RefDocItem"
              dpiColl.Add(dpi)
            End If
            'RefDocItem.Description
            dpi = New DocPrintingItem
            dpi.Mapping = "RefDocItem.Description"
            If Not item.EntityName Is Nothing AndAlso item.EntityName.Length > 0 Then
              dpi.Value = item.EntityName
            Else
              dpi.Value = item.Entity.Name
            End If
            dpi.DataType = "System.String"
            dpi.Row = m + 1
            dpi.Table = "RefDocItem"
            dpiColl.Add(dpi)

            'RefDocItem.Note
            dpi = New DocPrintingItem
            dpi.Mapping = "RefDocItem.Note"
            dpi.Value = item.Note
            dpi.DataType = "System.String"
            dpi.Row = m + 1
            dpi.Table = "RefDocItem"
            dpiColl.Add(dpi)

            m += 1
          Next
          'RemainingAmount
          dpi = New DocPrintingItem
          dpi.Mapping = "RemainingAmount"
          dpi.Value = Configuration.FormatToString(Me.Amount - Me.Gross, DigitConfig.UnitPrice)
          dpi.DataType = "System.String"
          dpiColl.Add(dpi)

          'WHTAmount
          dpi = New DocPrintingItem
          dpi.Mapping = "WHTAmount"
          dpi.Value = Configuration.FormatToString(gs.WitholdingTaxCollection.Amount, DigitConfig.UnitPrice)
          dpi.DataType = "System.String"
          dpiColl.Add(dpi)

          'PaidAmount
          dpi = New DocPrintingItem
          dpi.Mapping = "PaidAmount"
          dpi.Value = Configuration.FormatToString(Me.Gross, DigitConfig.UnitPrice)
          dpi.DataType = "System.String"
          dpiColl.Add(dpi)

        End If
      End If

      Return dpiColl
    End Function
    Private Function GetReceiveSelectionDocPrintingEntries() As DocPrintingItemCollection
      Dim n As Integer
      Dim sumAfterTax As Decimal = 0
      Dim dpiColl As New DocPrintingItemCollection
      Dim dpi As DocPrintingItem

      If TypeOf Me.RefDoc Is ReceiveSelection Then
        Dim rs As ReceiveSelection = CType(Me.RefDoc, ReceiveSelection)

        'CustomerInfo
        If rs.Customer.Originated Then
          rs.Customer.PopulateDPIColl(dpiColl)
        End If

        Dim cc As CostCenter = rs.GetAllCC
        If cc Is Nothing Then
          cc = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
        End If
        If cc.Originated Then
          cc.PopulateDPIColl(dpiColl)
        End If

        Dim dt As TreeTable = ReceiveSelection.GetSchemaTable()
        rs.ItemCollection.PopulateReceiveSelectionItem(dt)
        Dim tmpDescription As String = ""
        'Dim dtRet As DataTable = rs.GetAllMileStoneItem()

        Dim stockid As Integer = 0
        Dim entityid As Integer = 0
        Dim RefRetention As Decimal = 0
        Dim RefDocRetention As Decimal = 0

        For Each dr As TreeRow In dt.Rows

          'myDatatable.Columns.Add(New DataColumn("receivesi_entity", GetType(Integer)))
          'myDatatable.Columns.Add(New DataColumn("receivesi_entityType", GetType(Integer)))

          If dr.IsNull("receivesi_parentEntity") OrElse CDec(dr("receivesi_parentEntity")) <> 0 Then

            'RefDocItem.LineNumber
            dpi = New DocPrintingItem
            dpi.Mapping = "RefDocItem.LineNumber"
            If Not IsDBNull(dr("receivesi_linenumber")) Then
              dpi.Value = dr("receivesi_linenumber")
            End If
            dpi.DataType = "System.String"
            dpi.Row = n + 1
            dpi.Table = "RefDocItem"
            dpiColl.Add(dpi)

            'RefDocItem.Description
            dpi = New DocPrintingItem
            dpi.Mapping = "RefDocItem.Description"
            If Not IsDBNull(dr("receivesi_entityType")) Then
              If Not IsDBNull(dr("Code")) Then
                dpi.Value = CodeDescription.GetDescription("receivesi_entityType", CInt(dr("receivesi_entityType"))) & ":" & CStr(dr("Code"))
              Else
                dpi.Value = CodeDescription.GetDescription("receivesi_entityType", CInt(dr("receivesi_entityType")))
              End If
            Else
              If Not IsDBNull(dr("Code")) Then
                dpi.Value = CStr(dr("Code"))
              Else
                dpi.Value = ""
              End If
            End If
            tmpDescription = CStr(dpi.Value)
            dpi.DataType = "System.String"
            dpi.Row = n + 1
            dpi.Table = "RefDocItem"
            dpiColl.Add(dpi)

            'RefDocItem.DescriptionWithNote
            dpi = New DocPrintingItem
            dpi.Mapping = "RefDocItem.DescriptionWithNote"
            If Not IsDBNull(dr("receivesi_note")) Then
              dpi.Value = tmpDescription & " - " & CStr(dr("receivesi_note"))
            Else
              dpi.Value = tmpDescription
            End If
            dpi.DataType = "System.String"
            dpi.Row = n + 1
            dpi.Table = "RefDocItem"
            dpiColl.Add(dpi)

            'RefDocItem.Amount
            dpi = New DocPrintingItem
            dpi.Mapping = "RefDocItem.Amount"
            If Not IsDBNull(dr("receivesi_entityType")) Then
              If CInt(dr("receivesi_entityType")) = 79 OrElse CInt(dr("receivesi_entityType")) = 48 Then  'ลดงาน
                If Not IsDBNull(dr("receivesi_amt")) Then
                  dpi.Value = Configuration.FormatToString(-CDec(dr("receivesi_amt")), DigitConfig.UnitPrice)
                  sumAfterTax += CDec(dr("receivesi_amt"))
                End If
              Else
                If Not IsDBNull(dr("receivesi_amt")) Then
                  dpi.Value = Configuration.FormatToString(CDec(dr("receivesi_amt")), DigitConfig.UnitPrice)
                  sumAfterTax += CDec(dr("receivesi_amt"))
                End If
              End If
            Else
              If Not IsDBNull(dr("receivesi_amt")) Then
                dpi.Value = Configuration.FormatToString(CDec(dr("receivesi_amt")), DigitConfig.UnitPrice)
                sumAfterTax += CDec(dr("receivesi_amt"))
              End If
            End If
            dpi.DataType = "System.String"
            dpi.Row = n + 1
            dpi.Table = "RefDocItem"
            dpiColl.Add(dpi)

            If Not IsDBNull(dr("receivesi_entity")) Then
              stockid = CInt(dr("receivesi_entity"))
            End If
            If Not IsDBNull(dr("receivesi_entityType")) Then
              entityid = CInt(dr("receivesi_entityType"))
            End If
            RefRetention = rs.GetMileStoneItem(stockid, entityid)
            RefDocRetention += RefRetention
            'RefDocItem.Retontion 
            dpi = New DocPrintingItem
            dpi.Mapping = "RefDocItem.Retention"
            dpi.Value = Configuration.FormatToString(RefRetention, DigitConfig.Price)
            dpi.DataType = "System.String"
            dpi.Row = n + 1
            dpi.Table = "RefDocItem"
            dpiColl.Add(dpi)

            'RefDocItem.Note
            dpi = New DocPrintingItem
            dpi.Mapping = "RefDocItem.Note"
            If Not IsDBNull(dr("receivesi_note")) Then
              dpi.Value = CStr(dr("receivesi_note"))
            End If
            dpi.DataType = "System.String"
            dpi.Row = n + 1
            dpi.Table = "RefDocItem"
            dpiColl.Add(dpi)
            n += 1
          End If

        Next

        'RefDocRetention
        dpi = New DocPrintingItem
        dpi.Mapping = "RefDocRetention"
        dpi.Value = Configuration.FormatToString(RefDocRetention, DigitConfig.Price)
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'RefDocTaxAmount
        dpi = New DocPrintingItem
        dpi.Mapping = "RefDocTaxAmount"
        If rs.TaxAmount > 0 Then
          dpi.Value = Configuration.FormatToString(rs.TaxAmount, DigitConfig.UnitPrice)
        Else
          dpi.Value = ""
        End If
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'RefDocAfterTax
        dpi = New DocPrintingItem
        dpi.Mapping = "RefDocAfterTax"
        dpi.Value = Configuration.FormatToString(Me.Gross, DigitConfig.UnitPrice)
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'WHTAmount
        dpi = New DocPrintingItem
        dpi.Mapping = "WHTAmount"
        If rs.WitholdingTaxCollection.Amount > 0 Then
          dpi.Value = Configuration.FormatToString(rs.WitholdingTaxCollection.Amount, DigitConfig.UnitPrice)
        End If
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'PaidAmount
        dpi = New DocPrintingItem
        dpi.Mapping = "PaidAmount"
        dpi.Value = Configuration.FormatToString(Me.Gross, DigitConfig.UnitPrice)
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)
      End If
      Return dpiColl
    End Function
    Private Function GetPurchaseCNDocPrintingEntries() As DocPrintingItemCollection
      Dim n As Integer
      Dim dpiColl As New DocPrintingItemCollection
      Dim dpi As DocPrintingItem
      If TypeOf Me.RefDoc Is PurchaseCN Then
        Dim pCn As PurchaseCN = CType(Me.RefDoc, PurchaseCN)
        If Not pCn Is Nothing Then
          If Not pCn.FromCostCenter Is Nothing Then
            'ToCostCenterInfo
            dpi = New DocPrintingItem
            dpi.Mapping = "CostCenterInfo"
            dpi.Value = pCn.FromCostCenter.Code & ":" & pCn.FromCostCenter.Name
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)

            'ToCostCenterCode
            dpi = New DocPrintingItem
            dpi.Mapping = "CostCenterCode"
            dpi.Value = pCn.FromCostCenter.Code
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)

            'ToCostCenterName
            dpi = New DocPrintingItem
            dpi.Mapping = "CostCenterName"
            dpi.Value = pCn.FromCostCenter.Name
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)
          End If

          'RefDocVatIdInfo
          Dim tmpRefDocCode As String = ""
          For Each item As PurchaseCNRefDoc In pCn.RefDocCollection
            If tmpRefDocCode.Length > 0 Then
              tmpRefDocCode &= ", "
            End If
            tmpRefDocCode &= item.RefDocCode
          Next
          dpi = New DocPrintingItem
          dpi.Mapping = "RefDocVatIdInfo"
          dpi.Value = tmpRefDocCode
          dpi.DataType = "System.String"
          dpiColl.Add(dpi)

          'RefDocTaxAmount
          dpi = New DocPrintingItem
          dpi.Mapping = "RefDocTaxAmount"
          dpi.Value = Configuration.FormatToString(pCn.TaxAmount, DigitConfig.Price)
          dpi.DataType = "System.String"
          dpiColl.Add(dpi)

          'RefDocAfterTax
          dpi = New DocPrintingItem
          dpi.Mapping = "RefDocAfterTax"
          dpi.Value = Configuration.FormatToString(pCn.AfterTax, DigitConfig.Price)
          dpi.DataType = "System.String"
          dpiColl.Add(dpi)

          Dim whtAmt As Decimal = 0
          Dim whtCode As String = ""
          For Each wht As WitholdingTax In pCn.WitholdingTaxCollection
            If wht.Originated Then
              If whtCode.Length > 0 Then
                whtCode &= ", "
              End If
              whtCode &= wht.Code
              whtAmt += wht.Amount
            End If
          Next
          'RefDocWitholdingTaxAmount
          dpi = New DocPrintingItem
          dpi.Mapping = "RefDocWitholdingTaxAmount"
          dpi.Value = Configuration.FormatToString(whtAmt, DigitConfig.Price)
          dpi.DataType = "System.String"
          dpiColl.Add(dpi)

          'RefDocWitholdingTaxCodeInfo
          dpi = New DocPrintingItem
          dpi.Mapping = "RefDocWitholdingTaxCodeInfo"
          dpi.Value = whtCode
          dpi.DataType = "System.String"
          dpiColl.Add(dpi)

          'ReceiveRemaining
          dpi = New DocPrintingItem
          dpi.Mapping = "ReceiveRemaining"
          dpi.Value = Configuration.FormatToString(Me.Amount - Me.Gross, DigitConfig.Price)
          dpi.DataType = "System.String"
          dpiColl.Add(dpi)

          Dim m As Integer = 0
          Dim c As Integer = 0
          'For Each row As DataRow In pCn.ItemTable.Rows
          For Each item As PurchaseCNItem In pCn.ItemCollection
            'If Not row.IsNull("stocki_entitytype") Then
            'If item.ItemType.Value = 160 Or item.ItemType.Value = 162 Then
            '  'nothing
            'Else

            'RefDocItem.LineNumber
            dpi = New DocPrintingItem
            dpi.Mapping = "RefDocItem.LineNumber"
            If item.ItemType.Value = 160 Or item.ItemType.Value = 162 Then
              c += 1
            End If
            dpi.Value = c
            dpi.DataType = "System.Int32"
            dpi.Row = m + 1
            dpi.Table = "RefDocItem"
            dpiColl.Add(dpi)

            'RefDocItem.EntityType
            dpi = New DocPrintingItem
            dpi.Mapping = "RefDocItem.EntityType"
            dpi.Value = item.ItemType.Description
            dpi.DataType = "System.String"
            dpi.Row = m + 1
            dpi.Table = "RefDocItem"
            dpiColl.Add(dpi)

            If Not item.Entity Is Nothing Then
              'RefDocItem.Code
              dpi = New DocPrintingItem
              dpi.Mapping = "RefDocItem.Code"
              dpi.Value = item.Entity.Code
              dpi.DataType = "System.String"
              dpi.Row = m + 1
              dpi.Table = "RefDocItem"
              dpiColl.Add(dpi)
            End If

            'RefDocItem.Description
            dpi = New DocPrintingItem
            dpi.Mapping = "RefDocItem.Description"
            If Not item.Entity Is Nothing Then
              If item.Entity.Name.Length > 0 Then
                dpi.Value = item.Entity.Name
              Else
                dpi.Value = item.EntityName
              End If
            End If
            dpi.DataType = "System.String"
            dpi.Row = m + 1
            dpi.Table = "RefDocItem"
            dpiColl.Add(dpi)

            If Not item.Unit Is Nothing Then
              'RefDocItem.UnitCode
              dpi = New DocPrintingItem
              dpi.Mapping = "RefDocItem.UnitCode"
              dpi.Value = item.Unit.Code
              dpi.DataType = "System.String"
              dpi.Row = m + 1
              dpi.Table = "RefDocItem"
              dpiColl.Add(dpi)

              'RefDocItem.Unit
              dpi = New DocPrintingItem
              dpi.Mapping = "RefDocItem.Unit"
              dpi.Value = item.Unit.Name
              dpi.DataType = "System.String"
              dpi.Row = m + 1
              dpi.Table = "RefDocItem"
              dpiColl.Add(dpi)
            End If

            'RefDocItem.Qty
            dpi = New DocPrintingItem
            dpi.Mapping = "RefDocItem.Qty"
            dpi.Value = Configuration.FormatToString(item.Qty, DigitConfig.Qty)
            dpi.DataType = "System.String"
            dpi.Row = m + 1
            dpi.Table = "RefDocItem"
            dpiColl.Add(dpi)

            'RefDocItem.UnitPrice
            dpi = New DocPrintingItem
            dpi.Mapping = "RefDocItem.UnitPrice"
            dpi.Value = Configuration.FormatToString(item.UnitPrice, DigitConfig.UnitPrice)
            dpi.DataType = "System.String"
            dpi.Row = m + 1
            dpi.Table = "RefDocItem"
            dpiColl.Add(dpi)

            If Not item.Discount Is Nothing Then
              'RefDocItem.DiscountItem
              dpi = New DocPrintingItem
              dpi.Mapping = "RefDocItem.DiscountItem"
              dpi.Value = item.Discount.Rate
              dpi.DataType = "System.String"
              dpi.Row = m + 1
              dpi.Table = "RefDocItem"
              dpiColl.Add(dpi)

              'RefDocItem.DiscountItem
              dpi = New DocPrintingItem
              dpi.Mapping = "RefDocItem.DiscountItemAmount"
              dpi.Value = Configuration.FormatToString(item.Discount.Amount, DigitConfig.UnitPrice)
              dpi.DataType = "System.String"
              dpi.Row = m + 1
              dpi.Table = "RefDocItem"
              dpiColl.Add(dpi)
            End If

            'RefDocItem.Amount
            dpi = New DocPrintingItem
            dpi.Mapping = "RefDocItem.Amount"
            dpi.Value = Configuration.FormatToString(item.Amount, DigitConfig.UnitPrice)
            dpi.DataType = "System.String"
            dpi.Row = m + 1
            dpi.Table = "RefDocItem"
            dpiColl.Add(dpi)

            If Not item.Account Is Nothing Then
              'RefDocItem.AccountCode
              dpi = New DocPrintingItem
              dpi.Mapping = "RefDocItem.AccountCode"
              dpi.Value = item.Account.Code
              dpi.DataType = "System.String"
              dpi.Row = m + 1
              dpi.Table = "RefDocItem"
              dpiColl.Add(dpi)

              'RefDocItem.AccountName
              dpi = New DocPrintingItem
              dpi.Mapping = "RefDocItem.AccountName"
              dpi.Value = item.Account.Name
              dpi.DataType = "System.String"
              dpi.Row = m + 1
              dpi.Table = "RefDocItem"
              dpiColl.Add(dpi)

              'RefDocItem.Account
              dpi = New DocPrintingItem
              dpi.Mapping = "RefDocItem.Account"
              dpi.Value = item.Account.Code & ":" & item.Account.Name
              dpi.DataType = "System.String"
              dpi.Row = m + 1
              dpi.Table = "RefDocItem"
              dpiColl.Add(dpi)
            End If

            'RefDocItem.Note
            dpi = New DocPrintingItem
            dpi.Mapping = "RefDocItem.Note"
            dpi.Value = item.Note
            dpi.DataType = "System.String"
            dpi.Row = m + 1
            dpi.Table = "RefDocItem"
            dpiColl.Add(dpi)

            'End If
            'End If
            m += 1
          Next

          ''RefDocTaxAmount
          'dpi = New DocPrintingItem
          'dpi.Mapping = "RefDocTaxAmount"
          'dpi.Value = Configuration.FormatToString(gs.TaxAmount, DigitConfig.UnitPrice)
          'dpi.DataType = "System.String"
          'dpiColl.Add(dpi)

          ''RefDocAfterTax
          'dpi = New DocPrintingItem
          'dpi.Mapping = "RefDocAfterTax"
          'dpi.Value = Configuration.FormatToString(gs.AfterTax, DigitConfig.UnitPrice)
          'dpi.DataType = "System.String"
          'dpiColl.Add(dpi)

          ''Interest(INT) (am เพิ่ม)
          'dpi = New DocPrintingItem
          'dpi.Mapping = "Interest"
          'dpi.Value = Configuration.FormatToString(Interest, DigitConfig.Price)
          'dpi.DataType = "System.String"
          'dpiColl.Add(dpi)

          'Dim sumRefDocItemAmount As Decimal = 0
          'Dim line As Integer = 0

        End If
      End If

      Return dpiColl
    End Function
    Private Function GetPrettyCashClosedDocPrintingEntries() As DocPrintingItemCollection
      Dim n As Integer
      Dim dpiColl As New DocPrintingItemCollection
      Dim dpi As DocPrintingItem
      If TypeOf Me.RefDoc Is PettyCashClosed Then
        Dim pc As PettyCashClosed = CType(receive_refDoc, PettyCashClosed)
        If Not pc Is Nothing Then
          'RefPrettyCashCode
          dpi = New DocPrintingItem
          dpi.Mapping = "RefPrettyCashCode"
          dpi.Value = pc.PettyCash.Code
          dpi.DataType = "System.String"
          dpiColl.Add(dpi)

          'RefPrettyCashName
          dpi = New DocPrintingItem
          dpi.Mapping = "RefPrettyCashName"
          dpi.Value = pc.PettyCash.Name
          dpi.DataType = "System.String"
          dpiColl.Add(dpi)

          'RefEmpcode
          dpi = New DocPrintingItem
          dpi.Mapping = "RefEmpcode"
          dpi.Value = pc.PettyCash.Employee.Code
          dpi.DataType = "System.String"
          dpiColl.Add(dpi)

          'RefEmpName
          dpi = New DocPrintingItem
          dpi.Mapping = "RefEmpName"
          dpi.Value = pc.PettyCash.Employee.Name
          dpi.DataType = "System.String"
          dpiColl.Add(dpi)

          'RefCC_code
          dpi = New DocPrintingItem
          dpi.Mapping = "RefCC_code"
          dpi.Value = pc.PettyCash.Costcenter.Code
          dpi.DataType = "System.String"
          dpiColl.Add(dpi)

          'RefCC_Name
          dpi = New DocPrintingItem
          dpi.Mapping = "RefCC_Name"
          dpi.Value = pc.PettyCash.Costcenter.Name
          dpi.DataType = "System.String"
          dpiColl.Add(dpi)

        End If
      End If
      Return dpiColl
    End Function
#End Region

    Public Property FromCC() As CostCenter Implements IHasFromCostCenter.FromCC
      Get
        Return Me.CostCenter
      End Get
      Set(ByVal Value As CostCenter)

      End Set
    End Property

    Public Property ToCC() As CostCenter Implements IHasToCostCenter.ToCC
      Get
        Return Me.CostCenter
      End Get
      Set(ByVal Value As CostCenter)

      End Set
    End Property
  End Class

  Public Class ReceiveEntityType
    Inherits CodeDescription

#Region "Constructors"
    Public Sub New(ByVal value As Integer)
      MyBase.New(value)
    End Sub
#End Region

#Region "Properties"
    Public Overrides ReadOnly Property CodeName() As String
      Get
        Return "receivei_entityType"
      End Get
    End Property
#End Region

  End Class
  Public Class ReceiveItem

#Region "Members"
    Private m_receive As Receive
    Private m_lineNumber As Integer
    Private m_entity As IReceiveItem
    Private m_OldEntity As IHasAmount
    Private m_entityType As ReceiveEntityType

    Private m_amount As Decimal
    Private m_note As String
#End Region

#Region "Constructors"
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
        If dr.Table.Columns.Contains(aliasPrefix & "receivei_entityType") AndAlso Not dr.IsNull(aliasPrefix & "receivei_entityType") Then
          .m_entityType = New ReceiveEntityType(CInt(dr(aliasPrefix & "receivei_entityType")))
        End If
        Dim itemId As Integer
        If dr.Table.Columns.Contains(aliasPrefix & "receivei_entity") AndAlso Not dr.IsNull(aliasPrefix & "receivei_entity") Then
          itemId = CInt(dr(aliasPrefix & "receivei_entity"))
        End If
        Select Case .m_entityType.Value
          Case 0 'Cash
            If dr.Table.Columns.Contains(aliasPrefix & "receivei_amt") AndAlso Not dr.IsNull(aliasPrefix & "receivei_amt") Then
              Dim cash As New CashItem(CDec(dr(aliasPrefix & "receivei_amt")))
              If dr.Table.Columns.Contains(aliasPrefix & "receivei_duedate") AndAlso Not dr.IsNull(aliasPrefix & "receivei_duedate") Then
                cash.DocDate = CDate(dr(aliasPrefix & "receivei_duedate"))
              End If
              .m_entity = cash
            End If
          Case 72 'Transfer
            If dr.Table.Columns.Contains(aliasPrefix & "receivei_amt") AndAlso Not dr.IsNull(aliasPrefix & "receivei_amt") Then
              Dim bto As New BankTransferIn(CDec(dr(aliasPrefix & "receivei_amt")))
              If dr.Table.Columns.Contains(aliasPrefix & "receivei_bankacct") AndAlso Not dr.IsNull(aliasPrefix & "receivei_bankacct") Then
                bto.BankAccount = New BankAccount(CInt(dr(aliasPrefix & "receivei_bankacct")))
              End If
              If dr.Table.Columns.Contains(aliasPrefix & "receivei_duedate") AndAlso Not dr.IsNull(aliasPrefix & "receivei_duedate") Then
                bto.DocDate = CDate(dr(aliasPrefix & "receivei_duedate"))
              End If
              .m_entity = bto
            End If
          Case Else
            Dim myEntity As SimpleBusinessEntityBase = SimpleBusinessEntityBase.GetEntity(BusinessLogic.Entity.GetFullClassName(.m_entityType.Value), itemId)
            If TypeOf myEntity Is IReceiveItem Then
              .m_entity = CType(myEntity, IReceiveItem)
              .m_OldEntity = CType(myEntity, IHasAmount)
            End If
        End Select

        If dr.Table.Columns.Contains(aliasPrefix & "receivei_lineNumber") AndAlso Not dr.IsNull(aliasPrefix & "receivei_lineNumber") Then
          .m_lineNumber = CInt(dr(aliasPrefix & "receivei_lineNumber"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "receivei_amt") AndAlso Not dr.IsNull(aliasPrefix & "receivei_amt") Then
          .m_amount = CDec(dr(aliasPrefix & "receivei_amt"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "receivei_note") AndAlso Not dr.IsNull(aliasPrefix & "receivei_note") Then
          .m_note = CStr(dr(aliasPrefix & "receivei_note"))
        End If
      End With
    End Sub
    Protected Sub Construct(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
      Dim dr As DataRow = ds.Tables(0).Rows(0)
      Me.Construct(dr, aliasPrefix)
    End Sub
#End Region

#Region "Properties"
    Public Property Receive() As Receive      Get        Return m_receive      End Get      Set(ByVal Value As Receive)        m_receive = Value      End Set    End Property    Public Property LineNumber() As Integer      Get        Return m_lineNumber      End Get      Set(ByVal Value As Integer)        m_lineNumber = Value      End Set    End Property    Public Property Entity() As IReceiveItem      Get        Return m_entity      End Get      Set(ByVal Value As IReceiveItem)        m_entity = Value      End Set    End Property    Public Property OldEntity() As IHasAmount      Get        Return m_OldEntity      End Get      Set(ByVal Value As IHasAmount)        m_OldEntity = Value      End Set    End Property    Public Property EntityType() As ReceiveEntityType      Get        Return m_entityType      End Get      Set(ByVal Value As ReceiveEntityType)        m_entityType = Value      End Set    End Property    Public Property Amount() As Decimal      Get        Return m_amount      End Get      Set(ByVal Value As Decimal)        m_amount = Value      End Set    End Property    Public Property Note() As String      Get        Return m_note      End Get      Set(ByVal Value As String)        m_note = Value      End Set    End Property#End Region

#Region "Shared"
    Public Shared Function GetNewCheckFromitemRow(ByVal itemRow As TreeRow, ByVal itemReceive As Receive) As IncomingCheck
      'เช็คใหม่
      Dim check As New IncomingCheck
      If Not itemRow.IsNull("RealAmount") AndAlso IsNumeric(itemRow("RealAmount")) Then
        check.Amount = CDec(itemRow("RealAmount"))
      End If
      If Not itemRow.IsNull("code") AndAlso itemRow("code").ToString.Length > 0 Then
        check.CqCode = itemRow("code").ToString
      End If
      If Not itemRow.IsNull("receivei_bankacct") AndAlso IsNumeric(itemRow("receivei_bankacct")) Then
        check.BankAccount = New BankAccount(CInt(itemRow("receivei_bankacct")))
      End If
      If Not itemRow.IsNull("duedate") Then
        check.DueDate = CDate(itemRow("duedate"))
      End If
      check.ReceiveDate = itemReceive.DocDate
      If Not itemReceive.RefDoc Is Nothing Then
        If Not itemReceive.RefDoc.Payer Is Nothing Then
          If TypeOf itemReceive.RefDoc.Payer Is Customer Then
            check.Customer = CType(itemReceive.RefDoc.Payer, Customer)
          End If
        End If
      End If
      check.AutoGen = True
      Return check
    End Function
#End Region

#Region "Methods"
    Public Sub CopyToDataRow(ByVal row As TreeRow)
      If row Is Nothing Then
        Return
      End If
      Me.Receive.IsInitialized = False
      row("receivei_linenumber") = Me.LineNumber
      row("receivei_note") = Me.Note
      If Me.Amount <> 0 Then
        row("receivei_amt") = Configuration.FormatToString(Me.Amount, DigitConfig.Price)
      Else
        row("receivei_amt") = ""
      End If

      If Not Me.EntityType Is Nothing Then
        If Not Me.Entity Is Nothing Then
          Select Case Me.EntityType.Value
            Case 0 'สด
              Dim cash As CashItem = CType(Me.Entity, CashItem)
              row("code") = DBNull.Value
              row("DueDate") = cash.DocDate
              row("receivei_bankacct") = DBNull.Value
              row("BACode") = DBNull.Value
              row("BAName") = DBNull.Value
              row("Button") = "invisible"
              row("BAButton") = "invisible"
            Case 27 'เช็ครับ
              Dim check As IncomingCheck = CType(Me.Entity, IncomingCheck)
              Dim Oldcheck As IncomingCheck = CType(Me.OldEntity, IncomingCheck)
              row("code") = check.CqCode
              row("DueDate") = check.DueDate
              row("receivei_bankacct") = check.BankAccount.Id
              row("BACode") = check.BankAccount.Code
              row("BAName") = check.BankAccount.Name
              row("Button") = ""
              row("receivei_oldbankacct") = Oldcheck.BankAccount.Id
              'row("BAButton") = "invisible"
            Case 71 'มัดจำ
              Dim avr As AdvanceReceive = CType(Me.Entity, AdvanceReceive)
              row("code") = avr.Code
              row("DueDate") = avr.DocDate
              row("receivei_bankacct") = DBNull.Value
              row("BACode") = DBNull.Value
              row("BAName") = DBNull.Value
              row("Button") = ""
              row("BAButton") = "invisible"
            Case 72 'โอน
              Dim bto As BankTransferIn = CType(Me.Entity, BankTransferIn)
              row("code") = bto.Code
              row("DueDate") = bto.DocDate
              row("receivei_bankacct") = bto.BankAccount.Id
              row("BACode") = bto.BankAccount.Code
              row("BAName") = bto.BankAccount.Name
              row("Button") = "invisible"
              row("BAButton") = ""
            Case Else
              row("code") = DBNull.Value
              row("DueDate") = Date.MinValue
              row("receivei_bankacct") = DBNull.Value
              row("BACode") = DBNull.Value
              row("BAName") = DBNull.Value
              row("Button") = ""
              row("BAButton") = "invisible"
          End Select
          row("receivei_entitytype") = Me.EntityType.Value
          row("receivei_entity") = Me.Entity.Id
          If Me.Entity.Amount <> 0 Then
            row("RealAmount") = Configuration.FormatToString(Me.Entity.Amount, DigitConfig.Price)
          Else
            row("RealAmount") = ""
          End If
        Else
          row("receivei_entity") = DBNull.Value
          row("code") = DBNull.Value
          row("DueDate") = Date.MinValue
          row("receivei_bankacct") = DBNull.Value
          row("BACode") = DBNull.Value
          row("BAName") = DBNull.Value
          row("RealAmount") = DBNull.Value
          row("Button") = ""
          row("BAButton") = "invisible"
        End If
      Else
        row("Button") = ""
        row("BAButton") = "invisible"
      End If
      Me.Receive.IsInitialized = True
    End Sub
    Public Sub CopyFromDataRow(ByVal row As TreeRow)
      If row Is Nothing Then
        Return
      End If
      Try
        If Not row.IsNull(("receivei_linenumber")) Then
          Me.LineNumber = CInt(row("receivei_linenumber"))
        End If
        If Not row.IsNull(("receivei_amt")) AndAlso IsNumeric(row("receivei_amt")) Then
          Me.Amount = CDec(row("receivei_amt"))
        End If
        If Not row.IsNull(("receivei_note")) Then
          Me.Note = CStr(row("receivei_note"))
        End If
        If Not row.IsNull("receivei_entityType") Then
          Me.EntityType = New ReceiveEntityType(CInt(row("receivei_entityType")))
        End If
        If Not Me.EntityType Is Nothing Then
          Select Case Me.EntityType.Value
            Case 0 'สด
              If Not row.IsNull("RealAmount") AndAlso IsNumeric(row("RealAmount")) Then
                Me.Entity = New CashItem(CDec(row("RealAmount")))
                If Not row.IsNull("DueDate") Then
                  CType(Me.Entity, CashItem).DocDate = CDate(row("DueDate"))
                End If
              End If
            Case 27 'เช็ครับ
              If Not row.IsNull("receivei_entity") Then
                If CInt(row("receivei_entity")) = 0 Then
                  'เช็คใหม่
                  Me.Entity = GetNewCheckFromitemRow(row, Me.Receive)
                Else
                  Me.Entity = New IncomingCheck(CInt(row("receivei_entity")))
                End If
              End If
            Case 71 'มัดจำ
              If Not row.IsNull("receivei_entity") Then
                Me.Entity = New AdvanceReceive(CInt(row("receivei_entity")))
              End If
            Case 72 'โอน
              If Not row.IsNull("RealAmount") AndAlso IsNumeric(row("RealAmount")) Then
                Me.Entity = New BankTransferIn(CDec(row("RealAmount")))
                If Not row.IsNull("DueDate") Then
                  CType(Me.Entity, BankTransferIn).DocDate = CDate(row("DueDate"))
                End If
                If Not row.IsNull("receivei_bankacct") Then
                  CType(Me.Entity, BankTransferIn).BankAccount = New BankAccount(CInt(row("receivei_bankacct")))
                End If
              End If
            Case Else
              Me.Entity = Nothing
          End Select
        End If
      Catch ex As Exception
        MessageBox.Show(ex.Message & "::" & ex.StackTrace)
      End Try

    End Sub
#End Region

  End Class

  Public Class BankTransferIn
    Inherits SimpleBusinessEntityBase
    Implements IHasAmount, IHasBankAccount, IReceiveItem



#Region "Members"
    Private m_amount As Decimal
    Private m_bankacct As BankAccount
    Private m_docDate As Date
#End Region

#Region "Constructors"
    Public Sub New()
      m_bankacct = New BankAccount
    End Sub
    Public Sub New(ByVal amt As Decimal)
      Me.New()
      m_amount = amt
    End Sub
#End Region

#Region "Properties"
    Public Property BankAccount() As BankAccount Implements IHasBankAccount.BankAccount      Get        Return m_bankacct      End Get      Set(ByVal Value As BankAccount)        m_bankacct = Value      End Set    End Property
    Public Property DocDate() As Date
      Get
        Return m_docDate
      End Get
      Set(ByVal Value As Date)
        m_docDate = Value
      End Set
    End Property
    Public ReadOnly Property CreateDate As Nullable(Of Date) Implements IReceiveItem.CreateDate
      Get
        Return DocDate
      End Get
    End Property
#End Region

#Region "IHasAmount"
    Public Property Amount() As Decimal Implements IHasAmount.Amount
      Get
        Return m_amount
      End Get
      Set(ByVal Value As Decimal)
        m_amount = Value
      End Set
    End Property
#End Region

  End Class

  Public Class ReceiveAccountItem
    Implements ICloneable

#Region "Members"
    Private m_receive As Receive
    Private m_acct As Account
    Private m_amount As Decimal
    Private m_isDebit As Boolean
#End Region

#Region "Constructors"
    Public Sub New()
      MyBase.New()
      m_acct = New Account
    End Sub
    Public Sub New(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
      Me.Construct(ds, aliasPrefix)
    End Sub
    Public Sub New(ByVal dr As DataRow, ByVal aliasPrefix As String)
      Me.Construct(dr, aliasPrefix)
    End Sub
    Protected Sub Construct(ByVal dr As DataRow, ByVal aliasPrefix As String)
      With Me
        If dr.Table.Columns.Contains(aliasPrefix & "receivea_amt") AndAlso Not dr.IsNull(aliasPrefix & "receivea_amt") Then
          .m_amount = CDec(dr(aliasPrefix & "receivea_amt"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "receivea_isdebit") AndAlso Not dr.IsNull(aliasPrefix & "receivea_isdebit") Then
          .m_isDebit = CBool(dr(aliasPrefix & "receivea_isdebit"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "acct_id") AndAlso Not dr.IsNull(aliasPrefix & "acct_id") Then
          If Not dr.IsNull("acct_id") Then
            .m_acct = New Account(dr, "")
          End If
        Else
          If dr.Table.Columns.Contains(aliasPrefix & "receivea_acct") AndAlso Not dr.IsNull(aliasPrefix & "receivea_acct") Then
            .m_acct = New Account(CInt(dr(aliasPrefix & "receivea_acct")))
          End If
        End If
      End With
    End Sub
    Protected Sub Construct(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
      Dim dr As DataRow = ds.Tables(0).Rows(0)
      Me.Construct(dr, aliasPrefix)
    End Sub
#End Region

#Region "Properties"
    Public Property Receive() As Receive
      Get
        Return m_receive
      End Get
      Set(ByVal Value As Receive)
        m_receive = Value
      End Set
    End Property
    Public Property Account() As Account
      Get
        Return m_acct
      End Get
      Set(ByVal Value As Account)
        m_acct = Value
      End Set
    End Property
    Public Property Amount() As Decimal
      Get
        Return m_amount
      End Get
      Set(ByVal Value As Decimal)
        m_amount = Value
      End Set
    End Property
    Public Property IsDebit() As Boolean
      Get
        Return m_isDebit
      End Get
      Set(ByVal Value As Boolean)
        m_isDebit = Value
      End Set
    End Property
#End Region

#Region "ICloneable"
    Public Function Clone() As Object Implements System.ICloneable.Clone
      Dim receivea As New ReceiveAccountItem
      receivea.m_receive = Me.m_receive
      receivea.m_isDebit = Me.m_isDebit
      receivea.m_amount = Me.m_amount
      receivea.m_acct = Me.m_acct
      Return receivea
    End Function
#End Region

  End Class

  <Serializable(), DefaultMember("Item")> _
  Public Class ReceiveAccountItemCollection
    Inherits CollectionBase
    Implements ICloneable

#Region "Members"
    Private m_receive As Receive
    Private m_isDebit As Boolean
#End Region

#Region "Constructors"
    Public Sub New()
    End Sub
    Public Sub New(ByVal rc As Receive, ByVal isDebit As Boolean)
      m_receive = rc
      m_isDebit = isDebit
      If Not rc.Originated Then
        Return
      End If

      Dim sqlConString As String = RecentCompanies.CurrentCompany.ConnectionString


      Dim ds As DataSet = SqlHelper.ExecuteDataset(sqlConString _
      , CommandType.StoredProcedure _
      , "GetReceiveAccountItems" _
      , New SqlParameter("@receive_id", m_receive.Id) _
      , New SqlParameter("@receivea_isDebit", m_isDebit) _
      )

      For Each row As DataRow In ds.Tables(0).Rows
        Dim item As New ReceiveAccountItem(row, "")
        Me.Add(item)
      Next
    End Sub
#End Region

#Region "Properties"
    Public Property Receive() As Receive
      Get
        Return m_receive
      End Get
      Set(ByVal Value As Receive)
        m_receive = Value
      End Set
    End Property
    Default Public Property Item(ByVal index As Integer) As ReceiveAccountItem
      Get
        Return CType(MyBase.List.Item(index), ReceiveAccountItem)
      End Get
      Set(ByVal value As ReceiveAccountItem)
        MyBase.List.Item(index) = value
      End Set
    End Property
#End Region

#Region "Class Methods"
    Public Function GetAmount() As Decimal
      Dim ret As Decimal = 0
      For Each item As ReceiveAccountItem In Me
        ret += item.Amount
      Next
      Return ret
    End Function
    Public Sub Populate(ByVal dt As TreeTable)
      dt.Clear()
      Dim i As Integer = 0
      For Each receivea As ReceiveAccountItem In Me
        i += 1
        Dim newRow As TreeRow = dt.Childs.Add()
        newRow("Linenumber") = i
        If Not receivea.Account Is Nothing AndAlso receivea.Account.Originated Then
          newRow("Code") = receivea.Account.Code
          newRow("Name") = receivea.Account.Name
        End If
        newRow("receivea_amt") = Configuration.FormatToString(receivea.Amount, DigitConfig.Price)
        newRow.Tag = receivea
      Next
    End Sub
#End Region

#Region "Collection Methods"
    Public Function Add(ByVal value As ReceiveAccountItem) As Integer
      value.Receive = Me.m_receive
      value.IsDebit = m_isDebit
      Return MyBase.List.Add(value)
    End Function
    Public Sub AddRange(ByVal value As ReceiveAccountItemCollection)
      For i As Integer = 0 To value.Count - 1
        Me.Add(value(i))
      Next
    End Sub
    Public Sub AddRange(ByVal value As ReceiveAccountItem())
      For i As Integer = 0 To value.Length - 1
        Me.Add(value(i))
      Next
    End Sub
    Public Function Contains(ByVal value As ReceiveAccountItem) As Boolean
      Return MyBase.List.Contains(value)
    End Function
    Public Sub CopyTo(ByVal array As ReceiveAccountItem(), ByVal index As Integer)
      MyBase.List.CopyTo(array, index)
    End Sub
    Public Shadows Function GetEnumerator() As ReceiveAccountItemEnumerator
      Return New ReceiveAccountItemEnumerator(Me)
    End Function
    Public Function IndexOf(ByVal value As ReceiveAccountItem) As Integer
      Return MyBase.List.IndexOf(value)
    End Function
    Public Sub Insert(ByVal index As Integer, ByVal value As ReceiveAccountItem)
      value.Receive = Me.m_receive
      value.IsDebit = m_isDebit
      MyBase.List.Insert(index, value)
    End Sub
    Public Sub Remove(ByVal value As ReceiveAccountItem)
      MyBase.List.Remove(value)
    End Sub
    Public Sub Remove(ByVal value As ReceiveAccountItemCollection)
      For i As Integer = 0 To value.Count - 1
        Me.Remove(value(i))
      Next
    End Sub
    Public Sub Remove(ByVal index As Integer)
      MyBase.List.RemoveAt(index)
    End Sub
#End Region

#Region "ICloneable"
    Public Function Clone() As Object Implements System.ICloneable.Clone
      Dim newColl As New ReceiveAccountItemCollection
      newColl.m_receive = Me.m_receive
      newColl.m_isDebit = Me.m_isDebit
      For Each oldItem As ReceiveAccountItem In Me
        newColl.Add(CType(oldItem.Clone, ReceiveAccountItem))
      Next
      Return newColl
    End Function
#End Region


    Public Class ReceiveAccountItemEnumerator
      Implements IEnumerator

#Region "Members"
      Private m_baseEnumerator As IEnumerator
      Private m_temp As IEnumerable
#End Region

#Region "Construtor"
      Public Sub New(ByVal mappings As ReceiveAccountItemCollection)
        Me.m_temp = mappings
        Me.m_baseEnumerator = Me.m_temp.GetEnumerator
      End Sub
#End Region

      Public ReadOnly Property Current() As Object Implements System.Collections.IEnumerator.Current
        Get
          Return CType(Me.m_baseEnumerator.Current, ReceiveAccountItem)
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

  Public Class ReceiveForList

    Public Overrides Function Equals(ByVal obj As Object) As Boolean
      If obj Is Nothing Then
        Return False
      End If
      Return CType(obj, ReceiveForList).Id = Me.Id AndAlso CType(obj, ReceiveForList).RefCode = Me.RefCode AndAlso CType(obj, ReceiveForList).RefTypeId = Me.RefTypeId
      'Return CType
    End Function
    Public Property Id As Integer
    Public Property Selected As Boolean
    Public Property SelectedForDeleted As Boolean
    Public Property Code As String
    Public Property RefId As Integer
    Public Property RefCode As String
    Public Property RefType As String
    Public Property RefTypeId As Integer
    Public Property RefDocDate As Date
    Public Property RefDueDate As Date
    Public Property RefCreditPeriod As Integer
    Public Property RefAmount As Decimal
    Public Property RefPaid As Decimal
    Public Property JustAdded As Boolean = False
    Public Property Note As String
    Public ReadOnly Property RefRemain As Decimal
      Get
        Return RefAmount - RefPaid
      End Get
    End Property
    Public Property Amount As Decimal




    Public Shared Function GetPaymentList(ByVal filters As Filter()) As List(Of ReceiveForList)
      Dim params() As SqlParameter
      If Not filters Is Nothing AndAlso filters.Length > 0 Then
        ReDim params(filters.Length - 1)
        For i As Integer = 0 To filters.Length - 1
          params(i) = New SqlParameter("@" & filters(i).Name, filters(i).Value)
        Next
      End If
      Dim sqlConString As String = RecentCompanies.CurrentCompany.ConnectionString
      Dim ds As DataSet = SqlHelper.ExecuteDataset(sqlConString _
      , CommandType.StoredProcedure _
      , "GetReceiveForList" _
      , params _
      )
      Dim ret As New List(Of ReceiveForList)

      For Each row As DataRow In ds.Tables(0).Rows
        Dim deh As New DataRowHelper(row)
        Dim ri As New ReceiveForList
        ri.Id = deh.GetValue(Of Integer)("Id")
        ri.Code = deh.GetValue(Of String)("Code")
        ri.RefId = deh.GetValue(Of Integer)("RefId")
        ri.RefCode = deh.GetValue(Of String)("RefCode")
        ri.RefType = deh.GetValue(Of String)("RefType")
        ri.RefTypeId = deh.GetValue(Of Integer)("RefTypeId")
        ri.RefDocDate = deh.GetValue(Of Date)("RefDocDate")
        ri.RefDueDate = deh.GetValue(Of Date)("RefDueDate")
        ri.RefAmount = deh.GetValue(Of Decimal)("RefAmount")
        ri.RefPaid = deh.GetValue(Of Decimal)("RefPaid")
        ri.Note = ""
        ret.Add(ri)
      Next
      Return ret
    End Function

  End Class
End Namespace
