Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration
Imports System.Reflection
Imports Longkong.Pojjaman.Gui.Components
Imports System.ComponentModel
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.AddIns
Namespace Longkong.Pojjaman.BusinessLogic
  ''' -----------------------------------------------------------------------------
  ''' Project	 : Pojjaman.BusinessLogic
  ''' Class	 : Pojjaman.BusinessLogic.SimpleBusinessEntityBase
  ''' 
  ''' -----------------------------------------------------------------------------
  ''' <summary>
  ''' 
  ''' </summary>
  ''' <remarks>
  ''' เป็น Class แม่ของ Business Logic ทั้งหมด
  ''' </remarks>
  ''' <history>
  ''' 	[KRISS]	08/01/2549	Created
  ''' </history>
  ''' -----------------------------------------------------------------------------
  Public Class SimpleBusinessEntityBase
    Implements IPropertyChangeable, ISimpleEntity, ICodeGeneratable, IHasCustomNote, IDirtyAble, IDeletableWithLog, IGlChangable

#Region "Members"
    Private m_htChangedProperties As New Hashtable ' เก็บค่าของ columns ที่มีการเปลี่ยนแปลง
    Private m_id As Integer
    Private m_code As String

    Private m_canceled As Boolean
    Private m_cancelDate As Date
    Private m_cancelPerson As User
    Private m_originated As Boolean
    Private m_originDate As Date
    Private m_originator As User
    Private m_edited As Boolean
    Private m_lastEditDate As Date
    Private m_lastEditor As User

    Private m_status As CodeDescription

    Private m_stringParserService As StringParserService

    Private m_columns As ColumnCollection

    Private m_userId As Integer
    Private m_isinitialized As Boolean

    Private m_autogen As Boolean
		Private m_entityId As Integer
    Private m_noSaveMessage As Boolean = False

#End Region

#Region "Constructors"
    Public Sub New()
      Construct()
    End Sub
    Public Sub New(ByVal id As Integer)
      Me.New(id, 0)
    End Sub
    Public Sub New(ByVal id As Integer, ByVal ParamArray filters() As Filter)
      Me.New(id, 0, filters)
    End Sub
    Public Sub New(ByVal code As String)
      Me.New(code, 0)
    End Sub
    Public Sub New(ByVal code As String, ByVal ParamArray filters() As Filter)
      Me.New(code, 0, filters)
    End Sub
    Public Sub New(ByVal id As Integer, ByVal userId As Integer)
      If id <= 0 Then
        Return
      End If

      Me.m_userId = userId

      If Me.GetSprocName Is Nothing OrElse Me.GetSprocName.Length = 0 Then
        'MessageBox.Show(Me.ClassName)
        Return
      End If
      Dim ds As DataSet = SqlHelper.ExecuteDataset(Me.RealConnectionString _
      , CommandType.StoredProcedure _
      , Me.GetSprocName _
      , New SqlParameter("@" & Me.Prefix & "_id", id) _
      )
      If ds.Tables(0).Rows.Count = 1 Then
        Construct(ds.Tables(0).Rows(0), "")
      End If
    End Sub
    Public Sub New(ByVal id As Integer, ByVal userId As Integer, ByVal ParamArray filters() As Filter)
      If id <= 0 Then
        Return
      End If
      Dim params() As SqlParameter
      If Not filters Is Nothing AndAlso filters.Length > 0 Then
        ReDim params(filters.Length)
        For i As Integer = 0 To filters.Length - 1
          params(i) = New SqlParameter("@" & filters(i).Name, filters(i).Value)
        Next
        params(filters.Length) = New SqlParameter("@" & Me.Prefix & "_id", id)
      Else
        ReDim params(0)
        params(0) = New SqlParameter("@" & Me.Prefix & "_id", id)
      End If

      Me.m_userId = userId

      If Me.GetSprocName Is Nothing OrElse Me.GetSprocName.Length = 0 Then
        'MessageBox.Show(Me.ClassName)
        Return
      End If
      Dim ds As DataSet = SqlHelper.ExecuteDataset(Me.RealConnectionString _
      , CommandType.StoredProcedure _
      , Me.GetSprocName _
      , params _
      )
      If ds.Tables(0).Rows.Count = 1 Then
        Construct(ds.Tables(0).Rows(0), "")
      End If
    End Sub
    Public Sub New(ByVal code As String, ByVal userId As Integer, ByVal ParamArray filters() As Filter)
      If code Is Nothing OrElse code.Length = 0 Then
        Return
      End If
      Dim params() As SqlParameter
      If Not filters Is Nothing AndAlso filters.Length > 0 Then
        ReDim params(filters.Length)
        For i As Integer = 0 To filters.Length - 1
          params(i) = New SqlParameter("@" & filters(i).Name, filters(i).Value)
        Next
        params(filters.Length) = New SqlParameter("@" & Me.Prefix & "_code", code)
      Else
        ReDim params(0)
        params(0) = New SqlParameter("@" & Me.Prefix & "_code", code)
      End If

      Me.m_userId = userId

      If Me.GetSprocName Is Nothing OrElse Me.GetSprocName.Length = 0 Then
        'MessageBox.Show(Me.ClassName)
        Return
      End If
      Dim ds As DataSet = SqlHelper.ExecuteDataset(Me.RealConnectionString _
      , CommandType.StoredProcedure _
      , Me.GetSprocName _
      , params _
      )
      If ds.Tables(0).Rows.Count = 1 Then
        Construct(ds.Tables(0).Rows(0), "")
      End If
    End Sub
    Public Sub New(ByVal code As String, ByVal userId As Integer)
      If code Is Nothing OrElse code.Length = 0 Then
        Return
      End If

      Me.m_userId = userId

      Dim ds As DataSet = SqlHelper.ExecuteDataset(Me.RealConnectionString _
      , CommandType.StoredProcedure _
      , Me.GetSprocName _
      , New SqlParameter("@" & Me.Prefix & "_code", code) _
      )
      If ds.Tables(0).Rows.Count = 1 Then
        Construct(ds.Tables(0).Rows(0), "")
      End If
    End Sub
    Public Sub New(ByVal ds As DataSet, ByVal aliasPrefix As String)
      Construct(ds, aliasPrefix)
    End Sub
    Public Sub New(ByVal dr As DataRow, ByVal aliasPrefix As String)
      Construct(dr, aliasPrefix)
    End Sub
		Public Shared AutogenStatusHash As New Hashtable
		Public Shared EntityIdHash As New Hashtable
		Protected Overridable Sub Construct()
			m_id = 0
			m_code = ""

			m_canceled = False
			m_cancelDate = Date.MinValue

			'ป้องกัน Cyclic
			'm_cancelPerson = New User
			'm_originator = New User
			'm_lastEditor = New User

			m_originated = False
			m_originDate = Date.MinValue
			m_edited = False
			m_lastEditDate = Date.MinValue

			If Me.EntityIdHash.Count > 20 Then
				Me.EntityIdHash = New Hashtable
			End If
			If Not (Me.ClassName Is Nothing) Then
				If Me.EntityIdHash.Contains(Me.ClassName) Then
					m_entityId = CInt(Me.EntityIdHash(Me.ClassName))
				Else
					m_entityId = Entity.GetIdFromClassName(Me.ClassName)
					Me.EntityIdHash(Me.ClassName) = m_entityId
				End If
			End If
			'Me.m_autogen = True
			If Me.AutogenStatusHash.Count > 20 Then
				Me.AutogenStatusHash = New Hashtable
			End If
			If Not (Me.ClassName Is Nothing) Then
				If Me.AutogenStatusHash.Contains(Me.EntityId) Then
					Me.AutoGen = CBool(Me.AutogenStatusHash(Me.EntityId))
				Else
					Me.AutoGen = Entity.GetAutoGenStatus(Me.EntityId)
					Me.AutogenStatusHash(Me.EntityId) = Me.AutoGen
				End If
			End If

		End Sub
		Protected Overridable Sub Construct(ByVal dr As System.Data.DataRow, ByVal aliasPrefix As String)
			Construct()
			With Me
				If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_code") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_code") Then
					.m_code = CStr(dr(aliasPrefix & Me.Prefix & "_code"))
				End If
				If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_id") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_id") Then
					.m_id = CInt(dr(aliasPrefix & Me.Prefix & "_id"))
				End If

				If Me.Originated Then
					Me.AutoGen = False
				End If

				'status properties.....
				If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_cancelDate") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_cancelDate") Then
					.m_cancelDate = CDate(dr(aliasPrefix & Me.Prefix & "_cancelDate"))
					.m_canceled = True
				Else
					.m_canceled = False
				End If


				If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_originDate") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_originDate") Then
					.m_originDate = CDate(dr(aliasPrefix & Me.Prefix & "_originDate"))
				End If


				If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_lastEditDate") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_lastEditDate") Then
					.m_lastEditDate = CDate(dr(aliasPrefix & Me.Prefix & "_lastEditDate"))
					.m_edited = True
				Else
					.m_edited = False
				End If

				'status
				If Not m_status Is Nothing Then
					If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "status.code_value") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "status.code_value") Then
						.m_status.Value = CInt(dr(aliasPrefix & Me.Prefix & "status.code_value"))
					Else
						If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_status") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_status") Then
							.m_status.Value = CInt(dr(aliasPrefix & Me.Prefix & "_status"))
						End If
					End If
				End If


				If TypeOf Me Is User Then
					'ป้องกัน Cyclic
					Return
				End If
				If dr.Table.Columns.Contains("cancelPerson.user_id") Then
					If Not dr.IsNull("cancelPerson.user_id") Then
						.m_cancelPerson = New User(dr, "cancelPerson.")
					End If
				Else
					If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_cancelPerson") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_cancelPerson") Then
						.m_cancelPerson = New User(CInt(dr(aliasPrefix & Me.Prefix & "_cancelPerson")))
					End If
				End If
				If dr.Table.Columns.Contains("originator.user_id") Then
					If Not dr.IsNull("originator.user_id") Then
						.m_originator = New User(dr, "originator.")
					End If
				Else
					If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_originator") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_originator") Then
						.m_originator = New User(CInt(dr(aliasPrefix & Me.Prefix & "_originator")))
					End If
				End If
				If dr.Table.Columns.Contains("lasteditor.user_id") Then
					If Not dr.IsNull("lasteditor.user_id") Then
						.m_lastEditor = New User(dr, "lasteditor.")
					End If
				Else
					If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_lasteditor") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_lasteditor") Then
						.m_lastEditor = New User(CInt(dr(aliasPrefix & Me.Prefix & "_lasteditor")))
					End If
				End If


			End With
		End Sub
		Protected Overridable Sub Construct(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
			If ds.Tables(0).Rows.Count <= 0 Then
				Construct()
				Return
			End If
			Dim dr As DataRow = ds.Tables(0).Rows(0)
			Construct(dr, aliasPrefix)
		End Sub
		Protected Sub LoadEntity(ByVal sql As String)
			Dim ds As DataSet = SqlHelper.ExecuteDataset(Me.RealConnectionString, CommandType.Text, sql)
			If ds.Tables(0).Rows.Count > 0 Then
				Construct(ds, "")
			End If
		End Sub
#End Region

#Region "Methods"
    Public Overridable Sub ClearReference()

    End Sub
    Public Overridable Sub SetSaveParameters(ByVal currentUserId As Integer)

    End Sub
    Public Sub SetOriginEditCancelStatus(ByVal dr As DataRow, ByVal theTime As Date, ByVal currentUserId As Integer)
      Dim originatorId As Object = DBNull.Value
      Dim origindate As Object = DBNull.Value
      Dim editorId As Object = DBNull.Value
      Dim editDate As Object = DBNull.Value
      Dim cancelPersonId As Object = DBNull.Value
      Dim cancelDate As Object = DBNull.Value
      If Me.Originated Then
        origindate = ValidDateOrDBNull(Me.OriginDate)
        originatorId = ValidIdOrDBNull(Me.Originator)
        editorId = currentUserId
        editDate = theTime
        If Me.Canceled Then
          cancelPersonId = currentUserId
          cancelDate = theTime
        End If
      Else
        origindate = theTime
        originatorId = currentUserId
        If Me.Canceled Then
          cancelPersonId = currentUserId
          cancelDate = theTime
        End If
        editorId = DBNull.Value
        editDate = DBNull.Value
      End If
      dr(Me.Prefix & "_originator") = originatorId
      dr(Me.Prefix & "_originDate") = origindate
      dr(Me.Prefix & "_lastEditor") = editorId
      dr(Me.Prefix & "_lastEditDate") = editDate
      dr(Me.Prefix & "_canceled") = IIf(Me.Canceled, Me.Canceled, DBNull.Value)
      dr(Me.Prefix & "_cancelDate") = cancelDate
      dr(Me.Prefix & "_cancelPerson") = cancelPersonId
    End Sub
    Public Sub SetOriginEditCancelStatus(ByVal paramarrayList As ArrayList, ByVal currentUserId As Integer, ByVal theTime As Date)
      Dim originatorId As Object = DBNull.Value
      Dim origindate As Object = DBNull.Value
      Dim editorId As Object = DBNull.Value
      Dim editDate As Object = DBNull.Value
      Dim cancelPersonId As Object = DBNull.Value
      Dim cancelDate As Object = DBNull.Value
      If Me.Originated Then
        origindate = ValidDateOrDBNull(Me.OriginDate)
        originatorId = ValidIdOrDBNull(Me.Originator)
        editorId = currentUserId
        editDate = theTime
        If Me.Canceled Then
          cancelPersonId = currentUserId
          cancelDate = theTime
        End If
      Else
        origindate = theTime
        originatorId = currentUserId
        If Me.Canceled Then
          cancelPersonId = currentUserId
          cancelDate = theTime
        End If
        editorId = DBNull.Value
        editDate = DBNull.Value
      End If

      paramarrayList.Add(New SqlParameter("@" & Me.Prefix & "_originator", originatorId))
      paramarrayList.Add(New SqlParameter("@" & Me.Prefix & "_originDate", origindate))
      paramarrayList.Add(New SqlParameter("@" & Me.Prefix & "_lastEditor", editorId))
      paramarrayList.Add(New SqlParameter("@" & Me.Prefix & "_lastEditDate", editDate))
      paramarrayList.Add(New SqlParameter("@" & Me.Prefix & "_canceled", IIf(Me.Canceled, Me.Canceled, DBNull.Value)))
      paramarrayList.Add(New SqlParameter("@" & Me.Prefix & "_cancelDate", cancelDate))
      paramarrayList.Add(New SqlParameter("@" & Me.Prefix & "_cancelPerson", cancelPersonId))
    End Sub
    Public Overridable Sub ExecuteSaveSproc(ByVal returnVal As SqlParameter, ByVal sqlparams As SqlParameter(), ByVal theTime As Date, ByVal theUser As User)
      ' Execute Store Procedure ...
      If Not Me.Originated Then
        SqlHelper.ExecuteNonQuery(Me.ConnectionString, CommandType.StoredProcedure, "Insert" & Me.TableName, sqlparams)
        If IsNumeric(returnVal.Value) AndAlso CInt(returnVal.Value) > 0 Then
          Me.Id = CInt(returnVal.Value)
          Me.OriginDate = theTime
          Me.Originator = theUser
          If Me.Canceled Then
            'สร้างแล้ว cancel ทันที --> เป็นไปได้
            Me.CancelPerson = theUser
            Me.CancelDate = theTime
          End If
        End If
      Else
        SqlHelper.ExecuteNonQuery(Me.ConnectionString, CommandType.StoredProcedure, "Update" & Me.TableName, sqlparams)
        If IsNumeric(returnVal.Value) AndAlso CInt(returnVal.Value) > 0 Then
          Me.LastEditDate = theTime
          Me.LastEditor = theUser
          Me.Edited = True
          If Me.Canceled Then
            'cancel!!
            Me.CancelPerson = theUser
            Me.CancelDate = theTime
          Else
            'ยกเลิกการ Canceled
            Me.CancelPerson = Nothing
            Me.CancelDate = Date.MinValue
          End If
        End If
      End If
    End Sub
    Public Overridable Sub ExecuteSaveSproc(ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByVal returnVal As SqlParameter, ByVal sqlparams As SqlParameter(), ByVal theTime As Date, ByVal theUser As User)
      ' Execute Store Procedure ...
      If Not Me.Originated Then
        SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "Insert" & Me.TableName, sqlparams)
        If IsNumeric(returnVal.Value) AndAlso CInt(returnVal.Value) > 0 Then
          Me.Id = CInt(returnVal.Value)
          Me.OriginDate = theTime
          Me.Originator = theUser
          If Me.Canceled Then
            'สร้างแล้ว cancel ทันที --> เป็นไปได้
            Me.CancelPerson = theUser
            Me.CancelDate = theTime
          End If
        End If
      Else
        SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "Update" & Me.TableName, sqlparams)
        If IsNumeric(returnVal.Value) AndAlso CInt(returnVal.Value) > 0 Then
          Me.LastEditDate = theTime
          Me.LastEditor = theUser
          Me.Edited = True
          If Me.Canceled Then
            'cancel!!
            Me.CancelPerson = theUser
            Me.CancelDate = theTime
          Else
            'ยกเลิกการ Canceled
            Me.CancelPerson = Nothing
            Me.CancelDate = Date.MinValue
          End If
        End If
      End If
    End Sub
    Public Sub PrepareImageParams(ByVal paramarrayList As ArrayList)
      If TypeOf Me Is ILocatable Then
        Dim locatable As ILocatable = CType(Me, ILocatable)
        If Not locatable.Map Is Nothing Then
          paramarrayList.Add(New SqlParameter("@" & Me.Prefix & "_map", Pojjaman.Graphix.Imaging.ConvertImageToByteArray(locatable.Map)))
        End If
      End If
      If TypeOf Me Is IHasImage Then
        Dim hasImage As IHasImage = CType(Me, IHasImage)
        If Not hasImage.Image Is Nothing Then
          paramarrayList.Add(New SqlParameter("@" & Me.Prefix & "_image", Pojjaman.Graphix.Imaging.ConvertImageToByteArray(hasImage.Image)))
        End If
      End If
    End Sub
    Public Shared Function ValidIdOrDBNull(ByVal entity As SimpleBusinessEntityBase) As Object
      If entity Is Nothing OrElse Not entity.Valid Then
        Return DBNull.Value
      End If
      Return entity.Id
    End Function
    Public Shared Function ValidDateOrDBNull(ByVal myDate As Date) As Object
      If myDate.Equals(Date.MinValue) Then
        Return DBNull.Value
      End If
      Return myDate
    End Function
    Protected Sub AssignValue(ByVal prop As Object, ByVal fieldName As String, ByVal dr As DataRow)
      Try
        If dr.Table.Columns.Contains(fieldName) Then
          prop = dr(fieldName)
        End If
      Catch ex As Exception

      End Try
    End Sub

    'A function to get code-name list for showing in combobox
    Public Function GetCodeNameList() As DataTable
      'If Code.Length <> 0 Then
      '    Dim dt As New DataTable
      '    dt.Columns.Add(New DataColumn("Id"))
      '    dt.Columns.Add(New DataColumn("Code"))
      '    dt.Columns.Add(New DataColumn("Name"))
      '    Return dt
      'End If
      Dim dt As New DataTable
      Dim ds As DataSet = SqlHelper.ExecuteDataset(Me.RealConnectionString, CommandType.StoredProcedure, Me.GetListSprocName, Nothing)
      dt = ds.Tables(0)
      Return dt
    End Function
    Public Overridable Function UpdateRef(ByVal entityRefed As ISimpleEntity, ByVal conn As SqlConnection, ByVal trans As SqlTransaction) As SaveErrorException
      SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "InsertUpdatereference" _
      , New SqlParameter("@entity_id", entityRefed.Id) _
      , New SqlParameter("@entity_type", entityRefed.EntityId) _
      , New SqlParameter("@refto_id", Me.Id) _
      , New SqlParameter("@refto_type", Me.EntityId) _
      , New SqlParameter("@refto_iscanceled", (Me.Canceled Or Me.Status.Value = 0)))
    End Function
    Public Overridable Function CancelRef(ByVal conn As SqlConnection, ByVal trans As SqlTransaction) As SaveErrorException
      SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "CancelRef" _
      , New SqlParameter("@refto_id", Me.Id) _
      , New SqlParameter("@refto_type", Me.EntityId))
    End Function
    Public Overridable Function DeleteRef(ByVal conn As SqlConnection, ByVal trans As SqlTransaction) As SaveErrorException
      SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "DeleteRef" _
      , New SqlParameter("@refto_id", Me.Id) _
      , New SqlParameter("@refto_type", Me.EntityId))
    End Function
    Public Overridable Function DeleteRef(ByVal entityRefed As ISimpleEntity, ByVal conn As SqlConnection, ByVal trans As SqlTransaction) As SaveErrorException
      SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "DeleteRef" _
      , New SqlParameter("@entity_id", entityRefed.Id) _
      , New SqlParameter("@entity_type", entityRefed.EntityId) _
      , New SqlParameter("@refto_id", Me.Id) _
      , New SqlParameter("@refto_type", Me.EntityId))
    End Function
    Public Overridable Function IsReferenced() As Boolean
      Try
        Dim ds As DataSet = SqlHelper.ExecuteDataset( _
                Me.ConnectionString _
                , CommandType.StoredProcedure _
                , "GetIsReferenced" _
                , New SqlParameter("@entity_id", Me.Id) _
                , New SqlParameter("@entity_type", Me.EntityId) _
                )
        If ds.Tables(0).Rows.Count > 0 Then
          If ds.Tables(0).Rows(0).IsNull(0) Then
            Return False
          End If
          Return CBool(ds.Tables(0).Rows(0)(0))
        End If
      Catch ex As Exception
      End Try
      Return False
    End Function
    Public Overridable Function IsCancelable() As Boolean
      Try
        Dim ds As DataSet = SqlHelper.ExecuteDataset( _
                Me.ConnectionString _
                , CommandType.StoredProcedure _
                , "GetIsCancelable" _
                , New SqlParameter("@entity_id", Me.Id) _
                , New SqlParameter("@entity_type", Me.EntityId) _
                )
        If ds.Tables(0).Rows.Count > 0 Then
          If ds.Tables(0).Rows(0).IsNull(0) Then
            Return False
          End If
          Return CBool(ds.Tables(0).Rows(0)(0))
        End If
      Catch ex As Exception
      End Try
      Return False
    End Function
    Public Function GetReferenceDocs() As DataTable
      Try
        Dim ds As DataSet = SqlHelper.ExecuteDataset( _
                Me.ConnectionString _
                , CommandType.StoredProcedure _
                , "GetReferenceDocs" _
                , New SqlParameter("@entity_id", Me.Id) _
                , New SqlParameter("@entity_type", Me.EntityId) _
                )
        If ds.Tables(0).Rows.Count > 0 Then
          Return ds.Tables(0)
        End If
      Catch ex As Exception
      End Try
    End Function
#End Region

#Region "Properties"
    Private m_AutoCodeFormat As AutoCodeFormat
    Public Property AutoCodeFormat() As AutoCodeFormat
      Get
        Return m_AutoCodeFormat
      End Get
      Set(ByVal Value As AutoCodeFormat)
        m_AutoCodeFormat = Value
        OnAutoCodeFormatChanged()
      End Set
    End Property
    Public Overridable Sub OnAutoCodeFormatChanged()

    End Sub
    Private m_extender As New ArrayList
    Public ReadOnly Property Extenders() As ArrayList
      Get
        If m_extender Is Nothing Then
          m_extender = New ArrayList
        End If
        Return m_extender
      End Get
    End Property
    Public Property NoSaveMessage() As Boolean
      Get
        Return m_noSaveMessage
      End Get
      Set(ByVal Value As Boolean)
        m_noSaveMessage = Value
      End Set
    End Property
    Public Property IsInitialized() As Boolean
      Get
        Return m_isinitialized
      End Get
      Set(ByVal Value As Boolean)
        m_isinitialized = Value
      End Set
    End Property

    Public Property Id() As Integer Implements IIdentifiable.Id
      Get
        Return m_id
      End Get
      Set(ByVal Value As Integer)
        m_id = Value
      End Set
    End Property
    Public Overridable Property Code() As String Implements IIdentifiable.Code
      Get
        Return m_code
      End Get
      Set(ByVal Value As String)
        m_code = Value
        OnTabPageTextChanged(Me, New EventArgs)
      End Set
    End Property
    Public ReadOnly Property StringParserService() As StringParserService
      Get
        If m_stringParserService Is Nothing Then
          m_stringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
        End If
        Return m_stringParserService
      End Get
    End Property
    Public ReadOnly Property Valid() As Boolean
      Get
        Return Me.Id > 0
      End Get
    End Property
    Public Property HtChangedProperties() As Hashtable
      Get
        Return m_htChangedProperties
      End Get
      Set(ByVal Value As Hashtable)
        m_htChangedProperties = Value
      End Set
    End Property
    Public Overridable ReadOnly Property UseSiteConnString() As Boolean
      Get
        Return False
      End Get
    End Property
#End Region

#Region "Shared"
    Public Shared Function GetEntityRow(ByVal id As Integer, ByVal theType As Integer) As DataRow
      Try
        Dim ds As DataSet = SqlHelper.ExecuteDataset( _
                ConnectionString _
                , CommandType.StoredProcedure _
                , "GetEntityQueryText" _
                , New SqlParameter("@entity_id", id) _
                , New SqlParameter("@entity_type", theType) _
                )
        If ds.Tables(0).Rows.Count > 0 Then
          If Not ds.Tables(0).Rows(0).IsNull(0) Then
            Dim query As String = CStr(ds.Tables(0).Rows(0)(0))
            Try
              Dim ds2 As DataSet = SqlHelper.ExecuteDataset( _
                      ConnectionString _
                      , CommandType.Text _
                      , query _
                      )
              If ds2.Tables(0).Rows.Count > 0 Then
                Return ds2.Tables(0).Rows(0)
              End If
            Catch ex As Exception
            End Try
          End If
        End If
      Catch ex As Exception
      End Try
    End Function
    Public Shared ReadOnly Property SiteConnectionString() As String
      Get
        Return RecentCompanies.CurrentCompany.SiteConnectionString
      End Get
    End Property
    Public Shared ReadOnly Property ConnectionString() As String
      Get
        Return RecentCompanies.CurrentCompany.ConnectionString
      End Get
    End Property
    Public ReadOnly Property RealConnectionString() As String
      Get
        If Me.UseSiteConnString Then
          Return Me.SiteConnectionString
        Else
          Return Me.ConnectionString
        End If
      End Get
    End Property
    Protected Shared Function CreateEntity(ByVal fullClassName As String, ByVal args() As Object) As SimpleBusinessEntityBase
      Dim newInstance As Object
      'newInstance = [Assembly].GetExecutingAssembly.CreateInstance(fullClassName, True, BindingFlags.CreateInstance, Nothing, args, Nothing, Nothing)
      'If (newInstance Is Nothing) Then
      '    Debug.WriteLine("Type not found: " & fullClassName)
      '    Return Nothing
      'End If
      'Return CType(newInstance, SimpleBusinessEntityBase)
      Dim at As IAddInTree = AddInTreeSingleton.AddInTree
      Dim ac As AddInCollection = at.AddIns
      For i As Integer = 0 To ac.Count - 1
        Dim ad As AddIn = ac(i)
        newInstance = ad.CreateObject(fullClassName, args)
        If TypeOf newInstance Is SimpleBusinessEntityBase Then
          Return CType(newInstance, SimpleBusinessEntityBase)
        End If
      Next
      If newInstance Is Nothing OrElse Not TypeOf newInstance Is SimpleBusinessEntityBase Then
        Debug.WriteLine("Type not found: " & fullClassName)
        Return Nothing
      End If
    End Function
    Public Shared Function GetEntity(ByVal fullClassName As String, ByVal id As Integer) As SimpleBusinessEntityBase
      Return SimpleBusinessEntityBase.CreateEntity(fullClassName, New Object() {id})
    End Function
    Public Shared Function GetEntity(ByVal fullClassName As String, ByVal code As String) As SimpleBusinessEntityBase
      Return SimpleBusinessEntityBase.CreateEntity(fullClassName, New Object() {code})
    End Function
    Public Shared Function GetEntity(ByVal fullClassName As String) As SimpleBusinessEntityBase
      Return SimpleBusinessEntityBase.CreateEntity(fullClassName, Nothing)
    End Function
    Public Shared Function GetEntity(ByVal fullClassName As String, ByVal row As DataRow) As SimpleBusinessEntityBase
      Return SimpleBusinessEntityBase.CreateEntity(fullClassName, New Object() {row})
    End Function
#End Region

#Region "IBaseEntityStatusCapable"
    Public Property Canceled() As Boolean Implements IBaseEntityStatusCapable.Canceled
      Get
        Return m_canceled
      End Get
      Set(ByVal Value As Boolean)
        m_canceled = Value
      End Set
    End Property
    Public Property CancelDate() As Date Implements IBaseEntityStatusCapable.CancelDate
      Get
        Return m_cancelDate
      End Get
      Set(ByVal Value As Date)
        m_cancelDate = Value
      End Set
    End Property
    Public Property CancelPerson() As User Implements IBaseEntityStatusCapable.CancelPerson
      Get
        Return m_cancelPerson
      End Get
      Set(ByVal Value As User)
        m_cancelPerson = Value
      End Set
    End Property
    Public ReadOnly Property Originated() As Boolean Implements IBaseEntityStatusCapable.Originated
      Get
        Return Me.Valid
      End Get
    End Property
    Public Property OriginDate() As Date Implements IBaseEntityStatusCapable.OriginDate
      Get
        Return m_originDate
      End Get
      Set(ByVal Value As Date)
        m_originDate = Value
      End Set
    End Property
    Public Property Originator() As User Implements IBaseEntityStatusCapable.Originator
      Get
        Return m_originator
      End Get
      Set(ByVal Value As User)
        m_originator = Value
      End Set
    End Property
    Public Property Edited() As Boolean Implements IBaseEntityStatusCapable.Edited
      Get
        Return m_edited
      End Get
      Set(ByVal Value As Boolean)
        m_edited = Value
      End Set
    End Property
    Public Property LastEditDate() As Date Implements IBaseEntityStatusCapable.LastEditDate
      Get
        Return m_lastEditDate
      End Get
      Set(ByVal Value As Date)
        m_lastEditDate = Value
      End Set
    End Property
    Public Property LastEditor() As User Implements IBaseEntityStatusCapable.LastEditor
      Get
        Return m_lastEditor
      End Get
      Set(ByVal Value As User)
        m_lastEditor = Value
      End Set
    End Property
#End Region

#Region "IHasStatus"
    Public Overridable Property Status() As CodeDescription Implements IHasStatus.Status
      Get
        If m_status Is Nothing Then
          m_status = New StockStatus(-1)
        End If
        Return m_status
      End Get
      Set(ByVal Value As CodeDescription)
        m_status = Value
      End Set
    End Property
#End Region

#Region "IDatabaseEntity"
    Public Overridable ReadOnly Property GetListSprocName() As String Implements IDatabaseEntity.GetListSprocName
      Get
        Return "Get" & Me.ClassName & "List"
      End Get
    End Property
    Public Overridable ReadOnly Property GetSprocName() As String Implements IDatabaseEntity.GetSprocName
      Get
        Return "Get" & Me.ClassName
      End Get
    End Property
    Public Overridable ReadOnly Property SaveSprocName() As String Implements IDatabaseEntity.SaveSprocName
      Get

      End Get
    End Property
    Public Overridable ReadOnly Property TableName() As String Implements IDatabaseEntity.TableName
      Get
        'Default = class name
        Return Me.ClassName
      End Get
    End Property
    Public Overridable ReadOnly Property Prefix() As String Implements IDatabaseEntity.Prefix
      Get

      End Get
    End Property
    Public Overridable Function Save() As SaveErrorException Implements IDatabaseEntity.Save
      Return New SaveErrorException("Not implemented (save)" & Me.ClassName)
    End Function
    Public Overridable Function Save(ByVal currentUserId As Integer) As SaveErrorException Implements IDatabaseEntity.Save
      Return New SaveErrorException("Not implemented (save currentUserId)" & Me.ClassName)
    End Function
    Public Overridable Function Save(ByVal currentUserId As Integer, ByVal conn As System.Data.SqlClient.SqlConnection, ByVal trans As System.Data.SqlClient.SqlTransaction) As SaveErrorException Implements IDatabaseEntity.Save
      Return New SaveErrorException("Not implemented (save currentUserId,conn,trans)" & Me.ClassName)
    End Function
    Public Overridable Function Delete() As SaveErrorException Implements IDatabaseEntity.Delete
      Return New SaveErrorException("Not implemented (Delete)" & Me.ClassName)
    End Function
    Public Overridable Overloads Function DeleteWithLog(ByVal currentUserId As Integer, ByVal theTime As Date) As SaveErrorException Implements IDeletableWithLog.DeleteWithLog
      Throw New NotImplementedException
    End Function
    Public Overridable ReadOnly Property CanDelete() As Boolean Implements IDeletable.CanDelete
      Get
        Return False
      End Get
    End Property
    Public Function SaveAutoCode(ByVal conn As SqlConnection, ByVal trans As SqlTransaction) As SaveErrorException
      Try

        Dim da As New SqlDataAdapter("Select * from entityautocode where entity_id='" & Me.Id & "' and entity_type = '" & Me.EntityId & "'", conn)

        Dim ds As New DataSet

        Dim cmdBuilder As New SqlCommandBuilder(da)
        da.SelectCommand.Transaction = trans
        cmdBuilder.GetDeleteCommand.Transaction = trans
        cmdBuilder.GetInsertCommand.Transaction = trans
        cmdBuilder.GetUpdateCommand.Transaction = trans
        cmdBuilder = Nothing
        da.FillSchema(ds, SchemaType.Mapped, "entityautocode")
        da.Fill(ds, "entityautocode")

        Dim dt As DataTable = ds.Tables("entityautocode")

        Dim dr As DataRow
        If dt.Rows.Count > 0 Then
          dr = dt.Rows(0)
        Else
          dr = dt.NewRow
          dt.Rows.Add(dr)
          dr("entity_id") = Me.Id
          dr("entity_type") = Me.EntityId
        End If

        dr("entity_autocode") = Me.AutoCodeFormat.Id

        da.Update(dt.Select("", "", DataViewRowState.Deleted))

        da.Update(dt.Select("", "", DataViewRowState.ModifiedCurrent))

        da.Update(dt.Select("", "", DataViewRowState.Added))
        Return New SaveErrorException("1")
      Catch ex As Exception
        Return New SaveErrorException(ex.ToString)
      End Try
    End Function
#End Region

#Region "IObjectReflectable"

    Public Overridable ReadOnly Property EntityId() As Integer Implements IObjectReflectable.EntityId
      Get
        Return m_entityId  'Entity.GetIdFromClassName(Me.ClassName)
      End Get
    End Property
    Public Overridable ReadOnly Property ClassName() As String Implements IObjectReflectable.ClassName
      Get

      End Get
    End Property
    Public Overridable ReadOnly Property FullClassName() As String Implements IObjectReflectable.FullClassName
      Get
        Return Me.Namespace & "." & Me.ClassName
      End Get
    End Property
    Public Overridable ReadOnly Property [Namespace]() As String Implements IObjectReflectable.Namespace
      Get
        Return "Longkong.Pojjaman.BusinessLogic"
      End Get
    End Property
#End Region

#Region "IPageInfoCapable"
    Public Sub OnTabPageTextChanged(ByVal sender As Object, ByVal e As EventArgs)
      RaiseEvent TabPageTextChanged(sender, e)
    End Sub
    Public Event TabPageTextChanged As EventHandler Implements IPageInfoCapable.TabPageTextChanged
    Public Overridable ReadOnly Property TabPageText() As String Implements IPageInfoCapable.TabPageText
      Get
        Dim tpt As String = Me.StringParserService.Parse(Me.DetailPanelTitle) & " (" & Me.Code & ")"
        Dim blankSuffix As String = "()"
        If tpt.EndsWith(blankSuffix) Then
          tpt = tpt.Remove(tpt.Length - blankSuffix.Length, blankSuffix.Length)
        End If
        Return tpt
      End Get
    End Property
    Public Overridable ReadOnly Property DetailPanelIcon() As String Implements IPageInfoCapable.DetailPanelIcon
      Get
        Return "Icons.16x16." & Me.ClassName
      End Get
    End Property
    Public Overridable ReadOnly Property DetailPanelTitle() As String Implements IPageInfoCapable.DetailPanelTitle
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic." & Me.ClassName & ".DetailLabel}"
      End Get
    End Property
    Public Overridable ReadOnly Property ListPanelIcon() As String Implements IPageInfoCapable.ListPanelIcon
      Get
        Return "Icons.16x16." & Me.ClassName
      End Get
    End Property
    Public Overridable ReadOnly Property ListPanelTitle() As String Implements IPageInfoCapable.ListPanelTitle
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic." & Me.ClassName & ".ListLabel}"
      End Get
    End Property
#End Region

#Region "IListable"
    Public Function GetDataTable() As Gui.Components.TreeTable Implements IListable.GeDatatable
      Dim myDatatable As New TreeTable(Me.ClassName)
      For Each col As Column In Me.Columns
        myDatatable.Columns.Add(New DataColumn(col.Name, GetType(String)))
      Next
      Return myDatatable
    End Function
    Public Overridable ReadOnly Property Columns() As ColumnCollection Implements IListable.Columns
      Get
        If m_columns Is Nothing OrElse m_columns.Count <= 0 Then
          m_columns = New ColumnCollection(Me.ClassName, Me.m_userId)
        End If
        Return m_columns
      End Get
    End Property
    Public Overridable Function GetListDatatable(ByVal query As String, ByVal order As String) As System.Data.DataTable Implements IListable.GetListDatatable
      query = BuildSearchCriteria(query)
      Dim dt As DataTable = GetDataset(query, order).Tables(0)
      dt.TableName = Me.ClassName
      Return dt
    End Function
    Public Overridable Function GetListDatatable(ByVal order As String, ByVal ParamArray filters() As Filter) As System.Data.DataTable Implements IListable.GetListDatatable
      Return GetListDataSet(order, filters).Tables(0)
    End Function
    Public Overridable Function GetListDataSet(ByVal order As String, ByVal ParamArray filters() As Filter) As System.Data.DataSet Implements IListable.GetListDataSet
      Dim params() As SqlParameter
      If Not filters Is Nothing AndAlso filters.Length > 0 Then
        ReDim params(filters.Length - 1)
        For i As Integer = 0 To filters.Length - 1
          params(i) = New SqlParameter("@" & filters(i).Name, filters(i).Value)
        Next
      End If
      Dim ds As DataSet = SqlHelper.ExecuteDataset(Me.RealConnectionString, CommandType.StoredProcedure, Me.GetListSprocName, params)
      ds.Tables(0).TableName = Me.ClassName
      If Filter.BlankFilterArray(filters) Then
        If ds.Tables.Count > 1 Then
          ds.Tables(1).Rows.Clear()
        End If
      End If
      Return ds
    End Function
    Public Overridable Function GetDataset(ByVal query As String, ByVal order As String) As System.Data.DataSet
      Dim sql As String = BuildSql()
      If query.Length = 0 Then
        Return GetDataset(order)
      End If
      sql &= " where " & query
      If order.Length = 0 Then
        Return CreateDataset(sql)
      End If
      sql &= " order by " & order
      Return CreateDataset(sql)
    End Function
    Protected Overridable Function GetDataset(ByVal order As String) As System.Data.DataSet
      Dim sql As String = BuildSql()
      If order.Length = 0 Then
        Return CreateDataset(sql)
      End If
      sql &= " order by " & order
      Return CreateDataset(sql)
    End Function
    Protected Overridable Function GetDataset() As System.Data.DataSet
      Dim sql As String = BuildSql()
      Return CreateDataset(sql)
    End Function
    Protected Function CreateDataset(ByVal sql As String) As Data.DataSet
      Return SqlHelper.ExecuteDataset(Me.RealConnectionString, CommandType.Text, sql)
    End Function
    Protected Function BuildSql() As String
      Dim sql As String = ""
      For Each col As Column In Me.Columns
        sql &= col.Name & ","
      Next
      If sql = "" Then
        Return "Select * FROM [" & Me.TableName & "]"
      Else
        sql = Left(sql, sql.LastIndexOf(","))
        Return "Select " & sql & " FROM [" & Me.TableName & "]"
      End If
    End Function
    Protected Overridable Function BuildSearchCriteria(ByVal txt As String) As String
      Dim masterCriteria As String = ""
      If txt.Length = 0 Then
        Return masterCriteria
      End If
      txt = SqlHelper.CleanSQL(txt)
      Dim criteria As String = "("
      For Each col As Column In Me.Columns
        If Not col.Name.EndsWith("_id") Then
          criteria &= col.Name & " like '%" & txt & "%' or "
        End If
      Next
      If criteria.Length = 1 Then
        Return masterCriteria
      Else
        criteria = criteria.TrimEnd(" or ".ToCharArray)
        If masterCriteria.Length <> 0 Then
          criteria = criteria & ")" & " and " & masterCriteria
        Else
          criteria = criteria & ")"
        End If
      End If
      Return criteria
    End Function
#End Region

#Region "IPropertyChangeable"

    Public Overridable ReadOnly Property Initialized() As Boolean Implements IPropertyChangeable.Initialized
      Get
        Return True
      End Get
    End Property
    Public Event PropertyChanged(ByVal sender As Object, ByVal e As PropertyChangedEventArgs) Implements IPropertyChangeable.PropertyChanged
    Public Sub OnPropertyChanged(ByVal sender As Object, ByVal e As PropertyChangedEventArgs)
      'm_htChangedProperties(e.Name) = e.Value
      RaiseEvent PropertyChanged(sender, e)
    End Sub
#End Region

#Region "ICodeGeneratable"
    Public Overridable Function GetLastCode(ByVal prefixPattern As String) As String Implements ICodeGeneratable.GetLastCode
      Dim sqlConString As String = RecentCompanies.CurrentCompany.ConnectionString
      Dim conn As New SqlConnection(sqlConString)
      Dim sql As String = "select top 1 " & Me.Prefix & "_code from [" & Me.TableName & "] where " & Me.Prefix & "_code like '" & prefixPattern & "%' " & " order by " & Me.Prefix & "_id desc"

      conn.Open()

      Dim cmd As SqlCommand = conn.CreateCommand
      cmd.CommandText = sql

      Dim obj As Object = cmd.ExecuteScalar
      If Not IsDBNull(obj) AndAlso Not obj Is Nothing Then
        Return obj.ToString
      End If
      Return ""
    End Function
    Public Overridable Function GetNextCode() As String Implements ICodeGeneratable.GetNextCode
      Dim autoCodeFormat As String
      If Me.AutoCodeFormat.Format.Length > 0 Then
        autoCodeFormat = Me.AutoCodeFormat.Format
      Else
        autoCodeFormat = Entity.GetAutoCodeFormat(Me.EntityId)
      End If
      Dim pattern As String = CodeGenerator.GetPattern(AutoCodeFormat, Me)

      pattern = CodeGenerator.GetPattern(pattern)

      Dim lastCode As String = Me.GetLastCode(pattern)
      Dim newCode As String = _
      CodeGenerator.Generate(AutoCodeFormat, lastCode, Me)
      While DuplicateCode(newCode)
        newCode = CodeGenerator.Generate(AutoCodeFormat, newCode, Me)
      End While
      Return newCode
    End Function
    Public Property AutoGen() As Boolean Implements ICodeGeneratable.AutoGen
      Get
        Return m_autogen
      End Get
      Set(ByVal Value As Boolean)
        m_autogen = Value
      End Set
    End Property
    Public Overridable Function DuplicateCode(ByVal newCode As String) As Boolean
      Dim sqlConString As String = RecentCompanies.CurrentCompany.ConnectionString
      Dim conn As New SqlConnection(sqlConString)
      Dim sql As String = "select count(*) from [" & Me.TableName & "] where " & Me.Prefix & "_code='" & newCode & "' and " & Me.Prefix & "_id <> " & Me.Id

      conn.Open()

      Dim cmd As SqlCommand = conn.CreateCommand
      cmd.CommandText = sql
      Dim recordCount As Object = cmd.ExecuteScalar
      conn.Close()
      If Not IsDBNull(recordCount) AndAlso CInt(recordCount) > 0 Then
        Return True
      End If
      Return False
    End Function
#End Region

#Region "IHasCustomNote"
    Public Function GetCustomNoteCollection() As CustomNoteCollection Implements IHasCustomNote.GetCustomNoteCollection
      Return New CustomNoteCollection(Me)
    End Function
#End Region

#Region "IDirtyAble"
    Private m_isDirty As Boolean
    Public Property IsDirty() As Boolean Implements IDirtyAble.IsDirty
      Get
        Return m_isDirty
      End Get
      Set(ByVal Value As Boolean)
        m_isDirty = Value
      End Set
    End Property
#End Region

    Public Overridable ReadOnly Property CodonName() As String Implements ISimpleEntity.CodonName
      Get
        If TypeOf Me Is TreeBaseEntity Then
          Return "TreeBaseEntity"
        End If
        Return Me.ClassName
      End Get
    End Property

    Public Overrides Function ToString() As String
      If Not Me.Code Is Nothing Then
        Return Me.Code
      End If
      Return MyBase.ToString
    End Function

    Public Sub OnGlChanged()
      RaiseEvent GlChanged(Me, Nothing)
    End Sub

#Region "IGlChangable"
    Public Event GlChanged(ByVal sender As Object, ByVal e As System.EventArgs) Implements IGlChangable.GlChanged
#End Region

  End Class
End Namespace
