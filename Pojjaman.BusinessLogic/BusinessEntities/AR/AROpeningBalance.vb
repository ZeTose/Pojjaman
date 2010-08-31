Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Core.Services
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration

Namespace Longkong.Pojjaman.BusinessLogic
  Public Class AROpeningBalance
    Inherits SimpleBusinessEntityBase
    Implements IGLAble, ISaleBillIssuable, IPrintableEntity, IHasIBillablePerson, ICancelable, IHasToCostCenter, IVatable

#Region "Members"
    Private m_customer As Customer 'entity
    Private m_docDate As Date
    Private m_note As String
    Private m_creditPeriod As Integer
    Private m_CostCenter As CostCenter
    Private m_status As OpeningBalanceStatus
    Private m_amount As Decimal
    Private m_receive As Receive
    Private m_je As JournalEntry
    Private m_taxRate As Decimal
    Private m_taxType As TaxType
    Private m_vat As Vat
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
    Protected Overloads Overrides Sub Construct()
      MyBase.Construct()
      Me.m_customer = New Customer
      Me.m_status = New OpeningBalanceStatus(-1)
      Me.m_docDate = Date.Now.Date
      m_CostCenter = New CostCenter

      With Me
        '----------------------------Tab Entities-----------------------------------------
        .m_je = New JournalEntry(Me)
        .m_je.DocDate = Me.m_docDate

        .m_receive = New Receive(Me)
        .m_receive.DocDate = Me.m_docDate
        '----------------------------End Tab Entities-----------------------------------------
        .AutoCodeFormat = New AutoCodeFormat(Me)
      End With
      m_vat = New Vat(Me)
      m_taxRate = CDec(Configuration.GetConfig("CompanyTaxRate"))
      m_taxType = New TaxType(2)
    End Sub
    Public Sub New(ByVal dr As System.Data.DataRow, ByVal aliasPrefix As String)
      MyBase.New(dr, aliasPrefix)
      Me.Construct(dr, aliasPrefix)
    End Sub
    Protected Overloads Overrides Sub Construct(ByVal dr As System.Data.DataRow, ByVal aliasPrefix As String)
      MyBase.Construct(dr, aliasPrefix)
      With Me

        If dr.Table.Columns.Contains("customer_id") Then
          If Not dr.IsNull("customer_id") Then
            .m_customer = New Customer(dr, "")
          End If
        Else
          If dr.Table.Columns.Contains("stock_entity") AndAlso Not dr.IsNull(aliasPrefix & "stock_entity") Then
            .m_customer = New Customer(CInt(dr(aliasPrefix & "stock_entity")))
          End If
        End If

        If dr.Table.Columns.Contains("stock_aftertax") AndAlso Not dr.IsNull(aliasPrefix & "stock_aftertax") Then
          .m_amount = CDec(dr(aliasPrefix & "stock_aftertax"))
        End If

        If dr.Table.Columns.Contains("stock_creditPeriod") AndAlso Not dr.IsNull(aliasPrefix & "stock_creditPeriod") Then
          .m_creditPeriod = CInt(dr(aliasPrefix & "stock_creditPeriod"))
        End If

        If dr.Table.Columns.Contains("stock_docDate") AndAlso Not dr.IsNull(aliasPrefix & "stock_docDate") Then
          .m_docDate = CDate(dr(aliasPrefix & "stock_docDate"))
        End If

        If dr.Table.Columns.Contains("stock_note") AndAlso Not dr.IsNull(aliasPrefix & "stock_note") Then
          .m_note = CStr(dr(aliasPrefix & "stock_note"))
        End If

        If dr.Table.Columns.Contains("stock_status") AndAlso Not dr.IsNull(aliasPrefix & "stock_status") Then
          .m_status = New OpeningBalanceStatus(CInt(dr(aliasPrefix & "stock_status")))
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

        m_je = New JournalEntry(Me)
        m_receive = New Receive(Me)
        m_vat = New Vat(Me)
      End With
      Me.AutoCodeFormat = New AutoCodeFormat(Me)
    End Sub
#End Region

