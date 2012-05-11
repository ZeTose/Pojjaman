Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration
Imports Longkong.Core.Services

Namespace Longkong.Pojjaman.BusinessLogic
  Public Class OpeningBalanceStatus
    Inherits CodeDescription

#Region "Constructors"
    Public Sub New(ByVal value As Integer)
      MyBase.New(value)
    End Sub
#End Region

#Region "Properties"
    Public Overrides ReadOnly Property CodeName() As String
      Get
        Return "openingbalance_status"
      End Get
    End Property
#End Region

  End Class

  Public Class APOpeningBalance
    Inherits SimpleBusinessEntityBase
    Implements IGLAble, IBillAcceptable, IPrintableEntity, IHasIBillablePerson, ICancelable, IVatable, IHasAmount, IHasToCostCenter, INewPrintableEntity

#Region "Members"
    Private stock_supplier As Supplier 'entity
    Private stock_docDate As Date
    Private stock_note As String
    Private stock_creditPeriod As Long
    Private stock_status As OpeningBalanceStatus
    Private stock_aftertax As Decimal

    Private m_CostCenter As CostCenter

    Private m_taxRate As Decimal
    Private m_taxType As TaxType

    Private m_vat As Vat
    Private m_payment As Payment
    Private m_je As JournalEntry

    Private m_realTaxBase As Decimal
    Private m_realTaxAmount As Decimal

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
    Public Sub New(ByVal dr As System.Data.DataRow, ByVal aliasPrefix As String)
      MyBase.New(dr, aliasPrefix)
      Me.Construct(dr, aliasPrefix)
    End Sub
    Protected Overloads Overrides Sub Construct()
      MyBase.Construct()
      Me.stock_supplier = New Supplier
      Me.DocDate = Date.Now.Date
      m_CostCenter = New CostCenter
      Me.stock_status = New OpeningBalanceStatus(-1)
      m_taxRate = CDec(Configuration.GetConfig("CompanyTaxRate"))
      m_taxType = New TaxType(2)

      With Me
        '----------------------------Tab Entities-----------------------------------------
        .m_vat = New Vat(Me)
        .m_vat.Direction.Value = 1

        .m_je = New JournalEntry(Me)
        .m_je.DocDate = Me.DocDate

        .m_payment = New Payment(Me)
        .m_payment.DocDate = Me.DocDate
        '----------------------------End Tab Entities-----------------------------------------

        .AutoCodeFormat = New AutoCodeFormat(Me)
      End With
    End Sub
    Protected Overloads Overrides Sub Construct(ByVal dr As System.Data.DataRow, ByVal aliasPrefix As String)
      MyBase.Construct(dr, aliasPrefix)
      With Me

        If dr.Table.Columns.Contains("supplier_id") Then
          If Not dr.IsNull("supplier_id") Then
            .stock_supplier = New Supplier(dr, "")
          End If
        Else
          If dr.Table.Columns.Contains("stock_entity") AndAlso Not dr.IsNull(aliasPrefix & "stock_entity") Then
            .stock_supplier = New Supplier(CInt(dr(aliasPrefix & "stock_entity")))
          End If
        End If

        If dr.Table.Columns.Contains("stock_aftertax") AndAlso Not dr.IsNull(aliasPrefix & "stock_aftertax") Then
          .stock_aftertax = CDec(dr(aliasPrefix & "stock_aftertax"))
        End If

        If dr.Table.Columns.Contains("stock_creditPeriod") AndAlso Not dr.IsNull(aliasPrefix & "stock_creditPeriod") Then
          .stock_creditPeriod = CInt(dr(aliasPrefix & "stock_creditPeriod"))
        End If

        If dr.Table.Columns.Contains("stock_docDate") AndAlso Not dr.IsNull(aliasPrefix & "stock_docDate") Then
          .stock_docDate = CDate(dr(aliasPrefix & "stock_docDate"))
        End If

        If dr.Table.Columns.Contains("stock_note") AndAlso Not dr.IsNull(aliasPrefix & "stock_note") Then
          .stock_note = CStr(dr(aliasPrefix & "stock_note"))
        End If

        If dr.Table.Columns.Contains("stock_status") AndAlso Not dr.IsNull(aliasPrefix & "stock_status") Then
          .stock_status = New OpeningBalanceStatus(CInt(dr(aliasPrefix & "stock_status")))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "stock_taxtype") AndAlso Not dr.IsNull(aliasPrefix & "stock_taxtype") Then
          .m_taxType = New TaxType(CInt(dr(aliasPrefix & "stock_taxtype")))
        End If

        If Not dr.IsNull(aliasPrefix & "stock_taxrate") Then
          .m_taxRate = CDec(dr(aliasPrefix & "stock_taxrate"))
        End If

        '--------------------REAL-------------------------
        ' Tax Base
        If dr.Table.Columns.Contains(aliasPrefix & "stock_taxbase") _
        AndAlso Not dr.IsNull(aliasPrefix & "stock_taxbase") Then
          .m_realTaxBase = CDec(dr(aliasPrefix & "stock_taxbase"))
        End If

        ' Tax Amount
        If dr.Table.Columns.Contains(aliasPrefix & "stock_taxamt") _
        AndAlso Not dr.IsNull(aliasPrefix & "stock_taxamt") Then
          .m_realTaxAmount = CDec(dr(aliasPrefix & "stock_taxamt"))
        End If
        '--------------------END REAL-------------------------

        'Cost Center
        If dr.Table.Columns.Contains(aliasPrefix & "cc_id") Then
          If Not dr.IsNull(aliasPrefix & "cc_id") Then
            .m_CostCenter = New CostCenter(dr, "")
          End If
        Else
          If dr.Table.Columns.Contains("stock_cc") AndAlso Not dr.IsNull(aliasPrefix & "stock_cc") Then
            .m_CostCenter = New CostCenter(CInt(dr(aliasPrefix & "stock_cc")))
          End If
        End If

        .m_vat = New Vat(Me)
        m_vat.Direction.Value = 1

        m_je = New JournalEntry(Me)
        m_payment = New Payment(Me)
        .AutoCodeFormat = New AutoCodeFormat(Me)
      End With
    End Sub
