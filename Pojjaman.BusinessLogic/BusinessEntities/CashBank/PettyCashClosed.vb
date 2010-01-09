Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration
Imports Longkong.Core.Services

Namespace Longkong.Pojjaman.BusinessLogic
  Public Class PettyCashClosedStatus
    Inherits CodeDescription

#Region "Constructors"
    Public Sub New(ByVal value As Integer)
      MyBase.New(value)
    End Sub
#End Region

#Region "Properties"
    Public Overrides ReadOnly Property CodeName() As String
      Get
        Return "pc_status"
      End Get
    End Property
#End Region

  End Class
  Public Class PettyCashClosed
    Inherits SimpleBusinessEntityBase
    Implements IGLAble, IReceivable, ICheckPeriod



#Region "Members"
    Private m_docdate As Date
    Private m_pettycash As PettyCash
    Private m_remainamt As Decimal
    Private m_amt As Decimal
    Private m_note As String

    Private m_receive As Receive
    Private m_je As JournalEntry

    Private m_status As PettyCashClosedStatus
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
    Public Sub New(ByVal dr As System.Data.DataRow, ByVal aliasPrefix As String)
      Me.Construct(dr, aliasPrefix)
    End Sub
    Protected Overloads Overrides Sub Construct()
      MyBase.Construct()
      With Me
        .m_docdate = Now.Date
        .m_pettycash = New PettyCash
        .m_status = New PettyCashClosedStatus(-1)
        .m_docdate = Now.Date
        .m_receive = New Receive
        .m_receive.DocDate = Me.m_docdate
        .m_je = New JournalEntry(Me)
        .m_je.DocDate = Me.m_docdate
        m_note = ""
        .AutoCodeFormat = New AutoCodeFormat(Me)
      End With
    End Sub
    Protected Overloads Overrides Sub Construct(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
      MyBase.Construct(ds, aliasPrefix)
    End Sub
    Protected Overloads Overrides Sub Construct(ByVal dr As System.Data.DataRow, ByVal aliasPrefix As String)
      MyBase.Construct(dr, aliasPrefix)
      With Me

        ' docdate
        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_docdate") _
            AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_docdate") Then
          .m_docdate = CDate(dr(aliasPrefix & Me.Prefix & "_docdate"))
        End If
        ' account
        If dr.Table.Columns.Contains("pettycash.pc_id") Then
          If Not dr.IsNull("pettycash.pc_id") Then
            .m_pettycash = New PettyCash(dr, "")
          End If
        Else
          If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_entity") _
              AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_entity") Then
            .m_pettycash = New PettyCash(CInt(dr(aliasPrefix & Me.Prefix & "_entity")))
          End If
        End If

        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_remainamt") _
            AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_remainamt") Then
          .m_remainamt = CDec(dr(aliasPrefix & Me.Prefix & "_remainamt"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_amt") _
            AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_amt") Then
          .m_amt = CDec(dr(aliasPrefix & Me.Prefix & "_amt"))
        End If

        ' note
        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_note") _
            AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_note") Then
          .m_note = CStr(dr(aliasPrefix & Me.Prefix & "_note"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_status") _
            AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_status") Then
          .m_status = New PettyCashClosedStatus(CInt(dr(aliasPrefix & Me.Prefix & "_status")))
        End If

        .m_receive = New Receive(Me)
        .m_je = New JournalEntry(Me)
      End With
      Me.AutoCodeFormat = New AutoCodeFormat(Me)
    End Sub
#End Region

#Region "Properties"

    Public Property DocDate() As Date Implements IGLAble.Date, ICheckPeriod.DocDate
      Get
        Return m_docdate
      End Get
      Set(ByVal Value As Date)
        m_docdate = Value
        Me.m_je.DocDate = Value
      End Set
    End Property

    Public Property PettyCash() As PettyCash
      Get
        Return m_pettycash
      End Get
      Set(ByVal Value As PettyCash)
        m_pettycash = Value
      End Set
    End Property

    Public ReadOnly Property EntityType() As Integer
      Get
        Return m_pettycash.EntityId
      End Get

    End Property

    Public Property Amount() As Decimal
      Get
        Return m_amt
      End Get
      Set(ByVal Value As Decimal)
        m_amt = Value
      End Set
    End Property

    Public Property Note() As String Implements IGLAble.Note
      Get
        Return m_note
      End Get
      Set(ByVal Value As String)
        m_note = Value
      End Set
    End Property
    Public Property RemainAmount() As Decimal
      Get
        Return m_remainamt
      End Get
      Set(ByVal Value As Decimal)
        m_remainamt = Value
      End Set
    End Property
    Public Overrides Property Status() As CodeDescription
      Get
        Return m_status
      End Get
      Set(ByVal Value As CodeDescription)
        m_status = CType(Value, PettyCashClosedStatus)
      End Set
    End Property
#End Region

#Region "Methods"
    Private Sub ResetID(ByVal oldid As Integer, ByVal oldreceive As Integer, ByVal oldje As Integer)
      Me.Id = oldid
      Me.m_receive.Id = oldreceive
      Me.m_je.Id = oldje
    End Sub
    Public Overloads Overrides Function Save(ByVal currentUserId As Integer) As SaveErrorException
      'Return New SaveErrorException("Not Yet Implemented")
      'MessageBox.Show(String.Format("{0}:{1}", Me.Amount, Me.Receive.Amount))
      'If Me.Amount < Me.Receive.Amount Then
      '    Return New SaveErrorException("${res:Global.Error.ReceiveAmountExceedGross}", Me.Amount.ToString, Me.Receive.Amount.ToString)
      'ElseIf Me.Amount > Me.Receive.Amount Then
      '    Return New SaveErrorException("${res:Global.Error.ReceiveGrossExceedAmount}", Me.Amount.ToString, Me.Receive.Amount.ToString)
      'End If

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
      Me.m_je.DocDate = Me.DocDate
      Me.m_receive.Code = m_je.Code
      Me.m_receive.DocDate = m_je.DocDate
      If Me.AutoCodeFormat.CodeConfig.Value = 0 Then
        Me.m_receive.Code = Me.Code
        Me.m_receive.DocDate = Me.DocDate
      End If
      Me.AutoGen = False
      Me.m_receive.AutoGen = False
      Me.m_je.AutoGen = False

      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_code", Me.Code))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_docdate", IIf(Me.DocDate.Equals(Date.MinValue), DBNull.Value, Me.DocDate)))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_entity", IIf(Me.PettyCash.Originated, Me.PettyCash.Id, DBNull.Value)))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_entitytype", Me.EntityType))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_remainamt", Me.RemainingAmount))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_amt", Me.Amount))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_status", Me.Status.Value))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_note", Me.Note))

      SetOriginEditCancelStatus(paramArrayList, currentUserId, theTime)

      ' สร้าง SqlParameter จาก ArrayList ...note
      Dim sqlparams() As SqlParameter
      sqlparams = CType(paramArrayList.ToArray(GetType(SqlParameter)), SqlParameter())
      Dim trans As SqlTransaction
      Dim conn As New SqlConnection(Me.ConnectionString)
      conn.Open()
      trans = conn.BeginTransaction()

      Dim oldid As Integer = Me.Id
      Dim oldreceive As Integer = m_receive.Id
      Dim oldje As Integer = m_je.Id

      Try
        UpdatePettyCashStatus(False)

        Me.ExecuteSaveSproc(conn, trans, returnVal, sqlparams, theTime, theUser)
        If IsNumeric(returnVal.Value) Then
          Select Case CInt(returnVal.Value)
            Case -1, -2, -5
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

        If Not Me.PettyCash.Costcenter Is Nothing Then
          Me.m_receive.CcId = Me.PettyCash.Costcenter.Id
        End If

        ''******************************************************************
        Dim saveReceiveError As SaveErrorException = Me.m_receive.Save(currentUserId, conn, trans)
        If Not IsNumeric(saveReceiveError.Message) Then
          trans.Rollback()
          Me.ResetID(oldid, oldreceive, oldje)
          Return saveReceiveError
        Else
          Select Case CInt(saveReceiveError.Message)
            Case -1, -2
              trans.Rollback()
              Me.ResetID(oldid, oldreceive, oldje)
              Return saveReceiveError
            Case Else
          End Select
        End If
        ''******************************************************************

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
        Try
          trans = conn.BeginTransaction()


          If Me.m_je.Status.Value = -1 Then
            m_je.Status.Value = 3
          End If
          '********************************************
          If Not Me.m_je.ManualFormat Then
            m_je.SetGLFormat(Me.GetDefaultGLFormat)
          End If
          '********************************************
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
          trans.Commit()
        Catch ex As Exception
          trans.Rollback()
          Me.ResetID(oldid, oldreceive, oldje)
          Return New SaveErrorException(ex.ToString)
        End Try

        UpdatePettyCashStatus(True)

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
    Public Sub UpdatePettyCashStatus(ByVal Closed As Boolean)
      ' Execute Store Procedure ...
      If Not Me.Originated Then
        Return
      End If
      SqlHelper.ExecuteNonQuery(Me.ConnectionString, CommandType.StoredProcedure, "UpdatePettyCashStatus", New SqlParameter("@pcclosed_id", Me.Id), New SqlParameter("@pc_closed", Closed))
    End Sub

