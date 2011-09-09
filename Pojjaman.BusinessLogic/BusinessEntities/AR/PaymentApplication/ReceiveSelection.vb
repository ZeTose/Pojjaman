Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.TextHelper
Namespace Longkong.Pojjaman.BusinessLogic
  Public Class ReceiveSelectionStatus
    Inherits CodeDescription

#Region "Constructors"
    Public Sub New(ByVal value As Integer)
      MyBase.New(value)
    End Sub
#End Region

#Region "Properties"
    Public Overrides ReadOnly Property CodeName() As String
      Get
        Return "receives_status"
      End Get
    End Property
#End Region

  End Class
  Public Class ReceiveSelection
    Inherits SimpleBusinessEntityBase
    Implements IGLAble, IWitholdingTaxable, IReceivable, IVatable, IPrintableEntity, IHasIBillablePerson _
    , ICancelable, ICheckPeriod


#Region "Members"
    Private m_customer As Customer
    Private m_docDate As Date
    Private m_olddocDate As Date

    Private m_note As String
    Private m_creditPeriod As Integer

    Private m_status As ReceiveSelectionStatus

    Private m_itemCollection As SaleBillIssueItemCollection

    Private m_vat As Vat
    Private m_receive As Receive
    Private m_je As JournalEntry
    Private m_whtcol As WitholdingTaxCollection

    Private m_billissues As Hashtable

    Private m_singleVat As Boolean
#End Region

#Region "Constructors"
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
      m_billissues = New Hashtable
      With Me
        .m_customer = New Customer
        .m_creditPeriod = 0
        .m_note = ""
        .m_docDate = Date.Now.Date
        .m_olddocDate = Date.Now.Date
        .m_status = New ReceiveSelectionStatus(-1)
        m_itemCollection = New SaleBillIssueItemCollection(Me)
        m_singleVat = False

        '----------------------------Tab Entities-----------------------------------------
        .m_whtcol = New WitholdingTaxCollection(Me)
        .m_whtcol.Direction = New WitholdingTaxDirection(0)

        .m_vat = New Vat(Me)
        .m_vat.Direction.Value = 0

        .m_je = New JournalEntry(Me)
        .m_je.DocDate = Me.m_docDate

        .m_receive = New Receive(Me)
        .m_receive.DocDate = Me.m_docDate
        '----------------------------End Tab Entities-----------------------------------------
        .AutoCodeFormat = New AutoCodeFormat(Me)
      End With
    End Sub
    Protected Overloads Overrides Sub Construct(ByVal dr As System.Data.DataRow, ByVal aliasPrefix As String)
      MyBase.Construct(dr, aliasPrefix)
      With Me
        If dr.Table.Columns.Contains("customer.cust_id") Then
          If Not dr.IsNull("customer.cust_id") Then
            .m_customer = New Customer(dr, "customer.")
          End If
        Else
          If Not dr.IsNull(aliasPrefix & "receives_cust") Then
            .m_customer = New Customer(CInt(dr(aliasPrefix & "receives_cust")))
          End If
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "receives_creditperiod") AndAlso Not dr.IsNull(aliasPrefix & "receives_creditperiod") Then
          .m_creditPeriod = CInt(dr(aliasPrefix & "receives_creditperiod"))
        End If

        If dr.Table.Columns.Contains("receives_docDate") AndAlso Not dr.IsNull(aliasPrefix & "receives_docDate") Then
          .m_docDate = CDate(dr(aliasPrefix & "receives_docDate"))
          .m_olddocDate = CDate(dr(aliasPrefix & "receives_docDate"))
        End If

        If dr.Table.Columns.Contains("receives_note") AndAlso Not dr.IsNull(aliasPrefix & "receives_note") Then
          .m_note = CStr(dr(aliasPrefix & "receives_note"))
        End If

        If dr.Table.Columns.Contains("receives_status") AndAlso Not dr.IsNull(aliasPrefix & "receives_status") Then
          .m_status = New ReceiveSelectionStatus(CInt(dr(aliasPrefix & "receives_status")))
        End If

        If dr.Table.Columns.Contains("receives_singlevat") AndAlso Not dr.IsNull(aliasPrefix & "receives_singlevat") Then
          .m_singleVat = CBool(dr(aliasPrefix & "receives_singlevat"))
        End If

        .m_receive = New Receive(Me)

        .m_je = New JournalEntry(Me)

        .m_whtcol = New WitholdingTaxCollection(Me)
        .m_whtcol.Direction = New WitholdingTaxDirection(0)

        .m_vat = New Vat(Me)
        m_vat.Direction.Value = 0
        m_itemCollection = New SaleBillIssueItemCollection(Me)

        Me.AutoCodeFormat = New AutoCodeFormat(Me)
      End With
    End Sub
#End Region

#Region "Properties"
    Public Property SingleVat() As Boolean
      Get
        Return Me.m_singleVat
      End Get
      Set(ByVal Value As Boolean)
        Me.m_singleVat = Value
      End Set
    End Property
    Public Property ItemCollection() As SaleBillIssueItemCollection      Get        Return m_itemCollection      End Get      Set(ByVal Value As SaleBillIssueItemCollection)        m_itemCollection = Value      End Set    End Property
    Public Property Customer() As Customer      Get        Return m_customer      End Get      Set(ByVal Value As Customer)        Dim oldPerson As IBillablePerson = m_customer
        If (oldPerson Is Nothing AndAlso Not Value Is Nothing) _          OrElse (Not oldPerson Is Nothing AndAlso Not Value Is Nothing AndAlso oldPerson.Id <> Value.Id) Then          If Not Me.m_whtcol Is Nothing Then
            For Each wht As WitholdingTax In m_whtcol
              wht.UpdateRefDoc(Value, True)
            Next
          End If
        End If        m_customer = Value      End Set    End Property    Public Property DocDate() As Date Implements IReceivable.Date, IGLAble.Date, IWitholdingTaxable.Date, IVatable.Date, ICheckPeriod.DocDate      Get        Return m_docDate      End Get      Set(ByVal Value As Date)        m_docDate = Value      End Set    End Property    Public ReadOnly Property OldDocDate As Date Implements ICheckPeriod.OldDocDate      Get
        Return m_olddocDate
      End Get
    End Property    Public Property Note() As String Implements IReceivable.Note, IGLAble.Note      Get        Return m_note      End Get      Set(ByVal Value As String)        m_note = Value      End Set    End Property    Public Property CreditPeriod() As Integer      Get        Return m_creditPeriod      End Get      Set(ByVal Value As Integer)        m_creditPeriod = Value      End Set    End Property    Public Overrides Property Status() As CodeDescription      Get        Return m_status      End Get      Set(ByVal Value As CodeDescription)        m_status = CType(Value, ReceiveSelectionStatus)      End Set    End Property    Public ReadOnly Property Gross() As Decimal      Get        Return Me.ItemCollection.Amount      End Get    End Property    Public ReadOnly Property RemainingAmountAfter() As Decimal      Get        Return Me.ItemCollection.RemainingAmount      End Get    End Property    Public ReadOnly Property ItemCount() As Integer      Get        Return Me.ItemCollection.Count      End Get    End Property    Public Overrides ReadOnly Property ClassName() As String
      Get
        Return "ReceiveSelection"
      End Get
    End Property
    Public Overrides ReadOnly Property Prefix() As String
      Get
        Return "receives"
      End Get
    End Property
    Public Overrides ReadOnly Property TableName() As String
      Get
        Return "ReceiveSelection"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.ReceiveSelection.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.ReceiveSelection"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.ReceiveSelection"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.ReceiveSelection.ListLabel}"
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
    Public ReadOnly Property BeforeTax() As Decimal      Get        Dim biBeforeTax As Decimal = 0        For Each bi As SaleBillIssueItem In Me.ItemCollection          biBeforeTax += bi.BeforeTax
        Next        Return biBeforeTax      End Get    End Property
    Public ReadOnly Property AfterTax() As Decimal
      Get
        Dim biAftertax As Decimal = 0        For Each bi As SaleBillIssueItem In Me.ItemCollection          biAftertax += bi.AfterTax
        Next        Return biAftertax
      End Get
    End Property
#End Region

