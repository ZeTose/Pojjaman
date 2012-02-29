Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration
Imports Longkong.Core.Services

Namespace Longkong.Pojjaman.BusinessLogic
  Public Class BankingStatus
    Inherits CodeDescription

#Region "Constructors"
    Public Sub New(ByVal value As Integer)
      MyBase.New(value)
    End Sub
#End Region

#Region "Properties"
    Public Overrides ReadOnly Property CodeName() As String
      Get
        Return "banking_status"
      End Get
    End Property
#End Region

  End Class

  Public Class BankTransfer
    Inherits Banking
    Implements IWitholdingTaxable, IPrintableEntity

#Region "Member"

    Private m_whtcol As WitholdingTaxCollection
    Private m_check As OutgoingCheck
    Private m_oldCheck As OutgoingCheck
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
        .BankingTransType = New BankingTransType(3)
        .m_whtcol = New WitholdingTaxCollection
        .m_whtcol.Direction = New WitholdingTaxDirection(1)
        .m_check = New OutgoingCheck(.CqCode)
        .m_oldCheck = New OutgoingCheck(.CqCode)
      End With
    End Sub
    Protected Overloads Overrides Sub Construct(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
      MyBase.Construct(ds, aliasPrefix)
      Me.m_check = New OutgoingCheck(Me.CqCode)
      Me.m_oldCheck = New OutgoingCheck(Me.CqCode)
    End Sub
    Protected Overloads Overrides Sub Construct(ByVal dr As System.Data.DataRow, ByVal aliasPrefix As String)
      MyBase.Construct(dr, aliasPrefix)
      With Me
        .m_whtcol = New WitholdingTaxCollection(Me)
        .m_whtcol.Direction = New WitholdingTaxDirection(1)
        .m_check = New OutgoingCheck(.CqCode)
        .m_oldCheck = New OutgoingCheck(.CqCode)
      End With
    End Sub
#End Region

#Region "Properties"
    Public Overrides ReadOnly Property WHT() As Decimal
      Get
        Return Me.m_whtcol.Amount
      End Get
    End Property
    Public Property Check() As OutgoingCheck
      Get
        Return Me.m_check
      End Get
      Set(ByVal Value As OutgoingCheck)
        Me.m_check = Value
      End Set
    End Property
    Public Property OldCheck() As OutgoingCheck
      Get
        Return Me.m_oldCheck
      End Get
      Set(ByVal Value As OutgoingCheck)
        Me.m_oldCheck = Value
      End Set
    End Property
#End Region

#Region "Overrides"

    Public Overrides ReadOnly Property ClassName() As String
      Get
        Return "banktransfer"
      End Get
    End Property

    Public Overrides ReadOnly Property GetSprocName() As String
      Get
        Return "Get" & Me.ClassName
      End Get
    End Property

    Public Overrides ReadOnly Property DetailPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.BankTransfer.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.BankTransfer"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.BankTransfer"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.BankTransfer.ListLabel}"
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

      ' Dr. เงินฝากธนาคาร(โอนเข้า)    ji.Mapping = "G6.1"
      SetGLG6_1(jiColl)
      ' Dr. ค่าธรรมเนียมธนาคาร                ji.Mapping = "G6.2"
      SetGLG6_2(jiColl)

      ' Cr. เงินฝากธนาคาร(โอนออก)    ji.Mapping = "G6.3"
      SetGLG6_3(jiColl)
      ' Cr. ภาษีหัก ณ ที่จ่าย                    ji.Mapping = "G6.4"
      SetGLG6_4(jiColl)
      ''Dr. Cr. เกี่ยวกับ check
      'SetGLCheck(jiColl)
      Return jiColl
    End Function
    ' DR. เงินฝากธนาคาร(ปลายทาง)
    Private Sub SetGLG6_1(ByVal jicoll As JournalEntryItemCollection)
      Dim amnt As Decimal = Me.Amount
      If amnt > 0 Then
        Dim ji As JournalEntryItem
        ji = New JournalEntryItem
        ji.Amount = Me.Amount
        ji.Mapping = "G6.1"
        If Me.BankacctDestinate.Account.Originated Then
          ji.Account = Me.BankacctDestinate.Account
        End If
        ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
        jicoll.Add(ji)
      End If
    End Sub
    ' DR. ค่าธรรมเนียมธนาคาร
    Private Sub SetGLG6_2(ByVal jicoll As JournalEntryItemCollection)
      If Me.BankCharge > 0 Then
        Dim ji As JournalEntryItem
        ji = New JournalEntryItem
        ji.Amount = Me.BankCharge
        ji.Mapping = "G6.2"
        ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
        jicoll.Add(ji)
      End If
    End Sub
    ' CR. เงินฝากธนาคาร(ต้นทาง)
    Private Sub SetGLG6_3(ByVal jicoll As JournalEntryItemCollection)
      If Me.Amount + Me.BankCharge - Me.WHT > 0 Then
        Dim ji As JournalEntryItem
        ji = New JournalEntryItem
        ji.Amount = Me.Amount + Me.BankCharge - Me.WHT
        ji.Mapping = "G6.3"
        If Me.Bankacct.Account.Originated Then
          ji.Account = Me.Bankacct.Account
        End If
        ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
        jicoll.Add(ji)
      End If
    End Sub
    ' CR. ภาษีหัก ณ ที่จ่าย
    Private Sub SetGLG6_4(ByVal jicoll As JournalEntryItemCollection)
      If Me.WHT > 0 Then
        Dim ji As JournalEntryItem
        ji = New JournalEntryItem
        ji.Amount = Me.WHT
        ji.Mapping = "G6.4"
        ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
        jicoll.Add(ji)
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
            jicoll.Add(ji)
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
            jicoll.Add(ji)
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
            jicoll.Add(ji)
          End If
        Next
      End If
    End Sub
    'Dr. Cr. เกี่ยวกับ check
    Private Sub SetGLCheck(ByVal jicoll As JournalEntryItemCollection)
      'Dim ji As New JournalEntryItem

      'Dim acct As New Account
      'acct = GeneralAccount.GetDefaultGA(GeneralAccount.DefaultGAType.CheckAdvence).Account
      'ji = New JournalEntryItem
      'ji.Mapping = "H2.1"
      'ji.Amount = Me.Check.Amount
      'If acct.Originated Then
      'ji.Account = acct
      'End If
      'ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
      'jicoll.Add(ji)

      'ji = New JournalEntryItem
      'ji.Mapping = "PM1.5"
      'ji.Amount = Me.Check.Amount
      'ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
      'jicoll.Add(ji)

    End Sub

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
        If (oldPerson Is Nothing AndAlso Not Value Is Nothing) _
          OrElse (Not oldPerson Is Nothing AndAlso Not Value Is Nothing AndAlso oldPerson.Id <> Value.Id) Then
          If Not Me.m_whtcol Is Nothing Then
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
    Private Sub ResetCode(ByVal oldCode As String, ByVal oldautogen As Boolean, ByVal oldJecode As String, ByVal oldjeautogen As Boolean)
      Me.Code = oldCode
      Me.AutoGen = oldautogen
      Me.JournalEntry.Code = oldJecode
      Me.JournalEntry.AutoGen = oldjeautogen
    End Sub
    Public Function BeforeSave(ByVal currentUserId As Integer) As SaveErrorException

      Dim ValidateError As SaveErrorException

      Dim cc As CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
      If Not cc Is Nothing Then
        Me.m_whtcol.SetCCId(cc.Id)
      End If

      ValidateError = Me.WitholdingTaxCollection.BeforeSave(currentUserId)
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
      'Return New SaveErrorException("Not Yet Implemented")
      Dim showStr As String
      'Dim oldCqCode As String
      'oldCqCode = Me.Check.CqCode
      'If Me.CqCode = Nothing OrElse Me.CqCode.Trim = "" Then
      'If Not CBool(Configuration.GetConfig("AllowNoCqCode")) Then
      'Return New SaveErrorException("${res:Global.Error.NotAllowNoCqCode}")
      'End If
      'End If
      '----------------------Create Check-----------------------
      'OneCheckPerPV
      'ให้ใส่ check ได้ทีหลัง
      'If Not (Me.Originated) AndAlso Not (Me.CqCode = Nothing OrElse Me.CqCode.Trim = "") Then

      Dim config As Object = Configuration.GetConfig("AllowNoCqCode")
      Dim AllowNoCqCode As Boolean = False
      If CBool(config) Then
        'If Me.Bankacct.Type.Value = 3 AndAlso Me.BankacctDestinate.Type.Value = 3 Then
        AllowNoCqCode = True
        'End If
      End If

      If Not AllowNoCqCode Then
        If Not Me.Check.Originated Then 'And Not (CBool(Configuration.GetConfig("OneCheckPerPV"))) Then
          Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
          Me.Check = New OutgoingCheck(Me.CqCode)
          If Me.Check Is Nothing Then
            Me.Check = New OutgoingCheck
          ElseIf Me.Check IsNot Nothing AndAlso (Me.Check.Id = 0 OrElse Me.Check.EntityId = 0) Then
            Me.Check = New OutgoingCheck
          End If
          If Not (Me.Check.Originated) Then
            If Not (msgServ.AskQuestionFormatted("${res:Global.Question.CreateNewOutGoingCheck}", New String() {Me.CqCode})) Then
              'Me.Check = New OutgoingCheck(oldCqCode)
              Return New SaveErrorException("${res:Global.Error.NotAllowNoCqCode}")
            End If
          Else
            Return New SaveErrorException("${res:Global.Error.AlreadyHasOutGoingCheck}")
          End If
        End If
      End If


      'End If
      '---------------------End Create Check-------------------------

      If Me.Bankacct Is Nothing OrElse Not Me.Bankacct.Originated Then
        Return New SaveErrorException("${res:Global.BankAccountTransferOutIsNothing}")
      End If

      If Me.BankacctDestinate Is Nothing OrElse Not Me.BankacctDestinate.Originated Then
        Return New SaveErrorException("${res:Global.BankAccountTransferInIsNothing}")
      End If

      If Me.Amount <= 0 Then
        showStr = "${res:Longkong.Pojjaman.Gui.Panels.BankTransferDetail.lblAmount}"
        Return New SaveErrorException("${res:Global.Error.ZeroValueMiss}", showStr)
      End If

      If Me.Bankacct.Id = Me.BankacctDestinate.Id Then
        Return New SaveErrorException("${res:Global.BankAccountOutDuplicateIn}")
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
      Dim oldjecode As String
      Dim oldjeautogen As Boolean

      oldcode = Me.Code
      oldautogen = Me.AutoGen
      oldjecode = Me.JournalEntry.Code
      oldjeautogen = Me.JournalEntry.AutoGen

      'Me.JournalEntry.RefreshGLFormat()
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
      Me.JournalEntry.RefreshGLFormat()
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_code", Me.Code))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_docdate", IIf(Me.Docdate.Equals(Date.MinValue), DBNull.Value, Me.Docdate)))

      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_bankacct", IIf(Me.Bankacct.Originated, Me.Bankacct.Id, DBNull.Value)))

      ' BankTransfer
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_cqcode", IIf(Not (Me.CqCode = Nothing OrElse Me.CqCode.Trim = ""), Me.CqCode, DBNull.Value)))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_bankacctdestinate", IIf(Me.BankacctDestinate.Originated, Me.BankacctDestinate.Id, DBNull.Value)))

      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_amount", Me.Amount))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_bankcharge", Me.BankCharge))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_wht", Me.WHT))

      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_format", Me.BankingFormat.Value))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_type", Me.BankingTransType.Value))

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
              ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
              Return New SaveErrorException(returnVal.Value.ToString)
            Case -2
              trans.Rollback()
              Me.ResetID(oldid, oldje)
              ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
              Return New SaveErrorException(returnVal.Value.ToString)
            Case -5 'งวด
              trans.Rollback()
              Me.ResetID(oldid, oldje)
              ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
              Return New SaveErrorException(returnVal.Value.ToString)
            Case Else
          End Select
        ElseIf IsDBNull(returnVal.Value) OrElse Not IsNumeric(returnVal.Value) Then
          trans.Rollback()
          Me.ResetID(oldid, oldje)
          ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
          Return New SaveErrorException(returnVal.Value.ToString)
        End If

       

        If Not Me.m_whtcol Is Nothing AndAlso Me.m_whtcol.Count >= 0 Then
          Dim saveWhtError As SaveErrorException = Me.m_whtcol.Save(currentUserId, conn, trans)
          If Not IsNumeric(saveWhtError.Message) Then
            trans.Rollback()
            Me.ResetID(oldid, oldje)
            ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
            Return saveWhtError
          Else
            Select Case CInt(saveWhtError.Message)
              Case -1, -2, -5
                trans.Rollback()
                Me.ResetID(oldid, oldje)
                ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
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
          ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
          Return saveJeError
        Else
          Select Case CInt(saveJeError.Message)
            Case -1
              trans.Rollback()
              Me.ResetID(oldid, oldje)
              ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
              Return saveJeError
            Case -2
              'Post ไปแล้ว
              Return saveJeError
            Case -5
              trans.Rollback()
              Me.ResetID(oldid, oldje)
              ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
              Return saveJeError
            Case Else
          End Select
        End If

        '------------------------Save Old Check-------------------------------
        If Me.OldCheck.Originated Then
          Me.OldCheck.DocStatus = New OutgoingCheckDocStatus(1)
          Dim checkSaveError As SaveErrorException = Me.OldCheck.Save(theUser.Id, conn, trans)
          If Not IsNumeric(checkSaveError.Message) Then
            trans.Rollback()
            Me.ResetID(oldid, oldje)
            ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
            Return checkSaveError
          Else
            Select Case CInt(checkSaveError.Message)
              Case -1, -5
                trans.Rollback()
                Me.ResetID(oldid, oldje)
                ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
                Return checkSaveError
              Case -2
                trans.Rollback()
                Me.ResetID(oldid, oldje)
                ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
                Return checkSaveError
              Case Else
            End Select
          End If
        End If
        '-----------------------------------------------------------------

        '------------------------Save Check-------------------------------
        If Not Me.Check.Originated Then 'And Not (CBool(Configuration.GetConfig("OneCheckPerPV"))) 
          If Not (Me.CqCode = Nothing OrElse Me.CqCode.Trim = "") Then

            Me.Check.IssueDate = Me.Docdate
            Me.Check.DueDate = Me.Docdate
            If Not (Me.Check.Originated) Then
              Me.Check.Code = Check.GetNextCode
              Me.Check.CqCode = Me.CqCode
            End If
            If Me.Status.Value = 0 Then
              Me.Check.DocStatus = New OutgoingCheckDocStatus(1)
            Else
              Me.Check.DocStatus = New OutgoingCheckDocStatus(2)
            End If
            Me.Check.Amount = Me.Amount + Me.BankCharge
            Me.Check.Bankacct = Me.Bankacct
            Me.Check.Note = Me.Note
            Me.Check.BankCharge = Me.BankCharge
            Me.Check.WHT = Me.WHT

            Dim o As Object = Configuration.GetConfig("CheckDateFromWHT")
            If Not o Is Nothing AndAlso CBool(o) Then
              'CheckDateFromWHT
              If Me.WitholdingTaxCollection.Count >= 1 Then
                Me.Check.DueDate = Me.WitholdingTaxCollection(0).DocDate
              End If
            End If
            Dim checkSaveError As SaveErrorException = Me.Check.Save(theUser.Id, conn, trans, True)
            If Not IsNumeric(checkSaveError.Message) Then
              trans.Rollback()
              Me.ResetID(oldid, oldje)
              ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
              Return checkSaveError
            Else
              Select Case CInt(checkSaveError.Message)
                Case -1, -5
                  trans.Rollback()
                  Me.ResetID(oldid, oldje)
                  ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
                  Return checkSaveError
                Case -2
                  trans.Rollback()
                  Me.ResetID(oldid, oldje)
                  ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
                  Return checkSaveError
                Case Else
              End Select
            End If
          End If
        Else

          Me.Check.WHT = Me.WHT
          If Me.Status.Value = 0 Then
            Me.Check.DocStatus = New OutgoingCheckDocStatus(1)
          Else
            Me.Check.DocStatus = New OutgoingCheckDocStatus(2)
          End If

          Dim checkSaveError As SaveErrorException = Me.Check.Save(theUser.Id, conn, trans, True)
          If Not IsNumeric(checkSaveError.Message) Then
            trans.Rollback()
            Me.ResetID(oldid, oldje)
            ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
            Return checkSaveError
          Else
            Select Case CInt(checkSaveError.Message)
              Case -1, -5
                trans.Rollback()
                Me.ResetID(oldid, oldje)
                ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
                Return checkSaveError
              Case -2
                trans.Rollback()
                Me.ResetID(oldid, oldje)
                ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
                Return checkSaveError
              Case Else
            End Select
          End If
        End If
        '------------------------End Save Check---------------------------
        '==============================AUTOGEN==========================================
        Dim saveAutoCodeError As SaveErrorException = SaveAutoCode(conn, trans)
        If Not IsNumeric(saveAutoCodeError.Message) Then
          trans.Rollback()
          ResetID(oldid, oldje)
          ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
          Return saveAutoCodeError
        Else
          Select Case CInt(saveAutoCodeError.Message)
            Case -1, -2, -5
              trans.Rollback()
              ResetID(oldid, oldje)
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
        Me.ResetID(oldid, oldje)
        ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
        Return New SaveErrorException(returnVal.Value.ToString)
      Catch ex As SqlException
        trans.Rollback()
        Me.ResetID(oldid, oldje)
        ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
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
      If Not myMessage.AskQuestionFormatted("${res:Global.ConfirmDeleteBankTransfer}", format) Then
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
        SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "DeleteBankTransfer", New SqlParameter() {New SqlParameter("@" & Me.Prefix & "_id", Me.Id), returnVal})
        If IsNumeric(returnVal.Value) Then
          Select Case CInt(returnVal.Value)
            Case -1
              trans.Rollback()
              Return New SaveErrorException("${res:Global.BankTransferIsReferencedCannotBeDeleted}")
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
    Public Overrides Function DeleteWithLog(ByVal currentUserId As Integer, ByVal theTime As Date) As SaveErrorException
      If Not Me.Originated Then
        Return New SaveErrorException("${res:Global.Error.NoIdError}")
      End If
      Dim myMessage As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      Dim format(0) As String
      format(0) = Me.Code
      If Not myMessage.AskQuestionFormatted("${res:Global.ConfirmDeleteBankTransfer}", format) Then
        Return New SaveErrorException("${res:Global.CencelDelete}")
      End If
      Dim trans As SqlTransaction
      Dim conn As New SqlConnection(Me.ConnectionString)
      conn.Open()
      trans = conn.BeginTransaction()

      Try
        '------------------------Save Check-------------------------------
        If Me.Check.Originated Then

          Me.Check.DocStatus = New OutgoingCheckDocStatus(1)

          Dim checkSaveError As SaveErrorException = Me.Check.Save(currentUserId, conn, trans)
          If Not IsNumeric(checkSaveError.Message) Then
            Return checkSaveError
          Else
            Select Case CInt(checkSaveError.Message)
              Case -1, -5
                Return checkSaveError
              Case -2
                Return checkSaveError
              Case Else
            End Select
          End If
        End If
        '------------------------End Save Check---------------------------

        Dim returnVal As System.Data.SqlClient.SqlParameter = New SqlParameter
        returnVal.ParameterName = "RETURN_VALUE"
        returnVal.DbType = DbType.Int32
        returnVal.Direction = ParameterDirection.ReturnValue
        returnVal.SourceVersion = DataRowVersion.Current
        SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "DeleteBankTransfer", New SqlParameter() {New SqlParameter("@" & Me.Prefix & "_id", Me.Id), returnVal})
        If IsNumeric(returnVal.Value) Then
          Select Case CInt(returnVal.Value)
            Case -1
              trans.Rollback()
              Return New SaveErrorException("${res:Global.BankTransferIsReferencedCannotBeDeleted}")
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

