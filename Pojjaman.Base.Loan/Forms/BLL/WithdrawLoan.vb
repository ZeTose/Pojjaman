Imports Longkong.Pojjaman.BusinessLogic
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Services
Imports Longkong.Pojjaman.DataAccessLayer

Namespace Longkong.Pojjaman.BusinessLogic
  Public Class WithdrawLoan
    Inherits SimpleBusinessEntityBase
    Implements IReceivable, IGLAble, ICancelable


#Region "Members"
    'WL_id	numeric(18, 0)		Unchecked
    'WL_loan	numeric(18, 0)	Loan	Checked
    'WL_code	nvarchar(50)	Code	Checked
    'WL_note	nvarchar(1000)		Checked
    'WL_DocDate	smalldatetime	วันที่รับเงิน	Checked
    'WL_DueDate	smalldatetime	วันที่ครบกำหนดจ่ายคืนนะ	Checked
    'WL_Creditperiod	numeric(18, 0)	ตามนั้น	Checked
    'WL_status	nchar(10)	CodeDescription="WLStatus"	Checked
    'WL_Amount	numeric(18, 4)		Checked
    'WL_refid	numeric(18, 0)	WL/Aval เพื่อการแปลงวงเงิน
    'WL_refType	numeric(18, 0)	WL/Aval (Check)เพื่อการแปลงวงเงิน

    Private m_loan As Loan
    Private m_note As String
    Private m_docdate As Date
    Private m_duedate As Date
    Private m_creditperiod As Integer
    Private m_amount As Decimal
    Private m_costCenter As CostCenter
    Private m_statusId As Integer
    Private m_statusText As String
    Private m_closed As Boolean
    Private m_receive As Receive
    Private m_je As JournalEntry
#End Region

#Region "Constructors"
    Public Sub New()
      MyBase.New()
    End Sub
    Public Sub New(ByVal id As Integer)
      MyBase.New(id)
    End Sub
    Public Sub New(ByVal code As String)
      MyBase.New(code)
    End Sub
    Public Sub New(ByVal dr As DataRow, ByVal aliasPrefix As String)
      Construct(dr, aliasPrefix)
    End Sub
    Protected Overloads Overrides Sub Construct()
      'สร้างเอกสารใหม่
      MyBase.Construct()
      m_docdate = Now.Date
      DueDate = m_docdate
      StatusId = 2
      m_receive = New Receive(Me)
      m_receive.DocDate = Me.m_docdate
      '----------------------------Tab Entities-----------------------------------------
      m_je = New JournalEntry(Me)
      m_je.DocDate = Me.m_docdate

      m_receive = New Receive(Me)
      m_receive.DocDate = Me.m_docdate
      '----------------------------End Tab Entities-----------------------------------------
      AutoCodeFormat = New AutoCodeFormat(Me)
    End Sub
    Protected Overloads Overrides Sub Construct(ByVal dr As System.Data.DataRow, ByVal aliasPrefix As String)
      MyBase.Construct(dr, aliasPrefix)
      Dim deh As New DataRowHelper(dr)
      Dim loanId As Integer = deh.GetValue(Of Integer)("wl_loan")
      m_loan = New Loan(loanId)
      m_note = deh.GetValue(Of String)("wl_note")
      m_creditperiod = deh.GetValue(Of Integer)("WL_Creditperiod")
      m_docdate = deh.GetValue(Of Date)("wl_docdate")
      m_duedate = deh.GetValue(Of Date)("wl_duedate")
      m_amount = deh.GetValue(Of Decimal)("wl_amount")
      StatusId = deh.GetValue(Of Integer)("wl_status")
      If StatusId = 5 Then m_closed = True Else m_closed = False
      m_receive = New Receive(Me)
      m_je = New JournalEntry(Me)

      m_receive = New Receive(Me)
      m_receive.DocDate = Me.m_docdate
      AutoCodeFormat = New AutoCodeFormat(Me)
    End Sub
#End Region

