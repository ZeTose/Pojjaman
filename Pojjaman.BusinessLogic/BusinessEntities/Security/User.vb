Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration
Imports System.Reflection
Imports Longkong.Pojjaman.Gui.Components
Imports System.Security.Cryptography
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Imports Longkong.Core
Imports System.Text.RegularExpressions
Imports Longkong.Core.AddIns

Namespace Longkong.Pojjaman.BusinessLogic
  Public Class BinaryHelper
    Public Shared Function RevertString(ByVal st As String) As String
      Dim chArr As Char() = st.ToCharArray
      Array.Reverse(chArr)
      st = ""
      For Each ch As Char In chArr
        st &= ch
      Next
      Return st
    End Function
    Public Shared Function DecToBin(ByVal Num As Integer) As String
      Do
        DecToBin = CStr(IIf(Num / 2 <> Int(Num / 2), 1, 0)) & DecToBin
        Num = CInt(Int(Num / 2))
      Loop Until Num = 0
    End Function
    Public Shared Function DecToBin(ByVal Num As Integer, ByVal digit As Integer) As String
      For i As Integer = 0 To digit - 1
        DecToBin = CStr(IIf(Num / 2 <> Int(Num / 2), 1, 0)) & DecToBin
        Num = CInt(Int(Num / 2))
      Next
    End Function
    Public Shared Function AndOperation(ByVal Num1 As Integer, ByVal Num2 As Integer, ByVal digit As Integer) As String
      Dim ret As Integer = Num1 And Num2
      Return DecToBin(ret, digit)
    End Function
    Public Shared Function OrOperation(ByVal Num1 As Integer, ByVal Num2 As Integer, ByVal digit As Integer) As String
      Dim ret As Integer = Num1 Or Num2
      Return DecToBin(ret, digit)
    End Function
    Public Shared Function BinToDec(ByVal ParamArray values() As Boolean) As Integer
      Dim ret As String = ""
      For Each value As Boolean In values
        ret &= BoolToIntString(value)
      Next
      If ret.Length = 0 Then
        Return -1
      End If
      Return Convert.ToInt32(ret, 2)
    End Function
    Private Shared Function BoolToIntString(ByVal value As Boolean) As String
      If value Then
        Return "1"
      End If
      Return "0"
    End Function
  End Class
  Public Interface IHasAccess
    Property AccessCollection() As AccessCollection
    Sub SetAccessCollection()
  End Interface
  Public Class User
    Inherits PersonEntityBase
    Implements IHasAccess

    Public Const SALT As String = "cdc37908-cfcd-40da-84da-446bc83cbfce"

#Region "Members"
    Private user_password As String
    Private m_accessCollection As AccessCollection
    Private m_costCenterUserAccessCollection As CostCenterUserAccessCollection
    Private m_approvalDocLevelCollection As ApprovalDocLevelCollection
    Private m_signature As Image

    Private Shared m_sharedUserTable As DataTable
#End Region

