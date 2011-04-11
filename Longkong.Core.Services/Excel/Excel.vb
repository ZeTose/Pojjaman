Imports System.Text
Imports System.Data
Imports System.Data.OleDb
Imports System.ComponentModel
Imports Longkong.Pojjaman.TextHelper

Namespace Longkong.Core.Services.Excel
  Public Class ExcelBase
    Inherits Component

#Region "Constructors"
    Public Sub New()
      UseFinalizer = False
    End Sub
    Public Sub New(ByVal workBook As String)
      Me.New()
      Me.WorkBook = workBook
    End Sub
#End Region

#Region "Workbook/range settings"
    Private m_workBook As String
    <DefaultValue(GetType(String), "")> _
    Public Property WorkBook() As String
      Get
        Return m_workBook
      End Get
      Set(ByVal Value As String)
        CloseConnection()
        m_workBook = Value
        m_determinedRange = ""
      End Set
    End Property

    Private m_range As String
    <DefaultValue(GetType(String), "")> _
    Public Property Range() As String
      Get
        Return m_range
      End Get
      Set(ByVal Value As String)
        m_range = Value
        m_determinedRange = ""
      End Set
    End Property

    Private m_workSheetIndex As Integer = 0
    <DefaultValue(GetType(Integer), "0")> _
    Public Property WorkSheetIndex() As Integer
      Get
        Return m_workSheetIndex
      End Get
      Set(ByVal Value As Integer)
        m_workSheetIndex = Value
        m_determinedRange = ""
      End Set
    End Property

#Region "Range Formating"
    Private m_determinedRange As String
    Public Function GetRange() As String
      If m_determinedRange Is Nothing OrElse m_determinedRange.Length = 0 Then
        Dim range As String = Me.Range
        If range Is Nothing OrElse range.Length = 0 Then
          range = DetermineRange()
        End If
        If range.IndexOf(":") = -1 AndAlso Not range.EndsWith("$") Then
          range &= "$"
        End If
        m_determinedRange = "[" + range + "]"
      End If
      Return m_determinedRange
    End Function
    Function DetermineRange() As String
      Dim sheet As String = GetSheetName(m_workSheetIndex)
      If Not m_autodeterminerange Then Return sheet
      Return New RangeFinder(Me, sheet).ToString()
    End Function

