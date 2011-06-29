Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration
Imports Longkong.Core.Services

Namespace Longkong.Pojjaman.BusinessLogic
    Public Class BankCharge
        Inherits Banking
        Implements IWitholdingTaxable, IPrintableEntity

        ' *************************************
        ' // ต้องกำหนด BankingFormat ด้วยว่าเป็น ค่าธรรมเนียมธนาคาร หรือ ดอกเบี้ยจ่าย 
        ' *************************************

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
        .BankingFormat = New BankingFormat(1)
        .BankingTransType = New BankingTransType(4)
        .m_whtcol = New WitholdingTaxCollection
        .m_whtcol.Direction = New WitholdingTaxDirection(1)
      End With
    End Sub
    Protected Overloads Overrides Sub Construct(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
      MyBase.Construct(ds, aliasPrefix)
    End Sub
    Protected Overloads Overrides Sub Construct(ByVal dr As System.Data.DataRow, ByVal aliasPrefix As String)
      MyBase.Construct(dr, aliasPrefix)
      With Me
        .m_whtcol = New WitholdingTaxCollection(Me)
        .m_whtcol.Direction = New WitholdingTaxDirection(1)
      End With
    End Sub
#End Region

#Region "Overrides"

    Public Overrides ReadOnly Property ClassName() As String
      Get
        Return "bankcharge"
      End Get
    End Property

    Public Overrides ReadOnly Property GetSprocName() As String
      Get
        Return "Get" & Me.ClassName
      End Get
    End Property

    Public Overrides ReadOnly Property DetailPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.BankCharge.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.BankCharge"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.BankCharge"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.BankCharge.ListLabel}"
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

#Region "Properties"
    Public Overrides ReadOnly Property WHT() As Decimal
      Get
        Return Me.m_whtcol.Amount
      End Get
    End Property
#End Region

#Region " IGLAble Overrides "

    Public Overrides Function GetJournalEntries() As JournalEntryItemCollection

      Dim jiColl As New JournalEntryItemCollection
      Dim ji As New JournalEntryItem
      ' DR. ตรวจสอบ ว่าเป็นค่าธรรมเนียม หรือ ดอกเบี้ย
      If Me.BankingFormat.Value = 1 Then
        ' DR. ค่าธรรมเนียมธนคาร  ji.Mapping = "G7.1"
        SetGLG7_1(jiColl)
      ElseIf Me.BankingFormat.Value = 2 Then
        ' DR. ดอกเบี้ยจ่าย           ji.Mapping = "G7.2"
        SetGLG7_2(jiColl)
      End If

      ' Cr. เงินฝากธนาคาร               ji.Mapping = "G7.3"
      SetGLG7_3(jiColl)
      ' Cr. ภาษีหัก ณ ที่จ่าย             ji.Mapping = "G7.4"
      SetGLG7_4(jiColl)

      Return jiColl
    End Function
    ' DR. ค่าธรรมเนียมธนคาร
    Private Sub SetGLG7_1(ByVal jiColl As JournalEntryItemCollection)
      If Me.BankCharge > 0 Then
        Dim ji As JournalEntryItem
        ji = New JournalEntryItem
        ji.Amount = Me.BankCharge
        ji.Mapping = "G7.1"
        ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
        jiColl.Add(ji)
      End If
    End Sub
    ' DR. ดอกเบี้ยจ่าย
    Private Sub SetGLG7_2(ByVal jiColl As JournalEntryItemCollection)
      If Me.BankCharge > 0 Then
        Dim ji As JournalEntryItem
        ji = New JournalEntryItem
        ji.Amount = Me.BankCharge
        ji.Mapping = "G7.2"
        ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
        jiColl.Add(ji)
      End If
    End Sub
    ' CR. เงินฝากธนาคาร
    Private Sub SetGLG7_3(ByVal jiColl As JournalEntryItemCollection)
      If (Me.BankCharge - Me.WHT) > 0 Then
        Dim ji As JournalEntryItem
        ji = New JournalEntryItem
        ji.Amount = Me.BankCharge - Me.WHT
        If Me.Bankacct.Account.Originated Then
          ji.Account = Me.Bankacct.Account
        End If
        ji.Mapping = "G7.3"
        ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
        jiColl.Add(ji)
      End If
    End Sub
    ' CR. ภาษีหัก ณ ที่จ่าย
    Private Sub SetGLG7_4(ByVal jiColl As JournalEntryItemCollection)
      If Me.WHT > 0 Then
        Dim ji As JournalEntryItem
        ji = New JournalEntryItem
        ji.Amount = Me.WHT
        ji.Mapping = "G7.4"
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
      Return Me.BankCharge
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