#End Region

#Region "Properties"    '--------------------REAL-------------------------
    Public Property RealTaxAmount() As Decimal
      Get
        Return m_realTaxAmount
      End Get
      Set(ByVal Value As Decimal)
        m_realTaxAmount = Value
      End Set
    End Property
    Public Property RealTaxBase() As Decimal      Get        Return m_realTaxBase      End Get      Set(ByVal Value As Decimal)        m_realTaxBase = Value      End Set    End Property
    '--------------------END REAL-------------------------    Public Property Supplier() As Supplier      Get        Return stock_supplier      End Get      Set(ByVal Value As Supplier)        stock_supplier = Value        OnPropertyChanged(Me, New PropertyChangedEventArgs)      End Set    End Property    Public Property Amount() As Decimal
      Get
        Return Configuration.Format(Me.stock_aftertax, DigitConfig.Price)
      End Get
      Set(ByVal Value As Decimal)
        stock_aftertax = Value
      End Set
    End Property    Public Property CreditPeriod() As Long
      Get
        Return Me.stock_creditPeriod
      End Get
      Set(ByVal Value As Long)
        Me.stock_creditPeriod = Value
        OnPropertyChanged(Me, New PropertyChangedEventArgs)
      End Set
    End Property
    Public Property DocDate() As Date Implements IGLAble.Date, IPayable.Date
      Get
        Return Me.stock_docDate
      End Get
      Set(ByVal Value As Date)
        Me.stock_docDate = Value
        If Me.m_je IsNot Nothing Then
          Me.m_je.DocDate = Value
        End If
        OnPropertyChanged(Me, New PropertyChangedEventArgs)
      End Set
    End Property
    Public Property Entity() As ISimpleEntity
      Get
        Return Me.stock_supplier
      End Get
      Set(ByVal Value As ISimpleEntity)
        Me.stock_supplier = CType(Value, Supplier)
        OnPropertyChanged(Me, New PropertyChangedEventArgs)
      End Set
    End Property
    Public Property CostCenter() As CostCenter Implements IHasToCostCenter.ToCC      Get        Return m_CostCenter      End Get      Set(ByVal Value As CostCenter)        m_CostCenter = Value      End Set    End Property
    Public Property Note() As String Implements IPayable.Note, IGLAble.Note
      Get
        Return Me.stock_note
      End Get
      Set(ByVal Value As String)
        Me.stock_note = Value
        OnPropertyChanged(Me, New PropertyChangedEventArgs)
      End Set
    End Property
    Public Overrides Property Status() As CodeDescription
      Get        Return stock_status      End Get      Set(ByVal Value As CodeDescription)        stock_status = CType(Value, OpeningBalanceStatus)        OnPropertyChanged(Me, New PropertyChangedEventArgs)      End Set
    End Property
    Public Property TaxRate() As Decimal      Get        Return m_taxRate      End Get      Set(ByVal Value As Decimal)        m_taxRate = Value        OnPropertyChanged(Me, New PropertyChangedEventArgs)      End Set    End Property    Public Property TaxBase() As Decimal Implements IVatable.TaxBase
      Get
        Select Case Me.TaxType.Value
          Case 0 '"ไม่มี"
            Return 0
          Case 1, 2
            Return Configuration.Format(Vat.GetExcludedVatAmount(Me.AfterTax, Me.TaxRate), DigitConfig.Price)
        End Select
      End Get
      Set(ByVal Value As Decimal)

      End Set
    End Property    Public Property TaxType() As TaxType      Get        Return m_taxType      End Get      Set(ByVal Value As TaxType)        m_taxType = Value        OnPropertyChanged(Me, New PropertyChangedEventArgs)      End Set    End Property    Public ReadOnly Property TaxAmount() As Decimal      Get        Select Case Me.TaxType.Value
          Case 0 '"ไม่มี"
            Return 0
          Case 2 'รวม VAT
            Return Me.AfterTax - Me.RealTaxBase
          Case Else '1 แยก
            Return Configuration.Format((Me.TaxRate * Me.RealTaxBase) / 100, DigitConfig.Price)        End Select      End Get    End Property    Public ReadOnly Property BeforeTax() As Decimal      Get        Select Case Me.TaxType.Value
          Case 0 '"ไม่มี"
            Return Me.AfterTax
          Case 1 '"แยก"
            Return Me.AfterTax
          Case 2 '"รวม"
            Return Configuration.Format(Vat.GetExcludedVatAmount(Me.AfterTax, Me.TaxRate), DigitConfig.Price)
        End Select      End Get    End Property    Public Property AfterTax() As Decimal Implements IHasAmount.Amount      Get        Return Me.stock_aftertax      End Get      Set(ByVal Value As Decimal)        stock_aftertax = Value
      End Set    End Property    Public Overrides ReadOnly Property TabPageText() As String
      Get
        Dim tpt As String = Me.StringParserService.Parse(Me.DetailPanelTitle) & " (" & Me.Code & ")"
        Dim blankSuffix As String = "()"
        If tpt.EndsWith(blankSuffix) Then
          tpt = tpt.Remove(tpt.Length - blankSuffix.Length, blankSuffix.Length)
        End If
        Return tpt
      End Get
    End Property    Public Overrides ReadOnly Property ClassName() As String
      Get
        Return "APOpeningBalance"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.APOpeningBalance.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.APOpeningBalance"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.APOpeningBalance"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.APOpeningBalance.ListLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property Prefix() As String
      Get
        Return "stock"
      End Get
    End Property
    Public Overrides ReadOnly Property TableName() As String
      Get
        Return "stock"
      End Get
    End Property
    Public Overrides ReadOnly Property GetSprocName() As String
      Get
        Return "GetAPOpeningBalance"
      End Get
    End Property