#End Region

#Region "Overrides"
    Public Overrides ReadOnly Property Prefix() As String
      Get
        Return "pcclosed"
      End Get
    End Property
    Public Overrides ReadOnly Property ClassName() As String
      Get
        Return "PettyCashClosed"
      End Get
    End Property
    Public Overrides ReadOnly Property TableName() As String
      Get
        Return "PettyCashClosed"
      End Get
    End Property
    Public Overrides ReadOnly Property GetSprocName() As String
      Get
        Return "Get" & Me.TableName
      End Get
    End Property

    Public Overrides ReadOnly Property DetailPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.PettyCashClosed.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.PettyCashClosed"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.PettyCashClosed"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.PettyCashClosed.ListLabel}"
      End Get
    End Property
#End Region

#Region "Shared"
    Public Shared Function GetPettyCashClosed(ByVal txtCode As TextBox, ByRef oldPtc As PettyCashClosed) As Boolean
      Dim ptc As New PettyCashClosed(txtCode.Text)
      If txtCode.Text.Length <> 0 AndAlso Not ptc.Originated Then
        MessageBox.Show(txtCode.Text & " ไม่มีในระบบ")
        ptc = oldPtc
      End If
      txtCode.Text = ptc.Code
      If oldPtc.Id <> ptc.Id Then
        oldPtc = ptc
        Return True
      End If
      Return False
    End Function
