Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.TextHelper
Imports Longkong.Pojjaman.Services
Imports System.Reflection

Namespace Longkong.Pojjaman.BusinessLogic
    Public Class Country
        Inherits SimpleBusinessEntityBase
        Implements IHasName

#Region "Members"
        Private m_name As String
        Private m_unit As String
        Private m_subUnit As String
        Private m_subUnitConversion As Decimal
        Private m_rateCollection As CurrencyRateCollection
#End Region

#Region "Constructors"
        Public Sub New()
            MyBase.New()
        End Sub
        Public Sub New(ByVal id As Integer)
            MyBase.New(id)
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
        Protected Overloads Overrides Sub Construct()
            MyBase.Construct()
            m_rateCollection = New CurrencyRateCollection
        End Sub
        Protected Overloads Overrides Sub Construct(ByVal dr As System.Data.DataRow, ByVal aliasPrefix As String)
            MyBase.Construct(dr, aliasPrefix)
            With Me
                If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_name") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_name") Then
                    .m_name = CStr(dr(aliasPrefix & Me.Prefix & "_name"))
                End If

                If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_unit") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_unit") Then
                    .m_unit = CStr(dr(aliasPrefix & Me.Prefix & "_unit"))
                End If

                If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_subUnit") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_subUnit") Then
                    .m_subUnit = CStr(dr(aliasPrefix & Me.Prefix & "_subUnit"))
                End If

                If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_subUnitConversion") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_subUnitConversion") Then
                    .m_subUnitConversion = CDec(dr(aliasPrefix & Me.Prefix & "_subUnitConversion"))
                End If
            End With
            m_rateCollection = New CurrencyRateCollection(Me)
        End Sub
#End Region

#Region "Properties"
        Public Property Unit() As String            Get                Return m_unit            End Get            Set(ByVal Value As String)                m_unit = Value            End Set        End Property        Public Property SubUnit() As String            Get                Return m_subUnit            End Get            Set(ByVal Value As String)                m_subUnit = Value            End Set        End Property        Public Property SubUnitConversion() As Decimal            Get                Return m_subUnitConversion            End Get            Set(ByVal Value As Decimal)                m_subUnitConversion = Value            End Set        End Property        Public Property RateCollection() As CurrencyRateCollection            Get                Return m_rateCollection            End Get            Set(ByVal Value As CurrencyRateCollection)                m_rateCollection = Value            End Set        End Property        Public Overrides ReadOnly Property ClassName() As String
            Get
                Return "Country"
            End Get
        End Property
        Public Overrides ReadOnly Property DetailPanelTitle() As String
            Get
                Return "${res:Longkong.Pojjaman.BusinessLogic.Country.DetailLabel}"
            End Get
        End Property
        Public Overrides ReadOnly Property DetailPanelIcon() As String
            Get
                Return "Icons.16x16.Country"
            End Get
        End Property
        Public Overrides ReadOnly Property ListPanelIcon() As String
            Get
                Return "Icons.16x16.Country"
            End Get
        End Property
        Public Overrides ReadOnly Property ListPanelTitle() As String
            Get
                Return "${res:Longkong.Pojjaman.BusinessLogic.Country.ListLabel}"
            End Get
        End Property
        Public Overrides ReadOnly Property Prefix() As String
            Get
                Return "country"
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