#End Region

#Region "Methods"
    Private Sub ResetID(ByVal oldid As Integer, ByVal oldpayment As Integer, ByVal oldje As Integer, ByVal oldVatId As Integer)
      Me.Id = oldid
      Me.m_je.Id = oldje
      Me.m_payment.Id = oldpayment
      Me.m_vat.Id = oldVatId
      Me.m_vat.SetRefDocToItem(Me.Id, Me.EntityId)
    End Sub
    Private Sub ResetCode(ByVal oldCode As String, ByVal oldautogen As Boolean, ByVal oldJecode As String, ByVal oldjeautogen As Boolean)
      Me.Code = oldCode
      Me.AutoGen = oldautogen
      Me.m_payment.Code = oldJecode
      Me.m_payment.AutoGen = oldjeautogen
      Me.m_je.Code = oldJecode
      Me.m_je.AutoGen = oldjeautogen
    End Sub
    Public Function BeforeSave(ByVal currentUserId As Integer) As SaveErrorException

      Dim ValidateError As SaveErrorException

      ValidateError = Me.Vat.BeforeSave(currentUserId)
      If Not IsNumeric(ValidateError.Message) Then
        Return ValidateError
      End If

      ValidateError = Me.Payment.BeforeSave(currentUserId)
      If Not IsNumeric(ValidateError.Message) Then
        Return ValidateError
      End If

      ValidateError = Me.JournalEntry.BeforeSave(currentUserId)
      If Not IsNumeric(ValidateError.Message) Then
        Return ValidateError
      End If

      Return New SaveErrorException("0")

    End Function
    Public Overloads Overrides Function Save(ByVal currentUserId As Integer) As SaveErrorException

      If Me.Originated Then
        If Not Me.Supplier Is Nothing Then
          If Me.Supplier.Canceled Then
            Return New SaveErrorException(Me.StringParserService.Parse("${res:Global.Error.CanceledSupplier}"), New String() {Me.Supplier.Code})
          End If
        End If
      End If

      Dim returnVal As System.Data.SqlClient.SqlParameter = New SqlParameter
      returnVal.ParameterName = "RETURN_VALUE"
      returnVal.DbType = DbType.Int32
      returnVal.Direction = ParameterDirection.ReturnValue
      returnVal.SourceVersion = DataRowVersion.Current
      Dim paramArrayList As New ArrayList
      paramArrayList.Add(returnVal)
      If Me.Originated Then
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_id", Me.Id))
      End If

      Dim theTime As Date = Now
      Dim theUser As New User(currentUserId)
      'If Me.AutoGen And Me.Code.Length = 0 Then
      'Me.Code = Me.GetNextCode
      'End If
      'Me.AutoGen = False

      If Me.m_je.Status.Value = 4 Then
        Me.Status.Value = 4
        Me.m_payment.Status.Value = 4
        Me.m_vat.Status.Value = 4
      End If
      If Me.Status.Value = 0 Then
        Me.m_payment.Status.Value = 0
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

      oldcode = Me.Code
      oldautogen = Me.AutoGen
      oldjecode = Me.m_je.Code
      oldjeautogen = Me.m_je.AutoGen

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
      'paymentcode is null
      Me.m_je.DocDate = Me.DocDate
      Me.m_payment.DocDate = Me.m_je.DocDate
      Me.AutoGen = False
      Me.m_je.AutoGen = False


      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_code", Me.Code))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_type", Me.EntityId))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_docDate", Me.ValidDateOrDBNull(Me.DocDate)))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_aftertax", Me.Amount))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_creditPeriod", Me.CreditPeriod))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_taxType", Me.TaxType.Value))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_taxbase", Me.RealTaxBase))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_beforeTax", Me.BeforeTax))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_taxRate", Me.TaxRate))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_taxAmt", Me.RealTaxAmount))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_cc", ValidIdOrDBNull(Me.CostCenter)))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_entity", Me.ValidIdOrDBNull(Me.Supplier)))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_entityType", Me.Supplier.EntityId))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_note", Me.Note))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_status", Me.Status.Value))

      SetOriginEditCancelStatus(paramArrayList, currentUserId, theTime)

      '---==Validated การทำ before save ของหน้าย่อยอื่นๆ ====
      Dim ValidateError2 As SaveErrorException = Me.BeforeSave(currentUserId)
      If Not IsNumeric(ValidateError2.Message) Then
        ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
        Return ValidateError2
      End If
      '---==Validated การทำ before save ของหน้าย่อยอื่นๆ ====

      ' สร้าง SqlParameter จาก ArrayList ...
      Dim sqlparams() As SqlParameter
      sqlparams = CType(paramArrayList.ToArray(GetType(SqlParameter)), SqlParameter())
      Dim trans As SqlTransaction
      Dim conn As New SqlConnection(Me.ConnectionString)
      conn.Open()
      trans = conn.BeginTransaction()

      Dim oldid As Integer = Me.Id
      Dim oldje As Integer = Me.m_je.Id
      Dim oldPayment As Integer = Me.m_payment.Id
      Dim oldVatId As Integer = Me.m_vat.Id

      Try

        Try
          Me.ExecuteSaveSproc(conn, trans, returnVal, sqlparams, theTime, theUser)
          If IsNumeric(returnVal.Value) Then
            Select Case CInt(returnVal.Value)
              Case -1
                trans.Rollback()
                Me.ResetID(oldid, oldPayment, oldje, oldVatId)
                ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
                Return New SaveErrorException(returnVal.Value.ToString)
              Case -2
                trans.Rollback()
                Me.ResetID(oldid, oldPayment, oldje, oldVatId)
                ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
                Return New SaveErrorException(returnVal.Value.ToString)
              Case Else
            End Select
          ElseIf IsDBNull(returnVal.Value) OrElse Not IsNumeric(returnVal.Value) Then
            trans.Rollback()
            Me.ResetID(oldid, oldPayment, oldje, oldVatId)
            ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
            Return New SaveErrorException(returnVal.Value.ToString)
          End If

          'Me.m_payment.CCId = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ).Id
          Me.m_payment.CCId = Me.m_CostCenter.Id
          Me.m_vat.SetCCId(Me.m_payment.CCId)
          Me.m_vat.SetRefDocToItem(Me.Id, Me.EntityId)

          Dim savePaymentError As SaveErrorException = Me.m_payment.Save(currentUserId, conn, trans)
          If Not IsNumeric(savePaymentError.Message) Then
            trans.Rollback()
            Me.Payment.ResetDetail()
            Me.ResetID(oldid, oldPayment, oldje, oldVatId)
            ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
            Return savePaymentError
          Else
            Select Case CInt(savePaymentError.Message)
              Case -1, -2
                trans.Rollback()
                Me.Payment.ResetDetail()
                Me.ResetID(oldid, oldPayment, oldje, oldVatId)
                ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
                Return savePaymentError
              Case Else
            End Select
          End If

          Dim saveVatError As SaveErrorException = Me.m_vat.Save(currentUserId, conn, trans)
          If Not IsNumeric(saveVatError.Message) Then
            trans.Rollback()
            Me.Payment.ResetDetail()
            Me.ResetID(oldid, oldPayment, oldje, oldVatId)
            ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
            Return saveVatError
          Else
            Select Case CInt(saveVatError.Message)
              Case -1, -2, -5
                trans.Rollback()
                Me.Payment.ResetDetail()
                Me.ResetID(oldid, oldPayment, oldje, oldVatId)
                ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
                Return saveVatError
              Case Else
            End Select
          End If

          If Me.m_je.Status.Value = -1 Then
            m_je.Status.Value = 3
          End If
          Dim saveJeError As SaveErrorException = Me.m_je.Save(currentUserId, conn, trans)
          If Not IsNumeric(saveJeError.Message) Then
            trans.Rollback()
            Me.Payment.ResetDetail()
            Me.ResetID(oldid, oldPayment, oldje, oldVatId)
            ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
            Return saveJeError
          Else
            Select Case CInt(saveJeError.Message)
              Case -1
                trans.Rollback()
                Me.Payment.ResetDetail()
                Me.ResetID(oldid, oldPayment, oldje, oldVatId)
                ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
                Return saveJeError
              Case -2
                'Post ไปแล้ว
                Return saveJeError
              Case Else
            End Select
          End If

          Me.DeleteRef(conn, trans)
          If Me.Status.Value = 0 Then
            Me.CancelRef(conn, trans)
          End If

          '==============================AUTOGEN==========================================
          Dim saveAutoCodeError As SaveErrorException = SaveAutoCode(conn, trans)
          If Not IsNumeric(saveAutoCodeError.Message) Then
            trans.Rollback()
            Me.Payment.ResetDetail()
            ResetID(oldid, oldPayment, oldje, oldVatId)
            ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
            Return saveAutoCodeError
          Else
            Select Case CInt(saveAutoCodeError.Message)
              Case -1, -2, -5
                trans.Rollback()
                Me.Payment.ResetDetail()
                ResetID(oldid, oldPayment, oldje, oldVatId)
                ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
                Return saveAutoCodeError
              Case Else
            End Select
          End If
          '==============================AUTOGEN==========================================

          trans.Commit()
          'Return New SaveErrorException(returnVal.Value.ToString)
        Catch ex As SqlException
          trans.Rollback()
          Me.Payment.ResetDetail()
          Me.ResetID(oldid, oldPayment, oldje, oldVatId)
          ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
          Return New SaveErrorException(ex.ToString)
        Catch ex As Exception
          trans.Rollback()
          Me.Payment.ResetDetail()
          Me.ResetID(oldid, oldPayment, oldje, oldVatId)
          ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
          Return New SaveErrorException(ex.ToString)
          'Finally
          '  conn.Close()
        End Try

        '--Sub Save Block-- ============================================================
        Try
          Dim subsaveerror As SaveErrorException = SubSave(conn)
          If Not IsNumeric(subsaveerror.Message) Then
            Return New SaveErrorException(" Save Incomplete Please Save Again")
          End If
          Return New SaveErrorException(returnVal.Value.ToString)
          'Complete Save
        Catch ex As Exception
          Return New SaveErrorException(ex.ToString)
        End Try
        '--Sub Save Block-- ============================================================

      Catch ex As Exception
        Return New SaveErrorException(ex.ToString)
      Finally
        conn.Close()
      End Try
    End Function
    Private Function SubSave(ByVal conn As SqlConnection) As SaveErrorException

      '======เริ่ม trans 2 ลองผิดให้ save ใหม่ ========
      Dim trans As SqlTransaction = conn.BeginTransaction

      Try
        'If Me.Status.Value = 0 Then
        '  UpdateAdvancePayStatus(False, conn, trans)
        'Else
        '  UpdateAdvancePayStatus(True, conn, trans)
        'End If
      Catch ex As Exception
        trans.Rollback()
        Return New SaveErrorException(ex.ToString)
      End Try

      trans.Commit()
      Return New SaveErrorException("0")
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
      , New SqlParameter("@entity_name", Me.ClassName), New SqlParameter("@default", 1))
      Dim glf As New GLFormat(ds.Tables(0).Rows(0), "")
      Return glf
    End Function
    Public Property JournalEntry() As JournalEntry Implements IGLAble.JournalEntry
      Get
        Return m_je
      End Get
      Set(ByVal Value As JournalEntry)
        m_je = Value
      End Set
    End Property
    Public Function GetJournalEntries() As JournalEntryItemCollection Implements IGLAble.GetJournalEntries
      Dim jiColl As New JournalEntryItemCollection
      Dim ji As JournalEntryItem
      'Dim myCC As CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
      Dim myCC As CostCenter = Me.CostCenter
      If Me.BeforeTax > 0 Then
        'กำไรสะสม
        ji = New JournalEntryItem
        ji.Mapping = "B3.1"
        ji.Amount = Me.BeforeTax
        ji.CostCenter = myCC
        jiColl.Add(ji)
      End If

      If Me.AfterTax > 0 Then
        'เจ้าหนี้การค้า
        ji = New JournalEntryItem
        ji.Mapping = "B3.2"
        If Not Me.Supplier.Account Is Nothing AndAlso Me.Supplier.Account.Originated Then
          ji.Account = Me.Supplier.Account
        End If
        ji.CostCenter = myCC
        ji.Amount = Me.AfterTax
        jiColl.Add(ji)
      End If

      'ภาษีซื้อ
      If Me.Vat.Amount > 0 Then
        ji = New JournalEntryItem
        ji.Mapping = "B3.3"
        ji.Amount = Configuration.Format(Me.Vat.Amount, DigitConfig.Price)
        ji.CostCenter = myCC
        jiColl.Add(ji)
      End If

      'ภาษีซื้อไม่ถึงกำหนด
      If Me.RealTaxAmount - Me.Vat.Amount > 0 Then
        ji = New JournalEntryItem
        ji.Mapping = "B3.3.1"
        ji.Amount = Configuration.Format(Me.RealTaxAmount - Me.Vat.Amount, DigitConfig.Price)
        ji.CostCenter = myCC
        jiColl.Add(ji)
      End If

      Return jiColl
    End Function