#Region "RangeFinder"
    Class RangeFinder
      Private da As OleDbDataAdapter
      Private dtSchema As DataTable
      Private rng As New ExcelDataRange
      Private eb As Import
      Private cols As Integer
      Private min As Integer

      Public Sub New(ByVal owner As ExcelBase, ByVal sheet As String)
        Me.eb = New Import(owner.WorkBook)
        eb.Range = sheet
        eb.UseHeaders = False
        eb.InterMixedAsText = True
        Try
          eb.OpenConnection()
          da = New OleDbDataAdapter( _
              "select * from [" & sheet & "]", eb.Connection)
          dtSchema = New DataTable
          da.FillSchema(dtSchema, SchemaType.Source)
          cols = dtSchema.Columns.Count
          Dim rows As Integer = CInt(ExecuteScalar("select count(*) from [" & sheet & "]"))
          rng.From.Column = 1
          rng.From.Row = rng.From.Column
          rng.To.Row = rows
          rng.To.Column = cols

          min = CInt(cols * minfilled)

          DecreaseRange()

        Finally
          indexReader.Close()
          eb.CloseConnection()
        End Try
      End Sub
      Function ExecuteScalar(ByVal sql As String) As Object
        Return New OleDbCommand(sql, da.SelectCommand.Connection).ExecuteScalar()
      End Function

      Private indexquery As String
      Function GetIndexQuery() As String
        If indexquery Is Nothing OrElse indexquery.Length = 0 Then
          Dim sql As New StringBuilder("select 0")
          Dim i As Integer = 0
          For Each dr As DataRow In dtSchema.Rows
            Dim colName As String = "[" & dr("column_name").ToString() & "]"
            sql.Append("+iif(").Append(colName).Append(" is null,0,1)")
          Next
          sql.Append(" as ind from ")
          indexquery = sql.ToString()
        End If
        Return indexquery
      End Function

      Private indexTable As New DataTable
      Private indexReader As OleDbDataReader
      Function GetIndex() As Integer
        If Not Forward Then
          indexReader.Close()
          indexReader = Nothing
          da.SelectCommand.CommandText = String.Format(" select * from {0}:{0}" _
          , rng.To.Row)
        End If
        If indexReader Is Nothing Then
          indexReader = da.SelectCommand.ExecuteReader()
        End If
        Dim cnt As Integer = 0
        If Not indexReader.Read Then
          Return -1
        End If
        For i As Integer = 0 To indexReader.FieldCount - 1
          If indexReader.IsDBNull(i) Then
            cnt += 1
          End If
        Next
        Return cnt
        da.TableMappings.Clear()

        da = New OleDbDataAdapter(da.SelectCommand.CommandText, eb.conn)
        indexTable = New DataTable
        da.Fill(indexTable)
        Return indexTable.Columns.Count
      End Function

      Const minfilled As Double = 0.75
      Const CheckRows As Integer = 3

      Sub DecreaseRange()
        While True
          If GetIndex() >= min Then
            Dim i As Integer = 0
            For i = 0 To CheckRows - 1
              AlterRange(1)
              If GetIndex() < min Then
                Exit For
              End If
            Next
            If i = CheckRows Then
              AlterRange(-i)
              If Forward Then
                Forward = False
              Else
                Exit While
              End If
            End If
          End If
          If rng.From.Row > rng.To.Row Then
            Throw New Exception("Could not determine data range")
          End If
          AlterRange(1)
        End While
      End Sub

      Private Forward As Boolean = True
      Sub AlterRange(ByVal i As Integer)
        If Forward Then
          rng.From.Row += i
        Else
          rng.From.Row -= i
        End If
      End Sub

      Public Overrides Function ToString() As String
        Return rng.ToString
      End Function

      Structure ExcelRange
        Public Row, Column As Integer
        Public Sub New(ByVal col As Integer, ByVal row As Integer)
          Me.Column = col
          Me.Row = row
        End Sub
        Public Overrides Function ToString() As String
          Dim res As String = Row.ToString
          Dim col As Integer = Column
          res = StringHelper.GetExcelColumnString(col) & res
          Return res
        End Function
      End Structure
      Structure ExcelDataRange
        Public From, [To] As ExcelRange
        Public Overrides Function ToString() As String
          Return GetRange(From, [To])
        End Function
        Shared Function GetRange(ByVal from As ExcelRange, ByVal [to] As ExcelRange) As String
          Return from.ToString() & ":" & [to].ToString()
        End Function
        Public Function TopRow() As String
          Return GetRange(From, New ExcelRange([To].Column, From.Row))
        End Function
        Public Function BottomRow() As String
          Return GetRange(New ExcelRange(From.Column, [To].Row), [To])
        End Function
      End Structure
    End Class
#End Region
#End Region

    Public ReadOnly Property WorkBookExists() As Boolean
      Get
        Return System.IO.File.Exists(WorkBook)
      End Get
    End Property

    Protected Sub CheckWorkbook()
      If Not WorkBookExists Then
        Throw New System.IO.FileNotFoundException("Workbook not found", WorkBook)
      End If
    End Sub
#End Region