#Region "Properties"    Public Property Loan As Loan
      Get
        If m_loan Is Nothing Then
          m_loan = New Loan
        End If
        Return m_loan
      End Get
      Set(ByVal Value As Loan)
        m_loan = Value
      End Set
    End Property
    Public Property Note As String Implements IReceivable.Note, IGLAble.Note
      Get
        Return m_note
      End Get
      Set(ByVal Value As String)
        m_note = Value
      End Set
    End Property
    Public Property DocDate As Date Implements IReceivable.Date, IGLAble.Date
      Get
        Return m_docdate
      End Get
      Set(ByVal Value As Date)
        m_docdate = Value
        Me.m_je.DocDate = Value
      End Set
    End Property
    Public Property DueDate As Date Implements IReceivable.DueDate
      Get
        Try
          Return Me.DocDate.AddDays(Me.CreditPeriod)
        Catch ex As Exception
          Return Me.DocDate
        End Try
      End Get
      Set(ByVal Value As Date)
        Try
          m_creditperiod = CInt(DateDiff(DateInterval.Day, DocDate, Value))
        Catch ex As Exception

        End Try
      End Set
    End Property
    Public Property CreditPeriod As Integer
      Get
        Return m_creditperiod
      End Get
      Set(ByVal Value As Integer)
        m_creditperiod = Value
      End Set
    End Property
    Public Property Amount As Decimal
      Get
        Return m_amount
      End Get
      Set(ByVal Value As Decimal)
        m_amount = Value
      End Set
    End Property
    Public Property CostCenter As CostCenter
      Get
        If m_costCenter Is Nothing Then
          m_costCenter = New CostCenter
        End If
        Return m_costCenter
      End Get
      Set(ByVal Value As CostCenter)
        m_costCenter = Value
      End Set
    End Property
    Public Property StatusId As Integer
      Get
        Return m_statusId
      End Get
      Set(ByVal Value As Integer)
        m_statusId = Value
        Select Case m_statusId
          Case 0
            m_statusText = Me.StringParserService.Parse("${res:Global.DocStatus.Cancle}")
          Case 1
            m_statusText = Me.StringParserService.Parse("${res:Global.DocStatus.OnHold}")
          Case 2
            m_statusText = Me.StringParserService.Parse("${res:Global.DocStatus.Active}")
          Case 3
            m_statusText = Me.StringParserService.Parse("${res:Global.DocStatus.Reference}")
          Case 4
            m_statusText = Me.StringParserService.Parse("${res:Global.DocStatus.Post}")
          Case 5
            m_statusText = Me.StringParserService.Parse("${res:Global.DocStatus.Close}")
        End Select
        Me.Status.Value = Value
      End Set
    End Property
    Public Property StatusText As String
      Get
        Return m_StatusText
      End Get
      Set(ByVal Value As String)
        m_StatusText = Value
      End Set
    End Property
    Public Property Closed() As Boolean
      Get
        Return m_closed
      End Get
      Set(ByVal Value As Boolean)
        m_closed = Value
      End Set
    End Property
#End Region

#Region "Overrides Properties"
    Public Overrides ReadOnly Property ClassName() As String
      Get
        Return "WithdrawLoan"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.WithdrawLoan.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.WithdrawLoan"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.WithdrawLoan"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.WithdrawLoan.ListLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property Prefix() As String
      Get
        Return "wl"
      End Get
    End Property
#End Region

