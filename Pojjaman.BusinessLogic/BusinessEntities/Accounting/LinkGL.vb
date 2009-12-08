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
    Public Class LinkGL
        Inherits SimpleBusinessEntityBase
        Implements IHasName, IPrintableEntity

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
                Return "LinkGL"
            End Get
        End Property
        Public Overrides ReadOnly Property DetailPanelTitle() As String
            Get
                Return "${res:Longkong.Pojjaman.BusinessLogic.LinkGL.DetailLabel}"
            End Get
        End Property
        Public Overrides ReadOnly Property DetailPanelIcon() As String
            Get
                Return "Icons.16x16.LinkGL"
            End Get
        End Property
        Public Overrides ReadOnly Property ListPanelIcon() As String
            Get
                Return "Icons.16x16.LinkGL"
            End Get
        End Property
        Public Overrides ReadOnly Property ListPanelTitle() As String
            Get
                Return "${res:Longkong.Pojjaman.BusinessLogic.LinkGL.ListLabel}"
            End Get
        End Property
        Public Overrides ReadOnly Property Prefix() As String
            Get
                Return "linkgl"
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
            Dim ds As DataSet = GetLinkGLDataset(filters)
            Dim linkglTable As DataTable = ds.Tables(0)
            Dim glFormatTable As DataTable = ds.Tables(1)
            Dim currentGroupNode As New TreeNode("")
            Dim currentNode As TreeNode
            For Each row As DataRow In linkglTable.Rows
                If row("linkgl_group").ToString <> currentGroupNode.Text Then
                    currentGroupNode = tvGroup.Nodes.Add(row("linkgl_group").ToString)
                End If
                currentNode = currentGroupNode.Nodes.Add(row("linkgl_code").ToString & " - " & row("linkgl_name").ToString)
                currentNode.Tag = New IdValuePair(CInt(row("linkgl_id")), "linkgl")
                Dim childRows As DataRow() = glFormatTable.Select("glf_linkgl=" & row("linkgl_id").ToString)
                For Each childRow As DataRow In childRows
                    Dim childNode As TreeNode = currentNode.Nodes.Add(childRow("glf_code").ToString & " - " & childRow("glf_name").ToString)
                    childNode.Tag = New IdValuePair(CInt(childRow("glf_id")), "glformat")
                Next
            Next
        End Sub
        Public Shared Sub Populate(ByVal tvGroup As TreeView)
            Dim ds As DataSet = GetLinkGLDataset()
            Dim linkglTable As DataTable = ds.Tables(0)
            Dim glFormatTable As DataTable = ds.Tables(1)
            Dim currentGroupNode As New TreeNode("")
            Dim currentNode As TreeNode
            For Each row As DataRow In linkglTable.Rows
                If row("linkgl_group").ToString <> currentGroupNode.Text Then
                    currentGroupNode = tvGroup.Nodes.Add(row("linkgl_group").ToString)
                End If
                currentNode = currentGroupNode.Nodes.Add(row("linkgl_code").ToString & " - " & row("linkgl_name").ToString)
                currentNode.Tag = New IdValuePair(CInt(row("linkgl_id")), "linkgl")
                Dim childRows As DataRow() = glFormatTable.Select("glf_linkgl=" & row("linkgl_id").ToString)
                For Each childRow As DataRow In childRows
                    Dim childNode As TreeNode = currentNode.Nodes.Add(childRow("glf_code").ToString & " - " & childRow("glf_name").ToString)
                    childNode.Tag = New IdValuePair(CInt(childRow("glf_id")), "glformat")
                Next
            Next
        End Sub
        Private Shared Function GetLinkGLDataset() As DataSet

            Dim connString As String = RecentCompanies.CurrentCompany.ConnectionString
            Dim ds As DataSet = SqlHelper.ExecuteDataset(connString, CommandType.StoredProcedure, "GetLinkGLList")
            Return ds
        End Function
        Private Shared Function GetLinkGLDataset(ByVal filters() As Filter) As DataSet
            Dim params() As SqlParameter
            If Not filters Is Nothing AndAlso filters.Length > 0 Then
                ReDim params(filters.Length - 1)
                For i As Integer = 0 To filters.Length - 1
                    params(i) = New SqlParameter("@" & filters(i).Name, filters(i).Value)
                Next
            End If

            Dim connString As String = RecentCompanies.CurrentCompany.ConnectionString
            Dim ds As DataSet = SqlHelper.ExecuteDataset(connString, CommandType.StoredProcedure, "GetLinkGLList", params)
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

