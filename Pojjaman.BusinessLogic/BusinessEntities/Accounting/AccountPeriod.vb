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
Namespace Longkong.Pojjaman.BusinessLogic
  Public Interface IAbleExceptAccountPeriod
    ReadOnly Property ExceptAccountPeriod As Boolean
  End Interface
  Public Interface ICheckPeriod
    Property DocDate() As Date
    ReadOnly Property OldDocDate As Date
  End Interface
  Public Enum AccountPeriodLock
    NoLock = 0
    GlLock = 1
    AllLock = 2
  End Enum
  Public Class AccountPeriod
    Inherits SimpleBusinessEntityBase
    Implements IForceListDialog

#Region "Members"
    Private acctperiod_startDate As Date
    Private acctperiod_endDate As Date
    Private acctperiod_lockDate As Date

    Private m_linenumber As Integer
    Private m_parent As AccountPeriod

    Private m_year As Date

    Private acctperiod_locking As AccountPeriodLock = AccountPeriodLock.NoLock

#End Region

#Region "Constructors"
    Public Sub New()
    End Sub
    Public Sub New(ByVal code As String)
      MyBase.New(code)
    End Sub
    Public Sub New(ByVal id As Integer)
      MyBase.New(id)
    End Sub
    Public Sub New(ByVal dr As DataRow, ByVal aliasPrefix As String)
      Construct(dr, aliasPrefix)
    End Sub
    Protected Overloads Overrides Sub Construct(ByVal dr As System.Data.DataRow, ByVal aliasPrefix As String)
      MyBase.Construct(dr, aliasPrefix)
      With Me
        If dr.Table.Columns.Contains("acctperiod_startdate") AndAlso Not dr.IsNull(aliasPrefix & "acctperiod_startdate") Then
          .acctperiod_startDate = CDate(dr(aliasPrefix & "acctperiod_startdate"))
        End If
        If dr.Table.Columns.Contains("acctperiod_endDate") AndAlso Not dr.IsNull(aliasPrefix & "acctperiod_endDate") Then
          .acctperiod_endDate = CDate(dr(aliasPrefix & "acctperiod_endDate"))
        End If
        If dr.Table.Columns.Contains("acctperiod_lockDate") AndAlso Not dr.IsNull(aliasPrefix & "acctperiod_lockDate") Then
          .acctperiod_lockDate = CDate(dr(aliasPrefix & "acctperiod_lockDate"))
        End If
        If dr.Table.Columns.Contains("acctperiod_locking") AndAlso Not dr.IsNull(aliasPrefix & "acctperiod_locking") Then
          .acctperiod_locking = CType([Enum].Parse(GetType(AccountPeriodLock), CStr(dr(aliasPrefix & "acctperiod_locking"))), AccountPeriodLock)
        End If
      End With
    End Sub
#End Region

#Region "Properties"
    Public Property Year() As Date      Get        Return m_year      End Get      Set(ByVal Value As Date)        m_year = Value      End Set    End Property    Public Property StartDate() As Date
      Get
        Return Me.acctperiod_startDate
      End Get
      Set(ByVal Value As Date)
        Me.acctperiod_startDate = Value
      End Set
    End Property
    Public Property EndDate() As Date
      Get
        Return Me.acctperiod_endDate
      End Get
      Set(ByVal Value As Date)
        Me.acctperiod_endDate = Value
      End Set
    End Property
    Public Property LockDate() As Date
      Get
        Return Me.acctperiod_lockDate
      End Get
      Set(ByVal Value As Date)
        Me.acctperiod_lockDate = Value
      End Set
    End Property
    Public Property Locking() As AccountPeriodLock
      Get
        Return Me.acctperiod_locking
      End Get
      Set(ByVal Value As AccountPeriodLock)
        Me.acctperiod_locking = Value
      End Set
    End Property
    Public ReadOnly Property IsLocked() As Boolean
      Get
        Return Not Me.acctperiod_lockDate.Equals(DateTime.MinValue)
      End Get
    End Property
    Public Overrides ReadOnly Property ClassName() As String
      Get
        Return "AccountPeriod"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.AccountPeriod.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.AccountPeriod"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.AccountPeriod"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.AccountPeriod.ListLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property Prefix() As String
      Get
        Return "acctperiod"
      End Get
    End Property
    Public Overrides ReadOnly Property UseSiteConnString() As Boolean
      Get
        Return True
      End Get
    End Property
#End Region

