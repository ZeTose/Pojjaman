Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration
Imports System.Reflection
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Services
Imports Longkong.Pojjaman.TextHelper
Namespace Longkong.Pojjaman.BusinessLogic
  ' Main Class
  Public Class DepreciationCal
    Inherits SimpleBusinessEntityBase
    Implements IGLAble, IPrintableEntity, IHasToCostCenter, IHasFromCostCenter, ICheckPeriod, INewPrintableEntity

#Region " Member "
    Private m_docdate As Date
    Private m_olddocdate As Date
    Private m_depredate As Date

    Private m_fromcc As CostCenter
    Private m_fromperson As Employee

    Private m_tocc As CostCenter
    Private m_toperson As Employee

    Private m_note As String

    Private m_itemCollection As DepreciationCalItemCollection

    Private m_je As JournalEntry
    Private m_blankline As Integer
    Private m_istransfer As Boolean

#End Region

#Region " Constructors "
    Public Sub New()
      MyBase.New()
    End Sub
    Public Sub New(ByVal Code As String)
      MyBase.New(Code)
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
        .m_docdate = Now.Date
        .m_olddocdate = Now.Date
        .m_fromcc = New CostCenter
        .m_fromperson = New Employee

        .m_tocc = New CostCenter
        .m_toperson = New Employee

        .m_je = New JournalEntry(Me)
        .m_je.DocDate = Me.m_docdate
        m_blankline = 0
        .m_istransfer = False
      End With
      m_itemCollection = New DepreciationCalItemCollection(Me)
    End Sub
    Protected Overloads Overrides Sub Construct(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
      Dim dr As DataRow = ds.Tables(0).Rows(0)
      Construct(dr, aliasPrefix)
    End Sub
    Protected Overloads Overrides Sub Construct(ByVal dr As System.Data.DataRow, ByVal aliasPrefix As String)
      MyBase.Construct(dr, aliasPrefix)
      With Me
        ' m_docdate As Date
        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_docdate") _
        AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_docdate") Then
          .m_docdate = CDate(dr(aliasPrefix & Me.Prefix & "_docdate"))
          .m_olddocdate = CDate(dr(aliasPrefix & Me.Prefix & "_docdate"))
        End If
        ' m_depredate As Date
        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_depredate") _
        AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_depredate") Then
          .m_depredate = CDate(dr(aliasPrefix & Me.Prefix & "_depredate"))
        End If
        ' m_fromcc As CostCenter
        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_fromcc") _
        AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_fromcc") Then
          .m_fromcc = New CostCenter(CInt(dr(aliasPrefix & Me.Prefix & "_fromcc")))
        End If
        ' m_fromperson As Employee
        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_fromperson") _
        AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_fromperson") Then
          .m_fromperson = New Employee(CInt(dr(aliasPrefix & Me.Prefix & "_fromperson")))
        End If
        ' m_tocc As CostCenter
        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_tocc") _
        AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_tocc") Then
          .m_tocc = New CostCenter(CInt(dr(aliasPrefix & Me.Prefix & "_tocc")))
        End If
        ' m_toperson As Employee
        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_toperson") _
        AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_toperson") Then
          .m_toperson = New Employee(CInt(dr(aliasPrefix & Me.Prefix & "_toperson")))
        End If
        ' m_note As String
        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_note") _
        AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_note") Then
          .m_note = CStr(dr(aliasPrefix & Me.Prefix & "_note"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_status") _
        AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_status") Then
          Me.Status = New StockStatus(CInt(dr(aliasPrefix & Me.Prefix & "_status")))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_istransfer") _
        AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_istransfer") Then
          .m_istransfer = CBool(dr(aliasPrefix & Me.Prefix & "_istransfer"))
        End If

        m_itemCollection = New DepreciationCalItemCollection(Me)

        .m_je = New JournalEntry(Me)
        .m_blankline = 0
      End With
    End Sub

#End Region

#Region " Properties "
    Public Property DocDate() As Date Implements ICheckPeriod.DocDate
      Get
        Return m_docdate
      End Get
      Set(ByVal Value As Date)
        m_docdate = Value
      End Set
    End Property
    Public ReadOnly Property OldDocDate As Date Implements ICheckPeriod.OldDocDate
      Get
        Return m_olddocdate
      End Get
    End Property
    Public Property DepreDate() As Date
      Get
        Return m_depredate
      End Get
      Set(ByVal Value As Date)
        m_depredate = Value
      End Set
    End Property

    Public Property FromCostcenter() As CostCenter
      Get
        Return m_fromcc
      End Get
      Set(ByVal Value As CostCenter)
        m_fromcc = Value
      End Set
    End Property
    Public Property FromPerson() As Employee
      Get
        Return m_fromperson
      End Get
      Set(ByVal Value As Employee)
        m_fromperson = Value
      End Set
    End Property

    Public Property ToCostcenter() As CostCenter
      Get
        Return m_tocc
      End Get
      Set(ByVal Value As CostCenter)
        m_tocc = Value
      End Set
    End Property
    Public Property ToPerson() As Employee
      Get
        Return m_toperson
      End Get
      Set(ByVal Value As Employee)
        m_toperson = Value
      End Set
    End Property

    Public Property Note() As String Implements IGLAble.Note
      Get
        Return m_note
      End Get
      Set(ByVal Value As String)
        m_note = Value
      End Set
    End Property

    Public Property ItemCollection() As DepreciationCalItemCollection
      Get
        Return m_itemCollection
      End Get
      Set(ByVal Value As DepreciationCalItemCollection)
        m_itemCollection = Value
      End Set
    End Property
    Public Property BlankLine() As Integer
      Get
        Return m_blankline
      End Get
      Set(ByVal Value As Integer)
        m_blankline = Value
      End Set
    End Property

    Public ReadOnly Property TotalBuyPrice() As Decimal
      Get
        Dim ret As Decimal = 0
        For Each item As DepreciationCalItem In Me.ItemCollection
          If Not item.Entity Is Nothing Then
            ret += item.DepreBase
          End If
        Next
        Return ret
      End Get
    End Property
    Public ReadOnly Property TotalOPB() As Decimal
      Get
        Dim ret As Decimal = 0
        For Each item As DepreciationCalItem In Me.ItemCollection
          ret += item.DepreOpeningBalanceamnt
        Next
        Return ret
      End Get
    End Property
    Public ReadOnly Property TotalSalvage() As Decimal
      Get
        Dim ret As Decimal = 0
        For Each item As DepreciationCalItem In Me.ItemCollection
          ret += item.Entity.Salvage
        Next
        Return ret
      End Get
    End Property

    Public ReadOnly Property TotalDepre() As Decimal
      Get
        Dim ret As Decimal = 0
        For Each item As DepreciationCalItem In Me.ItemCollection
          ret += item.Depreamnt
        Next
        Return ret
      End Get
    End Property

    Public Property IsTransfer As Boolean
      Get
        Return m_istransfer
      End Get
      Set(ByVal value As Boolean)
        m_istransfer = value
      End Set
    End Property

#End Region

#Region " Overrides "
    Public Overrides ReadOnly Property ClassName() As String
      Get
        Return "depreciationcal"
      End Get
    End Property

    Public Overrides ReadOnly Property Prefix() As String
      Get
        Return "depre"
      End Get
    End Property
    Public Overrides ReadOnly Property TableName() As String
      Get
        Return "DepreciationCal"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.DepreciationCal.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.DepreciationCal"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.DepreciationCal"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.DepreciationCal.ListLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property TabPageText() As String
      Get
        Dim tpt As String = Me.StringParserService.Parse(Me.DetailPanelTitle) & " (" & Me.Code & ")"
        If tpt.EndsWith("()") Then
          tpt.TrimEnd("()".ToCharArray)
        End If
        Return tpt
      End Get
    End Property
#End Region

#Region " Shared "
    Public Shared Function GetSchemaTable() As TreeTable
      Dim myDatatable As New TreeTable("DepreciationCal")
      myDatatable.Columns.Add(New DataColumn("linenumber", GetType(Integer)))

      'Asset
      myDatatable.Columns.Add(New DataColumn("asset_code", GetType(String))) ' Asset code
      myDatatable.Columns.Add(New DataColumn("asset_name", GetType(String))) ' Asset name
      myDatatable.Columns.Add(New DataColumn("btnAsset", GetType(String))) ' Asset button find
      myDatatable.Columns.Add(New DataColumn("asset_startCalcDate", GetType(Date))) ' วันที่เริ่มคำนวณค่าเสื่อมราคา

      ' คำนวณค่าเสื่อม
      myDatatable.Columns.Add(New DataColumn("deprei_price", GetType(String))) ' ต้นทุน
      myDatatable.Columns.Add(New DataColumn("deprei_salvage", GetType(String))) ' ค่าซาก
      myDatatable.Columns.Add(New DataColumn("deprei_age", GetType(Integer))) ' อายุค่าเสื่อม
      myDatatable.Columns.Add(New DataColumn("deprei_depreopening", GetType(String))) ' ค่าเสื่อมยกมา
      myDatatable.Columns.Add(New DataColumn("deprei_depreamnt", GetType(String))) ' ค่าเสื่อมเพิ่มเฉลี่ยต่อวัน
      myDatatable.Columns.Add(New DataColumn("deprei_note", GetType(String))) ' Note

      Return myDatatable
    End Function
#End Region

#Region " Methods "
    Private Sub ResetID(ByVal oldid As Integer, ByVal oldje As Integer)
      Me.Id = oldid
      Me.m_je.Id = oldje
    End Sub
    Public Function BeforeSave(ByVal currentUserId As Integer) As SaveErrorException

      Dim ValidateError As SaveErrorException





      ValidateError = Me.JournalEntry.BeforeSave(currentUserId)
      If Not IsNumeric(ValidateError.Message) Then
        Return ValidateError
      End If




      Return New SaveErrorException("0")

    End Function
    Public Overloads Overrides Function Save(ByVal currentUserId As Integer) As SaveErrorException
      If Me.ItemCollection.Count = 0 Then
        Return New SaveErrorException("${res:Global.Error.NoItem}")
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
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_id", Me.Id))
      End If

      Dim theTime As Date = Now
      Dim theUser As New User(currentUserId)

      If Me.AutoGen And Me.Code.Length = 0 Then
        Me.Code = Me.GetNextCode
      End If
      Me.AutoGen = False

      If Me.m_je.Status.Value = 4 Then
        Me.Status.Value = 4
      End If
      If Me.Status.Value = -1 Then
        Me.Status.Value = 2
      End If

      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_code", Me.Code))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_docdate", IIf(Me.DocDate.Equals(Date.MinValue), DBNull.Value, Me.DocDate)))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_depredate", IIf(Me.DepreDate.Equals(Date.MinValue), DBNull.Value, Me.DepreDate)))

      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_fromcc", IIf(Me.FromCostcenter.Originated, Me.FromCostcenter.Id, DBNull.Value)))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_fromperson", IIf(Me.FromPerson.Originated, Me.FromPerson.Id, DBNull.Value)))

      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_tocc", IIf(Me.ToCostcenter.Originated, Me.ToCostcenter.Id, DBNull.Value)))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_toperson", IIf(Me.ToPerson.Originated, Me.ToPerson.Id, DBNull.Value)))

      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_note", Me.Note))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_status", Me.Status.Value))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_istransfer", Me.IsTransfer))

      ' กำหนดการบันทึกผู้แก้ไข
      SetOriginEditCancelStatus(paramArrayList, currentUserId, theTime)

      '---==Validated การทำ before save ของหน้าย่อยอื่นๆ ====
      Dim ValidateError2 As SaveErrorException = Me.BeforeSave(currentUserId)
      If Not IsNumeric(ValidateError2.Message) Then
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
      trans = conn.BeginTransaction()

      Dim oldid As Integer = Me.Id
      Dim oldjeid As Integer = Me.m_je.Id
      Try


        Try
          Me.ExecuteSaveSproc(conn, trans, returnVal, sqlparams, theTime, theUser)
          If IsNumeric(returnVal.Value) Then
            Select Case CInt(returnVal.Value)
              Case -1, -2, -5
                trans.Rollback()
                Me.ResetID(oldid, oldjeid)
                Return New SaveErrorException(returnVal.Value.ToString)
              Case Else
            End Select
          ElseIf IsDBNull(returnVal.Value) OrElse Not IsNumeric(returnVal.Value) Then
            trans.Rollback()
            Me.ResetID(oldid, oldjeid)
            Return New SaveErrorException(returnVal.Value.ToString)
          End If

          SaveDetail(Me.Id, conn, trans, currentUserId)

          ' Save JournalEntry.
          If Me.m_je.Status.Value = -1 Then
            m_je.Status.Value = 3
          End If
          Dim saveJeError As SaveErrorException = Me.m_je.Save(currentUserId, conn, trans)
          If Not IsNumeric(saveJeError.Message) Then
            trans.Rollback()
            ResetID(oldid, oldjeid)
            Return saveJeError
          Else
            Select Case CInt(saveJeError.Message)
              Case -1, -5
                trans.Rollback()
                ResetID(oldid, oldjeid)
                Return saveJeError
              Case -2
                'Post ไปแล้ว
                Return saveJeError
              Case Else
            End Select
          End If



          trans.Commit()
        Catch ex As SqlException
          trans.Rollback()
          Me.ResetID(oldid, oldjeid)
          Return New SaveErrorException(ex.ToString)
        Catch ex As Exception
          trans.Rollback()
          Me.ResetID(oldid, oldjeid)
          Return New SaveErrorException(ex.ToString)

        End Try
        'Sub Save Block
        Try
          Dim subsaveerror As SaveErrorException = SubSave(conn)
          If Not IsNumeric(subsaveerror.Message) Then
            Return New SaveErrorException(" Save Incomplete Please Save Again")
          End If
          Return New SaveErrorException(returnVal.Value.ToString)
          'Complete Save
        Catch ex As Exception
          Return New SaveErrorException(ex.ToString)
        End Try
        'Sub Save Block

      Catch ex As Exception
        Return New SaveErrorException(ex.ToString)
      Finally
        conn.Close()
      End Try
    End Function
    Private Function SubSave(ByVal conn As SqlConnection) As SaveErrorException

      '======เริ่ม trans 2 ลองผิดให้ save ใหม่ ========
      Dim trans As SqlTransaction = conn.BeginTransaction


      Try
        Me.DeleteRef(conn, trans)
        SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdateDepre_AWRef" _
       , New SqlParameter("@depre_id", Me.Id))

        If Me.Status.Value = 0 Then
          Me.CancelRef(conn, trans)
        End If
      Catch ex As Exception
        trans.Rollback()
        Return New SaveErrorException(ex.InnerException.ToString)
      End Try

      trans.Commit()
      Return New SaveErrorException("0")
    End Function
    'private function
    Private Function SaveDetail(ByVal parentID As Integer, ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByVal currentUserId As Integer) As Integer
      Dim sqlSelect As String = "Select * From DepreciationCalItem Where deprei_depre = " & Me.Id
      Dim da As New SqlDataAdapter(sqlSelect, conn)
      Dim cmdBuilder As New SqlCommandBuilder(da)

      Dim ds As New DataSet

      da.SelectCommand.Transaction = trans

      'ต้องอยู่ต่อจาก da.SelectCommand.Transaction = trans
      cmdBuilder.GetDeleteCommand.Transaction = trans
      cmdBuilder.GetInsertCommand.Transaction = trans
      cmdBuilder.GetUpdateCommand.Transaction = trans

      da.Fill(ds, "DepreciationCalItem")

      Dim oldItems As New ArrayList
      With ds.Tables("DepreciationCalItem")
        For Each row As DataRow In .Rows
          oldItems.Add(row("deprei_entity"))
          row.Delete()
        Next
        'For Each item As DepreciationCalItem In Me.ItemCollection
        '  item.DepreciationCalculation(item.Entity)
        'Next
        For Each oldId As Integer In oldItems
          Dim found As Boolean = False
          For Each item As DepreciationCalItem In Me.ItemCollection
            If oldId = item.Entity.Id Then
              found = True
              Exit For
            End If
          Next
          If Not found Then
            SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UnlockLastDeprecalOfAsset" _
            , New SqlParameter("@asset_id", oldId) _
            , New SqlParameter("@depre_id", Me.Id))

            SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "RollBackAssetCostCenter" _
            , New SqlParameter("@asset_id", oldId) _
            , New SqlParameter("@deprei_depre", Me.Id))

            SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "RollBackAssetLastDepreDate" _
            , New SqlParameter("@asset_id", oldId) _
            , New SqlParameter("@deprei_depre", Me.Id))
          End If
        Next
        Dim i As Integer = 0
        For Each item As DepreciationCalItem In Me.ItemCollection
          i += 1
          SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "LockLastDeprecalOfAsset" _
          , New SqlParameter("@asset_id", item.Entity.Id) _
          , New SqlParameter("@depre_id", Me.Id))

          If Me.IsTransfer Then
            SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdateAssetCostCenter" _
          , New SqlParameter("@asset_id", item.Entity.Id) _
          , New SqlParameter("@cc_id", ValidIdOrDBNull(Me.ToCostcenter)))
          End If

          SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdateAssetLastDepreDate" _
          , New SqlParameter("@asset_id", item.Entity.Id) _
          , New SqlParameter("@asset_lastdepredate", ValidDateOrDBNull(Me.DepreDate.Date)))

          Dim dr As DataRow = .NewRow
          dr("deprei_depre") = Me.Id
          dr("deprei_linenumber") = i
          dr("deprei_entity") = Me.ValidIdOrDBNull(item.Entity)
          dr("deprei_lastestcalcdate") = Me.ValidDateOrDBNull(item.LastestCalcDate.Date)
          dr("deprei_depredate") = Me.ValidDateOrDBNull(Me.DepreDate.Date)
          dr("deprei_depreamnt") = item.Depreamnt 'Configuration.Format(item.Depreamnt, DigitConfig.Price)
          dr("deprei_note") = item.Note
          dr("deprei_status") = Me.Status.Value
          dr("deprei_depreopening") = Configuration.Format(item.DepreOpeningBalanceamnt, DigitConfig.Price)
          dr("deprei_deprebase") = Configuration.Format(item.DepreBase, DigitConfig.Price)
          dr("deprei_cc") = ValidIdOrDBNull(item.CostCenter)
          .Rows.Add(dr)
        Next
      End With
      Dim saveRtn As Integer
      Dim dt As DataTable = ds.Tables("DepreciationCalItem")
      ' First process deletes.
      saveRtn = da.Update(dt.Select(Nothing, Nothing, DataViewRowState.Deleted))
      ' Next process updates.
      saveRtn = da.Update(dt.Select(Nothing, Nothing, DataViewRowState.ModifiedCurrent))
      ' Finally process inserts.
      saveRtn = da.Update(dt.Select(Nothing, Nothing, DataViewRowState.Added))
      Return saveRtn
    End Function