#Region "Method"
    Private Sub ResetID(ByVal oldid As Integer, ByVal oldreceive As Integer, ByVal oldje As Integer)
      Me.Id = oldid
      Me.m_receive.Id = oldreceive
      Me.m_je.Id = oldje
    End Sub
    Public Overrides Function ToString() As String
      Return Me.Code
    End Function
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
        If Me.StatusId > 2 Then
          Me.StatusId = 3 'Post แล้ว ถือว่าสถานะเอกสารรับเงินกู้ เป็นถูกอ้างอิงเพื่อคงจะเปลี่ยนเป็นปิดได้
        End If
        Me.m_receive.Status.Value = 4
      End If
      If Me.StatusId = 0 Then
        Me.m_receive.Status.Value = 0
        Me.m_je.Status.Value = 0
      End If

      Me.m_je.RefreshGLFormat()
      '---- AutoCode Format --------
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
              Me.Code = m_je.GetNextCode 'Me.Code = Me.GetNextCode
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
              Me.Code = m_je.GetNextCode 'Me.Code = Me.GetNextCode
            End If
            If Me.m_je.AutoGen Then
              Me.m_je.Code = m_je.GetNextCode
            End If

        End Select
      Else
        'แยก
        If Me.AutoGen Then 'And Me.Code.Length = 0 Then
          Me.Code = Me.GetNextCode
        End If
        If Me.m_je.AutoGen Then
          Me.m_je.Code = m_je.GetNextCode
        End If
      End If
      If Me.Receive.Gross <> 0 Then
        Me.m_receive.Code = m_je.Code
      End If
      Me.m_je.DocDate = Me.DocDate
      Me.m_receive.DocDate = m_je.DocDate
      If Me.AutoCodeFormat.CodeConfig.Value = 0 Then
        Me.m_receive.Code = Me.Code
        Me.m_receive.DocDate = Me.DocDate
      End If

      Me.AutoGen = False
      Me.m_receive.AutoGen = False
      Me.m_je.AutoGen = False
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_code", Me.Code))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_loan", ValidIdOrDBNull(Me.Loan)))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_note", Me.Note))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_docdate", ValidDateOrDBNull(Me.DocDate)))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_duedate", ValidDateOrDBNull(Me.DueDate)))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_creditperiod", Me.CreditPeriod))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_amount", Me.Amount))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_costCenter", ValidIdOrDBNull(Me.CostCenter)))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_statusId", Me.StatusId))

      ' Save Originator , LastEditor , CancelPerson ...
      ' SetOriginEditCancelStatus(paramArrayList, currentUserId, theTime)
      ' สร้าง SqlParameter จาก ArrayList ...
      Dim sqlparams() As SqlParameter
      sqlparams = CType(paramArrayList.ToArray(GetType(SqlParameter)), SqlParameter())

      Dim trans As SqlTransaction
      Dim conn As New SqlConnection(SimpleBusinessEntityBase.ConnectionString)

      If conn.State = ConnectionState.Open Then conn.Close()
      conn.Open()
      trans = conn.BeginTransaction
      Dim oldid As Integer = Me.Id
      Dim oldreceive As Integer = Me.m_receive.Id
      Dim oldje As Integer = Me.m_je.Id
      Try
        Me.ExecuteSaveSproc(conn, trans, returnVal, sqlparams, theTime, theUser)
        If IsNumeric(returnVal.Value) Then
          Select Case CInt(returnVal.Value)
            Case -1, -5
              trans.Rollback()
              Me.ResetID(oldid, oldreceive, oldje)
              Return New SaveErrorException(returnVal.Value.ToString)
            Case -2
              trans.Rollback()
              Me.ResetID(oldid, oldreceive, oldje)
              Return New SaveErrorException(returnVal.Value.ToString)
            Case Else
          End Select
        ElseIf IsDBNull(returnVal.Value) OrElse Not IsNumeric(returnVal.Value) Then
          trans.Rollback()
          Me.ResetID(oldid, oldreceive, oldje)
          Return New SaveErrorException(returnVal.Value.ToString)
        End If
        If Not Me.CostCenter Is Nothing Then
          Me.m_receive.CcId = Me.CostCenter.Id
        End If
        Dim saveReceiveError As SaveErrorException = Me.m_receive.Save(currentUserId, conn, trans)
        If Not IsNumeric(saveReceiveError.Message) Then
          trans.Rollback()
          Me.ResetID(oldid, oldreceive, oldje)
          Return saveReceiveError
        Else
          Select Case CInt(saveReceiveError.Message)
            Case -1, -5
              trans.Rollback()
              Me.ResetID(oldid, oldreceive, oldje)
              Return saveReceiveError
            Case -2
              trans.Rollback()
              Me.ResetID(oldid, oldreceive, oldje)
              Return saveReceiveError
            Case Else
          End Select
        End If
        If Me.m_je.Status.Value = -1 Then
          m_je.Status.Value = 3
        End If
        Dim saveJeError As SaveErrorException = Me.m_je.Save(currentUserId, conn, trans)
        If Not IsNumeric(saveJeError.Message) Then
          trans.Rollback()
          Me.ResetID(oldid, oldreceive, oldje)
          Return saveJeError
        Else
          Select Case CInt(saveJeError.Message)
            Case -1, -5
              trans.Rollback()
              Me.ResetID(oldid, oldreceive, oldje)
              Return saveJeError
            Case -2
              'Post ไปแล้ว
              Return saveJeError
            Case Else
          End Select
        End If
        '==============================Reference==========================================
        Me.DeleteRef(conn, trans)
        Me.UpdateRef(Me.Loan, conn, trans)
        If Me.Status.Value = 0 Then
          Me.CancelRef(conn, trans)
        End If
        '==============================Reference==========================================
        '==============================AUTOGEN==========================================
        Dim saveAutoCodeError As SaveErrorException = SaveAutoCode(conn, trans)
        If Not IsNumeric(saveAutoCodeError.Message) Then
          trans.Rollback()
          ResetID(oldid, oldreceive, oldje)
          Return saveAutoCodeError
        Else
          Select Case CInt(saveAutoCodeError.Message)
            Case -1, -2, -5
              trans.Rollback()
              ResetID(oldid, oldreceive, oldje)
              Return saveAutoCodeError
            Case Else
          End Select
        End If
        '==============================AUTOGEN==========================================
        trans.Commit()
        Return New SaveErrorException(returnVal.Value.ToString)
      Catch ex As SqlException
        trans.Rollback()
        Me.ResetID(oldid, oldreceive, oldje)
        Return New SaveErrorException(ex.ToString)
      Catch ex As Exception
        trans.Rollback()
        Me.ResetID(oldid, oldreceive, oldje)
        Return New SaveErrorException(ex.ToString)
      Finally
        conn.Close()
      End Try
    End Function
