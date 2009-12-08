Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration

Namespace Longkong.Pojjaman.BusinessLogic

Public Class Banking
    Inherits SimpleBusinessEntityBase
    Implements IGLAble, ICheckPeriod


#Region "Members"
        Private m_bankacct As BankAccount
        Private m_docdate As Date

        ' Transfer 
        Private m_cqcode As String
        Private m_bankacctdestinate As BankAccount

        Private m_amount As Decimal
        Private m_bankcharge As Decimal
        Private m_wht As Decimal

        Private m_note As String

        Private m_bankingType As BankingTransType
        Private m_bankingformat As BankingFormat
        Private m_status As BankingStatus

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
        Protected Overloads Overrides Sub Construct()
            MyBase.Construct()
            With Me
                .m_docdate = Now.Date
                .m_bankacct = New BankAccount
                .m_bankacctdestinate = New BankAccount

                .m_docdate = Date.Now.Date
                .m_bankingformat = New BankingFormat(0)

                .m_je = New JournalEntry(Me)
                .m_je.DocDate = Me.m_docdate
                .m_status = New BankingStatus(-1)
            End With
        End Sub
        Protected Overloads Overrides Sub Construct(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
            MyBase.Construct(ds, aliasPrefix)
        End Sub
        Protected Overloads Overrides Sub Construct(ByVal dr As System.Data.DataRow, ByVal aliasPrefix As String)
            MyBase.Construct(dr, aliasPrefix)
            With Me
                ' Document Date
                If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_docdate") _
                    AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_docdate") Then
                    .m_docdate = CDate(dr(aliasPrefix & Me.Prefix & "_docdate"))
                End If
                ' สมุดเงินฝาก
                If dr.Table.Columns.Contains("bankacct_id") Then
                    If Not dr.IsNull("bankacct_id") Then
                        .m_bankacct = New BankAccount(dr, "")
                    End If
                Else
                    If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_bankacct") _
                        AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_bankacct") Then
                        .m_bankacct = New BankAccount(CInt(dr(aliasPrefix & Me.Prefix & "_bankacct")))
                    End If
                End If

                ' CqCode 
                If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_cqcode") _
                                AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_cqcode") Then
                    Me.m_cqcode = CStr(dr(aliasPrefix & Me.Prefix & "_cqcode"))
                End If

                ' Bankaccount Destination
                If dr.Table.Columns.Contains("bankacctdestinate.bankacct_id") _
                    AndAlso Not dr.IsNull("bankacctdestinate.bankacct_id") Then
                    Me.m_bankacctdestinate = New BankAccount(dr, "")
                Else
                    If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_bankacctdestinate") _
                        AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_bankacctdestinate") Then
                        Me.m_bankacctdestinate = New BankAccount(CInt(dr(aliasPrefix & Me.Prefix & "_bankacctdestinate")))
                    End If
                End If

                ' Amount
                If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_amount") _
                    AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_amount") Then
                    .m_amount = CDec(dr(aliasPrefix & Me.Prefix & "_amount"))
                End If
                ' Bank Charge
                If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_bankcharge") _
                    AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_bankcharge") Then
                    .m_bankcharge = CDec(dr(aliasPrefix & Me.Prefix & "_bankcharge"))
                End If
                ' Wht
                If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_wht") _
                    AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_wht") Then
                    .m_wht = CDec(dr(aliasPrefix & Me.Prefix & "_wht"))
                End If

                ' Note
                If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_note") _
                    AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_note") Then
                    .m_note = CStr(dr(aliasPrefix & Me.Prefix & "_note"))
                End If

                'status
                If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_status") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_status") Then
                    m_status = New BankingStatus(CInt(dr(aliasPrefix & Me.Prefix & "_status")))
                End If

                'banking format
                If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_format") _
                    AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_format") Then
                    m_bankingformat = New BankingFormat(CInt(dr(aliasPrefix & Me.Prefix & "_format")))
                End If

                ' ประเภท banking transaction
                If dr.Table.Columns.Contains(aliasPrefix & "banking_type") _
                    AndAlso Not dr.IsNull(aliasPrefix & "banking_type") Then
                    Me.m_bankingType = New BankingTransType(CInt(dr(aliasPrefix & "banking_type")))
                End If

                m_je = New JournalEntry(Me)
            End With
        End Sub
#End Region

