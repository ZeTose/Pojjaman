Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.Gui.Components
Imports System.Collections.Generic
Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Core.Services
Imports System.Data.SqlClient

Namespace Longkong.Pojjaman.BusinessLogic

  Public Class ProjectReceivePayment
    Inherits SimpleBusinessEntityBase
    Implements IPrintableEntity, INewPrintableEntity, IHasToCostCenter

#Region "Member"
    Private m_reference As Boolean
#End Region

#Region "Constructor"
    Public Sub New()
      MyBase.New()
    End Sub
    Public Sub New(ByVal code As String)
      MyBase.New(code)
    End Sub
    Public Sub New(ByVal id As Integer)
      MyBase.New(id)
    End Sub
    Public Sub New(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
      Me.Construct(ds, aliasPrefix)
    End Sub
    Public Sub New(ByVal dr As System.Data.DataRow, ByVal aliasPrefix As String)
      Me.Construct(dr, aliasPrefix)
    End Sub
    Protected Overloads Overrides Sub Construct()
      MyBase.Construct()
      With Me
        .DeliverDate = Now
        .Project = New Project
        .AcceptPerson = New Employee
        .AcceptPerson2 = New Employee
        .IsNomalDeliver = True
        .CostCenter = New CostCenter
        '.m_olddocDate = Now.Date
        '.m_je = New JournalEntry(Me)
        '.m_je.DocDate = Me.m_docDate
        '.m_status = New OpenningBalanceStatus(-1)
        '.ProjectReceivePaymentItemList = New List(Of ProjectReceivePaymentItem)
        .GetPRPMI()
        .AutoCodeFormat = New AutoCodeFormat(Me)
      End With
    End Sub
    Protected Overloads Overrides Sub Construct(ByVal dr As System.Data.DataRow, ByVal aliasPrefix As String)
      MyBase.Construct(dr, aliasPrefix)

      Dim drh As New DataRowHelper(dr)

      m_project = New Project(drh.GetValue(Of Integer)("projectprp_project"))
      Me.DeliverDate = drh.GetValue(Of Date)("projectprp_deliverdate")
      Me.AccountPeriodDateStart = drh.GetValue(Of Date)("projectprp_acctperiodstart")
      Me.AccountPeriodDateEnd = drh.GetValue(Of Date)("projectprp_acctperiodend")
      Me.AcceptPerson = New Employee(drh.GetValue(Of Integer)("projectprp_acceptanceperson"))
      Me.AcceptPerson2 = New Employee(drh.GetValue(Of Integer)("projectprp_acceptanceperson2"))
      Me.IsNomalDeliver = drh.GetValue(Of Boolean)("projectprp_isnormaltransfer")
      Me.DeliverNumber = drh.GetValue(Of Integer)("projectprp_delivernumber")
      Me.NoRevenue = drh.GetValue(Of Boolean)("projectprp_norevenue")
      Me.NoExpenditure = drh.GetValue(Of Boolean)("projectprp_noexpenditure")
      Me.ContractAmount = drh.GetValue(Of Decimal)("projectprp_contractamt")
      Me.ReceivedAmount = drh.GetValue(Of Decimal)("projectprp_receivedamt")
      Me.MileStoneNumber = drh.GetValue(Of Integer)("projectprp_milestonenumber")
      Me.SentMileStoneNumber = drh.GetValue(Of Integer)("projectprp_sentmilestonenumber")
      Me.ReceivedMileStoneNumber = drh.GetValue(Of Integer)("projectprp_receivedmilestonenumber")
      Me.ReceivedNumber = drh.GetValue(Of Integer)("projectprp_receivednumber")
      Me.IsBiddingFinished = drh.GetValue(Of Boolean)("projectprp_isbindingfinished")
      Me.BiddingFinishedDate = drh.GetValue(Of Date)("projectprp_bindingfinisheddate")

      Me.Acceptancepersonposition = drh.GetValue(Of String)("projectprp_acceptancepersonposition")
      Me.Acceptancepersonposition2 = drh.GetValue(Of String)("projectprp_acceptancepersonposition2")

      Me.CostCenter = New CostCenter
      If m_project.Originated Then
        Me.CostCenter = New CostCenter(m_project.GetCostCenterForNacc)
      End If

      Me.GetPRPI()
    End Sub
#End Region

#Region "Properties"
    Public Property CostCenter As CostCenter Implements IHasToCostCenter.ToCC
    Private m_project As Project
    Public Property Project As Project
      Get
        Return m_project
      End Get
      Set(value As Project)
        m_project = value
        GetProjectContract()
      End Set
    End Property
    Public Property DeliverDate As Date
    Public ReadOnly Property DocDate As Date
      Get
        Return Me.DeliverDate
      End Get
    End Property
    Public Property AccountPeriodDateStart As Date
    Public Property AccountPeriodDateEnd As Date
    Public Property AcceptPerson As Employee
    Public Property AcceptPerson2 As Employee
    Public Property IsNomalDeliver As Boolean
    Public Property DeliverNumber As Integer
    Public Property NoRevenue As Boolean
    Public Property NoExpenditure As Boolean
    Public Property ContractAmount As Decimal
    Public Property ReceivedAmount As Decimal
    Public Property MileStoneNumber As Integer
    Public Property SentMileStoneNumber As Integer
    Public Property ReceivedMileStoneNumber As Integer
    Public Property ReceivedNumber As Integer
    Public Property IsBiddingFinished As Boolean
    Public Property BiddingFinishedDate As Date

    Public Property NormalDeliverNumber As Integer
    Public Property UnNormalDeliverNumber As Integer
    Public Property NormalDeliverDate As Date
    Public Property UnNormalDeliverDate As Date

    Public Property Acceptancepersonposition As String
    Public Property Acceptancepersonposition2 As String

    Public Property ProjectReceivePaymentItemList As Dictionary(Of Integer, ProjectReceivePaymentItem)

#End Region

#Region "Shared"
    Public Shared Function GetColumnSchemaTable() As TreeTable
      Dim myDatatable As New TreeTable("ProjectReceivePayment")
      myDatatable.Columns.Add(New DataColumn("LineNumber", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("ThaiNumber", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Description", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Separator1", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("GLAccount", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("GLButton", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Cash", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Bank", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Remain", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Other", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Sum", GetType(String)))

      Return myDatatable
    End Function
#End Region

#Region "Overrides Property"
    Public Overrides ReadOnly Property ClassName() As String
      Get
        Return "ProjectReceivePayment"
      End Get
    End Property
    Public Overrides ReadOnly Property TableName() As String
      Get
        Return "ProjectPRP"
      End Get
    End Property
    Public Overrides ReadOnly Property Prefix() As String
      Get
        Return "projectprp"
      End Get
    End Property

    Public Overrides ReadOnly Property DetailPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.ProjectReceivePayment.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.ProjectReceivePayment"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.ProjectReceivePayment"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.ProjectReceivePayment.ListLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property TabPageText() As String
      Get
        Dim tpt As String = Me.StringParserService.Parse(Me.DetailPanelTitle) & " (" & Me.Code & ")"
        If tpt.EndsWith("()") Then
          tpt = tpt.TrimEnd("()".ToCharArray)
        End If
        Return tpt
      End Get
    End Property
#End Region

#Region "Method"
    Private Function ValidateSaveDoc() As SaveErrorException
      'If Me.IsNomalDeliver Then
      '  If Me.AccountPeriodDateStart < Me.NormalDeliverDate Then
      '    Return New SaveErrorException(StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.ProjectReceivePayment.DateValid1}"), New String() {Me.AccountPeriodDateStart.ToShortDateString, Me.NormalDeliverDate.ToShortDateString})
      '  End If
      'Else
      '  If Me.AccountPeriodDateStart < Me.UnNormalDeliverDate Then
      '    Return New SaveErrorException(StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.ProjectReceivePayment.DateValid2}"), New String() {Me.AccountPeriodDateStart.ToShortDateString, Me.UnNormalDeliverDate.ToShortDateString})
      '  End If
      'End If

      If Me.AccountPeriodDateStart > Me.AccountPeriodDateEnd Then
        Return New SaveErrorException(StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.ProjectReceivePayment.DateValid3}"), New String() {Me.AccountPeriodDateStart.ToShortDateString, Me.AccountPeriodDateEnd.ToShortDateString})
      End If

      Return New SaveErrorException("1")
    End Function
    Public Overloads Overrides Function Save(ByVal currentUserId As Integer) As SaveErrorException

      Dim ValidateError As SaveErrorException = ValidateSaveDoc()
      If Not IsNumeric(ValidateError.Message) Then
        Return ValidateError
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
        paramArrayList.Add(New SqlParameter("@projectprp_id", Me.Id))
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

      '=====เอาออกได้นะ block นี่้
      If Me.AutoGen Then 'And Me.Code.Length = 0 Then
        Me.Code = Me.GetNextCode
      End If

      Me.AutoGen = False

      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_code", Me.Code))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_deliverdate", ValidDateOrDBNull(Me.DeliverDate)))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_project", Me.Project.Id))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_acctperiodstart", ValidDateOrDBNull(Me.AccountPeriodDateStart)))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_acctperiodend", ValidDateOrDBNull(Me.AccountPeriodDateEnd)))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_isnormaltransfer", Me.IsNomalDeliver))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_delivernumber", Me.DeliverNumber))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_norevenue", Me.NoRevenue))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_noexpenditure", Me.NoExpenditure))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_contractamt", Me.ContractAmount))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_receivedamt", Me.ReceivedAmount))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_milestonenumber", Me.MileStoneNumber))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_sentmilestonenumber", Me.SentMileStoneNumber))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_receivedmilestonenumber", Me.ReceivedMileStoneNumber))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_receivednumber", Me.ReceivedNumber))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_isbindingfinished", Me.IsBiddingFinished))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_bindingfinisheddate", ValidDateOrDBNull(Me.BiddingFinishedDate)))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_acceptanceperson", Me.AcceptPerson.Id))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_acceptanceperson2", Me.AcceptPerson2.Id))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_acceptancepersonposition", Me.Acceptancepersonposition))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_acceptancepersonposition2", Me.Acceptancepersonposition2))
      paramArrayList.Add(New SqlParameter("@cc_id", ValidIdOrDBNull(Me.CostCenter)))

      SetOriginEditCancelStatus(paramArrayList, currentUserId, theTime)

      ' สร้าง SqlParameter จาก ArrayList ...
      Dim sqlparams() As SqlParameter
      sqlparams = CType(paramArrayList.ToArray(GetType(SqlParameter)), SqlParameter())
      Dim trans As SqlTransaction
      Dim conn As New SqlConnection(Me.ConnectionString)
      conn.Open()

      trans = conn.BeginTransaction()
      Dim oldId As Integer = Me.Id

      Try

        ''Main Save Block
        Try
          Me.ExecuteSaveSproc(conn, trans, returnVal, sqlparams, theTime, theUser)

          If IsNumeric(returnVal.Value) Then
            Select Case CInt(returnVal.Value)
              Case -1, -5
                trans.Rollback()
                ResetId(oldId)
                ResetCode(oldcode, oldautogen)
                Return New SaveErrorException(returnVal.Value.ToString)
              Case -2 'เอกสารถูกอ้างอิงแล้ว
                If Me.IsDirty Then 'ถ้าเอกสารถูกแก้ไข --> ไม่ให้ save
                  trans.Rollback()
                  ResetId(oldId)
                  ResetCode(oldcode, oldautogen)
                  Return New SaveErrorException(returnVal.Value.ToString)
                End If
              Case Else
            End Select
          ElseIf IsDBNull(returnVal.Value) OrElse Not IsNumeric(returnVal.Value) Then
            trans.Rollback()
            ResetId(oldId)
            ResetCode(oldcode, oldautogen)
            Return New SaveErrorException(returnVal.Value.ToString)
          End If

          SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "DeletePRPI", New SqlParameter("@id", returnVal.Value))

          For Each kv As KeyValuePair(Of Integer, ProjectReceivePaymentItem) In ProjectReceivePaymentItemList
            Dim item As ProjectReceivePaymentItem = kv.Value
            SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "InsertPRPI", item.insertparameter(CInt(returnVal.Value)))
          Next

          trans.Commit()

          If Not Me.IsDirty AndAlso returnVal.Value.ToString = "-2" Then 'ถ้าเอกสารไม่ถูกแก้ไข --> ให้ save
            Return New SaveErrorException(Me.Id.ToString)
          End If
        Catch ex As SqlException
          trans.Rollback()
          ResetId(oldId)
          ResetCode(oldcode, oldautogen)
          Return New SaveErrorException(ex.ToString)
        Catch ex As Exception
          trans.Rollback()
          ResetId(oldId)
          ResetCode(oldcode, oldautogen)
          Return New SaveErrorException(ex.ToString)

        End Try

        Return New SaveErrorException(returnVal.Value.ToString)
        'Complete Save
      Catch ex As Exception
        Return New SaveErrorException(ex.ToString)
      Finally
        conn.Close()
      End Try

    End Function
    Private Sub ResetId(ByVal oldId As Integer)
      Me.Id = oldId
    End Sub
    Private Sub ResetCode(ByVal oldCode As String, ByVal oldautogen As Boolean)
      Me.Code = oldCode
      Me.AutoGen = oldautogen
    End Sub
    Private Sub GetProjectContract()
      Me.ContractAmount = 0
      Me.ReceivedAmount = 0
      Me.MileStoneNumber = 0
      Me.SentMileStoneNumber = 0
      Me.ReceivedMileStoneNumber = 0
      Me.ReceivedNumber = 0
      Me.NormalDeliverNumber = 0
      Me.UnNormalDeliverNumber = 0

            Dim ds As DataSet = SqlHelper.ExecuteDataset(SimpleBusinessEntityBase.ConnectionString, CommandType.StoredProcedure, "GetProjectContract", New SqlParameter("@Project_id", Me.Project.Id), New SqlParameter("@DeliverDate", Me.DeliverDate))
      For Each row As DataRow In ds.Tables(0).Rows
        Dim drh As New DataRowHelper(row)

        Me.ContractAmount = drh.GetValue(Of Decimal)("pma_contractAmt", 0)
        Me.ReceivedAmount = drh.GetValue(Of Decimal)("ReceivedAmount", 0)
        Me.MileStoneNumber = drh.GetValue(Of Integer)("MilestoneNumber", 0)
        Me.SentMileStoneNumber = drh.GetValue(Of Integer)("SentMilestoneNumber", 0)
        Me.ReceivedMileStoneNumber = drh.GetValue(Of Integer)("ReceivedMilestoneNumber", 0)
        Me.ReceivedNumber = drh.GetValue(Of Integer)("ReceivedNumber", 0)

      Next
      For Each row As DataRow In ds.Tables(1).Rows
        Dim drh As New DataRowHelper(row)
        Me.NormalDeliverNumber = drh.GetValue(Of Integer)("normal", 0)
        Me.UnNormalDeliverNumber = drh.GetValue(Of Integer)("unnormal", 0)
        Me.NormalDeliverDate = drh.GetValue(Of Date)("normaldate")
        Me.UnNormalDeliverDate = drh.GetValue(Of Date)("unnormaldate")
      Next

      If Me.IsNomalDeliver Then
        Me.DeliverNumber = Me.NormalDeliverNumber
      Else
        Me.DeliverNumber = Me.UnNormalDeliverNumber
      End If
    End Sub
    Public Sub GetRptGLPayType()
      ' สร้าง ArrayList จาก Item ของ  SqlParameter ...
      Dim paramArrayList As New ArrayList

      'paramArrayList.Add(New SqlParameter("@Detailed", Me.Code))
      paramArrayList.Add(New SqlParameter("@DocDateStart", ""))
      paramArrayList.Add(New SqlParameter("@DocDateEnd", ""))
      paramArrayList.Add(New SqlParameter("@cc_id", ""))
      'paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_creditPeriod", Me.CreditPeriod))
      'paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_note", Me.Note))
      'paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_gross", Me.Gross))
      'paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_status", Me.Status.Value))
      'paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_singleVat", Me.SingleVat))


      Dim ds As DataSet = SqlHelper.ExecuteDataset(SimpleBusinessEntityBase.ConnectionString, CommandType.StoredProcedure, "GetRptGLPayTypeList")

    End Sub
    Public Sub GetPRPMI()

      Me.ProjectReceivePaymentItemList = New Dictionary(Of Integer, ProjectReceivePaymentItem)

      Dim ds As DataSet = SqlHelper.ExecuteDataset(SimpleBusinessEntityBase.ConnectionString, CommandType.StoredProcedure, "GetPRPMI")
      For Each row As DataRow In ds.Tables(0).Rows
        Dim drh As New DataRowHelper(row)

        Dim itm As New ProjectReceivePaymentItem
        itm.ProjectReceivePaymen = Me

        itm.LineNumber = drh.GetValue(Of Integer)("projectprpmi_linenumber")
        itm.ThaiNumber = drh.GetValue(Of String)("projectprpmi_thainumber")
        itm.Description = drh.GetValue(Of String)("projectprpmi_description")
        itm.GroupName = drh.GetValue(Of String)("projectprpmi_groupname")
        itm.IsFormula = drh.GetValue(Of Boolean)("projectprpmi_isformula")
        itm.IsCanceld = drh.GetValue(Of Boolean)("projectprpmi_iscanceled")
        itm.GLAccountListString = drh.GetValue(Of String)("projectprpmi_accountlist", "")

        itm.GLAccountList = New List(Of Account)
        If drh.GetValue(Of String)("projectprpmi_accountlist", "").Length > 0 Then
          If Not itm.IsFormula Then
            Dim acctIdSplit() As String = drh.GetValue(Of String)("projectprpmi_accountlist").Split(","c)

            For Each acctIds As String In acctIdSplit
              If IsNumeric(acctIds) AndAlso CInt(acctIds) > 0 Then
                Dim acct As New Account(CInt(acctIds))

                itm.GLAccountList.Add(acct)
              End If
            Next
          Else
            itm.Formula = drh.GetValue(Of String)("projectprpmi_accountlist", "")
          End If
        End If
        Me.ProjectReceivePaymentItemList.Add(itm.LineNumber, itm)
      Next
    End Sub
    Public Sub GetPRPMIValue()

      If Me.CostCenter Is Nothing OrElse Not Me.CostCenter.Originated Then
        Return
      End If

      Me.ProjectReceivePaymentItemList = New Dictionary(Of Integer, ProjectReceivePaymentItem)
      Dim paramArrayList As New ArrayList

      paramArrayList.Add(New SqlParameter("@DocDateStart", Me.ValidDateOrDBNull(Me.AccountPeriodDateStart)))
      paramArrayList.Add(New SqlParameter("@DocDateEnd", Me.ValidDateOrDBNull(Me.AccountPeriodDateEnd)))
      paramArrayList.Add(New SqlParameter("@cc_id", Me.ValidIdOrDBNull(Me.CostCenter)))
      Dim sqlparams() As SqlParameter
      sqlparams = CType(paramArrayList.ToArray(GetType(SqlParameter)), SqlParameter())
      Dim ds2 As DataSet = SqlHelper.ExecuteDataset(SimpleBusinessEntityBase.ConnectionString, CommandType.StoredProcedure, "GetRptGLPayTypeList", sqlparams)
      Dim dtgli As DataTable = ds2.Tables(1) 'gli and cash amount

      Dim ds As DataSet = SqlHelper.ExecuteDataset(SimpleBusinessEntityBase.ConnectionString, CommandType.StoredProcedure, "GetPRPMI")

      For Each row As DataRow In ds.Tables(0).Rows
        Dim drh As New DataRowHelper(row)

        Dim itm As New ProjectReceivePaymentItem
        itm.ProjectReceivePaymen = Me

        itm.LineNumber = drh.GetValue(Of Integer)("projectprpmi_linenumber")
        itm.ThaiNumber = drh.GetValue(Of String)("projectprpmi_thainumber")
        itm.Description = drh.GetValue(Of String)("projectprpmi_description")
        itm.GroupName = drh.GetValue(Of String)("projectprpmi_groupname")
        itm.IsFormula = drh.GetValue(Of Boolean)("projectprpmi_isformula")
        itm.IsCanceld = drh.GetValue(Of Boolean)("projectprpmi_iscanceled")

        itm.GLAccountListString = drh.GetValue(Of String)("projectprpmi_accountlist", "")

        itm.Cash = 0
        itm.Bank = 0
        itm.Remain = 0
        itm.Other = 0
        itm.Sum = 0
        itm.Frac = 0

        itm.GLAccountList = New List(Of Account)
        If drh.GetValue(Of String)("projectprpmi_accountlist", "").Length > 0 Then
          If Not itm.IsFormula Then
            Dim acctIdSplit() As String = drh.GetValue(Of String)("projectprpmi_accountlist").Split(","c)

            For Each acctIds As String In acctIdSplit
              If IsNumeric(acctIds) AndAlso CInt(acctIds) > 0 Then
                Dim acct As New Account(CInt(acctIds))
                'หาค่าจากรายบรรทัด

                itm.GLAccountList.Add(acct)
                For Each glirow As DataRow In dtgli.Select("gli_acct =" & CStr(acctIds))
                  Dim glih As New DataRowHelper(glirow)
                  Dim gli As New GLforReceivePaymentItem
                  gli.AcctId = glih.GetValue(Of Integer)("gli_acct")
                  gli.amtwSign = glih.GetValue(Of Decimal)("gliamtwSign")
                  gli.total = glih.GetValue(Of Decimal)("totalnvat")
                  gli.totalCash = glih.GetValue(Of Decimal)("TotalCashnVat")
                  gli.totalBank = glih.GetValue(Of Decimal)("TotalBanknVat")
                  gli.totalOther = glih.GetValue(Of Decimal)("TotalOthernVat")
                  gli.payRemain = glih.GetValue(Of Decimal)("payRemainnVat")

                  Dim cash As Decimal = gli.Cash
                  Dim Bank As Decimal = gli.Bank
                  Dim remain As Decimal = gli.Remain
                  Dim Other As Decimal = gli.Other
                  Dim frac As Decimal = gli.Frac

                  If frac <> 0 Then
                    ProjectReceivePaymentItem.EqualizeFraction(frac, cash, Bank, remain, Other)
                  End If

                  itm.Cash += cash
                  itm.Bank += Bank
                  itm.Remain += remain
                  itm.Other += Other
                  itm.Sum += gli.amtwSign
                Next

              End If
            Next
          Else
            itm.Formula = drh.GetValue(Of String)("projectprpmi_accountlist", "")
          End If
        End If




        Me.ProjectReceivePaymentItemList.Add(itm.LineNumber, itm)
      Next

      For Each kv As KeyValuePair(Of Integer, ProjectReceivePaymentItem) In ProjectReceivePaymentItemList
        If kv.Key <> 1 AndAlso kv.Key <> 2 AndAlso kv.Key <> 24 AndAlso kv.Key <> 3 Then
          Dim itm As ProjectReceivePaymentItem = kv.Value
          ProjectReceivePaymentItemList(2).Plus(itm)
          ProjectReceivePaymentItemList(24).Plus(itm)
        End If
      Next
      ProjectReceivePaymentItemList(3).Plus(ProjectReceivePaymentItemList(1))
      ProjectReceivePaymentItemList(3).Plus(ProjectReceivePaymentItemList(2), -1)

    End Sub
    Public Sub GetPRPI()

      Me.ProjectReceivePaymentItemList = New Dictionary(Of Integer, ProjectReceivePaymentItem)

      Dim ds As DataSet = SqlHelper.ExecuteDataset(SimpleBusinessEntityBase.ConnectionString, CommandType.StoredProcedure, "GetPRPI", New SqlParameter("@projectprp_id", Me.Id))
      For Each row As DataRow In ds.Tables(0).Rows
        Dim drh As New DataRowHelper(row)

        Dim itm As New ProjectReceivePaymentItem
        itm.ProjectReceivePaymen = Me

        itm.LineNumber = drh.GetValue(Of Integer)("projectprpi_linenumber")
        itm.ThaiNumber = drh.GetValue(Of String)("projectprpi_thainumber")
        itm.Description = drh.GetValue(Of String)("projectprpi_description")
        itm.GroupName = drh.GetValue(Of String)("projectprpi_groupname")
        itm.IsFormula = drh.GetValue(Of Boolean)("projectprpi_isformula")
        'itm.IsCanceld = drh.GetValue(Of Boolean)("projectprpmi_iscanceled")
        itm.Cash = drh.GetValue(Of Decimal)("projectprpi_cashamt")
        itm.Bank = drh.GetValue(Of Decimal)("projectprpi_bankamt")
        itm.Remain = drh.GetValue(Of Decimal)("projectprpi_remainingamt")
        itm.Other = drh.GetValue(Of Decimal)("projectprpi_otheramt")
        itm.Sum = drh.GetValue(Of Decimal)("projectprpi_amt")
        itm.Frac = drh.GetValue(Of Decimal)("frac")
        itm.GLAccountListString = drh.GetValue(Of String)("projectprpmi_accountlist", "")

        itm.GLAccountList = New List(Of Account)
        If drh.GetValue(Of String)("projectprpi_accountlist", "").Length > 0 Then
          If Not itm.IsFormula Then
            Dim acctIdSplit() As String = drh.GetValue(Of String)("projectprpi_accountlist").Split(","c)

            For Each acctIds As String In acctIdSplit
              If IsNumeric(acctIds) AndAlso CInt(acctIds) > 0 Then
                Dim acct As New Account(CInt(acctIds))

                itm.GLAccountList.Add(acct)
              End If
            Next
          Else
            itm.Formula = drh.GetValue(Of String)("projectprpi_accountlist", "")
          End If
        End If
        Me.ProjectReceivePaymentItemList.Add(itm.LineNumber, itm)
      Next
    End Sub
    Public Sub Populate(ByVal dt As TreeTable)
      dt.Clear()
      Dim i As Integer = 7

      Dim hashParent As New Hashtable
      Dim hashKey As String = ""
      Dim newParentRow As TreeRow
      For Each kv As KeyValuePair(Of Integer, ProjectReceivePaymentItem) In Me.ProjectReceivePaymentItemList
        Dim itm As ProjectReceivePaymentItem = kv.Value
        i += 1
        itm.LineNumber = i

        hashKey = itm.GroupName
        If Not hashParent.ContainsKey(hashKey) Then
          newParentRow = itm.CopyToDataParentRow(dt)
          itm.ItemValidateRow(newParentRow, True)
          hashParent.Add(hashKey, newParentRow)
        Else
          newParentRow = CType(hashParent(hashKey), TreeRow)
        End If

        Dim newRow As TreeRow = newParentRow.Childs.Add()
        'newRow.State = RowExpandState.Expanded
        itm.CopyToDataRow(newRow)
        itm.ItemValidateRow(newRow)
        newRow.Tag = itm
      Next
      dt.AcceptChanges()
    End Sub