#Region "Shared"
    Public Shared Function GetSchemaTable() As TreeTable
      Dim myDatatable As New TreeTable("ReceiveSelection")


      myDatatable.Columns.Add(New DataColumn("receivesi_parentEntityType", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("receivesi_parentEntity", GetType(Integer)))

      myDatatable.Columns.Add(New DataColumn("receivesi_linenumber", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("receivesi_entity", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("receivesi_entityType", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("Code", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Button", GetType(String)))

      Dim dateCol As New DataColumn("DocDate", GetType(Date))
      dateCol.DefaultValue = Date.MinValue
      myDatatable.Columns.Add(dateCol)

      dateCol = New DataColumn("DueDate", GetType(Date))
      dateCol.DefaultValue = Date.MinValue
      myDatatable.Columns.Add(dateCol)

      myDatatable.Columns.Add(New DataColumn("receivesi_amt", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("RetentionAmount", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("UnreceivedAmount", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("RealAmount", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("receivesi_note", GetType(String)))

      'เพื่อให้แสดง error ตามคอลัมน์เป็นภาษาที่ต้องการ
      Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
      myDatatable.Columns("Code").Caption = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ReceiveSelectionDetail.CodeHeaderText}")
      myDatatable.Columns("receivesi_amt").Caption = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ReceiveSelectionDetail.AmountHeaderText}")
      Return myDatatable
    End Function
#End Region

#Region "Methods"
    Public Function ValidateReferenceDocDate(ByVal sbi As SaleBillIssueItem) As Boolean
      If Not sbi Is Nothing Then
        If sbi.Date <= Me.DocDate Then
          Return True
        End If
      End If
      Return False
    End Function
    Private Sub ResetID(ByVal oldid As Integer, ByVal oldreceive As Integer, ByVal oldvat As Integer, ByVal oldje As Integer)
      Me.Id = oldid
      Me.m_receive.Id = oldreceive
      Me.m_vat.Id = oldvat
      Me.m_je.Id = oldje
      If Not Me.WitholdingTaxCollection Is Nothing Then
        Me.WitholdingTaxCollection.ResetId()
      End If
    End Sub
    Private Sub ResetCode(ByVal oldCode As String, ByVal oldautogen As Boolean, ByVal oldJecode As String, ByVal oldjeautogen As Boolean, ByVal oldvatautogen As Boolean)
      Me.Code = oldCode
      Me.AutoGen = oldautogen
      Me.m_je.Code = oldJecode
      Me.m_je.AutoGen = oldjeautogen
      Me.m_vat.AutoGen = oldvatautogen
    End Sub
    Public Function BeforeSave(ByVal currentUserId As Integer) As SaveErrorException

      Dim ValidateError As SaveErrorException

      ''เนื่องจากตอนบันทึกเอกสาร แล้ว Vat มีการเรียก Implement ตัวนี้แล้วเกิด DeadLock บ่อยมาก ๆ เลยเก็บค่านี้ไว้จังหวะก่อนบันทึก แล้วให้ m_vat.Save เรียกตัวนี้แทน
      'Dim sv As New SimpleVat
      'sv = Vat.GetTaxBaseDeductedWithoutThisRefDoc(Me.Id, Me.EntityId, Me.Id, Me.EntityId)
      'Me.TaxBaseDeductedWithoutThisRefDoc = Me.RealTaxBase - sv.TaxBase

      ValidateError = Me.Vat.BeforeSave(currentUserId)
      If Not IsNumeric(ValidateError.Message) Then
        Return ValidateError
      End If

      ValidateError = Me.WitholdingTaxCollection.BeforeSave(currentUserId)
      If Not IsNumeric(ValidateError.Message) Then
        Return ValidateError
      End If

      'ValidateError = Me.Payment.BeforeSave(currentUserId)
      'If Not IsNumeric(ValidateError.Message) Then
      '  Return ValidateError
      'End If

      ValidateError = Me.JournalEntry.BeforeSave(currentUserId)
      If Not IsNumeric(ValidateError.Message) Then
        Return ValidateError
      End If


      Me.m_vat.SetRefDocMaximumTaxBase(Me.GetMaximumTaxBase())

      Dim cc As CostCenter = GetAllCC()
      If cc Is Nothing Then
        cc = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
      End If
      If Not cc Is Nothing Then
        Me.m_receive.CcId = cc.Id
        Me.m_whtcol.SetCCId(cc.Id)
        Me.m_vat.SetCCId(cc.Id)
      End If


      Return New SaveErrorException("0")

    End Function
    Private m_saving As Boolean = False
    Public Overloads Overrides Function Save(ByVal currentUserId As Integer) As SaveErrorException
      With Me
        RefreshTaxBase()

        'Hack by pui ใช้แล้วไปเปลี่ยนตอน save wht ให้ดึง Me.RealTaxBase แทน ไม่งั้นมัน Lock
        Me.RealTaxBase = Me.GetReceiveTaxBase

        m_saving = True
        If Me.ItemCollection.Count = 0 Then
          Return New SaveErrorException(Me.StringParserService.Parse("${res:Global.Error.NoItem}"))
        End If
        Dim returnVal As System.Data.SqlClient.SqlParameter = New SqlParameter
        returnVal.ParameterName = "RETURN_VALUE"
        returnVal.DbType = DbType.Int32
        returnVal.Direction = ParameterDirection.ReturnValue
        returnVal.SourceVersion = DataRowVersion.Current

        ' สร้าง ArrayList จาก Item ของ  SqlParameter ...
        Dim paramArrayList As New ArrayList

        paramArrayList.Add(returnVal)
        If Me.Originated Then
          paramArrayList.Add(New SqlParameter("@receives_id", Me.Id))
        End If

        Dim theTime As Date = Now
        Dim theUser As New User(currentUserId)

        If Me.m_je.Status.Value = 4 Then
          Me.Status.Value = 4
          Me.m_receive.Status.Value = 4
          Me.m_whtcol.SetStatus(4)
          Me.m_vat.Status.Value = 4
        End If
        If Me.Status.Value = 0 Then
          Me.m_receive.Status.Value = 0
          Me.m_whtcol.SetStatus(0)
          Me.m_vat.Status.Value = 0
          Me.m_je.Status.Value = 0
        End If
        If Me.Status.Value = -1 Then
          Me.Status.Value = 2
        End If

        '---- AutoCode Format --------
        Dim oldcode As String
        Dim oldautogen As Boolean
        Dim oldjecode As String
        Dim oldjeautogen As Boolean
        Dim oldvatautogen As Boolean

        oldcode = Me.Code
        oldautogen = Me.AutoGen
        oldjecode = Me.m_je.Code
        oldjeautogen = Me.m_je.AutoGen
        oldvatautogen = Me.Vat.AutoGen

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
        Me.m_receive.Code = m_je.Code
        Me.m_receive.DocDate = m_je.DocDate
        If Me.AutoCodeFormat.CodeConfig.Value = 0 Then
          Me.m_receive.Code = Me.Code
          Me.m_receive.DocDate = Me.DocDate
        End If
        Me.AutoGen = False
        Me.m_receive.AutoGen = False
        Me.m_je.AutoGen = False
        paramArrayList.Add(New SqlParameter("@receives_code", Me.Code))
        paramArrayList.Add(New SqlParameter("@receives_docDate", Me.ValidDateOrDBNull(Me.DocDate)))
        paramArrayList.Add(New SqlParameter("@receives_cust", Me.ValidIdOrDBNull(Me.Customer)))
        paramArrayList.Add(New SqlParameter("@receives_creditPeriod", Me.CreditPeriod))
        paramArrayList.Add(New SqlParameter("@receives_note", Me.Note))
        paramArrayList.Add(New SqlParameter("@receives_gross", Me.Gross))
        paramArrayList.Add(New SqlParameter("@receives_singlevat", Me.SingleVat))
        paramArrayList.Add(New SqlParameter("@receives_status", Me.Status.Value))

        SetOriginEditCancelStatus(paramArrayList, currentUserId, theTime)

        '---==Validated การทำ before save ของหน้าย่อยอื่นๆ ====
        Dim ValidateError2 As SaveErrorException = Me.BeforeSave(currentUserId)
        If Not IsNumeric(ValidateError2.Message) Then
          ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen, oldvatautogen)
          Return ValidateError2
        End If
        '---==Validated การทำ before save ของหน้าย่อยอื่นๆ ====

        ' สร้าง SqlParameter จาก ArrayList ...
        Dim sqlparams() As SqlParameter
        sqlparams = CType(paramArrayList.ToArray(GetType(SqlParameter)), SqlParameter())
        Dim trans As SqlTransaction
        Dim conn As New SqlConnection(Me.ConnectionString)
        conn.Open()

        'HACK================================
        SimpleBusinessEntityBase.Connection = conn
        SimpleBusinessEntityBase.Transaction = trans
        'HACK================================

        Dim oldid As Integer = Me.Id
        Dim oldreceive As Integer = Me.m_receive.Id
        Dim oldvat As Integer = Me.m_vat.Id
        Dim oldje As Integer = Me.m_je.Id
        If Not Me.WitholdingTaxCollection Is Nothing Then
          Me.WitholdingTaxCollection.SaveOldID()
        End If

        Try
          Try
            '--Generate Check--==================================================
            '--การสร้าง Check ใบใหม่จะได้ Id มาเก็บไว้ที่ Receive ด้วยจึงต้องวาง Code ไว้ก่อน Save Receive
            Dim subsaveerror As SaveErrorException = SubSaveFirst(conn, currentUserId)
            If Not IsNumeric(subsaveerror.Message) Then
              Return subsaveerror
            End If
          Catch ex As Exception
            Return New SaveErrorException(ex.ToString)
          End Try

          trans = conn.BeginTransaction()

          Try
            Me.ExecuteSaveSproc(conn, trans, returnVal, sqlparams, theTime, theUser)
            If IsNumeric(returnVal.Value) Then
              Select Case CInt(returnVal.Value)
                Case -1, -2, -5
                  trans.Rollback()
                  Me.ResetID(oldid, oldreceive, oldvat, oldje)
                  ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen, oldvatautogen)
                  Return New SaveErrorException(returnVal.Value.ToString)
                Case Else
              End Select
            ElseIf IsDBNull(returnVal.Value) OrElse Not IsNumeric(returnVal.Value) Then
              trans.Rollback()
              Me.ResetID(oldid, oldreceive, oldvat, oldje)
              ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen, oldvatautogen)
              Return New SaveErrorException(returnVal.Value.ToString)
            End If

            SaveDetail(Me.Id, conn, trans)
            'Dim cc As CostCenter = GetAllCC()
            'If cc Is Nothing Then
            '  cc = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
            'End If
            'If Not cc Is Nothing Then
            '  Me.m_receive.CcId = cc.Id
            '  Me.m_whtcol.SetCCId(cc.Id)
            '  Me.m_vat.SetCCId(cc.Id)
            'End If

            Dim savePaymentError As SaveErrorException = Me.m_receive.Save(currentUserId, conn, trans)
            If Not IsNumeric(savePaymentError.Message) Then
              trans.Rollback()
              Me.ResetID(oldid, oldreceive, oldvat, oldje)
              ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen, oldvatautogen)
              Return savePaymentError
            Else
              Select Case CInt(savePaymentError.Message)
                Case -1, -2, -5
                  trans.Rollback()
                  Me.ResetID(oldid, oldreceive, oldvat, oldje)
                  ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen, oldvatautogen)
                  Return savePaymentError
                Case Else
              End Select
            End If

            '' ป้องกัน dead lock =============
            'Me.m_vat.SetRefDocMaximumTaxBase(Me.GetMaximumTaxBase(conn, trans))
            '' ป้องกัน dead lock =============

            Dim saveVatError As SaveErrorException = Me.m_vat.Save(currentUserId, conn, trans)
            If Not IsNumeric(saveVatError.Message) Then
              trans.Rollback()
              Me.ResetID(oldid, oldreceive, oldvat, oldje)
              ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen, oldvatautogen)
              Return saveVatError
            Else
              Select Case CInt(saveVatError.Message)
                Case -1, -2
                  trans.Rollback()
                  Me.ResetID(oldid, oldreceive, oldvat, oldje)
                  ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen, oldvatautogen)
                  Return saveVatError
                Case Else
              End Select
            End If
            'Me.m_vat.AutoGen = False

            If Not Me.m_whtcol Is Nothing AndAlso Me.m_whtcol.Count >= 0 Then
              Dim saveWhtError As SaveErrorException = Me.m_whtcol.Save(currentUserId, conn, trans)
              If Not IsNumeric(saveWhtError.Message) Then
                trans.Rollback()
                Me.ResetID(oldid, oldreceive, oldvat, oldje)
                ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen, oldvatautogen)
                Return saveWhtError
              Else
                Select Case CInt(saveWhtError.Message)
                  Case -1, -2, -5
                    trans.Rollback()
                    Me.ResetID(oldid, oldreceive, oldvat, oldje)
                    ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen, oldvatautogen)
                    Return saveWhtError
                  Case Else
                End Select
              End If
            Else
              WitholdingTax.DeleteFromRefDoc(Me.Id, Me.EntityId, conn, trans)
            End If

            If Me.m_je.Status.Value = -1 Then
              m_je.Status.Value = 3
            ElseIf Me.m_status.Value = 0 Then
              m_je.Status.Value = 0
            End If
            Dim saveJeError As SaveErrorException = Me.m_je.Save(currentUserId, conn, trans)
            If Not IsNumeric(saveJeError.Message) Then
              trans.Rollback()
              Me.ResetID(oldid, oldreceive, oldvat, oldje)
              ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen, oldvatautogen)
              Return saveJeError
            Else
              Select Case CInt(saveJeError.Message)
                Case -1, -5
                  trans.Rollback()
                  Me.ResetID(oldid, oldreceive, oldvat, oldje)
                  ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen, oldvatautogen)
                  Return saveJeError
                Case -2
                  'Post ไปแล้ว
                  Return saveJeError
                Case Else
              End Select
            End If

            'Dim savePaymentError As SaveErrorException = Me.m_receive.Save(currentUserId, conn, trans)
            'If Not IsNumeric(savePaymentError.Message) Then
            '  trans.Rollback()
            '  Me.ResetID(oldid, oldreceive, oldvat, oldje)
            '  ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen, oldvatautogen)
            '  Return savePaymentError
            'Else
            '  Select Case CInt(savePaymentError.Message)
            '    Case -1, -2, -5
            '      trans.Rollback()
            '      Me.ResetID(oldid, oldreceive, oldvat, oldje)
            '      ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen, oldvatautogen)
            '      Return savePaymentError
            '    Case Else
            '  End Select
            'End If

            'Me.DeleteRef(conn, trans)
            'SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdateGS_ReceiveSRef" _
            ', New SqlParameter("@receives_id", Me.Id))
            'SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdateSBI_ReceiveSRef" _
            ', New SqlParameter("@receives_id", Me.Id))
            'SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdateARO_ReceiveSRef" _
            ', New SqlParameter("@receives_id", Me.Id))
            'SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdateAssetSold_ReceiveSRef" _
            ', New SqlParameter("@receives_id", Me.Id))
            'SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdateEQR_ReceiveSRef" _
            ', New SqlParameter("@receives_id", Me.Id))
            'SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdateBI_ReceiveSRef" _
            ', New SqlParameter("@receives_id", Me.Id))
            'SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdateSCN_ReceiveSRef" _
            ', New SqlParameter("@receives_id", Me.Id))
            'SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdateWO_ReceiveSRef" _
            ', New SqlParameter("@receives_id", Me.Id))
            'If Me.Status.Value = 0 Then
            '  Me.CancelRef(conn, trans)
            'End If

            'SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdateReceiveSelectionItemRVList", New SqlParameter("@receives_id", Me.Id))


            '==============================AUTOGEN==========================================
            Dim saveAutoCodeError As SaveErrorException = SaveAutoCode(conn, trans)
            If Not IsNumeric(saveAutoCodeError.Message) Then
              trans.Rollback()
              ResetID(oldid, oldreceive, oldvat, oldje)
              ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen, oldvatautogen)
              Return saveAutoCodeError
            Else
              Select Case CInt(saveAutoCodeError.Message)
                Case -1, -2, -5
                  trans.Rollback()
                  ResetID(oldid, oldreceive, oldvat, oldje)
                  ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen, oldvatautogen)
                  Return saveAutoCodeError
                Case Else
              End Select
            End If
            '==============================AUTOGEN==========================================


            trans.Commit()
            'Return New SaveErrorException(returnVal.Value.ToString)
          Catch ex As SqlException
            trans.Rollback()
            Me.ResetID(oldid, oldreceive, oldvat, oldje)
            ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen, oldvatautogen)
            Return New SaveErrorException(ex.ToString)
          Catch ex As Exception
            trans.Rollback()
            Me.ResetID(oldid, oldreceive, oldvat, oldje)
            ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen, oldvatautogen)
            Return New SaveErrorException(ex.ToString)
            'Finally
            'conn.Close()
            'm_saving = False
            ''HACK================================
            'SimpleBusinessEntityBase.Connection = Nothing
            'SimpleBusinessEntityBase.Transaction = Nothing
            ''HACK================================
          End Try

          '--Sub Save-- =================================
          Try
            Dim subsaveerror As SaveErrorException = SubSave(conn)
            If Not IsNumeric(subsaveerror.Message) Then
              Return New SaveErrorException(" Save Incomplete Please Save Again")
            End If
          Catch ex As Exception
            Return New SaveErrorException(ex.ToString)
          End Try

          Try
            Dim subsaveerror As SaveErrorException = SubSave2(conn, currentUserId)
            If Not IsNumeric(subsaveerror.Message) Then
              Return New SaveErrorException(" Save Incomplete Please Save Again")
            End If
          Catch ex As Exception
            Return New SaveErrorException(ex.ToString)
          End Try

          'Try
          '  Dim subsaveerror As SaveErrorException = SubSave3(conn, currentUserId)
          '  If Not IsNumeric(subsaveerror.Message) Then
          '    Return New SaveErrorException(" Save Incomplete Please Save Again")
          '  End If
          'Catch ex As Exception
          '  Return New SaveErrorException(ex.ToString)
          'End Try
          '--Sub Save-- =================================

          Return New SaveErrorException(returnVal.Value.ToString) 'Save complete and success

        Catch ex As Exception
          Return New SaveErrorException(ex.ToString)
        Finally
          conn.Close()
          m_saving = False
          'HACK=====================================================================
          SimpleBusinessEntityBase.Connection = Nothing
          SimpleBusinessEntityBase.Transaction = Nothing
          'HACK=====================================================================
        End Try
       
      End With
    End Function

    Private Function SubSave(ByVal conn As SqlConnection) As SaveErrorException

      '======เริ่ม trans 2 ลองผิดให้ save ใหม่ ========
      Dim trans As SqlTransaction = conn.BeginTransaction
      Try
        Me.DeleteRef(conn, trans)
        SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdateGS_ReceiveSRef" _
        , New SqlParameter("@receives_id", Me.Id))
        SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdateSBI_ReceiveSRef" _
        , New SqlParameter("@receives_id", Me.Id))
        SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdateARO_ReceiveSRef" _
        , New SqlParameter("@receives_id", Me.Id))
        SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdateAssetSold_ReceiveSRef" _
        , New SqlParameter("@receives_id", Me.Id))
        SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdateEQR_ReceiveSRef" _
        , New SqlParameter("@receives_id", Me.Id))
        SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdateBI_ReceiveSRef" _
        , New SqlParameter("@receives_id", Me.Id))
        SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdateSCN_ReceiveSRef" _
        , New SqlParameter("@receives_id", Me.Id))
        SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdateWO_ReceiveSRef" _
        , New SqlParameter("@receives_id", Me.Id))
        If Me.Status.Value = 0 Then
          Me.CancelRef(conn, trans)
        End If

        SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdateReceiveSelectionItemRVList", New SqlParameter("@receives_id", Me.Id))
      Catch ex As Exception
        trans.Rollback()
        Return New SaveErrorException(ex.InnerException.ToString)
      End Try

      trans.Commit()

      Return New SaveErrorException("0")
    End Function

    Private Function SubSaveFirst(ByVal conn As SqlConnection, ByVal currentUserId As Integer) As SaveErrorException

      '======เริ่ม trans 2 ลองผิดให้ save ใหม่ ========
      Dim trans2 As SqlTransaction = conn.BeginTransaction
      Try
        Dim subsaveerror As SaveErrorException = m_receive.AutoGenerateCheck(currentUserId, conn, trans2)
        If Not IsNumeric(subsaveerror.Message) Then
          Return subsaveerror 'SaveErrorException(" Save Incomplete Please Save Again")
        End If
      Catch ex As Exception
        trans2.Rollback()
        Return New SaveErrorException(ex.InnerException.ToString)
      End Try

      trans2.Commit()

      Return New SaveErrorException("0")
    End Function

    Private Function SubSave2(ByVal conn As SqlConnection, ByVal currentUserId As Integer) As SaveErrorException

      ''ใช้ connection ใหม่ transaction ใหม่ของ update deposit check เอง
      Dim trans2 As SqlTransaction = conn.BeginTransaction
      Try
        Dim subsaveerror As SaveErrorException = m_receive.AutoGenerateUpdateDepositCheck(currentUserId, conn, trans2)
        If Not IsNumeric(subsaveerror.Message) Then
          Return New SaveErrorException(" Save Incomplete Please Save Again")
        End If
      Catch ex As Exception
        trans2.Rollback()
        Return New SaveErrorException(ex.InnerException.ToString)
      End Try

      trans2.Commit()

      Return New SaveErrorException("0")
    End Function

    Public Overrides Function GetNextCode() As String
      Dim autoCodeFormat As String = Me.Code  'Entity.GetAutoCodeFormat(Me.EntityId)
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
    Private Function GetStockRefIdString() As String
      Dim ret As String = ""
      For Each billi As SaleBillIssueItem In Me.ItemCollection
        If billi.ParentType = 125 Then
          ret &= billi.Id.ToString & ","
        End If
      Next
      If ret.EndsWith(",") Then
        ret = ret.Substring(0, Len(ret) - 1)
      End If
      Return ret
    End Function
    Private Function GetSaleBillIssueRefIdString() As String
      Dim ret As String = ""
      For Each billi As SaleBillIssueItem In Me.ItemCollection
        If billi.ParentType = 125 Then
          ret &= billi.ParentId.ToString & ","
        End If
      Next
      If ret.EndsWith(",") Then
        ret = ret.Substring(0, Len(ret) - 1)
      End If
      Return ret
    End Function
    Private Function GetMilestoneRefIdString() As String
      Dim ret As String = ""
      For Each billi As SaleBillIssueItem In Me.ItemCollection
        If billi.ParentType = 81 Then
          ret &= billi.Id.ToString & ","
        End If
      Next
      If ret.EndsWith(",") Then
        ret = ret.Substring(0, Len(ret) - 1)
      End If
      Return ret
    End Function
    Private Function GetBillIssueRefIdString() As String
      Dim ret As String = ""
      For Each billi As SaleBillIssueItem In Me.ItemCollection
        If billi.ParentType = 81 Then
          ret &= billi.ParentId.ToString & ","
        End If
      Next
      If ret.EndsWith(",") Then
        ret = ret.Substring(0, Len(ret) - 1)
      End If
      Return ret
    End Function
    Private Function SaveDetail(ByVal parentID As Integer, ByVal conn As SqlConnection, ByVal trans As SqlTransaction) As Integer
      Dim da As New SqlDataAdapter("Select * from ReceiveSelectionItem where receivesi_receives=" & Me.Id, conn)
      Dim daOldRef As New SqlDataAdapter("select * from milestone where milestone_id in (select stock_id from ReceiveSelectionItem where receivesi_parentEntityType=81 and receivesi_receives=" & Me.Id & ")" & _
      " and milestone_id not in (select stock_id from ReceiveSelectionItem where receivesi_parentEntityType=81 and receivesi_receives <> " & Me.Id & ")" & _
      " and milestone_id not in (select billii_milestone from BillIssueItem)" _
      , conn)
      Dim daOldBIRef As New SqlDataAdapter("select * from billissue where billi_id in (select receivesi_parententity from ReceiveSelectionItem where receivesi_parentEntityType=81 and receivesi_receives=" & Me.Id & ")" & _
      " and billi_id not in (select receivesi_parententity from ReceiveSelectionItem where receivesi_parentEntityType=81 and receivesi_receives <> " & Me.Id & ")" _
      , conn)

      Dim daNewRef As SqlDataAdapter
      Dim refIds As String = Me.GetMilestoneRefIdString
      If refIds.Length > 0 Then
        daNewRef = New SqlDataAdapter("Select * from milestone where milestone_id in (" & refIds & ")", conn)
      End If


      Dim daNewBIRef As SqlDataAdapter
      Dim refBIIds As String = Me.GetBillIssueRefIdString
      If refBIIds.Length > 0 Then
        daNewBIRef = New SqlDataAdapter("Select * from billissue where billi_id in (" & refBIIds & ")", conn)
      End If

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
      da.FillSchema(ds, SchemaType.Mapped, "ReceiveSelectionItem")
      da.Fill(ds, "ReceiveSelectionItem")

      cmdBuilder = New SqlCommandBuilder(daOldRef)
      daOldRef.SelectCommand.Transaction = trans
      cmdBuilder.GetDeleteCommand.Transaction = trans
      cmdBuilder.GetInsertCommand.Transaction = trans
      cmdBuilder.GetUpdateCommand.Transaction = trans
      cmdBuilder = Nothing
      daOldRef.FillSchema(ds, SchemaType.Mapped, "oldMilestone")
      daOldRef.Fill(ds, "oldMilestone")


      cmdBuilder = New SqlCommandBuilder(daOldBIRef)
      daOldBIRef.SelectCommand.Transaction = trans
      cmdBuilder.GetDeleteCommand.Transaction = trans
      cmdBuilder.GetInsertCommand.Transaction = trans
      cmdBuilder.GetUpdateCommand.Transaction = trans
      cmdBuilder = Nothing
      daOldBIRef.FillSchema(ds, SchemaType.Mapped, "oldbi")
      daOldBIRef.Fill(ds, "oldbi")

      Dim dtNewRef As DataTable
      If Not daNewRef Is Nothing Then
        cmdBuilder = New SqlCommandBuilder(daNewRef)
        daNewRef.SelectCommand.Transaction = trans
        cmdBuilder.GetDeleteCommand.Transaction = trans
        cmdBuilder.GetInsertCommand.Transaction = trans
        cmdBuilder.GetUpdateCommand.Transaction = trans
        cmdBuilder = Nothing
        daNewRef.FillSchema(ds, SchemaType.Mapped, "newMilestone")
        daNewRef.Fill(ds, "newMilestone")
        dtNewRef = ds.Tables("newMilestone")
        For Each row As DataRow In dtNewRef.Rows
          If Not row.IsNull("milestone_status") AndAlso IsNumeric(row("milestone_status")) Then
            If CInt(row("milestone_status")) = 4 Then
              row("milestone_status") = 5
            ElseIf CInt(row("milestone_status")) = 5 AndAlso Me.Status.Value = 0 Then
              row("milestone_status") = 4
              row("milestone_billIssueDate") = DBNull.Value
            End If
          End If
        Next
      End If


      Dim dtNewBIRef As DataTable
      If Not daNewBIRef Is Nothing Then
        cmdBuilder = New SqlCommandBuilder(daNewBIRef)
        daNewBIRef.SelectCommand.Transaction = trans
        cmdBuilder.GetDeleteCommand.Transaction = trans
        cmdBuilder.GetInsertCommand.Transaction = trans
        cmdBuilder.GetUpdateCommand.Transaction = trans
        cmdBuilder = Nothing
        daNewBIRef.FillSchema(ds, SchemaType.Mapped, "newbi")
        daNewBIRef.Fill(ds, "newbi")
        dtNewBIRef = ds.Tables("newbi")
        For Each row As DataRow In dtNewBIRef.Rows
          If Not row.IsNull("billi_status") AndAlso IsNumeric(row("billi_status")) Then
            If CInt(row("billi_status")) = 2 Then
              row("billi_status") = 3
            ElseIf CInt(row("billi_status")) = 3 AndAlso Me.Status.Value = 0 Then
              row("billi_status") = 2
            End If
          End If
        Next
      End If

      Dim dt As DataTable = ds.Tables("ReceiveSelectionItem")

      Dim dtOldRef As DataTable = ds.Tables("oldMilestone")
      For Each row As DataRow In dtOldRef.Rows
        Dim found As Boolean = False
        For Each billi As SaleBillIssueItem In Me.ItemCollection
          If billi.Id = CInt(row("milestone_id")) Then
            'เจอแล้ว --> 
            found = True
            Exit For
          End If
        Next
        If Not found Then
          'ไม่เจอ
          If Not row.IsNull("milestone_status") AndAlso IsNumeric(row("milestone_status")) Then
            If CInt(row("milestone_status")) = 5 Then
              row("milestone_status") = 4
            End If
          End If
        End If
      Next

      Dim dtOldBIRef As DataTable = ds.Tables("oldbi")
      For Each row As DataRow In dtOldBIRef.Rows
        Dim found As Boolean = False
        For Each billi As SaleBillIssueItem In Me.ItemCollection
          If billi.ParentId = CInt(row("billi_id")) And billi.ParentType = 81 Then
            'เจอแล้ว --> 
            found = True
            Exit For
          End If
        Next
        If Not found Then
          'ไม่เจอ
          If Not row.IsNull("billi_status") AndAlso IsNumeric(row("billi_status")) Then
            If CInt(row("billi_status")) = 3 Then
              row("billi_status") = 2
            End If
          End If
        End If
      Next

      Dim i As Integer = 0
      With ds.Tables("ReceiveSelectionItem")
        For Each row As DataRow In .Rows
          row.Delete()
        Next
        For Each billi As SaleBillIssueItem In Me.ItemCollection
          i += 1
          Dim dr As DataRow = .NewRow
          dr("receivesi_receives") = Me.Id
          dr("receivesi_linenumber") = i
          dr("receivesi_parententity") = billi.ParentId
          dr("receivesi_parententityType") = billi.ParentType
          dr("receivesi_parententityCode") = billi.ParentCode
          dr("stock_id") = billi.Id
          dr("stock_type") = billi.EntityId
          dr("stock_code") = billi.Code
          dr("stock_docdate") = billi.Date
          dr("stock_creditprd") = billi.CreditPeriod
          dr("receivesi_amt") = billi.Amount
          dr("receivesi_vatamt") = billi.VatAmt
          dr("receivesi_billedamt") = billi.BilledAmount
          dr("receivesi_unreceivedamt") = billi.UnreceivedAmount
          dr("stock_beforetax") = billi.BeforeTax
          dr("stock_aftertax") = billi.AfterTax
          dr("stock_taxBase") = billi.TaxBase
          dr("stock_note") = billi.Note
          dr("stock_retention") = billi.Retention '==> Version 22
          dr("stock_status") = Me.Status.Value
          .Rows.Add(dr)
        Next
      End With

      AddHandler da.RowUpdated, AddressOf tmpDa_MyRowUpdated
      AddHandler daOldRef.RowUpdated, AddressOf tmpDa_MyRowUpdated
      AddHandler daOldBIRef.RowUpdated, AddressOf tmpDa_MyRowUpdated
      If Not daNewRef Is Nothing Then
        AddHandler daNewRef.RowUpdated, AddressOf tmpDa_MyRowUpdated
      End If
      If Not daNewBIRef Is Nothing Then
        AddHandler daNewBIRef.RowUpdated, AddressOf tmpDa_MyRowUpdated
      End If

      daOldRef.Update(GetDeletedRows(dtOldRef))
      daOldBIRef.Update(GetDeletedRows(dtOldBIRef))
      da.Update(GetDeletedRows(dt))
      If Not daNewRef Is Nothing Then
        daNewRef.Update(GetDeletedRows(dtNewRef))
      End If
      If Not daNewBIRef Is Nothing Then
        daNewBIRef.Update(GetDeletedRows(dtNewBIRef))
      End If

      da.Update(dt.Select("", "", DataViewRowState.ModifiedCurrent))
      daOldRef.Update(dtOldRef.Select("", "", DataViewRowState.ModifiedCurrent))
      daOldBIRef.Update(dtOldBIRef.Select("", "", DataViewRowState.ModifiedCurrent))
      If Not daNewRef Is Nothing Then
        daNewRef.Update(dtNewRef.Select("", "", DataViewRowState.ModifiedCurrent))
      End If
      If Not daNewBIRef Is Nothing Then
        daNewBIRef.Update(dtNewBIRef.Select("", "", DataViewRowState.ModifiedCurrent))
      End If
      da.Update(dt.Select("", "", DataViewRowState.Added))
      daOldRef.Update(dtOldRef.Select("", "", DataViewRowState.Added))
      daOldBIRef.Update(dtOldBIRef.Select("", "", DataViewRowState.Added))
      If Not daNewRef Is Nothing Then
        daNewRef.Update(dtNewRef.Select("", "", DataViewRowState.Added))
      End If
      If Not daNewBIRef Is Nothing Then
        daNewBIRef.Update(dtNewBIRef.Select("", "", DataViewRowState.Added))
      End If
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
    Public Function GetMileStoneItem(ByVal entityid As Integer, ByVal entityType As Integer) As Decimal
      If entityType = 75 Then
        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(ConnectionString _
        , CommandType.Text _
        , "SELECT isnull(milestone_retention,0) [milestone_retention] FROM milestone " & _
          "WHERE milestone_type = 75 " & _
          "AND milestone_id = " & entityid)
        If ds.Tables(0).Rows.Count > 0 Then
          If IsNumeric(ds.Tables(0).Rows(0)(0)) Then
            Return CDec(ds.Tables(0).Rows(0)(0))
          End If
        End If
      End If

      Return 0
    End Function
#End Region