#End Region

    Public Function GetListIdOfAssetRemaing() As Hashtable
      Dim hs As New Hashtable

      Dim ds As DataSet = SqlHelper.ExecuteDataset(SimpleBusinessEntityBase.ConnectionString, CommandType.StoredProcedure, "GetAssetEndedCalcDateStillRemaining")
      For Each row As DataRow In ds.Tables(0).Rows
        Dim drh As New DataRowHelper(row)
        hs(drh.GetValue(Of String)("asset_id")) = row
      Next

      Return hs
    End Function

    'Public Function SetDepreAmountFromAssetStillRemainingButEndCalcDate() As Hashtable
    '  Dim hs As New Hashtable

    '  Dim ds As DataSet = SqlHelper.ExecuteDataset(SimpleBusinessEntityBase.ConnectionString, CommandType.StoredProcedure, "GetAssetList",
    '                                               New SqlParameter("IncludeIdList", Me.GetIncludeIdList),
    '                                               New SqlParameter("depre_id", Me.Id))
    '  For Each row As DataRow In ds.Tables(0).Rows
    '    Dim drh As New DataRowHelper(row)
    '    hs(drh.GetValue(Of String)("asset_id")) = row
    '  Next

    '  Return hs
    'End Function

    'Public Function GetIncludeIdList() As String
    '  Dim idList As New ArrayList
    '  If Not Me.ItemCollection Is Nothing Then
    '    For Each item As DepreciationCalItem In Me.ItemCollection
    '      If item.Entity IsNot Nothing Then
    '        idList.Add(String.Format("|{0}|", item.Entity.Id))
    '      End If
    '    Next

    '    Return String.Join("", idList.ToArray)
    '  End If
    'End Function

    Public Sub ReCalculationAll()
      'Dim hs As Hashtable = Me.GetListIdOfAssetRemaing

      'Dim existsId As Boolean = False
      For Each item As DepreciationCalItem In Me.ItemCollection

        Dim existsId As Boolean = False
        If Me.DepreDate > item.Entity.StartCalcDate Then
          'If hs.ContainsKey(item.Entity.Id.ToString) Then
          '  existsId = True
          'End If

          If item.Entity.EndCalcDate.ToString("yyyyMMdd") <= Me.DepreDate.ToString("yyyyMMdd") OrElse item.Entity.EndCalcDate.ToString("yyyyMMdd") <= DateTime.Now.ToString("yyyyMMdd") Then
            item.Set_Depreamnt(0)
            item.Set_Depreopeningamnt(0)
            item.Set_Writeoffamt(0)
            item.Set_Deprebase(0)
            item.Set_BuyPrice(0)

            item.GetDepreciationFromDB(Me, item.Entity, True)
          Else
            item.Set_Depreamnt(0)
            item.Set_Depreopeningamnt(0)
            item.Set_Writeoffamt(0)
            item.Set_Deprebase(0)
            item.Set_BuyPrice(0)

            'ReCalculate Depreciation Amount
            item.GetDepreciationFromDB(Me, item.Entity, False)
          End If
        End If
      Next
    End Sub