#Region "Connection"
    Public Function CreateConnection() As OleDbConnection
      CheckWorkbook()
      Dim yesNo As String = ""
      If m_useHeaders Then
        yesNo = "Yes"
      Else
        yesNo = "No"
      End If
      Dim imexText As String = ""
      If imex Then
        imexText = "1"
      Else
        imexText = "0"
      End If
      Dim connString As String = String.Format("Provider=Microsoft.Jet.OLEDB.4.0;" & _
       "Data Source={0};Extended Properties='Excel 8.0;HDR={1};Imex={2}'", _
       WorkBook, yesNo, _
       imexText)
      Return New OleDbConnection( _
       connString _
       )
    End Function
    Private m_useHeaders As Boolean = True
    <DefaultValue(GetType(Boolean), "True")> _
    Public Property UseHeaders() As Boolean
      Get
        Return m_useHeaders
      End Get
      Set(ByVal Value As Boolean)
        If m_useHeaders <> Value Then
          CloseConnection()
          m_useHeaders = Value
        End If
      End Set
    End Property
    Private imex As Boolean
    Public Property InterMixedAsText() As Boolean
      Get
        Return imex
      End Get
      Set(ByVal Value As Boolean)
        If imex <> Value Then
          CloseConnection()
          imex = Value
        End If
      End Set
    End Property
    Private m_autodeterminerange As Boolean
    <DefaultValue(GetType(Boolean), "True")> _
    Public Property AutoDetermineRange() As Boolean
      Get
        Return m_autodeterminerange
      End Get
      Set(ByVal Value As Boolean)
        If m_autodeterminerange <> Value Then
          m_autodeterminerange = Value
          m_determinedRange = ""
        End If
      End Set
    End Property

    Private conn As OleDbConnection
    Public ReadOnly Property Connection() As OleDbConnection
      Get
        If conn Is Nothing Then
          conn = CreateConnection()
          UseFinalizer = True
        End If
        Return conn
      End Get
    End Property

    Public Sub CloseConnection()
      If Not conn Is Nothing AndAlso ConnectionIsOpen Then
        conn.Dispose()
        conn = Nothing
        UseFinalizer = False
      End If
    End Sub

    Protected Sub CloseConnection(ByVal OnlyIfNoneOpen As Boolean)
      If OnlyIfNoneOpen Then
        If opencount - 1 > 0 Or wasopenbeforerememberstate Then
          Return
        End If
      End If
      CloseConnection()
    End Sub
    Public Sub OpenConnection()
      OpenConnection(False)
    End Sub
    Private opencount As Integer
    Private wasopenbeforerememberstate As Boolean
    Protected Sub OpenConnection(ByVal RememberState As Boolean)
      If RememberState And opencount + 1 = 0 Then
        wasopenbeforerememberstate = ConnectionIsOpen
      End If
      If Not ConnectionIsOpen Then
        Connection.Open()
      End If
    End Sub
    Public ReadOnly Property ConnectionIsOpen() As Boolean
      Get
        Return Not conn Is Nothing AndAlso conn.State <> ConnectionState.Closed
      End Get
    End Property
#End Region
#Region "IDisposable"
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
      CloseConnection()
    End Sub
    Private m_useFinalizer As Boolean
    Property UseFinalizer() As Boolean
      Get
        Return m_useFinalizer
      End Get
      Set(ByVal Value As Boolean)
        If m_useFinalizer = Value Then
          Return
        End If
        If Value Then
          GC.ReRegisterForFinalize(Me)
        Else
          GC.SuppressFinalize(Me)
        End If
      End Set
    End Property
#End Region

#Region "Helper"
    Public Function GetSheetNames() As String()
      OpenConnection(True)
      Try
        Dim dt As DataTable = Connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, Nothing)
        If dt Is Nothing OrElse dt.Rows.Count = 0 Then
          Throw New Exception("Could not get sheet names")
        End If

        Dim res(dt.Rows.Count - 1) As String
        For i As Integer = 0 To res.Length - 1
          Dim name As String = dt.Rows(i)("TABLE_NAME").ToString
          If name.StartsWith("'") Then
            If (System.Text.RegularExpressions.Regex.IsMatch(name, "^'\d\w+\$'$")) Then
              name = name.Substring(1, name.Length - 2)
            End If
          End If
          res(i) = name
        Next
        Return res
      Finally
        CloseConnection(True)
      End Try
    End Function
    Public Function GetFirstSheet() As String
      Return GetSheetName(0)
    End Function
    Public Function GetSheetName(ByVal index As Integer) As String
      Dim sheets() As String = GetSheetNames()
      If index < 0 OrElse index >= sheets.Length Then
        Throw New IndexOutOfRangeException("No worksheet exists at the specified index")
      End If
      Return sheets(index)
    End Function