#Region "IBillIssuable"
    Public Function AmountToReceive() As Decimal Implements IReceivable.AmountToReceive
      'Dim tmp As Object = Configuration.GetConfig("ARRetentionPoint")
      'Dim apRetentionPoint As Integer = 0
      'If IsNumeric(tmp) Then
      'apRetentionPoint = CInt(tmp)
      'End If
      'Dim retentionHere As Boolean = (apRetentionPoint = 1)
      'If retentionHere Then
      'Return Me.Gross - Me.ItemCollection.ARretention
      'Else
      'Return Me.Gross
      'End If
      Return Me.Gross
    End Function
    Public Property DueDate() As Date Implements IReceivable.DueDate
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
    Public Property Receive() As Receive Implements IReceivable.Receive
      Get
        m_receive.CcId = GetAllCC.Id
        Return m_receive
      End Get
      Set(ByVal Value As Receive)
        m_receive = Value
      End Set
    End Property
    Public ReadOnly Property Payer() As IBillablePerson Implements IReceivable.Payer
      Get
        Return Me.Customer
      End Get
    End Property
    Public Function RemainingAmount() As Decimal Implements IReceivable.RemainingAmount
      'Undone
      Return AmountToReceive()
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
      Dim cc As CostCenter = GetAllCC()

      Dim tmp As Object = Configuration.GetConfig("ARRetentionPoint")
      Dim arRetentionPoint As Integer = 0
      If IsNumeric(tmp) Then
        arRetentionPoint = CInt(tmp)
      End If
      Dim retentionHere As Boolean = (arRetentionPoint = 1)

      For Each doc As SaleBillIssueItem In Me.ItemCollection
        Dim docRetention As Decimal = 0
        Dim itemCC As CostCenter
        Dim itemType As String = ""
        If doc.ParentType = 81 Then
          'วางบิลงวด                   
          Dim bi As BillIssue = CType(Me.m_billissues(doc.ParentId), BillIssue)
          For Each mi As Milestone In bi.ItemCollection
            If mi.Id = doc.Id AndAlso Not mi.TaxType.Value = 0 Then
              itemCC = mi.CostCenter
              itemType = mi.Type.Description
            End If
          Next
          'docRetention = bi.ItemCollection.GetRetentionAmount(Nothing)
        Else
          Dim tmpcc As CostCenter = GetCCFromDocTypeAndId(doc.EntityId, doc.Id)
          If tmpcc Is Nothing Then
            tmpcc = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
          End If
          If Not tmpcc Is Nothing Then
            itemCC = tmpcc
          End If
          itemType = GetTypeNameFromDocType(doc.EntityId)
        End If
        If itemCC Is Nothing Then
          itemCC = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
        End If
        Dim myGross As Decimal = doc.AmountForGL
        docRetention = doc.ARretention
        Dim myDebt As Decimal = myGross

        If doc.AmountForGL <> 0 Then
          'ลูกหนี้การค้า
          ji = New JournalEntryItem
          ji.Mapping = "C8.2"
          If retentionHere Then
            ji.Amount = myDebt + docRetention
          Else
            ji.Amount = myDebt
          End If
          If Not Me.Customer.Account Is Nothing AndAlso Me.Customer.Account.Originated Then
            ji.Account = Me.Customer.Account
          End If
          ji.CostCenter = itemCC
          jiColl.Add(ji)
        End If

        If doc.AmountForGL <> 0 Then
          'ลูกหนี้การค้า
          ji = New JournalEntryItem
          ji.Mapping = "C8.2W"
          If retentionHere Then
            ji.Amount = myDebt + docRetention
          Else
            ji.Amount = myDebt
          End If
          If Not Me.Customer.Account Is Nothing AndAlso Me.Customer.Account.Originated Then
            ji.Account = Me.Customer.Account
          End If
          ji.CostCenter = itemCC
          ji.Note = itemType & ":" & doc.Code.ToString
          jiColl.Add(ji)
        End If

        'Retention หัก
        If retentionHere AndAlso docRetention <> 0 Then
          ji = New JournalEntryItem
          ji.Mapping = "C7.18"
          ji.Amount = docRetention
          ji.CostCenter = itemCC
          ji.Note = Me.Payer.Name
          jiColl.Add(ji)
        End If

        'Retention หัก
        If retentionHere AndAlso docRetention <> 0 Then
          ji = New JournalEntryItem
          ji.Mapping = "C7.18W"
          ji.Amount = docRetention
          ji.CostCenter = itemCC
          ji.Note = Me.Payer.Name
          jiColl.Add(ji)
        End If

        If doc.VatAmt > 0 Then
          ji = New JournalEntryItem
          ji.Mapping = "C8.3D"
          ji.Amount = Configuration.Format(doc.VatAmt, DigitConfig.Price)
          ji.CostCenter = itemCC
          ji.Note = "ภาษีขายไม่ถึงกำหนด" & doc.Code
          jiColl.Add(ji)
        End If
      Next

      'ภาษีหัก ณ ที่จ่าย
      If Not Me.WitholdingTaxCollection Is Nothing AndAlso Me.WitholdingTaxCollection.Amount <> 0 Then
        ji = New JournalEntryItem
        ji.Mapping = "C8.1"
        ji.Amount = Me.WitholdingTaxCollection.Amount
        ji.CostCenter = cc
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
          ji.CostCenter = cc
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
          ji.CostCenter = cc
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
          ji.CostCenter = cc
          jiColl.Add(ji)
        End If
      Next
      RefreshTaxBase()

      Dim jTaxBase As Decimal = 0
      Dim jVat As Decimal = 0
      For Each jVatItem As VatItem In Me.m_vat.ItemCollection
        If IsNumeric(jVatItem.TaxBase) Then
          jTaxBase += jVatItem.TaxBase
          jVat += jVatItem.Amount
        End If
      Next

      ' ''--- Pui 20080422 เนื่องจาก รับชำระหน้าภาษี สามารถแบ่งรับชำระได้
      ' ''ภาษีขาย-ไม่ถึงกำหนด 'ซับซ้อนมาก
      'For Each i As SaleBillIssueItem In Me.ItemCollection
      '  Dim itamt As Decimal = Vat.GetVatAmount(i.TaxBase * (i.Amount / i.UnreceivedAmount))
      '  If itamt <> 0 Then
      '    ji = New JournalEntryItem
      '    ji.Mapping = "C8.3"
      '    'ji.Amount = Configuration.Format(Me.TaxAmount, DigitConfig.Price)
      '    ji.Amount = Configuration.Format(itamt, DigitConfig.Price)
      '    ji.CostCenter = cc   ' GetVatCC()
      '    jiColl.Add(ji)

      '    ji = New JournalEntryItem
      '    ji.Mapping = "C8.3D"
      '    'ji.Amount = Configuration.Format(Me.TaxAmount, DigitConfig.Price)
      '    ji.Amount = Configuration.Format(itamt, DigitConfig.Price)
      '    ji.CostCenter = cc   ' GetVatCC()
      '    ji.Note = i.Code
      '    jiColl.Add(ji)
      '  End If
      'Next

      

      'ภาษีขาย 
      If jVat <> 0 Then
        ji = New JournalEntryItem
        ji.Mapping = "C8.4"
        'ji.Amount = Configuration.Format(Me.TaxAmount, DigitConfig.Price)
        ji.Amount = Configuration.Format(jVat, DigitConfig.Price)
        ji.CostCenter = cc   'GetVatCC()
        jiColl.Add(ji)

        ' ''ภาษีขาย-ไม่ถึงกำหนด
        ji = New JournalEntryItem
        ji.Mapping = "C8.3"
        'ji.Amount = Configuration.Format(Me.TaxAmount, DigitConfig.Price)
        ji.Amount = Configuration.Format(Me.TaxAmount, DigitConfig.Price)
        ji.CostCenter = cc   ' GetVatCC()
        jiColl.Add(ji)
      End If

      

      For Each vi As VatItem In Me.Vat.ItemCollection
        ji = New JournalEntryItem
        ji.Mapping = "C8.4D"
        ji.Amount = Configuration.Format(vi.Amount, DigitConfig.Price)
        ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
        ji.Note = vi.Code & "/" & vi.PrintName
        jiColl.Add(ji)

        ji = New JournalEntryItem
        ji.Mapping = "C8.4W"
        ji.Amount = Configuration.Format(vi.Amount, DigitConfig.Price)
        ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
        ji.Note = vi.Code & "/" & vi.PrintName
        jiColl.Add(ji)

      Next

      If Not Me.Receive Is Nothing Then
        jiColl.AddRange(Me.Receive.GetJournalEntries)
      End If
      Return jiColl
    End Function
    Public ReadOnly Property TaxAmount() As Decimal
      Get
        Return Me.ItemCollection.VatAmount
      End Get
    End Property
    Public Property TaxBase() As Decimal Implements IVatable.TaxBase
      Get
        'Return m_taxbase
        Return Me.GetReceiveTaxBase
      End Get
      Set(ByVal Value As Decimal)

      End Set
    End Property
    Dim m_realTaxBase As Decimal
    Public Property RealTaxBase As Decimal
      Get
        Return m_realTaxBase
      End Get
      Set(ByVal value As Decimal)
        m_realTaxBase = value
      End Set
    End Property
    Private m_taxbase As Decimal
    Public Sub RefreshTaxBase()
      If m_saving Then
        Return
      End If
      m_taxbase = 0
      For Each item As SaleBillIssueItem In Me.ItemCollection
        If item.ParentType = 81 Then
          'วางบิลงวด
          If Not Me.m_billissues.Contains(item.ParentId) Then
            Me.m_billissues(item.ParentId) = New BillIssue(item.ParentId)
          End If
          Dim bi As BillIssue = CType(Me.m_billissues(item.ParentId), BillIssue)
          If bi.NoVat Then
            m_taxbase += item.TaxBase
          End If
        End If
      Next
    End Sub
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
      Return Me.ItemCollection.WHTBase
    End Function
    Public Property Person() As IBillablePerson Implements IWitholdingTaxable.Person, IVatable.Person
      Get
        Return Me.Customer
      End Get
      Set(ByVal Value As IBillablePerson)
        Me.Customer = CType(Value, Customer)
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

#Region "IVatable"
    Public Sub GenVatItems()
      '--- Pui 20080418 ASCON ต้องการปรับยอดใบกำกับภาษีได้ ตามการแบ่งรับชำระ ---
      RefreshTaxBase()
      Me.Vat.ItemCollection.Clear()
      Vat.AutoGen = True
      'If Me.TaxType.Value = 0 Then
      '    Return
      'End If
      Dim i As Integer = 0
      Dim vi As New VatItem
      'Dim ptn As String = Entity.GetAutoCodeFormat(vi.EntityId)
      'Dim pattern As String = CodeGenerator.GetPattern(ptn, Me)
      'pattern = CodeGenerator.GetPattern(pattern)
      'Dim lastCode As String = vi.GetLastCode(pattern)
      For Each item As SaleBillIssueItem In Me.ItemCollection
        If item.ParentType = 81 Then
          Dim bi As BillIssue = CType(Me.m_billissues(item.ParentId), BillIssue)
          For Each mi As Milestone In bi.ItemCollection
            If mi.Id = item.Id AndAlso Not mi.TaxType.Value = 0 Then
              i += 1
              Dim vitem As New VatItem
              vitem.AutoGen = True
              vitem.LineNumber = i
              'Dim newCode As String = CodeGenerator.Generate(ptn, lastCode, Me)
              vitem.Code = ""          'newCode
              'lastCode = newCode
              vitem.DocDate = Me.DocDate
              vitem.PrintName = Me.Customer.Name
              vitem.PrintAddress = Me.Customer.BillingAddress
              If Not item.DeductedTaxBase.HasValue Then
                Dim sv As New SimpleVat
                sv = Vat.GetTaxBaseDeductedWithoutThisRefDoc(mi.Id, mi.EntityId, Me.Id, Me.EntityId)
                item.DeductedTaxBase = sv.TaxBase
                item.DeductedVatAmt = sv.VatAmt
              End If
              Dim mtb As Decimal = mi.TaxBase - item.DeductedTaxBase.Value
              'ถ้ายอดวางบิล ไม่เท่ากับยอด ค้างรับคงเหลือ (หรือเป็นการแบ่งรับชำระรอบ 2,3,...)
              If item.BilledAmount <> item.UnreceivedAmount + mi.Retention Then
                mtb = (item.UnreceivedAmount / (item.BilledAmount - mi.Retention)) * mtb
              End If
              Dim amt As Decimal = item.Amount
              Dim uamt As Decimal = item.UnreceivedAmount
              '---------------------------------------------
              Dim tb As Decimal = (amt / uamt) * mtb
              'MessageBox.Show(String.Format("({0} / {1}) * {2} = {3}", amt, uamt, mtb, tb))
              '---------------------------------------------
              tb = Vat.GetExcludedVatAmount(item.Amount + item.BillIretention)
              If item.EntityId = 79 Then
                vitem.TaxBase = -Math.Abs(tb)
              Else
                vitem.TaxBase = tb
              End If
              vitem.TaxRate = bi.TaxRate
              'If mi.CostCenter.Originated Then
              '    vitem.CcId = mi.CostCenter.Id
              'Else
              '    vitem.CcId = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ).Id
              'End If

              vitem.CcId = GetAllCC.Id
              vitem.Milestone = mi
              vitem.Refdoc = Me.Id
              vitem.RefdocType = Me.EntityId
              item.VatAmt = vitem.Amount
              Me.Vat.ItemCollection.Add(vitem)
            End If
          Next
        ElseIf item.EntityId = 83 Then
          If Not item.TaxType.Value = 0 Then
            i += 1
            Dim vitem As New VatItem
            vitem.AutoGen = True
            vitem.LineNumber = i
            'Dim newCode As String = CodeGenerator.Generate(ptn, lastCode, Me)
            vitem.Code = ""          'newCode
            'lastCode = newCode
            vitem.DocDate = Me.DocDate
            vitem.PrintName = Me.Customer.Name
            vitem.PrintAddress = Me.Customer.BillingAddress
            If Not item.DeductedTaxBase.HasValue Then
              Dim sv As New SimpleVat
              sv = Vat.GetTaxBaseDeductedWithoutThisRefDoc(item.Id, item.EntityId, Me.Id, Me.EntityId)
              item.DeductedTaxBase = sv.TaxBase
              item.DeductedVatAmt = sv.VatAmt
            End If
            Dim mtb As Decimal = item.TaxBase - item.DeductedTaxBase.Value
            ''ถ้ายอดวางบิล ไม่เท่ากับยอด ค้างรับคงเหลือ (หรือเป็นการแบ่งรับชำระรอบ 2,3,...)
            'If item.BilledAmount <> item.UnreceivedAmount + mi.RetentionforBillIssue Then
            '  mtb = (item.UnreceivedAmount / (item.BilledAmount - mi.RetentionforBillIssue)) * mtb
            'End If
            Dim amt As Decimal = item.Amount
            Dim uamt As Decimal = item.UnreceivedAmount
            '---------------------------------------------
            Dim tb As Decimal = (amt / uamt) * mtb
            '---------------------------------------------

            vitem.TaxBase = tb
            vitem.TaxRate = item.TaxRate
            'If mi.CostCenter.Originated Then
            '    vitem.CcId = mi.CostCenter.Id
            'Else
            '    vitem.CcId = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ).Id
            'End If
            vitem.CcId = GetAllCC.Id
            vitem.Refdoc = Me.Id
            vitem.RefdocType = Me.EntityId
            item.VatAmt = vitem.Amount
            If tb <> 0 Then
              Me.Vat.ItemCollection.Add(vitem)
            End If
          End If
        ElseIf item.EntityId = 48 Then
          If Not item.TaxType.Value = 0 Then
            i += 1
            Dim vitem As New VatItem
            vitem.AutoGen = True
            vitem.LineNumber = i
            'Dim newCode As String = CodeGenerator.Generate(ptn, lastCode, Me)
            vitem.Code = ""          'newCode
            'lastCode = newCode
            vitem.DocDate = Me.DocDate
            vitem.PrintName = Me.Customer.Name
            vitem.PrintAddress = Me.Customer.BillingAddress
            If Not item.DeductedTaxBase.HasValue Then
              Dim sv As New SimpleVat
              sv = Vat.GetTaxBaseDeductedWithoutThisRefDoc(item.Id, item.EntityId, Me.Id, Me.EntityId)
              item.DeductedTaxBase = sv.TaxBase
              item.DeductedVatAmt = sv.VatAmt
            End If
            Dim mtb As Decimal = -item.TaxBase + item.DeductedTaxBase.Value
            ''ถ้ายอดวางบิล ไม่เท่ากับยอด ค้างรับคงเหลือ (หรือเป็นการแบ่งรับชำระรอบ 2,3,...)
            'If item.BilledAmount <> item.UnreceivedAmount + mi.RetentionforBillIssue Then
            '  mtb = (item.UnreceivedAmount / (item.BilledAmount - mi.RetentionforBillIssue)) * mtb
            'End If
            Dim amt As Decimal = item.Amount
            Dim uamt As Decimal = item.UnreceivedAmount
            '---------------------------------------------
            Dim tb As Decimal = (amt / uamt) * mtb
            '---------------------------------------------

            vitem.TaxBase = tb
            vitem.TaxRate = item.TaxRate
            'If mi.CostCenter.Originated Then
            '    vitem.CcId = mi.CostCenter.Id
            'Else
            '    vitem.CcId = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ).Id
            'End If
            vitem.CcId = GetAllCC.Id
            vitem.Refdoc = Me.Id
            vitem.RefdocType = Me.EntityId
            item.VatAmt = vitem.Amount
            If tb <> 0 Then
              Me.Vat.ItemCollection.Add(vitem)
            End If
          End If
        ElseIf item.EntityId = 366 Then
          If Not item.TaxType.Value = 0 Then
            i += 1
            Dim vitem As New VatItem
            vitem.AutoGen = True
            vitem.LineNumber = i
            'Dim newCode As String = CodeGenerator.Generate(ptn, lastCode, Me)
            vitem.Code = ""          'newCode
            'lastCode = newCode
            vitem.DocDate = Me.DocDate
            vitem.PrintName = Me.Customer.Name
            vitem.PrintAddress = Me.Customer.BillingAddress
            If Not item.DeductedTaxBase.HasValue Then
              Dim sv As New SimpleVat
              sv = Vat.GetTaxBaseDeductedWithoutThisRefDoc(item.Id, item.EntityId, Me.Id, Me.EntityId)
              item.DeductedTaxBase = sv.TaxBase
              item.DeductedVatAmt = sv.VatAmt
            End If
            Dim mtb As Decimal = item.BeforeTax - item.DeductedTaxBase.Value
            ''ถ้ายอดวางบิล ไม่เท่ากับยอด ค้างรับคงเหลือ (หรือเป็นการแบ่งรับชำระรอบ 2,3,...)
            'If item.BilledAmount <> item.UnreceivedAmount + mi.RetentionforBillIssue Then
            '  mtb = (item.UnreceivedAmount / (item.BilledAmount - mi.RetentionforBillIssue)) * mtb
            'End If
            Dim amt As Decimal = item.Amount
            Dim uamt As Decimal = item.UnreceivedAmount
            '---------------------------------------------
            Dim tb As Decimal = (amt / uamt) * mtb
            '---------------------------------------------

            vitem.TaxBase = tb
            vitem.TaxRate = item.TaxRate
            'If mi.CostCenter.Originated Then
            '    vitem.CcId = mi.CostCenter.Id
            'Else
            '    vitem.CcId = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ).Id
            'End If
            vitem.CcId = GetAllCC.Id
            vitem.Refdoc = Me.Id
            vitem.RefdocType = Me.EntityId
            item.VatAmt = vitem.Amount
            If tb <> 0 Then
              Me.Vat.ItemCollection.Add(vitem)
            End If
          End If
        End If
      Next
      '   If Me.Vat.ItemCollection.Amount = 0 Then
      '	RefreshTaxBase()
      '	Me.Vat.ItemCollection.Clear()
      '	'If Me.TaxType.Value = 0 Then
      '	'    Return
      '	'End If
      '	Dim i As Integer = 0
      '	Dim vi As New VatItem
      '	'Dim ptn As String = Entity.GetAutoCodeFormat(vi.EntityId)
      '	'Dim pattern As String = CodeGenerator.GetPattern(ptn, Me)
      '	'pattern = CodeGenerator.GetPattern(pattern)
      '	'Dim lastCode As String = vi.GetLastCode(pattern)
      '	For Each item As SaleBillIssueItem In Me.ItemCollection
      '		If item.ParentType = 81 Then
      '			Dim bi As BillIssue = CType(Me.m_billissues(item.ParentId), BillIssue)
      '			For Each mi As Milestone In bi.ItemCollection
      '				If mi.Id = item.Id AndAlso Not mi.TaxType.Value = 0 Then
      '					i += 1
      '					Dim vitem As New VatItem
      '					vitem.AutoGen = True
      '					vitem.LineNumber = i
      '					'Dim newCode As String = CodeGenerator.Generate(ptn, lastCode, Me)
      '					vitem.Code = ""						'newCode
      '					'lastCode = newCode
      '					vitem.DocDate = Me.DocDate
      '					vitem.PrintName = Me.Customer.Name
      '					vitem.PrintAddress = Me.Customer.BillingAddress
      '					Dim mtb As Decimal = mi.TaxBase
      '					Dim amt As Decimal = item.Amount
      '					Dim uamt As Decimal = item.UnreceivedAmount
      '					'---------------------------------------------
      '					Dim tb As Decimal = (amt / uamt) * mtb
      '					MessageBox.Show(String.Format("({0} / {1}) * {2} = {3}", amt, uamt, mtb, tb))
      '					'---------------------------------------------
      '					If item.EntityId = 79 Then
      '						vitem.TaxBase = -Math.Abs(tb)
      '					Else
      '						vitem.TaxBase = tb
      '					End If
      '					vitem.TaxRate = bi.TaxRate
      '					'If mi.CostCenter.Originated Then
      '					'    vitem.CcId = mi.CostCenter.Id
      '					'Else
      '					'    vitem.CcId = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ).Id
      '					'End If
      '					vitem.CcId = GetAllCC.Id
      '					vitem.Milestone = mi
      '					Me.Vat.ItemCollection.Add(vitem)
      '				End If
      '			Next
      '		End If
      '	Next
      'End If
    End Sub
    Public Sub GenSingleVatItem()
      Me.Vat.ItemCollection.Clear()
      Vat.AutoGen = True
      Dim vitem As New VatItem
      vitem.LineNumber = 1
      Dim vi As New VatItem
      Dim ptn As String = Entity.GetAutoCodeFormat(vi.EntityId)
      Dim pattern As String = CodeGenerator.GetPattern(ptn, Me)
      pattern = CodeGenerator.GetPattern(pattern)
      vitem.AutoGen = True
      vitem.Code = ""  'CodeGenerator.Generate(Entity.GetAutoCodeFormat(vitem.EntityId), vitem.GetLastCode(pattern), Me.DocDate)
      vitem.DocDate = Me.DocDate
      vitem.PrintName = Me.Customer.Name
      vitem.PrintAddress = Me.Customer.BillingAddress
      vitem.TaxBase = Me.GetMaximumTaxBase
      vitem.TaxRate = CDec(Configuration.GetConfig("CompanyTaxRate"))
      vitem.CcId = GetAllCC.Id  'GetVatCC.Id
      vitem.Refdoc = Me.Id
      vitem.RefdocType = Me.EntityId
      Me.Vat.ItemCollection.Add(vitem)
    End Sub
    Public Function GetAfterTax() As Decimal Implements IVatable.GetAfterTax

    End Function
    Public Function GetBeforeTax() As Decimal Implements IVatable.GetBeforeTax

    End Function
    Private Function GetReceiveTaxBase() As Decimal
      Dim sqlConString As String = Longkong.Pojjaman.Services.RecentCompanies.CurrentCompany.ConnectionString
      Dim iTaxBase As Decimal = 0

      For Each item As SaleBillIssueItem In Me.ItemCollection
        Select Case item.EntityId
          Case 75, 77, 78, 79, 86
            Dim mi As New Milestone(item.Id)
            Dim ds As DataSet = SqlHelper.ExecuteDataset(sqlConString _
            , CommandType.Text _
            , " select vat_taxbase from receiveselectionitem " & _
            " left join vat on receivesi_receives = vat_refDoc  " & _
            " where stock_type = 75 " & _
            " and stock_id = " & mi.Id & "  " & _
            " and receivesi_parentEntityType = 81 " & _
            " and vat_entity = " & m_customer.Id & "  " & _
            " and vat_refDocType = 82 " _
            )
            For Each row As DataRow In ds.Tables(0).Rows
              If Not row.IsNull("vat_taxbase") Then
                iTaxBase += CDec(row("vat_taxbase"))
              End If
            Next
          Case 83
            Dim ds As DataSet = SqlHelper.ExecuteDataset(sqlConString _
            , CommandType.Text _
            , " select vat_taxbase from receiveselectionitem " & _
            " left join vat on receivesi_receives = vat_refDoc  " & _
            " where stock_id = " & item.Id & "  " & _
            " and stock_type = " & item.EntityId & "  " & _
            " and vat_refDocType = 82 " _
            )
            For Each row As DataRow In ds.Tables(0).Rows
              If Not row.IsNull("vat_taxbase") Then
                iTaxBase += CDec(row("vat_taxbase"))
              End If
            Next

            'Dim d As Decimal = 0
            'iTaxBase += GoodsSold.GetTaxBase(item.Id)
        End Select
      Next

      Return iTaxBase
    End Function
    Public Function GetMaximumTaxBase(Optional ByVal conn As SqlConnection = Nothing, Optional ByVal trans As SqlTransaction = Nothing) As Decimal Implements IVatable.GetMaximumTaxBase
      Dim ret As Decimal = 0
      For Each key As Integer In m_billissues.Keys
        If key <> 0 Then
          Dim bi As BillIssue = CType(m_billissues(key), BillIssue)
          For Each item As SaleBillIssueItem In Me.ItemCollection
            If item.ParentType = 81 Then
              For Each mi As Milestone In bi.ItemCollection
                If mi.Id = item.Id AndAlso mi.TaxPoint.Value = 2 AndAlso Not mi.TaxType.Value = 0 Then
                  Dim mtb As Decimal = mi.TaxBase
                  Dim amt As Decimal = item.Amount
                  Dim uamt As Decimal = item.UnreceivedAmount
                  Dim sv As New SimpleVat
                  If Not item.DeductedTaxBase.HasValue Then
                    If conn IsNot Nothing AndAlso trans IsNot Nothing Then
                      sv = Vat.GetTaxBaseDeductedWithoutThisRefDoc(mi.Id, mi.EntityId, Me.Id, Me.EntityId, conn, trans)
                      item.DeductedTaxBase = sv.TaxBase
                      item.DeductedVatAmt = sv.VatAmt
                    Else
                      sv = Vat.GetTaxBaseDeductedWithoutThisRefDoc(mi.Id, mi.EntityId, Me.Id, Me.EntityId)
                      item.DeductedTaxBase = sv.TaxBase
                      item.DeductedVatAmt = sv.VatAmt
                    End If
                  End If
                  '---------------------------------------------
                  Dim tb As Decimal '= (amt / uamt) * (mtb - item.DeductedTaxBase.Value)
                  tb = Vat.GetExcludedVatAmount(amt + item.BillIretention)
                  item.VatAmt = Vat.GetVatAmount(tb)
                  If TypeOf mi Is VariationOrderDe Then
                    ret -= tb
                  Else
                    ret += tb
                  End If
                  'MessageBox.Show(String.Format("({0} / {1}) * {2} = {3}", amt, uamt, mtb, tb))
                  '---------------------------------------------
                End If
              Next
            End If
          Next
        End If
      Next

      'ถ้าไม่ได้มาจากใบวางบิลงวด แต่มาจากการขายสินค้า หรือวางบิล
      Dim d As Decimal = 0
      For Each item As SaleBillIssueItem In Me.ItemCollection
        'ถ้าไม่ใช่ใบวางบิลงวด
        If Not item.ParentType = 81 Then
          'ถ้าเป็นใบวางบิลขาย และเป็นรายการขายสินค้า
          If item.ParentType = 125 And item.EntityId = 83 Then
            item.TaxBase = GoodsSold.GetTaxBase(item.Id)
            item.VatAmt = Vat.GetVatAmount(item.TaxBase)
          ElseIf item.EntityId = 48 Then
            item.TaxBase = SaleCN.GetTaxBase(item.Id)
            item.VatAmt = Vat.GetVatAmount(item.TaxBase)
          ElseIf item.EntityId = 366 Then
            item.TaxBase = AssetWriteOff.GetTaxBase(item.Id)
            item.VatAmt = Vat.GetVatAmount(item.TaxBase)
          End If
          If Not item.DeductedTaxBase.HasValue Then
            Dim sv As New SimpleVat
            If conn IsNot Nothing AndAlso trans IsNot Nothing Then
              sv = Vat.GetTaxBaseDeductedWithoutThisRefDoc(item.Id, item.EntityId, Me.Id, Me.EntityId, conn, trans)
              item.DeductedTaxBase = sv.TaxBase
              item.DeductedVatAmt = sv.VatAmt
            Else
              sv = Vat.GetTaxBaseDeductedWithoutThisRefDoc(item.Id, item.EntityId, Me.Id, Me.EntityId)
              item.DeductedTaxBase = sv.TaxBase
              item.DeductedVatAmt = sv.VatAmt
            End If
          End If
          Dim mtb As Decimal
          If item.EntityId <> 48 Then
            mtb = item.TaxBase - item.DeductedTaxBase.Value
          Else
            mtb = -item.TaxBase + item.DeductedTaxBase.Value
          End If
          Dim amt As Decimal = item.Amount
          Dim uamt As Decimal = item.UnreceivedAmount
          '---------------------------------------------
          Dim tb As Decimal = (amt / uamt) * mtb
          item.VatAmt = Vat.GetVatAmount(tb)
          ret += tb
        End If
      Next

      Return ret
    End Function
    Public Function GetVatCC() As CostCenter
      Dim cc As CostCenter
      For Each key As Integer In m_billissues.Keys
        If key <> 0 Then
          Dim bi As BillIssue = CType(m_billissues(key), BillIssue)
          For Each item As SaleBillIssueItem In Me.ItemCollection
            If item.ParentType = 81 Then
              For Each mi As Milestone In bi.ItemCollection
                If mi.Id = item.Id AndAlso Not mi.TaxType.Value = 0 Then
                  If Not cc Is Nothing AndAlso cc.Id <> mi.CostCenter.Id Then
                    Return CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
                  Else
                    cc = mi.CostCenter
                  End If
                End If
              Next
            End If
          Next
        End If
      Next
      If cc Is Nothing OrElse Not cc.Originated Then
        Return CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
      End If
      Return cc
    End Function
    Public Function GetAllCC() As CostCenter
      Dim cc As CostCenter
      Dim hCC As New Hashtable
      For Each item As SaleBillIssueItem In Me.ItemCollection
        If item.ParentType = 81 Then
          'วางบิลงวด                   
          Dim bi As BillIssue = CType(Me.m_billissues(item.ParentId), BillIssue)
          For Each mi As Milestone In bi.ItemCollection
            If mi.Id = item.Id Then 'AndAlso Not mi.TaxType.Value = 0
              If Not cc Is Nothing AndAlso cc.Id <> mi.CostCenter.Id Then
                Return CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
              Else
                cc = mi.CostCenter
              End If
            End If
          Next
        Else
          Dim tmpcc As CostCenter = GetCCFromDocTypeAndId(item.EntityId, item.Id)
          If tmpcc Is Nothing Then
            tmpcc = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
          End If
          If Not tmpcc Is Nothing Then
            cc = tmpcc
          End If
        End If
        If Not cc Is Nothing Then
          hCC(cc.Id) = cc
        End If
      Next
      If hCC.Count > 1 OrElse cc Is Nothing OrElse Not cc.Originated Then
        Return CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
      End If
      Return cc
    End Function
    Public ReadOnly Property NoVat() As Boolean Implements IVatable.NoVat
      Get
        'RefreshTaxBase()
        'Return TaxAmount <= 0
        Return GetMaximumTaxBase() <= 0
      End Get
    End Property
    Public Property Vat() As Vat Implements IVatable.Vat
      Get
        Return m_vat
      End Get
      Set(ByVal Value As Vat)
        m_vat = Value
      End Set
    End Property