#Region " IGLAble "
    Private ReadOnly Property GetCurrentDepreOpening() As Decimal
      Get
        Dim currdeprevalue As Decimal

        Return currdeprevalue
      End Get
    End Property
    Private ReadOnly Property GetDepreOpening() As Decimal
      Get
        Dim deprevalue As Decimal

        Return deprevalue
      End Get
    End Property
    Public Property [Date]() As Date Implements IGLAble.Date
      Get
        Return Me.DocDate
      End Get
      Set(ByVal Value As Date)
        Me.DocDate = Value
      End Set
    End Property

    Public Function GetDefaultGLFormat() As GLFormat Implements IGLAble.GetDefaultGLFormat
      Dim ds As DataSet = SqlHelper.ExecuteDataset(Me.ConnectionString _
                            , CommandType.StoredProcedure _
                            , "GetGLFormatForEntity" _
                            , New SqlParameter("@entity_id", Me.EntityId), New SqlParameter("@default", 1))

      Dim glf As New GLFormat(ds.Tables(0).Rows(0), "")
      Return glf
    End Function
    Public Function SameCostCenter() As Boolean
      If Not Me.FromCostcenter Is Nothing Then
        If Not Me.ToCostcenter Is Nothing Then
          If Me.FromCostcenter.Id = Me.ToCostcenter.Id AndAlso Me.FromCostcenter.Id <> 0 Then
            Return True
          End If
        End If
      End If
      Return False
    End Function
    Public Function GetJournalEntries() As JournalEntryItemCollection Implements IGLAble.GetJournalEntries
      Dim jiColl As New JournalEntryItemCollection
      If GetTotalDeprePriceValue > 0 Then

        jiColl.AddRange(Me.GetItemJournalEntries())


        If IsTransfer AndAlso Not SameCostCenter() Then
          SetGLForCostCenter(jiColl)
        End If

      End If
      Return jiColl
    End Function

    Public Property JournalEntry() As JournalEntry Implements IGLAble.JournalEntry
      Get
        Return Me.m_je
      End Get
      Set(ByVal Value As JournalEntry)
        Me.m_je = Value
      End Set
    End Property
    Private ReadOnly Property GetTotalDeprePriceValue() As Decimal
      Get
        Dim totalbuyprice As Decimal
        For Each item As DepreciationCalItem In Me.ItemCollection
          totalbuyprice += item.DepreBase
        Next
        Return totalbuyprice
      End Get
    End Property
    Private Function GetItemJournalEntries() As JournalEntryItemCollection
      Dim jiColl As New JournalEntryItemCollection

      Dim ji As New JournalEntryItem
      Dim withdrawAccount As Account
      For Each item As DepreciationCalItem In Me.ItemCollection

        'item.DepreciationCalculation(item.Entity)

        Dim depreAcctMatched As Boolean = False
        Dim noDepreAcctMatched As Boolean = False

        Dim depreOPBAcctMatched As Boolean = False
        Dim noDepreOPBAcctMatched As Boolean = False

        'For Each addedJi As JournalEntryItem In jiColl
        '  If Not item.Entity Is Nothing Then
        '    'I6.2  ค่าเสื่อมสะสม
        '    Dim depreAccount As Account
        '    If Not item.Entity.DepreOpeningAccount Is Nothing AndAlso item.Entity.DepreOpeningAccount.Originated Then
        '      depreAccount = item.Entity.DepreOpeningAccount
        '    End If
        '    If Not depreAccount Is Nothing AndAlso depreAccount.Originated Then
        '      If (Not addedJi.Account Is Nothing AndAlso addedJi.Account.Id = depreAccount.Id) And addedJi.Mapping = "I6.2" Then
        '        addedJi.Amount += item.Depreamnt
        '        depreAcctMatched = True
        '      End If
        '    ElseIf depreAccount Is Nothing OrElse Not depreAccount.Originated Then
        '      If (addedJi.Account Is Nothing OrElse Not addedJi.Account.Originated) And addedJi.Mapping = "I6.2" Then
        '        addedJi.Amount += item.Depreamnt
        '        noDepreAcctMatched = True
        '      End If
        '    End If

        '    'I6.1 ค่าเสื่อมราคา
        '    Dim depreOPBAccount As Account
        '    If Not item.Entity.DepreAccount Is Nothing AndAlso item.Entity.DepreAccount.Originated Then
        '      depreOPBAccount = item.Entity.DepreAccount
        '    End If
        '    If Not depreOPBAccount Is Nothing AndAlso depreOPBAccount.Originated Then
        '      If (Not addedJi.Account Is Nothing AndAlso addedJi.Account.Id = depreOPBAccount.Id) And addedJi.Mapping = "I6.1" Then
        '        addedJi.Amount += item.Depreamnt
        '        depreAcctMatched = True
        '      End If
        '    ElseIf depreOPBAccount Is Nothing OrElse Not depreOPBAccount.Originated Then
        '      If (addedJi.Account Is Nothing OrElse Not addedJi.Account.Originated) And addedJi.Mapping = "I6.1" Then
        '        addedJi.Amount += item.Depreamnt
        '        noDepreAcctMatched = True
        '      End If
        '    End If
        '  End If
        'Next
        If Not item.Entity Is Nothing Then
          'I6.2  ค่าเสื่อมสะสม
          Dim depreAccount As Account
          If Not item.Entity.DepreOpeningAccount Is Nothing AndAlso item.Entity.DepreOpeningAccount.Originated Then
            'ใช้ acct ในรายการ
            depreAccount = item.Entity.DepreOpeningAccount
          End If
          If Not depreAccount Is Nothing AndAlso depreAccount.Originated Then
            'If Not depreAcctMatched Then
            ji = New JournalEntryItem
            ji.Mapping = "I6.2"
            ji.Amount += item.Depreamnt
            ji.Account = depreAccount
            If Me.IsTransfer AndAlso Me.FromCostcenter IsNot Nothing Then
              ji.CostCenter = Me.FromCostcenter
            ElseIf item.CostCenter IsNot Nothing Then
              ji.CostCenter = item.CostCenter
            Else
              ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
            End If
            'ji.EntityItem = item.Entity.Id
            'ji.EntityItemType = item.Entity.EntityId
            jiColl.Add(ji)
            'End If
          ElseIf depreAccount Is Nothing OrElse Not depreAccount.Originated Then
            If Not noDepreAcctMatched Then
              ji = New JournalEntryItem
              ji.Mapping = "I6.2"
              ji.Amount += item.Depreamnt
              If Me.IsTransfer AndAlso Me.FromCostcenter IsNot Nothing Then
                ji.CostCenter = Me.FromCostcenter
              ElseIf item.CostCenter IsNot Nothing Then
                ji.CostCenter = item.CostCenter
              Else
                ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
              End If
              'ji.EntityItem = item.Entity.Id
              'ji.EntityItemType = item.Entity.EntityId
              jiColl.Add(ji)
            End If
          End If

          If Not depreAccount Is Nothing AndAlso depreAccount.Originated Then
            'If Not depreAcctMatched Then
            ji = New JournalEntryItem
            ji.Mapping = "I6.2D"
            ji.Amount += item.Depreamnt
            ji.Account = depreAccount
            If Me.IsTransfer AndAlso Me.FromCostcenter IsNot Nothing Then
              ji.CostCenter = Me.FromCostcenter
            ElseIf item.CostCenter IsNot Nothing Then
              ji.CostCenter = item.CostCenter
            Else
              ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
            End If
            ji.Note = "{glfi.Field.Name}" + " " + item.Entity.Name
            ji.EntityItem = item.Entity.Id
            ji.EntityItemType = item.Entity.EntityId
            jiColl.Add(ji)
            'End If
          ElseIf depreAccount Is Nothing OrElse Not depreAccount.Originated Then
            'If Not noDepreAcctMatched Then
            ji = New JournalEntryItem
            ji.Mapping = "I6.2D"
            ji.Amount += item.Depreamnt
            If Me.IsTransfer AndAlso Me.FromCostcenter IsNot Nothing Then
              ji.CostCenter = Me.FromCostcenter
            ElseIf item.CostCenter IsNot Nothing Then
              ji.CostCenter = item.CostCenter
            Else
              ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
            End If
            ji.Note = "{glfi.Field.Name}" + " " + item.Entity.Name
            ji.EntityItem = item.Entity.Id
            ji.EntityItemType = item.Entity.EntityId
            jiColl.Add(ji)
            'End If
          End If

          'I6.1  ค่าเสื่อมราคา
          Dim depreOPBAccount As Account
          If Not item.Entity.DepreAccount Is Nothing AndAlso item.Entity.DepreAccount.Originated Then
            'ใช้ acct ในรายการ
            depreOPBAccount = item.Entity.DepreAccount
          End If
          If Not depreOPBAccount Is Nothing AndAlso depreOPBAccount.Originated Then
            'If Not depreAcctMatched Then
            ji = New JournalEntryItem
            ji.Mapping = "I6.1"
            ji.Amount += item.Depreamnt
            ji.Account = depreOPBAccount
            If Me.IsTransfer AndAlso Me.FromCostcenter IsNot Nothing Then
              ji.CostCenter = Me.FromCostcenter
            ElseIf item.CostCenter IsNot Nothing Then
              ji.CostCenter = item.CostCenter
            Else
              ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
            End If
            'ji.EntityItem = item.Entity.Id
            'ji.EntityItemType = item.Entity.EntityId
            jiColl.Add(ji)
            'End If
          ElseIf depreOPBAccount Is Nothing OrElse Not depreOPBAccount.Originated Then
            If Not noDepreAcctMatched Then
              ji = New JournalEntryItem
              ji.Mapping = "I6.1"
              ji.Amount += item.Depreamnt
              If Me.IsTransfer AndAlso Me.FromCostcenter IsNot Nothing Then
                ji.CostCenter = Me.FromCostcenter
              ElseIf item.CostCenter IsNot Nothing Then
                ji.CostCenter = item.CostCenter
              Else
                ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
              End If
              'ji.EntityItem = item.Entity.Id
              'ji.EntityItemType = item.Entity.EntityId
              jiColl.Add(ji)
            End If
          End If
          If Not depreOPBAccount Is Nothing AndAlso depreOPBAccount.Originated Then
            'If Not depreAcctMatched Then
            ji = New JournalEntryItem
            ji.Mapping = "I6.1D"
            ji.Amount += item.Depreamnt
            ji.Account = depreOPBAccount
            If Me.IsTransfer AndAlso Me.FromCostcenter IsNot Nothing Then
              ji.CostCenter = Me.FromCostcenter
            ElseIf item.CostCenter IsNot Nothing Then
              ji.CostCenter = item.CostCenter
            Else
              ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
            End If
            ji.Note = "{glfi.Field.Name}" + " " + item.Entity.Name
            ji.EntityItem = item.Entity.Id
            ji.EntityItemType = item.Entity.EntityId
            jiColl.Add(ji)
            'End If
          ElseIf depreOPBAccount Is Nothing OrElse Not depreOPBAccount.Originated Then
            'If Not noDepreAcctMatched Then
            ji = New JournalEntryItem
            ji.Mapping = "I6.1D"
            ji.Amount += item.Depreamnt
            If Me.IsTransfer AndAlso Me.FromCostcenter IsNot Nothing Then
              ji.CostCenter = Me.FromCostcenter
            ElseIf item.CostCenter IsNot Nothing Then
              ji.CostCenter = item.CostCenter
            Else
              ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
            End If
            ji.Note = "{glfi.Field.Name}" + " " + item.Entity.Name
            ji.EntityItem = item.Entity.Id
            ji.EntityItemType = item.Entity.EntityId
            jiColl.Add(ji)
            'End If
          End If
        End If

      Next
      Return jiColl
    End Function
    Private Sub SetGLForCostCenter(ByVal jiColl As JournalEntryItemCollection)
      Dim ji As New JournalEntryItem
      Dim ht As New Hashtable
      For Each item As DepreciationCalItem In Me.ItemCollection
        Dim toccacct As Account = item.Entity.Account
        If Not toccacct Is Nothing Then
          ht(toccacct.Id) = toccacct
        End If
        If item.Entity IsNot Nothing Then
          ' DR. สินทรัพย์ถาวร        costcenter ใหม่           ji.Mapping = "I6.3"
          ji = New JournalEntryItem
          ji.Mapping = "I6.3D"
          ji.Amount = item.DepreBase
          ji.Account = item.Entity.Account
          ji.CostCenter = Me.ToCostcenter
          ji.EntityItem = item.Entity.Id
          ji.EntityItemType = item.Entity.EntityId
          ji.Note = "{glfi.Field.Name}" + " " + item.Entity.Name
          jiColl.Add(ji)

          ' CR. สินทรัพย์ถาวร        costcenter เดิม           ji.Mapping = "I6.4"
          ji = New JournalEntryItem
          ji.Mapping = "I6.4D"
          ji.Amount = item.DepreBase
          ji.Account = item.Entity.Account
          ji.CostCenter = Me.FromCostcenter
          ji.EntityItem = item.Entity.Id
          ji.EntityItemType = item.Entity.EntityId
          ji.Note = "{glfi.Field.Name}" + " " + item.Entity.Name
          jiColl.Add(ji)
        End If
      Next
      For Each acct As Account In ht.Values
        Dim Intotalamnt As Decimal = 0
        For Each item As DepreciationCalItem In Me.ItemCollection
          Dim toccacct As Account = item.Entity.Account
          If toccacct.Originated Then
            If Not toccacct Is Nothing _
            AndAlso toccacct.Id = acct.Id Then
              Intotalamnt += item.Entity.BuyPrice
            End If
          End If
        Next
        If Intotalamnt > 0 Then
          ' DR. สินทรัพย์ถาวร        costcenter ใหม่           ji.Mapping = "I6.3"
          ji = New JournalEntryItem
          ji.Mapping = "I6.3"
          ji.Amount = Intotalamnt
          If acct.Originated Then
            ji.Account = acct
          End If
          ji.CostCenter = Me.ToCostcenter
          'ji.EntityItem = item.Entity.Id
          'ji.EntityItemType = item.Entity.EntityId
          jiColl.Add(ji)

          ' CR. สินทรัพย์ถาวร        costcenter เดิม           ji.Mapping = "I6.4"
          ji = New JournalEntryItem
          ji.Mapping = "I6.4"
          ji.Amount = Intotalamnt
          If acct.Originated Then
            ji.Account = acct
          End If
          ji.CostCenter = Me.FromCostcenter
          'ji.EntityItem = item.Entity.Id
          'ji.EntityItemType = item.Entity.EntityId
          jiColl.Add(ji)
        End If
      Next

    End Sub
