Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.TextHelper
Imports System.Text.RegularExpressions
Imports System.Collections.Generic

Namespace Longkong.Pojjaman.BusinessLogic
  ''' <summary>
  ''' Interface ���� �������������������� GL ����¹�����͹ Refresh
  ''' ����з���˹���ǵ�ͧ��� OnGlChanged �ء Property ���з���� GL ����¹� Class ���
  ''' </summary>
  ''' <remarks></remarks>
  Public Interface IGLCheckingBeforeRefresh
  End Interface
  Public Class JournalEntryStatus
    Inherits CodeDescription

#Region "Constructors"
    Public Sub New(ByVal value As Integer)
      MyBase.New(value)
    End Sub
#End Region

#Region "Properties"
    Public Overrides ReadOnly Property CodeName() As String
      Get
        Return "gl_status"
      End Get
    End Property
#End Region

  End Class
  Public Class JournalEntryType
    Inherits CodeDescription

#Region "Constructors"
    Public Sub New(ByVal value As Integer)
      MyBase.New(value)
    End Sub
#End Region

#Region "Properties"
    Public Overrides ReadOnly Property CodeName() As String
      Get
        Return "gl_type"
      End Get
    End Property
#End Region

  End Class
  Public Class JournalEntry
    Inherits SimpleBusinessEntityBase
    Implements IPrintableEntity, IApprovAble, IHasAccountBook, ICancelable, ICheckPeriod, IHasMainDoc, IDuplicable

#Region "Members"
    Private gl_accountBook As AccountBook
    Private gl_docDate As Date
    Private gl_note As String
    Private gl_status As JournalEntryStatus
    Private gl_postPerson As User
    Private gl_postDate As DateTime
    Private gl_refDoc As IGLAble

    Private gl_refjvdoc As ISimpleEntity
    Private gl_reftype As Integer

    Private m_glFormat As GLFormat
    Private m_manualFormat As Boolean

    Private m_hasRefDoc As Boolean = False
    Private m_itemCollection As JournalEntryItemCollection
#End Region

#Region "Constructors"
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
    Public Sub New(ByVal refDoc As IGLAble)
      Me.New(refDoc.Id, CType(refDoc, IObjectReflectable).EntityId)
      Me.RefDoc = refDoc
      If refDoc.Id = 0 Then
        Me.SetAccountBookFromEntity(CType(refDoc, IObjectReflectable).EntityId)

        'Dim glf As GLFormat = refDoc.GetDefaultGLFormat
        'If Not glf Is Nothing Then
        '  Me.SetGLFormat(glf)
        'End If
      End If
    End Sub
    Private Sub New(ByVal refId As Integer, ByVal refType As Integer)
      If refId = 0 Then
        m_hasRefDoc = True
        Me.gl_reftype = refType
        Return
      End If
      Dim ds As DataSet = SqlHelper.ExecuteDataset(Me.ConnectionString _
      , CommandType.StoredProcedure _
      , "GetGL" _
      , New SqlParameter("@gl_refid", refId), New SqlParameter("@gl_type", refType))
      If ds.Tables.Count > 0 AndAlso ds.Tables(0).Rows.Count = 1 Then
        m_hasRefDoc = True
        Construct(ds.Tables(0).Rows(0), "")
      End If
      Me.gl_reftype = refType
    End Sub
    Property DontSave As Boolean
    Protected Overloads Overrides Sub Construct()
      MyBase.Construct()
      With Me
        .gl_accountBook = New AccountBook
        .RefDoc = New GenericGlAble
        .gl_refDoc.Id = 0
        .gl_refDoc.Date = Date.MinValue
        .gl_refDoc.Code = ""
        .gl_postPerson = New User
        .gl_status = New JournalEntryStatus(-1)

        .gl_refjvdoc = New SimpleBusinessEntityBase
        .gl_reftype = Me.EntityId
        .m_glFormat = New GLFormat
        .m_manualFormat = False
      End With
      m_itemCollection = New JournalEntryItemCollection(Me)
      DBItemCollection = New JournalEntryItemCollection(Me)
    End Sub
    Protected Overloads Overrides Sub Construct(ByVal dr As System.Data.DataRow, ByVal aliasPrefix As String)
      MyBase.Construct(dr, aliasPrefix)
      With Me

        If Not dr.IsNull(aliasPrefix & "gl_docDate") Then
          .gl_docDate = CDate(dr(aliasPrefix & "gl_docDate"))
        End If

        If Not dr.IsNull(aliasPrefix & "gl_note") Then
          .gl_note = CStr(dr(aliasPrefix & "gl_note"))
        End If


        If Not dr.IsNull(aliasPrefix & "gl_postDate") Then
          .gl_postDate = CDate(dr(aliasPrefix & "gl_postDate"))
        End If
        If dr.Table.Columns.Contains("postPerson.user_id") Then
          If Not dr.IsNull("postPerson.user_id") Then
            .gl_postPerson = New User(dr, "postPerson.")
          End If
        Else
          If Not dr.IsNull(aliasPrefix & "gl_postPerson") Then
            .gl_postPerson = New User(CInt(dr(aliasPrefix & "gl_postPerson")))
          End If
        End If

        If dr.Table.Columns.Contains("accountbook_id") Then
          If Not dr.IsNull("accountbook_id") Then
            .gl_accountBook = New AccountBook(dr, "")
          End If
        Else
          If Not dr.IsNull(aliasPrefix & "gl_accountbook") Then
            .gl_accountBook = New AccountBook(CInt(dr(aliasPrefix & "gl_accountbook")))
          End If
        End If

        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_glFormat") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_glFormat") Then
          .m_glFormat = New GLFormat(CInt(dr(aliasPrefix & Me.Prefix & "_glFormat")))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_manualFormat") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_manualFormat") Then
          .m_manualFormat = CBool(dr(aliasPrefix & Me.Prefix & "_manualFormat"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_status") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_status") Then
          .gl_status = New JournalEntryStatus(CInt(dr(aliasPrefix & Me.Prefix & "_status")))
        End If

        If Not dr.IsNull(aliasPrefix & "gl_postDate") Then
          .gl_postDate = CDate(dr(aliasPrefix & "gl_postDate"))
        End If
        If dr.Table.Columns.Contains("postPerson.user_id") Then
          If Not dr.IsNull("postPerson.user_id") Then
            .gl_postPerson = New User(dr, "postPerson.")
          End If
        Else
          If Not dr.IsNull(aliasPrefix & "gl_postPerson") Then
            .gl_postPerson = New User(CInt(dr(aliasPrefix & "gl_postPerson")))
          End If
        End If

        If dr.Table.Columns.Contains("accountbook_id") Then
          If Not dr.IsNull("accountbook_id") Then
            .gl_accountBook = New AccountBook(dr, "")
          End If
        Else
          If Not dr.IsNull(aliasPrefix & "gl_accountbook") Then
            .gl_accountBook = New AccountBook(CInt(dr(aliasPrefix & "gl_accountbook")))
          End If
        End If

        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "glstatus.code_value") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "glstatus.code_value") Then
          .gl_status = New JournalEntryStatus(CInt(dr(aliasPrefix & Me.Prefix & "glstatus.code_value")))
        End If

        If Not Me.m_hasRefDoc Then
          SetRefDoc(dr, aliasPrefix)
        End If
      End With
      m_itemCollection = New JournalEntryItemCollection(Me)
      DBItemCollection = New JournalEntryItemCollection(Me)
    End Sub
    Public Sub SetRefDoc(ByVal dr As System.Data.DataRow, ByVal aliasPrefix As String)
      Dim refDocType As Integer
      Dim refDocId As Integer
      Dim refDocCode As String
      Dim refDocDate As Date

      If dr.Table.Columns.Contains(aliasPrefix & "gl_refDocType") AndAlso Not dr.IsNull(aliasPrefix & "gl_refDocType") Then
        refDocType = CInt(dr(aliasPrefix & "gl_refDocType"))
      End If
      If dr.Table.Columns.Contains(aliasPrefix & "gl_refid") AndAlso Not dr.IsNull(aliasPrefix & "gl_refid") Then
        refDocId = CInt(dr(aliasPrefix & "gl_refid"))
      End If
      If dr.Table.Columns.Contains(aliasPrefix & "gl_refcode") AndAlso Not dr.IsNull(aliasPrefix & "gl_refcode") Then
        refDocCode = CStr(dr(aliasPrefix & "gl_refcode"))
      End If
      If dr.Table.Columns.Contains(aliasPrefix & "gl_refdate") AndAlso Not dr.IsNull(aliasPrefix & "gl_refdate") Then
        refDocDate = CDate(dr(aliasPrefix & "gl_refdate"))
      End If
      'Hack: harcoded
      gl_reftype = refDocType

      If refDocType = 0 Or refDocType = Me.EntityId Then
        RefDoc = New GenericGlAble
        gl_refDoc.Id = refDocId
        gl_refDoc.Code = refDocCode
        gl_refDoc.Date = refDocDate
        gl_refDoc.Note = Me.Note

        'Comment ����͹ 㹢���ҷ����ǹ�ٻ
        'gl_refjvdoc = New JournalEntry(refDocId)
      Else
        RefDoc = CType(SimpleBusinessEntityBase.GetEntity(Entity.GetFullClassName(refDocType), refDocId), IGLAble)
      End If
    End Sub
    Protected Overloads Overrides Sub Construct(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
      Dim dr As DataRow = ds.Tables(0).Rows(0)
      Construct(dr, aliasPrefix)
    End Sub
#End Region

#Region "Properties"
    Public ReadOnly Property Maindoc() As ISimpleEntity Implements IHasMainDoc.MainDoc
      Get
        Return CType(gl_refDoc, ISimpleEntity)
      End Get
    End Property

    Public ReadOnly Property Editable() As Boolean
      Get
        If TypeOf Me.RefDoc Is ISimpleEntity Then
          Return False
        End If
        Return True
      End Get
    End Property
    ''' <summary>
    ''' Load From DB
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property DBItemCollection() As JournalEntryItemCollection
    Public Property ItemCollection() As JournalEntryItemCollection
      Get
        Return m_itemCollection
      End Get
      Set(ByVal Value As JournalEntryItemCollection)
        m_itemCollection = Value
      End Set
    End Property
    Public Property GLFormat() As GLFormat      Get        Return m_glFormat      End Get      Set(ByVal Value As GLFormat)        m_glFormat = Value        If Not Me.Originated Then          m_glFormat = Value        ElseIf m_glFormat Is Nothing Then
          m_glFormat = Value        End If      End Set    End Property
    Public Property ManualFormat() As Boolean      Get        Return m_manualFormat      End Get      Set(ByVal Value As Boolean)        m_manualFormat = Value      End Set    End Property
    Public ReadOnly Property DebitAmount() As Decimal
      Get
        Dim sumDebit As Decimal = 0
        For Each item As JournalEntryItem In Me.ItemCollection
          If item.IsDebit Then
            sumDebit += item.Amount
          End If
        Next
        Return sumDebit
      End Get
    End Property
    Public ReadOnly Property CreditAmount() As Decimal
      Get
        Dim sumCredit As Decimal = 0
        For Each item As JournalEntryItem In Me.ItemCollection
          If Not item.IsDebit Then
            sumCredit += item.Amount
          End If
        Next
        Return sumCredit
      End Get
    End Property
    Public Property AccountBook() As AccountBook Implements IHasAccountBook.AccountBook      Get        Return gl_accountBook      End Get      Set(ByVal Value As AccountBook)        gl_accountBook = Value      End Set    End Property    Public Property DocDate() As Date Implements ICheckPeriod.DocDate      Get        Return gl_docDate      End Get      Set(ByVal Value As Date)        gl_docDate = Value      End Set    End Property    Public Property Note() As String      Get        Return gl_note      End Get      Set(ByVal Value As String)        gl_note = Value      End Set    End Property    Public Overrides Property Status() As CodeDescription      Get        Return gl_status      End Get      Set(ByVal Value As CodeDescription)        gl_status = CType(Value, JournalEntryStatus)      End Set    End Property    Public Property PostPerson() As User      Get        Return gl_postPerson      End Get      Set(ByVal Value As User)        gl_postPerson = Value      End Set    End Property    Public Property PostDate() As DateTime      Get        Return gl_postDate      End Get      Set(ByVal Value As DateTime)        gl_postDate = Value      End Set    End Property    Public Property RefDoc() As IGLAble      Get        Return gl_refDoc      End Get      Set(ByVal Value As IGLAble)        gl_refDoc = Value        If Not gl_refDoc Is Nothing Then          gl_refDoc.JournalEntry = Me
          If TypeOf gl_refDoc Is IGlChangable Then
            RemoveHandler CType(gl_refDoc, IGlChangable).GlChanged, AddressOf GlChangedHandler
            AddHandler CType(gl_refDoc, IGlChangable).GlChanged, AddressOf GlChangedHandler
          End If
        End If      End Set    End Property
    Private Sub GlChangedHandler(ByVal sender As Object, ByVal e As EventArgs)
      'RefreshGLFormat()
    End Sub
    Public Property RefDoctype() As Integer
      Get
        Return gl_reftype
      End Get
      Set(ByVal Value As Integer)
        gl_reftype = Value
      End Set
    End Property

    Public Property RefJVdoc() As ISimpleEntity
      Get
        Return gl_refjvdoc
      End Get
      Set(ByVal Value As ISimpleEntity)
        gl_refjvdoc = Value
      End Set
    End Property

    Public Overrides ReadOnly Property GetListSprocName() As String
      Get
        Return "GetGLList"
      End Get
    End Property
    Public Overrides ReadOnly Property GetSprocName() As String
      Get
        Return "GetGL"
      End Get
    End Property
    Public Overrides ReadOnly Property ClassName() As String
      Get
        Return "JournalEntry"
      End Get
    End Property
    Public Overrides ReadOnly Property TableName() As String
      Get
        Return "gl"
      End Get
    End Property
    Public Overrides ReadOnly Property Prefix() As String
      Get
        Return "gl"
      End Get
    End Property

    Public Overrides ReadOnly Property DetailPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.JournalEntry.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.JournalEntry"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.JournalEntry"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.JournalEntry.ListLabel}"
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

#Region "Shared"
    Public Shared Function CreateTableStyle() As DataGridTableStyle
      Dim dst As New DataGridTableStyle
      dst.MappingName = "JournalEntry"
      Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)

      Dim csLineNumber As New TreeTextColumn
      csLineNumber.MappingName = "gli_linenumber"
      csLineNumber.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.JournalEntryDetail.LineNumberHeaderText}")
      csLineNumber.NullText = ""
      csLineNumber.Width = 30
      csLineNumber.DataAlignment = HorizontalAlignment.Center
      csLineNumber.ReadOnly = True
      csLineNumber.TextBox.Name = "gli_linenumber"

      Dim csCode As New TreeTextColumn
      csCode.MappingName = "Code"
      csCode.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.JournalEntryDetail.CodeHeaderText}")
      csCode.NullText = ""
      'csCode.ReadOnly = True
      csCode.TextBox.Name = "Code"

      Dim csButton As New DataGridButtonColumn
      csButton.MappingName = "Button"
      csButton.HeaderText = ""
      csButton.NullText = ""
      csButton.ButtonColor = Color.Lavender

      Dim csName As New TreeTextColumn
      csName.MappingName = "Name"
      csName.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.JournalEntryDetail.DescriptionHeaderText}")
      csName.NullText = ""
      csName.Width = 180
      csName.TextBox.Name = "Description"
      csName.ReadOnly = True

      Dim csDebitAmount As New TreeTextColumn
      csDebitAmount.MappingName = "DebitAmount"
      csDebitAmount.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.JournalEntryDetail.DebitAmountHeaderText}")
      csDebitAmount.NullText = ""
      csDebitAmount.DataAlignment = HorizontalAlignment.Right
      csDebitAmount.Format = "#,###.00"
      csDebitAmount.TextBox.Name = "DebitAmount"
      csDebitAmount.Width = 60

      Dim csCreditAmount As New TreeTextColumn
      csCreditAmount.MappingName = "CreditAmount"
      csCreditAmount.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.JournalEntryDetail.CreditAmountHeaderText}")
      csCreditAmount.NullText = ""
      csCreditAmount.DataAlignment = HorizontalAlignment.Right
      csCreditAmount.Format = "#,###.00"
      csCreditAmount.TextBox.Name = "CreditAmount"
      csCreditAmount.Width = 60

      Dim csCCCode As New TreeTextColumn
      csCCCode.MappingName = "CCCode"
      csCCCode.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.JournalEntryDetail.CCCodeHeaderText}")
      csCCCode.NullText = ""
      csCCCode.TextBox.Name = "CCCode"
      csCCCode.Width = 60
      'AddHandler csUnit.TextBox.TextChanged, AddressOf ChangeProperty
      'csUnit.DataAlignment = HorizontalAlignment.Center

      Dim csCCButton As New DataGridButtonColumn
      csCCButton.MappingName = "CCButton"
      csCCButton.HeaderText = ""
      csCCButton.NullText = ""
      AddHandler csCCButton.Click, AddressOf CCClicked

      Dim csCCName As New TreeTextColumn
      csCCName.MappingName = "CCName"
      csCCName.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.JournalEntryDetail.CCNameHeaderText}")
      csCCName.NullText = ""
      csCCName.TextBox.Name = "CCName"
      csCCName.ReadOnly = True
      csCCName.Width = 100

      Dim csNote As New TreeTextColumn
      csNote.MappingName = "gli_note"
      csNote.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.JournalEntryDetail.NoteHeaderText}")
      csNote.NullText = ""
      csNote.Width = 100
      csNote.TextBox.Name = "gli_note"

      dst.GridColumnStyles.Add(csLineNumber)
      dst.GridColumnStyles.Add(csCode)
      dst.GridColumnStyles.Add(csButton)
      dst.GridColumnStyles.Add(csName)
      dst.GridColumnStyles.Add(csDebitAmount)
      dst.GridColumnStyles.Add(csCreditAmount)
      dst.GridColumnStyles.Add(csCCCode)
      dst.GridColumnStyles.Add(csCCButton)
      dst.GridColumnStyles.Add(csCCName)
      dst.GridColumnStyles.Add(csNote)

      Return dst
    End Function
    Public Shared Sub CCClicked(ByVal e As ButtonColumnEventArgs)
      If e.Column = 2 Then
        RaiseEvent AcctButtonClick(e)
      Else
        RaiseEvent CCButtonClick(e)
      End If
    End Sub
    Public Shared Event AcctButtonClick As DataGridButtonColumn.ButtonColumnClickHandler
    Public Shared Event CCButtonClick As DataGridButtonColumn.ButtonColumnClickHandler

    Public Shared Function GetSchemaTable() As TreeTable
      Dim myDatatable As New TreeTable("JournalEntry")
      myDatatable.Columns.Add(New DataColumn("gli_linenumber", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("gli_acct", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("Code", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Button", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Name", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("gli_cc", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("CCCode", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("CCButton", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("CCName", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("gli_amt", GetType(Decimal)))
      myDatatable.Columns.Add(New DataColumn("gli_isdebit", GetType(Boolean)))
      myDatatable.Columns.Add(New DataColumn("DebitAmount", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("CreditAmount", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("gli_note", GetType(String)))
      Return myDatatable
    End Function
#End Region

#Region "Methods"
    Public Sub SetAccountBookFromEntity(ByVal entityId As Integer)
      Try
        Dim ds As DataSet = SqlHelper.ExecuteDataset(SimpleBusinessEntityBase.ConnectionString, CommandType.StoredProcedure, "GetAccountBookFromEntity", New SqlParameter("@entity_id", entityId))
        If Not ds.Tables(0).Rows(0).IsNull("accountbook_id") Then
          Me.AccountBook = New AccountBook(ds.Tables(0).Rows(0), "")
        End If
      Catch ex As Exception

      End Try
    End Sub
    Public Sub RefreshGLFormat()
      If Not Me.ManualFormat Then
        'If Not TypeOf Me.RefDoc Is GoodsSold _
        'AndAlso Not TypeOf Me.RefDoc Is PurchaseCN Then
        Me.GLFormat = Me.RefDoc.GetDefaultGLFormat
        Me.SetGLFormat(Me.GLFormat)
        'End If
      End If
    End Sub
    Public Function GetUnpostListTable(ByVal startDate As Date, ByVal endDate As Date) As DataTable
      Dim params(1) As SqlParameter
      params(0) = New SqlParameter("@docdatestart", startDate)
      params(1) = New SqlParameter("@docdateend", endDate)
      Dim ds As DataSet = SqlHelper.ExecuteDataset(Me.ConnectionString, CommandType.StoredProcedure, "GetUnPostGLList", params)
      ds.Tables(0).TableName = Me.ClassName
      Return ds.Tables(0)
    End Function
    Public Sub SetGLFormat(ByVal glf As GLFormat)
      If Me.RefDoc Is Nothing Then
        Return
      End If
      '�����鹷ع����� ˹�Ң�� ����ѧ������ӷ���
      'If Me.RefDoc.Id <> 0 AndAlso Me.Id = 0 Then
      '  Return
      'End If

      '===================Check ��� GL ����¹��� ================================
      If TypeOf Me.RefDoc Is IGLCheckingBeforeRefresh AndAlso TypeOf Me.RefDoc Is SimpleBusinessEntityBase Then
        If Not CType(Me.RefDoc, SimpleBusinessEntityBase).GLIsChanged Then
          '�������¹ ==> �͡���
          Return
        Else
          '����¹ ==> ����¹��Ѻ ����仵��
          CType(Me.RefDoc, SimpleBusinessEntityBase).GLIsChanged = False
        End If
      End If
      '===================Check ��� GL ����¹��� ================================

      Me.RefDoctype = CType(Me.RefDoc, IObjectReflectable).EntityId
      Dim entriesFromDoc As JournalEntryItemCollection = Me.RefDoc.GetJournalEntries
      Me.AccountBook = glf.AccountBook
      Me.ItemCollection.Clear()
      If entriesFromDoc.Count = 0 Then
        Return
      End If



      '-------------------------------Basic-------------------------------
      For Each glfi As GLFormatItem In glf.ItemCollection
        If glfi.Mapping.ToLower.IndexOf("sumdebit") < 0 AndAlso glfi.Mapping.ToLower.IndexOf("sumcredit") < 0 Then
          Dim matchItems As JournalEntryItemCollection = entriesFromDoc.GetMappingItems(glfi)
          For Each matchItem As JournalEntryItem In matchItems
            Me.ItemCollection.Add(matchItem)
          Next
        End If
      Next
      '-------------------------------Basic--------------------------------

      '-------------------------------Bypass �ç��Ҩҡ Entity--------------------------------
      Dim throughMatchItems As JournalEntryItemCollection = entriesFromDoc.GetExactMappingItems("Through")
      For Each matchItem As JournalEntryItem In throughMatchItems
        If Not matchItem Is Nothing Then
          Dim myItem As New JournalEntryItem
          myItem.Account = matchItem.Account
          myItem.Amount = matchItem.Amount
          If myItem.Amount <> 0 Then
            If myItem.Amount > 0 Then
              myItem.IsDebit = matchItem.IsDebit
            Else
              myItem.Amount = -myItem.Amount
              myItem.IsDebit = Not matchItem.IsDebit
            End If
            myItem.CostCenter = matchItem.CostCenter
            myItem.Note = matchItem.Note
            Me.ItemCollection.Add(myItem)
          End If
        Else
          'Todo: Error
        End If
      Next
      '-------------------------------Bypass �ç��Ҩҡ Entity--------------------------------

      '-------------------------------�Ѵ���--------------------------------
      '��ûѴ��� ���������Թ 1 ���ҡ�����Թ �֧�� 1*�ӹǹ��ҹ debit (�ѧ�������䧵���)
      Dim diff As Decimal = Me.DebitAmount - Me.CreditAmount
      If Math.Abs(diff) <> 0 AndAlso Math.Abs(diff) < entriesFromDoc.Count Then
        Dim ji As New JournalEntryItem
        If TypeOf Me.RefDoc Is IHasToCostCenter Then
          ji.CostCenter = CType(Me.RefDoc, IHasToCostCenter).ToCC
        Else
          ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
        End If
        ji.IsDebit = (diff < 0)
        'If diff < 0 Then
        diff = Math.Abs(diff)
        'End If
        ji.Amount = Configuration.Format(diff, DigitConfig.Price)
        ji.Account = GeneralAccount.GetDefaultGA(GeneralAccount.DefaultGAType.DiffFromDecimalPlace).Account
        Me.ItemCollection.Add(ji)
      End If
      '-------------------------------�Ѵ���--------------------------------

      '-------------------------------Sumdebit/Sumcredit--------------------------------
      'Loop �ա��������� Sum
      For Each glfi As GLFormatItem In glf.ItemCollection
        If glfi.Mapping.ToLower.IndexOf("sumdebit") >= 0 OrElse glfi.Mapping.ToLower.IndexOf("sumcredit") >= 0 Then
          Dim ji As New JournalEntryItem
          ji.Account = glfi.Account
          Dim cc As CostCenter = glfi.CostCenter
          If Not cc Is Nothing AndAlso cc.Originated Then
            ji.CostCenter = cc
          Else
            ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
          End If
          Dim mapping As String = glfi.Mapping.ToLower
          If glfi.Mapping.ToLower.IndexOf("sumdebit") >= 0 Then
            mapping = mapping.Replace("sumdebit", Me.DebitAmount.ToString)
          End If
          If glfi.Mapping.ToLower.IndexOf("sumcredit") >= 0 Then
            mapping = mapping.Replace("sumcredit", Me.CreditAmount.ToString)
          End If
          Dim reg As New Regex("[A-Za-z]+[0-9]*(\.?[0-9]+)+")
          reg.Replace(mapping, "0")
          Dim amt As Decimal = CDec(TextHelper.TextParser.Evaluate(mapping))
          ji.Amount = Configuration.Format(amt, DigitConfig.Price)
          If ji.Amount <> 0 Then
            If ji.Amount > 0 Then
              ji.IsDebit = glfi.IsDebit
            Else
              ji.Amount = -ji.Amount
              ji.IsDebit = Not glfi.IsDebit
            End If
            ji.Note = glfi.Field.Name
            Me.ItemCollection.Add(ji)
          End If
        End If
      Next
      '-------------------------------Sumdebit/Sumcredit--------------------------------

    End Sub

    Private saveParamArrayList As ArrayList
    Private saveReturnVal As System.Data.SqlClient.SqlParameter
    Private saveUser As User
    Private saveTime As Date
    Public Function BeforeSave(ByVal currentUserId As Integer) As SaveErrorException
      RefreshGLFormat()
      Dim tmpdebit As Decimal = Configuration.Format(DebitAmount, DigitConfig.Price)
      Dim tmpcredit As Decimal = Configuration.Format(CreditAmount, DigitConfig.Price)
      If tmpdebit <> tmpcredit Then
        Return New SaveErrorException(Me.StringParserService.Parse("${res:Global.Error.UnBalanceDebitCredit}"))
      End If

      'saveReturnVal = New SqlParameter
      'saveReturnVal.ParameterName = "RETURN_VALUE"
      'saveReturnVal.DbType = DbType.Int32
      'saveReturnVal.Direction = ParameterDirection.ReturnValue
      'saveReturnVal.SourceVersion = DataRowVersion.Current

      'saveParamArrayList = New ArrayList

      'saveParamArrayList.Add(saveReturnVal)

      'If Me.Originated Then
      '  saveParamArrayList.Add(New SqlParameter("@gl_id", Me.Id))
      'End If

      'saveTime = Now
      'saveUser = New User(currentUserId)
      'If Me.Status.Value = -1 Then
      '  Me.Status.Value = 2
      'End If

      'saveParamArrayList.Add(New SqlParameter("@gl_accountbook", IIf(Me.AccountBook.Originated, Me.AccountBook.Id, DBNull.Value)))
      'saveParamArrayList.Add(New SqlParameter("@gl_debitamt", Me.DebitAmount))
      'saveParamArrayList.Add(New SqlParameter("@gl_creditamt", Me.CreditAmount))
      'saveParamArrayList.Add(New SqlParameter("@gl_glFormat", IIf(Me.GLFormat.Originated, Me.GLFormat.Id, DBNull.Value)))
      'saveParamArrayList.Add(New SqlParameter("@gl_manualformat", Me.ManualFormat))
      'saveParamArrayList.Add(New SqlParameter("@gl_note", Me.Note))
      'saveParamArrayList.Add(New SqlParameter("@gl_status", Me.Status.Value))


      'If Me.RefDoc Is Nothing _
      'OrElse Me.RefDoctype = Me.EntityId Then
      '  saveRefType = Me.EntityId
      '  If Me.RefJVdoc.Originated Then
      '    RefDoc.Id = RefJVdoc.Id
      '    RefDoc.Date = CType(RefJVdoc, JournalEntry).DocDate
      '    RefDoc.Note = Me.Note
      '    Dim refDebit As Decimal
      '    Dim refCredit As Decimal
      '    Dim jv As New JournalEntry(RefJVdoc.Id)
      '    'If Me.DebitAmount <> jv.DebitAmount Then
      '    '  ' TODO : ����͹
      '    '  'Dim msgServics As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      '    '  'Dim b As Boolean = msgServics.AskQuestion("�ʹ���١��ͧ")
      '    '  'MessageBox.Show(b.ToString)
      '    'End If
      '  End If
      'Else
      '  saveRefType = CType(Me.RefDoc, ISimpleEntity).EntityId
      'End If

      'Dim config As Boolean = CBool(Configuration.GetConfig("JEDateComesFromDocDate"))
      'If config Then
      '  If Not Me.DocDate.Equals(Me.RefDoc.Date) Then
      '    Me.AutoGen = True
      '    Me.Code = ""
      '  End If
      '  Me.DocDate = Me.RefDoc.Date
      'End If
      'If IsDBNull(Me.ValidDateOrDBNull(Me.DocDate)) Then
      '  Me.DocDate = Me.RefDoc.Date
      'End If
      'If Me.AutoGen And Me.Code.Length = 0 Then
      '  Me.Code = Me.GetNextCode
      'End If
      'Me.AutoGen = False

      'If Not Me.RefDoc Is Nothing Then
      '  If Me.Code Is Nothing OrElse Me.Code.Length = 0 Then
      '    Me.Code = Me.RefDoc.Code
      '  End If
      'End If

      'saveParamArrayList.Add(New SqlParameter("@gl_code", Me.Code))
      'saveParamArrayList.Add(New SqlParameter("@gl_docDate", IIf(Me.DocDate.Equals(Date.MinValue), DBNull.Value, Me.DocDate)))
      'If Not Me.RefDoc Is Nothing AndAlso Not Me.RefDoc.Code Is Nothing Then
      '  saveParamArrayList.Add(New SqlParameter("@gl_refcode", IIf(Me.RefDoc.Code.Length = 0, DBNull.Value, Me.RefDoc.Code)))
      'End If
      'saveParamArrayList.Add(New SqlParameter("@gl_refDate", IIf(Me.RefDoc.Date.Equals(Date.MinValue), DBNull.Value, Me.RefDoc.Date)))
      'saveParamArrayList.Add(New SqlParameter("@gl_refid", IIf(Me.RefDoc.Id <> 0, Me.RefDoc.Id, DBNull.Value)))
      'saveParamArrayList.Add(New SqlParameter("@gl_refdoctype", saveRefType))
      'If Me.RefDoc.Note Is Nothing Then Me.RefDoc.Note = ""
      'saveParamArrayList.Add(New SqlParameter("@gl_refDocNote", IIf(Me.RefDoc.Note.Length = 0, DBNull.Value, Me.RefDoc.Note)))

      'SetOriginEditCancelStatus(saveParamArrayList, currentUserId, saveTime)

      Return New SaveErrorException("0")
    End Function


    Public Overloads Overrides Function Save(ByVal currentUserId As Integer, ByVal conn As System.Data.SqlClient.SqlConnection, ByVal trans As System.Data.SqlClient.SqlTransaction) As SaveErrorException
      If DontSave Then
        Return New SaveErrorException("0")
      End If
      'RefreshGLFormat()
      With Me
        'Dim tmpdebit As Decimal = Configuration.Format(DebitAmount, DigitConfig.Price)
        'Dim tmpcredit As Decimal = Configuration.Format(CreditAmount, DigitConfig.Price)
        'If tmpdebit <> tmpcredit Then
        '  Return New SaveErrorException(Me.StringParserService.Parse("${res:Global.Error.UnBalanceDebitCredit}"))
        'End If
        'Dim returnVal As System.Data.SqlClient.SqlParameter = New SqlParameter
        'returnVal.ParameterName = "RETURN_VALUE"
        'returnVal.DbType = DbType.Int32
        'returnVal.Direction = ParameterDirection.ReturnValue
        'returnVal.SourceVersion = DataRowVersion.Current

        saveReturnVal = New SqlParameter
        saveReturnVal.ParameterName = "RETURN_VALUE"
        saveReturnVal.DbType = DbType.Int32
        saveReturnVal.Direction = ParameterDirection.ReturnValue
        saveReturnVal.SourceVersion = DataRowVersion.Current

        saveParamArrayList = New ArrayList

        saveParamArrayList.Add(saveReturnVal)

        If Me.Originated Then
          saveParamArrayList.Add(New SqlParameter("@gl_id", Me.Id))
        End If

        saveTime = Now
        saveUser = New User(currentUserId)
        If Me.Status.Value = -1 Then
          Me.Status.Value = 2
        End If

        ' ���ҧ ArrayList �ҡ Item �ͧ  SqlParameter ...
        'Dim paramArrayList As New ArrayList

        'saveParamArrayList.Add(returnVal)

        'If Me.Originated Then
        '  saveParamArrayList.Add(New SqlParameter("@gl_id", Me.Id))
        'End If

        'Dim theTime As Date = Now
        'Dim theUser As New User(currentUserId)
       

        saveParamArrayList.Add(New SqlParameter("@gl_accountbook", IIf(Me.AccountBook.Originated, Me.AccountBook.Id, DBNull.Value)))
        saveParamArrayList.Add(New SqlParameter("@gl_debitamt", Me.DebitAmount))
        saveParamArrayList.Add(New SqlParameter("@gl_creditamt", Me.CreditAmount))
        saveParamArrayList.Add(New SqlParameter("@gl_glFormat", IIf(Me.GLFormat.Originated, Me.GLFormat.Id, DBNull.Value)))
        saveParamArrayList.Add(New SqlParameter("@gl_manualformat", Me.ManualFormat))
        saveParamArrayList.Add(New SqlParameter("@gl_note", Me.Note))
        saveParamArrayList.Add(New SqlParameter("@gl_status", Me.Status.Value))
        Dim refType As Integer
        If Me.RefDoc Is Nothing _
        OrElse Me.RefDoctype = Me.EntityId Then
          refType = Me.EntityId
          If Me.RefJVdoc.Originated Then
            RefDoc.Id = RefJVdoc.Id
            RefDoc.Date = CType(RefJVdoc, JournalEntry).DocDate
            RefDoc.Note = Me.Note
            'Dim refDebit As Decimal
            'Dim refCredit As Decimal
            'Dim jv As New JournalEntry(RefJVdoc.Id)
            'If Me.DebitAmount <> jv.DebitAmount Then
            '  ' TODO : ����͹
            '  'Dim msgServics As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
            '  'Dim b As Boolean = msgServics.AskQuestion("�ʹ���١��ͧ")
            '  'MessageBox.Show(b.ToString)
            'End If
          End If
        Else
          refType = CType(Me.RefDoc, ISimpleEntity).EntityId
        End If

        Dim config As Boolean = CBool(Configuration.GetConfig("JEDateComesFromDocDate"))
        If config Then
          If Not Me.DocDate.Equals(Me.RefDoc.Date) Then
            Me.AutoGen = True
            Me.Code = ""
          End If
          Me.DocDate = Me.RefDoc.Date
        End If
        If IsDBNull(Me.ValidDateOrDBNull(Me.DocDate)) Then
          Me.DocDate = Me.RefDoc.Date
        End If
        If Me.AutoGen And Me.Code.Length = 0 Then
          Me.Code = Me.GetNextCode
        End If
        Me.AutoGen = False

        If Not Me.RefDoc Is Nothing Then
          If Me.Code Is Nothing OrElse Me.Code.Length = 0 Then
            Me.Code = Me.RefDoc.Code
          End If
        End If

        saveParamArrayList.Add(New SqlParameter("@gl_code", Me.Code))
        saveParamArrayList.Add(New SqlParameter("@gl_docDate", IIf(Me.DocDate.Equals(Date.MinValue), DBNull.Value, Me.DocDate)))
        If Not Me.RefDoc Is Nothing AndAlso Not Me.RefDoc.Code Is Nothing Then
          saveParamArrayList.Add(New SqlParameter("@gl_refcode", IIf(Me.RefDoc.Code.Length = 0, DBNull.Value, Me.RefDoc.Code)))
        End If
        saveParamArrayList.Add(New SqlParameter("@gl_refDate", IIf(Me.RefDoc.Date.Equals(Date.MinValue), DBNull.Value, Me.RefDoc.Date)))
        saveParamArrayList.Add(New SqlParameter("@gl_refid", IIf(Me.RefDoc.Id <> 0, Me.RefDoc.Id, DBNull.Value)))
        saveParamArrayList.Add(New SqlParameter("@gl_refdoctype", refType))
        If Me.RefDoc.Note Is Nothing Then Me.RefDoc.Note = ""
        saveParamArrayList.Add(New SqlParameter("@gl_refDocNote", IIf(Me.RefDoc.Note.Length = 0, DBNull.Value, Me.RefDoc.Note)))

        SetOriginEditCancelStatus(saveParamArrayList, currentUserId, saveTime)

        ' ���ҧ SqlParameter �ҡ ArrayList ...
        Dim sqlparams() As SqlParameter
        sqlparams = CType(saveParamArrayList.ToArray(GetType(SqlParameter)), SqlParameter())
        Try
          Me.ExecuteSaveSproc(conn, trans, saveReturnVal, sqlparams, saveTime, saveUser)
          If IsNumeric(saveReturnVal.Value) Then
            Select Case CInt(saveReturnVal.Value)
              Case -1
                Return New SaveErrorException("GL " & Me.StringParserService.Parse("${res:Global.Error.AlreadyHasThisCode}"), New String() {Me.Code})
              Case -5
                Return New SaveErrorException(saveReturnVal.Value.ToString)
              Case -2
                Return New SaveErrorException(saveReturnVal.Value.ToString)
              Case Else
            End Select
          ElseIf IsDBNull(saveReturnVal.Value) OrElse Not IsNumeric(saveReturnVal.Value) Then
            Return New SaveErrorException(saveReturnVal.Value.ToString)
          End If
          Dim count As Integer = SaveDetail(Me.Id, conn, trans)
          Dim verbose As Boolean = True
          If TypeOf Me.RefDoc Is SimpleBusinessEntityBase Then
            verbose = Not CType(Me.RefDoc, SimpleBusinessEntityBase).NoSaveMessage
          End If
          If verbose AndAlso Me.Status.Value = 4 Then
            Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
            msgServ.ShowMessageFormatted("${res:Global.Info.PostItemCount}", New String() {count.ToString, Configuration.FormatToString(CreditAmount, DigitConfig.Price)})
          End If
          Return New SaveErrorException(saveReturnVal.Value.ToString)
        Catch ex As SqlException
          Return New SaveErrorException(ex.ToString)
        Catch ex As Exception
          Return New SaveErrorException(ex.ToString)
        End Try
      End With
    End Function
    Private ReadOnly Property PMOnHold As Boolean
      Get
        If TypeOf Me.RefDoc Is IPayable Then
          Dim pm As Payment = CType(Me.RefDoc, IPayable).Payment
          If pm IsNot Nothing AndAlso pm.OnHold Then
            Return True
          End If
        End If
        Return False
      End Get
    End Property
    Public Overloads Overrides Function Save(ByVal currentUserId As Integer) As SaveErrorException
      If DontSave Then
        Return New SaveErrorException("0")
      End If
      With Me
        If Me.ItemCollection.Count <= 0 Then
          Return New SaveErrorException(Me.StringParserService.Parse("${res:Global.Error.NoItem}"))
        End If
        Dim tmpdebit As Decimal = Configuration.Format(DebitAmount, DigitConfig.Price)
        Dim tmpcredit As Decimal = Configuration.Format(CreditAmount, DigitConfig.Price)
        If tmpdebit <> tmpcredit Then
          Return New SaveErrorException(Me.StringParserService.Parse("${res:Global.Error.UnBalanceDebitCredit}"))
        End If
        Dim returnVal As System.Data.SqlClient.SqlParameter = New SqlParameter
        returnVal.ParameterName = "RETURN_VALUE"
        returnVal.DbType = DbType.Int32
        returnVal.Direction = ParameterDirection.ReturnValue
        returnVal.SourceVersion = DataRowVersion.Current

        ' ���ҧ ArrayList �ҡ Item �ͧ  SqlParameter ...
        Dim paramArrayList As New ArrayList

        paramArrayList.Add(returnVal)

        If Me.Originated Then
          paramArrayList.Add(New SqlParameter("@gl_id", Me.Id))
        End If

        Dim theTime As Date = Now
        Dim theUser As New User(currentUserId)
        If Me.Status.Value = -1 Then
          Me.Status.Value = 2
        End If


        paramArrayList.Add(New SqlParameter("@gl_accountbook", IIf(Me.AccountBook.Originated, Me.AccountBook.Id, DBNull.Value)))
        paramArrayList.Add(New SqlParameter("@gl_debitamt", Me.DebitAmount))
        paramArrayList.Add(New SqlParameter("@gl_creditamt", Me.CreditAmount))
        paramArrayList.Add(New SqlParameter("@gl_glFormat", IIf(Me.GLFormat.Originated, Me.GLFormat.Id, DBNull.Value)))
        paramArrayList.Add(New SqlParameter("@gl_manualformat", Me.ManualFormat))
        paramArrayList.Add(New SqlParameter("@gl_note", Me.Note))
        paramArrayList.Add(New SqlParameter("@gl_status", Me.Status.Value))
        Dim refType As Integer
        If Me.RefDoc Is Nothing _
        OrElse Me.RefDoctype = Me.EntityId Then
          refType = Me.EntityId
          If Me.RefJVdoc.Originated Then
            RefDoc.Id = RefJVdoc.Id
            RefDoc.Date = CType(RefJVdoc, JournalEntry).DocDate
            RefDoc.Note = Me.Note
            Dim refDebit As Decimal
            Dim refCredit As Decimal
            Dim jv As New JournalEntry(RefJVdoc.Id)
            If Me.DebitAmount <> jv.DebitAmount Then
              ' TODO : ����͹
              'Dim msgServics As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
              'Dim b As Boolean = msgServics.AskQuestion("�ʹ���١��ͧ")
              'MessageBox.Show(b.ToString)
            End If
          End If
        Else
          refType = CType(Me.RefDoc, ISimpleEntity).EntityId
        End If

        If Me.AutoGen And Me.Code.Length = 0 Then
          If Me.Code Is Nothing OrElse Me.Code.Length = 0 Then
            Me.Code = Me.RefDoc.Code
          End If
          Dim config As Boolean = CBool(Configuration.GetConfig("JEDateComesFromDocDate"))
          If config Then
            Me.DocDate = Me.RefDoc.Date
          End If
          Me.Code = Me.GetNextCode
        End If
        Me.AutoGen = False

        If Not Me.RefDoc Is Nothing Then
          If IsDBNull(Me.ValidDateOrDBNull(Me.DocDate)) Then
            Me.DocDate = Me.RefDoc.Date
          End If
        End If

        paramArrayList.Add(New SqlParameter("@gl_code", Me.Code))
        paramArrayList.Add(New SqlParameter("@gl_docDate", IIf(Me.DocDate.Equals(Date.MinValue), DBNull.Value, Me.DocDate)))
        If Not Me.RefDoc Is Nothing AndAlso Not Me.RefDoc.Code Is Nothing Then
          paramArrayList.Add(New SqlParameter("@gl_refcode", IIf(Me.RefDoc.Code.Length = 0, DBNull.Value, Me.RefDoc.Code)))
        End If
        paramArrayList.Add(New SqlParameter("@gl_refDate", IIf(Me.RefDoc.Date.Equals(Date.MinValue), DBNull.Value, Me.RefDoc.Date)))
        paramArrayList.Add(New SqlParameter("@gl_refid", IIf(Me.RefDoc.Id <> 0, Me.RefDoc.Id, DBNull.Value)))
        paramArrayList.Add(New SqlParameter("@gl_refdoctype", refType))
        If Me.RefDoc.Note Is Nothing Then Me.RefDoc.Note = ""
        paramArrayList.Add(New SqlParameter("@gl_refDocNote", IIf(Me.RefDoc.Note.Length = 0, DBNull.Value, Me.RefDoc.Note)))

        SetOriginEditCancelStatus(paramArrayList, currentUserId, theTime)

        ' ���ҧ SqlParameter �ҡ ArrayList ...
        Dim sqlparams() As SqlParameter
        sqlparams = CType(paramArrayList.ToArray(GetType(SqlParameter)), SqlParameter())
        Dim trans As SqlTransaction
        Dim conn As New SqlConnection(Me.ConnectionString)
        conn.Open()
        trans = conn.BeginTransaction()
        Try
          Me.ExecuteSaveSproc(conn, trans, returnVal, sqlparams, theTime, theUser)
          If IsNumeric(returnVal.Value) Then
            Select Case CInt(returnVal.Value)
              Case -1, -2
                trans.Rollback()
                Return New SaveErrorException(returnVal.Value.ToString)
              Case Else
            End Select
          ElseIf IsDBNull(returnVal.Value) OrElse Not IsNumeric(returnVal.Value) Then
            trans.Rollback()
            Return New SaveErrorException(returnVal.Value.ToString)
          End If
          Dim count As Integer = SaveDetail(Me.Id, conn, trans)
          Dim verbose As Boolean = True
          If TypeOf Me.RefDoc Is SimpleBusinessEntityBase Then
            verbose = Not CType(Me.RefDoc, SimpleBusinessEntityBase).NoSaveMessage
          End If
          If verbose AndAlso Me.Status.Value = 4 Then
            Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
            msgServ.ShowMessageFormatted("${res:Global.Info.PostItemCount}", New String() {count.ToString, Configuration.FormatToString(CreditAmount, DigitConfig.Price)})
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
          conn.Close()
        End Try
      End With
    End Function
    Private Function SaveDetail(ByVal parentID As Integer, ByVal conn As SqlConnection, ByVal trans As SqlTransaction) As Integer
      'If Not Me.ManualFormat Then
      '    If Not TypeOf Me.RefDoc Is GoodsSold _
      '    AndAlso Not TypeOf Me.RefDoc Is PurchaseCN Then
      '        If Me.GLFormat Is Nothing OrElse Not Me.GLFormat.Originated Then
      '            Me.GLFormat = Me.RefDoc.GetDefaultGLFormat
      '        End If
      '        Me.SetGLFormat(Me.GLFormat)
      '    End If
      'End If

      Dim da As New SqlDataAdapter("Select * from glitem where gli_gl=" & Me.Id, conn)
      Dim cmdBuilder As New SqlCommandBuilder(da)

      Dim ds As New DataSet

      da.SelectCommand.Transaction = trans

      '��ͧ�����ͨҡ da.SelectCommand.Transaction = trans
      cmdBuilder.GetDeleteCommand.Transaction = trans
      cmdBuilder.GetInsertCommand.Transaction = trans
      cmdBuilder.GetUpdateCommand.Transaction = trans

      da.Fill(ds, "glitem")

      Dim i As Integer = 0
      With ds.Tables("glitem")
        For Each row As DataRow In .Rows
          row.Delete()
        Next

        'End If
        For Each item As JournalEntryItem In Me.ItemCollection
          i += 1
          Dim dr As DataRow = .NewRow
          dr("gli_gl") = Me.Id
          dr("gli_linenumber") = i     'item("gli_linenumber")
          dr("gli_acct") = Me.ValidIdOrDBNull(item.Account)
          dr("gli_cc") = Me.ValidIdOrDBNull(item.CostCenter)
          dr("gli_isdebit") = item.IsDebit
          dr("gli_amt") = Configuration.FormatToString(item.Amount, DigitConfig.Price)
          dr("gli_note") = item.Note
          dr("gli_status") = Me.Status.Value
          If Not item.Account Is Nothing AndAlso item.Account.Originated Then
            If TypeOf (Me.RefDoc) Is IPayable OrElse TypeOf (Me.RefDoc) Is IReceivable Then
              If item.Account.Type Is Nothing Then
                item.Account = New Account(item.Account.Id)
              End If
              Select Case item.Account.Type.Value
                Case 2
                  If TypeOf (Me.RefDoc) Is IPayable Then
                    If Not (CType(Me.RefDoc, IPayable).Payment Is Nothing) Then
                      dr("gli_entity") = CType(Me.RefDoc, IPayable).Recipient.Id
                      dr("gli_entitytype") = CType(CType(Me.RefDoc, IPayable).Recipient, SimpleBusinessEntityBase).EntityId
                    End If
                  End If
                  If TypeOf (Me.RefDoc) Is IReceivable Then
                    If Not (CType(Me.RefDoc, IReceivable).Receive Is Nothing) Then
                      dr("gli_entity") = CType(Me.RefDoc, IReceivable).Payer.Id
                      dr("gli_entitytype") = CType(CType(Me.RefDoc, IReceivable).Payer, SimpleBusinessEntityBase).EntityId
                    End If
                  End If
              End Select
            Else
              dr("gli_entity") = item.EntityItem
              dr("gli_entitytype") = item.EntityItemType
            End If

          End If
          dr("gli_entity") = item.EntityItem
          dr("gli_entitytype") = item.EntityItemType
          .Rows.Add(dr)
        Next
      End With
      Dim dt As DataTable = ds.Tables("glitem")
      ' First process deletes.
      da.Update(dt.Select(Nothing, Nothing, DataViewRowState.Deleted))
      ' Next process updates.
      da.Update(dt.Select(Nothing, Nothing, DataViewRowState.ModifiedCurrent))
      ' Finally process inserts.
      da.Update(dt.Select(Nothing, Nothing, DataViewRowState.Added))
      Return i
    End Function
    Public Shared Function PostData(ByVal DocID As Integer, ByVal currentUserId As Integer, ByVal theTime As Date) As SaveErrorException
      Dim myGL As New JournalEntry(DocID)
      With myGL
        Dim returnVal As System.Data.SqlClient.SqlParameter = New SqlParameter
        returnVal.ParameterName = "RETURN_VALUE"
        returnVal.DbType = DbType.Int32
        returnVal.Direction = ParameterDirection.ReturnValue
        returnVal.SourceVersion = DataRowVersion.Current
        ' ���ҧ ArrayList �ҡ Item �ͧ  SqlParameter ...
        Dim paramArrayList As New ArrayList

        paramArrayList.Add(returnVal)
        paramArrayList.Add(New SqlParameter("@gl_id", DocID))
        paramArrayList.Add(New SqlParameter("@gl_postperson", currentUserId))
        paramArrayList.Add(New SqlParameter("@gl_postdate", theTime))

        ' ���ҧ SqlParameter �ҡ ArrayList ...
        Dim sqlparams() As SqlParameter
        sqlparams = CType(paramArrayList.ToArray(GetType(SqlParameter)), SqlParameter())

        ' ��� Transaction �Ǻ��������ǹ�ͧ Client �����Ҩ������ loop ��
        Try
          SqlHelper.ExecuteNonQuery(JournalEntry.ConnectionString, CommandType.StoredProcedure, "PostJournalEntry", sqlparams)
          Return New SaveErrorException(returnVal.Value.ToString)
        Catch ex As SqlException
          Return New SaveErrorException(ex.ToString)
        Catch ex As Exception
          Return New SaveErrorException(ex.ToString)
        End Try
      End With
    End Function
    Public Sub GLPost(ByVal currentUserId As Integer)
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      Dim sql As String
      Dim entityList As String
      Dim dsEntityList As DataSet
      Dim dsEntity As DataSet
      Dim dsItem As DataSet
      Dim swStr As String
      Dim docTable As String
      docTable = CType(Me.RefDoc, SimpleBusinessEntityBase).TableName

      Dim glidstring As String = Me.Id.ToString

      ' สร้าง ArrayList จาก Item ของ  SqlParameter ...
      Dim paramArrayList As New ArrayList
      paramArrayList.Add(New SqlParameter("@gl_idList", glidstring))
      paramArrayList.Add(New SqlParameter("@CurrentUserId", currentUserId))

      Dim sqlparams() As SqlParameter
      sqlparams = CType(paramArrayList.ToArray(GetType(SqlParameter)), SqlParameter())

      Dim trans As SqlTransaction
      Dim conn As New SqlConnection(Me.ConnectionString)
      conn.Open()

      trans = conn.BeginTransaction()
      Try
        'entityList = Me.RefDoctype.ToString
        'entityList = entityList & ",38"
        'If TypeOf (Me.RefDoc) Is IVatable Then
        '  entityList = entityList & ",55"
        'End If
        'If TypeOf (Me.RefDoc) Is IWitholdingTaxable Then
        '  entityList = entityList & ",69"
        'End If
        'If TypeOf (Me.RefDoc) Is IBillAcceptable Then
        '  entityList = entityList & ",68"
        'End If
        'If TypeOf (Me.RefDoc) Is IBillIssuable Then
        '  entityList = entityList & ",74"
        'End If


        'sql = "select entity_id [id],entity_table [table],entity_prefix [prefix] from Entity where entity_id in (" & entityList & ")"
        'dsEntityList = SqlHelper.ExecuteDataset(Me.ConnectionString, CommandType.Text, sql)


        'For Each row As DataRow In dsEntityList.Tables(0).Rows

        '  If CInt(row("id")) = Me.RefDoctype Then
        '    sql = "select " _
        '    & CStr(row("prefix")) & "_id [id]," _
        '    & CStr(row("prefix")) & "_status [status]" _
        '    & " from " & CStr(row("table")) _
        '    & " where " & CStr(row("prefix")) & "_id = " & Me.RefDoc.Id
        '  Else
        '    If CStr(row("table")) = "gl" Then
        '      swStr = "refid"
        '    Else
        '      swStr = "refdoc"
        '    End If
        '    sql = "select " _
        '    & CStr(row("prefix")) & "_id [id]," _
        '    & CStr(row("prefix")) & "_status [status]" _
        '    & " from " & CStr(row("table")) _
        '    & " where " & CStr(row("prefix")) & "_" & swStr & " = " & Me.RefDoc.Id _
        '    & " and " & CStr(row("prefix")) & "_refdoctype = " & Me.RefDoctype
        '  End If
        '  dsEntity = SqlHelper.ExecuteDataset(Me.ConnectionString, CommandType.Text, sql)
        '  For Each row2 As DataRow In dsEntity.Tables(0).Rows

        '    sql = "insert into glpost " _
        '    & "(glp_gl,glp_docid,glp_doctype,glp_docstatus)" _
        '    & " values (" & Me.Id & "," & CInt(row2("id")) & "," _
        '    & CInt(row("id")) & "," & CInt(row2("status")) & ")"

        '    SqlHelper.ExecuteNonQuery(conn, trans, CommandType.Text, sql)

        '    sql = "update " & CStr(row("table")) _
        '    & " set " & CStr(row("prefix")) & "_status = 4" _
        '    & " where " & CStr(row("prefix")) & "_id = " & CInt(row2("id"))

        '    SqlHelper.ExecuteNonQuery(conn, trans, CommandType.Text, sql)

        '    sql = "select DISTINCT  sysobjects.name [table],left (syscolumns.name,charindex('_',syscolumns.name)) [prefix]" _
        '     & " from sysobjects" _
        '     & " left join syscolumns on sysobjects.id = syscolumns.id" _
        '     & " left join systypes on syscolumns.xtype = systypes.xtype" _
        '     & " where sysobjects.xtype = 'U'and not (systypes.name like 'sysname')" _
        '     & " and sysobjects.name = '" & CStr(row("table")) & "item'" _
        '     & " and syscolumns.name like '%status'" _
        '     & " and syscolumns.name like '%" & CStr(row("prefix")) & "'"

        '    dsItem = SqlHelper.ExecuteDataset(Me.ConnectionString, CommandType.Text, sql)

        '    For Each row3 As DataRow In dsItem.Tables(0).Rows
        '      sql = "Update " & CStr(row("table")) & "item set " & CStr(row3("prefix")) & "status = 4" _
        '       & "where " & CStr(row3("prefix")) & CStr(row("prefix")) & " = " & CStr(row2("id"))
        '      SqlHelper.ExecuteNonQuery(conn, trans, CommandType.Text, sql)
        '    Next

        '  Next

        'Next

        SqlHelper.ExecuteNonQuery(conn, trans _
                    , CommandType.StoredProcedure _
                    , "UpdatePostGLFromList" _
                    , sqlparams)
        trans.Commit()

        Me.Status.Value = 4

        CType(Me.RefDoc, SimpleBusinessEntityBase).Status.Value = 4

        If TypeOf (Me.RefDoc) Is IBillAcceptable Then
          If Not (CType(Me.RefDoc, IBillAcceptable).Payment Is Nothing) Then
            CType(Me.RefDoc, IBillAcceptable).Payment.Status.Value = 4
          End If
        End If

        If TypeOf (Me.RefDoc) Is IBillIssuable Then
          If Not (CType(Me.RefDoc, IBillIssuable).Receive Is Nothing) Then
            CType(Me.RefDoc, IBillIssuable).Receive.Status.Value = 4
          End If
        End If
        trans.Commit()

        msgServ.ShowMessageFormatted("${res:Global.Info.PostItemCount}", New String() {Me.ItemCollection.Count.ToString, Configuration.FormatToString(CreditAmount, DigitConfig.Price)})



      Catch ex As Exception
        trans.Rollback()
        MessageBox.Show(ex.ToString)
      Finally
        conn.Close()
      End Try

    End Sub
    Public Sub GLUnPost(ByVal currentUserId As Integer)
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      Dim sql As String
      Dim entityList As String
      Dim dsEntityList As DataSet
      Dim dsEntity As DataSet
      Dim dsItem As DataSet
      Dim glUnPost As Integer
      Dim docUnPost As Integer
      Dim recUnPost As Integer
      Dim payUnPost As Integer

      Dim unPosted As Boolean = True

      Dim glidstring As String = Me.Id.ToString

      ' สร้าง ArrayList จาก Item ของ  SqlParameter ...
      Dim paramArrayList As New ArrayList
      paramArrayList.Add(New SqlParameter("@gl_idList", glidstring))
      paramArrayList.Add(New SqlParameter("@CurrentUserId", currentUserId))

      Dim sqlparams() As SqlParameter
      sqlparams = CType(paramArrayList.ToArray(GetType(SqlParameter)), SqlParameter())

      Dim trans As SqlTransaction
      Dim conn As New SqlConnection(Me.ConnectionString)
      conn.Open()

      trans = conn.BeginTransaction()
      Try
        'entityList = Me.RefDoctype.ToString
        'entityList = entityList & ",38"
        'If TypeOf (Me.RefDoc) Is IVatable Then
        '  entityList = entityList & ",55"
        'End If
        'If TypeOf (Me.RefDoc) Is IWitholdingTaxable Then
        '  entityList = entityList & ",69"
        'End If
        'If TypeOf (Me.RefDoc) Is IBillAcceptable Then
        '  entityList = entityList & ",68"
        'End If
        'If TypeOf (Me.RefDoc) Is IBillIssuable Then
        '  entityList = entityList & ",74"
        'End If


        'sql = "select entity_id [id],entity_table [table],entity_prefix [prefix] from Entity where entity_id in (" & entityList & ")"
        'dsEntityList = SqlHelper.ExecuteDataset(Me.ConnectionString, CommandType.Text, sql)


        'For Each row As DataRow In dsEntityList.Tables(0).Rows

        '  sql = "select * from glpost " _
        '  & "where glp_gl = " & Me.Id & " and glp_doctype = " & CInt(row("id"))

        '  dsEntity = SqlHelper.ExecuteDataset(Me.ConnectionString, CommandType.Text, sql)

        '  For Each row2 As DataRow In dsEntity.Tables(0).Rows
        '    If CInt(row("id")) = 38 Then
        '      glUnPost = CInt(row2("glp_docstatus"))
        '      unPosted = True
        '    ElseIf CInt(row("id")) = Me.RefDoctype Then
        '      docUnPost = CInt(row2("glp_docstatus"))
        '    ElseIf CInt(row("id")) = 68 Then
        '      payUnPost = CInt(row2("glp_docstatus"))
        '    ElseIf CInt(row("id")) = 74 Then
        '      recUnPost = CInt(row2("glp_docstatus"))
        '    End If
        '    sql = "update " & CStr(row("table")) _
        '    & " set " & CStr(row("prefix")) & "_status = " & CInt(row2("glp_docstatus")) _
        '    & " where " & CStr(row("prefix")) & "_id = " & CInt(row2("glp_docid"))

        '    SqlHelper.ExecuteNonQuery(conn, trans, CommandType.Text, sql)

        '    sql = "select DISTINCT  sysobjects.name [table],left (syscolumns.name,charindex('_',syscolumns.name)) [prefix]" _
        '     & " from sysobjects" _
        '     & " left join syscolumns on sysobjects.id = syscolumns.id" _
        '     & " left join systypes on syscolumns.xtype = systypes.xtype" _
        '     & " where sysobjects.xtype = 'U'and not (systypes.name like 'sysname')" _
        '     & " and sysobjects.name = '" & CStr(row("table")) & "item'" _
        '     & " and syscolumns.name like '%status'" _
        '     & " and syscolumns.name like '%" & CStr(row("prefix")) & "'"

        '    dsItem = SqlHelper.ExecuteDataset(Me.ConnectionString, CommandType.Text, sql)

        '    For Each row3 As DataRow In dsItem.Tables(0).Rows
        '      sql = "Update " & CStr(row("table")) & "item set " & CStr(row3("prefix")) & "status = " & CInt(row2("glp_docstatus")) _
        '       & "where " & CStr(row3("prefix")) & CStr(row("prefix")) & " = " & CInt(row2("glp_docid"))
        '      SqlHelper.ExecuteNonQuery(conn, trans, CommandType.Text, sql)
        '    Next

        '  Next

        'Next

        Dim ds As DataSet = SqlHelper.ExecuteDataset(conn, trans _
                    , CommandType.StoredProcedure _
                    , "UpdateUnPostGLFromList" _
                    , sqlparams)

        For Each row As DataRow In ds.Tables(0).Rows
          Dim drh As New DataRowHelper(row)
          If Me.Id = drh.GetValue(Of Integer)("glpid") Then
            unPosted = True
            Select Case drh.GetValue(Of Integer)("glpreftype")
              Case 38
                glUnPost = drh.GetValue(Of Integer)("glpstatus")
              Case 55
                'glUnPost = drh.GetValue(Of Integer)("glpstatus")
              Case 68
                payUnPost = drh.GetValue(Of Integer)("glpstatus")
              Case 69
                'glUnPost = drh.GetValue(Of Integer)("glpstatus")
              Case 74
                recUnPost = drh.GetValue(Of Integer)("glpstatus")
              Case Else
                docUnPost = drh.GetValue(Of Integer)("glpstatus")

            End Select
          Else
            unPosted = False
          End If

        Next

        If unPosted Then
         
          trans.Commit()

          Me.Status.Value = glUnPost

          CType(Me.RefDoc, SimpleBusinessEntityBase).Status.Value = docUnPost

          If TypeOf (Me.RefDoc) Is IBillAcceptable Then
            If Not (CType(Me.RefDoc, IBillAcceptable).Payment Is Nothing) Then
              CType(Me.RefDoc, IBillAcceptable).Payment.Status.Value = payUnPost
            End If
          End If

          If TypeOf (Me.RefDoc) Is IBillIssuable Then
            If Not (CType(Me.RefDoc, IBillIssuable).Receive Is Nothing) Then
              CType(Me.RefDoc, IBillIssuable).Receive.Status.Value = recUnPost
            End If
          End If
          'trans.Commit()

          msgServ.ShowMessage("${res:Global.Info.UnPost}")
        Else
          trans.Rollback()
          msgServ.ShowMessage("${res:Global.Info.CannotUnPost}")
        End If


      Catch ex As Exception
        trans.Rollback()
        MessageBox.Show(ex.ToString)
      Finally
        conn.Close()
      End Try
    End Sub

#End Region

#Region "IApprovAble"
    Public Function ApproveData(ByVal DocID As Integer, ByVal currentUserId As Integer, ByVal theTime As Date) As SaveErrorException Implements IApprovAble.ApproveData
      With Me
        Dim returnVal As System.Data.SqlClient.SqlParameter = New SqlParameter
        returnVal.ParameterName = "RETURN_VALUE"
        returnVal.DbType = DbType.Int32
        returnVal.Direction = ParameterDirection.ReturnValue
        returnVal.SourceVersion = DataRowVersion.Current
        ' ���ҧ ArrayList �ҡ Item �ͧ  SqlParameter ...
        Dim paramArrayList As New ArrayList

        paramArrayList.Add(returnVal)
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_id", DocID))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_postperson", currentUserId))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_postdate", theTime))

        ' ���ҧ SqlParameter �ҡ ArrayList ...
        Dim sqlparams() As SqlParameter
        sqlparams = CType(paramArrayList.ToArray(GetType(SqlParameter)), SqlParameter())

        ' ��� Transaction �Ǻ��������ǹ�ͧ Client �����Ҩ������ loop ��
        Try
          SqlHelper.ExecuteNonQuery(Me.ConnectionString, CommandType.StoredProcedure, "Post" & Me.TableName, sqlparams)
          Return New SaveErrorException(returnVal.Value.ToString)
        Catch ex As SqlException
          Return New SaveErrorException(ex.ToString)
        Catch ex As Exception
          Return New SaveErrorException(ex.ToString)
        End Try
      End With
    End Function
    Public ReadOnly Property IsApproved() As Boolean Implements IApprovAble.IsApproved
      Get

      End Get
    End Property
    Public ReadOnly Property AmountToApprove() As Decimal Implements IApprovAble.AmountToApprove
      Get

      End Get
    End Property
    Public ReadOnly Property ApproveIcon() As String Implements IApprovAble.ApproveIcon
      Get
        Return "Icons.16x16.PostIcon"
      End Get
    End Property

    Public ReadOnly Property UnApproveIcon() As String Implements IApprovAble.UnApproveIcon
      Get
        Return "Icons.16x16.UnPostIcon"
      End Get
    End Property

    Public ReadOnly Property ShowUnApproveButton() As Boolean Implements IApprovAble.ShowUnApproveButton
      Get

      End Get
    End Property

    Public Function UnApproveData(ByVal DocID As Integer, ByVal currentUserId As Integer, ByVal theTime As Date) As SaveErrorException Implements IApprovAble.UnApproveData

    End Function
#End Region

#Region "IPrintableEntity"
    Public Function GetDefaultFormPath() As String Implements IPrintableEntity.GetDefaultFormPath
      Return "C:\Documents and Settings\Administrator\Desktop\Forms\Documents\GL.dfm"
    End Function
    Public Function GetDefaultForm() As String Implements IPrintableEntity.GetDefaultForm

    End Function
    Public Function GetDocPrintingEntries() As DocPrintingItemCollection Implements IPrintableEntity.GetDocPrintingEntries
      Dim dpiColl As New DocPrintingItemCollection
      Dim dpi As DocPrintingItem
      'Me.RefreshTaxBase()
      'Code
      dpi = New DocPrintingItem
      dpi.Mapping = "Code"
      dpi.Value = Me.Code
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'DocDate
      dpi = New DocPrintingItem
      dpi.Mapping = "DocDate"
      dpi.Value = Me.DocDate.ToShortDateString
      dpi.DataType = "System.DateTime"
      dpiColl.Add(dpi)

      'RefCode
      dpi = New DocPrintingItem
      dpi.Mapping = "RefCode"
      dpi.Value = Me.RefDoc.Code
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      Dim RefDeliveryCode As String = ""
      Dim RefRefCode As String = ""
      If TypeOf Me.RefDoc Is GoodsReceipt Then
        Dim myGR As GoodsReceipt = New GoodsReceipt(Me.RefDoc.Id)
        RefDeliveryCode = myGR.DeliveryDocCode
        If Not myGR.Po Is Nothing Then
          RefRefCode = myGR.Po.Code
        End If
      End If
      'RefDeliveryCode
      dpi = New DocPrintingItem
      dpi.Mapping = "RefDeliveryCode"
      dpi.Value = RefDeliveryCode
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'RefRefCode
      dpi = New DocPrintingItem
      dpi.Mapping = "RefRefCode"
      dpi.Value = RefRefCode
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'RefDocDate
      dpi = New DocPrintingItem
      dpi.Mapping = "RefDocDate"
      dpi.Value = Me.RefDoc.Date.ToShortDateString
      dpi.DataType = "System.DateTime"
      dpiColl.Add(dpi)

      If TypeOf Me.RefDoc Is BankCharge Then
        Dim ref As BankCharge = CType(Me.RefDoc, BankCharge)
        'RefBankAccountCode
        dpi = New DocPrintingItem
        dpi.Mapping = "RefBankAccountCode"
        dpi.Value = ref.Bankacct.Code()
        dpi.DataType = "System.DateTime"
        dpiColl.Add(dpi)

        'RefBankAccountName
        dpi = New DocPrintingItem
        dpi.Mapping = "RefBankAccountName"
        dpi.Value = ref.Bankacct.Name
        dpi.DataType = "System.DateTime"
        dpiColl.Add(dpi)


        'RefBankAccountCode:Name
        dpi = New DocPrintingItem
        dpi.Mapping = "RefBankAccountCode:Name"
        dpi.Value = ref.Bankacct.Code & ":" & ref.Bankacct.Name
        dpi.DataType = "System.DateTime"
        dpiColl.Add(dpi)
      End If

      'AccountBook
      dpi = New DocPrintingItem
      dpi.Mapping = "AccountBook"
      dpi.Value = Me.AccountBook.Name
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'VoucherName
      dpi = New DocPrintingItem
      dpi.Mapping = "VoucherName"
      dpi.Value = Me.AccountBook.TitleName
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'Note
      dpi = New DocPrintingItem
      dpi.Mapping = "Note"
      dpi.Value = Me.Note
      dpi.DataType = "System.String"
      'dpi.PrintingFrequency = DocPrintingItem.Frequency.LastPage
      dpiColl.Add(dpi)

      'SumDebit
      dpi = New DocPrintingItem
      dpi.Mapping = "SumDebit"
      dpi.Value = Configuration.FormatToString(Me.DebitAmount, DigitConfig.Price)
      dpi.DataType = "System.String"
      'dpi.PrintingFrequency = DocPrintingItem.Frequency.LastPage
      dpiColl.Add(dpi)

      'SumCredit
      dpi = New DocPrintingItem
      dpi.Mapping = "SumCredit"
      dpi.Value = Configuration.FormatToString(Me.CreditAmount, DigitConfig.Price)
      dpi.DataType = "System.String"
      'dpi.PrintingFrequency = DocPrintingItem.Frequency.LastPage
      dpiColl.Add(dpi)

      'LastEditor
      Dim myEditorName As String = ""
      If Not Me.LastEditor Is Nothing AndAlso Me.LastEditor.Originated Then
        myEditorName = Me.LastEditor.Name
      ElseIf Not Me.Originator Is Nothing AndAlso Me.Originator.Originated Then
        myEditorName = Me.Originator.Name
      End If
      dpi = New DocPrintingItem
      dpi.Mapping = "LastEditor"
      dpi.Value = myEditorName
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      If TypeOf Me.RefDoc Is IHasIBillablePerson Then
        Dim code As String = ""
        Dim name As String = ""
        Dim billable As IHasIBillablePerson = CType(Me.RefDoc, IHasIBillablePerson)
        If Not billable.BillablePerson Is Nothing Then
          code = billable.BillablePerson.Code
          name = billable.BillablePerson.Name
        End If

        'SupplierCode
        dpi = New DocPrintingItem
        dpi.Mapping = "SupplierCode"
        dpi.Value = code
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'SupplierName
        dpi = New DocPrintingItem
        dpi.Mapping = "SupplierName"
        dpi.Value = name
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'SupplierCodeWithName
        dpi = New DocPrintingItem
        dpi.Mapping = "SupplierCodeWithName"
        dpi.Value = code & ":" & name
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'CustomerCode
        dpi = New DocPrintingItem
        dpi.Mapping = "CustomerCode"
        dpi.Value = code
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'CustomerName
        dpi = New DocPrintingItem
        dpi.Mapping = "CustomerName"
        dpi.Value = name
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'CustomerCodeWithName
        dpi = New DocPrintingItem
        dpi.Mapping = "CustomerCodeWithName"
        dpi.Value = code & ":" & name
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)
      End If

      If TypeOf Me.RefDoc Is IHasToCostCenter Then
        Dim ccinfo As String = ""
        Dim hascc As IHasToCostCenter = CType(Me.RefDoc, IHasToCostCenter)
        If Not hascc.ToCC Is Nothing Then
          ccinfo = hascc.ToCC.Code & ":" & hascc.ToCC.Name
        End If
        'CostCenterInfo
        dpi = New DocPrintingItem
        dpi.Mapping = "CostCenterInfo"
        dpi.Value = ccinfo
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)
      End If

      If TypeOf Me.RefDoc Is IHasFromCostCenter Then
        Dim ccinfo As String = ""
        Dim hascc As IHasFromCostCenter = CType(Me.RefDoc, IHasFromCostCenter)
        If Not hascc.FromCC Is Nothing Then
          ccinfo = hascc.FromCC.Code & ":" & hascc.FromCC.Name
        End If
        'CostCenterInfo
        dpi = New DocPrintingItem
        dpi.Mapping = "CostCenterInfo"
        dpi.Value = ccinfo
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)
      End If

      Dim CCCode As String = ""
      Dim AllCCCode As String = ""
      For Each item As JournalEntryItem In Me.ItemCollection
        If item.Account IsNot Nothing Then
          If Not CCCode.Equals(item.CostCenter.Code) Then
            CCCode = item.CostCenter.Code
            AllCCCode &= ", " & item.CostCenter.Code & ":" & item.CostCenter.Name
          End If
        End If
      Next
      'CustomerName
      dpi = New DocPrintingItem
      dpi.Mapping = "CostCenterInfo"
      If AllCCCode.Length > 1 Then
        AllCCCode = AllCCCode.Substring(2)
        dpi.Value = AllCCCode
      Else
        dpi.Value = ""
      End If
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)



      Dim n As Integer = 0
      For Each item As JournalEntryItem In Me.ItemCollection
        If item.Account IsNot Nothing Then

          'Item.LineNumber
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.LineNumber"
          dpi.Value = n + 1
          dpi.DataType = "System.Int32"
          dpi.Row = n + 1
          dpi.Table = "Item"
          dpiColl.Add(dpi)

          Dim space As String = ""
          If Not item.IsDebit Then
            space = "   "
          End If

          'Item.AccountCode
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.AccountCode"
          dpi.Value = space & item.Account.Code
          dpi.DataType = "System.String"
          dpi.Row = n + 1
          dpi.Table = "Item"
          dpiColl.Add(dpi)

          'Item.Account
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.Account"
          dpi.Value = space & item.Account.Name
          dpi.DataType = "System.String"
          dpi.Row = n + 1
          dpi.Table = "Item"
          dpiColl.Add(dpi)

          'Item.CCCode
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.CCCode"
          dpi.Value = item.CostCenter.Code
          dpi.DataType = "System.String"
          dpi.Row = n + 1
          dpi.Table = "Item"
          dpiColl.Add(dpi)

          'Item.CCName
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.CCName"
          dpi.Value = item.CostCenter.Name
          dpi.DataType = "System.String"
          dpi.Row = n + 1
          dpi.Table = "Item"
          dpiColl.Add(dpi)

          'Item.CCInfo
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.CCInfo"
          dpi.Value = item.CostCenter.Code & ":" & item.CostCenter.Code
          dpi.DataType = "System.String"
          dpi.Row = n + 1
          dpi.Table = "Item"
          dpiColl.Add(dpi)

          If item.IsDebit Then
            'Item.Debit
            dpi = New DocPrintingItem
            dpi.Mapping = "Item.Debit"
            dpi.Value = Configuration.FormatToString(item.Amount, DigitConfig.Price)
            dpi.DataType = "System.String"
            dpi.Row = n + 1
            dpi.Table = "Item"
            dpiColl.Add(dpi)
          Else
            ' Item.Credit
            dpi = New DocPrintingItem
            dpi.Mapping = "Item.Credit"
            dpi.Value = Configuration.FormatToString(item.Amount, DigitConfig.Price)
            dpi.DataType = "System.String"
            dpi.Row = n + 1
            dpi.Table = "Item"
            dpiColl.Add(dpi)
          End If


          'Item.Note
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.Note"
          dpi.Value = item.Note
          dpi.DataType = "System.String"
          dpi.Row = n + 1
          dpi.Table = "Item"
          dpiColl.Add(dpi)
        End If


        n += 1
      Next

      Dim groups As New Dictionary(Of Integer, JournalEntryItem)
      Dim sumAmt As Decimal = 0
      n = 0
      For Each item As JournalEntryItem In Me.ItemCollection
        If item.Account IsNot Nothing Then
          Dim ji As JournalEntryItem
          If Not groups.ContainsKey(item.Account.Id) Then
            Dim newJi As New JournalEntryItem
            newJi.Account = item.Account
            newJi.IsDebit = item.IsDebit
            groups(item.Account.Id) = newJi
          End If
          ji = groups(item.Account.Id)
          ji.Amount += item.Amount
        End If
      Next
      For Each item As JournalEntryItem In groups.Values

        'Item.LineNumber
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.LineNumber"
        dpi.Value = n + 1
        dpi.DataType = "System.Int32"
        dpi.Row = n + 1
        dpi.Table = "GroupItem"
        dpiColl.Add(dpi)

        Dim space As String = ""
        If Not item.IsDebit Then
          space = "   "
        End If

        'Item.AccountCode
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.AccountCode"
        dpi.Value = space & item.Account.Code
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "GroupItem"
        dpiColl.Add(dpi)

        'Item.Account
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.Account"
        dpi.Value = space & item.Account.Name
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "GroupItem"
        dpiColl.Add(dpi)

        If item.IsDebit Then
          'Item.Debit
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.Debit"
          dpi.Value = Configuration.FormatToString(item.Amount, DigitConfig.Price)
          dpi.DataType = "System.String"
          dpi.Row = n + 1
          dpi.Table = "GroupItem"
          dpiColl.Add(dpi)
        Else
          ' Item.Credit
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.Credit"
          dpi.Value = Configuration.FormatToString(item.Amount, DigitConfig.Price)
          dpi.DataType = "System.String"
          dpi.Row = n + 1
          dpi.Table = "GroupItem"
          dpiColl.Add(dpi)
        End If
        n += 1
      Next

      dpiColl.AddRange(GetWBSDocPrintingEntries)

      Return dpiColl
    End Function
    Public Function GetWBSDocPrintingEntries() As DocPrintingItemCollection
      Dim dpiColl As New DocPrintingItemCollection
      Dim dpi As DocPrintingItem

      Dim n As Integer

      If TypeOf Me.RefDoc Is IWBSAllocatable Then
        For Each itm As IWBSAllocatableItem In CType(Me.RefDoc, IWBSAllocatable).GetWBSAllocatableItemCollection

          dpi = New DocPrintingItem
          dpi.Mapping = "WBSItem.ItemDescription"
          dpi.Value = itm.Type & "; " & itm.Description & "; " & Configuration.FormatToString(itm.ItemAmount, DigitConfig.Price)
          dpi.DataType = "System.String"
          dpi.Row = n + 1
          dpi.Table = "WBSItem"
          dpiColl.Add(dpi)

          Dim wbsList As New ArrayList
          Dim wbsDescription As String = ""
          For Each wbsd As WBSDistribute In itm.WBSDistributeCollection
            wbsDescription = wbsd.CostCenter.Code & "/" & wbsd.WBS.Code & "/" & Configuration.FormatToString(wbsd.Amount, DigitConfig.Price)
            wbsList.Add(wbsDescription)
          Next

          dpi = New DocPrintingItem
          dpi.Mapping = "WBSItem.WBSDescription"
          dpi.Value = ""
          If wbsList.Count > 0 Then
            dpi.Value = String.Join("; ", wbsList.ToArray)
          End If
          dpi.DataType = "System.String"
          dpi.Row = n + 1
          dpi.Table = "WBSItem"
          dpiColl.Add(dpi)

          n += 1
        Next
      End If

      Return dpiColl
    End Function
#End Region

#Region "Delete"
    Public Overrides ReadOnly Property CanDelete() As Boolean
      Get
        Return Me.RefDoctype = 38 AndAlso Me.Status.Value <= 2
      End Get
    End Property
    Public Overrides Function Delete() As SaveErrorException
      If Not Me.Originated Then
        Return New SaveErrorException("${res:Global.Error.NoIdError}")
      End If
      Dim myMessage As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      Dim format(0) As String
      format(0) = Me.Code
      If Not myMessage.AskQuestionFormatted("${res:Global.ConfirmDeleteJournalEntry}", format) Then
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
        SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "DeleteGL", _
          New SqlParameter() {New SqlParameter("@gl_id", Me.Id), New SqlParameter("@gl_docdate", Me.DocDate), returnVal})
        If IsNumeric(returnVal.Value) Then
          Select Case CInt(returnVal.Value)
            Case -1
              trans.Rollback()
              Return New SaveErrorException("${res:Global.JournalEntryIsReferencedCannotBeDeleted}")
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

#Region "ICancelable"
    Public ReadOnly Property CanCancel() As Boolean Implements ICancelable.CanCancel
      Get
        Return Me.Status.Value > 1 AndAlso Me.IsCancelable AndAlso Me.RefDoctype = 38    'CType(RefDoc, IObjectReflectable).EntityId = 38
      End Get
    End Property

    Public Function CancelEntity(ByVal currentUserId As Integer, ByVal theTime As Date) As SaveErrorException Implements ICancelable.CancelEntity
      Me.Status.Value = 0
      Return Me.Save(currentUserId)
    End Function
#End Region

#Region "IDuplicable"
    Public Function GetNewEntity() As Object Implements IDuplicable.GetNewEntity
      'เวลา Copy ให้เอา CustomNote จากอันปัจจุบันมาเก็บไว้ก่อน

      Me.Status.Value = -1
      If Not Me.Originated Then
        Return Me
      End If
      Me.Id = 0
      Me.Code = "Copy of " & Me.Code
      Me.Canceled = False
      Me.CancelPerson = New User
      'Me.Closing = False
      Me.ClearReference()

      Return Me
    End Function
#End Region

    Public Sub SortDebitCredit()
      Dim debitList As New List(Of JournalEntryItem)
      Dim creditList As New List(Of JournalEntryItem)
      For Each item As JournalEntryItem In Me.ItemCollection
        If item.IsDebit Then
          debitList.Add(item)
        Else
          creditList.Add(item)
        End If
      Next
      Me.ItemCollection.Clear()
      For Each debitItem As JournalEntryItem In debitList
        Me.ItemCollection.Add(debitItem)
      Next
      For Each creditItem As JournalEntryItem In creditList
        Me.ItemCollection.Add(creditItem)
      Next
    End Sub
  End Class

  Public Class JournalEntryUpdate
    Inherits JournalEntry
    Public Overrides ReadOnly Property CodonName() As String
      Get
        Return "JournalEntryUpdate"
      End Get
    End Property
  End Class
End Namespace