#Region "Properties"
    Public Property Bankacct() As BankAccount        Get            Return m_bankacct        End Get        Set(ByVal Value As BankAccount)            m_bankacct = Value        End Set    End Property    Public Property Docdate() As Date Implements ICheckPeriod.DocDate      Get        Return m_docdate      End Get      Set(ByVal Value As Date)        m_docdate = Value      End Set    End Property    Public Property CqCode() As String
      Get
        Return m_cqcode
      End Get
      Set(ByVal Value As String)
        m_cqcode = Value
      End Set
    End Property
    Public Property BankacctDestinate() As BankAccount
      Get
        Return m_bankacctdestinate
      End Get
      Set(ByVal Value As BankAccount)
        m_bankacctdestinate = Value
      End Set
    End Property    Public Property Amount() As Decimal      Get        Return m_amount      End Get      Set(ByVal Value As Decimal)        m_amount = Value      End Set    End Property    Public Property BankCharge() As Decimal      Get        Return m_bankcharge      End Get      Set(ByVal Value As Decimal)        m_bankcharge = Value      End Set    End Property    Public Overridable ReadOnly Property WHT() As Decimal      Get        Return m_wht      End Get    End Property    Public Property Note() As String Implements IGLAble.Note      Get        Return m_note      End Get      Set(ByVal Value As String)        m_note = Value      End Set    End Property    Public Overridable Property BankingTransType() As CodeDescription
      Get
        Return m_bankingType
      End Get
      Set(ByVal Value As CodeDescription)
        m_bankingType = CType(Value, BankingTransType)
      End Set
    End Property    Public Property BankingFormat() As CodeDescription      Get        Return m_bankingformat      End Get      Set(ByVal Value As CodeDescription)        m_bankingformat = CType(Value, BankingFormat)      End Set    End Property#End Region

#Region "Overrides"
        Public Overrides Property Status() As CodeDescription
            Get                Return m_status            End Get            Set(ByVal Value As CodeDescription)                m_status = CType(Value, BankingStatus)            End Set
        End Property

        Public Overrides ReadOnly Property Prefix() As String
            Get
                Return "banking"
            End Get
        End Property
        Public Overrides ReadOnly Property ClassName() As String
            Get
                Return "Banking"
            End Get
        End Property
        Public Overrides ReadOnly Property TableName() As String
            Get
                Return "Banking"
            End Get
        End Property
        Public Overrides ReadOnly Property GetSprocName() As String
            Get
                Return "Get" & Me.TableName
            End Get
        End Property

        Private Sub ResetID(ByVal oldid As Integer, ByVal oldje As Integer)
            Me.Id = oldid
            Me.m_je.Id = oldje
        End Sub
        Public Overloads Overrides Function Save(ByVal currentUserId As Integer) As SaveErrorException
            'Return New SaveErrorException("Not Yet Implemented")
            Dim showStr As String
            Select Case Me.ClassName.ToLower
                Case "bankcharge"
                    If Me.BankCharge <= 0 Then
                        showStr = "${res:Longkong.Pojjaman.Gui.Panels.BankChargeDetail.lblBankCharge}"
                        Return New SaveErrorException("${res:Global.Error.ZeroValueMiss}", showStr)
                    End If
                Case Else
                    If Me.Amount <= 0 Then
                        Select Case Me.ClassName.ToLower
                            Case "cashdeposite"
                                showStr = "${res:Longkong.Pojjaman.Gui.Panels.CashDepositDetail.lblAmount}"
                            Case "cashwithdraw"
                                showStr = "${res:Longkong.Pojjaman.Gui.Panels.CashWithdrawDetail.lblAmount}"
                            Case "banktransfer"
                                showStr = "${res:Longkong.Pojjaman.Gui.Panels.BankTransferDetail.lblAmount}"
                            Case Else
                                showStr = "${res:Longkong.Pojjaman.Gui.Panels.IncomeFromBank.lblAmount}"
                        End Select
                        Return New SaveErrorException("${res:Global.Error.ZeroValueMiss}", showStr)
                    End If
            End Select

            If Me.Bankacct Is Me.BankacctDestinate Then
                ' กรณีต้องการให้โอนคนล่ะบัญชี
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

            If Me.AutoGen And Me.Code.Length = 0 Then
                Me.Code = Me.GetNextCode
            End If
            Me.AutoGen = False

            If Me.m_je.Status.Value = 4 Then
                Me.Status.Value = 4
            End If
            If Me.Status.Value = -1 Then
                Me.Status.Value = 2
            End If

            paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_code", Me.Code))
            paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_docdate", IIf(Me.Docdate.Equals(Date.MinValue), DBNull.Value, Me.Docdate)))

            paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_bankacct", IIf(Me.Bankacct.Originated, Me.Bankacct.Id, DBNull.Value)))

            ' BankTransfer
            paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_cqcode", Me.CqCode))
            paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_bankacctdestinate", IIf(Me.BankacctDestinate.Originated, Me.BankacctDestinate.Id, DBNull.Value)))

            paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_amount", Me.Amount))
            paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_bankcharge", Me.BankCharge))
            paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_wht", Me.WHT))

            paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_format", Me.BankingFormat.Value))
            paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_type", Me.BankingTransType.Value))

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
            Dim oldje As Integer = Me.m_je.Id

            Try
                Me.ExecuteSaveSproc(conn, trans, returnVal, sqlparams, theTime, theUser)
                If IsNumeric(returnVal.Value) Then
                    Select Case CInt(returnVal.Value)
                        Case -1
                            trans.Rollback()
                            Me.ResetID(oldid, oldje)
                            Return New SaveErrorException(returnVal.Value.ToString)
                        Case -2
                            trans.Rollback()
                            Me.ResetID(oldid, oldje)
                            Return New SaveErrorException(returnVal.Value.ToString)
                        Case -5 'งวด
                            trans.Rollback()
                            Me.ResetID(oldid, oldje)
                            Return New SaveErrorException(returnVal.Value.ToString)
                        Case Else
                    End Select
                ElseIf IsDBNull(returnVal.Value) OrElse Not IsNumeric(returnVal.Value) Then
                    trans.Rollback()
                    Me.ResetID(oldid, oldje)
                    Return New SaveErrorException(returnVal.Value.ToString)
                End If


                If Me.m_je.Status.Value = -1 Then
                    m_je.Status.Value = 3
                End If
                Dim saveJeError As SaveErrorException = Me.m_je.Save(currentUserId, conn, trans)
                If Not IsNumeric(saveJeError.Message) Then
                    trans.Rollback()
                    Me.ResetID(oldid, oldje)
                    Return saveJeError
                Else
                    Select Case CInt(saveJeError.Message)
                        Case -1
                            trans.Rollback()
                            Me.ResetID(oldid, oldje)
                            Return saveJeError
                        Case -2
                            'Post ไปแล้ว
                            Return saveJeError
                        Case -5
                            trans.Rollback()
                            Me.ResetID(oldid, oldje)
                            Return saveJeError
                        Case Else
                    End Select
                End If
                trans.Commit()
                ' ตรวจจับ Error ของการ Save ...
                Return New SaveErrorException(returnVal.Value.ToString)
            Catch ex As Exception
                trans.Rollback()
                Me.ResetID(oldid, oldje)
                Return New SaveErrorException(returnVal.Value.ToString)
            Catch ex As SqlException
                trans.Rollback()
                Me.ResetID(oldid, oldje)
                Return New SaveErrorException(returnVal.Value.ToString)
            Finally
                conn.Close()
            End Try

        End Function