#End Region

#Region "Delete"
    Public Overrides ReadOnly Property CanDelete() As Boolean
      Get
        If Me.Originated Then
          Return Me.Status.Value <= 2 'AndAlso Not Me.IsReferenced
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
      If Not myMessage.AskQuestionFormatted("${res:Global.ConfirmDeleteProjectPRP}", format) Then
        Return New SaveErrorException("${res:Global.CencelDelete}")
      End If
      Dim trans As SqlTransaction
      Dim conn As New SqlConnection(Me.ConnectionString)
      conn.Open()
      trans = conn.BeginTransaction()
      Try
        For Each extender As Object In Me.Extenders
          If TypeOf extender Is IExtender Then
            Dim delDocError As SaveErrorException = CType(extender, IExtender).Delete(conn, trans)
            If Not IsNumeric(delDocError.Message) Then
              trans.Rollback()
              Return delDocError
            Else
              Select Case CInt(delDocError.Message)
                Case -1, -2, -5
                  trans.Rollback()
                  Return delDocError
                Case Else
              End Select
            End If
          End If
        Next

        Dim returnVal As System.Data.SqlClient.SqlParameter = New SqlParameter
        returnVal.ParameterName = "RETURN_VALUE"
        returnVal.DbType = DbType.Int32
        returnVal.Direction = ParameterDirection.ReturnValue
        returnVal.SourceVersion = DataRowVersion.Current
        SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "DeleteProjectPRP", New SqlParameter() {New SqlParameter("@projectprp_id", Me.Id), returnVal})
        If IsNumeric(returnVal.Value) Then
          Select Case CInt(returnVal.Value)
            Case -1
              trans.Rollback()
              'Return New SaveErrorException("${res:Global.PRIsReferencedCannotBeDeleted}")
            Case Else
          End Select
        ElseIf IsDBNull(returnVal.Value) OrElse Not IsNumeric(returnVal.Value) Then
          trans.Rollback()
          Return New SaveErrorException(returnVal.Value.ToString)
        End If
        'Me.DeleteRef(conn, trans)

        'Dim mldoc As New DocMultiApproval(Me.Id, Me.EntityId)
        'mldoc.DocMethod = SaveDocMultiApprovalMethod.Delete
        'Dim savemldocError As SaveErrorException = mldoc.UpdateApprove(0, conn, trans)
        'If Not IsNumeric(savemldocError.Message) Then
        '  trans.Rollback()
        '  Return savemldocError
        'End If

        trans.Commit()
        'Return New SaveErrorException("1")
      Catch ex As SqlException
        trans.Rollback()
        Return New SaveErrorException(ex.Message)
      Catch ex As Exception
        trans.Rollback()
        Return New SaveErrorException(ex.Message)
      Finally
        conn.Close()
      End Try

      'Try
      '  Parallel.Invoke(Sub()
      '                    WBSActual.SummaryPRWBSActual(conn)
      '                  End Sub,
      '                  Sub()
      '                    WBSActual.SummaryWRWBSActual(conn)
      '                  End Sub,
      '                  Sub()
      '                    WBSActual.SummaryPRAdjWBSActual(conn)
      '                  End Sub
      '           )
      'Catch ex As Exception
      '  Return New SaveErrorException(ex.ToString)
      'End Try

      'Try
      '  Dim subsaveerror As SaveErrorException = WBSActual.SummaryChildActual(conn, "pr")
      '  If Not IsNumeric(subsaveerror.Message) Then
      '    Return New SaveErrorException(" Save Incomplete Please Save Again (1)")
      '  End If
      'Catch ex As Exception
      '  Return New SaveErrorException(ex.ToString)
      'End Try

      Return New SaveErrorException("1")

    End Function