#End Region

#Region "IPrintableEntity"
    Public Function GetDefaultFormPath() As String Implements IPrintableEntity.GetDefaultFormPath
      Return "SalesRecieve"
    End Function
    Public Function GetDefaultForm() As String Implements IPrintableEntity.GetDefaultForm
      Return "SalesRecieve"
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

      'CustomerInfo
      If Me.Customer.Originated Then
        Me.Customer.PopulateDPIColl(dpiColl)
      End If

      Dim cc As CostCenter = GetAllCC()
      If cc Is Nothing Then
        cc = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
      End If
      If cc.Originated Then
        cc.PopulateDPIColl(dpiColl)
      End If

      'Note
      dpi = New DocPrintingItem
      dpi.Mapping = "Note"
      dpi.Value = Me.Note
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'WHT
      dpi = New DocPrintingItem
      dpi.Mapping = "WHT"
      dpi.Value = Configuration.FormatToString(Me.WitholdingTaxCollection.Amount, DigitConfig.Price)
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'AfterTax
      dpi = New DocPrintingItem
      dpi.Mapping = "AfterTax"
      dpi.Value = Configuration.FormatToString(Me.Receive.Amount, DigitConfig.Price)
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'Gross
      dpi = New DocPrintingItem
      dpi.Mapping = "Gross"
      dpi.Value = Configuration.FormatToString(Me.Gross, DigitConfig.Price)
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'DiscountRate = DiscountAmount เลย เพราะไม่มีการใส่สูตร
      dpi = New DocPrintingItem
      dpi.Mapping = "DiscountRate"
      dpi.Value = Configuration.FormatToString(Me.Receive.DiscountAmount, DigitConfig.Price)
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'DiscountAmount
      dpi = New DocPrintingItem
      dpi.Mapping = "DiscountAmount"
      dpi.Value = Configuration.FormatToString(Me.Receive.DiscountAmount, DigitConfig.Price)
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      '--- Last Page ------------------
      '--------------------------------
      'LastPageAfterTax
      dpi = New DocPrintingItem
      dpi.Mapping = "LastPageAfterTax"
      dpi.Value = Configuration.FormatToString(Me.Receive.Amount, DigitConfig.Price)
      dpi.DataType = "System.String"
      dpi.PrintingFrequency = DocPrintingItem.Frequency.LastPage
      dpiColl.Add(dpi)

      'LastPageGross
      dpi = New DocPrintingItem
      dpi.Mapping = "LastPageGross"
      dpi.Value = Configuration.FormatToString(Me.Gross, DigitConfig.Price)
      dpi.DataType = "System.String"
      dpi.PrintingFrequency = DocPrintingItem.Frequency.LastPage
      dpiColl.Add(dpi)

      'LastPageDiscountRate = DiscountAmount เลย เพราะไม่มีการใส่สูตร
      dpi = New DocPrintingItem
      dpi.Mapping = "LastPageDiscountRate"
      dpi.Value = Configuration.FormatToString(Me.Receive.DiscountAmount, DigitConfig.Price)
      dpi.DataType = "System.String"
      dpi.PrintingFrequency = DocPrintingItem.Frequency.LastPage
      dpiColl.Add(dpi)

      'LastPageDiscountAmount
      dpi = New DocPrintingItem
      dpi.Mapping = "LastPageDiscountAmount"
      dpi.Value = Configuration.FormatToString(Me.Receive.DiscountAmount, DigitConfig.Price)
      dpi.DataType = "System.String"
      dpi.PrintingFrequency = DocPrintingItem.Frequency.LastPage
      dpiColl.Add(dpi)
      '--------------------------------

      Dim myVat As Decimal = 0
      Dim myBeforeTax As Decimal = 0

      Dim n As Integer = 0
      Dim n2 As Integer = 0
      Dim line As Integer = 0
      Dim grossitem As Decimal = 0
      Dim discountamountitem As Decimal = 0

      Dim sumBillissue As Decimal = 0
      Dim sumDiscountAmount As Decimal = 0
      Dim sumPenalty As Decimal = 0
      Dim sumRetention As Decimal = 0
      Dim sumBeforeTax As Decimal = 0
      Dim sumTaxBase As Decimal = 0
      Dim sumVat As Decimal = 0
      Dim sumAfterTax As Decimal = 0
      Dim sumAdvanceAmount As Decimal = 0
      Dim sumMilestoneAmount As Decimal = 0
      Dim sumAdvanceWitdraw As Decimal = 0
      Dim sumRemainAmount As Decimal = 0
      For Each item As SaleBillIssueItem In Me.ItemCollection

        '-------------------------------------DETAIL ITEM---------------------------------------
        Try
          Select Case item.EntityId
            Case 83    'GoodsSold
              Dim o As New GoodsSold(item.Id)
              For Each oitem As GoodsSoldItem In o.ItemCollection

                'Item.RefDoc.ItemType                                
                dpi = New DocPrintingItem
                dpi.Mapping = "Item.RefDoc.ItemType"
                dpi.Value = oitem.ItemType.CodeName
                dpi.DataType = "System.String"
                dpi.Row = n2 + 1
                dpi.Table = "Item.RefDoc"
                dpiColl.Add(dpi)

                'Item.RefDoc.ItemCode                                
                dpi = New DocPrintingItem
                dpi.Mapping = "Item.RefDoc.ItemCode"
                dpi.Value = oitem.Entity.Code
                dpi.DataType = "System.String"
                dpi.Row = n2 + 1
                dpi.Table = "Item.RefDoc"
                dpiColl.Add(dpi)

                'Item.RefDoc.ItemName                                
                dpi = New DocPrintingItem
                dpi.Mapping = "Item.RefDoc.ItemName"
                'If Not oitem.EntityName Is Nothing AndAlso oitem.EntityName.Length > 0 Then
                '  dpi.Value = oitem.EntityName
                'Else
                dpi.Value = oitem.Entity.Name
                'End If
                dpi.DataType = "System.String"
                dpi.Row = n2 + 1
                dpi.Table = "Item.RefDoc"
                dpiColl.Add(dpi)

                If Not (oitem.ItemType.Value = 160 OrElse oitem.ItemType.Value = 162) Then
                  line += 1
                  'Item.LineNumber
                  dpi = New DocPrintingItem
                  dpi.Mapping = "Item.RefDoc.LineNumber"
                  dpi.Value = line
                  dpi.DataType = "System.Int32"
                  dpi.Row = n2 + 1
                  dpi.Table = "Item.RefDoc"
                  dpiColl.Add(dpi)

                  'Item.Unit
                  dpi = New DocPrintingItem
                  dpi.Mapping = "Item.RefDoc.Unit"
                  dpi.Value = oitem.Unit.Name
                  dpi.DataType = "System.String"
                  dpi.Row = n2 + 1
                  dpi.Table = "Item.RefDoc"
                  dpiColl.Add(dpi)

                  'Item.Qty
                  dpi = New DocPrintingItem
                  dpi.Mapping = "Item.RefDoc.Qty"
                  If oitem.Qty = 0 Then
                    dpi.Value = ""
                  Else
                    dpi.Value = Configuration.FormatToString(oitem.Qty, DigitConfig.Qty)
                  End If
                  dpi.DataType = "System.String"
                  dpi.Row = n2 + 1
                  dpi.Table = "Item.RefDoc"
                  dpiColl.Add(dpi)

                  'Item.UnitPrice
                  dpi = New DocPrintingItem
                  dpi.Mapping = "Item.RefDoc.UnitPrice"
                  If oitem.UnitPrice = 0 Then
                    dpi.Value = ""
                  Else
                    dpi.Value = Configuration.FormatToString(oitem.UnitPrice, DigitConfig.UnitPrice)
                  End If
                  dpi.DataType = "System.String"
                  dpi.Row = n2 + 1
                  dpi.Table = "Item.RefDoc"
                  dpiColl.Add(dpi)

                  'Item.DiscountRate
                  dpi = New DocPrintingItem
                  dpi.Mapping = "Item.RefDoc.DiscountRate"
                  dpi.Value = oitem.Discount.Rate
                  dpi.DataType = "System.String"
                  dpi.Row = n2 + 1
                  dpi.Table = "Item.RefDoc"
                  dpiColl.Add(dpi)

                  'Item.DiscountAmount
                  dpi = New DocPrintingItem
                  dpi.Mapping = "Item.RefDoc.DiscountAmount"
                  If oitem.Discount.Amount = 0 Then
                    dpi.Value = ""
                  Else
                    dpi.Value = Configuration.FormatToString(oitem.Discount.Amount, DigitConfig.Price)
                  End If
                  dpi.DataType = "System.String"
                  dpi.Row = n2 + 1
                  dpi.Table = "Item.RefDoc"
                  sumDiscountAmount += oitem.Discount.Amount
                  dpiColl.Add(dpi)

                  'Item.Amount
                  dpi = New DocPrintingItem
                  dpi.Mapping = "Item.RefDoc.Amount"
                  If oitem.Amount = 0 Then
                    dpi.Value = ""
                  Else
                    dpi.Value = Configuration.FormatToString(oitem.Amount, DigitConfig.Price)
                  End If
                  dpi.DataType = "System.String"
                  dpi.Row = n2 + 1
                  dpi.Table = "Item.RefDoc"
                  dpiColl.Add(dpi)
                End If

                'Item.Note
                dpi = New DocPrintingItem
                dpi.Mapping = "Item.RefDoc.Note"
                dpi.Value = oitem.Note
                dpi.DataType = "System.String"
                dpi.Row = n2 + 1
                dpi.Table = "Item.RefDoc"
                dpiColl.Add(dpi)

                'Item.ZeroVat
                dpi = New DocPrintingItem
                dpi.Mapping = "Item.RefDoc.ZeroVat"
                dpi.Value = oitem.UnVatable
                dpi.DataType = "System.Boolean"
                dpi.Row = n2 + 1
                dpi.Table = "Item.RefDoc"
                dpiColl.Add(dpi)

                'Item.Beforetax
                dpi = New DocPrintingItem
                dpi.Mapping = "Item.RefDoc.Beforetax"
                dpi.Value = Configuration.FormatToString(oitem.BeforeTax, DigitConfig.Price)
                dpi.DataType = "System.String"
                dpi.Row = n2 + 1
                dpi.Table = "Item.RefDoc"
                dpiColl.Add(dpi)

                'Item.TaxBase
                dpi = New DocPrintingItem
                dpi.Mapping = "Item.RefDoc.TaxBase"
                dpi.Value = Configuration.FormatToString(oitem.TaxBase, DigitConfig.Price)
                dpi.DataType = "System.String"
                dpi.Row = n2 + 1
                dpi.Table = "Item.RefDoc"
                dpiColl.Add(dpi)

                n2 += 1
              Next

              If o.TaxType.Value = 0 OrElse o.TaxType.Value = 1 Then
                sumAdvanceWitdraw += o.AdvanceReceiveItemCollection.GetExcludeVATAmount
              Else
                sumAdvanceWitdraw += o.AdvanceReceiveItemCollection.GetAmount
              End If

              'Item.RefDocCode
              dpi = New DocPrintingItem
              dpi.Mapping = "Item.RefDocCode"
              dpi.Value = o.Code
              dpi.DataType = "System.String"
              dpi.Row = n2
              dpi.Table = "Item.RefDoc"
              dpiColl.Add(dpi)

              'Item.RefDocDate
              dpi = New DocPrintingItem
              dpi.Mapping = "Item.RefDocDate"
              dpi.Value = o.DocDate.ToShortDateString
              dpi.DataType = "System.String"
              dpi.Row = n2
              dpi.Table = "Item.RefDoc"
              dpiColl.Add(dpi)

              'Item.RefDocCustomerCode
              dpi = New DocPrintingItem
              dpi.Mapping = "Item.RefDocCustomerCode"
              dpi.Value = o.Customer.Code
              dpi.DataType = "System.String"
              dpi.Row = n2
              dpi.Table = "Item.RefDoc"
              dpiColl.Add(dpi)

              'Item.RefDocCustomerName
              dpi = New DocPrintingItem
              dpi.Mapping = "Item.RefDocCustomerName"
              dpi.Value = o.Customer.Name
              dpi.DataType = "System.String"
              dpi.Row = n2
              dpi.Table = "Item.RefDoc"
              dpiColl.Add(dpi)

              'Item.RefDocCustomerInfo
              dpi = New DocPrintingItem
              dpi.Mapping = "Item.RefDocCustomerInfo"
              dpi.Value = o.Customer.Code & " : " & o.Customer.Name
              dpi.DataType = "System.String"
              dpi.Row = n2
              dpi.Table = "Item.RefDoc"
              dpiColl.Add(dpi)

              'Item.RefDocFromCCCode
              dpi = New DocPrintingItem
              dpi.Mapping = "Item.RefDocFromCCCode"
              dpi.Value = o.FromCC.Code
              dpi.DataType = "System.String"
              dpi.Row = n2
              dpi.Table = "Item.RefDoc"
              dpiColl.Add(dpi)

              'Item.RefDocFromCCName
              dpi = New DocPrintingItem
              dpi.Mapping = "Item.RefDocFromCCName"
              dpi.Value = o.FromCC.Name
              dpi.DataType = "System.String"
              dpi.Row = n2
              dpi.Table = "Item.RefDoc"
              dpiColl.Add(dpi)

              'Item.RefDocFromCCInfo
              dpi = New DocPrintingItem
              dpi.Mapping = "Item.RefDocFromCCInfo"
              dpi.Value = o.FromCC.Code & " : " & o.FromCC.Name
              dpi.DataType = "System.String"
              dpi.Row = n2
              dpi.Table = "Item.RefDoc"
              dpiColl.Add(dpi)

              'Item.RefDocGross
              dpi = New DocPrintingItem
              dpi.Mapping = "Item.RefDocGross"
              dpi.Value = Configuration.FormatToString(o.RealGross, DigitConfig.Price)
              dpi.DataType = "System.String"
              dpi.Row = n2
              dpi.Table = "Item.RefDoc"
              dpiColl.Add(dpi)

              'Item.RefDocDiscountAmount
              dpi = New DocPrintingItem
              dpi.Mapping = "Item.RefDocDiscountAmount"
              dpi.Value = Configuration.FormatToString(o.Discount.Amount, DigitConfig.Price)
              dpi.DataType = "System.String"
              dpi.Row = n2
              dpi.Table = "Item.RefDoc"
              dpiColl.Add(dpi)

              'Item.RefDocBeforeTax
              dpi = New DocPrintingItem
              dpi.Mapping = "Item.RefDocBeforeTax"
              dpi.Value = Configuration.FormatToString(o.BeforeTax, DigitConfig.Price)
              dpi.DataType = "System.String"
              dpi.Row = n2
              dpi.Table = "Item.RefDoc"
              dpiColl.Add(dpi)

              'Item.RefDocTaxBase
              dpi = New DocPrintingItem
              dpi.Mapping = "Item.RefDocTaxBase"
              dpi.Value = Configuration.FormatToString(o.RealTaxBase, DigitConfig.Price)
              dpi.DataType = "System.String"
              dpi.Row = n2
              dpi.Table = "Item.RefDoc"
              dpiColl.Add(dpi)

              'Item.RefDocTaxAmount
              dpi = New DocPrintingItem
              dpi.Mapping = "Item.RefDocTaxAmount"
              dpi.Value = Configuration.FormatToString(o.RealTaxAmount, DigitConfig.Price)
              dpi.DataType = "System.String"
              dpi.Row = n2
              dpi.Table = "Item.RefDoc"
              dpiColl.Add(dpi)

              'Item.RefDocAfterTax
              dpi = New DocPrintingItem
              dpi.Mapping = "Item.RefDocAfterTax"
              dpi.Value = Configuration.FormatToString(o.AfterTax, DigitConfig.Price)
              dpi.DataType = "System.String"
              dpi.Row = n2
              dpi.Table = "Item.RefDoc"
              dpiColl.Add(dpi)

              If o.TaxType.Value = 1 Then
                sumVat += (o.Amount - o.BeforeTax)
              End If

              'GrossItem กับ DiscountAmountItem
              sumTaxBase += o.RealTaxBase
              grossitem += o.RealGross
              discountamountitem += o.DiscountAmount
              '
            Case 56    'คืนเครื่องจักร
              Dim o As New AssetReturn(item.Id)
              For Each oitem As AssetReturnItem In o.ItemCollection
                'Item.LineNumber
                dpi = New DocPrintingItem
                dpi.Mapping = "Item.RefDoc.LineNumber"
                dpi.Value = n2 + 1
                dpi.DataType = "System.Int32"
                dpi.Row = n2 + 1
                dpi.Table = "Item.RefDoc"
                dpiColl.Add(dpi)

                'Item.Code
                dpi = New DocPrintingItem
                dpi.Mapping = "Item.RefDoc.Code"
                dpi.Value = oitem.Entity.Code
                dpi.DataType = "System.String"
                dpi.Row = n2 + 1
                dpi.Table = "Item.RefDoc"
                dpiColl.Add(dpi)

                'Item.Name
                dpi = New DocPrintingItem
                dpi.Mapping = "Item.RefDoc.Name"
                dpi.Value = "ค่าเช่า" & oitem.Entity.Name
                dpi.DataType = "System.String"
                dpi.Row = n2 + 1
                dpi.Table = "Item.RefDoc"
                dpiColl.Add(dpi)

                'Item.Unit
                dpi = New DocPrintingItem
                dpi.Mapping = "Item.RefDoc.Unit"
                If TypeOf oitem.Entity Is Asset Then
                  If Not CType(oitem.Entity, Asset).Type Is Nothing Then
                    dpi.Value = CType(oitem.Entity, Asset).Type.Unit.Name
                  End If
                End If
                If TypeOf oitem.Entity Is Tool Then
                  dpi.Value = CType(oitem.Entity, Tool).DefaultUnit.Name()
                End If
                dpi.DataType = "System.String"
                dpi.Row = n2 + 1
                dpi.Table = "Item.RefDoc"
                dpiColl.Add(dpi)

                'Item.Qty
                dpi = New DocPrintingItem
                dpi.Mapping = "Item.RefDoc.Qty"
                dpi.Value = 1
                dpi.DataType = "System.String"
                dpi.Row = n2 + 1
                dpi.Table = "Item.RefDoc"
                dpiColl.Add(dpi)

                'Item.UnitPrice
                dpi = New DocPrintingItem
                dpi.Mapping = "Item.RefDoc.UnitPrice"
                'If oitem. = 0 Then
                '    dpi.Value = ""
                'Else
                '    dpi.Value = Configuration.FormatToString(0, DigitConfig.UnitPrice)
                'End If
                dpi.Value = Configuration.FormatToString(0, DigitConfig.UnitPrice)
                dpi.DataType = "System.String"
                dpi.Row = n2 + 1
                dpi.Table = "Item.RefDoc"
                dpiColl.Add(dpi)

                'Item.Amount
                dpi = New DocPrintingItem
                dpi.Mapping = "Item.RefDoc.Amount"
                'If oitem.Amount = 0 Then
                '    dpi.Value = ""
                'Else
                '    dpi.Value = Configuration.FormatToString(oitem.Amount, DigitConfig.Price)
                'End If
                dpi.Value = Configuration.FormatToString(0, DigitConfig.Price)
                dpi.DataType = "System.String"
                dpi.Row = n2 + 1
                dpi.Table = "Item.RefDoc"
                dpiColl.Add(dpi)

                'Item.Note
                dpi = New DocPrintingItem
                dpi.Mapping = "Item.RefDoc.Note"
                dpi.Value = oitem.Note
                dpi.DataType = "System.String"
                dpi.Row = n2 + 1
                dpi.Table = "Item.RefDoc"
                dpiColl.Add(dpi)

                n2 += 1
              Next

              'Item.RefDocCode
              dpi = New DocPrintingItem
              dpi.Mapping = "Item.RefDocCode"
              dpi.Value = o.Code
              dpi.DataType = "System.String"
              dpi.Row = n2
              dpi.Table = "Item.RefDoc"
              dpiColl.Add(dpi)

              'Item.RefDocDate
              dpi = New DocPrintingItem
              dpi.Mapping = "Item.RefDocDate"
              dpi.Value = o.DocDate.ToShortDateString
              dpi.DataType = "System.String"
              dpi.Row = n2
              dpi.Table = "Item.RefDoc"
              dpiColl.Add(dpi)

              'Item.RefDocCustomerCode
              dpi = New DocPrintingItem
              dpi.Mapping = "Item.RefDocCustomerCode"
              dpi.Value = o.Customer.Code
              dpi.DataType = "System.String"
              dpi.Row = n2
              dpi.Table = "Item.RefDoc"
              dpiColl.Add(dpi)

              'Item.RefDocCustomerName
              dpi = New DocPrintingItem
              dpi.Mapping = "Item.RefDocCustomerName"
              dpi.Value = o.Customer.Name
              dpi.DataType = "System.String"
              dpi.Row = n2
              dpi.Table = "Item.RefDoc"
              dpiColl.Add(dpi)

              'Item.RefDocCustomerInfo
              dpi = New DocPrintingItem
              dpi.Mapping = "Item.RefDocCustomerInfo"
              dpi.Value = o.Customer.Code & " : " & o.Customer.Name
              dpi.DataType = "System.String"
              dpi.Row = n2
              dpi.Table = "Item.RefDoc"
              dpiColl.Add(dpi)

              'Item.RefDocFromCCCode
              dpi = New DocPrintingItem
              dpi.Mapping = "Item.RefDocFromCCCode"
              dpi.Value = o.FromCC.Code
              dpi.DataType = "System.String"
              dpi.Row = n2
              dpi.Table = "Item.RefDoc"
              dpiColl.Add(dpi)

              'Item.RefDocFromCCName
              dpi = New DocPrintingItem
              dpi.Mapping = "Item.RefDocFromCCName"
              dpi.Value = o.FromCC.Name
              dpi.DataType = "System.String"
              dpi.Row = n2
              dpi.Table = "Item.RefDoc"
              dpiColl.Add(dpi)

              'Item.RefDocFromCCInfo
              dpi = New DocPrintingItem
              dpi.Mapping = "Item.RefDocFromCCInfo"
              dpi.Value = o.FromCC.Code & " : " & o.FromCC.Name
              dpi.DataType = "System.String"
              dpi.Row = n2
              dpi.Table = "Item.RefDoc"
              dpiColl.Add(dpi)

              'Item.RefDocToCCCode
              dpi = New DocPrintingItem
              dpi.Mapping = "Item.RefDocToCCCode"
              dpi.Value = o.ToCC.Code
              dpi.DataType = "System.String"
              dpi.Row = n2
              dpi.Table = "Item.RefDoc"
              dpiColl.Add(dpi)

              'Item.RefDocToCCName
              dpi = New DocPrintingItem
              dpi.Mapping = "Item.RefDocToCCName"
              dpi.Value = o.ToCC.Name
              dpi.DataType = "System.String"
              dpi.Row = n2
              dpi.Table = "Item.RefDoc"
              dpiColl.Add(dpi)

              'Item.RefDocToCCInfo
              dpi = New DocPrintingItem
              dpi.Mapping = "Item.RefDocToCCInfo"
              dpi.Value = o.ToCC.Code & " : " & o.ToCC.Name
              dpi.DataType = "System.String"
              dpi.Row = n2
              dpi.Table = "Item.RefDoc"
              dpiColl.Add(dpi)


            Case 124    'AssetSold
              Dim o As New AssetSold(item.Id)
              For i As Integer = 0 To o.MaxRowIndex
                Dim itemRow As TreeRow = CType(o.ItemTable.Rows(i), TreeRow)
                If o.ValidateRow(itemRow) Then
                  Dim oitem As New AssetSoldItem
                  oitem.CopyFromDataRow(itemRow)
                  'Item.LineNumber
                  dpi = New DocPrintingItem
                  dpi.Mapping = "Item.RefDoc.LineNumber"
                  dpi.Value = n2 + 1
                  dpi.DataType = "System.Int32"
                  dpi.Row = n2 + 1
                  dpi.Table = "Item.RefDoc"
                  dpiColl.Add(dpi)

                  'Item.Code
                  dpi = New DocPrintingItem
                  dpi.Mapping = "Item.RefDoc.Code"
                  dpi.Value = oitem.Entity.Code
                  dpi.DataType = "System.String"
                  dpi.Row = n2 + 1
                  dpi.Table = "Item.RefDoc"
                  dpiColl.Add(dpi)

                  'Item.Name
                  dpi = New DocPrintingItem
                  dpi.Mapping = "Item.RefDoc.Name"
                  If Not oitem.EntityName Is Nothing AndAlso oitem.EntityName.Length > 0 Then
                    dpi.Value = oitem.EntityName
                  Else
                    dpi.Value = oitem.Entity.Name
                  End If
                  dpi.DataType = "System.String"
                  dpi.Row = n2 + 1
                  dpi.Table = "Item.RefDoc"
                  dpiColl.Add(dpi)

                  'Item.Unit
                  dpi = New DocPrintingItem
                  dpi.Mapping = "Item.RefDoc.Unit"
                  dpi.Value = oitem.Unit.Name
                  dpi.DataType = "System.String"
                  dpi.Row = n2 + 1
                  dpi.Table = "Item.RefDoc"
                  dpiColl.Add(dpi)

                  'Item.Qty
                  dpi = New DocPrintingItem
                  dpi.Mapping = "Item.RefDoc.Qty"
                  dpi.Value = Configuration.FormatToString(oitem.Qty, DigitConfig.Qty)
                  dpi.DataType = "System.String"
                  dpi.Row = n2 + 1
                  dpi.Table = "Item.RefDoc"
                  dpiColl.Add(dpi)

                  'Item.UnitPrice
                  dpi = New DocPrintingItem
                  dpi.Mapping = "Item.RefDoc.UnitPrice"
                  If oitem.UnitPrice = 0 Then
                    dpi.Value = ""
                  Else
                    dpi.Value = Configuration.FormatToString(oitem.UnitPrice, DigitConfig.UnitPrice)
                  End If
                  dpi.DataType = "System.String"
                  dpi.Row = n2 + 1
                  dpi.Table = "Item.RefDoc"
                  dpiColl.Add(dpi)

                  'Item.DiscountRate
                  dpi = New DocPrintingItem
                  dpi.Mapping = "Item.RefDoc.DiscountRate"
                  dpi.Value = oitem.Discount.Rate
                  dpi.DataType = "System.String"
                  dpi.Row = n2 + 1
                  dpi.Table = "Item.RefDoc"
                  dpiColl.Add(dpi)

                  'Item.DiscountAmount
                  dpi = New DocPrintingItem
                  dpi.Mapping = "Item.RefDoc.DiscountAmount"
                  If oitem.Discount.Amount = 0 Then
                    dpi.Value = ""
                  Else
                    dpi.Value = Configuration.FormatToString(oitem.Discount.Amount, DigitConfig.Price)
                  End If
                  dpi.DataType = "System.String"
                  dpi.Row = n2 + 1
                  dpi.Table = "Item.RefDoc"
                  dpiColl.Add(dpi)

                  'Item.Amount
                  dpi = New DocPrintingItem
                  dpi.Mapping = "Item.RefDoc.Amount"
                  If oitem.Amount = 0 Then
                    dpi.Value = ""
                  Else
                    dpi.Value = Configuration.FormatToString(oitem.Amount, DigitConfig.Price)
                  End If
                  dpi.DataType = "System.String"
                  dpi.Row = n2 + 1
                  dpi.Table = "Item.RefDoc"
                  dpiColl.Add(dpi)

                  'Item.Note
                  dpi = New DocPrintingItem
                  dpi.Mapping = "Item.RefDoc.Note"
                  dpi.Value = oitem.Note
                  dpi.DataType = "System.String"
                  dpi.Row = n2 + 1
                  dpi.Table = "Item.RefDoc"
                  dpiColl.Add(dpi)

                  'Item.ZeroVat
                  dpi = New DocPrintingItem
                  dpi.Mapping = "Item.RefDoc.ZeroVat"
                  dpi.Value = oitem.UnVatable
                  dpi.DataType = "System.Boolean"
                  dpi.Row = n2 + 1
                  dpi.Table = "Item.RefDoc"
                  dpiColl.Add(dpi)

                  n2 += 1
                End If
              Next

              'Item.RefDocCode
              dpi = New DocPrintingItem
              dpi.Mapping = "Item.RefDocCode"
              dpi.Value = o.Code
              dpi.DataType = "System.String"
              dpi.Row = n2
              dpi.Table = "Item.RefDoc"
              dpiColl.Add(dpi)

              'Item.RefDocDate
              dpi = New DocPrintingItem
              dpi.Mapping = "Item.RefDocDate"
              dpi.Value = o.DocDate.ToShortDateString
              dpi.DataType = "System.String"
              dpi.Row = n2
              dpi.Table = "Item.RefDoc"
              dpiColl.Add(dpi)

              'Item.RefDocCustomerCode
              dpi = New DocPrintingItem
              dpi.Mapping = "Item.RefDocCustomerCode"
              dpi.Value = o.Customer.Code
              dpi.DataType = "System.String"
              dpi.Row = n2
              dpi.Table = "Item.RefDoc"
              dpiColl.Add(dpi)

              'Item.RefDocCustomerName
              dpi = New DocPrintingItem
              dpi.Mapping = "Item.RefDocCustomerName"
              dpi.Value = o.Customer.Name
              dpi.DataType = "System.String"
              dpi.Row = n2
              dpi.Table = "Item.RefDoc"
              dpiColl.Add(dpi)

              'Item.RefDocCustomerInfo
              dpi = New DocPrintingItem
              dpi.Mapping = "Item.RefDocCustomerInfo"
              dpi.Value = o.Customer.Code & " : " & o.Customer.Name
              dpi.DataType = "System.String"
              dpi.Row = n2
              dpi.Table = "Item.RefDoc"
              dpiColl.Add(dpi)

              'Item.RefDocFromCCCode
              dpi = New DocPrintingItem
              dpi.Mapping = "Item.RefDocFromCCCode"
              dpi.Value = o.FromCC.Code
              dpi.DataType = "System.String"
              dpi.Row = n2
              dpi.Table = "Item.RefDoc"
              dpiColl.Add(dpi)

              'Item.RefDocFromCCName
              dpi = New DocPrintingItem
              dpi.Mapping = "Item.RefDocFromCCName"
              dpi.Value = o.FromCC.Name
              dpi.DataType = "System.String"
              dpi.Row = n2
              dpi.Table = "Item.RefDoc"
              dpiColl.Add(dpi)

              'Item.RefDocFromCCInfo
              dpi = New DocPrintingItem
              dpi.Mapping = "Item.RefDocFromCCInfo"
              dpi.Value = o.FromCC.Code & " : " & o.FromCC.Name
              dpi.DataType = "System.String"
              dpi.Row = n2
              dpi.Table = "Item.RefDoc"
              dpiColl.Add(dpi)

              'Item.RefDocGross
              dpi = New DocPrintingItem
              dpi.Mapping = "Item.RefDocGross"
              dpi.Value = Configuration.FormatToString(o.Gross, DigitConfig.Price)
              dpi.DataType = "System.String"
              dpi.Row = n2
              dpi.Table = "Item.RefDoc"
              dpiColl.Add(dpi)

              'Item.RefDocDiscountAmount
              dpi = New DocPrintingItem
              dpi.Mapping = "Item.RefDocDiscountAmount"
              dpi.Value = Configuration.FormatToString(o.Discount.Amount, DigitConfig.Price)
              dpi.DataType = "System.String"
              dpi.Row = n2
              dpi.Table = "Item.RefDoc"
              dpiColl.Add(dpi)

              'Item.RefDocBeforeTax
              dpi = New DocPrintingItem
              dpi.Mapping = "Item.RefDocBeforeTax"
              dpi.Value = Configuration.FormatToString(o.BeforeTax, DigitConfig.Price)
              dpi.DataType = "System.String"
              dpi.Row = n2
              dpi.Table = "Item.RefDoc"
              dpiColl.Add(dpi)

              'Item.RefDocTaxBase
              dpi = New DocPrintingItem
              dpi.Mapping = "Item.RefDocTaxBase"
              dpi.Value = Configuration.FormatToString(o.TaxBase, DigitConfig.Price)
              dpi.DataType = "System.String"
              dpi.Row = n2
              dpi.Table = "Item.RefDoc"
              dpiColl.Add(dpi)

              'Item.RefDocTaxAmount
              dpi = New DocPrintingItem
              dpi.Mapping = "Item.RefDocTaxAmount"
              dpi.Value = Configuration.FormatToString(o.TaxAmount, DigitConfig.Price)
              dpi.DataType = "System.String"
              dpi.Row = n2
              dpi.Table = "Item.RefDoc"
              dpiColl.Add(dpi)

              'Item.RefDocAfterTax
              dpi = New DocPrintingItem
              dpi.Mapping = "Item.RefDocAfterTax"
              dpi.Value = Configuration.FormatToString(o.AfterTax, DigitConfig.Price)
              dpi.DataType = "System.String"
              dpi.Row = n2
              dpi.Table = "Item.RefDoc"
              dpiColl.Add(dpi)

            Case 75, 77, 78, 86    'Milestone
              Dim mi As New Milestone(item.Id)
              'Dim mic As New MilestoneCollection(Me.Customer)
              'Item.LineNumber
              dpi = New DocPrintingItem
              dpi.Mapping = "Item.RefDoc.LineNumber"
              dpi.Value = n2 + 1
              dpi.DataType = "System.Int32"
              dpi.Row = n2 + 1
              dpi.Table = "Item.RefDoc"
              dpiColl.Add(dpi)

              'Item.Code
              dpi = New DocPrintingItem
              dpi.Mapping = "Item.RefDoc.Code"
              dpi.Value = mi.Code
              dpi.DataType = "System.String"
              dpi.Row = n2 + 1
              dpi.Table = "Item.RefDoc"
              dpiColl.Add(dpi)

              'Item.Name
              dpi = New DocPrintingItem
              dpi.Mapping = "Item.RefDoc.Name"
              dpi.Value = mi.Name
              dpi.DataType = "System.String"
              dpi.Row = n2 + 1
              dpi.Table = "Item.RefDoc"
              dpiColl.Add(dpi)

              'Item.CodeAndName
              dpi = New DocPrintingItem
              dpi.Mapping = "Item.RefDoc.CodeAndName"
              dpi.Value = mi.Code & ":" & mi.Name
              dpi.DataType = "System.String"
              dpi.Row = n2 + 1
              dpi.Table = "Item.RefDoc"
              dpiColl.Add(dpi)

              'Item.UnitPrice
              dpi = New DocPrintingItem
              dpi.Mapping = "Item.RefDoc.UnitPrice"
              dpi.Value = Configuration.FormatToString(item.Amount + item.ARretention, DigitConfig.Price)
              dpi.DataType = "System.Int32"
              dpi.Row = n2 + 1
              dpi.Table = "Item.RefDoc"
              dpiColl.Add(dpi)

              'Item.Unit
              dpi = New DocPrintingItem
              dpi.Mapping = "Item.RefDoc.Unit"
              dpi.Value = "รายการ"
              dpi.DataType = "System.String"
              dpi.Row = n + 1
              dpi.Table = "Item.RefDoc"
              dpiColl.Add(dpi)

              'Item.Qty
              dpi = New DocPrintingItem
              dpi.Mapping = "Item.RefDoc.Qty"
              dpi.Value = 1
              dpi.DataType = "System.String"
              dpi.Row = n2 + 1
              dpi.Table = "Item.RefDoc"
              dpiColl.Add(dpi)

              'Item.RefCode
              dpi = New DocPrintingItem
              dpi.Mapping = "Item.RefDoc.RefCode"
              dpi.Value = item.Code
              dpi.DataType = "System.String"
              dpi.Row = n2 + 1
              dpi.Table = "Item.RefDoc"
              dpiColl.Add(dpi)

              'Item.RefDate
              dpi = New DocPrintingItem
              dpi.Mapping = "Item.RefDoc.RefDate"
              dpi.Value = item.Date
              dpi.DataType = "System.DateTime"
              dpi.Row = n2 + 1
              dpi.Table = "Item.RefDoc"
              dpiColl.Add(dpi)

              'Item.SBICode
              dpi = New DocPrintingItem
              dpi.Mapping = "Item.RefDoc.SBICode"
              dpi.Value = item.ParentCode
              dpi.DataType = "System.String"
              dpi.Row = n2 + 1
              dpi.Table = "Item.RefDoc"
              dpiColl.Add(dpi)

              'Item.Amount
              dpi = New DocPrintingItem
              dpi.Mapping = "Item.RefDoc.Amount"
              dpi.Value = Configuration.FormatToString(item.Amount, DigitConfig.Price)
              dpi.DataType = "System.Int32"
              dpi.Row = n2 + 1
              dpi.Table = "Item.RefDoc"
              dpiColl.Add(dpi)

              'Item.billiAmount
              dpi = New DocPrintingItem
              dpi.Mapping = "Item.RefDoc.BilliAmount"
              dpi.Value = Configuration.FormatToString(item.Amount + item.ARretention, DigitConfig.Price)
              dpi.DataType = "System.Int32"
              dpi.Row = n2 + 1
              dpi.Table = "Item.RefDoc"
              dpiColl.Add(dpi)

              'Item.RemainingAmount
              dpi = New DocPrintingItem
              dpi.Mapping = "Item.RefDoc.RemainingAmount"
              dpi.Value = Configuration.FormatToString(item.RemainingAmount, DigitConfig.Price)
              dpi.DataType = "System.Int32"
              dpi.Row = n2 + 1
              dpi.Table = "Item.RefDoc"
              dpiColl.Add(dpi)

              'Item.AmountHeaderText
              dpi = New DocPrintingItem
              dpi.Mapping = "Item.RefDoc.AmountHeaderText"
              dpi.Value = Configuration.FormatToString(item.RemainingAmount, DigitConfig.Price)
              dpi.DataType = "System.Int32"
              dpi.Row = n2 + 1
              dpi.Table = "Item.RefDoc"
              dpiColl.Add(dpi)

              'Item.Beforetax
              dpi = New DocPrintingItem
              dpi.Mapping = "Item.RefDoc.Beforetax"
              dpi.Value = Configuration.FormatToString(item.BeforeTax, DigitConfig.Price)
              dpi.DataType = "System.String"
              dpi.Row = n2 + 1
              dpi.Table = "Item.RefDoc"
              dpiColl.Add(dpi)

              'Item.MilestoneAmount
              dpi = New DocPrintingItem
              dpi.Mapping = "Item.MilestoneAmount"
              dpi.Value = Configuration.FormatToString(mi.RealMileStoneAmount, DigitConfig.Price)
              dpi.DataType = "System.String"
              dpi.Row = n2 + 1
              dpi.Table = "Item"
              dpiColl.Add(dpi)

              'Item.billiAmount
              dpi = New DocPrintingItem
              dpi.Mapping = "Item.billiAmount"
              dpi.Value = Configuration.FormatToString(mi.AfterTax + mi.RetentionforReceiveSelection, DigitConfig.Price)
              dpi.DataType = "System.String"
              dpi.Row = n2 + 1
              dpi.Table = "Item"
              dpiColl.Add(dpi)

              'Item.Beforetax
              dpi = New DocPrintingItem
              dpi.Mapping = "Item.Beforetax"
              dpi.Value = Configuration.FormatToString(mi.BeforeTax, DigitConfig.Price)
              dpi.DataType = "System.String"
              dpi.Row = n2 + 1
              dpi.Table = "Item"
              dpiColl.Add(dpi)

              'Item.TaxBase
              dpi = New DocPrintingItem
              dpi.Mapping = "Item.TaxBase"
              dpi.Value = Configuration.FormatToString(mi.RealTaxBase, DigitConfig.Price)
              dpi.DataType = "System.String"
              dpi.Row = n2 + 1
              dpi.Table = "Item"
              dpiColl.Add(dpi)

              'Item.TaxAmount
              dpi = New DocPrintingItem
              dpi.Mapping = "Item.TaxAmount"
              dpi.Value = Configuration.FormatToString(mi.RealTaxAmount, DigitConfig.Price)
              dpi.DataType = "System.String"
              dpi.Row = n2 + 1
              dpi.Table = "Item"
              dpiColl.Add(dpi)

              'Item.AfterTax
              dpi = New DocPrintingItem
              dpi.Mapping = "Item.AfterTax"
              dpi.Value = Configuration.FormatToString(mi.AfterTax, DigitConfig.Price)
              dpi.DataType = "System.String"
              dpi.Row = n2 + 1
              dpi.Table = "Item"
              dpiColl.Add(dpi)

              'Item.RemainingAmount
              dpi = New DocPrintingItem
              dpi.Mapping = "Item.RemainingAmount"
              dpi.Value = Configuration.FormatToString(item.RemainingAmount, DigitConfig.Price)
              dpi.DataType = "System.Int32"
              dpi.Row = n2 + 1
              dpi.Table = "Item"
              dpiColl.Add(dpi)

              'Item.Amount
              dpi = New DocPrintingItem
              dpi.Mapping = "Item.Amount"
              dpi.Value = Configuration.FormatToString(item.Amount, DigitConfig.Price)
              dpi.DataType = "System.Int32"
              dpi.Row = n2 + 1
              dpi.Table = "Item"
              dpiColl.Add(dpi)

              'Item.retention
              dpi = New DocPrintingItem
              dpi.Mapping = "Item.RetentionAmount"
              dpi.Value = Configuration.FormatToString(mi.RetentionforReceiveSelection, DigitConfig.Price)
              dpi.DataType = "System.String"
              dpi.Row = n2 + 1
              dpi.Table = "Item"
              dpiColl.Add(dpi)

              'Item.Advance
              dpi = New DocPrintingItem
              dpi.Mapping = "Item.Advance"
              dpi.Value = Configuration.FormatToString(mi.Advance, DigitConfig.Price)
              dpi.DataType = "System.String"
              dpi.Row = n2 + 1
              dpi.Table = "Item"
              dpiColl.Add(dpi)

              'Item.Penalty
              dpi = New DocPrintingItem
              dpi.Mapping = "Item.Penalty"
              dpi.Value = Configuration.FormatToString(mi.Penalty, DigitConfig.Price)
              dpi.DataType = "System.String"
              dpi.Row = n2 + 1
              dpi.Table = "Item"
              dpiColl.Add(dpi)

              'Item.DiscountAmountItem
              dpi = New DocPrintingItem
              dpi.Mapping = "Item.DiscountAmountItem"
              dpi.Value = Configuration.FormatToString(mi.DiscountAmount, DigitConfig.Price)
              dpi.DataType = "System.String"
              dpi.Row = n2 + 1
              dpi.Table = "Item"
              dpiColl.Add(dpi)

              'Item.Note
              dpi = New DocPrintingItem
              dpi.Mapping = "Item.Note"
              dpi.Value = item.Note
              dpi.DataType = "System.String"
              dpi.Row = n2 + 1
              dpi.Table = "Item"
              dpiColl.Add(dpi)

              'Item.RefDocCode
              dpi = New DocPrintingItem
              dpi.Mapping = "Item.RefDocCode"
              dpi.Value = mi.Code
              dpi.DataType = "System.String"
              dpi.Row = n2
              dpi.Table = "Item.RefDoc"
              dpiColl.Add(dpi)

              'Item.RefDocDate
              dpi = New DocPrintingItem
              dpi.Mapping = "Item.RefDocDate"
              dpi.Value = mi.DocDate.ToShortDateString
              dpi.DataType = "System.String"
              dpi.Row = n2
              dpi.Table = "Item.RefDoc"
              dpiColl.Add(dpi)

              'Item.RefDocCustomerCode
              dpi = New DocPrintingItem
              dpi.Mapping = "Item.RefDocCustomerCode"
              dpi.Value = Me.Customer.Code
              dpi.DataType = "System.String"
              dpi.Row = n2
              dpi.Table = "Item.RefDoc"
              dpiColl.Add(dpi)

              'Item.RefDocCustomerName
              dpi = New DocPrintingItem
              dpi.Mapping = "Item.RefDocCustomerName"
              dpi.Value = Me.Customer.Name
              dpi.DataType = "System.String"
              dpi.Row = n2
              dpi.Table = "Item.RefDoc"
              dpiColl.Add(dpi)

              'Item.RefDocCustomerInfo
              dpi = New DocPrintingItem
              dpi.Mapping = "Item.RefDocCustomerInfo"
              dpi.Value = Me.Customer.Code & " : " & Me.Customer.Name
              dpi.DataType = "System.String"
              dpi.Row = n2
              dpi.Table = "Item.RefDoc"
              dpiColl.Add(dpi)

              If mi.TaxType.Value = 1 Then
                sumVat += (mi.Amount - mi.BeforeTax)
              End If

              sumMilestoneAmount += mi.RealMileStoneAmount
              sumBillissue += mi.Amount + mi.RetentionforReceiveSelection
              sumRetention += mi.RetentionforReceiveSelection
              sumTaxBase += mi.RealTaxBase
              sumAdvanceAmount += mi.Advance
              sumBeforeTax += mi.BeforeTax
              sumPenalty += mi.Penalty
              sumAfterTax += mi.AfterTax
              sumRemainAmount += item.RemainingAmount

              grossitem += item.RealAmount

              discountamountitem += mi.DiscountAmount


              n2 += 1

            Case 79   'Milestone  งานลด
              Dim mi As New Milestone(item.Id)
              'Dim mic As New MilestoneCollection(Me.Customer)
              'Item.LineNumber
              dpi = New DocPrintingItem
              dpi.Mapping = "Item.RefDoc.LineNumber"
              dpi.Value = n2 + 1
              dpi.DataType = "System.Int32"
              dpi.Row = n2 + 1
              dpi.Table = "Item.RefDoc"
              dpiColl.Add(dpi)

              'Item.Code
              dpi = New DocPrintingItem
              dpi.Mapping = "Item.RefDoc.Code"
              dpi.Value = mi.Code
              dpi.DataType = "System.String"
              dpi.Row = n2 + 1
              dpi.Table = "Item.RefDoc"
              dpiColl.Add(dpi)

              'Item.Name
              dpi = New DocPrintingItem
              dpi.Mapping = "Item.RefDoc.Name"
              dpi.Value = mi.Name
              dpi.DataType = "System.String"
              dpi.Row = n2 + 1
              dpi.Table = "Item.RefDoc"
              dpiColl.Add(dpi)

              'Item.CodeAndName
              dpi = New DocPrintingItem
              dpi.Mapping = "Item.RefDoc.CodeAndName"
              dpi.Value = mi.Code & ":" & mi.Name
              dpi.DataType = "System.String"
              dpi.Row = n2 + 1
              dpi.Table = "Item.RefDoc"
              dpiColl.Add(dpi)

              'Item.UnitPrice
              dpi = New DocPrintingItem
              dpi.Mapping = "Item.RefDoc.UnitPrice"
              dpi.Value = Configuration.FormatToString(item.Amount, DigitConfig.Price)
              dpi.DataType = "System.Int32"
              dpi.Row = n2 + 1
              dpi.Table = "Item.RefDoc"
              dpiColl.Add(dpi)

              'Item.Unit
              dpi = New DocPrintingItem
              dpi.Mapping = "Item.Unit"
              dpi.Value = "รายการ"
              dpi.DataType = "System.String"
              dpi.Row = n + 1
              dpi.Table = "Item"
              dpiColl.Add(dpi)

              'Item.Qty
              dpi = New DocPrintingItem
              dpi.Mapping = "Item.RefDoc.Qty"
              dpi.Value = 1
              dpi.DataType = "System.String"
              dpi.Row = n2 + 1
              dpi.Table = "Item.RefDoc"
              dpiColl.Add(dpi)

              'Item.RefCode
              dpi = New DocPrintingItem
              dpi.Mapping = "Item.RefDoc.RefCode"
              dpi.Value = item.Code
              dpi.DataType = "System.String"
              dpi.Row = n2 + 1
              dpi.Table = "Item.RefDoc"
              dpiColl.Add(dpi)

              'Item.RefDate
              dpi = New DocPrintingItem
              dpi.Mapping = "Item.RefDoc.RefDate"
              dpi.Value = item.Date
              dpi.DataType = "System.DateTime"
              dpi.Row = n2 + 1
              dpi.Table = "Item.RefDoc"
              dpiColl.Add(dpi)

              'Item.SBICode
              dpi = New DocPrintingItem
              dpi.Mapping = "Item.RefDoc.SBICode"
              dpi.Value = item.ParentCode
              dpi.DataType = "System.String"
              dpi.Row = n2 + 1
              dpi.Table = "Item.RefDoc"
              dpiColl.Add(dpi)

              'Item.Amount
              dpi = New DocPrintingItem
              dpi.Mapping = "Item.RefDoc.Amount"
              dpi.Value = Configuration.FormatToString(item.Amount, DigitConfig.Price)
              dpi.DataType = "System.Int32"
              dpi.Row = n2 + 1
              dpi.Table = "Item.RefDoc"
              dpiColl.Add(dpi)

              'Item.RemainingAmount
              dpi = New DocPrintingItem
              dpi.Mapping = "Item.RefDoc.RemainingAmount"
              dpi.Value = Configuration.FormatToString(item.RemainingAmount, DigitConfig.Price)
              dpi.DataType = "System.Int32"
              dpi.Row = n2 + 1
              dpi.Table = "Item.RefDoc"
              dpiColl.Add(dpi)

              'Item.AmountHeaderText
              dpi = New DocPrintingItem
              dpi.Mapping = "Item.RefDoc.AmountHeaderText"
              dpi.Value = Configuration.FormatToString(item.RemainingAmount, DigitConfig.Price)
              dpi.DataType = "System.Int32"
              dpi.Row = n2 + 1
              dpi.Table = "Item.RefDoc"
              dpiColl.Add(dpi)

              'Item.Beforetax
              dpi = New DocPrintingItem
              dpi.Mapping = "Item.RefDoc.Beforetax"
              dpi.Value = Configuration.FormatToString(-item.BeforeTax, DigitConfig.Price)
              dpi.DataType = "System.String"
              dpi.Row = n2 + 1
              dpi.Table = "Item.RefDoc"
              dpiColl.Add(dpi)

              'Item.MilestoneAmount
              dpi = New DocPrintingItem
              dpi.Mapping = "Item.MilestoneAmount"
              dpi.Value = Configuration.FormatToString(-mi.RealMileStoneAmount, DigitConfig.Price)
              dpi.DataType = "System.String"
              dpi.Row = n2 + 1
              dpi.Table = "Item"
              dpiColl.Add(dpi)

              'Item.billiAmount
              dpi = New DocPrintingItem
              dpi.Mapping = "Item.billiAmount"
              dpi.Value = Configuration.FormatToString(-mi.AfterTax - mi.RetentionforReceiveSelection, DigitConfig.Price)
              dpi.DataType = "System.String"
              dpi.Row = n2 + 1
              dpi.Table = "Item"
              dpiColl.Add(dpi)

              'Item.Beforetax
              dpi = New DocPrintingItem
              dpi.Mapping = "Item.Beforetax"
              dpi.Value = Configuration.FormatToString(-mi.BeforeTax, DigitConfig.Price)
              dpi.DataType = "System.String"
              dpi.Row = n2 + 1
              dpi.Table = "Item"
              dpiColl.Add(dpi)

              'Item.TaxBase
              dpi = New DocPrintingItem
              dpi.Mapping = "Item.TaxBase"
              dpi.Value = Configuration.FormatToString(-mi.RealTaxBase, DigitConfig.Price)
              dpi.DataType = "System.String"
              dpi.Row = n2 + 1
              dpi.Table = "Item"
              dpiColl.Add(dpi)

              'Item.TaxAmount
              dpi = New DocPrintingItem
              dpi.Mapping = "Item.TaxAmount"
              dpi.Value = Configuration.FormatToString(-mi.RealTaxAmount, DigitConfig.Price)
              dpi.DataType = "System.String"
              dpi.Row = n2 + 1
              dpi.Table = "Item"
              dpiColl.Add(dpi)

              'Item.AfterTax
              dpi = New DocPrintingItem
              dpi.Mapping = "Item.AfterTax"
              dpi.Value = Configuration.FormatToString(-mi.AfterTax, DigitConfig.Price)
              dpi.DataType = "System.String"
              dpi.Row = n2 + 1
              dpi.Table = "Item"
              dpiColl.Add(dpi)

              'Item.RemainingAmount
              dpi = New DocPrintingItem
              dpi.Mapping = "Item.RemainingAmount"
              dpi.Value = Configuration.FormatToString(-item.RemainingAmount, DigitConfig.Price)
              dpi.DataType = "System.Int32"
              dpi.Row = n2 + 1
              dpi.Table = "Item"
              dpiColl.Add(dpi)

              'Item.Amount
              dpi = New DocPrintingItem
              dpi.Mapping = "Item.Amount"
              dpi.Value = Configuration.FormatToString(-item.Amount, DigitConfig.Price)
              dpi.DataType = "System.Int32"
              dpi.Row = n2 + 1
              dpi.Table = "Item"
              dpiColl.Add(dpi)

              'Item.retention
              dpi = New DocPrintingItem
              dpi.Mapping = "Item.RetentionAmount"
              dpi.Value = Configuration.FormatToString(-mi.RetentionforReceiveSelection, DigitConfig.Price)
              dpi.DataType = "System.String"
              dpi.Row = n2 + 1
              dpi.Table = "Item"
              dpiColl.Add(dpi)

              'Item.Advance
              dpi = New DocPrintingItem
              dpi.Mapping = "Item.Advance"
              dpi.Value = Configuration.FormatToString(-mi.Advance, DigitConfig.Price)
              dpi.DataType = "System.String"
              dpi.Row = n2 + 1
              dpi.Table = "Item"
              dpiColl.Add(dpi)

              'Item.Penalty
              dpi = New DocPrintingItem
              dpi.Mapping = "Item.Penalty"
              dpi.Value = Configuration.FormatToString(-mi.Penalty, DigitConfig.Price)
              dpi.DataType = "System.String"
              dpi.Row = n2 + 1
              dpi.Table = "Item"
              dpiColl.Add(dpi)

              'Item.DiscountAmountItem
              dpi = New DocPrintingItem
              dpi.Mapping = "Item.DiscountAmountItem"
              dpi.Value = Configuration.FormatToString(-mi.DiscountAmount, DigitConfig.Price)
              dpi.DataType = "System.String"
              dpi.Row = n2 + 1
              dpi.Table = "Item"
              dpiColl.Add(dpi)

              'Item.Note
              dpi = New DocPrintingItem
              dpi.Mapping = "Item.Note"
              dpi.Value = item.Note
              dpi.DataType = "System.String"
              dpi.Row = n2 + 1
              dpi.Table = "Item"
              dpiColl.Add(dpi)

              'Item.RefDocCode
              dpi = New DocPrintingItem
              dpi.Mapping = "Item.RefDocCode"
              dpi.Value = mi.Code
              dpi.DataType = "System.String"
              dpi.Row = n2
              dpi.Table = "Item.RefDoc"
              dpiColl.Add(dpi)

              'Item.RefDocDate
              dpi = New DocPrintingItem
              dpi.Mapping = "Item.RefDocDate"
              dpi.Value = mi.DocDate.ToShortDateString
              dpi.DataType = "System.String"
              dpi.Row = n2
              dpi.Table = "Item.RefDoc"
              dpiColl.Add(dpi)

              'Item.RefDocCustomerCode
              dpi = New DocPrintingItem
              dpi.Mapping = "Item.RefDocCustomerCode"
              dpi.Value = Me.Customer.Code
              dpi.DataType = "System.String"
              dpi.Row = n2
              dpi.Table = "Item.RefDoc"
              dpiColl.Add(dpi)

              'Item.RefDocCustomerName
              dpi = New DocPrintingItem
              dpi.Mapping = "Item.RefDocCustomerName"
              dpi.Value = Me.Customer.Name
              dpi.DataType = "System.String"
              dpi.Row = n2
              dpi.Table = "Item.RefDoc"
              dpiColl.Add(dpi)

              'Item.RefDocCustomerInfo
              dpi = New DocPrintingItem
              dpi.Mapping = "Item.RefDocCustomerInfo"
              dpi.Value = Me.Customer.Code & " : " & Me.Customer.Name
              dpi.DataType = "System.String"
              dpi.Row = n2
              dpi.Table = "Item.RefDoc"
              dpiColl.Add(dpi)

              If mi.TaxType.Value = 1 Then
                sumVat -= (mi.Amount - mi.BeforeTax)
              End If

              sumMilestoneAmount -= mi.RealMileStoneAmount
              sumBillissue -= mi.Amount - mi.RetentionforReceiveSelection
              sumRetention -= mi.RetentionforReceiveSelection
              sumTaxBase -= mi.RealTaxBase
              sumAdvanceAmount -= mi.Advance
              sumBeforeTax -= mi.BeforeTax
              sumPenalty -= mi.Penalty
              sumAfterTax -= mi.AfterTax
              sumRemainAmount -= item.RemainingAmount

              grossitem -= item.RealAmount

              discountamountitem -= mi.DiscountAmount


              n2 += 1

            Case Else    '24 'ลูกหนี้ยกมา และอื่นๆ
              'Item.LineNumber
              dpi = New DocPrintingItem
              dpi.Mapping = "Item.RefDoc.LineNumber"
              dpi.Value = n2 + 1
              dpi.DataType = "System.Int32"
              dpi.Row = n2 + 1
              dpi.Table = "Item.RefDoc"
              dpiColl.Add(dpi)

              'Item.Name
              dpi = New DocPrintingItem
              dpi.Mapping = "Item.RefDoc.Name"
              dpi.Value = item.Code
              dpi.DataType = "System.String"
              dpi.Row = n2 + 1
              dpi.Table = "Item.RefDoc"
              dpiColl.Add(dpi)

              'Item.UnitPrice
              dpi = New DocPrintingItem
              dpi.Mapping = "Item.RefDoc.UnitPrice"
              dpi.Value = Configuration.FormatToString(item.Amount, DigitConfig.Price)
              dpi.DataType = "System.Int32"
              dpi.Row = n2 + 1
              dpi.Table = "Item.RefDoc"
              dpiColl.Add(dpi)

              'Item.Unit
              dpi = New DocPrintingItem
              dpi.Mapping = "Item.Unit"
              dpi.Value = "รายการ"
              dpi.DataType = "System.String"
              dpi.Row = n + 1
              dpi.Table = "Item"
              dpiColl.Add(dpi)

              'Item.Qty
              dpi = New DocPrintingItem
              dpi.Mapping = "Item.RefDoc.Qty"
              dpi.Value = 1
              dpi.DataType = "System.String"
              dpi.Row = n2 + 1
              dpi.Table = "Item.RefDoc"
              dpiColl.Add(dpi)

              'Item.RefCode
              dpi = New DocPrintingItem
              dpi.Mapping = "Item.RefDoc.RefCode"
              dpi.Value = item.Code
              dpi.DataType = "System.String"
              dpi.Row = n2 + 1
              dpi.Table = "Item.RefDoc"
              dpiColl.Add(dpi)

              'Item.RefDate
              dpi = New DocPrintingItem
              dpi.Mapping = "Item.RefDoc.RefDate"
              dpi.Value = item.Date
              dpi.DataType = "System.DateTime"
              dpi.Row = n2 + 1
              dpi.Table = "Item.RefDoc"
              dpiColl.Add(dpi)

              'Item.SBICode
              dpi = New DocPrintingItem
              dpi.Mapping = "Item.RefDoc.SBICode"
              dpi.Value = item.ParentCode
              dpi.DataType = "System.String"
              dpi.Row = n2 + 1
              dpi.Table = "Item.RefDoc"
              dpiColl.Add(dpi)

              'Item.Amount
              dpi = New DocPrintingItem
              dpi.Mapping = "Item.RefDoc.Amount"
              dpi.Value = Configuration.FormatToString(item.Amount, DigitConfig.Price)
              dpi.DataType = "System.Int32"
              dpi.Row = n2 + 1
              dpi.Table = "Item.RefDoc"
              dpiColl.Add(dpi)

              'Item.RemainingAmount
              dpi = New DocPrintingItem
              dpi.Mapping = "Item.RefDoc.RemainingAmount"
              dpi.Value = Configuration.FormatToString(item.RemainingAmount, DigitConfig.Price)
              dpi.DataType = "System.Int32"
              dpi.Row = n2 + 1
              dpi.Table = "Item.RefDoc"
              dpiColl.Add(dpi)

              'Item.AmountHeaderText
              dpi = New DocPrintingItem
              dpi.Mapping = "Item.RefDoc.AmountHeaderText"
              dpi.Value = Configuration.FormatToString(item.RemainingAmount, DigitConfig.Price)
              dpi.DataType = "System.Int32"
              dpi.Row = n2 + 1
              dpi.Table = "Item.RefDoc"
              dpiColl.Add(dpi)

              'Item.Beforetax
              dpi = New DocPrintingItem
              dpi.Mapping = "Item.RefDoc.Beforetax"
              dpi.Value = Configuration.FormatToString(item.BeforeTax, DigitConfig.Price)
              dpi.DataType = "System.String"
              dpi.Row = n2 + 1
              dpi.Table = "Item.RefDoc"
              dpiColl.Add(dpi)

              'Item.TaxBase
              dpi = New DocPrintingItem
              dpi.Mapping = "Item.RefDoc.TaxBase"
              dpi.Value = Configuration.FormatToString(item.TaxBase, DigitConfig.Price)
              dpi.DataType = "System.String"
              dpi.Row = n2 + 1
              dpi.Table = "Item.RefDoc"
              dpiColl.Add(dpi)

              n2 += 1
          End Select
        Catch ex As Exception

        End Try
        '-------------------------------------END DETAIL ITEM---------------------------------------

        'Item.LineNumber
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.LineNumber"
        dpi.Value = n + 1
        dpi.DataType = "System.Int32"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        'Item.RefCode
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.RefCode"
        dpi.Value = item.Code
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        'Item.RefType
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.RefType"
        dpi.Value = CodeDescription.GetDescription("receivesi_entityType", item.EntityId)
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        'Item.Name
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.Name"
        dpi.Value = CodeDescription.GetDescription("receivesi_entityType", item.EntityId) & "," & item.Code
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        'Item.Unit
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.Unit"
        dpi.Value = "รายการ"
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        'Item.Qty
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.Qty"
        dpi.Value = 1
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        'Item.RefVATCode
        Try
          Dim entityFromItem As SimpleBusinessEntityBase
          Dim entityClassName As String = Entity.GetFullClassName(item.EntityId)
          entityFromItem = SimpleBusinessEntityBase.GetEntity(entityClassName, item.Id)
          If TypeOf entityFromItem Is IVatable Then
            Dim vatable As IVatable = CType(entityFromItem, IVatable)
            If Not vatable.Vat Is Nothing Then
              If vatable.Vat.ItemCollection.Count > 0 Then
                'Item.RefVATCode
                dpi = New DocPrintingItem
                dpi.Mapping = "Item.RefVATCode"
                Dim vi As VatItem = vatable.Vat.ItemCollection(0)
                dpi.Value = vi.Code
                dpi.DataType = "System.String"
                dpi.Row = n + 1
                dpi.Table = "Item"
                dpiColl.Add(dpi)
              End If
            End If
          ElseIf TypeOf entityFromItem Is Milestone Then
            Dim mi As Milestone = CType(entityFromItem, Milestone)
            'Item.Name
            dpi = New DocPrintingItem
            dpi.Mapping = "Item.Name"
            dpi.Value = mi.Name
            dpi.DataType = "System.String"
            dpi.Row = n + 1
            dpi.Table = "Item"
            dpiColl.Add(dpi)

            'Item.Code
            dpi = New DocPrintingItem
            dpi.Mapping = "Item.Code"
            dpi.Value = mi.Code
            dpi.DataType = "System.String"
            dpi.Row = n + 1
            dpi.Table = "Item"
            dpiColl.Add(dpi)

            'Item.CodeAndName
            dpi = New DocPrintingItem
            dpi.Mapping = "Item.CodeAndName"
            dpi.Value = mi.Code & " : " & mi.Name
            dpi.DataType = "System.String"
            dpi.Row = n + 1
            dpi.Table = "Item"
            dpiColl.Add(dpi)
          End If
        Catch ex As Exception

        End Try


        'Item.RefDate
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.RefDate"
        dpi.Value = item.Date
        dpi.DataType = "System.DateTime"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        'Item.RefDueDate
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.RefDueDate"
        dpi.Value = item.DueDate
        dpi.DataType = "System.DateTime"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        'Item.SBICode
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.SBICode"
        dpi.Value = item.ParentCode
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        'Item.Amount ค่าข้างล่างถูกแล้ว ไม่ได้สลับนะ
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.Amount"
        If item.EntityId = 79 Then 'งานลด
          dpi.Value = Configuration.FormatToString(-item.RemainingAmount, DigitConfig.Price)
        Else
          dpi.Value = Configuration.FormatToString(item.RemainingAmount, DigitConfig.Price)
        End If
        dpi.DataType = "System.Int32"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        'Item.RemainingAmount ค่าข้างล่างถูกแล้ว ไม่ได้สลับนะ
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.RemainingAmount"
        dpi.Value = Configuration.FormatToString(item.UnreceivedAmount, DigitConfig.Price)
        dpi.DataType = "System.Int32"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        'Item.AmountHeaderText
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.AmountHeaderText"
        dpi.Value = Configuration.FormatToString(item.Amount, DigitConfig.Price)
        dpi.DataType = "System.Int32"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        Dim obj As Object = SimpleBusinessEntityBase.GetEntity(BusinessLogic.Entity.GetFullClassName(item.EntityId), item.Id)
        Dim ratio As Decimal = item.Amount / item.RemainingAmount
        Dim pmaHash As New Hashtable
        If TypeOf obj Is IVatable Then
          Dim vatable As IVatable = CType(obj, IVatable)
          myVat += (ratio * vatable.Vat.Amount)
          myBeforeTax += (ratio * vatable.GetBeforeTax)
        ElseIf TypeOf obj Is Milestone Then
          Dim mi As Milestone = CType(obj, Milestone)
          If Not pmaHash.Contains(mi.PMAId) Then
            pmaHash(mi.PMAId) = New PaymentApplication(mi.PMAId)
          End If
          mi.PaymentApplication = CType(pmaHash(mi.PMAId), PaymentApplication)
          myVat += (ratio * mi.TaxAmount)
          myBeforeTax += (ratio * mi.BeforeTax)
        End If

        'Item.Name (Show MileStone Detail)
        'Dim y As Integer = 0
        If Me.ItemCollection.ShowDetail Then
          Dim m_item As New Milestone(item.StockId)
          For Each miDetailRow As TreeRow In m_item.ItemTable.Childs
            n += 1
            'y += 1
            Dim childText As String = miDetailRow("milestonei_desc").ToString
            'Item.Name
            dpi = New DocPrintingItem
            dpi.Mapping = "Item.Name"
            dpi.Value = childText
            dpi.DataType = "System.String"
            dpi.Row = n + 1
            dpi.Table = "Item"
            dpiColl.Add(dpi)
          Next
          'n = n - y
        End If

        n += 1
      Next

      'GrossItem
      dpi = New DocPrintingItem
      dpi.Mapping = "GrossItem"
      dpi.Value = Configuration.FormatToString(grossitem, DigitConfig.Price)
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'DiscountAmountItem
      dpi = New DocPrintingItem
      dpi.Mapping = "DiscountAmountItem"
      dpi.Value = Configuration.FormatToString(discountamountitem, DigitConfig.Price)
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'SummaryMilestoneAmount
      dpi = New DocPrintingItem
      dpi.Mapping = "SummaryMilestoneAmount"
      dpi.Value = Configuration.FormatToString(sumMilestoneAmount, DigitConfig.Price)
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'SummaryAdvanceAmount
      dpi = New DocPrintingItem
      dpi.Mapping = "SummaryAdvanceAmount"
      dpi.Value = Configuration.FormatToString(sumAdvanceAmount, DigitConfig.Price)
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)


      'SummaryRetention
      dpi = New DocPrintingItem
      dpi.Mapping = "SummaryRetention"
      dpi.Value = Configuration.FormatToString(sumRetention, DigitConfig.Price)
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'SummaryPenalty
      dpi = New DocPrintingItem
      dpi.Mapping = "SummaryPenalty"
      dpi.Value = Configuration.FormatToString(sumPenalty, DigitConfig.Price)
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'BeforeTax
      dpi = New DocPrintingItem
      dpi.Mapping = "BeforeTax"
      dpi.Value = Configuration.FormatToString(sumBeforeTax, DigitConfig.Price)
      'dpi.Value = Configuration.FormatToString(Me.Gross - (myVat + Me.Vat.Amount), DigitConfig.Price)  '+Me.Vat.Amount เพื่อเอา vat จากเอกสารกับ vat ที่รับชำระมารวมกัน
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'ReceiptTaxAmount
      dpi = New DocPrintingItem
      dpi.Mapping = "ReceiptTaxAmount"
      dpi.Value = Configuration.FormatToString(Me.Gross * (CDec(Configuration.GetConfig("CompanyTaxRate")) / 100), DigitConfig.Price)
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'ReceiptTaxAmount
      dpi = New DocPrintingItem
      dpi.Mapping = "Amount"
      dpi.Value = Configuration.FormatToString(Me.Gross, DigitConfig.Price)
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'TaxAmount
      dpi = New DocPrintingItem
      dpi.Mapping = "TaxAmount"
      'dpi.Value = Configuration.FormatToString(Me.Vat.Amount, DigitConfig.Price) ไม่ใช้เพราะต้องการ Vat ทั้งหมด
      'dpi.Value = Configuration.FormatToString(myVat + Me.Vat.Amount, DigitConfig.Price) '+Me.Vat.Amount เพื่อเอา vat จากเอกสารกับ vat ที่รับชำระมารวมกัน           
      dpi.Value = Configuration.FormatToString(sumVat, DigitConfig.Price)  '+Me.Vat.Amount เพื่อเอา vat จากเอกสารกับ vat ที่รับชำระมารวมกัน           
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'TaxBase - มูลค่าสินค้า/บริการ
      dpi = New DocPrintingItem
      dpi.Mapping = "TaxBase"
      'dpi.Value = Configuration.FormatToString(Me.Vat.TaxBase, DigitConfig.Price)
      dpi.Value = Configuration.FormatToString(sumTaxBase, DigitConfig.Price)
      dpi.DataType = "System.string"
      dpiColl.Add(dpi)

      'AfterTaxBase - มูลค่าสินค้า/บริการ + TaxAmount
      dpi = New DocPrintingItem
      dpi.Mapping = "AfterTax"
      dpi.Value = Configuration.FormatToString(sumAfterTax, DigitConfig.Price)
      'dpi.Value = Configuration.FormatToString(sumTaxBase + (sumTaxBase * (CDec(Configuration.GetConfig("CompanyTaxRate")) / 100)), DigitConfig.Price)
      dpi.DataType = "System.string"
      dpiColl.Add(dpi)

      '--- Last Page ----------------------
      '------------------------------------
      'LastPageGrossItem
      dpi = New DocPrintingItem
      dpi.Mapping = "LastPageGrossItem"
      dpi.Value = Configuration.FormatToString(grossitem, DigitConfig.Price)
      dpi.DataType = "System.String"
      dpi.PrintingFrequency = DocPrintingItem.Frequency.LastPage
      dpiColl.Add(dpi)

      'LastPageDiscountAmountItem
      dpi = New DocPrintingItem
      dpi.Mapping = "LastPageDiscountAmountItem"
      dpi.Value = Configuration.FormatToString(discountamountitem, DigitConfig.Price)
      dpi.DataType = "System.String"
      dpi.PrintingFrequency = DocPrintingItem.Frequency.LastPage
      dpiColl.Add(dpi)

      'LastPageSummaryMilestoneAmount
      dpi = New DocPrintingItem
      dpi.Mapping = "LastPageSummaryMilestoneAmount"
      dpi.Value = Configuration.FormatToString(sumMilestoneAmount, DigitConfig.Price)
      dpi.DataType = "System.String"
      dpi.PrintingFrequency = DocPrintingItem.Frequency.LastPage
      dpiColl.Add(dpi)

      'LastPageSummaryAdvanceAmount
      dpi = New DocPrintingItem
      dpi.Mapping = "LastPageSummaryAdvanceAmount"
      dpi.Value = Configuration.FormatToString(sumAdvanceAmount, DigitConfig.Price)
      dpi.DataType = "System.String"
      dpi.PrintingFrequency = DocPrintingItem.Frequency.LastPage
      dpiColl.Add(dpi)

      'SummaryRetention
      dpi = New DocPrintingItem
      dpi.Mapping = "LastPageSummaryRetention"
      dpi.Value = Configuration.FormatToString(sumRetention, DigitConfig.Price)
      dpi.DataType = "System.String"
      dpi.PrintingFrequency = DocPrintingItem.Frequency.LastPage
      dpiColl.Add(dpi)

      'SummaryPenalty
      dpi = New DocPrintingItem
      dpi.Mapping = "LastPageSummaryPenalty"
      dpi.Value = Configuration.FormatToString(sumPenalty, DigitConfig.Price)
      dpi.DataType = "System.String"
      dpi.PrintingFrequency = DocPrintingItem.Frequency.LastPage
      dpiColl.Add(dpi)

      'LastPageBeforeTax
      dpi = New DocPrintingItem
      dpi.Mapping = "LastPageBeforeTax"
      dpi.Value = Configuration.FormatToString(sumBeforeTax, DigitConfig.Price)
      'dpi.Value = Configuration.FormatToString(Me.Gross - (myVat + Me.Vat.Amount), DigitConfig.Price)  '+Me.Vat.Amount เพื่อเอา vat จากเอกสารกับ vat ที่รับชำระมารวมกัน
      dpi.DataType = "System.String"
      dpi.PrintingFrequency = DocPrintingItem.Frequency.LastPage
      dpiColl.Add(dpi)

      'LastPageTaxAmount
      dpi = New DocPrintingItem
      dpi.Mapping = "LastPageTaxAmount"
      dpi.Value = Configuration.FormatToString(sumVat, DigitConfig.Price) 'ไม่ใช้เพราะต้องการ Vat ทั้งหมด
      'dpi.Value = Configuration.FormatToString(myVat + Me.Vat.Amount, DigitConfig.Price) '+Me.Vat.Amount เพื่อเอา vat จากเอกสารกับ vat ที่รับชำระมารวมกัน           
      'dpi.Value = Configuration.FormatToString(sumTaxBase * (CDec(Configuration.GetConfig("CompanyTaxRate")) / 100), DigitConfig.Price)  '+Me.Vat.Amount เพื่อเอา vat จากเอกสารกับ vat ที่รับชำระมารวมกัน           
      dpi.DataType = "System.String"
      dpi.PrintingFrequency = DocPrintingItem.Frequency.LastPage
      dpiColl.Add(dpi)

      'LastPageTaxBase - มูลค่าสินค้า/บริการ
      dpi = New DocPrintingItem
      dpi.Mapping = "LastPageTaxBase"
      'dpi.Value = Configuration.FormatToString(Me.Vat.TaxBase, DigitConfig.Price)
      dpi.Value = Configuration.FormatToString(sumTaxBase, DigitConfig.Price)
      dpi.DataType = "System.string"
      dpi.PrintingFrequency = DocPrintingItem.Frequency.LastPage
      dpiColl.Add(dpi)

      'LastPageAfterTaxBase - มูลค่าสินค้า/บริการ + TaxAmount
      dpi = New DocPrintingItem
      dpi.Mapping = "LastPageAfterTaxBase"
      dpi.Value = Configuration.FormatToString(Me.AfterTax, DigitConfig.Price)
      'dpi.Value = Configuration.FormatToString(sumTaxBase + (sumTaxBase * (CDec(Configuration.GetConfig("CompanyTaxRate")) / 100)), DigitConfig.Price)
      dpi.DataType = "System.string"
      dpi.PrintingFrequency = DocPrintingItem.Frequency.LastPage
      dpiColl.Add(dpi)
      '------------------------------------

      Dim TotalCash As Decimal = 0
      Dim TotalPettyCash As Decimal = 0
      Dim TotalAdvancePay As Decimal = 0
      Dim TotalCheck As Decimal = 0
      Dim TotalTransferIn As Decimal = 0
      Dim CheckCode As String = ""
      For tableType As Integer = 0 To 2
        'tableType 0 = เฉพาะเช็ค
        'tableType 1 = เฉพาะโอน
        'tableType 2 = ทั้งหมด

        Dim tableName As String
        Select Case tableType
          Case 0
            tableName = "ReceiveItem"
          Case 1
            tableName = "ReceiveItemBTI"    'BTI = Bank Transfer In
          Case 2
            tableName = "ReceiveItemAll"
        End Select

        Dim m As Integer = 0
        For i As Integer = 0 To Me.Receive.MaxRowIndex
          Dim itemRow As TreeRow = CType(Me.Receive.ItemTable.Rows(i), TreeRow)
          If Me.Receive.ValidateRow(itemRow) Then
            Dim item As New ReceiveItem
            item.CopyFromDataRow(itemRow)

            Dim entityType As Integer = item.EntityType.Value
            'ReceiveItem.LineNumber
            dpi = New DocPrintingItem
            dpi.Mapping = "ReceiveItem.LineNumber"
            dpi.Value = m + 1
            dpi.DataType = "System.Int32"
            dpi.Row = m + 1
            dpi.Table = tableName
            dpiColl.Add(dpi)

            Dim itIsCheck As Boolean = (TypeOf item.Entity Is IncomingCheck)
            Dim itIsBto As Boolean = (TypeOf item.Entity Is BankTransferIn)
            Dim itIsCash As Boolean = (TypeOf item.Entity Is CashItem)
            Dim itIsPC As Boolean = (TypeOf item.Entity Is PettyCash)
            Dim itIsADVP As Boolean = (TypeOf item.Entity Is AdvancePay)

            If itIsCheck Then
              If CheckCode Is Nothing OrElse CheckCode.Length = 0 Then
                CheckCode = CType(item.Entity, IncomingCheck).CqCode
              End If
            End If

            If (itIsCheck And tableType = 0) _
            Or (itIsBto And tableType = 1) _
            Or (itIsCheck Or itIsBto Or itIsCash) And tableType = 2 _
            Then
              If itIsCheck Then
                'ReceiveItem.DueDate
                dpi = New DocPrintingItem
                dpi.Mapping = tableName & ".DueDate"
                dpi.Value = CType(item.Entity, IncomingCheck).DueDate.ToShortDateString
                dpi.DataType = "System.DateTime"
                dpi.Row = m + 1
                dpi.Table = tableName
                dpiColl.Add(dpi)

                'ReceiveItem.Bank
                dpi = New DocPrintingItem
                dpi.Mapping = tableName & ".Bank"
                dpi.Value = CType(item.Entity, IncomingCheck).Bank
                dpi.DataType = "System.String"
                dpi.Row = m + 1
                dpi.Table = tableName
                dpiColl.Add(dpi)
              End If

              If itIsCash Then
                'ReceiveItem.Bank
                dpi = New DocPrintingItem
                dpi.Mapping = tableName & ".Bank"
                dpi.Value = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ReceiveSelection.Cash}")
                dpi.DataType = "System.String"
                dpi.Row = m + 1
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
              dpi.Row = m + 1
              dpi.Table = tableName
              dpiColl.Add(dpi)

              If TypeOf item.Entity Is IHasAmount Then
                'ReceiveItem.Amount
                dpi = New DocPrintingItem
                dpi.Mapping = tableName & ".Amount"
                dpi.Value = Configuration.FormatToString(CType(item.Entity, IHasAmount).Amount, DigitConfig.Price)
                dpi.DataType = "System.Decimal"
                dpi.Row = m + 1
                dpi.Table = tableName
                dpiColl.Add(dpi)
              End If

              If TypeOf item.Entity Is IHasBankAccount Then
                Dim hasBankAccount As IHasBankAccount = CType(item.Entity, IHasBankAccount)
                Dim bankAcct As BankAccount = hasBankAccount.BankAccount
                Dim bankBranch As BankBranch
                Dim bank As Bank
                If Not bankAcct Is Nothing Then
                  'ReceiveItem.BankAccount
                  dpi = New DocPrintingItem
                  dpi.Mapping = tableName & ".BankAccount"
                  dpi.Value = bankAcct.Name
                  dpi.DataType = "System.String"
                  dpi.Row = m + 1
                  dpi.Table = tableName
                  dpiColl.Add(dpi)

                  'ReceiveItem.BankAccountCode
                  dpi = New DocPrintingItem
                  dpi.Mapping = tableName & ".BankAccountCode"
                  dpi.Value = bankAcct.BankCode
                  dpi.DataType = "System.String"
                  dpi.Row = m + 1
                  dpi.Table = tableName
                  dpiColl.Add(dpi)

                  bankBranch = bankAcct.BankBranch
                  If Not bankBranch Is Nothing Then
                    'ReceiveItem.BankBranch
                    dpi = New DocPrintingItem
                    dpi.Mapping = tableName & ".BankBranch"
                    dpi.Value = bankBranch.Name
                    dpi.DataType = "System.String"
                    dpi.Row = m + 1
                    dpi.Table = tableName
                    dpiColl.Add(dpi)

                    bank = bankBranch.Bank
                    If Not bank Is Nothing Then
                      'ReceiveItem.Bank
                      dpi = New DocPrintingItem
                      dpi.Mapping = tableName & ".Bank"
                      dpi.Value = bank.Name
                      dpi.DataType = "System.String"
                      dpi.Row = m + 1
                      dpi.Table = tableName
                      dpiColl.Add(dpi)
                    End If
                  End If
                End If
              End If
              m += 1
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

      'TotalCash
      dpi = New DocPrintingItem
      dpi.Mapping = "TotalCash"
      dpi.Value = TotalCash
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'TotalPettyCash
      dpi = New DocPrintingItem
      dpi.Mapping = "TotalPettyCash"
      dpi.Value = TotalPettyCash
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'TotalAdvancePay
      dpi = New DocPrintingItem
      dpi.Mapping = "TotalAdvancePay"
      dpi.Value = TotalAdvancePay
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'TotalCheck
      dpi = New DocPrintingItem
      dpi.Mapping = "TotalCheck"
      dpi.Value = TotalCheck
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
      dpi.Value = TotalTransferIn
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      '---------------------------------- Total ----------------------------------
      Dim total As Decimal = TotalCash + TotalPettyCash + TotalAdvancePay + TotalCheck + TotalTransferIn
      'Total
      dpi = New DocPrintingItem
      dpi.Mapping = "Total"
      dpi.Value = total
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'LastPageTotal
      dpi = New DocPrintingItem
      dpi.Mapping = "LastPageTotal"
      dpi.Value = total
      dpi.DataType = "System.String"
      dpi.PrintingFrequency = DocPrintingItem.Frequency.LastPage
      dpiColl.Add(dpi)

      'LastPageTotalText
      dpi = New DocPrintingItem
      dpi.Mapping = "LastPageTotalText"
      dpi.Value = Configuration.FormatToString(total, DigitConfig.CurrencyText)
      dpi.DataType = "System.String"
      dpi.PrintingFrequency = DocPrintingItem.Frequency.LastPage
      dpiColl.Add(dpi)
      '----------------------------------END Total ----------------------------------

      'ส่วนที่พี่ดำทำไว้
      n = 0
      Dim hasCashOrTransfer As Boolean = False
      Dim hasCheck As Boolean = False
      For i As Integer = 0 To Me.Receive.MaxRowIndex
        Dim itemRow As TreeRow = CType(Me.Receive.ItemTable.Rows(i), TreeRow)
        If Me.Receive.ValidateRow(itemRow) Then
          Dim item As New ReceiveItem
          item.CopyFromDataRow(itemRow)
          If TypeOf item.Entity Is IncomingCheck Then
            hasCheck = True
            Dim chk As IncomingCheck = CType(item.Entity, IncomingCheck)
            'ChecqueAmount
            dpi = New DocPrintingItem
            dpi.Mapping = "ChecqueAmount"
            dpi.Value = Configuration.FormatToString(452121, DigitConfig.Price)
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)

            'BankName
            dpi = New DocPrintingItem
            dpi.Mapping = "BankName"
            If Not chk.Bank Is Nothing Then
              dpi.Value = chk.Bank.Name
            Else
              dpi.Value = ""
            End If
            dpi.DataType = "System.String"
            dpi.Row = n + 1
            dpi.Table = "Item2"
            dpiColl.Add(dpi)

            'BankBranchName
            dpi = New DocPrintingItem
            dpi.Mapping = "BankBranchName"
            If Not chk.BankAccount Is Nothing _
            AndAlso Not chk.BankAccount.BankBranch Is Nothing Then
              dpi.Value = chk.BankAccount.BankBranch.Name
            Else
              dpi.Value = ""
            End If
            dpi.DataType = "System.String"
            dpi.Row = n + 1
            dpi.Table = "Item2"
            dpiColl.Add(dpi)

            'ChecqueCode
            dpi = New DocPrintingItem
            dpi.Mapping = "ChecqueCode"
            dpi.Value = chk.CqCode
            dpi.DataType = "System.String"
            dpi.Row = n + 1
            dpi.Table = "Item2"
            dpiColl.Add(dpi)

            'ChecqueDate
            dpi = New DocPrintingItem
            dpi.Mapping = "ChecqueDate"
            dpi.Value = chk.DueDate
            dpi.DataType = "System.DateTime"
            dpi.Row = n + 1
            dpi.Table = "Item2"
            dpiColl.Add(dpi)

            'ChecqueAmount
            dpi = New DocPrintingItem
            dpi.Mapping = "ChecqueAmount"
            dpi.Value = Configuration.FormatToString(chk.Amount, DigitConfig.Price)
            dpi.DataType = "System.Decimal"
            dpi.Row = n + 1
            dpi.Table = "Item2"
            dpiColl.Add(dpi)

            n += 1
          ElseIf item.EntityType.Value = 0 Or item.EntityType.Value = 72 Then
            hasCashOrTransfer = True
          End If
        End If
      Next

      'HasCash
      If hasCashOrTransfer Then
        dpi = New DocPrintingItem
        dpi.Mapping = "HasCash"
        dpi.Value = "P"
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)
      End If
      'HasCheck
      If hasCheck Then
        dpi = New DocPrintingItem
        dpi.Mapping = "HasCheck"
        dpi.Value = "P"
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)
      End If

      'GrossIncludeAddedTax
      dpi = New DocPrintingItem
      dpi.Mapping = "GrossIncludeAddedTax"
      dpi.Value = Configuration.FormatToString(Me.Gross + (myVat + Me.Vat.Amount), DigitConfig.Price)
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'sumAdvanceWitdraw
      dpi = New DocPrintingItem
      dpi.Mapping = "AdvanceWitdraw"
      dpi.Value = Configuration.FormatToString(sumAdvanceWitdraw, DigitConfig.Price)
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      Return dpiColl
    End Function

    Public Function GetVatAmountForPrinting() As Decimal

    End Function
