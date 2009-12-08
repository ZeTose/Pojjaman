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
    Public Class LinkForm
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
                Return "linkform"
            End Get
        End Property
        Public Overrides ReadOnly Property DetailPanelTitle() As String
            Get
                Return "${res:Longkong.Pojjaman.BusinessLogic.LinkForm.DetailLabel}"
            End Get
        End Property
        Public Overrides ReadOnly Property DetailPanelIcon() As String
            Get
                Return "Icons.16x16.LinkForm"
            End Get
        End Property
        Public Overrides ReadOnly Property ListPanelIcon() As String
            Get
                Return "Icons.16x16.LinkForm"
            End Get
        End Property
        Public Overrides ReadOnly Property ListPanelTitle() As String
            Get
                Return "${res:Longkong.Pojjaman.BusinessLogic.LinkForm.ListLabel}"
            End Get
        End Property
        Public Overrides ReadOnly Property Prefix() As String
            Get
                Return "form"
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
            Dim ds As DataSet = GetLinkFormDataset(filters)
            Dim linkFormTable As DataTable = ds.Tables(0)
            Dim formFormatTable As DataTable = ds.Tables(1)
            Dim currentGroupNode As New TreeNode("")
            Dim currentNode As TreeNode
            For Each row As DataRow In linkFormTable.Rows
                If row("form_group").ToString <> currentGroupNode.Text Then
                    currentGroupNode = tvGroup.Nodes.Add(row("form_group").ToString)
                End If
                currentNode = currentGroupNode.Nodes.Add(row("form_code").ToString & " - " & row("form_name").ToString)
                currentNode.Tag = New IdValuePair(CInt(row("form_id")), "linkform")
                Dim childRows As DataRow() = formFormatTable.Select("formf_LinkForm=" & row("form_id").ToString)
                For Each childRow As DataRow In childRows
                    Dim childNode As TreeNode = currentNode.Nodes.Add(childRow("formf_code").ToString & " - " & childRow("formf_name").ToString)
                    childNode.Tag = New IdValuePair(CInt(childRow("formf_id")), "formformat")
                Next
            Next
        End Sub
        Public Shared Sub Populate(ByVal tvGroup As TreeView)
            Dim ds As DataSet = GetLinkFormDataset()
            Dim linkFormTable As DataTable = ds.Tables(0)
            Dim formFormatTable As DataTable = ds.Tables(1)
            Dim currentGroupNode As New TreeNode("")
            Dim currentNode As TreeNode
            For Each row As DataRow In linkFormTable.Rows
                If row("form_group").ToString <> currentGroupNode.Text Then
                    currentGroupNode = tvGroup.Nodes.Add(row("form_group").ToString)
                End If
                currentNode = currentGroupNode.Nodes.Add(row("form_code").ToString & " - " & row("form_name").ToString)
                currentNode.Tag = New IdValuePair(CInt(row("form_id")), "linkform")
                Dim childRows As DataRow() = formFormatTable.Select("formf_form=" & row("form_id").ToString)
                For Each childRow As DataRow In childRows
                    Dim childNode As TreeNode = currentNode.Nodes.Add(childRow("formf_code").ToString & " - " & childRow("formf_name").ToString)
                    childNode.Tag = New IdValuePair(CInt(childRow("formf_id")), "formformat")
                Next
            Next
        End Sub
        Private Shared Function GetLinkFormDataset() As DataSet

            Dim connString As String = RecentCompanies.CurrentCompany.ConnectionString
            Dim ds As DataSet = SqlHelper.ExecuteDataset(connString, CommandType.StoredProcedure, "GetLinkFormList")
            Return ds
        End Function
        Private Shared Function GetLinkFormDataset(ByVal filters() As Filter) As DataSet
            Dim params() As SqlParameter
            If Not filters Is Nothing AndAlso filters.Length > 0 Then
                ReDim params(filters.Length - 1)
                For i As Integer = 0 To filters.Length - 1
                    params(i) = New SqlParameter("@" & filters(i).Name, filters(i).Value)
                Next
            End If

            Dim connString As String = RecentCompanies.CurrentCompany.ConnectionString
            Dim ds As DataSet = SqlHelper.ExecuteDataset(connString, CommandType.StoredProcedure, "GetLinkFormList", params)
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
