Imports System.Data
Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.Configuration
Imports System.Runtime.InteropServices
Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.BusinessLogic
Imports System.IO
Imports Longkong.Core.Properties
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Services
Namespace Longkong.Pojjaman.BusinessLogic
    Public Class ReportFixValue

#Region "Members"

#End Region

#Region "Constructors"

#End Region

    End Class
    Public Enum Aggregate
        Sum
        Avg
        Min
        Max
        Count
        Remain  ' ToDo: หาค่าบวกสะสม  + กรณีใช้ function row ที่มีค่า Null จะใช้ function ไม่ได้
        None
    End Enum
    Public Class ReportColumn

#Region "Members"
        Private m_name As String
        Private m_alias As String
        Private m_dataType As Type
        Private m_width As Integer
        Private m_alignment As HorizontalAlignment
        Private m_ordinal As Integer

        Private m_digitConfig As DigitConfig
        Private m_level As Integer
        Private m_levelAggregate As Aggregate
        Private m_allAggregate As Aggregate
        Private m_sorting As String

        Private m_headerOnly As Boolean
#End Region

#Region "Constructors"
        Public Sub New(ByVal name As String, ByVal [alias] As String _
        , ByVal width As Integer, ByVal alignment As Integer _
        , ByVal ordinal As Integer, ByVal level As Integer, ByVal dgt As DigitConfig _
        , ByVal levelAgg As Aggregate, ByVal allAgg As Aggregate)
            With Me
                .m_name = name
                .m_alias = [alias]
                .m_width = width
                .m_alignment = CType(alignment, HorizontalAlignment)
                .m_ordinal = ordinal
                .m_level = level
                .m_digitConfig = dgt
                .m_levelAggregate = levelAgg
                .m_allAggregate = allAgg
            End With
        End Sub
        Public Sub New(ByVal row As DataRow)
            Construct(row)
        End Sub
        Private Sub Construct(ByVal row As DataRow)
            With Me
                .m_name = DBNullToString(row("col_name"))
                .m_alias = DBNullToString(row("col_alias"))
                .m_width = DBNullToInteger(row("col_width"))
                .m_alignment = CType(CStr(row("col_align")), HorizontalAlignment)
                .m_ordinal = DBNullToInteger(row("col_ordinal"))
                .m_dataType = Type.GetType(DBNullToString(row("col_dataType")))
                .m_level = DBNullToInteger(row("col_level"))
                Dim config As Integer = DBNullToInteger(row("col_digitconfig"))
                If config >= 0 Then
                    .m_digitConfig = CType([Enum].Parse(GetType(DigitConfig), [Enum].GetName(GetType(DigitConfig), DBNullToInteger(row("col_digitconfig")))), DigitConfig)
                Else
                    .m_digitConfig = Nothing
                End If
                Dim levelAgg As String = DBNullToString(row("col_levelAggregate"))
                If levelAgg.Length = 0 Then
                    .m_levelAggregate = Aggregate.None
                Else
                    .m_levelAggregate = CType([Enum].Parse(GetType(Aggregate), levelAgg), Aggregate)
                End If
                Dim allAgg As String = DBNullToString(row("col_allAggregate"))
                If allAgg.Length = 0 Then
                    .m_allAggregate = Aggregate.None
                Else
                    .m_allAggregate = CType([Enum].Parse(GetType(Aggregate), allAgg), Aggregate)
                End If
                .m_sorting = DBNullToString(row("col_sorting"))
                .m_headerOnly = DBNullToBool(row("col_headerOnly"))
            End With
        End Sub
        Private Function DBNullToString(ByVal obj As Object) As String
            If IsDBNull(obj) Then
                Return ""
            End If
            Return obj.ToString
        End Function
        Private Function DBNullToInteger(ByVal obj As Object) As Integer
            If IsDBNull(obj) OrElse Not IsNumeric(obj) Then
                Return 0
            End If
            Return CInt(obj)
        End Function
        Private Function DBNullToBool(ByVal obj As Object) As Boolean
            If IsDBNull(obj) OrElse Not TypeOf obj Is Boolean Then
                Return False
            End If
            Return CBool(obj)
        End Function
#End Region