#End Region

#Region "IPrintableEntity"
    Public Function GetDefaultFormPath() As String Implements IPrintableEntity.GetDefaultFormPath
      Return "AssetTransfer"
    End Function
    Public Function GetDefaultForm() As String Implements IPrintableEntity.GetDefaultForm
      Return "AssetTransfer"
    End Function

    Public Function GetDocPrintingEntries() As DocPrintingItemCollection Implements IPrintableEntity.GetDocPrintingEntries
      Dim dpiColl As New DocPrintingItemCollection
      Dim dpi As DocPrintingItem

      dpi = New DocPrintingItem
      dpi.Mapping = "depre_id"
      dpi.Value = Me.Id
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

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
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'TransferDate
      dpi = New DocPrintingItem
      dpi.Mapping = "TransferDate"
      dpi.Value = Me.DepreDate.ToShortDateString
      dpi.DataType = "System.DateTime"
      dpiColl.Add(dpi)

      'TransOutCCInfo
      If Me.FromCostcenter.Originated Then
        dpi = New DocPrintingItem
        dpi.Mapping = "TransOutCCInfo"
        dpi.Value = FromCostcenter.Code & ":" & FromCostcenter.Name
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        dpi = New DocPrintingItem
        dpi.Mapping = "TransOutCCCode"
        dpi.Value = FromCostcenter.Code
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        dpi = New DocPrintingItem
        dpi.Mapping = "TransOutCCName"
        dpi.Value = FromCostcenter.Name
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)
      End If

      'EmpTransOutInfo
      If Me.FromPerson.Originated Then
        dpi = New DocPrintingItem
        dpi.Mapping = "EmpTransOutInfo"
        dpi.Value = FromPerson.Code & ":" & FromPerson.Name
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        dpi = New DocPrintingItem
        dpi.Mapping = "EmpTransOutCode"
        dpi.Value = FromPerson.Code
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        dpi = New DocPrintingItem
        dpi.Mapping = "EmpTransOutName"
        dpi.Value = FromPerson.Name
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)
      End If

      'TransInCCInfo
      If Me.ToCostcenter.Originated Then
        dpi = New DocPrintingItem
        dpi.Mapping = "TransInCCInfo"
        dpi.Value = Me.ToCostcenter.Code & ":" & Me.ToCostcenter.Name
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        dpi = New DocPrintingItem
        dpi.Mapping = "TransInCCCode"
        dpi.Value = Me.ToCostcenter.Code
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        dpi = New DocPrintingItem
        dpi.Mapping = "TransInCCName"
        dpi.Value = Me.ToCostcenter.Name
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)
      End If

      'EmpTransInInfo
      If Me.ToPerson.Originated Then
        dpi = New DocPrintingItem
        dpi.Mapping = "EmpTransInInfo"
        dpi.Value = Me.ToPerson.Code & ":" & Me.ToPerson.Name
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        dpi = New DocPrintingItem
        dpi.Mapping = "EmpTransInCode"
        dpi.Value = Me.ToPerson.Code
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        dpi = New DocPrintingItem
        dpi.Mapping = "EmpTransInName"
        dpi.Value = Me.ToPerson.Name
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)
      End If

      'Note
      dpi = New DocPrintingItem
      dpi.Mapping = "Note"
      dpi.Value = Me.Note
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      Dim sumBuyPrice As Decimal = 0
      Dim sumDepreOpenning As Decimal = 0
      Dim sumSalvage As Decimal = 0
      Dim sumDepreamnt As Decimal = 0
      Dim sumDeprePlus As Decimal = 0

      Dim n As Integer = 0
      For Each item As DepreciationCalItem In Me.ItemCollection
        'item.DepreciationCalculation(item.Entity)
        dpi = New DocPrintingItem
        dpi.Mapping = "deprei_depre"
        dpi.Value = Me.Id
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        'Item.LineNumber
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.LineNumber"
        dpi.Value = n + 1
        dpi.DataType = "System.Int32"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        'Item.AssetCode
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.AssetCode"
        dpi.Value = item.Entity.Code
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        'Item.AssetName
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.AssetName"
        dpi.Value = item.Entity.Name
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        'Item.Age
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.Age"
        dpi.Value = item.Entity.Age
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        'Item.StartCalcDate
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.StartCalcDate"
        dpi.Value = item.Entity.StartCalcDate
        dpi.DataType = "System.DateTime"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        'Item.Price
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.Price"
        dpi.Value = Configuration.FormatToString(item.Entity.BuyPrice, DigitConfig.Price)
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)
        sumBuyPrice += item.Entity.BuyPrice

        'Item.DepreOpenning
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.DepreOpenning"
        dpi.Value = Configuration.FormatToString(item.DepreOpeningBalanceamnt, DigitConfig.Price)
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)
        sumDepreOpenning += item.DepreOpeningBalanceamnt

        'Item.Salvage
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.Salvage"
        dpi.Value = Configuration.FormatToString(item.Entity.Salvage, DigitConfig.Price)
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)
        sumSalvage += item.Entity.Salvage

        'Item.DeprePlus
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.DeprePlus"
        dpi.Value = Configuration.FormatToString(item.Depreamnt, DigitConfig.Price)
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)
        sumDeprePlus += item.Depreamnt

        n += 1
      Next

      'รวมราคาซื้อ
      'TotalPrice
      dpi = New DocPrintingItem
      dpi.Mapping = "TotalPrice"
      dpi.Value = Configuration.FormatToString(sumBuyPrice, DigitConfig.Price)
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'รวมค่าเสื่อมสะสมยกมา
      'TotalDepreOpenning
      dpi = New DocPrintingItem
      dpi.Mapping = "TotalDepreOpenning"
      dpi.Value = Configuration.FormatToString(sumDepreOpenning, DigitConfig.Price)
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'รวมค่าซาก
      'TotalSalvage
      dpi = New DocPrintingItem
      dpi.Mapping = "TotalSalvage"
      dpi.Value = Configuration.FormatToString(sumSalvage, DigitConfig.Price)
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'รวมค่าเสื่อมสะสมเพิ่ม
      'TotalDeprePlus
      dpi = New DocPrintingItem
      dpi.Mapping = "TotalDeprePlus"
      dpi.Value = Configuration.FormatToString(sumDeprePlus, DigitConfig.Price)
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)


      Return dpiColl
    End Function