#Region "Shared"
        Public Shared Function GetSchemaTable() As TreeTable
            Dim myDatatable As New TreeTable("CurrencyRate")

            Dim dateCol As New DataColumn("Date", GetType(Date))
            dateCol.DefaultValue = Date.MinValue
            myDatatable.Columns.Add(dateCol)

            myDatatable.Columns.Add(New DataColumn("Linenumber", GetType(Integer)))
            myDatatable.Columns.Add(New DataColumn("Country", GetType(String)))
            myDatatable.Columns.Add(New DataColumn("Rate", GetType(String)))

            'เพื่อให้แสดง error ตามคอลัมน์เป็นภาษาที่ต้องการ
            Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
            'myDatatable.Columns("Code").Caption = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaySelectionDetail.CodeHeaderText}")
            'myDatatable.Columns("paysi_amt").Caption = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaySelectionDetail.AmountHeaderText}")
            Return myDatatable
        End Function
        Public Shared Sub ListUnitInComboBox(ByVal cmb As ComboBox)
            cmb.Items.Clear()
            Try
                Dim ds As DataSet = SqlHelper.ExecuteDataset(ConnectionString _
                , CommandType.StoredProcedure _
                , "GetCountryList" _
                )
                Dim dt As DataTable = ds.Tables(0)
                If dt Is Nothing Then
                    Return
                End If
                For Each row As DataRow In dt.Rows
                    Dim item As New IdValuePair(CInt(row("country_id")), CStr(row("country_unit")))
                    cmb.Items.Add(item)
                Next
            Catch ex As Exception

            End Try
        End Sub
        Public Sub ComboSelect(ByVal cmb As ComboBox)
            For Each item As IdValuePair In cmb.Items
                If Me.Id = item.Id Then
                    cmb.SelectedItem = item
                    Return
                End If
            Next
            cmb.SelectedIndex = -1
        End Sub
        Public Function GetRateAtDate(ByVal theDate As Date) As Decimal
            Try
                Dim ds As DataSet = SqlHelper.ExecuteDataset(ConnectionString _
                , CommandType.StoredProcedure _
                , "GetLatestCurrencyRateForCountryAtDate" _
                , New SqlParameter("@country_id", Me.Id) _
                , New SqlParameter("@currencyrate_date", theDate.Date) _
                )
                Dim dt As DataTable = ds.Tables(0)
                If dt Is Nothing Then
                    Return 1
                End If
                If dt.Rows.Count = 1 Then
                    If IsNumeric(dt.Rows(0)(0)) Then
                        Return CDec(dt.Rows(0)(0))
                    End If
                End If
            Catch ex As Exception

            End Try
            Return 1
        End Function
#End Region

#Region "IHasName"
        Public Property Name() As String Implements IHasName.Name
            Get
                Return m_name
            End Get
            Set(ByVal Value As String)
                m_name = Value
            End Set
        End Property
#End Region

#Region "Methods"
        Private Sub ResetID(ByVal oldid As Integer)
            Me.Id = oldid
        End Sub
        Public Overloads Overrides Function Save(ByVal currentUserId As Integer) As SaveErrorException
            With Me
                'If Me.RateCollection.Count = 0 Then
                '    Return New SaveErrorException(Me.StringParserService.Parse("${res:Global.Error.NoItem}"))
                'End If
                Dim returnVal As System.Data.SqlClient.SqlParameter = New SqlParameter
                returnVal.ParameterName = "RETURN_VALUE"
                returnVal.DbType = DbType.Int32
                returnVal.Direction = ParameterDirection.ReturnValue
                returnVal.SourceVersion = DataRowVersion.Current

                ' สร้าง ArrayList จาก Item ของ  SqlParameter ...
                Dim paramArrayList As New ArrayList

                paramArrayList.Add(returnVal)
                If Me.Originated Then
                    paramArrayList.Add(New SqlParameter("@country_id", Me.Id))
                End If

                Dim theTime As Date = Now
                Dim theUser As New User(currentUserId)

                'If Me.Status.Value = -1 Then
                '    Me.Status.Value = 2
                'End If

                'If Me.AutoGen And Me.Code.Length = 0 Then
                '    Me.Code = Me.GetNextCode
                'End If
                'Me.AutoGen = False

                paramArrayList.Add(New SqlParameter("@country_code", Me.Code))
                paramArrayList.Add(New SqlParameter("@country_name", Me.Name))
                paramArrayList.Add(New SqlParameter("@country_unit", Me.Unit))
                paramArrayList.Add(New SqlParameter("@country_subunit", Me.SubUnit))

                SetOriginEditCancelStatus(paramArrayList, currentUserId, theTime)

                ' สร้าง SqlParameter จาก ArrayList ...
                Dim sqlparams() As SqlParameter
                sqlparams = CType(paramArrayList.ToArray(GetType(SqlParameter)), SqlParameter())
                Dim trans As SqlTransaction
                Dim conn As New SqlConnection(Me.ConnectionString)
                conn.Open()
                trans = conn.BeginTransaction()

                Dim oldid As Integer = Me.Id

                Try
                    Me.ExecuteSaveSproc(returnVal, sqlparams, theTime, theUser)
                    If IsNumeric(returnVal.Value) Then
                        Select Case CInt(returnVal.Value)
                            Case -1, -2, -5
                                trans.Rollback()
                                Me.ResetID(oldid)
                                Return New SaveErrorException(returnVal.Value.ToString)
                            Case Else
                        End Select
                    ElseIf IsDBNull(returnVal.Value) OrElse Not IsNumeric(returnVal.Value) Then
                        trans.Rollback()
                        Me.ResetID(oldid)
                        Return New SaveErrorException(returnVal.Value.ToString)
                    End If
                    Me.RateCollection.Save(Me.Id, conn, trans)
                    trans.Commit()
                    Return New SaveErrorException(returnVal.Value.ToString)
                Catch ex As SqlException
                    trans.Rollback()
                    Me.ResetID(oldid)
                    Return New SaveErrorException(ex.ToString)
                Catch ex As Exception
                    trans.Rollback()
                    Me.ResetID(oldid)
                    Return New SaveErrorException(ex.ToString)
                Finally
                    conn.Close()
                End Try
            End With
        End Function
