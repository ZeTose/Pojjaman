Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.TextHelper
Imports System.Collections.Generic

Namespace Longkong.Pojjaman.BusinessLogic
  Public Class Stock
    Public Property VatCodes As List(Of String)
    Public Property GLCode As String
    Public Property GLNote As String
    Public Property Note As String
    Public Property Id As Integer
    Public Property Type As Integer

    Function GetVatCodes() As String
      Dim ret As String = ""
      For Each vc As String In VatCodes
        ret &= "," & vc
      Next
      ret = ret.TrimStart(","c)
      Return ret
    End Function
  End Class

  Public Class PaySelectionStatus
    Inherits CodeDescription

#Region "Constructors"
    Public Sub New(ByVal value As Integer)
      MyBase.New(value)
    End Sub
#End Region

#Region "Properties"
    Public Overrides ReadOnly Property CodeName() As String
      Get
        Return "pays_status"
      End Get
    End Property
#End Region

  End Class
  Public Class PaySelection
    Inherits SimpleBusinessEntityBase
    Implements IGLAble, IWitholdingTaxable, IPrintableEntity, IPayable, IHasIBillablePerson, ICancelable, IVatable

#Region "Members"
    Private m_supplier As Supplier
    Private m_docDate As Date

    Private m_note As String
    Private m_creditPeriod As Long

    Private m_status As PaySelectionStatus

    Private m_payment As Payment
    Private m_je As JournalEntry
    Private m_whtcol As WitholdingTaxCollection

    Private m_itemCollection As BillAcceptanceItemCollection

    Private m_vat As Vat

    Private m_refWHTCollection As New ArrayList
    Private m_realTaxBaes As Decimal
#End Region