#Region "Properties"    Public Property RealTaxAmount() As Decimal
      Get
        Return m_realTaxAmount
      End Get
      Set(ByVal Value As Decimal)
        m_realTaxAmount = Value
      End Set
    End Property
    Public Property RealTaxBase() As Decimal      Get        Return m_realTaxBase      End Get      Set(ByVal Value As Decimal)        m_realTaxBase = Value      End Set    End Property    Public Property Customer() As Customer      Get        Return m_customer      End Get      Set(ByVal Value As Customer)        m_customer = Value        OnPropertyChanged(Me, New PropertyChangedEventArgs)      End Set    End Property    Public Property CostCenter() As CostCenter Implements IHasToCostCenter.ToCC
      Get
        Return m_CostCenter
      End Get
      Set(ByVal Value As CostCenter)
        m_CostCenter = Value
      End Set
    End Property    Public Property Amount() As Decimal
      Get
        Return Me.m_amount
      End Get
      Set(ByVal Value As Decimal)
        m_amount = Value
      End Set
    End Property    Public ReadOnly Property AfterTax() As Decimal
      Get
        Return Me.Amount
      End Get
    End Property
    Public ReadOnly Property BeforeTax() As Decimal
      Get
        Select Case Me.TaxType.Value
          Case 0 '"ไม่มี"
            Return Me.AfterTax
          Case 1 '"แยก"
            Return Me.AfterTax
          Case 2 '"รวม"
            Return Configuration.Format(Vat.GetExcludedVatAmount(Me.AfterTax, Me.TaxRate), DigitConfig.Price)
        End Select
      End Get
    End Property
    Public Property CreditPeriod() As Integer
      Get
        Return m_creditPeriod
      End Get
      Set(ByVal Value As Integer)
        m_creditPeriod = Value
        OnPropertyChanged(Me, New PropertyChangedEventArgs)
      End Set
    End Property
    Public Property DocDate() As Date Implements IGLAble.Date
      Get
        Return Me.m_docDate
      End Get
      Set(ByVal Value As Date)
        Me.m_docDate = Value
        Me.m_je.DocDate = Value
        'OnGlChanged()
        OnPropertyChanged(Me, New PropertyChangedEventArgs)
      End Set
    End Property
    Public Property Note() As String Implements IReceivable.Note, IGLAble.Note
      Get
        Return Me.m_note
      End Get
      Set(ByVal Value As String)
        Me.m_note = Value
        OnPropertyChanged(Me, New PropertyChangedEventArgs)
      End Set
    End Property
    Public Overrides Property Status() As CodeDescription
      Get        Return m_status      End Get      Set(ByVal Value As CodeDescription)        m_status = CType(Value, OpeningBalanceStatus)        OnPropertyChanged(Me, New PropertyChangedEventArgs)      End Set
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
    End Property    Public Property TaxType() As TaxType      Get        Return m_taxType      End Get      Set(ByVal Value As TaxType)        m_taxType = Value        OnPropertyChanged(Me, New PropertyChangedEventArgs)      End Set    End Property
    Public ReadOnly Property TaxAmount() As Decimal
      Get        Select Case Me.TaxType.Value
          Case 0 '"ไม่มี"
            Return 0
          Case 2 'รวม VAT
            Return Me.AfterTax - Me.RealTaxBase
          Case Else '1 แยก
            Return Configuration.Format((Me.TaxRate * Me.RealTaxBase) / 100, DigitConfig.Price)        End Select      End Get
    End Property    Public Overrides ReadOnly Property TabPageText() As String
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
        Return "AROpeningBalance"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.AROpeningBalance.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.AROpeningBalance"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.AROpeningBalance"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.AROpeningBalance.ListLabel}"
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
        Return "GetAROpeningBalance"
      End Get
    End Property
#End Region