#End Region

    End Class

    Public Class CurrencyRate

#Region "Members"
        Private m_countryId As Integer
        Private m_date As Date
        Private m_rate As Decimal
#End Region

#Region "Constructors"
        Public Sub New()
            MyBase.New()
        End Sub
        Public Sub New(ByVal country As Country, ByVal theDate As Date)
            Try
                Dim connString As String = RecentCompanies.CurrentCompany.ConnectionString
                Dim ds As DataSet = SqlHelper.ExecuteDataset(connString _
                , CommandType.StoredProcedure _
                , "GetCurrencyRates" _
                , New SqlParameter("@currencyrate_country", SimpleBusinessEntityBase.ValidIdOrDBNull(country)) _
                , New SqlParameter("@currencyrate_date", SimpleBusinessEntityBase.ValidDateOrDBNull(theDate.Date)) _
                )
                Me.Construct(ds.Tables(0).Rows(0), "")
            Catch ex As Exception

            End Try
        End Sub
        Public Sub New(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
            Me.Construct(ds, aliasPrefix)
        End Sub
        Public Sub New(ByVal dr As DataRow, ByVal aliasPrefix As String)
            Me.Construct(dr, aliasPrefix)
        End Sub
        Protected Sub Construct(ByVal dr As DataRow, ByVal aliasPrefix As String)
            If dr.Table.Columns.Contains(aliasPrefix & "currencyrate_country") AndAlso Not dr.IsNull(aliasPrefix & "currencyrate_country") Then
                m_countryId = CInt(dr(aliasPrefix & "currencyrate_country"))
            End If
            If dr.Table.Columns.Contains(aliasPrefix & "currencyrate_date") AndAlso Not dr.IsNull(aliasPrefix & "currencyrate_date") Then
                m_date = CDate(dr(aliasPrefix & "currencyrate_date"))
            End If
            If dr.Table.Columns.Contains(aliasPrefix & "currencyrate_country") AndAlso Not dr.IsNull(aliasPrefix & "currencyrate_country") Then
                m_countryId = CInt(dr(aliasPrefix & "currencyrate_country"))
            End If
            If dr.Table.Columns.Contains(aliasPrefix & "currencyrate_rate") AndAlso Not dr.IsNull(aliasPrefix & "currencyrate_rate") Then
                m_rate = CDec(dr(aliasPrefix & "currencyrate_rate"))
            End If
        End Sub
        Protected Sub Construct(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
            Dim dr As DataRow = ds.Tables(0).Rows(0)
            Me.Construct(dr, aliasPrefix)
        End Sub
#End Region

#Region "Properties"
        Public Property CountryId() As Integer            Get                Return m_countryId            End Get            Set(ByVal Value As Integer)                m_countryId = Value            End Set        End Property        Private m_country As Country        Public Property Country() As Country
            Get
                If m_country Is Nothing OrElse Not m_country.Originated Then
                    m_country = New Country(m_countryId)
                End If
                Return m_country
            End Get
            Set(ByVal Value As Country)
                m_country = Value
            End Set
        End Property        Public Property [Date]() As Date            Get                Return m_date            End Get            Set(ByVal Value As Date)                m_date = Value            End Set        End Property        Public Property Rate() As Decimal            Get                Return m_rate            End Get            Set(ByVal Value As Decimal)                m_rate = Value            End Set        End Property
#End Region

    End Class

    <Serializable(), DefaultMember("Item")> _
Public Class CurrencyRateCollection
        Inherits CollectionBase

#Region "Members"
#End Region

#Region "Constructors"
        Public Sub New()
        End Sub
        Public Sub New(ByVal country As Country)
            If Not country.Originated Then
                Return
            End If

            Dim sqlConString As String = RecentCompanies.CurrentCompany.ConnectionString


            Dim ds As DataSet = SqlHelper.ExecuteDataset(sqlConString _
            , CommandType.StoredProcedure _
            , "GetCurrencyRates" _
            , New SqlParameter("@currencyrate_country", country.Id) _
            )

            For Each row As DataRow In ds.Tables(0).Rows
                Dim item As New CurrencyRate(row, "")
                Me.Add(item)
            Next
        End Sub
        Public Sub New(ByVal theDate As Date)
            If theDate.Equals(Date.MinValue) Then
                Return
            End If

            Dim sqlConString As String = RecentCompanies.CurrentCompany.ConnectionString


            Dim ds As DataSet = SqlHelper.ExecuteDataset(sqlConString _
            , CommandType.StoredProcedure _
            , "GetCurrencyRates" _
            , New SqlParameter("@currencyrate_date", theDate) _
            )

            For Each row As DataRow In ds.Tables(0).Rows
                Dim item As New CurrencyRate(row, "")
                Me.Add(item)
            Next
        End Sub
#End Region

#Region "Properties"
        Default Public Property Item(ByVal index As Integer) As CurrencyRate
            Get
                Return CType(MyBase.List.Item(index), CurrencyRate)
            End Get
            Set(ByVal value As CurrencyRate)
                MyBase.List.Item(index) = value
            End Set
        End Property
#End Region

#Region "Class Methods"
        'เรียกจากประเทศ
        Public Sub PopulateCountry(ByVal dt As TreeTable)
            dt.Clear()
            Dim i As Integer = 1
            For Each rate As CurrencyRate In Me
                Dim newRow As TreeRow = dt.Childs.Add()
                newRow("Linenumber") = i
                newRow("Date") = rate.Date.Date
                newRow("Rate") = Configuration.FormatToString(rate.Rate, 5)
                newRow.Tag = rate
                i += 1
            Next
        End Sub
        'เรียกจากวันที่
        Public Sub PopulateDate(ByVal dt As TreeTable)
            dt.Clear()
            Dim i As Integer = 1
            For Each rate As CurrencyRate In Me
                Dim newRow As TreeRow = dt.Childs.Add()
                newRow("Linenumber") = i
                newRow("Country") = rate.Country.Name
                newRow("Rate") = Configuration.FormatToString(rate.Rate, 5)
                newRow.Tag = rate
                i += 1
            Next
        End Sub
        Public Function Save(ByVal countryID As Integer, ByVal conn As SqlConnection, ByVal trans As SqlTransaction) As Integer

            Dim da As New SqlDataAdapter("Select * from currencyrate where currencyrate_country=" & countryID, conn)


            Dim ds As New DataSet

            Dim cmdBuilder As New SqlCommandBuilder(da)
            da.SelectCommand.Transaction = trans
            da.DeleteCommand = cmdBuilder.GetDeleteCommand
            da.DeleteCommand.Transaction = trans
            da.InsertCommand = cmdBuilder.GetInsertCommand
            da.InsertCommand.Transaction = trans
            da.UpdateCommand = cmdBuilder.GetUpdateCommand
            da.UpdateCommand.Transaction = trans
            cmdBuilder = Nothing
            da.FillSchema(ds, SchemaType.Mapped, "currencyrate")
            da.Fill(ds, "currencyrate")

            Dim dt As DataTable = ds.Tables("currencyrate")

            With dt
                For Each row As DataRow In .Rows
                    row.Delete()
                Next
                For Each item As CurrencyRate In Me
                    Dim dr As DataRow = .NewRow
                    dr("currencyrate_country") = countryID
                    dr("currencyrate_date") = item.Date.Date
                    dr("currencyrate_rate") = item.Rate
                    .Rows.Add(dr)
                Next
            End With

            ' First process deletes.
            da.Update(dt.Select(Nothing, Nothing, DataViewRowState.Deleted))
            ' Next process updates.
            da.Update(dt.Select(Nothing, Nothing, DataViewRowState.ModifiedCurrent))
            ' Finally process inserts.
            da.Update(dt.Select(Nothing, Nothing, DataViewRowState.Added))

        End Function
        Private Function DateToSQLString(ByVal dt As Date) As String
            Dim ret As String
            Dim dateString As String = dt.Day.ToString
            Dim monthString As String = dt.Month.ToString
            Dim yearString As String = dt.Year.ToString
            ret = "'" & yearString & "-" & monthString & "-" & dateString & "'"
        End Function
        Public Function Save(ByVal theDate As Date, ByVal conn As SqlConnection, ByVal trans As SqlTransaction) As Integer

            Dim da As New SqlDataAdapter("Select * from currencyrate where currencyrate_date=" & DateToSQLString(theDate), conn)

            Dim ds As New DataSet

            Dim cmdBuilder As New SqlCommandBuilder(da)
            da.SelectCommand.Transaction = trans
            da.DeleteCommand = cmdBuilder.GetDeleteCommand
            da.DeleteCommand.Transaction = trans
            da.InsertCommand = cmdBuilder.GetInsertCommand
            da.InsertCommand.Transaction = trans
            da.UpdateCommand = cmdBuilder.GetUpdateCommand
            da.UpdateCommand.Transaction = trans
            cmdBuilder = Nothing
            da.FillSchema(ds, SchemaType.Mapped, "BillAcceptanceItem")
            da.Fill(ds, "BillAcceptanceItem")

            Dim dt As DataTable = ds.Tables("currencyrate")

            With dt
                For Each row As DataRow In .Rows
                    row.Delete()
                Next
                For Each item As CurrencyRate In Me
                    Dim dr As DataRow = .NewRow
                    dr("currencyrate_date") = theDate
                    dr("currencyrate_country") = item.CountryId
                    dr("currencyrate_rate") = item.Rate
                    .Rows.Add(dr)
                Next
            End With

            ' First process deletes.
            da.Update(dt.Select(Nothing, Nothing, DataViewRowState.Deleted))
            ' Next process updates.
            da.Update(dt.Select(Nothing, Nothing, DataViewRowState.ModifiedCurrent))
            ' Finally process inserts.
            da.Update(dt.Select(Nothing, Nothing, DataViewRowState.Added))

        End Function
#End Region

#Region "Collection Methods"
        Public Function Add(ByVal value As CurrencyRate) As Integer
            Return MyBase.List.Add(value)
        End Function
        Public Sub AddRange(ByVal value As CurrencyRateCollection)
            For i As Integer = 0 To value.Count - 1
                Me.Add(value(i))
            Next
        End Sub
        Public Sub AddRange(ByVal value As CurrencyRate())
            For i As Integer = 0 To value.Length - 1
                Me.Add(value(i))
            Next
        End Sub
        Public Function Contains(ByVal value As CurrencyRate) As Boolean
            Return MyBase.List.Contains(value)
        End Function
        Public Sub CopyTo(ByVal array As CurrencyRate(), ByVal index As Integer)
            MyBase.List.CopyTo(array, index)
        End Sub
        Public Shadows Function GetEnumerator() As CurrencyRateEnumerator
            Return New CurrencyRateEnumerator(Me)
        End Function
        Public Function IndexOf(ByVal value As CurrencyRate) As Integer
            Return MyBase.List.IndexOf(value)
        End Function
        Public Sub Insert(ByVal index As Integer, ByVal value As CurrencyRate)
            MyBase.List.Insert(index, value)
        End Sub
        Public Sub Remove(ByVal value As CurrencyRate)
            MyBase.List.Remove(value)
        End Sub
        Public Sub Remove(ByVal value As CurrencyRateCollection)
            For i As Integer = 0 To value.Count - 1
                Me.Remove(value(i))
            Next
        End Sub
        Public Sub Remove(ByVal index As Integer)
            MyBase.List.RemoveAt(index)
        End Sub
#End Region


        Public Class CurrencyRateEnumerator
            Implements IEnumerator

#Region "Members"
            Private m_baseEnumerator As IEnumerator
            Private m_temp As IEnumerable
#End Region

#Region "Construtor"
            Public Sub New(ByVal mappings As CurrencyRateCollection)
                Me.m_temp = mappings
                Me.m_baseEnumerator = Me.m_temp.GetEnumerator
            End Sub
#End Region

            Public ReadOnly Property Current() As Object Implements System.Collections.IEnumerator.Current
                Get
                    Return CType(Me.m_baseEnumerator.Current, CurrencyRate)
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
