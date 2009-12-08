Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Data.SqlClient
Imports System.IO
Imports System.ComponentModel
Imports System.Configuration
Imports System.Reflection
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Services

Namespace Longkong.Pojjaman.BusinessLogic
    Public Class LinkFinancialStatement
        Inherits SimpleBusinessEntityBase
        Implements IHasName, IPrintableEntity

#Region "Members"
        Private m_FinancialStatementItemcollection As FinancialStatementItemCollection
        Private m_group As LinkFinancialType
        Private m_name As String
        Private m_note As String
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
            With Me
                .m_group = New LinkFinancialType(-1)
            End With
        End Sub
        Protected Overloads Overrides Sub Construct(ByVal dr As System.Data.DataRow, ByVal aliasPrefix As String)
            MyBase.Construct(dr, aliasPrefix)
            With Me
                ' group 
                If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_group") _
                AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_group") Then
                    .m_group = New LinkFinancialType(CInt(dr(aliasPrefix & Me.Prefix & "_group")))
                End If
                ' name 
                If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_name") _
                AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_name") Then
                    .m_name = CStr(dr(aliasPrefix & Me.Prefix & "_name"))
                End If
                ' note
                If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_note") _
                AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_note") Then
                    .m_note = CStr(dr(aliasPrefix & Me.Prefix & "_note"))
                End If
            End With
        End Sub
#End Region

#Region "Properties"
        Public Property FinancialStatementItemCollection() As FinancialStatementItemCollection            Get                Return m_FinancialStatementItemcollection            End Get            Set(ByVal Value As FinancialStatementItemCollection)                m_FinancialStatementItemcollection = Value            End Set        End Property

        Public Property Name() As String Implements IHasName.Name
            Get
                Return m_name
            End Get
            Set(ByVal Value As String)
                m_name = Value
                OnTabPageTextChanged(Me, New EventArgs)
            End Set
        End Property
        Public Property Group() As CodeDescription
            Get
                Return m_group
            End Get
            Set(ByVal Value As CodeDescription)
                m_group = CType(Value, LinkFinancialType)
            End Set
        End Property
        Public Property Note() As String
            Get
                Return m_note
            End Get
            Set(ByVal Value As String)
                m_note = Value
            End Set
        End Property
#End Region

#Region " Overrides Properties "
        Public Overrides ReadOnly Property ClassName() As String
            Get
                Return "LinkFinancialStatement"
            End Get
        End Property
        Public Overrides ReadOnly Property DetailPanelTitle() As String
            Get
                Return "${res:Longkong.Pojjaman.BusinessLogic.LinkFinancialStatement.DetailLabel}"
            End Get
        End Property
        Public Overrides ReadOnly Property DetailPanelIcon() As String
            Get
                Return "Icons.16x16.LinkFinancialStatement"
            End Get
        End Property
        Public Overrides ReadOnly Property ListPanelIcon() As String
            Get
                Return "Icons.16x16.LinkFinancialStatement"
            End Get
        End Property
        Public Overrides ReadOnly Property ListPanelTitle() As String
            Get
                Return "${res:Longkong.Pojjaman.BusinessLogic.LinkFinancialStatement.ListLabel}"
            End Get
        End Property
        Public Overrides ReadOnly Property Prefix() As String
            Get
                Return "financial"
            End Get
        End Property
        Public Overrides ReadOnly Property TabPageText() As String
            Get
                Dim tpt As String = Me.StringParserService.Parse(Me.DetailPanelTitle) & " (" & Me.Name & ")"
                If tpt.EndsWith("()") Then
                    tpt = tpt.TrimEnd("()".ToCharArray)
                End If
                Return tpt
            End Get
        End Property
#End Region

#Region "Methods"
        Public Overrides Function ToString() As String
            Return m_name
        End Function
        Public Overloads Overrides Function Save(ByVal currentUserId As Integer) As SaveErrorException
            With Me

            End With
        End Function
#End Region

