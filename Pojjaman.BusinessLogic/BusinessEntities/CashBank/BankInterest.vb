Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration
Imports Longkong.Core.Services

Namespace Longkong.Pojjaman.BusinessLogic
    Public Class BankInterest
        Inherits Banking
        Implements IWitholdingTaxable

#Region "Member"
        Private m_whtcol As WitholdingTaxCollection
#End Region

#Region "Constructs"
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
                .BankingTransType = New BankingTransType(5)
                .m_whtcol = New WitholdingTaxCollection
                .m_whtcol.Direction = New WitholdingTaxDirection(0)
            End With
        End Sub
        Protected Overloads Overrides Sub Construct(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
            MyBase.Construct(ds, aliasPrefix)
        End Sub
        Protected Overloads Overrides Sub Construct(ByVal dr As System.Data.DataRow, ByVal aliasPrefix As String)
            MyBase.Construct(dr, aliasPrefix)
            With Me
                .m_whtcol = New WitholdingTaxCollection(Me)
                .m_whtcol.Direction = New WitholdingTaxDirection(0)
            End With
        End Sub
#End Region

#Region "Properties"
        Public Overrides ReadOnly Property WHT() As Decimal
            Get
                Return Me.m_whtcol.Amount
            End Get
        End Property
#End Region

#Region "Overrides"

        Public Overrides ReadOnly Property ClassName() As String
            Get
                Return "bankinterest"
            End Get
        End Property

        Public Overrides ReadOnly Property GetSprocName() As String
            Get
                Return "Get" & Me.ClassName
            End Get
        End Property

        Public Overrides ReadOnly Property DetailPanelTitle() As String
            Get
                Return "${res:Longkong.Pojjaman.BusinessLogic.BankInterest.DetailLabel}"
            End Get
        End Property
        Public Overrides ReadOnly Property DetailPanelIcon() As String
            Get
                Return "Icons.16x16.BankInterest"
            End Get
        End Property
        Public Overrides ReadOnly Property ListPanelIcon() As String
            Get
                Return "Icons.16x16.BankInterest"
            End Get
        End Property
        Public Overrides ReadOnly Property ListPanelTitle() As String
            Get
                Return "${res:Longkong.Pojjaman.BusinessLogic.BankInterest.ListLabel}"
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

#Region " LGLable Overrides "
        Public Overrides Function GetJournalEntries() As JournalEntryItemCollection
            Dim jiColl As New JournalEntryItemCollection

            Dim ji As New JournalEntryItem
            If Me.Amount > 0 AndAlso Not Me.Bankacct Is Nothing Then
                ' เงินฝากธนาคาร
                If Not Me.Bankacct.Account Is Nothing AndAlso Me.Bankacct.Account.Originated Then
                    ji.Amount = Me.Amount - Me.WHT
                    ji.Mapping = "G8.1"
                    ji.Account = Me.Bankacct.Account
                    ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
                    jiColl.Add(ji)
                End If

                ' ภาษีหัก ณ ที่จ่าย
                If Me.WHT > 0 Then
                    ji = New JournalEntryItem
                    ji.Amount = Me.WHT
                    ji.Mapping = "G8.2"
                    ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
          jiColl.Add(ji)
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
                    ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
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
                    ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
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
                    ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
              jiColl.Add(ji)
            End If
          Next
        End If

                ' ดอกเบี้ยรับ
                ji = New JournalEntryItem
                ji.Amount = Me.Amount
                If Not Me.Bankacct.Account Is Nothing AndAlso Me.Bankacct.Account.Originated Then
                    ji.Account = Me.Bankacct.Account
                End If
                ji.Mapping = "G8.3"
                ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
                jiColl.Add(ji)
            End If


            Return jiColl
        End Function
#End Region

#Region " IWitholdingTaxable "
        Public Property Date1() As Date Implements IWitholdingTaxable.Date
            Get
                Return Me.Docdate
            End Get
            Set(ByVal Value As Date)
                Me.Docdate = Value
            End Set
        End Property

        Public Function GetMaximumWitholdingTaxBase() As Decimal Implements IWitholdingTaxable.GetMaximumWitholdingTaxBase
      Return Me.Amount
        End Function

        Public Property Person() As IBillablePerson Implements IWitholdingTaxable.Person
            Get
                Return Me.Bankacct.BankBranch
            End Get
      Set(ByVal Value As IBillablePerson)
        Dim oldPerson As IBillablePerson = Me.Bankacct.BankBranch
        If (oldPerson Is Nothing AndAlso Not Value Is Nothing) _          OrElse (Not oldPerson Is Nothing AndAlso Not Value Is Nothing AndAlso oldPerson.Id <> Value.Id) Then          If Not Me.m_whtcol Is Nothing Then
            For Each wht As WitholdingTax In m_whtcol
              wht.UpdateRefDoc(Value, True)
            Next
          End If
        End If
        Me.Bankacct.BankBranch = CType(Value, BankBranch)
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

#Region " Save "
        Private Sub ResetID(ByVal oldid As Integer, ByVal oldje As Integer)
            Me.Id = oldid
            If Not Me.WitholdingTaxCollection Is Nothing Then
                Me.WitholdingTaxCollection.ResetId()
            End If
            Me.JournalEntry.Id = oldje
    End Sub
    Private Sub ResetCode(ByVal oldCode As String, ByVal oldautogen As Boolean)
      Me.Code = oldCode
      Me.AutoGen = oldautogen
    End Sub
        Public Overloads Overrides Function Save(ByVal currentUserId As Integer) As SaveErrorException
            'Return New SaveErrorException("Not Yet Implemented")
            Dim showStr As String
            If Me.Amount <= 0 Then
                showStr = "${res:Longkong.Pojjaman.Gui.Panels.IncomeFromBank.lblAmount}"
                Return New SaveErrorException("${res:Global.Error.ZeroValueMiss}", showStr)
            End If

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

      '---- AutoCode Format --------
      Dim oldcode As String
      Dim oldautogen As Boolean

      oldcode = Me.Code
      oldautogen = Me.AutoGen

      Me.JournalEntry.RefreshGLFormat()
      If Not AutoCodeFormat Is Nothing Then
        Select Case Me.AutoCodeFormat.CodeConfig.Value
          Case 0
            If Me.AutoGen Then 'And Me.Code.Length = 0 Then

              Me.Code = Me.GetNextCode
            End If
            Me.JournalEntry.DontSave = True
            Me.JournalEntry.Code = ""
            Me.JournalEntry.DocDate = Me.Docdate
          Case 1
            'ตาม entity
            If Me.AutoGen Then 'And Me.Code.Length = 0 Then
              Me.Code = Me.GetNextCode
            End If
            Me.JournalEntry.Code = Me.Code
          Case 2
            'ตาม gl
            If Me.JournalEntry.AutoGen Then
              Me.JournalEntry.Code = JournalEntry.GetNextCode
            End If
            Me.Code = Me.JournalEntry.Code
          Case Else
            'แยก
            If Me.AutoGen Then 'And Me.Code.Length = 0 Then
              Me.Code = Me.GetNextCode
            End If
            If Me.JournalEntry.AutoGen Then
              Me.JournalEntry.Code = JournalEntry.GetNextCode
            End If
        End Select
      Else
        If Me.AutoGen Then 'And Me.Code.Length = 0 Then
          Me.Code = Me.GetNextCode
        End If
        If Me.JournalEntry.AutoGen Then
          Me.JournalEntry.Code = JournalEntry.GetNextCode
        End If
      End If
      Me.JournalEntry.DocDate = Me.Docdate
      Me.AutoGen = False
      Me.JournalEntry.AutoGen = False


            If Me.JournalEntry.Status.Value = 4 Then
                Me.Status.Value = 4
                Me.m_whtcol.SetStatus(4)
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
            If Not Me.WitholdingTaxCollection Is Nothing Then
                Me.WitholdingTaxCollection.SaveOldID()
            End If
            Dim oldje As Integer = Me.JournalEntry.Id

            Try
                Me.ExecuteSaveSproc(conn, trans, returnVal, sqlparams, theTime, theUser)
                If IsNumeric(returnVal.Value) Then
                    Select Case CInt(returnVal.Value)
                        Case -1
                            trans.Rollback()
                            Me.ResetID(oldid, oldje)
              ResetCode(oldcode, oldautogen)
              Return New SaveErrorException(returnVal.Value.ToString)
                        Case -2
                            trans.Rollback()
                            Me.ResetID(oldid, oldje)
              ResetCode(oldcode, oldautogen)
              Return New SaveErrorException(returnVal.Value.ToString)
                        Case -5 'งวด
                            trans.Rollback()
                            Me.ResetID(oldid, oldje)
              ResetCode(oldcode, oldautogen)
              Return New SaveErrorException(returnVal.Value.ToString)
                        Case Else
                    End Select
                ElseIf IsDBNull(returnVal.Value) OrElse Not IsNumeric(returnVal.Value) Then
                    trans.Rollback()
                    Me.ResetID(oldid, oldje)
          ResetCode(oldcode, oldautogen)
          Return New SaveErrorException(returnVal.Value.ToString)
                End If
                Dim cc As CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
                If Not cc Is Nothing Then
                    Me.m_whtcol.SetCCId(cc.Id)
                End If

                If Not Me.m_whtcol Is Nothing AndAlso Me.m_whtcol.Count >= 0 Then
                    Dim saveWhtError As SaveErrorException = Me.m_whtcol.Save(currentUserId, conn, trans)
                    If Not IsNumeric(saveWhtError.Message) Then
                        trans.Rollback()
                        ResetID(oldid, oldje)
            ResetCode(oldcode, oldautogen)
            Return saveWhtError
                    Else
                        Select Case CInt(saveWhtError.Message)
                            Case -1, -2, -5
                                trans.Rollback()
                                ResetID(oldid, oldje)
                ResetCode(oldcode, oldautogen)
                Return saveWhtError
                            Case Else
                        End Select
                    End If
                End If


                'Me.JournalEntry.Code = Me.Code
                'Me.JournalEntry.DocDate = Me.Docdate
                If Me.JournalEntry.Status.Value = -1 Then
                    Me.JournalEntry.Status.Value = 3
                End If
                Dim saveJeError As SaveErrorException = Me.JournalEntry.Save(currentUserId, conn, trans)
                If Not IsNumeric(saveJeError.Message) Then
                    trans.Rollback()
                    Me.ResetID(oldid, oldje)
          ResetCode(oldcode, oldautogen)
          Return saveJeError
                Else
                    Select Case CInt(saveJeError.Message)
                        Case -1
                            trans.Rollback()
                            Me.ResetID(oldid, oldje)
              ResetCode(oldcode, oldautogen)
              Return saveJeError
                        Case -2
                            'Post ไปแล้ว
                            Return saveJeError
                        Case -5
                            trans.Rollback()
                            Me.ResetID(oldid, oldje)
              ResetCode(oldcode, oldautogen)
              Return saveJeError
                        Case Else
                    End Select
        End If

        '==============================AUTOGEN==========================================
        Dim saveAutoCodeError As SaveErrorException = SaveAutoCode(conn, trans)
        If Not IsNumeric(saveAutoCodeError.Message) Then
          trans.Rollback()
          ResetID(oldid, oldje)
          ResetCode(oldcode, oldautogen)
          Return saveAutoCodeError
        Else
          Select Case CInt(saveAutoCodeError.Message)
            Case -1, -2, -5
              trans.Rollback()
              ResetID(oldid, oldje)
              ResetCode(oldcode, oldautogen)
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
                Me.ResetID(oldid, oldje)
        ResetCode(oldcode, oldautogen)
        Return New SaveErrorException(returnVal.Value.ToString)
            Catch ex As SqlException
                trans.Rollback()
                Me.ResetID(oldid, oldje)
        ResetCode(oldcode, oldautogen)
        Return New SaveErrorException(returnVal.Value.ToString)
            Finally
                conn.Close()
            End Try
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
            If Not myMessage.AskQuestionFormatted("${res:Global.ConfirmDeleteBankInterest}", format) Then
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
                SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "DeleteBankInterest", New SqlParameter() {New SqlParameter("@" & Me.Prefix & "_id", Me.Id), returnVal})
                If IsNumeric(returnVal.Value) Then
                    Select Case CInt(returnVal.Value)
                        Case -1
                            trans.Rollback()
                            Return New SaveErrorException("${res:Global.BankInterestIsReferencedCannotBeDeleted}")
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