#Region "Proprties"
        Public ReadOnly Property Name() As String
            Get
                Return m_name
            End Get
        End Property
        Public Property [Alias]() As String
            Get
                Return m_alias
            End Get
            Set(ByVal Value As String)
                m_alias = Value
            End Set
        End Property
        Public Property DataType() As Type
            Get
                Return m_dataType
            End Get
            Set(ByVal Value As Type)
                m_dataType = Value
            End Set
        End Property
        Public Property Width() As Integer
            Get
                Return m_width
            End Get
            Set(ByVal Value As Integer)
                m_width = Value
            End Set
        End Property
        Public Property Alignment() As HorizontalAlignment
            Get
                Return m_alignment
            End Get
            Set(ByVal Value As HorizontalAlignment)
                m_alignment = Value
            End Set
        End Property
        Public Property Oridnal() As Integer
            Get
                Return m_ordinal
            End Get
            Set(ByVal Value As Integer)
                m_ordinal = Value
            End Set
        End Property
        Public Property Level() As Integer            Get                Return m_level            End Get            Set(ByVal Value As Integer)                m_level = Value            End Set        End Property
        Public Property DigitConfig() As DigitConfig            Get                Return m_digitConfig            End Get            Set(ByVal Value As DigitConfig)                m_digitConfig = Value            End Set        End Property
        Public Property LevelAggregate() As Aggregate            Get                Return m_levelAggregate            End Get            Set(ByVal Value As Aggregate)                m_levelAggregate = Value            End Set        End Property        Public Property AllAggregate() As Aggregate            Get                Return m_allAggregate            End Get            Set(ByVal Value As Aggregate)                m_allAggregate = Value            End Set        End Property
        Public Property Sorting() As String            Get                Return m_sorting            End Get            Set(ByVal Value As String)                m_sorting = Value            End Set        End Property
        Public Property HeaderOnly() As Boolean            Get                Return m_headerOnly            End Get            Set(ByVal Value As Boolean)                m_headerOnly = Value            End Set        End Property
#End Region

    End Class
    Public Class ReportColumnCollection
        Inherits CollectionBase

#Region "Members"
        Private Shared m_columnListDataSet As DataSet
        Private m_className As String
#End Region

#Region "Constructors"
        Public Shared Sub RefreshReportColumnList()

            Dim sqlConString As String = RecentCompanies.CurrentCompany.ConnectionString
            Dim ds As DataSet = SqlHelper.ExecuteDataset(sqlConString, CommandType.StoredProcedure, "GetAllReportColumnList")
            m_columnListDataSet = ds
        End Sub
        Shared Sub New()
            If m_columnListDataSet Is Nothing OrElse m_columnListDataSet.Tables(0).Rows.Count = 0 Then
                RefreshReportColumnList()
            End If
        End Sub
        Public Sub New()
        End Sub
        Public Sub New(ByVal className As String)
            m_className = className
            Construct(m_columnListDataSet)
        End Sub
        Private Sub Construct(ByVal ds As DataSet)
            Dim defaultFilter As String = "(report_name ='" & m_className & "')"
            Dim defaultRows As DataRow() = ds.Tables(0).Select(defaultFilter, "[col_ordinal]")
            If defaultRows.Length > 0 Then
                For Each row As DataRow In defaultRows
                    Add(New ReportColumn(row))
                Next
            End If
        End Sub
#End Region

#Region "Properties"
        Public Shared ReadOnly Property CodeDescriptionTable() As DataSet
            Get
                Return m_columnListDataSet
            End Get
        End Property
        Default Public Property Item(ByVal index As Integer) As ReportColumn
            Get
                Return CType(MyBase.List.Item(index), ReportColumn)
            End Get
            Set(ByVal value As ReportColumn)
                MyBase.List.Item(index) = value
            End Set
        End Property
#End Region

