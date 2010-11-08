Imports System.Collections.Generic

Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.Gui.Components
Imports System.Data.SqlClient
Imports System.IO
Imports System.ComponentModel
Imports System.Configuration
Imports System.Reflection
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Services
Imports Telerik.WinControls.UI
Namespace Longkong.Pojjaman.BusinessLogic
  Public Enum MultiApproveResult
    Comment
    Approve
    Reject
    Non
  End Enum
  Public Enum MultiApproveType
    WaitForApprove
    Approved
    Rejected
    NotAppreve
  End Enum
  Public Class MultiApproval
    Inherits SimpleBusinessEntityBase
    Implements IHasName, IPJMUpdatable, IForceListDialog

#Region "Members"
    Private m_unapoveDoclist As List(Of UnApproveDoc)

    Private m_ListData As DataSet
    'Private m_ListChildData As DataTable

    'Private m_hashData As Hashtable

    'Private m_name As String
    'Private m_pjmid As Integer
    'Private m_isDefault As Boolean

    'Private Shared m_AllMultiApprovals As Hashtable
    'Public Shared ReadOnly Property AllMultiApprovals As Hashtable
    '  Get
    '    If m_AllMultiApprovals Is Nothing Then
    '      RefreshAllData()
    '    End If
    '    Return m_AllMultiApprovals
    '  End Get
    'End Property
    'Private Shared m_MultiApprovalTable As DataTable

    Private m_docTypefilter As MultiApproveType
#End Region