#End Region

#Region " IGLAble "

        Public Property [Date]() As Date Implements IGLAble.Date
            Get
                Return Me.Docdate
            End Get
            Set(ByVal Value As Date)
                Me.Docdate = Value
            End Set
        End Property

        Public Overridable Function GetDefaultGLFormat() As GLFormat Implements IGLAble.GetDefaultGLFormat
            Dim ds As DataSet = SqlHelper.ExecuteDataset(Me.ConnectionString _
                        , CommandType.StoredProcedure _
                        , "GetGLFormatForEntity" _
                        , New SqlParameter("@entity_name", Me.ClassName), New SqlParameter("@default", 1))
            Dim glf As New GLFormat(ds.Tables(0).Rows(0), "")

            Return glf
        End Function

        Public Overridable Function GetJournalEntries() As JournalEntryItemCollection Implements IGLAble.GetJournalEntries
            ' Debug.WriteLine("Must implements")
        End Function

        Public Property JournalEntry() As JournalEntry Implements IGLAble.JournalEntry
            Get
                Return m_je
            End Get
            Set(ByVal Value As JournalEntry)
                m_je = Value
            End Set
        End Property

#End Region

   
End Class

Public Class BankingTransType
    Inherits CodeDescription

#Region "Construtors"
    Public Sub New(ByVal value As Integer)
        MyBase.New(value)
    End Sub
#End Region

#Region "Properties"
    Public Overrides ReadOnly Property CodeName() As String
        Get
            Return "banking_type"
        End Get
    End Property
#End Region

    End Class

    Public Class BankingFormat
        Inherits CodeDescription

#Region "Construtors"
        Public Sub New()
            MyBase.New()
        End Sub
        Public Sub New(ByVal value As Integer)
            MyBase.New(value)
        End Sub
#End Region

#Region "Properties"
        Public Overrides ReadOnly Property CodeName() As String
            Get
                Return "banking_format"
            End Get
        End Property
#End Region

    End Class

End Namespace