#Region "Class Methods"
        Public Function GetCollectionForLevel(ByVal level As Integer) As ReportColumnCollection
            Dim newCollection As New ReportColumnCollection
            For Each col As ReportColumn In Me
                If col.Level = level Then
                    newCollection.Add(col)
                End If
            Next
            Return newCollection
        End Function
        Public Function GetDataCollectionForLevel(ByVal level As Integer) As ReportColumnCollection
            Dim newCollection As ReportColumnCollection = GetCollectionForLevel(level)
            Dim nextCollection As ReportColumnCollection = GetCollectionForLevel(level + 1)
            For Each col As ReportColumn In nextCollection
                For Each oldCol As ReportColumn In newCollection
                    If col.Oridnal = oldCol.Oridnal Then
                        If oldCol.HeaderOnly Then
                            newCollection(newCollection.IndexOf(oldCol)) = col
                        End If
                        Exit For
                    End If
                Next
            Next
            Return newCollection
        End Function
        Public Function GetMaxLevel() As Integer
            Dim maxLvl As Integer = 0
            For Each col As ReportColumn In Me
                maxLvl = Math.Max(maxLvl, col.Level)
            Next
            Return maxLvl
        End Function
        Public Function GetMaxDataLevel() As Integer
            Dim maxLvl As Integer = 0
            For Each col As ReportColumn In Me
                If col.HeaderOnly Then
                    Return col.Level
                End If
                maxLvl = Math.Max(maxLvl, col.Level)
            Next
            Return maxLvl
        End Function
        Public Function GetMaxOrdinal() As Integer
            Dim maxOrd As Integer = 0
            For Each col As ReportColumn In Me
                maxOrd = Math.Max(maxOrd, col.Oridnal)
            Next
            Return maxOrd
        End Function
        Public Function GetEffectiveAlignment(ByVal ord As Integer) As HorizontalAlignment
            Dim ret As HorizontalAlignment = HorizontalAlignment.Left
            For Each col As ReportColumn In Me
                If col.Oridnal = ord Then
                    ret = col.Alignment
                    If ret = HorizontalAlignment.Right Then
                        Return ret
                    End If
                End If
            Next
            Return ret
        End Function
        Public Function GetMaxWidth(ByVal ord As Integer) As Integer
            Dim maxW As Integer = 0
            For Each col As ReportColumn In Me
                If col.Oridnal = ord Then
                    maxW = Math.Max(maxW, col.Width)
                End If
            Next
            Return maxW
        End Function
        Public Function GetGroupingColumnList() As String
            Dim ret As String = ""
            For Each col As ReportColumn In Me
                ret &= col.Name & ","
            Next
            If ret.EndsWith(",") Then
                ret = ret.Remove(ret.Length - 1, 1)
            End If
            Return ret
        End Function
        Public Function GetSortingList() As String
            Dim ret As String = ""
            For Each col As ReportColumn In Me
                If col.Sorting.Length > 0 AndAlso col.Sorting.ToLower <> "none" Then
                    ret &= col.Name & " " & col.Sorting & ","
                End If
            Next
            If ret.EndsWith(",") Then
                ret = ret.Remove(ret.Length - 1, 1)
            End If
            Return ret
        End Function
        Public Function GetFilterList(ByVal dr As DataRow) As String
            Dim ret As String = ""
            For Each col As ReportColumn In Me
                ret &= col.Name & "='" & dr(col.Oridnal).ToString & "' and "
            Next
            If ret.EndsWith(" and ") Then
                ret = ret.Remove(ret.Length - 5, 5)
            End If
            Return ret
        End Function
#End Region

#Region "Collection Methods"
        Public Function Add(ByVal value As ReportColumn) As Integer
            Return MyBase.List.Add(value)
        End Function
        Public Sub AddRange(ByVal value As ReportColumnCollection)
            For i As Integer = 0 To value.Count - 1
                Me.Add(value(i))
            Next
        End Sub
        Public Sub AddRange(ByVal value As ReportColumn())
            For i As Integer = 0 To value.Length - 1
                Me.Add(value(i))
            Next
        End Sub
        Public Function Contains(ByVal value As ReportColumn) As Boolean
            Return MyBase.List.Contains(value)
        End Function
        Public Sub CopyTo(ByVal array As ReportColumn(), ByVal index As Integer)
            MyBase.List.CopyTo(array, index)
        End Sub
        Public Shadows Function GetEnumerator() As ItemEnumerator
            Return New ItemEnumerator(Me)
        End Function
        Public Function IndexOf(ByVal value As ReportColumn) As Integer
            Return MyBase.List.IndexOf(value)
        End Function
        Public Sub Insert(ByVal index As Integer, ByVal value As ReportColumn)
            MyBase.List.Insert(index, value)
        End Sub
        Public Sub Remove(ByVal value As ReportColumn)
            MyBase.List.Remove(value)
        End Sub
        Public Overridable Function Save() As SaveErrorException
            Debug.WriteLine("Implement Me!!! ReportColumnCollection.Save")
        End Function
        Public Overridable Function Save(ByVal currentUserId As Integer) As SaveErrorException
            Debug.WriteLine("Implement Me!!! ReportColumnCollection.Save")
        End Function
#End Region

        Public Class ItemEnumerator
            Implements IEnumerator

#Region "Members"
            Private m_baseEnumerator As IEnumerator
            Private m_temp As IEnumerable
#End Region

#Region "Construtor"
            Public Sub New(ByVal mappings As ReportColumnCollection)
                Me.m_temp = mappings
                Me.m_baseEnumerator = Me.m_temp.GetEnumerator
            End Sub
#End Region

            Public ReadOnly Property Current() As Object Implements System.Collections.IEnumerator.Current
                Get
                    Return CType(Me.m_baseEnumerator.Current, ReportColumn)
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