#End Region

#Region "Shared"
    Public Shared Function GetWithdrawLoan(ByVal txtCode As TextBox, ByVal txtName As TextBox, ByRef oldEmp As WithdrawLoan) As Boolean
      Dim emp As New WithdrawLoan(txtCode.Text)
      If txtCode.Text.Length <> 0 AndAlso Not emp.Valid Then
        MessageBox.Show(txtCode.Text & " ไม่มีในระบบ")
        emp = oldEmp
      End If
      txtCode.Text = emp.Code
      txtName.Text = emp.Code
      If oldEmp.Id <> emp.Id Then
        oldEmp = emp
        Return True
      End If
      Return False
    End Function
#End Region

#Region "Delete"
    Public Overrides ReadOnly Property CanDelete() As Boolean
      Get
        If Me.Originated Then
          Return Me.StatusId <= 2 AndAlso Not Me.IsReferenced
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
      If Not myMessage.AskQuestionFormatted("${res:Global.ConfirmDeleteWithdrawLoan}", format) Then
        Return New SaveErrorException("${res:Global.CencelDelete}")
      End If
      Dim trans As SqlTransaction
      Dim conn As New SqlConnection(SimpleBusinessEntityBase.ConnectionString)
      conn.Open()
      trans = conn.BeginTransaction()
      Try
        Dim returnVal As System.Data.SqlClient.SqlParameter = New SqlParameter
        returnVal.ParameterName = "RETURN_VALUE"
        returnVal.DbType = DbType.Int32
        returnVal.Direction = ParameterDirection.ReturnValue
        returnVal.SourceVersion = DataRowVersion.Current
        SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "DeleteWithdrawLoan", New SqlParameter() {New SqlParameter("@wl_id", Me.Id), returnVal})
        If IsNumeric(returnVal.Value) Then
          Select Case CInt(returnVal.Value)
            Case -1
              trans.Rollback()
              Return New SaveErrorException("${res:Global.WithdrawLoanIsReferencedCannotBeDeleted}")
            Case Else
          End Select
        ElseIf IsDBNull(returnVal.Value) OrElse Not IsNumeric(returnVal.Value) Then
          trans.Rollback()
          Return New SaveErrorException(returnVal.Value.ToString)
        End If
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
#Region "IGLAble"


    Public Function GetDefaultGLFormat() As GLFormat Implements IGLAble.GetDefaultGLFormat
      If Not Me.AutoCodeFormat.GLFormat Is Nothing AndAlso Me.AutoCodeFormat.GLFormat.Originated Then
        Return Me.AutoCodeFormat.GLFormat
      End If
      Dim ds As DataSet = SqlHelper.ExecuteDataset(SimpleBusinessEntityBase.ConnectionString _
      , CommandType.StoredProcedure _
      , "GetGLFormatForEntity" _
      , New SqlParameter("@entity_id", Me.EntityId), New SqlParameter("@default", 1) _
      , New SqlParameter("@inventoryType", CInt(Configuration.GetConfig("CompanyInventoryMethod"))))
      If ds.Tables(0).Rows.Count > 0 Then
        Dim glf As New GLFormat(ds.Tables(0).Rows(0), "")
        Return glf
      End If
      Return New GLFormat
    End Function

    Public Function GetJournalEntries() As JournalEntryItemCollection Implements IGLAble.GetJournalEntries
      Dim jiColl As New JournalEntryItemCollection
      Dim ji As JournalEntryItem
      'เจ้าหนี้เงินกู้
      If Me.Amount > 0 Then
        ji = New JournalEntryItem
        ji.Mapping = "WL1" 'ตั้งใหม่
        ji.Amount = Configuration.Format(Me.Amount, DigitConfig.Price)
        ji.Account = Me.Loan.Account
        If Me.Loan.CostCenter.Originated Then 'เอกสารเคยมีใน DB หรือไม่
          ji.CostCenter = Me.Loan.CostCenter
        Else
          ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
        End If
        jiColl.Add(ji)
      End If
      If Not Me.Receive Is Nothing Then
        For Each ji1 As JournalEntryItem In Me.Receive.GetJournalEntries
          ji1.CostCenter = Me.Loan.CostCenter 'เพื่อให้ลง CC ที่ Loan นั้นอยู่
        Next
        jiColl.AddRange(Me.Receive.GetJournalEntries)
      End If
      Return (jiColl)
    End Function

    Public Property JournalEntry As JournalEntry Implements IGLAble.JournalEntry
      Get
        Return Me.m_je
      End Get
      Set(ByVal Value As JournalEntry)
        m_je = Value
      End Set
    End Property

#End Region

#Region "IReceivable"
    Public Function AmountToReceive() As Decimal Implements IReceivable.AmountToReceive
      Return Me.Amount
    End Function


    Public ReadOnly Property Payer As IBillablePerson Implements IReceivable.Payer
      Get
        Return m_loan.BankAccount
      End Get
    End Property

    Public Property Receive As Receive Implements IReceivable.Receive
      Get
        Return m_receive
      End Get
      Set(ByVal value As Receive)
        m_receive = value
      End Set
    End Property

    Public Function RemainingAmount() As Decimal Implements IReceivable.RemainingAmount
      Return 0 'ไม่รู้ว่าคืออะไรกันแน่
    End Function
#End Region

#Region "ICancelable"
    Public ReadOnly Property CanCancel() As Boolean Implements ICancelable.CanCancel
      Get
        Return Me.StatusId > 1 AndAlso Me.IsCancelable
      End Get
    End Property
    Public Function CancelEntity(ByVal currentUserId As Integer, ByVal theTime As Date) As SaveErrorException Implements ICancelable.CancelEntity
      Me.StatusId = 0
      Return Me.Save(currentUserId)
    End Function
#End Region

  End Class
End Namespace