#Region "Constructors"
    Shared Sub New()
      RefreshUserTable()
    End Sub
    Property CanSeeAllDocType1 As Boolean
    Property CanSeeAllDocType2 As Boolean
    Property CanSeeAllDocType0 As Boolean
    Public Shared Sub RefreshUserTable()
      Dim connString As String = RecentCompanies.CurrentCompany.ConnectionString
      Dim ds As DataSet = SqlHelper.ExecuteDataset(connString _
      , CommandType.StoredProcedure _
      , "GetUser" _
      )
      m_sharedUserTable = ds.Tables(0)
    End Sub
    Public Sub New()
      MyBase.New()
    End Sub
    Public Sub New(ByVal id As Integer)
      Dim drs As DataRow() = m_sharedUserTable.Select("user_id=" & id)
      If drs.Length = 1 Then
        Construct(drs(0), "")
      End If
    End Sub
    Public Sub New(ByVal code As String)
      Dim drs As DataRow() = m_sharedUserTable.Select("user_code='" & code & "'")
      If drs.Length = 1 Then
        Construct(drs(0), "")
      End If
    End Sub
    Public Sub New(ByVal dr As DataRow, ByVal aliasPrefix As String)
      MyBase.New(dr, aliasPrefix)
    End Sub
    Public Sub New(ByVal code As String, ByVal pass As String)
      pass = GeneratePassword(pass)
      Dim sql As String = "select * from [user] where [user_id] = (select [user_id] from [user] where [user_code] = '" & code & "' and [user_password]= '" & pass & "')"
      LoadEntity(sql)
    End Sub
    Protected Overloads Overrides Sub Construct(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
      Dim dr As DataRow = ds.Tables(0).Rows(0)
      Construct(dr, aliasPrefix)
    End Sub
    Protected Overloads Overrides Sub Construct(ByVal dr As System.Data.DataRow, ByVal aliasPrefix As String)
      'ห้าม Mybase.Construct .... เด็ดขาด !!!
      With Me
        If Not dr.IsNull(aliasPrefix & "user_id") Then
          .Id = CInt(dr(aliasPrefix & "user_id"))
        End If

        If Not dr.IsNull(aliasPrefix & "user_code") Then
          .Code = CStr(dr(aliasPrefix & "user_code"))
        End If

        If Not dr.IsNull(aliasPrefix & "user_name") Then
          .Name = CStr(dr(aliasPrefix & "user_name"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "user_password") Then
          If Not dr.IsNull(aliasPrefix & "user_password") Then
            .user_password = CStr(dr(aliasPrefix & "user_password"))
          End If
        End If

        Dim deh As New DataRowHelper(dr)
        Me.CanSeeAllDocType1 = deh.GetValue(Of Boolean)("user_CanSeeAllDocType1")
        Me.CanSeeAllDocType2 = deh.GetValue(Of Boolean)("user_CanSeeAllDocType2")
        Me.CanSeeAllDocType0 = deh.GetValue(Of Boolean)("user_CanSeeAllDocType0")
      End With
      'Me.CostCenterUserAccessCollection = New CostCenterUserAccessCollection(Me)
      'Me.ApprovalDocLevelCollection = New ApprovalDocLevelCollection(Me)
    End Sub
    Public Overloads Sub LoadImage(ByVal reader As IDataReader)
      m_signature = Field.GetImage(reader, "user_signature")
    End Sub
    Public Overloads Sub LoadImage()
      If Not Me.Originated Then
        Return
      End If

      Dim sqlConString As String = RecentCompanies.CurrentCompany.ConnectionString
      Dim conn As New SqlConnection(sqlConString)
      Dim sql As String = "select user_signature from userimage where [user_id] = " & Me.Id
      Dim reader As SqlDataReader
      Try
        conn.Open()
        Dim cmd As SqlCommand = conn.CreateCommand
        cmd.CommandText = sql
        reader = cmd.ExecuteReader((CommandBehavior.KeyInfo Or CommandBehavior.CloseConnection))
        If reader.Read Then
          LoadImage(reader)
        End If
      Catch ex As Exception
        MessageBox.Show(ex.ToString)
      Finally
        conn.Close()
        reader = Nothing
        conn = Nothing
      End Try
    End Sub
#End Region

#Region "Properties"
    Public Property AccessCollection() As AccessCollection Implements IHasAccess.AccessCollection
      Get
        Return m_accessCollection
      End Get
      Set(ByVal Value As AccessCollection)
        m_accessCollection = Value
      End Set
    End Property
    Public Property CostCenterUserAccessCollection() As CostCenterUserAccessCollection
      Get
        If m_costCenterUserAccessCollection Is Nothing Then
          m_costCenterUserAccessCollection = New CostCenterUserAccessCollection(Me)
        End If
        Return m_costCenterUserAccessCollection
      End Get
      Set(ByVal Value As CostCenterUserAccessCollection)
        m_costCenterUserAccessCollection = Value
      End Set
    End Property
    Public Property ApprovalDocLevelCollection() As ApprovalDocLevelCollection
      Get
        If m_approvalDocLevelCollection Is Nothing Then
          m_approvalDocLevelCollection = New ApprovalDocLevelCollection(Me)
        End If
        Return m_approvalDocLevelCollection
      End Get
      Set(ByVal Value As ApprovalDocLevelCollection)
        m_approvalDocLevelCollection = Value
      End Set
    End Property
    Public ReadOnly Property Role() As Role
      Get

      End Get
    End Property
    Public Property Password() As String
      Get
        Return Me.user_password
      End Get
      Set(ByVal Value As String)
        user_password = Value
        Me.OnPropertyChanged(Me, New PropertyChangedEventArgs)
      End Set
    End Property
    Public Property Signature() As Image
      Get
        Return m_signature
      End Get
      Set(ByVal Value As Image)
        m_signature = Value
        OnPropertyChanged(Me, New PropertyChangedEventArgs)
      End Set
    End Property
    Public Overrides ReadOnly Property ClassName() As String
      Get
        Return "User"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.User.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.User"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.User"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.User.ListLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property Prefix() As String
      Get
        Return "user"
      End Get
    End Property
    Public Overrides ReadOnly Property GetSprocName() As String
      Get
        Return "GetUser"
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

#Region "Methods"
    Private Shared Function GetLKConString(ByVal conString As String) As String
      Dim serverName As String = "."
      Dim re As New Regex("Data Source=(.*)")
      Dim reDB As New Regex("Initial Catalog=(.*);")
      Dim m As Match = re.Match(conString)
      Dim databaseName As String = "master"
      If m.Success Then
        serverName = m.Groups(1).Value.Replace(";", "")
      End If
      m = reDB.Match(conString)
      If m.Success Then
        databaseName = m.Groups(1).Value
      End If
      Dim userName As String = "50e6d914-044f-45f8-b209-545a6260bb42"
      Dim password As String = "1f4bee680ca047a114e8bc900c8ec921"

      Dim connectionString As String = String.Empty
      connectionString &= ("Data Source=" + serverName)

      connectionString &= (";initial catalog=" + databaseName)

      connectionString &= (";user id=" + userName + ";password=" + password)

      connectionString &= (";pooling=false;application name=Longkong - Pojjaman")
      Return connectionString
    End Function
    Private Shared Function ChangeDB(ByVal conString As String) As String
      Dim re As New Regex("(Initial Catalog=)(.*);")
      Dim m As Match = re.Match(conString)
      If m.Success Then
        conString = re.Replace(conString, "$1master;")
      End If
      Return conString
    End Function
    Public Shared Function GetLicenseInfo() As DataSet
      Dim con As New SqlConnection(ChangeDB(RecentCompanies.CurrentCompany.ConnectionString))
      con.Open()
      Dim cmd As New SqlCommand
      cmd.CommandText = _
      "if not exists(select * from sysobjects where xtype = 'v' and name = 'licenseregister') " & _
      "begin " & _
      "   if not exists(select * from sysobjects where xtype = 'v' and name = 'demoregister') " & _
      "   begin " & _
      "      select 1 [license], (select sid from syslogins where name = '50e6d914-044f-45f8-b209-545a6260bb42') [machinecode] " & _
      "      ,null [pepper], 30 [licenseday] " & _
      "   end " & _
      "   else " & _
      "   begin " & _
      "      select license, (select sid from syslogins where name = '50e6d914-044f-45f8-b209-545a6260bb42') [machinecode] " & _
      "      ,pepper, licenseday from demoregister " & _
      "   end " & _
      "End " & _
      "else " & _
      "begin " & _
      "select license " & _
      ", (select sid from syslogins where name = '50e6d914-044f-45f8-b209-545a6260bb42') [machinecode] " & _
      ", pepper " & _
      ", null [licenseday] " & _
      "from licenseregister " & _
      "end; " & _
      "declare @licenseday numeric(18,0) " & _
      "set @licenseday = 30  " & _
      "if exists (select * from sysobjects where xtype = 'v' and name = 'demoregister')  " & _
      "begin select @licenseday = licenseday from demoregister end; " & _
      "select count(*) [hostnumber] " & _
      "from (" & _
      "select distinct dbid,hostname,net_address from sysprocesses " & _
      "where loginame = '50e6d914-044f-45f8-b209-545a6260bb42'" & _
      ")[sysprocesses]; " & _
      "select isnull(sum(remainingday),0) [remainingday] " & _
      "from ( " & _
      "select datediff(day,getdate(),dateadd(day,@licenseday,createdate)) [remainingday] " & _
      "from syslogins where name = '50e6d914-044f-45f8-b209-545a6260bb42'" & _
      ")[syslogins]"

      cmd.CommandType = CommandType.Text
      cmd.Connection = con
      Dim da As New SqlDataAdapter(cmd)
      Dim ds As New DataSet
      da.Fill(ds)

      Return ds
    End Function
    Public Shared Function GetMD5Hash(ByVal s As String) As String
      Dim md5Object As New MD5CryptoServiceProvider
      Dim bytesToHash() As Byte = System.Text.Encoding.ASCII.GetBytes(s)
      bytesToHash = md5Object.ComputeHash(bytesToHash)
      Return BytesToHexSmall(bytesToHash)
    End Function
    Private Shared con As SqlConnection
    Public Shared Sub HitDB()
      Dim conStr As String = GetLKConString(RecentCompanies.CurrentCompany.ConnectionString)
      'Return
      If con Is Nothing Then
        con = New SqlConnection(conStr)
      End If
      Try
        If con.State <> ConnectionState.Open Then
          con.Open()
        End If
        Dim cmd As New SqlCommand
        cmd.CommandText = "select 1"
        cmd.CommandType = CommandType.Text
        cmd.Connection = con
        cmd.ExecuteNonQuery()
      Catch ex As Exception
        MessageBox.Show("Error checking Liecnes:" & ex.Message)
        Application.ExitThread()
        Application.Exit()
      Finally
        'con.Close()
      End Try
    End Sub
    Public Sub SetAccessCollection() Implements IHasAccess.SetAccessCollection
      m_accessCollection = New AccessCollection(Me)
    End Sub
    Public Shared Function BytesToHex(ByVal arr() As Byte) As String
      Dim res As New System.Text.StringBuilder
      For Each b As Byte In arr
        res.AppendFormat("{0:X2}", b)
      Next
      Return res.ToString
    End Function
    Public Shared Function BytesToHexSmall(ByVal arr() As Byte) As String
      Dim ret As String = ""
      For Each b As Byte In arr
        ret &= b.ToString("x2")
      Next
      Return ret.ToString
    End Function
    Public Shared Function GeneratePassword(ByVal plainText As String) As String
      Dim salt() As Byte = {3, 45, 78, 123, 9, 77}
      Dim pdb As New PasswordDeriveBytes(plainText, salt)
      Dim bytes() As Byte = pdb.GetBytes(32)
      Return BytesToHex(bytes)
    End Function
    Public Function ValidPassword(ByVal checkingPass As String) As Boolean
      If GeneratePassword(checkingPass) = Me.user_password Then
        Return True
      End If
      Return False
    End Function
    Public Shared Function ValidUser(ByVal userInQuestion As User) As Boolean
      If New User(userInQuestion.Name, userInQuestion.Password).Originated Then
        Return True
      End If
      Return False
    End Function
    Public Shared Function ValidUser(ByVal name As String, ByVal pass As String) As Boolean
      If New User(name, pass).Originated Then
        Return True
      End If
      Return False
    End Function
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' AccessValue (แบบ TextBox)
    ''' </summary>
    ''' <param name="access"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Administrator]	11/01/2549	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Function GetAccessValue(ByVal access As Access) As Decimal
      Try
        Dim ds As DataSet = SqlHelper.ExecuteDataset( _
                Me.ConnectionString _
                , CommandType.StoredProcedure _
                , "GetAccessValueForUser" _
                , New SqlParameter("@user_id", Me.Id) _
                , New SqlParameter("@access_id", access.Id) _
                )
        If ds.Tables(0).Rows.Count > 0 Then
          If ds.Tables(0).Rows(0).IsNull(0) Then
            Return Nothing
          End If
          Return CDec(ds.Tables(0).Rows(0)(0))
        End If
        Return Nothing
      Catch ex As Exception
        MessageBox.Show(ex.Message)
      End Try
    End Function
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' AccessValue (แบบ CheckBox)
    ''' </summary>
    ''' <param name="access"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[KRISS]	11/01/2549	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Function GetAccess(ByVal access As Access) As Integer
      Try
        Dim ds As DataSet = SqlHelper.ExecuteDataset( _
                Me.ConnectionString _
                , CommandType.StoredProcedure _
                , "GetAccessForUser" _
                , New SqlParameter("@user_id", Me.Id) _
                , New SqlParameter("@access_id", access.Id) _
                )
        If ds.Tables(0).Rows.Count > 0 Then
          If ds.Tables(0).Rows(0).IsNull(0) Then
            Return Nothing
          End If
          Return CInt(ds.Tables(0).Rows(0)(0))
        End If
        Return Nothing
      Catch ex As Exception
        MessageBox.Show(ex.Message)
      End Try
    End Function
    Private Sub ResetID(ByVal oldid As Integer)
      Me.Id = oldid
    End Sub
    Public Overloads Overrides Function Save(ByVal currentUserId As Integer) As SaveErrorException
      With Me
        Dim AllDocType0 As Boolean
        Dim AllDocType1 As Boolean
        Dim AllDocType2 As Boolean

        Dim returnVal As System.Data.SqlClient.SqlParameter = New SqlParameter
        returnVal.ParameterName = "RETURN_VALUE"
        returnVal.DbType = DbType.Int32
        returnVal.Direction = ParameterDirection.ReturnValue
        returnVal.SourceVersion = DataRowVersion.Current
        Dim paramArrayList As New ArrayList

        paramArrayList.Add(returnVal)
        If Me.Originated Then
          paramArrayList.Add(New SqlParameter("@user_id", Me.Id))
        End If

        Dim theTime As Date = Now
        Dim theUser As New User(currentUserId)

        paramArrayList.Add(New SqlParameter("@user_code", Me.Code))
        paramArrayList.Add(New SqlParameter("@user_password", Me.Password))
        paramArrayList.Add(New SqlParameter("@user_name", Me.Name))

        'ถ้าไม่ใช่ Customize ทุกคนต้องสามารถเห็นเอกสารได้หมด (ตามสิทธิ์ CostCenter) ==============
        AllDocType1 = False
        AllDocType2 = False
        AllDocType0 = True
        If Customizations.ValidCustomize("Pojjaman.Base.Form.VArch") Then
          AllDocType1 = Me.CanSeeAllDocType1
          AllDocType2 = Me.CanSeeAllDocType2
          AllDocType0 = Me.CanSeeAllDocType0
        End If
        '===========================================================================

        paramArrayList.Add(New SqlParameter("@user_CanSeeAllDocType1", AllDocType1))
        paramArrayList.Add(New SqlParameter("@user_CanSeeAllDocType2", AllDocType2))
        paramArrayList.Add(New SqlParameter("@user_CanSeeAllDocType0", AllDocType0))


        'SetOriginEditCancelStatus(paramArrayList, currentUserId, theTime) '********* Todo: Revise

        ' สร้าง SqlParameter จาก ArrayList ...
        Dim sqlparams() As SqlParameter
        sqlparams = CType(paramArrayList.ToArray(GetType(SqlParameter)), SqlParameter())
        Dim trans As SqlTransaction
        Dim conn As New SqlConnection(Me.ConnectionString)
        conn.Open()
        trans = conn.BeginTransaction()

        Dim oldid As Integer = Me.Id

        Try
          Me.ExecuteSaveSproc(conn, trans, returnVal, sqlparams, theTime, theUser)
          If IsNumeric(returnVal.Value) Then
            Select Case CInt(returnVal.Value)
              Case -1, -2
                trans.Rollback()
                Me.ResetID(oldid)
                Return New SaveErrorException(returnVal.Value.ToString)
              Case Else
            End Select
          ElseIf IsDBNull(returnVal.Value) OrElse Not IsNumeric(returnVal.Value) Then
            trans.Rollback()
            Me.ResetID(oldid)
            Return New SaveErrorException(returnVal.Value.ToString)
          End If

          If Not Me.AccessCollection Is Nothing Then
            SaveDetail(Me.Id, conn, trans)
          End If

          Dim saveerror As SaveErrorException
          If Not Me.m_costCenterUserAccessCollection Is Nothing AndAlso Me.m_costCenterUserAccessCollection.Count >= 0 Then
            saveerror = Me.m_costCenterUserAccessCollection.Save(Me)
            If Not IsNumeric(saveerror.Message) Then
              Throw New Exception(saveerror.Message)
            End If
          End If
          If Not Me.m_approvalDocLevelCollection Is Nothing AndAlso Me.m_approvalDocLevelCollection.Count >= 0 Then
            saveerror = Me.m_approvalDocLevelCollection.Save(Me)
            If Not IsNumeric(saveerror.Message) Then
              Throw New Exception(saveerror.Message)
            End If
          End If

          ' Update UserImage & UserSignature ...
          If Me.Originated Then
            paramArrayList = New ArrayList
            paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_id", Me.Id))
            paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_signature", Pojjaman.Graphix.Imaging.ConvertImageToByteArray(Me.Signature)))
            Dim imageparams() As SqlParameter
            imageparams = CType(paramArrayList.ToArray(GetType(SqlParameter)), SqlParameter())
            SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "InsertUserImage", imageparams)
          End If

          trans.Commit()
          Return New SaveErrorException(returnVal.Value.ToString)
        Catch ex As SqlException
          trans.Rollback()
          Return New SaveErrorException(ex.ToString)
        Catch ex As Exception
          trans.Rollback()
          Return New SaveErrorException(ex.ToString)
        Finally
          RefreshUserTable()
          conn.Close()
        End Try
      End With
    End Function
    Private Function SaveDetail(ByVal parentID As Integer, ByVal conn As SqlConnection, ByVal trans As SqlTransaction) As Integer

      Dim da As New SqlDataAdapter("Select * from useraccess where useraccess_user=" & Me.Id, conn)
      Dim cmdBuilder As New SqlCommandBuilder(da)

      Dim ds As New DataSet

      da.SelectCommand.Transaction = trans

      'ต้องอยู่ต่อจาก da.SelectCommand.Transaction = trans
      cmdBuilder.GetDeleteCommand.Transaction = trans
      cmdBuilder.GetInsertCommand.Transaction = trans
      cmdBuilder.GetUpdateCommand.Transaction = trans

      da.Fill(ds, "useraccess")

      Dim dbCount As Integer = ds.Tables("useraccess").Rows.Count
      If Not Me.AccessCollection Is Nothing Then
        With ds.Tables("useraccess")
          For Each row As DataRow In .Rows
            row.Delete()
          Next
          For Each myAcess As Access In Me.AccessCollection
            Dim dr As DataRow = .NewRow
            dr("useraccess_user") = Me.Id
            dr("useraccess_access") = myAcess.Id
            dr("useraccess_value") = myAcess.CurrentValue
            dr("useraccess_accessvalue") = myAcess.Current
            .Rows.Add(dr)
          Next
        End With
      End If
      Dim dt As DataTable = ds.Tables("useraccess")
      ' First process deletes.
      da.Update(dt.Select(Nothing, Nothing, DataViewRowState.Deleted))
      ' Next process updates.
      da.Update(dt.Select(Nothing, Nothing, DataViewRowState.ModifiedCurrent))
      ' Finally process inserts.
      da.Update(dt.Select(Nothing, Nothing, DataViewRowState.Added))
    End Function
