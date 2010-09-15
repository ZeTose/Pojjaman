Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Services
Namespace Longkong.Pojjaman.BusinessLogic
  Public Class Account
    Inherits TreeBaseEntity
    Implements IControlItem

#Region "Members"
    Private acct_type As AccountType

    Private Shared m_idHash As Hashtable
    Private Shared m_codeHash As Hashtable
    Private Shared m_accountSet As DataTable
#End Region

#Region "Constructors"
    Shared Sub New()
      RefreshEntityTable()
    End Sub
    Public Shared Sub RefreshEntityTable()
      Dim connString As String = RecentCompanies.CurrentCompany.ConnectionString
      Dim ds As DataSet = SqlHelper.ExecuteDataset(connString _
      , CommandType.StoredProcedure _
      , "GetAccount" _
      )
      m_idHash = New Hashtable
      m_codeHash = New Hashtable
      m_accountSet = New DataTable
      Dim myTable As DataTable = ds.Tables(0)
      m_accountSet = SetAccountSet(ds.Tables(0))
      For Each row As DataRow In myTable.Rows
        Dim acct As New Account
        acct.Construct(row, "")
        m_idHash(acct.Id) = acct
        m_codeHash(acct.Code) = acct
      Next
    End Sub
    Public Shared Function GetAccountSet() As DataTable
      If m_accountSet Is Nothing Then
        Account.RefreshEntityTable()
      End If
      Return m_accountSet
    End Function
    Public Sub New()
      MyBase.New()
    End Sub
    Public Sub New(ByVal myParent As Account)
      MyBase.New(myParent)
      If myParent.Type Is Nothing Then
        myParent = New Account(myParent.Id)
      End If
      Me.Type = myParent.Type
    End Sub
    Public Sub New(ByVal id As Integer)
      If id = 0 Then
        Return
      End If
      Dim acct As Account = CType(m_idHash(id), Account)
      If Not acct Is Nothing Then
        Me.Clone(acct)
      End If
    End Sub
    Public Sub New(ByVal code As String)
      If code = "" Then
        Return
      End If
      Dim acct As Account = CType(m_codeHash(code), Account)
      If Not acct Is Nothing Then
        Me.Clone(acct)
      End If
    End Sub
    Private Sub Clone(ByVal acct As Account)
      Me.AlternateName = acct.AlternateName
      Me.AutoGen = acct.AutoGen
      Me.CancelDate = acct.CancelDate
      Me.Canceled = acct.Canceled
      Me.CancelPerson = acct.CancelPerson
      Me.Code = acct.Code
      Me.Edited = acct.Edited
      Me.Id = acct.Id
      Me.IsControlGroup = acct.IsControlGroup
      Me.IsDirty = acct.IsDirty
      Me.IsInitialized = acct.IsInitialized
      Me.LastEditDate = acct.LastEditDate
      Me.LastEditor = acct.LastEditor
      Me.Level = acct.Level
      Me.Name = acct.Name
      Me.NoSaveMessage = acct.NoSaveMessage
      Me.Originator = acct.Originator
      Me.OriginDate = acct.OriginDate
      Me.Parent = acct.Parent
      Me.Path = acct.Path
      Me.Status = acct.Status
      Me.Type = acct.Type
    End Sub
    Public Sub New(ByVal dr As DataRow, ByVal aliasPrefix As String)
      MyBase.New(dr, aliasPrefix)
    End Sub
    Protected Overloads Overrides Sub Construct(ByVal dr As System.Data.DataRow, ByVal aliasPrefix As String)
      MyBase.Construct(dr, aliasPrefix)
      With Me
        If dr.Table.Columns.Contains(aliasPrefix & "acct_type") AndAlso Not dr.IsNull(aliasPrefix & "acct_type") Then
          .acct_type = New AccountType(CInt(dr(aliasPrefix & "acct_type")))
        End If
      End With
    End Sub
#End Region

