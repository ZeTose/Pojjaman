Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Data.SqlClient
Imports System.IO
Imports System.ComponentModel
Imports System.Configuration
Imports System.Reflection
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Services
Imports Longkong.Pojjaman.Gui.Components

Namespace Longkong.Pojjaman.BusinessLogic
    Public Class LinkFinancial
        Inherits SimpleBusinessEntityBase
        Implements IHasName

#Region "Members"
        Private m_name As String
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

        Protected Overloads Overrides Sub Construct(ByVal dr As System.Data.DataRow, ByVal aliasPrefix As String)
            MyBase.Construct(dr, aliasPrefix)
            With Me
                If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_name") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_name") Then
                    .m_name = CStr(dr(aliasPrefix & Me.Prefix & "_name"))
                End If
            End With
        End Sub
#End Region

#Region "Properties"
        Public Overrides ReadOnly Property ClassName() As String
            Get
                Return "LinkFinancial"
            End Get
        End Property
        Public Overrides ReadOnly Property DetailPanelTitle() As String
            Get
                Return "${res:Longkong.Pojjaman.BusinessLogic.LinkFinancial.DetailLabel}"
            End Get
        End Property
        Public Overrides ReadOnly Property DetailPanelIcon() As String
            Get
                Return "Icons.16x16.LinkFinancial"
            End Get
        End Property
        Public Overrides ReadOnly Property ListPanelIcon() As String
            Get
                Return "Icons.16x16.LinkFinancial"
            End Get
        End Property
        Public Overrides ReadOnly Property ListPanelTitle() As String
            Get
                Return "${res:Longkong.Pojjaman.BusinessLogic.LinkFinancial.ListLabel}"
            End Get
        End Property
        Public Overrides ReadOnly Property Prefix() As String
            Get
                Return "link"
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
            Dim ds As DataSet = GetLinkFinancialDataset(filters)
            Dim dtType As DataTable = ds.Tables(0)  ' Codedescription
            Dim dtFormat As DataTable = ds.Tables(1)   ' LinkFinancial
            Dim currentGroupNode As New TreeNode("")
            Dim currentNode As TreeNode
            For Each row As DataRow In dtType.Rows
                If row("code_description").ToString <> currentGroupNode.Text Then
                    currentGroupNode = tvGroup.Nodes.Add(row("code_description").ToString)
                    currentGroupNode.Tag = New IdValuePair(CInt(row("code_value")), "reporttype")
                End If
                'currentNode = currentGroupNode.Nodes.Add(row("linkgl_code").ToString & " - " & row("linkgl_name").ToString)
                'currentNode.Tag = New IdValuePair(CInt(row("code_value")), "reporttype")
                Dim childRows As DataRow() = dtFormat.Select("link_reporttype = " & row("code_value").ToString)
                For Each childRow As DataRow In childRows
                    Dim childNode As TreeNode = currentGroupNode.Nodes.Add(childRow("link_code").ToString & " - " & childRow("link_name").ToString)
                    childNode.Tag = New IdValuePair(CInt(childRow("link_id")), "financialformat")
                Next
            Next
        End Sub
        Public Shared Sub Populate(ByVal tvGroup As TreeView)
            Dim ds As DataSet = GetLinkFinancialDataset()
            Dim dtType As DataTable = ds.Tables(0)  ' CodeDescription
            Dim dtFormat As DataTable = ds.Tables(1) ' LinkFinancial
            Dim currentGroupNode As New TreeNode("")
            Dim currentNode As TreeNode
            For Each row As DataRow In dtType.Rows
                If row("code_description").ToString <> currentGroupNode.Text Then
                    currentGroupNode = tvGroup.Nodes.Add(row("code_description").ToString)
                    currentGroupNode.Tag = New IdValuePair(CInt(row("code_value")), "reporttype")
                End If
                'currentNode = currentGroupNode.Nodes.Add(row("linkgl_code").ToString & " - " & row("linkgl_name").ToString)
                'currentNode.Tag = New IdValuePair(CInt(row("code_value")), "reporttype")
                Dim childRows As DataRow() = dtFormat.Select("link_reporttype = " & row("code_value").ToString)
                For Each childRow As DataRow In childRows
                    Dim childNode As TreeNode = currentGroupNode.Nodes.Add(childRow("link_code").ToString & " - " & childRow("link_name").ToString)
                    childNode.Tag = New IdValuePair(CInt(childRow("link_id")), "financialformat")
                Next
            Next
        End Sub
        Private Shared Function GetLinkFinancialDataset() As DataSet

            Dim connString As String = RecentCompanies.CurrentCompany.ConnectionString
            Dim ds As DataSet = SqlHelper.ExecuteDataset(connString, CommandType.StoredProcedure, "GetLinkFinancialList")
            Return ds
        End Function
        Private Shared Function GetLinkFinancialDataset(ByVal filters() As Filter) As DataSet
            Dim params() As SqlParameter
            If Not filters Is Nothing AndAlso filters.Length > 0 Then
                ReDim params(filters.Length - 1)
                For i As Integer = 0 To filters.Length - 1
                    params(i) = New SqlParameter("@" & filters(i).Name, filters(i).Value)
                Next
            End If

            Dim connString As String = RecentCompanies.CurrentCompany.ConnectionString
            Dim ds As DataSet = SqlHelper.ExecuteDataset(connString, CommandType.StoredProcedure, "GetLinkFinancialList", params)
            Return ds
        End Function
#End Region

#Region "IHasName"
        Public Property Name() As String Implements IHasName.Name
            Get
                Return m_name
            End Get
            Set(ByVal Value As String)
                m_name = Value
                OnTabPageTextChanged(Me, New EventArgs)
            End Set
        End Property
#End Region

    End Class
End Namespace