#Region "IPrintableEntity"
    Public Function GetDefaultFormPath() As String Implements IPrintableEntity.GetDefaultFormPath
      Return "RptBankCharge"
    End Function
    Public Function GetDefaultForm() As String Implements IPrintableEntity.GetDefaultForm
      Return "RptBankCharge"
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
      dpi.Value = Me.Docdate.ToShortDateString
      dpi.DataType = "System.DateTime"
      dpiColl.Add(dpi)

      'txtBankAccountCode
      dpi = New DocPrintingItem
      dpi.Mapping = "BankAccountCode"
      dpi.Value = Me.Bankacct.Code
      dpi.DataType = "System.DateTime"
      dpiColl.Add(dpi)

      'txtBankAccountName
      dpi = New DocPrintingItem
      dpi.Mapping = "BankAccountName"
      dpi.Value = Me.Bankacct.Name
      dpi.DataType = "System.DateTime"
      dpiColl.Add(dpi)


      'BankAccountCode:Name
      dpi = New DocPrintingItem
      dpi.Mapping = "BankAccountCode:Name"
      dpi.Value = Me.Bankacct.Code & ":" & Me.Bankacct.Name
      dpi.DataType = "System.DateTime"
      dpiColl.Add(dpi)


      Dim n As Integer = 0
      Dim jiColl As DocPrintingItemCollection = Me.JournalEntry.GetDocPrintingEntries
      For Each item As DocPrintingItem In jiColl

        Dim found As Boolean = True
        Select Case item.Mapping.ToLower
          Case "item.linenumber"
            'Item.LineNumber
            dpi = New DocPrintingItem
            dpi.Mapping = "Item.LineNumber"
            dpi.DataType = "System.Int32"
          Case "item.accountcode"
            'Item.AccountCode
            dpi = New DocPrintingItem
            dpi.Mapping = "Item.AccountCode"
            dpi.DataType = "System.String"
          Case "item.account"
            'Item.AccountName
            dpi = New DocPrintingItem
            dpi.Mapping = "Item.AccountName"
            dpi.DataType = "System.String"
          Case "item.debit"
            'Item.Debit
            dpi = New DocPrintingItem
            dpi.Mapping = "Item.Debit"
            dpi.DataType = "System.String"
          Case "item.credit"
            ' Item.Credit
            dpi = New DocPrintingItem
            dpi.Mapping = "Item.Credit"
            dpi.DataType = "System.String"
          Case "item.costcentercode"
            'Item.CostCenter
            dpi = New DocPrintingItem
            dpi.Mapping = "Item.CostCenter"
            dpi.DataType = "System.String"
          Case "item.costcentercode"
            'Item.CostCenterCode
            dpi = New DocPrintingItem
            dpi.Mapping = "Item.CostCenterCode"
            dpi.DataType = "System.String"
          Case "item.costcentername"
            'Item.CostCenterName
            dpi = New DocPrintingItem
            dpi.Mapping = "Item.CostCenterName"
            dpi.DataType = "System.String"
          Case "item.costcenterinfo"
            'Item.CostCenterInfo
            dpi = New DocPrintingItem
            dpi.Mapping = "Item.CostCenterInfo"
            dpi.DataType = "System.String"
          Case "item.note"
            'Item.Note
            dpi = New DocPrintingItem
            dpi.Mapping = "Item.Note"
            dpi.DataType = "System.String"
          Case Else
            found = False
        End Select
        If found Then
          dpi.Value = item.Value
          dpi.Row = item.Row
          dpi.Table = "Item"
          dpiColl.Add(dpi)
        End If
      Next
      Return dpiColl
    End Function
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

      ValidateError = Me.JournalEntry.BeforeSave(currentUserId)
      If Not IsNumeric(ValidateError.Message) Then
        Return ValidateError
      End If




      Return New SaveErrorException("0")

    End Function
    Public Overloads Overrides Function Save(ByVal currentUserId As Integer) As SaveErrorException
      'Return New SaveErrorException("Not Yet Implemented")
      Dim showStr As String
      If Me.BankCharge <= 0 Then
        showStr = "${res:Longkong.Pojjaman.Gui.Panels.BankChargeDetail.lblBankCharge}"
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
      Dim oldjecode As String
      Dim oldjeautogen As Boolean

      oldcode = Me.Code
      oldautogen = Me.AutoGen
      oldjecode = Me.JournalEntry.Code
      oldjeautogen = Me.JournalEntry.AutoGen

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
            ResetID(oldid, oldje)
            ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
            Return saveWhtError
          Else
            Select Case CInt(saveWhtError.Message)
              Case -1, -2, -5
                trans.Rollback()
                ResetID(oldid, oldje)
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
            Case -5 'งวด
              trans.Rollback()
              Me.ResetID(oldid, oldje)
              ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
              Return saveJeError
            Case Else
          End Select
        End If

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
      If Not myMessage.AskQuestionFormatted("${res:Global.ConfirmDeleteBankCharge}", format) Then
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
        SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "DeleteBankCharge", New SqlParameter() {New SqlParameter("@" & Me.Prefix & "_id", Me.Id), returnVal})
        If IsNumeric(returnVal.Value) Then
          Select Case CInt(returnVal.Value)
            Case -1
              trans.Rollback()
              Return New SaveErrorException("${res:Global.BankChargeIsReferencedCannotBeDeleted}")
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