#Region "Methods"
    Private Sub ResetID(ByVal oldid As Integer, ByVal oldreceive As Integer, ByVal oldje As Integer, ByVal oldvat As Integer)
      Me.Id = oldid
      Me.m_receive.Id = oldreceive
      Me.m_je.Id = oldje
      Me.m_vat.Id = oldvat
    End Sub
    Private Sub ResetCode(ByVal oldCode As String, ByVal oldautogen As Boolean, ByVal oldJecode As String, ByVal oldjeautogen As Boolean)
      Me.Code = oldCode
      Me.AutoGen = oldautogen
      Me.m_je.Code = oldJecode
      Me.m_je.AutoGen = oldjeautogen
    End Sub
    Public Overloads Overrides Function Save(ByVal currentUserId As Integer) As SaveErrorException

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

      If Me.m_je.Status.Value = 4 Then
        Me.Status.Value = 4
        Me.m_receive.Status.Value = 4
        Me.m_vat.Status.Value = 4
      End If
      If Me.Status.Value = -1 Then
        Me.Status = New OpeningBalanceStatus(2)
      End If
      If Me.Status.Value = 0 Then
        Me.m_receive.Status.Value = 0
        Me.m_vat.Status.Value = 0
        Me.m_je.Status.Value = 0
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
      Me.m_je.DocDate = Me.DocDate
      Me.m_receive.DocDate = Me.m_je.DocDate
      Me.AutoGen = False
      Me.m_je.AutoGen = False
      Me.m_receive.AutoGen = False

      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_code", Me.Code))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_type", Me.EntityId))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_docdate", IIf(Me.DocDate.Equals(Date.MinValue), DBNull.Value, Me.DocDate)))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_afterTax", Me.Amount))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_creditPeriod", Me.CreditPeriod))

      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_taxType", Me.TaxType.Value))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_taxbase", Me.RealTaxBase))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_beforeTax", Me.BeforeTax))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_taxRate", Me.TaxRate))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_taxAmt", Me.RealTaxAmount))

      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_entity", ValidIdOrDBNull(Me.Customer)))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_entityType", Me.Customer.EntityId))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_cc", ValidIdOrDBNull(Me.CostCenter)))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_note", Me.Note))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_status", Me.Status.Value))

      SetOriginEditCancelStatus(paramArrayList, currentUserId, theTime)

      ' สร้าง SqlParameter จาก ArrayList ...
      Dim sqlparams() As SqlParameter
      sqlparams = CType(paramArrayList.ToArray(GetType(SqlParameter)), SqlParameter())

      Dim trans As SqlTransaction
      Dim conn As New SqlConnection(Me.ConnectionString)

      If conn.State = ConnectionState.Open Then conn.Close()
      conn.Open()
      trans = conn.BeginTransaction

      Dim oldid As Integer = Me.Id
      Dim oldreceive As Integer = Me.m_receive.Id
      Dim oldje As Integer = Me.m_je.Id
      Dim oldVat As Integer = Me.m_vat.Id
      Try
        Me.ExecuteSaveSproc(conn, trans, returnVal, sqlparams, theTime, theUser)
        If IsNumeric(returnVal.Value) Then
          Select Case CInt(returnVal.Value)
            Case -1, -2
              trans.Rollback()
              Me.ResetID(oldid, oldreceive, oldje, oldVat)
              ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
              Return New SaveErrorException(returnVal.Value.ToString)
            Case Else
          End Select
        ElseIf IsDBNull(returnVal.Value) OrElse Not IsNumeric(returnVal.Value) Then
          trans.Rollback()
          Me.ResetID(oldid, oldreceive, oldje, oldVat)
          ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
          Return New SaveErrorException(returnVal.Value.ToString)
        End If

        Me.m_receive.CcId = Me.m_CostCenter.Id
        Me.m_vat.SetCCId(Me.m_CostCenter.Id)
        Me.m_vat.SetRefDocToItem(Me.Id, Me.EntityId)

        Dim savePaymentError As SaveErrorException = Me.m_receive.Save(currentUserId, conn, trans)
        If Not IsNumeric(savePaymentError.Message) Then
          trans.Rollback()
          Me.ResetID(oldid, oldreceive, oldje, oldVat)
          ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
          Return savePaymentError
        Else
          Select Case CInt(savePaymentError.Message)
            Case -1, -2
              trans.Rollback()
              Me.ResetID(oldid, oldreceive, oldje, oldVat)
              ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
              Return savePaymentError
            Case Else
          End Select
        End If

        Dim saveVatError As SaveErrorException = Me.m_vat.Save(currentUserId, conn, trans)
        If Not IsNumeric(saveVatError.Message) Then
          trans.Rollback()
          Me.ResetID(oldid, oldreceive, oldje, oldVat)
          ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
          Return saveVatError
        Else
          Select Case CInt(saveVatError.Message)
            Case -1, -2, -5
              trans.Rollback()
              Me.ResetID(oldid, oldreceive, oldje, oldVat)
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
          Me.ResetID(oldid, oldreceive, oldje, oldVat)
          ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
          Return saveJeError
        Else
          Select Case CInt(saveJeError.Message)
            Case -1
              trans.Rollback()
              Me.ResetID(oldid, oldreceive, oldje, oldVat)
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
          ResetID(oldid, oldVat, oldreceive, oldje)
          ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
          Return saveAutoCodeError
        Else
          Select Case CInt(saveAutoCodeError.Message)
            Case -1, -2, -5
              trans.Rollback()
              ResetID(oldid, oldVat, oldreceive, oldje)
              ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
              Return saveAutoCodeError
            Case Else
          End Select
        End If
        '==============================AUTOGEN==========================================


        trans.Commit()
        ' ตรวจจับ Error ของการ Save ...
        Return New SaveErrorException(returnVal.Value.ToString)
      Catch ex As Exception
        trans.Rollback()
        Me.ResetID(oldid, oldreceive, oldje, oldVat)
        ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
        Return New SaveErrorException(returnVal.Value.ToString)
      Catch ex As SqlException
        trans.Rollback()
        Me.ResetID(oldid, oldreceive, oldje, oldVat)
        ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
        Return New SaveErrorException(returnVal.Value.ToString)
      Finally
        conn.Close()
      End Try

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
      'Dim myCC As CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
      Dim myCC As CostCenter = Me.CostCenter

      If Me.BeforeTax > 0 Then
        Dim ji As New JournalEntryItem
        'ลูกหนี้การค้า
        ji.Mapping = "C3.1"
        If Not Me.Customer.Account Is Nothing AndAlso Me.Customer.Account.Originated Then
          ji.Account = Me.Customer.Account
        End If
        ji.CostCenter = myCC
        ji.Amount = Me.AfterTax
        jiColl.Add(ji)

        'กำไรสะสม
        ji = New JournalEntryItem
        ji.Mapping = "C3.2"
        ji.CostCenter = myCC
        ji.Amount = Me.BeforeTax
        jiColl.Add(ji)

        'ภาษีขาย
        If Me.Vat.Amount > 0 Then
          ji = New JournalEntryItem
          ji.Mapping = "C3.3"
          ji.CostCenter = myCC
          ji.Amount = Me.Vat.Amount
          jiColl.Add(ji)
        End If

        'ภาษีขายยังไม่ถึงกำหนด
        If Me.RealTaxAmount - Me.Vat.Amount > 0 Then
          ji = New JournalEntryItem
          ji.Mapping = "C3.3.1"
          ji.Amount = Configuration.Format(Me.RealTaxAmount - Me.Vat.Amount, DigitConfig.Price)
          ji.CostCenter = myCC
          jiColl.Add(ji)
        End If
      End If

      Return jiColl
    End Function