#Region "IPrintableEntity"
        Public Function GetDefaultFormPath() As String Implements IPrintableEntity.GetDefaultFormPath
            Return "RptLinkGL"
        End Function
        Public Function GetDefaultForm() As String Implements IPrintableEntity.GetDefaultForm
            Return "RptLinkGL"
        End Function
        Public Function GetDocPrintingEntries() As DocPrintingItemCollection Implements IPrintableEntity.GetDocPrintingEntries
            Dim dpiColl As New DocPrintingItemCollection
            Dim dpi As DocPrintingItem

            Dim ds As DataSet = GetLinkGLDataset()
            Dim glFormatTable As DataTable = ds.Tables(1)
            Dim indent As String = Space(5)
            Dim n As Integer = 0
            For Each childRow As DataRow In glFormatTable.Rows
                Dim glf As New GLFormat(CInt(childRow("glf_id")))

                dpi = New DocPrintingItem
                dpi.Mapping = "col0"
                dpi.Value = glf.Code
                dpi.DataType = "System.String"
                dpi.Row = n + 1
                dpi.Table = "Item"
                dpi.Font = New Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
                dpiColl.Add(dpi)

                dpi = New DocPrintingItem
                dpi.Mapping = "col1"
                dpi.Value = glf.Name
                dpi.DataType = "System.String"
                dpi.Row = n + 1
                dpi.Table = "Item"
                dpi.Font = New Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
                dpiColl.Add(dpi)

                dpi = New DocPrintingItem
                dpi.Mapping = "col2"
                dpi.Value = glf.AccountBook.Name
                dpi.DataType = "System.String"
                dpi.Row = n + 1
                dpi.Table = "Item"
                dpi.Font = New Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
                dpiColl.Add(dpi)

                dpi = New DocPrintingItem
                dpi.Mapping = "col3"
                dpi.Value = glf.Note
                dpi.DataType = "System.String"
                dpi.Row = n + 1
                dpi.Table = "Item"
                dpi.Font = New Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
                dpiColl.Add(dpi)
                n += 1
                For Each glfi As GLFormatItem In glf.ItemCollection
                    dpi = New DocPrintingItem
                    dpi.Mapping = "col0"
                    dpi.Value = indent & glfi.LineNumber
                    dpi.DataType = "System.String"
                    dpi.Row = n + 1
                    dpi.Table = "Item"
                    dpiColl.Add(dpi)

                    Dim displayName As String = ""
                    Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
                    If glfi.IsDebit Then
                        '"DR. "
                        displayName = myStringParserService.Parse("${res:Global.DebitPrefix}") & glfi.Field.Name
                    Else
                        '"      CR. "
                        displayName = myStringParserService.Parse("${res:Global.CreditPrefix}") & glfi.Field.Name
                    End If

                    dpi = New DocPrintingItem
                    dpi.Mapping = "col1"
                    dpi.Value = indent & displayName
                    dpi.DataType = "System.String"
                    dpi.Row = n + 1
                    dpi.Table = "Item"
                    dpiColl.Add(dpi)

                    Dim acctCode As String = ""
                    Dim acctName As String = ""
                    If Not glfi.Account Is Nothing AndAlso glfi.Account.Originated Then
                        acctCode = glfi.Account.Code
                        acctName = glfi.Account.Name
                    Else
                        If Not glfi.Field Is Nothing And TypeOf glfi.Field Is GeneralAccount Then
                            Dim acct As Account = CType(glfi.Field, GeneralAccount).Account
                            acct = New Account(acct.Code)
                            If Not acct Is Nothing AndAlso acct.Originated Then
                                acctCode = acct.Code
                                acctName = acct.Name & " <" & Me.StringParserService.Parse("${res:Global.Default}") & ">"
                            End If
                        End If
                    End If
                    If glfi.FieldType.Description.ToLower = "dynamic" Or glfi.FieldType.Description.ToLower = "mix" Then
                        acctCode = "-------------"
                        acctName = glfi.FieldDescription
                    End If

                    dpi = New DocPrintingItem
                    dpi.Mapping = "col3"
                    dpi.Value = indent & acctCode
                    dpi.DataType = "System.String"
                    dpi.Row = n + 1
                    dpi.Table = "Item"
                    dpiColl.Add(dpi)

                    dpi = New DocPrintingItem
                    dpi.Mapping = "col4"
                    dpi.Value = indent & acctName
                    dpi.DataType = "System.String"
                    dpi.Row = n + 1
                    dpi.Table = "Item"
                    dpiColl.Add(dpi)

                    dpi = New DocPrintingItem
                    dpi.Mapping = "col2"
                    dpi.Value = indent & glfi.Note
                    dpi.DataType = "System.String"
                    dpi.Row = n + 1
                    dpi.Table = "Item"
                    dpiColl.Add(dpi)

                    n += 1
                Next
            Next

            ''DocDate
            'dpi = New DocPrintingItem
            'dpi.Mapping = "DocDate"
            'dpi.Value = Me.DocDate.ToShortDateString
            'dpi.DataType = "System.DateTime"
            'dpiColl.Add(dpi)

            ''RefCode
            'dpi = New DocPrintingItem
            'dpi.Mapping = "RefCode"
            'dpi.Value = Me.RefDoc.Code
            'dpi.DataType = "System.String"
            'dpiColl.Add(dpi)

            ''RefDate
            'dpi = New DocPrintingItem
            'dpi.Mapping = "RefDate"
            'dpi.Value = Me.RefDoc.Date.ToShortDateString
            'dpi.DataType = "System.DateTime"
            'dpiColl.Add(dpi)

            ''AccountBook
            'dpi = New DocPrintingItem
            'dpi.Mapping = "AccountBook"
            'dpi.Value = Me.AccountBook.Name
            'dpi.DataType = "System.String"
            'dpiColl.Add(dpi)

            ''Note
            'dpi = New DocPrintingItem
            'dpi.Mapping = "Note"
            'dpi.Value = Me.Note
            'dpi.DataType = "System.String"
            ''dpi.PrintingFrequency = DocPrintingItem.Frequency.LastPage
            'dpiColl.Add(dpi)


            'Dim n As Integer = 0
            'For i As Integer = 0 To Me.MaxRowIndex
            '    Dim itemRow As TreeRow = CType(Me.m_itemTable.Rows(i), TreeRow)
            '    If ValidateRow(itemRow) Then
            '        Dim item As New JournalEntryItem
            '        item.CopyFromDataRow(itemRow)
            '        'Item.LineNumber
            '        dpi = New DocPrintingItem
            '        dpi.Mapping = "Item.LineNumber"
            '        dpi.Value = n + 1
            '        dpi.DataType = "System.Int32"
            '        dpi.Row = n + 1
            '        dpi.Table = "Item"
            '        dpiColl.Add(dpi)

            '        'Item.Account
            '        dpi = New DocPrintingItem
            '        dpi.Mapping = "Item.Account"
            '        dpi.Value = item.Account.Name
            '        dpi.DataType = "System.String"
            '        dpi.Row = n + 1
            '        dpi.Table = "Item"
            '        dpiColl.Add(dpi)

            '        If item.IsDebit Then
            '            'Item.Debit
            '            dpi = New DocPrintingItem
            '            dpi.Mapping = "Item.Debit"
            '            dpi.Value = Configuration.FormatToString(item.Amount, DigitConfig.Price)
            '            dpi.DataType = "System.String"
            '            dpi.Row = n + 1
            '            dpi.Table = "Item"
            '            dpiColl.Add(dpi)
            '        Else
            '            ' Item.Credit
            '            dpi = New DocPrintingItem
            '            dpi.Mapping = "Item.Credit"
            '            dpi.Value = Configuration.FormatToString(item.Amount, DigitConfig.Price)
            '            dpi.DataType = "System.String"
            '            dpi.Row = n + 1
            '            dpi.Table = "Item"
            '            dpiColl.Add(dpi)
            '        End If


            '        'Item.Note
            '        dpi = New DocPrintingItem
            '        dpi.Mapping = "Item.Note"
            '        dpi.Value = item.Note
            '        dpi.DataType = "System.String"
            '        dpi.Row = n + 1
            '        dpi.Table = "Item"
            '        dpiColl.Add(dpi)

            '        n += 1
            '    End If
            'Next
            Return dpiColl
        End Function
#End Region

    End Class
End Namespace