#End Region

#Region "IPrintableEntity"
    Public Function GetDefaultFormPath() As String Implements IPrintableEntity.GetDefaultFormPath
      Return "APOpeningBalance"
    End Function
    Public Function GetDefaultForm() As String Implements IPrintableEntity.GetDefaultForm
      Return "APOpeningBalance"
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

      'SupplierInfo
      If Me.Supplier.Valid Then
        dpi = New DocPrintingItem
        dpi.Mapping = "SupplierInfo"
        dpi.Value = Me.Supplier.Code & ":" & Me.Supplier.Name
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        dpi = New DocPrintingItem
        dpi.Mapping = "SupplierCode"
        dpi.Value = Me.Supplier.Code
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        dpi = New DocPrintingItem
        dpi.Mapping = "SupplierName"
        dpi.Value = Me.Supplier.Name
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)
      End If

      If Not Me.CostCenter Is Nothing AndAlso Me.CostCenter.Originated Then
        'CostCenterInfo
        dpi = New DocPrintingItem
        dpi.Mapping = "CostCenterInfo"
        dpi.Value = Me.CostCenter.Code & ":" & Me.CostCenter.Name
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'CostCenterCode
        dpi = New DocPrintingItem
        dpi.Mapping = "CostCenterCode"
        dpi.Value = Me.CostCenter.Code
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'CostCenterName
        dpi = New DocPrintingItem
        dpi.Mapping = "CostCenterName"
        dpi.Value = Me.CostCenter.Name
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'CostCenterPhone
        dpi = New DocPrintingItem
        dpi.Mapping = "CostCenterPhone"
        dpi.Value = Me.CostCenter.Phone
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'CostCenterFax
        dpi = New DocPrintingItem
        dpi.Mapping = "CostCenterFax"
        dpi.Value = Me.CostCenter.Fax
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)
      End If

      'Credit
      dpi = New DocPrintingItem
      dpi.Mapping = "Credit"
      dpi.Value = Me.CreditPeriod
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'Amount
      dpi = New DocPrintingItem
      dpi.Mapping = "Amount"
      dpi.Value = Me.Amount
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'Note
      dpi = New DocPrintingItem
      dpi.Mapping = "Note"
      dpi.Value = Me.Note
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      Return dpiColl
    End Function
