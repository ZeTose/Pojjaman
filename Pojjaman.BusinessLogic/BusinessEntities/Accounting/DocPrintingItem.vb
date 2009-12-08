Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration
Imports System.Reflection
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services

Namespace Longkong.Pojjaman.BusinessLogic
    Public Interface IPrintableEntity
        Inherits IIdentifiable
        Function GetDefaultFormPath() As String
        Function GetDefaultForm() As String
        Function GetDocPrintingEntries() As DocPrintingItemCollection
    End Interface
    Public Interface IHasCustomNote
        Function GetCustomNoteCollection() As CustomNoteCollection
	End Interface
	Public Interface IHasMainDoc
		ReadOnly Property MainDoc() As ISimpleEntity
	End Interface
	Public Class DocPrintingItem
		Public Enum Frequency
			FirstPage
			EveryPage
			LastPage
		End Enum
#Region "Members"
		Private m_dataType As String
		Private m_value As Object
		Private m_mapping As String
		Private m_row As Integer
		Private m_table As String
		Private m_font As Font = Nothing
		Private m_level As Integer
		Private m_printingFrequency As Frequency = Frequency.EveryPage
		Private m_linestyle As Integer
		Private m_lines As Integer = 1
#End Region

#Region "Properties"
		Public Property PrintingFrequency() As Frequency			Get				Return m_printingFrequency			End Get			Set(ByVal Value As Frequency)				m_printingFrequency = Value			End Set		End Property
		Public Property DataType() As String			Get				Return m_dataType			End Get			Set(ByVal Value As String)				m_dataType = Value			End Set		End Property		Public Property Value() As Object			Get				If Not m_value Is Nothing Then					If Not Me.DataType Is Nothing AndAlso Me.DataType.ToLower = "system.string" Then
						Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
						Return myStringParserService.Parse(m_value.ToString)
					End If
				End If				Return m_value			End Get			Set(ByVal Value As Object)				m_value = Value			End Set		End Property		Public Property Mapping() As String			Get				Return m_mapping			End Get			Set(ByVal Value As String)				m_mapping = Value			End Set		End Property		Public Property Lines() As Integer			Get				Return m_lines			End Get			Set(ByVal Value As Integer)				m_lines = Value			End Set		End Property		Public Property Row() As Integer			Get				Return m_row			End Get			Set(ByVal Value As Integer)				m_row = Value			End Set		End Property		Public Property Table() As String			Get				Return m_table			End Get			Set(ByVal Value As String)				m_table = Value			End Set		End Property		Public Property Font() As Font			Get				Return m_font			End Get			Set(ByVal Value As Font)				m_font = Value			End Set		End Property		Public Property Level() As Integer			Get				Return m_level			End Get			Set(ByVal Value As Integer)				m_level = Value			End Set		End Property		Public Property LineStyle() As Integer			Get
				Return m_linestyle
			End Get
			Set(ByVal Value As Integer)
				m_linestyle = Value
			End Set
		End Property#End Region

#Region "Clone"
		Public Function Clone() As DocPrintingItem
			Dim cloneItem As New DocPrintingItem
			cloneItem.m_dataType = Me.m_dataType
			cloneItem.m_value = Me.m_value
			cloneItem.m_mapping = Me.m_mapping
			cloneItem.m_row = Me.m_row
			cloneItem.m_table = Me.m_table
			cloneItem.m_font = Me.m_font
			cloneItem.m_level = Me.m_level
			cloneItem.m_printingFrequency = Me.m_printingFrequency
			cloneItem.m_linestyle = Me.m_linestyle
			cloneItem.m_lines = Me.m_lines
			Return cloneItem
		End Function
#End Region


	End Class

	<Serializable(), DefaultMember("Item")> _
	Public Class DocPrintingItemCollection
		Inherits CollectionBase

#Region "Members"
		Private m_level As Integer
		Private m_mappingHash As Hashtable
#End Region

#Region "Constructors"
		Public Sub New()
			m_mappingHash = New Hashtable
		End Sub
		Public Sub New(ByVal level As Integer)
			Me.New()
			m_level = level
		End Sub
#End Region

#Region "Properties"
		Default Public Property Item(ByVal index As Integer) As DocPrintingItem
			Get
				Return CType(MyBase.List.Item(index), DocPrintingItem)
			End Get
			Set(ByVal value As DocPrintingItem)
				MyBase.List.Item(index) = value
			End Set
		End Property
		Public Property Level() As Integer			Get				Return m_level			End Get			Set(ByVal Value As Integer)				m_level = Value			End Set		End Property
#End Region