#End Region

#Region "Delete"
    Public Overrides ReadOnly Property CanDelete() As Boolean
      Get
        If Me.Originated Then
          Return Me.Status.Value <= 2 AndAlso Not Me.IsReferenced
        Else
          Return False
        End If
      End Get
    End Property
    Public Overrides Function Delete() As SaveErrorException
      If Not Me.Originated Then
        Return New SaveErrorException("${res:Global.Error.NoIdError}")
      End If
      Dim myMessage As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      Dim format(0) As String
      format(0) = Me.Code
      If Not myMessage.AskQuestionFormatted("${res:Global.ConfirmDeleteReceiveSelection}", format) Then
        Return New SaveErrorException("${res:Global.CencelDelete}")
      End If
      Dim trans As SqlTransaction
      Dim conn As New SqlConnection(Me.ConnectionString)
      conn.Open()
      trans = conn.BeginTransaction()
      Try
        ' จัดการเอกสารอ้างอิงก่อน
        SaveDetailForDeleted(Me.Id, conn, trans)

        ' จัดการลบเอกสาร
        Dim returnVal As System.Data.SqlClient.SqlParameter = New SqlParameter
        returnVal.ParameterName = "RETURN_VALUE"
        returnVal.DbType = DbType.Int32
        returnVal.Direction = ParameterDirection.ReturnValue
        returnVal.SourceVersion = DataRowVersion.Current
        SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "DeleteReceiveSelection", New SqlParameter() {New SqlParameter("@receives_id", Me.Id), returnVal})
        If IsNumeric(returnVal.Value) Then
          Select Case CInt(returnVal.Value)
            Case -1
              trans.Rollback()
              Return New SaveErrorException("${res:Global.ReceiveSelectionIsReferencedCannotBeDeleted}")
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
    Private Function SaveDetailForDeleted(ByVal parentID As Integer, ByVal conn As SqlConnection, ByVal trans As SqlTransaction) As Integer
      Dim da As New SqlDataAdapter("Select * from ReceiveSelectionItem where receivesi_receives=" & Me.Id, conn)

      Dim daOldRef As New SqlDataAdapter("select * from milestone where milestone_id in (select stock_id from ReceiveSelectionItem where receivesi_parentEntityType = 81 and receivesi_receives = " & Me.Id & ")" & _
      " and milestone_id not in (select stock_id from ReceiveSelectionItem where receivesi_parentEntityType = 81 and receivesi_receives <> " & Me.Id & ")", conn)

      Dim daNewRef As SqlDataAdapter
      Dim refIds As String = Me.GetMilestoneRefIdString
      If refIds.Length > 0 Then
        daNewRef = New SqlDataAdapter("Select * from milestone where milestone_id in (" & refIds & ")" & _
        " and milestone_id not in (select stock_id from ReceiveSelectionItem where receivesi_parentEntityType = 81 and receivesi_receives <> " & Me.Id & ")", conn)
      End If

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
      da.FillSchema(ds, SchemaType.Mapped, "ReceiveSelectionItem")
      da.Fill(ds, "ReceiveSelectionItem")

      cmdBuilder = New SqlCommandBuilder(daOldRef)
      daOldRef.SelectCommand.Transaction = trans
      cmdBuilder.GetDeleteCommand.Transaction = trans
      cmdBuilder.GetInsertCommand.Transaction = trans
      cmdBuilder.GetUpdateCommand.Transaction = trans
      cmdBuilder = Nothing
      daOldRef.FillSchema(ds, SchemaType.Mapped, "oldMilestone")
      daOldRef.Fill(ds, "oldMilestone")


      Dim dtNewRef As DataTable
      If Not daNewRef Is Nothing Then
        cmdBuilder = New SqlCommandBuilder(daNewRef)
        daNewRef.SelectCommand.Transaction = trans
        cmdBuilder.GetDeleteCommand.Transaction = trans
        cmdBuilder.GetInsertCommand.Transaction = trans
        cmdBuilder.GetUpdateCommand.Transaction = trans
        cmdBuilder = Nothing
        daNewRef.FillSchema(ds, SchemaType.Mapped, "newMilestone")
        daNewRef.Fill(ds, "newMilestone")
        dtNewRef = ds.Tables("newMilestone")
        For Each row As DataRow In dtNewRef.Rows
          If Not row.IsNull("milestone_status") AndAlso IsNumeric(row("milestone_status")) Then
            If CInt(row("milestone_status")) = 5 Then
              row("milestone_status") = 4
            End If
          End If
        Next
      End If

      Dim dt As DataTable = ds.Tables("ReceiveSelectionItem")

      Dim dtOldRef As DataTable = ds.Tables("oldMilestone")
      For Each row As DataRow In dtOldRef.Rows
        Dim found As Boolean = False
        For Each billi As SaleBillIssueItem In Me.ItemCollection
          If billi.Id = CInt(row("milestone_id")) Then
            'เจอแล้ว --> 
            found = True
            Exit For
          End If
        Next
        If Not found Then
          'ไม่เจอ
          If Not row.IsNull("milestone_status") AndAlso IsNumeric(row("milestone_status")) Then
            If CInt(row("milestone_status")) = 5 Then
              row("milestone_status") = 4
            End If
          End If
        End If
      Next

      Dim i As Integer = 0
      With ds.Tables("ReceiveSelectionItem")   ' ลบทั้งหมดเลย
        For Each row As DataRow In .Rows
          row.Delete()
        Next
      End With

      AddHandler da.RowUpdated, AddressOf tmpDa_MyRowUpdated
      AddHandler daOldRef.RowUpdated, AddressOf tmpDa_MyRowUpdated
      If Not daNewRef Is Nothing Then
        AddHandler daNewRef.RowUpdated, AddressOf tmpDa_MyRowUpdated
      End If
      daOldRef.Update(GetDeletedRows(dtOldRef))
      da.Update(GetDeletedRows(dt))
      If Not daNewRef Is Nothing Then
        daNewRef.Update(GetDeletedRows(dtNewRef))
      End If
      da.Update(dt.Select("", "", DataViewRowState.ModifiedCurrent))
      daOldRef.Update(dtOldRef.Select("", "", DataViewRowState.ModifiedCurrent))
      If Not daNewRef Is Nothing Then
        daNewRef.Update(dtNewRef.Select("", "", DataViewRowState.ModifiedCurrent))
      End If
      da.Update(dt.Select("", "", DataViewRowState.Added))
      daOldRef.Update(dtOldRef.Select("", "", DataViewRowState.Added))
      If Not daNewRef Is Nothing Then
        da.Update(dtNewRef.Select("", "", DataViewRowState.Added))
      End If
      Return 1
    End Function
#End Region

#Region "ICancelable"
    Public ReadOnly Property CanCancel() As Boolean Implements ICancelable.CanCancel
      Get
        Return (Me.Status.Value = 1 OrElse Me.Status.Value = 2) AndAlso Me.IsCancelable
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
        Return Me.Customer
      End Get
      Set(ByVal Value As IBillablePerson)
        If TypeOf Value Is Customer Then
          Me.Customer = CType(Value, Customer)
        End If
      End Set
    End Property
#End Region


  End Class

End Namespace