#End Region

#Region "IPrintableEntity"
    Public Function GetDefaultFormPath() As String Implements IPrintableEntity.GetDefaultFormPath
      Return "AROpeningBalance"
    End Function
    Public Function GetDefaultForm() As String Implements IPrintableEntity.GetDefaultForm
      Return "AROpeningBalance"
    End Function
    Public Function GetDocPrintingEntries() As DocPrintingItemCollection Implements IPrintableEntity.GetDocPrintingEntries
      Dim dpiColl As New DocPrintingItemCollection
      Dim dpi As DocPrintingItem

      'DocCode
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
      If Me.Customer.Valid Then
        dpi = New DocPrintingItem
        dpi.Mapping = "CustomerInfo"
        dpi.Value = Me.Customer.Code & ":" & Me.Customer.Name
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        dpi = New DocPrintingItem
        dpi.Mapping = "CustomerCode"
        dpi.Value = Me.Customer.Code
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        dpi = New DocPrintingItem
        dpi.Mapping = "CustomerName"
        dpi.Value = Me.Customer.Name
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

#Region "ISaleBillIssuable"
    Public Function AmountToReceive() As Decimal Implements IReceivable.AmountToReceive
      Return Me.Amount
    End Function
    Public Property [Dated]() As Date Implements IReceivable.Date
      Get
        Return DocDate
      End Get
      Set(ByVal Value As Date)
        DocDate = Value
      End Set
    End Property
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
    Public ReadOnly Property Payer() As IBillablePerson Implements IReceivable.Payer
      Get
        Return Me.Customer
      End Get
    End Property
    Public Property Receive() As Receive Implements IReceivable.Receive
      Get
        Return m_receive
      End Get
      Set(ByVal Value As Receive)
        m_receive = Value
      End Set
    End Property
    Public Function RemainingAmount() As Decimal Implements IReceivable.RemainingAmount
      Return AmountToReceive()
    End Function
    Public Function GetRemainingAmountWithBillIssue(ByVal billi_id As Integer) As Decimal Implements ISaleBillIssuable.GetRemainingAmountWithBillIssue
      Try
        Dim ds As DataSet = SqlHelper.ExecuteDataset( _
                Me.ConnectionString _
                , CommandType.StoredProcedure _
                , "GetUnreceiveStockAmount" _
                , New SqlParameter("@stock_id", Me.Id) _
                , New SqlParameter("@salebillii_salebilli", billi_id) _
                )
        If ds.Tables(0).Rows.Count > 0 Then
          Return Configuration.Format(CDec(ds.Tables(0).Rows(0)(0)), DigitConfig.Price)
        End If
      Catch ex As Exception
        MessageBox.Show(ex.Message)
      End Try
    End Function
    Public Function GetRemainingAmountReceiveSelection(ByVal receives_id As Integer) As Decimal Implements ISaleBillIssuable.GetRemainingAmountReceiveSelection
      Try
        Dim ds As DataSet = SqlHelper.ExecuteDataset( _
                Me.ConnectionString _
                , CommandType.StoredProcedure _
                , "GetUnreceiveStockAmount" _
                , New SqlParameter("@stock_id", Me.Id) _
                , New SqlParameter("@receivesi_receives", receives_id) _
                )
        If ds.Tables(0).Rows.Count > 0 Then
          Return Configuration.Format(CDec(ds.Tables(0).Rows(0)(0)), DigitConfig.Price)
        End If
      Catch ex As Exception
        MessageBox.Show(ex.Message)
      End Try
    End Function
    Public Function GetRemainingAmountReceiveSelection(ByVal receives_id As Integer, ByVal billi_id As Integer) As Decimal Implements ISaleBillIssuable.GetRemainingAmountReceiveSelection
      Try
        Dim ds As DataSet = SqlHelper.ExecuteDataset( _
                Me.ConnectionString _
                , CommandType.StoredProcedure _
                , "GetUnreceiveStockAmount" _
                , New SqlParameter("@stock_id", Me.Id) _
                , New SqlParameter("@receivesi_receives", receives_id) _
                , New SqlParameter("@salebillii_salebilli", billi_id) _
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
      If Not myMessage.AskQuestionFormatted("${res:Global.ConfirmDeleteAROpeningBalance}", format) Then
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
        SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "DeleteAROpeningBalance", New SqlParameter() {New SqlParameter("@stock_id", Me.Id), returnVal})
        If IsNumeric(returnVal.Value) Then
          Select Case CInt(returnVal.Value)
            Case -1
              trans.Rollback()
              Return New SaveErrorException("${res:Global.AROpeningBalanceIsReferencedCannotBeDeleted}")
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
        Return Me.Customer
      End Get
      Set(ByVal Value As IBillablePerson)
        If TypeOf Value Is Customer Then
          Me.Customer = CType(Value, Customer)
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
    Public Function GetMaximumTaxBase() As Decimal Implements IVatable.GetMaximumTaxBase
      'Todo: ต้อง refresh หรือเปล่า?
      Return Me.RealTaxBase
    End Function
    Public Property Person() As IBillablePerson Implements IVatable.Person
      Get
        Return Me.Customer
      End Get
      Set(ByVal Value As IBillablePerson)
        Me.Customer = CType(Value, Customer)
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
  End Class
End Namespace
