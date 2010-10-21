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
  Public Interface IHasCurrency
    Inherits IIdentifiable, IObjectReflectable
    Property Currency As Currency
  End Interface
  Public Class Currency

    ''' <summary>
    ''' หน่วยหลัก :Default = บาท
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Unit As String

    ''' <summary>
    ''' หน่วยย่อย :Default = สตางค์
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property SubUnit As String

    ''' <summary>
    ''' ภาษา (ใช้พิมพ์) :Default = "THAI"
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Language As String

    ''' <summary>
    ''' อัตราต่อ 1 บาท
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Conversion As Decimal

    Public Function Clone() As Currency
      Dim ret As New Currency
      ret.Conversion = Me.Conversion
      ret.Language = Me.Language
      ret.Unit = Me.Unit
      ret.SubUnit = Me.SubUnit
      Return ret
    End Function
    Public Overrides Function Equals(ByVal obj As Object) As Boolean
      If Not TypeOf obj Is Currency Then
        Return False
      End If
      Dim other As Currency = CType(obj, Currency)
      If Me.Unit <> other.Unit Then
        Return False
      End If
      If Me.SubUnit <> other.SubUnit Then
        Return False
      End If
      If Me.Conversion <> other.Conversion Then
        Return False
      End If
      If Me.Language <> other.Language Then
        Return False
      End If
      Return True
    End Function
    Public ReadOnly Property IsDefault As Boolean
      Get
        Return Me.Equals(DefaultCurrency)
      End Get
    End Property
#Region "Shared Methods"
    Private Shared _DefaultCurrency As Currency
    Public Shared ReadOnly Property DefaultCurrency As Currency
      Get
        If _DefaultCurrency Is Nothing Then
          _DefaultCurrency = New Currency
          _DefaultCurrency.Conversion = 1
          _DefaultCurrency.Language = "THAI"
          _DefaultCurrency.Unit = "บาท"
          _DefaultCurrency.SubUnit = "สตางค์"
        End If
        Return _DefaultCurrency
      End Get
    End Property
    Public Shared Sub SetCurrencyFromDB(ByVal doc As IHasCurrency)
      doc.Currency = Currency.DefaultCurrency.Clone()
      Try
        Dim ds As DataSet _
        = SqlHelper.ExecuteDataset(SimpleBusinessEntityBase.ConnectionString, _
        CommandType.Text, _
        "select * from currency where entitytype=" & doc.EntityId & " and entityid=" & doc.Id)
        If ds.Tables(0).Rows.Count > 0 Then
          Dim deh As New DataRowHelper(ds.Tables(0).Rows(0))
          doc.Currency.Conversion = deh.GetValue(Of Decimal)("Conversion", doc.Currency.Conversion)
          doc.Currency.Unit = deh.GetValue(Of String)("Unit", doc.Currency.Unit)
          doc.Currency.SubUnit = deh.GetValue(Of String)("SubUnit", doc.Currency.SubUnit)
          doc.Currency.Language = deh.GetValue(Of String)("Language", doc.Currency.Language)
        End If
      Catch ex As Exception
      End Try
    End Sub
    Public Shared Sub SaveCurrency(ByVal doc As IHasCurrency, ByVal conn As SqlConnection, ByVal trans As SqlTransaction)
      If doc.Currency Is Nothing Then
        doc.Currency = Currency.DefaultCurrency.Clone()
      End If

      Dim da As New SqlDataAdapter("select * from currency where entitytype=" & doc.EntityId & " and entityid=" & doc.Id, conn)

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
      da.FillSchema(ds, SchemaType.Mapped, "currency")
      da.Fill(ds, "currency")

      Dim dt As DataTable = ds.Tables("currency")

      With ds.Tables("currency")
        For Each row As DataRow In .Rows
          row.Delete()
        Next
        If Not doc.Currency.IsDefault Then
          'Save เฉพาะที่ไม่ใช่ Default
          Dim dr As DataRow = .NewRow
          dr("entitytype") = doc.EntityId
          dr("entityid") = doc.Id
          dr("Language") = doc.Currency.Language
          dr("Unit") = doc.Currency.Unit
          dr("SubUnit") = doc.Currency.SubUnit
          dr("Conversion") = doc.Currency.Conversion
          .Rows.Add(dr)
        End If
      End With

      AddHandler da.RowUpdated, AddressOf tmpDa_MyRowUpdated
      da.Update(GetDeletedRows(dt))
      da.Update(dt.Select("", "", DataViewRowState.ModifiedCurrent))
      da.Update(dt.Select("", "", DataViewRowState.Added))
    End Sub
    Private Shared Sub tmpDa_MyRowUpdated(ByVal sender As Object, ByVal e As System.Data.SqlClient.SqlRowUpdatedEventArgs)
      If e.StatementType = StatementType.Insert Then e.Status = UpdateStatus.SkipCurrentRow
      If e.StatementType = StatementType.Delete Then e.Status = UpdateStatus.SkipCurrentRow
    End Sub
    Private Shared Function GetDeletedRows(ByVal dt As DataTable) As DataRow()
      Dim Rows() As DataRow
      If dt Is Nothing Then Return Rows
      Rows = dt.Select("", "", DataViewRowState.Deleted)
      If Rows.Length = 0 OrElse Not (Rows(0) Is Nothing) Then Return Rows
      '
      ' Workaround:
      ' With a remoted DataSet, Select returns the array elements
      ' filled with Nothing/null, instead of DataRow objects.
      '
      Dim r As DataRow, I As Integer = 0
      For Each r In dt.Rows
        If r.RowState = DataRowState.Deleted Then
          Rows(I) = r
          I += 1
        End If
      Next
      Return Rows
    End Function
#End Region



  End Class
End Namespace