#Region "Properties"
    Public Overrides Property Parent() As TreeBaseEntity
      Get
        Return MyBase.Parent
      End Get
      Set(ByVal Value As TreeBaseEntity)
        Dim myParent As Account = CType(Value, Account)
        If myParent.Type Is Nothing Then
          myParent = New Account(myParent.Id)
        End If
        Me.Type = myParent.Type
        MyBase.Parent = Value
      End Set
    End Property
    Public Property Type() As AccountType
      Get
        Return acct_type
      End Get
      Set(ByVal Value As AccountType)
        acct_type = Value
      End Set
    End Property
    Public Overrides ReadOnly Property Prefix() As String
      Get
        Return "acct"
      End Get
    End Property
    Public Overrides ReadOnly Property ClassName() As String
      Get
        Return "Account"
      End Get
    End Property
    Public Overrides ReadOnly Property CodonName() As String
      Get
        Return "Account"
      End Get
    End Property
    Public Overrides ReadOnly Property [NameSpace]() As String
      Get
        Return "Longkong.Pojjaman.BusinessLogic"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.Account.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.Account"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.Account"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.Account.ListLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property UseSiteConnString() As Boolean
      Get
        Return True
      End Get
    End Property
#End Region

#Region "Methods"
    Private Shared Function SetAccountSet(ByVal dsSource As DataTable) As DataTable
      Dim dt As New DataTable
      dt.Columns.Add("acct_id")
      dt.Columns.Add("acct_code")
      dt.Columns.Add("acct_name")

      For Each row As DataRow In dsSource.Rows
        Dim drh As New DataRowHelper(row)
        If drh.GetValue(Of Integer)("acct_id") > 0 Then
          Dim dr As DataRow = dt.NewRow()
          dr("acct_id") = drh.GetValue(Of String)("acct_id")
          dr("acct_code") = drh.GetValue(Of String)("acct_code")
          dr("acct_name") = drh.GetValue(Of String)("acct_name")
          dt.Rows.Add(dr)
        End If
      Next

      Return dt
    End Function
    Public Function GetProfitToDate(ByVal endDate As Date) As Decimal
      Try
        If Not Me.Originated Then
          Return Nothing
        End If
        Dim ds As DataSet = SqlHelper.ExecuteDataset( _
                Me.ConnectionString _
                , CommandType.StoredProcedure _
                , "GetProfitToDate" _
                , New SqlParameter("@acct_id", Me.Id) _
                , New SqlParameter("@date", endDate) _
                )
        If ds.Tables(0).Rows.Count > 0 Then
          If IsNumeric(ds.Tables(0).Rows(0)(0)) Then
            Return CDec(ds.Tables(0).Rows(0)(0))
          End If
        End If
        Return 0
      Catch ex As Exception
        MessageBox.Show(ex.Message)
        Return 0
      End Try
    End Function
    Public Overloads Overrides Sub SetParent(ByVal parId As Integer)
      If parId <> Id Then
        Me.Parent = New Account(parId)
      Else
        Me.Parent = Nothing
      End If
    End Sub
    Public Overloads Overrides Sub SetParent(ByVal id As Integer, ByVal code As String, ByVal name As String)
      Dim parAcct As New Account
      parAcct.Id = id
      parAcct.Code = code
      parAcct.Name = name
      Me.Parent = parAcct
    End Sub
    Public Overloads Overrides Function Save(ByVal currentUserId As Integer) As SaveErrorException
      With Me
        If Me.Type Is Nothing OrElse Me.Type.Value < 0 Then
          Account.RefreshEntityTable()
          Return New SaveErrorException(Me.StringParserService.Parse("${res:Global.Error.NoAccountType}"))
        End If
        Dim parID As Object = 0
        If Not Me.Parent Is Nothing AndAlso Me.Parent.Originated Then
          parID = Me.Parent.Id
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
          paramArrayList.Add(New SqlParameter("@acct_id", Me.Id))
        End If

        Dim theTime As Date = Now
        Dim theUser As New User(currentUserId)

        paramArrayList.Add(New SqlParameter("@acct_code", Me.Code))
        paramArrayList.Add(New SqlParameter("@acct_name", Me.Name))
        paramArrayList.Add(New SqlParameter("@acct_altname", Me.AlternateName))
        paramArrayList.Add(New SqlParameter("@acct_parid", parID))
        paramArrayList.Add(New SqlParameter("@acct_level", Me.Level))
        paramArrayList.Add(New SqlParameter("@acct_path", Me.Path))
        paramArrayList.Add(New SqlParameter("@acct_control", Me.IsControlGroup))
        paramArrayList.Add(New SqlParameter("@acct_type", IIf(Me.Type Is Nothing, DBNull.Value, Me.Type.Value)))

        SetOriginEditCancelStatus(paramArrayList, currentUserId, theTime)

        ' สร้าง SqlParameter จาก ArrayList ...
        Dim sqlparams() As SqlParameter
        sqlparams = CType(paramArrayList.ToArray(GetType(SqlParameter)), SqlParameter())

        Dim trans As SqlTransaction
        Dim conn As New SqlConnection(Me.ConnectionString)

        If conn.State = ConnectionState.Open Then conn.Close()
        conn.Open()
        trans = conn.BeginTransaction()
        Dim oldid As Integer = Me.Id
        Try
          'Me.ExecuteSaveSproc(returnVal, sqlparams, theTime, theUser)
          Me.ExecuteSaveSproc(conn, trans, returnVal, sqlparams, theTime, theUser)

          '--------------------------SAVING EXTENDERS---------------------
          For Each extender As Object In Me.Extenders
            If TypeOf extender Is IExtender Then
              Dim saveDetailError As SaveErrorException = CType(extender, IExtender).Save(conn, trans)
              If Not IsNumeric(saveDetailError.Message) Then
                trans.Rollback()
                ResetID(oldid)
                Account.RefreshEntityTable()
                Return saveDetailError
              Else
                Select Case CInt(saveDetailError.Message)
                  Case -1, -2, -5
                    trans.Rollback()
                    ResetID(oldid)
                    Account.RefreshEntityTable()
                    Return saveDetailError
                  Case Else
                End Select
              End If
            End If
          Next
          '--------------------------END SAVING EXTENDERS---------------------
          trans.Commit()

          ' ตรวจจับ Error ของการ Save ...
          Account.RefreshEntityTable()
          Return New SaveErrorException(returnVal.Value.ToString)
        Catch ex As Exception
          trans.Rollback()
          Me.ResetID(oldid)
          Account.RefreshEntityTable()
          Return New SaveErrorException(ex.ToString)
        End Try
      End With
    End Function
    Private Sub ResetID(ByVal oldid As Integer)
      Me.Id = oldid
    End Sub