#Region "Constructors"
    Public Sub New()
      MyBase.New()
    End Sub
    Public Sub New(ByVal Id As Integer)
      MyBase.New(Id)
    End Sub
    Public Sub New(ByVal code As String)
      MyBase.New(code)
    End Sub
    Public Sub New(ByVal ds As DataSet, ByVal aliasPrefix As String)
      MyBase.New(ds, aliasPrefix)
    End Sub
    Public Sub New(ByVal dr As DataRow, ByVal aliasPrefix As String)
      MyBase.New(dr, aliasPrefix)
    End Sub

    Protected Overloads Overrides Sub Construct(ByVal dr As System.Data.DataRow, ByVal aliasPrefix As String)
      MyBase.Construct(dr, aliasPrefix)
      'With Me
      '  If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_name") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_name") Then
      '    .m_name = CStr(dr(aliasPrefix & Me.Prefix & "_name"))
      '  End If

      '  If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_pjmid") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_pjmid") Then
      '    .m_pjmid = CInt(dr(aliasPrefix & Me.Prefix & "_pjmid"))
      '  End If

      '  If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_default") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_default") Then
      '    .m_isDefault = CBool(dr(aliasPrefix & Me.Prefix & "_default"))
      '  End If
      'End With
    End Sub
    Public Function GetDocumentFilter(ByVal arr As ArrayList) As String
      Dim filterString As String = ""

      'For Each key As Integer In arr
      '  If filterString.Length > 0 Then
      '    filterString &= " or "
      '  End If
      '  filterString &= " doctype = " & key.ToString
      'Next

      filterString = String.Join(" or ", arr.ToArray)
      'filterString = String.Join(" or doctype = ", arr.ToArray)
      'If filterString.Length > 0 Then
      '  filterString = " doctype = " & filterString
      'Else
      '  filterString = " doctype = -1"
      'End If

      Return filterString
    End Function
    Public Function GetApproveFilter(ByVal arr As ArrayList) As String
      Dim filterString As String = ""

      filterString = String.Join("", arr.ToArray)

      Return filterString
    End Function
    Public Sub New(ByVal UserId As Integer, ByVal approveType As Integer, ByVal DateRank As Integer)
      Me.RefreshData(UserId, approveType, DateRank, Me.AlwaysShowData)
    End Sub
    Public Function RefreshData(ByVal UserId As Integer, ByVal approveType As Integer, ByVal DateRank As Integer, Optional ByVal ShowData As Boolean = True) As DataSet

      Dim ds As DataSet = SqlHelper.ExecuteDataset(Me.ConnectionString, _
                                                   CommandType.StoredProcedure, _
                                                   "GetMultiApprovalList", _
                                                   New SqlParameter("@userRight", UserId), _
                                                   New SqlParameter("@ShowData", ShowData), _
                                                   New SqlParameter("@ApproveType", approveType), _
                                                   New SqlParameter("@DateRank", DateRank) _
                                                   )
      m_ListData = ds
      'm_hashData = New Hashtable
      'Dim key As String
      'For Each row As DataRow In ds.Tables(0).Rows
      '  Dim drh As New DataRowHelper(row)
      '  key = drh.GetValue(Of Integer)("linenumber")
      '  m_hashData(key) = row
      'Next

      'm_ListChildData = ds.Tables(1)
      'If Not m_hashData Is Nothing Then
      '  m_hashData = New Hashtable
      'End If

      Return ds
    End Function
    Public Sub RefreshDataSource(ByVal UserId As Integer, _
                                 ByVal rGrid As Telerik.WinControls.UI.RadGridView, _
                                 ByVal filters As ArrayList, _
                                 ByVal ApproveType As Integer, _
                                 ByVal DateRank As Integer, _
                                 Optional ByVal refresh As Boolean = False)

      If m_ListData Is Nothing OrElse refresh Then
        Me.RefreshData(UserId, ApproveType, DateRank)
      End If
      Dim dt As DataTable = Nothing
      'Dim dt2 As DataTable = Nothing

      If filters Is Nothing Then
        dt = m_ListData.Tables(0)
      Else
        dt = Me.GetDataFiltered(m_ListData.Tables(0), filters)
      End If

      'rGrid.MasterGridViewTemplate.Columns("amount").FormatString = "{0:n}"

      Dim linenumber As Integer = 0
      For Each row As DataRow In dt.Rows
        linenumber += 1
        row("linenumber") = linenumber
        row("amount") = Configuration.FormatToString(CDec(row("amount")), DigitConfig.Price)
        row("docdate") = CDate(row("docdate")).ToShortDateString
        row("lasteditdocstatus") = row("lastEditdocStatus").ToString() & _
            Space(2) & "(" & row("daterank").ToString & _
            Space(1) & Me.GetDateUnitName(CInt(row("dateranktype"))) & ")"
      Next

      Try
        rGrid.DataSource = dt

        'If m_ListData.Tables.Count > 1 Then
        rGrid.MasterGridViewTemplate.ChildGridViewTemplates(0).DataSource = m_ListData.Tables(1)

        rGrid.MasterGridViewTemplate.ChildGridViewTemplates(1).DataSource = dt 'm_ListData.Tables(2)
      Catch ex As Exception

      End Try

      'End If


      'If Not childTable Is Nothing Then
      '  rGrid.MasterGridViewTemplate.ChildGridViewTemplates(0).DataSource = childTable
      '  Return
      'End If

      'If m_ListData.Tables.Count > 1 Then
      '  'rGrid.MasterGridViewTemplate.ChildGridViewTemplates.Clear()

      '  dt2 = m_ListData.Tables(1)

      '  rGrid.MasterGridViewTemplate.ChildGridViewTemplates(0).DataSource = dt2

      'Else
      '  Return
      'End If

      'Dim template As New GridViewTemplate(rGrid)

      'template.AllowAddNewRow = False
      'template.AllowDeleteRow = False
      'template.AllowCellContextMenu = False
      'template.AllowColumnResize = True

      'template.Columns.Add(New GridViewTextBoxColumn("docid"))
      'template.Columns.Add(New GridViewTextBoxColumn("apvdoc_comment"))
      'template.Columns.Add(New GridViewTextBoxColumn("apvdoc_originDate"))


      'template.Caption = "Details"
      'template.DataSource = dt2
      'template.AllowRowResize = False
      'template.ShowColumnHeaders = False
      'rGrid.MasterGridViewTemplate.ChildGridViewTemplates.Add(template)

      'Dim relation1 As New GridViewRelation(rGrid.MasterGridViewTemplate)
      'relation1.RelationName = "approvedoc"
      'relation1.ParentColumnNames.Add("docid")
      'relation1.ChildColumnNames.Add("docid")
      'relation1.ChildTemplate = template
      'rGrid.Relations.Add(relation1)

      'Dim template As New Telerik.WinControls.UI.GridViewTemplate
      'template.AllowAddNewRow = True
      'For Each col As DataColumn In dt.Columns
      '  template.Columns.Add(New GridViewTextBoxColumn(col.ColumnName))
      'Next
      'rGrid.MasterGridViewTemplate.ChildGridViewTemplates.Add(template)

      'For Each row As DataRow In dt.Rows
      '  Dim deh As New DataRowHelper(row)
      '  Dim currentGridRow As GridViewDataRowInfo = rGrid.MasterGridViewTemplate.Rows.AddNew()
      '  currentGridRow.Cells("doctypename").Value = deh.GetValue(Of String)("doctypename")
      '  currentGridRow.Cells("doccode").Value = deh.GetValue(Of String)("doccode")
      '  currentGridRow.Cells("docdate").Value = deh.GetValue(Of DateTime)("docdate").ToShortTimeString
      '  currentGridRow.Cells("amount").Value = Configuration.FormatToString(deh.GetValue(Of Decimal)("amount"), DigitConfig.Price)
      '  'currentGridRow.Cells(5).Value = Configuration.FormatToString(deh.GetValue(Of Decimal)("amount"), DigitConfig.Price)
      '  ''currentGridRow.colls(6).value = Configuration.FormatToString(deh.GetValue(Of Decimal)(" "), DigitConfig.Price)
      '  'currentGridRow.Cells(6).Value = Configuration.FormatToString(deh.GetValue(Of Decimal)("MaintenanceAmount"), DigitConfig.Price)
      '  'currentGridRow.colls(8).value = Configuration.FormatToString(deh.GetValue(Of Decimal)(" "), DigitConfig.Price)
      'Next

    End Sub
    Public Function GetDateUnitName(ByVal type As Integer) As String
      Dim dateUnitName As String = ""
      Dim expandUnit As String = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.MultiApproval.Ago}")
      Select Case type
        Case -1
          dateUnitName = ""
        Case 0
          dateUnitName = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.MultiApproval.MinutsUnit}") '"นาที"
          dateUnitName &= Space(1) & expandUnit
        Case 1
          dateUnitName = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.MultiApproval.TodayUnit}") '"วันนี้"
        Case 2
          dateUnitName = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.MultiApproval.HourUnit}") '"ชั่วโมง
          dateUnitName &= Space(1) & expandUnit
        Case 3
          dateUnitName = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.MultiApproval.DaysUnit}") '"วัน"
          dateUnitName &= Space(1) & expandUnit
        Case 4
          dateUnitName = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.MultiApproval.WeeksUnit}") '"สัปดาห์"
          dateUnitName &= Space(1) & expandUnit
        Case 5
          dateUnitName = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.MultiApproval.MonthsUnit}") '"เดือน"
          dateUnitName &= Space(1) & expandUnit
        Case 6
          dateUnitName = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.MultiApproval.YearsUnit}") '"ปี"
          dateUnitName &= Space(1) & expandUnit
      End Select

      Return dateUnitName
    End Function
    Public Sub RefreshDocumentList(ByVal chkDocumenList As System.Windows.Forms.CheckedListBox)
      chkDocumenList.Items.Clear()
      chkDocumenList.Items.Add("PR", CheckState.Checked)
      chkDocumenList.Items.Add("PO")
      chkDocumenList.Items.Add("GR")
      chkDocumenList.Items.Add("WR")
      chkDocumenList.Items.Add("SC")
      chkDocumenList.Items.Add("PA")
    End Sub
    Public Function GetDataFiltered(ByVal dt As DataTable, ByVal filters As ArrayList) As DataTable
      Dim newdt As New DataTable
      For Each col As DataColumn In dt.Columns
        newdt.Columns.Add(New DataColumn(col.ColumnName))
      Next

      'Dim appFilter As String = ""
      Dim docFilter As String = ""
      'Dim stringFilter As String = ""

      docFilter = Me.GetDocumentFilter(filters)
      'appFilter = Me.GetApproveFilter(Approvefilters)

      'If docFilter.Length > 0 Then
      '  stringFilter &= "(" & docFilter & ")"
      'End If
      'If docFilter.Length > 0 AndAlso appFilter.Length > 0 Then
      '  stringFilter &= " and "
      'End If
      'If appFilter.Length > 0 Then
      '  stringFilter &= "(" & appFilter & ")"
      'End If

      'Trace.WriteLine(stringFilter)
      For Each drow As DataRow In dt.Select(docFilter)
        Dim newdrow As DataRow = newdt.NewRow
        For Each col As DataColumn In dt.Columns
          newdrow(col.ColumnName) = drow(col.ColumnName)
        Next
        newdt.Rows.Add(newdrow)
        'Trace.WriteLine(newdrow("doctypename").ToString)
      Next

      Return newdt

    End Function