#End Region

#Region "IBillAcceptable"
    Public Function AmountToPay() As Decimal Implements IPayable.AmountToPay
      Return Me.Amount
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
        Try
          CreditPeriod = DateDiff(DateInterval.Day, DocDate, Value)
        Catch ex As Exception

        End Try
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
    Public Function RemainingAmount() As Decimal Implements IPayable.RemainingAmount
      'Undone
      Return Me.AmountToPay
    End Function
    Public ReadOnly Property Recipient() As IBillablePerson Implements IPayable.Recipient
      Get
        Return Me.Supplier
      End Get
    End Property
    Public Function GetRemainingAmountWithBillAcceptance(ByVal billa_id As Integer) As Decimal Implements IBillAcceptable.GetRemainingAmountWithBillAcceptance
      Try
        Dim ds As DataSet = SqlHelper.ExecuteDataset( _
                Me.ConnectionString _
                , CommandType.StoredProcedure _
                , "GetUnpaidStockAmount" _
                , New SqlParameter("@stock_id", Me.Id) _
                , New SqlParameter("@billai_billa", billa_id) _
                )
        If ds.Tables(0).Rows.Count > 0 Then
          Return Configuration.Format(CDec(ds.Tables(0).Rows(0)(0)), DigitConfig.Price)
        End If
      Catch ex As Exception
        MessageBox.Show(ex.Message)
      End Try
    End Function
    Public Function GetRemainingAmountPayselection(ByVal pays_id As Integer) As Decimal Implements IBillAcceptable.GetRemainingAmountPayselection
      Try
        Dim ds As DataSet = SqlHelper.ExecuteDataset( _
                Me.ConnectionString _
                , CommandType.StoredProcedure _
                , "GetUnpaidStockAmount" _
                , New SqlParameter("@stock_id", Me.Id) _
                , New SqlParameter("@paysi_pays", pays_id) _
                )
        If ds.Tables(0).Rows.Count > 0 Then
          Return Configuration.Format(CDec(ds.Tables(0).Rows(0)(0)), DigitConfig.Price)
        End If
      Catch ex As Exception
        MessageBox.Show(ex.Message)
      End Try
    End Function
    Public Function GetRemainingAmountPayselection(ByVal pays_id As Integer, ByVal billa_id As Integer) As Decimal Implements IBillAcceptable.GetRemainingAmountPayselection
      Try
        Dim ds As DataSet = SqlHelper.ExecuteDataset( _
                Me.ConnectionString _
                , CommandType.StoredProcedure _
                , "GetUnpaidStockAmount" _
                , New SqlParameter("@stock_id", Me.Id) _
                , New SqlParameter("@paysi_pays", pays_id) _
                , New SqlParameter("@billai_billa", billa_id) _
                )
        If ds.Tables(0).Rows.Count > 0 Then
          Return Configuration.Format(CDec(ds.Tables(0).Rows(0)(0)), DigitConfig.Price)
        End If
      Catch ex As Exception
        MessageBox.Show(ex.Message)
      End Try
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
      If Not myMessage.AskQuestionFormatted("${res:Global.ConfirmDeleteAPOpeningBalance}", format) Then
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
        SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "DeleteAPOpeningBalance", New SqlParameter() {New SqlParameter("@stock_id", Me.Id), returnVal})
        If IsNumeric(returnVal.Value) Then
          Select Case CInt(returnVal.Value)
            Case -1
              trans.Rollback()
              Return New SaveErrorException("${res:Global.APOpeningBalanceIsReferencedCannotBeDeleted}")
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
      Dim cancancelError As SaveErrorException = Me.Save(currentUserId)
      Return cancancelError
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
    Public Property [Date]() As Date Implements IVatable.Date
      Get
        Return Me.DocDate
      End Get
      Set(ByVal Value As Date)
        Me.DocDate = Value
      End Set
    End Property
    Public Property Vat() As Vat Implements IVatable.Vat      Get        Return m_vat      End Get      Set(ByVal Value As Vat)        m_vat = Value      End Set    End Property
    Public Function GetMaximumTaxBase(Optional ByVal conn As SqlConnection = Nothing, Optional ByVal trans As SqlTransaction = Nothing) As Decimal Implements IVatable.GetMaximumTaxBase
      'Todo: ต้อง refresh หรือเปล่า?
      Return Me.RealTaxBase
    End Function
    Public Property Person() As IBillablePerson Implements IVatable.Person
      Get
        Return Me.Supplier
      End Get
      Set(ByVal Value As IBillablePerson)
        Me.Supplier = CType(Value, Supplier)
      End Set
    End Property
    Public Function GetAfterTax() As Decimal Implements IVatable.GetAfterTax
      Return Me.AfterTax
    End Function
    Public Function GetBeforeTax() As Decimal Implements IVatable.GetBeforeTax
      Return Me.BeforeTax
    End Function
    Public ReadOnly Property NoVat() As Boolean Implements IVatable.NoVat
      Get
        Return Me.TaxType.Value = 0
      End Get
    End Property
#End Region

#Region "INewPrintableEntity"
    Public Function GetDocPrintingColumnsEntries() As DocPrintingItemCollection Implements INewPrintableEntity.GetDocPrintingColumnsEntries
      Dim dpiColl As New DocPrintingItemCollection
      Dim dpi As DocPrintingItem

      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Code", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("DocDate", "System.DateTime"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("SupplierInfo", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("SupplierCode", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("SupplierName", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("CostCenterInfo", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("CostCenterCode", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("CostCenterName", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("CostCenterPhone", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("CostCenterFax", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Credit", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Amount", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Note", "System.String"))

      Return dpiColl
    End Function

    Public Function GetDocPrintingDataEntries() As DocPrintingItemCollection Implements INewPrintableEntity.GetDocPrintingDataEntries
      Return Me.GetDocPrintingEntries
    End Function
#End Region

  End Class
End Namespace