#End Region

    Public Function GetDocPrintingColumnsEntries() As DocPrintingItemCollection Implements INewPrintableEntity.GetDocPrintingColumnsEntries
      Dim dpiColl As New DocPrintingItemCollection
      Dim dpi As DocPrintingItem

      Return dpiColl
    End Function

    Public Function GetDocPrintingDataEntries() As DocPrintingItemCollection Implements INewPrintableEntity.GetDocPrintingDataEntries
      Dim dpiColl As New DocPrintingItemCollection
      Dim dpi As DocPrintingItem

      Return dpiColl
    End Function

    Public Function GetDefaultForm() As String Implements IPrintableEntity.GetDefaultForm

    End Function

    Public Function GetDefaultFormPath() As String Implements IPrintableEntity.GetDefaultFormPath
      'Return "..\data\forms\DevExpress\ProjectReceivePaymentDeliverForm.repx"
    End Function

    Public Function GetDocPrintingEntries() As DocPrintingItemCollection Implements IPrintableEntity.GetDocPrintingEntries
      Dim dpiColl As New DocPrintingItemCollection
      Dim dpi As DocPrintingItem

      Return dpiColl
    End Function
  End Class

  Public Class ProjectReceivePaymentItem
    Public Property ProjectReceivePaymen As ProjectReceivePayment
    Public Property LineNumber As Integer
    Public Property ThaiNumber As String
    Public Property Description As String
    Public Property GroupName As String
    Public Property IsFormula As Boolean
    Public Property Formula As String
    Public Property Cash As Decimal
    Public Property Bank As Decimal
    Public Property Remain As Decimal
    Public Property Other As Decimal
    Public Property Sum As Decimal
    Public Property Frac As Decimal
    Public Property IsCanceld As Boolean
    Public Property GLAccountList As List(Of Account)
    Public Property GLAccountListString As String

    Public Function GLIdSeparate() As String
      Dim codeList As New ArrayList
      For Each itm As Account In Me.GLAccountList
        codeList.Add(itm.Id.ToString)
      Next
      Return String.Join(",", codeList.ToArray)
    End Function
    Public Function GLCodeSeparate() As String
      Dim codeList As New ArrayList
      For Each itm As Account In Me.GLAccountList
        Dim _code As String = "|" & itm.Code
        codeList.Add(_code)
      Next
      If codeList.Count > 0 Then
        Return String.Join("|", codeList.ToArray) & "|"
      End If
      Return ""
    End Function
    Public Sub Plus(ByVal item As ProjectReceivePaymentItem, Optional ByVal sign As Integer = 1)
      Me.Cash += sign * item.Cash
      Me.Bank += sign * item.Bank
      Me.Remain += sign * item.Remain
      Me.Other += sign * item.Other
      Me.Sum += sign * item.Sum
    End Sub
    Public Function CopyToDataParentRow(ByVal dt As TreeTable) As TreeRow
      Dim newRow As TreeRow = dt.Childs.Add
      newRow("Description") = Me.GroupName
      newRow.State = RowExpandState.Expanded

      Return newRow
    End Function
    Public Sub CopyToDataRow(ByVal row As TreeRow)
      If row Is Nothing Then
        Return
      End If
      Try
        Me.ProjectReceivePaymen.IsInitialized = False

        row("LineNumber") = Me.LineNumber
        row("ThaiNumber") = Me.ThaiNumber
        row("Description") = Me.Description
        If Me.IsFormula Then
          row("GLAccount") = Me.Formula
        Else
          row("GLAccount") = Me.GLCodeSeparate
        End If
        row("Cash") = Configuration.FormatToString(Me.Cash, DigitConfig.Price)
        row("Bank") = Configuration.FormatToString(Me.Bank, DigitConfig.Price)
        row("Remain") = Configuration.FormatToString(Me.Remain, DigitConfig.Price)
        row("Other") = Configuration.FormatToString(Me.Other, DigitConfig.Price)
        row("Sum") = Configuration.FormatToString(Me.Sum, DigitConfig.Price)

        Me.ProjectReceivePaymen.IsInitialized = True
      Catch ex As Exception
        MessageBox.Show(ex.Message & "::" & ex.StackTrace)
      End Try
    End Sub
    Public Sub ItemValidateRow(ByVal row As DataRow, Optional ByVal isParent As Boolean = False)
      'Dim glcode As Object = row("GLAccount")

      'Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)

      'If IsDBNull(glcode) OrElse glcode.ToString.Length = 0 Then
      '  row.SetColumnError("GLAccount", myStringParserService.Parse("${res:Global.Error.ItemNameMissing}"))
      'Else
      '  row.SetColumnError("GLAccount", "")
      'End If

      If isParent OrElse Me.IsFormula OrElse Me.Description.Trim.Length = 0 Then
        row("GLButton") = "invisible"
      End If
    End Sub

    Public Shared Sub EqualizeFraction(ByVal frac As Decimal, ByRef cash As Decimal, ByRef bank As Decimal, ByRef remain As Decimal, ByRef other As Decimal)
      Dim kv As New Dictionary(Of String, Decimal)
      kv.Add("cash", cash)
      kv.Add("bank", bank)
      kv.Add("remain", remain)
      kv.Add("other", other)

      Dim sumforfrac As Decimal = 0
      Dim delkey As New List(Of String)
      For Each item As KeyValuePair(Of String, Decimal) In kv
        If item.Value Mod 1 = 0 Then
          delkey.Add(item.Key)
        Else
          sumforfrac += item.Value
        End If
      Next
      Dim remfrac As Decimal = frac

      Dim count As Integer = kv.Count - delkey.Count
      For Each item As KeyValuePair(Of String, Decimal) In kv
        Dim tmpkey As String = item.Key
        Dim temval As Decimal = item.Value
        Dim tmpfrac As Decimal = 0
        If temval Mod 1 <> 0 Then
          If remfrac > 0 AndAlso count > 1 Then
            tmpfrac = Configuration.Format(temval * frac / sumforfrac, DigitConfig.Price)
            remfrac = remfrac - tmpfrac
            count -= 1
          Else
            tmpfrac = remfrac
            remfrac = 0
            count -= 1
          End If
          temval = temval + tmpfrac

          Select Case tmpkey
            Case "cash"
              cash = temval
            Case "bank"
              bank = temval
            Case "remain"
              remain = temval
            Case "other"
              other = temval
          End Select
        End If
      Next

    End Sub

    Public Function insertparameter(ByVal returnVal As Integer) As SqlParameter()
      Dim paramArrayList As New ArrayList

      paramArrayList.Add(New SqlParameter("@projectprpi_projectprp", returnVal))
      paramArrayList.Add(New SqlParameter("@projectprpi_linenumber", Me.LineNumber))
      paramArrayList.Add(New SqlParameter("@projectprpi_thainumber", Me.ThaiNumber))
      paramArrayList.Add(New SqlParameter("@projectprpi_description", Me.Description))
      paramArrayList.Add(New SqlParameter("@projectprpi_groupname", Me.GroupName))
      paramArrayList.Add(New SqlParameter("@projectprpi_isformula", Me.IsFormula))
      paramArrayList.Add(New SqlParameter("@projectprpi_accountlist", Me.GLAccountListString))
      paramArrayList.Add(New SqlParameter("@projectprpi_cashamt", Configuration.Format(Me.Cash, DigitConfig.Price)))
      paramArrayList.Add(New SqlParameter("@projectprpi_bankamt", Configuration.Format(Me.Bank, DigitConfig.Price)))
      paramArrayList.Add(New SqlParameter("@projectprpi_remainingamt", Configuration.Format(Me.Remain, DigitConfig.Price)))
      paramArrayList.Add(New SqlParameter("@projectprpi_otheramt", Configuration.Format(Me.Other, DigitConfig.Price)))
      paramArrayList.Add(New SqlParameter("@projectprpi_amt", Configuration.Format(Me.Sum, DigitConfig.Price)))
      Dim sqlparams() As SqlParameter
      sqlparams = CType(paramArrayList.ToArray(GetType(SqlParameter)), SqlParameter())

      Return sqlparams
    End Function

  End Class


  Public Class GLforReceivePaymentItem

    Public Property AcctId As Integer
    Public Property amtwSign As Decimal
    Public Property total As Decimal
    Public Property totalCash As Decimal
    Public Property totalBank As Decimal
    Public Property payRemain As Decimal
    Public Property totalOther As Decimal
    Public ReadOnly Property Cash As Decimal
      Get
        Return totalCash / total * amtwSign
      End Get
    End Property
    Public ReadOnly Property Bank As Decimal
      Get
        Return totalBank / total * amtwSign
      End Get
    End Property
    Public ReadOnly Property Remain As Decimal
      Get
        Return payRemain / total * amtwSign
      End Get
    End Property
    Public ReadOnly Property Other As Decimal
      Get
        Return totalOther / total * amtwSign
      End Get
    End Property
    Public ReadOnly Property Frac As Decimal
      Get
        Return amtwSign - (Cash + Bank + Remain + Other)
      End Get
    End Property

  End Class
End Namespace