#End Region

#Region "Shared"
    Public Shared Function GetUser(ByVal txtCode As TextBox, ByVal txtName As TextBox, ByRef oldUser As User) As Boolean
      Dim myUser As New User(txtCode.Text)
      If txtCode.Text.Length <> 0 AndAlso Not myUser.Originated Then
        MessageBox.Show(txtCode.Text & " ไม่มีในระบบ")
        myUser = oldUser
      End If
      txtCode.Text = myUser.Code
      txtName.Text = myUser.Name
      If oldUser.Id <> myUser.Id Then
        oldUser = myUser
        Return True
      End If
      Return False
    End Function
    Public Shared Function MaxLevel() As Integer
      Dim ds As DataSet = SqlHelper.ExecuteDataset(RecentCompanies.CurrentCompany.ConnectionString _
    , CommandType.Text, "select max(app_level) [maxLevel] from dbo.ApprovalDocLevel")
      If ds.Tables(0).Rows.Count <> 0 Then
        If IsNumeric(ds.Tables(0).Rows(0)(0)) Then
          Return CInt(ds.Tables(0).Rows(0)(0))
        End If
      End If
      Return 0
    End Function
#End Region

#Region "Delete"
    Public Overrides ReadOnly Property CanDelete() As Boolean
      Get
        Return True
      End Get
    End Property
    Public Overrides Function Delete() As SaveErrorException
      If Not Me.Originated Then
        Return New SaveErrorException("${res:Global.Error.NoIdError}")
      End If
      Dim myMessage As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      Dim format(0) As String
      format(0) = Me.Code
      If Not myMessage.AskQuestionFormatted("${res:Global.ConfirmDeleteUser}", format) Then
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
        SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "DeleteUser", New SqlParameter() {New SqlParameter("@user_id", Me.Id), returnVal})
        If IsNumeric(returnVal.Value) Then
          Select Case CInt(returnVal.Value)
            Case -1
              trans.Rollback()
              Return New SaveErrorException("${res:Global.UserIsReferencedCannotBeDeleted}")
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

  Public Class Role
    Inherits SimpleBusinessEntityBase
    Implements IHasAccess

