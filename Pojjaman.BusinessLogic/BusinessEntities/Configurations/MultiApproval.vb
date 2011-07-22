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

    Private m_docTypefilter As MultiApproveType
    Private m_unitType As Hashtable
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
    End Sub
    Public Function GetDocumentFilter(ByVal arr As ArrayList) As String
      Dim filterString As String = ""

      filterString = String.Join(" or ", arr.ToArray)

      Return filterString
    End Function
    Public Function GetApproveFilter(ByVal arr As ArrayList) As String
      Dim filterString As String = ""

      filterString = String.Join("", arr.ToArray)

      Return filterString
    End Function
    Public Sub New(ByVal UserId As Integer, ByVal approveType As Integer, ByVal DateRank As Integer)

      Me.RefreshData(UserId, approveType, DateRank, Me.AlwaysShowData)
      m_unitType = New Hashtable

      m_unitType(-2) = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.MultiApproval.Over}") '"เกิน"
      m_unitType(-1) = ""
      m_unitType(0) = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.MultiApproval.MinutsUnit}") '"นาทีมาแล่้ว"
      m_unitType(1) = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.MultiApproval.TodayUnit}") '"วันนี้มาแล้ว"
      m_unitType(2) = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.MultiApproval.HourUnit}") '"ชั่วโมงมาแล้ว
      m_unitType(3) = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.MultiApproval.DaysUnit}") '"วันมาแล้ว"
      m_unitType(4) = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.MultiApproval.WeeksUnit}") '"สัปดาห์มาแล้ว"
      m_unitType(5) = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.MultiApproval.MonthsUnit}") '"เดือนมาแล้ว"
      m_unitType(6) = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.MultiApproval.YearsUnit}") '"ปีมาแล้ว"

      'Dim expandUnit As String = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.MultiApproval.Ago}")

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

      If filters Is Nothing Then
        dt = m_ListData.Tables(0)
      Else
        dt = Me.GetDataFiltered(m_ListData.Tables(0), filters)
      End If

      Dim authorizeString As String = CodeDescription.GetDescription("docApproveMethod", 5)
      Dim linenumber As Integer = 0
      Me.TotalQty = 0
      Me.TotalAmount = 0
      For Each row As DataRow In dt.Rows
        linenumber += 1

        Dim drh As New DataRowHelper(row)

        row("linenumber") = linenumber
        row("doca_amount") = Configuration.FormatToString(drh.GetValue(Of Decimal)("doca_amount"), DigitConfig.Price)
        If Not row.IsNull("doca_docdate") Then
          row("doca_docdate") = drh.GetValue(Of Date)("doca_docdate").ToShortDateString
        End If
        If drh.GetValue(Of Integer)("doca_method") > 0 Then
          If Not row.IsNull("minute_approve") Then
            row("approveperson") = drh.GetValue(Of String)("approveperson") & " (" & authorizeString & " " & Me.DateRank(drh.GetValue(Of Long)("minute_approve"), drh.GetValue(Of Integer)("day_approve")) & ")"
          End If
        End If
        If Not row.IsNull("minute_edite") Then
          row("laststatus") = drh.GetValue(Of String)("laststatus") & " " & Me.DateRank(drh.GetValue(Of Long)("minute_edite"), drh.GetValue(Of Integer)("day_edite")) & ")"
        End If
        'row("lasteditdocstatus") = row("lastEditdocStatus").ToString() & _
        '    Space(2) & "(" & Me.GetDateUnitName(row("daterank").ToString, CInt(row("dateranktype"))) & ")"

        Me.TotalQty += 1
        Me.TotalAmount += drh.GetValue(Of Decimal)("doca_amount")
      Next

      'laststatus
      ',datediff(minute,doca_editdate,getdate()) [minute_edite]
      ',datediff(minute,doca_approvdate,getdate()) [minute_approve]
      ',datediff(day,doca_editdate,getdate()) [day_edite]
      ',datediff(day,doca_approvdate,getdate()) [day_approve]

      Try
        rGrid.DataSource = dt

        'rGrid.MasterGridViewTemplate.ChildGridViewTemplates(0).DataSource = m_ListData.Tables(1)

        'rGrid.MasterGridViewTemplate.ChildGridViewTemplates(1).DataSource = dt
      Catch ex As Exception

      End Try

    End Sub
    Public Shared Function DateRank(ByVal minute As Long, ByVal day As Integer) As String
      Select Case minute
        Case Is < 1440
          If minute < 60 AndAlso day <= 0 Then
            Return minute.ToString & " นาทีมาแล้ว"
          ElseIf day > 0 Then
            Return day.ToString & " วันมาแล้ว"
          Else
            Return Math.Floor(minute / 60).ToString & " ชั่วโมงมาแล้ว"
          End If
        Case Is < 10080
          Return Math.Floor(minute / 1440).ToString & " วันมาแล้ว"
        Case Is < 21600
          Return Math.Floor(minute / 1440).ToString & " วันมาแล้ว"
        Case Is < 43200
          If minute < 30240 Then
            Return Math.Floor(minute / 1440).ToString & " วันมาแล้ว"
          Else
            Return Math.Floor(minute / 10080).ToString & " สัปดาห์มาแล้ว"
          End If
        Case Is < 525600
          Return Math.Floor(minute / 43200).ToString & " เดือนมาแล้ว"
        Case Else
          Return "มากกว่า 1 ปีมาแล้ว"
      End Select
    End Function
    Public Function GetDateUnitName(ByVal rank As String, ByVal type As Integer) As String
      'Dim expandUnit As String = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.MultiApproval.Ago}")
      Select Case type
        Case -1
          Return ""
        Case 6
          Return CStr(m_unitType(-2)) & rank & CStr(m_unitType(type))
        Case Else
          Return rank.ToString & CStr(m_unitType(type))
      End Select
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

      Dim docFilter As String = ""

      docFilter = Me.GetDocumentFilter(filters)

      For Each drow As DataRow In dt.Select(docFilter)
        Dim newdrow As DataRow = newdt.NewRow
        For Each col As DataColumn In dt.Columns
          newdrow(col.ColumnName) = drow(col.ColumnName)
        Next
        newdt.Rows.Add(newdrow)
      Next

      Return newdt

    End Function
    Public Shared Function GetMaxLevelApproveConfig(ByVal CurrentUserId As Integer) As Integer
      Dim ds As DataSet = SqlHelper.ExecuteDataset(SimpleBusinessEntityBase.ConnectionString,
                                                   CommandType.Text,
                                                   "select isnull(max(app_level),0) mx from dbo.ApprovalDocLevel where app_user = " & CurrentUserId.ToString)
      If ds.Tables.Count > 0 AndAlso Not ds.Tables(0).Rows(0).IsNull("mx") Then
        Return CInt(ds.Tables(0).Rows(0)(0))
      End If
      Return 0
    End Function