#Region "Methods"
    Public Shared Function GetLockingForDate(ByVal theDate As Date) As AccountPeriodLock
      Dim o As Object = SqlHelper.ExecuteScalar(AccountPeriod.ConnectionString _
      , CommandType.StoredProcedure _
      , "GetLockingForDate" _
      , New SqlParameter("@date", AccountPeriod.ValidDateOrDBNull(theDate)) _
      )
      If IsNumeric(o) Then
        Return CType([Enum].Parse(GetType(AccountPeriodLock), o.ToString), AccountPeriodLock)
      End If
      Return AccountPeriodLock.NoLock
    End Function
    Public Shared Function ValidDate(ByVal theDate As Date) As Boolean
      Dim o As Object = SqlHelper.ExecuteScalar(AccountPeriod.ConnectionString _
      , CommandType.StoredProcedure _
      , "ValidDate" _
      , New SqlParameter("@date", IIf(theDate.Equals(Date.MinValue), DBNull.Value, theDate)) _
      )
      If Not IsDBNull(o) And IsNumeric(o) Then
        If CInt(o) > 0 Then
          Return True
        End If
      End If
      Return False
    End Function
    Public Function GetNetProfit() As Decimal
      If Not Me.IsLocked Then
        Return 0
      End If
      Dim acct As Account = GeneralAccount.GetDefaultGA(GeneralAccount.DefaultGAType.AccProfit).Account
      Return acct.GetProfitToDate(Me.EndDate) - acct.GetProfitToDate(Me.StartDate.AddDays(-1))
    End Function
    Public Function GetAccProfit() As Decimal
      If Not Me.IsLocked Then
        Return 0
      End If
      Dim acct As Account = GeneralAccount.GetDefaultGA(GeneralAccount.DefaultGAType.AccProfit).Account
      Return acct.GetProfitToDate(Me.EndDate)
    End Function
    Public Function GetFirstUnlockedPeriodBefore() As AccountPeriod
      Try

        Dim sqlConString As String = RecentCompanies.CurrentCompany.ConnectionString
        Dim ds As DataSet = SqlHelper.ExecuteDataset( _
                sqlConString _
                , CommandType.StoredProcedure _
                , "GetFirstUnlockedPeriodBefore" _
                , New SqlParameter("@acctperiod_id", Me.Id) _
                )
        If ds.Tables(0).Rows.Count > 0 Then
          If Not IsDBNull(ds.Tables(0).Rows(0)(0)) AndAlso IsNumeric(ds.Tables(0).Rows(0)(0)) Then
            Dim newPeriod As AccountPeriod = New AccountPeriod(CInt(ds.Tables(0).Rows(0)(0)))
            If newPeriod.Originated Then
              Return newPeriod
            End If
          End If
        End If
        Return Nothing
      Catch ex As Exception
        MessageBox.Show(ex.Message)
      End Try
    End Function
    Public Shared Function YearIsBlank(ByVal year As Date) As Boolean
      Dim startDate As Date = GetYearStartDate(year)
      Dim endDate As Date = GetYearEndDate(year)
      If startDate.Equals(Date.MinValue) AndAlso endDate.Equals(Date.MinValue) Then
        Return True
      End If
      Return False
    End Function
    Public Shared Function GetYearStartDate(ByVal year As Date) As Date
      Try

        Dim sqlConString As String = RecentCompanies.CurrentCompany.ConnectionString
        Dim ds As DataSet = SqlHelper.ExecuteDataset( _
                sqlConString _
                , CommandType.StoredProcedure _
                , "GetYearStartDate" _
                , New SqlParameter("@year", year) _
                )
        If ds.Tables(0).Rows.Count > 0 Then
          If IsDate(ds.Tables(0).Rows(0)(0)) Then
            Return CDate(ds.Tables(0).Rows(0)(0))
          End If
        End If
        Return Date.MinValue
      Catch ex As Exception
        MessageBox.Show(ex.Message)
      End Try
    End Function
    Public Shared Function GetYearEndDate(ByVal year As Date) As Date
      Try

        Dim sqlConString As String = RecentCompanies.CurrentCompany.ConnectionString
        Dim ds As DataSet = SqlHelper.ExecuteDataset( _
                sqlConString _
                , CommandType.StoredProcedure _
                , "GetYearEndDate" _
                , New SqlParameter("@year", year) _
                )
        If ds.Tables(0).Rows.Count > 0 Then
          If IsDate(ds.Tables(0).Rows(0)(0)) Then
            Return CDate(ds.Tables(0).Rows(0)(0))
          End If
        End If
        Return Date.MinValue
      Catch ex As Exception
        MessageBox.Show(ex.Message)
      End Try
    End Function
    Public Function GetNextYearStartDate() As Date
      Return GetYearStartDate(Me.Year.AddYears(1))
    End Function
    Public Function GetLastYearEndDate() As Date
      Return GetYearEndDate(Me.Year.AddYears(-1))
    End Function