#Region "Shared"
        Public Shared Sub Populate(ByVal tvGroup As TreeView, ByVal filters() As Filter)
            Dim ds As DataSet = GetLinkFinancialStatementDataset(filters)
            Dim financialTable As DataTable = ds.Tables(0)
            Dim glFormatTable As DataTable = ds.Tables(1)
            Dim currentGroupNode As New TreeNode("")
            Dim currentNode As TreeNode
            For Each row As DataRow In financialTable.Rows
                Dim obj As New LinkFinancialType(CInt(row("financial_group")))
                If obj.Description <> currentGroupNode.Text Then
                    currentGroupNode = tvGroup.Nodes.Add(obj.Description)
                End If

                currentNode = currentGroupNode.Nodes.Add(row("financial_code").ToString & " - " & row("financial_name").ToString)
                currentNode.Tag = New IdValuePair(CInt(row("financial_id")), "LinkID")

            Next
        End Sub
        Public Shared Sub Populate(ByVal tvGroup As TreeView)
            Dim ds As DataSet = GetLinkFinancialStatementDataset()
            Dim financialTable As DataTable = ds.Tables(0)
            Dim glFormatTable As DataTable = ds.Tables(1)
            Dim currentGroupNode As New TreeNode("")
            Dim currentNode As TreeNode
            For Each row As DataRow In financialTable.Rows
                Dim obj As New LinkFinancialType(CInt(row("financial_group")))
                If obj.Description <> currentGroupNode.Text Then
                    currentGroupNode = tvGroup.Nodes.Add(obj.Description)
                End If
                currentNode = currentGroupNode.Nodes.Add(row("financial_code").ToString & " - " & row("financial_name").ToString)
                currentNode.Tag = New IdValuePair(CInt(row("financial_id")), "LinkID")
            Next
        End Sub
        Private Shared Function GetLinkFinancialStatementDataset() As DataSet

            Dim connString As String = RecentCompanies.CurrentCompany.ConnectionString
            Dim ds As DataSet = SqlHelper.ExecuteDataset(connString, CommandType.StoredProcedure, "GetLinkFinancialStatementList")
            Return ds
        End Function
        Private Shared Function GetLinkFinancialStatementDataset(ByVal filters() As Filter) As DataSet
            Dim params() As SqlParameter
            If Not filters Is Nothing AndAlso filters.Length > 0 Then
                ReDim params(filters.Length - 1)
                For i As Integer = 0 To filters.Length - 1
                    params(i) = New SqlParameter("@" & filters(i).Name, filters(i).Value)
                Next
            End If

            Dim connString As String = RecentCompanies.CurrentCompany.ConnectionString
            Dim ds As DataSet = SqlHelper.ExecuteDataset(connString, CommandType.StoredProcedure, "GetLinkFinancialStatementList", params)
            Return ds
        End Function
#End Region

#Region "IPrintableEntity"
        Public Function GetDefaultFormPath() As String Implements IPrintableEntity.GetDefaultFormPath
            Return "C:\Documents and Settings\Administrator\Desktop\Report.dfm"
        End Function
        Public Function GetDefaultForm() As String Implements IPrintableEntity.GetDefaultForm

        End Function
        Public Function GetDocPrintingEntries() As DocPrintingItemCollection Implements IPrintableEntity.GetDocPrintingEntries
            Dim dpiColl As New DocPrintingItemCollection
            Dim dpi As DocPrintingItem

            'For Each fixDpi As DocPrintingItem In Me.FixValueCollection
            '    Select Case fixDpi.Mapping.ToLower
            '        Case "month", "year"
            '            dpiColl.Add(fixDpi)
            '    End Select
            'Next

            Dim i As Integer = 0
            'For Each itemRow As DataRow In Me.DataSet.Tables(0).Rows
            '    'Item.DocDate
            '    dpi = New DocPrintingItem
            '    dpi.Mapping = "Item.DocDate"
            '    dpi.Value = itemRow("docdate")
            '    dpi.DataType = "System.DateTime"
            '    dpi.Row = i + 1
            '    dpi.Table = "Item"
            '    dpiColl.Add(dpi)
            '    i += 1
            'Next
            Return dpiColl
        End Function
#End Region

    End Class
End Namespace