#End Region

#Region "Delete"
    Public Overrides ReadOnly Property CanDelete() As Boolean
      Get
        Return Me.Status.Value <= 2
      End Get
    End Property
    Public Overrides Function Delete() As SaveErrorException
      If Not Me.Originated Then
        Return New SaveErrorException("${res:Global.Error.NoIdError}")
      End If
      Dim myMessage As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      Dim format(0) As String
      format(0) = Me.Code
      If Not myMessage.AskQuestionFormatted("${res:Global.ConfirmDeleteDepreciationCal}", format) Then
        Return New SaveErrorException("${res:Global.CencelDelete}")
      End If
      Dim trans As SqlTransaction
      Dim conn As New SqlConnection(Me.ConnectionString)
      conn.Open()
      trans = conn.BeginTransaction()
      Try

        Dim sqlSelect As String = "Select * From DepreciationCalItem Where deprei_depre = " & Me.Id
        Dim da As New SqlDataAdapter(sqlSelect, conn)
        Dim cmdBuilder As New SqlCommandBuilder(da)

        Dim ds As New DataSet

        da.SelectCommand.Transaction = trans

        'ต้องอยู่ต่อจาก da.SelectCommand.Transaction = trans
        cmdBuilder.GetDeleteCommand.Transaction = trans
        cmdBuilder.GetInsertCommand.Transaction = trans
        cmdBuilder.GetUpdateCommand.Transaction = trans

        da.Fill(ds, "DepreciationCalItem")
        Dim oldItems As New ArrayList
        For Each row As DataRow In ds.Tables(0).Rows
          oldItems.Add(row("deprei_entity"))
          row.Delete()
        Next
        For Each oldId As Integer In oldItems
          SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UnlockLastDeprecalOfAsset" _
          , New SqlParameter("@asset_id", oldId) _
          , New SqlParameter("@depre_id", Me.Id))

          SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "RollBackAssetCostCenter" _
          , New SqlParameter("@asset_id", oldId) _
          , New SqlParameter("@deprei_depre", Me.Id))

          SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "RollBackAssetLastDepreDate" _
          , New SqlParameter("@asset_id", oldId) _
          , New SqlParameter("@deprei_depre", Me.Id))
        Next
        Dim returnVal As System.Data.SqlClient.SqlParameter = New SqlParameter
        returnVal.ParameterName = "RETURN_VALUE"
        returnVal.DbType = DbType.Int32
        returnVal.Direction = ParameterDirection.ReturnValue
        returnVal.SourceVersion = DataRowVersion.Current
        SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "DeleteDepreciationCal", New SqlParameter() {New SqlParameter("@depre_id", Me.Id), returnVal})
        If IsNumeric(returnVal.Value) Then
          Select Case CInt(returnVal.Value)
            Case -1
              trans.Rollback()
              Return New SaveErrorException("${res:Global.DepreciationCalIsReferencedCannotBeDeleted}")
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

    Public Property FromCC() As CostCenter Implements IHasFromCostCenter.FromCC
      Get
        Return Me.FromCostcenter
      End Get
      Set(ByVal Value As CostCenter)
        Me.FromCostcenter = Value
      End Set
    End Property

    Public Property ToCC() As CostCenter Implements IHasToCostCenter.ToCC
      Get
        Return Me.ToCostcenter
      End Get
      Set(ByVal Value As CostCenter)
        Me.ToCostcenter = Value
      End Set
    End Property