#End Region

#Region "Overrides"
    Public Overloads Overrides Function ToString() As String
      If Me.StartDate.Equals(Date.MinValue) Or Me.EndDate.Equals(Date.MinValue) Then
        Return ""
      End If
      Return Me.StartDate.ToShortDateString & "-" & Me.EndDate.ToShortDateString
    End Function
#End Region

#Region " Shared "
    Public Shared Function GetAccountPeriod(ByVal year As Date, ByVal periodcode As String) As AccountPeriod
      Dim filters(0) As Filter
      filters(0) = New Filter("year", IIf(year.Equals(Date.MinValue), DBNull.Value, year))
      Dim periodColl As New AccountPeriodCollection(filters)
      For Each period As AccountPeriod In periodColl
        If period.Code = periodcode Then
          Return period
        End If
      Next
      Return Nothing
    End Function
    Public Shared Function GetLastestAccountPeriod() As AccountPeriodCollection
      Dim periodColl As New AccountPeriodCollection
      Dim sqlConString As String = RecentCompanies.CurrentCompany.SiteConnectionString

      Dim ds As DataSet = Longkong.Pojjaman.DataAccessLayer.SqlHelper.ExecuteDataset(sqlConString _
      , CommandType.StoredProcedure _
      , "GetAccountPeriodList" _
      , New SqlClient.SqlParameter("@isMaxYear", 1))

      For Each row As DataRow In ds.Tables(0).Rows
        Dim item As New AccountPeriod(row, "")
        periodColl.Add(item)
      Next
      Return periodColl
    End Function
#End Region

  End Class


  <Serializable(), DefaultMember("Item")> _
  Public Class AccountPeriodCollection
    Inherits CollectionBase

#Region "Members"
    Private m_filters As Filter()
    Private m_year As Date
#End Region

#Region "Constructors"
    Public Sub New()
      MyBase.New()
    End Sub
    Public Sub New(ByVal filters As Filter())

      Dim sqlConString As String = RecentCompanies.CurrentCompany.SiteConnectionString
      m_filters = filters
      m_year = CDate(filters(0).Value)
      Dim params() As SqlParameter
      If Not filters Is Nothing AndAlso filters.Length > 0 Then
        ReDim params(filters.Length - 1)
        For i As Integer = 0 To filters.Length - 1
          params(i) = New SqlParameter("@" & filters(i).Name, filters(i).Value)
        Next
      End If

      Dim ds As DataSet = SqlHelper.ExecuteDataset(sqlConString _
      , CommandType.StoredProcedure _
      , "GetAccountPeriodList" _
      , params _
      )

      For Each row As DataRow In ds.Tables(0).Rows
        Dim item As New AccountPeriod(row, "")
        Me.Add(item)
      Next
    End Sub
#End Region

#Region "Properties"
    Default Public Property Item(ByVal index As Integer) As AccountPeriod
      Get
        Return CType(MyBase.List.Item(index), AccountPeriod)
      End Get
      Set(ByVal value As AccountPeriod)
        MyBase.List.Item(index) = value
      End Set
    End Property
#End Region