#End Region


  End Class
  Public Class Import
    Inherits ExcelBase

#Region "Static query procedures"
    Public Shared Function Query(ByVal file As String) As DataTable
      Return Query(file, Nothing)
    End Function
    Public Shared Function Query(ByVal file As String, ByVal range As String) As DataTable
      Return New Import(file, range).Query()
    End Function
    Public Shared Function [Select](ByVal file As String, ByVal sql As String) As DataTable
      Dim i As Import = New Import(file)
      i.SQL = sql
      Return i.Query
    End Function
#End Region

#Region "Constructions"
    Public Sub New()
    End Sub
    Public Sub New(ByVal workbook As String)
      MyBase.New(workbook)
    End Sub
    Public Sub New(ByVal workbook As String, ByVal range As String)
      Me.New(workbook)
      Me.Range = range
    End Sub
#End Region

#Region "SQL Query"
    Private m_fields As String = "*"
    <DefaultValue(GetType(String), "*")> _
    Public Property Fields() As String
      Get
        Return m_fields
      End Get
      Set(ByVal Value As String)
        m_fields = Value
      End Set
    End Property
    Sub ResetFields()
      m_fields = "*"
    End Sub
    Private m_where As String
    <DefaultValue(GetType(String), "*")> _
    Public Property Where() As String
      Get
        Return m_where
      End Get
      Set(ByVal Value As String)
        m_where = Value
      End Set
    End Property

    Public SQL As String
    Protected Function GetSelectSQL() As String
      If Not Me.SQL Is Nothing AndAlso Me.SQL.Length > 0 Then
        Return Me.SQL
      End If
      Dim sql As String = String.Format("select {0} from {1}", Fields, GetRange())
      If Not m_where Is Nothing Then
        sql &= " WHERE " & m_where
      End If
      Return sql
    End Function

    Public Function Query() As DataTable
      Return Query(CType(Nothing, DataTable))
    End Function

    Public Function Query(ByVal dt As DataTable) As DataTable
      CheckWorkbook()
      Dim sql As String = ""
      Try
        OpenConnection(True)
        If dt Is Nothing Then
          dt = New DataTable
        End If

        VerifiedFields()
        sql = GetSelectSQL()

        Dim da As New OleDbDataAdapter(sql, Connection)
        da.Fill(dt)
        Return dt
      Catch ex As Exception
        MessageBox.Show(sql)
        Throw ex
      Finally
        CloseConnection(True)
      End Try
    End Function

    Private Sub VerifiedFields()
      Dim dt As New DataTable
      Dim excelColl As New ArrayList
      Dim splitFields() As String
      Dim newColl As New ArrayList

      Dim newsql As String = "select top 1 * from " & GetRange() & " where 1 = -1"
      Dim da As New OleDbDataAdapter(newsql, Connection)
      da.Fill(dt)

      For Each dc As DataColumn In dt.Columns
        excelColl.Add(dc.ColumnName)
      Next
      splitFields = Me.Fields.Split(","c)
      For Each str As String In splitFields
        If excelColl.Contains(str.Replace("[", "").Replace("]", "")) Then
          newColl.Add(str)
        End If
      Next

      Me.Fields = String.Join(",", newColl.ToArray)
    End Sub

    Public Sub Fill(ByVal dt As DataTable)
      Query(dt)
    End Sub
#End Region
  End Class
End Namespace