#Region "INewPrintableEntity"
    Public Function GetDocPrintingColumnsEntries() As DocPrintingItemCollection Implements INewPrintableEntity.GetDocPrintingColumnsEntries
      Dim dpiColl As New DocPrintingItemCollection
      Dim dpi As DocPrintingItem

      dpiColl.RelationList.Add("general>depre_id>item>deprei_depre")

      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("depre_id", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Code", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("DocDate", "System.DateTime"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("TransferDate", "System.DateTime"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("TransOutCCInfo", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("TransOutCCCode", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("TransOutCCName", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("EmpTransOutInfo", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("EmpTransOutCode", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("EmpTransOutName", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("TransInCCInfo", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("TransInCCCode", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("TransInCCName", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("EmpTransInInfo", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("EmpTransInCode", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("EmpTransInName", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Note", "System.String"))

      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("TotalPrice", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("TotalDepreOpenning", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("TotalSalvage", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("TotalDeprePlus", "System.String"))

      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("deprei_depre", "System.String", "Item"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.LineNumber", "System.Int32", "Item"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.AssetCode", "System.String", "Item"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.AssetName", "System.String", "Item"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.Age", "System.String", "Item"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.StartCalcDate", "System.DateTime", "Item"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.Price", "System.String", "Item"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.DepreOpenning", "System.String", "Item"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.Salvage", "System.String", "Item"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.DeprePlus", "System.String", "Item"))

      Return dpiColl
    End Function

    Public Function GetDocPrintingDataEntries() As DocPrintingItemCollection Implements INewPrintableEntity.GetDocPrintingDataEntries
      Return Me.GetDocPrintingEntries
    End Function
#End Region

  End Class

  'Item Class
  Public Class DepreciationCalItem

#Region "Members"
    Private m_depreciationcal As DepreciationCal

    Private m_entity As Asset
    Private m_lineNumber As Integer

    Private m_note As String
    Private m_lastestCalcDate As Date
    Private m_cc As CostCenter
#End Region

#Region "Constructors"
    Public Sub New()
      MyBase.New()
      Me.Construct()
    End Sub
    Public Sub New(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
      Me.Construct(ds, aliasPrefix)
    End Sub
    Public Sub New(ByVal dr As DataRow, ByVal aliasPrefix As String)
      Me.Construct(dr, aliasPrefix)
    End Sub
    Protected Sub Construct()
      With Me
        .m_entity = New Asset
        .m_cc = New CostCenter
        m_note = ""
      End With
    End Sub
    Protected Sub Construct(ByVal dr As DataRow, ByVal aliasPrefix As String)
      'Me.Construct()
      With Me
        ' m_entity As Asset
        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_entity") _
        AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_entity") Then
          .m_entity = New Asset(CInt(dr(aliasPrefix & Me.Prefix & "_entity")))
        Else
          .m_entity = New Asset
        End If
        ' m_lineNumber As Integer
        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_linenumber") _
        AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_linenumber") Then
          .m_lineNumber = CInt(dr(aliasPrefix & Me.Prefix & "_linenumber"))
        End If
        ' m_note As String
        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_note") _
        AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_note") Then
          .m_note = CStr(dr(aliasPrefix & Me.Prefix & "_note"))
        Else
          .m_note = ""
        End If

        ' m_note As String
        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_lastestcalcdate") _
        AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_lastestcalcdate") Then
          .m_lastestCalcDate = CDate(dr(aliasPrefix & Me.Prefix & "_lastestcalcdate"))
        End If
        Dim drh As New DataRowHelper(dr)
        m_depreamnt = drh.GetValue(Of Decimal)(aliasPrefix & Me.Prefix & "_depreamnt")
        m_depreopeningamnt = drh.GetValue(Of Decimal)(aliasPrefix & Me.Prefix & "_depreopening")
        m_writeoffamt = drh.GetValue(Of Decimal)("asset_writeoffamt")
        m_deprebase = drh.GetValue(Of Decimal)(aliasPrefix & Me.Prefix & "_deprebase")
        m_buyprice = drh.GetValue(Of Decimal)("asset_buyprice")
        m_cc = CostCenter.GetCCMinDataById(drh.GetValue(Of Integer)(aliasPrefix & Me.Prefix & "_cc"))
      End With
    End Sub
    Protected Sub Construct(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
      Dim dr As DataRow = ds.Tables(0).Rows(0)
      Me.Construct(dr, aliasPrefix)
    End Sub
#End Region

#Region "Properties"
    Private ReadOnly Property Prefix() As String
      Get
        Return "deprei"
      End Get
    End Property

    Public Property LineNumber() As Integer
      Get
        Return m_lineNumber
      End Get
      Set(ByVal Value As Integer)
        m_lineNumber = Value
      End Set
    End Property
    Public Property DepreciationCal() As DepreciationCal
      Get
        Return m_depreciationcal
      End Get
      Set(ByVal Value As DepreciationCal)
        m_depreciationcal = Value
      End Set
    End Property
    Public Property Entity() As Asset
      Get
        Return m_entity
      End Get
      Set(ByVal Value As Asset)
        m_entity = Value
      End Set
    End Property
    Public ReadOnly Property LastestCalcDate() As Date
      Get
        If m_lastestCalcDate.Equals(Date.MinValue) Then
          Return Me.Entity.LastDepreDate
        End If
        Return m_lastestCalcDate
      End Get
    End Property
    ' หาจำนวนวันทั้งหมดในปีนั้น ๆ
    Private ReadOnly Property GetTotalOfYear(ByVal datevalue As Date) As Integer
      Get
        Dim dt As Date
        dt = DateSerial(datevalue.Year, 12, 31)
        Return dt.DayOfYear
      End Get
    End Property
    Public Property Note() As String
      Get
        Return m_note
      End Get
      Set(ByVal Value As String)
        m_note = Value
      End Set
    End Property
    Public Property CostCenter As CostCenter
      Get
        Return m_cc
      End Get
      Set(ByVal value As CostCenter)
        m_cc = value
      End Set
    End Property
#End Region

#Region "Methods"
    Public Sub CopyToDataRow(ByVal row As TreeRow)
      If row Is Nothing Then
        Return
      End If
      Me.DepreciationCal.IsInitialized = False
      row("linenumber") = Me.LineNumber
      If Not Me.Entity Is Nothing AndAlso Me.Entity.Originated Then

        'Asset

        ' คำนวณค่าเสื่อม

        row("asset_code") = Me.Entity.Code
        row("asset_name") = Me.Entity.Name
        row("btnAsset") = ""
        row("asset_startCalcDate") = Me.DepreciationCal.ValidDateOrDBNull(Me.Entity.StartCalcDate)

        ' คำนวณค่า
        'Me.DepreciationCalculation(Me.Entity)
        'Me.GetDepreciationFromDB(Me.DepreciationCal, Me.Entity)
        'm_deprebase = Entity.BuyPrice - m_writeoffamt
        row("deprei_note") = Me.Note
        row("deprei_depreopening") = Configuration.FormatToString(Me.DepreOpeningBalanceamnt, DigitConfig.Price)
        row("deprei_depreamnt") = Configuration.FormatToString(Me.Depreamnt, DigitConfig.Price)
        'row("deprei_price") = Configuration.FormatToString(Me.DepreBase, DigitConfig.Price)
        row("deprei_price") = Configuration.FormatToString(Me.DepreBase, DigitConfig.Price)
        row("deprei_salvage") = Configuration.FormatToString(Me.Entity.Salvage, DigitConfig.Price)
        row("deprei_age") = Configuration.FormatToString(Me.Entity.Age, DigitConfig.Int)
      End If
      Me.DepreciationCal.IsInitialized = True
    End Sub
#End Region

#Region "UI"
    Public Sub Clear()
      Me.m_entity = New Asset
      Me.m_note = ""
    End Sub
    Private HashAsset As Hashtable
    Public Sub SetEntityCode(ByVal theCode As String)
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      If theCode Is Nothing OrElse theCode.Length = 0 Then
        If Me.Entity.Code.Length <> 0 Then
          If msgServ.AskQuestionFormatted("${res:Global.Question.DeleteAssetDetail}", New String() {Me.Entity.Code}) Then
            Me.Clear()
          End If
        End If
        Return
      End If
      If HashAsset Is Nothing Then
        HashAsset = New Hashtable
      End If
      For Each item As DepreciationCalItem In Me.DepreciationCal.ItemCollection
        If Not HashAsset.ContainsKey(item.Entity.Code.ToLower) Then
          HashAsset.Add(item.Entity.Code.ToLower, item)
        End If
      Next
      If HashAsset.ContainsKey(theCode.ToLower) Then
        msgServ.ShowWarningFormatted("${res:Global.Error.AssetAreDuplicate}", theCode)
        Me.Clear()
        Return
      End If

      Dim oEntity As New Asset(theCode)
      If oEntity.Originated Then
        If Me.DepreciationCal.IsTransfer AndAlso Not oEntity.ValidCostCenter(Me.DepreciationCal.FromCostcenter) Then
          ' เตือนไม่มีใน costcenter
          msgServ.ShowWarningFormatted("${res:Global.Error.NoAssetCostcenter}", Me.DepreciationCal.FromCostcenter.Name)
          Return
        End If
        If oEntity.Status.Value <> 1 AndAlso Me.DepreciationCal.IsTransfer Then
          ' เตือน Status
          msgServ.ShowWarningFormatted("${res:Global.Error.AssetEqNotAvaliable}", oEntity.Code, oEntity.Status.Description)
          Return
        End If
        Me.Entity = oEntity
        Me.CostCenter = oEntity.Costcenter
      Else
        msgServ.ShowMessageFormatted("${res:Global.Error.NoEqAsset}", New String() {theCode})
        Return
      End If
    End Sub
    Public Sub SetItems(ByVal row As DataRow)
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      'If theCode Is Nothing OrElse theCode.Length = 0 Then
      'If Me.Entity.Code.Length <> 0 Then
      '  If msgServ.AskQuestionFormatted("${res:Global.Question.DeleteAssetDetail}", New String() {Me.Entity.Code}) Then
      Me.Clear()
      '  End If
      'End If
      'Return
      'End If
      Dim oEntity As New Asset(row, "")
      Me.Entity = oEntity

      Dim drh As New DataRowHelper(row)

      'oEntity.Id = drh.GetValue(Of Integer)("asset_id")
      'oEntity.Code = drh.GetValue(Of String)("asset_code")
      'oEntity.Name = drh.GetValue(Of String)("asset_name")
      'oEntity.Age = drh.GetValue(Of Integer)("asset_age")
      'oEntity.Salvage = drh.GetValue(Of Decimal)("asset_salvage")
      'oEntity.StartCalcDate = drh.GetValue(Of DateTime)("asset_startCalcDate")
      'oEntity.Costcenter = New CostCenter(drh.GetValue(Of Integer)("asset_cc"))

      ' Select Asset.asset_id
      ', asset_code
      ', asset_name
      ', asset_age
      '--, asset_calcRate
      ', asset_salvage
      ', asset_startCalcDate
      ', asset_endCalcDate +1 [asset_endCalcDate]

      ', asset_deprebase
      ', asset_buyPrice
      ', asset_writeoffamt
      ', isnull(asset_depreopening,0) + isnull(depreamt,0) [depreopeningamnt]
      ', isnull(asset_deprebase,0) - 1 - isnull(asset_depreopening,0) - isnull(depreamt,0) [depreamnt]

      Me.Set_Deprebase(drh.GetValue(Of Decimal)("asset_deprebase"))
      Me.Set_BuyPrice(drh.GetValue(Of Decimal)("asset_buyPrice"))
      Me.Set_Writeoffamt(drh.GetValue(Of Decimal)("asset_writeoffamt"))
      Me.Set_Depreopeningamnt(drh.GetValue(Of Decimal)("depreopeningamnt"))
      Me.Set_Depreamnt(drh.GetValue(Of Decimal)("depreamnt"))

      Me.CostCenter = oEntity.Costcenter

      'If oEntity.Originated Then
      '  If Me.DepreciationCal.IsTransfer AndAlso Not oEntity.ValidCostCenter(Me.DepreciationCal.FromCostcenter) Then
      '    ' เตือนไม่มีใน costcenter
      '    msgServ.ShowWarningFormatted("${res:Global.Error.NoAssetCostcenter}", Me.DepreciationCal.FromCostcenter.Name)
      '    Return
      '  End If
      '  If oEntity.Status.Value <> 1 AndAlso Me.DepreciationCal.IsTransfer Then
      '    ' เตือน Status
      '    msgServ.ShowWarningFormatted("${res:Global.Error.AssetEqNotAvaliable}", oEntity.Code, oEntity.Status.Description)
      '    Return
      '  End If
      '  Me.Entity = oEntity
      '  Me.CostCenter = oEntity.Costcenter
      'Else
      '  msgServ.ShowMessageFormatted("${res:Global.Error.NoEqAsset}", New String() {theCode})
      '  Return
      'End If

    End Sub
#End Region

#Region " Depreciation Calculation "

    Private m_depreamntinprocess As Decimal     ' ค่าเสื่อมถึงวันที่คำนวณ

    Private m_writeoffamt As Decimal              ' มูลค่า write-off ที่หักไปแล้ว
    Private m_deprebase As Decimal              ' ฐานราคาที่คิดค่าเสื่อม
    Private m_depreopeningamnt As Decimal       ' ค่าเสื่อมสะสมยกมา
    Private m_depreamnt As Decimal              ' ค่าเสื่อมสะสมที่ต้องการ
    Private m_remainingamnt As Decimal          ' ยอดคงเหลือ
    Private m_buyprice As Decimal               ' ราคาซื้อ

    Public ReadOnly Property DepreamntInProcess() As Decimal
      Get
        Return m_depreamntinprocess
      End Get
    End Property
    Public ReadOnly Property WriteOffAmt() As Decimal
      Get
        'If Me.m_entity.Type.DepreAble Then
        Return m_writeoffamt
        'End If

        'Return 0
      End Get
    End Property
    Public ReadOnly Property DepreBase() As Decimal
      Get
        'If Me.m_entity.Type.DepreAble Then
        Return m_deprebase
        'End If

        'Return 0
      End Get
    End Property
    Public ReadOnly Property BuyPrice() As Decimal
      Get
        Return m_buyprice
      End Get
    End Property
    Public ReadOnly Property DepreOpeningBalanceamnt() As Decimal
      Get
        If Me.m_entity.Type.DepreAble Then
          Return m_depreopeningamnt
        End If

        Return 0
      End Get
    End Property
    Public ReadOnly Property Depreamnt() As Decimal
      Get
        If Me.m_entity.Type.DepreAble Then
          Return m_depreamnt
        End If

        Return 0
      End Get
    End Property
    Public ReadOnly Property DepreRemainingamnt() As Decimal
      Get
        Return m_remainingamnt
      End Get
    End Property
    Public Sub Set_Depreamnt(value As Decimal)
      m_depreamnt = value
    End Sub
    Public Sub Set_Depreopeningamnt(value As Decimal)
      m_depreopeningamnt = value
    End Sub
    Public Sub Set_Writeoffamt(value As Decimal)
      m_writeoffamt = value
    End Sub
    Public Sub Set_Deprebase(value As Decimal)
      m_deprebase = value
    End Sub
    Public Sub Set_BuyPrice(value As Decimal)
      m_buyprice = value
    End Sub
    Public Sub GetDepreciationFromDB(ByVal Depre As DepreciationCal, ByVal myAsset As Asset, ByVal isRemainWithEndedCalc As Boolean)
      If myAsset Is Nothing OrElse Not myAsset.Originated Then
        Return
      End If

      Dim ds As New DataSet

      Try
        Dim sqlConString As String = RecentCompanies.CurrentCompany.ConnectionString

        ds = SqlHelper.ExecuteDataset(sqlConString _
        , CommandType.StoredProcedure _
        , "AssetDepreciation" _
        , New SqlParameter("@DepreId", Depre.Id) _
        , New SqlParameter("@AssetId", myAsset.Id) _
        , New SqlParameter("@DocDateEnd", Depre.DepreDate) _
        , New SqlParameter("@isRemainWithEndedCalc", isRemainWithEndedCalc))

        If ds.Tables(0).Rows.Count > 0 Then
          m_depreamnt = CDec(ds.Tables(0).Rows(0)("Depre"))
          m_depreopeningamnt = CDec(ds.Tables(0).Rows(0)("DepreAmount"))
          m_writeoffamt = CDec(ds.Tables(0).Rows(0)("writeoffamt"))
          m_deprebase = CDec(ds.Tables(0).Rows(0)("DepreBase"))
          m_buyprice = CDec(ds.Tables(0).Rows(0)("BuyPrice"))
        End If
      Catch ex As Exception

      End Try
    End Sub
    Public Sub DepreciationCalculation(ByVal myAsset As Asset)
      If myAsset Is Nothing OrElse Not myAsset.Originated Then
        Return
      End If

      m_depreamntinprocess = 0
      m_depreopeningamnt = 0
      m_depreamnt = 0
      m_remainingamnt = 0

      Dim lastestCalcDate As Date = Me.Entity.GetLastCalcDate(Me.DepreciationCal)
      If lastestCalcDate.Equals(Date.MinValue) Then
        m_depreopeningamnt = myAsset.DepreOpening
      Else
        If lastestCalcDate.Date < Me.DepreciationCal.DepreDate.Date Then
          m_depreopeningamnt = CDec(myAsset.DepreCalcAtDate(lastestCalcDate.Date))
        End If
      End If

      m_depreamntinprocess = CDec(myAsset.DepreCalcAtDate(Me.DepreciationCal.DepreDate.Date))

      m_depreamnt = m_depreamntinprocess - m_depreopeningamnt

      Dim depreval As Decimal = myAsset.RemainValue
      m_remainingamnt = depreval - m_depreamntinprocess
    End Sub
#End Region

  End Class

  <Serializable(), DefaultMember("Item")> _
  Public Class DepreciationCalItemCollection
    Inherits CollectionBase

#Region "Members"
    Private m_depre As DepreciationCal
    Private m_currentItem As DepreciationCalItem
#End Region

#Region "Constructors"
    Public Sub New(ByVal owner As DepreciationCal)
      Me.m_depre = owner
      If Not Me.m_depre.Originated Then
        Return
      End If


      Dim sqlConString As String = RecentCompanies.CurrentCompany.ConnectionString

      Dim ds As DataSet = SqlHelper.ExecuteDataset(sqlConString _
      , CommandType.StoredProcedure _
      , "GetDepreciationCalItem" _
      , New SqlParameter("@deprei_depre", Me.m_depre.Id))

      For Each row As DataRow In ds.Tables(0).Rows
        Dim item As New DepreciationCalItem(row, "")
        item.DepreciationCal = m_depre
        Me.Add(item)
      Next
    End Sub
#End Region

#Region "Properties"
    Default Public Property Item(ByVal index As Integer) As DepreciationCalItem
      Get
        Return CType(MyBase.List.Item(index), DepreciationCalItem)
      End Get
      Set(ByVal value As DepreciationCalItem)
        MyBase.List.Item(index) = value
      End Set
    End Property
    Public Property CurrentItem() As DepreciationCalItem
      Get
        Return m_currentItem
      End Get
      Set(ByVal Value As DepreciationCalItem)
        m_currentItem = Value
      End Set
    End Property
#End Region

#Region "Class Methods"
    Public Sub SetItems(ByVal items As BasketItemCollection, Optional ByVal targetType As Integer = -1)
      For i As Integer = 0 To items.Count - 1 Step 1
        Dim item As BasketItem = CType(items(i), BasketItem)
        Dim doc As New DepreciationCalItem
        If Not Me.CurrentItem Is Nothing Then
          doc = Me.CurrentItem
          Me.CurrentItem = Nothing
          If Me.Count = 0 Then
            Me.Add(doc)
          End If
        Else
          Me.Add(doc)
        End If
        Dim row As DataRow = Nothing
        If TypeOf (item.Tag) Is DataRow Then
          row = CType(item.Tag, DataRow)
        End If

        'doc.SetEntityCode(item.Code)
        doc.SetItems(row)
      Next
    End Sub
    Public Sub Populate(ByVal dt As TreeTable)
      dt.Clear()
      Dim i As Integer = 0
      For Each dpi As DepreciationCalItem In Me
        i += 1
        Dim newRow As TreeRow = dt.Childs.Add()
        dpi.CopyToDataRow(newRow)
        'dpi.ItemValidateRow(newRow)
        newRow.Tag = dpi
      Next
    End Sub
#End Region

#Region "Collection Methods"
    Public Function Add(ByVal value As DepreciationCalItem) As Integer
      If Not m_depre Is Nothing Then
        value.DepreciationCal = m_depre
      End If
      Return MyBase.List.Add(value)
    End Function
    Public Sub AddRange(ByVal value As DepreciationCalItemCollection)
      For i As Integer = 0 To value.Count - 1
        Me.Add(value(i))
      Next
    End Sub
    Public Sub AddRange(ByVal value As DepreciationCalItem())
      For i As Integer = 0 To value.Length - 1
        Me.Add(value(i))
      Next
    End Sub
    Public Function Contains(ByVal value As DepreciationCalItem) As Boolean
      Return MyBase.List.Contains(value)
    End Function
    Public Sub CopyTo(ByVal array As DepreciationCalItem(), ByVal index As Integer)
      MyBase.List.CopyTo(array, index)
    End Sub
    Public Shadows Function GetEnumerator() As DepreciationCalItemEnumerator
      Return New DepreciationCalItemEnumerator(Me)
    End Function
    Public Function IndexOf(ByVal value As DepreciationCalItem) As Integer
      Return MyBase.List.IndexOf(value)
    End Function
    Public Sub Insert(ByVal index As Integer, ByVal value As DepreciationCalItem)
      If Not m_depre Is Nothing Then
        value.DepreciationCal = m_depre
      End If
      MyBase.List.Insert(index, value)
    End Sub
    Public Sub Remove(ByVal value As DepreciationCalItem)
      MyBase.List.Remove(value)
    End Sub
    Public Sub Remove(ByVal index As Integer)
      MyBase.List.RemoveAt(index)
    End Sub
#End Region


    Public Class DepreciationCalItemEnumerator
      Implements IEnumerator

#Region "Members"
      Private m_baseEnumerator As IEnumerator
      Private m_temp As IEnumerable
#End Region

#Region "Construtor"
      Public Sub New(ByVal mappings As DepreciationCalItemCollection)
        Me.m_temp = mappings
        Me.m_baseEnumerator = Me.m_temp.GetEnumerator
      End Sub
#End Region

      Public ReadOnly Property Current() As Object Implements System.Collections.IEnumerator.Current
        Get
          Return CType(Me.m_baseEnumerator.Current, DepreciationCalItem)
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