#Region "Class Methods"
    Public Function GetItemWithId(ByVal id As Integer) As AccountPeriod
      For Each item As AccountPeriod In Me
        If item.Id = id Then
          Return item
        End If
      Next
    End Function
    Protected Function GetParamsString(ByVal filters() As Filter) As String
      Dim ret As String = ""
      If Not filters Is Nothing AndAlso filters.Length > 0 Then
        For i As Integer = 0 To filters.Length - 1
          ret &= "@" & filters(i).Name & ","
        Next
      End If
      ret = ret.TrimEnd(","c)
      Return ret
    End Function
    Public Function Save(ByVal currentUserId As Integer) As SaveErrorException
      Try

        Dim sqlConString As String = RecentCompanies.CurrentCompany.ConnectionString
        Dim conn As New SqlConnection(sqlConString)
        Dim cmd As SqlCommand = conn.CreateCommand
        cmd.CommandText = "Execute GetAccountPeriodList " & GetParamsString(m_filters)
        If Not m_filters Is Nothing AndAlso m_filters.Length > 0 Then
          For i As Integer = 0 To m_filters.Length - 1
            cmd.Parameters.Add(New SqlParameter("@" & m_filters(i).Name, m_filters(i).Value))
          Next
        End If

        Dim m_dataset As New DataSet
        Dim m_da As New SqlDataAdapter
        m_da.SelectCommand = cmd

        m_da.Fill(m_dataset, "AccountPeriod")

        Dim cmdBuilder As New SqlCommandBuilder(m_da)

        Dim dt As DataTable = m_dataset.Tables("AccountPeriod")
        For Each row As DataRow In dt.Rows
          If row.IsNull("acctperiod_lockdate") Then
            'ยังไม่ปิดงวด
            If GetItemWithId(CInt(row("acctperiod_id"))) Is Nothing Then
              'หาไม่เจอ
              row.Delete()
            End If
          End If
        Next
        For Each item As AccountPeriod In Me
          If Not item.Originated Then
            Dim dr As DataRow = dt.NewRow
            dr("acctperiod_code") = item.Code
            dr("acctperiod_year") = m_year
            dr("acctperiod_originator") = currentUserId
            dr("acctperiod_lasteditor") = currentUserId
            dr("acctperiod_origindate") = Now
            dr("acctperiod_lasteditdate") = Now
            dr("acctperiod_startdate") = item.StartDate
            dr("acctperiod_enddate") = item.EndDate
            dr("acctperiod_origindate") = Now
            dr("acctperiod_locking") = CInt(item.Locking)
            dt.Rows.Add(dr)
          Else
            Dim theRows As DataRow() = dt.Select("acctperiod_id=" & item.Id)
            If theRows.Length = 1 Then
              Dim dr As DataRow = theRows(0)
              dr("acctperiod_code") = item.Code
              dr("acctperiod_year") = m_year
              dr("acctperiod_originator") = currentUserId
              dr("acctperiod_lasteditor") = currentUserId
              dr("acctperiod_origindate") = Now
              dr("acctperiod_lasteditdate") = Now
              dr("acctperiod_startdate") = item.StartDate
              dr("acctperiod_enddate") = item.EndDate
              dr("acctperiod_origindate") = Now
              dr("acctperiod_locking") = CInt(item.Locking)
            End If
          End If
        Next
        ' First process deletes.
        m_da.Update(dt.Select(Nothing, Nothing, DataViewRowState.Deleted))
        ' Next process updates.
        m_da.Update(dt.Select(Nothing, Nothing, DataViewRowState.ModifiedCurrent))
        ' Finally process inserts.
        m_da.Update(dt.Select(Nothing, Nothing, DataViewRowState.Added))
        Return New SaveErrorException("1")
      Catch ex As Exception
        Return New SaveErrorException("Error Saving:" & ex.ToString)
      End Try
    End Function
    Public Function AutoRun(ByVal taxYear As Date) As Boolean
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      If Me.Count > 1 Then
        msgServ.ShowMessage("${res:Global.Error.MoreThanOneAccountPeriod}")
        Return False
      End If
      If Me.Count = 0 Then
        'ไม่มีงวดเลย
        For i As Integer = 1 To 12
          Dim acctPeriod As New AccountPeriod
          acctPeriod.Code = i.ToString.PadLeft(2, "0"c)
          acctPeriod.StartDate = New Date(taxYear.Year, i, 1)
          If i <> 12 Then
            acctPeriod.EndDate = New Date(taxYear.Year, i + 1, 1).AddDays(-1)
          Else
            acctPeriod.EndDate = New Date(taxYear.Year + 1, 1, 1).AddDays(-1)
          End If
          Me.Add(acctPeriod)
        Next
        Return True
      End If
      If Me.Count = 1 Then
        If Me(0).StartDate.Equals(Date.MinValue) Then
          msgServ.ShowMessage("${res:Global.Error.OneAccountPeriodNoStartDate}")
          Return False
        End If
        Dim startMonth As Integer = Me(0).StartDate.Month
        Dim startDay As Integer = Me(0).StartDate.Day
        Dim startYear As Integer = Me(0).StartDate.Year

        Dim nextStartDate As Date = Me(0).StartDate
        For i As Integer = 1 To 12
          Dim nextStartMonth As Integer = (startMonth + i) Mod 12
          If nextStartMonth = 0 Then
            nextStartMonth = 12
          End If
          Dim nextStartYear As Integer
          If (startMonth + i) \ 12 > 0 Then
            nextStartYear = startYear + 1
          Else
            nextStartYear = startYear
          End If
          Dim nextStartDay As Integer
          Dim days As Integer = Date.DaysInMonth(nextStartYear, nextStartMonth)
          nextStartDay = Math.Min(startDay, days)
          Dim acctPeriod As New AccountPeriod
          acctPeriod.Code = i.ToString.PadLeft(2, "0"c)
          acctPeriod.StartDate = nextStartDate
          nextStartDate = New Date(nextStartYear, nextStartMonth, nextStartDay)
          acctPeriod.EndDate = nextStartDate.AddDays(-1)
          If i = 1 Then
            Me(0) = acctPeriod
          Else
            Me.Add(acctPeriod)
          End If
        Next
        Return True
      End If
    End Function

    Public Sub PopulateTable(ByVal dt As TreeTable)
      Dim i As Integer = 0
      dt.Clear()
      For Each item As AccountPeriod In Me
        i += 1
        Dim newRow As TreeRow = dt.Childs.Add
        newRow("Linenumber") = i
        newRow("code") = item.Code
        newRow("StartDate") = item.StartDate
        newRow("EndDate") = item.EndDate
        Dim profit As Decimal = item.GetNetProfit
        Dim accProfit As Decimal = item.GetAccProfit
        If profit = 0 Then
          newRow("Profit") = ""
        Else
          newRow("Profit") = Configuration.FormatToString(profit, DigitConfig.Price)
        End If
        If accProfit = 0 Then
          newRow("AccProfit") = ""
        Else
          newRow("AccProfit") = Configuration.FormatToString(accProfit, DigitConfig.Price)
        End If
        If item.IsLocked Then
          newRow("Status") = item.StringParserService.Parse("${res:Global.PeriodClose}")
        Else
          newRow("status") = item.StringParserService.Parse("${res:Global.PeriodOpen}")
        End If
        If item.IsLocked Then
          newRow("Status") = item.StringParserService.Parse("${res:Global.PeriodClose}")
        Else
          newRow("status") = item.StringParserService.Parse("${res:Global.PeriodOpen}")
        End If
        newRow("Locking") = CInt(item.Locking)
        newRow.Tag = item
      Next
    End Sub