#Region "Constructors"
    Private _getCCFromItem As CostCenter
    Public Sub New()
      MyBase.New()
    End Sub
    Public Sub New(ByVal code As String)
      MyBase.New(code)
    End Sub
    Public Sub New(ByVal id As Integer)
      MyBase.New(id)
    End Sub
    Public Sub New(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
      Me.Construct(ds, aliasPrefix)
    End Sub
    Public Sub New(ByVal dr As System.Data.DataRow, ByVal aliasPrefix As String)
      Me.Construct(dr, aliasPrefix)
    End Sub
    Protected Overloads Overrides Sub Construct(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
      Dim dr As DataRow = ds.Tables(0).Rows(0)
      Construct(dr, aliasPrefix)
    End Sub
    Protected Overloads Overrides Sub Construct()
      MyBase.Construct()
      With Me
        .m_vat = New Vat(Me)
        .m_vat.Direction.Value = 1
        .m_supplier = New Supplier
        .m_creditPeriod = 0
        .m_note = ""
        .m_docDate = Date.Now.Date
        .m_status = New PaySelectionStatus(-1)
        .m_payment = New Payment(Me)
        .m_je = New JournalEntry(Me)
        .m_je.DocDate = Me.m_docDate
        .m_whtcol = New WitholdingTaxCollection
        .m_whtcol.Direction = New WitholdingTaxDirection(1)
        .m_payment.DocDate = .m_je.DocDate
        m_itemCollection = New BillAcceptanceItemCollection(Me)
        .AutoCodeFormat = New AutoCodeFormat(Me)
      End With
    End Sub
    Protected Overloads Overrides Sub Construct(ByVal dr As System.Data.DataRow, ByVal aliasPrefix As String)
      MyBase.Construct(dr, aliasPrefix)
      With Me

        If dr.Table.Columns.Contains("supplier.supplier_id") Then
          If Not dr.IsNull("supplier.supplier_id") Then
            .m_supplier = New Supplier(dr, "supplier.")
          End If
        Else
          If Not dr.IsNull(aliasPrefix & "pays_supplier") Then
            .m_supplier = New Supplier(CInt(dr(aliasPrefix & "pays_supplier")))
          End If
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "pays_creditperiod") AndAlso Not dr.IsNull(aliasPrefix & "pays_creditperiod") Then
          .m_creditPeriod = CInt(dr(aliasPrefix & "pays_creditperiod"))
        End If

        If dr.Table.Columns.Contains("pays_docDate") AndAlso Not dr.IsNull(aliasPrefix & "pays_docDate") Then
          .m_docDate = CDate(dr(aliasPrefix & "pays_docDate"))
        End If

        If dr.Table.Columns.Contains("pays_note") AndAlso Not dr.IsNull(aliasPrefix & "pays_note") Then
          .m_note = CStr(dr(aliasPrefix & "pays_note"))
        End If

        If dr.Table.Columns.Contains("pays_status") AndAlso Not dr.IsNull(aliasPrefix & "pays_status") Then
          .m_status = New PaySelectionStatus(CInt(dr(aliasPrefix & "pays_status")))
        End If

        .m_payment = New Payment(Me)

        .m_je = New JournalEntry(Me)

        .m_whtcol = New WitholdingTaxCollection(Me)
        .m_whtcol.Direction = New WitholdingTaxDirection(1)

        .m_vat = New Vat(Me)
        .m_vat.Direction.Value = 1

        m_itemCollection = New BillAcceptanceItemCollection(Me)
        CreateRefDocs()
      End With
      Me.AutoCodeFormat = New AutoCodeFormat(Me)
    End Sub
    Public Function FindStock(ByVal id As Integer, ByVal type As Integer) As Stock
      For Each s As Stock In Refinform
        If s.Id = id AndAlso s.Type = type Then
          Return s
        End If
      Next
    End Function
    Private Sub CreateRefDocs()
      Dim ds As DataSet = SqlHelper.ExecuteDataset(Me.ConnectionString _
                 , CommandType.StoredProcedure _
                 , "GetPayselectionItemRefDoc" _
                 , New SqlParameter("@pays_id", Me.Id))

      For Each row As DataRow In ds.Tables(0).Rows
        Dim dh As New DataRowHelper(row)
        Dim id, type As Integer
        id = dh.GetValue(Of Integer)("stock_id")
        type = dh.GetValue(Of Integer)("stock_type")
        Dim s As Stock = FindStock(id, type)
        If s Is Nothing Then
          s = New Stock
          s.Id = id
          s.Type = type
          s.GLCode = dh.GetValue(Of String)("GLCode")
          s.GLNote = dh.GetValue(Of String)("GLNote")
          s.Note = dh.GetValue(Of String)("Note")
          s.VatCodes = New List(Of String)
          Refinform.Add(s)
        End If
        Dim vatcode As String = dh.GetValue(Of String)("VatCode")
        s.VatCodes.Add(vatcode)
      Next
    End Sub
#End Region

#Region "Properties"
    Private m_RefDocs As List(Of Stock)
    Public ReadOnly Property Refinform As List(Of Stock)
      Get
        If m_RefDocs Is Nothing Then
          m_RefDocs = New List(Of Stock)
        End If
        Return m_RefDocs
      End Get
    End Property
    Public Property RefWHTCollection() As ArrayList      Get        Return m_refWHTCollection      End Get      Set(ByVal Value As ArrayList)        m_refWHTCollection = Value      End Set    End Property
    Public Property ItemCollection() As BillAcceptanceItemCollection
      Get
        Return m_itemCollection
      End Get
      Set(ByVal Value As BillAcceptanceItemCollection)
        m_itemCollection = Value
      End Set
    End Property
    Public Property RealTaxBase As Decimal
      Get
        Return m_realTaxBaes
      End Get
      Set(ByVal value As Decimal)
        m_realTaxBaes = value
      End Set
    End Property
    Public Property Supplier() As Supplier
      Get
        Return m_supplier
      End Get
      Set(ByVal Value As Supplier)
        Dim oldPerson As IBillablePerson = m_supplier
        If (oldPerson Is Nothing AndAlso Not Value Is Nothing) _          OrElse (Not oldPerson Is Nothing AndAlso Not Value Is Nothing AndAlso oldPerson.Id <> Value.Id) Then          If Not Me.m_whtcol Is Nothing Then
            For Each wht As WitholdingTax In m_whtcol
              wht.UpdateRefDoc(Value, True)
            Next
          End If
        End If
        m_supplier = Value
      End Set
    End Property
    Public Property DocDate() As Date Implements IPayable.Date, IGLAble.Date, IWitholdingTaxable.Date, IVatable.Date
      Get
        Return m_docDate
      End Get
      Set(ByVal Value As Date)
        m_docDate = Value
        Me.m_je.DocDate = Value
      End Set
    End Property
    Public Property Note() As String Implements IPayable.Note, IGLAble.Note
      Get
        Return m_note
      End Get
      Set(ByVal Value As String)
        m_note = Value
        'Dim config As Object = Configuration.GetConfig("PutGRNoteInOtherTabs")
        'Dim putit As Boolean = False
        'If Not config Is Nothing Then
        'putit = CBool(config)
        'End If        'If putit Then        'If Not Me.Payment Is Nothing Then        Me.Payment.Note = m_note
        'End If        'If Not Me.JournalEntry Is Nothing Then        Me.JournalEntry.Note = m_note
        'End If        'End If
      End Set
    End Property
    Public Property CreditPeriod() As Long
      Get
        Return m_creditPeriod
      End Get
      Set(ByVal Value As Long)
        m_creditPeriod = Value
      End Set
    End Property

    Public Overrides Property Status() As CodeDescription
      Get
        Return m_status
      End Get
      Set(ByVal Value As CodeDescription)
        m_status = CType(Value, PaySelectionStatus)
      End Set
    End Property
    Public ReadOnly Property Gross() As Decimal
      Get
        Return Me.ItemCollection.Amount
      End Get
    End Property
    Public ReadOnly Property Retention() As Decimal
      Get
        Return Me.ItemCollection.GetRetention
      End Get
    End Property
    Public ReadOnly Property BeforeTax As Decimal
      Get
        'Return Me.ItemCollection.GetBeforeTax
        Dim ret As Decimal = 0
        For Each doc As BillAcceptanceItem In Me.ItemCollection         
            ret += doc.BeforeTax
        Next
        Return ret
      End Get
    End Property
    Public ReadOnly Property RemainingAmountAfter() As Decimal
      Get
        Return Me.ItemCollection.RemainingAmount
      End Get
    End Property
    Public ReadOnly Property ItemCount() As Integer
      Get
        Return Me.ItemCollection.Count
      End Get
    End Property
    Public Overrides ReadOnly Property ClassName() As String
      Get
        Return "PaySelection"
      End Get
    End Property
    Public Overrides ReadOnly Property Prefix() As String
      Get
        Return "pays"
      End Get
    End Property
    Public Overrides ReadOnly Property TableName() As String
      Get
        Return "PaySelection"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.PaySelection.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.PaySelection"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.PaySelection"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.PaySelection.ListLabel}"
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
      Dim myDatatable As New TreeTable("PaySelection")

      myDatatable.Columns.Add(New DataColumn("paysi_parentEntityType", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("paysi_parentEntity", GetType(Integer)))

      myDatatable.Columns.Add(New DataColumn("paysi_linenumber", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("paysi_entity", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("paysi_entityType", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("Code", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Button", GetType(String)))

      Dim dateCol As New DataColumn("DocDate", GetType(Date))
      dateCol.DefaultValue = Date.MinValue
      myDatatable.Columns.Add(dateCol)

      dateCol = New DataColumn("DueDate", GetType(Date))
      dateCol.DefaultValue = Date.MinValue
      myDatatable.Columns.Add(dateCol)

      myDatatable.Columns.Add(New DataColumn("paysi_amt", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("UnpaidAmount", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("RemainingAmount", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("RealAmount", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("paysi_note", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Retention", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("PlusRetention", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("RemainningBalance", GetType(String)))

      'เพื่อให้แสดง error ตามคอลัมน์เป็นภาษาที่ต้องการ
      Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
      myDatatable.Columns("Code").Caption = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaySelectionDetail.CodeHeaderText}")
      myDatatable.Columns("paysi_amt").Caption = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaySelectionDetail.AmountHeaderText}")
      Return myDatatable
    End Function
#End Region

#Region "Methods"
    Private Sub ResetID(ByVal oldid As Integer, ByVal oldpay As Integer, ByVal oldje As Integer, ByVal oldVatId As Integer)
      Me.Id = oldid
      Me.m_payment.Id = oldpay
      Me.m_je.Id = oldje
      Me.m_vat.Id = oldVatId
      If Not Me.WitholdingTaxCollection Is Nothing Then
        Me.WitholdingTaxCollection.ResetId()
      End If
    End Sub
    Public Overloads Overrides Function Save(ByVal currentUserId As Integer) As SaveErrorException
      With Me

        'Hack by pui ใช้แล้วไปเปลี่ยนตอน save wht ให้ดึง Me.RealTaxBase แทน ไม่งั้นมัน Lock
        Me.RealTaxBase = Me.GetTaxBase

        If Originated Then
          If Not Supplier Is Nothing Then
            If Supplier.Canceled Then
              Return New SaveErrorException(StringParserService.Parse("${res:Global.Error.CanceledSupplier}"), New String() {Supplier.Code})
            End If
          End If
        End If

        If Me.ItemCollection.Count <= 0 Then
          Return New SaveErrorException(Me.StringParserService.Parse("${res:Global.Error.NoItem}"))
        End If

        'If Me.MaxRowIndex < 0 Then '.ItemTable.Childs.Count = 0 Then
        '    Return New SaveErrorException(Me.StringParserService.Parse("${res:Global.Error.NoItem}"))
        'End If
        Dim returnVal As System.Data.SqlClient.SqlParameter = New SqlParameter
        returnVal.ParameterName = "RETURN_VALUE"
        returnVal.DbType = DbType.Int32
        returnVal.Direction = ParameterDirection.ReturnValue
        returnVal.SourceVersion = DataRowVersion.Current

        ' สร้าง ArrayList จาก Item ของ  SqlParameter ...
        Dim paramArrayList As New ArrayList

        paramArrayList.Add(returnVal)
        If Me.Originated Then
          paramArrayList.Add(New SqlParameter("@pays_id", Me.Id))
        End If

        Dim theTime As Date = Now
        Dim theUser As New User(currentUserId)

        If Me.m_je.Status.Value = 4 Then
          Me.Status.Value = 4
          Me.m_payment.Status.Value = 4
          Me.m_whtcol.SetStatus(4)
          Me.m_vat.Status.Value = 4
        End If
        If Me.Status.Value = 0 Then
          Me.m_payment.Status.Value = 0
          Me.m_whtcol.SetStatus(0)
          Me.m_vat.Status.Value = 0
          Me.m_je.Status.Value = 0
        End If
        If Me.Status.Value = -1 Then
          Me.Status.Value = 2
        End If

        '---- AutoCode Format --------
        Me.m_je.RefreshGLFormat()
        If Not AutoCodeFormat Is Nothing Then


          Select Case Me.AutoCodeFormat.CodeConfig.Value
            Case 0
              If Me.AutoGen Then 'And Me.Code.Length = 0 Then
                Me.Code = Me.GetNextCode
              End If
              Me.m_je.DontSave = True
              Me.m_je.Code = ""
              Me.m_je.DocDate = Me.DocDate
            Case 1
              'ตาม entity
              If Me.AutoGen Then 'And Me.Code.Length = 0 Then
                Me.Code = Me.GetNextCode
              End If
              Me.m_je.Code = Me.Code
            Case 2
              'ตาม gl
              If Me.m_je.AutoGen Then
                Me.m_je.Code = m_je.GetNextCode
              End If
              Me.Code = Me.m_je.Code
            Case Else
              'แยก
              If Me.AutoGen Then 'And Me.Code.Length = 0 Then
                Me.Code = Me.GetNextCode
              End If
              If Me.m_je.AutoGen Then
                Me.m_je.Code = m_je.GetNextCode
              End If
          End Select
        Else
          If Me.AutoGen Then 'And Me.Code.Length = 0 Then
            Me.Code = Me.GetNextCode
          End If
          If Me.m_je.AutoGen Then
            Me.m_je.Code = m_je.GetNextCode
          End If
        End If
        Me.m_payment.Code = m_je.Code
        Me.m_payment.DocDate = m_je.DocDate
        If Me.AutoCodeFormat.CodeConfig.Value = 0 Then
          Me.m_payment.Code = Me.Code
          Me.m_payment.DocDate = Me.DocDate
        End If
        Me.AutoGen = False
        Me.m_payment.AutoGen = False
        Me.m_je.AutoGen = False
        paramArrayList.Add(New SqlParameter("@pays_code", Me.Code))
        paramArrayList.Add(New SqlParameter("@pays_docDate", Me.ValidDateOrDBNull(Me.DocDate)))
        paramArrayList.Add(New SqlParameter("@pays_supplier", Me.ValidIdOrDBNull(Me.Supplier)))
        paramArrayList.Add(New SqlParameter("@pays_creditPeriod", Me.CreditPeriod))
        paramArrayList.Add(New SqlParameter("@pays_note", Me.Note))
        paramArrayList.Add(New SqlParameter("@pays_gross", Me.Gross))
        paramArrayList.Add(New SqlParameter("@pays_status", Me.Status.Value))

        SetOriginEditCancelStatus(paramArrayList, currentUserId, theTime)

        ' สร้าง SqlParameter จาก ArrayList ...
        Dim sqlparams() As SqlParameter
        sqlparams = CType(paramArrayList.ToArray(GetType(SqlParameter)), SqlParameter())
        Dim trans As SqlTransaction
        Dim conn As New SqlConnection(Me.ConnectionString)
        conn.Open()
        trans = conn.BeginTransaction()

        'HACK================================
        SimpleBusinessEntityBase.Connection = conn
        SimpleBusinessEntityBase.Transaction = trans
        'HACK================================

        Dim oldid As Integer = Me.Id
        Dim oldpay As Integer = Me.m_payment.Id
        Dim oldVatId As Integer = Me.m_vat.Id
        If Not Me.WitholdingTaxCollection Is Nothing Then
          Me.WitholdingTaxCollection.SaveOldID()
        End If
        Dim oldje As Integer = Me.m_je.Id

        Try
          Me.ExecuteSaveSproc(conn, trans, returnVal, sqlparams, theTime, theUser)
          If IsNumeric(returnVal.Value) Then
            Select Case CInt(returnVal.Value)
              Case -1, -2, -5
                trans.Rollback()
                Me.ResetID(oldid, oldpay, oldje, oldVatId)
                Return New SaveErrorException(returnVal.Value.ToString)
              Case Else
            End Select
          ElseIf IsDBNull(returnVal.Value) OrElse Not IsNumeric(returnVal.Value) Then
            trans.Rollback()
            Me.ResetID(oldid, oldpay, oldje, oldVatId)
            Return New SaveErrorException(returnVal.Value.ToString)
          End If

          SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "ClearPayselectionItemPVList", New SqlParameter("@pays_id", Me.Id))

          SaveDetail(Me.Id, conn, trans)
          Dim cc As CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
          Dim mycc As CostCenter = GetCCFromItem()
          If Not mycc Is Nothing Then
            Me.m_payment.CCId = mycc.Id
            Me.m_whtcol.SetCCId(mycc.Id)
            Me.m_vat.SetCCId(mycc.Id)
          ElseIf Not cc Is Nothing Then
            Me.m_payment.CCId = cc.Id
            Me.m_whtcol.SetCCId(cc.Id)
            Me.m_vat.SetCCId(cc.Id)
          End If
          Dim savePaymentError As SaveErrorException = Me.m_payment.Save(currentUserId, conn, trans)
          If Not IsNumeric(savePaymentError.Message) Then
            trans.Rollback()
            Me.ResetID(oldid, oldpay, oldje, oldVatId)
            Return savePaymentError
          Else
            Select Case CInt(savePaymentError.Message)
              Case -1, -2, -5
                trans.Rollback()
                Me.ResetID(oldid, oldpay, oldje, oldVatId)
                Return savePaymentError
              Case Else
            End Select
          End If

          If Not Me.NoVat Then
            Dim saveVatError As SaveErrorException = Me.m_vat.Save(currentUserId, conn, trans)
            If Not IsNumeric(saveVatError.Message) Then
              trans.Rollback()
              Me.ResetID(oldid, oldpay, oldje, oldVatId)
              Return saveVatError
            Else
              Select Case CInt(saveVatError.Message)
                Case -1, -2, -5
                  trans.Rollback()
                  Me.ResetID(oldid, oldpay, oldje, oldVatId)
                  Return saveVatError
                Case Else
              End Select
            End If
          End If

          If Not Me.m_whtcol Is Nothing AndAlso Me.m_whtcol.Count >= 0 Then
            Dim saveWhtError As SaveErrorException = Me.m_whtcol.Save(currentUserId, conn, trans)
            If Not IsNumeric(saveWhtError.Message) Then
              trans.Rollback()
              Me.ResetID(oldid, oldpay, oldje, oldVatId)
              Return saveWhtError
            Else
              Select Case CInt(saveWhtError.Message)
                Case -1, -2, -5
                  trans.Rollback()
                  Me.ResetID(oldid, oldpay, oldje, oldVatId)
                  Return saveWhtError
                Case Else
              End Select
            End If
          End If

          If Me.m_je.Status.Value = -1 Then
            m_je.Status.Value = 3
          End If
          Dim saveJeError As SaveErrorException = Me.m_je.Save(currentUserId, conn, trans)
          If Not IsNumeric(saveJeError.Message) Then
            trans.Rollback()
            Me.ResetID(oldid, oldpay, oldje, oldVatId)
            Return saveJeError
          Else
            Select Case CInt(saveJeError.Message)
              Case -1, -5
                trans.Rollback()
                Me.ResetID(oldid, oldpay, oldje, oldVatId)
                Return saveJeError
              Case -2
                'Post ไปแล้ว
                Return saveJeError
              Case Else
            End Select
          End If

          Me.DeleteRef(conn, trans)
          SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdateGR_PaySRef" _
          , New SqlParameter("@pays_id", Me.Id))
          SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdatePCN_PaySRef" _
          , New SqlParameter("@pays_id", Me.Id))
          SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdateBillA_PaySRef" _
          , New SqlParameter("@pays_id", Me.Id))
          SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdateEQMaint_PaySRef" _
          , New SqlParameter("@pays_id", Me.Id))
          SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdateAPO_PaySRef" _
          , New SqlParameter("@pays_id", Me.Id))
          If Me.Status.Value = 0 Then
            Me.CancelRef(conn, trans)
          End If

          SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdatePayselectionItemPVList", New SqlParameter("@pays_id", Me.Id))

          '==============================AUTOGEN==========================================
          Dim saveAutoCodeError As SaveErrorException = SaveAutoCode(conn, trans)
          If Not IsNumeric(saveAutoCodeError.Message) Then
            trans.Rollback()
            ResetID(oldid, oldpay, oldVatId, oldje)
            Return saveAutoCodeError
          Else
            Select Case CInt(saveAutoCodeError.Message)
              Case -1, -2, -5
                trans.Rollback()
                ResetID(oldid, oldpay, oldVatId, oldje)
                Return saveAutoCodeError
              Case Else
            End Select
          End If
          '==============================AUTOGEN==========================================

          trans.Commit()

          trans = conn.BeginTransaction()
          For Each refwhtcoll As WitholdingTaxCollection In m_refWHTCollection
            For Each refw As WitholdingTax In refwhtcoll
              refw.AutoGen = False
            Next
            Dim saverefWHTError As SaveErrorException = refwhtcoll.Save(currentUserId, conn, trans)
            If Not IsNumeric(saverefWHTError.Message) Then
              trans.Rollback()
              Me.ResetID(oldid, oldpay, oldje, oldVatId)
              Return saverefWHTError
            Else
              Select Case CInt(saverefWHTError.Message)
                Case -1, -2, -5
                  trans.Rollback()
                  Me.ResetID(oldid, oldpay, oldje, oldVatId)
                  Return saverefWHTError
                Case Else
              End Select
            End If
          Next
          trans.Commit()
          Return New SaveErrorException(returnVal.Value.ToString)
        Catch ex As SqlException
          trans.Rollback()
          Me.ResetID(oldid, oldpay, oldje, oldVatId)
          Return New SaveErrorException(ex.ToString)
        Catch ex As Exception
          trans.Rollback()
          Me.ResetID(oldid, oldpay, oldje, oldVatId)
          Return New SaveErrorException(ex.ToString)
        Finally
          conn.Close()
          'HACK================================
          SimpleBusinessEntityBase.Connection = Nothing
          SimpleBusinessEntityBase.Transaction = Nothing
          'HACK================================
        End Try
      End With
    End Function
    Public Overrides Function GetNextCode() As String
      Dim autoCodeFormat As String = Me.Code 'Entity.GetAutoCodeFormat(Me.EntityId)
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
    Private Function GetRefIdString() As String
      Dim ret As String = ""
      For Each billi As BillAcceptanceItem In Me.ItemCollection
        ret &= billi.Id.ToString & ","
      Next
      If ret.EndsWith(",") Then
        ret = ret.Substring(0, Len(ret) - 1)
      End If
      Return ret
    End Function
    Private Function GetRefBAIdString() As String
      Dim ret As String = ""
      For Each billi As BillAcceptanceItem In Me.ItemCollection
        If billi.ParentId <> 0 And billi.ParentType = 60 Then
          ret &= billi.ParentId.ToString & ","
        End If
      Next
      If ret.EndsWith(",") Then
        ret = ret.Substring(0, Len(ret) - 1)
      End If
      Return ret
    End Function
    Private Function SaveDetail(ByVal parentID As Integer, ByVal conn As SqlConnection, ByVal trans As SqlTransaction) As Integer
      Dim da As New SqlDataAdapter("Select * from PayselectionItem where paysi_pays=" & Me.Id, conn)
      Dim ds As New DataSet

      Dim cmdBuilder As New SqlCommandBuilder(da)
      da.SelectCommand.Transaction = trans
      da.DeleteCommand = cmdBuilder.GetDeleteCommand
      da.DeleteCommand.Transaction = trans
      da.InsertCommand = cmdBuilder.GetInsertCommand
      da.InsertCommand.Transaction = trans
      da.UpdateCommand = cmdBuilder.GetUpdateCommand
      da.UpdateCommand.Transaction = trans
      cmdBuilder = Nothing
      da.FillSchema(ds, SchemaType.Mapped, "PayselectionItem")
      da.Fill(ds, "PayselectionItem")

      Dim dt As DataTable = ds.Tables("PayselectionItem")

      Dim i As Integer = 0
      With ds.Tables("PayselectionItem")
        For Each row As DataRow In .Rows
          row.Delete()
        Next
        For Each billi As BillAcceptanceItem In Me.ItemCollection
          i += 1
          Dim dr As DataRow = .NewRow
          dr("paysi_pays") = Me.Id
          dr("paysi_linenumber") = i
          dr("paysi_parententity") = billi.ParentId
          dr("paysi_parententityType") = billi.ParentType
          dr("paysi_parententityCode") = billi.ParentCode
          dr("stock_id") = billi.Id
          dr("stock_type") = billi.EntityId
          dr("stock_code") = billi.Code
          dr("stock_docdate") = billi.Date
          dr("stock_creditprd") = billi.CreditPeriod
          dr("paysi_amt") = billi.Amount
          dr("paysi_billedamt") = billi.BilledAmount
          dr("paysi_unpaidamt") = billi.UnpaidAmount
          dr("stock_beforetax") = billi.BeforeTax
          dr("stock_aftertax") = billi.AfterTax
          dr("stock_taxBase") = billi.TaxBase
          dr("stock_note") = billi.Note
          dr("stock_status") = Me.Status.Value
          dr("stock_retention") = billi.Retention
          dr("paysi_retentiontype") = billi.RetentionType
          .Rows.Add(dr)
        Next
      End With

      AddHandler da.RowUpdated, AddressOf tmpDa_MyRowUpdated
      da.Update(GetDeletedRows(dt))
      da.Update(dt.Select("", "", DataViewRowState.ModifiedCurrent))
      da.Update(dt.Select("", "", DataViewRowState.Added))

    End Function
    Private Sub tmpDa_MyRowUpdated(ByVal sender As Object, ByVal e As System.Data.SqlClient.SqlRowUpdatedEventArgs)
      If e.StatementType = StatementType.Insert Then e.Status = UpdateStatus.SkipCurrentRow
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
    Public Function GetCCFromItem() As CostCenter
      Dim dummyCC As CostCenter
      For Each item As BillAcceptanceItem In Me.ItemCollection
        Dim thisCC As CostCenter = GetCCFromDocTypeAndId(item.EntityId, item.Id)
        If dummyCC IsNot Nothing AndAlso dummyCC.Id <> thisCC.Id Then
          Return CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
        End If
        dummyCC = thisCC
      Next
      Return dummyCC
    End Function

    Public Function GetCostCenterFromRefDoc(ByVal stock_id As Integer, ByVal stock_type As Integer) As CostCenter
      Try
        Dim dsr As DataSet = SqlHelper.ExecuteDataset( _
            Me.ConnectionString _
            , CommandType.StoredProcedure _
            , "GetCCForBillAccaptance" _
            , New SqlParameter("@stock_id", stock_id) _
            , New SqlParameter("@stock_type", stock_type) _
            )
        If dsr.Tables(0).Rows.Count > 0 Then
          If Not dsr.Tables(0).Rows(0).IsNull("cc_id") Then
            Return New CostCenter(dsr.Tables(0).Rows(0), "")
          End If
        End If
        Return New CostCenter
      Catch ex As Exception
        MessageBox.Show(ex.Message)
      End Try
    End Function
#End Region

#Region "IPayable"
    Public Function AmountToPay() As Decimal Implements IPayable.AmountToPay
      Return Me.Gross
    End Function
    Public Property DueDate() As Date Implements IPayable.DueDate
      Get
        Try
          Return Me.DocDate.AddDays(Me.CreditPeriod)
        Catch ex As Exception
          Return Me.DocDate
        End Try
      End Get
      Set(ByVal Value As Date)

      End Set
    End Property
    Public Property Payment() As Payment Implements IPayable.Payment
      Get
        Return m_payment
      End Get
      Set(ByVal Value As Payment)
        m_payment = Value
      End Set
    End Property
    Public ReadOnly Property Recipient() As IBillablePerson Implements IPayable.Recipient
      Get
        Return Me.Supplier
      End Get
    End Property
    Public Function RemainingAmount() As Decimal Implements IPayable.RemainingAmount
      'Undone
      Return AmountToPay()
    End Function
#End Region

#Region "IGLAble"
    Public Function GetDefaultGLFormat() As GLFormat Implements IGLAble.GetDefaultGLFormat
      If Not Me.AutoCodeFormat.GLFormat Is Nothing AndAlso Me.AutoCodeFormat.GLFormat.Originated Then
        Return Me.AutoCodeFormat.GLFormat
      End If
      Dim ds As DataSet = SqlHelper.ExecuteDataset(Me.ConnectionString _
      , CommandType.StoredProcedure _
      , "GetGLFormatForEntity" _
      , New SqlParameter("@entity_id", Me.EntityId), New SqlParameter("@default", 1))
      Dim glf As New GLFormat(ds.Tables(0).Rows(0), "")
      Return glf
    End Function    
    Public Function GetJournalEntries() As JournalEntryItemCollection Implements IGLAble.GetJournalEntries
      Dim jiColl As New JournalEntryItemCollection
      Dim ji As JournalEntryItem
      Dim myCC As CostCenter
      myCC = GetCCFromItem()
      If myCC Is Nothing OrElse Not myCC.Originated Then
        myCC = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
      End If
      Dim tmp As Object = Configuration.GetConfig("APRetentionPoint")
      Dim apRetentionPoint As Integer = 0
      If IsNumeric(tmp) Then
        apRetentionPoint = CInt(tmp)
      End If
      Dim retentionHere As Boolean = (apRetentionPoint = 1)

      Dim ccList As New Dictionary(Of Integer, CostCenter)

      For Each doc As BillAcceptanceItem In Me.ItemCollection
        Dim itemCC As CostCenter = GetCCFromDocTypeAndId(doc.EntityId, doc.Id)
        Dim itemCode As String = doc.Code.ToString
        Dim itemType As String = GetTypeNameFromDocType(doc.EntityId)
        If itemCC Is Nothing Then
          itemCC = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
        End If
        Dim myGross As Decimal = doc.AmountForGL
        Dim myRetention As Decimal = doc.RetentionForGL
        Dim myDebt As Decimal = myGross - myRetention
        If myDebt <> 0 Then
          'เจ้าหนี้การค้า
          ji = New JournalEntryItem
          ji.Mapping = "B8.1"
          If retentionHere Then
            ji.Amount = myDebt + doc.Retention
          Else
            ji.Amount = myDebt
          End If
          If Not Me.Supplier.Account Is Nothing AndAlso Me.Supplier.Account.Originated Then
            ji.Account = Me.Supplier.Account
          End If

          ji.CostCenter = itemCC
          ji.Note = itemCode & ":" & itemType
          jiColl.Add(ji)
        End If

        If myRetention <> 0 Then
          'เจ้าหนี้เงินประกันผลงาน
          ji = New JournalEntryItem
          ji.Mapping = "B8.3"
            ji.Amount = myRetention
          ji.CostCenter = itemCC
          ji.Note = itemCode & ":" & itemType
          jiColl.Add(ji)
        End If

        'Retention หัก
        If retentionHere AndAlso doc.Retention <> 0 Then
          ji = New JournalEntryItem
          ji.Mapping = "E3.16"
          ji.Amount = doc.Retention
          ji.CostCenter = itemCC
          ji.Note = Me.Recipient.Name & ":" & itemCode & ":" & itemType
          jiColl.Add(ji)
        End If
      Next

      'ภาษีซื้อ
      If Me.Vat.Amount <> 0 Then
        ji = New JournalEntryItem
        ji.Mapping = "B8.4"
        ji.Amount = Configuration.Format(Me.Vat.Amount, DigitConfig.Price)
        ji.CostCenter = myCC
        jiColl.Add(ji)
      End If

      'ภาษีซื้อไม่ถึงกำหนด
      If Me.Vat.Amount <> 0 Then
        ji = New JournalEntryItem
        ji.Mapping = "B8.5"
        ji.Amount = Configuration.Format(Me.Vat.Amount, DigitConfig.Price)
        ji.CostCenter = myCC
        jiColl.Add(ji)
      End If

      'ภาษีหัก ณ ที่จ่าย
      If Not Me.WitholdingTaxCollection Is Nothing AndAlso Me.WitholdingTaxCollection.Amount > 0 Then
        ji = New JournalEntryItem
        ji.Mapping = "B8.2"
        ji.Amount = Me.WitholdingTaxCollection.Amount
        ji.CostCenter = myCC 'CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
        jiColl.Add(ji)
      End If
      Dim WHTTypeSum As New Hashtable

      For Each wht As WitholdingTax In Me.WitholdingTaxCollection
        If WHTTypeSum.Contains(wht.Type.Value) Then
          WHTTypeSum(wht.Type.Value) = CDec(WHTTypeSum(wht.Type.Value)) + wht.Amount
        Else
          WHTTypeSum(wht.Type.Value) = wht.Amount
        End If
      Next
      Dim typeNum As String
      For Each obj As Object In WHTTypeSum.Keys
        typeNum = CStr(obj)
        If Not (typeNum.Length > 1) Then
          typeNum = "0" & typeNum
        End If
        If Not IsDBNull(Configuration.GetConfig("WHTAcc" & typeNum)) Then
          ji = New JournalEntryItem
          ji.Mapping = "E3.18"
          ji.Amount = CDec(WHTTypeSum(obj))
          ji.Account = New Account(CStr(Configuration.GetConfig("WHTAcc" & typeNum)))
          ji.CostCenter = myCC
          ji.Note = Me.Recipient.Name
          jiColl.Add(ji)
        End If
      Next
      For Each wht As WitholdingTax In Me.WitholdingTaxCollection
        typeNum = CStr(wht.Type.Value)
        If Not (typeNum.Length > 1) Then
          typeNum = "0" & typeNum
        End If
        If Not IsDBNull(Configuration.GetConfig("WHTAcc" & typeNum)) Then
          ji = New JournalEntryItem
          ji.Mapping = "E3.18D"
          ji.Amount = wht.Amount
          ji.Account = New Account(CStr(Configuration.GetConfig("WHTAcc" & typeNum)))
          ji.CostCenter = myCC
          ji.Note = Me.Recipient.Name
          jiColl.Add(ji)
        End If
      Next
      For Each wht As WitholdingTax In Me.WitholdingTaxCollection
        typeNum = CStr(wht.Type.Value)
        If Not (typeNum.Length > 1) Then
          typeNum = "0" & typeNum
        End If
        If Not IsDBNull(Configuration.GetConfig("WHTAcc" & typeNum)) Then
          ji = New JournalEntryItem
          ji.Mapping = "E3.18W"
          ji.Amount = wht.Amount
          ji.Account = New Account(CStr(Configuration.GetConfig("WHTAcc" & typeNum)))
          ji.CostCenter = myCC
          ji.Note = Me.Recipient.Name
          jiColl.Add(ji)
        End If
      Next
      Me.Payment.CCId = myCC.Id

      If Not Me.Payment Is Nothing Then
        jiColl.AddRange(Me.Payment.GetJournalEntries)
      End If
      Return jiColl
    End Function
    Public Property JournalEntry() As JournalEntry Implements IGLAble.JournalEntry
      Get
        Return Me.m_je
      End Get
      Set(ByVal Value As JournalEntry)
        m_je = Value
      End Set
    End Property
#End Region

#Region "IWitholdingTaxable"
    Public Function GetMaximumWitholdingTaxBase() As Decimal Implements IWitholdingTaxable.GetMaximumWitholdingTaxBase
      Return Me.TaxBase
    End Function
    Public Property Person() As IBillablePerson Implements IWitholdingTaxable.Person, IVatable.Person
      Get
        Return Me.Supplier
      End Get
      Set(ByVal Value As IBillablePerson)
        Me.Supplier = CType(Value, Supplier)
      End Set
    End Property
    Public Property WitholdingTaxCollection() As WitholdingTaxCollection Implements IWitholdingTaxable.WitholdingTaxCollection
      Get
        Return m_whtcol
      End Get
      Set(ByVal Value As WitholdingTaxCollection)
        m_whtcol = Value
      End Set
    End Property
#End Region

#Region "IPrintableEntity"
    Public Function GetDefaultFormPath() As String Implements IPrintableEntity.GetDefaultFormPath
      Return "PaySelection"
    End Function
    Public Function GetDefaultForm() As String Implements IPrintableEntity.GetDefaultForm
      Return "PaySelection"
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

      Return dpiColl
    End Function
#End Region

#Region "Delete"
    Public Overrides ReadOnly Property CanDelete() As Boolean
      Get
        Return Me.Status.Value <= 2 AndAlso Not Me.IsReferenced
      End Get
    End Property
    Public Overrides Function Delete() As SaveErrorException
      If Not Me.Originated Then
        Return New SaveErrorException("${res:Global.Error.NoIdError}")
      End If
      Dim myMessage As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      Dim format(0) As String
      format(0) = Me.Code
      If Not myMessage.AskQuestionFormatted("${res:Global.ConfirmDeletePaySelection}", format) Then
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
        SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "DeletePaySelection", New SqlParameter() {New SqlParameter("@pays_id", Me.Id), returnVal})
        SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdatePaymentItemEntityStatus", New SqlParameter("@payment_id", Me.Payment.Id))
        If IsNumeric(returnVal.Value) Then
          Select Case CInt(returnVal.Value)
            Case -1
              trans.Rollback()
              Return New SaveErrorException("${res:Global.PaySelectionIsReferencedCannotBeDeleted}")
            Case Else
          End Select
        ElseIf IsDBNull(returnVal.Value) OrElse Not IsNumeric(returnVal.Value) Then
          trans.Rollback()
          Return New SaveErrorException(returnVal.Value.ToString)
        End If
        Me.DeleteRef(conn, trans)
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

#Region "ICancelable"
    Public ReadOnly Property CanCancel() As Boolean Implements ICancelable.CanCancel
      Get
        Return Me.Status.Value > 1 AndAlso Me.IsCancelable
      End Get
    End Property
    Public Function CancelEntity(ByVal currentUserId As Integer, ByVal theTime As Date) As SaveErrorException Implements ICancelable.CancelEntity
      Me.Status.Value = 0
      Return Me.Save(currentUserId)
    End Function
#End Region

#Region "IHasIBillablePerson"
    Public Property BillablePerson() As IBillablePerson Implements IHasIBillablePerson.BillablePerson
      Get
        Return Me.Supplier
      End Get
      Set(ByVal Value As IBillablePerson)
        If TypeOf Value Is Supplier Then
          Me.Supplier = CType(Value, Supplier)
        End If
      End Set
    End Property
#End Region

#Region "IVatable"
    Public Sub GenVatItems()
      Me.Vat.ItemCollection.Clear()
      Dim i As Integer = 0
      Dim vi As New VatItem
      Dim ptn As String = Entity.GetAutoCodeFormat(vi.EntityId)
      Dim pattern As String = CodeGenerator.GetPattern(ptn, Me)
      pattern = CodeGenerator.GetPattern(pattern)
      Dim lastCode As String = vi.GetLastCode(pattern)
      For Each item As BillAcceptanceItem In Me.ItemCollection
        If item.TaxType.Value <> 0 Then
          i += 1
          Dim vitem As New VatItem
          vitem.LineNumber = i
          Dim newCode As String = CodeGenerator.Generate(ptn, lastCode, Me)
          vitem.Code = newCode
          lastCode = newCode
          vitem.DocDate = Me.DocDate
          vitem.PrintName = Me.Supplier.Name
          vitem.PrintAddress = Me.Supplier.BillingAddress
          vitem.TaxBase = item.TaxBase - Vat.GetTaxBaseDeductedWithoutThisRefDoc(item.Id, item.EntityId, Me.Id, Me.EntityId)
          vitem.TaxRate = CDec(Configuration.GetConfig("CompanyTaxRate"))
          vitem.CcId = item.CostCenterId
          vitem.Refdoc = item.Id
          vitem.RefdocType = item.EntityId
          vitem.BillAcceptanceItem = item
          Me.Vat.ItemCollection.Add(vitem)
        End If
      Next
    End Sub
    Public Sub GenSingleVatItem()
      Me.Vat.ItemCollection.Clear()
      Dim vitem As New VatItem
      vitem.LineNumber = 1
      Dim ptn As String = Entity.GetAutoCodeFormat(vitem.EntityId)
      Dim pattern As String = CodeGenerator.GetPattern(ptn, Me)
      pattern = CodeGenerator.GetPattern(pattern)
      vitem.Code = CodeGenerator.Generate(ptn, vitem.GetLastCode(pattern), Me.DocDate)
      vitem.DocDate = Me.DocDate
      vitem.PrintName = Me.Supplier.Name
      vitem.PrintAddress = Me.Supplier.BillingAddress
      vitem.TaxBase = Me.GetMaximumTaxBase
      vitem.TaxRate = CDec(Configuration.GetConfig("CompanyTaxRate"))
      Me.Vat.ItemCollection.Add(vitem)
    End Sub

    Public Function GetAfterTax() As Decimal Implements IVatable.GetAfterTax
      Return Me.ItemCollection.GetAfterTax
    End Function

    Public Function GetBeforeTax() As Decimal Implements IVatable.GetBeforeTax
      Return Me.ItemCollection.GetBeforeTax
    End Function
    Public Property TaxBase() As Decimal Implements IVatable.TaxBase
      Get
        Return Me.GetTaxBase
      End Get
      Set(ByVal Value As Decimal)

      End Set
    End Property
    Private Function GetTaxBase() As Decimal
      Dim amt As Decimal
      For Each item As BillAcceptanceItem In Me.ItemCollection
        Dim d As Decimal = item.TaxBaseDeducted
        If d = Decimal.MinValue Then
          d = Vat.GetTaxBaseDeductedWithoutThisRefDoc(item.Id, item.EntityId, Me.Id, Me.EntityId)
          item.TaxBaseDeducted = d
        End If
        If item.TaxType.Value <> 0 Then
          amt += item.TaxBase - d
        End If
      Next
      Return amt
    End Function
    Public Function GetMaximumTaxBase() As Decimal Implements IVatable.GetMaximumTaxBase
      Return GetTaxBase()
    End Function

    Public ReadOnly Property NoVat() As Boolean Implements IVatable.NoVat
      Get
        Return False
      End Get
    End Property
    Public Property Vat() As Vat Implements IVatable.Vat
      Get
        Return Me.m_vat
      End Get
      Set(ByVal Value As Vat)
        Me.m_vat = Value
      End Set
    End Property
#End Region

  End Class

  Public Class GoodsReceiptForPaySelection
    Inherits GoodsReceipt

    Public Overrides ReadOnly Property ClassName As String
      Get
        Return "GoodsReceiptForPaySelection"
      End Get
    End Property
    Public Overrides ReadOnly Property Columns() As ColumnCollection
      Get
        Return New ColumnCollection(Me.ClassName, 0)
      End Get
    End Property

  End Class
  Public Class APOpeningBalanceForPaySelection
    Inherits APOpeningBalance

    Public Overrides ReadOnly Property ClassName As String
      Get
        Return "APOpeningBalanceForPaySelection"
      End Get
    End Property
  End Class
  Public Class EqMaintenanceForPaySelection
    Inherits EqMaintenance

    Public Overrides ReadOnly Property ClassName As String
      Get
        Return "EqMaintenanceForPaySelection"
      End Get
    End Property
  End Class
  Public Class PurchaseCNForPaySelection
    Inherits PurchaseCN

    Public Overrides ReadOnly Property ClassName As String
      Get
        Return "PurchaseCNForPaySelection"
      End Get
    End Property
  End Class
  Public Class PurchaseRetentionForPaySelection
    Inherits PurchaseRetention

    Public Overrides ReadOnly Property ClassName As String
      Get
        Return "PurchaseRetentionForPaySelection"
      End Get
    End Property
    Public Overrides ReadOnly Property Columns() As ColumnCollection
      Get
        Return New ColumnCollection(Me.ClassName, 0)
      End Get
    End Property
  End Class
  Public Class PAForPaySelection
    Inherits PA

    Public Overrides ReadOnly Property ClassName As String
      Get
        Return "PAForPaySelection"
      End Get
    End Property
  End Class
End Namespace