#End Region

#Region "Properties"

    Private m_listSelected As ArrayList
    Public ReadOnly Property IsSelected(ByVal rgrid As RadGridView) As Boolean
      Get
        Dim selected As Boolean = False

        'For rowIndex As Integer = 0 To rgrid.RowCount - 1
        '  'Reset==============
        '  Me.ListData.Tables(0).Rows(rowIndex)("selected") = False
        '  'Reset==
        'Next


        '  If CBool(rgrid.Rows(rowIndex).Cells("selected").Value) Then

        '    selected = True
        '  End If

        m_listSelected = New ArrayList

        For Each gv As GridViewDataRowInfo In rgrid.Rows
          If CBool(gv.Cells("selected").Value) = True Then
            'Me.ListData.Tables(0).Rows(rgrid.MasterGridViewInfo.ViewTemplate.Rows.IndexOf(gv))("selected") = True

            m_listSelected.Add(rgrid.MasterGridViewInfo.ViewTemplate.Rows(rgrid.MasterGridViewInfo.ViewTemplate.Rows.IndexOf(gv)))
            'CType(rgrid.MasterGridViewInfo.ViewTemplate.DataSource, DataTable).Rows.IndexOf(gv)("selected") = True
            selected = True
          End If
        Next

        'Next

        'For Each row As DataRow In Me.m_ListData.Tables(0).Rows
        '  If CBool(row("selected")) Then
        '    selected = True
        '    Exit For
        '  End If
        'Next
        Return selected
      End Get
    End Property
    Public Property ApproveType As MultiApproveType
      Get
        Return m_docTypefilter
      End Get
      Set(ByVal value As MultiApproveType)
        m_docTypefilter = value
      End Set
    End Property
    'Public Property IsDefault() As Boolean    '  Get    '    Return m_isDefault    '  End Get    '  Set(ByVal Value As Boolean)    '    m_isDefault = Value    '  End Set    'End Property
    Public Property ListData As DataSet
      Get
        Return m_ListData
      End Get
      Set(ByVal value As DataSet)

      End Set
    End Property
    Public Property CurrentUserId As Integer
    'Public ReadOnly Property HashData As Hashtable
    '  Get
    '    Return m_hashData
    '  End Get
    'End Property
    Public Property AlwaysShowPage As Boolean
      Get
        Dim config As Boolean = CBool(ConfigurationUser.GetConfig(CurrentUserId, "AlwaysShowMultiApprovePage"))
        Return config
      End Get
      Set(ByVal value As Boolean)
        Dim saveEx As SaveErrorException = ConfigurationUser.Save(CurrentUserId, "AlwaysShowMultiApprovePage", value)
        If Not IsNumeric(saveEx.Message) Then
          MessageBox.Show("ไม่สามารถกำหนดค่าได้" & vbCrLf, "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
      End Set
    End Property
    Public Property AlwaysShowData As Boolean
      Get
        Dim config As Boolean = CBool(ConfigurationUser.GetConfig(CurrentUserId, "AlwaysShowDataMultiApprovePage"))
        Return config
      End Get
      Set(ByVal value As Boolean)
        Dim saveEx As SaveErrorException = ConfigurationUser.Save(CurrentUserId, "AlwaysShowDataMultiApprovePage", value)
        If Not IsNumeric(saveEx.Message) Then
          MessageBox.Show("ไม่สามารถกำหนดค่าได้" & vbCrLf, "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
      End Set
    End Property
    Public Overrides ReadOnly Property ClassName() As String
      Get
        Return "MultiApproval"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.MultiApproval.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.MultiApproval"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.MultiApproval"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.MultiApproval.ListLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property Prefix() As String
      Get
        Return "MultiApproval"
      End Get
    End Property
    Public Overrides ReadOnly Property TabPageText() As String
      Get
        Dim tpt As String = Me.StringParserService.Parse(Me.DetailPanelTitle) & " (" & Me.Name & ")"
        Dim blankSuffix As String = "()"
        If tpt.EndsWith(blankSuffix) Then
          tpt = tpt.Remove(tpt.Length - blankSuffix.Length, blankSuffix.Length)
        End If
        Return tpt
      End Get
    End Property
    Public Overrides ReadOnly Property UseSiteConnString() As Boolean
      Get
        Return True
      End Get
    End Property
#End Region

#Region "Methods"
    Public Function AddNewComment(ByVal comment As String, ByVal isComment As Boolean, Optional ByVal isReject As Boolean = False) As SaveErrorException
      Try
        Dim saveError As SaveErrorException

        For Each gv As GridViewDataRowInfo In Me.m_listSelected
          'If CBool(gv.Cells("selected").Value) Then

          Dim AppMultiDoc As New ApprovalMultiDoc

          AppMultiDoc.EntityId = CInt(gv.Cells("docid").Value)
          AppMultiDoc.EntityType = CInt(gv.Cells("doctype").Value)
          AppMultiDoc.LineNumber = CInt(gv.Cells("apvdoc_linenumber").Value)

          'MessageBox.Show(AppMultiDoc.EntityId.ToString & vbCrLf & AppMultiDoc.EntityType.ToString & vbCrLf & AppMultiDoc.LineNumber.ToString)

          AppMultiDoc.Comment = comment.Trim
          If isComment Then
            AppMultiDoc.Level = 0
          Else
            AppMultiDoc.Level = CInt(gv.Cells("applevel").Value)
          End If
          AppMultiDoc.Originator = Me.CurrentUserId
          AppMultiDoc.Reject = isReject

          saveError = AppMultiDoc.Save()
          If Not IsNumeric(saveError.Message) Then
            Throw New SaveErrorException(saveError.Message)
          End If
          'End If
        Next

        'For Each row As DataRow In Me.ListData.Tables(0).Rows
        '  If CBool(row("selected")) Then
        '    Dim drh As New DataRowHelper(row)

        '    Dim AppMultiDoc As New ApprovalMultiDoc

        '    AppMultiDoc.EntityId = drh.GetValue(Of Integer)("docid")
        '    AppMultiDoc.EntityType = drh.GetValue(Of Integer)("doctype")
        '    AppMultiDoc.LineNumber = drh.GetValue(Of Integer)("apvLineNumber")

        '    MessageBox.Show(AppMultiDoc.EntityId.ToString & vbCrLf & AppMultiDoc.EntityType.ToString & vbCrLf & AppMultiDoc.LineNumber.ToString)

        '    AppMultiDoc.Comment = comment.Trim
        '    If isComment Then
        '      AppMultiDoc.Level = 0
        '    Else
        '      AppMultiDoc.Level = drh.GetValue(Of Integer)("applevel")
        '    End If
        '    AppMultiDoc.Originator = Me.CurrentUserId
        '    AppMultiDoc.Reject = isReject

        '    'saveError = AppMultiDoc.Save()
        '    'If Not IsNumeric(saveError.Message) Then
        '    '  Throw saveError
        '    'End If
        '  End If
        'Next

        Return New SaveErrorException("0")
      Catch ex As Exception
        Return New SaveErrorException(ex.Message)
      End Try

    End Function
    Public Sub SetToggleSelection(ByVal selected As Boolean, Optional ByVal rowIndex As Integer = -1)
      If rowIndex = -1 Then
        For Each row As DataRow In Me.m_ListData.Tables(0).Rows
          row("selected") = selected
        Next
      Else
        Me.m_ListData.Tables(0).Rows(rowIndex)("selected") = selected

        'docId = rGrid.Rows(e.RowIndex).Cells("DocId").Value
        'docType = rGrid.Rows(e.RowIndex).Cells("DocType").Value
      End If

    End Sub
    Public Function GetApproveDoc(ByVal docid As Integer, ByVal doctype As Integer) As Boolean
      Try
        Dim dt As DataTable = Nothing
        Dim hashChild As Boolean = False

        'If m_ListChildData Is Nothing OrElse m_ListChildData.Rows.Count = 0 Then
        '  'm_hashData = New Hashtable

        '  Dim ds As DataSet = SqlHelper.ExecuteDataset(SimpleBusinessEntityBase.ConnectionString _
        '             , CommandType.StoredProcedure _
        '             , "GetApproveDocForMultiApproveDoc")
        '  m_ListChildData = ds.Tables(0)

        'End If

        'Dim dr As DataRow() = m_ListChildData.Select("apvdoc_entityId=" & docid & " and apvdoc_entityType=" & doctype)
        'If dr.Length > 0 Then
        '  hashChild = True
        'End If

        'Return hashChild

      Catch ex As Exception

      End Try
    End Function
    'Public Shared Sub RefreshAllData()
    '  MultiApproval.m_AllMultiApprovals = New Hashtable
    '  Dim key As String = ""

    '  Dim ds As DataSet = SqlHelper.ExecuteDataset(SimpleBusinessEntityBase.ConnectionString _
    ', CommandType.StoredProcedure _
    ', "GetMultiApprovalList" _
    ', Nothing)
    '  If ds.Tables(0).Rows.Count >= 1 Then
    '    For Each row As DataRow In ds.Tables(0).Rows
    '      Dim drh As New DataRowHelper(row)
    '      key = CStr(drh.GetValue(Of Integer)("MultiApproval_id"))
    '      MultiApproval.m_AllMultiApprovals(key) = row
    '    Next
    '  End If
    'End Sub
    'Public Shared Function GetMultiApprovalById(ByVal id As Integer) As MultiApproval
    '  Dim key As String = id.ToString
    '  Dim row As DataRow = CType(AllMultiApprovals(key), DataRow)
    '  If row Is Nothing Then
    '    Dim blankMultiApproval As New MultiApproval
    '    blankMultiApproval.Id = 0
    '    blankMultiApproval.Code = ""
    '    blankMultiApproval.Name = ""
    '    Return blankMultiApproval
    '  End If
    '  Dim MultiApproval As New MultiApproval(row, "") 'Pui
    '  Return MultiApproval
    'End Function
    'Public Shared Sub DestroyCachMultiApproval()
    '  m_AllMultiApprovals = Nothing
    'End Sub
    'Public Shared Function CanDeleteThisId(ByVal id As Integer) As Boolean
    '  Dim ds As DataSet = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "CountMultiApprovalRef", _
    '  New SqlParameter("@MultiApproval_id", id))
    '  If ds.Tables(0).Rows.Count > 0 Then
    '    Return (CInt(ds.Tables(0).Rows(0)(0)) = 0)
    '  End If
    '  Return True
    'End Function
    'Public Overrides Function ToString() As String
    '  Return m_name
    'End Function
    'Public Overloads Overrides Function Save(ByVal currentUserId As Integer) As SaveErrorException
    '  Dim returnVal As System.Data.SqlClient.SqlParameter = New SqlParameter
    '  returnVal.ParameterName = "RETURN_VALUE"
    '  returnVal.DbType = DbType.Int32
    '  returnVal.Direction = ParameterDirection.ReturnValue
    '  returnVal.SourceVersion = DataRowVersion.Current

    '  Dim paramArrayList As New ArrayList
    '  paramArrayList.Add(returnVal)

    '  If Me.Originated Then
    '    paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_id", Me.Id))
    '  End If

    '  Dim theTime As Date = Now
    '  Dim theUser As New User(currentUserId)

    '  If Me.AutoGen And Me.Code.Length = 0 Then
    '    Me.Code = Me.GetNextCode
    '  End If
    '  Me.AutoGen = False

    '  paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_code", Me.Code))
    '  paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_name", Me.Name))
    '  paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_pjmid", Me.PJMID))

    '  Dim sqlparams() As SqlParameter
    '  sqlparams = CType(paramArrayList.ToArray(GetType(SqlParameter)), SqlParameter())

    '  Dim trans As SqlTransaction
    '  Dim conn As New SqlConnection(Me.ConnectionString)

    '  If conn.State = ConnectionState.Open Then conn.Close()
    '  conn.Open()
    '  trans = conn.BeginTransaction

    '  Try
    '    Me.ExecuteSaveSproc(conn, trans, returnVal, sqlparams, theTime, theUser)
    '    trans.Commit()

    '    '== ทำลาย Member นี้ทิ้งเสมอ เมื่อมีการแก้ไข ============
    '    MultiApproval.m_AllMultiApprovals = Nothing
    '    '== ทำลาย Member นี้ทิ้งเสมอ เมื่อมีการแก้ไข ============

    '    Return New SaveErrorException(returnVal.Value.ToString)
    '  Catch ex As SqlException
    '    trans.Rollback()
    '    Return New SaveErrorException(returnVal.Value.ToString)
    '  Catch ex As Exception
    '    trans.Rollback()
    '    Return New SaveErrorException(returnVal.Value.ToString)
    '  Finally
    '    conn.Close()
    '  End Try
    'End Function
#End Region

#Region "IHasName"
    Public Property Name() As String Implements IHasName.Name
      Get
        'Return m_name
      End Get
      Set(ByVal Value As String)
        'm_name = Value
        'OnTabPageTextChanged(Me, New EventArgs)
      End Set
    End Property
#End Region

#Region "Shared"
    Public Shared Function SetSchema() As DataTable

    End Function
    'Public Shared Function GetMultiApproval(ByVal txtCode As TextBox, ByVal txtName As TextBox, ByRef oldMultiApproval As MultiApproval) As Boolean
    'Dim newMultiApproval As New MultiApproval(txtCode.Text)
    'If txtCode.Text.Length <> 0 AndAlso Not newMultiApproval.Valid Then
    '  MessageBox.Show(txtCode.Text & " ไม่มีในระบบ")
    '  newMultiApproval = oldMultiApproval
    'End If
    'txtCode.Text = newMultiApproval.Code
    'txtName.Text = newMultiApproval.Name
    'If oldMultiApproval.Id <> newMultiApproval.Id Then
    '  oldMultiApproval = newMultiApproval
    '  Return True
    'End If
    'Return False
    'End Function
#End Region

#Region "IPJMUpdatable"
    Public Property PJMID() As Integer Implements IPJMUpdatable.PJMID
      Get
        'Return m_pjmid
      End Get
      Set(ByVal Value As Integer)
        'm_pjmid = Value
      End Set
    End Property
#End Region

  End Class

  '  <Serializable(), DefaultMember("Item")> _
  '  Public Class MultiApprovalCollection
  '    Inherits CollectionBase

  '#Region "Members"
  '    Private m_filters As Filter()
  '#End Region

  '#Region "Constructors"
  '    Public Sub New(ByVal filters As Filter())

  '      'Dim sqlConString As String = SimpleBusinessEntityBase.SiteConnectionString
  '      'm_filters = filters
  '      'Dim params() As SqlParameter
  '      'If Not filters Is Nothing AndAlso filters.Length > 0 Then
  '      '  ReDim params(filters.Length - 1)
  '      '  For i As Integer = 0 To filters.Length - 1
  '      '    params(i) = New SqlParameter("@" & filters(i).Name, filters(i).Value)
  '      '  Next
  '      'End If

  '      'Dim ds As DataSet = SqlHelper.ExecuteDataset(sqlConString _
  '      ', CommandType.StoredProcedure _
  '      ', "GetMultiApprovalList" _
  '      ', params _
  '      ')

  '      'For Each row As DataRow In ds.Tables(0).Rows
  '      '  Dim item As New MultiApproval(row, "")
  '      '  Me.Add(item)
  '      'Next
  '    End Sub
  '#End Region

  '#Region "Properties"
  '    'Default Public Property Item(ByVal index As Integer) As MultiApproval
  '    '  Get
  '    '    Return CType(MyBase.List.Item(index), MultiApproval)
  '    '  End Get
  '    '  Set(ByVal value As MultiApproval)
  '    '    MyBase.List.Item(index) = value
  '    '  End Set
  '    'End Property
  '#End Region

  '#Region "Class Methods"
  '    Public Function GetItemWithId(ByVal id As Integer) As MultiApproval
  '      For Each item As MultiApproval In Me
  '        If item.Id = id Then
  '          Return item
  '        End If
  '      Next
  '    End Function
  '    Protected Function GetParamsString(ByVal filters() As Filter) As String
  '      Dim ret As String = ""
  '      If Not filters Is Nothing AndAlso filters.Length > 0 Then
  '        For i As Integer = 0 To filters.Length - 1
  '          ret &= "@" & filters(i).Name & ","
  '        Next
  '      End If
  '      ret = ret.TrimEnd(","c)
  '      Return ret
  '    End Function
  '    Public Function Save(ByVal currentUserId As Integer) As SaveErrorException
  '      Try

  '        Dim sqlConString As String = RecentCompanies.CurrentCompany.ConnectionString
  '        Dim conn As New SqlConnection(sqlConString)
  '        Dim cmd As SqlCommand = conn.CreateCommand
  '        cmd.CommandText = "Execute GetMultiApprovalList " & GetParamsString(m_filters)
  '        If Not m_filters Is Nothing AndAlso m_filters.Length > 0 Then
  '          For i As Integer = 0 To m_filters.Length - 1
  '            cmd.Parameters.Add(New SqlParameter("@" & m_filters(i).Name, m_filters(i).Value))
  '          Next
  '        End If

  '        Dim m_dataset As New DataSet
  '        Dim m_da As New SqlDataAdapter
  '        m_da.SelectCommand = cmd

  '        m_da.Fill(m_dataset, "MultiApproval")

  '        Dim cmdBuilder As New SqlCommandBuilder(m_da)

  '        Dim dt As DataTable = m_dataset.Tables("MultiApproval")
  '        For Each row As DataRow In dt.Rows
  '          If row.IsNull("MultiApproval_default") OrElse CInt(row("MultiApproval_default")) = 0 Then
  '            'ไม่ใช่ default
  '            If GetItemWithId(CInt(row("MultiApproval_id"))) Is Nothing Then
  '              'หาไม่เจอ
  '              If MultiApproval.CanDeleteThisId(CInt(row("MultiApproval_id"))) Then
  '                'ลบได้
  '                row.Delete()
  '              Else
  '                MessageBox.Show("หน่วยนับ '" & CStr(row("MultiApproval_name")) & "' ถูกอ้างอิงแล้ว ไม่สามารถลบได้")
  '              End If
  '            End If
  '          End If
  '        Next
  '        For Each item As MultiApproval In Me
  '          If Not item.Originated Then
  '            Dim dr As DataRow = dt.NewRow
  '            dr("MultiApproval_code") = item.Code
  '            dr("MultiApproval_name") = item.Name
  '            dr("MultiApproval_default") = 0 'add เพิ่มเอง
  '            dr("MultiApproval_pjmid") = DBNull.Value
  '            dt.Rows.Add(dr)
  '          Else
  '            Dim theRows As DataRow() = dt.Select("MultiApproval_id=" & item.Id)
  '            If theRows.Length = 1 Then
  '              Dim dr As DataRow = theRows(0)
  '              dr("MultiApproval_code") = item.Code
  '              dr("MultiApproval_name") = item.Name
  '              dr("MultiApproval_default") = dr("MultiApproval_default")
  '              dr("MultiApproval_pjmid") = dr("MultiApproval_pjmid")
  '            End If
  '          End If
  '        Next
  '        ' First process deletes.
  '        m_da.Update(dt.Select(Nothing, Nothing, DataViewRowState.Deleted))
  '        ' Next process updates.
  '        m_da.Update(dt.Select(Nothing, Nothing, DataViewRowState.ModifiedCurrent))
  '        ' Finally process inserts.
  '        m_da.Update(dt.Select(Nothing, Nothing, DataViewRowState.Added))
  '        Return New SaveErrorException("1")
  '      Catch ex As Exception
  '        Return New SaveErrorException("Error Saving:" & ex.ToString)
  '      End Try
  '    End Function
  '    Public Sub PopulateTable(ByVal dt As TreeTable)
  '      Dim i As Integer = 0
  '      dt.Clear()
  '      Dim stServ As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
  '      For Each item As MultiApproval In Me
  '        i += 1
  '        Dim newRow As TreeRow = dt.Childs.Add
  '        newRow("Linenumber") = i
  '        newRow("code") = item.Code
  '        newRow("Name") = item.Name
  '        If item.IsDefault Then
  '          newRow("Default") = stServ.Parse("${res:Longkong.Pojjaman.Gui.Panels.MultiApprovalFilterSubPanel.cmbMultiApprovalType.Default}")
  '        Else
  '          newRow("Default") = stServ.Parse("${res:Longkong.Pojjaman.Gui.Panels.MultiApprovalFilterSubPanel.cmbMultiApprovalType.UserDefined}")
  '        End If
  '        newRow.Tag = item
  '      Next
  '    End Sub
  '#End Region

  '#Region "Collection Methods"
  '    Public Function Add(ByVal value As MultiApproval) As Integer
  '      If Not Me.Contains(value) Then
  '        Return MyBase.List.Add(value)
  '      End If
  '    End Function
  '    Public Sub AddRange(ByVal value As MultiApprovalCollection)
  '      For i As Integer = 0 To value.Count - 1
  '        Me.Add(value(i))
  '      Next
  '    End Sub
  '    Public Sub AddRange(ByVal value As MultiApproval())
  '      For i As Integer = 0 To value.Length - 1
  '        Me.Add(value(i))
  '      Next
  '    End Sub
  '    Public Function Contains(ByVal value As MultiApproval) As Boolean
  '      Return MyBase.List.Contains(value)
  '    End Function
  '    Public Sub CopyTo(ByVal array As MultiApproval(), ByVal index As Integer)
  '      MyBase.List.CopyTo(array, index)
  '    End Sub
  '    Public Shadows Function GetEnumerator() As MultiApprovalEnumerator
  '      Return New MultiApprovalEnumerator(Me)
  '    End Function
  '    Public Function IndexOf(ByVal value As MultiApproval) As Integer
  '      Return MyBase.List.IndexOf(value)
  '    End Function
  '    Public Sub Insert(ByVal index As Integer, ByVal value As MultiApproval)
  '      MyBase.List.Insert(index, value)
  '    End Sub
  '    Public Sub Remove(ByVal value As MultiApproval)
  '      MyBase.List.Remove(value)
  '    End Sub
  '    Public Sub Remove(ByVal value As MultiApprovalCollection)
  '      For i As Integer = 0 To value.Count - 1
  '        Me.Remove(value(i))
  '      Next
  '    End Sub
  '    Public Sub Remove(ByVal index As Integer)
  '      MyBase.List.RemoveAt(index)
  '    End Sub
  '#End Region


  '    Public Class MultiApprovalEnumerator
  '      Implements IEnumerator

  '#Region "Members"
  '      Private m_baseEnumerator As IEnumerator
  '      Private m_temp As IEnumerable
  '#End Region

  '#Region "Construtor"
  '      Public Sub New(ByVal mappings As MultiApprovalCollection)
  '        Me.m_temp = mappings
  '        Me.m_baseEnumerator = Me.m_temp.GetEnumerator
  '      End Sub
  '#End Region

  '      Public ReadOnly Property Current() As Object Implements System.Collections.IEnumerator.Current
  '        Get
  '          Return CType(Me.m_baseEnumerator.Current, MultiApproval)
  '        End Get
  '      End Property

  '      Public Function MoveNext() As Boolean Implements System.Collections.IEnumerator.MoveNext
  '        Return Me.m_baseEnumerator.MoveNext
  '      End Function

  '      Public Sub Reset() Implements System.Collections.IEnumerator.Reset
  '        Me.m_baseEnumerator.Reset()
  '      End Sub
  '    End Class
  '  End Class

End Namespace

Public Class UnApproveDoc

End Class