#End Region

#Region "Collection Methods"
    Public Function Add(ByVal value As AccountPeriod) As Integer
      If Not Me.Contains(value) Then
        value.Year = m_year
        Return MyBase.List.Add(value)
      End If
    End Function
    Public Sub AddRange(ByVal value As AccountPeriodCollection)
      For i As Integer = 0 To value.Count - 1
        value(i).Year = m_year
        Me.Add(value(i))
      Next
    End Sub
    Public Sub AddRange(ByVal value As AccountPeriod())
      For i As Integer = 0 To value.Length - 1
        value(i).Year = m_year
        Me.Add(value(i))
      Next
    End Sub
    Public Function Contains(ByVal value As AccountPeriod) As Boolean
      Return MyBase.List.Contains(value)
    End Function
    Public Sub CopyTo(ByVal array As AccountPeriod(), ByVal index As Integer)
      MyBase.List.CopyTo(array, index)
    End Sub
    Public Shadows Function GetEnumerator() As AccountPeriodEnumerator
      Return New AccountPeriodEnumerator(Me)
    End Function
    Public Function IndexOf(ByVal value As AccountPeriod) As Integer
      Return MyBase.List.IndexOf(value)
    End Function
    Public Sub Insert(ByVal index As Integer, ByVal value As AccountPeriod)
      value.Year = m_year
      MyBase.List.Insert(index, value)
    End Sub
    Public Sub Remove(ByVal value As AccountPeriod)
      MyBase.List.Remove(value)
    End Sub
    Public Sub Remove(ByVal value As AccountPeriodCollection)
      For i As Integer = 0 To value.Count - 1
        Me.Remove(value(i))
      Next
    End Sub
    Public Sub Remove(ByVal index As Integer)
      MyBase.List.RemoveAt(index)
    End Sub
#End Region


    Public Class AccountPeriodEnumerator
      Implements IEnumerator

#Region "Members"
      Private m_baseEnumerator As IEnumerator
      Private m_temp As IEnumerable
#End Region

#Region "Construtor"
      Public Sub New(ByVal mappings As AccountPeriodCollection)
        Me.m_temp = mappings
        Me.m_baseEnumerator = Me.m_temp.GetEnumerator
      End Sub
#End Region

      Public ReadOnly Property Current() As Object Implements System.Collections.IEnumerator.Current
        Get
          Return CType(Me.m_baseEnumerator.Current, AccountPeriod)
        End Get
      End Property

      Public Function MoveNext() As Boolean Implements System.Collections.IEnumerator.MoveNext
        Return Me.m_baseEnumerator.MoveNext
      End Function

      Public Sub Reset() Implements System.Collections.IEnumerator.Reset
        Me.m_baseEnumerator.Reset()
      End Sub
    End Class
  End Class

End Namespace