#End Region

#Region "Shared"
    Private Shared m_AllAccount As Hashtable
    Private Shared m_AccountCodeandId As Hashtable
    Public Shared ReadOnly Property AllAccount As Hashtable
      Get
        If m_AllAccount Is Nothing Then
          RefreshAllAccount()
        End If
        Return m_AllAccount
      End Get
    End Property
    Public Shared ReadOnly Property AllAccountCode As Hashtable
      Get
        If m_AccountCodeandId Is Nothing Then
          RefreshAllAccount()
        End If
        Return m_AccountCodeandId
      End Get
    End Property
    Public Shared Sub RefreshAllAccount()
      Account.m_AllAccount = New Hashtable
      Account.m_AccountCodeandId = New Hashtable
      Dim key As String = ""
      Dim code As String = ""
      Dim ds As DataSet = SqlHelper.ExecuteDataset(SimpleBusinessEntityBase.ConnectionString _
    , CommandType.StoredProcedure _
    , "GetAccountCollection" _
    , Nothing)
      If ds.Tables(0).Rows.Count >= 1 Then
        For Each row As DataRow In ds.Tables(0).Rows
          Dim drh As New DataRowHelper(row)
          key = CStr(drh.GetValue(Of Integer)("acct_id"))
          code = drh.GetValue(Of String)("acct_code")
          Account.m_AllAccount(key) = row
          Account.m_AccountCodeandId(code) = key
        Next
      End If
    End Sub
    Public Shared Function GetAccountById(ByVal Id As Integer) As Account
      Dim key As String = Id.ToString
      Dim row As DataRow = CType(AllAccount(key), DataRow)
      Dim cc As New Account
      SetAccount(cc, row)
      Return cc
    End Function
    Public Shared Function GetAccountByCode(ByVal code As String) As Account
      Dim id As Integer = CInt(AllAccountCode(code))
      Dim key As String = id.ToString
      Dim row As DataRow = CType(AllAccount(key), DataRow)
      Dim acct As New Account
      SetAccount(acct, row)
      Return acct
    End Function
    Private Shared Sub SetAccount(ByVal acct As Account, ByVal dr As DataRow)
      Dim drh As New DataRowHelper(dr)
      acct.Id = drh.GetValue(Of Integer)("acct_id")
      acct.Code = drh.GetValue(Of String)("acct_code")
      acct.Name = drh.GetValue(Of String)("acct_name")
      acct.Type = New AccountType(drh.GetValue(Of Integer)("acct_type"))
      acct.IsControlGroup = drh.GetValue(Of Boolean)("acct_control")
    End Sub
    Public Shared Function GetAccProfit(ByVal endDate As Date) As Decimal
      Dim acct As Account = GeneralAccount.GetDefaultGA(GeneralAccount.DefaultGAType.AccProfit).Account
      If acct Is Nothing OrElse Not acct.Originated Then
        Return Nothing
      End If
      Return acct.GetProfitToDate(endDate)
    End Function
    Public Shared Function GetAccount(ByVal txtCode As TextBox, ByVal txtName As TextBox, ByRef oldAcct As Account) As Boolean
      Dim acct As New Account(txtCode.Text)
      If txtCode.Text.Length <> 0 AndAlso Not acct.Valid Then
        MessageBox.Show(txtCode.Text & " ไม่มีในระบบ")
        acct = oldAcct
      ElseIf acct.IsControlGroup Then
        MessageBox.Show(acct.Code & "-" & acct.Name & " เป็นบัญชีคุม")
        acct = oldAcct
      End If
      txtCode.Text = acct.Code
      txtName.Text = acct.Name
      If oldAcct.Id <> acct.Id Then
        oldAcct = acct
        Return True
      End If
      Return False
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
      If Not myMessage.AskQuestionFormatted("${res:Global.ConfirmDeleteAccount}", format) Then
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
        SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "DeleteAccount", New SqlParameter() {New SqlParameter("@acct_id", Me.Id), returnVal})
        If IsNumeric(returnVal.Value) Then
          Select Case CInt(returnVal.Value)
            Case -1
              trans.Rollback()
              Return New SaveErrorException("${res:Global.AccountIsReferencedCannotBeDeleted}")
            Case Else
          End Select
        ElseIf IsDBNull(returnVal.Value) OrElse Not IsNumeric(returnVal.Value) Then
          trans.Rollback()
          Return New SaveErrorException(returnVal.Value.ToString)
        End If
        Me.DeleteRef(conn, trans)
        trans.Commit()
        If m_idHash.Contains(Me.Id) Then
          m_idHash.Remove(Me.Id)
        End If
        If m_codeHash.Contains(Me.Code) Then
          m_codeHash.Remove(Me.Code)
        End If
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

#Region "IControlItem"
    Public ReadOnly Property ControlMessage As String Implements IControlItem.ControlMessage
      Get
        Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
        Dim myString As String = myStringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.Account.ControlMessage}")   '"ไม่สามารถเลือก ผังบัญชี " + Me.Code + " - " + Me.Name + " เนื่องจากเป็นผังบัญชีคุม"
        myString = String.Format(myString, Me.Code + " - " + Me.Name)
        Return myString
      End Get
    End Property
#End Region


  End Class

  Public Class AccountType
    Inherits CodeDescription

#Region "Constructors"
    Public Sub New(ByVal value As Integer)
      MyBase.New(value)
    End Sub
#End Region

#Region "Properties"
    Public Overrides ReadOnly Property CodeName() As String
      Get
        Return "acct_type"
      End Get
    End Property
#End Region

  End Class
End Namespace