#Region "Members"
    Private m_name As String
    Private m_accessCollection As AccessCollection
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
      MyBase.New(dr, aliasPrefix)
    End Sub
    Public Sub New(ByVal user As User)
    End Sub
    Protected Overloads Overrides Sub Construct(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
      Dim dr As DataRow = ds.Tables(0).Rows(0)
      Construct(dr, aliasPrefix)
    End Sub
    Protected Overloads Overrides Sub Construct(ByVal dr As System.Data.DataRow, ByVal aliasPrefix As String)
      MyBase.Construct(dr, aliasPrefix)
      With Me
        If Not dr.IsNull(aliasPrefix & "role_id") Then
          .Id = CInt(dr(aliasPrefix & "role_id"))
        End If

        If Not dr.IsNull(aliasPrefix & "role_code") Then
          .Code = CStr(dr(aliasPrefix & "role_code"))
        End If

        If Not dr.IsNull(aliasPrefix & "role_name") Then
          .m_name = CStr(dr(aliasPrefix & "role_name"))
        End If
      End With
    End Sub
#End Region

#Region "Properties"
    Public Property AccessCollection() As AccessCollection Implements IHasAccess.AccessCollection
      Get
        Return m_accessCollection
      End Get
      Set(ByVal Value As AccessCollection)
        m_accessCollection = Value
      End Set
    End Property
    Public Property Name() As String
      Get
        Return Me.m_name
      End Get
      Set(ByVal Value As String)
        m_name = Value
        Me.OnPropertyChanged(Me, New PropertyChangedEventArgs)
      End Set
    End Property
    Public Overrides ReadOnly Property ClassName() As String
      Get
        Return "Role"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.Role.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.Role"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.Role"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.Role.ListLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property Prefix() As String
      Get
        Return "role"
      End Get
    End Property
    Public Overrides ReadOnly Property GetSprocName() As String
      Get
        Return "GetRole"
      End Get
    End Property
    Public Overrides ReadOnly Property TabPageText() As String
      Get
        Return Me.ClassName & ":" & Me.Code
      End Get
    End Property
#End Region

#Region "Methods"
    Public Sub SetAccessCollection() Implements IHasAccess.SetAccessCollection
      m_accessCollection = New AccessCollection(Me)
    End Sub
    Public Function GetAccessValue(ByVal access As Access) As Decimal
      'ค่าเวลาที่ Access เป็นแบบใส่ค่าโดยตรง
      Try
        Dim ds As DataSet = SqlHelper.ExecuteDataset( _
                Me.ConnectionString _
                , CommandType.StoredProcedure _
                , "GetAccessValueForRole" _
                , New SqlParameter("@role_id", Me.Id) _
                , New SqlParameter("@access_id", access.Id) _
                )
        If ds.Tables(0).Rows.Count > 0 Then
          If ds.Tables(0).Rows(0).IsNull(0) Then
            Return Nothing
          End If
          Return CDec(ds.Tables(0).Rows(0)(0))
        End If
        Return Nothing
      Catch ex As Exception
        MessageBox.Show(ex.Message)
      End Try
    End Function
    Public Function GetAccess(ByVal access As Access) As Integer
      'ค่าของ Access
      Try
        Dim ds As DataSet = SqlHelper.ExecuteDataset( _
                Me.ConnectionString _
                , CommandType.StoredProcedure _
                , "GetAccessForRole" _
                , New SqlParameter("@role_id", Me.Id) _
                , New SqlParameter("@access_id", access.Id) _
                )
        If ds.Tables(0).Rows.Count > 0 Then
          If ds.Tables(0).Rows(0).IsNull(0) Then
            Return Nothing
          End If
          Return CInt(ds.Tables(0).Rows(0)(0))
        End If
        Return Nothing
      Catch ex As Exception
        MessageBox.Show(ex.Message)
      End Try
    End Function
    Public Overloads Overrides Function Save(ByVal currentUserId As Integer) As SaveErrorException
      With Me
        Dim returnVal As System.Data.SqlClient.SqlParameter = New SqlParameter
        returnVal.ParameterName = "RETURN_VALUE"
        returnVal.DbType = DbType.Int32
        returnVal.Direction = ParameterDirection.ReturnValue
        returnVal.SourceVersion = DataRowVersion.Current
        Dim paramArrayList As New ArrayList

        paramArrayList.Add(returnVal)
        If Me.Originated Then
          paramArrayList.Add(New SqlParameter("@role_id", Me.Id))
        End If

        Dim theTime As Date = Now
        Dim theUser As New User(currentUserId)

        paramArrayList.Add(New SqlParameter("@role_code", Me.Code))
        paramArrayList.Add(New SqlParameter("@role_name", Me.Name))

        'SetOriginEditCancelStatus(paramArrayList, currentUserId, theTime) '********* Todo: Revise

        ' สร้าง SqlParameter จาก ArrayList ...
        Dim sqlparams() As SqlParameter
        sqlparams = CType(paramArrayList.ToArray(GetType(SqlParameter)), SqlParameter())
        Dim trans As SqlTransaction
        Dim conn As New SqlConnection(Me.ConnectionString)
        conn.Open()
        trans = conn.BeginTransaction()
        Try
          Me.ExecuteSaveSproc(conn, trans, returnVal, sqlparams, theTime, theUser)
          SaveDetail(Me.Id, conn, trans)
          trans.Commit()
          Return New SaveErrorException(returnVal.Value.ToString)
        Catch ex As SqlException
          trans.Rollback()
          Return New SaveErrorException(ex.ToString)
        Catch ex As Exception
          trans.Rollback()
          Return New SaveErrorException(ex.ToString)
        Finally
          conn.Close()
        End Try
      End With
    End Function
    Private Function SaveDetail(ByVal parentID As Integer, ByVal conn As SqlConnection, ByVal trans As SqlTransaction) As Integer

      Dim da As New SqlDataAdapter("Select * from roleaccess where roleaccess_role=" & Me.Id, conn)
      Dim cmdBuilder As New SqlCommandBuilder(da)

      Dim ds As New DataSet

      da.SelectCommand.Transaction = trans

      'ต้องอยู่ต่อจาก da.SelectCommand.Transaction = trans
      cmdBuilder.GetDeleteCommand.Transaction = trans
      cmdBuilder.GetInsertCommand.Transaction = trans
      cmdBuilder.GetUpdateCommand.Transaction = trans

      da.Fill(ds, "roleaccess")

      Dim dbCount As Integer = ds.Tables("roleaccess").Rows.Count
      With ds.Tables("roleaccess")
        For Each row As DataRow In .Rows
          row.Delete()
        Next
        For Each myAcess As Access In Me.AccessCollection
          Dim dr As DataRow = .NewRow
          dr("roleaccess_role") = Me.Id
          dr("roleaccess_access") = myAcess.Id
          dr("roleaccess_value") = myAcess.CurrentValue
          dr("roleaccess_accessvalue") = myAcess.Current
          .Rows.Add(dr)
        Next
      End With
      Dim dt As DataTable = ds.Tables("roleaccess")
      ' First process deletes.
      da.Update(dt.Select(Nothing, Nothing, DataViewRowState.Deleted))
      ' Next process updates.
      da.Update(dt.Select(Nothing, Nothing, DataViewRowState.ModifiedCurrent))
      ' Finally process inserts.
      da.Update(dt.Select(Nothing, Nothing, DataViewRowState.Added))
    End Function
#End Region

  End Class

  Public Class Customizations
    Public Shared Function ValidCustomize(ByVal CompanyAddInsName As String) As Boolean
      '==Checking for addin วิศวพัฒน์
      Dim hasAddIns As Boolean = False
      For Each a As AddIn In AddInTreeSingleton.AddInTree.AddIns
        If a.FileName.ToLower.Contains(CompanyAddInsName.ToLower) Then
          hasAddIns = True
        End If
        'Trace.WriteLine(a.FileName)
      Next
      Return hasAddIns
    End Function
  End Class
End Namespace