#Region "Class Methods"
		Private m_rowCount As Integer
		Public Function GetRowCount(ByVal table As String) As Integer
			Dim maxRow As Integer = 0
			For Each item As DocPrintingItem In Me.GetTableItems(table)
				If item.Row > maxRow Then
					maxRow = item.Row
				End If
			Next
			m_rowCount = maxRow
			Return m_rowCount
		End Function
		Public Function GetMappingItem(ByVal mapping As String) As DocPrintingItem
			Try
				Dim item As DocPrintingItem = CType(m_mappingHash("|" & mapping.ToLower & "|"), DocPrintingItem)
				Return item
			Catch ex As Exception
				For Each item As DocPrintingItem In Me
					If item.Mapping.ToLower = mapping.ToLower Then
						Return item
					End If
				Next
			End Try
		End Function
		Public Function GetMappingItem(ByVal table As String, ByVal mapping As String, ByVal row As Integer) As DocPrintingItem
			If table Is Nothing Then
				Return Nothing
			End If
			If mapping Is Nothing Then
				Return Nothing
			End If
			Try
				Dim ht As Hashtable = CType(m_mappingHash(table.ToLower & "|" & mapping.ToLower), Hashtable)
				If ht Is Nothing Then
					Return Nothing
				End If
				Return CType(ht(row), DocPrintingItem)
			Catch ex As Exception
				For Each item As DocPrintingItem In Me
					If item.Mapping.ToLower = mapping.ToLower AndAlso item.Table.ToLower = table.ToLower AndAlso item.Row = row Then
						Return item
					End If
				Next
			End Try
		End Function
		Public Function GetTableItems(ByVal table As String) As DocPrintingItemCollection
			If table Is Nothing Then
				Return Nothing
			End If
			Dim ret As New DocPrintingItemCollection
			Try
				Dim tbHash As Hashtable = CType(m_mappingHash("|" & table.ToLower & "|"), Hashtable)
				For Each item As DocPrintingItem In tbHash.Values
					ret.Add(item)
					If item.Value Is Nothing Then
						item.Value = "Nothing"
					End If
				Next
			Catch ex As Exception
				For Each item As DocPrintingItem In Me
					If Not item.Table Is Nothing AndAlso item.Table.ToLower = table.ToLower Then
						ret.Add(item)
						If item.Value Is Nothing Then
							item.Value = "Nothing"
						End If
					End If
				Next
			End Try
			Return ret
		End Function
#End Region

#Region "Collection Methods"
		Public Function Add(ByVal value As DocPrintingItem) As Integer
			If Not value.Mapping Is Nothing AndAlso value.Mapping.Length <> 0 Then
				If Not value.Table Is Nothing AndAlso value.Table.Length <> 0 Then
					'เก็บ table/row
					If Not m_mappingHash.Contains(value.Table.ToLower & "|" & value.Mapping.ToLower) Then
						m_mappingHash(value.Table.ToLower & "|" & value.Mapping.ToLower) = New Hashtable
					End If
					Dim ht As Hashtable = CType(m_mappingHash(value.Table.ToLower & "|" & value.Mapping.ToLower), Hashtable)
					ht(value.Row) = value
					'เก็บ table
					If Not m_mappingHash.Contains("|" & value.Table.ToLower & "|") Then
						m_mappingHash("|" & value.Table.ToLower & "|") = New Hashtable
					End If
					ht = CType(m_mappingHash("|" & value.Table.ToLower & "|"), Hashtable)
					ht(value.Row) = value
				Else
					'เก็บ Mapping
					If Not m_mappingHash.Contains("|" & value.Mapping.ToLower & "|") Then
						m_mappingHash("|" & value.Mapping.ToLower & "|") = value
					End If
				End If
			End If
			Return MyBase.List.Add(value)
		End Function
		Public Sub AddRange(ByVal value As DocPrintingItemCollection)
			For i As Integer = 0 To value.Count - 1
				Me.Add(value(i))
			Next
		End Sub
		Public Sub AddRange(ByVal value As DocPrintingItem())
			For i As Integer = 0 To value.Length - 1
				Me.Add(value(i))
			Next
		End Sub
		Public Function Contains(ByVal value As DocPrintingItem) As Boolean
			Return MyBase.List.Contains(value)
		End Function
		Public Sub CopyTo(ByVal array As DocPrintingItem(), ByVal index As Integer)
			MyBase.List.CopyTo(array, index)
		End Sub
		Public Shadows Function GetEnumerator() As DocPrintingItemEnumerator
			Return New DocPrintingItemEnumerator(Me)
		End Function
		Public Function IndexOf(ByVal value As DocPrintingItem) As Integer
			Return MyBase.List.IndexOf(value)
		End Function
		Public Sub Insert(ByVal index As Integer, ByVal value As DocPrintingItem)
			MyBase.List.Insert(index, value)
		End Sub
		Public Sub Remove(ByVal value As DocPrintingItem)
			MyBase.List.Remove(value)
		End Sub
		Public Sub Remove(ByVal index As Integer)
			MyBase.List.RemoveAt(index)
		End Sub
#End Region

		Public Class DocPrintingItemEnumerator
			Implements IEnumerator

#Region "Members"
			Private m_baseEnumerator As IEnumerator
			Private m_temp As IEnumerable
#End Region

#Region "Construtor"
			Public Sub New(ByVal mappings As DocPrintingItemCollection)
				Me.m_temp = mappings
				Me.m_baseEnumerator = Me.m_temp.GetEnumerator
			End Sub
#End Region

			Public ReadOnly Property Current() As Object Implements System.Collections.IEnumerator.Current
				Get
					Return CType(Me.m_baseEnumerator.Current, DocPrintingItem)
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

