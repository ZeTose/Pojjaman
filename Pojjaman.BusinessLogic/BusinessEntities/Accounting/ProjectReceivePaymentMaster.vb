Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.Gui.Components
Imports System.Collections.Generic
Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Core.Services

Namespace Longkong.Pojjaman.BusinessLogic

  Public Class ProjectReceivePaymentMaster
    Inherits SimpleBusinessEntityBase

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
        '.DeliverDate = Now
        '.Project = New Project
        '.AcceptPerson = New Employee
        '.AcceptPerson2 = New Employee
        .LoadPRPMI()
        '.AutoCodeFormat = New AutoCodeFormat(Me)
      End With
    End Sub
    Protected Overloads Overrides Sub Construct(ByVal dr As System.Data.DataRow, ByVal aliasPrefix As String)
      MyBase.Construct(dr, aliasPrefix)

    End Sub
#End Region

#Region "Properties"
    'Public Property Project As Project
    'Public Property DeliverDate As Date
    'Public Property AccountPeriodDateStart As Date
    'Public Property AccountPeriodDateEnd As Date
    'Public Property AcceptPerson As Employee
    'Public Property AcceptPerson2 As Employee

    'Public Property IsNomalDeliver As Boolean
    'Public Property DeliverNumber As Integer
    'Public Property NoRevenue As Boolean
    'Public Property NoExpenditure As Boolean
    'Public Property ContractAmount As Decimal
    'Public Property ReceivedAmount As Decimal
    'Public Property MileStoneNumber As Integer
    'Public Property SentMileStoneNumber As Integer
    'Public Property ReceivedMileStoneNumber As Integer
    'Public Property ReceivedNumber As Integer
    'Public Property IsBiddingFinished As Boolean
    'Public Property BiddingFinishedDate As Date

    Public Property ProjectReceivePaymentMasterItemList As List(Of ProjectReceivePaymentMasterItem)
#End Region

#Region "Shared"
    Public Shared Function GetColumnSchemaTable() As TreeTable
      Dim myDatatable As New TreeTable("ProjectReceivePaymentMaster")
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
        Return "ProjectReceivePaymentMaster"
      End Get
    End Property
    Public Overrides ReadOnly Property TableName() As String
      Get
        Return "ProjectReceivePaymentMaster"
      End Get
    End Property
    Public Overrides ReadOnly Property Prefix() As String
      Get
        Return "projectprpmi"
      End Get
    End Property

    Public Overrides ReadOnly Property DetailPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.ProjectReceivePaymentMaster.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.ProjectReceivePaymentMaster"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.ProjectReceivePaymentMaster"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.ProjectReceivePaymentMaster.ListLabel}"
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
    Public Overloads Overrides Function Save(ByVal currentUserId As Integer) As SaveErrorException

      Dim cmd As String = ""
      Dim cmdList As New ArrayList
      For Each itm As ProjectReceivePaymentMasterItem In Me.ProjectReceivePaymentMasterItemList
        If itm.IsFormula Then
          cmd &= "Update ProjectPRPMI Set projectprpmi_accountlist = '" & itm.Formula & "' Where projectprpmi_id = " & itm.Id.ToString & ";"
        Else
          If itm.GLAccountList.Count > 0 Then
            cmd &= "Update ProjectPRPMI Set projectprpmi_accountlist = '" & itm.GLIdSeparate & "' Where projectprpmi_id = " & itm.Id.ToString & ";"
          End If
        End If
      Next

      If cmd.Length > 0 Then
        Try
          SqlHelper.ExecuteNonQuery(SimpleBusinessEntityBase.ConnectionString, CommandType.Text, cmd)
          Return New SaveErrorException("1")
        Catch ex As SaveErrorException
          Return New SaveErrorException(ex.Message)
        End Try
      End If

    End Function
    Public Sub LoadPRPMI()

      Me.ProjectReceivePaymentMasterItemList = New List(Of ProjectReceivePaymentMasterItem)

      Dim ds As DataSet = SqlHelper.ExecuteDataset(SimpleBusinessEntityBase.ConnectionString, CommandType.StoredProcedure, "GetPRPMI")
      For Each row As DataRow In ds.Tables(0).Rows
        Dim drh As New DataRowHelper(row)

        Dim itm As New ProjectReceivePaymentMasterItem
        Me.ProjectReceivePaymentMasterItemList.Add(itm)
        itm.ProjectReceivePaymentMaster = Me

        itm.Id = drh.GetValue(Of Integer)("projectprpmi_id")
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
    Public Sub Populate(ByVal dt As TreeTable)
      dt.Clear()
      Dim i As Integer = 0

      Dim hashParent As New Hashtable
      Dim hashKey As String = ""
      Dim newParentRow As TreeRow
      For Each itm As ProjectReceivePaymentMasterItem In Me.ProjectReceivePaymentMasterItemList
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
    Public Function GLIdSeparateAll() As String
      Dim acctIdlist As New ArrayList
      For Each itm As ProjectReceivePaymentMasterItem In Me.ProjectReceivePaymentMasterItemList
        For Each aitm As Account In itm.GLAccountList
          acctIdlist.Add(aitm.Id.ToString)
        Next
      Next
      Return String.Join(",", acctIdlist.ToArray)
    End Function
    Public Function GLIdHashAll() As Hashtable
      Dim achash As New Hashtable
      For Each itm As ProjectReceivePaymentMasterItem In Me.ProjectReceivePaymentMasterItemList
        For Each aitm As Account In itm.GLAccountList
          If Not achash.ContainsKey(aitm.Id.ToString) Then
            achash.Add(aitm.Id.ToString, aitm)
          End If
        Next
      Next
      Return achash
    End Function
    Public Function ValidateGL(acct As Account) As Account
      If Not GLIdHashAll.ContainsKey(acct.Id.ToString) Then
        Return New Account
      Else
        Return acct
      End If
    End Function
#End Region

  End Class

  Public Class ProjectReceivePaymentMasterItem
    Public Property ProjectReceivePaymentMaster As ProjectReceivePaymentMaster
    Public Property Id As Integer
    Public Property LineNumber As Integer
    Public Property ThaiNumber As String
    Public Property Description As String
    Public Property GroupName As String
    Public Property Formula As String
    Public Property IsCanceld As Boolean
    Public Property GLAccountList As List(Of Account)
    Private m_isFormula As Boolean
    Public Property IsFormula As Boolean
      Get
        Return m_isFormula
      End Get
      Set(value As Boolean)
        m_isFormula = value
        If value Then
          Me.GLAccountList = New List(Of Account)
        End If
      End Set
    End Property

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
        Me.ProjectReceivePaymentMaster.IsInitialized = False

        row("LineNumber") = Me.LineNumber
        row("ThaiNumber") = Me.ThaiNumber
        row("Description") = Me.Description
        If Me.IsFormula Then
          row("GLAccount") = Me.Formula
        Else
          row("GLAccount") = Me.GLCodeSeparate
        End If


        Me.ProjectReceivePaymentMaster.IsInitialized = True
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