#End Region

#Region "Properties"
    Public Property TotalQty As Integer
    Public Property TotalAmount As Decimal
    Private m_listSelected As ArrayList
    Public ReadOnly Property IsSelected(ByVal rgrid As RadGridView) As Boolean
      Get
        Dim selected As Boolean = False

        m_listSelected = New ArrayList

        For Each gv As GridViewDataRowInfo In rgrid.Rows
          If CBool(gv.Cells("selected").Value) = True Then

            m_listSelected.Add(rgrid.MasterGridViewInfo.ViewTemplate.Rows(rgrid.MasterGridViewInfo.ViewTemplate.Rows.IndexOf(gv)))
            selected = True
          End If
        Next

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
  
    Public Property ListData As DataSet
      Get
        Return m_ListData
      End Get
      Set(ByVal value As DataSet)

      End Set
    End Property
    Public Property CurrentUserId As Integer
  
    Public Property AlwaysShowPage As Boolean
      Get
        'Dim config As Boolean = CBool(ConfigurationUser.GetConfig(CurrentUserId, "AlwaysShowMultiApprovePage"))
        Dim config As String = (ConfigurationUser.GetConfig(CurrentUserId, "CurrentClassNameOfStartUpPage")).ToString
        If Me.FullClassName.ToLower.Equals(config.ToLower) Then
          Return True
        Else
          Return False
        End If
      End Get
      Set(ByVal value As Boolean)
        Dim classToStartUp As String
        If value Then
          classToStartUp = Me.FullClassName
        Else
          classToStartUp = "" 'Configuration.GetConfig("CurrentClassNameOfStartUpPage").ToString
        End If
        Dim saveEx As SaveErrorException = ConfigurationUser.Save(CurrentUserId, "CurrentClassNameOfStartUpPage", classToStartUp)
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

          Dim AppMultiDoc As New ApprovalMultiDoc

          AppMultiDoc.EntityId = CInt(gv.Cells("doca_entityid").Value)
          AppMultiDoc.EntityType = CInt(gv.Cells("doca_entitytype").Value)
          'AppMultiDoc.LineNumber = CInt(gv.Cells("apvdoc_linenumber").Value)

          AppMultiDoc.Comment = comment.Trim
          If isComment Then
            AppMultiDoc.Level = 0
          Else
            AppMultiDoc.Level = CInt(gv.Cells("viewer_level").Value)
          End If
          AppMultiDoc.Originator = Me.CurrentUserId
          AppMultiDoc.Reject = isReject

          saveError = AppMultiDoc.Save()
          If Not IsNumeric(saveError.Message) Then
            Throw New SaveErrorException(saveError.Message)
          End If
        Next

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
      End If

    End Sub
    Public Function GetApproveDoc(ByVal docid As Integer, ByVal doctype As Integer) As Boolean
      Try
        Dim dt As DataTable = Nothing
        Dim hashChild As Boolean = False

      Catch ex As Exception

      End Try
    End Function
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

End Namespace

Public Class UnApproveDoc

End Class