#End Region

#Region " IGLAble "
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
      ' Cr. เงินสดย่อย
      If Me.Amount > 0 Then
        ji = New JournalEntryItem
        ji.Mapping = "G1.1"
        ji.Account = Me.PettyCash.Account
        ji.Amount = Me.RemainingAmount
        ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
        jiColl.Add(ji)
      End If
      ' TODO : Implements GL ...
      If Not Me.Receive Is Nothing Then
        jiColl.AddRange(Me.Receive.GetJournalEntries)
      End If
      Return jiColl
    End Function

    Public Property JournalEntry() As JournalEntry Implements IGLAble.JournalEntry
      Get
        Return Me.m_je
      End Get
      Set(ByVal Value As JournalEntry)
        Me.m_je = Value
      End Set
    End Property
#End Region

#Region " IReceivable "
    Public Function AmountToReceive() As Decimal Implements IReceivable.AmountToReceive
      Return Me.RemainingAmount
      'Return Me.Amount
    End Function

    Public Property Date2() As Date Implements IReceivable.Date
      Get
        Return Me.m_receive.DocDate
      End Get
      Set(ByVal Value As Date)
        Me.m_receive.DocDate = Value
      End Set
    End Property

    Public Property DueDate() As Date Implements IReceivable.DueDate
      Get
        Return Me.m_receive.DocDate
      End Get
      Set(ByVal Value As Date)

      End Set
    End Property

    Public Property IReceivableNote() As String Implements IReceivable.Note
      Get
        Return Me.m_receive.Note
      End Get
      Set(ByVal Value As String)
        Me.m_receive.Note = Value
      End Set
    End Property

    Public ReadOnly Property Payer() As IBillablePerson Implements IReceivable.Payer
      Get

      End Get
    End Property

    Public Property Receive() As Receive Implements IReceivable.Receive
      Get
        Return Me.m_receive
      End Get
      Set(ByVal Value As Receive)
        Me.m_receive = Value
      End Set
    End Property

    Public Function RemainingAmount() As Decimal Implements IReceivable.RemainingAmount
      Return Me.RemainAmount
    End Function

#End Region

#Region "Delete"
    Public Overrides ReadOnly Property CanDelete() As Boolean
      Get
        If Me.Originated Then
          Return Me.Status.Value <= 2
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
      If Not myMessage.AskQuestionFormatted("${res:Global.ConfirmDeletePettyCashClosed}", format) Then
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
        SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "DeletePettyCashClosed", New SqlParameter() {New SqlParameter("@" & Me.Prefix & "_id", Me.Id), returnVal})
        If IsNumeric(returnVal.Value) Then
          Select Case CInt(returnVal.Value)
            Case -1
              trans.Rollback()
              Return New SaveErrorException("${res:Global.PettyCashClosedIsReferencedCannotBeDeleted}")
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


  End Class
End Namespace