#Region "IPrintableEntity"
    Public Function GetDefaultForm() As String Implements IPrintableEntity.GetDefaultForm
      Return "BankTransfer"
    End Function

    Public Function GetDefaultFormPath() As String Implements IPrintableEntity.GetDefaultFormPath
      Return "BankTransfer"
    End Function

    Public Function GetDocPrintingEntries() As DocPrintingItemCollection Implements IPrintableEntity.GetDocPrintingEntries
      Dim dpiColl As New DocPrintingItemCollection
      Dim dpi As DocPrintingItem

      'Code (am เพิ่ม)
      dpi = New DocPrintingItem
      dpi.Mapping = "Code"
      dpi.Value = Me.Code
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'DocDate (am เพิ่ม)
      dpi = New DocPrintingItem
      dpi.Mapping = "DocDate"
      dpi.Value = Me.Docdate.ToShortDateString
      dpi.DataType = "System.DateTime"
      dpiColl.Add(dpi)

      'FromBankbranch (am เพิ่ม)
      dpi = New DocPrintingItem
      dpi.Mapping = "FromBankbranch"
      dpi.Value = Me.Bankacct.BankBranch.Name
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'FromBankAccount (am เพิ่ม)
      dpi = New DocPrintingItem
      dpi.Mapping = "FromBankAccount"
      dpi.Value = Me.Bankacct.Name
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'FromBankAccountCode (am เพิ่ม)
      dpi = New DocPrintingItem
      dpi.Mapping = "FromBankAccountCode"
      dpi.Value = Me.Bankacct
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'NOTE (am เพิ่ม)
      dpi = New DocPrintingItem
      dpi.Mapping = "NOTE"
      dpi.Value = Me.Note
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'FEE (am เพิ่ม)
      dpi = New DocPrintingItem
      dpi.Mapping = "FEE"
      dpi.Value = Configuration.FormatToString(Me.BankCharge, DigitConfig.Price)
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'WHT (am เพิ่ม)
      dpi = New DocPrintingItem
      dpi.Mapping = "WHT"
      dpi.Value = Configuration.FormatToString(Me.WHT, DigitConfig.Price)
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'Amount (am เพิ่ม)
      dpi = New DocPrintingItem
      dpi.Mapping = "Amount"
      dpi.Value = Configuration.FormatToString(Me.Amount, DigitConfig.Price)
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'Originator (am เพิ่ม)
      If Not Me.Originator Is Nothing Then
        dpi = New DocPrintingItem
        dpi.Mapping = "Originator"
        dpi.Value = Me.Originator.Name
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)
      End If

      'LastEditor (am เพิ่ม)
      If Not Me.LastEditor Is Nothing Then
        dpi = New DocPrintingItem
        dpi.Mapping = "LastEditor"
        dpi.Value = Me.LastEditor.Name
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)
      End If

      'ToBankbrance (am เพิ่ม)
      dpi = New DocPrintingItem
      dpi.Mapping = "ToBankbrance"
      dpi.Value = Me.BankacctDestinate.BankBranch.Name
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'ToBankAccount (am เพิ่ม)
      dpi = New DocPrintingItem
      dpi.Mapping = "ToBankAccount"
      dpi.Value = Me.BankacctDestinate.Name
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'ToBankAccountCode (am เพิ่ม)
      dpi = New DocPrintingItem
      dpi.Mapping = "ToBankAccountCode"
      dpi.Value = Me.BankacctDestinate
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      Return dpiColl
    End Function
#End Region

  End Class
End Namespace
