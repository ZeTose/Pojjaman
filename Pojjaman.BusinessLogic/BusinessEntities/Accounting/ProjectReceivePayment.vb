Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.Gui.Components
Imports System.Collections.Generic
Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Core.Services
Imports System.Data.SqlClient

Namespace Longkong.Pojjaman.BusinessLogic

  Public Class ProjectReceivePayment
    Inherits SimpleBusinessEntityBase
    Implements IPrintableEntity, INewPrintableEntity

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
    Public Property CostCenter As CostCenter
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

    Public Property ProjectReceivePaymentItemList As List(Of ProjectReceivePaymentItem)

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

      Dim ds As DataSet = SqlHelper.ExecuteDataset(SimpleBusinessEntityBase.ConnectionString, CommandType.StoredProcedure, "GetProjectContract", New SqlParameter("@Project_id", Me.Project.Id))
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

      Me.ProjectReceivePaymentItemList = New List(Of ProjectReceivePaymentItem)

      Dim ds As DataSet = SqlHelper.ExecuteDataset(SimpleBusinessEntityBase.ConnectionString, CommandType.StoredProcedure, "GetPRPMI")
      For Each row As DataRow In ds.Tables(0).Rows
        Dim drh As New DataRowHelper(row)

        Dim itm As New ProjectReceivePaymentItem
        Me.ProjectReceivePaymentItemList.Add(itm)
        itm.ProjectReceivePaymen = Me

        itm.LineNumber = drh.GetValue(Of Integer)("projectprpmi_linenumber")
        itm.ThaiNumber = drh.GetValue(Of String)("projectprpmi_thainumber")
        itm.Description = drh.GetValue(Of String)("projectprpmi_description")
        itm.GroupName = drh.GetValue(Of String)("projectprpmi_groupname")
        itm.IsFormula = drh.GetValue(Of Boolean)("projectprpmi_isformula")
        itm.IsCanceld = drh.GetValue(Of Boolean)("projectprpmi_iscanceled")

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
      Next
    End Sub
    Public Sub GetPRPI()

      Me.ProjectReceivePaymentItemList = New List(Of ProjectReceivePaymentItem)

      Dim ds As DataSet = SqlHelper.ExecuteDataset(SimpleBusinessEntityBase.ConnectionString, CommandType.StoredProcedure, "GetPRPI", New SqlParameter("@projectprp_id", Me.Id))
      For Each row As DataRow In ds.Tables(0).Rows
        Dim drh As New DataRowHelper(row)

        Dim itm As New ProjectReceivePaymentItem
        Me.ProjectReceivePaymentItemList.Add(itm)
        itm.ProjectReceivePaymen = Me

        itm.LineNumber = drh.GetValue(Of Integer)("projectprpi_linenumber")
        itm.ThaiNumber = drh.GetValue(Of String)("projectprpi_thainumber")
        itm.Description = drh.GetValue(Of String)("projectprpi_description")
        itm.GroupName = drh.GetValue(Of String)("projectprpi_groupname")
        itm.IsFormula = drh.GetValue(Of Boolean)("projectprpi_isformula")
        'itm.IsCanceld = drh.GetValue(Of Boolean)("projectprpmi_iscanceled")

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
      Next
    End Sub
    Public Sub Populate(ByVal dt As TreeTable)
      dt.Clear()
      Dim i As Integer = 0

      Dim hashParent As New Hashtable
      Dim hashKey As String = ""
      Dim newParentRow As TreeRow
      For Each itm As ProjectReceivePaymentItem In Me.ProjectReceivePaymentItemList
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
    Public Property IsCanceld As Boolean
    Public Property GLAccountList As List(Of Account)

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
  End Class

End Namespace
